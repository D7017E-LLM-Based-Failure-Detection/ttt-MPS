using System;
using NxtControl.GuiFramework;
using NxtControl.Services;

namespace Flexbridge.FestoMPS400.Symbols.IOTest16
{
	/// <summary>
	/// I/O test panel. Code here only changes what is shown; every decision is taken in the controller (IOTest16Logic).
	/// </summary>
	public partial class sDefault : NxtControl.GuiFramework.HMISymbol
	{
		public sDefault()
		{
			InitializeComponent();
			// Grey out a button while the controller does not allow it (partner output on, or another pulse running).
			// Bring a button back in line with the real output state (refused request, pulse ended, all off).
			ledEn00.ValueChanged += (s, e) => btnDO00.Enabled = ToBool(ledEn00.Value);
			ledDO00.ValueChanged += (s, e) => SyncButton(btnDO00, ledDO00.Value);
			ledEn01.ValueChanged += (s, e) => btnDO01.Enabled = ToBool(ledEn01.Value);
			ledDO01.ValueChanged += (s, e) => SyncButton(btnDO01, ledDO01.Value);
			ledEn02.ValueChanged += (s, e) => btnDO02.Enabled = ToBool(ledEn02.Value);
			ledDO02.ValueChanged += (s, e) => SyncButton(btnDO02, ledDO02.Value);
			ledEn03.ValueChanged += (s, e) => btnDO03.Enabled = ToBool(ledEn03.Value);
			ledDO03.ValueChanged += (s, e) => SyncButton(btnDO03, ledDO03.Value);
			ledEn04.ValueChanged += (s, e) => btnDO04.Enabled = ToBool(ledEn04.Value);
			ledDO04.ValueChanged += (s, e) => SyncButton(btnDO04, ledDO04.Value);
			ledEn05.ValueChanged += (s, e) => btnDO05.Enabled = ToBool(ledEn05.Value);
			ledDO05.ValueChanged += (s, e) => SyncButton(btnDO05, ledDO05.Value);
			ledEn06.ValueChanged += (s, e) => btnDO06.Enabled = ToBool(ledEn06.Value);
			ledDO06.ValueChanged += (s, e) => SyncButton(btnDO06, ledDO06.Value);
			ledEn07.ValueChanged += (s, e) => btnDO07.Enabled = ToBool(ledEn07.Value);
			ledDO07.ValueChanged += (s, e) => SyncButton(btnDO07, ledDO07.Value);
			ledEn08.ValueChanged += (s, e) => btnDO08.Enabled = ToBool(ledEn08.Value);
			ledDO08.ValueChanged += (s, e) => SyncButton(btnDO08, ledDO08.Value);
			ledEn09.ValueChanged += (s, e) => btnDO09.Enabled = ToBool(ledEn09.Value);
			ledDO09.ValueChanged += (s, e) => SyncButton(btnDO09, ledDO09.Value);
			ledEn10.ValueChanged += (s, e) => btnDO10.Enabled = ToBool(ledEn10.Value);
			ledDO10.ValueChanged += (s, e) => SyncButton(btnDO10, ledDO10.Value);
			ledEn11.ValueChanged += (s, e) => btnDO11.Enabled = ToBool(ledEn11.Value);
			ledDO11.ValueChanged += (s, e) => SyncButton(btnDO11, ledDO11.Value);
			ledEn12.ValueChanged += (s, e) => btnDO12.Enabled = ToBool(ledEn12.Value);
			ledDO12.ValueChanged += (s, e) => SyncButton(btnDO12, ledDO12.Value);
			ledEn13.ValueChanged += (s, e) => btnDO13.Enabled = ToBool(ledEn13.Value);
			ledDO13.ValueChanged += (s, e) => SyncButton(btnDO13, ledDO13.Value);
			ledEn14.ValueChanged += (s, e) => btnDO14.Enabled = ToBool(ledEn14.Value);
			ledDO14.ValueChanged += (s, e) => SyncButton(btnDO14, ledDO14.Value);
			ledEn15.ValueChanged += (s, e) => btnDO15.Enabled = ToBool(ledEn15.Value);
			ledDO15.ValueChanged += (s, e) => SyncButton(btnDO15, ledDO15.Value);
		}

		static bool ToBool(object value)
		{
			return value != null && Convert.ToBoolean(value);
		}

		static void SyncButton(System.HMI.Symbols.Base.SwitchButton button, object state)
		{
			bool on = ToBool(state);
			if (ToBool(button.Value) != on)
				button.Value = on;
		}

		public override void ConnectionStateChanged(int chanelId, bool connected)
		{
			base.ConnectionStateChanged(chanelId, connected);
			if (!connected) return;
			var hmi = ServiceProvider.GetService<IHMIManagementService>();
			txtInstance.Text = hmi.GetCATInstanceInfo(this.TagName).Name;
		}
	}
}
