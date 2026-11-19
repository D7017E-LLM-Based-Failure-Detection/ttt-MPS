using System;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Distributing
{
	/// <summary>
	/// Station overview: mode, step, waiting lamp, and a button that requests one workpiece.
	/// Display only; every decision is taken in the controller (DistributingSequence).
	/// </summary>
	public partial class sDefault : NxtControl.GuiFramework.HMISymbol
	{
		public sDefault()
		{
			InitializeComponent();
		}
	}
}
