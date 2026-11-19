"""Symbolic links of a version 1 station in the hardware configuration of its PLC.

A link value is the path of a signal block, written with IDs:
  <resource ID>.<instance in RES0>.<child>[.<grandchild>].<signal block in the child (UID, else ID)>.DIn|DOut
The script reads all IDs from the files, so it stays right if EAE changes them. Channels the station does not
use are cleared (they held the links of the version 0 panel). Run it with the solution CLOSED.

Usage (repository root):
  .venv\\Scripts\\python tools\\v1_symlinks.py DS --check    show the mapping of Distributing, change nothing
  .venv\\Scripts\\python tools\\v1_symlinks.py TS            write the links of Testing
"""
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SYS = next((ROOT / "IEC61499" / "System").glob("*.system")).with_suffix("")
LIB = ROOT / "Flexbridge.FestoMPS400" / "IEC61499"
LIBSE = Path(r"C:\ProgramData\Schneider Electric\Libraries\SE.App2CommonProcess-25.0.1.5\Files")

# control console: the same on every station (ControlConsole inside the station CAT, children named by Festo tag)
CONSOLE = {
    "DI08": ("Console.S1_Start", "pv", "DIn"),        # S1 START
    "DI09": ("Console.S2_Stop", "pv", "DIn"),         # S2 STOP (normally closed)
    "DI10": ("Console.S3_AutoMan", "pv", "DIn"),      # S3 AUTO/MAN
    "DI11": ("Console.S4_Reset", "pv", "DIn"),        # S4 RESET
    "DO08": ("Console.P1_StartLamp", "value", "DOut"),  # P1 START lamp
    "DO09": ("Console.P2_ResetLamp", "value", "DOut"),  # P2 RESET lamp
    "DO10": ("Console.P3_Q1Lamp", "value", "DOut"),     # P3 lamp Q1
    "DO11": ("Console.P4_Q2Lamp", "value", "DOut"),     # P4 lamp Q2
}

# channel -> (child path, signal block in the child, DIn/DOut); Festo meaning for the record
STATIONS = {
    "DS": {
        "device": "a0026ceb-2e0f-4635-9d99-a98c0e68dc61",   # PLC_DS
        "instance": "DS01", "cat": "Distributing",
        "map": {
            "DO00": ("Ejector", "cmd", "DOut"),            # 1M1 push out workpiece
            # 1M1 on ("push out workpiece") RETRACTS the ejecting cylinder (Festo: "extend magazine slide (retract
            # ejecting cylinder)"). At rest the cylinder is extended: DI01 (1B2) is on. Confirmed 2026-11-16: with
            # DI01 as open feedback the Actuator raised a feedback failure at rest.
            "DI01": ("Ejector", "fbClose", "DIn"),         # 1B2 cylinder extended  = rest (closed)
            "DI02": ("Ejector", "fbOpen", "DIn"),          # 1B1 cylinder retracted = 1M1 on (open)
            "DO01": ("Vacuum", "cmdOpen", "DOut"),         # 2M1 vacuum on
            "DO02": ("Vacuum", "cmdClose", "DOut"),        # 2M2 ejection pulse
            "DI03": ("Vacuum", "fbOpen", "DIn"),           # 2B1 workpiece gripped
            "DO03": ("Swivel", "cmdClose", "DOut"),        # 3M1 swivel to magazine
            "DO04": ("Swivel", "cmdOpen", "DOut"),         # 3M2 swivel to downstream station
            "DI04": ("Swivel", "fbClose", "DIn"),          # 3B1 at magazine
            "DI05": ("Swivel", "fbOpen", "DIn"),           # 3B2 at downstream station
            "DI06": ("MagazineEmpty", "pv", "DIn"),        # B4 magazine empty
            "DI07": ("DownstreamFree", "pv", "DIn"),       # IP_FI downstream station free
            **CONSOLE,
        },
    },
    "TS": {
        "device": "c440123d-ccc1-447a-bdaa-3b96ba6d77e9",   # PLC_TS
        "instance": "TS01", "cat": "Testing",
        "map": {
            "DI00": ("PartAvailable", "pv", "DIn"),        # PART_AV workpiece available
            "DI01": ("NotBlack", "pv", "DIn"),             # B2 workpiece is not black
            "DI02": ("LightBarrier", "pv", "DIn"),         # B4 safety light barrier
            "DI03": ("HeightOk", "pv", "DIn"),             # height comparator: height correct
            "DI04": ("Lift", "fbOpen", "DIn"),             # 1B1 lift raised   = open
            "DI05": ("Lift", "fbClose", "DIn"),            # 1B2 lift lowered  = closed
            "DI06": ("Ejector", "fbClose", "DIn"),         # 2B1 ejector retracted = closed (no extended sensor)
            "DO00": ("Lift", "cmdClose", "DOut"),          # 1M1 lower the lift
            "DO01": ("Lift", "cmdOpen", "DOut"),           # 1M2 raise the lift
            "DO02": ("Ejector", "cmd", "DOut"),            # 2M1 extend the ejector
            "DO03": ("AirSlide", "value", "DOut"),         # 3M1 air slide on
            **CONSOLE,
        },
    },
}
CHILD_TYPES = {"Actuator": LIB / "Actuator" / "Actuator.fbt", "Actuator2Op": LIB / "Actuator2Op" / "Actuator2Op.fbt",
               "DigitalInput": LIBSE / "DigitalInput" / "DigitalInput.fbt",
               "DigitalOutput": LIBSE / "DigitalOutput" / "DigitalOutput.fbt",
               "ControlConsole": LIB / "ControlConsole" / "ControlConsole.fbt"}


