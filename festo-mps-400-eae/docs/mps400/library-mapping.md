# Library elements for the MPS devices — proposal

Which built-in library CAT stands for which physical device. This is a proposal for review, not a decision. Covered so far: all five station types; the conveyor loop follows.

Sources: the library help installed with EAE 25.0 UP 1 (read with `tools/libhelp.py`), the installed type files, the Festo drawings and the NxtStudio solution (see `station-types/` and `legacy/`).

Items marked **⚠ To verify** are not stated in the help and need a test in EAE.

## What the library offers for a boolean plant

All from `SE.App2CommonProcess` 25.0.1.5.

| CAT | What it models | Commands (setpoint) | Feedback | Useful extras |
|---|---|---|---|---|
| `Valve` | Actuator with **one** output and open/closed limit switches | 1 = open, 2 = close | Open and closed; `FbMode` selects both, only open, or none | Feedback-failure alarm after a monitoring time, interlock, permissive, simulation, maintenance mode, faceplate |
| `Valve2Op` | Actuator with **two** outputs (one per direction) | 0 = stop (both off), 1 = open, 2 = close | Open and closed, same `FbMode` options | Same as `Valve` |
| `DigitalInput` | One sensor | — | Value with quality | Invert, on/off delay, alarm, override from the HMI |
| `DigitalOutput` | One lamp or coil without feedback | On/off | — | Invert, on-pulse, off-pulse, cyclic pulse (blinking), interlock |
| `ilckCondItem` | One interlock condition on a device | — | — | Shown by name on the device's faceplate, with bypass |

### `Valve` is an on/off device, not 0–100 %

Checked in the installed type files (2026-11-10):

| CAT | Command | Output to the field | Feedback |
|---|---|---|---|
| `Valve` | `Lsp` (INT): 1 = open, 2 = close | one BOOL (`cmd`) | two BOOL (`fbOpen`, `fbClose`); pins `FbOpened`, `FbClosed` |
| `Valve2Op` | `Lsp` (INT): 0 = stop, 1 = open, 2 = close | two BOOL (`cmdOpen`, `cmdClose`) | two BOOL; pins `FbOpen`, `FbClosed`, `FbStopped` |
| `ValveControl` | `LspReal1` (REAL), 0–100 % | REAL (`Out`) | REAL position (`FbPos`) |

The analog 0–100 % valve is `ValveControl`; the AHU uses it for its modulating dampers and coil valves. `Valve` and `Valve2Op` are what the AHU uses for its on/off dampers.

No installed library has a cylinder, gripper or other pneumatic actuator CAT (searched all SE.\*, Runtime.\* and Standard.\* type names). What `Valve` gets wrong for a cylinder is only the wording and the picture: the faceplate says *open* and *closed*, and the symbols are valve, damper and diverter shapes.

Three ways to model a cylinder:

| | A. Use `Valve` / `Valve2Op` directly | B. Own `Cylinder` CAT that wraps `Valve` | C. Own `Cylinder` CAT from `DigitalInput` + `DigitalOutput` + logic |
|---|---|---|---|
| Feedback monitoring, alarms, interlock, permissive, simulation, maintenance mode, faceplate, OPC UA | Built in | Built in (inside) | Must be written by us |
| Names on the interface and in OPC UA | open / close | extend / retract on the wrapper; open / close inside | Our choice |
| HMI symbol | Valve shapes | Our own symbol **⚠ To verify:** whether the inner `Valve` faceplate can be reused from it | Our own symbol and faceplate |
| CATs per single-solenoid cylinder | 1 | 2 (wrapper + `Valve`) | 3 (1 DO + 2 DI) plus our logic |
| Fits the pattern | Yes: "instantiate and parameterise" | Yes: "wrap a CAT in a new one" is the second step of the extension order | Against checklist item 4: "No hand-written device logic" |

Each family comes in three layers: the top CAT (`Valve2Op`) with all optional services and its own I/O points, a middle layer (`Valve2OpBaseExt`) and a base layer (`Valve2OpBase`) with plain pins and the smallest footprint. The AHU reference uses the top layer.

How a station sequence drives them: through the device's `ISc` socket (adapter `IDevice`), as in the AHU. Setpoint 0/1/2 goes in `Lsp` with `REQ_CMD`; the device must be in owner *Program Local*.

## Distributing

