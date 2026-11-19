"""Content of the version 1 basic FBs, filled into the skeletons EAE created (library Flexbridge.FestoMPS400).

EAE creates each type with its wizard (keeps project registration, GUID, header). This script replaces only
the interface and the BasicFB part, and keeps EAE's IDs for INIT/INITO/QI/QO. Event outputs are emitted only
by ECC actions; ST algorithms only compute (project rule). Design: docs/version1/distributing.md.

Usage (repository root, solution CLOSED):
  .venv\\Scripts\\python tools\\v1_types.py --check     show what would change
  .venv\\Scripts\\python tools\\v1_types.py             write
"""
import hashlib
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
IEC = ROOT / "Flexbridge.FestoMPS400" / "IEC61499"


def h16(key):
    return hashlib.sha1(key.encode()).hexdigest()[:16].upper()


def eae_ids(text):
    return {m.group(2): m.group(1) for m in re.finditer(r'ID="([0-9A-F]{16})"\s+Name="(\w+)"', text)}


class BasicFB:
    """Small writer for a basic FB: interface + internal vars + ECC + algorithms."""

    def __init__(self, name, keep):
        self.name, self.keep = name, keep          # keep: EAE IDs to reuse by pin name
        self.ev_in, self.ev_out, self.v_in, self.v_out, self.v_int = [], [], [], [], []
        self.plugs = []                            # (name, adapter type, namespace)
        self.states, self.trans, self.algs = [], [], []

    def pid(self, pin):
        return self.keep.get(pin) or h16(f"{self.name}.{pin}")

    def interface(self):
        def ev(name, withs, com):
            w = "".join(f'\n        <With Var="{v}" />' for v in withs)
            return f'      <Event ID="{self.pid(name)}" Name="{name}" Comment="{com}">{w}\n      </Event>'

        def var(n, t, com, init=None):
            iv = f' InitialValue="{init}"' if init is not None else ""
            return f'      <VarDeclaration ID="{self.pid(n)}" Name="{n}" Type="{t}"{iv} Comment="{com}" />'
        j = "\n".join
        plugs = ""
        if self.plugs:  # declared without ID, as in the AHU reference (PreHeaterControl)
            plugs = ("    <Plugs>\n" + j(f'      <AdapterDeclaration Name="{n}" Type="{t}" Namespace="{ns}" />'
                                        for n, t, ns in self.plugs) + "\n    </Plugs>\n")
        return (f"  <InterfaceList>\n    <EventInputs>\n{j(ev(*e) for e in self.ev_in)}\n    </EventInputs>\n"
                f"    <EventOutputs>\n{j(ev(*e) for e in self.ev_out)}\n    </EventOutputs>\n"
                f"    <InputVars>\n{j(var(*v) for v in self.v_in)}\n    </InputVars>\n"
                f"    <OutputVars>\n{j(var(*v) for v in self.v_out)}\n    </OutputVars>\n{plugs}  </InterfaceList>\n")

    def body(self):
        iv = "\n".join(f'      <VarDeclaration Name="{n}" Type="{t}"'
                       + (f' InitialValue="{i}"' if i is not None else "") + f' Comment="{c}" />'
                       for n, t, c, i in self.v_int)
        st = []
        for name, x, y, actions, com in self.states:
            acts = "".join(f'\n        <ECAction' + (f' Algorithm="{a}"' if a else "") + (f' Output="{o}"' if o else "") + " />"
                           for a, o in actions)
            c = f' Comment="{com}"' if com else ""
            st.append(f'      <ECState Name="{name}"{c} x="{x}" y="{y}">{acts}\n      </ECState>' if acts
                      else f'      <ECState Name="{name}"{c} x="{x}" y="{y}" />')
        esc = lambda c: c.replace("&", "&amp;").replace("<", "&lt;").replace(">", "&gt;")
        tr = "\n".join(f'      <ECTransition Source="{s}" Destination="{d}" Condition="{esc(c)}" x="{x}" y="{y}" />'
                       for s, d, c, x, y in self.trans)
        al = "\n".join(f'    <Algorithm Name="{n}" Comment="{c}">\n      <ST><![CDATA[{code.strip()}\n]]></ST>\n    </Algorithm>'
                       for n, c, code in self.algs)
        order = ",".join(n for n, _c, _code in self.algs)
        return (f'  <BasicFB>\n    <Attribute Name="FBType.Basic.Algorithm.Order" Value="{order}" />\n'
                f"    <InternalVars>\n{iv}\n    </InternalVars>\n    <ECC>\n" + "\n".join(st) + "\n" + tr
                + f"\n    </ECC>\n{al}\n  </BasicFB>\n</FBType>\n")


# --------------------------------------------------------------------------------------------------
# StationMode: RESET / START / STOP of a station and its START and RESET lamps (same for all stations)
# --------------------------------------------------------------------------------------------------
MODES = "0 = wait for RESET, 1 = resetting, 2 = wait for START, 3 = started"


