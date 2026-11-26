# Using `csv2csv.py`

`csv2csv.py` adds a `delta_time` column to a CSV file from the `data/` directory. It does not modify the source file.

## Run

From the repository root, run:

```bash
python csv2csv/csv2csv.py
```

The script lists the CSV files it found in `data/`. Enter the input filename exactly as listed, then enter a name for the output file. The `.csv` extension is added automatically if you omit it.

The converted file is written to `processed-data/`. That directory is created if it does not exist. The script will not overwrite an existing output file.

## How `delta_time` is calculated

The converter uses `host_time` and measures each row relative to the first row:

```text
delta_time[i] = host_time[i] - host_time[0]
```

The result is written in seconds with six digits after the decimal point. The first row is therefore `0.000000`. For example, if the first row has a `host_time` of `10:00:00.000000` and a later row has a `host_time` of `10:00:02.500000`, the later row's `delta_time` is `2.500000` seconds.

Some source files contain PLC timestamps from different dates interleaved in row order, so the converter uses `host_time` rather than `plc_time`. A row can still have a negative `delta_time` if its `host_time` is earlier than the first row's `host_time`; the converter subtracts the first timestamp as-is and does not reorder or clamp values.

The original columns and values are preserved. The input must have a valid ISO-8601 `host_time` column and must not already contain a `delta_time` column.
