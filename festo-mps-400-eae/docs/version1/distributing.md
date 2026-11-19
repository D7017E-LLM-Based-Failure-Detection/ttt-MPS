# Version 1: Distributing station logic (design draft)

Status: agreed 2026-11-16, being built. Branch `version1`.

The asset CAT `Distributing` (instance `DS01` on PLC_DS) already holds its devices: `Ejector` (`Actuator`), `Vacuum` and `Swivel` (`Actuator2Op`), `MagazineEmpty` and `DownstreamFree` (`DigitalInput`). They are linked to the I/O, tested by hand from their faceplates, and their alarms show in the alarm grid of canvas `V1_DS`. This document adds the logic.

Decided 2026-11-16 (user):

- The station sequence is a **basic FB with an ECC**: one ECC state per step, as the AHU's `SequenceCtrl`. ST only computes; the ECC emits every event.
- **Legacy order, with feedback:** the steps and their order are those of the NxtStudio solution (`docs/mps400/legacy/distributing.yaml`), but every move waits for its end-position feedback, and the pick waits for "workpiece gripped" (2B1) instead of a blind 500 ms. A stuck cylinder or a failed pick is then an alarm of the device (feedback failure after 5 s), not a silent stall.
- **Trigger:** the request/confirm adapter to Testing is built now; until Testing is on version 1, an HMI button stands in for Testing's request.

Items marked **⚠ To verify** need a test in EAE or on the machine before we rely on them.

## 1. Blocks

| Frame | Block | Type | New? | Job |
|---|---|---|---|---|
| 0 Initialization | `EVENTCHAIN` | Runtime.Standard | | `'APP_INIT'`: initialises `IThis` and the logic, then acknowledges |
| 1 Functional input | `ISupply` | socket of adapter `IWorkpieceSupply` | new adapter | Testing asks for a workpiece (`REQ`), Distributing confirms the handover (`CNF`) |
| 3 Field interface | `Console` | `ControlConsole` | new CAT, reusable | Buttons and lamps of the station's control console (inside: 4 × `DigitalInput`, 4 × `DigitalOutput`, basic FB `ConsoleIO`) |
| 3 Field interface | `MagazineEmpty`, `DownstreamFree` | `DigitalInput` | exists | Sensors B4 and IP_FI |
| 4.A Typicals | `Ejector`, `Vacuum`, `Swivel` | `Actuator`, `Actuator2Op` | exists | The three devices, commanded through their `ISc` socket |
| 5.A Control logic | `Mode` | `StationMode` | new basic FB, reusable | RESET / START / STOP of the station, panel lamps |
| 5.A Control logic | `StationSeq` | `DistributingSequence` | new basic FB | Reset sequence and workpiece cycle; one `IDevice` plug per device (the block cannot be named `Sequence`: EAE reports "Invalid component name") |
| 5.A Control logic | `EjectTimer` | `E_DELAY` | | Length of the ejection pulse (outside the logic, as the pattern asks) |
| 6 HMI interface | `IThis` | `Distributing_HMI` | extend | HMI button "request workpiece", parameters, step and state display, OPC UA |

`StationMode` and `ControlConsole` are the same for all five stations; only `DistributingSequence` is specific to Distributing. All three live in the library `Flexbridge.FestoMPS400`: `ControlConsole` and `StationMode` in folder `Common`, `DistributingSequence` next to `Distributing` in `Stations`. The design draft was agreed by the user on 2026-11-16.

## 2. Control console: `ControlConsole` (CAT)

| Child | Type | Channel | Note |
|---|---|---|---|
| `S1_Start` | `DigitalInput` | DI08 | S1, normally open |
| `S2_Stop` | `DigitalInput` | DI09 | S2, normally closed: **inverted** in `ConsoleIO`, so `Stop` = TRUE while pressed |
| `S3_AutoMan` | `DigitalInput` | DI10 | S3, read and exposed; not used by the logic (as legacy) |
| `S4_Reset` | `DigitalInput` | DI11 | S4, normally open |
| `P1_StartLamp` | `DigitalOutput` | DO08 | P1 |
| `P2_ResetLamp` | `DigitalOutput` | DO09 | P2 |
| `P3_Q1Lamp` | `DigitalOutput` | DO10 | P3: "waiting, magazine empty" (legacy use) |
| `P4_Q2Lamp` | `DigitalOutput` | DO11 | P4: not used yet |

