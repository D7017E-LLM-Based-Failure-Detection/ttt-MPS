"""Networks of the version 1 CATs: ControlConsole (complete) and the additions to Distributing (step 1).

ControlConsole: 4 DigitalInput (buttons), 4 DigitalOutput (lamps), basic FB ConsoleIO, EVENTCHAIN 'APP_INIT'.
Distributing, step 1 of docs/version1/distributing.md: Console (ControlConsole), Mode (StationMode),
EVENTCHAIN 'APP_INIT'; the reset sequence is a stub (Mode.DO_RESET -> Mode.RESET_DONE) until
DistributingSequence exists.

Pin IDs of our own types are read from their files; library pins are connected by name. EAE keeps the
skeletons (header, GUID, project entries). Run with the solution CLOSED.

Usage (repository root):
  .venv\\Scripts\\python tools\\v1_networks.py --check
  .venv\\Scripts\\python tools\\v1_networks.py
"""
import hashlib
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
IEC = ROOT / "Flexbridge.FestoMPS400" / "IEC61499"
NS, SE = "Flexbridge.FestoMPS400", "SE.App2CommonProcess"
X = '\n        <Attribute Name="Configuration.Connections.CrossReference" Value="True" />\n      '


def h16(key):
    return hashlib.sha1(key.encode()).hexdigest()[:16].upper()


def pins(path):
    """Pin name -> ID of a type file (events and variables of its interface)."""
    t = path.read_text(encoding="utf-8-sig").replace("\r\n", "\n")
    il = t[t.index("<InterfaceList"):t.index("</InterfaceList>")]
    return {m.group(2): m.group(1) for m in re.finditer(r'ID="([0-9A-F]{16})"\s+Name="(\w+)"', il)}


def read(p):
    """Text with LF line endings (EAE writes CRLF, our tools LF; files can mix both), and whether it had a BOM."""
    raw = p.read_bytes()
    return raw.decode("utf-8-sig").replace("\r\n", "\n"), raw.startswith(b"\xef\xbb\xbf")


def write(p, text, bom, check, what):
    print(f"{'would write' if check else 'write'} {p.relative_to(ROOT)}: {what}")
    if not check:
        p.write_bytes((b"\xef\xbb\xbf" if bom else b"") + text.encode("utf-8"))


def conn(s, d):
    return f'      <Connection Source="{s}" Destination="{d}">{X}</Connection>'


def section(tag, items):
    return f"    <{tag}>\n" + "\n".join(items) + f"\n    </{tag}>\n" if items else ""


def frame(n, x, y, w, h, col, text):
    p = [("BackgroundColor", col), ("TextColor", "Black"), ("Font", "Microsoft Sans Serif, 9.75pt, style=Bold"),
         ("TextAlignment", "TopLeft"), ("MoveStyle", "AnyContained"), ("Text", text), ("NxtLayerIdentifier", "")]
    inner = "".join(f'\n      <Parameter Name="{k}" Value="{v}" />' for k, v in p)
    return f'    <Frame Name="{n}" X="{x}" Y="{y}" Width="{w}" Height="{h}">{inner}\n    </Frame>\n'


def add_subcats(cfg_text, subcats):
    """Insert <SubCAT> lines (name, type, namespace) that are not there yet, before <HMIInterface."""
    new = [f'  <SubCAT Name="{n}" Type="{t}" Namespace="{ns}" UsedInCAT="true" />'
           for n, t, ns in subcats if f'<SubCAT Name="{n}"' not in cfg_text]
    if not new:
        return cfg_text
    i = cfg_text.index("  <HMIInterface")
    return cfg_text[:i] + "\n".join(new) + "\n" + cfg_text[i:]


# ------------------------------------------------------------------------------------------------
# ControlConsole
# ------------------------------------------------------------------------------------------------
BUTTONS = ["Start", "Stop", "Reset", "AutoMan"]
LAMPS = ["StartLamp", "ResetLamp", "Q1Lamp", "Q2Lamp"]
# Child blocks are named by Festo tag. They must not share a name with a pin of the CAT's interface:
# EAE then reports "Ambiguous path DS01.Console.Start.pv" and cannot resolve the symbolic link.
CHILD = {"Start": "S1_Start", "Stop": "S2_Stop", "AutoMan": "S3_AutoMan", "Reset": "S4_Reset",
         "StartLamp": "P1_StartLamp", "ResetLamp": "P2_ResetLamp", "Q1Lamp": "P3_Q1Lamp", "Q2Lamp": "P4_Q2Lamp"}


