using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
	/// <summary>
	/// Summary description for sLflValve.
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
			this.alarmFrame1 = new NxtControl.GuiFramework.AlarmFrame();
			this.abnormal = new SE.App2Base.Graphics.Abnormal();
			this.FbStatus = new System.HMI.Symbols.Base.Execute<short>();
			this.TransFbStatus = new System.HMI.Symbols.Base.Execute<short>();
			this.Sim = new System.HMI.Symbols.Base.Execute<bool>();
			this.execute_11 = new System.HMI.Symbols.Base.Execute<bool>();
			this.Maint = new System.HMI.Symbols.Base.Execute<bool>();
			this.execute_12 = new System.HMI.Symbols.Base.Execute<bool>();
			this.Oos = new System.HMI.Symbols.Base.Execute<bool>();
			this.PermClose = new System.HMI.Symbols.Base.Execute<bool>();
			this.PermOpen = new System.HMI.Symbols.Base.Execute<bool>();
			this.IlckCond = new System.HMI.Symbols.Base.Execute<bool>();
			this.ExtOwnerConnected = new System.HMI.Symbols.Base.Execute<bool>();
			this.CurrentOp = new System.HMI.Symbols.Base.Execute<short>();
			this.interlock = new SE.App2CommonProcess.Graphics.InterlockSmallBasic();
			this.permissive = new SE.App2CommonProcess.Graphics.PermissiveSmallBasic();
			this.owner = new SE.App2Base.Graphics.OwnerBasic();
			this.EquipState = new SE.App2Base.Graphics.State();
			this.StdOwnerConnected = new System.HMI.Symbols.Base.Execute<bool>();
			this.CurrentOwner = new System.HMI.Symbols.Base.Execute<ushort>();
			this.InstanceName = new NxtControl.GuiFramework.AliasDisplayLabel();
			this.valveBody1 = new SE.App2Base.Graphics.LFLValveBody();
			this.valveBody2 = new SE.App2Base.Graphics.LFLValveBody();
			this.valveBody3 = new SE.App2Base.Graphics.LFLValveBody();
			this.sValve = new NxtControl.GuiFramework.Group();
			this.FbFail = new System.HMI.Symbols.Base.Execute<NxtControl.GuiFramework.VTQ<bool>>();
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).BeginInit();
			// 
			// alarmFrame1
			// 
			this.alarmFrame1.Bounds = new NxtControl.Drawing.RectF(((float)(42D)), ((float)(22D)), ((float)(83D)), ((float)(143D)));
			this.alarmFrame1.FrameWidth = ((uint)(2u));
			this.alarmFrame1.Name = "alarmFrame1";
			this.alarmFrame1.Radius = 5D;
			// 
			// abnormal
			// 
			this.abnormal.BeginInit();
			this.abnormal.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 85D, 44D);
			this.abnormal.Name = "abnormal";
			this.abnormal.EndInit();
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
			this.FbStatus.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.PvValueChanged);
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
			this.TransFbStatus.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.TransFbValueChanged);
			this.TransFbStatus.EndInit();
			// 
			// Sim
			// 
			this.Sim.BeginInit();
			this.Sim.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Sim.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Sim.Name = "Sim";
			this.Sim.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Sim.TagName = "Simulation";
			this.Sim.Value = false;
			this.Sim.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.SimulationValueChanged);
			this.Sim.EndInit();
			// 
			// execute_11
			// 
			this.execute_11.BeginInit();
			this.execute_11.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.execute_11.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.execute_11.Name = "execute_11";
			this.execute_11.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.execute_11.TagName = "FbOverride";
			this.execute_11.Value = false;
			this.execute_11.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.OverrideValueChanged);
			this.execute_11.EndInit();
			// 
			// Maint
			// 
			this.Maint.BeginInit();
			this.Maint.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Maint.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Maint.Name = "Maint";
			this.Maint.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Maint.TagName = "Maintenance";
			this.Maint.Value = false;
			this.Maint.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.MaintenanceValueChanged);
			this.Maint.EndInit();
			// 
			// execute_12
			// 
			this.execute_12.BeginInit();
			this.execute_12.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.execute_12.IsOnlyInput = true;
			this.execute_12.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.execute_12.Name = "execute_12";
			this.execute_12.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.execute_12.TagName = "NeedReset";
			this.execute_12.Value = false;
			this.execute_12.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.NeedResetValueChanged);
			this.execute_12.EndInit();
			// 
			// Oos
			// 
			this.Oos.BeginInit();
			this.Oos.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.Oos.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.Oos.Name = "Oos";
			this.Oos.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.Oos.TagName = "OutOfService";
			this.Oos.Value = false;
			this.Oos.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.OutOfServiceValueChanged);
			this.Oos.EndInit();
			// 
			// PermClose
			// 
			this.PermClose.BeginInit();
			this.PermClose.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.PermClose.IsOnlyInput = true;
			this.PermClose.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.PermClose.Name = "PermClose";
			this.PermClose.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.PermClose.TagName = "PermClose";
			this.PermClose.Value = false;
			this.PermClose.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.PermCloseValueChanged);
			this.PermClose.EndInit();
			// 
			// PermOpen
			// 
			this.PermOpen.BeginInit();
			this.PermOpen.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.PermOpen.IsOnlyInput = true;
			this.PermOpen.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.PermOpen.Name = "PermOpen";
			this.PermOpen.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.PermOpen.TagName = "PermOpen";
			this.PermOpen.Value = false;
			this.PermOpen.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.PermOpenValueChanged);
			this.PermOpen.EndInit();
			// 
			// IlckCond
			// 
			this.IlckCond.BeginInit();
			this.IlckCond.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.IlckCond.IsOnlyInput = true;
			this.IlckCond.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.IlckCond.Name = "IlckCond";
			this.IlckCond.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.IlckCond.TagName = "IlckCond";
			this.IlckCond.Value = false;
			this.IlckCond.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.IlckCondValueChanged);
			this.IlckCond.EndInit();
			// 
			// ExtOwnerConnected
			// 
			this.ExtOwnerConnected.BeginInit();
			this.ExtOwnerConnected.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.ExtOwnerConnected.IsOnlyInput = true;
			this.ExtOwnerConnected.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.ExtOwnerConnected.Name = "ExtOwnerConnected";
			this.ExtOwnerConnected.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.ExtOwnerConnected.TagName = "StdOwnerConnected";
			this.ExtOwnerConnected.Value = false;
			this.ExtOwnerConnected.EndInit();
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
			// interlock
			// 
			this.interlock.BeginInit();
			this.interlock.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 61D, 124D);
			this.interlock.InstanceName = "";
			this.interlock.InterlockSignal = false;
			this.interlock.Name = "interlock";
			this.interlock.OnAbnormalDetected += new SE.App2CommonProcess.Graphics.InterlockSmallBasic.AbnormalDetected(this.InterlockOnAbnormalDetected);
			this.interlock.OnAvailablityChanged += new SE.App2CommonProcess.Graphics.InterlockSmallBasic.AvailablityChanged(this.InterlockOnAvailablityChanged);
			this.interlock.EndInit();
			// 
			// permissive
			// 
			this.permissive.BeginInit();
			this.permissive.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 82D, 124D);
			this.permissive.InstanceName = "";
			this.permissive.Name = "permissive";
			this.permissive.PermissiveActive1Signal = false;
			this.permissive.PermissiveActive2Signal = false;
			this.permissive.PermissivePassiveSignal = false;
			this.permissive.OnAbnormalDetected += new SE.App2CommonProcess.Graphics.PermissiveSmallBasic.AbnormalDetected(this.PermissiveOnAbnormalDetected);
			this.permissive.OnAvailablityChanged += new SE.App2CommonProcess.Graphics.PermissiveSmallBasic.AvailablityChanged(this.PermissiveOnAvailablityChanged);
			this.permissive.EndInit();
			// 
			// owner
			// 
			this.owner.BeginInit();
			this.owner.BasicOwner = ((ushort)(0));
			this.owner.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 83D, 26D);
			this.owner.ExternalAvailable = false;
			this.owner.InstanceName = "";
			this.owner.Name = "owner";
			this.owner.OnAbnormalDetected += new SE.App2Base.Graphics.OwnerBasic.AbnormalDetected(this.OwnerOnAbnormalDetected);
			this.owner.OnAvailablityChanged += new SE.App2Base.Graphics.OwnerBasic.AvailablityChanged(this.OwnerOnAvailablityChanged);
			this.owner.EndInit();
			// 
			// EquipState
			// 
			this.EquipState.BeginInit();
			this.EquipState.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 68D, 27D);
			this.EquipState.ExternalControlled = false;
			this.EquipState.Name = "EquipState";
			this.EquipState.EndInit();
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
			// CurrentOwner
			// 
			this.CurrentOwner.BeginInit();
			this.CurrentOwner.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.CurrentOwner.IsOnlyInput = true;
			this.CurrentOwner.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.CurrentOwner.Name = "CurrentOwner";
			this.CurrentOwner.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.CurrentOwner.TagName = "CurrentOwner";
			this.CurrentOwner.Value = ((ushort)(0));
			this.CurrentOwner.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.CurrentOwnerValueChanged);
			this.CurrentOwner.EndInit();
			// 
			// InstanceName
			// 
			this.InstanceName.AngleIgnore = true;
			this.InstanceName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.InstanceName.Bounds = new NxtControl.Drawing.RectF(((float)(40D)), ((float)(-2D)), ((float)(58D)), ((float)(20D)));
			this.InstanceName.Brush = new NxtControl.Drawing.Brush();
			this.InstanceName.CustomInstanceName = null;
			this.InstanceName.Font = new NxtControl.Drawing.Font("SE.App2Base.SymInstanceLabel");
			this.InstanceName.FontScale = true;
			this.InstanceName.Name = "InstanceName";
			this.InstanceName.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.InstanceName.Text = "Label";
			this.InstanceName.TextColor = new NxtControl.Drawing.Color("SE.App2Base.SymInstanceLabelTextColor");
			// 
			// valveBody1
			// 
			this.valveBody1.BeginInit();
			this.valveBody1.CurrView = SE.App2Base.SupportClasses.CurrentView.Open;
			this.valveBody1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 67D, 47D);
			this.valveBody1.Name = "valveBody1";
			this.valveBody1.ViewHorz1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody1.ViewHorz2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody1.ViewVert1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody1.ViewVert2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody1.EndInit();
			// 
			// valveBody2
			// 
			this.valveBody2.BeginInit();
			this.valveBody2.CurrView = SE.App2Base.SupportClasses.CurrentView.Open;
			this.valveBody2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 67D, 71D);
			this.valveBody2.Name = "valveBody2";
			this.valveBody2.ViewHorz1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody2.ViewHorz2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody2.ViewVert1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody2.ViewVert2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody2.EndInit();
			// 
			// valveBody3
			// 
			this.valveBody3.BeginInit();
			this.valveBody3.CurrView = SE.App2Base.SupportClasses.CurrentView.Open;
			this.valveBody3.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 67D, 95D);
			this.valveBody3.Name = "valveBody3";
			this.valveBody3.ViewHorz1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody3.ViewHorz2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody3.ViewVert1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody3.ViewVert2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.valveBody3.EndInit();
			// 
			// sValve
			// 
			this.sValve.BeginInit();
			this.sValve.Name = "sValve";
			this.sValve.OpenFaceplates.Add(new NxtControl.GuiFramework.OpenFaceplate("fpDefault", NxtControl.GuiFramework.MouseButtonType.Click));
			this.sValve.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.valveBody1,
			this.valveBody2,
			this.valveBody3});
			this.sValve.EndInit();
			// 
			// FbFail
			// 
			this.FbFail.BeginInit();
			this.FbFail.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 209D, 186D);
			this.FbFail.IsOnlyInput = true;
			this.FbFail.Location = new NxtControl.Drawing.PointF(209D, 186D);
			this.FbFail.Name = "FbFail";
			this.FbFail.Size = new NxtControl.Drawing.SizeF(100D, 20D);
			this.FbFail.TagName = "FbFail";
			this.FbFail.Value = new NxtControl.GuiFramework.VTQ<bool>(false, new System.DateTime(((long)(0))), ((uint)(0u)));
			this.FbFail.EndInit();
			// 
			// sLflVert
			// 
			this.OpenFaceplates.Add(new NxtControl.GuiFramework.OpenFaceplate("fpDefault", NxtControl.GuiFramework.MouseButtonType.Click));
			this.SecurityToken = ((uint)(4294967175u));
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmFrame1,
			this.FbStatus,
			this.TransFbStatus,
			this.Sim,
			this.execute_11,
			this.Maint,
			this.execute_12,
			this.Oos,
			this.PermClose,
			this.PermOpen,
			this.IlckCond,
			this.ExtOwnerConnected,
			this.CurrentOp,
			this.interlock,
			this.permissive,
			this.owner,
			this.EquipState,
			this.StdOwnerConnected,
			this.CurrentOwner,
			this.InstanceName,
			this.sValve,
			this.abnormal,
			this.FbFail});
			this.SymbolSize = new System.Drawing.Size(352, 296);
			this.UpdateOptionalService += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnUpdateOptionalService(this.SDefaultUpdateOptionalService);
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).EndInit();

		}
		//private NxtControl.GuiFramework.Group HorzModeState;
		private NxtControl.GuiFramework.AlarmFrame alarmFrame1;
		private NxtControl.GuiFramework.AliasDisplayLabel InstanceName;
		private SE.App2Base.Graphics.Abnormal abnormal;
		private System.HMI.Symbols.Base.Execute<bool> Sim;
		private System.HMI.Symbols.Base.Execute<bool> execute_11;
		private System.HMI.Symbols.Base.Execute<bool> Maint;
		private System.HMI.Symbols.Base.Execute<bool> execute_12;
		private System.HMI.Symbols.Base.Execute<short> FbStatus;
		private System.HMI.Symbols.Base.Execute<short> TransFbStatus;
		private System.HMI.Symbols.Base.Execute<bool> Oos;
		private System.HMI.Symbols.Base.Execute<bool> PermClose;
		private System.HMI.Symbols.Base.Execute<bool> PermOpen;
		private System.HMI.Symbols.Base.Execute<bool> IlckCond;
		private System.HMI.Symbols.Base.Execute<bool> ExtOwnerConnected;
		private System.HMI.Symbols.Base.Execute<System.Int16> CurrentOp;
		private SE.App2CommonProcess.Graphics.InterlockSmallBasic interlock;
		private SE.App2CommonProcess.Graphics.PermissiveSmallBasic permissive;
		private SE.App2Base.Graphics.OwnerBasic owner;
		private SE.App2Base.Graphics.State EquipState;
		private System.HMI.Symbols.Base.Execute<bool> StdOwnerConnected;
		private System.HMI.Symbols.Base.Execute<ushort> CurrentOwner;
		private SE.App2Base.Graphics.LFLValveBody valveBody1;
		private SE.App2Base.Graphics.LFLValveBody valveBody2;
		private SE.App2Base.Graphics.LFLValveBody valveBody3;
		private NxtControl.GuiFramework.Group sValve;
		private System.HMI.Symbols.Base.Execute<NxtControl.GuiFramework.VTQ<bool>> FbFail;
		#endregion
	}
}



