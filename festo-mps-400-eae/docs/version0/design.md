# Version 0 — I/O test panel: design (draft)

Status: draft for review, 2026-11-11. Nothing of this is built yet.

Version 0 is the first application on the MPS 400. It lets you switch every output by hand and see every input, for each station, from an HMI on the EAE host PC. With it we test the wiring of all five PLCs end to end: sensor → TM3 input → symbolic link → HMI, and HMI button → symbolic link → TM3 output → valve or motor.

It is also the first teaching exercise. It uses the same EAE steps as version 1 (device, resource, hardware configuration, symbolic links, CAT, HMI, deploy), but with almost no logic.

Items marked **⚠ To verify** have to be checked in EAE before we rely on them.

## 1. What gets built

| Item | Where | Notes |
|---|---|---|
| Library project `Flexbridge.FestoMPS400` | New EAE library project in this solution | Holds all our own types, as `SE.HVAC` does in the AHU reference. Namespace = project name. Version 0 adds the folder `Testers`. |
| CAT type `IOTest16` | `Flexbridge.FestoMPS400`, folder `Testers` | One input module (16 channels) and one output module (16 channels), with an HMI symbol. Reusable for any TM3 16-in/16-out pair. |
| 5 devices `M251_dPAC` | Solution's `IEC61499` project | One per PLC, each with resource `RES0` and `DPAC_FULLINIT`. Firmware dPAC 25.0.1 on all five. Addresses in the table below. |
| Hardware configuration | Per device | Bus `BMTM3` with `TM3DI16_G` and `TM3DQ16R_G` modules, in the order input, output (, input, output). |
| Application `V0_IOTest` | Solution's `IEC61499` project | 8 instances of `IOTest16`, each mapped to its device. |
| HMI canvas | Solution's `HMI` project | One page per PLC, or one overview with all 8 panels. |

Devices (IP address of port ETH1 10.10.XXX.YYY from the last two bytes of the MAC address, written in decimal (ETH2 has 10.11.XXX.YYY); confirmed with the Automation Device Maintenance tool):

| Device | PLC | MAC (last two bytes) | IP address |
|---|---|---|---|
| `PLC_DS` | plc-distributing | D7:85 | 10.10.215.133 |
| `PLC_TS` | plc-testing | D7:19 | 10.10.215.25 |
| `PLC_HP` | plc-handling-processing | D7:15 | 10.10.215.21 |
| `PLC_CV` | plc-conveyor | D7:13 | 10.10.215.19 |
| `PLC_HS` | plc-handling-sorting | D6:FB | 10.10.214.251 |

Instances (one per module pair):

| Instance | Device | Modules | What is wired there |
|---|---|---|---|
| `DS` | plc-distributing | 1 + 2 | Distributing station and panel |
| `TS` | plc-testing | 1 + 2 | Testing station and panel |
| `HS2` | plc-handling-processing | 1 + 2 | Handling (interface 2) station and panel |
| `PS` | plc-handling-processing | 3 + 4 | Processing station and panel |
| `CV_AB` | plc-conveyor | 1 + 2 | Conveyors A and B |
| `CV_CD` | plc-conveyor | 3 + 4 | Conveyors C and D |
| `HS6` | plc-handling-sorting | 1 + 2 | Handling (interface 6) station and panel |
| `SS` | plc-handling-sorting | 3 + 4 | Sorting station and panel |

## 2. How a channel reaches the hardware

The library's documented way (SE.App2CommonProcess help, "Hardware IO interface") is one small signal block per channel, from SE.App2Base:

- `dISignal`: publishes a symbolic link named `<instance path>.DIn` and outputs the channel value as `VTQBOOL` (value, timestamp, quality).
- `dOSignal`: publishes a symbolic link named `<instance path>.DOut` and writes the value given at its `Signal` input.

In the hardware configuration, each TM3 channel parameter (`DI00`–`DI15`, `DO00`–`DO15`) is a symbolic link. You drag the published names from the Symbolic Links window onto the channels. If the blocks inside `IOTest16` are named after the channels (`DI00` … `DI15`, `DO00` … `DO15`), every instance shows the same 32 names in channel order, and the mapping is a straight 1:1 drag.

Why not `SYMLINKMULTIVARDST` / `SYMLINKMULTIVARSRC` directly, as the NxtStudio solution and the student port do: their help says they are meant for use inside hardware CATs. They also bundle up to 16 values, so every value fires on every change, which the design pattern advises against (DESIGN_PATTERN section 14). `dISignal` and `dOSignal` use them internally, one channel each.

