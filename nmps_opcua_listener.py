r"""
NMPS OPC UA listener
====================

Prints every change of the values that the Distribution, Testing, and Conveyor
stations' library blocks expose over OPC UA (the IThis interface of each block), for example:

    20:41:07.512  Distribution.Ejector.FbStatus           1 (Opened, pushed out (1B1))
    20:41:07.530  Distribution.CycleSeq.MsgCurrentStepId  6 (AC6 Arm to magazine)
    20:41:08.110  Testing.Lift.FbStatus                   1 (Opened, raised (1B1))
    20:41:08.125  Testing.CycleSeq.MsgCurrentStepId       5 (TC5 Raise lift)
    20:41:09.005  Conveyor.Stop1.TrayPresent.Pv           True (tray at Stop 1 (DI02))

The first lines after connecting show the current value of everything that is
ticked; after that, one line per change.

The script takes the addresses of the ticked values from the files EAE writes when
you deploy (IEC61499\bin\Deploy\<controller>\System.<Station>.opcua.xml), so it
does not have to search the controller for them. Run it from the solution folder
(the one with the .sln file), or pass --deploy-file / --dist-deploy-file /
--test-deploy-file / --conv-deploy-file. Deploy again after changing ticks.

    pip install asyncua
    python nmps_opcua_listener.py                            # sim mode, watch all 3 stations
    python nmps_opcua_listener.py --station conveyor         # watch Conveyor only
    python nmps_opcua_listener.py --station testing --url opc.tcp://127.0.0.1:4840
    python nmps_opcua_listener.py --mode lab                 # lab PLCs (PLC_DS, PLC_TS, PLC_CV)
    python nmps_opcua_listener.py --mode lab --user opcuser  # lab PLCs with auth & auto security
    python nmps_opcua_listener.py --all                      # print changes of every exposed value
    python nmps_opcua_listener.py --list                     # list every exposed value (* = watched) and exit
    python nmps_opcua_listener.py --csv log.csv              # also append every change to a CSV file
    python nmps_opcua_listener.py --browse                   # dump each server's whole address space

Default simulation ports expect Distribution on opc.tcp://127.0.0.1:4840, Testing
on opc.tcp://127.0.0.1:4841, and Conveyor on opc.tcp://127.0.0.1:4842 (if only one
station is simulated on the default port, pass `--station <name> --url opc.tcp://127.0.0.1:4840`).
In `--mode lab`, the defaults point to PLC_DS (10.10.215.133:4840), PLC_TS (10.10.215.25:4840),
and PLC_CV (10.10.215.19:4840). Stop with Ctrl+C.
"""

from pathlib import Path

HMI_INTERFACE = "IThis"            # each library block publishes its values below its IThis node
SKIP_VARIABLES = {"QI", "QO", "STATUS"}
NOISY_VARIABLES = {"ElapsedTime"}  # change all the time while a sequence runs; never shown

PUBLISH_INTERVAL_MS = 500          # matches EcoRT min_publishing_interval (500 ms)
KEEPALIVE_COUNT = 10               # keepalive every 5 s (10 * 500 ms)
LIFETIME_COUNT = 120               # 60 s subscription lifetime (< EcoRT max_lifetime 100 s, >= 3 * keepalive)
SAMPLING_INTERVAL_MS = 0           # 0 = as fast as the server can (EcoRT revises to 200 ms)
QUEUE_SIZE = 1000                  # keep every change between two sends instead of only the last
BROWSE_DEPTH = 12                  # how deep to search the address space for IThis nodes
BROWSE_BATCH = 50                  # answers per browse request; small answers are easier on a PLC's memory
READ_BATCH = 50                    # values per read or subscribe request, for the same reason
RECONNECT_DELAY_S = 5
DEPLOY_FILE_PATTERNS = ["IEC61499/bin/Deploy/*/System.*.opcua.xml",
                        "*/IEC61499/bin/Deploy/*/System.*.opcua.xml"]
DEFAULT_CERT_DIR = Path.home() / ".nmps_opcua_cert"

POLICY_NONE = "http://opcfoundation.org/UA/SecurityPolicy#None"
POLICY_BASIC256SHA256 = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256"

