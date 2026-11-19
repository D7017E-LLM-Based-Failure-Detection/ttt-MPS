using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Actuator
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
			this.alarmFrame1 = new NxtControl.GuiFramework.AlarmFrame();
			this.sDiverter1 = new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sDiverter();
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).BeginInit();
			// 
			// alarmFrame1
			// 
			this.alarmFrame1.Bounds = new NxtControl.Drawing.RectF(((float)(32D)), ((float)(24D)), ((float)(88D)), ((float)(88D)));
			this.alarmFrame1.FrameWidth = ((uint)(2u));
			this.alarmFrame1.Name = "alarmFrame1";
			this.alarmFrame1.Radius = 5D;
			// 
			// sDiverter1
			// 
			this.sDiverter1.BeginInit();
			this.sDiverter1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 40D, 21D);
			this.sDiverter1.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.sDiverter1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDiverter1.MyTagDisplayName = null;
			this.sDiverter1.Name = "sDiverter1";
			this.sDiverter1.SecurityToken = ((uint)(4294967175u));
			this.sDiverter1.TagName = "actuatorBaseExt.actuatorBase";
			this.sDiverter1.OnOptionalServicesAvailable += new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sDiverter.OptionalServicesAvailable(this.SDefault1OnOptionalServicesAvailable);
			this.sDiverter1.EndInit();
			// 
			// sDiverter
			// 
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmFrame1,
			this.sDiverter1});
			this.SymbolSize = new System.Drawing.Size(600, 400);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SDefaultSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SDefaultSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SDefaultSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SDefaultSecuritySetpointChanged);
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).EndInit();

		}
		private NxtControl.GuiFramework.AlarmFrame alarmFrame1;
		private Flexbridge.FestoMPS400.Symbols.ActuatorBase.sDiverter sDiverter1;
		#endregion
	}
}



