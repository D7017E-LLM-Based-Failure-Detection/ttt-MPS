"""One-off scaffolding for version 0: library project Flexbridge.Festo.MPS400 with the CAT IOTest16.

Writes into OUT (a staging folder that mirrors the repository):
  Flexbridge.Festo.MPS400/...        new library project (IEC61499, HMI, HwConfiguration, AssetLinkData, ATVHMIPlugin)
  festo-mps-400-eae.sln              patched copy (adds the five library projects)
  IEC61499/IEC61499.dfbproj          patched copy (references the library)
  HMI/HMI.csproj                     patched copy (references the library HMI)
  HwConfiguration/HwConfiguration.hwconfigproj   patched copy (references the library hardware project)

Usage (from the repository root):
  .venv\\Scripts\\python tools\\v0_scaffold.py OUT

The formats follow the AHU reference (resources/Tutorial) file by file. Once EAE has opened and saved
the files, EAE owns them: fix things in EAE, do not re-run this script over them.
"""
import hashlib
import re
import shutil
import sys
import uuid
from pathlib import Path
from xml.sax.saxutils import escape

ROOT = Path(__file__).resolve().parent.parent
TUT = ROOT / "resources" / "Tutorial" / "Air Handling Unit" / "AHUCompleteApplication"
LIB = "Flexbridge.Festo.MPS400"
NS = LIB
N = 16
CH = [f"{i:02d}" for i in range(N)]

TYPE_IEC = "{EAD1E85F-CEF5-4861-AFF8-597F2DDE70FC}"
TYPE_HMI = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
TYPE_HW = "{72AEB29F-A91B-8B3D-40ED-1C96841A14A3}"
TYPE_ALD = "{E25C2A81-DD87-490C-A304-820B0BA163F2}"
TYPE_ATV = "{AF5A4E9E-1CB6-4325-AE5C-F3437C6CEE36}"


def h16(key):
    """Deterministic 16-hex-digit ID, as EAE uses for pins and FB instances."""
    return hashlib.sha1(f"{LIB}:{key}".encode()).hexdigest()[:16].upper()


def guid(key):
    return str(uuid.uuid5(uuid.NAMESPACE_URL, f"https://flexbridge.se/{LIB}/{key}"))


G = {k: guid(k).upper() for k in ("iec", "hmi", "hw", "ald", "atv")}
DATE = "11/11/2026"
AUTHOR = "Flexbridge AB"


def write(path, text, bom=False):
    """No BOM by default: EAE does not resolve .fbt types that start with one (2026-11-13)."""
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(text, encoding="utf-8-sig" if bom else "utf-8")


