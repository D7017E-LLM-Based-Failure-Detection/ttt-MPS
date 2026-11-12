r"""
Sorting OPC UA listener
====================

Prints every change of the values that the Sorting station's library blocks
expose over OPC UA (the IThis interface of each block), for example:

    20:41:07.512  Branch1.FbStatus                 1 (Opened, extended)
    20:41:07.530  CycleSeq.MsgCurrentStepId        6 (Feed)

The first lines after connecting show the current value of everything that is
ticked; after that, one line per change.

The script takes the addresses of the ticked values from the file EAE writes when
you deploy (IEC61499\bin\Deploy\<controller>\System.Sorting_M251.opcua.xml), so it
does not have to search the controller for them. Run it from this package folder or the sorting solution folder, or pass --deploy-file. Deploy again after changing ticks.

    pip install asyncua
    python sorting_opcua_listener.py                  # listen and print changes of the WATCH values
    python sorting_opcua_listener.py --all            # print changes of every exposed value
    python sorting_opcua_listener.py --list           # list every exposed value (* = watched) and exit
    python sorting_opcua_listener.py --csv log.csv    # also append every change to a CSV file
    python sorting_opcua_listener.py --url opc.tcp://127.0.0.1:4841
    python sorting_opcua_listener.py --deploy-file path\to\System.Sorting_M251.opcua.xml
    python sorting_opcua_listener.py --browse         # dump the server's whole address space

Set URL to the Server Port of the Sorting device (device Properties >
OPCUA Stack Configuration > Server configuration), or pass --url.
Stop with Ctrl+C.
"""

URL = "opc.tcp://127.0.0.1:4840"

HMI_INTERFACE = "IThis"            # each library block publishes its values below its IThis node
SKIP_VARIABLES = {"QI", "QO", "STATUS"}
NOISY_VARIABLES = {"ElapsedTime"}  # change all the time while a sequence runs; never shown

# The values printed by default. The library exposes many more; --all shows every one.
WATCH = {'Branch2.FbStatus', 'SlideFull.Pv', 'Cycle.ResetFinished', 'PartAvailable.Pv', 'Metal.Pv', 'Cycle.Route', 'Branch2.CurrentOwner', 'Cycle.SlideFullLamp', 'Cycle.State', 'Conveyor.CurrentOwner', 'Branch1.FbStatus', 'Cycle.StationOccupied', 'Stopper.Out', 'Conveyor.FbStatus', 'Cycle.Fault', 'Cycle.ResetLamp', 'ResetSeq.MsgCurrentStepId', 'NotBlack.Pv', 'Branch1.CurrentOwner', 'Cycle.CycleEnd', 'ResetSeq.SeqState', 'Cycle.StartLamp', 'CycleSeq.MsgCurrentStepId', 'CycleSeq.SeqState'}
PUBLISH_INTERVAL_MS = 50           # how often the server sends changes
SAMPLING_INTERVAL_MS = 0           # 0 = as fast as the server can, so short moves are not missed
QUEUE_SIZE = 1000                  # keep every change between two sends instead of only the last
BROWSE_DEPTH = 12                  # how deep to search the address space for IThis nodes
BROWSE_BATCH = 50                  # answers per browse request; small answers are easier on a PLC's memory
READ_BATCH = 50                    # values per read or subscribe request, for the same reason
RECONNECT_DELAY_S = 5
DEPLOY_FILE_PATTERNS = ["IEC61499/bin/Deploy/*/System.*.opcua.xml",
                        "*/IEC61499/bin/Deploy/*/System.*.opcua.xml"]

# Readable names for some numeric values (from the SE.App2CommonProcess and SE.AppSequence help).
LABELS = {
    "FbStatus": {0: "Stopped", 1: "Opened", 2: "Closed", 253: "Unknown"},
    "TransFbStatus": {0: "Stopped", 1: "Opened", 2: "Closed", 5: "Stopping",
                      6: "Opening", 7: "Closing", 253: "Unknown"},
    "CurrentMode": {0: "Auto", 1: "Semi-Auto", 2: "Manual"},
    "SeqState": {0: "Undefined", 1: "Stopped", 2: "Running", 4: "Held", 8: "Completed",
                 16: "Pausing", 32: "Paused"},
}
# Owner bits: 16#8 program, 16#10 operator, 16#4 local (program), 16#40 local (operator).
OWNER_LABELS = {0x10: "Operator", 0x08: "Program remote", 0x0C: "Program local", 0x50: "Operator local"}
OWNER_VARIABLES = {"CurrentOwner", "Owner"}

