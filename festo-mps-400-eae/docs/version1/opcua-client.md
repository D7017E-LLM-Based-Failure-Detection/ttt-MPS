# Version 1: connecting UaExpert to the station PLCs

How to add a station PLC to UaExpert (the OPC UA client from Unified Automation), check the station's values, and save the setup so that it does not have to be entered again. It was first tested on Distributing (`DS01`, 2026-11-16, [distributing.md](distributing.md), section 5a). Steps marked **⚠ To verify** have not been checked in the UaExpert version installed in the lab.

Never write the lab password into this file, a screenshot or a saved project that goes into git.

## 1. Server settings

| | Distributing | Testing | Later |
|---|---|---|---|
| PLC | PLC_DS | PLC_TS | PLC_CV, PLC_HP, PLC_HS |
| Discovery URL | `opc.tcp://10.10.215.133:4840` | `opc.tcp://10.10.215.25:4840` | `opc.tcp://10.10.215.19:4840`, `…215.21:4840`, `…214.251:4840` |
| Endpoint to pick | Basic256Sha256 – Sign & Encrypt | the same | the same |
| Authentication | Username/Password: the lab user (the same as for the HMI login) | the same | the same |
| Configuration name (free text) | `PLC_DS DS01` | `PLC_TS TS01` | `PLC_CV`, `PLC_HP`, `PLC_HS` |
| Top object in the address space | `DS01` | `TS01` | |
| Tested | 2026-11-16 | **⚠ To verify** (the server is set up the same way on every dPAC) | |

Why *Discovery* and not the *Advanced* tab: the PLC announces its endpoints under the host name `spearHead`, not its IP address. An address typed by hand on the *Advanced* tab matches no endpoint and fails with "the server does not support the configured security policy".

The server accepts no anonymous login and no unencrypted connection (security policy *None* is off).

## 2. Adding a server

1. **Server → Add…** (or the **+** button in the toolbar). The *Add Server* dialog opens on the **Discovery** tab.
2. Expand **Custom Discovery**, double-click **< Double click to Add Server... >**, enter the discovery URL from section 1 and click **OK**.
3. Expand the new entry and the server below it, and select **Basic256Sha256 – Sign & Encrypt**.
4. Under **Authentication Settings** select **Username/Password** and enter the lab user name. Leave the password empty, or enter it without ticking any option that stores it (**⚠ To verify:** whether this UaExpert version offers to store the password). UaExpert then asks for the password at every connect, so the saved project does not hold it.
5. In **Configuration Name**, enter the name from section 1. If you tick **Connect automatically**, UaExpert connects when the project is opened.
6. Click **OK**. The server appears in the **Project** window under **Servers**, with an unplugged connector.
7. Right-click the server and choose **Connect**. The first time, UaExpert shows the PLC's certificate. Tick **Trust Server Certificate** (this saves it permanently) and click **Continue**. The PLC_DS certificate is already trusted on the lab PC (2026-11-16). If UaExpert warns that the host name in the endpoint (`spearHead`) differs from the URL you entered, choose to keep the URL you entered (**⚠ To verify:** the exact wording).
8. In the **Address Space** window, open **Root → Objects** and then the station (`DS01`, `TS01`). The station's blocks (`IThis`, `Console`, the devices) are under the station node. They are not under the **Server** node next to it, which every OPC UA server has for its own status and diagnostics. The **Project** window only lists the connection, not the variables. Drag the variables you want to watch, for example `IThis.ModeText`, `IThis.StepText` and `IThis.Cycles`, into the **Data Access View**.

## 3. Saving the setup (UaExpert project)

UaExpert keeps servers and views in a **project file** (`.uap`). If the project is not saved, the servers are gone when UaExpert closes. Its own settings and the trusted certificates stay saved anyway (`%APPDATA%\unifiedautomation\uaexpert`). This happened on 2026-11-16: the certificate was kept, the server was not.

1. After adding the servers (and filling the Data Access View), choose **File → Save Project As…**.
2. Save it outside the repository, for example as `Documents\UaExpert\MPS400.uap`. It holds the server addresses, the user name and the views. Keep it out of git.
3. After later changes (another server, more variables), choose **File → Save Project**.
4. To open it again: on UaExpert's **Start Page** under **Recent Projects**, or with **File → Open Project…**. Connect with right-click **Connect** (or automatically, see section 2, step 5) and enter the password.

One project can hold all station PLCs, so `MPS400.uap` grows as stations move to version 1.

The `.uap` format is UaExpert's own and can change between UaExpert versions. After a UaExpert update, check that the project still opens, and if it does not, add the servers again as in section 2.

## 4. Quick check that a station is reachable

With a station started:

- `IThis.ModeText` shows the mode (for example "Started"), and `IThis.StepText` shows the current step, both with status *Good*.
- Writing `TRUE` to the request variable (Distributing: `IThis.RequestWp`) fires its event and runs one cycle (tested on `DS01`, 2026-11-16).
