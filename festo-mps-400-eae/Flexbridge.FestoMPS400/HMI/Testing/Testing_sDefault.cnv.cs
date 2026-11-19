using System;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Testing
{
	/// <summary>
	/// Station overview: mode, step, tray released, and stand-in buttons for the conveyor.
	/// Display only; every decision is taken in the controller (TestingSequence).
	/// </summary>
	public partial class sDefault : NxtControl.GuiFramework.HMISymbol
	{
		public sDefault()
		{
			InitializeComponent();
		}
	}
}
