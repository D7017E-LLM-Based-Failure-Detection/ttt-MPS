using System;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBaseExt
{
	/// <summary>
	/// Description of InstanceName.
	/// </summary>
	public partial class sInstanceName : SE.App2Base.Symbols.SEAppLibHMISymbol
	{
		public sInstanceName()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		
		public override void UpdateTagDisplayName()
		{
			base.UpdateTagDisplayName();
			aliasDisplayLabel1.CustomInstanceName = TagDisplayName;
		}
		
	}
}