# ----------------------------------------------------------------------------------------------------------
# IOTest16Logic: basic FB. Events are emitted only by ECC actions; ST only computes and sets guard flags.
# ----------------------------------------------------------------------------------------------------------
def logic_fbt():
    def withs(names):
        return "".join(f'\n        <With Var="{n}" />' for n in names)

    ev_in = [
        ("INIT", [f"Excl{c}" for c in CH] + [f"Pulse{c}" for c in CH], "Initialise; takes over the exclusive pairs and pulse times"),
        ("CMD", [f"Cmd{c}" for c in CH], "Button states requested on the HMI"),
        ("ALL_OFF", [], "Switch every output off"),
        ("DI", [f"In{c}" for c in CH], "An input channel changed"),
        ("PULSE_END", [], "Pulse timer elapsed"),
    ]
    ev_out = [
        ("INITO", [], "Initialisation done"),
        ("DO_UPD", [f"Out{c}" for c in CH], "New output values for the dOSignal blocks"),
        ("HMI_DO", [f"St{c}" for c in CH] + [f"En{c}" for c in CH], "Output states and enabled buttons for the HMI"),
        ("HMI_DI", [f"Di{c}" for c in CH], "Input values for the HMI"),
        ("TSTART", ["PulseDT"], "Start the pulse timer"),
        ("TSTOP", [], "Cancel the pulse timer"),
    ]
    ins = ([(f"Excl{c}", "INT", "-1", f"Output that must never be on together with output {c}; -1 = none") for c in CH]
           + [(f"Pulse{c}", "TIME", "T#0s", f"Pulse time of output {c}; T#0s = toggle") for c in CH]
           + [(f"Cmd{c}", "BOOL", None, f"Requested state of output {c}") for c in CH]
           + [(f"In{c}", "VTQBOOL", None, f"Input channel {c}") for c in CH])
    outs = ([(f"Out{c}", "VTQBOOL", None, f"Output channel {c}") for c in CH]
            + [(f"St{c}", "BOOL", None, f"Current state of output {c}") for c in CH]
            + [(f"En{c}", "BOOL", None, f"Button of output {c} may be pressed") for c in CH]
            + [(f"Di{c}", "BOOL", None, f"Value of input {c}") for c in CH]
            + [("PulseDT", "TIME", None, "Duration of the pulse being started")])
    internal = ([("Changed", "BOOL", None, "An output state changed"),
                 ("StartPulse", "BOOL", None, "A pulse timer must be started"),
                 ("StopPulse", "BOOL", None, "The pulse timer must be cancelled"),
                 ("PulseCh", "INT", "-1", "Output whose pulse is running; -1 = none")]
                + [(f"PrevRq{c}", "BOOL", None, f"Last requested state of output {c}") for c in CH])

    def decl(v, with_id=True):
        name, typ, init, com = v
        iv = f' InitialValue="{escape(init)}"' if init is not None else ""
        i = f' ID="{lid(name)}"' if with_id else ""
        return f'      <VarDeclaration{i} Name="{name}" Type="{typ}"{iv} Comment="{escape(com)}" />'

    def events(lst):
        return "\n".join(f'      <Event ID="{lid("ev." + n)}" Name="{n}" Comment="{escape(c)}">{withs(w)}\n      </Event>' if w
                         else f'      <Event ID="{lid("ev." + n)}" Name="{n}" Comment="{escape(c)}" />' for n, w, c in lst)

    load = lambda arr, pfx: "\n".join(f"{arr}[{i}] := {pfx}{c};" for i, c in enumerate(CH))
    store = lambda arr, pfx: "\n".join(f"{pfx}{c} := {arr}[{i}];" for i, c in enumerate(CH))

    alg = {}
    alg["algInit"] = ("(* All outputs off, no pulse running *)\n"
                      + "\n".join(f"St{c} := FALSE;\nPrevRq{c} := FALSE;" for c in CH)
                      + "\nPulseCh := -1;\nChanged := FALSE;\nStartPulse := FALSE;\nStopPulse := FALSE;\n")
    alg["algDI"] = "(* Copy the input values for the HMI *)\n" + "\n".join(f"Di{c} := In{c}.value;" for c in CH) + "\n"
    alg["algCmd"] = f"""VAR
  aSt : ARRAY[0..15] OF BOOL;
  aRq : ARRAY[0..15] OF BOOL;
  aPr : ARRAY[0..15] OF BOOL;
  aEx : ARRAY[0..15] OF INT;
  aPu : ARRAY[0..15] OF TIME;
  i : INT;
  p : INT;
  allowed : BOOL;
END_VAR
{load('aSt', 'St')}
{load('aRq', 'Cmd')}
{load('aPr', 'PrevRq')}
{load('aEx', 'Excl')}
{load('aPu', 'Pulse')}
Changed := FALSE;
StartPulse := FALSE;
StopPulse := FALSE;
(* Only buttons whose request changed since the last CMD are handled, so a request that was
   refused earlier never switches an output on later by surprise. *)
FOR i := 0 TO 15 DO
  IF aRq[i] <> aPr[i] THEN
    aPr[i] := aRq[i];
    IF aRq[i] <> aSt[i] THEN
      IF NOT aRq[i] THEN
        (* Switching off is always allowed *)
        aSt[i] := FALSE;
        Changed := TRUE;
        IF PulseCh = i THEN
          PulseCh := -1;
          StopPulse := TRUE;
        END_IF;
      ELSE
        (* Switching on: refused while the partner output is on, or while another pulse runs *)
        allowed := TRUE;
        p := aEx[i];
        IF (p >= 0) AND (p <= 15) THEN
          IF aSt[p] THEN
            allowed := FALSE;
          END_IF;
        END_IF;
        IF (aPu[i] > T#0s) AND (PulseCh >= 0) THEN
          allowed := FALSE;
        END_IF;
        IF allowed THEN
          aSt[i] := TRUE;
          Changed := TRUE;
          IF aPu[i] > T#0s THEN
            PulseCh := i;
            PulseDT := aPu[i];
            StartPulse := TRUE;
          END_IF;
        END_IF;
      END_IF;
    END_IF;
  END_IF;
END_FOR;
{store('aSt', 'St')}
{store('aPr', 'PrevRq')}
"""
    alg["algAllOff"] = ("(* Switch everything off and cancel a running pulse *)\n"
                        + "\n".join(f"St{c} := FALSE;" for c in CH)
                        + "\nStopPulse := (PulseCh >= 0);\nPulseCh := -1;\nStartPulse := FALSE;\nChanged := TRUE;\n")
    alg["algTimeout"] = f"""VAR
  aSt : ARRAY[0..15] OF BOOL;
END_VAR
{load('aSt', 'St')}
Changed := FALSE;
StartPulse := FALSE;
StopPulse := FALSE;
IF (PulseCh >= 0) AND (PulseCh <= 15) THEN
  aSt[PulseCh] := FALSE;
  PulseCh := -1;
  Changed := TRUE;
END_IF;
{store('aSt', 'St')}
"""
    alg["algUpdate"] = f"""VAR
  aSt : ARRAY[0..15] OF BOOL;
  aEx : ARRAY[0..15] OF INT;
  aPu : ARRAY[0..15] OF TIME;
  aEn : ARRAY[0..15] OF BOOL;
  i : INT;
  p : INT;
END_VAR
{load('aSt', 'St')}
{load('aEx', 'Excl')}
{load('aPu', 'Pulse')}
(* A button is enabled unless its partner output is on, or it is a pulse output while another pulse runs *)
FOR i := 0 TO 15 DO
  aEn[i] := TRUE;
  p := aEx[i];
  IF (p >= 0) AND (p <= 15) THEN
    IF aSt[p] THEN
      aEn[i] := FALSE;
    END_IF;
  END_IF;
  IF (aPu[i] > T#0s) AND (PulseCh >= 0) AND (PulseCh <> i) THEN
    aEn[i] := FALSE;
  END_IF;
END_FOR;
{store('aEn', 'En')}
""" + "\n".join(f"Out{c}.value := St{c};" for c in CH) + "\n"

    states = [  # name, x, y, actions [(algorithm or None, output or None)], comment
        ("START", 400, 1200, [], "Initial State"),
        ("INIT_S", 1600, 200, [("algInit", None), ("algUpdate", "DO_UPD"), (None, "HMI_DO"), ("algDI", "HMI_DI"), (None, "INITO")], ""),
        ("DI_S", 1600, 600, [("algDI", "HMI_DI")], ""),
        ("CMD_S", 1600, 1000, [("algCmd", None)], ""),
        ("OFF_S", 1600, 1400, [("algAllOff", None)], ""),
        ("TO_S", 1600, 1800, [("algTimeout", None)], ""),
        ("OUT_S", 2800, 1400, [("algUpdate", "DO_UPD"), (None, "HMI_DO")], ""),
        ("PSTOP_S", 4000, 1200, [(None, "TSTOP")], ""),
        ("PSTART_S", 4000, 1700, [(None, "TSTART")], ""),
    ]
    trans = [
        ("START", "INIT_S", "INIT"), ("INIT_S", "START", "1"),
        ("START", "DI_S", "DI"), ("DI_S", "START", "1"),
        ("START", "CMD_S", "CMD"), ("CMD_S", "OUT_S", "Changed"), ("CMD_S", "START", "NOT Changed"),
        ("START", "OFF_S", "ALL_OFF"), ("OFF_S", "OUT_S", "1"),
        ("START", "TO_S", "PULSE_END"), ("TO_S", "OUT_S", "Changed"), ("TO_S", "START", "NOT Changed"),
        ("OUT_S", "PSTOP_S", "StopPulse"), ("OUT_S", "PSTART_S", "StartPulse AND NOT StopPulse"),
        ("OUT_S", "START", "NOT StartPulse AND NOT StopPulse"),
        ("PSTOP_S", "PSTART_S", "StartPulse"), ("PSTOP_S", "START", "NOT StartPulse"),
        ("PSTART_S", "START", "1"),
    ]
    pos = {s[0]: (s[1], s[2]) for s in states}

    def st_xml(s):
        name, x, y, acts, com = s
        c = f' Comment="{com}"' if com else ""
        if not acts:
            return f'      <ECState Name="{name}"{c} x="{x}" y="{y}" />'
        a = "".join("\n        <ECAction" + (f' Algorithm="{al}"' if al else "") + (f' Output="{o}"' if o else "") + " />"
                    for al, o in acts)
        return f'      <ECState Name="{name}"{c} x="{x}" y="{y}">{a}\n      </ECState>'

    def tr_xml(t):
        s, d, cond = t
        x = (pos[s][0] + pos[d][0]) / 2
        y = (pos[s][1] + pos[d][1]) / 2
        return f'      <ECTransition Source="{s}" Destination="{d}" Condition="{escape(cond)}" x="{x}" y="{y}" />'

    algs = "\n".join(f'    <Algorithm Name="{n}">\n      <ST><![CDATA[{body}]]></ST>\n    </Algorithm>' for n, body in alg.items())
    return f"""<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE FBType SYSTEM "../LibraryElement.dtd">
<FBType GUID="{guid('IOTest16Logic')}" Name="IOTest16Logic" Comment="Basic Function Block Type" Namespace="{NS}">
  <Identification Standard="61499-2" />
  <VersionInfo Version="0.1" Author="{AUTHOR}" Date="{DATE}" Remarks="Version 0 I/O test: output requests, exclusive pairs, pulse outputs" />
  <InterfaceList>
    <EventInputs>
{events(ev_in)}
    </EventInputs>
    <EventOutputs>
{events(ev_out)}
    </EventOutputs>
    <InputVars>
{chr(10).join(decl(v) for v in ins)}
    </InputVars>
    <OutputVars>
{chr(10).join(decl(v) for v in outs)}
    </OutputVars>
  </InterfaceList>
  <BasicFB>
    <Attribute Name="FBType.Basic.Algorithm.Order" Value="{','.join(alg)}" />
    <InternalVars>
{chr(10).join(decl(v, with_id=False) for v in internal)}
    </InternalVars>
    <ECC>
{chr(10).join(st_xml(s) for s in states)}
{chr(10).join(tr_xml(t) for t in trans)}
    </ECC>
{algs}
  </BasicFB>
</FBType>
"""


# ----------------------------------------------------------------------------------------------------------
# IOTest16_HMI: the IThis service interface block
# ----------------------------------------------------------------------------------------------------------
# Labels go to the HMI with their own event REQ_LBL. INIT belongs to the service handshake, and the HMI
# cannot subscribe to it ("Event not found or not a HMI one"), so data sent WITH INIT never reaches a symbol.
HMI_IN_INIT = [f"LabelDI{c}" for c in CH] + [f"LabelDO{c}" for c in CH]
HMI_IN_DI = [f"DI{c}" for c in CH]
HMI_IN_DO = [f"DOSt{c}" for c in CH] + [f"EnDO{c}" for c in CH]
HMI_OUT_CMD = [f"CmdDO{c}" for c in CH]


def lid(name):
    """ID of a pin of IOTest16Logic."""
    return h16(f"LOGIC.{name}")


def hid(name):
    return h16(f"HMI.{name}")