# Readable names for some numeric and boolean values (from SE.App2CommonProcess and SE.AppSequence).
LABELS = {
    "FbStatus": {0: "Stopped", 1: "Opened", 2: "Closed", 253: "Unknown"},
    "TransFbStatus": {0: "Stopped", 1: "Opened", 2: "Closed", 5: "Stopping",
                      6: "Opening", 7: "Closing", 253: "Unknown"},
    "CurrentMode": {0: "Auto", 1: "Semi-Auto", 2: "Manual"},
    "SeqState": {0: "Undefined", 1: "Stopped", 2: "Running", 4: "Held", 8: "Completed",
                 16: "Pausing", 32: "Paused"},
}
BOOL_LABELS = {
    "FbFail": {True: "feedback failure", False: "OK"},
}
# Owner bits: 16#8 program, 16#10 operator, 16#4 local (program), 16#40 local (operator).
OWNER_LABELS = {0x04: "Program local", 0x08: "Program remote", 0x0C: "Program local",
                0x10: "Operator", 0x50: "Operator local"}
OWNER_VARIABLES = {"CurrentOwner", "Owner"}

STATIONS = {
    "Distribution": {
        "sim_url": "opc.tcp://127.0.0.1:4840",
        "lab_url": "opc.tcp://10.10.215.133:4840",
        "deploy_filename": "System.Distribution.opcua.xml",
        "watch": {
            "Ejector.FbStatus", "Ejector.CurrentOwner", "Ejector.FbFail",
            "Swivel.FbStatus", "Swivel.CurrentOwner", "Swivel.FbFail",
            "Vacuum.FbStatus", "Vacuum.CurrentOwner", "Vacuum.FbFail",
            "BlowOff.Out",
            "MagazineEmpty.Pv", "DownstreamFree.Pv",
            "ResetSeq.SeqState", "ResetSeq.MsgCurrentStepId",
            "CycleSeq.SeqState", "CycleSeq.MsgCurrentStepId",
        },
        "meanings": {
            "Ejector.FbStatus": {1: "pushed out (1B1)", 2: "retracted (1B2)"},
            "Swivel.FbStatus": {0: "mid-parked", 1: "arm at Testing (3B2)", 2: "arm at magazine (3B1)"},
            "Vacuum.FbStatus": {1: "suction on (2B1)", 2: "suction off"},
            "BlowOff.Out": {1: "blowing", 0: "off"},
            "MagazineEmpty.Pv": {True: "magazine empty (B4)", False: "workpieces left"},
            "DownstreamFree.Pv": {True: "Testing free", False: "Testing busy"},
        },
        "steps": {
            "ResetSeq": {
                1: "RS1 Take over", 2: "RS2 Vacuum off", 3: "RS3 Ejector back",
                4: "RS4 Swivel home (3B1)", 5: "RS5 Swivel off mag",
                6: "RS6 Swivel park stop", 7: "End",
            },
            "CycleSeq": {
                1: "AC1 Take over", 2: "AC2 Wait downstream", 3: "AC3 Check magazine",
                4: "AC4 Eject", 5: "AC5 Ejector back", 6: "AC6 Arm to magazine",
                7: "AC7 Pick up", 8: "AC8 Carry", 9: "AC9 Drop off",
                10: "AC10 Park to mag", 11: "AC11 Park off mag",
                12: "AC12 Park stop", 13: "End",
            },
        },
    },
    "Testing": {
        "sim_url": "opc.tcp://127.0.0.1:4841",
        "lab_url": "opc.tcp://10.10.215.25:4840",
        "deploy_filename": "System.Testing.opcua.xml",
        "watch": {
            "Lift.FbStatus", "Lift.CurrentOwner", "Lift.FbFail",
            "Ejector.FbStatus", "Ejector.CurrentOwner", "Ejector.FbFail",
            "AirSlide.Out",
            "PartAvailable.Pv", "NotBlack.Pv", "HeightOk.Pv", "LightBarrier.Pv",
            "AutoMode.bitState", "AutoRelease.bitState",
            "ResetSeq.SeqState", "ResetSeq.MsgCurrentStepId",
            "CycleSeq.SeqState", "CycleSeq.MsgCurrentStepId",
        },
        "meanings": {
            "Lift.FbStatus": {0: "stopped mid-travel", 1: "raised (1B1)", 2: "lowered (1B2)"},
            "Ejector.FbStatus": {1: "extended (ejecting)", 2: "retracted (2B1)"},
            "AirSlide.Out": {1: "air slide on", 0: "air slide off"},
            "PartAvailable.Pv": {True: "workpiece present", False: "no workpiece"},
            "NotBlack.Pv": {True: "red/metallic (pass color)", False: "black or no reflection"},
            "HeightOk.Pv": {True: "height OK", False: "height bad"},
            "LightBarrier.Pv": {True: "light barrier triggered", False: "light barrier clear"},
            "AutoMode.bitState": {True: "Auto Station 1 ON", False: "Auto Station 1 OFF"},
            "AutoRelease.bitState": {True: "Auto-Release ON", False: "Auto-Release OFF"},
        },
        "steps": {
            "ResetSeq": {
                1: "TR1 Take over", 2: "TR2 Air slide off", 3: "TR3 Lower lift",
                4: "TR4 Clear eject (1 s)", 5: "TR5 Ejector back", 6: "End",
            },
            "CycleSeq": {
                1: "TC1 Take over", 2: "TC2 Ensure bottom", 3: "TC3 Wait part",
                4: "TC4 Check color", 5: "TC5 Raise lift", 6: "TC6 Check height",
                7: "TC7 Pass eject (1 s)", 8: "TC8 Pass retract",
                9: "TC9 Slide wait (2 s)", 10: "TC10 Lower lift",
                11: "TC11 Reject lower", 12: "TC12 Reject eject (1 s)",
                13: "TC13 Reject retract", 14: "TC14 Finish", 15: "End",
            },
        },
    },
    "Conveyor": {
        "sim_url": "opc.tcp://127.0.0.1:4842",
        "lab_url": "opc.tcp://10.10.215.19:4840",
        "deploy_filename": "System.Conveyor.opcua.xml",
        "watch": {
            "RunBelts.bitState",
            "BeltA.Out", "BeltB.Out", "BeltC.Out", "BeltD.Out",
            "Stop1.TrayPresent.Pv", "Stop1.WorkpiecePresent.Pv",
            *(f"Stop{i}.Stopper.Out" for i in range(1, 7)),
            *(f"Stop{i}.PassThrough.bitState" for i in range(1, 7)),
        },
        "meanings": {
            "RunBelts.bitState": {True: "master belts ON", False: "master belts OFF"},
            "BeltA.Out": {1: "Belt A running (pre-S1)", 0: "Belt A stopped"},
            "BeltB.Out": {1: "Belt B running (S1-3)", 0: "Belt B stopped"},
            "BeltC.Out": {1: "Belt C running (pre-S4)", 0: "Belt C stopped"},
            "BeltD.Out": {1: "Belt D running (S4-6)", 0: "Belt D stopped"},
            "Stop1.TrayPresent.Pv": {True: "tray at Stop 1 (DI02)", False: "no tray at Stop 1"},
            "Stop1.WorkpiecePresent.Pv": {True: "workpiece in S1 pocket (DI05)", False: "S1 pocket empty"},
            **{
                f"Stop{i}.Stopper.Out": {1: f"Stop {i} lowered (pass)", 0: f"Stop {i} raised (blocking)"}
                for i in range(1, 7)
            },
            **{
                f"Stop{i}.PassThrough.bitState": {True: "Pass mode", False: "Block mode"}
                for i in range(1, 7)
            },
        },
        "steps": {},
    },
}
STATION_ALIASES = {"distribution": "Distribution", "testing": "Testing", "conveyor": "Conveyor"}
CONTAINER_ROOTS = {"RES0", "Distribution", "Testing", "Conveyor", "Reset", "Cycle"}

