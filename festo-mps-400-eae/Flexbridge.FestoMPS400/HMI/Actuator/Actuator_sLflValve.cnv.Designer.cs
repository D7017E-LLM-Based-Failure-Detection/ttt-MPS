using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Actuator
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
			this.alarmSAFrame1 = new NxtControl.GuiFramework.AlarmFrame();
			this.sLflValve1 = new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflValve();
			((System.ComponentModel.ISupportInitialize)(this.alarmSAFrame1)).BeginInit();
			// 
			// alarmSAFrame1
			// 
			this.alarmSAFrame1.Bounds = new NxtControl.Drawing.RectF(((float)(42D)), ((float)(23D)), ((float)(83D)), ((float)(55D)));
			this.alarmSAFrame1.FrameWidth = ((uint)(2u));
			this.alarmSAFrame1.Name = "alarmSAFrame1";
			this.alarmSAFrame1.Radius = 5D;
			// 
			// sLflValve1
			// 
			this.sLflValve1.BeginInit();
			this.sLflValve1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 42D, 5D);
			this.sLflValve1.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.sLflValve1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sLflValve1.MyTagDisplayName = null;
			this.sLflValve1.Name = "sLflValve1";
			this.sLflValve1.SecurityToken = ((uint)(4294967175u));
			this.sLflValve1.TagName = "actuatorBaseExt.actuatorBase";
			this.sLflValve1.OnOptionalServicesAvailable += new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflValve.OptionalServicesAvailable(this.SLflValve1OnOptionalServicesAvailable);
			this.sLflValve1.EndInit();
			// 
			// sLflValve
			// 
			this.Name = "sLflValve";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmSAFrame1,
			this.sLflValve1});
			this.SymbolSize = new System.Drawing.Size(200, 200);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SLflValveSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SLflValveSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SLflValveSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SLflValveSecuritySetpointChanged);
			((System.ComponentModel.ISupportInitialize)(this.alarmSAFrame1)).EndInit();

		}
		private NxtControl.GuiFramework.AlarmFrame alarmSAFrame1;
		private Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflValve sLflValve1;
		#endregion
	}
}



