# Version 0 — student guide: I/O test of the MPS 400

You wired the five M251 controllers and checked every wire with a multimeter. Now you check the same wires from the other end: from the EAE application. When you are done, you can switch every output of every station by hand from an HMI, see every input light up, and you have proof in the wiring sheet that each channel works.

On the way you learn the steps every EAE project needs: device, resource, hardware configuration, symbolic links, CAT, HMI and deploy. Version 1 uses exactly these steps again.

Background reading: [design.md](design.md) (what we build and why), [instance-parameters.md](instance-parameters.md) (the settings for each panel), `docs/mps400/wiring-check.xlsx` (your test record).

Steps marked **⚠** are not yet tried in our EAE installation. If the IDE looks different from what is written, note what you did instead, so we can correct the guide.

---

## 0. Safety first

Read this before you touch a button. These are real machines with compressed air, motors and a drill.

1. The person pressing a button must see the machine. Say what you are about to switch ("swivel to magazine") before you press.
2. Nobody's hands in a station while outputs are being tested.
3. One output at a time. Switch it off before the next one.
4. Pneumatic stations: test the outputs first with the **air supply off**. The LED on the valve terminal tells you the coil is switched. Only then turn the air on.
5. Processing: the table output is a start pulse and the drill motor turns a real drill. Keep clear.
6. Conveyors: belts start moving. Keep loose clothing and cables away.
7. If anything moves unexpectedly: press **All outputs off** on the HMI, then turn off the air.

## 1. Who does what

Work in pairs: one at the PC (EAE and HMI), one at the machine (sensors, LEDs, observing). Swap roles after each station.

Three PLCs are set up for you as the worked example (Part B done, you do Part C on them). You set up the other two yourselves, following the example:

| PLC | IP address | Panels | Part B (set-up) | Part C (test) |
|---|---|---|---|---|
| plc-distributing | 10.10.215.133 | `DS` | example | students |
| plc-testing | 10.10.215.25 | `TS` | example | students |
| plc-conveyor | 10.10.215.19 | `CV_AB`, `CV_CD` | example | students |
| plc-handling-processing | 10.10.215.21 | `HS2`, `PS` | students (pair 1) | students |
| plc-handling-sorting | 10.10.214.251 | `HS6`, `SS` | students (pair 2) | students |

The conveyor test is the detective job: nobody knows yet which connector belongs to which conveyor. You find out by triggering sensors and watching which lamp lights.

**One solution, one keyboard.** All work happens in the same EAE solution on the lab PC (git branch `version0`). EAE files do not merge well, so only one person edits at a time; the others prepare at their station.

## 2. Levels: from the wire to the screen

Everything you do sits at one of these levels. Keep the picture in mind; version 1 adds more on top, but the bottom stays the same.

```
HMI panel  (lamp, button)                        ← what the operator sees
   │
CAT instance  DS : IOTest16                      ← application: one per module pair
   │   dISignal DI04  →  symbolic link  "…DS.DI04.DIn"
   │   dOSignal DO03  →  symbolic link  "…DS.DO03.DOut"
   │
Hardware configuration of device PLC_DS          ← which link goes to which channel
   │   TM3DI16_G  channel DI04  ← "…DS.DI04.DIn"
   │   TM3DQ16R_G channel DO03  ← "…DS.DO03.DOut"
   │
TM3 module terminal  →  wire  →  SysLink  →  sensor 3B1 / coil 3M1   ← what you wired
```

## 3. Part A — together, once: the `IOTest16` type

This part is prepared for you; the project owner opens it in EAE and walks you through it. Read the steps below to know what is inside and why.

1. **Library project.** Create the EAE library project `Flexbridge.FestoMPS400` in the solution, and in it the folder `Testers`. **⚠** (menu path to be noted).
2. **New CAT `IOTest16`** in that folder. Lay out the frames as in the design pattern: 0 Initialization, 3 Field interface, 5 Logic, 6 HMI interface.
3. **Field interface.** Add 16 × `dISignal` (SE.App2Base), named `DI00` … `DI15`, and 16 × `dOSignal`, named `DO00` … `DO15`. Leave their `Name` parameter at the default (`${PATH}DIn`, `${PATH}DOut`). The block names become part of the symbolic-link names, so spell them exactly like this.
4. **Interface parameters.** `LabelDI00`–`LabelDI15`, `LabelDO00`–`LabelDO15` (`STRING[48]`), `ExclDO00`–`ExclDO15` (INT, default -1), `PulseDO00`–`PulseDO15` (TIME, default `T#0s`).
5. **Logic** `IOTest16Logic` (basic FB, ST). Its rules:
   - A button request for output *n* to switch **on** is refused while the partner output (`ExclDOn`) is on.
   - A request to switch **off** is always accepted. **All outputs off** switches all 16 off.
   - When output *n* goes on and `PulseDOn` > 0, a timer starts; when it runs out, output *n* goes off.
   - After every change: send the new value to `DOn`, and recompute for every output whether its button is enabled (= its partner is off).
   - Send events only when something changed.