def console(check):
    fbt, cfg = IEC / "ControlConsole" / "ControlConsole.fbt", IEC / "ControlConsole" / "ControlConsole.cfg"
    io = pins(IEC / "ConsoleIO.fbt")
    cid = lambda pin: h16(f"ControlConsole.{pin}")          # CAT interface pins
    fid = lambda name: h16(f"ControlConsole.fb.{name}")     # blocks in the network

    # interface: BUTTONS out, LAMPS and AUX_LAMPS in
    def ev(name, withs, com):
        w = "".join(f'\n        <With Var="{v}" />' for v in withs)
        return f'      <Event ID="{cid(name)}" Name="{name}" Comment="{com}">{w}\n      </Event>'

    def var(n, t, com):
        return f'      <VarDeclaration ID="{cid(n)}" Name="{n}" Type="{t}" Comment="{com}" />'
    iface = ("  <InterfaceList>\n    <EventInputs>\n"
             + ev("LAMPS", LAMPS[:2], "START and RESET lamps (from StationMode)") + "\n"
             + ev("AUX_LAMPS", LAMPS[2:], "Lamps Q1 and Q2 (from the station sequence)")
             + "\n    </EventInputs>\n    <EventOutputs>\n"
             + ev("BUTTONS", BUTTONS, "Button states changed")
             + "\n    </EventOutputs>\n    <InputVars>\n"
             + "\n".join(var(l, "BOOL", f"{l} on") for l in LAMPS)
             + "\n    </InputVars>\n    <OutputVars>\n"
             + "\n".join(var(b, "BOOL", c) for b, c in zip(BUTTONS, ["START pressed", "STOP pressed (NC inverted)",
                                                                     "RESET pressed", "Key switch position"]))
             + "\n    </OutputVars>\n  </InterfaceList>\n")

    fbs = [f'    <FB ID="{fid("EVENTCHAIN")}" Name="EVENTCHAIN" Type="EVENTCHAIN" x="500" y="450" Namespace="Runtime.Standard">'
           '\n      <Parameter Name="$NAME" Value="\'APP_INIT\'" />\n      <Parameter Name="$PRIO" Value="10" />\n    </FB>',
           f'    <FB ID="{fid("IO")}" Name="IO" Type="ConsoleIO" x="2600" y="1900" Namespace="{NS}" />']
    for k, b in enumerate(BUTTONS):
        fbs.append(f'    <FB ID="{fid(CHILD[b])}" Name="{CHILD[b]}" Type="DigitalInput" x="{500 + 1500 * k}" y="5000" Namespace="{SE}" />')
    for k, l in enumerate(LAMPS):
        fbs.append(f'    <FB ID="{fid(CHILD[l])}" Name="{CHILD[l]}" Type="DigitalOutput" x="{500 + 1500 * k}" y="7600" Namespace="{SE}" />')
    io_pins = [("LAMPS", "Event", 200, 1900), ("AUX_LAMPS", "Event", 200, 1960)] + \
              [(l, "Data", 200, 2020 + 60 * k) for k, l in enumerate(LAMPS)]
    ifc = [f'    <Input ID="{cid(n)}" Name="{n}" x="{x}" y="{y}" Type="{t}" />' for n, t, x, y in io_pins]
    ifc += [f'    <Output ID="{cid("BUTTONS")}" Name="BUTTONS" x="5600" y="1900" Type="Event" />']
    ifc += [f'    <Output ID="{cid(b)}" Name="{b}" x="5600" y="{1960 + 60 * k}" Type="Data" />' for k, b in enumerate(BUTTONS)]
    frames = (frame("FRAME0", 200, 200, 1800, 1300, "AliceBlue", "0 - INITIALIZATION")
              + frame("FRAME5", 2200, 1600, 3000, 2800, "Gainsboro", "5 - LOGICS (ConsoleIO)")
              + frame("FRAME3B", 200, 4600, 6200, 2400, "PeachPuff", "3.B - FROM THE FIELD (buttons, DI08-DI11)")
              + frame("FRAME3A", 200, 7200, 6200, 2600, "PeachPuff", "3.A - TO THE FIELD (lamps, DO08-DO11)"))

    I = lambda pin: f"${fid('IO')}.{io[pin]}"
    evc = [conn(f"${fid('EVENTCHAIN')}.EO", I("INIT")), conn(I("INITO"), f"${fid('EVENTCHAIN')}.ACK")]
    evc += [conn(f"${fid(CHILD[b])}.CNF", I("BTN")) for b in BUTTONS]
    evc += [conn(f"${cid('LAMPS')}", I("LAMPS")), conn(f"${cid('AUX_LAMPS')}", I("AUX_LAMPS")),
            conn(I("BUTTONS"), f"${cid('BUTTONS')}")]
    dac = [conn(f"${fid(CHILD[b])}.Pv", I(f"{b}Pv")) for b in BUTTONS]
    dac += [conn(f"${cid(l)}", I(l)) for l in LAMPS]
    dac += [conn(I(b), f"${cid(b)}") for b in BUTTONS]
    adc = [conn(f"${fid('IO')}.I{l}", f"${fid(CHILD[l])}.ISc") for l in LAMPS]

    net = ("  <FBNetwork>\n" + "\n".join(fbs) + "\n" + "\n".join(ifc) + "\n" + frames
           + section("EventConnections", evc) + section("DataConnections", dac)
           + section("AdapterConnections", adc) + "  </FBNetwork>\n</FBType>\n")
    old, bom = read(fbt)
    head = old[:old.index("<InterfaceList")].rstrip(" ")
    write(fbt, head + iface + net, bom, check, f"{len(fbs)} blocks, {len(evc)} event, {len(dac)} data, {len(adc)} adapter connections")

    c, cbom = read(cfg)
    # drop SubCAT entries of children that no longer exist (renamed), then add the current ones
    c1 = re.sub(r'\n  <SubCAT Name="(\w+)" Type="Digital(?:Input|Output)"[^>]*/>',
                lambda m: m.group(0) if m.group(1) in CHILD.values() else "", c)
    c2 = add_subcats(c1, [(CHILD[b], "DigitalInput", SE) for b in BUTTONS] + [(CHILD[l], "DigitalOutput", SE) for l in LAMPS])
    if c2 != c:
        write(cfg, c2, cbom, check, "SubCAT entries for the 8 children")
    return {n: cid(n) for n in ["LAMPS", "AUX_LAMPS", "BUTTONS"] + LAMPS + BUTTONS}


# ------------------------------------------------------------------------------------------------
# Distributing (steps 1-3): Console, Mode, StationSeq, EjectTimer, IThis, EVENTCHAIN and all their wiring.
# The devices (Ejector, Vacuum, Swivel, MagazineEmpty, DownstreamFree) and the frames stay as they are;
# the blocks below and all connections are rebuilt on every run (same IDs), so the script can be re-run.
# ------------------------------------------------------------------------------------------------
# HMI types (service interface) accept only plain STRING ("incompatible datatype STRING[40]", 2026-11-16); unsized
# STRING in an HMI type carries long texts (the V0 labels showed more than 40 characters).
HMI_IN = [("ModeText", "STRING", "Station mode"), ("StepText", "STRING", "Current step (number and name)"),
          ("Waiting", "BOOL", "Waiting for workpieces (magazine empty)"),
          ("Cycles", "UDINT", "Workpieces handed over since start-up"), ("StepNo", "INT", "Current step number")]
# buttons: (event, variable, type, comment); each click on the HMI fires its own event
HMI_OUT = [("HMI_REQ", "RequestWp", "BOOL", "Button: request one workpiece (stands in for Testing)")]


