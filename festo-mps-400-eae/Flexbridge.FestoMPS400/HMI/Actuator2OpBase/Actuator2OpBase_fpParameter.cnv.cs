using System;
using System.Drawing;
using NxtControl.GuiFramework;
using System.ComponentModel;

namespace Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase
{
	/// <summary>
	/// Description of fpParameter.
	/// </summary>
	public partial class fpParameter : SE.App2Base.Faceplates.SEAppLibHMIFaceplate
	{
		public fpParameter()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
//			Sim.SecurityLevel = 0;
//			Over.SecurityLevel = 0;
//			Maint.SecurityLevel = 0;
			DDBoxPopulate(); // For Drop Down Box Text Populating
		}
		
		//*****************************************Security Group***********************************************************
		
		void FpParameterSecurityOwnerChanged(bool isSecurity)
		{
			ModeEnablement();
		}
		private bool SecurityVal ;
		void FpParameterSecurityParameterChanged(bool isSecurity)
		{
			combofbmode.SecurityLevel =  SecParameter;
			SecurityVal = ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecParameter);
			txtMonitorTime.SecurityLevel =  SecParameter;
			txtTripTime.SecurityLevel =  SecParameter;

			ConfResetReq.SecurityLevel =  SecParameter;
			DDBoxPopulate();
		}

		void FpParameterSecurityModeChanged(bool isSecurity)
		{
			ModeEnablement();
		}
		
		//*******************************************************************End of Instance Level Security*********************************************//
		// For Drop Down Box Text Populating
		public void DDBoxPopulate()
		{
			combofbmode.Enabled = true;
			combofbmode.DropDownItems.Clear();
			this.combofbmode.DropDownItems.AddRange(new System.HMI.Symbols.Base.DropDownItem[]
			                                        {
			                                        	new System.HMI.Symbols.Base.DropDownItem("$key:SE.App2CommonProcess.TxtOpenCloseFb", ((byte)(0))),
			                                        	new System.HMI.Symbols.Base.DropDownItem("$key:SE.App2CommonProcess.TxtOnlyOpenFb", ((byte)(1))),
			                                        	new System.HMI.Symbols.Base.DropDownItem("$key:SE.App2CommonProcess.TxtNoFb", ((byte)(3))) });
			
		}
		// End of DropDown Box Populating
		
		
		
		//Simulation mode
		bool overrideEnable, simulationEnable, maintEnable, oosEnable;
		void SimValueChanged(object sender, ValueChangedEventArgs e)
		{
			simulationEnable = (bool) e.Value;
			labelS5.Abnormal = simulationEnable;
			ModeEnablement();
		}

		//Override mode
		void OverValueChanged(object sender, ValueChangedEventArgs e)
		{
			overrideEnable = (bool) e.Value;
			labelS6.Abnormal = overrideEnable;
			ModeEnablement();
		}
		
		//Maintenance mode
		void MaintValueChanged(object sender, ValueChangedEventArgs e)
		{
			maintEnable = (bool) e.Value;
			labelS7.Abnormal = maintEnable;
		}

		//Oos mode
		void OosOutputValueChanged(object sender, ValueChangedEventArgs e)
		{
			oosEnable = (bool)e.Value;
			labelS4.Abnormal =  oosEnable;
		}
		
		//Process value change detected
		short fbckVal;
		void FbStatusValueChanged(object sender, ValueChangedEventArgs e)
		{
			fbckVal = (short) e.Value;
			ModeEnablement();
		}
		

		//Code to decisde the enabling disabling of mode buttons
		void ModeEnablement()
		{
			Over.Enabled =  !simulationEnable && ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecMode);
			Sim.Enabled =  !overrideEnable&& ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecMode) && ModeEn;
			Maint.Enabled = ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecMode) && ModeEn;
			Oos.Enabled = ((NxtControl.Security.ISecuritySetValues) this).IsSetValuesSecure(SecMode) && ModeEn;
			
		}

		short fbckTransVal;
		bool ModeEn;
		void TransFbStatusValueChanged(object sender, ValueChangedEventArgs e)
		{
			fbckTransVal = (short) e.Value;
			if(fbckTransVal == 5 ||fbckTransVal ==6||fbckTransVal ==7)
			{
				ModeEn = false;
			}
			else
			{
				ModeEn = true;
			}
			ModeEnablement();
		}
		
	}
}



