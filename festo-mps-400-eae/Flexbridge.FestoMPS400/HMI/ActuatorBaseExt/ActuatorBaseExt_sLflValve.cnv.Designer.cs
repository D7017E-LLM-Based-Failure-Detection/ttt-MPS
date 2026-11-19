using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBaseExt
{
	/// <summary>
	/// Summary description for sLflValve.
	/// </summary>
	partial class sLflValve
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.baseControl = new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflValve();
			// 
			// baseControl
			// 
			this.baseControl.BeginInit();
			this.baseControl.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 32D, 24D);
			this.baseControl.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.baseControl.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.baseControl.MyTagDisplayName = null;
			this.baseControl.Name = "baseControl";
			this.baseControl.SecurityToken = ((uint)(4294967175u));
			this.baseControl.TagName = "actuatorBase";
			this.baseControl.EndInit();
			// 
			// sLflValve
			// 
			this.Name = "sLflValve";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.baseControl});
			this.SymbolSize = new System.Drawing.Size(200, 200);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SLflValveSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SLflValveSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SLflValveSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SLflValveSecuritySetpointChanged);

		}
		private Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflValve baseControl;
		#endregion
	}
}