# What the library values mean on this station (block names as in the Sorting CAT).
MEANINGS = {'Branch1.FbStatus': {1: 'extended, route to slide one', 2: 'home'}, 'Branch2.FbStatus': {1: 'extended, route to slide two', 2: 'home'}, 'Stopper.Out': {True: 'release command', False: 'hold command'}, 'PartAvailable.Pv': {True: 'part at entrance', False: 'entrance clear'}, 'NotBlack.Pv': {True: 'non-black detected', False: 'black or no part'}, 'Metal.Pv': {True: 'metal detected', False: 'no metal detected'}, 'SlideFull.Pv': {True: 'slide full', False: 'slide clear'}}

# Step numbers that MsgCurrentStepId reports, from each step's TransStepId (next step number).
STEPS = {'CycleSeq': {1: 'Take ownership', 2: 'Check slide', 3: 'Finish transport, wait one second', 4: 'Slide full, acknowledge Start', 5: 'Wait for part', 6: 'Feed', 7: 'Sensing', 8: 'Choose route', 9: 'Extend branch one', 10: 'Release red', 11: 'Extend branch two', 12: 'Release metal', 13: 'Release black', 14: 'Cycle end and home', 15: 'End'}, 'ResetSeq': {1: 'Take ownership', 2: 'Command initial position', 3: 'Wait initial position', 4: 'End'}}

# ---------------------------------------------------------------------------
import argparse
import asyncio
import csv
import datetime as dt
import logging
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

try:
    from asyncua import Client, ua
except ImportError:
    if "--help" in sys.argv or "-h" in sys.argv:
        print(__doc__)
        sys.exit(0)
    sys.exit("Install the listener dependency first: python -m pip install -r requirements.txt")

log = logging.getLogger("sorting")


def owner_of(path):
    """The station block a value belongs to. The library keeps a block's IThis a few
    levels down (Branch1 > valveBaseExt > valveBase > IThis), and its inner parts have
    lower-case names, so take the nearest name above IThis that starts upper-case."""
    i = len(path) - 1 - path[::-1].index(HMI_INTERFACE)
    for name in reversed(path[:i]):
        if name[:1].isupper():
            return name
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
        main_part = part == block or part[:1].isupper() or part.endswith("Base")
        if counts[(block, var)] > 1 and not main_part:
            names[node] = f"{block}.{part}.{var}"
        else:
            names[node] = f"{block}.{var}"
    return names


def wanted(path, var):
    return HMI_INTERFACE in path and var not in SKIP_VARIABLES and var not in NOISY_VARIABLES


# --- addresses from the deploy file -----------------------------------------------

def find_deploy_file(explicit):
    if explicit:
        return Path(explicit)
    for folder in (Path.cwd(), Path(__file__).resolve().parent):  # this folder first, then the script's
        found = {p for pattern in DEPLOY_FILE_PATTERNS for p in folder.glob(pattern)}
        if found:
            # the Sorting controller's file first, then the most recently deployed
            return sorted(found, key=lambda p: ("Sorting" not in p.name, -p.stat().st_mtime))[0]
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
    log.warning("none of the values in %s are on the server; deploy again, or check --url", path.name)
    return None, []


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


def readable(name, value):
    block, _, variable = name.rpartition(".")
    value = getattr(value, "Value", value)  # VTQ structures carry the value in .Value
    is_number = isinstance(value, int) and not isinstance(value, bool)
    words = []
    if variable in OWNER_VARIABLES and is_number:
        text = f"16#{value:X}"
        if value in OWNER_LABELS:
            words.append(OWNER_LABELS[value])
    else:
        text = str(value) if str(value).strip() else "(none)"
        if variable == "MsgCurrentStepId":
            step = str(value).strip()
            if step.isdigit() and int(step) in STEPS.get(block, {}):
                words.append(STEPS[block][int(step)])
        elif is_number and value in LABELS.get(variable, {}):
            words.append(LABELS[variable][value])
        meaning = MEANINGS.get(name, {}).get(value)
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

    def __init__(self, names, writer):
        self.names, self.writer = names, writer
        self.seen, self.initial, self.changes = set(), [], []
        self.started = False

    def datachange_notification(self, node, val, data):
        stamp = local_time(data.monitored_item.Value.SourceTimestamp)
        name = self.names.get(node.nodeid, str(node.nodeid))
        entry = (stamp, name, readable(name, val))
        if node.nodeid in self.seen:
            self.changes.append(entry)
        else:  # the first notification of each value is its current value
            self.seen.add(node.nodeid)
            self.initial.append(entry)

    def flush(self):
        if self.initial:
            print("Current values:", flush=True)
            for entry in sorted(self.initial, key=lambda e: e[1]):
                self.emit(*entry)
            self.initial = []
        if not self.started and self.seen:
            print("Changes (Ctrl+C to stop):", flush=True)
            self.started = True
        for entry in sorted(self.changes, key=lambda e: e[0]):
            self.emit(*entry)
        self.changes = []

    def emit(self, stamp, name, text):
        print(f"{stamp:%H:%M:%S.%f}"[:-3] + f"  {name:<32} {text}", flush=True)
        if self.writer:
            self.writer.writerow([stamp.isoformat(), name, text])

    def status_change_notification(self, status):
        code = getattr(status, "Status", status)
        log.warning("subscription status %s", getattr(code, "name", code))


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


