/*
 * Created by EcoStruxure Automation Expert.
 * User:  
 * Date: 11/22/2026
 * Time: 11:00 PM
 * 
 */
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

using NxtControl.GuiFramework;

namespace HMI.Main.Canvases
{
	/// <summary>
	/// Summary description for Conveyor.
	/// </summary>
	partial class Conveyor
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.hdrBg = new NxtControl.GuiFramework.Rectangle();
			this.beltPanel = new NxtControl.GuiFramework.Rectangle();
			this.lineBeltDiv = new NxtControl.GuiFramework.Line();
			this.lblTitle = new NxtControl.GuiFramework.Label();
			this.lblSubtitle = new NxtControl.GuiFramework.Label();
			this.lblBeltHeader = new NxtControl.GuiFramework.Label();
			this.lblBeltMasterCap = new NxtControl.GuiFramework.Label();
			this.lblBeltMasterHint = new NxtControl.GuiFramework.Label();
			this.lblBeltA = new NxtControl.GuiFramework.Label();
			this.lblBeltB = new NxtControl.GuiFramework.Label();
			this.lblBeltC = new NxtControl.GuiFramework.Label();
			this.lblBeltD = new NxtControl.GuiFramework.Label();
			this.symRunBelts = new SE.App2Base.Symbols.SetBool.sButton();
			this.symBeltA = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symBeltB = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symBeltC = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symBeltD = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.cardBg1 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr1 = new NxtControl.GuiFramework.Rectangle();
			this.lineDiv1 = new NxtControl.GuiFramework.Line();
			this.lblStopHdr1 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap1 = new NxtControl.GuiFramework.Label();
			this.lblModeCap1 = new NxtControl.GuiFramework.Label();
			this.lblTrayCap1 = new NxtControl.GuiFramework.Label();
			this.lblWpCap1 = new NxtControl.GuiFramework.Label();
			this.symStopper1 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symPass1 = new SE.App2Base.Symbols.SetBool.sButton();
			this.symTray1 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWp1 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.cardBg2 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr2 = new NxtControl.GuiFramework.Rectangle();
			this.lineDiv2 = new NxtControl.GuiFramework.Line();
			this.lblStopHdr2 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap2 = new NxtControl.GuiFramework.Label();
			this.lblModeCap2 = new NxtControl.GuiFramework.Label();
			this.lblTrayCap2 = new NxtControl.GuiFramework.Label();
			this.lblWpCap2 = new NxtControl.GuiFramework.Label();
			this.symStopper2 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symPass2 = new SE.App2Base.Symbols.SetBool.sButton();
			this.symTray2 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWp2 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.cardBg3 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr3 = new NxtControl.GuiFramework.Rectangle();
			this.lineDiv3 = new NxtControl.GuiFramework.Line();
			this.lblStopHdr3 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap3 = new NxtControl.GuiFramework.Label();
			this.lblModeCap3 = new NxtControl.GuiFramework.Label();
			this.lblTrayCap3 = new NxtControl.GuiFramework.Label();
			this.lblWpCap3 = new NxtControl.GuiFramework.Label();
			this.symStopper3 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symPass3 = new SE.App2Base.Symbols.SetBool.sButton();
			this.symTray3 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWp3 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.cardBg4 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr4 = new NxtControl.GuiFramework.Rectangle();
			this.lineDiv4 = new NxtControl.GuiFramework.Line();
			this.lblStopHdr4 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap4 = new NxtControl.GuiFramework.Label();
			this.lblModeCap4 = new NxtControl.GuiFramework.Label();
			this.lblTrayCap4 = new NxtControl.GuiFramework.Label();
			this.lblWpCap4 = new NxtControl.GuiFramework.Label();
			this.symStopper4 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symPass4 = new SE.App2Base.Symbols.SetBool.sButton();
			this.symTray4 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWp4 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.cardBg5 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr5 = new NxtControl.GuiFramework.Rectangle();
			this.lineDiv5 = new NxtControl.GuiFramework.Line();
			this.lblStopHdr5 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap5 = new NxtControl.GuiFramework.Label();
			this.lblModeCap5 = new NxtControl.GuiFramework.Label();
			this.lblTrayCap5 = new NxtControl.GuiFramework.Label();
			this.lblWpCap5 = new NxtControl.GuiFramework.Label();
			this.symStopper5 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symPass5 = new SE.App2Base.Symbols.SetBool.sButton();
			this.symTray5 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWp5 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.cardBg6 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr6 = new NxtControl.GuiFramework.Rectangle();
			this.lineDiv6 = new NxtControl.GuiFramework.Line();
			this.lblStopHdr6 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap6 = new NxtControl.GuiFramework.Label();
			this.lblModeCap6 = new NxtControl.GuiFramework.Label();
			this.lblTrayCap6 = new NxtControl.GuiFramework.Label();
			this.lblWpCap6 = new NxtControl.GuiFramework.Label();
			this.symStopper6 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.symPass6 = new SE.App2Base.Symbols.SetBool.sButton();
			this.symTray6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWp6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.alarmGrid1 = new NxtControl.GuiFramework.AlarmGrid();
			((System.ComponentModel.ISupportInitialize)(this.alarmGrid1)).BeginInit();
			// 
			// hdrBg
			// 
			this.hdrBg.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(8D)), ((float)(1088D)), ((float)(36D)));
			this.hdrBg.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(244)), ((byte)(248))));
			this.hdrBg.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.hdrBg.Name = "hdrBg";
			this.hdrBg.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(192)), ((byte)(202)), ((byte)(214))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// beltPanel
			// 
			this.beltPanel.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(52D)), ((float)(1088D)), ((float)(124D)));
			this.beltPanel.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.beltPanel.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.beltPanel.Name = "beltPanel";
			this.beltPanel.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineBeltDiv
			// 
			this.lineBeltDiv.EndPoint = new NxtControl.Drawing.PointF(222D, 166D);
			this.lineBeltDiv.Name = "lineBeltDiv";
			this.lineBeltDiv.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineBeltDiv.StartPoint = new NxtControl.Drawing.PointF(222D, 62D);
			// 
			// lblTitle
			// 
			this.lblTitle.AngleIgnore = true;
			this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTitle.Bounds = new NxtControl.Drawing.RectF(((float)(26D)), ((float)(12D)), ((float)(460D)), ((float)(28D)));
			this.lblTitle.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTitle.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 13F, System.Drawing.FontStyle.Bold);
			this.lblTitle.FontScale = true;
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTitle.Text = "Conveyor Station (PLC_CV - M251)";
			this.lblTitle.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.TextAutoSizeHorizontalOffset = 10;
			this.lblTitle.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblTitle.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSubtitle
			// 
			this.lblSubtitle.AngleIgnore = true;
			this.lblSubtitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSubtitle.Bounds = new NxtControl.Drawing.RectF(((float)(500D)), ((float)(14D)), ((float)(594D)), ((float)(24D)));
			this.lblSubtitle.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSubtitle.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.lblSubtitle.FontScale = true;
			this.lblSubtitle.Name = "lblSubtitle";
			this.lblSubtitle.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSubtitle.Text = "Startup: Stop 1 Blocking | Stop 2-6 Pass-Through | Belts OFF";
			this.lblSubtitle.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.lblSubtitle.TextAutoSizeHorizontalOffset = 10;
			this.lblSubtitle.TextColor = new NxtControl.Drawing.Color(((byte)(85)), ((byte)(96)), ((byte)(112)));
			this.lblSubtitle.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltHeader
			// 
			this.lblBeltHeader.AngleIgnore = true;
			this.lblBeltHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltHeader.Bounds = new NxtControl.Drawing.RectF(((float)(26D)), ((float)(56D)), ((float)(360D)), ((float)(20D)));
			this.lblBeltHeader.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltHeader.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblBeltHeader.FontScale = true;
			this.lblBeltHeader.Name = "lblBeltHeader";
			this.lblBeltHeader.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltHeader.Text = "Main Conveyor Loop - 4 Belt Segments";
			this.lblBeltHeader.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltHeader.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltHeader.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblBeltHeader.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltMasterCap
			// 
			this.lblBeltMasterCap.AngleIgnore = true;
			this.lblBeltMasterCap.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltMasterCap.Bounds = new NxtControl.Drawing.RectF(((float)(26D)), ((float)(78D)), ((float)(184D)), ((float)(16D)));
			this.lblBeltMasterCap.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltMasterCap.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblBeltMasterCap.FontScale = true;
			this.lblBeltMasterCap.Name = "lblBeltMasterCap";
			this.lblBeltMasterCap.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltMasterCap.Text = "Master Start / Stop";
			this.lblBeltMasterCap.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltMasterCap.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltMasterCap.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblBeltMasterCap.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltMasterHint
			// 
			this.lblBeltMasterHint.AngleIgnore = true;
			this.lblBeltMasterHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltMasterHint.Bounds = new NxtControl.Drawing.RectF(((float)(26D)), ((float)(142D)), ((float)(188D)), ((float)(22D)));
			this.lblBeltMasterHint.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltMasterHint.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 7.5F, System.Drawing.FontStyle.Regular);
			this.lblBeltMasterHint.FontScale = true;
			this.lblBeltMasterHint.Name = "lblBeltMasterHint";
			this.lblBeltMasterHint.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltMasterHint.Text = "Click Belt DO for Operator mode";
			this.lblBeltMasterHint.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltMasterHint.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltMasterHint.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblBeltMasterHint.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltA
			// 
			this.lblBeltA.AngleIgnore = true;
			this.lblBeltA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltA.Bounds = new NxtControl.Drawing.RectF(((float)(236D)), ((float)(78D)), ((float)(196D)), ((float)(18D)));
			this.lblBeltA.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltA.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.lblBeltA.FontScale = true;
			this.lblBeltA.Name = "lblBeltA";
			this.lblBeltA.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltA.Text = "Belt A: Small pre-S1 (M1.DO02)";
			this.lblBeltA.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltA.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltA.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblBeltA.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltB
			// 
			this.lblBeltB.AngleIgnore = true;
			this.lblBeltB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltB.Bounds = new NxtControl.Drawing.RectF(((float)(452D)), ((float)(78D)), ((float)(196D)), ((float)(18D)));
			this.lblBeltB.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltB.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.lblBeltB.FontScale = true;
			this.lblBeltB.Name = "lblBeltB";
			this.lblBeltB.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltB.Text = "Belt B: Long S1-3 (M1.DO09)";
			this.lblBeltB.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltB.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltB.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblBeltB.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltC
			// 
			this.lblBeltC.AngleIgnore = true;
			this.lblBeltC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltC.Bounds = new NxtControl.Drawing.RectF(((float)(668D)), ((float)(78D)), ((float)(196D)), ((float)(18D)));
			this.lblBeltC.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltC.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.lblBeltC.FontScale = true;
			this.lblBeltC.Name = "lblBeltC";
			this.lblBeltC.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltC.Text = "Belt C: Small pre-S4 (M2.DO01)";
			this.lblBeltC.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltC.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltC.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblBeltC.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltD
			// 
			this.lblBeltD.AngleIgnore = true;
			this.lblBeltD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltD.Bounds = new NxtControl.Drawing.RectF(((float)(884D)), ((float)(78D)), ((float)(196D)), ((float)(18D)));
			this.lblBeltD.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltD.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.lblBeltD.FontScale = true;
			this.lblBeltD.Name = "lblBeltD";
			this.lblBeltD.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltD.Text = "Belt D: Long S4-6 (M2.DO10)";
			this.lblBeltD.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltD.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltD.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblBeltD.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symRunBelts
			// 
			this.symRunBelts.BeginInit();
			this.symRunBelts.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symRunBelts.DefaultInstanceName = null;
			this.symRunBelts.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.15D, 0D, 0D, 1D, 40D, 104D);
			this.symRunBelts.Direct = "$key:SE.App2Base.TxtDirect";
			this.symRunBelts.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symRunBelts.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symRunBelts.MyTagDisplayName = null;
			this.symRunBelts.Name = "symRunBelts";
			this.symRunBelts.SecSetpoint = 0;
			this.symRunBelts.SecurityToken = ((uint)(4294967175u));
			this.symRunBelts.TagName = "41B2000000000001.RunBelts";
			this.symRunBelts.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symRunBelts.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symRunBelts.TextOff = "Belts: OFF";
			this.symRunBelts.TextOn = "Belts: ON";
			this.symRunBelts.EndInit();
			// 
			// symBeltA
			// 
			this.symBeltA.BeginInit();
			this.symBeltA.DefaultInstanceName = null;
			this.symBeltA.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 236D, 102D);
			this.symBeltA.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symBeltA.FalseText = "TxtOFF";
			this.symBeltA.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symBeltA.MyTagDisplayName = null;
			this.symBeltA.Name = "symBeltA";
			this.symBeltA.SecurityToken = ((uint)(4294967295u));
			this.symBeltA.TagName = "41B2000000000001.BeltA";
			this.symBeltA.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symBeltA.TrueText = "TxtON";
			this.symBeltA.EndInit();
			// 
			// symBeltB
			// 
			this.symBeltB.BeginInit();
			this.symBeltB.DefaultInstanceName = null;
			this.symBeltB.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 452D, 102D);
			this.symBeltB.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symBeltB.FalseText = "TxtOFF";
			this.symBeltB.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symBeltB.MyTagDisplayName = null;
			this.symBeltB.Name = "symBeltB";
			this.symBeltB.SecurityToken = ((uint)(4294967295u));
			this.symBeltB.TagName = "41B2000000000001.BeltB";
			this.symBeltB.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symBeltB.TrueText = "TxtON";
			this.symBeltB.EndInit();
			// 
			// symBeltC
			// 
			this.symBeltC.BeginInit();
			this.symBeltC.DefaultInstanceName = null;
			this.symBeltC.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 668D, 102D);
			this.symBeltC.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symBeltC.FalseText = "TxtOFF";
			this.symBeltC.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symBeltC.MyTagDisplayName = null;
			this.symBeltC.Name = "symBeltC";
			this.symBeltC.SecurityToken = ((uint)(4294967295u));
			this.symBeltC.TagName = "41B2000000000001.BeltC";
			this.symBeltC.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symBeltC.TrueText = "TxtON";
			this.symBeltC.EndInit();
			// 
			// symBeltD
			// 
			this.symBeltD.BeginInit();
			this.symBeltD.DefaultInstanceName = null;
			this.symBeltD.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 884D, 102D);
			this.symBeltD.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symBeltD.FalseText = "TxtOFF";
			this.symBeltD.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symBeltD.MyTagDisplayName = null;
			this.symBeltD.Name = "symBeltD";
			this.symBeltD.SecurityToken = ((uint)(4294967295u));
			this.symBeltD.TagName = "41B2000000000001.BeltD";
			this.symBeltD.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symBeltD.TrueText = "TxtON";
			this.symBeltD.EndInit();
			// 
			// cardBg1
			// 
			this.cardBg1.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(186D)), ((float)(352D)), ((float)(216D)));
			this.cardBg1.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg1.Name = "cardBg1";
			this.cardBg1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr1
			// 
			this.cardHdr1.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(186D)), ((float)(352D)), ((float)(28D)));
			this.cardHdr1.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr1.Name = "cardHdr1";
			this.cardHdr1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDiv1
			// 
			this.lineDiv1.EndPoint = new NxtControl.Drawing.PointF(356D, 284D);
			this.lineDiv1.Name = "lineDiv1";
			this.lineDiv1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv1.StartPoint = new NxtControl.Drawing.PointF(28D, 284D);
			// 
			// lblStopHdr1
			// 
			this.lblStopHdr1.AngleIgnore = true;
			this.lblStopHdr1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr1.Bounds = new NxtControl.Drawing.RectF(((float)(26D)), ((float)(190D)), ((float)(332D)), ((float)(20D)));
			this.lblStopHdr1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr1.FontScale = true;
			this.lblStopHdr1.Name = "lblStopHdr1";
			this.lblStopHdr1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr1.Text = "Stop 1 - Station 1 (Default: Block)";
			this.lblStopHdr1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopHdr1.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr1.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap1
			// 
			this.lblStopperCap1.AngleIgnore = true;
			this.lblStopperCap1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap1.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(220D)), ((float)(156D)), ((float)(16D)));
			this.lblStopperCap1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap1.FontScale = true;
			this.lblStopperCap1.Name = "lblStopperCap1";
			this.lblStopperCap1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap1.Text = "Stopper (M1.DO00)";
			this.lblStopperCap1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopperCap1.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblStopperCap1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblModeCap1
			// 
			this.lblModeCap1.AngleIgnore = true;
			this.lblModeCap1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblModeCap1.Bounds = new NxtControl.Drawing.RectF(((float)(200D)), ((float)(220D)), ((float)(156D)), ((float)(16D)));
			this.lblModeCap1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblModeCap1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblModeCap1.FontScale = true;
			this.lblModeCap1.Name = "lblModeCap1";
			this.lblModeCap1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblModeCap1.Text = "Mode (Block / Pass)";
			this.lblModeCap1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblModeCap1.TextAutoSizeHorizontalOffset = 10;
			this.lblModeCap1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblModeCap1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblTrayCap1
			// 
			this.lblTrayCap1.AngleIgnore = true;
			this.lblTrayCap1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTrayCap1.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(292D)), ((float)(156D)), ((float)(16D)));
			this.lblTrayCap1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTrayCap1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblTrayCap1.FontScale = true;
			this.lblTrayCap1.Name = "lblTrayCap1";
			this.lblTrayCap1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTrayCap1.Text = "Tray (M1.DI02)";
			this.lblTrayCap1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTrayCap1.TextAutoSizeHorizontalOffset = 10;
			this.lblTrayCap1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblTrayCap1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpCap1
			// 
			this.lblWpCap1.AngleIgnore = true;
			this.lblWpCap1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpCap1.Bounds = new NxtControl.Drawing.RectF(((float)(200D)), ((float)(292D)), ((float)(156D)), ((float)(16D)));
			this.lblWpCap1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpCap1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblWpCap1.FontScale = true;
			this.lblWpCap1.Name = "lblWpCap1";
			this.lblWpCap1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpCap1.Text = "Workpiece (M1.DI05)";
			this.lblWpCap1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpCap1.TextAutoSizeHorizontalOffset = 10;
			this.lblWpCap1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpCap1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symStopper1
			// 
			this.symStopper1.BeginInit();
			this.symStopper1.DefaultInstanceName = null;
			this.symStopper1.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.80207100591715974D, 0D, 0D, 0.86304347826086947D, 16D, 232D);
			this.symStopper1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symStopper1.FalseText = "TxtOFF";
			this.symStopper1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper1.MyTagDisplayName = null;
			this.symStopper1.Name = "symStopper1";
			this.symStopper1.SecurityToken = ((uint)(4294967295u));
			this.symStopper1.TagName = "41B2000000000001.Stop1.Stopper";
			this.symStopper1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symStopper1.TrueText = "TxtON";
			this.symStopper1.EndInit();
			// 
			// symPass1
			// 
			this.symPass1.BeginInit();
			this.symPass1.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symPass1.DefaultInstanceName = null;
			this.symPass1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 224D, 248D);
			this.symPass1.Direct = "$key:SE.App2Base.TxtDirect";
			this.symPass1.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symPass1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPass1.MyTagDisplayName = null;
			this.symPass1.Name = "symPass1";
			this.symPass1.SecSetpoint = 0;
			this.symPass1.SecurityToken = ((uint)(4294967175u));
			this.symPass1.TagName = "41B2000000000001.Stop1.PassThrough";
			this.symPass1.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass1.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass1.TextOff = "Block";
			this.symPass1.TextOn = "Pass";
			this.symPass1.EndInit();
			// 
			// symTray1
			// 
			this.symTray1.BeginInit();
			this.symTray1.DefaultInstanceName = null;
			this.symTray1.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 26D, 312D);
			this.symTray1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symTray1.FalseText = "TxtOFF";
			this.symTray1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symTray1.MyTagDisplayName = null;
			this.symTray1.Name = "symTray1";
			this.symTray1.SecurityToken = ((uint)(4294967295u));
			this.symTray1.TagName = "41B2000000000001.Stop1.TrayPresent";
			this.symTray1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symTray1.TrueText = "TxtON";
			this.symTray1.EndInit();
			// 
			// symWp1
			// 
			this.symWp1.BeginInit();
			this.symWp1.DefaultInstanceName = null;
			this.symWp1.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 200D, 312D);
			this.symWp1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWp1.FalseText = "TxtOFF";
			this.symWp1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWp1.MyTagDisplayName = null;
			this.symWp1.Name = "symWp1";
			this.symWp1.SecurityToken = ((uint)(4294967295u));
			this.symWp1.TagName = "41B2000000000001.Stop1.WorkpiecePresent";
			this.symWp1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWp1.TrueText = "TxtON";
			this.symWp1.EndInit();
			// 
			// cardBg2
			// 
			this.cardBg2.Bounds = new NxtControl.Drawing.RectF(((float)(384D)), ((float)(186D)), ((float)(352D)), ((float)(216D)));
			this.cardBg2.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg2.Name = "cardBg2";
			this.cardBg2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr2
			// 
			this.cardHdr2.Bounds = new NxtControl.Drawing.RectF(((float)(384D)), ((float)(186D)), ((float)(352D)), ((float)(28D)));
			this.cardHdr2.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr2.Name = "cardHdr2";
			this.cardHdr2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDiv2
			// 
			this.lineDiv2.EndPoint = new NxtControl.Drawing.PointF(724D, 284D);
			this.lineDiv2.Name = "lineDiv2";
			this.lineDiv2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv2.StartPoint = new NxtControl.Drawing.PointF(396D, 284D);
			// 
			// lblStopHdr2
			// 
			this.lblStopHdr2.AngleIgnore = true;
			this.lblStopHdr2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr2.Bounds = new NxtControl.Drawing.RectF(((float)(394D)), ((float)(190D)), ((float)(332D)), ((float)(20D)));
			this.lblStopHdr2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr2.FontScale = true;
			this.lblStopHdr2.Name = "lblStopHdr2";
			this.lblStopHdr2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr2.Text = "Stop 2 (Default: Pass-Through)";
			this.lblStopHdr2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopHdr2.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr2.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap2
			// 
			this.lblStopperCap2.AngleIgnore = true;
			this.lblStopperCap2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap2.Bounds = new NxtControl.Drawing.RectF(((float)(396D)), ((float)(220D)), ((float)(156D)), ((float)(16D)));
			this.lblStopperCap2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap2.FontScale = true;
			this.lblStopperCap2.Name = "lblStopperCap2";
			this.lblStopperCap2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap2.Text = "Stopper (M1.DO01)";
			this.lblStopperCap2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopperCap2.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblStopperCap2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblModeCap2
			// 
			this.lblModeCap2.AngleIgnore = true;
			this.lblModeCap2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblModeCap2.Bounds = new NxtControl.Drawing.RectF(((float)(568D)), ((float)(220D)), ((float)(156D)), ((float)(16D)));
			this.lblModeCap2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblModeCap2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblModeCap2.FontScale = true;
			this.lblModeCap2.Name = "lblModeCap2";
			this.lblModeCap2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblModeCap2.Text = "Mode (Block / Pass)";
			this.lblModeCap2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblModeCap2.TextAutoSizeHorizontalOffset = 10;
			this.lblModeCap2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblModeCap2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblTrayCap2
			// 
			this.lblTrayCap2.AngleIgnore = true;
			this.lblTrayCap2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTrayCap2.Bounds = new NxtControl.Drawing.RectF(((float)(396D)), ((float)(292D)), ((float)(156D)), ((float)(16D)));
			this.lblTrayCap2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTrayCap2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblTrayCap2.FontScale = true;
			this.lblTrayCap2.Name = "lblTrayCap2";
			this.lblTrayCap2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTrayCap2.Text = "Tray Present (DI)";
			this.lblTrayCap2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTrayCap2.TextAutoSizeHorizontalOffset = 10;
			this.lblTrayCap2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblTrayCap2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpCap2
			// 
			this.lblWpCap2.AngleIgnore = true;
			this.lblWpCap2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpCap2.Bounds = new NxtControl.Drawing.RectF(((float)(568D)), ((float)(292D)), ((float)(156D)), ((float)(16D)));
			this.lblWpCap2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpCap2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblWpCap2.FontScale = true;
			this.lblWpCap2.Name = "lblWpCap2";
			this.lblWpCap2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpCap2.Text = "Workpiece Present (DI)";
			this.lblWpCap2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpCap2.TextAutoSizeHorizontalOffset = 10;
			this.lblWpCap2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpCap2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symStopper2
			// 
			this.symStopper2.BeginInit();
			this.symStopper2.DefaultInstanceName = null;
			this.symStopper2.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.84940828402366864D, 0D, 0D, 0.776086956521739D, 384D, 232D);
			this.symStopper2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symStopper2.FalseText = "TxtOFF";
			this.symStopper2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper2.MyTagDisplayName = null;
			this.symStopper2.Name = "symStopper2";
			this.symStopper2.SecurityToken = ((uint)(4294967295u));
			this.symStopper2.TagName = "41B2000000000001.Stop2.Stopper";
			this.symStopper2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symStopper2.TrueText = "TxtON";
			this.symStopper2.EndInit();
			// 
			// symPass2
			// 
			this.symPass2.BeginInit();
			this.symPass2.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symPass2.DefaultInstanceName = null;
			this.symPass2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 600D, 240D);
			this.symPass2.Direct = "$key:SE.App2Base.TxtDirect";
			this.symPass2.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symPass2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPass2.MyTagDisplayName = null;
			this.symPass2.Name = "symPass2";
			this.symPass2.SecSetpoint = 0;
			this.symPass2.SecurityToken = ((uint)(4294967175u));
			this.symPass2.TagName = "41B2000000000001.Stop2.PassThrough";
			this.symPass2.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass2.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass2.TextOff = "Block";
			this.symPass2.TextOn = "Pass";
			this.symPass2.EndInit();
			// 
			// symTray2
			// 
			this.symTray2.BeginInit();
			this.symTray2.DefaultInstanceName = null;
			this.symTray2.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 394D, 312D);
			this.symTray2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symTray2.FalseText = "TxtOFF";
			this.symTray2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symTray2.MyTagDisplayName = null;
			this.symTray2.Name = "symTray2";
			this.symTray2.SecurityToken = ((uint)(4294967295u));
			this.symTray2.TagName = "41B2000000000001.Stop2.TrayPresent";
			this.symTray2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symTray2.TrueText = "TxtON";
			this.symTray2.EndInit();
			// 
			// symWp2
			// 
			this.symWp2.BeginInit();
			this.symWp2.DefaultInstanceName = null;
			this.symWp2.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 568D, 312D);
			this.symWp2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWp2.FalseText = "TxtOFF";
			this.symWp2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWp2.MyTagDisplayName = null;
			this.symWp2.Name = "symWp2";
			this.symWp2.SecurityToken = ((uint)(4294967295u));
			this.symWp2.TagName = "41B2000000000001.Stop2.WorkpiecePresent";
			this.symWp2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWp2.TrueText = "TxtON";
			this.symWp2.EndInit();
			// 
			// cardBg3
			// 
			this.cardBg3.Bounds = new NxtControl.Drawing.RectF(((float)(752D)), ((float)(186D)), ((float)(352D)), ((float)(216D)));
			this.cardBg3.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg3.Name = "cardBg3";
			this.cardBg3.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr3
			// 
			this.cardHdr3.Bounds = new NxtControl.Drawing.RectF(((float)(752D)), ((float)(186D)), ((float)(352D)), ((float)(28D)));
			this.cardHdr3.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr3.Name = "cardHdr3";
			this.cardHdr3.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDiv3
			// 
			this.lineDiv3.EndPoint = new NxtControl.Drawing.PointF(1092D, 284D);
			this.lineDiv3.Name = "lineDiv3";
			this.lineDiv3.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv3.StartPoint = new NxtControl.Drawing.PointF(764D, 284D);
			// 
			// lblStopHdr3
			// 
			this.lblStopHdr3.AngleIgnore = true;
			this.lblStopHdr3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr3.Bounds = new NxtControl.Drawing.RectF(((float)(762D)), ((float)(190D)), ((float)(332D)), ((float)(20D)));
			this.lblStopHdr3.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr3.FontScale = true;
			this.lblStopHdr3.Name = "lblStopHdr3";
			this.lblStopHdr3.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr3.Text = "Stop 3 (Default: Pass-Through)";
			this.lblStopHdr3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopHdr3.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr3.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr3.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap3
			// 
			this.lblStopperCap3.AngleIgnore = true;
			this.lblStopperCap3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap3.Bounds = new NxtControl.Drawing.RectF(((float)(760D)), ((float)(224D)), ((float)(156D)), ((float)(16D)));
			this.lblStopperCap3.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap3.FontScale = true;
			this.lblStopperCap3.Name = "lblStopperCap3";
			this.lblStopperCap3.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap3.Text = "Stopper (M1.DO08)";
			this.lblStopperCap3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopperCap3.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap3.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblStopperCap3.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblModeCap3
			// 
			this.lblModeCap3.AngleIgnore = true;
			this.lblModeCap3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblModeCap3.Bounds = new NxtControl.Drawing.RectF(((float)(936D)), ((float)(220D)), ((float)(156D)), ((float)(16D)));
			this.lblModeCap3.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblModeCap3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblModeCap3.FontScale = true;
			this.lblModeCap3.Name = "lblModeCap3";
			this.lblModeCap3.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblModeCap3.Text = "Mode (Block / Pass)";
			this.lblModeCap3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblModeCap3.TextAutoSizeHorizontalOffset = 10;
			this.lblModeCap3.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblModeCap3.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblTrayCap3
			// 
			this.lblTrayCap3.AngleIgnore = true;
			this.lblTrayCap3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTrayCap3.Bounds = new NxtControl.Drawing.RectF(((float)(768D)), ((float)(312D)), ((float)(156D)), ((float)(16D)));
			this.lblTrayCap3.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTrayCap3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblTrayCap3.FontScale = true;
			this.lblTrayCap3.Name = "lblTrayCap3";
			this.lblTrayCap3.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTrayCap3.Text = "Tray Present (DI)";
			this.lblTrayCap3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTrayCap3.TextAutoSizeHorizontalOffset = 10;
			this.lblTrayCap3.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblTrayCap3.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpCap3
			// 
			this.lblWpCap3.AngleIgnore = true;
			this.lblWpCap3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpCap3.Bounds = new NxtControl.Drawing.RectF(((float)(936D)), ((float)(292D)), ((float)(156D)), ((float)(16D)));
			this.lblWpCap3.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpCap3.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblWpCap3.FontScale = true;
			this.lblWpCap3.Name = "lblWpCap3";
			this.lblWpCap3.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpCap3.Text = "Workpiece Present (DI)";
			this.lblWpCap3.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpCap3.TextAutoSizeHorizontalOffset = 10;
			this.lblWpCap3.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpCap3.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symStopper3
			// 
			this.symStopper3.BeginInit();
			this.symStopper3.DefaultInstanceName = null;
			this.symStopper3.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.89674556213017753D, 0D, 0D, 0.87391304347826082D, 744D, 232D);
			this.symStopper3.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symStopper3.FalseText = "TxtOFF";
			this.symStopper3.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper3.MyTagDisplayName = null;
			this.symStopper3.Name = "symStopper3";
			this.symStopper3.SecurityToken = ((uint)(4294967295u));
			this.symStopper3.TagName = "41B2000000000001.Stop3.Stopper";
			this.symStopper3.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symStopper3.TrueText = "TxtON";
			this.symStopper3.EndInit();
			// 
			// symPass3
			// 
			this.symPass3.BeginInit();
			this.symPass3.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symPass3.DefaultInstanceName = null;
			this.symPass3.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 976D, 248D);
			this.symPass3.Direct = "$key:SE.App2Base.TxtDirect";
			this.symPass3.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symPass3.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPass3.MyTagDisplayName = null;
			this.symPass3.Name = "symPass3";
			this.symPass3.SecSetpoint = 0;
			this.symPass3.SecurityToken = ((uint)(4294967175u));
			this.symPass3.TagName = "41B2000000000001.Stop3.PassThrough";
			this.symPass3.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass3.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass3.TextOff = "Block";
			this.symPass3.TextOn = "Pass";
			this.symPass3.EndInit();
			// 
			// symTray3
			// 
			this.symTray3.BeginInit();
			this.symTray3.DefaultInstanceName = null;
			this.symTray3.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 767.2D, 344D);
			this.symTray3.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symTray3.FalseText = "TxtOFF";
			this.symTray3.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symTray3.MyTagDisplayName = null;
			this.symTray3.Name = "symTray3";
			this.symTray3.SecurityToken = ((uint)(4294967295u));
			this.symTray3.TagName = "41B2000000000001.Stop3.TrayPresent";
			this.symTray3.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symTray3.TrueText = "TxtON";
			this.symTray3.EndInit();
			// 
			// symWp3
			// 
			this.symWp3.BeginInit();
			this.symWp3.DefaultInstanceName = null;
			this.symWp3.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 936D, 312D);
			this.symWp3.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWp3.FalseText = "TxtOFF";
			this.symWp3.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWp3.MyTagDisplayName = null;
			this.symWp3.Name = "symWp3";
			this.symWp3.SecurityToken = ((uint)(4294967295u));
			this.symWp3.TagName = "41B2000000000001.Stop3.WorkpiecePresent";
			this.symWp3.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWp3.TrueText = "TxtON";
			this.symWp3.EndInit();
			// 
			// cardBg4
			// 
			this.cardBg4.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(408D)), ((float)(352D)), ((float)(216D)));
			this.cardBg4.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg4.Name = "cardBg4";
			this.cardBg4.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr4
			// 
			this.cardHdr4.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(408D)), ((float)(352D)), ((float)(28D)));
			this.cardHdr4.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr4.Name = "cardHdr4";
			this.cardHdr4.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDiv4
			// 
			this.lineDiv4.EndPoint = new NxtControl.Drawing.PointF(356D, 506D);
			this.lineDiv4.Name = "lineDiv4";
			this.lineDiv4.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv4.StartPoint = new NxtControl.Drawing.PointF(28D, 506D);
			// 
			// lblStopHdr4
			// 
			this.lblStopHdr4.AngleIgnore = true;
			this.lblStopHdr4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr4.Bounds = new NxtControl.Drawing.RectF(((float)(26D)), ((float)(412D)), ((float)(332D)), ((float)(20D)));
			this.lblStopHdr4.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr4.FontScale = true;
			this.lblStopHdr4.Name = "lblStopHdr4";
			this.lblStopHdr4.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr4.Text = "Stop 4 (Default: Pass-Through)";
			this.lblStopHdr4.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopHdr4.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr4.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr4.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap4
			// 
			this.lblStopperCap4.AngleIgnore = true;
			this.lblStopperCap4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap4.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(442D)), ((float)(156D)), ((float)(16D)));
			this.lblStopperCap4.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap4.FontScale = true;
			this.lblStopperCap4.Name = "lblStopperCap4";
			this.lblStopperCap4.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap4.Text = "Stopper (M2.DO00)";
			this.lblStopperCap4.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopperCap4.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap4.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblStopperCap4.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblModeCap4
			// 
			this.lblModeCap4.AngleIgnore = true;
			this.lblModeCap4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblModeCap4.Bounds = new NxtControl.Drawing.RectF(((float)(200D)), ((float)(442D)), ((float)(156D)), ((float)(16D)));
			this.lblModeCap4.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblModeCap4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblModeCap4.FontScale = true;
			this.lblModeCap4.Name = "lblModeCap4";
			this.lblModeCap4.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblModeCap4.Text = "Mode (Block / Pass)";
			this.lblModeCap4.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblModeCap4.TextAutoSizeHorizontalOffset = 10;
			this.lblModeCap4.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblModeCap4.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblTrayCap4
			// 
			this.lblTrayCap4.AngleIgnore = true;
			this.lblTrayCap4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTrayCap4.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(514D)), ((float)(156D)), ((float)(16D)));
			this.lblTrayCap4.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTrayCap4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblTrayCap4.FontScale = true;
			this.lblTrayCap4.Name = "lblTrayCap4";
			this.lblTrayCap4.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTrayCap4.Text = "Tray Present (DI)";
			this.lblTrayCap4.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTrayCap4.TextAutoSizeHorizontalOffset = 10;
			this.lblTrayCap4.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblTrayCap4.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpCap4
			// 
			this.lblWpCap4.AngleIgnore = true;
			this.lblWpCap4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpCap4.Bounds = new NxtControl.Drawing.RectF(((float)(200D)), ((float)(514D)), ((float)(156D)), ((float)(16D)));
			this.lblWpCap4.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpCap4.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblWpCap4.FontScale = true;
			this.lblWpCap4.Name = "lblWpCap4";
			this.lblWpCap4.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpCap4.Text = "Workpiece Present (DI)";
			this.lblWpCap4.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpCap4.TextAutoSizeHorizontalOffset = 10;
			this.lblWpCap4.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpCap4.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symStopper4
			// 
			this.symStopper4.BeginInit();
			this.symStopper4.DefaultInstanceName = null;
			this.symStopper4.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.89674556213017753D, 0D, 0D, 0.86304347826086947D, 16D, 448D);
			this.symStopper4.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symStopper4.FalseText = "TxtOFF";
			this.symStopper4.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper4.MyTagDisplayName = null;
			this.symStopper4.Name = "symStopper4";
			this.symStopper4.SecurityToken = ((uint)(4294967295u));
			this.symStopper4.TagName = "41B2000000000001.Stop4.Stopper";
			this.symStopper4.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symStopper4.TrueText = "TxtON";
			this.symStopper4.EndInit();
			// 
			// symPass4
			// 
			this.symPass4.BeginInit();
			this.symPass4.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symPass4.DefaultInstanceName = null;
			this.symPass4.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 240D, 464D);
			this.symPass4.Direct = "$key:SE.App2Base.TxtDirect";
			this.symPass4.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symPass4.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPass4.MyTagDisplayName = null;
			this.symPass4.Name = "symPass4";
			this.symPass4.SecSetpoint = 0;
			this.symPass4.SecurityToken = ((uint)(4294967175u));
			this.symPass4.TagName = "41B2000000000001.Stop4.PassThrough";
			this.symPass4.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass4.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass4.TextOff = "Block";
			this.symPass4.TextOn = "Pass";
			this.symPass4.EndInit();
			// 
			// symTray4
			// 
			this.symTray4.BeginInit();
			this.symTray4.DefaultInstanceName = null;
			this.symTray4.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 39.2D, 544D);
			this.symTray4.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symTray4.FalseText = "TxtOFF";
			this.symTray4.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symTray4.MyTagDisplayName = null;
			this.symTray4.Name = "symTray4";
			this.symTray4.SecurityToken = ((uint)(4294967295u));
			this.symTray4.TagName = "41B2000000000001.Stop4.TrayPresent";
			this.symTray4.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symTray4.TrueText = "TxtON";
			this.symTray4.EndInit();
			// 
			// symWp4
			// 
			this.symWp4.BeginInit();
			this.symWp4.DefaultInstanceName = null;
			this.symWp4.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 207.2D, 536D);
			this.symWp4.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWp4.FalseText = "TxtOFF";
			this.symWp4.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWp4.MyTagDisplayName = null;
			this.symWp4.Name = "symWp4";
			this.symWp4.SecurityToken = ((uint)(4294967295u));
			this.symWp4.TagName = "41B2000000000001.Stop4.WorkpiecePresent";
			this.symWp4.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWp4.TrueText = "TxtON";
			this.symWp4.EndInit();
			// 
			// cardBg5
			// 
			this.cardBg5.Bounds = new NxtControl.Drawing.RectF(((float)(384D)), ((float)(408D)), ((float)(352D)), ((float)(216D)));
			this.cardBg5.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg5.Name = "cardBg5";
			this.cardBg5.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr5
			// 
			this.cardHdr5.Bounds = new NxtControl.Drawing.RectF(((float)(384D)), ((float)(408D)), ((float)(352D)), ((float)(28D)));
			this.cardHdr5.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr5.Name = "cardHdr5";
			this.cardHdr5.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDiv5
			// 
			this.lineDiv5.EndPoint = new NxtControl.Drawing.PointF(724D, 506D);
			this.lineDiv5.Name = "lineDiv5";
			this.lineDiv5.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv5.StartPoint = new NxtControl.Drawing.PointF(396D, 506D);
			// 
			// lblStopHdr5
			// 
			this.lblStopHdr5.AngleIgnore = true;
			this.lblStopHdr5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr5.Bounds = new NxtControl.Drawing.RectF(((float)(394D)), ((float)(412D)), ((float)(332D)), ((float)(20D)));
			this.lblStopHdr5.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr5.FontScale = true;
			this.lblStopHdr5.Name = "lblStopHdr5";
			this.lblStopHdr5.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr5.Text = "Stop 5 (Default: Pass-Through)";
			this.lblStopHdr5.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopHdr5.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr5.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr5.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap5
			// 
			this.lblStopperCap5.AngleIgnore = true;
			this.lblStopperCap5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap5.Bounds = new NxtControl.Drawing.RectF(((float)(396D)), ((float)(442D)), ((float)(156D)), ((float)(16D)));
			this.lblStopperCap5.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap5.FontScale = true;
			this.lblStopperCap5.Name = "lblStopperCap5";
			this.lblStopperCap5.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap5.Text = "Stopper (M2.DO08)";
			this.lblStopperCap5.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopperCap5.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap5.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblStopperCap5.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblModeCap5
			// 
			this.lblModeCap5.AngleIgnore = true;
			this.lblModeCap5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblModeCap5.Bounds = new NxtControl.Drawing.RectF(((float)(568D)), ((float)(442D)), ((float)(156D)), ((float)(16D)));
			this.lblModeCap5.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblModeCap5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblModeCap5.FontScale = true;
			this.lblModeCap5.Name = "lblModeCap5";
			this.lblModeCap5.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblModeCap5.Text = "Mode (Block / Pass)";
			this.lblModeCap5.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblModeCap5.TextAutoSizeHorizontalOffset = 10;
			this.lblModeCap5.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblModeCap5.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblTrayCap5
			// 
			this.lblTrayCap5.AngleIgnore = true;
			this.lblTrayCap5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTrayCap5.Bounds = new NxtControl.Drawing.RectF(((float)(396D)), ((float)(514D)), ((float)(156D)), ((float)(16D)));
			this.lblTrayCap5.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTrayCap5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblTrayCap5.FontScale = true;
			this.lblTrayCap5.Name = "lblTrayCap5";
			this.lblTrayCap5.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTrayCap5.Text = "Tray Present (DI)";
			this.lblTrayCap5.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTrayCap5.TextAutoSizeHorizontalOffset = 10;
			this.lblTrayCap5.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblTrayCap5.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpCap5
			// 
			this.lblWpCap5.AngleIgnore = true;
			this.lblWpCap5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpCap5.Bounds = new NxtControl.Drawing.RectF(((float)(568D)), ((float)(514D)), ((float)(156D)), ((float)(16D)));
			this.lblWpCap5.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpCap5.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblWpCap5.FontScale = true;
			this.lblWpCap5.Name = "lblWpCap5";
			this.lblWpCap5.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpCap5.Text = "Workpiece Present (DI)";
			this.lblWpCap5.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpCap5.TextAutoSizeHorizontalOffset = 10;
			this.lblWpCap5.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpCap5.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symStopper5
			// 
			this.symStopper5.BeginInit();
			this.symStopper5.DefaultInstanceName = null;
			this.symStopper5.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.68372781065088739D, 0D, 0D, 0.7543478260869565D, 392D, 456D);
			this.symStopper5.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symStopper5.FalseText = "TxtOFF";
			this.symStopper5.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper5.MyTagDisplayName = null;
			this.symStopper5.Name = "symStopper5";
			this.symStopper5.SecurityToken = ((uint)(4294967295u));
			this.symStopper5.TagName = "41B2000000000001.Stop5.Stopper";
			this.symStopper5.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symStopper5.TrueText = "TxtON";
			this.symStopper5.EndInit();
			// 
			// symPass5
			// 
			this.symPass5.BeginInit();
			this.symPass5.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symPass5.DefaultInstanceName = null;
			this.symPass5.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 592D, 464D);
			this.symPass5.Direct = "$key:SE.App2Base.TxtDirect";
			this.symPass5.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symPass5.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPass5.MyTagDisplayName = null;
			this.symPass5.Name = "symPass5";
			this.symPass5.SecSetpoint = 0;
			this.symPass5.SecurityToken = ((uint)(4294967175u));
			this.symPass5.TagName = "41B2000000000001.Stop5.PassThrough";
			this.symPass5.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass5.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass5.TextOff = "Block";
			this.symPass5.TextOn = "Pass";
			this.symPass5.EndInit();
			// 
			// symTray5
			// 
			this.symTray5.BeginInit();
			this.symTray5.DefaultInstanceName = null;
			this.symTray5.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 394D, 534D);
			this.symTray5.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symTray5.FalseText = "TxtOFF";
			this.symTray5.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symTray5.MyTagDisplayName = null;
			this.symTray5.Name = "symTray5";
			this.symTray5.SecurityToken = ((uint)(4294967295u));
			this.symTray5.TagName = "41B2000000000001.Stop5.TrayPresent";
			this.symTray5.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symTray5.TrueText = "TxtON";
			this.symTray5.EndInit();
			// 
			// symWp5
			// 
			this.symWp5.BeginInit();
			this.symWp5.DefaultInstanceName = null;
			this.symWp5.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 568D, 534D);
			this.symWp5.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWp5.FalseText = "TxtOFF";
			this.symWp5.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWp5.MyTagDisplayName = null;
			this.symWp5.Name = "symWp5";
			this.symWp5.SecurityToken = ((uint)(4294967295u));
			this.symWp5.TagName = "41B2000000000001.Stop5.WorkpiecePresent";
			this.symWp5.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWp5.TrueText = "TxtON";
			this.symWp5.EndInit();
			// 
			// cardBg6
			// 
			this.cardBg6.Bounds = new NxtControl.Drawing.RectF(((float)(752D)), ((float)(408D)), ((float)(352D)), ((float)(216D)));
			this.cardBg6.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg6.Name = "cardBg6";
			this.cardBg6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr6
			// 
			this.cardHdr6.Bounds = new NxtControl.Drawing.RectF(((float)(752D)), ((float)(408D)), ((float)(352D)), ((float)(28D)));
			this.cardHdr6.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr6.Name = "cardHdr6";
			this.cardHdr6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDiv6
			// 
			this.lineDiv6.EndPoint = new NxtControl.Drawing.PointF(1092D, 506D);
			this.lineDiv6.Name = "lineDiv6";
			this.lineDiv6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv6.StartPoint = new NxtControl.Drawing.PointF(764D, 506D);
			// 
			// lblStopHdr6
			// 
			this.lblStopHdr6.AngleIgnore = true;
			this.lblStopHdr6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr6.Bounds = new NxtControl.Drawing.RectF(((float)(762D)), ((float)(412D)), ((float)(332D)), ((float)(20D)));
			this.lblStopHdr6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr6.FontScale = true;
			this.lblStopHdr6.Name = "lblStopHdr6";
			this.lblStopHdr6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr6.Text = "Stop 6 (Default: Pass-Through)";
			this.lblStopHdr6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopHdr6.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr6.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap6
			// 
			this.lblStopperCap6.AngleIgnore = true;
			this.lblStopperCap6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap6.Bounds = new NxtControl.Drawing.RectF(((float)(764D)), ((float)(442D)), ((float)(156D)), ((float)(16D)));
			this.lblStopperCap6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap6.FontScale = true;
			this.lblStopperCap6.Name = "lblStopperCap6";
			this.lblStopperCap6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap6.Text = "Stopper (M2.DO09)";
			this.lblStopperCap6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStopperCap6.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblStopperCap6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblModeCap6
			// 
			this.lblModeCap6.AngleIgnore = true;
			this.lblModeCap6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblModeCap6.Bounds = new NxtControl.Drawing.RectF(((float)(936D)), ((float)(442D)), ((float)(156D)), ((float)(16D)));
			this.lblModeCap6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblModeCap6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblModeCap6.FontScale = true;
			this.lblModeCap6.Name = "lblModeCap6";
			this.lblModeCap6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblModeCap6.Text = "Mode (Block / Pass)";
			this.lblModeCap6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblModeCap6.TextAutoSizeHorizontalOffset = 10;
			this.lblModeCap6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblModeCap6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblTrayCap6
			// 
			this.lblTrayCap6.AngleIgnore = true;
			this.lblTrayCap6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTrayCap6.Bounds = new NxtControl.Drawing.RectF(((float)(764D)), ((float)(514D)), ((float)(156D)), ((float)(16D)));
			this.lblTrayCap6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTrayCap6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblTrayCap6.FontScale = true;
			this.lblTrayCap6.Name = "lblTrayCap6";
			this.lblTrayCap6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTrayCap6.Text = "Tray Present (DI)";
			this.lblTrayCap6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTrayCap6.TextAutoSizeHorizontalOffset = 10;
			this.lblTrayCap6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblTrayCap6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpCap6
			// 
			this.lblWpCap6.AngleIgnore = true;
			this.lblWpCap6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpCap6.Bounds = new NxtControl.Drawing.RectF(((float)(936D)), ((float)(514D)), ((float)(156D)), ((float)(16D)));
			this.lblWpCap6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpCap6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblWpCap6.FontScale = true;
			this.lblWpCap6.Name = "lblWpCap6";
			this.lblWpCap6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpCap6.Text = "Workpiece Present (DI)";
			this.lblWpCap6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpCap6.TextAutoSizeHorizontalOffset = 10;
			this.lblWpCap6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpCap6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symStopper6
			// 
			this.symStopper6.BeginInit();
			this.symStopper6.DefaultInstanceName = null;
			this.symStopper6.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.77840236686390529D, 0D, 0D, 0.84130434782608687D, 752D, 448D);
			this.symStopper6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symStopper6.FalseText = "TxtOFF";
			this.symStopper6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper6.MyTagDisplayName = null;
			this.symStopper6.Name = "symStopper6";
			this.symStopper6.SecurityToken = ((uint)(4294967295u));
			this.symStopper6.TagName = "41B2000000000001.Stop6.Stopper";
			this.symStopper6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symStopper6.TrueText = "TxtON";
			this.symStopper6.EndInit();
			// 
			// symPass6
			// 
			this.symPass6.BeginInit();
			this.symPass6.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symPass6.DefaultInstanceName = null;
			this.symPass6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 984D, 472D);
			this.symPass6.Direct = "$key:SE.App2Base.TxtDirect";
			this.symPass6.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symPass6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPass6.MyTagDisplayName = null;
			this.symPass6.Name = "symPass6";
			this.symPass6.SecSetpoint = 0;
			this.symPass6.SecurityToken = ((uint)(4294967175u));
			this.symPass6.TagName = "41B2000000000001.Stop6.PassThrough";
			this.symPass6.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass6.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symPass6.TextOff = "Block";
			this.symPass6.TextOn = "Pass";
			this.symPass6.EndInit();
			// 
			// symTray6
			// 
			this.symTray6.BeginInit();
			this.symTray6.DefaultInstanceName = null;
			this.symTray6.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 762D, 534D);
			this.symTray6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symTray6.FalseText = "TxtOFF";
			this.symTray6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symTray6.MyTagDisplayName = null;
			this.symTray6.Name = "symTray6";
			this.symTray6.SecurityToken = ((uint)(4294967295u));
			this.symTray6.TagName = "41B2000000000001.Stop6.TrayPresent";
			this.symTray6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symTray6.TrueText = "TxtON";
			this.symTray6.EndInit();
			// 
			// symWp6
			// 
			this.symWp6.BeginInit();
			this.symWp6.DefaultInstanceName = null;
			this.symWp6.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.8D, 0D, 0D, 0.85D, 936D, 534D);
			this.symWp6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWp6.FalseText = "TxtOFF";
			this.symWp6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWp6.MyTagDisplayName = null;
			this.symWp6.Name = "symWp6";
			this.symWp6.SecurityToken = ((uint)(4294967295u));
			this.symWp6.TagName = "41B2000000000001.Stop6.WorkpiecePresent";
			this.symWp6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWp6.TrueText = "TxtON";
			this.symWp6.EndInit();
			// 
			// alarmGrid1
			// 
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Shortcut, true, null, 32));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Ack, true, null, 40));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Origin, true, null, 200));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Text, true, null, 100));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.CameTime, true, null, 130));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.GoneTime, true, null, 130));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Present, true, null, 48));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.State, true, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Value, true, null, 80));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.InfoValue, true, null, 80));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.CameAckTime, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.GoneAckTime, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Interval, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.CameAckUser, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.GoneAckUser, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Path, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Alias, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Time, false, null, 0));
			this.alarmGrid1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Selected, true, null, 25));
			this.alarmGrid1.AlarmFilter = new NxtControl.GuiFramework.AlarmConfiguration("");
			this.alarmGrid1.AlternatingRowColor = System.Drawing.Color.Empty;
			this.alarmGrid1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.alarmGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.alarmGrid1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
			this.alarmGrid1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.alarmGrid1.GridCellBackColor = System.Drawing.SystemColors.Window;
			this.alarmGrid1.HeaderBackColor = System.Drawing.SystemColors.Control;
			this.alarmGrid1.HeaderForeColor = System.Drawing.SystemColors.WindowText;
			this.alarmGrid1.Location = new System.Drawing.Point(1120, 56);
			this.alarmGrid1.Name = "alarmGrid1";
			this.alarmGrid1.SecurityLevel = 3;
			this.alarmGrid1.Size = new System.Drawing.Size(374, 254);
			this.alarmGrid1.Text = "alarmGrid1";
			this.alarmGrid1.ToolBarBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.alarmGrid1.ToolBarForeColor = System.Drawing.SystemColors.ControlText;
			// 
			// Conveyor
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1480D)), ((float)(632D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.hdrBg,
			this.beltPanel,
			this.lineBeltDiv,
			this.lblTitle,
			this.lblSubtitle,
			this.lblBeltHeader,
			this.lblBeltMasterCap,
			this.lblBeltMasterHint,
			this.lblBeltA,
			this.lblBeltB,
			this.lblBeltC,
			this.lblBeltD,
			this.symRunBelts,
			this.symBeltA,
			this.symBeltB,
			this.symBeltC,
			this.symBeltD,
			this.cardBg1,
			this.cardHdr1,
			this.lineDiv1,
			this.lblStopHdr1,
			this.lblStopperCap1,
			this.lblModeCap1,
			this.lblTrayCap1,
			this.lblWpCap1,
			this.symStopper1,
			this.symPass1,
			this.symTray1,
			this.symWp1,
			this.cardBg2,
			this.cardHdr2,
			this.lineDiv2,
			this.lblStopHdr2,
			this.lblStopperCap2,
			this.lblModeCap2,
			this.lblTrayCap2,
			this.lblWpCap2,
			this.symStopper2,
			this.symPass2,
			this.symTray2,
			this.symWp2,
			this.cardBg3,
			this.cardHdr3,
			this.lineDiv3,
			this.lblStopHdr3,
			this.lblStopperCap3,
			this.lblModeCap3,
			this.lblTrayCap3,
			this.lblWpCap3,
			this.symStopper3,
			this.symPass3,
			this.symTray3,
			this.symWp3,
			this.cardBg4,
			this.cardHdr4,
			this.lineDiv4,
			this.lblStopHdr4,
			this.lblStopperCap4,
			this.lblModeCap4,
			this.lblTrayCap4,
			this.lblWpCap4,
			this.symStopper4,
			this.symPass4,
			this.symTray4,
			this.symWp4,
			this.cardBg5,
			this.cardHdr5,
			this.lineDiv5,
			this.lblStopHdr5,
			this.lblStopperCap5,
			this.lblModeCap5,
			this.lblTrayCap5,
			this.lblWpCap5,
			this.symStopper5,
			this.symPass5,
			this.symTray5,
			this.symWp5,
			this.cardBg6,
			this.cardHdr6,
			this.lineDiv6,
			this.lblStopHdr6,
			this.lblStopperCap6,
			this.lblModeCap6,
			this.lblTrayCap6,
			this.lblWpCap6,
			this.symStopper6,
			this.symPass6,
			this.symTray6,
			this.symWp6,
			this.alarmGrid1});
			this.Size = new System.Drawing.Size(1480, 632);
			this.Title = "Conveyor";
			((System.ComponentModel.ISupportInitialize)(this.alarmGrid1)).EndInit();

		}
		private NxtControl.GuiFramework.Rectangle hdrBg;
		private NxtControl.GuiFramework.Rectangle beltPanel;
		private NxtControl.GuiFramework.Line lineBeltDiv;
		private NxtControl.GuiFramework.Label lblTitle;
		private NxtControl.GuiFramework.Label lblSubtitle;
		private NxtControl.GuiFramework.Label lblBeltHeader;
		private NxtControl.GuiFramework.Label lblBeltMasterCap;
		private NxtControl.GuiFramework.Label lblBeltMasterHint;
		private NxtControl.GuiFramework.Label lblBeltA;
		private NxtControl.GuiFramework.Label lblBeltB;
		private NxtControl.GuiFramework.Label lblBeltC;
		private NxtControl.GuiFramework.Label lblBeltD;
		private SE.App2Base.Symbols.SetBool.sButton symRunBelts;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symBeltA;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symBeltB;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symBeltC;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symBeltD;
		private NxtControl.GuiFramework.Rectangle cardBg1;
		private NxtControl.GuiFramework.Rectangle cardHdr1;
		private NxtControl.GuiFramework.Line lineDiv1;
		private NxtControl.GuiFramework.Label lblStopHdr1;
		private NxtControl.GuiFramework.Label lblStopperCap1;
		private NxtControl.GuiFramework.Label lblModeCap1;
		private NxtControl.GuiFramework.Label lblTrayCap1;
		private NxtControl.GuiFramework.Label lblWpCap1;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symStopper1;
		private SE.App2Base.Symbols.SetBool.sButton symPass1;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symTray1;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWp1;
		private NxtControl.GuiFramework.Rectangle cardBg2;
		private NxtControl.GuiFramework.Rectangle cardHdr2;
		private NxtControl.GuiFramework.Line lineDiv2;
		private NxtControl.GuiFramework.Label lblStopHdr2;
		private NxtControl.GuiFramework.Label lblStopperCap2;
		private NxtControl.GuiFramework.Label lblModeCap2;
		private NxtControl.GuiFramework.Label lblTrayCap2;
		private NxtControl.GuiFramework.Label lblWpCap2;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symStopper2;
		private SE.App2Base.Symbols.SetBool.sButton symPass2;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symTray2;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWp2;
		private NxtControl.GuiFramework.Rectangle cardBg3;
		private NxtControl.GuiFramework.Rectangle cardHdr3;
		private NxtControl.GuiFramework.Line lineDiv3;
		private NxtControl.GuiFramework.Label lblStopHdr3;
		private NxtControl.GuiFramework.Label lblStopperCap3;
		private NxtControl.GuiFramework.Label lblModeCap3;
		private NxtControl.GuiFramework.Label lblTrayCap3;
		private NxtControl.GuiFramework.Label lblWpCap3;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symStopper3;
		private SE.App2Base.Symbols.SetBool.sButton symPass3;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symTray3;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWp3;
		private NxtControl.GuiFramework.Rectangle cardBg4;
		private NxtControl.GuiFramework.Rectangle cardHdr4;
		private NxtControl.GuiFramework.Line lineDiv4;
		private NxtControl.GuiFramework.Label lblStopHdr4;
		private NxtControl.GuiFramework.Label lblStopperCap4;
		private NxtControl.GuiFramework.Label lblModeCap4;
		private NxtControl.GuiFramework.Label lblTrayCap4;
		private NxtControl.GuiFramework.Label lblWpCap4;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symStopper4;
		private SE.App2Base.Symbols.SetBool.sButton symPass4;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symTray4;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWp4;
		private NxtControl.GuiFramework.Rectangle cardBg5;
		private NxtControl.GuiFramework.Rectangle cardHdr5;
		private NxtControl.GuiFramework.Line lineDiv5;
		private NxtControl.GuiFramework.Label lblStopHdr5;
		private NxtControl.GuiFramework.Label lblStopperCap5;
		private NxtControl.GuiFramework.Label lblModeCap5;
		private NxtControl.GuiFramework.Label lblTrayCap5;
		private NxtControl.GuiFramework.Label lblWpCap5;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symStopper5;
		private SE.App2Base.Symbols.SetBool.sButton symPass5;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symTray5;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWp5;
		private NxtControl.GuiFramework.Rectangle cardBg6;
		private NxtControl.GuiFramework.Rectangle cardHdr6;
		private NxtControl.GuiFramework.Line lineDiv6;
		private NxtControl.GuiFramework.Label lblStopHdr6;
		private NxtControl.GuiFramework.Label lblStopperCap6;
		private NxtControl.GuiFramework.Label lblModeCap6;
		private NxtControl.GuiFramework.Label lblTrayCap6;
		private NxtControl.GuiFramework.Label lblWpCap6;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault symStopper6;
		private SE.App2Base.Symbols.SetBool.sButton symPass6;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symTray6;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWp6;
		private NxtControl.GuiFramework.AlarmGrid alarmGrid1;
		#endregion
	}
}
