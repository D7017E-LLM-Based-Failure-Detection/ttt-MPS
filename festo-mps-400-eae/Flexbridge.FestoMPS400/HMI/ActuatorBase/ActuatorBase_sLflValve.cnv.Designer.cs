using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
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
			this.line22 = new NxtControl.GuiFramework.Line();
			this.line23 = new NxtControl.GuiFramework.Line();
			this.line24 = new NxtControl.GuiFramework.Line();
			this.line25 = new NxtControl.GuiFramework.Line();
			this.line26 = new NxtControl.GuiFramework.Line();
			this.line27 = new NxtControl.GuiFramework.Line();
			this.line28 = new NxtControl.GuiFramework.Line();
			this.line29 = new NxtControl.GuiFramework.Line();
			this.line30 = new NxtControl.GuiFramework.Line();
			this.line31 = new NxtControl.GuiFramework.Line();
			this.line21 = new NxtControl.GuiFramework.Line();
			this.line19 = new NxtControl.GuiFramework.Line();
			this.rectangle1 = new NxtControl.GuiFramework.Rectangle();
			this.line1 = new NxtControl.GuiFramework.Line();
			this.line2 = new NxtControl.GuiFramework.Line();
			this.line3 = new NxtControl.GuiFramework.Line();
			this.line4 = new NxtControl.GuiFramework.Line();
			this.line5 = new NxtControl.GuiFramework.Line();
			this.line6 = new NxtControl.GuiFramework.Line();
			this.line7 = new NxtControl.GuiFramework.Line();
			this.line8 = new NxtControl.GuiFramework.Line();
			this.line20 = new NxtControl.GuiFramework.Line();
			this.rectangle2 = new NxtControl.GuiFramework.Rectangle();
			this.line9 = new NxtControl.GuiFramework.Line();
			this.line11 = new NxtControl.GuiFramework.Line();
			this.rectangle3 = new NxtControl.GuiFramework.Rectangle();
			this.line18 = new NxtControl.GuiFramework.Line();
			this.line17 = new NxtControl.GuiFramework.Line();
			this.line10 = new NxtControl.GuiFramework.Line();
			this.line15 = new NxtControl.GuiFramework.Line();
			this.line16 = new NxtControl.GuiFramework.Line();
			this.line13 = new NxtControl.GuiFramework.Line();
			this.line12 = new NxtControl.GuiFramework.Line();
			this.line14 = new NxtControl.GuiFramework.Line();
			this.group1 = new NxtControl.GuiFramework.Group();
			this.group2 = new NxtControl.GuiFramework.Group();
			this.group3 = new NxtControl.GuiFramework.Group();
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
			this.FbFail = new System.HMI.Symbols.Base.Execute<NxtControl.GuiFramework.VTQ<bool>>();
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).BeginInit();
			// 
			// line22
			// 
			this.line22.EndPoint = new NxtControl.Drawing.PointF(97D, 86D);
			this.line22.Name = "line22";
			this.line22.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line22.StartPoint = new NxtControl.Drawing.PointF(97D, 56D);
			// 
			// line23
			// 
			this.line23.EndPoint = new NxtControl.Drawing.PointF(114D, 106.99999999999999D);
			this.line23.Name = "line23";
			this.line23.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line23.StartPoint = new NxtControl.Drawing.PointF(97D, 106.99999999999999D);
			// 
			// line24
			// 
			this.line24.EndPoint = new NxtControl.Drawing.PointF(97D, 108D);
			this.line24.Name = "line24";
			this.line24.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line24.StartPoint = new NxtControl.Drawing.PointF(97D, 85D);
			// 
			// line25
			// 
			this.line25.EndPoint = new NxtControl.Drawing.PointF(98D, 106.99999999999999D);
			this.line25.Name = "line25";
			this.line25.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line25.StartPoint = new NxtControl.Drawing.PointF(82D, 106.99999999999999D);
			// 
			// line26
			// 
			this.line26.EndPoint = new NxtControl.Drawing.PointF(97D, 119D);
			this.line26.Name = "line26";
			this.line26.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line26.StartPoint = new NxtControl.Drawing.PointF(97D, 105D);
			// 
			// line27
			// 
			this.line27.EndPoint = new NxtControl.Drawing.PointF(114D, 77.666666666666657D);
			this.line27.Name = "line27";
			this.line27.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line27.StartPoint = new NxtControl.Drawing.PointF(82D, 77.666666666666657D);
			// 
			// line28
			// 
			this.line28.EndPoint = new NxtControl.Drawing.PointF(114D, 65D);
			this.line28.Name = "line28";
			this.line28.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line28.StartPoint = new NxtControl.Drawing.PointF(82D, 65D);
			// 
			// line29
			// 
			this.line29.EndPoint = new NxtControl.Drawing.PointF(114D, 97D);
			this.line29.Name = "line29";
			this.line29.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line29.StartPoint = new NxtControl.Drawing.PointF(82D, 97D);
			// 
			// line30
			// 
			this.line30.EndPoint = new NxtControl.Drawing.PointF(114D, 85D);
			this.line30.Name = "line30";
			this.line30.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line30.StartPoint = new NxtControl.Drawing.PointF(96D, 85D);
			// 
			// line31
			// 
			this.line31.EndPoint = new NxtControl.Drawing.PointF(98D, 85D);
			this.line31.Name = "line31";
			this.line31.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line31.StartPoint = new NxtControl.Drawing.PointF(82D, 85D);
			// 
			// line21
			// 
			this.line21.EndPoint = new NxtControl.Drawing.PointF(98D, 55D);
			this.line21.Name = "line21";
			this.line21.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line21.StartPoint = new NxtControl.Drawing.PointF(82D, 55D);
			// 
			// line19
			// 
			this.line19.EndPoint = new NxtControl.Drawing.PointF(114D, 55D);
			this.line19.Name = "line19";
			this.line19.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line19.StartPoint = new NxtControl.Drawing.PointF(98D, 55D);
			// 
			// rectangle1
			// 
			this.rectangle1.Bounds = new NxtControl.Drawing.RectF(((float)(82D)), ((float)(67D)), ((float)(58D)), ((float)(32D)));
			this.rectangle1.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive"));
			this.rectangle1.Font = new NxtControl.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
			this.rectangle1.Name = "rectangle1";
			this.rectangle1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// line1
			// 
			this.line1.EndPoint = new NxtControl.Drawing.PointF(94D, 67D);
			this.line1.Name = "line1";
			this.line1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line1.StartPoint = new NxtControl.Drawing.PointF(94D, 85D);
			// 
			// line2
			// 
			this.line2.EndPoint = new NxtControl.Drawing.PointF(94D, 84D);
			this.line2.Name = "line2";
			this.line2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line2.StartPoint = new NxtControl.Drawing.PointF(82D, 84D);
			// 
			// line3
			// 
			this.line3.EndPoint = new NxtControl.Drawing.PointF(94D, 83D);
			this.line3.Name = "line3";
			this.line3.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line3.StartPoint = new NxtControl.Drawing.PointF(94D, 99D);
			// 
			// line4
			// 
			this.line4.EndPoint = new NxtControl.Drawing.PointF(110D, 84D);
			this.line4.Name = "line4";
			this.line4.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line4.StartPoint = new NxtControl.Drawing.PointF(95D, 84D);
			// 
			// line5
			// 
			this.line5.EndPoint = new NxtControl.Drawing.PointF(125D, 67D);
			this.line5.Name = "line5";
			this.line5.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line5.StartPoint = new NxtControl.Drawing.PointF(125D, 85D);
			// 
			// line6
			// 
			this.line6.EndPoint = new NxtControl.Drawing.PointF(125D, 84D);
			this.line6.Name = "line6";
			this.line6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line6.StartPoint = new NxtControl.Drawing.PointF(110D, 84D);
			// 
			// line7
			// 
			this.line7.EndPoint = new NxtControl.Drawing.PointF(125D, 83D);
			this.line7.Name = "line7";
			this.line7.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line7.StartPoint = new NxtControl.Drawing.PointF(125D, 99D);
			// 
			// line8
			// 
			this.line8.EndPoint = new NxtControl.Drawing.PointF(139D, 84D);
			this.line8.Name = "line8";
			this.line8.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line8.StartPoint = new NxtControl.Drawing.PointF(125D, 84D);
			// 
			// line20
			// 
			this.line20.EndPoint = new NxtControl.Drawing.PointF(97D, 55D);
			this.line20.Name = "line20";
			this.line20.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line20.StartPoint = new NxtControl.Drawing.PointF(97D, 45D);
			// 
			// rectangle2
			// 
			this.rectangle2.Bounds = new NxtControl.Drawing.RectF(((float)(82D)), ((float)(47D)), ((float)(32D)), ((float)(58D)));
			this.rectangle2.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive"));
			this.rectangle2.Font = new NxtControl.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
			this.rectangle2.Name = "rectangle2";
			this.rectangle2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// line9
			// 
			this.line9.EndPoint = new NxtControl.Drawing.PointF(110D, 67D);
			this.line9.Name = "line9";
			this.line9.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line9.StartPoint = new NxtControl.Drawing.PointF(110D, 99D);
			// 
			// line11
			// 
			this.line11.EndPoint = new NxtControl.Drawing.PointF(97D, 59D);
			this.line11.Name = "line11";
			this.line11.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line11.StartPoint = new NxtControl.Drawing.PointF(97D, 47D);
			// 
			// rectangle3
			// 
			this.rectangle3.Bounds = new NxtControl.Drawing.RectF(((float)(82D)), ((float)(45D)), ((float)(32D)), ((float)(74D)));
			this.rectangle3.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive"));
			this.rectangle3.Font = new NxtControl.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
			this.rectangle3.Name = "rectangle3";
			this.rectangle3.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// line18
			// 
			this.line18.EndPoint = new NxtControl.Drawing.PointF(114D, 74D);
			this.line18.Name = "line18";
			this.line18.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line18.StartPoint = new NxtControl.Drawing.PointF(82D, 74D);
			// 
			// line17
			// 
			this.line17.EndPoint = new NxtControl.Drawing.PointF(97D, 105D);
			this.line17.Name = "line17";
			this.line17.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line17.StartPoint = new NxtControl.Drawing.PointF(97D, 90D);
			// 
			// line10
			// 
			this.line10.EndPoint = new NxtControl.Drawing.PointF(114D, 59D);
			this.line10.Name = "line10";
			this.line10.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line10.StartPoint = new NxtControl.Drawing.PointF(96D, 59D);
			// 
			// line15
			// 
			this.line15.EndPoint = new NxtControl.Drawing.PointF(97D, 90D);
			this.line15.Name = "line15";
			this.line15.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line15.StartPoint = new NxtControl.Drawing.PointF(97D, 70D);
			// 
			// line16
			// 
			this.line16.EndPoint = new NxtControl.Drawing.PointF(98D, 90D);
			this.line16.Name = "line16";
			this.line16.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line16.StartPoint = new NxtControl.Drawing.PointF(82D, 90D);
			// 
			// line13
			// 
			this.line13.EndPoint = new NxtControl.Drawing.PointF(97D, 70D);
			this.line13.Name = "line13";
			this.line13.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line13.StartPoint = new NxtControl.Drawing.PointF(97D, 58D);
			// 
			// line12
			// 
			this.line12.EndPoint = new NxtControl.Drawing.PointF(98D, 59D);
			this.line12.Name = "line12";
			this.line12.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line12.StartPoint = new NxtControl.Drawing.PointF(82D, 59D);
			// 
			// line14
			// 
			this.line14.EndPoint = new NxtControl.Drawing.PointF(114D, 90D);
			this.line14.Name = "line14";
			this.line14.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("SymStaticIconColor"), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.line14.StartPoint = new NxtControl.Drawing.PointF(96D, 90D);
			// 
			// group1
			// 
			this.group1.BeginInit();
			this.group1.Name = "group1";
			this.group1.OpenFaceplates.Add(new NxtControl.GuiFramework.OpenFaceplate("fpDefault", NxtControl.GuiFramework.MouseButtonType.Click));
			this.group1.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.rectangle1,
			this.line1,
			this.line2,
			this.line3,
			this.line4,
			this.line5,
			this.line6,
			this.line7,
			this.line8,
			this.line9});
			this.group1.EndInit();
			// 
			// group2
			// 
			this.group2.BeginInit();
			this.group2.Name = "group2";
			this.group2.OpenFaceplates.Add(new NxtControl.GuiFramework.OpenFaceplate("fpDefault", NxtControl.GuiFramework.MouseButtonType.Click));
			this.group2.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.rectangle2,
			this.line10,
			this.line11,
			this.line12,
			this.line13,
			this.line14,
			this.line15,
			this.line16,
			this.line17,
			this.line18});
			this.group2.EndInit();
			// 
			// group3
			// 
			this.group3.BeginInit();
			this.group3.Name = "group3";
			this.group3.OpenFaceplates.Add(new NxtControl.GuiFramework.OpenFaceplate("fpDefault", NxtControl.GuiFramework.MouseButtonType.Click));
			this.group3.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.rectangle3,
			this.line19,
			this.line20,
			this.line21,
			this.line22,
			this.line23,
			this.line24,
			this.line25,
			this.line26,
			this.line27,
			this.line28,
			this.line29,
			this.line30,
			this.line31});
			this.group3.EndInit();
			// 
			// alarmFrame1
			// 
			this.alarmFrame1.Bounds = new NxtControl.Drawing.RectF(((float)(42D)), ((float)(23D)), ((float)(83D)), ((float)(55D)));
			this.alarmFrame1.FrameWidth = ((uint)(2u));
			this.alarmFrame1.Name = "alarmFrame1";
			this.alarmFrame1.Radius = 5D;
			// 
			// abnormal
			// 
			this.abnormal.BeginInit();
			this.abnormal.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 108D, 42D);
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
			this.interlock.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 45D, 26D);
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
			this.permissive.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 65D, 26D);
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
			this.owner.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 104D, 25D);
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
			this.EquipState.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 89D, 26D);
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
			this.InstanceName.Bounds = new NxtControl.Drawing.RectF(((float)(40D)), ((float)(0D)), ((float)(58D)), ((float)(20D)));
			this.InstanceName.Brush = new NxtControl.Drawing.Brush();
			this.InstanceName.CustomInstanceName = null;
			this.InstanceName.Font = new NxtControl.Drawing.Font("SE.App2Base.SymInstanceLabel");
			this.InstanceName.FontScale = true;
			this.InstanceName.Name = "InstanceName";
			this.InstanceName.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.InstanceName.Text = "Label";
			this.InstanceName.TextColor = new NxtControl.Drawing.Color("SE.App2Base.SymInstanceLabelTextColor");
			// 
			// FbFail
			// 
			this.FbFail.BeginInit();
			this.FbFail.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, double.NaN, double.NaN);
			this.FbFail.IsOnlyInput = true;
			this.FbFail.Location = new NxtControl.Drawing.PointF(double.NaN, double.NaN);
			this.FbFail.Name = "FbFail";
			this.FbFail.Size = new NxtControl.Drawing.SizeF(double.NegativeInfinity, double.NegativeInfinity);
			this.FbFail.TagName = "FbFail";
			this.FbFail.Value = new NxtControl.GuiFramework.VTQ<bool>(false, new System.DateTime(((long)(0))), ((uint)(0u)));
			this.FbFail.ValueChanged += new System.EventHandler<NxtControl.GuiFramework.ValueChangedEventArgs>(this.FbFailValueChanged);
			this.FbFail.EndInit();
			// 
			// sLflValve
			// 
			this.OpenFaceplates.Add(new NxtControl.GuiFramework.OpenFaceplate("fpDefault", NxtControl.GuiFramework.MouseButtonType.Click));
			this.SecurityToken = ((uint)(4294967175u));
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmFrame1,
			this.group1,
			this.group2,
			this.group3,
			this.abnormal,
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
			this.FbFail});
			this.SymbolSize = new System.Drawing.Size(352, 296);
			this.UpdateOptionalService += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnUpdateOptionalService(this.SDefaultUpdateOptionalService);
			((System.ComponentModel.ISupportInitialize)(this.alarmFrame1)).EndInit();

		}
		private NxtControl.GuiFramework.Line line22;
		private NxtControl.GuiFramework.Line line23;
		private NxtControl.GuiFramework.Line line24;
		private NxtControl.GuiFramework.Line line25;
		private NxtControl.GuiFramework.Line line26;
		private NxtControl.GuiFramework.Line line27;
		private NxtControl.GuiFramework.Line line28;
		private NxtControl.GuiFramework.Line line29;
		private NxtControl.GuiFramework.Line line30;
		private NxtControl.GuiFramework.Line line31;
		private NxtControl.GuiFramework.Line line21;
		private NxtControl.GuiFramework.Line line19;
		private NxtControl.GuiFramework.Rectangle rectangle1;
		private NxtControl.GuiFramework.Line line1;
		private NxtControl.GuiFramework.Line line2;
		private NxtControl.GuiFramework.Line line3;
		private NxtControl.GuiFramework.Line line4;
		private NxtControl.GuiFramework.Line line5;
		private NxtControl.GuiFramework.Line line6;
		private NxtControl.GuiFramework.Line line7;
		private NxtControl.GuiFramework.Line line8;
		private NxtControl.GuiFramework.Line line20;
		private NxtControl.GuiFramework.Rectangle rectangle2;
		private NxtControl.GuiFramework.Line line9;
		private NxtControl.GuiFramework.Line line11;
		private NxtControl.GuiFramework.Rectangle rectangle3;
		private NxtControl.GuiFramework.Line line18;
		private NxtControl.GuiFramework.Line line17;
		private NxtControl.GuiFramework.Line line10;
		private NxtControl.GuiFramework.Line line15;
		private NxtControl.GuiFramework.Line line16;
		private NxtControl.GuiFramework.Line line13;
		private NxtControl.GuiFramework.Line line12;
		private NxtControl.GuiFramework.Line line14;
		private NxtControl.GuiFramework.Group group1;
		private NxtControl.GuiFramework.Group group2;
		private NxtControl.GuiFramework.Group group3;
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
		private System.HMI.Symbols.Base.Execute<NxtControl.GuiFramework.VTQ<bool>> FbFail;
		#endregion
	}
}



