using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.Distributing
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
			this.ledWaiting = new System.HMI.Symbols.Base.Led<bool>();
			this.txtWaiting = new NxtControl.GuiFramework.FreeText();
			this.btnRequest = new System.HMI.Symbols.Base.SwitchButton();
			this.txtRequest = new NxtControl.GuiFramework.FreeText();
			this.txtTitle.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtTitle.Font = new NxtControl.Drawing.Font("HMI Monospace", 14F, System.Drawing.FontStyle.Regular);
			this.txtTitle.Location = new NxtControl.Drawing.PointF(8D, 8D);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Text = "Distributing station";
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
			this.ledWaiting.BeginInit();
			this.ledWaiting.ColorFrame = new NxtControl.Drawing.Color("LedFrameColor");
			this.ledWaiting.DesignMatrix = new NxtControl.Drawing.Matrix2D(2D, 0D, 0D, 2D, 8D, 116D);
			this.ledWaiting.FrameSize = 33F;
			this.ledWaiting.IsOnlyInput = true;
			this.ledWaiting.Name = "ledWaiting";
			propertyDictionary2.Add("Color", new NxtControl.Drawing.Color("LedFalseColor"));
			propertyDictionary3.Add("Color", new NxtControl.Drawing.Color("LedTrueColor"));
			propertyDictionary1.Add("Color", new NxtControl.Drawing.Color("LedFalseColor"));
			this.ledWaiting.Ranges.Clear();
			this.ledWaiting.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(false, propertyDictionary2));
			this.ledWaiting.Ranges.Add(new NxtControl.GuiFramework.Range<bool>(true, propertyDictionary3));
			this.ledWaiting.Ranges.DefaultPropertyValues = propertyDictionary1;
			this.ledWaiting.TagName = "Waiting";
			this.ledWaiting.EndInit();
			this.txtWaiting.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtWaiting.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtWaiting.Location = new NxtControl.Drawing.PointF(48D, 122D);
			this.txtWaiting.Name = "txtWaiting";
			this.txtWaiting.Text = "Magazine empty, waiting";
			this.btnRequest.BeginInit();
			this.btnRequest.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 8D, 156D);
			this.btnRequest.FalseImage = new NxtControl.Drawing.ImageHolder();
			this.btnRequest.FalseImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.btnRequest.Font = new NxtControl.Drawing.Font("ButtonFont");
			this.btnRequest.Name = "btnRequest";
			this.btnRequest.TagName = "RequestWp";
			this.btnRequest.TrueImage = new NxtControl.Drawing.ImageHolder();
			this.btnRequest.TrueImageDisabled = new NxtControl.Drawing.ImageHolder();
			this.btnRequest.Value = false;
			this.btnRequest.EndInit();
			this.txtRequest.Color = new NxtControl.Drawing.Color("LabelTextColor");
			this.txtRequest.Font = new NxtControl.Drawing.Font("HMI Monospace", 10F, System.Drawing.FontStyle.Regular);
			this.txtRequest.Location = new NxtControl.Drawing.PointF(90D, 160D);
			this.txtRequest.Name = "txtRequest";
			this.txtRequest.Text = "Request one workpiece (each click = one)";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.txtTitle,
			this.txtMode,
			this.lblMode,
			this.txtStep,
			this.lblStep,
			this.ledWaiting,
			this.txtWaiting,
			this.btnRequest,
			this.txtRequest});
			this.SymbolSize = new System.Drawing.Size(440, 200);
			this.Name = "sDefault";

		}
		private NxtControl.GuiFramework.FreeText txtTitle;
		private NxtControl.GuiFramework.FreeText txtMode;
		private System.HMI.Symbols.Base.Label lblMode;
		private NxtControl.GuiFramework.FreeText txtStep;
		private System.HMI.Symbols.Base.Label lblStep;
		private System.HMI.Symbols.Base.Led<bool> ledWaiting;
		private NxtControl.GuiFramework.FreeText txtWaiting;
		private System.HMI.Symbols.Base.SwitchButton btnRequest;
		private NxtControl.GuiFramework.FreeText txtRequest;
		#endregion
	}
}