6. **`IThis`** (`IOTest16_HMI`): inputs to the HMI = lamps (with quality), output states, button-enabled flags, labels; outputs from the HMI = button requests (one event each) and **All outputs off**. Expose everything over OPC UA.
7. **HMI symbol.** Two columns (channels 0–7 = station, 8–15 = control panel). Per row: input lamp + label, output button + label. Button greyed out when not enabled. Lamp looks different for "bad quality" than for "off". **⚠** (how EAE shows VTQ quality).
8. **Compile** the library. No errors before you continue.

Checkpoint A: the project owner reviews the CAT before anyone uses it.

## 4. Part B — per PLC: device, hardware, instance, links

Do these steps for your own PLC. Use the names from the table in [design.md](design.md) (`PLC_DS`, `PLC_TS`, `PLC_HP`, `PLC_CV`, `PLC_HS`).

1. **Ping** the PLC from the lab PC (`ping 10.10.215.133` etc.). No answer: check cable, power and the PC's network settings before going on. Write down whether the address was right.
2. **Device.** System → Devices → add device of type `M251_dPAC`, name it, set its IP address. **⚠** (where the address is set: device properties or topology).
3. **Resource.** Open `RES0`, insert `DPAC_FULLINIT` (Ctrl+W), connect `START.COLD` and `START.WARM` → `INIT`, `START.ONLINECHANGE` → `OC_RETRIGGER`.
4. **Device settings.** Deploy Service → *Auto clean before deploy* = True; Runtime Configuration → *Auto start after deploy* = True; Boot → *Behaviour on boot* = Run.
5. **Hardware configuration.** Add the TM3 bus (`BMTM3`) and the modules **in the order they sit on the PLC**: `TM3DI16_G`, `TM3DQ16R_G` (and for shared PLCs again `TM3DI16_G`, `TM3DQ16R_G`). Compare with the real module order on the rail.
6. **Instances.** In application `V0_IOTest`, place one `IOTest16` per module pair and name it (`DS`, `TS`, `HS2`, `PS`, `CV_AB`, `CV_CD`, `HS6`, `SS`). Map each instance to your device's `RES0`.
7. **Parameters.** Enter the labels, `Excl` and `Pulse` values from [instance-parameters.md](instance-parameters.md). Check the exclusive pairs twice: they protect the machine.
8. **Symbolic links.** Open the Symbolic Links window, filter on your instance, select its `DI00.DIn` … `DI15.DIn` and drag them onto channels DI00–DI15 of the right input module; the same for `DO00.DOut` … onto the output module. Then check three channels by hand: is `DI04.DIn` really on channel DI04?
9. **Deploy.** Deploy and Diagnostic → tick only your device → Deploy Device Configuration (*Deploy and Restart*) → log in → Deploy. **⚠** (network profile for real hardware).

Checkpoint B: the project owner looks at your hardware configuration and links before the first output is switched.

## 5. Part C — per panel: the test

Open the HMI on the lab PC and your panel. Have `wiring-check.xlsx` open on the sheet for your station.

1. **Inputs.** For each input channel: trigger the sensor (move the cylinder by hand with air off, put a workpiece in front, press the panel button). Both the LED on the TM3 module and the lamp on the HMI must light. Mark "Wired and checked" = Yes, or write what you saw in Notes.
2. **Outputs, air off.** Press each button. The TM3 output LED and the valve-terminal LED must light. Try to switch on both outputs of an exclusive pair: the second button must be greyed out.
3. **Outputs, air on.** Press each button and watch the device move. Its end-position sensor must light on the HMI.
4. **One cycle by hand.** Run the station through one Festo cycle with the buttons, in the order of the sequence in `docs/mps400/station-types/<station>.yaml`. This is what version 1 will do automatically.

Special tasks:

- **Processing** `PS` DI01 / DI02 and **Sorting** `SS` DI01 / DI02 are marked ⚠: the old program and Festo's drawing disagree about which sensor is where. Put a workpiece at the checking unit (Processing) or a metal workpiece in front of the sensors (Sorting) and write down which lamp lights.
- **Conveyor** `CV_AB`, `CV_CD`: for each lamp and button, find out what it is (stopper, tray sensor, …) and at which interface, and fill in the Conveyor sheet. Watch what the CONGESTION inputs do.

Checkpoint C: every row of your sheet is Yes, or has a note.

## 6. When something does not work

| Symptom | Look at |
|---|---|
| Lamp off, TM3 LED off | Wiring or sensor: back to the multimeter |
| TM3 LED on, lamp off | Symbolic link on the wrong channel, or module order in the hardware configuration differs from the rail |
| Lamp shows bad quality | TM3 bus or module not running: diagnostics in EAE, module LEDs |
| Button pressed, nothing on the TM3 output LED | Link of the `DOxx` channel; button greyed out because the partner is on |
| TM3 output LED on, valve LED off | Wiring between module and SysLink, or 24 V supply of the outputs (XMA2 pins 9–12) |
| Valve LED on, nothing moves | Air supply, manual override on the valve, flow controls closed |

Write every problem and its cause in the Notes column. The next group will thank you.