def station_hmi(check, cat, hmi_in, hmi_out):
    """Interface of IThis (<cat>_HMI): REQ_ST (state for the HMI) in, one event per HMI button out, OPC UA exposure."""
    p = IEC / cat / f"{cat}_HMI.fbt"
    old, bom = read(p)
    keep = {m.group(2): m.group(1) for m in re.finditer(r'ID="([0-9A-F]{16})"\s+Name="(\w+)"', old)}
    hid = lambda pin: keep.get(pin) if pin in ("INIT", "INITO", "QI", "QO", "STATUS") else h16(f"{cat}_HMI.{pin}")

    def ev(name, withs):
        w = "".join(f'\n          <With Var="{v}" />' for v in withs)
        return f'        <Event ID="{hid(name)}" Name="{name}">{w}\n        </Event>'

    def var(n, t, c):
        return f'        <VarDeclaration ID="{hid(n)}" Name="{n}" Type="{t}" Comment="{c}" />'
    il = ("    <InterfaceList>\n      <EventInputs>\n" + ev("INIT", ["QI"]) + "\n" + ev("REQ_ST", [n for n, _t, _c in hmi_in])
          + "\n      </EventInputs>\n      <EventOutputs>\n" + ev("INITO", ["QO", "STATUS"]) + "\n"
          + "\n".join(ev(e, [v]) for e, v, _t, _c in hmi_out) + "\n      </EventOutputs>\n      <InputVars>\n"
          + var("QI", "BOOL", "Input event qualifier") + "\n" + "\n".join(var(*v) for v in hmi_in)
          + "\n      </InputVars>\n      <OutputVars>\n" + var("QO", "BOOL", "Event Output Qualifier") + "\n"
          + var("STATUS", "STRING", "Service Status") + "\n" + "\n".join(var(v, t, c) for _e, v, t, c in hmi_out)
          + "\n      </OutputVars>\n    </InterfaceList>\n")
    new = re.sub(r"(?s)    <InterfaceList>.*?</InterfaceList>\n", lambda m: il, old, count=1)
    if new != old:
        write(p, new, bom, check, "IThis interface: REQ_ST in, " + ", ".join(e for e, _v, _t, _c in hmi_out) + " out")

    # OPC UA: everything exposed; a button variable written over OPC UA fires its event (Trigger=<event>)
    rows = []
    for n, trig in [(n, "") for n, _t, _c in hmi_in] + [(v, f";Trigger={e}") for e, v, _t, _c in hmi_out]:
        rows.append(f'  <OPCUAVariable UID="{hid(n)}" Enabled="false">\n'
                    '    <OPCUAAttribute Name="Exposed" Value="True" Locked="false" AttributeMask="True;True|False;True" />\n'
                    f'    <Extensions>\n      <Extension>\n        <RTAddress>V1;${{VariableFullPath}}{trig}</RTAddress>\n'
                    '      </Extension>\n    </Extensions>\n  </OPCUAVariable>')
    oxml = ('<?xml version="1.0" encoding="utf-8"?>\n<OPCUAObject xmlns:xsd="http://www.w3.org/2001/XMLSchema" '
            'xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">\n' + "\n".join(rows) + "\n</OPCUAObject>\n")
    op = IEC / cat / f"{cat}_HMI.opcua.xml"
    o, obom = read(op)
    if o != oxml:
        write(op, oxml, obom, check, "OPC UA exposure of IThis")
    return {n: hid(n) for n in ["INIT", "INITO", "QI", "REQ_ST"] + [e for e, _v, _t, _c in hmi_out]
            + [n for n, _t, _c in hmi_in] + [v for _e, v, _t, _c in hmi_out]}


def distributing_hmi(check):
    return station_hmi(check, "Distributing", HMI_IN, HMI_OUT)


def workpiece_supply(check):
    """Adapter IWorkpieceSupply, defined from the plug side (the station that needs a workpiece, Testing):
    the plug sends REQ (please hand over a workpiece) and receives CNF (workpiece handed over). No data.
    EAE's template has the opposite orientation and four STRING[15] data; its header and IDs are kept."""
    p = IEC / "IWorkpieceSupply.adp"
    old, bom = read(p)
    ids = {m.group(2): m.group(1) for m in re.finditer(r'ID="([0-9A-F]{16})"\s+Name="(\w+)"', old)}
    head = old[:old.index("<InterfaceList")].rstrip(" ")
    body = (f"""  <InterfaceList>
      <EventInputs>
        <Event ID="{ids.get("CNF", h16("IWorkpieceSupply.CNF"))}" Name="CNF" Comment="To the plug: the workpiece has been handed over" />
      </EventInputs>
      <EventOutputs>
        <Event ID="{ids.get("REQ", h16("IWorkpieceSupply.REQ"))}" Name="REQ" Comment="From the plug: please hand over one workpiece" />
      </EventOutputs>
    </InterfaceList>
    <Service RightInterface="PLUG" LeftInterface="SOCKET">
      <ServiceSequence Name="request_workpiece">
        <ServiceTransaction>
          <InputPrimitive Interface="PLUG" Event="REQ" />
          <OutputPrimitive Interface="SOCKET" Event="REQ" />
        </ServiceTransaction>
        <ServiceTransaction>
          <InputPrimitive Interface="SOCKET" Event="CNF" />
          <OutputPrimitive Interface="PLUG" Event="CNF" />
        </ServiceTransaction>
      </ServiceSequence>
    </Service>
  </AdapterType>
""")
    new = head + body
    if new != old:
        write(p, new, bom, check, "adapter: plug sends REQ, receives CNF")


