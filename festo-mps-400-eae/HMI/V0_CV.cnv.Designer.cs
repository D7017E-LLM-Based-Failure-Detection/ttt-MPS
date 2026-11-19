/*
 * Created by EcoStruxure Automation Expert.
 * User: Sandeep Patil
 * Date: 11/13/2026
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
	/// Summary description for V0_CV.
	/// </summary>
	partial class V0_CV
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CV_AB = new Flexbridge.FestoMPS400.Symbols.IOTest16.sDefault();
			this.CV_CD = new Flexbridge.FestoMPS400.Symbols.IOTest16.sDefault();
			// 
			// CV_AB
			// 
			this.CV_AB.BeginInit();
			this.CV_AB.Name = "CV_AB";
			this.CV_AB.SecurityToken = ((uint)(4294967295u));
			this.CV_AB.TagName = "0241352EDFAA560E";
			this.CV_AB.EndInit();
			// 
			// CV_CD
			// 
			this.CV_CD.BeginInit();
			this.CV_CD.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 0D, 448D);
			this.CV_CD.Name = "CV_CD";
			this.CV_CD.SecurityToken = ((uint)(4294967295u));
			this.CV_CD.TagName = "EC9C0DF141D86266";
			this.CV_CD.EndInit();
			// 
			// V0_CV
			// 
			this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1280D)), ((float)(882D)));
			this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.CV_AB,
			this.CV_CD});
			this.Size = new System.Drawing.Size(1280, 882);
			this.Title = "Conveyor";

		}
		private Flexbridge.FestoMPS400.Symbols.IOTest16.sDefault CV_AB;
		private Flexbridge.FestoMPS400.Symbols.IOTest16.sDefault CV_CD;
		#endregion
	}
}
