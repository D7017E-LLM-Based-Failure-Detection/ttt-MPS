# MPS 400 knowledge graph

What is known about the lab's Festo MPS 400, kept as YAML so it can be reviewed in git and later used to generate parts of the EAE solution (for example one CAT instance per device and one symbolic link per signal).

## Files

| File | Holds |
|---|---|
| `plant.yaml` | The lab installation: the conveyor loop and its interfaces, which station stands where, the workpiece flow, and the open questions |
| `component-types/<type>.yaml` | A Festo component shared by the stations, such as the control console every station has |
| `legacy/<type>.yaml` | How the NxtStudio solution runs a station: its signals, blocks, interfaces and step-by-step behaviour. This is the behaviour version 1 must reproduce |
| `library-mapping.md` | Proposal: which built-in library CAT stands for which physical device |
| `wiring-check.xlsx` | Sheets for the project owner to fill in while wiring: the conveyor connectors, and a channel-by-channel checklist per station |
| `layout.html` | The confirmed top view of the loop (open in a browser). Also published as a private page for the project owner |
| `station-types/<type>.yaml` | One Festo station type: I/O terminal, valve terminal, devices (cylinders, valves, sensors), every input and output, parts, and Festo's reference sequence (GRAFCET) |

Station types are shared: the lab's two Handling stations will both refer to `station-types/handling.yaml`.

Status (2026-11-10): the plant, the control console, and all five station types (Festo facts and legacy behaviour each) are written. The conveyor loop (legacy waypoints and the conveyor controller) follows the same structure.

## How the graph is built

Entities and their relations:

- plant → line `main-loop` → interfaces `if1` … `if6` → stations (`distributing-1`, `handling-2`, …)
- station → station type → devices (`1A1` ejecting cylinder, …) → signals (`I1` = `1B2`, …)
- device → valve and solenoid coils (`1V1`, `1M1`) and sensors (`1B1`, `1B2`)
- station type → sequence → steps and transitions

A relation is written as a reference to an id, for example `interface: if1` or `device: "1A1"`.

## Conventions

- **Every fact has a status.** An entity's `status` covers all its fields unless a field has its own.

  | Status | Meaning |
  |---|---|
  | `user` | Stated by the project owner |
  | `documented` | Taken from a source document, which is cited |
  | `inferred` | Derived from sources by reasoning, not stated directly; check before relying on it |
  | `assumed` | A placeholder until someone confirms it |
  | `confirmed` | Checked on the lab hardware or in the existing solution |

- **Unknown values** are `null` and have an entry under `open_questions` in `plant.yaml`.
- **Sources** are listed at the top of each file by id and cited as `id` or `id#page`.
- **`verify`** notes flag readings of a source that could be wrong, for example in dense drawings.
- **Names**: Festo's equipment codes are kept as ids: `1A1` actuator, `1B1` sensor, `1M1` solenoid coil, `1V1` valve. English text comes first; the German original from the drawings follows as `*_de`.
- **Quoting**: inside `{ … }` and `[ … ]`, quote any text that contains `,` `:` `?` `#` or brackets, and quote ids that start with a digit (`"1A1"`). Run `tools/check_yaml.py` after editing.
- **Addresses** in station-type files are local to the station's I/O terminal (`I0`–`I7`, `O0`–`O7` and SysLink pins). How they reach the controller depends on the lab hardware and is recorded in `plant.yaml` once known.

## Source documents

`resources/MPS documentation CD/` (not in git) holds Festo's documentation for all 13 MPS station types. Each station folder has assembly instructions, electrical and pneumatic circuit diagrams, data sheets, operating instructions, a parts list, a GRAFCET function chart and a video; most also have a manual of about 100 pages. `00_Boards` covers the control console, the emergency stop and several PLC boards.

The lab uses `01_Distributing`, `02_Testing`, `03_Processing`, `04_Handling` and `09_Sorting`. The conveyor loop, its stoppers and the trays are not documented on the CD.
