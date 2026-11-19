using System;
using System.ComponentModel;
using NxtControl.GuiFramework;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using NxtControl.ComponentModel;
using System.Collections.Generic;

namespace Flexbridge.FestoMPS400.Symbols.Actuator2OpBase
{
	/// <summary>
	/// DescRightiption of sDefault.
	/// </summary>
	public partial class sDamper :  SE.App2Base.Symbols.SEAppLibHMISymbol
	{
		
		public sDamper()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			InstanceName.Text = "Valve2Op";
			
			SymbolGroup = new NxtControl.GuiFramework.Group();
			SymbolGroup.BeginInit();SymbolGroup.Visible = false;
			SymbolGroup.Shapes.AddRange(getSymbolsGroup(false));
			this.shapes.AddRange(new System.ComponentModel.IComponent[] {SymbolGroup});
			SymbolGroup.EndInit();
			
			
			FrameGroup = new NxtControl.GuiFramework.Group();
			FrameGroup.BeginInit();FrameGroup.Visible = false;
			FrameGroup.Shapes.AddRange(getSymbolsGroup(true));
			this.shapes.AddRange(new System.ComponentModel.IComponent[] {FrameGroup});
			FrameGroup.EndInit();
		}
		private IComponent[] getSymbolsGroup(bool GetAll)
		{
			var requiredCollection = new List<IComponent>();
			var shapeCollect = this.Shapes;
			if (!GetAll)
			{
				foreach (IComponent element in shapeCollect) {
					if(element.GetType().FullName.StartsWith("System.HMI.Symbols.Base.Execute<",StringComparison.OrdinalIgnoreCase) || element is NxtControl.GuiFramework.AlarmFrame || element is NxtControl.GuiFramework.AliasDisplayLabel)
					{continue;}
					else	{requiredCollection.Add(element);}
				}
			}
			else
			{
				foreach (IComponent element in shapeCollect) {
					if(element.GetType().FullName.StartsWith("System.HMI.Symbols.Base.Execute<",StringComparison.OrdinalIgnoreCase))
					{continue;}
					else	{requiredCollection.Add(element);}
				}
			}
			return requiredCollection.ToArray();
		}
		
		
		NxtControl.GuiFramework.Group FrameGroup;
		NxtControl.GuiFramework.Group SymbolGroup;
		
		
		#region Abnormal
		

		
		//Simulation mode
		bool simulation;
		void SimulationValueChanged(object sender, ValueChangedEventArgs e)
		{
			simulation = (bool)e.Value;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Override
		bool over;
		void FbOverrideValueChanged(object sender, ValueChangedEventArgs e)
		{
			over = (bool)e.Value;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Maintenance mode
		bool maintenance;
		void MaintenanceValueChanged(object sender, ValueChangedEventArgs e)
		{
			maintenance = (bool)e.Value;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Oos mode
		bool oosVal;
		void OutOfServiceValueChanged(object sender, ValueChangedEventArgs e)
		{
			oosVal = (bool)e.Value;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		
		//Interlock bypass and rearm required
		bool interlockActReq;
		bool interlockBypass;
		void InterlockOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			interlockBypass = Abnormal;
			interlockActReq = ActionReq;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
			ActionRequired(needReset, interlockActReq);
		}
		
		//Permissive bypass
		bool permissiveBypass;
		void PermissiveOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			permissiveBypass = Abnormal;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Owner abnormal
		bool ownerAbnormal;
		void OwnerOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			ownerAbnormal = Abnormal;
			AbnornalIndication(simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		//Generic function to calculate abnormality
		bool AbnormalCond;
		void AbnornalIndication(bool sim, bool overr, bool maint, bool ilckAbnormal, bool permAbnormal, bool OwnerAbnormal, bool OosState)
		{
			AbnormalCond = sim || overr || maint || ilckAbnormal || permAbnormal || OwnerAbnormal || OosState;
			abnormal.Abnormality(AbnormalCond, ActionReqCond);
		}
		
		#endregion


		#region Action Required
		//Rearm required
		bool needReset;
		void NeedResetValueChanged(object sender, ValueChangedEventArgs e)
		{
			needReset = (bool)e.Value;
			ActionRequired(needReset, interlockActReq);
		}
		
		//Generic function to calculate action required
		bool ActionReqCond;
		void ActionRequired(bool RearmReq, bool ilckActionReq)
		{
			ActionReqCond = RearmReq || ilckActionReq;
			abnormal.Abnormality(AbnormalCond, ActionReqCond);
		}
		
		#endregion
		
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
		
		#endregion
		
		//Hide Instance Name
	
		[DefaultValue(false), Browsable (true)]
		public override bool HideTagDisplayName {
			get {
				return base.HideTagDisplayName;
			}
			set {
				base.HideTagDisplayName = value;
				InstanceName.Visible = !HideTagDisplayName;
			}
		}

		// For Instance name display

		public override void UpdateTagDisplayName()
		{
			base.UpdateTagDisplayName();
			InstanceName.CustomInstanceName = TagDisplayName;
			alarmFrame1.Visible = (Instancelayer != InstanceLayer.Top);
		}
		
		
		//Move the required data from symbol to faceplate on initialize
		protected override void OnInitializeFaceplate(HMIFaceplate hmiFaceplate)
		{
			Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fp = hmiFaceplate as Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault;
			
			if (fp != null) {
				fp.TitleText = MyTagDisplayName;
				fp.SecOwner = SecOwner;
				fp.SecMode = SecMode;
				fp.SecParameter = SecParameter;
				fp.SecSetpoint = SecSetpoint;
				fp.Tooltip = this.tooltip;
			}
			
			base.OnInitializeFaceplate(hmiFaceplate);
		}
#region User Properties

		ServoRotation rotation = ServoRotation.Horizontal;
		[DefaultValue(""), RefreshProperties(RefreshProperties.All), Category("Configuration") , LRDescriptionAttribute("$key:SE.App2CommonProcess.Rotation")]
		[Browsable(true)]
			public ServoRotation Rotation {
			get { return rotation; }
			set {
				rotation = value;
				SValve1.Rotation = rotation;
				FrameView();
				}
		}
		
		#endregion
		

		#region Data change
		//Process value change detected
		private Int16 iPv;
		void FbStatusChanged(object sender, ValueChangedEventArgs e)
		{
			iPv = (Int16)e.Value;
			StatusUpdate(iPv,iTransPv,fbFail.Value);
		}
		
		void StatusUpdate(int Pv,int TransPv,bool fbfail)
		{
			if(fbfail)
				SValve1.AlarmState();
			else
			{
				if ((Pv != 1 && Pv != 2) && (TransPv == 6 || TransPv == 7 || TransPv == 5))
				{
					if (iTransPv == 7)
						SValve1.Transition();
					else if (iTransPv == 6)
						SValve1.Transition();
					else if (iTransPv == 5)
						SValve1.Transition();
				}
				else
					switch (Pv) {
					case 0:
						SValve1.PartiallyActive();
						break;
					case 1:
						SValve1.ActiveState();
						break;
					case 2:
						SValve1.DeactiveState();
						break;
					case 253:
						SValve1.AlarmState();
						break;
				}
			}
		}
		
		//Current output value change detected
		short iOp;
		void CurrentOpValueChanged(object sender, ValueChangedEventArgs e)
		{
			iOp = (short)e.Value;
			SValve1.EnAct2 = true;
			SValve1.OpValue = (SpOpFbState)iOp;
		}

		//Trans process value change detected
		Int16 iTransPv;
		void TransFbStatusChanged(object sender, ValueChangedEventArgs e)
		{
			iTransPv = (Int16)e.Value;
			SValve1.EnAct2 = true;
			SValve1.TransFbValue = iTransPv;
			StatusUpdate(iPv,iTransPv,fbFail.Value);
		}
		
		VTQ<bool> fbFail;
		void FbFailValueChanged(object sender, ValueChangedEventArgs e)
		{
			fbFail = (VTQ<bool>)e.Value;
			StatusUpdate(iPv,iTransPv,fbFail.Value);
		}
		
		void CurrentOwnerValueChanged(object sender, ValueChangedEventArgs e)
		{
			owner.BasicOwner = (ushort)e.Value;
		}
		void ExcInterlockValueChanged(object sender, ValueChangedEventArgs e)
		{
			interlock.InterlockSignal = interlock.Visible = (bool)e.Value;
			OptionalServicesActive();

		}
		bool permstop;
		void PermStopValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissivePassiveSignal = permstop =(bool)e.Value;
			permissive.Visible = (!permopen||!permclose||!permstop);
			OptionalServicesActive();
		}
		bool permclose;
		void PermCloseValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissiveActive2Signal = permclose =(bool)e.Value;
			permissive.Visible = (!permopen||!permclose||!permstop);
			OptionalServicesActive();
		}
		bool permopen;
		void PermOpenValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissiveActive1Signal = permopen =(bool)e.Value;
			permissive.Visible = (!permopen||!permclose||!permstop);
			OptionalServicesActive();
		}
		#endregion

		#region Graphics Animation
		
		//Set View method helps to derive different type of valve symbol using properties
		
		//Element style changes when the state is active
		NxtControl.Drawing.Color ActiveColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.ActiveStatus");
		NxtControl.Drawing.Color PassiveColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.PassiveStatus");
		NxtControl.Drawing.Color TransitionColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.Transition");
		NxtControl.Drawing.Color UnknownColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.Unknown");
		NxtControl.Drawing.Color NotRunningColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.NotRunning");
		
		//Set the size and location of alarm frame, interlock and permissive
		void FrameView()
		{

			const int gap = 5;
			NxtControl.Drawing.PointF LOC = SymbolGroup.Location;
			NxtControl.Drawing.SizeF SIZE = SymbolGroup.Size;
			alarmFrame1.Location = new NxtControl.Drawing.PointF(LOC.X-gap, LOC.Y-gap);
			alarmFrame1.Size =new NxtControl.Drawing.SizeF(SIZE.Width+(2*gap),SIZE.Height+(2*gap));
			
			if (rotation == ServoRotation.Horizontal) {
			permissive.Location = new NxtControl.Drawing.PointF(99,106);
			interlock.Location = new NxtControl.Drawing.PointF(81,106);
			owner.Location = new NxtControl.Drawing.PointF(107,47);
			abnormal.Location = new NxtControl.Drawing.PointF(104,65);
			InstanceName.Location = new NxtControl.Drawing.PointF(72, alarmFrame1.Y-18);
			InstanceName.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;}
			
			else if(rotation == ServoRotation.Vertical){
			abnormal.Location = new NxtControl.Drawing.PointF(83,63);
			permissive.Location = new NxtControl.Drawing.PointF(125, 78);
			interlock.Location = new NxtControl.Drawing.PointF(125, 61);
			owner.Location = new NxtControl.Drawing.PointF(63,55);
			InstanceName.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleLeft;
			InstanceName.Location = new NxtControl.Drawing.PointF(117, alarmFrame1.Y-18);	}
		}


		
		#endregion
		
		#region subscription
		void SDefaultConnStateChanged(string instancePath)
		{
			owner.InstanceName = FindInstanceLayer(InstanceLayer.BaseExt) + ".serviceManager.owner";
			interlock.InstanceName = FindInstanceLayer(InstanceLayer.Top) + ".interlock";
			permissive.InstanceName = FindInstanceLayer(InstanceLayer.Top) + ".permissive";
		}
		

		bool externalOwner;
		void StdOwnerConnectedValueChanged(object sender, ValueChangedEventArgs e)
		{
			externalOwner = (bool)e.Value;
			owner.ExternalAvailable = externalOwner;
			FrameView();
		}
		
		
		bool ownerAvailable;
		void OwnerOnAvailablityChanged(bool Available)
		{
			ownerAvailable = Available;
			OptionalServicesActive();
		}
		
		bool interlockAvailable;
		void InterlockOnAvailablityChanged(bool Available)
		{
			interlockAvailable = Available;

			OptionalServicesActive();
		}
		
		bool permissiveAvailable;
		void PermissiveOnAvailablityChanged(bool Available)
		{
			permissiveAvailable = Available;
			OptionalServicesActive();
		}
		
		public delegate void OptionalServicesAvailable( NxtControl.Drawing.SizeF frameSize, NxtControl.Drawing.PointF frameLoc , NxtControl.Drawing.PointF instnameLoc);
		public event OptionalServicesAvailable OnOptionalServicesAvailable;
		
		void OptionalServicesActive()
		{
			FrameView();
			if (this.OnOptionalServicesAvailable != null)
			{
				this.OnOptionalServicesAvailable(alarmFrame1.Size,alarmFrame1.Location,FrameGroup.Location);
			}

		}

		#endregion
	}
}