def station_mode(keep):
    f = BasicFB("StationMode", keep)
    f.ev_in = [("INIT", ["QI"], "Initialisation request"),
               ("BUTTONS", ["Start", "Stop", "Reset"], "Console buttons changed"),
               ("RESET_DONE", [], "The station's reset sequence has finished"),
               ("FAULT", [], "The station's sequence stopped on a device fault")]
    f.ev_out = [("INITO", ["QO"], "Initialisation confirm"),
                ("DO_RESET", [], "Start the station's reset sequence"),
                ("MODE", ["Mode", "Started"], "Station mode changed"),
                ("LAMPS", ["StartLamp", "ResetLamp"], "Lamp states for the console")]
    f.v_in = [("QI", "BOOL", "Input event qualifier"),
              ("Start", "BOOL", "START button pressed"),
              ("Stop", "BOOL", "STOP button pressed (already inverted: TRUE while pressed)"),
              ("Reset", "BOOL", "RESET button pressed")]
    f.v_out = [("QO", "BOOL", "Output event qualifier"),
               ("Mode", "INT", f"Station mode: {MODES}"),
               ("Started", "BOOL", "TRUE while the station is started and accepts requests"),
               ("StartLamp", "BOOL", "START lamp"),
               ("ResetLamp", "BOOL", "RESET lamp")]
    f.v_int = [("PrevStart", "BOOL", "Start at the last BUTTONS event", None),
               ("PrevStop", "BOOL", "Stop at the last BUTTONS event", None),
               ("PrevReset", "BOOL", "Reset at the last BUTTONS event", None),
               ("StartPressed", "BOOL", "Rising edge of Start", None),
               ("StopPressed", "BOOL", "Rising edge of Stop", None),
               ("ResetReleased", "BOOL", "Falling edge of Reset", None)]
    f.algs = [
        ("algInit", "Wait for RESET: RESET lamp on", """
QO := QI;
PrevStart := FALSE; PrevStop := FALSE; PrevReset := FALSE;
StartPressed := FALSE; StopPressed := FALSE; ResetReleased := FALSE;
Mode := 0; Started := FALSE;
StartLamp := FALSE; ResetLamp := TRUE;"""),
        ("algEdges", "Edges of the buttons since the last BUTTONS event", """
StartPressed := Start AND NOT PrevStart;
StopPressed := Stop AND NOT PrevStop;
ResetReleased := PrevReset AND NOT Reset;
PrevStart := Start; PrevStop := Stop; PrevReset := Reset;"""),
        ("algResetting", "Reset sequence running: RESET lamp stays on", """
Mode := 1; Started := FALSE;
StartLamp := FALSE; ResetLamp := TRUE;"""),
        ("algWaitStart", "Wait for START: START lamp on", """
Mode := 2; Started := FALSE;
StartLamp := TRUE; ResetLamp := FALSE;"""),
        ("algStarted", "Started: lamps off", """
Mode := 3; Started := TRUE;
StartLamp := FALSE; ResetLamp := FALSE;"""),
        ("algFault", "Device fault: back to wait for RESET", """
Mode := 0; Started := FALSE;
StartLamp := FALSE; ResetLamp := TRUE;"""),
    ]
    # idle states (one per mode) and short action states; x/y only for the ECC drawing
    f.states = [
        ("START", 300, 200, [], "Initial state"),
        ("INIT_S", 900, 200, [("algInit", "MODE"), (None, "LAMPS"), (None, "INITO")], ""),
        ("W_RESET", 900, 700, [], "Mode 0: wait for RESET"),
        ("E_WR", 300, 700, [("algEdges", None)], ""),
        ("RESETTING_S", 1500, 700, [("algResetting", "MODE"), (None, "LAMPS"), (None, "DO_RESET")], ""),
        ("RESETTING", 1500, 1200, [], "Mode 1: reset sequence running"),
        ("E_RS", 2100, 1200, [("algEdges", None)], ""),
        ("W_START_S", 900, 1700, [("algWaitStart", "MODE"), (None, "LAMPS")], ""),
        ("W_START", 900, 2200, [], "Mode 2: wait for START"),
        ("E_WS", 300, 2200, [("algEdges", None)], ""),
        ("STARTED_S", 1500, 2700, [("algStarted", "MODE"), (None, "LAMPS")], ""),
        ("STARTED", 1500, 3200, [], "Mode 3: started"),
        ("E_ST", 2100, 3200, [("algEdges", None)], ""),
        ("FAULT_S", 2700, 700, [("algFault", "MODE"), (None, "LAMPS")], ""),
    ]
    f.trans = [
        ("START", "INIT_S", "INIT", 600, 150),
        ("INIT_S", "W_RESET", "1", 950, 450),
        ("W_RESET", "E_WR", "BUTTONS", 600, 650),
        ("E_WR", "RESETTING_S", "ResetReleased", 1100, 600),
        ("E_WR", "W_RESET", "NOT ResetReleased", 600, 760),
        ("RESETTING_S", "RESETTING", "1", 1550, 950),
        ("RESETTING", "W_START_S", "RESET_DONE", 1200, 1450),
        ("RESETTING", "FAULT_S", "FAULT", 2100, 950),
        ("RESETTING", "E_RS", "BUTTONS", 1800, 1150),
        ("E_RS", "RESETTING", "1", 1800, 1260),
        ("W_START_S", "W_START", "1", 950, 1950),
        ("W_START", "E_WS", "BUTTONS", 600, 2150),
        ("E_WS", "STARTED_S", "StartPressed", 1100, 2450),
        ("E_WS", "W_START", "NOT StartPressed", 600, 2260),
        ("W_START", "FAULT_S", "FAULT", 1800, 1700),
        ("STARTED_S", "STARTED", "1", 1550, 2950),
        ("STARTED", "E_ST", "BUTTONS", 1800, 3150),
        ("E_ST", "W_START_S", "StopPressed", 1300, 2000),
        ("E_ST", "STARTED", "NOT StopPressed", 1800, 3260),
        ("STARTED", "FAULT_S", "FAULT", 2400, 2000),
        ("FAULT_S", "W_RESET", "1", 1800, 650),
    ]
    return f


# --------------------------------------------------------------------------------------------------
# ConsoleIO: buttons in (from 4 DigitalInput), lamps out (to 4 DigitalOutput through IDevice)
# --------------------------------------------------------------------------------------------------
LAMPS = ["StartLamp", "ResetLamp", "Q1Lamp", "Q2Lamp"]


