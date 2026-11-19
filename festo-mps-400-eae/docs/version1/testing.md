# Version 1: Testing station (design draft)

Status: built 2026-11-16; tested 2026-11-17 on the machine (section 7): reset, a full cycle with the workpiece requested from Distributing across the two PLCs, black reject. Wrong-height reject not yet tested. Sources: (`tools/v1_types.py` TestingSequence; `tools/v1_networks.py` network, IWaypoint, Testing_HMI, symbol; `tools/v1_symlinks.py TS`; `tools/v1_owner.py` EnProgReq for the air slide). Agreed 2026-11-16 (user: stand-in buttons for the conveyor until the conveyor is on version 1; height read at once, as legacy). Branch `version1`. Follows the pattern of [distributing.md](distributing.md), which is built and tested; this document lists only what is different or new.

Behaviour to reproduce: `docs/mps400/legacy/testing.yaml` (NxtStudio), with the version 1 decisions: black workpieces are rejected (user, 2026-11-09), every move waits for its end-position feedback where there is one, events instead of polling.

Items marked **⚠ To verify** need a test in EAE or on the machine before we rely on them.

## 1. Blocks

Asset CAT `Testing` (library `Flexbridge.FestoMPS400`, folder `Stations`), instance `TS01` in application `MPS400`, mapped to PLC_TS. The version 0 panel `TS` leaves PLC_TS first (a channel holds only one symbolic link), as `DS` did on PLC_DS.

| Frame | Block | Type | New? | Job |
|---|---|---|---|---|
| 0 Initialization | `EVENTCHAIN` | Runtime.Standard | | `'APP_INIT'`: `Mode` → `StationSeq` → `IThis` → acknowledge |
| 2 Functional output | `ISupply` | plug of `IWorkpieceSupply` | exists | Asks Distributing for a workpiece (`REQ`), gets `CNF` when it has been handed over |
| 2 Functional output | `IWaypoint` | plug of `IWaypoint` | new adapter | Talks to the conveyor waypoint at interface 1: tray state in, tray release out |
| 3 Field interface | `Console` | `ControlConsole` | exists | Buttons and lamps (DI08–DI11, DO08–DO11) |
| 3 Field interface | `PartAvailable`, `NotBlack`, `LightBarrier`, `HeightOk` | `DigitalInput` | | Sensors I0 (PART_AV), I1 (B2), I2 (B4), I3 (height comparator) |
| 4.A Typicals | `Lift` | `Actuator2Op` | exists | Lifting cylinder 1A1: open = raise (1M2, DO01, feedback 1B1 raised DI04), close = lower (1M1, DO00, feedback 1B2 lowered DI05) |
| 4.A Typicals | `Ejector` | `Actuator` | exists | Ejecting cylinder 2A1: open = extend (2M1, DO02); only a *retracted* sensor (2B1, DI06) = closed feedback |
| 4.A Typicals | `AirSlide` | `DigitalOutput` | | Air slide 3A1 (3M1, DO03), no feedback |
| 5.A Control logic | `Mode` | `StationMode` | exists | RESET / START / STOP, START and RESET lamps |
| 5.A Control logic | `StationSeq` | `TestingSequence` | new basic FB | Reset sequence and test cycle; `IDevice` plugs to `Lift`, `Ejector`, `AirSlide` |
| 5.A Control logic | `EjectTimer`, `SlideTimer` | `E_DELAY` | | Ejector extended 1 s (legacy); air slide on 2 s (stand-in, see section 4) |
| 6 HMI interface | `IThis` | `Testing_HMI` | new | Step display, stand-in buttons, OPC UA |

Not placed: the 1-bit optical link (IP_FI I7, IP_N_FO O7); the adapters replace it, as in Distributing. This also keeps the OPC UA variable count of PLC_TS (about 460) below the device limit of 500 (see distributing.md, section 5a).

Ejector without an open sensor: the `Actuator` watches both feedbacks, but the ejector is only ever held open for 1 s, and the feedback-failure alarm comes after 5 s (`MonTime`). The sequence ends "extend" on `EjectTimer`, then closes and waits for the retracted sensor. The same works for the vacuum's ejection pulse in Distributing.

## 2. Reset sequence (on `DO_RESET`)

1. `Lift`, `Ejector`, `AirSlide` to program local; wait until all report it (as Distributing).
2. Air slide off. Lower the lift until lowered (1B2).
3. Eject: ejector open, `EjectTimer` 1 s, ejector close until retracted (2B1). This clears a workpiece that may be in the station.
4. `RESET_DONE`.

## 3. Test cycle

Trigger: a tray at interface 1 (event `TRAY` from `IWaypoint`, or the stand-in button), accepted only while started.

| Step | Do | Next when |
|---|---|---|
| 1 | Tray carries a workpiece already: release the tray (`IWaypoint.RELEASE`). End | — |
| 2 | Tray empty: ask Distributing (`ISupply.REQ`) | `ISupply.CNF` |
| 3 | Black (`NotBlack` FALSE): eject at the bottom (1 s), back home, then back to step 2 | — |
| 4 | Raise the lift | raised |
| 5 | Height not ok (`HeightOk` FALSE): lower the lift, eject at the bottom, back to step 2 | — |
| 6 | Height ok: ejector open (pushes the workpiece onto the air slide) and air slide on | `EjectTimer` (1 s) |
| 7 | Ejector close | retracted |
| 8 | Air slide stays on | `SlideTimer` (2 s); later: conveyor reports a workpiece on the tray |
| 9 | Air slide off, lower the lift | lowered |
| 10 | Release the tray (`IWaypoint.RELEASE`); cycle counter + 1 | back to idle |

