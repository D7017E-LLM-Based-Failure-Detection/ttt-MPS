"""Set EnProgReq = TRUE in the Owner service of every device we command from logic.

Why (found 2026-11-16, SE.App2Base ownerBasic): a REQ_PROGLOCAL from logic sets the Program bit (16#8) of the
requested owner only when EnProgReq is TRUE; with the default FALSE it only sets the local bit (16#4). If the
request reaches the device before its Owner service has initialised, or if 16#4 was persisted, the owner is
left at 16#4 = "Unknown" and the device ignores the program. With EnProgReq = TRUE the logic's request always
gives 16#C = Program Local. EnProgReq is not persisted; its offline default is applied at every start.

Written the way the library sets owner parameters of nested children (see Valve_CAT.offline.xml: a chain of
OfflineParameterModel elements with the block IDs down to the Owner's IThis).

Usage (repository root, solution CLOSED):
  .venv\\Scripts\\python tools\\v1_owner.py --check
  .venv\\Scripts\\python tools\\v1_owner.py
"""
import re
import sys
import xml.dom.minidom as minidom
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
IEC = ROOT / "Flexbridge.FestoMPS400" / "IEC61499"
EN_PROG_REQ = "450272A1C9C061CB"   # Owner_HMI.EnProgReq (SE.App2Base Owner)

# path inside each device type down to the Owner's IThis: <BaseExt>.<serviceManager>.<owner>.<IThis>
DEVICE_PATH = {
    "DigitalOutput": ["1", "6", "27", "17"],     # digitalOutputBaseExt.serviceManager.owner.IThis
    "Actuator": ["16", "19", "27", "17"],        # actuatorBaseExt.serviceManager.owner.IThis
    "Actuator2Op": ["18", "24", "27", "17"],     # actuator2OpBaseExt.serviceManager.owner.IThis
}


def child(parent, pid):
    for n in parent.childNodes:
        if n.nodeType == n.ELEMENT_NODE and n.tagName == "OfflineParameterModel" and n.getAttribute("ID") == pid:
            return n
    doc = parent.ownerDocument
    n = doc.createElement("OfflineParameterModel")
    n.setAttribute("ID", pid)
    n.setAttribute("IsDefaultEventSelectionDialogsHidden", "0")
    parent.appendChild(n)
    return n


def set_default(root, path, value):
    node = root
    for pid in path:
        node = child(node, pid)
    for n in node.getElementsByTagName("OfflineAttributeModel"):
        if n.getAttribute("Name") == "Default Value":
            changed = n.getAttribute("Value") != value
            n.setAttribute("Value", value)
            return changed
    a = root.ownerDocument.createElement("OfflineAttributeModel")
    a.setAttribute("Name", "Default Value")
    a.setAttribute("Value", value)
    a.setAttribute("Locked", "false")
    node.appendChild(a)
    return True


def update(path, entries, check):
    raw = path.read_bytes()
    bom = raw.startswith(b"\xef\xbb\xbf")
    doc = minidom.parseString(raw)
    root = doc.documentElement
    n = sum(set_default(root, p, v) for p, v in entries)
    text = doc.toprettyxml(indent="  ", encoding="utf-8").decode("utf-8")
    text = "\n".join(line for line in text.splitlines() if line.strip()) + "\n"
    text = text.replace('<?xml version="1.0" encoding="utf-8"?>', '<?xml version="1.0" encoding="utf-8"?>', 1)
    print(f"{'would write' if check else 'write'} {path.relative_to(ROOT)}: {n} value(s) set")
    if n and not check:
        path.write_bytes((b"\xef\xbb\xbf" if bom else b"") + text.encode("utf-8"))


def main():
    check = "--check" in sys.argv
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")
    # library DigitalOutput children commanded from logic: the console lamps, and the air slide of Testing
    for cat in ("ControlConsole", "Testing"):
        src = (IEC / cat / f"{cat}.fbt").read_text(encoding="utf-8-sig")
        outs = re.findall(r'<FB ID="(\w+)" Name="(\w+)" Type="DigitalOutput"', src)
        if outs:
            update(IEC / cat / f"{cat}_CAT.offline.xml",
                   [([fid] + DEVICE_PATH["DigitalOutput"] + [EN_PROG_REQ], "TRUE") for fid, _n in outs], check)
            print(f"  {cat}:", ", ".join(n for _f, n in outs))
    # our actuators: set it in the type, so every Ejector/Vacuum/Swivel gets it
    for t in ("Actuator", "Actuator2Op"):
        update(IEC / t / f"{t}_CAT.offline.xml", [(DEVICE_PATH[t] + [EN_PROG_REQ], "TRUE")], check)


if __name__ == "__main__":
    main()