def hmi_fbt():
    def ev(name, vars_):
        w = "".join(f'\n        <With Var="{v}" />' for v in vars_)
        return f'      <Event ID="{hid("ev." + name)}" Name="{name}">{w}\n      </Event>'

    def var(name, typ, com=""):
        c = f' Comment="{com}"' if com else ""
        return f'      <VarDeclaration ID="{hid(name)}" Name="{name}" Type="{typ}"{c} />'

    ins = [var("QI", "BOOL")] + [var(n, "STRING", "Label text") for n in HMI_IN_INIT] \
        + [var(n, "BOOL", "Input lamp") for n in HMI_IN_DI] \
        + [var(f"DOSt{c}", "BOOL", "Output state lamp") for c in CH] + [var(f"EnDO{c}", "BOOL", "Button enabled") for c in CH]
    outs = [var("QO", "BOOL", "Event Output Qualifier"), var("STATUS", "STRING", "Service Status")] \
        + [var(n, "BOOL", "Button: requested output state") for n in HMI_OUT_CMD] + [var("AllOff", "BOOL", "Button: all outputs off")]
    return f"""<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE FBType SYSTEM "../LibraryElement.dtd">
<FBType GUID="{guid('IOTest16_HMI')}" Name="IOTest16_HMI" Comment="Service Interface Function Block Type" Namespace="{NS}">
  <Identification Standard="61499-2" />
  <VersionInfo Version="0.1" Author="{AUTHOR}" Date="{DATE}" Remarks="template" />
  <InterfaceList>
    <EventInputs>
{ev("INIT", ["QI"])}
{ev("REQ_LBL", HMI_IN_INIT)}
{ev("REQ_DI", HMI_IN_DI)}
{ev("REQ_DO", HMI_IN_DO)}
    </EventInputs>
    <EventOutputs>
{ev("INITO", ["QO", "STATUS"])}
{ev("CMD", HMI_OUT_CMD)}
{ev("ALL_OFF", ["AllOff"])}
    </EventOutputs>
    <InputVars>
{chr(10).join(ins)}
    </InputVars>
    <OutputVars>
{chr(10).join(outs)}
    </OutputVars>
  </InterfaceList>
  <Service RightInterface="" LeftInterface="">
    <ServiceSequence Name="" />
  </Service>
</FBType>
"""


def hmi_opcua():
    rows = []
    for n in HMI_IN_INIT + HMI_IN_DI + HMI_IN_DO:
        rows.append(f"""  <OPCUAVariable UID="{hid(n)}" Enabled="false">
    <OPCUAAttribute Name="Exposed" Value="True" Locked="false" AttributeMask="True;True|False;True" />
    <Extensions>
      <Extension>
        <RTAddress>V1;${{VariableFullPath}}</RTAddress>
      </Extension>
    </Extensions>
  </OPCUAVariable>""")
    for n, trig in [(c, "CMD") for c in HMI_OUT_CMD] + [("AllOff", "ALL_OFF")]:
        rows.append(f"""  <OPCUAVariable UID="{hid(n)}" Enabled="false">
    <OPCUAAttribute Name="Exposed" Value="True" Locked="false" AttributeMask="True;True|False;True" />
    <Extensions>
      <Extension>
        <RTAddress>V1;${{VariableFullPath}};Trigger={trig}</RTAddress>
      </Extension>
    </Extensions>
  </OPCUAVariable>""")
    return ('<?xml version="1.0" encoding="utf-8"?>\n<OPCUAObject xmlns:xsd="http://www.w3.org/2001/XMLSchema" '
            'xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">\n' + "\n".join(rows) + "\n</OPCUAObject>\n")


# ----------------------------------------------------------------------------------------------------------
# IOTest16: the CAT network
# ----------------------------------------------------------------------------------------------------------
def cid(name):
    return h16(f"CAT.{name}")


def cat_fbt():
    iface = ([(f"LabelDI{c}", "STRING", None, f"Text next to input lamp {c}") for c in CH]
             + [(f"LabelDO{c}", "STRING", None, f"Text on output button {c}") for c in CH]
             + [(f"ExclDO{c}", "INT", "-1", f"Output that must never be on together with output {c}; -1 = none") for c in CH]
             + [(f"PulseDO{c}", "TIME", "T#0s", f"Pulse time of output {c}; T#0s = toggle") for c in CH])
    decls = "\n".join(
        f'      <VarDeclaration ID="{cid(n)}" Name="{n}" Type="{t}"' + (f' InitialValue="{iv}"' if iv else "") + f' Comment="{escape(c)}" />'
        for n, t, iv, c in iface)
    F = {n: cid("fb." + n) for n in ["EVENTCHAIN", "IThis", "Logic", "PulseTimer"] + [f"DI{c}" for c in CH] + [f"DO{c}" for c in CH]}

    fbs = [
        f'    <FB ID="{F["EVENTCHAIN"]}" Name="EVENTCHAIN" Type="EVENTCHAIN" x="700" y="500" Namespace="Runtime.Standard">\n'
        f"      <Parameter Name=\"$NAME\" Value=\"'APP_INIT'\" />\n      <Parameter Name=\"$PRIO\" Value=\"20\" />\n    </FB>",
        f'    <FB ID="{F["IThis"]}" Name="IThis" Type="IOTest16_HMI" x="2700" y="500" Namespace="{NS}">\n'
        f'      <Parameter Name="${hid("QI")}" Value="TRUE" />\n    </FB>',
        f'    <FB ID="{F["Logic"]}" Name="Logic" Type="IOTest16Logic" x="5300" y="500" Namespace="{NS}" />',
        f'    <FB ID="{F["PulseTimer"]}" Name="PulseTimer" Type="E_DELAY" x="7800" y="500" Namespace="IEC61499.Standard" />',
    ]
    for i, c in enumerate(CH):
        fbs.append(f'    <FB ID="{F["DI" + c]}" Name="DI{c}" Type="dISignal" x="{2600 + (i // 8) * 1000}" y="{7600 + (i % 8) * 420}" Namespace="SE.App2Base">\n'
                   f"      <Parameter Name=\"$Name\" Value=\"'$${{PATH}}DIn'\" />\n    </FB>")
        fbs.append(f'    <FB ID="{F["DO" + c]}" Name="DO{c}" Type="dOSignal" x="{5300 + (i // 8) * 1000}" y="{7600 + (i % 8) * 420}" Namespace="SE.App2Base">\n'
                   f"      <Parameter Name=\"$Name\" Value=\"'$${{PATH}}DOut'\" />\n    </FB>")
    inputs = "\n".join(f'    <Input ID="{cid(n)}" Name="{n}" x="500" y="{1900 + k * 60}" Type="Data" />' for k, (n, *_r) in enumerate(iface))

    def frame(name, x, y, w, h, color, text):
        return f"""    <Frame Name="{name}" X="{x}" Y="{y}" Width="{w}" Height="{h}">
      <Parameter Name="BackgroundColor" Value="{color}" />
      <Parameter Name="TextColor" Value="Black" />
      <Parameter Name="Font" Value="Microsoft Sans Serif, 9.75pt, style=Bold" />
      <Parameter Name="TextAlignment" Value="TopLeft" />
      <Parameter Name="MoveStyle" Value="AnyContained" />
      <Parameter Name="Text" Value="{text}" />
      <Parameter Name="NxtLayerIdentifier" Value="" />
    </Frame>"""
    frames = "\n".join([
        frame("FRAME0", 200, 200, 1800, 1300, "AliceBlue", "0 - INITIALIZATION"),
        frame("FRAME4", 2200, 200, 2400, 6800, "LightPink", "6 - HMI INTERFACE"),
        frame("FRAME1", 200, 1700, 1800, 8000, "Cornsilk", "1 - FUNCTIONAL INPUT INTERFACE (labels, exclusive pairs, pulse times)"),
        frame("FRAME2", 4800, 200, 4200, 5400, "Gainsboro", "5 - LOGICS"),
        frame("FRAME9", 2200, 7200, 6800, 3800, "PeachPuff", "3 - FIELD INTERFACE (DI00-DI15 from the input module, DO00-DO15 to the output module)"),
    ])

    X = "\n        <Attribute Name=\"Configuration.Connections.CrossReference\" Value=\"True\" />\n      "
    conn = lambda s, d: f'      <Connection Source="{s}" Destination="{d}">{X}</Connection>'
    ith = lambda pin: f'${F["IThis"]}.{hid(pin)}'
    ithe = lambda ev: f'${F["IThis"]}.{hid("ev." + ev)}'
    LOGIC_EVENTS = {'INIT', 'CMD', 'ALL_OFF', 'DI', 'PULSE_END', 'INITO', 'DO_UPD', 'HMI_DO', 'HMI_DI', 'TSTART', 'TSTOP'}
    lg = lambda pin: f'${F["Logic"]}.' + (lid('ev.' + pin) if pin in LOGIC_EVENTS else lid(pin))
    ev = [
        conn(f'${F["EVENTCHAIN"]}.EO', ithe("INIT")),
        conn(ithe("INITO"), lg("INIT")),
        conn(lg("INITO"), ithe("REQ_LBL")),  # labels to the HMI; independent of the ACK below
        conn(lg("INITO"), f'${F["EVENTCHAIN"]}.ACK'),
        conn(ithe("CMD"), lg("CMD")),
        conn(ithe("ALL_OFF"), lg("ALL_OFF")),
        conn(lg("HMI_DI"), ithe("REQ_DI")),
        conn(lg("HMI_DO"), ithe("REQ_DO")),
        conn(lg("TSTART"), f'${F["PulseTimer"]}.START'),
        conn(lg("TSTOP"), f'${F["PulseTimer"]}.STOP'),
        conn(f'${F["PulseTimer"]}.EO', lg("PULSE_END")),
    ] + [conn(f'${F["DI" + c]}.CNF', lg("DI")) for c in CH] + [conn(lg("DO_UPD"), f'${F["DO" + c]}.REQ') for c in CH]
    da = ([conn(f"${cid('LabelDI' + c)}", ith("LabelDI" + c)) for c in CH]
          + [conn(f"${cid('LabelDO' + c)}", ith("LabelDO" + c)) for c in CH]
          + [conn(f"${cid('ExclDO' + c)}", lg("Excl" + c)) for c in CH]
          + [conn(f"${cid('PulseDO' + c)}", lg("Pulse" + c)) for c in CH]
          + [conn(ith("CmdDO" + c), lg("Cmd" + c)) for c in CH]
          + [conn(f'${F["DI" + c]}.Out', lg("In" + c)) for c in CH]
          + [conn(lg("Out" + c), f'${F["DO" + c]}.Signal') for c in CH]
          + [conn(lg("Di" + c), ith("DI" + c)) for c in CH]
          + [conn(lg("St" + c), ith("DOSt" + c)) for c in CH]
          + [conn(lg("En" + c), ith("EnDO" + c)) for c in CH]
          + [conn(lg("PulseDT"), f'${F["PulseTimer"]}.DT')])
    return f"""<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE FBType SYSTEM "../LibraryElement.dtd">
<FBType GUID="{guid('IOTest16')}" Comment="CAT Function Block Type" Name="IOTest16" Format="2.0" Namespace="{NS}">
  <Attribute Name="HMI.Alias" Value="" />
  <Identification Standard="61499-2" />
  <VersionInfo Version="0.1" Author="{AUTHOR}" Date="{DATE}" Remarks="Version 0 I/O test panel for one TM3 16-in/16-out module pair" />
  <InterfaceList>
    <InputVars>
{decls}
    </InputVars>
  </InterfaceList>
  <FBNetwork>
{chr(10).join(fbs)}
{inputs}
{frames}
    <EventConnections>
{chr(10).join(ev)}
    </EventConnections>
    <DataConnections>
{chr(10).join(da)}
    </DataConnections>
  </FBNetwork>
</FBType>
"""