# ---------------------------------------------------------------------------
import argparse
import asyncio
import csv
import datetime as dt
import getpass
import logging
import os
import socket
import sys
import xml.etree.ElementTree as ET

from asyncua import Client, ua

log = logging.getLogger("nmps")


def owner_of(path):
    """The station block a value belongs to. The library keeps a block's IThis a few
    levels down (Ejector > valveBaseExt > valveBase > IThis), and its inner parts have
    lower-case names, so take the nearest name above IThis that starts upper-case
    (plus its sub-CAT prefix like Stop1.Stopper when nested inside a sub-CAT)."""
    i = len(path) - 1 - path[::-1].index(HMI_INTERFACE)
    for k in range(i - 1, -1, -1):
        leaf = path[k]
        if leaf[:1].isupper():
            parent = path[k - 1] if k > 0 else ""
            if parent[:1].isupper() and parent not in CONTAINER_ROOTS:
                return f"{parent}.{leaf}"
            return leaf
    return path[i - 1] if i > 0 else "?"


def name_values(found):
    """found: {node: (path above the variable, variable)} -> {node: 'Block.Variable'}.
    A block can hold more than one IThis (its local panel, maintenance part, ...).
    Keep "Block.Variable" for the main one and add the inner part's name to the others."""
    parts = {}
    for node, (path, var) in found.items():
        i = len(path) - 1 - path[::-1].index(HMI_INTERFACE)
        parts[node] = (owner_of(path), path[i - 1] if i > 0 else "?", var)
    counts = {}
    for block, part, var in parts.values():
        counts[(block, var)] = counts.get((block, var), 0) + 1
    names = {}
    for node, (block, part, var) in parts.items():
        leaf = block.rsplit(".", 1)[-1]
        main_part = part == leaf or part[:1].isupper() or part.endswith("Base")
        if counts[(block, var)] > 1 and not main_part:
            names[node] = f"{block}.{part}.{var}"
        else:
            names[node] = f"{block}.{var}"
    return names


