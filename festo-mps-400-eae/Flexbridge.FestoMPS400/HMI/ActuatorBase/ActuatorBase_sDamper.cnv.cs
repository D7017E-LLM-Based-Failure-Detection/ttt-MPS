using System;
using System.Drawing;
using System.ComponentModel;
using NxtControl.GuiFramework;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using NxtControl.ComponentModel;
using System.Collections.Generic;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
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
			InstanceName.Text = "Valve";
			
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
		
		//Count threshold warning is forced
		bool countThresholdSt;
		void CountThresholdOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			countThresholdSt = Abnormal;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Duration threshold warning is forced
		bool durationThresholdSt;
		void DurationThresholdOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			durationThresholdSt = Abnormal;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Feedback failure alarm is forced
		bool feedbackeFailureSt;
		void FeedbackFailureOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			feedbackeFailureSt = Abnormal;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Simulation mode
		bool simulation;
		void SimulationValueChanged(object sender, ValueChangedEventArgs e)
		{
			
			simulation = (bool)e.Value;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Override mode
		bool over;
		void OverrideValueChanged(object sender, ValueChangedEventArgs e)
		{
			over = (bool)e.Value;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		
		//Maintenance mode
		bool maintenance;
		void MaintenanceValueChanged(object sender, ValueChangedEventArgs e)
		{
			maintenance = (bool)e.Value;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Oos mode
		bool oosVal;
		void OutOfServiceValueChanged(object sender, ValueChangedEventArgs e)
		{
			oosVal = (bool)e.Value;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		
		//Interlock bypass and rearm required
		bool interlockActReq;
		bool interlockBypass;
		void InterlockOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			interlockBypass = Abnormal;
			interlockActReq = ActionReq;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
			ActionRequired(needReset, interlockActReq);
		}
		
		//Permissive bypass
		bool permissiveBypass;
		void PermissiveOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			permissiveBypass = Abnormal;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Owner abnormal
		bool ownerAbnormal;
		void OwnerOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			ownerAbnormal = Abnormal;
			AbnormalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
			FrameView();
			
		}

		//Generic function to calculate abnormality
		bool AbnormalCond;
		void AbnormalIndication(bool countThreshold, bool durationThreshold, bool feedbackeFailure, bool sim, bool overr, bool maint, bool ilckAbnormal, bool permAbnormal, bool OwnerAbnormal, bool OosState)
		{
			AbnormalCond = countThreshold || durationThreshold || feedbackeFailure || sim || overr || maint || ilckAbnormal || permAbnormal || OwnerAbnormal || OosState;
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
			Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fp = hmiFaceplate as Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault;
			
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
		#region User properties
		ServoRotation rotation = ServoRotation.Horizontal;
		[DefaultValue(""), RefreshProperties(RefreshProperties.All), Category("Configuration") , LRDescriptionAttribute("$key:SE.App2CommonProcess.Rotation")]
		[Browsable(true)]
			public ServoRotation Rotation {
			get { return rotation; }
			set {
				rotation = value;
				SValve.Rotation = rotation;
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
		
		
		void StatusUpdate(int Pv, int TransPv, bool fbfail)
		{
			if(fbfail)
			{
				SValve.AlarmState();
			}
			else
			{
				if ((Pv != 1 && Pv != 2) && (TransPv == 6 || TransPv == 7))
					SValve.Transition();
				else
					switch (Pv) {
					case 0:
						SValve.DeactiveState();
						break;
					case 1:
						SValve.ActiveState();
						break;
					case 2:
						SValve.DeactiveState();
						break;
					case 253:
						SValve.AlarmState();
						break;
				}
			}
		}
		
		//Current output value change detected
		short iOp;
		void CurrentOpValueChanged(object sender, ValueChangedEventArgs e)
		{
			iOp = (short)e.Value;
			SValve.EnAct2 = false;
			SValve.OpValue = (SpOpFbState)iOp;
			
		}

		//Trans process value change detected
		Int16 iTransPv;
		void TransFbStatusChanged(object sender, ValueChangedEventArgs e)
		{
			iTransPv = (Int16)e.Value;
			StatusUpdate(iPv,iTransPv,fbFail.Value);
			SValve.TransFbValue = iTransPv;
			
		}
		
		VTQ<bool> fbFail;
		void FbFailValueChanged(object sender, ValueChangedEventArgs e)
		{
			fbFail = (VTQ<bool>)e.Value;
			StatusUpdate(iPv,iTransPv,fbFail.Value);
		}
		
		void ExcInterlockValueChanged(object sender, ValueChangedEventArgs e)
		{

			interlock.InterlockSignal = interlock.Visible = (bool)e.Value;
			OptionalServicesActive();
		}
		bool passivePerm;
		void PassivePemissiveValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissivePassiveSignal = passivePerm = (bool)e.Value;
			permissive.Visible = (!activePerm || !passivePerm);
			permissive.PermissiveActive2Signal = true;
			OptionalServicesActive();
		}
		bool activePerm;
		void ActivePermissiveValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissiveActive1Signal = activePerm = (bool)e.Value;
			permissive.Visible = (!activePerm || !passivePerm);
			OptionalServicesActive();
		}
		
		void CurrentOwnerValueChanged(object sender, ValueChangedEventArgs e)
		{
			owner.BasicOwner = (ushort)e.Value;
			OptionalServicesActive();
		}

		#endregion

		#region Graphics Animation
		
		
		//Set the size and location of alarm frame, interlock and permissive

		void FrameView()
		{
			const int gap = 5;
			NxtControl.Drawing.PointF LOC = SymbolGroup.Location;
			NxtControl.Drawing.SizeF SIZE = SymbolGroup.Size;
			alarmFrame1.Location = new NxtControl.Drawing.PointF(LOC.X-gap, LOC.Y-gap);
			alarmFrame1.Size =new NxtControl.Drawing.SizeF(SIZE.Width+(2*gap),SIZE.Height+(2*gap));
			if(rotation == ServoRotation.Horizontal)
			
			{
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
			InstanceName.Location = new NxtControl.Drawing.PointF(117, alarmFrame1.Y-18);	
			}
		}

		
		#endregion
		#region Subscription
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
			OptionalServicesActive();
			//FrameView();
		}
		
		
		bool ownerAvailable;
		void OwnerOnAvailablityChanged(bool Available)
		{
			ownerAvailable = Available;
			OptionalServicesActive();
			//FrameView();
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

			//permissiveAvailable = Available;
			//MessageBox(permissiveAvailable.ToString(),"Hiiiiii");
			
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





