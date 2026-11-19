"""Point the copied CAT chains at each other instead of the library.

Chains: Actuator / ActuatorBaseExt / ActuatorBase (from Valve) and Actuator2Op / Actuator2OpBaseExt /
Actuator2OpBase (from Valve2Op). Safe to run again: what is already fixed stays as it is.

EAE's copy and paste (2026-11-16) created the three types in Flexbridge.FestoMPS400 but left their inner
references on the library originals (Actuator contains ValveBaseExt, ActuatorBaseExt contains ValveBase),
kept the plugin entries of the library (project SE.App2CommonProcess, files of ValveBase/ValveControl), and
did not copy the OPC UA files. This script fixes that. Run it with the solution CLOSED.

Usage (repository root):
  .venv\\Scripts\\python tools\\v1_actuator_refs.py --check     show what would change
  .venv\\Scripts\\python tools\\v1_actuator_refs.py             change the files

Instance names inside the CATs (valveBaseExt, valveBase) are left as they are.
"""
import re
import shutil
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
LIB = ROOT / "Flexbridge.FestoMPS400"
IEC = LIB / "IEC61499"
NS = "Flexbridge.FestoMPS400"
SRC = Path(r"C:\ProgramData\Schneider Electric\Libraries\SE.App2CommonProcess-25.0.1.5\Files")

# library type -> our copy, for both chains (Valve -> Actuator, Valve2Op -> Actuator2Op).
# Only the copied types; all other library children (ValveLp, valveLogic, ...) stay library types.
CHAINS = {"Valve": "Actuator", "Valve2Op": "Actuator2Op"}
TYPES = {}
for lib, ours in CHAINS.items():
    TYPES[f"{lib}BaseExt"] = f"{ours}BaseExt"
    TYPES[f"{lib}Base"] = f"{ours}Base"
OURS = [n for lib, ours in CHAINS.items() for n in (ours, f"{ours}BaseExt", f"{ours}Base")]
# instance names inside the CATs, as used in symbol tag paths (lower-case first letter)
INSTANCES = {t[0].lower() + t[1:]: o[0].lower() + o[1:] for t, o in TYPES.items()}
OPCUA = {  # library file -> our file (copied only if EAE did not)
    f"{lib}{sfx}/{lib}{sfx}_{kind}.opcua.xml": f"{ours}{sfx}/{ours}{sfx}_{kind}.opcua.xml"
    for lib, ours in CHAINS.items() for sfx in ("", "BaseExt", "Base") for kind in ("CAT", "HMI")
}
LEFTOVER_DIRS = ["ValveControl", "ValveControlBaseExt"]

changes = []


def read(p):
    raw = p.read_bytes()
    bom = raw.startswith(b"\xef\xbb\xbf")
    return raw.decode("utf-8-sig"), bom


def write(p, text, bom, check):
    if not check:
        p.write_bytes((b"\xef\xbb\xbf" if bom else b"") + text.encode("utf-8"))


def fix_type_refs(text):
    """Type="ValveBaseExt" ... Namespace="SE.App2CommonProcess" -> our type and namespace (FB and SubCAT tags)."""
    def tag(m):
        t = m.group(0)
        typ = re.search(r'Type="(\w+)"', t).group(1)
        if typ in TYPES:
            t = t.replace(f'Type="{typ}"', f'Type="{TYPES[typ]}"').replace('Namespace="SE.App2CommonProcess"', f'Namespace="{NS}"')
        return t
    return re.sub(r'<(?:FB|SubCAT) [^>]*Type="\w+"[^>]*>', tag, text)


def fix_cfg(name, text):
    text = fix_type_refs(text)
    text = re.sub(r"<MetaFile>[^<]*</MetaFile>", f"<MetaFile>{name}\\\\{name}_HMI.meta.xml</MetaFile>", text)
    # plugin entries: drop those that point at library files (ValveBase\..., ValveControl\..., ...),
    # drop exact duplicates, and give the rest our project name
    seen, lines = set(), []
    for ln in text.split("\n"):
        if re.search(r'<Plugin [^>]*Value="Valve\w*\\', ln):
            continue
        if "<Plugin " in ln:
            if ln.strip() in seen:
                continue
            seen.add(ln.strip())
        lines.append(ln)
    text = "\n".join(lines).replace('Project="SE.App2CommonProcess"', f'Project="{NS}"')
    return text


def main():
    check = "--check" in sys.argv
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")

    for name in OURS:
        if not (IEC / name).exists():
            changes.append(f"skip {name} (not in the library)")
            continue
        for p, fn in [(IEC / name / f"{name}.cfg", lambda t, n=name: fix_cfg(n, t)), (IEC / name / f"{name}.fbt", fix_type_refs)]:
            old, bom = read(p)
            new = fn(old)
            if new != old:
                changes.append(f"{p.relative_to(ROOT)}: {sum(1 for a, b in zip(old.splitlines(), new.splitlines()) if a != b) + abs(len(old.splitlines()) - len(new.splitlines()))} lines")
                write(p, new, bom, check)

    # symbols: embed our *Base symbols, not the library's; tag paths use our instance names
    for p in (LIB / "HMI").glob("Actuator*/*.cs"):
        old, bom = read(p)
        new = old
        for lib_t, our_t in TYPES.items():
            new = re.sub(rf"SE\.App2CommonProcess\.Symbols\.{lib_t}\b", f"{NS}.Symbols.{our_t}", new)

        def tag(m):
            def part(x):
                low = x[:1].lower() + x[1:]
                if x in INSTANCES:            # library instance name: valve2OpBase -> actuator2OpBase
                    return INSTANCES[x]
                if low in INSTANCES.values():  # our name with a capital: ActuatorBase -> actuatorBase
                    return low
                return x
            return 'TagName = "' + ".".join(part(x) for x in m.group(1).split(".")) + '"'
        new = re.sub(r'TagName = "([^"]+)"', tag, new)
        if new != old:
            changes.append(f"{p.relative_to(ROOT)}: symbol references / tag paths")
            write(p, new, bom, check)

    # OPC UA files the paste did not copy
    for src, dst in OPCUA.items():
        d = IEC / dst
        if not (SRC / src).exists() or not d.parent.exists():
            continue
        if not d.exists():
            changes.append(f"copy {src} -> {d.relative_to(ROOT)}")
            if not check:
                shutil.copyfile(SRC / src, d)

    # leftovers of the library's ValveControl plugin entries
    proj = IEC / f"{NS}.dfbproj"
    old, bom = read(proj)
    new = re.sub(r'\s*<(None|Content) Include="ValveControl\w*\\[^"]*"(?: />|>.*?</\1>)', "", old, flags=re.S)
    if new != old:
        changes.append(f"{proj.relative_to(ROOT)}: ValveControl entries removed")
        write(proj, new, bom, check)
    for d in LEFTOVER_DIRS:
        p = IEC / d
        if p.exists():
            files = [f.name for f in p.iterdir()]
            changes.append(f"delete folder {p.relative_to(ROOT)} {files}")
            if not check:
                shutil.rmtree(p)

    print(("Would change:" if check else "Changed:") + "\n  " + "\n  ".join(changes))


if __name__ == "__main__":
    main()