def wanted(path, var):
    return HMI_INTERFACE in path and var not in SKIP_VARIABLES and var not in NOISY_VARIABLES


# --- addresses from the deploy file -----------------------------------------------

def find_deploy_file(station, explicit):
    if explicit:
        return Path(explicit)
    expected_name = STATIONS[station]["deploy_filename"]
    for folder in (Path.cwd(), Path(__file__).resolve().parent):  # this folder first, then the script's
        found = {
            p
            for pattern in DEPLOY_FILE_PATTERNS
            for p in folder.glob(pattern)
            if p.name == expected_name
        }
        if found:
            return sorted(found, key=lambda p: -p.stat().st_mtime)[0]
    return None


def read_deploy_file(path):
    """Return (namespace URIs, [(node id text, path above the variable, variable)])."""
    ua_ns = "{http://opcfoundation.org/UA/2011/03/UANodeSet.xsd}"
    root = ET.parse(path).getroot()
    uris = [u.text for u in root.iter(ua_ns + "Uri")]
    entries = []
    for var in root.iter(ua_ns + "UAVariable"):
        address = var.find(f"{ua_ns}Extensions/{ua_ns}Extension/RTAddress")
        if address is None or "Path=" not in (address.text or ""):
            continue
        full = address.text.split("Path=", 1)[1].split(";")[0].split(".")  # drop ";Trigger=..."
        entries.append((var.get("NodeId"), full[:-1], full[-1]))
    return uris, entries


async def values_from_deploy_file(client, path):
    """{node: name} for the ticked values in the deploy file that the server has,
    plus the names it lacks. Returns (None, []) when the file does not fit this server."""
    try:
        uris, entries = read_deploy_file(path)
    except (ET.ParseError, OSError, ValueError) as exc:
        log.warning("cannot read %s (%s)", path, exc)
        return None, []
    server_uris = await client.get_namespace_array()
    found = {}
    for text, above, var in entries:
        if not wanted(above, var):
            continue
        nodeid = ua.NodeId.from_string(text)
        if nodeid.NamespaceIndex:
            uri = uris[nodeid.NamespaceIndex - 1] if nodeid.NamespaceIndex <= len(uris) else None
            if uri not in server_uris:
                log.warning("the server has no namespace %s from %s; is this the right deploy file?", uri, path.name)
                return None, []
            nodeid = ua.NodeId(nodeid.Identifier, server_uris.index(uri), nodeid.NodeIdType)
        found[client.get_node(nodeid)] = (above, var)
    names = name_values(found)
    # check that the server really has them (reading is cheap, browsing is not)
    nodes, missing = list(names), []
    for i in range(0, len(nodes), READ_BATCH):
        batch = nodes[i:i + READ_BATCH]
        params = ua.ReadParameters()
        for node in batch:
            rv = ua.ReadValueId()
            rv.NodeId, rv.AttributeId = node.nodeid, ua.AttributeIds.Value
            params.NodesToRead.append(rv)
        for node, result in zip(batch, await client.uaclient.read(params)):
            if result.StatusCode.value in (ua.StatusCodes.BadNodeIdUnknown, ua.StatusCodes.BadNodeIdInvalid):
                missing.append(names.pop(node))
    if names:
        return names, sorted(missing)
    log.warning("none of the values in %s are on the server; deploy again, or check URL", path.name)
    return None, []


# --- security and authentication (for live lab PLCs) ------------------------------

CLIENT_APP_URI = "urn:eislab:nmps-opcua-listener"

async def ensure_client_cert(cert_dir: Path) -> tuple[Path, Path]:
    """Create a reusable self-signed OPC UA client certificate outside git."""
    cert_dir.mkdir(parents=True, exist_ok=True)
    cert_file = cert_dir / "nmps_client_cert.der"
    key_file = cert_dir / "nmps_client_key.pem"
    if not (cert_file.is_file() and key_file.is_file()):
        from asyncua.crypto.cert_gen import setup_self_signed_certificate
        from cryptography.x509.oid import ExtendedKeyUsageOID

        await setup_self_signed_certificate(
            key_file=key_file,
            cert_file=cert_file,
            app_uri=CLIENT_APP_URI,
            host_name=socket.gethostname(),
            cert_use=[ExtendedKeyUsageOID.CLIENT_AUTH],
            subject_attrs={"commonName": "nmps_opcua_listener", "organizationName": "EISLAB"},
        )
    return cert_file, key_file


