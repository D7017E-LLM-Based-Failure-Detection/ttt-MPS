using System;
using System.ComponentModel;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using System.Reflection;
using NxtControl.Services;
using NxtControl.GuiFramework;
using NxtControl.ComponentModel;

namespace Flexbridge.FestoMPS400.Symbols.Actuator
{
	/// <summary>
	/// Description of sLflValve.
	/// </summary>
	public partial class sLflValve : SE.App2Base.Symbols.SEAppLibHMISymbol, IPropertiesNotifyChange
	{
		ValveLflAppearance valveAppearance;
		public sLflValve()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//Update Main layer availablity in Base symbol
			sLflValve1.Instancelayer = InstanceLayer.Top;
			
			valveAppearance = new ValveLflAppearance(this);
		}
		
		#region SecurityGroup
		
		// Hide default SecurityLevel
		[Browsable(false)]
		public override int SecurityLevel{get{return base.SecurityLevel;} set{base.SecurityLevel = value;}}
		
		// Owner level Security
		[DefaultValue(3), Browsable(true)]
		public override int SecOwner{ get { return base.SecOwner; } set { base.SecOwner = value; } }
		
		// Parameter level Security
		[DefaultValue(12), Browsable(true)]
		public override int SecParameter{ get { return base.SecParameter; } set { base.SecParameter = value; } }

		// Setpoint level Security
		[DefaultValue(3), Browsable(true)]
		public override int SecSetpoint{ get { return base.SecSetpoint; } set { base.SecSetpoint = value; } }

		// Mode level Security
		[DefaultValue(6), Browsable(true)]
		public override int SecMode{ get { return base.SecMode; } set { base.SecMode = value; } }


		void SLflValveSecurityOwnerChanged(bool isSecurity)
		{
			sLflValve1.SecOwner = SecOwner;
		}

		void SLflValveSecurityParameterChanged(bool isSecurity)
		{
			sLflValve1.SecParameter = SecParameter;
		}

		void SLflValveSecurityModeChanged(bool isSecurity)
		{
			sLflValve1.SecMode = SecMode;
		}

		void SLflValveSecuritySetpointChanged(bool isSecurity)
		{
			sLflValve1.SecSetpoint = SecSetpoint;
		}
		
		#endregion SecurityGroup
		
		
		#region User Properties
		
		[Browsable(true)]
		public override bool HideTagDisplayName {
			get {
				return base.HideTagDisplayName;
			}
			set {
				base.HideTagDisplayName = value;
			}
		}
		
		//Valve Appearence
		
		[RefreshProperties(RefreshProperties.All)]
		[Category("Configuration")]
		[DisplayName("Appearence")]
		[LRDescriptionAttribute("$key:SE.App2CommonProcess.Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ValveLflAppearance ValveAppearance
		{
			get {return valveAppearance;}
			set {valveAppearance = value;}
		}
		
		//Type - NO NC

		[RefreshProperties(RefreshProperties.All)]
		[Category("Configuration")]
		[DisplayName("Contact Type")]
		[LRDescriptionAttribute("$key:SE.App2CommonProcess.ValveContactType")]
		[DefaultValue(CloseOpenValve.NormallyOpen)]
		[Browsable(true)]
		public CloseOpenValve ContactType {
			get { return sLflValve1.ContactType; }
			set {
				sLflValve1.ContactType = value;
			}
		}
		
		public void UpdateIProperties()
		{
			sLflValve1.ValveAppearance.ValveType = ValveAppearance.ValveType;
			sLflValve1.ValveAppearance.ButterflyOrientation = ValveAppearance.ButterflyOrientation;
			sLflValve1.ValveAppearance.LTypeOrientation = ValveAppearance.LTypeOrientation;
			sLflValve1.ValveAppearance.TTypeOrientation = ValveAppearance.TTypeOrientation;
			sLflValve1.ValveAppearance.ThreeWayOrientation = ValveAppearance.ThreeWayOrientation;
			sLflValve1.ValveAppearance.FourWayOrientation = ValveAppearance.FourWayOrientation;
			
			DisplayAlrmInstance();
		}
		
		#endregion
		
		
		#region Alarm border
		
		//Alarm border displaying logic
		private void DisplayAlrmInstance()
		{
			alarmSAFrame1.Location = AlmFrameLocation;
			alarmSAFrame1.Size = AlmFrameSize;
		}
		
		NxtControl.Drawing.SizeF AlmFrameSize;
		NxtControl.Drawing.PointF AlmFrameLocation;
		NxtControl.Drawing.PointF instNameLocation;
		void SLflValve1OnOptionalServicesAvailable(NxtControl.Drawing.SizeF frameSize, NxtControl.Drawing.PointF frameLoc, NxtControl.Drawing.PointF instLoc)
		{
			AlmFrameSize = frameSize;
			AlmFrameLocation = frameLoc;
			instNameLocation = instLoc;
			DisplayAlrmInstance();
		}

		#endregion

	}
}



