/*
 * Created by EcoStruxure Automation Expert.
 * User: SESA645093
 * Date: 21/02/2022
 * Time: 4:08 pm
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
	/// Summary description for Alarms.
	/// </summary>
	partial class Alarms
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.alarmControl1 = new NxtControl.GuiFramework.AlarmControl();
			((System.ComponentModel.ISupportInitialize)(this.alarmControl1)).BeginInit();
			// 
			// alarmControl1
			// 
			//this.alarmControl1.AlarmArchiveConfig = new NxtControl.GuiFramework.AlarmArchiveConfiguration("", new NxtControl.ComponentModel.TimePeriod(NxtControl.ComponentModel.TimePeriod.Range.LastDay));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Shortcut, true, "SC", 32));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Ack, true, "Ack", 40));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Origin, true, "Origin", 200));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Text, true, "Text", 100));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.CameTime, true, "Came", 130));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.GoneTime, true, "Gone", 130));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Present, true, "Present", 48));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.State, true, "State", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Value, true, "Value", 80));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.InfoValue, true, "Info", 80));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.CameAckTime, false, "CameAckTime", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.GoneAckTime, false, "GoneAckTime", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Interval, false, "Interval", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.CameAckUser, false, "CameAckUser", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.GoneAckUser, false, "GoneAckUser", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Path, false, "Path", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Alias, false, "Alias", 0));
			this.alarmControl1.AlarmColumns.Add(new NxtControl.GuiFramework.AlarmControl.AlarmColumnInfo(NxtControl.GuiFramework.AlarmControl.AlarmColumn.Time, false, "Time", 0));
			this.alarmControl1.AlternatingRowColor = System.Drawing.Color.Empty;
			this.alarmControl1.HeaderBackColor = System.Drawing.SystemColors.Control;
			this.alarmControl1.HeaderForeColor = System.Drawing.SystemColors.WindowText;
			this.alarmControl1.Location = new System.Drawing.Point(40, 56);
			this.alarmControl1.Name = "alarmControl1";
			this.alarmControl1.Size = new System.Drawing.Size(1065, 361);
			this.alarmControl1.TabIndex = 0;
			this.alarmControl1.Text = "alarmControl1";
			// 
			// Alarms
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1280D)), ((float)(900D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Name = "Alarms";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.alarmControl1});
			this.Size = new System.Drawing.Size(1280, 900);
			((System.ComponentModel.ISupportInitialize)(this.alarmControl1)).EndInit();

		}
		private NxtControl.GuiFramework.AlarmControl alarmControl1;
		#endregion
	}
}