def select_security_mode(endpoints, user):
    """Choose ('none' | 'basic256sha256', MessageSecurityMode) from server endpoints."""
    none_eps = [ep for ep in endpoints if ep.SecurityPolicyUri == POLICY_NONE]
    if none_eps:
        if user:
            for ep in none_eps:
                if any(tok.TokenType == ua.UserTokenType.UserName for tok in (ep.UserIdentityTokens or [])):
                    return "none", ua.MessageSecurityMode.None_
        else:
            for ep in none_eps:
                tokens = ep.UserIdentityTokens or []
                if not tokens or any(tok.TokenType == ua.UserTokenType.Anonymous for tok in tokens):
                    return "none", ua.MessageSecurityMode.None_

    basic_eps = [ep for ep in endpoints if ep.SecurityPolicyUri == POLICY_BASIC256SHA256]
    if basic_eps:
        for mode in (ua.MessageSecurityMode.SignAndEncrypt, ua.MessageSecurityMode.Sign):
            if any(ep.SecurityMode == mode for ep in basic_eps):
                return "basic256sha256", mode
        return "basic256sha256", basic_eps[0].SecurityMode

    return "none", ua.MessageSecurityMode.None_


async def build_client(url, security, user, password, cert_dir, station):
    """Build an asyncua Client configured for anonymous/None or Basic256Sha256 auth."""
    policy = security
    mode = ua.MessageSecurityMode.SignAndEncrypt
    if security == "auto":
        probe = Client(url=url, timeout=10)
        endpoints = await probe.connect_and_get_server_endpoints()
        policy, mode = select_security_mode(endpoints, user)
        log.info("[%s] auto-selected OPC UA security %s (%s)", station, policy, mode.name)

    client = Client(url=url, timeout=10)
    client.application_uri = CLIENT_APP_URI
    cert_file = None
    if policy == "basic256sha256":
        from asyncua.crypto.security_policies import SecurityPolicyBasic256Sha256

        cert_file, key_file = await ensure_client_cert(cert_dir)
        await client.set_security(SecurityPolicyBasic256Sha256, str(cert_file), str(key_file), mode=mode)

    if user:
        client.set_user(user)
        if password is not None:
            client.set_password(password)

    return client, cert_file


# --- addresses by searching the server (when there is no deploy file) -------------

NODE_ERRORS = {ua.StatusCodes.BadNodeIdUnknown, ua.StatusCodes.BadNodeIdInvalid,
               ua.StatusCodes.BadUserAccessDenied, ua.StatusCodes.BadNotReadable}


async def browse_children(client, nodeid, where):
    """Children of a node, asked for in small pieces with only the fields we use."""
    desc = ua.BrowseDescription()
    desc.NodeId = nodeid
    desc.BrowseDirection = ua.BrowseDirection.Forward
    desc.ReferenceTypeId = ua.NodeId(ua.ObjectIds.HierarchicalReferences)
    desc.IncludeSubtypes = True
    desc.NodeClassMask = int(ua.NodeClass.Object) | int(ua.NodeClass.Variable)
    desc.ResultMask = int(ua.BrowseResultMask.BrowseName) | int(ua.BrowseResultMask.NodeClass)
    params = ua.BrowseParameters()
    params.NodesToBrowse.append(desc)
    params.RequestedMaxReferencesPerNode = BROWSE_BATCH
    try:
        result = (await client.uaclient.browse(params))[0]
        references = []
        while True:
            result.StatusCode.check()
            references.extend(result.References or [])
            if not result.ContinuationPoint:
                return references
            more = ua.BrowseNextParameters()
            more.ContinuationPoints = [result.ContinuationPoint]
            result = (await client.uaclient.browse_next(more))[0]
    except ua.UaStatusCodeError as exc:
        if exc.code in NODE_ERRORS:
            return []
        raise ConnectionError(f"the server answered {ua.StatusCode(exc.code).name} while browsing {where}") from None


async def find_exposed_values(client):
    """Walk the address space and return {node: 'Block.Variable'} for every
    variable that sits below an IThis node."""
    found = {}

    async def walk(node, path, depth):
        if depth > BROWSE_DEPTH:
            return
        for desc in await browse_children(client, node.nodeid, "/".join(["Objects"] + path)):
            name = desc.BrowseName.Name
            if depth == 0 and name == "Server":
                continue  # the server's own diagnostics, not application data
            child = client.get_node(desc.NodeId)
            if desc.NodeClass == ua.NodeClass.Variable:
                if wanted(path, name):
                    found[child] = (path, name)
                continue
            await walk(child, path + [name], depth + 1)

    await walk(client.nodes.objects, [], 0)
    return name_values(found)


