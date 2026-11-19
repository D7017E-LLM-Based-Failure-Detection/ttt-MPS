using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Actuator2OpBaseExt
{
	/// <summary>
	/// Summary description for sDefauly.
	/// </summary>
	partial class sDamper
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sDamper1 = new Flexbridge.FestoMPS400.Symbols.Actuator2OpBase.sDamper();
			// 
			// sDamper1
			// 
			this.sDamper1.BeginInit();
			this.sDamper1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 12D, 18D);
			this.sDamper1.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.sDamper1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDamper1.MyTagDisplayName = null;
			this.sDamper1.Name = "sDamper1";
			this.sDamper1.SecurityToken = ((uint)(4294967175u));
			this.sDamper1.TagName = "actuator2OpBase";
			this.sDamper1.EndInit();
			// 
			// sDamper
			// 
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.sDamper1});
			this.SymbolSize = new System.Drawing.Size(200, 200);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SDefaultSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SDefaultSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SDefaultSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SDefaultSecuritySetpointChanged);

		}
		private Flexbridge.FestoMPS400.Symbols.Actuator2OpBase.sDamper sDamper1;
		#endregion
	}
}



