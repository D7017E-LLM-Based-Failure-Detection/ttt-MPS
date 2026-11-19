using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Actuator
{
	/// <summary>
	/// Summary description for InstanceName.
	/// </summary>
	partial class sInstanceName
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.aliasDisplayLabel1 = new NxtControl.GuiFramework.AliasDisplayLabel();
			// 
			// aliasDisplayLabel1
			// 
			this.aliasDisplayLabel1.AngleIgnore = true;
			this.aliasDisplayLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.aliasDisplayLabel1.Bounds = new NxtControl.Drawing.RectF(((float)(23D)), ((float)(46.5D)), ((float)(43D)), ((float)(16D)));
			this.aliasDisplayLabel1.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color("Transparent"));
			this.aliasDisplayLabel1.CustomInstanceName = null;
			this.aliasDisplayLabel1.Font = new NxtControl.Drawing.Font("SE.App2Base.SymInstanceLabel");
			this.aliasDisplayLabel1.FontScale = true;
			this.aliasDisplayLabel1.Name = "aliasDisplayLabel1";
			this.aliasDisplayLabel1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
			this.aliasDisplayLabel1.Text = "Valve";
			this.aliasDisplayLabel1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
			this.aliasDisplayLabel1.TextAutoSize = true;
			this.aliasDisplayLabel1.TextColor = new NxtControl.Drawing.Color("SE.App2Base.SymInstanceLabelTextColor");
			// 
			// InstanceName
			// 
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.aliasDisplayLabel1});
			this.SymbolSize = new System.Drawing.Size(336, 112);

		}
		private NxtControl.GuiFramework.AliasDisplayLabel aliasDisplayLabel1;
		#endregion
	}
}
