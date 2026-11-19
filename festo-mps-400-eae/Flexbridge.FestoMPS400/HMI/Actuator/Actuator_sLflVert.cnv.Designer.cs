using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Actuator
{
	/// <summary>
	/// Summary description for sLflVert.
	/// </summary>
	partial class sLflVert
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.slflValve = new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflVert();
			this.alarmFrame1 = new NxtControl.GuiFramework.AlarmFrame();
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).BeginInit();
			// 
			// slflValve
			// 
			this.slflValve.BeginInit();
			this.slflValve.CurrView = SE.App2Base.SupportClasses.CurrentView.Open;
			this.slflValve.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 48D, 16D);
			this.slflValve.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.slflValve.MyTagDisplayName = null;
			this.slflValve.Name = "slflValve";
			this.slflValve.SecurityToken = ((uint)(4294967175u));
			this.slflValve.TagName = "actuatorBaseExt.actuatorBase";
			this.slflValve.ValveAppearance.HouseNos = SE.App2Base.SupportClasses.HousingNos.Three;
			this.slflValve.OnOptionalServicesAvailable += new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflVert.OptionalServicesAvailable(this.SlflValveOnOptionalServicesAvailable);
			this.slflValve.EndInit();
			// 
			// alarmFrame1
			// 
			this.alarmFrame1.Bounds = new NxtControl.Drawing.RectF(((float)(48D)), ((float)(32D)), ((float)(72D)), ((float)(128D)));
			this.alarmFrame1.FrameWidth = ((uint)(2u));
			this.alarmFrame1.Name = "alarmFrame1";
			this.alarmFrame1.Radius = 5D;
			// 
			// sLflVert
			// 
			this.Name = "sLflVert";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmFrame1,
			this.slflValve});
			this.SymbolSize = new System.Drawing.Size(200, 200);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.sLFLValveSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.sLFLValveSecurityOwnerChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.sLFLValveSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.sLFLValveSecuritySetpointChanged);
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).EndInit();

		}
		private Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflVert slflValve;
		private NxtControl.GuiFramework.AlarmFrame alarmFrame1;
		#endregion
	}
}