def readable(station, name, value):
    station_cfg = STATIONS[station]
    block, _, variable = name.rpartition(".")
    value = getattr(value, "Value", value)  # VTQ structures carry the value in .Value
    is_bool = isinstance(value, bool)
    is_number = isinstance(value, int) and not is_bool
    words = []
    if variable in OWNER_VARIABLES and is_number:
        text = f"16#{value:X}"
        if value in OWNER_LABELS:
            words.append(OWNER_LABELS[value])
    else:
        text = str(value) if str(value).strip() else "(none)"
        if variable == "MsgCurrentStepId":
            step = str(value).strip()
            steps = station_cfg["steps"].get(block, {})
            if step.isdigit() and int(step) in steps:
                words.append(steps[int(step)])
        elif is_number and value in LABELS.get(variable, {}):
            words.append(LABELS[variable][value])
        elif is_bool and value in BOOL_LABELS.get(variable, {}):
            words.append(BOOL_LABELS[variable][value])
        meaning = station_cfg["meanings"].get(name, {}).get(value)
        if meaning:
            words.append(meaning)
    return text + (f" ({', '.join(words)})" if words else "")


def local_time(stamp):
    if stamp is None:
        return dt.datetime.now()
    if stamp.tzinfo is None:  # OPC UA timestamps are UTC
        stamp = stamp.replace(tzinfo=dt.timezone.utc)
    return stamp.astimezone()


class ChangeHandler:
    """Collects the changes the server sends and prints them in the order they
    happened on the PLC (the server sends them grouped per value)."""

    def __init__(self, station, names, writer):
        self.station, self.names, self.writer = station, names, writer
        self.seen, self.initial, self.changes = set(), [], []
        self.started = False
        self.dead_reason = None

    def datachange_notification(self, node, val, data):
        dv = data.monitored_item.Value
        if val is None and dv.StatusCode.value == ua.StatusCodes.BadWaitingForInitialData:
            return
        stamp = local_time(dv.SourceTimestamp)
        host_stamp = dt.datetime.now().astimezone()
        name = self.names.get(node.nodeid, str(node.nodeid))
        entry = (stamp, host_stamp, name, readable(self.station, name, val))
        if node.nodeid in self.seen:
            self.changes.append(entry)
        else:  # the first notification of each value is its current value
            self.seen.add(node.nodeid)
            self.initial.append(entry)

    def flush(self):
        if self.initial:
            print(f"Current values ({self.station}):", flush=True)
            for entry in sorted(self.initial, key=lambda e: e[2]):
                self.emit(*entry)
            self.initial = []
        if not self.started and self.seen:
            print(f"Changes ({self.station}; Ctrl+C to stop):", flush=True)
            self.started = True
        for entry in sorted(self.changes, key=lambda e: e[0]):
            self.emit(*entry)
        self.changes = []

    def emit(self, stamp, host_stamp, name, text):
        full_name = f"{self.station}.{name}"
        print(f"{stamp:%H:%M:%S.%f}"[:-3] + f"  {full_name:<42} {text}", flush=True)
        if self.writer:
            self.writer.writerow([stamp.isoformat(), host_stamp.isoformat(), self.station, name, text])

    def status_change_notification(self, status):
        code = getattr(status, "Status", status)
        name = getattr(code, "name", str(code))
        log.warning("[%s] subscription status %s", self.station, name)
        if callable(getattr(code, "is_bad", None)) and code.is_bad():
            self.dead_reason = f"subscription {name}"


async def dump_tree(client):
    """Print the server's address space below Objects (to see what the PLC exposes)."""
    async def walk(node, path, depth):
        if depth > BROWSE_DEPTH:
            return
        for desc in await browse_children(client, node.nodeid, "/".join(["Objects"] + path)):
            name = desc.BrowseName.Name
            if depth == 0 and name == "Server":
                continue
            print(f"{'  ' * depth}{name}  [{desc.NodeClass.name}]  {desc.NodeId.to_string()}", flush=True)
            if desc.NodeClass != ua.NodeClass.Variable:
                await walk(client.get_node(desc.NodeId), path + [name], depth + 1)
    await walk(client.nodes.objects, [], 0)