Children are named by Festo tag, so that no child shares a name with an interface pin (EAE: "Ambiguous path"). Interface towards the station logic: output event `BUTTONS` with `Start`, `Stop`, `Reset`, `AutoMan` (BOOL, on every change); input event `LAMPS` with `StartLamp`, `ResetLamp` (from `StationMode`), input event `AUX_LAMPS` with `Q1Lamp`, `Q2Lamp` (from the station sequence). The communication-panel channels (I4–I7, Q4–Q7) are not used.

Checked in the library (2026-11-16): a `DigitalInput` passes its value on with event `CNF` and `Pv` (VTQBOOL); a `DigitalOutput` is commanded like the actuators, through its `ISc` socket (`IDevice`, `Lsp` 0 = off, 1 = on). The console therefore has a small basic FB of its own, `ConsoleIO` (folder `Common`): it turns the four `CNF` events into `BUTTONS` (taking `.value`, inverting STOP), and commands the four lamps through one `IDevice` plug each, only when a lamp changes. At `INIT` it selects program local on the four lamps.

## 3. Station mode: `StationMode` (basic FB)

Reproduces the legacy panel behaviour:

```
WAIT_RESET  (RESET lamp on)
   ─ RESET released ─►  RESETTING  (event DO_RESET to the sequence)
   ─ RESET_DONE ─────►  WAIT_START (START lamp on)
   ─ START pressed ──►  STARTED    (lamps off; Started = TRUE)
   ─ STOP pressed ───►  WAIT_START (Started = FALSE; a running cycle is finished, not aborted, as legacy)
   ─ FAULT (any state) ► WAIT_RESET
```

Edges (pressed, released) are computed in ST from the previous button values; the ECC decides with guards such as `ResetReleased`. Interface: inputs `INIT`, `BUTTONS` (`Start`, `Stop`, `Reset`), `RESET_DONE`, `FAULT`; outputs `INITO`, `DO_RESET`, `MODE` (`Mode` 0–3, `Started`), `LAMPS` (`StartLamp`, `ResetLamp`). Written by `tools/v1_types.py` (2026-11-16).

## 4. Station sequence: `DistributingSequence` (basic FB)

Commands go to each device as `Lsp` with `REQ_CMD` on its `IDevice` plug: 1 = open, 2 = close, 0 = stop (`Actuator2Op` only). The device answers with `CNF_STATUS` (`Status`: 0 = stopped, 1 = opened, 2 = closed) and `CNF_READY` (`Ready`, `Alarm`, `NeedReset`, `ProgLocal` …). At `INIT` the sequence sends `REQ_PROGLOCALSEL` with `ProgLocalSel = TRUE` to all three devices, so that they follow the program. If a device's owner was switched to Operator on its faceplate, it ignores the sequence until it is switched back to Program.

Found 2026-11-16 on the console lamps: a device CAT may initialise *after* the block that commands it (the order of the `'APP_INIT'` chains is not under our control). Its owner is then "Unknown", and a `REQ_PROGLOCALSEL` sent at our `INIT` is lost. The library itself would accept it (`EnProgReq` of the `Owner` service is FALSE by default, so `ProgLocalSel` from logic selects Program Local even from Operator). The mechanism, read in the owner logic (SE.App2Base `ownerBasic`): Program Local is 16#C (Program bit 16#8 plus local bit 16#4). `REQ_PROGLOCALSEL` from logic sets the Program bit only if the Owner's `EnProgReq` is TRUE (default FALSE, against the wording of the library doc). A request that arrives before the device's Owner has initialised leaves 16#4 alone, which the faceplate shows as owner "Unknown", and the device ignores the program; later requests only set 16#4 again. Only a manual Operator → Program on the faceplate repaired it.