def console_io(keep):
    f = BasicFB("ConsoleIO", keep)
    f.ev_in = [("INIT", ["QI"], "Initialisation request"),
               ("BTN", ["StartPv", "StopPv", "ResetPv", "AutoManPv"], "A console input changed"),
               ("LAMPS", ["StartLamp", "ResetLamp"], "START and RESET lamps (from StationMode)"),
               ("AUX_LAMPS", ["Q1Lamp", "Q2Lamp"], "Lamps Q1 and Q2 (from the station sequence)")]
    f.ev_out = [("INITO", ["QO"], "Initialisation confirm"),
                ("BUTTONS", ["Start", "Stop", "Reset", "AutoMan"], "Button states")]
    f.v_in = [("QI", "BOOL", "Input event qualifier"),
              ("StartPv", "VTQBOOL", "S1 START button (normally open)"),
              ("StopPv", "VTQBOOL", "S2 STOP button (normally closed)"),
              ("ResetPv", "VTQBOOL", "S4 RESET button (normally open)"),
              ("AutoManPv", "VTQBOOL", "S3 AUTO/MAN key switch"),
              ("StartLamp", "BOOL", "P1 START lamp"), ("ResetLamp", "BOOL", "P2 RESET lamp"),
              ("Q1Lamp", "BOOL", "P3 lamp Q1"), ("Q2Lamp", "BOOL", "P4 lamp Q2")]
    f.v_out = [("QO", "BOOL", "Output event qualifier"),
               ("Start", "BOOL", "START pressed"),
               ("Stop", "BOOL", "STOP pressed (the NC contact is inverted here)"),
               ("Reset", "BOOL", "RESET pressed"),
               ("AutoMan", "BOOL", "Key switch position")]
    f.plugs = [(f"I{l}", "IDevice", "SE.App2CommonProcess") for l in LAMPS]
    f.v_int = [(f"Cur{l}", "BOOL", f"{l} as last commanded", None) for l in LAMPS] \
        + [(f"Ch{l}", "BOOL", f"{l} changed at this event", None) for l in LAMPS] \
        + [(f"Req{l}", "BOOL", f"{l} as requested before INIT", None) for l in LAMPS] \
        + [(f"Synced{l}", "BOOL", f"{l} has received its state while program local", None) for l in LAMPS] \
        + [(f"Tries{l}", "INT", f"Program-local requests sent to {l} after a ready report", None) for l in LAMPS] \
        + [("NeedSel", "BOOL", "The lamp that just reported ready must be switched to program local", None)]

    def lamp_cmd(l, src=None):
        src = src or l
        return f"IF {src} THEN I{l}.Lsp.value := 1; ELSE I{l}.Lsp.value := 0; END_IF;"

    # The start order of the APP_INIT chains is not known (StationMode in Distributing may send LAMPS before
    # this block is initialised). Lamp requests that arrive before INIT are stored, and INIT applies them.
    f.algs = [
        ("algInit", "Apply the lamp states requested so far (program local is selected on CNF_READY)", "QO := QI;\n" + "\n".join(
            f"I{l}.ProgLocalSel := TRUE;\n{lamp_cmd(l, 'Req' + l)}\nCur{l} := Req{l};" for l in LAMPS)),
        ("algStoreLamps", "Before INIT: remember the START and RESET lamp request", "\n".join(
            f"Req{l} := {l};" for l in LAMPS[:2])),
        ("algStoreAux", "Before INIT: remember the Q1 and Q2 lamp request", "\n".join(
            f"Req{l} := {l};" for l in LAMPS[2:])),
        ("algButtons", "Button states from the inputs; STOP is a normally closed contact", """
Start := StartPv.value;
Stop := NOT StopPv.value;
Reset := ResetPv.value;
AutoMan := AutoManPv.value;"""),
        ("algLamps", "START and RESET lamps: command only those that changed", "\n".join(
            f"Ch{l} := {l} <> Cur{l};\nCur{l} := {l};\n{lamp_cmd(l)}" for l in LAMPS[:2])),
        ("algAuxLamps", "Lamps Q1 and Q2: command only those that changed", "\n".join(
            f"Ch{l} := {l} <> Cur{l};\nCur{l} := {l};\n{lamp_cmd(l)}" for l in LAMPS[2:])),
    ] + [
        # A lamp's own initialisation may come after ours: the program-local request and the lamp command
        # sent at our INIT are then lost (seen 2026-11-16: owner "Unknown", RESET lamp dark although
        # requested). On the lamp's ready report, send both again, until the lamp has received its state
        # while program local, at most 3 times (no event storm). After that the owner is left alone, so an
        # operator may take the lamp over from its faceplate.
        (f"algReady{l}", f"{l} reported ready: send owner request and lamp state again until synchronised", f"""
NeedSel := NOT Synced{l} AND Tries{l} < 3;
IF NeedSel THEN
    Tries{l} := Tries{l} + 1;
    I{l}.ProgLocalSel := TRUE;
    {lamp_cmd(l, 'Cur' + l)}
    Synced{l} := I{l}.ProgLocal;
END_IF;""") for l in LAMPS]
    # No REQ_PROGLOCALSEL at INIT: if it reaches a lamp before the lamp's Owner service has initialised,
    # the Owner stores 16#4 (local bit without the Program bit) and keeps it at its own init: owner
    # "Unknown" (SE.App2Base ownerBasic, algReqInit). The request is sent on the lamp's CNF_READY instead.
    init_actions = [("algInit", None)] + [(None, f"I{l}.REQ_CMD") for l in LAMPS] + [(None, "INITO")]
    f.states = [
        ("START", 300, 300, [], "Initial state: not initialised yet, lamp requests are stored"),
        ("PRE_LMP", 100, 50, [("algStoreLamps", None)], ""),
        ("PRE_AUX", 550, 50, [("algStoreAux", None)], ""),
        ("INIT_S", 1000, 100, init_actions, ""),
        ("READY", 1000, 300, [], "Initialised"),
        ("BTN_S", 1000, 500, [("algButtons", "BUTTONS")], ""),
        # START and RESET lamps: send REQ_CMD only for a lamp that changed
        ("LMP_S", 300, 900, [("algLamps", None)], ""),
        ("LMP_START", 900, 900, [(None, "IStartLamp.REQ_CMD")], ""),
        ("LMP_C2", 300, 1300, [], ""),
        ("LMP_RESET", 900, 1300, [(None, "IResetLamp.REQ_CMD")], ""),
        # Q1 and Q2
        ("AUX_S", 1700, 900, [("algAuxLamps", None)], ""),
        ("AUX_Q1", 2300, 900, [(None, "IQ1Lamp.REQ_CMD")], ""),
        ("AUX_C2", 1700, 1300, [], ""),
        ("AUX_Q2", 2300, 1300, [(None, "IQ2Lamp.REQ_CMD")], ""),
    ] + [s for k, l in enumerate(LAMPS) for s in [
        (f"RDY_{l}", 300 + 700 * k, 1800, [(f"algReady{l}", None)], ""),
        (f"SEL_{l}", 300 + 700 * k, 2200, [(None, f"I{l}.REQ_PROGLOCALSEL"), (None, f"I{l}.REQ_CMD")], ""),
    ]]
    f.trans = [
        # not initialised yet: store lamp requests, pass buttons on
        ("START", "INIT_S", "INIT", 650, 150),
        ("START", "PRE_LMP", "LAMPS", 150, 200), ("PRE_LMP", "START", "1", 250, 150),
        ("START", "PRE_AUX", "AUX_LAMPS", 450, 200), ("PRE_AUX", "START", "1", 500, 150),
        ("INIT_S", "READY", "1", 1050, 200),
        # initialised
        ("READY", "INIT_S", "INIT", 1200, 200),
        ("READY", "BTN_S", "BTN", 1050, 400), ("BTN_S", "READY", "1", 1150, 400),
        ("READY", "LMP_S", "LAMPS", 650, 600),
        ("LMP_S", "LMP_START", "ChStartLamp", 600, 850), ("LMP_S", "LMP_C2", "NOT ChStartLamp", 250, 1100),
        ("LMP_START", "LMP_C2", "1", 600, 1100),
        ("LMP_C2", "LMP_RESET", "ChResetLamp", 600, 1250), ("LMP_C2", "READY", "NOT ChResetLamp", 150, 800),
        ("LMP_RESET", "READY", "1", 700, 700),
        ("READY", "AUX_S", "AUX_LAMPS", 1300, 700),
        ("AUX_S", "AUX_Q1", "ChQ1Lamp", 2000, 850), ("AUX_S", "AUX_C2", "NOT ChQ1Lamp", 1700, 1100),
        ("AUX_Q1", "AUX_C2", "1", 2000, 1100),
        ("AUX_C2", "AUX_Q2", "ChQ2Lamp", 2000, 1250), ("AUX_C2", "READY", "NOT ChQ2Lamp", 1300, 1100),
        ("AUX_Q2", "READY", "1", 1500, 750),
    ] + [t for k, l in enumerate(LAMPS) for t in [
        ("READY", f"RDY_{l}", f"I{l}.CNF_READY", 500 + 700 * k, 1500),
        (f"RDY_{l}", f"SEL_{l}", "NeedSel", 350 + 700 * k, 2000),
        (f"RDY_{l}", "READY", "NOT NeedSel", 650 + 700 * k, 1600),
        (f"SEL_{l}", "READY", "1", 700 + 700 * k, 1700),
    ]]
    return f


