/*
 * Created by EcoStruxure Automation Expert.
 * User:  
 * Date: 10/21/2026
 * Time: 11:48 AM
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
	/// Summary description for Distribution.
	/// </summary>
	partial class Distribution
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sDefault1 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
			this.sDefault2 = new SE.App2CommonProcess.Symbols.Valve2Op.sDefault();
			this.sDefault3 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
			this.sDefault4 = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
			this.sDefault5 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.sDefault6 = new SE.App2CommonProcess.Symbols.DigitalInput.sDefault();
			this.sHead1 = new SE.AppSequence.Symbols.SeqHead.sHead();
			this.sHead2 = new SE.AppSequence.Symbols.SeqHead.sHead();
			// 
			// sDefault1
			// 
			this.sDefault1.BeginInit();
			this.sDefault1.DefaultInstanceName = null;
			this.sDefault1.DesignMatrix = new NxtControl.Drawing.Matrix2D(2.3013698630136985D, 0D, 0D, 2D, 12.493150684931493D, 8D);
			this.sDefault1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault1.MyTagDisplayName = null;
			this.sDefault1.Name = "sDefault1";
			this.sDefault1.SecurityToken = ((uint)(4294967295u));
			this.sDefault1.TagName = "33A16FB4708913B3.Ejector";
			this.sDefault1.EndInit();
			// 
			// sDefault2
			// 
			this.sDefault2.BeginInit();
			this.sDefault2.DefaultInstanceName = null;
			this.sDefault2.DesignMatrix = new NxtControl.Drawing.Matrix2D(2.0821917808219177D, 0D, 0D, 1.9047619047619047D, 309.58904109589048D, 47.999999999999993D);
			this.sDefault2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault2.MyTagDisplayName = null;
			this.sDefault2.Name = "sDefault2";
			this.sDefault2.SecurityToken = ((uint)(4294967295u));
			this.sDefault2.TagName = "33A16FB4708913B3.Swivel";
			this.sDefault2.EndInit();
			// 
			// sDefault3
			// 
			this.sDefault3.BeginInit();
			this.sDefault3.DefaultInstanceName = null;
			this.sDefault3.DesignMatrix = new NxtControl.Drawing.Matrix2D(2.1917808219178081D, 0D, 0D, 2.1904761904761907D, 597.041095890411D, 24D);
			this.sDefault3.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault3.MyTagDisplayName = null;
			this.sDefault3.Name = "sDefault3";
			this.sDefault3.SecurityToken = ((uint)(4294967295u));
			this.sDefault3.TagName = "33A16FB4708913B3.Vacuum";
			this.sDefault3.EndInit();
			// 
			// sDefault4
			// 
			this.sDefault4.BeginInit();
			this.sDefault4.DefaultInstanceName = null;
			this.sDefault4.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 0D, 256D);
			this.sDefault4.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault4.FalseText = "TxtOFF";
			this.sDefault4.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault4.MyTagDisplayName = null;
			this.sDefault4.Name = "sDefault4";
			this.sDefault4.SecurityToken = ((uint)(4294967295u));
			this.sDefault4.TagName = "33A16FB4708913B3.BlowOff";
			this.sDefault4.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault4.TrueText = "TxtON";
			this.sDefault4.EndInit();
			// 
			// sDefault5
			// 
			this.sDefault5.BeginInit();
			this.sDefault5.DefaultInstanceName = null;
			this.sDefault5.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 295D, 248D);
			this.sDefault5.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault5.FalseText = "TxtOFF";
			this.sDefault5.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault5.MyTagDisplayName = null;
			this.sDefault5.Name = "sDefault5";
			this.sDefault5.SecurityToken = ((uint)(4294967295u));
			this.sDefault5.TagName = "33A16FB4708913B3.DownstreamFree";
			this.sDefault5.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault5.TrueText = "TxtON";
			this.sDefault5.EndInit();
			// 
			// sDefault6
			// 
			this.sDefault6.BeginInit();
			this.sDefault6.DefaultInstanceName = null;
			this.sDefault6.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 583D, 248D);
			this.sDefault6.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
			this.sDefault6.FalseText = "TxtOFF";
			this.sDefault6.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.sDefault6.MyTagDisplayName = null;
			this.sDefault6.Name = "sDefault6";
			this.sDefault6.SecurityToken = ((uint)(4294967295u));
			this.sDefault6.TagName = "33A16FB4708913B3.MagazineEmpty";
			this.sDefault6.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
			this.sDefault6.TrueText = "TxtON";
			this.sDefault6.EndInit();
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
			this.sHead1.TagName = "33A16FB4708913B3.Reset.ResetSeq";
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
			this.sHead2.TagName = "33A16FB4708913B3.Cycle.CycleSeq";
			this.sHead2.EndInit();
			// 
			// Distribution
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1032D)), ((float)(600D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.sDefault1,
			this.sDefault2,
			this.sDefault3,
			this.sDefault4,
			this.sDefault5,
			this.sDefault6,
			this.sHead1,
			this.sHead2});
			this.Size = new System.Drawing.Size(1032, 600);

		}
		private SE.App2CommonProcess.Symbols.Valve.sDefault sDefault1;
		private SE.App2CommonProcess.Symbols.Valve2Op.sDefault sDefault2;
		private SE.App2CommonProcess.Symbols.Valve.sDefault sDefault3;
		private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault sDefault4;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault sDefault5;
		private SE.App2CommonProcess.Symbols.DigitalInput.sDefault sDefault6;
		private SE.AppSequence.Symbols.SeqHead.sHead sHead1;
		private SE.AppSequence.Symbols.SeqHead.sHead sHead2;
		#endregion
	}
}