async def run_station(station, url, writer, list_only, browse, show_all, deploy_file,
                      security, user, password, cert_dir):
    watch = STATIONS[station]["watch"]
    while True:
        cert_file = None
        try:
            client, cert_file = await build_client(url, security, user, password, cert_dir, station)
            async with client:
                if browse:
                    print(f"=== {station} ({url}) ===", flush=True)
                    await dump_tree(client)
                    return
                values, missing_on_server = None, []
                if deploy_file:
                    values, missing_on_server = await values_from_deploy_file(client, deploy_file)
                if values is None:
                    log.info("[%s] searching the server for ticked values (this can take a moment)", station)
                    values = await find_exposed_values(client)
                if not values:
                    log.warning("[%s] connected to %s, but found no ticked values below %s. "
                                "Tick them in the OPC-UA server editor, then build and deploy.",
                                station, url, HMI_INTERFACE)
                if missing_on_server:
                    log.warning("[%s] in the deploy file but not on the server (deploy again?): %s",
                                station, ", ".join(missing_on_server))
                if list_only:
                    print(f"=== {station} ({url}) ===", flush=True)
                    for node, name in sorted(values.items(), key=lambda kv: kv[1]):
                        mark = "*" if name in watch else " "
                        print(f"{mark} {station}.{name:<40} {node.nodeid.to_string()}")
                    missing = sorted(watch - set(values.values()))
                    if missing:
                        log.warning("[%s] not found (not ticked, or named differently): %s",
                                    station, ", ".join(missing))
                    elif values:
                        log.info("[%s] all %d values marked * are there", station, len(watch))
                    return
                if not values:
                    return
                if not show_all:
                    values = {node: name for node, name in values.items() if name in watch}
                    if not values:
                        log.warning("[%s] none of the watch values were found; run with --list to see what is exposed",
                                    station)
                        return
                log.info("[%s] connected to %s, watching %d values", station, url, len(values))
                names = {node.nodeid: name for node, name in values.items()}
                handler = ChangeHandler(station, names, writer)
                sub_params = ua.CreateSubscriptionParameters()
                sub_params.RequestedPublishingInterval = PUBLISH_INTERVAL_MS
                sub_params.RequestedMaxKeepAliveCount = KEEPALIVE_COUNT
                sub_params.RequestedLifetimeCount = LIFETIME_COUNT
                sub_params.MaxNotificationsPerPublish = 1000
                sub_params.PublishingEnabled = True
                sub_params.Priority = 0
                sub = await client.create_subscription(sub_params, handler)
                nodes = sorted(values, key=lambda n: values[n])
                for i in range(0, len(nodes), READ_BATCH):
                    batch = nodes[i:i + READ_BATCH]
                    results = await sub.subscribe_data_change(batch, queuesize=QUEUE_SIZE,
                                                              sampling_interval=SAMPLING_INTERVAL_MS)
                    for node, result in zip(batch, results):
                        if isinstance(result, ua.StatusCode):
                            log.warning("[%s] cannot watch %s: %s", station, values[node], result.name)
                while True:  # print what arrived, keep the session alive, notice a dropped connection
                    for _ in range(5):
                        await asyncio.sleep(0.2)
                        handler.flush()
                        if handler.dead_reason:
                            raise ConnectionError(handler.dead_reason)
                    await client.check_connection()
        except (OSError, asyncio.TimeoutError, ua.UaError, ConnectionError) as exc:
            reason = str(exc) or f"{type(exc).__name__} (no answer at this address)"
            is_untrusted = (
                isinstance(exc, ua.UaStatusCodeError) and exc.code == ua.StatusCodes.BadCertificateUntrusted
            ) or "BadCertificateUntrusted" in reason
            if is_untrusted and cert_file:
                log.error("[%s] client certificate was rejected by %s; trust %s on the PLC",
                          station, url, cert_file)
            if list_only or browse:
                log.error("[%s] %s: %s", station, url, reason)
                return
            log.error("[%s] %s: %s, retrying in %ss", station, url, reason, RECONNECT_DELAY_S)
            await asyncio.sleep(RECONNECT_DELAY_S)


def resolve_targets(args, parser):
    """Build per-station connection/deploy settings from CLI arguments."""
    if args.station == "all":
        selected = ["Distribution", "Testing", "Conveyor"]
    elif args.station == "both":
        selected = ["Distribution", "Testing"]
    else:
        selected = [STATION_ALIASES[args.station]]

    if args.url and len(selected) > 1:
        parser.error("--url applies to a single station; pass --station distribution, testing, or conveyor, "
                     "or use --dist-url / --test-url / --conv-url")
    if args.deploy_file and len(selected) > 1:
        parser.error("--deploy-file applies to a single station; pass --station distribution, testing, or conveyor, "
                     "or use --dist-deploy-file / --test-deploy-file / --conv-deploy-file")

    url_key = "sim_url" if args.mode == "sim" else "lab_url"
    url_overrides = {
        "Distribution": args.dist_url or args.url,
        "Testing": args.test_url or args.url,
        "Conveyor": args.conv_url or args.url,
    }
    deploy_overrides = {
        "Distribution": args.dist_deploy_file or args.deploy_file,
        "Testing": args.test_deploy_file or args.deploy_file,
        "Conveyor": args.conv_deploy_file or args.deploy_file,
    }

    targets = []
    for station in selected:
        url = url_overrides[station] or STATIONS[station][url_key]
        explicit_deploy = deploy_overrides[station]
        deploy_file = None if args.browse else find_deploy_file(station, explicit_deploy)
        if deploy_file and not deploy_file.is_file():
            log.error("[%s] no such deploy file: %s", station, deploy_file)
            return None
        targets.append((station, url, deploy_file))
    return targets


