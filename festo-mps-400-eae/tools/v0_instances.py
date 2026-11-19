"""Fill the version 0 panel instances: parameters (labels, exclusive pairs, pulse times) and symbolic links.

EAE creates the devices, resources, hardware configuration, application and IOTest16 instances. This
script then:
  * sets the 64 parameters of each instance, in the application layer and in the mapped resource copy
    (values from the knowledge graph, as in docs/version0/instance-parameters.md);
  * writes the symbolic link of every TM3 channel of the module pair that belongs to the instance.

All IDs are read from the files EAE wrote. Run only with the solution CLOSED:
  .venv\\Scripts\\python tools\\v0_instances.py [--check]
"""
import importlib.util
import re
import sys
import unicodedata
from pathlib import Path
from xml.sax.saxutils import escape

ROOT = Path(__file__).resolve().parent.parent
SYSTEM = next((ROOT / "IEC61499" / "System").glob("*.system"))
SYSDIR = SYSTEM.with_suffix("")
CAT_FBT = ROOT / "Flexbridge.FestoMPS400" / "IEC61499" / "IOTest16" / "IOTest16.fbt"

spec = importlib.util.spec_from_file_location("v0_params", ROOT / "tools" / "v0_params.py")
params = importlib.util.module_from_spec(spec)
spec.loader.exec_module(params)

# instance name in EAE -> (entry in v0_params.INSTANCES, module pair on its PLC: 1 or 2)
INSTANCE_MAP = {"DS": ("DS", 1), "TS": ("TS", 1), "CV": ("CV_AB", 1), "CV_AB": ("CV_AB", 1), "CV_CD": ("CV_CD", 2),
                "HS2": ("HS2", 1), "PS": ("PS", 2), "HS6": ("HS6", 1), "SS": ("SS", 2)}


def ascii_text(text):
    text = text.replace("⚠ ", "CHECK ").replace("⚠", "CHECK").replace("…", "...")
    return unicodedata.normalize("NFKD", text).encode("ascii", "ignore").decode()


def st_string(text):
    """IEC 61131 STRING literal, XML-escaped for an attribute."""
    return escape("'" + ascii_text(text).replace("$", "$$").replace("'", "$'") + "'", {'"': "&quot;"})


def wanted_values(entry_name):
    """Parameter name -> value for one instance, from the knowledge graph."""
    entry = next(e for e in params.INSTANCES if e[0] == entry_name)
    _inst, _dev, _plc, _pair, stype, excl_pairs, pulses = entry
    excl = {}
    for a, b in excl_pairs:
        excl[a], excl[b] = b, a
    values = {}
    if stype is None:
        labels_di = [f"DI{c:02d}" for c in range(16)]
        labels_do = [f"DO{c:02d}" for c in range(16)]
    else:
        st = params.load(f"station-types/{stype}.yaml")
        sig_in = {s["address"]: s for s in st["signals"]["inputs"]}
        sig_out = {s["address"]: s for s in st["signals"]["outputs"]}
        mark = "CHECK " if stype in ("processing", "sorting") else ""
        labels_di, labels_do = [], []
        for ch in range(16):
            if ch < 8:
                si, so = sig_in[f"I{ch}"], sig_out[f"O{ch}"]
                labels_di.append((mark if ch in (1, 2) else "") + params.label(f"I{ch}", si.get("symbol"), si["meaning"]))
                labels_do.append(params.label(f"O{ch}", so.get("symbol"), so["meaning"]) if so.get("symbol") else params.label(f"O{ch}", "spare"))
            else:
                labels_di.append(params.label(f"Panel I{ch - 8}", params.PANEL_IN[ch - 8]))
                labels_do.append(params.label(f"Panel Q{ch - 8}", params.PANEL_OUT[ch - 8]))
    for ch in range(16):
        c = f"{ch:02d}"
        values[f"LabelDI{c}"] = st_string(labels_di[ch])
        values[f"LabelDO{c}"] = st_string(labels_do[ch])
        values[f"ExclDO{c}"] = str(excl.get(ch, -1))
        values[f"PulseDO{c}"] = pulses.get(ch, "T#0s")
    return values