Rules for every block that commands devices (`ConsoleIO`, `DistributingSequence`):

1. Never send `REQ_PROGLOCALSEL` at `INIT`. Send it with the current command on the device's `CNF_READY`, until the device has received the command while program local, at most 3 times per device (no event storm); after that leave the owner alone so that an operator can take the device over from the faceplate.
2. Every device we command has `EnProgReq = TRUE` (CAT-level offline default, `tools/v1_owner.py`: the four console lamps in `ControlConsole`, and the `Actuator`/`Actuator2Op` types).

**⚠ To verify** on the next deploy: that a device sends `CNF_READY` after its Owner has initialised (if not, the owner stays Program remote, and another trigger is needed).

What "open" means per device:

| Device | Open (1) | Close (2) | Stop (0) |
|---|---|---|---|
| `Ejector` | 1M1 on: push a workpiece out (cylinder retracts, DI02) | rest (cylinder extended, DI01) | — |
| `Vacuum` | 2M1 vacuum on; open feedback = 2B1 workpiece gripped | 2M2 ejection pulse | both off |
| `Swivel` | 3M2 to the downstream station (DI05) | 3M1 to the magazine (DI04) | both off |

**Reset sequence** (event `DO_RESET` from `Mode`; ends with `RESET_DONE`):

1. `Vacuum` stop, `Ejector` close; wait until the ejector reports closed.
2. Park the arm as legacy: `Swivel` close until it reports closed (at the magazine), then open until it leaves the closed position, then stop. Why parked between the end positions: with the arm at the magazine the ejector cannot push a workpiece out, and with the arm at the Testing side the Testing lift cannot move (user, 2026-11-16). Tested on the machine 2026-11-16: `Swivel` stopped between its end positions raises no alarm.

**Workpiece cycle** (event `REQ` from `ISupply`, or `HMI_REQ` from `IThis`; accepted only while `Started`):

| Step | Do | Next when |
|---|---|---|
| 1 WAIT_MAG | If `MagazineEmpty`: Q1 lamp on (`Waiting`) | magazine not empty |
| 2 PUSH | `Ejector` open | `Ejector` opened |
| 3 PUSH_BACK | `Ejector` close | `Ejector` closed |
| 4 TO_MAG | `Swivel` close | `Swivel` closed |
| 5 GRIP | `Vacuum` open | `Vacuum` opened (workpiece gripped) |
| 6 TO_DOWN | `Swivel` open | `Swivel` opened |
| 7 RELEASE | `Vacuum` close (ejection pulse), start `EjectTimer` | timer expired |
| 8 VAC_OFF | `Vacuum` stop | `Vacuum` stopped |
| 9 PARK | Park the arm as in the reset sequence | arm parked |
| 10 DONE | `CNF` to `ISupply`; Q1 lamp off; cycle counter + 1 | back to idle |

**Faults:** if a device reports an alarm or `NeedReset` (`CNF_READY`) during a cycle, the sequence stops where it is and reports `FAULT` to `Mode`, which goes back to WAIT_RESET (RESET lamp on). The operator clears the cause, resets the device on its faceplate (**Rearm**), and presses RESET on the console; the reset sequence brings the station back to its start position.

**⚠ To verify:**

- The `Vacuum` must watch only its open feedback (2B1): which value of its offline parameter `FbMode` selects that.
- Whether `Status` also reports transition values (opening, closing) besides 0/1/2.

## 5. Adapter to Testing: `IWorkpieceSupply`

Defined from the plug side, which belongs to the station that asks (Testing):

| Plug sends | Plug receives |
|---|---|
| `REQ`: please hand over a workpiece | `CNF`: workpiece handed over |

Distributing has the socket `ISupply` in frame 1. A request that arrives while the station is not started is ignored, as legacy.