def distributing(check, con):
    fbt, cfg = IEC / "Distributing" / "Distributing.fbt", IEC / "Distributing" / "Distributing.cfg"
    mode = pins(IEC / "StationMode.fbt")
    seq = pins(IEC / "DistributingSequence.fbt")
    ith = distributing_hmi(check)
    fid = lambda name: h16(f"Distributing.fb.{name}")
    old, bom = read(fbt)
    t = old
    dev = {m.group(2): m.group(1) for m in re.finditer(r'<FB ID="(\w+)" Name="(\w+)" Type="(?:Actuator|Actuator2Op|DigitalInput)"', t)}

    # "Sequence" is not a valid block name in EAE ("Invalid component name", 2026-11-16): the block is
    # StationSeq. The old name stays in the removal list so that a network written with it is cleaned up.
    ours = ["EVENTCHAIN", "Mode", "Console", "StationSeq", "EjectTimer", "IThis", "Sequence"]
    for name in ours:   # remove our blocks (re-added below with the same IDs)
        t = re.sub(rf'(?s)\n    <FB ID="{fid(name)}" [^>]*?(?:/>|>.*?</FB>)', "", t)
    t = re.sub(r"(?s)    <(EventConnections|DataConnections|AdapterConnections)>.*?</\1>\n", "", t)

    fbs = [f'    <FB ID="{fid("EVENTCHAIN")}" Name="EVENTCHAIN" Type="EVENTCHAIN" x="500" y="450" Namespace="Runtime.Standard">'
           '\n      <Parameter Name="$NAME" Value="\'APP_INIT\'" />\n      <Parameter Name="$PRIO" Value="20" />\n    </FB>',
           f'    <FB ID="{fid("IThis")}" Name="IThis" Type="Distributing_HMI" x="3000" y="450" Namespace="{NS}">'
           f'\n      <Parameter Name="${ith["QI"]}" Value="TRUE" />\n    </FB>',
           f'    <FB ID="{fid("Mode")}" Name="Mode" Type="StationMode" x="2500" y="2000" Namespace="{NS}" />',
           f'    <FB ID="{fid("StationSeq")}" Name="StationSeq" Type="DistributingSequence" x="4300" y="1900" Namespace="{NS}" />',
           f'    <FB ID="{fid("EjectTimer")}" Name="EjectTimer" Type="E_DELAY" x="2500" y="3700" Namespace="IEC61499.Standard">'
           '\n      <Parameter Name="$DT" Value="T#500ms" />\n    </FB>',
           f'    <FB ID="{fid("Console")}" Name="Console" Type="ControlConsole" x="2500" y="6600" Namespace="{NS}" />']
    M = lambda pin: f"${fid('Mode')}.{mode[pin]}"
    S = lambda pin: f"${fid('StationSeq')}.{seq[pin]}"
    C = lambda pin: f"${fid('Console')}.{con[pin]}"
    H = lambda pin: f"${fid('IThis')}.{ith[pin]}"
    EC, ET = fid("EVENTCHAIN"), fid("EjectTimer")
    evc = [
        # initialisation chain: Mode -> Sequence -> IThis -> acknowledge
        conn(f"${EC}.EO", M("INIT")), conn(M("INITO"), S("INIT")), conn(S("INITO"), H("INIT")), conn(H("INITO"), f"${EC}.ACK"),
        # console and station mode
        conn(C("BUTTONS"), M("BUTTONS")), conn(M("LAMPS"), C("LAMPS")), conn(S("AUX_LAMPS"), C("AUX_LAMPS")),
        # station mode and sequence
        conn(M("DO_RESET"), S("DO_RESET")), conn(S("RESET_DONE"), M("RESET_DONE")), conn(S("FAULT"), M("FAULT")),
        conn(M("MODE"), S("MODE")),
        # magazine sensor, ejection pulse timer, HMI
        conn(f"${dev['MagazineEmpty']}.CNF", S("MAG")),
        conn(S("TSTART"), f"${ET}.START"), conn(f"${ET}.EO", S("TIMEOUT")),
        conn(S("HMI_ST"), H("REQ_ST")), conn(H("HMI_REQ"), S("REQ_WP")),
        # Testing asks for a workpiece through the socket ISupply (frame 1); the HMI button stays as well
        conn("$ISupply.REQ", S("REQ_WP")), conn(S("WP_DONE"), "$ISupply.CNF"),
    ]
    dac = [conn(C(b), M(b)) for b in ["Start", "Stop", "Reset"]]
    dac += [conn(M(l), C(l)) for l in ["StartLamp", "ResetLamp"]]
    dac += [conn(S(l), C(l)) for l in ["Q1Lamp", "Q2Lamp"]]
    dac += [conn(M("Mode"), S("Mode")), conn(M("Started"), S("Started")),
            conn(f"${dev['MagazineEmpty']}.Pv", S("MagEmptyPv"))]
    dac += [conn(S(n), H(n)) for n, _t, _c in HMI_IN]
    adc = [conn(f"${fid('StationSeq')}.{plug}", f"${dev[d]}.ISc")
           for plug, d in [("IEjector", "Ejector"), ("IVacuum", "Vacuum"), ("ISwivel", "Swivel")]]

    # interface: the socket ISupply (frame 1, functional input interface), terminated inside the CAT
    socket = ('  <InterfaceList>\n    <Sockets>\n      <AdapterDeclaration Name="ISupply" Type="IWorkpieceSupply" '
              f'Namespace="{NS}" x="600" y="2200" />\n    </Sockets>\n  </InterfaceList>\n')
    t = re.sub(r"(?s)  <InterfaceList />\n|  <InterfaceList>.*?</InterfaceList>\n", lambda m: socket, t, count=1)

    last_fb = list(re.finditer(r"    <FB [^\n]*(?:\n      <Parameter[^\n]*)*(?:\n    </FB>)?\n", t))[-1]
    t = t[:last_fb.end()] + "\n".join(fbs) + "\n" + t[last_fb.end():]
    t = t.replace("  </FBNetwork>", section("EventConnections", evc) + section("DataConnections", dac)
                  + section("AdapterConnections", adc) + "  </FBNetwork>")
    write(fbt, t, bom, check, f"{len(fbs)} logic blocks, {len(evc)} event, {len(dac)} data, {len(adc)} adapter connections")

    c, cbom = read(cfg)
    c2 = add_subcats(c, [("Console", "ControlConsole", NS)])
    # IThis is part of the network: the CAT definition must say so (lesson from version 0)
    if 'UsedInCAT="true">' not in c2.split("<HMIInterface", 1)[1].split("\n", 1)[0]:
        c2 = re.sub(r'(<HMIInterface Name="IThis"[^>]*?)\s*>', r'\1 UsedInCAT="true">', c2, count=1)
    if c2 != c:
        write(cfg, c2, cbom, check, "SubCAT Console, IThis UsedInCAT")