A **hardware CAT** (CAT sub-type *Hardware*) sits on the other side of the link: it lives in the hardware configuration and stands in for the field, as the AHU's `AHUSim` and `ValveSim` do. For version 0 the real TM3 modules are the field side, so `IOTest16` is an ordinary CAT in the application. Hardware CATs become useful later, for station simulators that let us test version 1 without the machines.

## 3. The `IOTest16` CAT

### Interface (set per instance)

| Parameter | Type | Meaning |
|---|---|---|
| `LabelDI00` … `LabelDI15` | STRING | Text shown next to each input lamp, e.g. `I4 3B1 Swivel at magazine` |
| `LabelDO00` … `LabelDO15` | STRING | Text shown on each output button, e.g. `O3 3M1 Swivel to magazine` |
| `ExclDO00` … `ExclDO15` | INT | The output channel this output must never be on together with; `-1` = none |
| `PulseDO00` … `PulseDO15` | TIME | `T#0s` = the button toggles the output. Longer than zero = the output switches off again by itself after this time |

### Pulse outputs

| Instance | Channel | Pulse | Why |
|---|---|---|---|
| `PS` | DO01 | e.g. `T#300ms` | Table start pulse: the relay circuit keeps the table turning to the next position |
| `DS` | DO02 | e.g. `T#500ms` | Ejection pulse of the vacuum gripper (the legacy solution uses 500 ms) |

The values are starting points to try on the machine. One `E_DELAY` per panel (`PulseTimer`) times the pulse, outside the logic block as the design pattern asks. So only one pulse can run at a time per panel: while it runs, the buttons of the other pulse outputs are greyed out. On the MPS each panel has at most one pulse output, so this costs nothing.

The values for every instance are generated from the knowledge graph into [instance-parameters.md](instance-parameters.md) (`tools/v0_params.py`). Proposed label length: `STRING[48]`. **⚠ To verify:** the memory 32 strings × 8 instances take on an M251.

### Exclusive pairs

Some outputs drive the same device in opposite directions and must never be on together:

| Instance | Pair | Device |
|---|---|---|
| `DS` | DO01 ↔ DO02 | Vacuum on / ejection pulse |
| `DS` | DO03 ↔ DO04 | Swivel to magazine / to downstream station |
| `TS` | DO00 ↔ DO01 | Lift down / up |
| `HS2`, `HS6` | DO00 ↔ DO01 | Arm to upstream / to downstream position |
| `PS` | DO02 ↔ DO03 | Drill down / up |

Set `ExclDOxx` on both channels of a pair (e.g. `DS`: `ExclDO03 = 4`, `ExclDO04 = 3`).

The rule is enforced **in the controller**, not only on the HMI: a request to switch an output on is refused while its partner is on. The HMI greys out the button of the partner so the operator sees why. Reason: a value can also be written over OPC UA or from a second HMI, which bypasses any check that exists only on one screen. This is a good teaching point.

### Inside (frames as in the design pattern, kept minimal)

| Frame | Content |
|---|---|
| 0 Initialization | `EVENTCHAIN` 'APP_INIT' → `IThis` → logic → acknowledge (and `IThis.REQ_LBL` for the labels) |
| 3 Field interface | 16 × `dISignal` named `DI00`–`DI15`; 16 × `dOSignal` named `DO00`–`DO15` |
| 5 Logic | Basic FB `Logic : IOTest16Logic` and the timer `PulseTimer : E_DELAY` |
| 6 HMI interface | `IThis : IOTest16_HMI` |

`IOTest16Logic` keeps the output states, applies the exclusive pairs and the pulse rule, computes which buttons are enabled, and handles "all outputs off". Its ST algorithms only compute and set flags (`Changed`, `StartPulse`, `StopPulse`). **Every event is emitted by the ECC**, which decides with guard conditions (project rule):

```
START ─INIT──► INIT_S  (all off; DO_UPD, HMI_DO, HMI_DI, INITO) ─► START
START ─DI────► DI_S    (HMI_DI) ─► START
START ─CMD───► CMD_S   ─[Changed]─► OUT_S       ─[NOT Changed]─► START
START ─ALL_OFF► OFF_S  ─────────────► OUT_S
START ─TO────► TO_S    ─[Changed]─► OUT_S       ─[NOT Changed]─► START
OUT_S (DO_UPD, HMI_DO) ─[StopPulse]─► PSTOP_S (TSTOP) ─[StartPulse]─► PSTART_S (TSTART) ─► START
                       ─[StartPulse AND NOT StopPulse]─► PSTART_S
                       ─[neither]─► START
```

