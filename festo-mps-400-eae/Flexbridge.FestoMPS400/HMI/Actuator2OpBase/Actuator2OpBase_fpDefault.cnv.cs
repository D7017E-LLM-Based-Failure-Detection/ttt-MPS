using System;
using System.Drawing;
using NxtControl.GuiFramework;
using System.ComponentModel;
using System.Resources;
using System.Runtime.InteropServices;
using SE.App2Base.SupportClasses;
using SE.App2CommonProcess.SupportClasses;

namespace Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase
{
	/// <summary>
	/// Description of fpDefault.
	/// </summary>
	public partial class fpDefault : SE.App2Base.Faceplates.SEAppLibHMIFaceplate
	{
		public fpDefault()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.AutoScroll = false;
			
		}
		
		#region Abnormal
		//Simulation mode
		bool Simulation;
		void SimValueChanged(object sender, ValueChangedEventArgs e)
		{
			Simulation = (bool)e.Value;
			AbnornalIndication( Simulation , OverVal , Maintenece, oosVal);
		}
		
		//Override mode
		bool OverVal;
		void OverValueChanged(object sender, ValueChangedEventArgs e)
		{
			OverVal = (bool)e.Value;
			AbnornalIndication( Simulation , OverVal , Maintenece, oosVal);
		}
		
		//Maintenance mode
		bool Maintenece;
		void MaintValueChanged(object sender, ValueChangedEventArgs e)
		{
			Maintenece = (bool)e.Value;
			AbnornalIndication(Simulation , OverVal , Maintenece, oosVal);
		}
		
		//Oos mode
		bool oosVal;
		void OosValueChanged(object sender, ValueChangedEventArgs e)
		{
			oosVal = (bool)e.Value;
			AbnornalIndication( Simulation , OverVal , Maintenece, oosVal);
			ButtonEnablement( Owner ,CSpValue ,TransFbValue, IsSecuritySetpoint,oosVal);
		}
		//Generic function to calculate abnormality
		bool AbnormalCond;
		void AbnornalIndication(bool sim , bool over , bool maint, bool oos)
		{
			AbnormalCond = sim || over || maint || oos;
			fpNavigationPane.Abnormality("Parameter",AbnormalCond,false);
		}
		
		#endregion
		
		//**********************************************************Security Group********************************************************************
		
