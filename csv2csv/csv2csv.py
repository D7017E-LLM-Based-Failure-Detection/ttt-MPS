import csv
import sys
from datetime import datetime
from pathlib import Path


def convert_csv(source: Path, destination: Path) -> None:
    if source.resolve() == destination.resolve():
        raise ValueError("The output file must be different from the input file.")
    if destination.exists():
        raise FileExistsError(f"Output file already exists: {destination}")

    with source.open("r", newline="", encoding="utf-8-sig") as input_file:
        reader = csv.reader(input_file)
        try:
            header = next(reader)
        except StopIteration as error:
            raise ValueError(f"Input CSV is empty: {source}") from error

        if "host_time" not in header:
            raise ValueError(f"Input CSV has no 'host_time' column: {source}")
        if "delta_time" in header:
            raise ValueError(f"Input CSV already has a 'delta_time' column: {source}")

        host_time_index = header.index("host_time")
        rows = [header + ["delta_time"]]
        first_host_time = None

        for row in reader:
            if len(row) != len(header):
                raise ValueError(
                    f"Malformed CSV row {reader.line_num} in {source}: "
                    f"expected {len(header)} columns, found {len(row)}."
                )

            try:
                host_time = datetime.fromisoformat(row[host_time_index])
            except ValueError as error:
                raise ValueError(
                    f"Invalid host_time on CSV row {reader.line_num} in {source}: "
                    f"{row[host_time_index]!r}"
                ) from error

            if first_host_time is None:
                first_host_time = host_time
            delta_seconds = (host_time - first_host_time).total_seconds()
            rows.append(row + [f"{delta_seconds:.6f}"])

    destination.parent.mkdir(parents=True, exist_ok=True)
    with destination.open("x", newline="", encoding="utf-8") as output_file:
        writer = csv.writer(output_file)
        writer.writerows(rows)


def main() -> None:
    project_dir = Path(__file__).resolve().parent.parent
    data_dir = project_dir / "data"
    output_dir = project_dir / "processed-data"
    input_files = sorted(data_dir.glob("*.csv"))

    if not input_files:
        raise FileNotFoundError(f"No CSV files found in {data_dir}")

    print("CSV files in data/:")
    for path in input_files:
        print(f"  {path.name}")

    input_name = input("Input CSV filename: ").strip()
    source = next((path for path in input_files if path.name == input_name), None)
    if source is None:
        raise ValueError(f"Choose an input filename listed above: {input_name!r}")

    output_name = input("Output filename: ").strip()
    if not output_name or Path(output_name).name != output_name or output_name in {".", ".."}:
        raise ValueError("Enter an output filename without a directory path.")
    if not output_name.lower().endswith(".csv"):
        output_name += ".csv"

    destination = output_dir / output_name
    convert_csv(source, destination)
    print(f"Created {destination}")


if __name__ == "__main__":
    try:
        main()
    except (OSError, ValueError) as error:
        print(f"Error: {error}", file=sys.stderr)
        raise SystemExit(1) from error