def blocks(text):
    """name -> (step ID: UID if present else ID, type)"""
    return {m.group(3): (m.group(2) or m.group(1), m.group(4))
            for m in re.finditer(r'<FB ID="(\w+)"(?: UID="(\w+)")? Name="(\w+)" Type="(\w+)"', text)}


def main():
    args = [a for a in sys.argv[1:] if not a.startswith("--")]
    check = "--check" in sys.argv
    if not args or args[0] not in STATIONS:
        sys.exit(f"Usage: v1_symlinks.py {'|'.join(STATIONS)} [--check]")
    st = STATIONS[args[0]]
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")
    dev = SYS / st["device"]
    res_file = next(dev.glob("*.sysres"))
    res_id = res_file.stem
    inst = blocks(res_file.read_text(encoding="utf-8-sig"))[st["instance"]][0]
    children = blocks((LIB / st["cat"] / f"{st['cat']}.fbt").read_text(encoding="utf-8-sig"))
    inner = {t: blocks(p.read_text(encoding="utf-8-sig")) for t, p in CHILD_TYPES.items()}

    hcf = dev / f"{st['device']}.hcf"
    raw = hcf.read_bytes()
    bom = raw.startswith(b"\xef\xbb\xbf")
    text = raw.decode("utf-8-sig")
    out = []
    for ch in [f"DI{i:02d}" for i in range(16)] + [f"DO{i:02d}" for i in range(16)]:
        if ch in st["map"]:
            child, sig, kind = st["map"][ch]
            steps, blk = [], children           # follow Console.S1_Start ... level by level
            for name in child.split("."):
                sid, stype = blk[name]
                steps.append(sid)
                blk = inner[stype]
            value = f"{res_id}.{inst}.{'.'.join(steps)}.{blk[sig][0]}.{kind}"
            label = f"{st['instance']}.{child}.{sig}.{kind}"
        else:
            value, label = "", "(cleared)"
        pat = rf'(<ParameterValue Name="{ch}" Value=")[^"]*(" IsSymlink="true" />)'
        if len(re.findall(pat, text)) != 1:
            sys.exit(f"{ch}: expected exactly one channel entry in {hcf.name}")
        text = re.sub(pat, lambda m: m.group(1) + value + m.group(2), text)
        out.append(f"  {ch}  {label:38} {value}")
    print("\n".join(out))
    if not check:
        hcf.write_bytes((b"\xef\xbb\xbf" if bom else b"") + text.encode("utf-8"))
        print(f"written: {hcf.relative_to(ROOT)}")


if __name__ == "__main__":
    main()
