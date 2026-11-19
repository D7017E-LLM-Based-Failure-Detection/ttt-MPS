using System;
using System.ComponentModel;
using System.Collections;
using NxtControl.GuiFramework;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBaseExt
{
	/// <summary>
	/// Summary description for sLflVert.
	/// </summary>
	partial class sLflVert
	{

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.slflValve = new Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflVert();
			// 
			// slflValve
			// 
			this.slflValve.BeginInit();
			this.slflValve.CurrView = SE.App2Base.SupportClasses.CurrentView.Open;
			this.slflValve.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 32D, 16D);
			this.slflValve.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
			this.slflValve.MyTagDisplayName = null;
			this.slflValve.Name = "slflValve";
			this.slflValve.SecurityToken = ((uint)(4294967175u));
			this.slflValve.TagName = "actuatorBase";
			this.slflValve.ValveAppearance.House1.ViewHorz1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House1.ViewHorz2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House1.ViewVert1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House2.ViewHorz1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House2.ViewHorz2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House2.ViewVert1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House3.ViewHorz1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House3.ViewHorz2 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.House3.ViewVert1 = SE.App2Base.SupportClasses.VisibleState.Open;
			this.slflValve.ValveAppearance.HouseNos = SE.App2Base.SupportClasses.HousingNos.Three;
			this.slflValve.EndInit();
			// 
			// sLflVert
			// 
			this.Name = "sLflVert";
			this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.slflValve});
			this.SymbolSize = new System.Drawing.Size(200, 200);
			this.SecurityOwnerChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityOwnerChanged(this.SLFLHorzSecurityOwnerChanged);
			this.SecurityParameterChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityParameterChanged(this.SLFLHorzSecurityParameterChanged);
			this.SecurityModeChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecurityModeChanged(this.SLFLHorzSecurityModeChanged);
			this.SecuritySetpointChanged += new SE.App2Base.Symbols.SEAppLibHMISymbol.OnSecuritySetpointChanged(this.SLFLHorzSecuritySetpointChanged);

		}
		private Flexbridge.FestoMPS400.Symbols.ActuatorBase.sLflVert slflValve;
		#endregion
	}
}