Built 2026-11-16 (`tools/v1_networks.py`): `IWorkpieceSupply` is a normal adapter (as all AHU adapters) in folder `Common`, without data; EAE's template (socket requests, plug confirms, four `STRING[15]`) was turned round. Inside `Distributing`: `ISupply.REQ` → `StationSeq.REQ_WP`, `StationSeq.WP_DONE` → `ISupply.CNF`; the HMI button stays connected to `REQ_WP` until Testing is on version 1.

## 5a. OPC UA (step 4)

Step-by-step setup and saving in UaExpert, for all stations: [opcua-client.md](opcua-client.md).

The OPC UA server is enabled on the dPAC (deployed `System.PLC_DS.runtime.config`): endpoint `opc.tcp://10.10.215.133:4840`, security Basic256Sha256 or Aes256_Sha256_RsaPss (sign, or sign and encrypt; "None" is off), user name and password only (no anonymous login), client certificates are checked. `DS01` publishes 451 variables (console 224, each actuator 63, each sensor 16, `IThis` 6) against `MaxVariableNodes = 500` per device: enough for Distributing, but PLCs with two stations (PLC_HP, PLC_HS) will need a higher limit.

Connected 2026-11-16 with UaExpert: the server announces its endpoints under the host name `spearHead` (`opc.tcp://spearHead:4840`), not under its IP address. Entering `opc.tcp://10.10.215.133:4840` by hand on UaExpert's *Advanced* tab therefore fails with "the server does not support the configured security policy" (no endpoint matches the address). What works: *Add Server → Discovery → Custom Discovery*, add `opc.tcp://10.10.215.133:4840`, pick "Basic256Sha256 – Sign & Encrypt" from the list, user name and password (the lab user). The PLC accepted UaExpert's certificate without any extra step. The address space shows `DS01` with `Console`, `DownstreamFree`, `Ejector`, `IThis`, `MagazineEmpty`, `Swivel`, `Vacuum`.

Tested 2026-11-16: `IThis` values read live in UaExpert (`ModeText` "Started", `StepText` "40 Cycle done: handed over", `StepNo`, `Cycles`, `Waiting`, all status Good), and writing `RequestWp` from UaExpert runs one workpiece cycle (the write fires `HMI_REQ`, as configured with `Trigger=HMI_REQ`), `Cycles` counts up. Step 4 is done for Distributing; the socket `ISupply` waits for Testing on version 1.

## 6. `IThis` of `Distributing`: HMI and OPC UA

| Direction | Item | Type | Meaning |
|---|---|---|---|
| From the HMI | `RequestWp` (event `HMI_REQ`) | BOOL | Test button: request one workpiece, as Testing will |
| Parameter (persistent) | `EjectPulse` | TIME, default `T#500ms` | Length of the ejection pulse |
| To the HMI | `Mode` | INT | Station mode (wait reset, resetting, wait start, started) |
| To the HMI | `Step` | INT | Current step of the sequence (table above) |
| To the HMI | `Waiting` | BOOL | Magazine empty, station waits |
| To the HMI | `Cycles` | UDINT | Workpieces delivered since start-up |

`IThis` sits in the CAT's network, so the CAT definition needs `UsedInCAT="true"` (lesson from version 0). Everything is exposed over OPC UA. The `Distributing` symbol gets a small station overview: mode, step, waiting, cycles, and the request button.

## 7. Interlocks (next step, not in the first build)

One `ilckCondItem` per device in frame 5.D, fed by an interlock basic FB, for example: the swivel may not go to the magazine while the ejector is open, and the ejector may not push while the arm is at the magazine (the arm blocks the push). The arm at the Testing side blocks Testing's lift; that one crosses the station boundary and goes through an adapter to Testing. To be agreed once the sequence runs.

## 8. Build order

Each increment is tested on the machine before the next one starts.