def cat_cfg():
    return f"""<?xml version="1.0" encoding="utf-8"?>
<CAT xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="IOTest16" CATFile="IOTest16\\IOTest16.fbt" SymbolDefFile="..\\HMI\\IOTest16\\IOTest16.def.cs" SymbolEventFile="..\\HMI\\IOTest16\\IOTest16.event.cs" DesignFile="..\\HMI\\IOTest16\\IOTest16.Design.resx" DocFile="IOTest16\\IOTest16.doc.xml" MetaFile="IOTest16\\IOTest16.meta.xml" Folder=".Commissioning" xmlns="http://www.nxtcontrol.com/IEC61499.xsd">
  <HMIInterface Name="IThis" FileName="IOTest16\\IOTest16_HMI.fbt" DocFile="IOTest16\\IOTest16_HMI.doc.xml" UsedInCAT="true">
    <Symbol Name="sDefault" FileName="..\\HMI\\IOTest16\\IOTest16_sDefault.cnv.cs">
      <DependentFiles>..\\HMI\\IOTest16\\IOTest16_sDefault.cnv.Designer.cs</DependentFiles>
      <DependentFiles>..\\HMI\\IOTest16\\IOTest16_sDefault.cnv.resx</DependentFiles>
      <DependentFiles>..\\HMI\\IOTest16\\IOTest16_sDefault.cnv.xml</DependentFiles>
    </Symbol>
    <MetaFile>IOTest16\\IOTest16_HMI.meta.xml</MetaFile>
  </HMIInterface>
  <Plugin Name="IEC61499Type=CAT_ASPMAP;Plugin=AvevaServerPlugin;$ItemType$=None" Project="{LIB}" Value="IOTest16\\IOTest16_CAT.aspmap.xml" />
  <Plugin Name="Plugin=OfflineParametrizationEditor;IEC61499Type=CAT_OFFLINE;$ItemType$=Content" Project="{LIB}" Value="IOTest16\\IOTest16_CAT.offline.xml" />
  <Plugin Name="Plugin=OfflineParametrizationEditor;IEC61499Type=CAT_OFFLINE;$ItemType$=None" Project="{LIB}" Value="IOTest16\\IOTest16_HMI.offline.xml" />
  <Plugin Name="Plugin=OPCUAConfigurator;IEC61499Type=CAT_OPCUA;$ItemType$=Content" Project="{LIB}" Value="IOTest16\\IOTest16_CAT.opcua.xml" />
  <Plugin Name="Plugin=OPCUAConfigurator;IEC61499Type=CAT_OPCUA;$ItemType$=None" Project="{LIB}" Value="IOTest16\\IOTest16_HMI.opcua.xml" />
  <Plugin Name="IEC61499Type=CAT_EngineeringMAPPING;Plugin=BulkEngineeringPlugin;$ItemType$=None" Project="{LIB}" Value="IOTest16\\IOTest16_CAT.engineering.xml" />
  <Plugin Name="IEC61499Type=CAT_EngineeringMAPPING;Plugin=BulkEngineeringPlugin;$ItemType$=None" Project="{LIB}" Value="IOTest16\\IOTest16_CAT.EngInstAttrMapping.xml" />
  <HWConfiguration xsi:nil="true" />
</CAT>
"""


DOC = """<?xml version="1.0" encoding="UTF-8"?>
<section xmlns="http://docbook.org/ns/docbook" xmlns:xi="http://www.w3.org/2001/XInclude" xmlns:xlink="http://www.w3.org/1999/xlink">
  <info>
    <author>
      <personname>
        <firstname>Flexbridge</firstname>
        <surname>AB</surname>
      </personname>
    </author>
    <abstract>
      <para>{text}</para>
    </abstract>
  </info>
  <para>
  </para>
</section>
"""