# --------------------------------------------------------------------------------------------------
# Start-up takeover of two-output devices (Actuator2Op: Distributing swivel, Testing lift)
# --------------------------------------------------------------------------------------------------
def takeover(devs, idle, x0, y0):
    """Take over each device at start-up and command the end position it already reports.

    Why (found 2026-11-17, library devControlBasic in valve2OpLogic): a two-output device starts with setpoint 0
    (stop) and, with both feedbacks monitored, expects neither end position when stopped (FbStop = NOT (open OR
    closed) in Actuator2OpBaseExt). A device resting at an end position (the Testing lift, lowered) therefore
    raises "Detected Feedback Failure" a monitoring time after every start. Commanding the end position it
    reports confirms it, and nothing moves. Program local is requested on the device's CNF_READY (its owner has
    initialised then; see ConsoleIO), at most 3 times. A device between its end positions (Status 0) needs no
    takeover. The reset sequence sets Adp<dev> := TRUE, so the takeover never runs after a reset.

    Returns (algs, states, trans, v_int, init_code, first_state). The caller's START state gets one transition
    per device (CNF_READY before INIT), the idle state reacts to the device events, and the state after INIT
    goes to first_state; the chain over all devices ends in `idle`.
    """
    algs, states, trans, v_int, init = [], [], [], [], []
    nxt = lambda k: f"TK_{devs[k + 1][1:]}" if k + 1 < len(devs) else idle
    for k, d in enumerate(devs):
        n = d[1:]
        x = x0 + 900 * k
        sel = f"NOT Adp{n} AND Rdy{n} AND NOT {d}.ProgLocal AND Try{n} < 3"
        cmd = f"NOT Adp{n} AND Rdy{n} AND {d}.ProgLocal AND ({d}.Status.value = 1 OR {d}.Status.value = 2)"
        v_int += [(f"Rdy{n}", "BOOL", f"{n} has sent CNF_READY: its owner has initialised", None),
                  (f"Adp{n}", "BOOL", f"{n} taken over at start-up, or the reset sequence has run", None),
                  (f"Try{n}", "INT", f"Program-local requests sent to {n} at start-up", None)]
        init.append(f"Adp{n} := FALSE; Try{n} := 0;")
        algs += [(f"algRdy{n}", f"{n} has reported ready", f"Rdy{n} := TRUE;"),
                 (f"algTkSel{n}", f"Start-up: ask {n} for program local", f"{d}.ProgLocalSel := TRUE;\nTry{n} := Try{n} + 1;"),
                 (f"algTkCmd{n}", f"Start-up: command the end position {n} reports (it does not move)",
                  f"{d}.Lsp.value := {d}.Status.value;\nAdp{n} := TRUE;")]
        states += [(f"SR_{n}", x, y0, [(f"algRdy{n}", None)], f"{n} ready before INIT"),
                   (f"TR_{n}", x, y0 + 400, [(f"algRdy{n}", None)], ""),
                   (f"TK_{n}", x, y0 + 800, [], f"Start-up takeover of {n}"),
                   (f"TS_{n}", x - 300, y0 + 1200, [(f"algTkSel{n}", f"{d}.REQ_PROGLOCALSEL")], ""),
                   (f"TC_{n}", x + 300, y0 + 1200, [(f"algTkCmd{n}", f"{d}.REQ_CMD")], "")]
        trans += [("START", f"SR_{n}", f"{d}.CNF_READY", x, y0 - 200), (f"SR_{n}", "START", "1", x + 100, y0 - 100),
                  (idle, f"TR_{n}", f"{d}.CNF_READY", x - 100, y0 + 200), (f"TR_{n}", f"TK_{n}", "1", x + 50, y0 + 600),
                  (idle, f"TK_{n}", f"{d}.CNF_STATUS", x - 200, y0 + 600),
                  (f"TK_{n}", f"TS_{n}", sel, x - 200, y0 + 1000), (f"TK_{n}", f"TC_{n}", cmd, x + 200, y0 + 1000),
                  (f"TK_{n}", nxt(k), f"NOT ({sel}) AND NOT ({cmd})", x + 50, y0 + 1100),
                  (f"TS_{n}", nxt(k), "1", x - 300, y0 + 1400), (f"TC_{n}", nxt(k), "1", x + 300, y0 + 1400)]
    return algs, states, trans, v_int, "\n".join(init), f"TK_{devs[0][1:]}"


# --------------------------------------------------------------------------------------------------
# DistributingSequence: reset sequence (owners, home, park the arm) and the workpiece cycle
# --------------------------------------------------------------------------------------------------
DEVS = ["IEjector", "IVacuum", "ISwivel"]
DEV_EVENTS = " OR ".join(f"{d}.CNF_STATUS OR {d}.CNF_READY" for d in DEVS)
FAULT_EXPR = " OR ".join(f"{d}.NeedReset" for d in DEVS)
ALL_LOCAL = " AND ".join(f"{d}.ProgLocal" for d in DEVS)
MODE_TEXT = """CASE Mode OF
    0: ModeText := 'Wait for RESET';
    1: ModeText := 'Resetting';
    2: ModeText := 'Wait for START';
    3: ModeText := 'Started';
ELSE
    ModeText := 'Unknown mode';
END_CASE;"""