# ------------------------------------------------------------------------------------------------
# Station symbols sDefault (elements as in IOTest16): one builder for all stations
# ------------------------------------------------------------------------------------------------
def distributing_symbol(check):
    station_symbol(check, "Distributing", [
        ("text", "txtTitle", "Distributing station", 8, 8, 14),
        ("text", "txtMode", "Mode", 8, 48), ("label", "lblMode", "ModeText", 90, 44),
        ("text", "txtStep", "Step", 8, 84), ("label", "lblStep", "StepText", 90, 80),
        ("led", "ledWaiting", "Waiting", 8, 116), ("text", "txtWaiting", "Magazine empty, waiting", 48, 122),
        ("button", "btnRequest", "RequestWp", 8, 156), ("text", "txtRequest", "Request one workpiece (each click = one)", 90, 160),
    ], (440, 200), "Station overview: mode, step, waiting lamp, and a button that requests one workpiece.",
        "DistributingSequence", HMI_IN, HMI_OUT)


def station_symbol(check, cat, elements, size, summary, seq_type, hmi_in, hmi_out):
    hmi = ROOT / "Flexbridge.FestoMPS400" / "HMI" / cat
    sns = f"{NS}.Symbols.{cat}"
    decl, ctors, body, shapes, fields = [], [], [], [], []

    def text(name, txt, x, y, size=10):
        ctors.append(f"\t\t\tthis.{name} = new NxtControl.GuiFramework.FreeText();")
        body.extend([f"\t\t\tthis.{name}.Color = new NxtControl.Drawing.Color(\"LabelTextColor\");",
                     f"\t\t\tthis.{name}.Font = new NxtControl.Drawing.Font(\"HMI Monospace\", {size}F, System.Drawing.FontStyle.Regular);",
                     f"\t\t\tthis.{name}.Location = new NxtControl.Drawing.PointF({x}D, {y}D);",
                     f"\t\t\tthis.{name}.Name = \"{name}\";", f"\t\t\tthis.{name}.Text = \"{txt}\";"])
        shapes.append(name)
        fields.append(f"\t\tprivate NxtControl.GuiFramework.FreeText {name};")

    def label(name, tag, x, y):
        ctors.append(f"\t\t\tthis.{name} = new System.HMI.Symbols.Base.Label();")
        body.extend([f"\t\t\tthis.{name}.BeginInit();",
                     f"\t\t\tthis.{name}.BorderStyle = System.Windows.Forms.BorderStyle.None;",
                     f"\t\t\tthis.{name}.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, {x}D, {y}D);",
                     f"\t\t\tthis.{name}.Font = new NxtControl.Drawing.Font(\"Arial\", 10F, System.Drawing.FontStyle.Regular);",
                     f"\t\t\tthis.{name}.FontScale = false;", f"\t\t\tthis.{name}.IsOnlyInput = true;",
                     f"\t\t\tthis.{name}.Name = \"{name}\";", f"\t\t\tthis.{name}.Pen = new NxtControl.Drawing.Pen(\"LabelPen\");",
                     f"\t\t\tthis.{name}.TagName = \"{tag}\";",
                     f"\t\t\tthis.{name}.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;",
                     f"\t\t\tthis.{name}.TextColor = new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0)));",
                     f"\t\t\tthis.{name}.EndInit();"])
        shapes.append(name)
        fields.append(f"\t\tprivate System.HMI.Symbols.Base.Label {name};")

    def led(name, tag, x, y):
        ids = [f"propertyDictionary{len(decl) + k + 1}" for k in range(3)]
        decl.extend(f"\t\t\tNxtControl.GuiFramework.PropertyDictionary {i} = new NxtControl.GuiFramework.PropertyDictionary();" for i in ids)
        ctors.append(f"\t\t\tthis.{name} = new System.HMI.Symbols.Base.Led<bool>();")
        body.extend([f"\t\t\tthis.{name}.BeginInit();",
                     f"\t\t\tthis.{name}.ColorFrame = new NxtControl.Drawing.Color(\"LedFrameColor\");",
                     f"\t\t\tthis.{name}.DesignMatrix = new NxtControl.Drawing.Matrix2D(2D, 0D, 0D, 2D, {x}D, {y}D);",
                     f"\t\t\tthis.{name}.FrameSize = 33F;", f"\t\t\tthis.{name}.IsOnlyInput = true;",
                     f"\t\t\tthis.{name}.Name = \"{name}\";",
                     f"\t\t\t{ids[1]}.Add(\"Color\", new NxtControl.Drawing.Color(\"LedFalseColor\"));",
                     f"\t\t\t{ids[2]}.Add(\"Color\", new NxtControl.Drawing.Color(\"LedTrueColor\"));",
                     f"\t\t\t{ids[0]}.Add(\"Color\", new NxtControl.Drawing.Color(\"LedFalseColor\"));",
                     f"\t\t\tthis.{name}.Ranges.Clear();",
                     f"\t\t\tthis.{name}.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(false, {ids[1]}));",
                     f"\t\t\tthis.{name}.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(true, {ids[2]}));",
                     f"\t\t\tthis.{name}.Ranges.DefaultPropertyValues = {ids[0]};",
                     f"\t\t\tthis.{name}.TagName = \"{tag}\";", f"\t\t\tthis.{name}.EndInit();"])
        shapes.append(name)
        fields.append(f"\t\tprivate System.HMI.Symbols.Base.Led<bool> {name};")

    def button(name, tag, x, y):
        ctors.append(f"\t\t\tthis.{name} = new System.HMI.Symbols.Base.SwitchButton();")
        body.extend([f"\t\t\tthis.{name}.BeginInit();",
                     f"\t\t\tthis.{name}.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, {x}D, {y}D);",
                     f"\t\t\tthis.{name}.FalseImage = new NxtControl.Drawing.ImageHolder();",
                     f"\t\t\tthis.{name}.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();",
                     f"\t\t\tthis.{name}.Font = new NxtControl.Drawing.Font(\"ButtonFont\");",
                     f"\t\t\tthis.{name}.Name = \"{name}\";", f"\t\t\tthis.{name}.TagName = \"{tag}\";",
                     f"\t\t\tthis.{name}.TrueImage = new NxtControl.Drawing.ImageHolder();",
                     f"\t\t\tthis.{name}.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();",
                     f"\t\t\tthis.{name}.Value = false;", f"\t\t\tthis.{name}.EndInit();"])
        shapes.append(name)
        fields.append(f"\t\tprivate System.HMI.Symbols.Base.SwitchButton {name};")

    make = {"text": text, "label": label, "led": led, "button": button}
    for kind, *args in elements:
        make[kind](*args)

    designer = ("using System;\nusing System.ComponentModel;\nusing System.Collections;\nusing NxtControl.GuiFramework;\n\n"
                f"namespace {sns}\n{{\n\t/// <summary>\n\t/// Summary description for sDefault.\n\t/// </summary>\n"
                "\tpartial class sDefault\n\t{\n\n\t\t#region Component Designer generated code\n\t\t/// <summary>\n"
                "\t\t/// Required method for Designer support - do not modify\n\t\t/// the contents of this method with the code editor.\n"
                "\t\t/// </summary>\n\t\tprivate void InitializeComponent()\n\t\t{\n"
                + "\n".join(decl) + "\n" + "\n".join(ctors) + "\n" + "\n".join(body) + "\n"
                + "\t\t\tthis.Shapes.AddRange(new System.ComponentModel.IComponent[] {\n"
                + ",\n".join(f"\t\t\tthis.{s}" for s in shapes) + "});\n"
                + f"\t\t\tthis.SymbolSize = new System.Drawing.Size({size[0]}, {size[1]});\n\t\t\tthis.Name = \"sDefault\";\n\n\t\t}}\n"
                + "\n".join(fields) + "\n\t\t#endregion\n\t}\n}\n")
    code = (f"using System;\nusing NxtControl.GuiFramework;\n\nnamespace {sns}\n{{\n"
            f"\t/// <summary>\n\t/// {summary}\n"
            f"\t/// Display only; every decision is taken in the controller ({seq_type}).\n\t/// </summary>\n"
            "\tpublic partial class sDefault : NxtControl.GuiFramework.HMISymbol\n\t{\n"
            "\t\tpublic sDefault()\n\t\t{\n\t\t\tInitializeComponent();\n\t\t}\n\t}\n}\n")
    types = {"STRING": "STRING", "BOOL": "BOOL", "UDINT": "UDINT", "INT": "INT"}
    mapping = ('<?xml version="1.0" encoding="utf-8"?>\n<Mapping>\n  <EventInputs>\n'
               f'    <Event Name="REQ_ST">{";".join(n for n, _t, _c in hmi_in)}</Event>\n  </EventInputs>\n'
               '  <EventOutputs>\n' + "\n".join(f'    <Event Name="{e}">{v}</Event>' for e, v, _t, _c in hmi_out)
               + '\n  </EventOutputs>\n'
               '  <Inputs>\n' + "\n".join(f'    <Input Name="{n}" Type="{types[t]}" />' for n, t, _c in hmi_in)
               + '\n  </Inputs>\n  <Outputs>\n' + "\n".join(f'    <Output Name="{v}" Type="{types[t]}" />' for _e, v, t, _c in hmi_out)
               + '\n  </Outputs>\n</Mapping>\n')
    for name, content in [(f"{cat}_sDefault.cnv.Designer.cs", designer), (f"{cat}_sDefault.cnv.cs", code),
                          (f"{cat}_sDefault.cnv.xml", mapping)]:
        p = hmi / name
        old, bom = read(p)
        if old != content:
            write(p, content, bom, check, "station overview symbol")


