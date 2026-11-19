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
	/// Description of sDefault.
	/// </summary>
	public partial class sDiverter : SE.App2Base.Symbols.SEAppLibHMISymbol
	{
		public sDiverter()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//Update BaseExt layer availablity in Base symbol
			sDiverter1.Instancelayer = InstanceLayer.BaseExt;
			
		}
		
		#region Security Group
		
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

		void SDefaultSecurityOwnerChanged(bool isSecurity)
		{
			sDiverter1.SecOwner = SecOwner;
		}

		void SDefaultSecurityParameterChanged(bool isSecurity)
		{
			sDiverter1.SecParameter = SecParameter;
		}

		void SDefaultSecuritySetpointChanged(bool isSecurity)
		{
			sDiverter1.SecSetpoint = SecSetpoint;
		}

		void SDefaultSecurityModeChanged(bool isSecurity)
		{
			sDiverter1.SecMode = SecMode;
		}
		
		#endregion Security Group
		
		[Browsable(true)]
		public override bool HideTagDisplayName {
			get {
				return base.HideTagDisplayName;
			}
			set {
				base.HideTagDisplayName = value;
			}
		}
		
	}
}



