"""Check the YAML files of the knowledge graph.

Fails on syntax errors, duplicate keys, and keys that YAML 1.1 parsers read as
something other than text (for example `no:` becomes False).

Usage, from the repository root:
    .venv\\Scripts\\python tools\\check_yaml.py [FILE ...]
Without arguments it checks every *.yaml file under docs/mps400.
"""
import sys
from pathlib import Path

import yaml
from yaml.constructor import ConstructorError

ROOT = Path(__file__).resolve().parent.parent


class StrictLoader(yaml.SafeLoader):
    """SafeLoader that rejects duplicate keys and keys that are not text."""


def _construct_mapping(loader, node, deep=False):
    seen = set()
    for key_node, _ in node.value:
        key = loader.construct_object(key_node, deep=deep)
        if not isinstance(key, str):
            raise ConstructorError(
                None, None,
                f"key {key_node.value!r} is read as {type(key).__name__}, not text; quote it",
                key_node.start_mark)
        if key in seen:
            raise ConstructorError(None, None, f"duplicate key {key!r}", key_node.start_mark)
        seen.add(key)
    return loader.construct_mapping(node, deep=deep)


StrictLoader.add_constructor(yaml.resolver.BaseResolver.DEFAULT_MAPPING_TAG, _construct_mapping)


def check(path: Path) -> str | None:
    """Return an error message, or None when the file is valid."""
    try:
        with path.open(encoding="utf-8") as handle:
            yaml.load(handle, Loader=StrictLoader)
    except yaml.YAMLError as error:
        return str(error)
    return None


def main(args: list[str]) -> int:
    paths = [Path(arg).resolve() for arg in args] or sorted((ROOT / "docs" / "mps400").rglob("*.yaml"))
    failures = 0
    for path in paths:
        shown = path.relative_to(ROOT) if path.is_relative_to(ROOT) else path
        error = check(path)
        if error:
            failures += 1
            print(f"FAIL {shown}\n{error}\n")
        else:
            print(f"ok   {shown}")
    return 1 if failures else 0


if __name__ == "__main__":
    sys.exit(main(sys.argv[1:]))
