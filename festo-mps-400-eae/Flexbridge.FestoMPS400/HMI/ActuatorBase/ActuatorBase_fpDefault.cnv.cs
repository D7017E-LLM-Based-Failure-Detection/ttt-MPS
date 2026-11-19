using System;
using System.Drawing;
using NxtControl.GuiFramework;
using System.ComponentModel;
using System.Resources;
using System.Runtime.InteropServices;
using SE.App2Base.SupportClasses;
using SE.App2CommonProcess.SupportClasses;

namespace Flexbridge.FestoMPS400.Faceplates.ActuatorBase
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
			ButtonEnablement( Owner ,CSpValve , IsSecuritySetpoint,oosVal);
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
			ButtonEnablement( Owner ,CSpValve, SecurityValSetpoint, oosVal);
		}
		
		
		//*********************************************************End of Security Group************************************************************************************************************
		
		
		//Move the required data from symbol to faceplate on initialize
		protected override void OnInitializeFaceplate(HMIFaceplate hmiFaceplate)
		{
			Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fp = hmiFaceplate as Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter;
			if (fp != null)
			{
				fp.Title = Title+" "+"Parameter";
				fp.SecMode = SecMode;
				fp.SecParameter = SecParameter;
				fp.SecOwner = SecOwner;
			}
			base.OnInitializeFaceplate(hmiFaceplate);
			
			Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fp1 = hmiFaceplate as Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend;
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
		private short PvValve;
		void PvValueChanged(object sender, ValueChangedEventArgs e)
		{

			PvValve = (short)e.Value;
			ButtonEnablement( Owner ,CSpValve, SecurityValSetpoint, oosVal);
			StatusUpdate();
		}
		
		void StatusUpdate()
		{
			if ((PvValve != 1 && PvValve != 2) && (TransPvValve == 6 || TransPvValve == 7))
			{
				if (TransPvValve == 7)
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtTransClose";
				else if (TransPvValve == 6)
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtTransOpen";
			}
			else
				switch (PvValve) {
				case 0:
					lblIsPv.Text = "$key:SE.App2CommonProcess.TxtClosed";
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
		private short CSpValve;
		void CurrentSpValueChanged(object sender, ValueChangedEventArgs e)
		{
			CSpValve = (short)e.Value;
			ButtonEnablement( Owner ,CSpValve, SecurityValSetpoint, oosVal);
			if (CSpValve == 1)
			{
				lblAutoSp.Text = "$key:SE.App2CommonProcess.TxtOpen";
			}
			else
				if (CSpValve == 2)
			{
				lblAutoSp.Text = "$key:SE.App2CommonProcess.TxtClose";
			}
		}
		//Trans process value change detected
		private short TransPvValve;
		void TransFbStatusChanged(object sender, ValueChangedEventArgs e)
		{
			TransPvValve = (short)e.Value;
			StatusUpdate();
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
		
		//Code to enable and disable buttons on faceplate
		public void ButtonEnablement( bool Owner , short CSpval , bool SecurityVal ,bool Oos)
		{
			if (Owner && SecurityVal && !Oos)
			{
				if (CSpval == 1)
				{
					btnManOff.Enabled = true;
					btnManOn.Enabled = false;
				}
				else
					if (CSpval == 2)
				{
					btnManOn.Enabled = true;
					btnManOff.Enabled = false;
				}
				
				
			}
			
			else
				btnManOn.Enabled = btnManOff.Enabled = false;
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
			Owner = (icurrentowner == 0x10);  // Commented CurrentOwner --On button enabling in prog mode if interlock comes
			ButtonEnablement( Owner ,CSpValve , IsSecuritySetpoint,oosVal);
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
		private short OpValve;
		void CurrentOpValueChanged(object sender, ValueChangedEventArgs e)
		{

			OpValve = (short)e.Value;
			if (OpValve == 1)
				lblReqPv.Text = "$key:SE.App2CommonProcess.TxtOpen";
			else
				if (OpValve == 2)
					lblReqPv.Text = "$key:SE.App2CommonProcess.TxtClose";
		}


		#endregion

	}
}