def distributing_sequence(keep):
    f = BasicFB("DistributingSequence", keep)
    f.ev_in = [("INIT", ["QI"], "Initialisation request"),
               ("MODE", ["Mode", "Started"], "Station mode changed (StationMode)"),
               ("DO_RESET", [], "Run the reset sequence (StationMode)"),
               ("REQ_WP", [], "Request one workpiece (Testing, or the HMI button)"),
               ("MAG", ["MagEmptyPv"], "Magazine sensor changed"),
               ("TIMEOUT", [], "Ejection pulse time over (EjectTimer)")]
    f.ev_out = [("INITO", ["QO"], "Initialisation confirm"),
                ("RESET_DONE", [], "Reset sequence finished (StationMode)"),
                ("FAULT", [], "Stopped on a device fault (StationMode)"),
                ("WP_DONE", [], "Workpiece handed over (Testing)"),
                ("AUX_LAMPS", ["Q1Lamp", "Q2Lamp"], "Console lamps Q1 and Q2"),
                ("TSTART", [], "Start the ejection pulse timer"),
                ("HMI_ST", ["ModeText", "StepText", "Waiting", "Cycles", "StepNo"], "State for the HMI")]
    f.v_in = [("QI", "BOOL", "Input event qualifier"),
              ("Mode", "INT", f"Station mode: {MODES}"),
              ("Started", "BOOL", "Station started: requests are accepted"),
              ("MagEmptyPv", "VTQBOOL", "B4 magazine empty")]
    f.v_out = [("QO", "BOOL", "Output event qualifier"),
               ("Q1Lamp", "BOOL", "Lamp Q1: waiting, magazine empty"),
               ("Q2Lamp", "BOOL", "Lamp Q2: not used"),
               ("ModeText", "STRING[40]", "Station mode as text"),
               ("StepText", "STRING[40]", "Current step as text (number and name)"),
               ("Waiting", "BOOL", "Waiting for workpieces (magazine empty)"),
               ("Cycles", "UDINT", "Workpieces handed over since start-up"),
               ("StepNo", "INT", "Current step number")]
    f.plugs = [(d, "IDevice", "SE.App2CommonProcess") for d in DEVS]
    f.v_int = [("Done", "BOOL", "The current step has reached its target", None),
               ("Fault", "BOOL", "A device needs Rearm, or is not program local when it must be", None),
               ("InCycle", "BOOL", "Parking belongs to a workpiece cycle (else to the reset sequence)", None),
               ("Accept", "BOOL", "A workpiece request is accepted (station started)", None)]

    algs, states, trans = [], [], []
    tk_algs, tk_states, tk_trans, tk_vars, tk_init, tk_first = takeover(["ISwivel"], "IDLE_W", 100, 2300)
    f.v_int += tk_vars
    algs.append(("algModeText", "Station mode as text", MODE_TEXT))
    algs.append(("algInit", "Idle; lamps Q1 and Q2 off", """
QO := QI;
StepNo := 0; StepText := '0 Idle';
Waiting := FALSE; Q1Lamp := FALSE; Q2Lamp := FALSE;
InCycle := FALSE; Done := FALSE; Fault := FALSE;
Cycles := 0;
""" + tk_init))
    algs.append(("algIdle", "Idle", "StepNo := 0; StepText := '0 Idle';"))

    col = [0]

    def pos(row):
        return 300 + 900 * col[0], 300 + 400 * row

    def wait_step(name, no, text, cmd, emits, done, nxt):
        """S_: command and show; C_: check target and faults; W_: wait for a device event."""
        algs.append((f"algS_{name}", text, f"StepNo := {no}; StepText := '{no} {text}';\n{cmd}"))
        algs.append((f"algC_{name}", f"Check: {text}", f"Fault := {FAULT_EXPR};\nDone := {done};"))
        (x, y) = pos(0)
        states.extend([(f"S_{name}", x, y, [("algModeText", None), (f"algS_{name}", "HMI_ST")] + [(None, e) for e in emits], ""),
                       (f"C_{name}", x, y + 400, [(f"algC_{name}", None)], ""),
                       (f"W_{name}", x, y + 800, [], f"Wait: {text}")])
        trans.extend([(f"S_{name}", f"C_{name}", "1", x + 50, y + 200),
                      (f"C_{name}", "FAULT_S", "Fault", x + 300, y + 450),
                      (f"C_{name}", nxt, "NOT Fault AND Done", x + 300, y + 350),
                      (f"C_{name}", f"W_{name}", "NOT Fault AND NOT Done", x + 50, y + 600),
                      (f"W_{name}", f"C_{name}", DEV_EVENTS, x + 150, y + 600)])
        col[0] += 1

    def plain_step(name, no, text, cmd, emits, nxt_list):
        algs.append((f"algS_{name}", text, f"StepNo := {no}; StepText := '{no} {text}';\n{cmd}"))
        (x, y) = pos(0)
        states.append((f"S_{name}", x, y, [("algModeText", None), (f"algS_{name}", "HMI_ST")] + [(None, e) for e in emits], ""))
        for cond, nxt in nxt_list:
            trans.append((f"S_{name}", nxt, cond, x + 50, y + 200))
        col[0] += 1

    # --- idle, init, mode display -----------------------------------------------------------------
    states.extend([("START", 100, 100, [], "Initial state"),
                   ("INIT_S", 100, 500, [("algInit", None), ("algModeText", None), (None, "AUX_LAMPS"), (None, "HMI_ST"), (None, "INITO")], ""),
                   ("S_IDLE", 100, 900, [("algModeText", None), ("algIdle", "HMI_ST")], ""),
                   ("IDLE_W", 100, 1300, [], "Idle: wait for RESET (reset sequence) or a workpiece request"),
                   ("M_IDLE", 100, 1700, [("algModeText", "HMI_ST")], "")])
    trans.extend([("START", "INIT_S", "INIT", 150, 300),
                  ("INIT_S", "S_IDLE", "1", 150, 700),
                  ("S_IDLE", tk_first, "1", 150, 1100),
                  ("IDLE_W", "INIT_S", "INIT", 250, 900),
                  ("IDLE_W", "M_IDLE", "MODE", 150, 1500),
                  ("M_IDLE", "IDLE_W", "1", 250, 1500),
                  ("IDLE_W", "S_R_SEL", "DO_RESET", 400, 1300),
                  ("IDLE_W", "Q_CHK", "REQ_WP", 400, 1400)])
    col[0] = 1

    # --- reset sequence ---------------------------------------------------------------------------
    sel = ("\n".join(f"{d}.ProgLocalSel := TRUE;" for d in DEVS) + "\nInCycle := FALSE; Waiting := FALSE; Q1Lamp := FALSE;"
           "\nAdpSwivel := TRUE;")
    wait_step("R_SEL", 10, "Reset: owners to program", sel,
              [f"{d}.REQ_PROGLOCALSEL" for d in DEVS] + ["AUX_LAMPS"], ALL_LOCAL, "S_R_HOME")
    wait_step("R_HOME", 11, "Reset: ejector home",
              "IVacuum.Lsp.value := 0;\nIEjector.Lsp.value := 2;",
              ["IVacuum.REQ_CMD", "IEjector.REQ_CMD"], "IEjector.Status.value = 2", "S_P_MAG")

    # --- park the arm just off the magazine (reset sequence and end of every cycle) ----------------
    wait_step("P_MAG", 20, "Park: swivel to magazine", "ISwivel.Lsp.value := 2;",
              ["ISwivel.REQ_CMD"], "ISwivel.Status.value = 2", "S_P_OFF")
    wait_step("P_OFF", 21, "Park: off the magazine", "ISwivel.Lsp.value := 1;",
              ["ISwivel.REQ_CMD"], "ISwivel.Status.value <> 2", "S_P_STOP")
    plain_step("P_STOP", 22, "Park: swivel stopped", "ISwivel.Lsp.value := 0;", ["ISwivel.REQ_CMD"],
               [("InCycle", "S_C_DONE"), ("NOT InCycle", "S_R_DONE")])
    plain_step("R_DONE", 12, "Reset done", "", ["RESET_DONE"], [("1", "IDLE_W")])

    # --- workpiece cycle ----------------------------------------------------------------------------
    algs.append(("algQ_CHK", "Workpiece request: accept only when started and all devices ready", f"""
Accept := Started;
Fault := {FAULT_EXPR} OR NOT ({ALL_LOCAL});
IF NOT Accept THEN
    StepText := '0 Idle: press START first';
END_IF;"""))
    (x, y) = pos(0)
    states.extend([("Q_CHK", x, y, [("algQ_CHK", None)], ""),
                   ("Q_NOSTART", x, y + 400, [("algModeText", "HMI_ST")], "")])
    trans.extend([("Q_CHK", "Q_NOSTART", "NOT Accept", x + 50, y + 200),
                  ("Q_NOSTART", "IDLE_W", "1", x + 150, y + 600),
                  ("Q_CHK", "FAULT_S", "Accept AND Fault", x + 300, y + 200),
                  ("Q_CHK", "S_C_MAG", "Accept AND NOT Fault", x + 300, y + 100)])
    col[0] += 1

    algs.append(("algS_C_MAG", "Cycle: wait while the magazine is empty", """
InCycle := TRUE;
Waiting := MagEmptyPv.value;
Q1Lamp := Waiting;
IF Waiting THEN
    StepNo := 31; StepText := '31 Wait: magazine empty';
ELSE
    StepNo := 31; StepText := '31 Magazine: workpiece there';
END_IF;"""))
    (x, y) = pos(0)
    states.extend([("S_C_MAG", x, y, [("algModeText", None), ("algS_C_MAG", "HMI_ST"), (None, "AUX_LAMPS")], ""),
                   ("W_C_MAG", x, y + 800, [], "Wait: magazine empty")])
    trans.extend([("S_C_MAG", "S_C_PUSH", "NOT Waiting", x + 300, y + 100),
                  ("S_C_MAG", "W_C_MAG", "Waiting", x + 50, y + 400),
                  ("W_C_MAG", "S_C_MAG", "MAG", x + 150, y + 400)])
    col[0] += 1

    wait_step("C_PUSH", 32, "Push workpiece out", "IEjector.Lsp.value := 1;",
              ["IEjector.REQ_CMD"], "IEjector.Status.value = 1", "S_C_BACK")
    wait_step("C_BACK", 33, "Ejector back home", "IEjector.Lsp.value := 2;",
              ["IEjector.REQ_CMD"], "IEjector.Status.value = 2", "S_C_TOMAG")
    wait_step("C_TOMAG", 34, "Swivel to magazine", "ISwivel.Lsp.value := 2;",
              ["ISwivel.REQ_CMD"], "ISwivel.Status.value = 2", "S_C_GRIP")
    wait_step("C_GRIP", 35, "Vacuum on, wait gripped", "IVacuum.Lsp.value := 1;",
              ["IVacuum.REQ_CMD"], "IVacuum.Status.value = 1", "S_C_TODOWN")
    wait_step("C_TODOWN", 36, "Swivel to Testing", "ISwivel.Lsp.value := 1;",
              ["ISwivel.REQ_CMD"], "ISwivel.Status.value = 1", "S_C_REL")

    # release: ejection pulse for the time of EjectTimer; device faults still stop the sequence
    algs.append(("algS_C_REL", "Ejection pulse", "StepNo := 37; StepText := '37 Release: ejection pulse';\nIVacuum.Lsp.value := 2;"))
    algs.append(("algK_C_REL", "Fault check while the pulse runs", f"Fault := {FAULT_EXPR};"))
    (x, y) = pos(0)
    states.extend([("S_C_REL", x, y, [("algModeText", None), ("algS_C_REL", "HMI_ST"), (None, "IVacuum.REQ_CMD"), (None, "TSTART")], ""),
                   ("W_C_REL", x, y + 400, [], "Wait: ejection pulse"),
                   ("K_C_REL", x, y + 800, [("algK_C_REL", None)], "")])
    trans.extend([("S_C_REL", "W_C_REL", "1", x + 50, y + 200),
                  ("W_C_REL", "S_C_VACOFF", "TIMEOUT", x + 300, y + 400),
                  ("W_C_REL", "K_C_REL", DEV_EVENTS, x + 50, y + 600),
                  ("K_C_REL", "FAULT_S", "Fault", x + 300, y + 800),
                  ("K_C_REL", "W_C_REL", "NOT Fault", x + 150, y + 600)])
    col[0] += 1

    plain_step("C_VACOFF", 38, "Vacuum off", "IVacuum.Lsp.value := 0;", ["IVacuum.REQ_CMD"], [("1", "S_P_MAG")])
    plain_step("C_DONE", 40, "Cycle done: handed over",
               "Cycles := Cycles + 1;\nInCycle := FALSE; Waiting := FALSE; Q1Lamp := FALSE;",
               ["AUX_LAMPS", "WP_DONE"], [("1", "IDLE_W")])

    # --- fault ---------------------------------------------------------------------------------------
    algs.append(("algFault", "Device fault: stop here, report to StationMode", f"""
StepNo := 99;
IF IEjector.NeedReset THEN
    StepText := '99 FAULT: Rearm Ejector';
ELSIF IVacuum.NeedReset THEN
    StepText := '99 FAULT: Rearm Vacuum';
ELSIF ISwivel.NeedReset THEN
    StepText := '99 FAULT: Rearm Swivel';
ELSE
    StepText := '99 FAULT: owner not program';
END_IF;
InCycle := FALSE; Waiting := FALSE; Q1Lamp := FALSE;"""))
    (x, y) = pos(0)
    states.append(("FAULT_S", x, y, [("algModeText", None), ("algFault", "HMI_ST"), (None, "AUX_LAMPS"), (None, "FAULT")],
                   "Fault: RESET restarts the reset sequence after Rearm on the faceplate"))
    trans.append(("FAULT_S", "IDLE_W", "1", x + 50, y + 200))

    f.algs, f.states, f.trans = algs + tk_algs, states + tk_states, trans + tk_trans
    return f


