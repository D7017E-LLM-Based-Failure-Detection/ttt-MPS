"""Search and read the help of an installed EAE library.

The help of a library is a zip archive of HTML pages:
    C:\\ProgramData\\Schneider Electric\\Libraries\\<Library>-<version>\\Documentation\\<Library>.help
    C:\\ProgramData\\CATLibraries\\Shared\\<Library>-<version>\\Documentation\\<Library>.help

Usage, from the repository root:
    .venv\\Scripts\\python tools\\libhelp.py LIBRARY toc [FILTER]     list help topics (title and page)
    .venv\\Scripts\\python tools\\libhelp.py LIBRARY find TEXT        pages whose text contains TEXT
    .venv\\Scripts\\python tools\\libhelp.py LIBRARY show PAGE [...]  print pages as plain text

LIBRARY is a name such as SE.App2CommonProcess; the newest installed version is used. It can also be the path
of a .help file, for example EAE's own help in the Buildtime folder Documentation\\en\\EcoStruxureAutomationExpert.help.
"""
import html
import re
import sys
import zipfile
from pathlib import Path

STORES = [Path(r"C:\ProgramData\Schneider Electric\Libraries"), Path(r"C:\ProgramData\CATLibraries\Shared")]


def find_help(library: str) -> Path:
    # a path to a .help file is used as it is (e.g. EAE's own help:
    # "C:\Program Files\Schneider Electric\EcoStruxure Automation Expert - Buildtime 25.0\Documentation\en\EcoStruxureAutomationExpert.help")
    if library.lower().endswith(".help") and Path(library).is_file():
        return Path(library)
    found = []
    for store in STORES:
        for folder in store.glob(f"{library}-*"):
            version = tuple(int(p) for p in folder.name.rsplit("-", 1)[1].split(".") if p.isdigit())
            for help_file in (folder / "Documentation").glob("*.help"):
                found.append((version, help_file))
    if not found:
        sys.exit(f"No help found for library {library}")
    return max(found)[1]


def page_text(raw: bytes) -> str:
    text = raw.decode("utf-8", errors="replace")
    text = re.sub(r"(?is)<(script|style|head)\b.*?</\1>", " ", text)
    text = re.sub(r"(?i)</(tr|p|div|h\d|li|table)>|<br\s*/?>", "\n", text)
    text = re.sub(r"(?i)</t[dh]>", " | ", text)
    text = html.unescape(re.sub(r"<[^>]+>", "", text))
    lines = [re.sub(r"[ \t\xa0]+", " ", line).strip() for line in text.splitlines()]
    return "\n".join(line for line in lines if line and line != "|")


def toc(archive: zipfile.ZipFile) -> list[tuple[str, str]]:
    entries = []
    for name in archive.namelist():
        if name.lower().endswith(".hhc"):
            content = archive.read(name).decode("utf-8", errors="replace")
            for block in re.findall(r"(?is)<object[^>]*>(.*?)</object>", content):
                title = re.search(r'(?i)name="Name"\s+value="([^"]*)"', block)
                local = re.search(r'(?i)name="Local"\s+value="([^"]*)"', block)
                if title and local:
                    entries.append((html.unescape(title.group(1)), local.group(1)))
    return entries


def main(args: list[str]) -> int:
    if len(args) < 2:
        print(__doc__)
        return 2
    library, command, rest = args[0], args[1], args[2:]
    help_file = find_help(library)
    with zipfile.ZipFile(help_file) as archive:
        if command == "toc":
            needle = rest[0].lower() if rest else ""
            for title, local in toc(archive):
                if needle in title.lower():
                    print(f"{title}  [{local}]")
        elif command == "find":
            needle = " ".join(rest).lower()
            for name in archive.namelist():
                if name.lower().endswith((".htm", ".html")):
                    text = page_text(archive.read(name))
                    if needle in text.lower():
                        print(f"{name}: {text.splitlines()[0][:100] if text else ''}")
        elif command == "show":
            for page in rest:
                print(f"===== {page}")
                print(page_text(archive.read(page)))
        else:
            print(__doc__)
            return 2
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv[1:]))
