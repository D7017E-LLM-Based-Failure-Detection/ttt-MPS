/*
 * Created by EcoStruxure Automation Expert.
 * User:  
 * Date: 11/16/2026
 * Time: 2:29 PM
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
			this.hdrBackground = new NxtControl.GuiFramework.Rectangle();
			this.beltSectionBg = new NxtControl.GuiFramework.Rectangle();
			this.beltTrack = new NxtControl.GuiFramework.Rectangle();
			this.cardBg1 = new NxtControl.GuiFramework.Rectangle();
			this.cardBg2 = new NxtControl.GuiFramework.Rectangle();
			this.cardBg6 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr1 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr2 = new NxtControl.GuiFramework.Rectangle();
			this.cardHdr6 = new NxtControl.GuiFramework.Rectangle();
			this.lineDrop1 = new NxtControl.GuiFramework.Line();
			this.lineDrop2 = new NxtControl.GuiFramework.Line();
			this.lineDrop6 = new NxtControl.GuiFramework.Line();
			this.lineDiv1 = new NxtControl.GuiFramework.Line();
			this.lineDiv2 = new NxtControl.GuiFramework.Line();
			this.lineDiv6 = new NxtControl.GuiFramework.Line();
			this.lblTitle = new NxtControl.GuiFramework.Label();
			this.lblSubtitle = new NxtControl.GuiFramework.Label();
			this.lblBeltHeader = new NxtControl.GuiFramework.Label();
			this.lblFlowLeft = new NxtControl.GuiFramework.Label();
			this.lblBeltOrder = new NxtControl.GuiFramework.Label();
			this.lblBeltHint1 = new NxtControl.GuiFramework.Label();
			this.lblBeltHint2 = new NxtControl.GuiFramework.Label();
			this.lblStopHdr1 = new NxtControl.GuiFramework.Label();
			this.lblStopHdr2 = new NxtControl.GuiFramework.Label();
			this.lblStopHdr6 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap1 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap2 = new NxtControl.GuiFramework.Label();
			this.lblStopperCap6 = new NxtControl.GuiFramework.Label();
			this.lblSeqCap1 = new NxtControl.GuiFramework.Label();
			this.lblSeqCap2 = new NxtControl.GuiFramework.Label();
			this.lblSeqCap6 = new NxtControl.GuiFramework.Label();
			this.lblSeqHint1 = new NxtControl.GuiFramework.Label();
			this.lblSeqHint2 = new NxtControl.GuiFramework.Label();
			this.lblSeqHint6 = new NxtControl.GuiFramework.Label();
			this.lblPalletTitle1 = new NxtControl.GuiFramework.Label();
			this.lblPalletSub1 = new NxtControl.GuiFramework.Label();
			this.lblWpTitle1 = new NxtControl.GuiFramework.Label();
			this.lblWpSub1 = new NxtControl.GuiFramework.Label();
			this.lblRelTitle1 = new NxtControl.GuiFramework.Label();
			this.lblRelSub1 = new NxtControl.GuiFramework.Label();
			this.lblPalletTitle2 = new NxtControl.GuiFramework.Label();
			this.lblPalletSub2 = new NxtControl.GuiFramework.Label();
			this.lblWpTitle2 = new NxtControl.GuiFramework.Label();
			this.lblWpSub2 = new NxtControl.GuiFramework.Label();
			this.lblRelTitle2 = new NxtControl.GuiFramework.Label();
			this.lblRelSub2 = new NxtControl.GuiFramework.Label();
			this.lblPalletTitle6 = new NxtControl.GuiFramework.Label();
			this.lblPalletSub6 = new NxtControl.GuiFramework.Label();
			this.lblWpTitle6 = new NxtControl.GuiFramework.Label();
			this.lblWpSub6 = new NxtControl.GuiFramework.Label();
			this.lblRelTitle6 = new NxtControl.GuiFramework.Label();
			this.lblRelSub6 = new NxtControl.GuiFramework.Label();
			this.symBelt = new SE.App2CommonProcess.Symbols.Motor.sConveyor();
			this.symStopper1 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
			this.symStopper2 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
			this.symStopper6 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
			this.symReleaseSeq1 = new SE.AppSequence.Symbols.SeqHead.sHead();
			this.symReleaseSeq2 = new SE.AppSequence.Symbols.SeqHead.sHead();
			this.symReleaseSeq6 = new SE.AppSequence.Symbols.SeqHead.sHead();
			this.symPallet1 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWorkpiece1 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symReleaseReq1 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symPallet2 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWorkpiece2 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symReleaseReq2 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symPallet6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symWorkpiece6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.symReleaseReq6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			// 
			// hdrBackground
			// 
			this.hdrBackground.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(8D)), ((float)(1000D)), ((float)(40D)));
			this.hdrBackground.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(244)), ((byte)(248))));
			this.hdrBackground.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.hdrBackground.Name = "hdrBackground";
			this.hdrBackground.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(192)), ((byte)(202)), ((byte)(214))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// beltSectionBg
			// 
			this.beltSectionBg.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(56D)), ((float)(1000D)), ((float)(136D)));
			this.beltSectionBg.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.beltSectionBg.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.beltSectionBg.Name = "beltSectionBg";
			this.beltSectionBg.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(192)), ((byte)(202)), ((byte)(214))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// beltTrack
			// 
			this.beltTrack.Bounds = new NxtControl.Drawing.RectF(((float)(32D)), ((float)(88D)), ((float)(968D)), ((float)(92D)));
			this.beltTrack.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(226)), ((byte)(232)), ((byte)(240))));
			this.beltTrack.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.beltTrack.Name = "beltTrack";
			this.beltTrack.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(148)), ((byte)(160)), ((byte)(176))), 2F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardBg1
			// 
			this.cardBg1.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(208D)), ((float)(320D)), ((float)(416D)));
			this.cardBg1.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg1.Name = "cardBg1";
			this.cardBg1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardBg2
			// 
			this.cardBg2.Bounds = new NxtControl.Drawing.RectF(((float)(356D)), ((float)(208D)), ((float)(320D)), ((float)(416D)));
			this.cardBg2.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg2.Name = "cardBg2";
			this.cardBg2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardBg6
			// 
			this.cardBg6.Bounds = new NxtControl.Drawing.RectF(((float)(696D)), ((float)(208D)), ((float)(320D)), ((float)(416D)));
			this.cardBg6.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.cardBg6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardBg6.Name = "cardBg6";
			this.cardBg6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr1
			// 
			this.cardHdr1.Bounds = new NxtControl.Drawing.RectF(((float)(16D)), ((float)(208D)), ((float)(320D)), ((float)(32D)));
			this.cardHdr1.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr1.Name = "cardHdr1";
			this.cardHdr1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr2
			// 
			this.cardHdr2.Bounds = new NxtControl.Drawing.RectF(((float)(356D)), ((float)(208D)), ((float)(320D)), ((float)(32D)));
			this.cardHdr2.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr2.Name = "cardHdr2";
			this.cardHdr2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// cardHdr6
			// 
			this.cardHdr6.Bounds = new NxtControl.Drawing.RectF(((float)(696D)), ((float)(208D)), ((float)(320D)), ((float)(32D)));
			this.cardHdr6.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(228)), ((byte)(235)), ((byte)(243))));
			this.cardHdr6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.cardHdr6.Name = "cardHdr6";
			this.cardHdr6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lineDrop1
			// 
			this.lineDrop1.EndPoint = new NxtControl.Drawing.PointF(176D, 208D);
			this.lineDrop1.Name = "lineDrop1";
			this.lineDrop1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(135)), ((byte)(148)), ((byte)(165))), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDrop1.StartPoint = new NxtControl.Drawing.PointF(176D, 180D);
			// 
			// lineDrop2
			// 
			this.lineDrop2.EndPoint = new NxtControl.Drawing.PointF(516D, 208D);
			this.lineDrop2.Name = "lineDrop2";
			this.lineDrop2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(135)), ((byte)(148)), ((byte)(165))), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDrop2.StartPoint = new NxtControl.Drawing.PointF(516D, 180D);
			// 
			// lineDrop6
			// 
			this.lineDrop6.EndPoint = new NxtControl.Drawing.PointF(856D, 208D);
			this.lineDrop6.Name = "lineDrop6";
			this.lineDrop6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(135)), ((byte)(148)), ((byte)(165))), 2F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDrop6.StartPoint = new NxtControl.Drawing.PointF(856D, 180D);
			// 
			// lineDiv1
			// 
			this.lineDiv1.EndPoint = new NxtControl.Drawing.PointF(322D, 394D);
			this.lineDiv1.Name = "lineDiv1";
			this.lineDiv1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv1.StartPoint = new NxtControl.Drawing.PointF(30D, 394D);
			// 
			// lineDiv2
			// 
			this.lineDiv2.EndPoint = new NxtControl.Drawing.PointF(662D, 394D);
			this.lineDiv2.Name = "lineDiv2";
			this.lineDiv2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv2.StartPoint = new NxtControl.Drawing.PointF(370D, 394D);
			// 
			// lineDiv6
			// 
			this.lineDiv6.EndPoint = new NxtControl.Drawing.PointF(1002D, 394D);
			this.lineDiv6.Name = "lineDiv6";
			this.lineDiv6.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(214)), ((byte)(222)), ((byte)(232))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.lineDiv6.StartPoint = new NxtControl.Drawing.PointF(710D, 394D);
			// 
			// lblTitle
			// 
			this.lblTitle.AngleIgnore = true;
			this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTitle.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(12D)), ((float)(520D)), ((float)(32D)));
			this.lblTitle.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblTitle.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 14F, System.Drawing.FontStyle.Bold);
			this.lblTitle.FontScale = true;
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblTitle.Text = "Conveyor Station (ConSys M251)";
			this.lblTitle.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.TextAutoSizeHorizontalOffset = 10;
			this.lblTitle.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblTitle.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSubtitle
			// 
			this.lblSubtitle.AngleIgnore = true;
			this.lblSubtitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSubtitle.Bounds = new NxtControl.Drawing.RectF(((float)(560D)), ((float)(14D)), ((float)(444D)), ((float)(28D)));
			this.lblSubtitle.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSubtitle.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Regular);
			this.lblSubtitle.FontScale = true;
			this.lblSubtitle.Name = "lblSubtitle";
			this.lblSubtitle.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSubtitle.Text = "Belt Motor + Active StopPoints: Stop1, Stop2, Stop6";
			this.lblSubtitle.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleRight;
			this.lblSubtitle.TextAutoSizeHorizontalOffset = 10;
			this.lblSubtitle.TextColor = new NxtControl.Drawing.Color(((byte)(85)), ((byte)(96)), ((byte)(112)));
			this.lblSubtitle.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltHeader
			// 
			this.lblBeltHeader.AngleIgnore = true;
			this.lblBeltHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltHeader.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(60D)), ((float)(340D)), ((float)(24D)));
			this.lblBeltHeader.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltHeader.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblBeltHeader.FontScale = true;
			this.lblBeltHeader.Name = "lblBeltHeader";
			this.lblBeltHeader.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltHeader.Text = "CONVEYOR BELT DRIVE (M1 DO02 / M2 DO01)";
			this.lblBeltHeader.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltHeader.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltHeader.TextColor = new NxtControl.Drawing.Color(((byte)(40)), ((byte)(52)), ((byte)(68)));
			this.lblBeltHeader.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblFlowLeft
			// 
			this.lblFlowLeft.AngleIgnore = true;
			this.lblFlowLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFlowLeft.Bounds = new NxtControl.Drawing.RectF(((float)(44D)), ((float)(114D)), ((float)(220D)), ((float)(24D)));
			this.lblFlowLeft.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblFlowLeft.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblFlowLeft.FontScale = true;
			this.lblFlowLeft.Name = "lblFlowLeft";
			this.lblFlowLeft.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblFlowLeft.Text = "Pallet Flow   >>>";
			this.lblFlowLeft.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblFlowLeft.TextAutoSizeHorizontalOffset = 10;
			this.lblFlowLeft.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(74)), ((byte)(92)));
			this.lblFlowLeft.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltOrder
			// 
			this.lblBeltOrder.AngleIgnore = true;
			this.lblBeltOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltOrder.Bounds = new NxtControl.Drawing.RectF(((float)(44D)), ((float)(140D)), ((float)(240D)), ((float)(22D)));
			this.lblBeltOrder.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltOrder.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
			this.lblBeltOrder.FontScale = true;
			this.lblBeltOrder.Name = "lblBeltOrder";
			this.lblBeltOrder.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltOrder.Text = "Stop 1  ->  Stop 2  ->  Stop 6";
			this.lblBeltOrder.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltOrder.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltOrder.TextColor = new NxtControl.Drawing.Color(((byte)(85)), ((byte)(96)), ((byte)(112)));
			this.lblBeltOrder.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltHint1
			// 
			this.lblBeltHint1.AngleIgnore = true;
			this.lblBeltHint1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltHint1.Bounds = new NxtControl.Drawing.RectF(((float)(616D)), ((float)(114D)), ((float)(372D)), ((float)(22D)));
			this.lblBeltHint1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltHint1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.lblBeltHint1.FontScale = true;
			this.lblBeltHint1.Name = "lblBeltHint1";
			this.lblBeltHint1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltHint1.Text = "Click Belt symbol to open Motor faceplate";
			this.lblBeltHint1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltHint1.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltHint1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblBeltHint1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblBeltHint2
			// 
			this.lblBeltHint2.AngleIgnore = true;
			this.lblBeltHint2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblBeltHint2.Bounds = new NxtControl.Drawing.RectF(((float)(616D)), ((float)(138D)), ((float)(372D)), ((float)(22D)));
			this.lblBeltHint2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblBeltHint2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
			this.lblBeltHint2.FontScale = true;
			this.lblBeltHint2.Name = "lblBeltHint2";
			this.lblBeltHint2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblBeltHint2.Text = "FbOverride=TRUE | Owner: Operator -> Run / Stop";
			this.lblBeltHint2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblBeltHint2.TextAutoSizeHorizontalOffset = 10;
			this.lblBeltHint2.TextColor = new NxtControl.Drawing.Color(((byte)(85)), ((byte)(96)), ((byte)(112)));
			this.lblBeltHint2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopHdr1
			// 
			this.lblStopHdr1.AngleIgnore = true;
			this.lblStopHdr1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr1.Bounds = new NxtControl.Drawing.RectF(((float)(24D)), ((float)(211D)), ((float)(304D)), ((float)(26D)));
			this.lblStopHdr1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr1.FontScale = true;
			this.lblStopHdr1.Name = "lblStopHdr1";
			this.lblStopHdr1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr1.Text = "Stop 1 — Station 1";
			this.lblStopHdr1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblStopHdr1.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr1.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopHdr2
			// 
			this.lblStopHdr2.AngleIgnore = true;
			this.lblStopHdr2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr2.Bounds = new NxtControl.Drawing.RectF(((float)(364D)), ((float)(211D)), ((float)(304D)), ((float)(26D)));
			this.lblStopHdr2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr2.FontScale = true;
			this.lblStopHdr2.Name = "lblStopHdr2";
			this.lblStopHdr2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr2.Text = "Stop 2 — Station 2";
			this.lblStopHdr2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblStopHdr2.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr2.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopHdr6
			// 
			this.lblStopHdr6.AngleIgnore = true;
			this.lblStopHdr6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopHdr6.Bounds = new NxtControl.Drawing.RectF(((float)(704D)), ((float)(211D)), ((float)(304D)), ((float)(26D)));
			this.lblStopHdr6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopHdr6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
			this.lblStopHdr6.FontScale = true;
			this.lblStopHdr6.Name = "lblStopHdr6";
			this.lblStopHdr6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopHdr6.Text = "Stop 6 — Station 6";
			this.lblStopHdr6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblStopHdr6.TextAutoSizeHorizontalOffset = 10;
			this.lblStopHdr6.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblStopHdr6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap1
			// 
			this.lblStopperCap1.AngleIgnore = true;
			this.lblStopperCap1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap1.Bounds = new NxtControl.Drawing.RectF(((float)(28D)), ((float)(246D)), ((float)(144D)), ((float)(20D)));
			this.lblStopperCap1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap1.FontScale = true;
			this.lblStopperCap1.Name = "lblStopperCap1";
			this.lblStopperCap1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap1.Text = "Stopper (FbMode=1)";
			this.lblStopperCap1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblStopperCap1.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap1.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(72)), ((byte)(88)));
			this.lblStopperCap1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap2
			// 
			this.lblStopperCap2.AngleIgnore = true;
			this.lblStopperCap2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap2.Bounds = new NxtControl.Drawing.RectF(((float)(368D)), ((float)(246D)), ((float)(144D)), ((float)(20D)));
			this.lblStopperCap2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap2.FontScale = true;
			this.lblStopperCap2.Name = "lblStopperCap2";
			this.lblStopperCap2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap2.Text = "Stopper (FbMode=1)";
			this.lblStopperCap2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblStopperCap2.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap2.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(72)), ((byte)(88)));
			this.lblStopperCap2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblStopperCap6
			// 
			this.lblStopperCap6.AngleIgnore = true;
			this.lblStopperCap6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStopperCap6.Bounds = new NxtControl.Drawing.RectF(((float)(708D)), ((float)(246D)), ((float)(144D)), ((float)(20D)));
			this.lblStopperCap6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblStopperCap6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblStopperCap6.FontScale = true;
			this.lblStopperCap6.Name = "lblStopperCap6";
			this.lblStopperCap6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStopperCap6.Text = "Stopper (FbMode=1)";
			this.lblStopperCap6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblStopperCap6.TextAutoSizeHorizontalOffset = 10;
			this.lblStopperCap6.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(72)), ((byte)(88)));
			this.lblStopperCap6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSeqCap1
			// 
			this.lblSeqCap1.AngleIgnore = true;
			this.lblSeqCap1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSeqCap1.Bounds = new NxtControl.Drawing.RectF(((float)(180D)), ((float)(246D)), ((float)(144D)), ((float)(20D)));
			this.lblSeqCap1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSeqCap1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblSeqCap1.FontScale = true;
			this.lblSeqCap1.Name = "lblSeqCap1";
			this.lblSeqCap1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSeqCap1.Text = "ReleaseSeq";
			this.lblSeqCap1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblSeqCap1.TextAutoSizeHorizontalOffset = 10;
			this.lblSeqCap1.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(72)), ((byte)(88)));
			this.lblSeqCap1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSeqCap2
			// 
			this.lblSeqCap2.AngleIgnore = true;
			this.lblSeqCap2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSeqCap2.Bounds = new NxtControl.Drawing.RectF(((float)(520D)), ((float)(246D)), ((float)(144D)), ((float)(20D)));
			this.lblSeqCap2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSeqCap2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblSeqCap2.FontScale = true;
			this.lblSeqCap2.Name = "lblSeqCap2";
			this.lblSeqCap2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSeqCap2.Text = "ReleaseSeq";
			this.lblSeqCap2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblSeqCap2.TextAutoSizeHorizontalOffset = 10;
			this.lblSeqCap2.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(72)), ((byte)(88)));
			this.lblSeqCap2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSeqCap6
			// 
			this.lblSeqCap6.AngleIgnore = true;
			this.lblSeqCap6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSeqCap6.Bounds = new NxtControl.Drawing.RectF(((float)(860D)), ((float)(246D)), ((float)(144D)), ((float)(20D)));
			this.lblSeqCap6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSeqCap6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
			this.lblSeqCap6.FontScale = true;
			this.lblSeqCap6.Name = "lblSeqCap6";
			this.lblSeqCap6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSeqCap6.Text = "ReleaseSeq";
			this.lblSeqCap6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblSeqCap6.TextAutoSizeHorizontalOffset = 10;
			this.lblSeqCap6.TextColor = new NxtControl.Drawing.Color(((byte)(60)), ((byte)(72)), ((byte)(88)));
			this.lblSeqCap6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSeqHint1
			// 
			this.lblSeqHint1.AngleIgnore = true;
			this.lblSeqHint1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSeqHint1.Bounds = new NxtControl.Drawing.RectF(((float)(180D)), ((float)(356D)), ((float)(144D)), ((float)(20D)));
			this.lblSeqHint1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSeqHint1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblSeqHint1.FontScale = true;
			this.lblSeqHint1.Name = "lblSeqHint1";
			this.lblSeqHint1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSeqHint1.Text = "Looping (P1..P6 -> P2)";
			this.lblSeqHint1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblSeqHint1.TextAutoSizeHorizontalOffset = 10;
			this.lblSeqHint1.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblSeqHint1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSeqHint2
			// 
			this.lblSeqHint2.AngleIgnore = true;
			this.lblSeqHint2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSeqHint2.Bounds = new NxtControl.Drawing.RectF(((float)(520D)), ((float)(356D)), ((float)(144D)), ((float)(20D)));
			this.lblSeqHint2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSeqHint2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblSeqHint2.FontScale = true;
			this.lblSeqHint2.Name = "lblSeqHint2";
			this.lblSeqHint2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSeqHint2.Text = "Looping (P1..P6 -> P2)";
			this.lblSeqHint2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblSeqHint2.TextAutoSizeHorizontalOffset = 10;
			this.lblSeqHint2.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblSeqHint2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblSeqHint6
			// 
			this.lblSeqHint6.AngleIgnore = true;
			this.lblSeqHint6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSeqHint6.Bounds = new NxtControl.Drawing.RectF(((float)(860D)), ((float)(356D)), ((float)(144D)), ((float)(20D)));
			this.lblSeqHint6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblSeqHint6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblSeqHint6.FontScale = true;
			this.lblSeqHint6.Name = "lblSeqHint6";
			this.lblSeqHint6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblSeqHint6.Text = "Looping (P1..P6 -> P2)";
			this.lblSeqHint6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.lblSeqHint6.TextAutoSizeHorizontalOffset = 10;
			this.lblSeqHint6.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblSeqHint6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblPalletTitle1
			// 
			this.lblPalletTitle1.AngleIgnore = true;
			this.lblPalletTitle1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPalletTitle1.Bounds = new NxtControl.Drawing.RectF(((float)(30D)), ((float)(412D)), ((float)(134D)), ((float)(22D)));
			this.lblPalletTitle1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblPalletTitle1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblPalletTitle1.FontScale = true;
			this.lblPalletTitle1.Name = "lblPalletTitle1";
			this.lblPalletTitle1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblPalletTitle1.Text = "Pallet (DI)";
			this.lblPalletTitle1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletTitle1.TextAutoSizeHorizontalOffset = 10;
			this.lblPalletTitle1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblPalletTitle1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblPalletSub1
			// 
			this.lblPalletSub1.AngleIgnore = true;
			this.lblPalletSub1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPalletSub1.Bounds = new NxtControl.Drawing.RectF(((float)(30D)), ((float)(434D)), ((float)(134D)), ((float)(20D)));
			this.lblPalletSub1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblPalletSub1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblPalletSub1.FontScale = true;
			this.lblPalletSub1.Name = "lblPalletSub1";
			this.lblPalletSub1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblPalletSub1.Text = "Pallet at stopper";
			this.lblPalletSub1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletSub1.TextAutoSizeHorizontalOffset = 10;
			this.lblPalletSub1.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblPalletSub1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpTitle1
			// 
			this.lblWpTitle1.AngleIgnore = true;
			this.lblWpTitle1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpTitle1.Bounds = new NxtControl.Drawing.RectF(((float)(30D)), ((float)(484D)), ((float)(134D)), ((float)(22D)));
			this.lblWpTitle1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpTitle1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblWpTitle1.FontScale = true;
			this.lblWpTitle1.Name = "lblWpTitle1";
			this.lblWpTitle1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpTitle1.Text = "Workpiece (DI)";
			this.lblWpTitle1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpTitle1.TextAutoSizeHorizontalOffset = 10;
			this.lblWpTitle1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpTitle1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpSub1
			// 
			this.lblWpSub1.AngleIgnore = true;
			this.lblWpSub1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpSub1.Bounds = new NxtControl.Drawing.RectF(((float)(30D)), ((float)(506D)), ((float)(134D)), ((float)(20D)));
			this.lblWpSub1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpSub1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblWpSub1.FontScale = true;
			this.lblWpSub1.Name = "lblWpSub1";
			this.lblWpSub1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpSub1.Text = "Part present (v1 idle)";
			this.lblWpSub1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpSub1.TextAutoSizeHorizontalOffset = 10;
			this.lblWpSub1.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblWpSub1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblRelTitle1
			// 
			this.lblRelTitle1.AngleIgnore = true;
			this.lblRelTitle1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRelTitle1.Bounds = new NxtControl.Drawing.RectF(((float)(30D)), ((float)(556D)), ((float)(134D)), ((float)(22D)));
			this.lblRelTitle1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblRelTitle1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblRelTitle1.FontScale = true;
			this.lblRelTitle1.Name = "lblRelTitle1";
			this.lblRelTitle1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblRelTitle1.Text = "ReleaseReq (DI)";
			this.lblRelTitle1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblRelTitle1.TextAutoSizeHorizontalOffset = 10;
			this.lblRelTitle1.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblRelTitle1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblRelSub1
			// 
			this.lblRelSub1.AngleIgnore = true;
			this.lblRelSub1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRelSub1.Bounds = new NxtControl.Drawing.RectF(((float)(30D)), ((float)(578D)), ((float)(134D)), ((float)(20D)));
			this.lblRelSub1.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblRelSub1.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblRelSub1.FontScale = true;
			this.lblRelSub1.Name = "lblRelSub1";
			this.lblRelSub1.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblRelSub1.Text = "Override True = release";
			this.lblRelSub1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblRelSub1.TextAutoSizeHorizontalOffset = 10;
			this.lblRelSub1.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblRelSub1.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblPalletTitle2
			// 
			this.lblPalletTitle2.AngleIgnore = true;
			this.lblPalletTitle2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPalletTitle2.Bounds = new NxtControl.Drawing.RectF(((float)(370D)), ((float)(412D)), ((float)(134D)), ((float)(22D)));
			this.lblPalletTitle2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblPalletTitle2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblPalletTitle2.FontScale = true;
			this.lblPalletTitle2.Name = "lblPalletTitle2";
			this.lblPalletTitle2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblPalletTitle2.Text = "Pallet (DI)";
			this.lblPalletTitle2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletTitle2.TextAutoSizeHorizontalOffset = 10;
			this.lblPalletTitle2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblPalletTitle2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblPalletSub2
			// 
			this.lblPalletSub2.AngleIgnore = true;
			this.lblPalletSub2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPalletSub2.Bounds = new NxtControl.Drawing.RectF(((float)(370D)), ((float)(434D)), ((float)(134D)), ((float)(20D)));
			this.lblPalletSub2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblPalletSub2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblPalletSub2.FontScale = true;
			this.lblPalletSub2.Name = "lblPalletSub2";
			this.lblPalletSub2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblPalletSub2.Text = "Pallet at stopper";
			this.lblPalletSub2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletSub2.TextAutoSizeHorizontalOffset = 10;
			this.lblPalletSub2.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblPalletSub2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpTitle2
			// 
			this.lblWpTitle2.AngleIgnore = true;
			this.lblWpTitle2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpTitle2.Bounds = new NxtControl.Drawing.RectF(((float)(370D)), ((float)(484D)), ((float)(134D)), ((float)(22D)));
			this.lblWpTitle2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpTitle2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblWpTitle2.FontScale = true;
			this.lblWpTitle2.Name = "lblWpTitle2";
			this.lblWpTitle2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpTitle2.Text = "Workpiece (DI)";
			this.lblWpTitle2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpTitle2.TextAutoSizeHorizontalOffset = 10;
			this.lblWpTitle2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpTitle2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpSub2
			// 
			this.lblWpSub2.AngleIgnore = true;
			this.lblWpSub2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpSub2.Bounds = new NxtControl.Drawing.RectF(((float)(370D)), ((float)(506D)), ((float)(134D)), ((float)(20D)));
			this.lblWpSub2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpSub2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblWpSub2.FontScale = true;
			this.lblWpSub2.Name = "lblWpSub2";
			this.lblWpSub2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpSub2.Text = "Part present (v1 idle)";
			this.lblWpSub2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpSub2.TextAutoSizeHorizontalOffset = 10;
			this.lblWpSub2.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblWpSub2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblRelTitle2
			// 
			this.lblRelTitle2.AngleIgnore = true;
			this.lblRelTitle2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRelTitle2.Bounds = new NxtControl.Drawing.RectF(((float)(370D)), ((float)(556D)), ((float)(134D)), ((float)(22D)));
			this.lblRelTitle2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblRelTitle2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblRelTitle2.FontScale = true;
			this.lblRelTitle2.Name = "lblRelTitle2";
			this.lblRelTitle2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblRelTitle2.Text = "ReleaseReq (DI)";
			this.lblRelTitle2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblRelTitle2.TextAutoSizeHorizontalOffset = 10;
			this.lblRelTitle2.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblRelTitle2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblRelSub2
			// 
			this.lblRelSub2.AngleIgnore = true;
			this.lblRelSub2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRelSub2.Bounds = new NxtControl.Drawing.RectF(((float)(370D)), ((float)(578D)), ((float)(134D)), ((float)(20D)));
			this.lblRelSub2.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblRelSub2.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblRelSub2.FontScale = true;
			this.lblRelSub2.Name = "lblRelSub2";
			this.lblRelSub2.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblRelSub2.Text = "Override True = release";
			this.lblRelSub2.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblRelSub2.TextAutoSizeHorizontalOffset = 10;
			this.lblRelSub2.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblRelSub2.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblPalletTitle6
			// 
			this.lblPalletTitle6.AngleIgnore = true;
			this.lblPalletTitle6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPalletTitle6.Bounds = new NxtControl.Drawing.RectF(((float)(710D)), ((float)(412D)), ((float)(134D)), ((float)(22D)));
			this.lblPalletTitle6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblPalletTitle6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblPalletTitle6.FontScale = true;
			this.lblPalletTitle6.Name = "lblPalletTitle6";
			this.lblPalletTitle6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblPalletTitle6.Text = "Pallet (DI)";
			this.lblPalletTitle6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletTitle6.TextAutoSizeHorizontalOffset = 10;
			this.lblPalletTitle6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblPalletTitle6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblPalletSub6
			// 
			this.lblPalletSub6.AngleIgnore = true;
			this.lblPalletSub6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPalletSub6.Bounds = new NxtControl.Drawing.RectF(((float)(710D)), ((float)(434D)), ((float)(134D)), ((float)(20D)));
			this.lblPalletSub6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblPalletSub6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblPalletSub6.FontScale = true;
			this.lblPalletSub6.Name = "lblPalletSub6";
			this.lblPalletSub6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblPalletSub6.Text = "Pallet at stopper";
			this.lblPalletSub6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletSub6.TextAutoSizeHorizontalOffset = 10;
			this.lblPalletSub6.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblPalletSub6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpTitle6
			// 
			this.lblWpTitle6.AngleIgnore = true;
			this.lblWpTitle6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpTitle6.Bounds = new NxtControl.Drawing.RectF(((float)(710D)), ((float)(484D)), ((float)(134D)), ((float)(22D)));
			this.lblWpTitle6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpTitle6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblWpTitle6.FontScale = true;
			this.lblWpTitle6.Name = "lblWpTitle6";
			this.lblWpTitle6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpTitle6.Text = "Workpiece (DI)";
			this.lblWpTitle6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpTitle6.TextAutoSizeHorizontalOffset = 10;
			this.lblWpTitle6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblWpTitle6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblWpSub6
			// 
			this.lblWpSub6.AngleIgnore = true;
			this.lblWpSub6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblWpSub6.Bounds = new NxtControl.Drawing.RectF(((float)(710D)), ((float)(506D)), ((float)(134D)), ((float)(20D)));
			this.lblWpSub6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblWpSub6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblWpSub6.FontScale = true;
			this.lblWpSub6.Name = "lblWpSub6";
			this.lblWpSub6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblWpSub6.Text = "Part present (v1 idle)";
			this.lblWpSub6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblWpSub6.TextAutoSizeHorizontalOffset = 10;
			this.lblWpSub6.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblWpSub6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblRelTitle6
			// 
			this.lblRelTitle6.AngleIgnore = true;
			this.lblRelTitle6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRelTitle6.Bounds = new NxtControl.Drawing.RectF(((float)(710D)), ((float)(556D)), ((float)(134D)), ((float)(22D)));
			this.lblRelTitle6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblRelTitle6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
			this.lblRelTitle6.FontScale = true;
			this.lblRelTitle6.Name = "lblRelTitle6";
			this.lblRelTitle6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblRelTitle6.Text = "ReleaseReq (DI)";
			this.lblRelTitle6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblRelTitle6.TextAutoSizeHorizontalOffset = 10;
			this.lblRelTitle6.TextColor = new NxtControl.Drawing.Color(((byte)(45)), ((byte)(58)), ((byte)(76)));
			this.lblRelTitle6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblRelSub6
			// 
			this.lblRelSub6.AngleIgnore = true;
			this.lblRelSub6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRelSub6.Bounds = new NxtControl.Drawing.RectF(((float)(710D)), ((float)(578D)), ((float)(134D)), ((float)(20D)));
			this.lblRelSub6.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblRelSub6.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8F, System.Drawing.FontStyle.Regular);
			this.lblRelSub6.FontScale = true;
			this.lblRelSub6.Name = "lblRelSub6";
			this.lblRelSub6.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblRelSub6.Text = "Override True = release";
			this.lblRelSub6.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblRelSub6.TextAutoSizeHorizontalOffset = 10;
			this.lblRelSub6.TextColor = new NxtControl.Drawing.Color(((byte)(95)), ((byte)(106)), ((byte)(122)));
			this.lblRelSub6.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symBelt
			// 
			this.symBelt.BeginInit();
			this.symBelt.DefaultInstanceName = null;
			this.symBelt.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.1D, 0D, 0D, 0.95D, 434D, 76D);
			this.symBelt.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symBelt.MyTagDisplayName = null;
			this.symBelt.Name = "symBelt";
			this.symBelt.SecurityToken = ((uint)(4294967295u));
			this.symBelt.TagName = "F8F802AB3B2841F2.Belt";
			this.symBelt.EndInit();
			// 
			// symStopper1
			// 
			this.symStopper1.BeginInit();
			this.symStopper1.DefaultInstanceName = null;
			this.symStopper1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.25D, 0D, 0D, 1.25D, 18D, 254D);
			this.symStopper1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper1.MyTagDisplayName = null;
			this.symStopper1.Name = "symStopper1";
			this.symStopper1.SecurityToken = ((uint)(4294967295u));
			this.symStopper1.TagName = "F8F802AB3B2841F2.Stop1.Stopper";
			this.symStopper1.EndInit();
			// 
			// symStopper2
			// 
			this.symStopper2.BeginInit();
			this.symStopper2.DefaultInstanceName = null;
			this.symStopper2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.25D, 0D, 0D, 1.25D, 358D, 254D);
			this.symStopper2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper2.MyTagDisplayName = null;
			this.symStopper2.Name = "symStopper2";
			this.symStopper2.SecurityToken = ((uint)(4294967295u));
			this.symStopper2.TagName = "F8F802AB3B2841F2.Stop2.Stopper";
			this.symStopper2.EndInit();
			// 
			// symStopper6
			// 
			this.symStopper6.BeginInit();
			this.symStopper6.DefaultInstanceName = null;
			this.symStopper6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.25D, 0D, 0D, 1.25D, 698D, 254D);
			this.symStopper6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symStopper6.MyTagDisplayName = null;
			this.symStopper6.Name = "symStopper6";
			this.symStopper6.SecurityToken = ((uint)(4294967295u));
			this.symStopper6.TagName = "F8F802AB3B2841F2.Stop6.Stopper";
			this.symStopper6.EndInit();
			// 
			// symReleaseSeq1
			// 
			this.symReleaseSeq1.ActiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.symReleaseSeq1.CompletedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.CompletedBrush");
			this.symReleaseSeq1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 194D, 266D);
			this.symReleaseSeq1.HodBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq1.Name = "symReleaseSeq1";
			this.symReleaseSeq1.PassiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq1.PausedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq1.PausingBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.symReleaseSeq1.SecOwner = 3;
			this.symReleaseSeq1.SecSetpoint = 3;
			this.symReleaseSeq1.SecurityToken = ((uint)(4294967175u));
			this.symReleaseSeq1.StepName = "Stop1";
			this.symReleaseSeq1.TagName = "F8F802AB3B2841F2.Stop1.ReleaseSeq";
			// 
			// symReleaseSeq2
			// 
			this.symReleaseSeq2.ActiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.symReleaseSeq2.CompletedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.CompletedBrush");
			this.symReleaseSeq2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 534D, 266D);
			this.symReleaseSeq2.HodBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq2.Name = "symReleaseSeq2";
			this.symReleaseSeq2.PassiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq2.PausedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq2.PausingBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.symReleaseSeq2.SecOwner = 3;
			this.symReleaseSeq2.SecSetpoint = 3;
			this.symReleaseSeq2.SecurityToken = ((uint)(4294967175u));
			this.symReleaseSeq2.StepName = "Stop2";
			this.symReleaseSeq2.TagName = "F8F802AB3B2841F2.Stop2.ReleaseSeq";
			// 
			// symReleaseSeq6
			// 
			this.symReleaseSeq6.ActiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.symReleaseSeq6.CompletedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.CompletedBrush");
			this.symReleaseSeq6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 874D, 266D);
			this.symReleaseSeq6.HodBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq6.Name = "symReleaseSeq6";
			this.symReleaseSeq6.PassiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq6.PausedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.symReleaseSeq6.PausingBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.symReleaseSeq6.SecOwner = 3;
			this.symReleaseSeq6.SecSetpoint = 3;
			this.symReleaseSeq6.SecurityToken = ((uint)(4294967175u));
			this.symReleaseSeq6.StepName = "Stop6";
			this.symReleaseSeq6.TagName = "F8F802AB3B2841F2.Stop6.ReleaseSeq";
			// 
			// symPallet1
			// 
			this.symPallet1.BeginInit();
			this.symPallet1.DefaultInstanceName = null;
			this.symPallet1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 168D, 404D);
			this.symPallet1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symPallet1.FalseText = "TxtOFF";
			this.symPallet1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPallet1.MyTagDisplayName = null;
			this.symPallet1.Name = "symPallet1";
			this.symPallet1.SecurityToken = ((uint)(4294967295u));
			this.symPallet1.TagName = "F8F802AB3B2841F2.Stop1.Pallet";
			this.symPallet1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symPallet1.TrueText = "TxtON";
			this.symPallet1.EndInit();
			// 
			// symWorkpiece1
			// 
			this.symWorkpiece1.BeginInit();
			this.symWorkpiece1.DefaultInstanceName = null;
			this.symWorkpiece1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 168D, 476D);
			this.symWorkpiece1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWorkpiece1.FalseText = "TxtOFF";
			this.symWorkpiece1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWorkpiece1.MyTagDisplayName = null;
			this.symWorkpiece1.Name = "symWorkpiece1";
			this.symWorkpiece1.SecurityToken = ((uint)(4294967295u));
			this.symWorkpiece1.TagName = "F8F802AB3B2841F2.Stop1.Workpiece";
			this.symWorkpiece1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWorkpiece1.TrueText = "TxtON";
			this.symWorkpiece1.EndInit();
			// 
			// symReleaseReq1
			// 
			this.symReleaseReq1.BeginInit();
			this.symReleaseReq1.DefaultInstanceName = null;
			this.symReleaseReq1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 168D, 548D);
			this.symReleaseReq1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symReleaseReq1.FalseText = "TxtOFF";
			this.symReleaseReq1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symReleaseReq1.MyTagDisplayName = null;
			this.symReleaseReq1.Name = "symReleaseReq1";
			this.symReleaseReq1.SecurityToken = ((uint)(4294967295u));
			this.symReleaseReq1.TagName = "F8F802AB3B2841F2.Stop1.ReleaseReq";
			this.symReleaseReq1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symReleaseReq1.TrueText = "TxtON";
			this.symReleaseReq1.EndInit();
			// 
			// symPallet2
			// 
			this.symPallet2.BeginInit();
			this.symPallet2.DefaultInstanceName = null;
			this.symPallet2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 508D, 404D);
			this.symPallet2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symPallet2.FalseText = "TxtOFF";
			this.symPallet2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPallet2.MyTagDisplayName = null;
			this.symPallet2.Name = "symPallet2";
			this.symPallet2.SecurityToken = ((uint)(4294967295u));
			this.symPallet2.TagName = "F8F802AB3B2841F2.Stop2.Pallet";
			this.symPallet2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symPallet2.TrueText = "TxtON";
			this.symPallet2.EndInit();
			// 
			// symWorkpiece2
			// 
			this.symWorkpiece2.BeginInit();
			this.symWorkpiece2.DefaultInstanceName = null;
			this.symWorkpiece2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 508D, 476D);
			this.symWorkpiece2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWorkpiece2.FalseText = "TxtOFF";
			this.symWorkpiece2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWorkpiece2.MyTagDisplayName = null;
			this.symWorkpiece2.Name = "symWorkpiece2";
			this.symWorkpiece2.SecurityToken = ((uint)(4294967295u));
			this.symWorkpiece2.TagName = "F8F802AB3B2841F2.Stop2.Workpiece";
			this.symWorkpiece2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWorkpiece2.TrueText = "TxtON";
			this.symWorkpiece2.EndInit();
			// 
			// symReleaseReq2
			// 
			this.symReleaseReq2.BeginInit();
			this.symReleaseReq2.DefaultInstanceName = null;
			this.symReleaseReq2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 508D, 548D);
			this.symReleaseReq2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symReleaseReq2.FalseText = "TxtOFF";
			this.symReleaseReq2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symReleaseReq2.MyTagDisplayName = null;
			this.symReleaseReq2.Name = "symReleaseReq2";
			this.symReleaseReq2.SecurityToken = ((uint)(4294967295u));
			this.symReleaseReq2.TagName = "F8F802AB3B2841F2.Stop2.ReleaseReq";
			this.symReleaseReq2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symReleaseReq2.TrueText = "TxtON";
			this.symReleaseReq2.EndInit();
			// 
			// symPallet6
			// 
			this.symPallet6.BeginInit();
			this.symPallet6.DefaultInstanceName = null;
			this.symPallet6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 848D, 404D);
			this.symPallet6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symPallet6.FalseText = "TxtOFF";
			this.symPallet6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symPallet6.MyTagDisplayName = null;
			this.symPallet6.Name = "symPallet6";
			this.symPallet6.SecurityToken = ((uint)(4294967295u));
			this.symPallet6.TagName = "F8F802AB3B2841F2.Stop6.Pallet";
			this.symPallet6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symPallet6.TrueText = "TxtON";
			this.symPallet6.EndInit();
			// 
			// symWorkpiece6
			// 
			this.symWorkpiece6.BeginInit();
			this.symWorkpiece6.DefaultInstanceName = null;
			this.symWorkpiece6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 848D, 476D);
			this.symWorkpiece6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symWorkpiece6.FalseText = "TxtOFF";
			this.symWorkpiece6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symWorkpiece6.MyTagDisplayName = null;
			this.symWorkpiece6.Name = "symWorkpiece6";
			this.symWorkpiece6.SecurityToken = ((uint)(4294967295u));
			this.symWorkpiece6.TagName = "F8F802AB3B2841F2.Stop6.Workpiece";
			this.symWorkpiece6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symWorkpiece6.TrueText = "TxtON";
			this.symWorkpiece6.EndInit();
			// 
			// symReleaseReq6
			// 
			this.symReleaseReq6.BeginInit();
			this.symReleaseReq6.DefaultInstanceName = null;
			this.symReleaseReq6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 848D, 548D);
			this.symReleaseReq6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.symReleaseReq6.FalseText = "TxtOFF";
			this.symReleaseReq6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symReleaseReq6.MyTagDisplayName = null;
			this.symReleaseReq6.Name = "symReleaseReq6";
			this.symReleaseReq6.SecurityToken = ((uint)(4294967295u));
			this.symReleaseReq6.TagName = "F8F802AB3B2841F2.Stop6.ReleaseReq";
			this.symReleaseReq6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.symReleaseReq6.TrueText = "TxtON";
			this.symReleaseReq6.EndInit();
			// 
			// Conveyor
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1032D)), ((float)(640D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Name = "Conveyor";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.hdrBackground,
			this.beltSectionBg,
			this.beltTrack,
			this.cardBg1,
			this.cardBg2,
			this.cardBg6,
			this.cardHdr1,
			this.cardHdr2,
			this.cardHdr6,
			this.lineDrop1,
			this.lineDrop2,
			this.lineDrop6,
			this.lineDiv1,
			this.lineDiv2,
			this.lineDiv6,
			this.lblTitle,
			this.lblSubtitle,
			this.lblBeltHeader,
			this.lblFlowLeft,
			this.lblBeltOrder,
			this.lblBeltHint1,
			this.lblBeltHint2,
			this.lblStopHdr1,
			this.lblStopHdr2,
			this.lblStopHdr6,
			this.lblStopperCap1,
			this.lblStopperCap2,
			this.lblStopperCap6,
			this.lblSeqCap1,
			this.lblSeqCap2,
			this.lblSeqCap6,
			this.lblSeqHint1,
			this.lblSeqHint2,
			this.lblSeqHint6,
			this.lblPalletTitle1,
			this.lblPalletSub1,
			this.lblWpTitle1,
			this.lblWpSub1,
			this.lblRelTitle1,
			this.lblRelSub1,
			this.lblPalletTitle2,
			this.lblPalletSub2,
			this.lblWpTitle2,
			this.lblWpSub2,
			this.lblRelTitle2,
			this.lblRelSub2,
			this.lblPalletTitle6,
			this.lblPalletSub6,
			this.lblWpTitle6,
			this.lblWpSub6,
			this.lblRelTitle6,
			this.lblRelSub6,
			this.symBelt,
			this.symStopper1,
			this.symStopper2,
			this.symStopper6,
			this.symReleaseSeq1,
			this.symReleaseSeq2,
			this.symReleaseSeq6,
			this.symPallet1,
			this.symWorkpiece1,
			this.symReleaseReq1,
			this.symPallet2,
			this.symWorkpiece2,
			this.symReleaseReq2,
			this.symPallet6,
			this.symWorkpiece6,
			this.symReleaseReq6});
			this.Size = new System.Drawing.Size(1032, 640);
			this.Title = "Conveyor";
		}
		private NxtControl.GuiFramework.Rectangle hdrBackground;
		private NxtControl.GuiFramework.Rectangle beltSectionBg;
		private NxtControl.GuiFramework.Rectangle beltTrack;
		private NxtControl.GuiFramework.Rectangle cardBg1;
		private NxtControl.GuiFramework.Rectangle cardBg2;
		private NxtControl.GuiFramework.Rectangle cardBg6;
		private NxtControl.GuiFramework.Rectangle cardHdr1;
		private NxtControl.GuiFramework.Rectangle cardHdr2;
		private NxtControl.GuiFramework.Rectangle cardHdr6;
		private NxtControl.GuiFramework.Line lineDrop1;
		private NxtControl.GuiFramework.Line lineDrop2;
		private NxtControl.GuiFramework.Line lineDrop6;
		private NxtControl.GuiFramework.Line lineDiv1;
		private NxtControl.GuiFramework.Line lineDiv2;
		private NxtControl.GuiFramework.Line lineDiv6;
		private NxtControl.GuiFramework.Label lblTitle;
		private NxtControl.GuiFramework.Label lblSubtitle;
		private NxtControl.GuiFramework.Label lblBeltHeader;
		private NxtControl.GuiFramework.Label lblFlowLeft;
		private NxtControl.GuiFramework.Label lblBeltOrder;
		private NxtControl.GuiFramework.Label lblBeltHint1;
		private NxtControl.GuiFramework.Label lblBeltHint2;
		private NxtControl.GuiFramework.Label lblStopHdr1;
		private NxtControl.GuiFramework.Label lblStopHdr2;
		private NxtControl.GuiFramework.Label lblStopHdr6;
		private NxtControl.GuiFramework.Label lblStopperCap1;
		private NxtControl.GuiFramework.Label lblStopperCap2;
		private NxtControl.GuiFramework.Label lblStopperCap6;
		private NxtControl.GuiFramework.Label lblSeqCap1;
		private NxtControl.GuiFramework.Label lblSeqCap2;
		private NxtControl.GuiFramework.Label lblSeqCap6;
		private NxtControl.GuiFramework.Label lblSeqHint1;
		private NxtControl.GuiFramework.Label lblSeqHint2;
		private NxtControl.GuiFramework.Label lblSeqHint6;
		private NxtControl.GuiFramework.Label lblPalletTitle1;
		private NxtControl.GuiFramework.Label lblPalletSub1;
		private NxtControl.GuiFramework.Label lblWpTitle1;
		private NxtControl.GuiFramework.Label lblWpSub1;
		private NxtControl.GuiFramework.Label lblRelTitle1;
		private NxtControl.GuiFramework.Label lblRelSub1;
		private NxtControl.GuiFramework.Label lblPalletTitle2;
		private NxtControl.GuiFramework.Label lblPalletSub2;
		private NxtControl.GuiFramework.Label lblWpTitle2;
		private NxtControl.GuiFramework.Label lblWpSub2;
		private NxtControl.GuiFramework.Label lblRelTitle2;
		private NxtControl.GuiFramework.Label lblRelSub2;
		private NxtControl.GuiFramework.Label lblPalletTitle6;
		private NxtControl.GuiFramework.Label lblPalletSub6;
		private NxtControl.GuiFramework.Label lblWpTitle6;
		private NxtControl.GuiFramework.Label lblWpSub6;
		private NxtControl.GuiFramework.Label lblRelTitle6;
		private NxtControl.GuiFramework.Label lblRelSub6;
		private SE.App2CommonProcess.Symbols.Motor.sConveyor symBelt;
		private SE.App2CommonProcess.Symbols.Valve.sDefault symStopper1;
		private SE.App2CommonProcess.Symbols.Valve.sDefault symStopper2;
		private SE.App2CommonProcess.Symbols.Valve.sDefault symStopper6;
		private SE.AppSequence.Symbols.SeqHead.sHead symReleaseSeq1;
		private SE.AppSequence.Symbols.SeqHead.sHead symReleaseSeq2;
		private SE.AppSequence.Symbols.SeqHead.sHead symReleaseSeq6;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symPallet1;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWorkpiece1;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symReleaseReq1;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symPallet2;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWorkpiece2;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symReleaseReq2;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symPallet6;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symWorkpiece6;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault symReleaseReq6;
		#endregion
	}
}