# --------------------------------------------------------------------------------------------------
# TestingSequence: reset sequence and test cycle of the Testing station (docs/version1/testing.md)
# --------------------------------------------------------------------------------------------------
class Seq:
    """Builder for a station sequence: one command/check/wait state group per step, as DistributingSequence."""

    def __init__(self, devs):
        self.devs = devs
        self.dev_events = " OR ".join(f"{d}.CNF_STATUS OR {d}.CNF_READY" for d in devs)
        self.fault = " OR ".join(f"{d}.NeedReset" for d in devs)
        self.all_local = " AND ".join(f"{d}.ProgLocal" for d in devs)
        self.algs, self.states, self.trans = [], [], []
        self.col = 1

    def _pos(self):
        return 300 + 900 * self.col, 300

    def _show(self, name, no, text, cmd):
        self.algs.append((f"algS_{name}", text, f"StepNo := {no}; StepText := '{no} {text}';\n{cmd}".rstrip()))
        return [("algModeText", None), (f"algS_{name}", "HMI_ST")]

    def wait(self, name, no, text, cmd, emits, done, nxt):
        """Command, then wait until `done` (checked on every device event); a device fault stops the sequence."""
        acts = self._show(name, no, text, cmd)
        self.algs.append((f"algC_{name}", f"Check: {text}", f"Fault := {self.fault};\nDone := {done};"))
        x, y = self._pos()
        self.states += [(f"S_{name}", x, y, acts + [(None, e) for e in emits], ""),
                        (f"C_{name}", x, y + 400, [(f"algC_{name}", None)], ""),
                        (f"W_{name}", x, y + 800, [], f"Wait: {text}")]
        self.trans += [(f"S_{name}", f"C_{name}", "1", x + 50, y + 200),
                       (f"C_{name}", "FAULT_S", "Fault", x + 300, y + 450),
                       (f"C_{name}", nxt, "NOT Fault AND Done", x + 300, y + 350),
                       (f"C_{name}", f"W_{name}", "NOT Fault AND NOT Done", x + 50, y + 600),
                       (f"W_{name}", f"C_{name}", self.dev_events, x + 150, y + 600)]
        self.col += 1

    def event(self, name, no, text, cmd, emits, event, nxt):
        """Command, then wait for `event` (a timer, or a confirmation); device faults still stop the sequence."""
        acts = self._show(name, no, text, cmd)
        x, y = self._pos()
        self.states += [(f"S_{name}", x, y, acts + [(None, e) for e in emits], ""),
                        (f"W_{name}", x, y + 400, [], f"Wait: {text}"),
                        (f"K_{name}", x, y + 800, [("algFaultOnly", None)], "")]
        self.trans += [(f"S_{name}", f"W_{name}", "1", x + 50, y + 200),
                       (f"W_{name}", nxt, event, x + 300, y + 400),
                       (f"W_{name}", f"K_{name}", self.dev_events, x + 50, y + 600),
                       (f"K_{name}", "FAULT_S", "Fault", x + 300, y + 800),
                       (f"K_{name}", f"W_{name}", "NOT Fault", x + 150, y + 600)]
        self.col += 1

    def plain(self, name, no, text, cmd, emits, nxt_list):
        """Command and go on at once (one or more guarded exits)."""
        acts = self._show(name, no, text, cmd)
        x, y = self._pos()
        self.states.append((f"S_{name}", x, y, acts + [(None, e) for e in emits], ""))
        for cond, nxt in nxt_list:
            self.trans.append((f"S_{name}", nxt, cond, x + 50, y + 200))
        self.col += 1


