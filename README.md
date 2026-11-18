# Festo MPS - EcoStruxure Automation Expert (EAE)

Control software and HMI visualization for the Festo Modular Production System (MPS), implemented in Schneider Electric **EcoStruxure Automation Expert (EAE)** using IEC 61499 and Schneider Electric's standard process and sequence libraries.

---

## Requirements

- **EcoStruxure Automation Expert (EAE):** `25.0.1.0` (25.0 Update 1)
- **Standard Libraries:** Installed locally with EAE in `C:\ProgramData\Schneider Electric\Libraries` (pinned in `IEC61499/IEC61499.dfbproj`, including `Runtime.Base 25.0.1.2`, `SE.App2Base 25.0.1.5`, `SE.App2CommonProcess 25.0.1.5`, `SE.AppSequence 25.0.1.5`, `SE.DPAC 25.0.1.10`, and `SE.IoTMx 25.0.1.4`)

> [!NOTE]
> Library copies (`.exportedlibraries/`, `*.fblib`), build outputs (`[Bb]in/`, `[Oo]bj/`), compile snapshots, and generated help archives are excluded via `.gitignore` and regenerated automatically by EAE on build.

---

## Opening & Building the Solution

1. Open the target `.sln` file in **EAE 25.0.1**.
2. Wait for EAE to resolve the standard libraries from the local installation.
3. Run **Verify** (compiles IEC 61499 types), then **Build → Rebuild Solution** (builds the HMI and hardware configuration).

> [!TIP]
> Always close the solution in EAE before switching Git branches or modifying files outside EAE so `.lock_sln` or cached build outputs do not interfere.

---

## Running Simulation & Deploying

1. Open **Deploy and Diagnostic** and set **Active Network Profile** to **`Local Test`**.
2. Right-click the target device and select **Start Runtime Simulation**.
3. **Log in** to the device using the solution credentials.
4. Deploy the configuration and application:
   - Run **Deploy and Restart** (for device configuration changes).
   - **Log in again** once the runtime finishes restarting.
   - Run **Deploy** to download the application.
5. Confirm the device status shows **`Running`**.

---

## Starting & Testing the HMI

1. Under **HMI → Canvases**, verify that the desired canvas is marked as **Startup Canvas** (if you change it, save all and **Rebuild** the HMI project so the runtime database updates).
2. Select **Start Local HMI** and **log in** when prompted on the canvas.
3. For offline testing via faceplates:
   - **Clear start-up alarms:** Open any faceplate showing a warning/alarm badge (`!`) and press **Rearm**.
   - **Manual device testing:** Switch **Owner** to **`Operator`** to command devices directly (`Run`/`Stop`, `Open`/`Close`), then return **Owner** to **`Program`** before running sequences.
   - **Simulated feedback & sensors:** Enable **Simulation** on actuator faceplates where needed, and use **Override** / **Override Value** on `DigitalInput` faceplates to simulate sensor transitions.
   - **Sequence testing:** Open the sequence (`SeqHead`) faceplate, switch **Owner** to **`Operator`**, select **`Auto`** or **`Semi-Auto`**, and press **Start**.

---

## Troubleshooting

- **Simulation login fails with *"Device cannot be authenticated"*:**
  Windows NAT (`winnat`, commonly triggered alongside WSL) can reserve TCP ports used by EAE's local runtime simulator. From an **Administrator Command Prompt**, cycle `winnat` around starting simulation:
  ```bat
  net stop winnat
  :: Start Runtime Simulation and deploy in EAE
  net start winnat
  ```
- **Start Local HMI opens the wrong canvas:**
  Set the target canvas as **Startup Canvas**, press `Ctrl+Shift+S` to save, run **Build → Rebuild Solution** (or rebuild the `HMI` project), and relaunch **Start Local HMI**.
- **HMI symbols appear magenta:**
  Confirm you are logged in on the HMI canvas and that the application has been deployed and is **Running** on the controller.