async def run(url, writer, list_only, browse, show_all, deploy_file):
    while True:
        try:
            async with Client(url=url, timeout=10) as client:
                if browse:
                    await dump_tree(client)
                    return
                values, missing_on_server = None, []
                if deploy_file:
                    values, missing_on_server = await values_from_deploy_file(client, deploy_file)
                if values is None:
                    log.info("searching the server for ticked values (this can take a moment)")
                    values = await find_exposed_values(client)
                if not values:
                    log.warning("connected to %s, but found no ticked values below %s. "
                                "Tick them in the OPC-UA server editor, then build and deploy.",
                                url, HMI_INTERFACE)
                if missing_on_server:
                    log.warning("in the deploy file but not on the server (deploy again?): %s",
                                ", ".join(missing_on_server))
                if list_only:
                    for node, name in sorted(values.items(), key=lambda kv: kv[1]):
                        mark = "*" if name in WATCH else " "
                        print(f"{mark} {name:<40} {node.nodeid.to_string()}")
                    missing = sorted(WATCH - set(values.values()))
                    if missing:
                        log.warning("not found (not ticked, or named differently): %s", ", ".join(missing))
                    elif values:
                        log.info("all %d values marked * are there", len(WATCH))
                    return
                if not values:
                    return
                if not show_all:
                    values = {node: name for node, name in values.items() if name in WATCH}
                    if not values:
                        log.warning("none of the WATCH values were found; run with --list to see what is exposed")
                        return
                log.info("connected to %s, watching %d values", url, len(values))
                names = {node.nodeid: name for node, name in values.items()}
                handler = ChangeHandler(names, writer)
                sub = await client.create_subscription(PUBLISH_INTERVAL_MS, handler)
                nodes = sorted(values, key=lambda n: values[n])
                for i in range(0, len(nodes), READ_BATCH):
                    batch = nodes[i:i + READ_BATCH]
                    results = await sub.subscribe_data_change(batch, queuesize=QUEUE_SIZE,
                                                              sampling_interval=SAMPLING_INTERVAL_MS)
                    for node, result in zip(batch, results):
                        if isinstance(result, ua.StatusCode):
                            log.warning("cannot watch %s: %s", values[node], result.name)
                while True:  # print what arrived, keep the session alive, notice a dropped connection
                    for _ in range(5):
                        await asyncio.sleep(0.2)
                        handler.flush()
                    await client.check_connection()
        except (OSError, asyncio.TimeoutError, ua.UaError, ConnectionError) as exc:
            reason = str(exc) or f"{type(exc).__name__} (no answer at this address)"
            if list_only or browse:
                log.error("%s: %s", url, reason)
                return
            log.error("%s: %s, retrying in %ss", url, reason, RECONNECT_DELAY_S)
            await asyncio.sleep(RECONNECT_DELAY_S)


async def main():
    parser = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--url", default=URL, help=f"OPC UA server address (default {URL})")
    parser.add_argument("--list", action="store_true", help="list the exposed values and exit")
    parser.add_argument("--browse", action="store_true", help="print every node the server exposes and exit")
    parser.add_argument("--csv", metavar="FILE", help="also append every change to this CSV file")
    parser.add_argument("--all", action="store_true", help="print changes of every exposed value, not only WATCH")
    parser.add_argument("--deploy-file", metavar="FILE",
                        help="System.Sorting_M251.opcua.xml from IEC61499\\bin\\Deploy (found by itself when run "
                             "from the solution folder)")
    args = parser.parse_args()
    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s", datefmt="%H:%M:%S")
    logging.getLogger("asyncua").setLevel(logging.CRITICAL)
    logging.getLogger("asyncio").setLevel(logging.CRITICAL)  # Windows prints a traceback when a server hangs up

    deploy_file = None if args.browse else find_deploy_file(args.deploy_file)
    if deploy_file and not deploy_file.is_file():
        log.error("no such file: %s", deploy_file)
        return
    if deploy_file:
        log.info("taking the value addresses from %s", deploy_file)
    elif not args.browse:
        log.info("no deploy file found here, so the script will search the server; run it from the "
                 "solution folder or pass --deploy-file if that fails")

    csv_file = open(args.csv, "a", newline="", buffering=1) if args.csv else None
    writer = csv.writer(csv_file) if csv_file else None
    if writer and csv_file.tell() == 0:
        writer.writerow(["time", "value_name", "value"])
    try:
        await run(args.url, writer, args.list, args.browse, args.all, deploy_file)
    finally:
        if csv_file:
            csv_file.close()


if __name__ == "__main__":
    try:
        asyncio.run(main())
    except KeyboardInterrupt:
        sys.exit(0)