def testing_sequence(keep):
    f = BasicFB("TestingSequence", keep)
    devs = ["ILift", "IEjector", "IAirSlide"]
    s = Seq(devs)
    f.ev_in = [("INIT", ["QI"], "Initialisation request"),
               ("MODE", ["Mode", "Started"], "Station mode changed (StationMode)"),
               ("DO_RESET", [], "Run the reset sequence (StationMode)"),
               ("TRAY", ["Tray", "Workpiece"], "Tray state at interface 1 (conveyor waypoint, IWaypoint)"),
               ("SIM_EMPTY", [], "Stand-in: an empty tray has arrived (HMI button)"),
               ("SIM_FULL", [], "Stand-in: a tray with a workpiece has arrived (HMI button)"),
               ("WP_CNF", [], "Distributing has handed a workpiece over (IWorkpieceSupply)"),
               ("SENS", ["NotBlackPv", "HeightOkPv"], "Colour or height sensor changed"),
               ("T_EJ", [], "Ejector time over (EjectTimer)"),
               ("T_SL", [], "Air slide time over (SlideTimer)")]
    f.ev_out = [("INITO", ["QO"], "Initialisation confirm"),
                ("RESET_DONE", [], "Reset sequence finished (StationMode)"),
                ("FAULT", [], "Stopped on a device fault (StationMode)"),
                ("WP_REQ", [], "Ask Distributing for a workpiece (IWorkpieceSupply)"),
                ("RELEASE", [], "Release the tray (IWaypoint)"),
                ("STATE_REQ", [], "Ask the waypoint for the tray state (IWaypoint)"),
                ("TSTART_EJ", [], "Start the ejector timer"),
                ("TSTART_SL", [], "Start the air slide timer"),
                ("HMI_ST", ["ModeText", "StepText", "Cycles", "Rejected", "StepNo", "TrayReleased"], "State for the HMI")]
    f.v_in = [("QI", "BOOL", "Input event qualifier"),
              ("Mode", "INT", f"Station mode: {MODES}"),
              ("Started", "BOOL", "Station started: trays are accepted"),
              ("Tray", "BOOL", "A tray is at the stopper of interface 1"),
              ("Workpiece", "BOOL", "The tray carries a workpiece"),
              ("NotBlackPv", "VTQBOOL", "B2 workpiece is not black"),
              ("HeightOkPv", "VTQBOOL", "Height comparator: height correct")]
    f.v_out = [("QO", "BOOL", "Output event qualifier"),
               ("ModeText", "STRING[40]", "Station mode as text"),
               ("StepText", "STRING[40]", "Current step as text (number and name)"),
               ("Cycles", "UDINT", "Workpieces put on a tray since start-up"),
               ("Rejected", "UDINT", "Workpieces rejected (black or wrong height) since start-up"),
               ("StepNo", "INT", "Current step number"),
               ("TrayReleased", "BOOL", "The tray has been released (until the next tray)")]
    f.plugs = [(d, "IDevice", "SE.App2CommonProcess") for d in devs]
    f.v_int = [("Done", "BOOL", "The current step has reached its target", None),
               ("Fault", "BOOL", "A device needs Rearm, or is not program local when it must be", None),
               ("Accept", "BOOL", "A tray is accepted (station started, tray present)", None),
               ("TrayNow", "BOOL", "A tray is present (from the waypoint or a stand-in button)", None),
               ("Full", "BOOL", "The present tray carries a workpiece", None),
               ("Black", "BOOL", "The workpiece is black", None),
               ("HeightGood", "BOOL", "The workpiece has the right height", None)]
    tk_algs, tk_states, tk_trans, tk_vars, tk_init, tk_first = takeover(["ILift"], "IDLE_W", 100, 2900)
    f.v_int += tk_vars

    s.algs += [("algModeText", "Station mode as text", MODE_TEXT),
               ("algInit", "Idle", "QO := QI;\nStepNo := 0; StepText := '0 Idle';\n"
                                   "Cycles := 0; Rejected := 0; TrayReleased := FALSE;\nDone := FALSE; Fault := FALSE;\n"
                                   + tk_init),
               ("algIdle", "Idle", "StepNo := 0; StepText := '0 Idle';"),
               ("algFaultOnly", "Fault check while waiting for a timer or a confirmation", f"Fault := {s.fault};"),
               ("algQTray", "Tray state from the waypoint", "TrayNow := Tray; Full := Workpiece;"),
               ("algQEmpty", "Stand-in: empty tray", "TrayNow := TRUE; Full := FALSE;"),
               ("algQFull", "Stand-in: tray with a workpiece", "TrayNow := TRUE; Full := TRUE;"),
               ("algQ_CHK", "Tray: accept only when started; all devices must be ready", f"""
Accept := Started AND TrayNow;
Fault := {s.fault} OR NOT ({s.all_local});
IF NOT Started THEN
    StepText := '0 Idle: press START first';
ELSIF NOT TrayNow THEN
    StepText := '0 Idle: no tray';
END_IF;""")]
    s.states += [("START", 100, 100, [], "Initial state"),
                 ("INIT_S", 100, 500, [("algInit", None), ("algModeText", None), (None, "HMI_ST"), (None, "INITO")], ""),
                 ("S_IDLE", 100, 900, [("algModeText", None), ("algIdle", "HMI_ST")], ""),
                 ("IDLE_W", 100, 1300, [], "Idle: wait for RESET (reset sequence) or a tray"),
                 ("M_IDLE", 100, 1700, [("algModeText", "HMI_ST")], ""),
                 ("Q_TRAY", 500, 1700, [("algQTray", None)], ""),
                 ("Q_EMPTY", 500, 2100, [("algQEmpty", None)], ""),
                 ("Q_FULL", 500, 2500, [("algQFull", None)], ""),
                 ("Q_CHK", 900, 2100, [("algQ_CHK", None)], ""),
                 ("Q_NOSTART", 900, 2500, [("algModeText", "HMI_ST")], "")]
    s.trans += [("START", "INIT_S", "INIT", 150, 300), ("INIT_S", "S_IDLE", "1", 150, 700),
                ("S_IDLE", tk_first, "1", 150, 1100), ("IDLE_W", "INIT_S", "INIT", 250, 900),
                ("IDLE_W", "M_IDLE", "MODE", 150, 1500), ("M_IDLE", "IDLE_W", "1", 250, 1500),
                ("IDLE_W", "S_R_SEL", "DO_RESET", 400, 1300),
                ("IDLE_W", "Q_TRAY", "TRAY", 350, 1500), ("IDLE_W", "Q_EMPTY", "SIM_EMPTY", 350, 1800),
                ("IDLE_W", "Q_FULL", "SIM_FULL", 350, 2100),
                ("Q_TRAY", "Q_CHK", "1", 700, 1900), ("Q_EMPTY", "Q_CHK", "1", 700, 2100), ("Q_FULL", "Q_CHK", "1", 700, 2300),
                ("Q_CHK", "Q_NOSTART", "NOT Accept", 950, 2300), ("Q_NOSTART", "IDLE_W", "1", 600, 1300),
                ("Q_CHK", "FAULT_S", "Accept AND Fault", 1100, 2100),
                ("Q_CHK", "S_C_PASS", "Accept AND NOT Fault AND Full", 1100, 2000),
                ("Q_CHK", "S_C_REQ", "Accept AND NOT Fault AND NOT Full", 1100, 2200)]
    s.col = 2

    # --- reset sequence: owners, lift down, clear the station with one ejector stroke --------------
    sel = "\n".join(f"{d}.ProgLocalSel := TRUE;" for d in devs) + "\nAdpLift := TRUE;"
    s.wait("R_SEL", 10, "Reset: owners to program", sel, [f"{d}.REQ_PROGLOCALSEL" for d in devs], s.all_local, "S_R_HOME")
    s.wait("R_HOME", 11, "Reset: air off, lift down", "IAirSlide.Lsp.value := 0;\nILift.Lsp.value := 2;",
           ["IAirSlide.REQ_CMD", "ILift.REQ_CMD"], "ILift.Status.value = 2", "S_R_EJ")
    s.event("R_EJ", 12, "Reset: eject", "IEjector.Lsp.value := 1;", ["IEjector.REQ_CMD", "TSTART_EJ"], "T_EJ", "S_R_BACK")
    s.wait("R_BACK", 13, "Reset: ejector back", "IEjector.Lsp.value := 2;", ["IEjector.REQ_CMD"],
           "IEjector.Status.value = 2", "S_R_DONE")
    s.plain("R_DONE", 14, "Reset done", "TrayReleased := FALSE;", ["RESET_DONE", "STATE_REQ"], [("1", "IDLE_W")])

    # --- tray already carries a workpiece: pass it on ------------------------------------------------
    s.plain("C_PASS", 20, "Tray full: released", "TrayReleased := TRUE;", ["RELEASE"], [("1", "IDLE_W")])

    # --- test cycle ------------------------------------------------------------------------------------
    s.event("C_REQ", 21, "Ask Distributing", "TrayReleased := FALSE;", ["WP_REQ"], "WP_CNF", "S_C_COLOUR")
    s.plain("C_COLOUR", 22, "Check colour", "Black := NOT NotBlackPv.value;", [],
            [("Black", "S_X_EJ"), ("NOT Black", "S_C_RAISE")])
    s.wait("C_RAISE", 23, "Raise lift", "ILift.Lsp.value := 1;", ["ILift.REQ_CMD"], "ILift.Status.value = 1", "S_C_HEIGHT")
    s.plain("C_HEIGHT", 24, "Check height", "HeightGood := HeightOkPv.value;", [],
            [("HeightGood", "S_C_PUSH"), ("NOT HeightGood", "S_X_LOWER")])
    s.event("C_PUSH", 25, "Push onto air slide", "IEjector.Lsp.value := 1;\nIAirSlide.Lsp.value := 1;",
            ["IEjector.REQ_CMD", "IAirSlide.REQ_CMD", "TSTART_EJ"], "T_EJ", "S_C_BACK")
    s.wait("C_BACK", 26, "Ejector back", "IEjector.Lsp.value := 2;", ["IEjector.REQ_CMD"],
           "IEjector.Status.value = 2", "S_C_SLIDE")
    s.event("C_SLIDE", 27, "Air slide on", "", ["TSTART_SL"], "T_SL", "S_C_LOWER")
    s.wait("C_LOWER", 28, "Air off, lift down", "IAirSlide.Lsp.value := 0;\nILift.Lsp.value := 2;",
           ["IAirSlide.REQ_CMD", "ILift.REQ_CMD"], "ILift.Status.value = 2", "S_C_DONE")
    s.plain("C_DONE", 29, "Done: tray released", "Cycles := Cycles + 1;\nTrayReleased := TRUE;", ["RELEASE"], [("1", "IDLE_W")])

    # --- reject: black at the bottom, or wrong height (lift down first); then ask again --------------
    s.wait("X_LOWER", 32, "Reject: lift down", "ILift.Lsp.value := 2;", ["ILift.REQ_CMD"], "ILift.Status.value = 2", "S_X_EJ")
    s.event("X_EJ", 30, "Reject: eject", "IEjector.Lsp.value := 1;", ["IEjector.REQ_CMD", "TSTART_EJ"], "T_EJ", "S_X_BACK")
    s.wait("X_BACK", 31, "Reject: ejector back", "IEjector.Lsp.value := 2;", ["IEjector.REQ_CMD"],
           "IEjector.Status.value = 2", "S_X_COUNT")
    s.plain("X_COUNT", 33, "Rejected: ask again", "Rejected := Rejected + 1;", [], [("1", "S_C_REQ")])

    # --- fault ---------------------------------------------------------------------------------------
    s.algs.append(("algFault", "Device fault: stop here, report to StationMode", """
StepNo := 99;
IF ILift.NeedReset THEN
    StepText := '99 FAULT: Rearm Lift';
ELSIF IEjector.NeedReset THEN
    StepText := '99 FAULT: Rearm Ejector';
ELSIF IAirSlide.NeedReset THEN
    StepText := '99 FAULT: Rearm AirSlide';
ELSE
    StepText := '99 FAULT: owner not program';
END_IF;"""))
    x, y = s._pos()
    s.states.append(("FAULT_S", x, y, [("algModeText", None), ("algFault", "HMI_ST"), (None, "FAULT")],
                     "Fault: RESET restarts the reset sequence after Rearm on the faceplate"))
    s.trans.append(("FAULT_S", "IDLE_W", "1", x + 50, y + 200))

    f.algs, f.states, f.trans = s.algs + tk_algs, s.states + tk_states, s.trans + tk_trans
    return f


TYPES = {"StationMode": (IEC / "StationMode.fbt", station_mode),
         "ConsoleIO": (IEC / "ConsoleIO.fbt", console_io),
         "DistributingSequence": (IEC / "DistributingSequence.fbt", distributing_sequence),
         "TestingSequence": (IEC / "TestingSequence.fbt", testing_sequence)}


def main():
    check = "--check" in sys.argv
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")
    for name, (path, make) in TYPES.items():
        if not path.exists():
            print(f"skip {name}: {path.relative_to(ROOT)} does not exist (create it in EAE first)")
            continue
        raw = path.read_bytes()
        old = raw.decode("utf-8-sig")
        head = old[:old.index("<InterfaceList")].rstrip(" ")
        keep = {k: v for k, v in eae_ids(old).items() if k in ("INIT", "INITO", "QI", "QO")}
        f = make(keep)
        new = head + f.interface() + f.body()
        print(f"{'would write' if check else 'write'} {path.relative_to(ROOT)} ({len(old)} -> {len(new)} chars); "
              f"EAE IDs kept: {keep}")
        if not check:
            path.write_bytes(new.encode("utf-8"))  # no BOM (EAE does not resolve .fbt files with a BOM)


if __name__ == "__main__":
    main()