# ------------------------------------------------------------------------------------------------
# Adapter IWaypoint (station <-> conveyor waypoint), defined from the plug side (the station):
# the plug sends STATE_REQ and RELEASE, and receives TRAY with Tray and Workpiece (docs/version1/testing.md)
# ------------------------------------------------------------------------------------------------
def waypoint(check):
    p = IEC / "IWaypoint.adp"
    old, bom = read(p)
    wid = lambda pin: h16(f"IWaypoint.{pin}")
    head = old[:old.index("<InterfaceList")].rstrip(" ")
    body = (f"""  <InterfaceList>
      <EventInputs>
        <Event ID="{wid("TRAY")}" Name="TRAY" Comment="To the plug: tray state changed (or answer to STATE_REQ)">
          <With Var="Tray" />
          <With Var="Workpiece" />
        </Event>
      </EventInputs>
      <EventOutputs>
        <Event ID="{wid("STATE_REQ")}" Name="STATE_REQ" Comment="From the plug: tell me the tray state" />
        <Event ID="{wid("RELEASE")}" Name="RELEASE" Comment="From the plug: release the tray" />
      </EventOutputs>
      <InputVars>
        <VarDeclaration ID="{wid("Tray")}" Name="Tray" Type="BOOL" Comment="A tray is at the stopper" />
        <VarDeclaration ID="{wid("Workpiece")}" Name="Workpiece" Type="BOOL" Comment="The tray carries a workpiece" />
      </InputVars>
    </InterfaceList>
    <Service RightInterface="PLUG" LeftInterface="SOCKET">
      <ServiceSequence Name="tray">
        <ServiceTransaction>
          <InputPrimitive Interface="PLUG" Event="STATE_REQ" />
          <OutputPrimitive Interface="SOCKET" Event="STATE_REQ" />
        </ServiceTransaction>
        <ServiceTransaction>
          <InputPrimitive Interface="SOCKET" Event="TRAY" Parameters="Tray, Workpiece" />
          <OutputPrimitive Interface="PLUG" Event="TRAY" Parameters="Tray, Workpiece" />
        </ServiceTransaction>
        <ServiceTransaction>
          <InputPrimitive Interface="PLUG" Event="RELEASE" />
          <OutputPrimitive Interface="SOCKET" Event="RELEASE" />
        </ServiceTransaction>
      </ServiceSequence>
    </Service>
  </AdapterType>
""")
    new = head + body
    if new != old:
        write(p, new, bom, check, "adapter: plug sends STATE_REQ and RELEASE, receives TRAY (Tray, Workpiece)")


