using System;
using System.ComponentModel;
using SE.App2Base.SupportClasses;
using SE.App2CommonProcess.SupportClasses;
using NxtControl.ComponentModel;


namespace Flexbridge.FestoMPS400.Symbols.ActuatorBaseExt
{
	/// <summary>
	/// Description of sLflVert.
	/// </summary>
	public partial class sLflVert : SE.App2Base.Symbols.SEAppLibHMISymbol, IPropertiesNotifyChange
	{
		public sLflVert()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			valveAppearance = new sLFLValveAppearance(this);
			slflValve.Instancelayer = InstanceLayer.BaseExt;
		}
				[Browsable(false)]
		public override int SecurityLevel{get{return base.SecurityLevel;} set{base.SecurityLevel = value;}}
		
		// Owner level Security
		[DefaultValue(3),Browsable(true)]
		public override int SecOwner{ get {return base.SecOwner;} set {base.SecOwner = value;} }
		
		// Parameter level Security
		[DefaultValue(12),Browsable(true)]
		public override int SecParameter{ get {return base.SecParameter;} set {base.SecParameter = value;} }

		// Setpoint level Security
		[DefaultValue(3),Browsable(true)]
		public override int SecSetpoint{ get {return base.SecSetpoint;} set {base.SecSetpoint = value;} }

		// Mode level Security
		[DefaultValue(6),Browsable(true)]
		public override int SecMode{ get { return base.SecMode; } set { base.SecMode = value; } }
		
		void SLFLHorzSecurityOwnerChanged(bool isSecurity)
		{
			slflValve.SecOwner = SecOwner;
		}

		void SLFLHorzSecurityParameterChanged(bool isSecurity)
		{
			slflValve.SecParameter = SecParameter;
		}

		void SLFLHorzSecurityModeChanged(bool isSecurity)
		{
			slflValve.SecMode = SecMode;
		}

		void SLFLHorzSecuritySetpointChanged(bool isSecurity)
		{
			slflValve.SecSetpoint = SecSetpoint;
		}
		
		[Browsable(true)]
		public override bool HideTagDisplayName {
			get {
				return base.HideTagDisplayName;
			}
			set {
				base.HideTagDisplayName = value;
			}
		}

		private CurrentView currView=CurrentView.Open;
		[RefreshProperties(RefreshProperties.All)]
		[Category("Test")]
		[DisplayName("Preview")]
		[Browsable(true)]
		public CurrentView CurrView
		{
			get { return currView; }
			set
			{
				currView=value;
				UpdateIProperties();
			}
		}

		
		sLFLValveAppearance valveAppearance;
		[RefreshProperties(RefreshProperties.All)]
		[Category("Visibility Configuration")]
		[DisplayName("Housings")]
		[LRDescriptionAttribute("$key:SE.App2CommonProcess.Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public sLFLValveAppearance ValveAppearance
		{
			get {return valveAppearance;}
			set 
			{
				valveAppearance = value;
				UpdateIProperties();
			}
		}

		public void UpdateIProperties()
		{
			slflValve.ValveAppearance.HouseNos = valveAppearance.HouseNos;
			slflValve.ValveAppearance.House1.ViewVert1 = valveAppearance.House1.ViewVert1;
			slflValve.ValveAppearance.House1.ViewVert2 = valveAppearance.House1.ViewVert2;
			slflValve.ValveAppearance.House2.ViewVert1 = valveAppearance.House2.ViewVert1;
			slflValve.ValveAppearance.House2.ViewVert2 = valveAppearance.House2.ViewVert2;
			slflValve.ValveAppearance.House3.ViewVert1  = valveAppearance.House3.ViewVert1;;
			slflValve.ValveAppearance.House3.ViewVert2  = valveAppearance.House3.ViewVert2;
			slflValve.ValveAppearance.House1.ViewHorz1  = valveAppearance.House1.ViewHorz1;
			slflValve.ValveAppearance.House1.ViewHorz2  = valveAppearance.House1.ViewHorz2;
			slflValve.ValveAppearance.House2.ViewHorz1  = valveAppearance.House2.ViewHorz1;;
			slflValve.ValveAppearance.House2.ViewHorz2  = valveAppearance.House2.ViewHorz2;
			slflValve.ValveAppearance.House3.ViewHorz1  = valveAppearance.House3.ViewHorz1;
			slflValve.ValveAppearance.House3.ViewHorz2  = valveAppearance.House3.ViewHorz2;
			slflValve.CurrView = currView;
			slflValve.CurrView = currView;
			slflValve.CurrView = currView;

		}
	}
}