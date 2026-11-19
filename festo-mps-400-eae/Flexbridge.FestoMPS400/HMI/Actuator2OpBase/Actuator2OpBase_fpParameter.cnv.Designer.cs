using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase
{
	/// <summary>
	/// Summary description for fpParameter.
	/// </summary>
	partial class fpParameter
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ConfResetReq = new System.HMI.Symbols.Base.SwitchButton();
			this.Sim = new System.HMI.Symbols.Base.SwitchButton();
			this.Over = new System.HMI.Symbols.Base.SwitchButton();
			this.Maint = new System.HMI.Symbols.Base.SwitchButton();
			this.txtMonitorTime = new System.HMI.Symbols.Base.TextBox<int>();
			this.txtTripTime = new System.HMI.Symbols.Base.TextBox<int>();
			this.combofbmode = new System.HMI.Symbols.Base.DropDown<byte>();
			this.execute_11 = new System.HMI.Symbols.Base.Execute<bool>();
			this.execute_12 = new System.HMI.Symbols.Base.Execute<bool>();
			this.labelS1 = new SE.App2Base.Graphics.LabelS();
			this.labelS2 = new SE.App2Base.Graphics.LabelS();
			this.labelS3 = new SE.App2Base.Graphics.LabelS();
			this.labelS5 = new SE.App2Base.Graphics.LabelS();
			this.labelS6 = new SE.App2Base.Graphics.LabelS();
			this.labelS7 = new SE.App2Base.Graphics.LabelS();
			this.labelS9 = new SE.App2Base.Graphics.LabelS();
			this.execute_13 = new System.HMI.Symbols.Base.Execute<bool>();
			this.Oos = new System.HMI.Symbols.Base.SwitchButton();
			this.labelS4 = new SE.App2Base.Graphics.LabelS();
			this.FbStatus = new System.HMI.Symbols.Base.Execute<short>();
			this.TransFbStatus = new System.HMI.Symbols.Base.Execute<short>();
			// 
			// ConfResetReq
			// 
			this.ConfResetReq.BeginInit();
			this.ConfResetReq.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.475D, 0D, 0D, 0.83333333333333348D, 120D, 108D);
			this.ConfResetReq.FalseBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.ConfResetReq.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.ConfResetReq.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.ConfResetReq.FalseText = "$key:SE.App2CommonProcess.TxtDisable";
			this.ConfResetReq.FalseTextKey = "SE.App2CommonProcess.TxtDisable";
			this.ConfResetReq.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.ConfResetReq.Name = "ConfResetReq";
			this.ConfResetReq.SecurityLevel = 0;
			this.ConfResetReq.TagName = "ConfResetReq";
			this.ConfResetReq.TrueBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.ConfResetReq.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.ConfResetReq.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.ConfResetReq.TrueText = "$key:SE.App2CommonProcess.TxtEnable";
			this.ConfResetReq.TrueTextKey = "SE.App2CommonProcess.TxtEnable";
			this.ConfResetReq.Value = false;
			this.ConfResetReq.EndInit();
			// 
			// Sim
			// 
			this.Sim.BeginInit();
			this.Sim.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.475D, 0D, 0D, 0.83333333333333348D, 119D, 138D);
			this.Sim.FalseBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Sim.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.Sim.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Sim.FalseText = "$key:SE.App2CommonProcess.TxtDisable";
			this.Sim.FalseTextKey = "SE.App2CommonProcess.TxtDisable";
			this.Sim.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.Sim.Name = "Sim";
			this.Sim.SecurityLevel = 0;
			this.Sim.TagName = "Simulation";
			this.Sim.TrueBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Sim.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.Sim.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Sim.TrueText = "$key:SE.App2CommonProcess.TxtEnable";
			this.Sim.TrueTextKey = "SE.App2CommonProcess.TxtEnable";
			this.Sim.Value = false;
			this.Sim.EndInit();
			// 
			// Over
			// 
			this.Over.BeginInit();
			this.Over.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.475D, 0D, 0D, 0.83333333333333348D, 120D, 168D);
			this.Over.FalseBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Over.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.Over.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Over.FalseText = "$key:SE.App2CommonProcess.TxtDisable";
			this.Over.FalseTextKey = "SE.App2CommonProcess.TxtDisable";
			this.Over.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.Over.Name = "Over";
			this.Over.SecurityLevel = 0;
			this.Over.TagName = "FbOverride";
			this.Over.TrueBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Over.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.Over.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Over.TrueText = "$key:SE.App2CommonProcess.TxtEnable";
			this.Over.TrueTextKey = "SE.App2CommonProcess.TxtEnable";
			this.Over.Value = false;
			this.Over.EndInit();
			// 
			// Maint
			// 
			this.Maint.BeginInit();
			this.Maint.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.475D, 0D, 0D, 0.83333333333333348D, 120D, 198D);
			this.Maint.FalseBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Maint.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.Maint.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Maint.FalseText = "$key:SE.App2CommonProcess.TxtDisable";
			this.Maint.FalseTextKey = "SE.App2CommonProcess.TxtDisable";
			this.Maint.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.Maint.Name = "Maint";
			this.Maint.SecurityLevel = 0;
			this.Maint.TagName = "Maintenance";
			this.Maint.TrueBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Maint.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.Maint.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Maint.TrueText = "$key:SE.App2CommonProcess.TxtEnable";
			this.Maint.TrueTextKey = "SE.App2CommonProcess.TxtEnable";
			this.Maint.Value = false;
			this.Maint.OutputValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.MaintValueChanged);
			this.Maint.EndInit();
			// 
			// txtMonitorTime
			// 
			this.txtMonitorTime.BeginInit();
			this.txtMonitorTime.DecimalPlacesCount = ((uint)(0u));
			this.txtMonitorTime.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.6333333333333333D, 0D, 0D, 0.56448D, 120D, 46D);
			this.txtMonitorTime.Font = new NxtControl.Drawing.Font("SE.App2Base.Sp");
			this.txtMonitorTime.MaximumTag = null;
			this.txtMonitorTime.Minimum = 1;
			this.txtMonitorTime.MinimumTag = null;
			this.txtMonitorTime.Name = "txtMonitorTime";
			this.txtMonitorTime.NumberBase = NxtControl.GuiFramework.NumberBase.Decimal;
			this.txtMonitorTime.Pen = new NxtControl.Drawing.Pen("TextBoxPen");
			this.txtMonitorTime.SecurityLevel = 12;
			this.txtMonitorTime.SetColor = new NxtControl.Drawing.Color("Yellow");
			this.txtMonitorTime.Suffix = "s";
			this.txtMonitorTime.TagName = "MonTime";
			this.txtMonitorTime.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.txtMonitorTime.UseInputPad = true;
			this.txtMonitorTime.UseRange = true;
			this.txtMonitorTime.Value = 0;
			this.txtMonitorTime.EndInit();
			// 
			// txtTripTime
			// 
			this.txtTripTime.BeginInit();
			this.txtTripTime.DecimalPlacesCount = ((uint)(0u));
			this.txtTripTime.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.6333333333333333D, 0D, 0D, 1D, 120D, 76D);
			this.txtTripTime.Font = new NxtControl.Drawing.Font("SE.App2Base.Sp");
			this.txtTripTime.MaximumTag = null;
			this.txtTripTime.Minimum = 1;
			this.txtTripTime.MinimumTag = null;
			this.txtTripTime.Name = "txtTripTime";
			this.txtTripTime.NumberBase = NxtControl.GuiFramework.NumberBase.Decimal;
			this.txtTripTime.Pen = new NxtControl.Drawing.Pen("TextBoxPen");
			this.txtTripTime.SecurityLevel = 12;
			this.txtTripTime.SetColor = new NxtControl.Drawing.Color("Yellow");
			this.txtTripTime.Suffix = "s";
			this.txtTripTime.TagName = "TripTime";
			this.txtTripTime.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.txtTripTime.UseInputPad = true;
			this.txtTripTime.UseRange = true;
			this.txtTripTime.Value = 0;
			this.txtTripTime.EndInit();
			// 
			// combofbmode
			// 
			this.combofbmode.BeginInit();
			this.combofbmode.Brush = new NxtControl.Drawing.Brush("ComboBoxBrush");
			this.combofbmode.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.79744988141382056D, 0D, 0D, 0.84392377406903374D, 120D, 16D);
			this.combofbmode.Font = new NxtControl.Drawing.Font("ComboBoxFont");
			this.combofbmode.Name = "combofbmode";
			this.combofbmode.SecurityLevel = 12;
			this.combofbmode.TagName = "FbMode";
			this.combofbmode.TextColor = new NxtControl.Drawing.Color("ComboBoxTextColor");
			this.combofbmode.TextPadding = new NxtControl.Drawing.Padding(2);
			this.combofbmode.Value = ((byte)(0));
			this.combofbmode.EndInit();
			// 
			// execute_11
			// 
			this.execute_11.BeginInit();
			this.execute_11.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.execute_11.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.execute_11.Name = "execute_11";
			this.execute_11.SecurityLevel = 0;
			this.execute_11.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.execute_11.TagName = "Simulation";
			this.execute_11.Value = false;
			this.execute_11.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.SimValueChanged);
			this.execute_11.EndInit();
			// 
			// execute_12
			// 
			this.execute_12.BeginInit();
			this.execute_12.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.execute_12.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.execute_12.Name = "execute_12";
			this.execute_12.SecurityLevel = 0;
			this.execute_12.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.execute_12.TagName = "FbOverride";
			this.execute_12.Value = false;
			this.execute_12.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.OverValueChanged);
			this.execute_12.EndInit();
			// 
			// labelS1
			// 
			this.labelS1.BeginInit();
			this.labelS1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 16D);
			this.labelS1.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS1.Name = "labelS1";
			this.labelS1.NameSpace = "SE.App2CommonProcess";
			this.labelS1.SeperatorVisiblity = true;
			this.labelS1.Text = "Feedback Mode";
			this.labelS1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS1.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS1.TextKey = "LabelFbMode";
			this.labelS1.EndInit();
			// 
			// labelS2
			// 
			this.labelS2.BeginInit();
			this.labelS2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 108D);
			this.labelS2.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS2.Name = "labelS2";
			this.labelS2.NameSpace = "SE.App2CommonProcess";
			this.labelS2.SeperatorVisiblity = true;
			this.labelS2.Text = "Feedback Reset";
			this.labelS2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS2.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS2.TextKey = "LabelFBReset";
			this.labelS2.EndInit();
			// 
			// labelS3
			// 
			this.labelS3.BeginInit();
			this.labelS3.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 76D);
			this.labelS3.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS3.Name = "labelS3";
			this.labelS3.NameSpace = "SE.App2CommonProcess";
			this.labelS3.SeperatorVisiblity = true;
			this.labelS3.Text = "Trip Time";
			this.labelS3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS3.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS3.TextKey = "LabelTripTime";
			this.labelS3.EndInit();
			// 
			// labelS5
			// 
			this.labelS5.BeginInit();
			this.labelS5.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 138D);
			this.labelS5.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS5.Name = "labelS5";
			this.labelS5.NameSpace = "SE.App2CommonProcess";
			this.labelS5.SeperatorVisiblity = true;
			this.labelS5.Text = "Simulation";
			this.labelS5.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS5.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS5.TextKey = "LabelSimulation";
			this.labelS5.EndInit();
			// 
			// labelS6
			// 
			this.labelS6.BeginInit();
			this.labelS6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 168D);
			this.labelS6.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS6.Name = "labelS6";
			this.labelS6.NameSpace = "SE.App2CommonProcess";
			this.labelS6.SeperatorVisiblity = true;
			this.labelS6.Text = "Override";
			this.labelS6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS6.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS6.TextKey = "LabelOverride";
			this.labelS6.EndInit();
			// 
			// labelS7
			// 
			this.labelS7.BeginInit();
			this.labelS7.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 198D);
			this.labelS7.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS7.Name = "labelS7";
			this.labelS7.NameSpace = "SE.App2CommonProcess";
			this.labelS7.SeperatorVisiblity = true;
			this.labelS7.Text = "Maintenance";
			this.labelS7.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS7.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS7.TextKey = "LabelMaintenance";
			this.labelS7.EndInit();
			// 
			// labelS9
			// 
			this.labelS9.BeginInit();
			this.labelS9.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 46D);
			this.labelS9.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS9.Name = "labelS9";
			this.labelS9.NameSpace = "SE.App2CommonProcess";
			this.labelS9.SeperatorVisiblity = true;
			this.labelS9.Text = "Monitoring Time";
			this.labelS9.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS9.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS9.TextKey = "LabelMonTime";
			this.labelS9.EndInit();
			// 
			// execute_13
			// 
			this.execute_13.BeginInit();
			this.execute_13.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.execute_13.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.execute_13.Name = "execute_13";
			this.execute_13.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.execute_13.TagName = "Maintenance";
			this.execute_13.Value = false;
			this.execute_13.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.MaintValueChanged);
			this.execute_13.EndInit();
			// 
			// Oos
			// 
			this.Oos.BeginInit();
			this.Oos.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.475D, 0D, 0D, 0.83333333333333348D, 120D, 228D);
			this.Oos.FalseBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Oos.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.Oos.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Oos.FalseText = "$key:SE.App2CommonProcess.TxtDisable";
			this.Oos.FalseTextKey = "SE.App2CommonProcess.TxtDisable";
			this.Oos.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.Oos.Name = "Oos";
			this.Oos.SecurityLevel = 0;
			this.Oos.TagName = "OutOfService";
			this.Oos.TrueBrush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.Oos.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.Oos.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.Oos.TrueText = "$key:SE.App2CommonProcess.TxtEnable";
			this.Oos.TrueTextKey = "SE.App2CommonProcess.TxtEnable";
			this.Oos.Value = false;
			this.Oos.OutputValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.OosOutputValueChanged);
			this.Oos.EndInit();
			// 
			// labelS4
			// 
			this.labelS4.BeginInit();
			this.labelS4.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 228D);
			this.labelS4.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS4.Name = "labelS4";
			this.labelS4.NameSpace = "SE.App2CommonProcess";
			this.labelS4.SeperatorVisiblity = true;
			this.labelS4.Text = "Out of Service";
			this.labelS4.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS4.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS4.TextKey = "LabelOOS";
			this.labelS4.EndInit();
			// 
			// FbStatus
			// 
			this.FbStatus.BeginInit();
			this.FbStatus.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.FbStatus.IsOnlyInput = true;
			this.FbStatus.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.FbStatus.Name = "FbStatus";
			this.FbStatus.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.FbStatus.TagName = "FbStatus";
			this.FbStatus.Value = ((short)(0));
			this.FbStatus.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.FbStatusValueChanged);
			this.FbStatus.EndInit();
			// 
			// TransFbStatus
			// 
			this.TransFbStatus.BeginInit();
			this.TransFbStatus.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.TransFbStatus.IsOnlyInput = true;
			this.TransFbStatus.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.TransFbStatus.Name = "TransFbStatus";
			this.TransFbStatus.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.TransFbStatus.TagName = "TransFbStatus";
			this.TransFbStatus.Value = ((short)(0));
			this.TransFbStatus.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.TransFbStatusValueChanged);
			this.TransFbStatus.EndInit();
			// 
			// fpParameter
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(268D)), ((float)(289D)));
			this.Brush = new NxtControl.Drawing.Brush("FpBackgroundBrush");
			this.FormBorderStyle = NxtControl.GuiFramework.FormBorderStyle.FixedSingle;
			this.SecurityToken = ((uint)(4294967175u));
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.ConfResetReq,
			this.Sim,
			this.Over,
			this.Maint,
			this.txtMonitorTime,
			this.txtTripTime,
			this.combofbmode,
			this.execute_11,
			this.execute_12,
			this.labelS1,
			this.labelS2,
			this.labelS3,
			this.labelS5,
			this.labelS6,
			this.labelS7,
			this.labelS9,
			this.execute_13,
			this.Oos,
			this.labelS4,
			this.FbStatus,
			this.TransFbStatus});
			this.Size = new System.Drawing.Size(268, 289);
			this.SecurityOwnerChanged += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnSecurityOwnerChanged(this.FpParameterSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnSecurityParameterChanged(this.FpParameterSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnSecurityModeChanged(this.FpParameterSecurityModeChanged);

		}
		private System.HMI.Symbols.Base.SwitchButton ConfResetReq;
		private System.HMI.Symbols.Base.SwitchButton Sim;
		private System.HMI.Symbols.Base.SwitchButton Over;
		private System.HMI.Symbols.Base.SwitchButton Maint;
		private System.HMI.Symbols.Base.TextBox<int> txtMonitorTime;
		private System.HMI.Symbols.Base.TextBox<int> txtTripTime;
		private System.HMI.Symbols.Base.DropDown<byte> combofbmode;
		private System.HMI.Symbols.Base.Execute<bool> execute_11;
		private System.HMI.Symbols.Base.Execute<bool> execute_12;
		private SE.App2Base.Graphics.LabelS labelS1;
		private SE.App2Base.Graphics.LabelS labelS2;
		private SE.App2Base.Graphics.LabelS labelS3;
		private SE.App2Base.Graphics.LabelS labelS5;
		private SE.App2Base.Graphics.LabelS labelS6;
		private SE.App2Base.Graphics.LabelS labelS7;
		private SE.App2Base.Graphics.LabelS labelS9;
		private System.HMI.Symbols.Base.Execute<bool> execute_13;
		private System.HMI.Symbols.Base.SwitchButton Oos;
		private SE.App2Base.Graphics.LabelS labelS4;
		private System.HMI.Symbols.Base.Execute<short> FbStatus;
		private System.HMI.Symbols.Base.Execute<short> TransFbStatus;
		#endregion
	}
}



