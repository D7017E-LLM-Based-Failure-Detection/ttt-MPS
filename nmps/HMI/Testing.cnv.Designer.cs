/*
 * Created by EcoStruxure Automation Expert.
 * User:  
 * Date: 11/20/2026
 * Time: 5:35 PM
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
	/// Summary description for Testing.
	/// </summary>
	partial class Testing
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sDefault1 = new SE.App2CommonProcess.Symbols.Valve2Op.sDefault();
			this.sDefault2 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
			this.sDefault3 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.sDefault4 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.sDefault5 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.sDefault6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.sDefault7 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.sHead1 = new SE.AppSequence.Symbols.SeqHead.sHead();
			this.sHead2 = new SE.AppSequence.Symbols.SeqHead.sHead();
			this.alarmGrid1 = new NxtControl.GuiFramework.AlarmGrid();
			this.autoPanel = new NxtControl.GuiFramework.Rectangle();
			this.lblAutoHeader = new NxtControl.GuiFramework.Label();
			this.lblAutoHint = new NxtControl.GuiFramework.Label();
			this.symAutoMode = new SE.App2Base.Symbols.SetBool.sButton();
			this.symAutoRelease = new SE.App2Base.Symbols.SetBool.sButton();
			((System.ComponentModel.ISupportInitialize)(this.alarmGrid1)).BeginInit();
			// 
			// sDefault1
			// 
			this.sDefault1.BeginInit();
			this.sDefault1.DefaultInstanceName = null;
			this.sDefault1.DesignMatrix = new NxtControl.Drawing.Matrix2D(2.0821917808219177D, 0D, 0D, 1.9047619047619047D, 28.493150684931507D, 48D);
			this.sDefault1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault1.MyTagDisplayName = null;
			this.sDefault1.Name = "sDefault1";
			this.sDefault1.SecurityToken = ((uint)(4294967295u));
			this.sDefault1.TagName = "248448E89426980E.Lift";
			this.sDefault1.EndInit();
			// 
			// sDefault2
			// 
			this.sDefault2.BeginInit();
			this.sDefault2.DefaultInstanceName = null;
			this.sDefault2.DesignMatrix = new NxtControl.Drawing.Matrix2D(2.3013698630136985D, 0D, 0D, 2D, 309.58904109589048D, 56D);
			this.sDefault2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault2.MyTagDisplayName = null;
			this.sDefault2.Name = "sDefault2";
			this.sDefault2.SecurityToken = ((uint)(4294967295u));
			this.sDefault2.TagName = "248448E89426980E.Ejector";
			this.sDefault2.EndInit();
			// 
			// sDefault3
			// 
			this.sDefault3.BeginInit();
			this.sDefault3.DefaultInstanceName = null;
			this.sDefault3.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 591D, 80D);
			this.sDefault3.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault3.FalseText = "TxtOFF";
			this.sDefault3.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault3.MyTagDisplayName = null;
			this.sDefault3.Name = "sDefault3";
			this.sDefault3.SecurityToken = ((uint)(4294967295u));
			this.sDefault3.TagName = "248448E89426980E.AirSlide";
			this.sDefault3.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault3.TrueText = "TxtON";
			this.sDefault3.EndInit();
			// 
			// sDefault4
			// 
			this.sDefault4.BeginInit();
			this.sDefault4.DefaultInstanceName = null;
			this.sDefault4.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 16D, 264D);
			this.sDefault4.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault4.FalseText = "TxtOFF";
			this.sDefault4.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault4.MyTagDisplayName = null;
			this.sDefault4.Name = "sDefault4";
			this.sDefault4.SecurityToken = ((uint)(4294967295u));
			this.sDefault4.TagName = "248448E89426980E.PartAvailable";
			this.sDefault4.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault4.TrueText = "TxtON";
			this.sDefault4.EndInit();
			// 
			// sDefault5
			// 
			this.sDefault5.BeginInit();
			this.sDefault5.DefaultInstanceName = null;
			this.sDefault5.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 287D, 264D);
			this.sDefault5.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault5.FalseText = "TxtOFF";
			this.sDefault5.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault5.MyTagDisplayName = null;
			this.sDefault5.Name = "sDefault5";
			this.sDefault5.SecurityToken = ((uint)(4294967295u));
			this.sDefault5.TagName = "248448E89426980E.NotBlack";
			this.sDefault5.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault5.TrueText = "TxtON";
			this.sDefault5.EndInit();
			// 
			// sDefault6
			// 
			this.sDefault6.BeginInit();
			this.sDefault6.DefaultInstanceName = null;
			this.sDefault6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 558D, 264D);
			this.sDefault6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault6.FalseText = "TxtOFF";
			this.sDefault6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault6.MyTagDisplayName = null;
			this.sDefault6.Name = "sDefault6";
			this.sDefault6.SecurityToken = ((uint)(4294967295u));
			this.sDefault6.TagName = "248448E89426980E.HeightOk";
			this.sDefault6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault6.TrueText = "TxtON";
			this.sDefault6.EndInit();
			// 
			// sDefault7
			// 
			this.sDefault7.BeginInit();
			this.sDefault7.DefaultInstanceName = null;
			this.sDefault7.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 16D, 384D);
			this.sDefault7.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault7.FalseText = "TxtOFF";
			this.sDefault7.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault7.MyTagDisplayName = null;
			this.sDefault7.Name = "sDefault7";
			this.sDefault7.SecurityToken = ((uint)(4294967295u));
			this.sDefault7.TagName = "248448E89426980E.LightBarrier";
			this.sDefault7.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault7.TrueText = "TxtON";
			this.sDefault7.EndInit();
			// 
			// sHead1
			// 
			this.sHead1.BeginInit();
			this.sHead1.ActiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.sHead1.CompletedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.CompletedBrush");
			this.sHead1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 360D, 392D);
			this.sHead1.HodBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.sHead1.Name = "sHead1";
			this.sHead1.PassiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.sHead1.PausedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.sHead1.PausingBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.sHead1.SecOwner = 3;
			this.sHead1.SecSetpoint = 3;
			this.sHead1.SecurityToken = ((uint)(4294967175u));
			this.sHead1.StepName = "Head";
			this.sHead1.TagName = "248448E89426980E.Reset.ResetSeq";
			this.sHead1.EndInit();
			// 
			// sHead2
			// 
			this.sHead2.BeginInit();
			this.sHead2.ActiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.sHead2.CompletedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.CompletedBrush");
			this.sHead2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 688D, 392D);
			this.sHead2.HodBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.sHead2.Name = "sHead2";
			this.sHead2.PassiveBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.sHead2.PausedBrush = new NxtControl.Drawing.Brush("SE.AppSequence.PassiveBrush");
			this.sHead2.PausingBrush = new NxtControl.Drawing.Brush("SE.AppSequence.ActiveBrush");
			this.sHead2.SecOwner = 3;
			this.sHead2.SecSetpoint = 3;
			this.sHead2.SecurityToken = ((uint)(4294967175u));
			this.sHead2.StepName = "Head";
			this.sHead2.TagName = "248448E89426980E.Cycle.CycleSeq";
			this.sHead2.EndInit();
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
			this.alarmGrid1.Location = new System.Drawing.Point(832, 16);
			this.alarmGrid1.Name = "alarmGrid1";
			this.alarmGrid1.SecurityLevel = 3;
			this.alarmGrid1.Size = new System.Drawing.Size(926, 414);
			this.alarmGrid1.Text = "alarmGrid1";
			this.alarmGrid1.ToolBarBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.alarmGrid1.ToolBarForeColor = System.Drawing.SystemColors.ControlText;
			// 
			// autoPanel
			// 
			this.autoPanel.Bounds = new NxtControl.Drawing.RectF(((float)(832D)), ((float)(456D)), ((float)(520D)), ((float)(152D)));
			this.autoPanel.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(248)), ((byte)(250)), ((byte)(252))));
			this.autoPanel.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 9F, System.Drawing.FontStyle.Regular);
			this.autoPanel.Name = "autoPanel";
			this.autoPanel.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(188)), ((byte)(198)), ((byte)(212))), 1.5F, NxtControl.Drawing.DashStyle.Solid);
			// 
			// lblAutoHeader
			// 
			this.lblAutoHeader.AngleIgnore = true;
			this.lblAutoHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblAutoHeader.Bounds = new NxtControl.Drawing.RectF(((float)(848D)), ((float)(464D)), ((float)(488D)), ((float)(22D)));
			this.lblAutoHeader.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblAutoHeader.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblAutoHeader.FontScale = true;
			this.lblAutoHeader.Name = "lblAutoHeader";
			this.lblAutoHeader.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblAutoHeader.Text = "Station 1 <-> Conveyor Auto Mode";
			this.lblAutoHeader.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblAutoHeader.TextAutoSizeHorizontalOffset = 10;
			this.lblAutoHeader.TextColor = new NxtControl.Drawing.Color(((byte)(30)), ((byte)(42)), ((byte)(58)));
			this.lblAutoHeader.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// lblAutoHint
			// 
			this.lblAutoHint.AngleIgnore = true;
			this.lblAutoHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblAutoHint.Bounds = new NxtControl.Drawing.RectF(((float)(848D)), ((float)(488D)), ((float)(488D)), ((float)(18D)));
			this.lblAutoHint.Brush = new NxtControl.Drawing.Brush("LabelBrush");
			this.lblAutoHint.Font = new NxtControl.Drawing.Font("HMI Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
			this.lblAutoHint.FontScale = true;
			this.lblAutoHint.Name = "lblAutoHint";
			this.lblAutoHint.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblAutoHint.Text = "Keep Distribution & Testing CycleSeq in Program / Auto";
			this.lblAutoHint.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblAutoHint.TextAutoSizeHorizontalOffset = 10;
			this.lblAutoHint.TextColor = new NxtControl.Drawing.Color(((byte)(85)), ((byte)(96)), ((byte)(112)));
			this.lblAutoHint.TextPadding = new NxtControl.Drawing.Padding(2);
			// 
			// symAutoMode
			// 
			this.symAutoMode.BeginInit();
			this.symAutoMode.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symAutoMode.DefaultInstanceName = null;
			this.symAutoMode.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.15D, 0D, 0D, 1D, 856D, 514D);
			this.symAutoMode.Direct = "$key:SE.App2Base.TxtDirect";
			this.symAutoMode.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symAutoMode.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symAutoMode.MyTagDisplayName = null;
			this.symAutoMode.Name = "symAutoMode";
			this.symAutoMode.SecSetpoint = 0;
			this.symAutoMode.SecurityToken = ((uint)(4294967175u));
			this.symAutoMode.TagName = "248448E89426980E.AutoMode";
			this.symAutoMode.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symAutoMode.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symAutoMode.TextOff = "Auto S1: OFF";
			this.symAutoMode.TextOn = "Auto S1: ON";
			this.symAutoMode.EndInit();
			// 
			// symAutoRelease
			// 
			this.symAutoRelease.BeginInit();
			this.symAutoRelease.ButtonMode = SE.App2Base.Symbols.SetBool.btnMode_.Toggle;
			this.symAutoRelease.DefaultInstanceName = null;
			this.symAutoRelease.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.15D, 0D, 0D, 1D, 1072D, 514D);
			this.symAutoRelease.Direct = "$key:SE.App2Base.TxtDirect";
			this.symAutoRelease.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.symAutoRelease.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.symAutoRelease.MyTagDisplayName = null;
			this.symAutoRelease.Name = "symAutoRelease";
			this.symAutoRelease.SecSetpoint = 0;
			this.symAutoRelease.SecurityToken = ((uint)(4294967175u));
			this.symAutoRelease.TagName = "248448E89426980E.AutoRelease";
			this.symAutoRelease.TextColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symAutoRelease.TextColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.symAutoRelease.TextOff = "Auto-Rel: OFF";
			this.symAutoRelease.TextOn = "Auto-Rel: ON";
			this.symAutoRelease.EndInit();
			// 
			// Testing
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1808D)), ((float)(704D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.sDefault1,
			this.sDefault2,
			this.sDefault3,
			this.sDefault4,
			this.sDefault5,
			this.sDefault6,
			this.sDefault7,
			this.sHead1,
			this.sHead2,
			this.alarmGrid1,
			this.autoPanel,
			this.lblAutoHeader,
			this.lblAutoHint,
			this.symAutoMode,
			this.symAutoRelease});
			this.Size = new System.Drawing.Size(1808, 704);
			((System.ComponentModel.ISupportInitialize)(this.alarmGrid1)).EndInit();

		}
		private SE.App2CommonProcess.Symbols.Valve2Op.sDefault sDefault1;
		private SE.App2CommonProcess.Symbols.Valve.sDefault sDefault2;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault sDefault3;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault sDefault4;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault sDefault5;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault sDefault6;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault sDefault7;
		private SE.AppSequence.Symbols.SeqHead.sHead sHead1;
		private SE.AppSequence.Symbols.SeqHead.sHead sHead2;
		private NxtControl.GuiFramework.AlarmGrid alarmGrid1;
		private NxtControl.GuiFramework.Rectangle autoPanel;
		private NxtControl.GuiFramework.Label lblAutoHeader;
		private NxtControl.GuiFramework.Label lblAutoHint;
		private SE.App2Base.Symbols.SetBool.sButton symAutoMode;
		private SE.App2Base.Symbols.SetBool.sButton symAutoRelease;
		#endregion
	}
}
