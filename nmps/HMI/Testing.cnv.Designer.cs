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
			this.alarmGrid1});
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
		#endregion
	}
}