| Device (Festo) | Signals | NxtStudio block | Proposed CAT | Notes |
|---|---|---|---|---|
| Stack magazine: ejecting cylinder `1A1` | Coil `1M1` (O0); sensors `1B2` (I1), `1B1` (I2) | `SingleActingCylinder` | `Valve` | Open = push a workpiece out (`1M1` on). Open feedback = slide extended (I2), closed feedback = slide retracted (I1). Confirmed on the machine 2026-11-16: at rest I1 (`1B2`) is on; `1M1` retracts the ejecting cylinder. |
| Swivel arm: swivel drive `3A1` | Coils `3M1` (O3), `3M2` (O4); switches `3B1` (I4), `3B2` (I5) | `CustomStopActuator` | `Valve2Op` | Open = to the downstream station, close = to the magazine, stop = both coils off. The legacy sequence parks the arm between the end positions with stop. |
| Vacuum suction cup `2A1` | Coils `2M1` vacuum on (O1), `2M2` ejection pulse (O2); vacuum switch `2B1` (I3) | `CustomStopActuator` | `Valve2Op` with `FbMode` = only open feedback | Open = vacuum on, close = ejection pulse, stop = both off. Open feedback = workpiece gripped (I3). The legacy sequence ignores the vacuum switch; with `Valve2Op` a failed pick raises a feedback alarm. |
| Magazine empty sensor `B4` | I6 | read directly | `DigitalInput` | Its alarm can replace the legacy "waiting" lamp logic. |
| Downstream station free `IP_FI` | I7 | not used | `DigitalInput` | Not used in version 1 (the request/confirm adapter replaces the optical link). Exposed only because everything is exposed. |

## Testing

