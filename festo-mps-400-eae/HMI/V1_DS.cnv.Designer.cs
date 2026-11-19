/*
 * Created by EcoStruxure Automation Expert.
 * User: Sandeep Patil
 * Date: 11/16/2026
 * Time: 3:00 PM
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
	/// Summary description for V1_DS.
	/// </summary>
	partial class V1_DS
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Ejector = new Flexbridge.FestoMPS400.Symbols.Actuator.sDefault();
			this.Swivel = new Flexbridge.FestoMPS400.Symbols.Actuator2Op.sDefault();
			this.Vacuum = new Flexbridge.FestoMPS400.Symbols.Actuator2Op.sDefault();
			this.MagazineEmpty = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.DownStreamFree = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.EjectorAlarmGrid = new NxtControl.GuiFramework.AlarmGrid();
			this.sDefault1 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.sDefault2 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.DS01 = new Flexbridge.FestoMPS400.Symbols.Distributing.sDefault();
			((System.ComponentModel.ISupportInitialize)(this.EjectorAlarmGrid)).BeginInit();
			// 
			// Ejector
			// 
			this.Ejector.BeginInit();
			this.Ejector.DefaultInstanceName = null;
			this.Ejector.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 98D, 167D);
			this.Ejector.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.Ejector.MyTagDisplayName = null;
			this.Ejector.Name = "Ejector";
			this.Ejector.SecurityToken = ((uint)(4294967295u));
			this.Ejector.TagName = "4A49DD7FEEFD8EC0.Ejector";
			this.Ejector.EndInit();
			// 
			// Swivel
			// 
			this.Swivel.BeginInit();
			this.Swivel.DefaultInstanceName = null;
			this.Swivel.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 353D, 174D);
			this.Swivel.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.Swivel.MyTagDisplayName = null;
			this.Swivel.Name = "Swivel";
			this.Swivel.SecurityToken = ((uint)(4294967295u));
			this.Swivel.TagName = "4A49DD7FEEFD8EC0.Swivel";
			this.Swivel.EndInit();
			// 
			// Vacuum
			// 
			this.Vacuum.BeginInit();
			this.Vacuum.DefaultInstanceName = null;
			this.Vacuum.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 671D, 175D);
			this.Vacuum.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.Vacuum.MyTagDisplayName = null;
			this.Vacuum.Name = "Vacuum";
			this.Vacuum.SecurityToken = ((uint)(4294967295u));
			this.Vacuum.TagName = "4A49DD7FEEFD8EC0.Vacuum";
			this.Vacuum.EndInit();
			// 
			// MagazineEmpty
			// 
			this.MagazineEmpty.BeginInit();
			this.MagazineEmpty.DefaultInstanceName = null;
			this.MagazineEmpty.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 143D, 411D);
			this.MagazineEmpty.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.MagazineEmpty.FalseText = "TxtOFF";
			this.MagazineEmpty.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.MagazineEmpty.MyTagDisplayName = null;
			this.MagazineEmpty.Name = "MagazineEmpty";
			this.MagazineEmpty.SecurityToken = ((uint)(4294967295u));
			this.MagazineEmpty.TagName = "4A49DD7FEEFD8EC0.MagazineEmpty";
			this.MagazineEmpty.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.MagazineEmpty.TrueText = "TxtON";
			this.MagazineEmpty.EndInit();
			// 
			// DownStreamFree
			// 
			this.DownStreamFree.BeginInit();
			this.DownStreamFree.DefaultInstanceName = null;
			this.DownStreamFree.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 461D, 421D);
			this.DownStreamFree.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.DownStreamFree.FalseText = "TxtOFF";
			this.DownStreamFree.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.DownStreamFree.MyTagDisplayName = null;
			this.DownStreamFree.Name = "DownStreamFree";
			this.DownStreamFree.SecurityToken = ((uint)(4294967295u));
			this.DownStreamFree.TagName = "4A49DD7FEEFD8EC0.DownstreamFree";
			this.DownStreamFree.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.DownStreamFree.TrueText = "TxtON";
			this.DownStreamFree.EndInit();
			// 
			// EjectorAlarmGrid
			// 
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Shortcut, true, null, 32));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Ack, true, null, 40));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Origin, true, null, 200));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Text, true, null, 100));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.CameTime, true, null, 130));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.GoneTime, true, null, 130));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Present, true, null, 48));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.State, true, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Value, true, null, 80));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.InfoValue, true, null, 80));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.CameAckTime, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.GoneAckTime, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Interval, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.CameAckUser, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.GoneAckUser, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Path, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Alias, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Time, false, null, 0));
			this.EjectorAlarmGrid.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmColumnInformation(NxtControl.GuiFramework.AlarmColumn.Selected, true, null, 25));
			this.EjectorAlarmGrid.AlarmFilter = new NxtControl.GuiFramework.AlarmConfiguration("");
			this.EjectorAlarmGrid.AlternatingRowColor = System.Drawing.Color.Empty;
			this.EjectorAlarmGrid.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.EjectorAlarmGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EjectorAlarmGrid.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
			this.EjectorAlarmGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EjectorAlarmGrid.GridCellBackColor = System.Drawing.SystemColors.Window;
			this.EjectorAlarmGrid.HeaderBackColor = System.Drawing.SystemColors.Control;
			this.EjectorAlarmGrid.HeaderForeColor = System.Drawing.SystemColors.WindowText;
			this.EjectorAlarmGrid.Location = new System.Drawing.Point(824, 168);
			this.EjectorAlarmGrid.Name = "EjectorAlarmGrid";
			this.EjectorAlarmGrid.SecurityLevel = 3;
			this.EjectorAlarmGrid.Size = new System.Drawing.Size(382, 254);
			this.EjectorAlarmGrid.Text = "alarmGrid1";
			this.EjectorAlarmGrid.ToolBarBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.EjectorAlarmGrid.ToolBarForeColor = System.Drawing.SystemColors.ControlText;
			// 
			// sDefault1
			// 
			this.sDefault1.BeginInit();
			this.sDefault1.DefaultInstanceName = null;
			this.sDefault1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 245D, 618D);
			this.sDefault1.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault1.FalseText = "TxtOFF";
			this.sDefault1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault1.MyTagDisplayName = null;
			this.sDefault1.Name = "sDefault1";
			this.sDefault1.SecurityToken = ((uint)(4294967295u));
			this.sDefault1.TagName = "4A49DD7FEEFD8EC0.Console.P1_StartLamp";
			this.sDefault1.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault1.TrueText = "TxtON";
			this.sDefault1.EndInit();
			// 
			// sDefault2
			// 
			this.sDefault2.BeginInit();
			this.sDefault2.DefaultInstanceName = null;
			this.sDefault2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 500D, 631D);
			this.sDefault2.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault2.FalseText = "TxtOFF";
			this.sDefault2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault2.MyTagDisplayName = null;
			this.sDefault2.Name = "sDefault2";
			this.sDefault2.SecurityToken = ((uint)(4294967295u));
			this.sDefault2.TagName = "4A49DD7FEEFD8EC0.Console.P2_ResetLamp";
			this.sDefault2.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault2.TrueText = "TxtON";
			this.sDefault2.EndInit();
			// 
			// DS01
			// 
			this.DS01.BeginInit();
			this.DS01.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 752D, 472D);
			this.DS01.Name = "DS01";
			this.DS01.SecurityToken = ((uint)(4294967295u));
			this.DS01.TagName = "4A49DD7FEEFD8EC0";
			this.DS01.EndInit();
			// 
			// V1_DS
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1280D)), ((float)(910D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.Ejector,
			this.Swivel,
			this.Vacuum,
			this.MagazineEmpty,
			this.DownStreamFree,
			this.EjectorAlarmGrid,
			this.sDefault1,
			this.sDefault2,
			this.DS01});
			this.Size = new System.Drawing.Size(1280, 910);
			((System.ComponentModel.ISupportInitialize)(this.EjectorAlarmGrid)).EndInit();

		}
		private Flexbridge.FestoMPS400.Symbols.Actuator.sDefault Ejector;
		private Flexbridge.FestoMPS400.Symbols.Actuator2Op.sDefault Swivel;
		private Flexbridge.FestoMPS400.Symbols.Actuator2Op.sDefault Vacuum;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault MagazineEmpty;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault DownStreamFree;
		private NxtControl.GuiFramework.AlarmGrid EjectorAlarmGrid;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault sDefault1;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault sDefault2;
		private Flexbridge.FestoMPS400.Symbols.Distributing.sDefault DS01;
		#endregion
	}
}
