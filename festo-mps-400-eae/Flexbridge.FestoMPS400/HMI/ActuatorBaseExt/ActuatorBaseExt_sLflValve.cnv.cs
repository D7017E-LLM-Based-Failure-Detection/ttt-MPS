using System;
using System.ComponentModel;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using System.Reflection;
using NxtControl.Services;
using NxtControl.GuiFramework;
using NxtControl.ComponentModel;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBaseExt
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
			
			//Update BaseExt layer availablity in Base symbol
			baseControl.Instancelayer = InstanceLayer.BaseExt;
			
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
			baseControl.SecOwner = SecOwner;
		}

		void SLflValveSecurityParameterChanged(bool isSecurity)
		{
			baseControl.SecParameter = SecParameter;
		}

		void SLflValveSecurityModeChanged(bool isSecurity)
		{
			baseControl.SecMode = SecMode;
		}

		void SLflValveSecuritySetpointChanged(bool isSecurity)
		{
			baseControl.SecSetpoint = SecSetpoint;
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
			get { return baseControl.ContactType; }
			set {
				baseControl.ContactType = value;
			}
		}
		
		public void UpdateIProperties()
		{
			baseControl.ValveAppearance.ValveType = ValveAppearance.ValveType;
			baseControl.ValveAppearance.ButterflyOrientation = ValveAppearance.ButterflyOrientation;
			baseControl.ValveAppearance.LTypeOrientation = ValveAppearance.LTypeOrientation;
			baseControl.ValveAppearance.TTypeOrientation = ValveAppearance.TTypeOrientation;
			baseControl.ValveAppearance.ThreeWayOrientation = ValveAppearance.ThreeWayOrientation;
			baseControl.ValveAppearance.FourWayOrientation = ValveAppearance.FourWayOrientation;
		}
		
		#endregion

	}
}