| Device (Festo) | Signals | NxtStudio block | Proposed CAT | Notes |
|---|---|---|---|---|
| Lifting cylinder `1A1` | Coils `1M1` lower (O0), `1M2` raise (O1); sensors `1B1` raised (I4), `1B2` lowered (I5) | `DoubleActingCylinder` | `Valve2Op` | Open = raise, close = lower. |
| Ejecting cylinder `2A1` | Coil `2M1` extend (O2); sensor `2B1` retracted (I6) | `E_SR` latch | `Valve` | Open = extend. It has only a *retracted* (closed) sensor. **⚠ To verify:** `FbMode` offers both, only open, or none, but not "only closed". Fallback: `Valve` with no feedback plus a `DigitalInput` for the sensor. |
| Air slide `3A1` | Coil `3M1` (O3); no feedback | `E_SR` latch | `DigitalOutput` | |
| Workpiece available `PART_AV` | I0 | not used | `DigitalInput` | |
| Not black `B2` | I1 | read directly | `DigitalInput` | |
| Safety light barrier `B4` | I2 | not used | `DigitalInput` | Candidate interlock for the lift (Festo's sequence requires it unbroken for reset). Not in version 1 behaviour. |
| Height correct (comparator) | I3 | read directly | `DigitalInput` | The analog height value would need an analog input module and `AnalogInput`; not in version 1. |
| Downstream free `IP_FI`, station occupied `IP_N_FO` | I7, O7 | not used | `DigitalInput`, `DigitalOutput` | Not used in version 1. |

## Handling (both stations)

| Device (Festo) | Signals | NxtStudio block | Proposed CAT | Notes |
|---|---|---|---|---|
| Linear drive, X axis `1A1` | Coils `1M1` to upstream (O0), `1M2` to downstream (O1); sensors `1B1` upstream (I1), `1B2` downstream (I2), `1B3` middle (I3) | `DoubleActingCylinder` | `Valve2Op` + `DigitalInput` for the middle position | Open = towards the neighbouring station, close = towards the conveyor, stop = both off. Which Festo end is the conveyor differs between the two stations (handling-1: downstream end; handling-2: upstream end), so the mapping of open/close to I1/I2 is a per-instance setting. The middle position is not used in version 1. |
| Z axis `2A1` | Coil `2M1` lower (O2); sensors `2B1` lowered (I4), `2B2` raised (I5) | `SingleActingCylinder` | `Valve` | Open = lower. |
| Gripper `3A1` | Coil `3M1` open (O3); no sensor | `SingleActingActuator` | `DigitalOutput` | |
| Workpiece available, not black `3B1` | I0, I6 | not used | `DigitalInput` | |

## Processing

| Device (Festo) | Signals | NxtStudio block | Proposed CAT | Notes |
|---|---|---|---|---|
| Rotary indexing table | Start pulse O1; "positioned" `B3` (I5) | `TableDriver`, `TableRotate` | `DigitalOutput` + `DigitalInput` | No library CAT fits: the PLC only gives a start pulse, and a relay circuit runs the motor until the next position. The step logic (pulse on, off when the table leaves its position, done when it is back in position) belongs in the station's own logic. |
| Drill feed | `K4` lower (O2), `K3` raise (O3); limit switches `1B2` lower (I4), `1B1` upper (I3) | `DoubleActingCylinder` inside `DrillDriver` | `Valve2Op` | Open = lower, close = raise. The relays stop the feed at the end positions in hardware. |
| Drill motor `M3` | `K1` (O0); no feedback | `SingleActingActuator` | `Motor` with no feedback (`FbMode` 16#3) | `Motor` adds run-hour and start counters, useful for maintenance figures over OPC UA. |
| Clamp `M4` | O4; no feedback | `SingleActingActuator` | `DigitalOutput` | |
| Checking probe `M5` | O5; result `B4` (I6) | `SingleActingActuator` | `DigitalOutput` + `DigitalInput` | |
| Ejector `M6` | O6 | not used | `DigitalOutput` | Not used in version 1. |
| Workpiece sensors `PART_AV`, `B1`, `B2` | I0, I1, I2 | read directly | `DigitalInput` | I1 and I2 are to be checked on the hardware (q-proc-sensors). |

## Sorting

| Device (Festo) | Signals | NxtStudio block | Proposed CAT | Notes |
|---|---|---|---|---|
| Belt motor `M1` | `K1` (O0); no feedback | `E_SR` latch | `Motor` with no feedback | |
| Switch 1 `1A1`, switch 2 `2A1` | Coils O1, O2; sensors retracted (I4, I6) and extended (I5, I7) | `E_SR` latch | `Valve` each | Open = extend. The legacy solution reads only the extended sensors; `Valve` uses both. |
| Stopper `3A1` | Coil `3M1` retract (O3); no sensor | `E_SR` latch | `DigitalOutput` | |
| Workpiece, metal, not black, slide full | I0–I3 | read directly | `DigitalInput` | I1 and I2 are to be checked on the hardware (q-sort-sensors). Slide full is not used by the legacy sequence. |

## Control panel (every station)

One reusable CAT of our own, composed of library CATs, used once per station:

| Element | Signal | Proposed CAT | Notes |
|---|---|---|---|
| START, RESET buttons | I0, I3 | `DigitalInput` | |
| STOP button (normally closed) | I1 | `DigitalInput` with invert | |
| AUTO/MAN key switch | I2 | `DigitalInput` | |
| START lamp, RESET lamp, lamps Q1 and Q2 | Q0–Q3 | `DigitalOutput` | Cyclic pulse gives a blinking lamp without extra logic. |
| Sockets I4–I7, Q4–Q7 | | `DigitalInput`, `DigitalOutput` | Spare. |

## Station level

| Need | Candidate | Notes |
|---|---|---|
| Step sequence of a station | `SE.AppSequence` (`SeqHead`, `SeqStep`, `SeqTransition`, `SeqTerminate`) or a basic FB with a state machine, as the AHU does | To pilot on one station and compare footprint and clarity. |
| Start/stop/reset state of a station | A basic FB of our own, or `StateManager` from `SE.App2StateManagement` (PackML) | The PackML state model is larger than the panel sequence needs; to decide in the architecture draft. |
| Timers (500 ms vacuum pulse, 1 s ejector) | `E_DELAY` outside the logic block | As the legacy solution and the pattern both do. |
| Collision protection | One `ilckCondItem` per actuator | For example: the swivel arm may not go to the magazine while the slide is extended. |
| Station parameters and status for HMI and OPC UA | The station CAT's own `IThis` | Timer values and counters as persistent parameters. |

## Points to settle

1. **Footprint on the M251.** A station needs roughly 3 device CATs and 8 to 20 `DigitalInput`/`DigitalOutput` CATs. The top-layer CATs are the largest. Measure memory on a pilot station before deciding between top and base layer.
2. **Cylinder model: copy instead of wrap (decided 2026-11-16, replaces B of 2026-11-11).** `Actuator` and `Actuator2Op` are copies of the top layer of `Valve` and `Valve2Op` in our library, renamed, with extend/retract and at-home/at-end names. The copy is made by importing the CAT exports the library ships (`SE.App2CommonProcess-25.0.1.5\Exports\CAT\Valve.*.cat.zip`, `Valve2Op.*.cat.zip`, which include the HMI symbols as source) into EAE, then renaming in EAE. Only the top layer is copied: its children (`ValveBaseExt`/`Valve2OpBaseExt`, `IlckCondSum`, `PermCondSum`, `DevMnt`, `ValveLp`, the signal blocks) stay library types, so library fixes still reach the core logic. Why not wrap: one CAT layer per cylinder instead of two (footprint on the M251), our names directly on the interface and in OPC UA, symbols editable. **⚠ To verify:** EAE's import of a `.cat.zip` into our library, and whether the faceplate (it lives in the inner layers) shows our names.
3. **Feedback alarms change behaviour slightly.** The legacy solution waits forever for an end position. The library CATs raise a feedback-failure alarm after a monitoring time. This is an improvement, but it is a difference from "same behaviour as before".
4. **Ejector feedback** (see ⚠ above).
