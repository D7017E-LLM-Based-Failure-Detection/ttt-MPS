using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Actuator2Op
{
	/// <summary>
	/// Summary description for sDefaul2.
	/// </summary>
	partial class sDefault
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.alarmFrame1 = new NxtControl.GuiFramework.AlarmFrame();
			this.sDefault1 = new Flexbridge.FestoMPS400.Symbols.Actuator2OpBase.sDefault();
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).BeginInit();
			// 
			// alarmFrame1
			// 
			this.alarmFrame1.Bounds = new NxtControl.Drawing.RectF(((float)(24D)), ((float)(24D)), ((float)(56D)), ((float)(64D)));
			this.alarmFrame1.FrameWidth = ((uint)(2u));
			this.alarmFrame1.Name = "alarmFrame1";
			this.alarmFrame1.Radius = 5D;
			// 
			// sDefault1
			// 
			this.sDefault1.BeginInit();
			this.sDefault1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 9D, -2D);
			this.sDefault1.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.sDefault1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault1.MyTagDisplayName = null;
			this.sDefault1.Name = "sDefault1";

			this.sDefault1.SecurityToken = ((uint)(4294967175u));
			this.sDefault1.TagName = "actuator2OpBaseExt.actuator2OpBase";
			this.sDefault1.OnOptionalServicesAvailable += new Flexbridge.FestoMPS400.Symbols.Actuator2OpBase.sDefault.OptionalServicesAvailable(this.SDefault1OnOptionalServicesAvailable);
			this.sDefault1.EndInit();
			// 
			// sDefault
			// 
			this.Name = "sDefaul2";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmFrame1,
			this.sDefault1});
			this.SymbolSize = new System.Drawing.Size(200, 200);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SDefaultSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SDefaultSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SDefaultSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SDefaultSecuritySetpointChanged);
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).EndInit();

		}
		private NxtControl.GuiFramework.AlarmFrame alarmFrame1;
		private Flexbridge.FestoMPS400.Symbols.Actuator2OpBase.sDefault sDefault1;
		#endregion
	}
}