def set_parameters(fb_xml, var_ids, values):
    """Rewrite the <Parameter> list of one FB element: EAE's order first, then the missing ones."""
    head = re.match(r"\s*<FB [^>]*?(/?)>", fb_xml)
    tag = head.group(0)
    indent = re.match(r"\s*", fb_xml).group(0).rsplit("\n", 1)[-1]  # spaces before <FB, without the line break
    lines = [f'{indent}  <Parameter Name="${var_ids[name]}" Value="{value}" />' for name, value in values.items()]
    open_tag = tag[:-2].rstrip() + ">" if tag.endswith("/>") else tag
    return f"{open_tag}\n" + "\n".join(lines) + f"\n{indent}</FB>"


def main():
    check = "--check" in sys.argv
    if (ROOT / ".lock_sln").exists() and not check:
        sys.exit("The solution is open in EAE (.lock_sln exists). Close it first.")
    cat = CAT_FBT.read_text(encoding="utf-8-sig")
    iface = cat[cat.index("<InterfaceList"):cat.index("</InterfaceList>")]
    var_ids = {n: i for i, n in re.findall(r'<VarDeclaration ID="([0-9A-F]+)" Name="(\w+)"', iface)}
    inner = {n: i for i, n in re.findall(r'<FB ID="([0-9A-F]+)" Name="(D[IO]\d\d)"', cat)}
    assert len(var_ids) >= 64 and len(inner) == 32, (len(var_ids), len(inner))

    layer = next(SYSDIR.glob("*/*.syslay"))
    files = {layer: layer.read_text(encoding="utf-8-sig")}
    devices = {}
    for sysres in SYSDIR.glob("*/*.sysres"):
        dev_id = sysres.parent.name
        files[sysres] = sysres.read_text(encoding="utf-8-sig")
        hcf = sysres.parent / f"{dev_id}.hcf"
        files[hcf] = hcf.read_text(encoding="utf-8-sig")
        devices[dev_id] = (sysres, hcf, re.search(r'<Resource [^>]*ID="([0-9A-F]+)"', files[sysres]).group(1))

    fb_pattern = r'(?s)\s*<FB ID="([0-9A-F]+)" Name="(\w+)" Type="IOTest16"[^>]*?(?:/>|>.*?</FB>)'
    for path in list(files):
        text = files[path]
        if not path.suffix in (".syslay", ".sysres"):
            continue
        for m in reversed(list(re.finditer(fb_pattern, text))):
            name = m.group(2)
            if name not in INSTANCE_MAP:
                print(f"skip unknown instance {name} in {path.name}")
                continue
            new = set_parameters(m.group(0), var_ids, wanted_values(INSTANCE_MAP[name][0]))
            text = text[:m.start()] + new + text[m.end():]
        files[path] = text

    # symbolic links: resource id . instance id in the resource . channel block id . DIn/DOut
    for dev_id, (sysres, hcf, res_id) in devices.items():
        text = files[hcf]
        for fb_id, name in re.findall(r'<FB ID="([0-9A-F]+)" Name="(\w+)" Type="IOTest16"', files[sysres]):
            pair = INSTANCE_MAP.get(name, (None, None))[1]
            if pair is None:
                continue
            suffix = "" if pair == 1 else "_1"
            for module, kind, end in ((f"TM3DI16_G{suffix}", "DI", "DIn"), (f"TM3DQ16R_G{suffix}", "DO", "DOut")):
                block = re.search(r"(?s)<ConfigurationBaseItem>\s*<Name>" + re.escape(module) + r"</Name>.*?</ParameterValues>", text)
                if not block:
                    print(f"{dev_id}: module {module} not found for {name}")
                    continue
                part = block.group(0)
                for ch in range(16):
                    path_value = f"{res_id}.{fb_id}.{inner[f'{kind}{ch:02d}']}.{end}"
                    part = re.sub(rf'<ParameterValue Name="{kind}{ch:02d}" Value="[^"]*" IsSymlink="true" />',
                                  f'<ParameterValue Name="{kind}{ch:02d}" Value="{path_value}" IsSymlink="true" />', part)
                text = text[:block.start()] + part + text[block.end():]
                print(f"{hcf.parent.name[:8]} {module:<13} -> {name} ({res_id}.{fb_id}.<{kind}xx>.{end})")
        files[hcf] = text

    for path, text in files.items():
        old = path.read_text(encoding="utf-8-sig")
        if text != old:
            print(f"{'would write' if check else 'write'} {path.relative_to(ROOT)}")
            if not check:
                path.write_text(text, encoding="utf-8-sig" if path.read_bytes()[:3] == b"\xef\xbb\xbf" else "utf-8")


if __name__ == "__main__":
    main()