Legacy checks the height as soon as the lift is up (Festo's sequence waits 2 s). Version 1 does the same; **⚠ To verify** on the machine that the comparator has settled by then. If not, a short settle delay goes into step 5.

Faults: as Distributing (a device that needs Rearm stops the sequence, `FAULT` to `Mode`, Rearm on the faceplate, then RESET).

Cross-station safety comes from the handshake: Testing asks for a workpiece only with the lift lowered and the ejector retracted, and Distributing confirms only after its arm has left the Testing side. So the lift never moves while the arm is over it.

## 4. Adapter to the conveyor: `IWaypoint` (new)

Defined from the plug side, which belongs to the station (Testing now; later also the stations at the other interfaces):

| Plug sends | Plug receives |
|---|---|
| `STATE_REQ`: tell me the tray state (sent once after RESET, so that nothing is missed at start-up) | `TRAY` with `Tray` (a tray is at the stopper) and `Workpiece` (the tray carries a workpiece), sent on every change |
| `RELEASE`: release the tray | |

The conveyor waypoint (a CAT with the socket) is not built yet; it is part of the conveyor work. Until then, stand-ins on the `Testing` symbol replace it (section 5), and the air slide runs on `SlideTimer`.

## 5. `IThis` of `Testing`: HMI and OPC UA

Display as Distributing (`ModeText`, `StepText`, `StepNo`, `Cycles`), plus `Rejected` (counter of rejected workpieces) and `TrayReleased` (lamp: the tray has been released, until the next tray). Stand-in buttons (each click = one event): `TrayEmpty` (an empty tray has arrived) and `TrayFull` (a tray with a workpiece has arrived). Everything exposed over OPC UA.

## 6. Build order

1. EAE creates: CAT `Testing` and basic FB `TestingSequence` (folder `Stations`), adapter `IWaypoint` (normal, folder `Common`); instance `TS01` in `MPS400` mapped to PLC_TS; the V0 panel `TS` removed from `V0_IOTest`. The scripts fill in the rest: network, children, sequence, adapters, symbol, links on PLC_TS, `EnProgReq` for the air slide.
2. **First test of the adapter across PLCs:** connect `TS01.ISupply` to `DS01.ISupply` in the application. Verified 2026-11-17: EAE carries a normal adapter connection between two devices of one solution (TS01 on PLC_TS, DS01 on PLC_DS); a request from Testing makes Distributing run a cycle. (Open adapters are only needed between *solutions*.)
3. Reset sequence and a full test cycle with the stand-in tray button; black and wrong-height rejects.
4. Then step 5 of the plan for both stations: interlocks.

## 7. Test results (2026-11-17)

| Test | Result |
|---|---|
| Deploy PLC_TS (and PLC_DS with the adapter connection) | OK, no errors in the Studio log |
| RESET: lift down, one ejector stroke, START lamp | OK, after a *Rearm* of `Lift` (see below) |
| Cycle: *Empty tray* button → request to Distributing over `ISupply` → DS delivers → colour and height check → push onto the air slide → lift down → tray released | OK |
| Black workpiece: ejected at the bottom, `Rejected` + 1, asks Distributing again | OK |
| Wrong height: lift lowered, ejected, `Rejected` + 1 | Not tested: no workpiece of the wrong height at hand. Proposed test: *Input Override* on the `HeightOk` faceplate (library `DigitalInput`: the override value replaces the field signal and follows it while override is off), set it FALSE while the lift is down, then run a cycle. **⚠ To verify:** where the faceplate offers the override |
| Comparator settled when the lift reports *raised* (section 3) | Good workpieces passed, so no settle delay is needed so far. **⚠ To verify** again with the wrong-height test |

Lift alarm after every start (2026-11-17, cause found): *Detected Feedback Failure* on `Lift` a few seconds after each PLC start, before RESET; *Rearm* on the faceplate cleared it. The library starts a two-output device with setpoint 0 (stop), and with both feedbacks monitored it expects *neither* end position while stopped (`FbStop = NOT (open OR closed)` in `Actuator2OpBaseExt`; `devControlBasic` in `valve2OpLogic`). The lift rests lowered, so the monitoring time runs out. The Distributing swivel does not show it only because it is parked between its end positions.

Fix (agreed 2026-11-17, "adopt position"): at start-up the sequence takes the device over and commands the end position it already reports, so it is confirmed and nothing moves. Program local is requested on the device's `CNF_READY` (as `ConsoleIO` does for the lamps), at most 3 times; a device between its end positions needs nothing; the reset sequence ends the takeover. Built into `TestingSequence` (lift) and `DistributingSequence` (swivel) by `takeover()` in `tools/v1_types.py`. **⚠ To verify** on the machine: after a PLC start the lift faceplate shows *Program Local* and *closed* without an alarm, and the swivel likewise when it stands at an end position.

OPC UA (2026-11-17, open): UaExpert connects to PLC_TS (10.10.215.25), but **Objects** shows no `TS01`; `DS01` on PLC_DS shows. Checked and ruled out: the generated node set (`System.PLC_TS.opcua.xml`: `TS01` under Objects like `DS01`, no duplicate or dangling nodes); the device limits (EAE Output window: 462 of 1000 variables, 1176 of 1500 references, 2 strings, after raising *Maximum number of variable nodes* on PLC_TS to 1000 and deploying the device configuration). Difference noticed: the compiled address space of `TS01` (`ecort_opcua_ns2.bin`) is 101,226 bytes, that of `DS01` 98,305. **⚠ To verify** whether the dPAC loads it at all.
