using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBaseExt
{
	/// <summary>
	/// Summary description for sDefault.
	/// </summary>
	partial class sDiverter
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sDiverter1 = new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sDiverter();
			// 
			// sDiverter1
			// 
			this.sDiverter1.BeginInit();
			this.sDiverter1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 36D, 10D);
			this.sDiverter1.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.sDiverter1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDiverter1.MyTagDisplayName = null;
			this.sDiverter1.Name = "sDiverter1";
			this.sDiverter1.SecurityToken = ((uint)(4294967175u));
			this.sDiverter1.TagName = "actuatorBase";
			this.sDiverter1.EndInit();
			// 
			// sDiverter
			// 
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.sDiverter1});
			this.SymbolSize = new System.Drawing.Size(508, 368);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SDefaultSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SDefaultSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SDefaultSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SDefaultSecuritySetpointChanged);

		}
		private Flexbridge.FestoMPS400.Symbols.ActuatorBase.sDiverter sDiverter1;
		#endregion
	}
}



