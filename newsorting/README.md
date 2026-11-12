# Sorting station

Distribution-style sorting project for EAE 25.0.1.

- Open `sorting/sorting2n.sln` in EAE.
- Read [docs/REPORT.md](docs/REPORT.md) for the conversion from the Festo chart to standard EAE blocks.
- The original chart is `docs/09_Sorting_GRAFCET.pdf`.
- Two diagrams: `docs/station-blocks.png` and `docs/auto-cycle.png`.
- Run `python sorting_opcua_listener.py --help` for listener options. Install its dependency with `python -m pip install -r requirements.txt`.

The M251/M580 physical device and channel assignments still need commissioning. No runtime/deployment tests were run.

## OPC UA listener

Enable the required library `IThis` values in the selected device OPC UA server editor, then build and deploy. Use the actual endpoint configured for that device.

```powershell
python -m pip install -r requirements.txt
python sorting_opcua_listener.py --url opc.tcp://CONTROLLER_IP:4840 --list
python sorting_opcua_listener.py --url opc.tcp://CONTROLLER_IP:4840 --csv sorting.csv
```

The listener reads generated deployment addresses or browses the server. Use `--deploy-file` to select the matching file when several controllers have been deployed. It prints current values and subsequent changes; it does not command the station. No live listener connection has been verified.