1. `ControlConsole` and `StationMode`: RESET and START lamps and buttons work as in legacy (the reset sequence is a stub that answers at once).
2. `DistributingSequence` with the reset sequence (parking the arm).
3. The workpiece cycle with the HMI request button.
4. Adapter `IWorkpieceSupply`, `IThis` overview, OPC UA client check of all variables.
5. Interlocks.

As in version 0, EAE creates every new type (CAT, basic FB, adapter) with its wizard, and the content (network, ECC, ST) is then filled in with the solution closed.

Status 2026-11-16: steps 1, 2 and 3 built and tested on the machine (reset sequence and a full workpiece cycle: workpiece handed over to the Testing station, arm parked just off the magazine). Built in steps 2 and 3: `DistributingSequence` (`tools/v1_types.py`), its wiring, `EjectTimer` (500 ms, constant for now), `IThis` with `REQ_ST`/`HMI_REQ` and OPC UA exposure, and the `Distributing` symbol (`tools/v1_networks.py`).

## 9. Test of steps 2 and 3

Steps of the sequence as shown on the `Distributing` symbol (`StepText`):

| No | Text | Device action | Next when |
|---|---|---|---|
| 0 | Idle | — | RESET released, or a request while started |
| 10 | Reset: owners to program | program local requested for all three devices | all three report program local |
| 11 | Reset: ejector home | vacuum off, ejector to rest | ejector closed |
| 20 | Park: swivel to magazine | swivel to the magazine | at the magazine |
| 21 | Park: off the magazine | swivel towards Testing | magazine sensor off |
| 22 | Park: swivel stopped | swivel stop | at once; then 12 (reset) or 40 (cycle) |
| 12 | Reset done | — | START lamp on |
| 31 | Wait: magazine empty / Magazine: workpiece there | lamp Q1 while empty | workpiece in the magazine |
| 32 | Push workpiece out | ejector open (1M1) | ejector opened |
| 33 | Ejector back home | ejector close | ejector closed |
| 34 | Swivel to magazine | swivel close | at the magazine |
| 35 | Vacuum on, wait gripped | vacuum open (2M1) | workpiece gripped (2B1) |
| 36 | Swivel to Testing | swivel open | at Testing |
| 37 | Release: ejection pulse | vacuum close (2M2) for 500 ms | timer |
| 38 | Vacuum off | vacuum stop | at once; then park (20–22) |
| 40 | Cycle done: handed over | cycle counter + 1 | back to 0 |
| 99 | FAULT: Rearm Ejector / Vacuum / Swivel, or owner not program | — | Rearm the device on its faceplate, then RESET |

Preparation: Verify and Build; put the `DS01` symbol on `V1_DS` (next to the device symbols and the alarm grid); deploy PLC_DS; air on; a few workpieces in the magazine; nothing in the way of the swivel arm on the Testing side.

1. **Reset.** After the deploy the RESET lamp is on, step 0. Release RESET: steps 10, 11, 20, 21, 22, 12 follow; the arm goes to the magazine and back until it just leaves the magazine sensor; then the START lamp comes on.
2. **Not started.** Click "Request one workpiece": the step text says "0 Idle: press START first"; nothing moves.
3. **Cycle.** Press START (lamps off). Click "Request one workpiece": steps 31 to 38, then 20–22, then 40. The workpiece ends on the Testing station; the arm parks just off the magazine.
4. **Empty magazine.** Empty the magazine, request: step 31 "Wait: magazine empty", lamp Q1 on. Put a workpiece in: the cycle continues, Q1 goes off.
5. **STOP during a cycle.** Request, then press STOP while the arm moves: the cycle finishes (legacy behaviour), then the START lamp comes on.

If it stops somewhere, note the step text and the state on the device faceplates (owner, setpoint, status) and the alarm grid.

Confirmed 2026-11-16: the `Status` an actuator reports through `IDevice` is the confirmed feedback (0 stopped, 1 opened, 2 closed), not the command: the arm stops at step 21 only after it has left the magazine sensor. Tests 1 and 3 passed; tests 2, 4 and 5 still to run.
