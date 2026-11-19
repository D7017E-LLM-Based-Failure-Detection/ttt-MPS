using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Testing
{
	/// <summary>
	/// Summary description for sDefault.
	/// </summary>
	partial class sDefault
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			NxtControl.GuiFramework.PropertyDictionary propertyDictionary1 = new NxtControl.GuiFramework.PropertyDictionary();
			NxtControl.GuiFramework.PropertyDictionary propertyDictionary2 = new NxtControl.GuiFramework.PropertyDictionary();
			NxtControl.GuiFramework.PropertyDictionary propertyDictionary3 = new NxtControl.GuiFramework.PropertyDictionary();
			this.txtTitle = new NxtControl.GuiFramework.FreeText();
			this.txtMode = new NxtControl.GuiFramework.FreeText();
			this.lblMode = new System.HMI.Symbols.Base.Label();
			this.txtStep = new NxtControl.GuiFramework.FreeText();
			this.lblStep = new System.HMI.Symbols.Base.Label();
			this.ledReleased = new System.HMI.Symbols.Base.Led<bool>();
			this.txtReleased = new NxtControl.GuiFramework.FreeText();
			this.btnEmpty = new System.HMI.Symbols.Base.SwitchButton();
			this.txtEmpty = new NxtControl.GuiFramework.FreeText();
			this.btnFull = new System.HMI.Symbols.Base.SwitchButton();
			this.txtFull = new NxtControl.GuiFramework.FreeText();
			this.txtTitle.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtTitle.Font = new NxtControl.Drawing.Font("HMI Monospace", 14F, System.Drawing.FontStyle.Regular);
			this.txtTitle.Location = new NxtControl.Drawing.PointF(8D, 8D);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Text = "Testing station";
			this.txtMode.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtMode.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtMode.Location = new NxtControl.Drawing.PointF(8D, 48D);
			this.txtMode.Name = "txtMode";
			this.txtMode.Text = "Mode";
			this.lblMode.BeginInit();
			this.lblMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMode.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 90D, 44D);
			this.lblMode.Font = new NxtControl.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
			this.lblMode.FontScale = false;
			this.lblMode.IsOnlyInput = true;
			this.lblMode.Name = "lblMode";
			this.lblMode.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblMode.TagName = "ModeText";
			this.lblMode.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblMode.TextColor = new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0)));
			this.lblMode.EndInit();
			this.txtStep.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtStep.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtStep.Location = new NxtControl.Drawing.PointF(8D, 84D);
			this.txtStep.Name = "txtStep";
			this.txtStep.Text = "Step";
			this.lblStep.BeginInit();
			this.lblStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStep.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 90D, 80D);
			this.lblStep.Font = new NxtControl.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
			this.lblStep.FontScale = false;
			this.lblStep.IsOnlyInput = true;
			this.lblStep.Name = "lblStep";
			this.lblStep.Pen = new NxtControl.Drawing.Pen("LabelPen");
			this.lblStep.TagName = "StepText";
			this.lblStep.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			this.lblStep.TextColor = new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0)));
			this.lblStep.EndInit();
			this.ledReleased.BeginInit();
			this.ledReleased.ColorFrame = new NxtControl.Drawing.Color("LedFrameColor");
			this.ledReleased.DesignMatrix = new NxtControl.Drawing.Matrix2D(2D, 0D, 0D, 2D, 8D, 116D);
			this.ledReleased.FrameSize = 33F;
			this.ledReleased.IsOnlyInput = true;
			this.ledReleased.Name = "ledReleased";
			propertyDictionary2.Add("Color", new NxtControl.Drawing.Color("LedFalseColor"));
			propertyDictionary3.Add("Color", new NxtControl.Drawing.Color("LedTrueColor"));
			propertyDictionary1.Add("Color", new NxtControl.Drawing.Color("LedFalseColor"));
			this.ledReleased.Ranges.Clear();
			this.ledReleased.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(false, propertyDictionary2));
			this.ledReleased.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(true, propertyDictionary3));
			this.ledReleased.Ranges.DefaultPropertyValues = propertyDictionary1;
			this.ledReleased.TagName = "TrayReleased";
			this.ledReleased.EndInit();
			this.txtReleased.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtReleased.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtReleased.Location = new NxtControl.Drawing.PointF(48D, 122D);
			this.txtReleased.Name = "txtReleased";
			this.txtReleased.Text = "Tray released";
			this.btnEmpty.BeginInit();
			this.btnEmpty.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 8D, 156D);
			this.btnEmpty.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.btnEmpty.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.btnEmpty.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.btnEmpty.Name = "btnEmpty";
			this.btnEmpty.TagName = "TrayEmpty";
			this.btnEmpty.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.btnEmpty.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.btnEmpty.Value = false;
			this.btnEmpty.EndInit();
			this.txtEmpty.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtEmpty.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtEmpty.Location = new NxtControl.Drawing.PointF(90D, 160D);
			this.txtEmpty.Name = "txtEmpty";
			this.txtEmpty.Text = "Empty tray arrives (stand-in for the conveyor)";
			this.btnFull.BeginInit();
			this.btnFull.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 8D, 196D);
			this.btnFull.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.btnFull.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.btnFull.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.btnFull.Name = "btnFull";
			this.btnFull.TagName = "TrayFull";
			this.btnFull.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.btnFull.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.btnFull.Value = false;
			this.btnFull.EndInit();
			this.txtFull.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtFull.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtFull.Location = new NxtControl.Drawing.PointF(90D, 200D);
			this.txtFull.Name = "txtFull";
			this.txtFull.Text = "Tray with workpiece arrives (stand-in)";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.txtTitle,
			this.txtMode,
			this.lblMode,
			this.txtStep,
			this.lblStep,
			this.ledReleased,
			this.txtReleased,
			this.btnEmpty,
			this.txtEmpty,
			this.btnFull,
			this.txtFull});
			this.SymbolSize = new System.Drawing.Size(460, 240);
			this.Name = "sDefault";

		}
		private NxtControl.GuiFramework.FreeText txtTitle;
		private NxtControl.GuiFramework.FreeText txtMode;
		private System.HMI.Symbols.Base.Label lblMode;
		private NxtControl.GuiFramework.FreeText txtStep;
		private System.HMI.Symbols.Base.Label lblStep;
		private System.HMI.Symbols.Base.Led<bool> ledReleased;
		private NxtControl.GuiFramework.FreeText txtReleased;
		private System.HMI.Symbols.Base.SwitchButton btnEmpty;
		private NxtControl.GuiFramework.FreeText txtEmpty;
		private System.HMI.Symbols.Base.SwitchButton btnFull;
		private NxtControl.GuiFramework.FreeText txtFull;
		#endregion
	}
}