async def main():
    parser = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--mode", choices=["sim", "lab"], default="sim",
                        help="target environment: local EAE simulation ('sim') or live lab PLCs ('lab')")
    parser.add_argument("--station", choices=["all", "both", "distribution", "testing", "conveyor"], default="all",
                        help="which station(s) to watch (default all; 'both' watches Distribution and Testing)")
    parser.add_argument("--url", help="explicit OPC UA URL for a single --station")
    parser.add_argument("--dist-url", help="override Distribution OPC UA URL")
    parser.add_argument("--test-url", help="override Testing OPC UA URL")
    parser.add_argument("--conv-url", help="override Conveyor OPC UA URL")
    parser.add_argument("--list", action="store_true", help="list the exposed values and exit")
    parser.add_argument("--browse", action="store_true", help="print every node the server exposes and exit")
    parser.add_argument("--csv", metavar="FILE", help="also append every change to this CSV file")
    parser.add_argument("--all", action="store_true", help="print changes of every exposed value, not only watched ones")
    parser.add_argument("--deploy-file", metavar="FILE",
                        help="explicit .opcua.xml deploy file for a single --station")
    parser.add_argument("--dist-deploy-file", metavar="FILE",
                        help="override Distribution System.Distribution.opcua.xml path")
    parser.add_argument("--test-deploy-file", metavar="FILE",
                        help="override Testing System.Testing.opcua.xml path")
    parser.add_argument("--conv-deploy-file", metavar="FILE",
                        help="override Conveyor System.Conveyor.opcua.xml path")
    parser.add_argument("--security", choices=["auto", "none", "basic256sha256"], default=None,
                        help="OPC UA security policy (default: none in sim mode, auto in lab mode)")
    parser.add_argument("--user", default=os.environ.get("OPCUA_USER"),
                        help="OPC UA username (or set OPCUA_USER)")
    parser.add_argument("--password", default=os.environ.get("OPCUA_PASSWORD"),
                        help="OPC UA password (or set OPCUA_PASSWORD; prompts if --user is set without password)")
    parser.add_argument("--cert-dir", type=Path, default=DEFAULT_CERT_DIR,
                        help=f"directory for auto-generated client certificate (default {DEFAULT_CERT_DIR})")
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s", datefmt="%H:%M:%S")
    logging.getLogger("asyncua").setLevel(logging.CRITICAL)
    logging.getLogger("asyncio").setLevel(logging.CRITICAL)  # Windows prints a traceback when a server hangs up

    targets = resolve_targets(args, parser)
    if targets is None:
        return

    for station, _, deploy_file in targets:
        if deploy_file:
            log.info("[%s] taking the value addresses from %s", station, deploy_file)
        elif not args.browse:
            log.info("[%s] no deploy file found here, so the script will search the server; run it from the "
                     "solution folder or pass --deploy-file if that fails", station)

    security = args.security or ("none" if args.mode == "sim" else "auto")
    password = args.password
    if args.user and password is None:
        password = getpass.getpass(f"OPC UA password for {args.user}: ")

    csv_file = open(args.csv, "a", newline="", buffering=1) if args.csv else None
    writer = csv.writer(csv_file) if csv_file else None
    if writer and csv_file.tell() == 0:
        writer.writerow(["plc_time", "host_time", "station", "value_name", "value"])
    try:
        if args.list or args.browse:
            for station, url, deploy_file in targets:
                await run_station(
                    station, url, writer, args.list, args.browse, args.all,
                    deploy_file, security, args.user, password, args.cert_dir,
                )
        else:
            await asyncio.gather(*(
                run_station(
                    station, url, writer, False, False, args.all,
                    deploy_file, security, args.user, password, args.cert_dir,
                )
                for station, url, deploy_file in targets
            ))
    finally:
        if csv_file:
            csv_file.close()


if __name__ == "__main__":
    try:
        asyncio.run(main())
    except KeyboardInterrupt:
        sys.exit(0)
