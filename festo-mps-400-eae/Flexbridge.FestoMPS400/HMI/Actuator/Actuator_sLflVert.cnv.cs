using System;
using System.ComponentModel;
using NxtControl.GuiFramework;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using NxtControl.ComponentModel;
using System.Collections.Generic;

namespace Flexbridge.FestoMPS400.Symbols.Actuator
{
	/// <summary>
	/// Description of sLflVert.
	/// </summary>
	public partial class sLflVert : SE.App2Base.Symbols.SEAppLibHMISymbol, IPropertiesNotifyChange
	{
		public sLflVert()
		{
			
			InitializeComponent();
			valveAppearance = new sLFLValveAppearance(this);
			slflValve.Instancelayer = InstanceLayer.Top;
		}
	
		#region Security Group
		
		// Hide default SecurityLevel
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
		
		//Passing Security Parameters to Base symbol
		
		void sLFLValveSecurityOwnerChanged(bool isSecurity)
		{
			slflValve.SecOwner = SecOwner;
		}

		void sLFLValveSecurityParameterChanged(bool isSecurity)
		{
			slflValve.SecParameter = SecParameter;
		}

		void sLFLValveSecurityModeChanged(bool isSecurity)
		{
			slflValve.SecMode = SecMode;
		}

		void sLFLValveSecuritySetpointChanged(bool isSecurity)
		{
			slflValve.SecSetpoint = SecSetpoint;
		}
		
		#endregion Security Group
		
		# region User Properties
		
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

			FrameView();
		}
		
		# endregion
		
		public void FrameView()
		{
			alarmFrame1.Location = new NxtControl.Drawing.PointF(slflValve.Location.X + (AlmFrameLocation.X- instNameLocation.X),slflValve.Location.Y - (instNameLocation.Y - AlmFrameLocation.Y));
			alarmFrame1.Size = AlmFrameSize;
		}

		NxtControl.Drawing.SizeF AlmFrameSize;
		NxtControl.Drawing.PointF AlmFrameLocation;
		NxtControl.Drawing.PointF instNameLocation;
		void SlflValveOnOptionalServicesAvailable(NxtControl.Drawing.SizeF frameSize, NxtControl.Drawing.PointF frameLoc, NxtControl.Drawing.PointF instnameLoc)
		{
			AlmFrameSize = frameSize;
			AlmFrameLocation = frameLoc;
			instNameLocation = instnameLoc;

			FrameView();
		}
	}
}
