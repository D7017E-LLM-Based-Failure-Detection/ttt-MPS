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
	
	public partial class sLflValve : SE.App2Base.Symbols.SEAppLibHMISymbol, IPropertiesNotifyChange
	{
		private ActiveStates activeState = ActiveStates.De_Active;
		bool ret = false;
		ValveLflAppearance valveAppearance;
		public sLflValve()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			setInitialHieghtWidth();
			valveAppearance = new ValveLflAppearance(this);
			
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
			setView();
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
		
		[RefreshProperties(RefreshProperties.All)]
		[Category("Configuration")]
		[DisplayName("Appearence")]
		[LRDescriptionAttribute("$key:SE.App2CommonProcess.Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ValveLflAppearance ValveAppearance {
			get { return valveAppearance; }
			set { valveAppearance = value; }
		}
		
		//Type - NO NC
		
		private CloseOpenValve iSubCloseOpenValve = CloseOpenValve.NormallyOpen;
		[RefreshProperties(RefreshProperties.All)]
		[Category("Configuration")]
		[DisplayName("Contact Type")]
		[LRDescriptionAttribute("$key:SE.App2CommonProcess.ValveContactType")]
		[DefaultValue(CloseOpenValve.NormallyOpen)]
		[Browsable(true)]
		public CloseOpenValve ContactType {
			get { return this.iSubCloseOpenValve; }
			set {
				this.iSubCloseOpenValve = value;
				
				setView();
				DisplayAlrmInstance();
			}
		}
		
		public void UpdateIProperties()
		{
			setView();
			DisplayAlrmInstance();
		}
		
		#endregion
		
		#region Data change
		
		//Process value change detected
		Int16 valPv;
		void PvValueChanged(object sender, ValueChangedEventArgs e)
		{
			valPv = (Int16)e.Value;
			activeState = (ActiveStates)valPv;
			StatusUpdate(valPv,iTransFb,fbFail.Value);
		}
		
		//Trans process value change detected
		NxtControl.Drawing.Color ActiveColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.aaLibSymBodyActive");
		NxtControl.Drawing.Color PassiveColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.aaLibSymBodyPassive");
		NxtControl.Drawing.Color TransitionColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.aaLibSymBodyTransition");
		NxtControl.Drawing.Color AlarmColor =  NxtControl.Drawing.Color.FromName("SE.App2Base.aaLibSymBodyAlarm");

		Int16 iTransFb;
		void TransFbValueChanged(object sender, ValueChangedEventArgs e)
		{
			iTransFb = (Int16)e.Value;
			EquipState.enableActive2 = false;
			EquipState.EquipmentStatus(iCurrOp, iTransFb);
			if (iTransFb == 0 || iTransFb == 1 || iTransFb == 2)
				setView();
			StatusUpdate(valPv,iTransFb,fbFail.Value);
		}
		
		void StatusUpdate(int Pv, int TransPv, bool fbfail)
		{
			if(fbfail)
			{
				rectangle1.BrushColor = rectangle2.BrushColor = rectangle3.BrushColor = AlarmColor;
			}
			else
			{
				if ((Pv != 1 && Pv != 2) && (TransPv == 6 || TransPv == 7))
					rectangle1.BrushColor = rectangle2.BrushColor = rectangle3.BrushColor = TransitionColor;
				else
					switch (Pv) {
					case 0:
						rectangle1.BrushColor = rectangle2.BrushColor = rectangle3.BrushColor = PassiveColor;
						break;
					case 1:
						rectangle1.BrushColor = rectangle2.BrushColor = rectangle3.BrushColor = ActiveColor;
						break;
					case 2:
						rectangle1.BrushColor = rectangle2.BrushColor = rectangle3.BrushColor = PassiveColor;
						break;
					case 253:
						rectangle1.BrushColor = rectangle2.BrushColor = rectangle3.BrushColor = AlarmColor;
						break;
				}
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
			OptionalServicesActive();
		}
		bool activePerm;
		void PermOpenValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissivePassiveSignal = activePerm = (bool)e.Value;
			permissive.Visible = (!activePerm || !passivePerm);
			permissive.PermissiveActive2Signal = true;
			OptionalServicesActive();

		}
		bool passivePerm;
		void PermCloseValueChanged(object sender, ValueChangedEventArgs e)
		{
			permissive.PermissiveActive1Signal = passivePerm = (bool)e.Value;
			permissive.Visible = (!activePerm || !passivePerm);
			OptionalServicesActive();
		}
		#endregion
		

		#endregion

		#region Graphics Animation
		private double fHieght;
		private double fWidth;
		
		//Initial Hieght of group2 and Width of group1
		private void setInitialHieghtWidth()
		{
			//Initial Hieght of group2
			foreach (IComponent c in group2.Shapes) {
				
				if (c.GetType().ToString() == "NxtControl.GuiFramework.Rectangle") {
					fHieght = ((NxtControl.GuiFramework.Rectangle)c).Height;
				}
			}
			
			//Initial Width of group1
			foreach (IComponent c in group1.Shapes) {
				
				if (c.GetType().ToString() == "NxtControl.GuiFramework.Rectangle") {
					fWidth = ((NxtControl.GuiFramework.Rectangle)c).Width;
				}
			}
		}
		
		//Set line visibility
		private void setLVisible(bool val, IComponent c)
		{
			((NxtControl.GuiFramework.Line)c).Visible = val;
		}
		
		private bool Decoration(bool isVert, bool isHalf, bool[] Lineset_VisHid, bool isMixed = false)
		{
			float fHalf = 1F, fAdjust = 0F;
			int i = 0;
			
			group3.Visible = isMixed;
			group2.Visible = isMixed ? false : isVert;
			group1.Visible = isMixed ? false : !isVert;
			
			if (!isMixed) {
				ShapeCollection gShapes = group1.Visible ? group1.Shapes : group2.Shapes;
				foreach (IComponent c in gShapes) {
					
					if (c.GetType().ToString() == "NxtControl.GuiFramework.Rectangle") {
						var iRes = isHalf ? fHalf = 2F : fHalf = 1F;
						var i1Res = isHalf ? fAdjust = 6F : fAdjust = 0F;
						
						
						//Initial Hieght of group2 and Width of group1
						if (isVert)
							((NxtControl.GuiFramework.Rectangle)c).Height = fHieght;
						if (!isVert)
							((NxtControl.GuiFramework.Rectangle)c).Width = fWidth;
						
						if (isVert)
							((NxtControl.GuiFramework.Rectangle)c).Height = ((NxtControl.GuiFramework.Rectangle)c).Height / fHalf - fAdjust;
						if (!isVert)
							((NxtControl.GuiFramework.Rectangle)c).Width = ((NxtControl.GuiFramework.Rectangle)c).Width / fHalf - fAdjust;
						
					}
					if (c.GetType().ToString() == "NxtControl.GuiFramework.Line") {
						
						i = i + 1;
						switch (i) {
							case 1:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 2:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 3:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 4:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 5:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 6:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 7:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 8:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 9:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
						}
						
					}
				}
			} else {
				
				foreach (IComponent c in group3.Shapes) {
					if (c.GetType().ToString() == "NxtControl.GuiFramework.Line") {
						
						i = i + 1;
						switch (i) {
							case 1:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 2:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 3:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 4:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 5:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 6:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 7:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 8:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 9:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 10:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 11:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 12:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
							case 13:
								setLVisible(Lineset_VisHid[i - 1], c);
								break;
						}
						
					}
				}
			}
			return true;
		}
		
		//For Lib Development -start
		public void setView()
		{
			//Butterfly decoration
			if (ValveAppearance.ValveType == lFlValves.Butterfly) {
				abnormal.Location = new NxtControl.Drawing.PointF(80,50);
				
				if (this.ValveAppearance.ButterflyOrientation == ButterflyValve.Horizontal && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ButterflyOrientation == ButterflyValve.Vertical && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 2;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ButterflyOrientation == ButterflyValve.Horizontal && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ButterflyOrientation == ButterflyValve.Vertical && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 2;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	true,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
			}
			
			//LType decoration
			if (ValveAppearance.ValveType == lFlValves.LType) {
				iLocation = 1;
				abnormal.Location = new NxtControl.Drawing.PointF(104, 61);
				
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.DownLeft && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.DownRight && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.UpLeft && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.UpRight && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.DownLeft && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.DownRight && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.UpLeft && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.LTypeOrientation == LTypeValve.UpRight && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
			}
			
			//TType decoration
			if (ValveAppearance.ValveType == lFlValves.TType) {
				iLocation = 1;
				abnormal.Location = new NxtControl.Drawing.PointF(104, 61);
				
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Down && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Left && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Up && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Right && iSubCloseOpenValve == CloseOpenValve.NormallyOpen)
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Down && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Left && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Up && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				if (this.ValveAppearance.TTypeOrientation == TTypeValve.Right && iSubCloseOpenValve == CloseOpenValve.NormallyClosed)
					ret = (activeState == ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
					                	false,
					                	true,
					                	false,
					                	true,
					                	false,
					                	false,
					                	false,
					                	false,
					                	false
					                });
				
			}
			
			//3WayValveType decoration
			if (ValveAppearance.ValveType == lFlValves.ThreeWay) {
				abnormal.Location = new NxtControl.Drawing.PointF(104, 61);
				
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.DownLeft) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.DownLeftHorizontal) {
					iLocation = 2;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.DownRightHorizontal) {
					iLocation = 2;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.DownRightVertical) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.UpLeft) {
					iLocation = 2;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.UpleftVertical) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.UpRight) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.UprightHorizontal) {
					iLocation = 2;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.RightDownHorizontal) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.RightLeftHorizontal) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.LeftDownHorizontal) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
				if (this.ValveAppearance.ThreeWayOrientation == ThreeWayValve.LeftRightHorizontal) {
					iLocation = 1;
					ret = (activeState != ActiveStates.Active) ? Decoration(true, true, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false
					                                                        }) : Decoration(true, true, new bool[] {
						                	true,
						                	false,
						                	true,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false,
						                	false
						                });
				}
				
			}
			
			//4WayValveType decoration
			if (ValveAppearance.ValveType == lFlValves.FourWay) {
				
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.One && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Two && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Three && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Four && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Five && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Six && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Seven && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Eight && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Nine && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Ten && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Eleven && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Twelve && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Thirteen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Forteen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					;
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Fifteen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Sixteen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Seventeen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Eighteen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Ninteen && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Twenty && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyOne && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyTwo && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyThree && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState != ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyFour && iSubCloseOpenValve == CloseOpenValve.NormallyOpen) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState != ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.One && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Two && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Three && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Four && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Five && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Six && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Seven && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Eight && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Nine && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Ten && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Eleven && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Twelve && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Thirteen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Forteen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Fifteen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Sixteen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Seventeen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Eighteen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Ninteen && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.Twenty && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyOne && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });

				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyTwo && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });

				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyThree && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 1;
					abnormal.Location = new NxtControl.Drawing.PointF(104, 95);
					ret = (activeState == ActiveStates.Active) ? Decoration(true, false, new bool[] {
					                                                        	true,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	true
					                                                        }) : Decoration(true, false, new bool[] {
						                	true,
						                	false,
						                	false,
						                	true,
						                	true,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
				if (this.ValveAppearance.FourWayOrientation == FourWayValve.TwentyFour && iSubCloseOpenValve == CloseOpenValve.NormallyClosed) {
					iLocation = 3;
					abnormal.Location = new NxtControl.Drawing.PointF(131, 90);
					ret = (activeState == ActiveStates.Active) ? Decoration(false, false, new bool[] {
					                                                        	true,
					                                                        	false,
					                                                        	true,
					                                                        	false,
					                                                        	false,
					                                                        	false,
					                                                        	true,
					                                                        	true,
					                                                        	true
					                                                        }) : Decoration(false, false, new bool[] {
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true,
						                	true,
						                	false,
						                	true
						                });
				}
			}
			
			DisplayAlrmInstance();
			setLocation();
		}
		
		//Alarm border displaying logic
		private void DisplayAlrmInstance()
		{
			const int gap = 5;
			NxtControl.Drawing.PointF LOC = SymbolGroup.Location;
			NxtControl.Drawing.SizeF SIZE = SymbolGroup.Size;
			alarmFrame1.Location = new NxtControl.Drawing.PointF(LOC.X-gap, LOC.Y-gap);
			alarmFrame1.Size =new NxtControl.Drawing.SizeF(SIZE.Width+(2*gap),SIZE.Height+(2*gap));
			InstanceName.Y = alarmFrame1.Y-18;
		}
		


		#endregion

		//Code to decide the location of interlock permissive equipstate owner
		ushort iLocation;
		void setLocation()
		{
			switch (iLocation) {
				case 1:
					interlock.Location = new NxtControl.Drawing.PointF(45, 26);
					permissive.Location = new NxtControl.Drawing.PointF(62, 26);
					EquipState.Location = new NxtControl.Drawing.PointF(83, 26);
					owner.Location = new NxtControl.Drawing.PointF(100, 26);
					break;
				case 2:
					interlock.Location = new NxtControl.Drawing.PointF(6, 47);
					permissive.Location = new NxtControl.Drawing.PointF(23, 47);
					EquipState.Location = new NxtControl.Drawing.PointF(43, 47);
					owner.Location = new NxtControl.Drawing.PointF(60, 47);
					break;
				case 3:
					interlock.Location = new NxtControl.Drawing.PointF(10, 76);
					permissive.Location = new NxtControl.Drawing.PointF(27, 76);
					EquipState.Location = new NxtControl.Drawing.PointF(46, 76);
					owner.Location = new NxtControl.Drawing.PointF(63, 76);
					break;
			}
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
			setLocation();
			DisplayAlrmInstance();
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



