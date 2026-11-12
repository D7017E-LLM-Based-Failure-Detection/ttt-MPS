using System;

using NxtControl.GuiFramework;

namespace HMI.Main.Symbols.SortingCycle {

 public partial class sDefault : HMISymbol {


  private bool hasStatus;

  private static readonly string[] StateNames={"Undefined","Clearing","Stopped","Starting","Idle","Suspended","Execute","Stopping","Aborting","Aborted","Holding","Held","Unholding","Suspending","Unsuspending","Resetting","Completing","Completed"};

  public sDefault() { InitializeComponent(); STATUS_UPD_Fired+=StatusUpdated; }

  private void Send(int command) {

   if(!hasStatus) { message.Text="Waiting for station connection"; return; }


   bool sent=FireEvent_COMMAND(command);

   message.Text=sent ? "Command sent; station permissives apply" : "Command could not be sent";


  }

  private void StartClick(object s,EventArgs e) { Send(2); }

  private void StopClick(object s,EventArgs e) { Send(3); }

  private void ResetClick(object s,EventArgs e) { Send(1); }


  private void AutoClick(object s,EventArgs e) { SetMode(true); }

  private void SingleClick(object s,EventArgs e) { SetMode(false); }

  private void SetMode(bool mode) { message.Text=hasStatus && FireEvent_MODE(mode) ? "Mode requested" : "Mode unavailable; connect to station"; }

  private void StatusUpdated(object sender,STATUS_UPDEventArgs e) {

   long? state=e.State; long? route=e.Route; bool? fault=e.Fault,blocked=e.SlideBlocked,permit=e.RunPermit,automatic=e.Automatic;

   if(!state.HasValue || !route.HasValue || !fault.HasValue || !blocked.HasValue || !permit.HasValue || !automatic.HasValue) { hasStatus=false; stationState.Text="Status unavailable"; return; }


   hasStatus=true;
   chartFlags.Text="Reset light: "+(e.ResetLamp==true?"ON":"OFF")+"   Start light: "+(e.StartLamp==true?"ON":"OFF")+"   Slide full light: "+(e.SlideFullLamp==true?"ON":"OFF")+"   Occupied: "+(e.StationOccupied==true?"YES":"NO")+"   Reset finished: "+(e.ResetFinished==true?"YES":"NO")+"   Cycle end: "+(e.CycleEnd==true?"YES":"NO");


   stationState.Text="State: "+(state.Value>=0 && state.Value<StateNames.Length?StateNames[state.Value]:state.Value.ToString());

   routeLabel.Text="Route: "+(route.Value==0?"Awaiting part":route.Value==1?"1 - Red / non-metal":route.Value==2?"2 - Metal":"3 - Black");

   permitLabel.Text="Run permit: "+(permit.Value?"AVAILABLE":"BLOCKED");

   modeLabel.Text="Mode: "+(automatic.Value?"AUTOMATIC":"SINGLE CYCLE");

   alarmLabel.Text=fault.Value ? "STATION FAULT - inspect device alarms" : (blocked.Value || e.SlideFullLamp==true) ? "SLIDE FULL - clear slide and press Start to acknowledge" : "No station fault / slide blockage";

   alarmLabel.TextColor=new NxtControl.Drawing.Color(fault.Value||blocked.Value?"Red":"Black");

  }

 }

}