		//Security owner value change
		void FpDefaultSecurityOwnerChanged(bool isSecurity)
		{
			fpNavigationPane.SecOwner=SecOwner;
			SecurityVal = ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecOwner);
		}
		
		//Security parameter value change
		void FpDefaultSecurityParameterChanged(bool isSecurity)
		{
			fpNavigationPane.SecParameter=SecParameter;
		}
		
		//Security setpoint value change
		private bool SecurityValSetpoint ;
		private bool SecurityVal ;
		void FpDefaultSecuritySetpointChanged(bool isSecurity)
		{
			SecurityValSetpoint = ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecSetpoint);
			fpNavigationPane.SecSetpoint = SecSetpoint;
			ButtonEnablement( Owner ,CSpValue,TransFbValue, SecurityValSetpoint, oosVal);
		}
		
		
		//*********************************************************End of Security Group************************************************************************************************************
		
		
		//Move the required data from symbol to faceplate on initialize
		protected override void OnInitializeFaceplate(HMIFaceplate hmiFaceplate)
		{
			Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fp = hmiFaceplate as Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter;
			if (fp != null)
			{
				fp.Title = Title+" "+"Parameter";
				fp.SecMode = SecMode;
				fp.SecParameter = SecParameter;
				fp.SecOwner = SecOwner;
			}
			base.OnInitializeFaceplate(hmiFaceplate);
			
			Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fp1 = hmiFaceplate as Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend;
			if (fp1 != null)
			{
				fp1.Title = Title+" "+"Trend";
			}
			base.OnInitializeFaceplate(hmiFaceplate);
		}
		
		#region UserProperties
		//Title of the faceplate
		[DefaultValue(""), RefreshProperties(RefreshProperties.All), Category("Faceplate")]
		public string TitleText
		{
			get { return Title; }
			set
			{
				Title = value;
				fpNavigationPane.ParentTitle = value;
			}
		}
		//Enable or disable the maintenece subscription
		private bool MaintVisiblity;
		public void MaintenanceVisibility(bool MntVisible)
		{
			MaintVisiblity = MntVisible;
		}
		//Enable or disable the local panel subscription
		private bool LpVisiblity;
		public void LocalPanelVisibility(bool LpVisible)
		{
			LpVisiblity = LpVisible;

		}
		//Enable or disable the interlock/permissive/failure subscription
		private bool IlckVisiblity,PermVisiblity,FailVisiblity;
		public void InterPermFailVisibility (bool IlckVisible,bool PermVisible,bool FailVisible)
		{
			IlckVisiblity = IlckVisible;
			PermVisiblity = PermVisible;
			FailVisiblity = FailVisible;
		}

		#endregion UserProperties

		#region Data change
		//Rearm required
		void NeedResetValueChanged(object sender, ValueChangedEventArgs e)
		{
			if(SecurityValSetpoint)
				
				btnReset.Enabled = (bool) e.Value;
			else
				
				btnReset.Enabled = false;

		}
		//Process value change detected
		private short FbStatusVal;
		void FbStatusValueChanged(object sender, ValueChangedEventArgs e)
		{
			FbStatusVal = (short)e.Value;
			StatusUpdate();
		}
		
		void StatusUpdate()
		{
			if ((FbStatusVal != 1 && FbStatusVal != 2) && (TransFbValue == 6 || TransFbValue == 7) || TransFbValue == 5)
			{
				if (TransFbValue == 7)
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtTransClose";
				else if (TransFbValue == 6)
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtTransOpen";
				else if (TransFbValue == 5)
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtTransStop";
			}
			else
				switch (FbStatusVal) {
				case 0:
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtStopped";
					break;
				case 1:
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtOpen";
					break;
				case 2:
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtClosed";
					break;
				case 253:
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtUnknown";
					break;
			}
		}
		//Current setpoint value change detected
		private short CSpValue;
		void CurrentSpValueChanged(object sender, ValueChangedEventArgs e)
		{
			CSpValue = (short)e.Value;
			ButtonEnablement( Owner ,CSpValue,TransFbValue, SecurityValSetpoint, oosVal);
			switch (CSpValue){
				case(1):
					lblAutoSp.Text = "$key:SE.App2CommonProcess.TxtOpen";
					break;
				case(2):
					lblAutoSp.Text = "$key:SE.App2CommonProcess.TxtClose";
					break;
				default:
					lblAutoSp.Text = "$key:SE.App2CommonProcess.TxtStop";
					break;
			}
		}
		//Trans process value change detected
		short TransFbValue;
		void TransFbStatusChanged(object sender, ValueChangedEventArgs e)
		{
			TransFbValue = (short)e.Value;
			ButtonEnablement( Owner ,CSpValue,TransFbValue, SecurityValSetpoint, oosVal);
			StatusUpdate();
		}
		private short OpValue;
		void CurrentOpValueChanged(object sender, ValueChangedEventArgs e)
		{
			OpValue = (short)e.Value;
			switch (OpValue) {
				case(1):
					lblReqPv.Text = "$key:SE.App2CommonProcess.TxtOpen";
					break;
				case(2):
					lblReqPv.Text = "$key:SE.App2CommonProcess.TxtClose";
					break;
				default:
					lblReqPv.Text = "$key:SE.App2CommonProcess.TxtStop";
					break;
			}
		}
		#endregion

		#region Buttons
		//Click reset button
		void BtnResetClick(object sender, EventArgs e)
		{
			FireEvent_RESET_CMD(true);
		}

		//Click open button
		void BtnManOnClick(object sender, EventArgs e)
		{
			FireEvent_SP_CMD(1);
		}

		//Click close button
		void BtnManOffClick(object sender, EventArgs e)
		{
			FireEvent_SP_CMD(2);
		}
		void BtnManStopClick(object sender, EventArgs e)
		{
			FireEvent_SP_CMD(0);
		}
		//Code to enable and disable buttons on faceplate
		public void ButtonEnablement( bool Owner , short CSpval ,short TransPV ,bool SecurityVal ,bool Oos)
		{
			if (Owner && SecurityVal && !Oos)
			{
				btnManStop.Enabled = false;
				switch (CSpval)
				{
					case(0):
						btnManOn.Enabled = true;
						btnManOff.Enabled = true;
						btnManStop.Enabled = false;
						break;
					case(1):
						btnManOn.Enabled = false;
						btnManOff.Enabled = true;
						break;
					case(2):
						btnManOn.Enabled = true;
						btnManOff.Enabled = false;
						break;
				}
				btnManStop.Enabled =  ((TransFbValue == 6)|| (TransFbValue == 7));
			}
			else
				btnManOn.Enabled = btnManOff.Enabled = btnManStop.Enabled = false;
		}
		#endregion




		#region Faceplate Navigation
		//Open parameter faceplate
		void FpNavigationPaneOnParameterClick()
		{

			DoOpenFaceplate("fpParameter");
		}

		//Open trend faceplate
		void FpNavigationPaneOnTrendClick()
		{
			DoOpenFaceplate("fpTrend");
		}

		ushort requestOwner;
		void OwnerSwitchOnBasicOwnerChanged(bool BasicSwitchState)
		{
			if (BasicSwitchState)
				requestOwner = (ushort)((requestOwner & (0xE7)) | 0x10);
			else
				requestOwner = (ushort)((requestOwner & ~(1 << 4)) | 0x8);
			FireEvent_OWNER(requestOwner);
		}
		
		bool StandardOwnerAvail;
		void StdOwnerConnectedValueChanged(object sender, ValueChangedEventArgs e)
		{
			StandardOwnerAvail = (bool)e.Value;
			ownerSwitch.ExternalAvailable = StandardOwnerAvail;
			ownerStatus.ExternalAvailable = StandardOwnerAvail;
			
			if (StandardOwnerAvail)
			{
				fpNavigationPane.Owner.SymbolType = "SE.App2Base.Symbols.Owner.sOwnerConfig";
				fpNavigationPane.Owner.InstanceName = FindInstanceLayer(InstanceLayer.BaseExt)+".serviceManager.owner";
			}
		}
		
		//Owner is changed
		ushort icurrentowner;
		private bool Owner;
		void CurrentOwnerBasicValueChanged(object sender, ValueChangedEventArgs e)
		{
			
			ownerSwitch.CurrentBasicOwner = ((ushort)e.Value & 0x10) == 0x10;
			ownerStatus.CurrentBasicOwner = ((ushort)e.Value & 0x10) == 0x10;
			
			icurrentowner = (ushort)e.Value;
			Owner = (icurrentowner == 0x10) ;  // Commented CurrentOwner --On button enabling in prog mode if interlock comes
			ButtonEnablement( Owner ,CSpValue ,TransFbValue,IsSecuritySetpoint,oosVal);
		}

		
		void FpDefaultUpdateOptionalService(string instancePath)
		{
			if (StandardOwnerAvail)
			{
				fpNavigationPane.Owner.SymbolType = "SE.App2Base.Symbols.Owner.sOwnerConfig";
				fpNavigationPane.Owner.InstanceName = FindInstanceLayer(InstanceLayer.BaseExt)+".serviceManager.owner";
			}
			
			fpNavigationPane.Interlock.SymbolType = "SE.App2CommonProcess.Symbols.IlckCondSum.sInterlock";
			fpNavigationPane.Interlock.InstanceName = FindInstanceLayer(InstanceLayer.Top)+".interlock";
			
			fpNavigationPane.Permissive.SymbolType = "SE.App2CommonProcess.Symbols.PermCondSum.sPermissive";
			fpNavigationPane.Permissive.InstanceName =  FindInstanceLayer(InstanceLayer.Top)+".permissive";
			
			fpNavigationPane.LocalPanel.SymbolType = "SE.App2CommonProcess.Symbols.ValveLp.sDefault";
			fpNavigationPane.LocalPanel.InstanceName = FindInstanceLayer(InstanceLayer.Top)+".localPanel";
			
			fpNavigationPane.Maintenance.SymbolType = "SE.App2CommonProcess.Symbols.DevMnt.sDefault";
			fpNavigationPane.Maintenance.InstanceName = FindInstanceLayer(InstanceLayer.Top)+".maintenance";

			ownerStatus.InstanceName = FindInstanceLayer(InstanceLayer.BaseExt)+".serviceManager.owner";
			ownerSwitch.InstanceName = FindInstanceLayer(InstanceLayer.BaseExt)+".serviceManager.owner";
		}

		//Current output value change detected


		#endregion

	}
}



