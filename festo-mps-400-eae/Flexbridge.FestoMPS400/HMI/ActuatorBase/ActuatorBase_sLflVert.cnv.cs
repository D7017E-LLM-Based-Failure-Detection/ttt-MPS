using System;
using NxtControl.GuiFramework;
using System.ComponentModel;
using System.Reflection;
using SE.App2CommonProcess.SupportClasses;
using SE.App2Base.SupportClasses;
using NxtControl.Services;
using NxtControl.ComponentModel;
using System.Collections.Generic;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
	/// <summary>
	/// Description of sLflValve.
	/// </summary>
	
	public partial class sLflVert : SE.App2Base.Symbols.SEAppLibHMISymbol, IPropertiesNotifyChange
	{
		private ActiveStates activeState = ActiveStates.De_Active;

		
		public sLflVert()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			valveAppearance = new sLFLValveAppearance(this);
			
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
		public override void EndInit()
		{
			setLocation();
			DisplayAlrmInstance();
			
			base.EndInit();
		}

		#region Abnormal
		//Count threshold warning is forced
		bool countThresholdSt;
		void CountThresholdOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			countThresholdSt = Abnormal;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Duration threshold warning is forced
		bool durationThresholdSt;
		void DurationThresholdOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			durationThresholdSt = Abnormal;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Feedback failure alarm is forced
		bool feedbackeFailureSt;
		void FeedbackFailureOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			feedbackeFailureSt = Abnormal;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Simulation mode
		bool simulation;
		void SimulationValueChanged(object sender, ValueChangedEventArgs e)
		{
			simulation = (bool)e.Value;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		//Override mode
		bool over;
		void OverrideValueChanged(object sender, ValueChangedEventArgs e)
		{
			over = (bool)e.Value;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Maintenance mode
		bool maintenance;
		void MaintenanceValueChanged(object sender, ValueChangedEventArgs e)
		{
			maintenance = (bool)e.Value;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Out of service
		bool oosVal;
		void OutOfServiceValueChanged(object sender, ValueChangedEventArgs e)
		{
			oosVal = (bool)e.Value;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		//Interlock bypass and rearm required
		bool interlockActReq;
		bool interlockBypass;
		void InterlockOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			interlockBypass = Abnormal;
			interlockActReq = ActionReq;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
			ActionRequired(needReset, interlockActReq);
		}
		
		//Permissive bypass
		bool permissiveBypass;
		void PermissiveOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			permissiveBypass = Abnormal;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}
		
		//Owner abnormal
		bool ownerAbnormal;
		void OwnerOnAbnormalDetected(bool Abnormal = false, bool ActionReq = false)
		{
			ownerAbnormal = Abnormal;
			AbnornalIndication(countThresholdSt, durationThresholdSt, feedbackeFailureSt, simulation, over, maintenance, interlockBypass, permissiveBypass, ownerAbnormal, oosVal);
		}

		//Generic function to calculate abnormality
		bool AbnormalCond;
		void AbnornalIndication(bool countThreshold, bool durationThreshold, bool feedbackeFailure, bool sim, bool overr, bool maint, bool ilckAbnormal, bool permAbnormal, bool OwnerAbnormal, bool oos)
		{
			AbnormalCond = countThreshold || durationThreshold || feedbackeFailure || sim || overr || maint || ilckAbnormal || permAbnormal || OwnerAbnormal || oos;
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
		
		#endregion SecurityGroup
		
		// For Instance name display
		#region User Properties
		
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
		
		//Valve Appearence
		
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
			set {valveAppearance = value;
				UpdateIProperties();
				setLocation();}
		}
		
		
		
		
		public void UpdateIProperties()
		{
			valveBody1.ViewVert1 = valveAppearance.House1.ViewVert1;
			valveBody1.ViewVert2 = valveAppearance.House1.ViewVert2;
			valveBody2.ViewVert1 = valveAppearance.House2.ViewVert1;
			valveBody2.ViewVert2 = valveAppearance.House2.ViewVert2;
			valveBody3.ViewVert1 = valveAppearance.House3.ViewVert1;;
			valveBody3.ViewVert2 = valveAppearance.House3.ViewVert2;
			valveBody1.ViewHorz1 = valveAppearance.House1.ViewHorz1;
			valveBody1.ViewHorz2 = valveAppearance.House1.ViewHorz2;
			valveBody2.ViewHorz1 = valveAppearance.House2.ViewHorz1;;
			valveBody2.ViewHorz2 = valveAppearance.House2.ViewHorz2;
			valveBody3.ViewHorz1 = valveAppearance.House3.ViewHorz1;
			valveBody3.ViewHorz2 = valveAppearance.House3.ViewHorz2;
			valveBody1.CurrView = currView;
			valveBody2.CurrView = currView;
			valveBody3.CurrView = currView;
			setLocation();
			DisplayAlrmInstance();
		}
		
		#endregion
		
		#region Data change
		
		//Process value change detected
		Int16 valPv ;
		void PvValueChanged(object sender, ValueChangedEventArgs e)
		{
			valPv = (Int16)e.Value;
			activeState = (ActiveStates)valPv;
			StatusUpdate(valPv,iTransFb,fbFail.Value);
		}
		
		//Trans process value change detected
		Int16 iTransFb;
		void TransFbValueChanged(object sender, ValueChangedEventArgs e)
		{
			iTransFb = (Int16)e.Value;
			EquipState.enableActive2 = false;
			EquipState.EquipmentStatus(iCurrOp, iTransFb);
			StatusUpdate(valPv,iTransFb,fbFail.Value);
		}
		void StatusUpdate(int Pv, int TransPv, bool fbfail)
		{
			if(fbfail)
			{
				valveBody1.Alarm();
				valveBody2.Alarm();
				valveBody3.Alarm();
			}
			if ((Pv != 1 && Pv != 2) && (TransPv == 6 || TransPv == 7))
			{
				valveBody1.Transition();
				valveBody2.Transition();
				valveBody3.Transition();
			}
			else
				switch (Pv) {
				case 0:
					valveBody1.Close();
					valveBody2.Close();
					valveBody3.Close();
					break;
				case 1:
					valveBody1.Open();
					valveBody2.Open();
					valveBody3.Open();
					break;
				case 2:
					valveBody1.Close();
					valveBody2.Close();
					valveBody3.Close();
					break;
				case 253:
					valveBody1.Alarm();
					valveBody2.Alarm();
					valveBody3.Alarm();
					break;
			}
		}
		
		void CurrentOwnerValueChanged(object sender, ValueChangedEventArgs e)
		{
			owner.BasicOwner = (ushort)e.Value;
		}

		#region Interlock Permissive Failure Signal Update
		
		/* Move Corresponding signal to L3 base graphic DynamicShapes symbols*/
		void IlckCondValueChanged(object sender, ValueChangedEventArgs e)
		{
			interlock.InterlockSignal = interlock.Visible = (bool)e.Value;
			DisplayAlrmInstance();
		}
		bool activePerm;
		void PermOpenValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissivePassiveSignal = activePerm = (bool)e.Value;
			permissive.Visible = (!activePerm || !passivePerm);
			permissive.PermissiveActive2Signal = true;
			DisplayAlrmInstance();

		}
		bool passivePerm;
		void PermCloseValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissiveActive1Signal = passivePerm = (bool)e.Value;
			permissive.Visible = (!activePerm || !passivePerm);
			DisplayAlrmInstance();
		}
		#endregion
		

		#endregion



		

		
		//For Lib Development -start

		//Alarm border displaying logic
		private void DisplayAlrmInstance()
		{
			const int gap = 5;
			NxtControl.Drawing.PointF LOC = SymbolGroup.Location;
			NxtControl.Drawing.SizeF SIZE = SymbolGroup.Size;
			alarmFrame1.Location = new NxtControl.Drawing.PointF(LOC.X-gap, LOC.Y-gap);
			alarmFrame1.Size =new NxtControl.Drawing.SizeF(SIZE.Width+(2*gap),SIZE.Height+(2*gap));
			InstanceName.Y = alarmFrame1.Y-18;
			OptionalServicesActive();
		}
		


		//Code to decide the location of interlock permissive equipstate owner

		void setLocation()
		{
			if (valveAppearance.HouseNos == HousingNos.One)
			{
				valveBody1.Visible = true;
				valveBody2.Visible = false;
				valveBody3.Visible = false;
			}
			if (valveAppearance.HouseNos == HousingNos.Two)
			{
				valveBody1.Visible = true;
				valveBody2.Visible = true;
				valveBody3.Visible = false;
			}
			if (valveAppearance.HouseNos == HousingNos.Three)
			{
				valveBody1.Visible = true;
				valveBody2.Visible = true;
				valveBody3.Visible = true;
			}
			permissive.Location = new NxtControl.Drawing.PointF(sValve.Location.X , sValve.Location.Y + sValve.Size.Height+10);
			interlock.Location = new NxtControl.Drawing.PointF(permissive.Location.X + 20, sValve.Location.Y + sValve.Size.Height+10);
		}
		
		#region Subscription
		
		void SDefaultUpdateOptionalService(string instancePath)
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
		}
		#endregion
		
		bool ownerAvailable;
		void OwnerOnAvailablityChanged(bool Available)
		{
			ownerAvailable = Available;
			DisplayAlrmInstance();

		}
		bool interlockAvailable;
		void InterlockOnAvailablityChanged(bool Available)
		{
			interlockAvailable = Available;
			DisplayAlrmInstance();

		}
		bool permissiveAvailable;
		void PermissiveOnAvailablityChanged(bool Available)
		{
			permissiveAvailable = Available;
			DisplayAlrmInstance();
			
		}
		public delegate void OptionalServicesAvailable( NxtControl.Drawing.SizeF frameSize, NxtControl.Drawing.PointF frameLoc , NxtControl.Drawing.PointF instnameLoc);
		public event OptionalServicesAvailable OnOptionalServicesAvailable;
		void OptionalServicesActive()
		{
			setLocation();
			if (this.OnOptionalServicesAvailable != null)
				this.OnOptionalServicesAvailable(alarmFrame1.Size,alarmFrame1.Location,FrameGroup.Location);

		}
		short iCurrOp;
		void CurrentOpValueChanged(object sender, ValueChangedEventArgs e)
		{
			iCurrOp = (short)e.Value;
			EquipState.enableActive2 = false;
			EquipState.EquipmentStatus(iCurrOp, iTransFb);
		}
		VTQ<bool> fbFail;
		void FbFailValueChanged(object sender, ValueChangedEventArgs e)
		{
			fbFail = (VTQ<bool>)e.Value;
			StatusUpdate(valPv,iTransFb,fbFail.Value);
		}
		
	}
}