# ------------------------------------------------------------------------------------------------
# Testing (docs/version1/testing.md): the whole network is made here (EAE made only the empty CAT)
# ------------------------------------------------------------------------------------------------
TS_HMI_IN = [("ModeText", "STRING", "Station mode"), ("StepText", "STRING", "Current step (number and name)"),
             ("Cycles", "UDINT", "Workpieces put on a tray since start-up"),
             ("Rejected", "UDINT", "Workpieces rejected since start-up"), ("StepNo", "INT", "Current step number"),
             ("TrayReleased", "BOOL", "The tray has been released (until the next tray)")]
TS_HMI_OUT = [("HMI_EMPTY", "TrayEmpty", "BOOL", "Stand-in button: an empty tray has arrived at interface 1"),
              ("HMI_FULL", "TrayFull", "BOOL", "Stand-in button: a tray with a workpiece has arrived at interface 1")]
# field children: name -> (type, namespace, x, y); devices in frame 4.A, sensors and console in frame 3
TS_CHILDREN = {
    "Lift": ("Actuator2Op", NS, 6700, 5400), "Ejector": ("Actuator", NS, 8400, 5400),
    "AirSlide": ("DigitalOutput", SE, 10100, 5400),
    "PartAvailable": ("DigitalInput", SE, 2300, 5300), "NotBlack": ("DigitalInput", SE, 3300, 5300),
    "LightBarrier": ("DigitalInput", SE, 4300, 5300), "HeightOk": ("DigitalInput", SE, 5300, 5300),
    "Console": ("ControlConsole", NS, 2500, 6600),
}
TS_FRAMES = [("FRAME0", 200, 200, 1800, 1200, "AliceBlue", "0 - INITIALIZATION"),
             ("FRAME6", 2200, 200, 4000, 1200, "LightPink", "6 - HMI INTERFACE"),
             ("FRAME1", 200, 1600, 1800, 3000, "Cornsilk", "1 - FUNCTIONAL INPUT INTERFACE"),
             ("FRAME5", 2200, 1600, 4000, 3000, "Gainsboro", "5 - LOGICS"),
             ("FRAME2", 6400, 1600, 1800, 3000, "Cornsilk", "2 - FUNCTIONAL OUTPUT INTERFACE (ISupply to Distributing, IWaypoint to the conveyor)"),
             ("FRAME3", 2200, 4800, 4000, 3000, "PeachPuff", "3 - FIELD INTERFACE (3.B FROM THE FIELD: sensors, console)"),
             ("FRAME4", 6400, 4800, 5500, 3400, "Honeydew", "4 - CHILDREN"),
             ("FRAME4A", 6500, 5100, 5300, 3000, "DarkSeaGreen", "4.A - TYPICALS (one device CAT per Festo device)")]