Only buttons whose request changed since the last command are handled. A request that was refused earlier therefore never switches an output on later by surprise.

Event flow:

- Input: any `dISignal.CNF` → `Logic.DI` → `IThis.REQ_DI` (lamp values).
- Output: button on the HMI → `IThis.CMD` → `Logic` (accept or refuse) → `DO_UPD` to all 16 `dOSignal.REQ` → TM3 outputs; states and enabled flags → `IThis.REQ_DO`.

### `IThis` (`IOTest16_HMI`)

| Direction | Event | Data | Meaning |
|---|---|---|---|
| To the HMI (inputs) | `REQ_LBL` | `LabelDI00`–`LabelDI15`, `LabelDO00`–`LabelDO15` | Texts; sent once when `Logic` has initialised (`Logic.INITO`). Not with `INIT`: the HMI cannot subscribe to the service's `INIT` event |
| | `REQ_DI` | `DI00`–`DI15` | Input lamps |
| | `REQ_DO` | `DOSt00`–`DOSt15`, `EnDO00`–`EnDO15` | Output state lamps; button enabled (false = greyed out) |
| From the HMI (outputs) | `CMD` | `CmdDO00`–`CmdDO15` | Button states: requested output states |
| | `ALL_OFF` | `AllOff` | Switch every output off |

Everything is exposed over OPC UA (project rule).

### HMI symbol

Two columns: channels 0–7 (station) and 8–15 (control panel). Each row: input lamp and its label, then output button, output state lamp and label. The button shows what was asked, the lamp what the PLC really does. The button is greyed out when the controller would refuse it. Code in the symbol only changes what is shown: it greys buttons out and brings a button back in line with its lamp after a refusal, the end of a pulse or "all off". One "All outputs off" button per panel; the instance name is shown in the title.

Not in version 0: showing the signal quality (a lamp for "module or bus fault"). **⚠ To verify** how to test a `VTQBOOL` quality for "bad" in ST before adding it.

## 4. Safety rules for the test

1. The person pressing a button must be able to see the machine. Nobody's hands in the machine while outputs are tested.
2. Test outputs one at a time, and switch each off before the next.
3. Pneumatic stations: first with the air supply off (the LED on the valve terminal shows the coil), then with air on.
4. Processing table (`PS` DO01) is a start pulse; with its pulse time set it switches off by itself. Without one it must be switched off as soon as the table moves, or the table keeps turning.
5. Processing drill motor (`PS` DO00) and the conveyor motors turn real tools and belts.

## 5. Test procedure per instance (summary; the student guide will give the details)

1. Inputs: trigger each sensor by hand or with a workpiece; the LED on the TM3 module and the lamp on the HMI must both light. Record it in `wiring-check.xlsx`, column "Wired and checked".
2. Outputs, air off: each button; the TM3 output LED and the valve-terminal LED light.
3. Outputs, air on: each button; the device moves and its end-position sensor lights on the HMI.
4. Last: run one cycle of the station by hand with the buttons, in the order of the Festo sequence (`docs/mps400/station-types/*.yaml`). That is what version 1 will automate.

Open questions this answers on the way: which sensor is on Processing I1/I2 and Sorting I1/I2 (`q-proc-sensors`, `q-sort-sensors`), which conveyor connector is which (`q-connectors`), and what CONGESTION does (`q-congestion`).

## 6. Open points

- **⚠ To verify:** whether EAE accepts an INT and a TIME parameter per channel, or whether array parameters are the better choice.
- **⚠ To verify** at the first compile in EAE (files are hand-generated by `tools/v0_scaffold.py`, formats copied from the AHU reference):
  - the library project loads in the solution, and `IOTest16` and `IOTest16Logic` compile;
  - the outputs reach the module with the default VTQ quality (the logic sets only `.value`);
  - the symbol code compiles: `Led<bool>.ValueChanged`, `SwitchButton.Enabled`, and setting `SwitchButton.Value` from code;
  - the OPC UA address of the display values (`V1;${VariableFullPath}` without trigger).

## 7. Git

Version 0 is built on its own branch, `version0`, made from `main` after the current documentation has been committed there. When version 0 works, the devices, hardware configuration and topology are what version 1 builds on (merge into `main`, or branch version 1 from `version0`).
