"""Fill the version 0 content into the type skeletons EAE created (library Flexbridge.FestoMPS400).

EAE creates the library, the CAT IOTest16 (with IThis : IOTest16_HMI and symbol sDefault) and the basic
FB IOTest16Logic. This script replaces only the content of those files and keeps what EAE owns:
the file header of each type (GUID, version info, author), the pin IDs EAE gave the HMI block, and all
project files, folder entries and the .cfg (where it only adds UsedInCAT="true" to the HMI interface).

Usage (from the repository root, with the solution CLOSED in EAE):
  .venv\\Scripts\\python tools\\v0_fill.py            fill in place
  .venv\\Scripts\\python tools\\v0_fill.py --check    only show what would change

Content comes from tools/v0_scaffold.py (network, ECC and ST, symbol).
"""
import importlib.util
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
LIB = "Flexbridge.FestoMPS400"
L = ROOT / LIB

spec = importlib.util.spec_from_file_location("v0_scaffold", ROOT / "tools" / "v0_scaffold.py")
gen = importlib.util.module_from_spec(spec)
spec.loader.exec_module(gen)
gen.LIB = gen.NS = LIB  # namespace of the EAE-created library


def eae_head(text):
    """Everything EAE wrote before <InterfaceList> (XML declaration, DOCTYPE, FBType tag, version info)."""
    i = text.index("<InterfaceList")
    return text[:i].rstrip(" ")


def body(text):
    i = text.index("<InterfaceList")
    return text[i:]


def main():
    check = "--check" in sys.argv
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")

    hmi_path = L / "IEC61499" / "IOTest16" / "IOTest16_HMI.fbt"
    hmi_eae = hmi_path.read_text(encoding="utf-8-sig")
    # IDs EAE gave the standard pins of IThis; reuse them instead of ours
    eae_ids = {m.group(2): m.group(1) for m in re.finditer(r'ID="([0-9A-F]{16})" Name="(\w+)"', hmi_eae)}
    remap = {gen.hid("QI"): eae_ids["QI"], gen.hid("QO"): eae_ids["QO"], gen.hid("STATUS"): eae_ids["STATUS"],
             gen.hid("ev.INIT"): eae_ids["INIT"], gen.hid("ev.INITO"): eae_ids["INITO"]}

    def ids(text):
        for ours, theirs in remap.items():
            text = text.replace(ours, theirs)
        return text

    files = {}
    p = L / "IEC61499" / "IOTest16" / "IOTest16.fbt"
    files[p] = eae_head(p.read_text(encoding="utf-8-sig")) + ids(body(gen.cat_fbt()))
    p = L / "IEC61499" / "IOTest16Logic.fbt"
    files[p] = eae_head(p.read_text(encoding="utf-8-sig")) + body(gen.logic_fbt())
    files[hmi_path] = eae_head(hmi_eae) + ids(body(gen.hmi_fbt()))
    files[L / "IEC61499" / "IOTest16" / "IOTest16_HMI.opcua.xml"] = ids(gen.hmi_opcua())
    files[L / "HMI" / "IOTest16" / "IOTest16_sDefault.cnv.cs"] = gen.symbol_code()
    files[L / "HMI" / "IOTest16" / "IOTest16_sDefault.cnv.Designer.cs"] = gen.symbol_designer()
    files[L / "HMI" / "IOTest16" / "IOTest16_sDefault.cnv.xml"] = gen.symbol_mapping()

    # IThis is part of our CAT network, so the CAT definition must say so (UsedInCAT="true"), as in every
    # reference CAT with IThis in its network. Without it the runtime does not register IThis as the CAT's
    # HMI accessor ("FB instance not found or is not a HMI accessor"). EAE's wizard leaves it out.
    p = L / "IEC61499" / "IOTest16" / "IOTest16.cfg"
    cfg = p.read_text(encoding="utf-8-sig")
    if 'UsedInCAT="true"' not in cfg:
        cfg = re.sub(r'(<HMIInterface Name="IThis"[^>]*?)\s*>', r'\1 UsedInCAT="true">', cfg, count=1)
    files[p] = cfg

    for path, text in files.items():
        old = path.read_text(encoding="utf-8-sig") if path.exists() else ""
        print(f"{'would write' if check else 'write'} {path.relative_to(ROOT)}  ({len(old)} -> {len(text)} chars)")
        if not check:
            path.write_text(text, encoding="utf-8")  # no BOM
    print("EAE IDs reused for IThis:", ", ".join(f"{k}={eae_ids[k]}" for k in ("INIT", "INITO", "QI", "QO", "STATUS")))


if __name__ == "__main__":
    main()
