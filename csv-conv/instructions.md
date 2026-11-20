# Festo CSV Converter

`converter.py` converts Festo CSV exports into a separate output file containing only rows whose `value` is `true` or `false`.

## Requirements

- Python 3.10 or newer
- No third-party Python packages

Run the converter from the `csv-conv` directory.

## Input format

The input CSV must contain these columns:

- `received_at_utc`
- `plc`
- `node_id`
- `signal`
- `value`
- `mqtt_topic`

A value must be exactly `true` or `false`, ignoring surrounding whitespace and letter case. Integer, decimal, text, empty, and other values are skipped.

## Running the converter

Use the input filename as the first argument:

```bash
python3 converter.py dataSt1/festo-2026-11-19.csv
```

By default, the output is created beside the input file with `.converted.jsonl` appended to the input filename:

```text
dataSt1/festo-2026-11-19.converted.jsonl
```

For example:

```text
festo-2026-11-19.csv
    -> festo-2026-11-19.converted.jsonl
```

To choose another output location:

```bash
python3 converter.py input.csv --output results/output.jsonl
```

To replace an existing output file:

```bash
python3 converter.py input.csv --overwrite
```

Without `--overwrite`, the converter reports an error instead of replacing an existing file.

## Output format

Each retained row becomes a pretty-printed JSON object:

```json
{
    "received_at": "2026-11-19T17:15:22.405Z",
    "plc": "PLC_TS",
    "node_id": "ns=2;g=2C6165B0-1143-757F-E8A7-39E74BBF44BF",
    "signal": "TS01/IThis/TrayEmpty",
    "value": true,
    "mqtt_topic": "TS01/IThis/TrayEmpty"
}
```

Objects are written consecutively to the output file. The `mqtt_topic` field is shortened to the text after `/tags/`. For example:

```text
festo/PLC_TS/tags/TS01/IThis/TrayEmpty
    -> TS01/IThis/TrayEmpty
```

The converter normalizes `received_at_utc` to UTC and appends `Z`. Invalid timestamps produce a warning and are retained as the original trimmed text.

`source_timestamp`, `quality`, `quality_code`, and `value_type` are not included.

> Note: pretty-printing places one object across several lines. Therefore this output is not strict one-object-per-line JSON Lines format. It must be read as a stream of consecutive JSON objects, or the pretty-printing can be changed to `separators=(',', ':')` in a future update for strict JSONL compatibility.

## Safety behavior

- The input file is opened only for reading.
- The input file can never be used as the output path.
- Conversion uses a temporary file and replaces the output only after successful completion.
- Existing output files are protected unless `--overwrite` is used.
- If required headers are missing, conversion stops with an error.

## Command help

To display all command-line options:

```bash
python3 converter.py --help
```

## Example

```bash
python3 converter.py dataSt1/festo-2026-11-19.csv --overwrite
```

For the supplied file, this prints a conversion count and creates `dataSt1/festo-2026-11-19.converted.jsonl` containing boolean rows only.