def testing(check, con):
    fbt, cfg = IEC / "Testing" / "Testing.fbt", IEC / "Testing" / "Testing.cfg"
    mode = pins(IEC / "StationMode.fbt")
    seq = pins(IEC / "TestingSequence.fbt")
    ith = station_hmi(check, "Testing", TS_HMI_IN, TS_HMI_OUT)
    fid = lambda name: h16(f"Testing.fb.{name}")
    old, bom = read(fbt)
    t = old.replace("  <FBNetwork />\n", "  <FBNetwork>\n  </FBNetwork>\n")

    # field children: added once (EAE keeps their positions afterwards)
    have = set(re.findall(r'<FB ID="\w+"(?: UID="\w+")? Name="(\w+)"', t))
    kids = [f'    <FB ID="{fid(n)}" Name="{n}" Type="{ty}" x="{x}" y="{y}" Namespace="{ns}" />'
            for n, (ty, ns, x, y) in TS_CHILDREN.items() if n not in have]
    dev = {n: fid(n) for n in TS_CHILDREN}

    # logic blocks and all connections: rebuilt on every run (same IDs)
    ours = ["EVENTCHAIN", "Mode", "StationSeq", "EjectTimer", "SlideTimer", "IThis"]
    for name in ours:
        t = re.sub(rf'(?s)\n    <FB ID="{fid(name)}" [^>]*?(?:/>|>.*?</FB>)', "", t)
    t = re.sub(r"(?s)    <(EventConnections|DataConnections|AdapterConnections)>.*?</\1>\n", "", t)
    logic = [f'    <FB ID="{fid("EVENTCHAIN")}" Name="EVENTCHAIN" Type="EVENTCHAIN" x="500" y="450" Namespace="Runtime.Standard">'
             '\n      <Parameter Name="$NAME" Value="\'APP_INIT\'" />\n      <Parameter Name="$PRIO" Value="20" />\n    </FB>',
             f'    <FB ID="{fid("IThis")}" Name="IThis" Type="Testing_HMI" x="3000" y="450" Namespace="{NS}">'
             f'\n      <Parameter Name="${ith["QI"]}" Value="TRUE" />\n    </FB>',
             f'    <FB ID="{fid("Mode")}" Name="Mode" Type="StationMode" x="2500" y="2000" Namespace="{NS}" />',
             f'    <FB ID="{fid("StationSeq")}" Name="StationSeq" Type="TestingSequence" x="4300" y="1900" Namespace="{NS}" />',
             f'    <FB ID="{fid("EjectTimer")}" Name="EjectTimer" Type="E_DELAY" x="2500" y="3700" Namespace="IEC61499.Standard">'
             '\n      <Parameter Name="$DT" Value="T#1s" />\n    </FB>',
             f'    <FB ID="{fid("SlideTimer")}" Name="SlideTimer" Type="E_DELAY" x="3500" y="3700" Namespace="IEC61499.Standard">'
             '\n      <Parameter Name="$DT" Value="T#2s" />\n    </FB>']
    M = lambda pin: f"${fid('Mode')}.{mode[pin]}"
    S = lambda pin: f"${fid('StationSeq')}.{seq[pin]}"
    C = lambda pin: f"${dev['Console']}.{con[pin]}"
    H = lambda pin: f"${fid('IThis')}.{ith[pin]}"
    EC, EJ, SL = fid("EVENTCHAIN"), fid("EjectTimer"), fid("SlideTimer")
    evc = [
        conn(f"${EC}.EO", M("INIT")), conn(M("INITO"), S("INIT")), conn(S("INITO"), H("INIT")), conn(H("INITO"), f"${EC}.ACK"),
        conn(C("BUTTONS"), M("BUTTONS")), conn(M("LAMPS"), C("LAMPS")),
        conn(M("DO_RESET"), S("DO_RESET")), conn(S("RESET_DONE"), M("RESET_DONE")), conn(S("FAULT"), M("FAULT")),
        conn(M("MODE"), S("MODE")),
        conn(f"${dev['NotBlack']}.CNF", S("SENS")), conn(f"${dev['HeightOk']}.CNF", S("SENS")),
        conn(S("TSTART_EJ"), f"${EJ}.START"), conn(f"${EJ}.EO", S("T_EJ")),
        conn(S("TSTART_SL"), f"${SL}.START"), conn(f"${SL}.EO", S("T_SL")),
        conn(S("HMI_ST"), H("REQ_ST")), conn(H("HMI_EMPTY"), S("SIM_EMPTY")), conn(H("HMI_FULL"), S("SIM_FULL")),
        # Distributing (plug ISupply) and the conveyor waypoint at interface 1 (plug IWaypoint)
        conn(S("WP_REQ"), "$ISupply.REQ"), conn("$ISupply.CNF", S("WP_CNF")),
        conn("$IWaypoint.TRAY", S("TRAY")), conn(S("RELEASE"), "$IWaypoint.RELEASE"), conn(S("STATE_REQ"), "$IWaypoint.STATE_REQ"),
    ]
    dac = [conn(C(b), M(b)) for b in ["Start", "Stop", "Reset"]]
    dac += [conn(M(l), C(l)) for l in ["StartLamp", "ResetLamp"]]
    dac += [conn(M("Mode"), S("Mode")), conn(M("Started"), S("Started")),
            conn(f"${dev['NotBlack']}.Pv", S("NotBlackPv")), conn(f"${dev['HeightOk']}.Pv", S("HeightOkPv")),
            conn("$IWaypoint.Tray", S("Tray")), conn("$IWaypoint.Workpiece", S("Workpiece"))]
    dac += [conn(S(n), H(n)) for n, _t, _c in TS_HMI_IN]
    adc = [conn(f"${fid('StationSeq')}.{plug}", f"${dev[d]}.ISc")
           for plug, d in [("ILift", "Lift"), ("IEjector", "Ejector"), ("IAirSlide", "AirSlide")]]

    plugs = ('  <InterfaceList>\n    <Plugs>\n'
             f'      <AdapterDeclaration Name="ISupply" Type="IWorkpieceSupply" Namespace="{NS}" x="7600" y="2200" />\n'
             f'      <AdapterDeclaration Name="IWaypoint" Type="IWaypoint" Namespace="{NS}" x="7600" y="2600" />\n'
             '    </Plugs>\n  </InterfaceList>\n')
    t = re.sub(r"(?s)  <InterfaceList />\n|  <InterfaceList>.*?</InterfaceList>\n", lambda m: plugs, t, count=1)
    if kids:   # new children at the start of the network
        i = t.index("<FBNetwork>\n") + len("<FBNetwork>\n")
        t = t[:i] + "\n".join(kids) + "\n" + t[i:]
    # logic blocks always after the last block, so that every run gives the same file
    last_fb = list(re.finditer(r"    <FB [^\n]*(?:\n      <Parameter[^\n]*)*(?:\n    </FB>)?\n", t))[-1]
    t = t[:last_fb.end()] + "\n".join(logic) + "\n" + t[last_fb.end():]
    if "<Frame " not in t:
        t = t.replace("  </FBNetwork>", "".join(frame(*f) for f in TS_FRAMES) + "  </FBNetwork>")
    t = t.replace("  </FBNetwork>", section("EventConnections", evc) + section("DataConnections", dac)
                  + section("AdapterConnections", adc) + "  </FBNetwork>")
    write(fbt, t, bom, check, f"{len(kids)} new children, {len(logic)} logic blocks, "
                              f"{len(evc)} event, {len(dac)} data, {len(adc)} adapter connections")

    c, cbom = read(cfg)
    c2 = add_subcats(c, [(n, ty, ns) for n, (ty, ns, _x, _y) in TS_CHILDREN.items()])
    if 'UsedInCAT="true">' not in c2.split("<HMIInterface", 1)[1].split("\n", 1)[0]:
        c2 = re.sub(r'(<HMIInterface Name="IThis"[^>]*?)\s*>', r'\1 UsedInCAT="true">', c2, count=1)
    if c2 != c:
        write(cfg, c2, cbom, check, "SubCAT entries for the children, IThis UsedInCAT")

    station_symbol(check, "Testing", [
        ("text", "txtTitle", "Testing station", 8, 8, 14),
        ("text", "txtMode", "Mode", 8, 48), ("label", "lblMode", "ModeText", 90, 44),
        ("text", "txtStep", "Step", 8, 84), ("label", "lblStep", "StepText", 90, 80),
        ("led", "ledReleased", "TrayReleased", 8, 116), ("text", "txtReleased", "Tray released", 48, 122),
        ("button", "btnEmpty", "TrayEmpty", 8, 156), ("text", "txtEmpty", "Empty tray arrives (stand-in for the conveyor)", 90, 160),
        ("button", "btnFull", "TrayFull", 8, 196), ("text", "txtFull", "Tray with workpiece arrives (stand-in)", 90, 200),
    ], (460, 240), "Station overview: mode, step, tray released, and stand-in buttons for the conveyor.",
        "TestingSequence", TS_HMI_IN, TS_HMI_OUT)


def main():
    check = "--check" in sys.argv
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")
    con = console(check)
    workpiece_supply(check)
    distributing(check, con)
    distributing_symbol(check)
    waypoint(check)
    testing(check, con)


if __name__ == "__main__":
    main()
