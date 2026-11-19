using System;
using System.ComponentModel;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using NxtControl.ComponentModel;


namespace Flexbridge.FestoMPS400.Symbols.Actuator
{
	/// <summary>
	/// Description of sDefault.
	/// </summary>
	public partial class sDefault : SE.App2Base.Symbols.SEAppLibHMISymbol, IPropertiesNotifyChange
	{
		
		ValveAppearance valveAppearance;
		public sDefault()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			//Update Main layer availablity in Base symbol
			sDefault1.Instancelayer = InstanceLayer.Top;
			
			valveAppearance = new ValveAppearance(this);
		}
		
		bool initProperties;
		public override void EndInit()
		{
			if (!initProperties)
				UpdateIProperties();
			
			base.EndInit();
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
			sDefault1.SecOwner = SecOwner;
		}

		void SDefaultSecurityParameterChanged(bool isSecurity)
		{
			sDefault1.SecParameter = SecParameter;
		}

		void SDefaultSecuritySetpointChanged(bool isSecurity)
		{
			sDefault1.SecSetpoint = SecSetpoint;
		}

		void SDefaultSecurityModeChanged(bool isSecurity)
		{
			sDefault1.SecMode = SecMode;
		}
		
		#endregion Security Group
		
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
		public ValveAppearance ValveAppearance
		{
			get {return valveAppearance;}
			set {valveAppearance = value;}
		}
		
		public void UpdateIProperties()
		{
			initProperties = true;
			
			sDefault1.ValveAppearance.ValveType = ValveAppearance.ValveType;
			sDefault1.ValveAppearance.Rotation = ValveAppearance.Rotation;
			sDefault1.ValveAppearance.Orientation = ValveAppearance.Orientation;
			sDefault1.ValveAppearance.HorizontalFlow = ValveAppearance.HorizontalFlow;
			sDefault1.ValveAppearance.VerticalFlow = ValveAppearance.VerticalFlow;
			
			//Setting the View
			FrameView();
		}
		
		#endregion User Properties
		

		public void FrameView()
		{
			alarmFrame1.Location = new NxtControl.Drawing.PointF(sDefault1.Location.X + (AlmFrameLocation.X- instNameLocation.X),sDefault1.Location.Y - (instNameLocation.Y - AlmFrameLocation.Y));
			alarmFrame1.Size = AlmFrameSize;
		}

		NxtControl.Drawing.SizeF AlmFrameSize;
		NxtControl.Drawing.PointF AlmFrameLocation;
		NxtControl.Drawing.PointF instNameLocation;
		void SDefault1OnOptionalServicesAvailable(NxtControl.Drawing.SizeF frameSize, NxtControl.Drawing.PointF frameLoc, NxtControl.Drawing.PointF instLoc)
		{
			AlmFrameSize = frameSize;
			AlmFrameLocation = frameLoc;
			instNameLocation = instLoc;

			FrameView();
		}

		//Generic function to set the size and location of alarm frame


	}
}