# ----------------------------------------------------------------------------------------------------------
# HMI symbol sDefault: 16 input lamps with labels, 16 output buttons with state lamps and labels
# ----------------------------------------------------------------------------------------------------------
def symbol_designer():
    decl, ctors, body, shapes, fields = [], [], [], [], []
    pd = [0]

    def led(name, tag, x, y, visible=True):
        ids = []
        for _ in range(3):
            pd[0] += 1
            ids.append(f"propertyDictionary{pd[0]}")
        decl.extend(f"\t\t\tNxtControl.GuiFramework.PropertyDictionary {i} = new NxtControl.GuiFramework.PropertyDictionary();" for i in ids)
        ctors.append(f"\t\t\tthis.{name} = new System.HMI.Symbols.Base.Led<bool>();")
        props = [
            f"\t\t\tthis.{name}.BeginInit();",
            f"\t\t\tthis.{name}.ColorFrame = new NxtControl.Drawing.Color(\"LedFrameColor\");",
            f"\t\t\tthis.{name}.DesignMatrix = new NxtControl.Drawing.Matrix2D(2D, 0D, 0D, 2D, {x}D, {y}D);",
            f"\t\t\tthis.{name}.FrameSize = 33F;",
            f"\t\t\tthis.{name}.IsOnlyInput = true;",
            f"\t\t\tthis.{name}.Name = \"{name}\";",
            f"\t\t\t{ids[1]}.Add(\"Color\", new NxtControl.Drawing.Color(\"LedFalseColor\"));",
            f"\t\t\t{ids[2]}.Add(\"Color\", new NxtControl.Drawing.Color(\"LedTrueColor\"));",
            f"\t\t\t{ids[0]}.Add(\"Color\", new NxtControl.Drawing.Color(\"LedFalseColor\"));",
            f"\t\t\tthis.{name}.Ranges.Clear();",
            f"\t\t\tthis.{name}.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(false, {ids[1]}));",
            f"\t\t\tthis.{name}.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(true, {ids[2]}));",
            f"\t\t\tthis.{name}.Ranges.DefaultPropertyValues = {ids[0]};",
            f"\t\t\tthis.{name}.TagName = \"{tag}\";",
        ]
        if not visible:
            props.append(f"\t\t\tthis.{name}.Visible = false;")
        props.append(f"\t\t\tthis.{name}.EndInit();")
        body.extend(props)
        shapes.append(name)
        fields.append(f"\t\tprivate System.HMI.Symbols.Base.Led<bool> {name};")

    def label(name, tag, x, y):
        ctors.append(f"\t\t\tthis.{name} = new System.HMI.Symbols.Base.Label();")
        body.extend([
            f"\t\t\tthis.{name}.BeginInit();",
            f"\t\t\tthis.{name}.BorderStyle = System.Windows.Forms.BorderStyle.None;",
            f"\t\t\tthis.{name}.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, {x}D, {y}D);",
            f"\t\t\tthis.{name}.Font = new NxtControl.Drawing.Font(\"Arial\", 10F, System.Drawing.FontStyle.Regular);",
            f"\t\t\tthis.{name}.FontScale = false;",
            f"\t\t\tthis.{name}.IsOnlyInput = true;",
            f"\t\t\tthis.{name}.Name = \"{name}\";",
            f"\t\t\tthis.{name}.Pen = new NxtControl.Drawing.Pen(\"LabelPen\");",
            f"\t\t\tthis.{name}.TagName = \"{tag}\";",
            f"\t\t\tthis.{name}.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;",
            f"\t\t\tthis.{name}.TextColor = new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0)));",
            f"\t\t\tthis.{name}.EndInit();",
        ])
        shapes.append(name)
        fields.append(f"\t\tprivate System.HMI.Symbols.Base.Label {name};")

    def button(name, tag, x, y):
        ctors.append(f"\t\t\tthis.{name} = new System.HMI.Symbols.Base.SwitchButton();")
        body.extend([
            f"\t\t\tthis.{name}.BeginInit();",
            f"\t\t\tthis.{name}.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, {x}D, {y}D);",
            f"\t\t\tthis.{name}.FalseImage = new NxtControl.Drawing.ImageHolder();",
            f"\t\t\tthis.{name}.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();",
            f"\t\t\tthis.{name}.Font = new NxtControl.Drawing.Font(\"ButtonFont\");",
            f"\t\t\tthis.{name}.Name = \"{name}\";",
            f"\t\t\tthis.{name}.TagName = \"{tag}\";",
            f"\t\t\tthis.{name}.TrueImage = new NxtControl.Drawing.ImageHolder();",
            f"\t\t\tthis.{name}.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();",
            f"\t\t\tthis.{name}.Value = false;",
            f"\t\t\tthis.{name}.EndInit();",
        ])
        shapes.append(name)
        fields.append(f"\t\tprivate System.HMI.Symbols.Base.SwitchButton {name};")

    def text(name, txt, x, y, size=12):
        ctors.append(f"\t\t\tthis.{name} = new NxtControl.GuiFramework.FreeText();")
        body.extend([
            f"\t\t\tthis.{name}.Color = new NxtControl.Drawing.Color(\"LabelTextColor\");",
            f"\t\t\tthis.{name}.Font = new NxtControl.Drawing.Font(\"HMI Monospace\", {size}F, System.Drawing.FontStyle.Regular);",
            f"\t\t\tthis.{name}.Location = new NxtControl.Drawing.PointF({x}D, {y}D);",
            f"\t\t\tthis.{name}.Name = \"{name}\";",
            f"\t\t\tthis.{name}.Text = \"{txt}\";",
        ])
        shapes.append(name)
        fields.append(f"\t\tprivate NxtControl.GuiFramework.FreeText {name};")

    text("txtTitle", "I/O test", 16, 12, 14)
    text("txtInstance", "", 160, 12, 14)
    for col, (x0, part) in enumerate([(16, "Station terminal (channels 0-7)"), (760, "Control panel (channels 8-15)")]):
        text(f"txtCol{col}", part, x0, 48, 10)
    for i, c in enumerate(CH):
        x0 = 16 + (i // 8) * 744
        y = 84 + (i % 8) * 40
        led(f"ledDI{c}", f"DI{c}", x0, y)
        label(f"lblDI{c}", f"LabelDI{c}", x0 + 30, y)
        button(f"btnDO{c}", f"CmdDO{c}", x0 + 330, y - 4)
        led(f"ledDO{c}", f"DOSt{c}", x0 + 400, y)
        label(f"lblDO{c}", f"LabelDO{c}", x0 + 430, y)
        led(f"ledEn{c}", f"EnDO{c}", x0 + 400, y, visible=False)
    button("btnAllOff", "AllOff", 16, 420)
    text("txtAllOff", "All outputs off", 90, 424, 10)

    return ("using System;\nusing System.ComponentModel;\nusing System.Collections;\nusing NxtControl.GuiFramework;\n\n"
            f"namespace {NS}.Symbols.IOTest16\n{{\n\t/// <summary>\n\t/// Summary description for sDefault.\n\t/// </summary>\n"
            "\tpartial class sDefault\n\t{\n\n\t\t#region Component Designer generated code\n\t\t/// <summary>\n"
            "\t\t/// Required method for Designer support - do not modify\n\t\t/// the contents of this method with the code editor.\n"
            "\t\t/// </summary>\n\t\tprivate void InitializeComponent()\n\t\t{\n"
            + "\n".join(decl) + "\n" + "\n".join(ctors) + "\n" + "\n".join(body) + "\n"
            + "\t\t\tthis.Shapes.AddRange(new System.ComponentModel.IComponent[] {\n"
            + ",\n".join(f"\t\t\tthis.{s}" for s in shapes) + "});\n"
            + "\t\t\tthis.SymbolSize = new System.Drawing.Size(1480, 470);\n\n\t\t}\n"
            + "\n".join(fields) + "\n\t\t#endregion\n\t}\n}\n")


def symbol_code():
    wires = "\n".join(
        f"\t\t\tledEn{c}.ValueChanged += (s, e) => btnDO{c}.Enabled = ToBool(ledEn{c}.Value);\n"
        f"\t\t\tledDO{c}.ValueChanged += (s, e) => SyncButton(btnDO{c}, ledDO{c}.Value);" for c in CH)
    return f"""using System;
using NxtControl.GuiFramework;
using NxtControl.Services;

namespace {NS}.Symbols.IOTest16
{{
	/// <summary>
	/// I/O test panel. Code here only changes what is shown; every decision is taken in the controller (IOTest16Logic).
	/// </summary>
	public partial class sDefault : NxtControl.GuiFramework.HMISymbol
	{{
		public sDefault()
		{{
			InitializeComponent();
			// Grey out a button while the controller does not allow it (partner output on, or another pulse running).
			// Bring a button back in line with the real output state (refused request, pulse ended, all off).
{wires}
		}}

		static bool ToBool(object value)
		{{
			return value != null && Convert.ToBoolean(value);
		}}

		static void SyncButton(System.HMI.Symbols.Base.SwitchButton button, object state)
		{{
			bool on = ToBool(state);
			if (ToBool(button.Value) != on)
				button.Value = on;
		}}

		public override void ConnectionStateChanged(int chanelId, bool connected)
		{{
			base.ConnectionStateChanged(chanelId, connected);
			if (!connected) return;
			var hmi = ServiceProvider.GetService<IHMIManagementService>();
			txtInstance.Text = hmi.GetCATInstanceInfo(this.TagName).Name;
		}}
	}}
}}
"""


def symbol_mapping():
    ins = "\n".join(f'    <Input Name="{n}" Type="{"STRING" if n.startswith("Label") else "BOOL"}" />' for n in HMI_IN_INIT + HMI_IN_DI + HMI_IN_DO)
    outs = "\n".join(f'    <Output Name="{n}" Type="BOOL" />' for n in HMI_OUT_CMD + ["AllOff"])
    return f"""<?xml version="1.0" encoding="utf-8"?>
<Mapping>
  <EventInputs>
    <Event Name="REQ_LBL">{';'.join(HMI_IN_INIT)}</Event>
    <Event Name="REQ_DI">{';'.join(HMI_IN_DI)}</Event>
    <Event Name="REQ_DO">{';'.join(HMI_IN_DO)}</Event>
  </EventInputs>
  <EventOutputs>
    <Event Name="CMD">{';'.join(HMI_OUT_CMD)}</Event>
    <Event Name="ALL_OFF">AllOff</Event>
  </EventOutputs>
  <Inputs>
{ins}
  </Inputs>
  <Outputs>
{outs}
  </Outputs>
</Mapping>
"""


def def_cs():
    return ("using System;\nusing NxtControl.GuiFramework;\nusing NxtControl.Services;\n\n\n"
            "#region Definitions;\n#region IOTest16_HMI;\n#endregion IOTest16_HMI;\n\n#endregion Definitions;\n\n")


def event_cs():
    return ("using System;\nusing NxtControl.GuiFramework;\nusing NxtControl.Services;\n\n"
            "#region Definitions;\n\n#endregion Definitions;\n")


# ----------------------------------------------------------------------------------------------------------
# Library project files
# ----------------------------------------------------------------------------------------------------------
def lib_dfbproj():
    cat = "IOTest16"
    return f"""<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" DefaultTargets="Build">
  <PropertyGroup>
    <ProjectGuid>{{{G['iec']}}}</ProjectGuid>
    <ProjectTypeGuids>{TYPE_IEC}</ProjectTypeGuids>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">Windows</Platform>
    <OutputType>Library</OutputType>
    <RootNamespace>{LIB}</RootNamespace>
    <AssemblyName>{LIB}</AssemblyName>
    <NxtVersion>25.0.0.0</NxtVersion>
    <CheckConnectionsStrictly>TRUE</CheckConnectionsStrictly>
    <HardwareConfigurationMigrationVersion>1</HardwareConfigurationMigrationVersion>
    <MultiUserSupport>true</MultiUserSupport>
    <ProjectType>IEC61499</ProjectType>
    <CheckGenericInstances>False</CheckGenericInstances>
    <ConvertStringValues>False</ConvertStringValues>
    <HMIProject>{LIB}.HMI</HMIProject>
    <IsConnectionIdModified>true</IsConnectionIdModified>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Platform)' == 'AnyCPU' " />
  <PropertyGroup Condition=" '$(Platform)' == 'Windows' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)' == 'Debug' ">
    <OutputPath>bin\\Default\\</OutputPath>
    <DebugSymbols>True</DebugSymbols>
    <DebugType>Full</DebugType>
    <Optimize>False</Optimize>
    <IntermediateOutputPath>obj\\Default\\</IntermediateOutputPath>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)' == 'Release' ">
    <OutputPath>bin\\Default\\</OutputPath>
    <DebugSymbols>False</DebugSymbols>
    <DebugType>None</DebugType>
    <Optimize>True</Optimize>
    <IntermediateOutputPath>obj\\Default\\</IntermediateOutputPath>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|Windows' ">
    <Version>1.0</Version>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)' == 'Verify' ">
    <OutputPath>bin\\Verify\\</OutputPath>
    <IntermediateOutputPath>obj\\Verify\\</IntermediateOutputPath>
  </PropertyGroup>
  <ItemGroup>
    <None Include="..\\General\\Folders.xml" />
    <None Include="..\\General\\ProjectInfo.xml" />
    <None Include="{cat}\\{cat}.cfg">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <IEC61499Type>CAT</IEC61499Type>
    </None>
    <None Include="{cat}\\{cat}.doc.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
    </None>
    <None Include="{cat}\\{cat}.meta.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
    </None>
    <None Include="{cat}\\{cat}_HMI.doc.xml">
      <DependentUpon>{cat}_HMI.fbt</DependentUpon>
    </None>
    <None Include="{cat}\\{cat}_HMI.meta.xml">
      <DependentUpon>{cat}_HMI.fbt</DependentUpon>
    </None>
    <None Include="{cat}\\{cat}_CAT.aspmap.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <IEC61499Type>CAT_ASPMAP</IEC61499Type>
      <Plugin>AvevaServerPlugin</Plugin>
    </None>
    <None Include="{cat}\\{cat}_CAT.engineering.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <IEC61499Type>CAT_EngineeringMAPPING</IEC61499Type>
      <Plugin>BulkEngineeringPlugin</Plugin>
    </None>
    <None Include="{cat}\\{cat}_CAT.EngInstAttrMapping.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <IEC61499Type>CAT_EngineeringMAPPING</IEC61499Type>
      <Plugin>BulkEngineeringPlugin</Plugin>
    </None>
    <None Include="{cat}\\{cat}_HMI.offline.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <Plugin>OfflineParametrizationEditor</Plugin>
      <IEC61499Type>CAT_OFFLINE</IEC61499Type>
    </None>
    <None Include="{cat}\\{cat}_HMI.opcua.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <Plugin>OPCUAConfigurator</Plugin>
      <IEC61499Type>CAT_OPCUA</IEC61499Type>
    </None>
  </ItemGroup>
  <ItemGroup>
    <Compile Include="IOTest16Logic.fbt">
      <IEC61499Type>Basic</IEC61499Type>
      <Parent>.Commissioning</Parent>
    </Compile>
    <Compile Include="{cat}\\{cat}.fbt">
      <IEC61499Type>CAT</IEC61499Type>
      <Parent>.Commissioning</Parent>
    </Compile>
    <Compile Include="{cat}\\{cat}_HMI.fbt">
      <IEC61499Type>CAT</IEC61499Type>
      <DependentUpon>{cat}\\{cat}.fbt</DependentUpon>
      <Usage>Private</Usage>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <Content Include="{cat}\\{cat}_CAT.offline.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <Plugin>OfflineParametrizationEditor</Plugin>
      <IEC61499Type>CAT_OFFLINE</IEC61499Type>
    </Content>
    <Content Include="{cat}\\{cat}_CAT.opcua.xml">
      <DependentUpon>{cat}.fbt</DependentUpon>
      <Plugin>OPCUAConfigurator</Plugin>
      <IEC61499Type>CAT_OPCUA</IEC61499Type>
    </Content>
  </ItemGroup>
  <ItemGroup>
    <Folder Include="Configuration" />
    <Folder Include="License" />
    <Folder Include="Log" />
  </ItemGroup>
  <ItemGroup>
    <Reference Include="Runtime.Base">
      <Version>25.0.1.2</Version>
    </Reference>
    <Reference Include="SE.App2Base">
      <Version>25.0.1.5</Version>
    </Reference>
    <Reference Include="SE.App2CommonProcess">
      <Version>25.0.1.5</Version>
    </Reference>
  </ItemGroup>
  <Import Project="$(SharpDevelopBinPath)\\NxtControl.Build.61499.Targets" />
</Project>
"""


def lib_hmi_csproj():
    hmi_head = (TUT / "SE.HVAC" / "HMI" / "SE.HVAC.HMI.csproj").read_text(encoding="utf-8-sig")
    props = hmi_head[: hmi_head.index("<ItemGroup>")]
    props = (props.replace("{CB96616A-3CBA-42BD-80F9-4002674C1E6B}", "{" + G["hmi"] + "}")
             .replace("SE.HVAC.HMI", f"{LIB}.HMI").replace("<AssemblyVersion>24.1.0.0</AssemblyVersion>", "<AssemblyVersion>25.0.0.0</AssemblyVersion>"))
    c = "IOTest16"
    return props + f"""<ItemGroup>
    <Compile Include="AssemblyInfo.cs" />
    <Compile Include="Colors\\ProjectColors.cs" />
    <Compile Include="Colors\\ProjectDrawingObjects.cs" />
    <Compile Include="{c}\\{c}.def.cs" />
    <Compile Include="{c}\\{c}.event.cs" />
    <Compile Include="{c}\\{c}_sDefault.cnv.cs" />
    <Compile Include="{c}\\{c}_sDefault.cnv.Designer.cs">
      <DependentUpon>{c}_sDefault.cnv.cs</DependentUpon>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <None Include="Colors\\ProjectColors.xml" />
    <None Include="Colors\\ProjectDrawingObjects.xml" />
    <None Include="GeneralProperties\\Properties.xml" />
    <None Include="GraphicsList.xml" />
    <None Include="ImageStorage\\ImageStorage.xml" />
    <None Include="Languages\\neutral\\Dictionary.Resources.xml" />
    <EmbeddedResource Include="Alarms\\AlarmClasses.xml" />
    <EmbeddedResource Include="Alarms\\SystemAlarmClasses.xml" />
    <EmbeddedResource Include="Configurations\\HistoryTrend.xml" />
    <EmbeddedResource Include="Configurations\\Journalling.xml" />
    <EmbeddedResource Include="Configurations\\TagValueEditor.xml" />
    <None Include="{c}\\{c}.Design.resx" />
    <EmbeddedResource Include="{c}\\{c}_sDefault.cnv.resx">
      <DependentUpon>{c}_sDefault.cnv.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="{c}\\{c}_sDefault.cnv.xml">
      <DependentUpon>{c}_sDefault.cnv.cs</DependentUpon>
    </EmbeddedResource>
  </ItemGroup>
  <ItemGroup>
    <Reference Include="CommunicationProfile">
      <HintPath>CommunicationProfile</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="HMIBaseSymbols">
      <HintPath>HMIBaseSymbols</HintPath>
    </Reference>
    <Reference Include="NxtControl.ComponentModel">
      <HintPath>NxtControl.ComponentModel</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="NxtControl.GuiFramework">
      <HintPath>NxtControl.GuiFramework</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="SE.App2Base.HMI">
      <Version>25.0.1.5</Version>
      <HintPath>SE.App2Base.HMI</HintPath>
    </Reference>
    <Reference Include="SE.App2CommonProcess.HMI">
      <Version>25.0.1.5</Version>
      <HintPath>SE.App2CommonProcess.HMI</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Data" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Windows.Forms" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <Import Project="$(SharpDevelopBinPath)\\SharpDevelop.Build.CSharp.targets" />
</Project>
"""


def from_tutorial(rel, replacements):
    text = (TUT / rel).read_text(encoding="utf-8-sig")
    for a, b in replacements:
        text = text.replace(a, b)
    return text


def assembly_info(title):
    return f"""#region Using directives

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#endregion

[assembly: AssemblyTitle("{title}")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Flexbridge AB")]
[assembly: AssemblyProduct("{title}")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("25.0.0.0")]
"""


def build_library(out):
    L = out / LIB
    I = L / "IEC61499"
    H = L / "HMI"
    c = "IOTest16"
    write(I / f"{LIB}.dfbproj", lib_dfbproj())
    write(I / "IOTest16Logic.fbt", logic_fbt())
    write(I / c / f"{c}.fbt", cat_fbt())
    write(I / c / f"{c}.cfg", cat_cfg())
    write(I / c / f"{c}_HMI.fbt", hmi_fbt())
    write(I / c / f"{c}.doc.xml", DOC.format(text="I/O test panel for one TM3 16-input / 16-output module pair (version 0)."))
    write(I / c / f"{c}_HMI.doc.xml", DOC.format(text="HMI and OPC UA interface of IOTest16."))
    write(I / c / f"{c}.meta.xml", "", bom=False)
    write(I / c / f"{c}_HMI.meta.xml", "", bom=False)
    write(I / c / f"{c}_CAT.offline.xml", '<?xml version="1.0" encoding="utf-8"?>\n<OfflineParameterModel xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" IsDefaultEventSelectionDialogsHidden="0" />\n')
    write(I / c / f"{c}_HMI.offline.xml", '<?xml version="1.0" encoding="utf-8"?>\n<OfflineParameterModel xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" IsDefaultEventSelectionDialogsHidden="0" />\n')
    write(I / c / f"{c}_CAT.opcua.xml", '<?xml version="1.0" encoding="utf-8"?>\n<OPCUAComplexObject xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" />\n')
    write(I / c / f"{c}_HMI.opcua.xml", hmi_opcua())
    write(I / c / f"{c}_CAT.aspmap.xml", f'<?xml version="1.0" encoding="UTF-8"?>\n<ASPMapping xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ID="{c}" AssetType="Device" />\n', bom=False)
    write(I / c / f"{c}_CAT.engineering.xml", '<?xml version="1.0" encoding="UTF-8"?>\n<TagMapping xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" ID="0" Level="Root" />\n', bom=False)
    write(I / c / f"{c}_CAT.EngInstAttrMapping.xml", '<?xml version="1.0" encoding="utf-8"?>\n<CAT xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Id="0" />\n')

    write(H / f"{LIB}.HMI.csproj", lib_hmi_csproj())
    write(H / "AssemblyInfo.cs", assembly_info(f"{LIB}.HMI"))
    write(H / c / f"{c}.def.cs", def_cs())
    write(H / c / f"{c}.event.cs", event_cs())
    write(H / c / f"{c}_sDefault.cnv.cs", symbol_code())
    write(H / c / f"{c}_sDefault.cnv.Designer.cs", symbol_designer())
    write(H / c / f"{c}_sDefault.cnv.xml", symbol_mapping())
    # Support files every HMI project needs (EAE refuses to load the project without Colors\ProjectDrawingObjects.cs)
    write(H / "Colors" / "ProjectColors.cs", f"namespace {LIB} {{\n    \n    \n    public class ProjectColors {{\n        \n        static ProjectColors() {{\n        }}\n    }}\n}}\n", bom=False)
    write(H / "Colors" / "ProjectDrawingObjects.cs", f"namespace {LIB} {{\n    \n    \n    public class ProjectBrushes {{\n        \n        static ProjectBrushes() {{\n        }}\n    }}\n    \n    public class ProjectPens {{\n        \n        static ProjectPens() {{\n        }}\n    }}\n    \n    public class ProjectFonts {{\n        \n        static ProjectFonts() {{\n        }}\n    }}\n}}\n", bom=False)
    write(H / "Colors" / "ProjectColors.xml", '<?xml version="1.0" encoding="utf-8"?>\n<Colors xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/Colors.xsd" />\n')
    write(H / "Colors" / "ProjectDrawingObjects.xml", '<?xml version="1.0" encoding="utf-8"?>\n<DrawingObjects xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/Colors.xsd" />\n')
    write(H / "GeneralProperties" / "Properties.xml", '<?xml version="1.0" encoding="utf-8"?>\n<GeneralProperties xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/GeneralProperties.xsd" />\n')
    write(H / "GraphicsList.xml", f'<?xml version="1.0" encoding="utf-8"?>\n<GraphicsList xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="{LIB}" Version="1.6.0.0" xmlns="http://www.nxtcontrol.com/IEC61499.xsd">\n  <Graphics Name="Graphics" IsExternal="false">\n    <Graphics />\n  </Graphics>\n</GraphicsList>\n')
    for rel in ["Alarms/AlarmClasses.xml", "Alarms/SystemAlarmClasses.xml", "Configurations/HistoryTrend.xml", "Configurations/Journalling.xml",
                "Configurations/TagValueEditor.xml", "ImageStorage/ImageStorage.xml", "Languages/neutral/Dictionary.Resources.xml"]:
        shutil.copyfile(ROOT / "HMI" / rel, _mk(H / rel))
    shutil.copyfile(TUT / "SE.HVAC" / "HMI" / "Timer" / "Timer.Design.resx", H / c / f"{c}.Design.resx")
    shutil.copyfile(TUT / "SE.HVAC" / "HMI" / "Timer" / "Timer_sDefault.cnv.resx", H / c / f"{c}_sDefault.cnv.resx")

    hw = from_tutorial(
        "SE.HVAC/HwConfiguration/SE.HVAC.HwConfiguration.hwconfigproj",
        [("{58C79F0E-E1DC-47FF-B2FC-12D9397542D3}", "{" + G["hw"] + "}"), ("SE.HVAC.HwConfiguration", f"{LIB}.HwConfiguration"),
         ("<LibraryName>SE.HVAC</LibraryName>", f"<LibraryName>{LIB}</LibraryName>")])
    # our library does not reference SE.AppSequence or Standard.OPCUAClient (EAE warning MSB3245)
    hw = re.sub(r'    <Reference Include="(SE\.AppSequence|Standard\.OPCUAClient)\.HwConfiguration">.*?</Reference>\n', "", hw, flags=re.S)
    write(L / "HwConfiguration" / f"{LIB}.HwConfiguration.hwconfigproj", hw.split("  <ItemGroup>\n    <ProjectReference")[0]
          + "  <Import Project=\"$(SharpDevelopBinPath)\\SharpDevelop.Build.CSharp.targets\" />\n</Project>\n")
    write(L / "HwConfiguration" / "AssemblyInfo.cs", assembly_info(f"{LIB}.HwConfiguration"))
    shutil.copyfile(ROOT / "HwConfiguration" / "ImageStorage" / "ImageStorage.xml", _mk(L / "HwConfiguration" / "ImageStorage" / "ImageStorage.xml"))

    write(L / "AssetLinkData" / f"{LIB}.AssetLinkData.assetLinkDataproj", from_tutorial(
        "SE.HVAC/AssetLinkData/SE.HVAC.AssetLinkData.assetLinkDataproj",
        [("{47E36D5B-43D3-4B70-92AB-65468477A1B8}", "{" + G["ald"] + "}"), ("SE.HVAC.AssetLinkData", f"{LIB}.AssetLinkData"),
         ("<LibraryName>SE.HVAC</LibraryName>", f"<LibraryName>{LIB}</LibraryName>")]))
    for rel in ["Config.json", "EngineeringHubConfiguration.config", "Asset Manifest/AssetFacets.json", "Asset Manifest/AssetRelations.json",
                "Asset Manifest/Assets.json", "Asset Manifest/EcoRTDevices.json", "Asset Manifest/FacetRelations.json"]:
        shutil.copyfile(ROOT / "AssetLinkData" / rel, _mk(L / "AssetLinkData" / rel))

    write(L / "ATVHMIPlugin" / f"{LIB}.ATVHMIPlugin.atvdisplayproj", from_tutorial(
        "SE.HVAC/ATVHMIPlugin/SE.HVAC.ATVHMIPlugin.atvdisplayproj",
        [("{DB1D53B1-100D-422E-BFBB-AF02BBEDD207}", "{" + G["atv"] + "}"), ("SE.HVAC.ATVHMIPlugin", f"{LIB}.ATVHMIPlugin"),
         ("<LibraryName>SE.HVAC</LibraryName>", f"<LibraryName>{LIB}</LibraryName>")]))
    write(L / "ATVHMIPlugin" / "AssemblyInfo.cs", assembly_info(f"{LIB}.ATVHMIPlugin"))

    write(L / "General" / "ProjectInfo.xml", f'<?xml version="1.0" encoding="utf-8"?>\n<ProjectInfo xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="{LIB}" Guid="{{{G["iec"]}}}" Version="1.6.0.0" xmlns="http://www.nxtcontrol.com/IEC61499.xsd" />\n')
    write(L / "General" / "Folders.xml", f"""<?xml version="1.0" encoding="utf-8"?>
<Folders xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="{LIB}" Version="1.6.0.0" xmlns="http://www.nxtcontrol.com/IEC61499.xsd">
  <Folder Type="Basic" Name=".Commissioning">
    <Items />
  </Folder>
  <Folder Type="CAT" Name=".Commissioning">
    <Items />
  </Folder>
</Folders>
""")


def _mk(path):
    path.parent.mkdir(parents=True, exist_ok=True)
    return path


# ----------------------------------------------------------------------------------------------------------
# Patched copies of the solution's own files
# ----------------------------------------------------------------------------------------------------------
def patch_root(out):
    sln = (ROOT / "festo-mps-400-eae.sln").read_text(encoding="utf-8-sig")
    projs = [(TYPE_IEC, LIB, f"{LIB}\\IEC61499\\{LIB}.dfbproj", G["iec"]),
             (TYPE_HMI, f"{LIB}.HMI", f"{LIB}\\HMI\\{LIB}.HMI.csproj", G["hmi"]),
             (TYPE_HW, f"{LIB}.HwConfiguration", f"{LIB}\\HwConfiguration\\{LIB}.HwConfiguration.hwconfigproj", G["hw"]),
             (TYPE_ALD, f"{LIB}.AssetLinkData", f"{LIB}\\AssetLinkData\\{LIB}.AssetLinkData.assetLinkDataproj", G["ald"]),
             (TYPE_ATV, f"{LIB}.ATVHMIPlugin", f"{LIB}\\ATVHMIPlugin\\{LIB}.ATVHMIPlugin.atvdisplayproj", G["atv"])]
    if LIB not in sln:
        block = "".join(f'Project("{t}") = "{n}", "{p}", "{{{g}}}"\nEndProject\n' for t, n, p, g in projs)
        sln = sln.replace("Global\n", block + "Global\n", 1)
        cfg = "".join(f"\t\t{{{g}}}.{c}|Windows.{k} = {c}|Windows\n" for *_x, g in projs for c in ("Debug", "Release") for k in ("ActiveCfg", "Build.0"))
        sln = sln.replace("\tEndGlobalSection\nEndGlobal", cfg + "\tEndGlobalSection\nEndGlobal")
    write(out / "festo-mps-400-eae.sln", sln, bom=True)

    def add_ref(rel, include, g, name):
        text = (ROOT / rel).read_text(encoding="utf-8-sig")
        if include not in text:
            ref = (f'  <ItemGroup>\n    <ProjectReference Include="{include}">\n      <Project>{{{g.lower()}}}</Project>\n'
                   f"      <Name>{name}</Name>\n    </ProjectReference>\n  </ItemGroup>\n")
            i = text.rindex("  <Import Project=")
            text = text[:i] + ref + text[i:]
        write(out / rel, text, bom=True)

    add_ref("IEC61499/IEC61499.dfbproj", f"..\\{LIB}\\IEC61499\\{LIB}.dfbproj", G["iec"], LIB)
    add_ref("HMI/HMI.csproj", f"..\\{LIB}\\HMI\\{LIB}.HMI.csproj", G["hmi"], f"{LIB}.HMI")
    add_ref("HwConfiguration/HwConfiguration.hwconfigproj", f"..\\{LIB}\\HwConfiguration\\{LIB}.HwConfiguration.hwconfigproj", G["hw"], f"{LIB}.HwConfiguration")


def main():
    if len(sys.argv) != 2:
        sys.exit(__doc__)
    out = Path(sys.argv[1])
    if out.resolve() == ROOT.resolve():
        sys.exit("Write to a staging folder, not into the repository.")
    build_library(out)
    patch_root(out)
    print("written to", out)


if __name__ == "__main__":
    main()
