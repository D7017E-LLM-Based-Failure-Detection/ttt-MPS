"""Turn a Markdown document of this repository into a PDF (A4), images included.

Markdown -> HTML with the `markdown` package, then Microsoft Edge (headless) prints the HTML to PDF.
Edge renders the SVG diagrams and PNG screenshots exactly as a browser shows them.

Usage (from the repository root):
  .venv\\Scripts\\python tools\\md2pdf.py docs\\version0\\knowledge-transfer.md
  .venv\\Scripts\\python tools\\md2pdf.py IN.md OUT.pdf

Without OUT, the PDF is written next to the Markdown file with the same name. Re-run it after every
change to the Markdown (for example when the students have filled in a placeholder).
"""
import html
import subprocess
import sys
import tempfile
from pathlib import Path

import markdown

EDGE_PATHS = [
    Path(r"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"),
    Path(r"C:\Program Files\Microsoft\Edge\Application\msedge.exe"),
]

CSS = """
@page { size: A4; margin: 18mm 16mm 18mm 16mm; }
html { font-family: Calibri, Arial, Helvetica, sans-serif; font-size: 10.5pt; line-height: 1.4; color: #111; }
body { margin: 0; }
h1 { font-size: 22pt; margin: 0 0 6pt 0; color: #0b3d63; }
h2 { font-size: 16pt; margin: 18pt 0 6pt 0; color: #0b3d63; border-bottom: 1.5px solid #0b3d63; padding-bottom: 2pt;
     break-before: page; }
h2.no-break { break-before: auto; }
h3 { font-size: 12.5pt; margin: 14pt 0 4pt 0; color: #0b3d63; break-after: avoid; }
h4 { font-size: 11pt; margin: 10pt 0 4pt 0; break-after: avoid; }
p, li { orphans: 3; widows: 3; }
code { font-family: Consolas, "Courier New", monospace; font-size: 9.5pt; background: #f2f2f2; padding: 0 2px; }
pre { background: #f2f2f2; padding: 6pt; font-size: 9pt; white-space: pre-wrap; break-inside: avoid; }
table { border-collapse: collapse; width: 100%; margin: 6pt 0 10pt 0; font-size: 9.5pt; break-inside: auto; }
th, td { border: 1px solid #999; padding: 3pt 5pt; vertical-align: top; text-align: left; }
th { background: #e3ecf5; }
tr { break-inside: avoid; }
img { max-width: 100%; max-height: 190mm; display: block; margin: 8pt auto 2pt auto; break-inside: avoid; }
p:has(> img) { break-inside: avoid; break-after: avoid; text-align: center; }
p > em:only-child { display: block; text-align: center; font-size: 9.5pt; color: #333; }
hr { border: 0; border-top: 1px solid #bbb; margin: 12pt 0; }
a { color: #0b5394; text-decoration: none; }
blockquote { margin: 8pt 0; padding: 6pt 10pt; border: 1.5px dashed #c77700; background: #fff7e6;
             break-inside: avoid; }
blockquote p { margin: 3pt 0; }
blockquote table { background: #ffffff; }
blockquote td { height: 16pt; }
"""


def find_edge():
    for p in EDGE_PATHS:
        if p.exists():
            return p
    sys.exit("Microsoft Edge not found; it is needed to print the PDF.")


def to_html(md_path: Path) -> str:
    text = md_path.read_text(encoding="utf-8")
    body = markdown.markdown(text, extensions=["tables", "fenced_code", "toc", "sane_lists", "md_in_html"],
                             extension_configs={"toc": {"permalink": False}}, output_format="html5")
    # The first two h2 (placeholder legend, contents) follow the title directly: no page break before them.
    for _ in range(2):
        body = body.replace("<h2 ", '<h2 class="no-break" ', 1) if "<h2 " in body else body.replace("<h2>", '<h2 class="no-break">', 1)
    title = next((line[2:].strip() for line in text.splitlines() if line.startswith("# ")), md_path.stem)
    base = md_path.parent.resolve().as_uri() + "/"
    return (f'<!doctype html><html lang="en"><head><meta charset="utf-8"><base href="{base}">'
            f"<title>{html.escape(title)}</title><style>{CSS}</style></head><body>{body}</body></html>")


def main():
    if len(sys.argv) < 2:
        sys.exit(__doc__)
    md_path = Path(sys.argv[1]).resolve()
    out = Path(sys.argv[2]).resolve() if len(sys.argv) > 2 else md_path.with_suffix(".pdf")
    edge = find_edge()
    with tempfile.TemporaryDirectory() as tmp:
        page = Path(tmp) / "page.html"
        page.write_text(to_html(md_path), encoding="utf-8")
        cmd = [str(edge), "--headless=new", "--disable-gpu", "--no-first-run", f"--user-data-dir={Path(tmp) / 'profile'}",
               "--no-pdf-header-footer", "--print-to-pdf-no-header", "--allow-file-access-from-files",
               "--virtual-time-budget=10000", f"--print-to-pdf={out}", page.as_uri()]
        subprocess.run(cmd, check=True, timeout=180, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
    if not out.exists():
        sys.exit("Edge did not write the PDF.")
    print(f"wrote {out} ({out.stat().st_size // 1024} kB)")


if __name__ == "__main__":
    main()
