#!/usr/bin/env python3
"""Convert Festo CSV exports to newline-delimited JSON.

The input file is only read; the converter writes a separate .jsonl file.
"""

import argparse
import csv
import json
import os
import sys
import tempfile
from datetime import datetime, timezone
from pathlib import Path
from typing import Iterable


REQUIRED_COLUMNS = (
    "received_at_utc",
    "plc",
    "node_id",
    "signal",
    "value",
    "mqtt_topic",
)


def parse_timestamp(value: str) -> str:
    """Validate and normalize a timestamp to a UTC ISO-8601 string."""
    text = value.strip()
    if not text:
        raise ValueError("timestamp is empty")

    iso = text[:-1] + "+00:00" if text.endswith("Z") else text
    try:
        parsed = datetime.fromisoformat(iso)
    except ValueError as exc:
        raise ValueError(f"invalid ISO-8601 timestamp: {value!r}") from exc

    if parsed.tzinfo is not None:
        parsed = parsed.astimezone(timezone.utc).replace(tzinfo=None)

    normalized = parsed.isoformat(timespec="microseconds").rstrip("0").rstrip(".")
    normalized = normalized.replace("+00:00", "")
    return normalized + "Z"


def mqtt_signal(topic: str) -> str:
    """Return the signal portion after /tags/<station>/..."""
    marker = "/tags/"
    if marker in topic:
        return topic.split(marker, 1)[1].strip("/")
    return topic.strip("/")


def parse_boolean(value: str) -> bool | None:
    """Return a boolean value, or None for a non-boolean CSV value."""
    text = value.strip().lower()
    if text == "true":
        return True
    if text == "false":
        return False
    return None


def default_output_path(input_path: Path) -> Path:
    return input_path.with_name(input_path.stem + ".converted.jsonl")


def convert(input_path: Path, output_path: Path, overwrite: bool = False) -> tuple[int, int]:
    if not input_path.is_file():
        raise FileNotFoundError(f"input file does not exist: {input_path}")
    if input_path.resolve() == output_path.resolve():
        raise ValueError("output path must be different from the input file")
    if output_path.exists() and not overwrite:
        raise FileExistsError(f"output file already exists: {output_path} (use --overwrite)")

    output_path.parent.mkdir(parents=True, exist_ok=True)
    tempfile_path: Path | None = None
    converted = 0
    warnings = 0

    try:
        with input_path.open("r", encoding="utf-8-sig", newline="") as source:
            reader = csv.DictReader(source)
            if reader.fieldnames is None:
                raise ValueError("input CSV is missing a header row")

            fieldnames = [name.strip() for name in reader.fieldnames if name is not None]
            missing = [name for name in REQUIRED_COLUMNS if name not in fieldnames]
            if missing:
                raise ValueError("missing required CSV columns: " + ", ".join(missing))

            with tempfile.NamedTemporaryFile(
                "w",
                encoding="utf-8",
                newline="\n",
                dir=output_path.parent,
                prefix=f".{output_path.name}.",
                suffix=".tmp",
                delete=False,
            ) as destination:
                tempfile_path = Path(destination.name)

                for line_number, row in enumerate(reader, start=2):
                    try:
                        received_at = parse_timestamp(row["received_at_utc"] or "")
                    except (KeyError, ValueError) as exc:
                        print(f"warning: line {line_number}: {exc}", file=sys.stderr)
                        warnings += 1
                        received_at = (row.get("received_at_utc") or "").strip() or None

                    parsed_value = parse_boolean(row.get("value") or "")

                    if parsed_value is None:
                        continue

                    mqtt_topic = mqtt_signal(row.get("mqtt_topic") or "") or None
                    event = {
                        "received_at": received_at,
                        "plc": (row.get("plc") or "").strip() or None,
                        "node_id": (row.get("node_id") or "").strip() or None,
                        "signal": (row.get("signal") or "").strip() or None,
                        "value": parsed_value,
                        "mqtt_topic": mqtt_topic,
                    }

                    json.dump(event, destination, ensure_ascii=False, indent=4)
                    destination.write("\n")
                    converted += 1

        os.replace(tempfile_path, output_path)
        tempfile_path = None
        return converted, warnings

    finally:
        if tempfile_path is not None:
            try:
                tempfile_path.unlink()
            except FileNotFoundError:
                pass


def build_argument_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description="Convert Festo CSV exports to JSON Lines")
    parser.add_argument("input", type=Path, help="input Festo CSV file")
    parser.add_argument("-o", "--output", type=Path, help="output .jsonl file")
    parser.add_argument("--overwrite", action="store_true", help="overwrite an existing output file")
    return parser


def main(argv: Iterable[str] | None = None) -> int:
    args = build_argument_parser().parse_args(argv)
    input_path: Path = args.input
    output_path: Path = args.output or default_output_path(input_path)

    try:
        converted, warnings = convert(input_path, output_path, args.overwrite)
    except (OSError, csv.Error, ValueError, FileExistsError) as exc:
        print(f"error: {exc}", file=sys.stderr)
        return 1

    print(f"Converted {converted} rows to {output_path}")
    if warnings:
        print(f"Warnings: {warnings}", file=sys.stderr)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
