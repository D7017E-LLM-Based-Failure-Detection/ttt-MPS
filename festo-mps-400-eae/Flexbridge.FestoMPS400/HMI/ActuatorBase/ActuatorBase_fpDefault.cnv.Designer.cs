using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Faceplates.ActuatorBase
{
	/// <summary>
	/// Summary description for fpDefault.
	/// </summary>
	partial class fpDefault
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.line7 = new NxtControl.GuiFramework.Line();
			this.line1 = new NxtControl.GuiFramework.Line();
			this.lblIsPv = new NxtControl.GuiFramework.Label();
			this.lblReqPv = new NxtControl.GuiFramework.Label();
			this.btnManOff = new NxtControl.GuiFramework.DrawnButton();
			this.btnManOn = new NxtControl.GuiFramework.DrawnButton();
			this.btnReset = new NxtControl.GuiFramework.DrawnButton();
			this.lblAutoSp = new NxtControl.GuiFramework.Label();
			this.labelS1 = new SE.App2Base.Graphics.LabelS();
			this.labelS2 = new SE.App2Base.Graphics.LabelS();
			this.labelS3 = new SE.App2Base.Graphics.LabelS();
			this.fpNavigationPane = new SE.App2Base.Graphics.FpNavigationPane();
			this.NeedReset = new System.HMI.Symbols.Base.Execute<bool>();
			this.Fb = new System.HMI.Symbols.Base.Execute<short>();
			this.CurrentSp = new System.HMI.Symbols.Base.Execute<short>();
			this.TransFbStatus = new System.HMI.Symbols.Base.Execute<short>();
			this.Sim = new System.HMI.Symbols.Base.Execute<bool>();
			this.Maint = new System.HMI.Symbols.Base.Execute<bool>();
			this.Oos = new System.HMI.Symbols.Base.Execute<bool>();
			this.ExtOwnerConnected = new System.HMI.Symbols.Base.Execute<bool>();
			this.CurrentOwnerBasic = new System.HMI.Symbols.Base.Execute<ushort>();
			this.ownerStatus = new SE.App2Base.Graphics.OwnerStatusBasic();
			this.ownerSwitch = new SE.App2Base.Graphics.OwnerSwitchBasic();
			this.CurrentOp = new System.HMI.Symbols.Base.Execute<short>();
			this.StdOwnerConnected = new System.HMI.Symbols.Base.Execute<bool>();
			this.FbOverride = new System.HMI.Symbols.Base.Execute<bool>();
			// 
			// line7
			// 
			this.line7.EndPoint = new NxtControl.Drawing.PointF(268D, 150D);
			this.line7.Name = "line7";
			this.line7.Pen = new NxtControl.Drawing.Pen("FpLinePen");
			this.line7.StartPoint = new NxtControl.Drawing.PointF(8D, 150D);
			// 
			// line1
			// 
			this.line1.EndPoint = new NxtControl.Drawing.PointF(272D, 150D);
			this.line1.Name = "line1";
			this.line1.Pen = new NxtControl.Drawing.Pen("FpLinePen");
			this.line1.StartPoint = new NxtControl.Drawing.PointF(0D, 150D);
			// 
			// lblIsPv
			// 
			this.lblIsPv.AngleIgnore = true;
			this.lblIsPv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblIsPv.Bounds = new NxtControl.Drawing.RectF(((float)(120D)), ((float)(8D)), ((float)(120D)), ((float)(16D)));
			this.lblIsPv.Brush = new NxtControl.Drawing.Brush(true);
			this.lblIsPv.Font = new NxtControl.Drawing.Font("SE.App2Base.Pv");
			this.lblIsPv.Name = "lblIsPv";
			this.lblIsPv.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lblIsPv.Text = "$key:SE.App2CommonProcess.LabelUnknown";
			this.lblIsPv.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblIsPv.TextColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibFpData");
			// 
			// lblReqPv
			// 
			this.lblReqPv.AngleIgnore = true;
			this.lblReqPv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblReqPv.Bounds = new NxtControl.Drawing.RectF(((float)(120D)), ((float)(52D)), ((float)(116D)), ((float)(16D)));
			this.lblReqPv.Brush = new NxtControl.Drawing.Brush(true);
			this.lblReqPv.Font = new NxtControl.Drawing.Font("SE.App2Base.Pv");
			this.lblReqPv.Name = "lblReqPv";
			this.lblReqPv.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lblReqPv.Text = "$key:SE.App2CommonProcess.LabelUnknown";
			this.lblReqPv.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblReqPv.TextColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibFpOp");
			// 
			// btnManOff
			// 
			this.btnManOff.Bounds = new NxtControl.Drawing.RectF(((float)(15D)), ((float)(215D)), ((float)(114D)), ((float)(30D)));
			this.btnManOff.Brush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.btnManOff.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.btnManOff.InnerBorderColor = new NxtControl.Drawing.Color("ButtonInnerBorderColor");
			this.btnManOff.Name = "btnManOff";
			this.btnManOff.Pen = new NxtControl.Drawing.Pen("ButtonPen");
			this.btnManOff.Radius = 4D;
			this.btnManOff.Text = "$key:SE.App2CommonProcess.BtnManClose";
			this.btnManOff.TextColor = new NxtControl.Drawing.Color("ButtonTextColor");
			this.btnManOff.TextColorMouseDown = new NxtControl.Drawing.Color("ButtonTextColorMouseDown");
			this.btnManOff.Use3DEffect = false;
			this.btnManOff.Click += new System.EventHandler(this.BtnManOffClick);
			// 
			// btnManOn
			// 
			this.btnManOn.Bounds = new NxtControl.Drawing.RectF(((float)(141D)), ((float)(215D)), ((float)(114D)), ((float)(30D)));
			this.btnManOn.Brush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.btnManOn.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.btnManOn.InnerBorderColor = new NxtControl.Drawing.Color("ButtonInnerBorderColor");
			this.btnManOn.Name = "btnManOn";
			this.btnManOn.Pen = new NxtControl.Drawing.Pen("ButtonPen");
			this.btnManOn.Radius = 4D;
			this.btnManOn.Text = "$key:SE.App2CommonProcess.BtnManOpen";
			this.btnManOn.TextColor = new NxtControl.Drawing.Color("ButtonTextColor");
			this.btnManOn.TextColorMouseDown = new NxtControl.Drawing.Color("ButtonTextColorMouseDown");
			this.btnManOn.Use3DEffect = false;
			this.btnManOn.Click += new System.EventHandler(this.BtnManOnClick);
			// 
			// btnReset
			// 
			this.btnReset.Bounds = new NxtControl.Drawing.RectF(((float)(81D)), ((float)(271D)), ((float)(108D)), ((float)(30D)));
			this.btnReset.Brush = new NxtControl.Drawing.Brush("ButtonBrush");
			this.btnReset.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.btnReset.InnerBorderColor = new NxtControl.Drawing.Color("ButtonInnerBorderColor");
			this.btnReset.Name = "btnReset";
			this.btnReset.Pen = new NxtControl.Drawing.Pen("ButtonPen");
			this.btnReset.Radius = 4D;
			this.btnReset.Text = "$key:SE.App2CommonProcess.LabelRearm";
			this.btnReset.TextColor = new NxtControl.Drawing.Color("ButtonTextColor");
			this.btnReset.TextColorMouseDown = new NxtControl.Drawing.Color("ButtonTextColorMouseDown");
			this.btnReset.Use3DEffect = false;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// lblAutoSp
			// 
			this.lblAutoSp.AngleIgnore = true;
			this.lblAutoSp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblAutoSp.Bounds = new NxtControl.Drawing.RectF(((float)(120D)), ((float)(30D)), ((float)(119D)), ((float)(16D)));
			this.lblAutoSp.Brush = new NxtControl.Drawing.Brush(true);
			this.lblAutoSp.Font = new NxtControl.Drawing.Font("SE.App2Base.Pv");
			this.lblAutoSp.Name = "lblAutoSp";
			this.lblAutoSp.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lblAutoSp.Text = "$key:SE.App2CommonProcess.LabelUnknown";
			this.lblAutoSp.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblAutoSp.TextColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibFpSp");
			// 
			// labelS1
			// 
			this.labelS1.BeginInit();
			this.labelS1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 4D);
			this.labelS1.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS1.Name = "labelS1";
			this.labelS1.NameSpace = "SE.App2CommonProcess";
			this.labelS1.SeperatorVisiblity = true;
			this.labelS1.Text = "Status";
			this.labelS1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS1.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS1.TextKey = "LabelRunState";
			this.labelS1.EndInit();
			// 
			// labelS2
			// 
			this.labelS2.BeginInit();
			this.labelS2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 26D);
			this.labelS2.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS2.Name = "labelS2";
			this.labelS2.NameSpace = "SE.App2CommonProcess";
			this.labelS2.SeperatorVisiblity = true;
			this.labelS2.Text = "Current Setpoint";
			this.labelS2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS2.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS2.TextKey = "LabelCurrentSetpoint";
			this.labelS2.EndInit();
			// 
			// labelS3
			// 
			this.labelS3.BeginInit();
			this.labelS3.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 48D);
			this.labelS3.Font = new NxtControl.Drawing.Font("SE.App2Base.LabelFont");
			this.labelS3.Name = "labelS3";
			this.labelS3.NameSpace = "SE.App2CommonProcess";
			this.labelS3.SeperatorVisiblity = true;
			this.labelS3.Text = "Current Output";
			this.labelS3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.labelS3.TextColor = new NxtControl.Drawing.Color("FpLabelText");
			this.labelS3.TextKey = "LabelCurrentOutput";
			this.labelS3.EndInit();
			// 
			// fpNavigationPane
			// 
			this.fpNavigationPane.BeginInit();
			this.fpNavigationPane.Backwash.AliasName = "";
			this.fpNavigationPane.Backwash.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.Backwash.InstanceName = null;
			this.fpNavigationPane.Backwash.ParentTitle = "Title";
			this.fpNavigationPane.Backwash.SymbolType = "SE.AppWWW.Symbols.Backwash.sDefault";
			this.fpNavigationPane.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 214D, 0D);
			this.fpNavigationPane.Failure.AliasName = "";
			this.fpNavigationPane.Failure.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.Failure.InstanceName = null;
			this.fpNavigationPane.Failure.ParentTitle = "Title";
			this.fpNavigationPane.Failure.SymbolType = "SE.AppCommonProcess.Symbols.CondSum.sFailure";
			this.fpNavigationPane.Filtration.AliasName = "";
			this.fpNavigationPane.Filtration.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.Filtration.InstanceName = null;
			this.fpNavigationPane.Filtration.ParentTitle = "Title";
			this.fpNavigationPane.Filtration.SymbolType = "SE.AppWWW.Symbols.Filtration.sDefault";
			this.fpNavigationPane.GeneralPropertySubscription.AddRange(new string[] {
			"System.ShowTagNames"});
			this.fpNavigationPane.HideSlider = false;
			this.fpNavigationPane.InputParameters.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.Interlock.AliasName = "";
			this.fpNavigationPane.Interlock.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot2L;
			this.fpNavigationPane.Interlock.InstanceName = null;
			this.fpNavigationPane.Interlock.LabelActive1 = SE.App2Base.SupportClasses.CondActive1LabelText.Open;
			this.fpNavigationPane.Interlock.LabelPassive = SE.App2Base.SupportClasses.CondPassiveLabelText.Close;
			this.fpNavigationPane.Interlock.ParentTitle = "Title";
			this.fpNavigationPane.Interlock.SymbolType = "SE.AppCommonProcess.Symbols.IlckCondSum.sInterlock";
			this.fpNavigationPane.IsBasic = false;
			this.fpNavigationPane.LocalPanel.AliasName = "";
			this.fpNavigationPane.LocalPanel.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot4R;
			this.fpNavigationPane.LocalPanel.InstanceName = null;
			this.fpNavigationPane.LocalPanel.LabelActive1 = SE.App2Base.SupportClasses.CondActive1LabelText.Open;
			this.fpNavigationPane.LocalPanel.LabelPassive = SE.App2Base.SupportClasses.CondPassiveLabelText.Close;
			this.fpNavigationPane.LocalPanel.ParentTitle = "Title";
			this.fpNavigationPane.LocalPanel.SymbolType = "SE.AppCommonProcess.Symbols.DevLp.sDefault";
			this.fpNavigationPane.Maintenance.AliasName = "";
			this.fpNavigationPane.Maintenance.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot1L;
			this.fpNavigationPane.Maintenance.InstanceName = null;
			this.fpNavigationPane.Maintenance.ParentTitle = "Title";
			this.fpNavigationPane.Maintenance.SymbolType = "SE.AppCommonProcess.Symbols.DevMnt.sDefault";
			this.fpNavigationPane.Measures.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.Name = "fpNavigationPane";
			this.fpNavigationPane.OutputParameters.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.Owner.AliasName = "";
			this.fpNavigationPane.Owner.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot1R;
			this.fpNavigationPane.Owner.InstanceName = null;
			this.fpNavigationPane.Owner.ParentTitle = "Title";
			this.fpNavigationPane.Owner.SymbolType = "SE.App2Base.Symbols.Owner.sOwnerConfig";
			this.fpNavigationPane.Parameter.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot2R;
			this.fpNavigationPane.ParentTitle = "";
			this.fpNavigationPane.Permissive.AliasName = "";
			this.fpNavigationPane.Permissive.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot3L;
			this.fpNavigationPane.Permissive.InstanceName = null;
			this.fpNavigationPane.Permissive.LabelActive1 = SE.App2Base.SupportClasses.CondActive1LabelText.Open;
			this.fpNavigationPane.Permissive.LabelPassive = SE.App2Base.SupportClasses.CondPassiveLabelText.Close;
			this.fpNavigationPane.Permissive.ParentTitle = "Title";
			this.fpNavigationPane.Permissive.SymbolType = "SE.AppCommonProcess.Symbols.PermCondSum.sPermissive";
			this.fpNavigationPane.SecMode = 6;
			this.fpNavigationPane.SecOwner = 3;
			this.fpNavigationPane.SecParameter = 12;
			this.fpNavigationPane.SecSetpoint = 3;
			this.fpNavigationPane.ShortFlush.AliasName = "";
			this.fpNavigationPane.ShortFlush.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.NotAvailable;
			this.fpNavigationPane.ShortFlush.InstanceName = null;
			this.fpNavigationPane.ShortFlush.ParentTitle = "Title";
			this.fpNavigationPane.ShortFlush.SymbolType = "SE.AppWWW.Symbols.ShortFlush.sDefault";
			this.fpNavigationPane.Trend.Availablity = SE.App2Base.SupportClasses.FpIconSymbolAllocation.Slot3R;
			this.fpNavigationPane.OnParameterClick += new SE.App2Base.Graphics.FpNavigationPane.ParameterClicked(this.FpNavigationPaneOnParameterClick);
			this.fpNavigationPane.OnTrendClick += new SE.App2Base.Graphics.FpNavigationPane.TrendClicked(this.FpNavigationPaneOnTrendClick);
			this.fpNavigationPane.EndInit();
			// 
			// NeedReset
			// 
			this.NeedReset.BeginInit();
			this.NeedReset.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.NeedReset.IsOnlyInput = true;
			this.NeedReset.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.NeedReset.Name = "NeedReset";
			this.NeedReset.SecurityLevel = 0;
			this.NeedReset.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.NeedReset.TagName = "NeedReset";
			this.NeedReset.Value = false;
			this.NeedReset.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.NeedResetValueChanged);
			this.NeedReset.EndInit();
			// 
			// Fb
			// 
			this.Fb.BeginInit();
			this.Fb.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Fb.IsOnlyInput = true;
			this.Fb.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Fb.Name = "Fb";
			this.Fb.SecurityLevel = 0;
			this.Fb.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Fb.TagName = "FbStatus";
			this.Fb.Value = ((short)(0));
			this.Fb.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.PvValueChanged);
			this.Fb.EndInit();
			// 
			// CurrentSp
			// 
			this.CurrentSp.BeginInit();
			this.CurrentSp.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.CurrentSp.IsOnlyInput = true;
			this.CurrentSp.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.CurrentSp.Name = "CurrentSp";
			this.CurrentSp.SecurityLevel = 0;
			this.CurrentSp.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.CurrentSp.TagName = "CurrentSp";
			this.CurrentSp.Value = ((short)(0));
			this.CurrentSp.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.CurrentSpValueChanged);
			this.CurrentSp.EndInit();
			// 
			// TransFbStatus
			// 
			this.TransFbStatus.BeginInit();
			this.TransFbStatus.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.TransFbStatus.IsOnlyInput = true;
			this.TransFbStatus.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.TransFbStatus.Name = "TransFbStatus";
			this.TransFbStatus.SecurityLevel = 0;
			this.TransFbStatus.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.TransFbStatus.TagName = "TransFbStatus";
			this.TransFbStatus.Value = ((short)(0));
			this.TransFbStatus.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.TransFbStatusChanged);
			this.TransFbStatus.EndInit();
			// 
			// Sim
			// 
			this.Sim.BeginInit();
			this.Sim.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Sim.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Sim.Name = "Sim";
			this.Sim.SecurityLevel = 0;
			this.Sim.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Sim.TagName = "Simulation";
			this.Sim.Value = false;
			this.Sim.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.SimValueChanged);
			this.Sim.EndInit();
			// 
			// Maint
			// 
			this.Maint.BeginInit();
			this.Maint.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Maint.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Maint.Name = "Maint";
			this.Maint.SecurityLevel = 0;
			this.Maint.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Maint.TagName = "Maintenance";
			this.Maint.Value = false;
			this.Maint.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.MaintValueChanged);
			this.Maint.EndInit();
			// 
			// Oos
			// 
			this.Oos.BeginInit();
			this.Oos.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Oos.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Oos.Name = "Oos";
			this.Oos.SecurityLevel = 0;
			this.Oos.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Oos.TagName = "OutOfService";
			this.Oos.Value = false;
			this.Oos.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.OosValueChanged);
			this.Oos.EndInit();
			// 
			// ExtOwnerConnected
			// 
			this.ExtOwnerConnected.BeginInit();
			this.ExtOwnerConnected.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.ExtOwnerConnected.IsOnlyInput = true;
			this.ExtOwnerConnected.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.ExtOwnerConnected.Name = "ExtOwnerConnected";
			this.ExtOwnerConnected.SecurityLevel = 0;
			this.ExtOwnerConnected.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.ExtOwnerConnected.TagName = "";
			this.ExtOwnerConnected.Value = false;
			this.ExtOwnerConnected.EndInit();
			// 
			// CurrentOwnerBasic
			// 
			this.CurrentOwnerBasic.BeginInit();
			this.CurrentOwnerBasic.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.CurrentOwnerBasic.IsOnlyInput = true;
			this.CurrentOwnerBasic.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.CurrentOwnerBasic.Name = "CurrentOwnerBasic";
			this.CurrentOwnerBasic.SecurityLevel = 0;
			this.CurrentOwnerBasic.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.CurrentOwnerBasic.TagName = "CurrentOwner";
			this.CurrentOwnerBasic.Value = ((ushort)(0));
			this.CurrentOwnerBasic.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.CurrentOwnerBasicValueChanged);
			this.CurrentOwnerBasic.EndInit();
			// 
			// ownerStatus
			// 
			this.ownerStatus.BeginInit();
			this.ownerStatus.CurrentBasicOwner = false;
			this.ownerStatus.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 4D, 70D);
			this.ownerStatus.ExternalAvailable = false;
			this.ownerStatus.InstanceName = "";
			this.ownerStatus.Name = "ownerStatus";
			this.ownerStatus.EndInit();
			// 
			// ownerSwitch
			// 
			this.ownerSwitch.BeginInit();
			this.ownerSwitch.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 5D, 170D);
			this.ownerSwitch.ExternalAvailable = false;
			this.ownerSwitch.InstanceName = "";
			this.ownerSwitch.Name = "ownerSwitch";
			this.ownerSwitch.SecOwner = 0;
			this.ownerSwitch.SecurityToken = ((uint)(4294967295u));
			this.ownerSwitch.OnBasicOwnerChanged += new SE.App2Base.Graphics.OwnerSwitchBasic.BasicOwnerChanged(this.OwnerSwitchOnBasicOwnerChanged);
			this.ownerSwitch.EndInit();
			// 
			// CurrentOp
			// 
			this.CurrentOp.BeginInit();
			this.CurrentOp.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.CurrentOp.IsOnlyInput = true;
			this.CurrentOp.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.CurrentOp.Name = "CurrentOp";
			this.CurrentOp.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.CurrentOp.TagName = "CurrentOp";
			this.CurrentOp.Value = ((short)(0));
			this.CurrentOp.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.CurrentOpValueChanged);
			this.CurrentOp.EndInit();
			// 
			// StdOwnerConnected
			// 
			this.StdOwnerConnected.BeginInit();
			this.StdOwnerConnected.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.StdOwnerConnected.IsOnlyInput = true;
			this.StdOwnerConnected.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.StdOwnerConnected.Name = "StdOwnerConnected";
			this.StdOwnerConnected.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.StdOwnerConnected.TagName = "StdOwnerConnected";
			this.StdOwnerConnected.Value = false;
			this.StdOwnerConnected.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.StdOwnerConnectedValueChanged);
			this.StdOwnerConnected.EndInit();
			// 
			// FbOverride
			// 
			this.FbOverride.BeginInit();
			this.FbOverride.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.FbOverride.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.FbOverride.Name = "FbOverride";
			this.FbOverride.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.FbOverride.TagName = "FbOverride";
			this.FbOverride.Value = false;
			this.FbOverride.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.OverValueChanged);
			this.FbOverride.EndInit();
			// 
			// fpDefault
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(274D)), ((float)(350D)));
			this.Brush = new NxtControl.Drawing.Brush("FpBackgroundBrush");
			this.FormBorderStyle = NxtControl.GuiFramework.FormBorderStyle.FixedSingle;
			this.SecurityToken = ((uint)(4294967175u));
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.btnManOff,
			this.btnManOn,
			this.btnReset,
			this.lblIsPv,
			this.lblAutoSp,
			this.lblReqPv,
			this.labelS1,
			this.labelS2,
			this.labelS3,
			this.line7,
			this.line1,
			this.NeedReset,
			this.Fb,
			this.CurrentSp,
			this.TransFbStatus,
			this.Sim,
			this.Maint,
			this.Oos,
			this.ExtOwnerConnected,
			this.CurrentOwnerBasic,
			this.ownerStatus,
			this.ownerSwitch,
			this.CurrentOp,
			this.StdOwnerConnected,
			this.FbOverride,
			this.fpNavigationPane});
			this.Size = new System.Drawing.Size(274, 350);
			this.SecurityOwnerChanged += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnSecurityOwnerChanged(this.FpDefaultSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnSecurityParameterChanged(this.FpDefaultSecurityParameterChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnSecuritySetpointChanged(this.FpDefaultSecuritySetpointChanged);
			this.UpdateOptionalService += new SE.App2Base.Faceplates.SEAppLibHMIFaceplate.OnUpdateOptionalService(this.FpDefaultUpdateOptionalService);

		}
		private NxtControl.GuiFramework.Line line7;
		private NxtControl.GuiFramework.Line line1;
		private NxtControl.GuiFramework.Label lblIsPv;
		private NxtControl.GuiFramework.Label lblReqPv;
		private NxtControl.GuiFramework.DrawnButton btnManOff;
		private NxtControl.GuiFramework.DrawnButton btnManOn;
		private NxtControl.GuiFramework.DrawnButton btnReset;
		private System.HMI.Symbols.Base.Execute<bool> NeedReset;
		private System.HMI.Symbols.Base.Execute<System.Int16> CurrentOp;
		private System.HMI.Symbols.Base.Execute<short> CurrentSp;
		private NxtControl.GuiFramework.Label lblAutoSp;
		private SE.App2Base.Graphics.LabelS labelS1;
		private SE.App2Base.Graphics.LabelS labelS2;
		private SE.App2Base.Graphics.LabelS labelS3;
		private SE.App2Base.Graphics.FpNavigationPane fpNavigationPane;
		private System.HMI.Symbols.Base.Execute<bool> Sim;
		private System.HMI.Symbols.Base.Execute<bool> Maint;
		private System.HMI.Symbols.Base.Execute<short> Fb;
		private System.HMI.Symbols.Base.Execute<short> TransFbStatus;
		private System.HMI.Symbols.Base.Execute<bool> Oos;
		private System.HMI.Symbols.Base.Execute<bool> ExtOwnerConnected;
		private System.HMI.Symbols.Base.Execute<ushort> CurrentOwnerBasic;
		private SE.App2Base.Graphics.OwnerStatusBasic ownerStatus;
		private SE.App2Base.Graphics.OwnerSwitchBasic ownerSwitch;
		private System.HMI.Symbols.Base.Execute<bool> StdOwnerConnected;
		private System.HMI.Symbols.Base.Execute<bool> FbOverride;
		


		#endregion
	
}
}



