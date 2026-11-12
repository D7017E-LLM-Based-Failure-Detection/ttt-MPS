using System;

using NxtControl.GuiFramework;

using NxtControl.Services;

#region Definitions;

#region #SortingCycle_HMI;

namespace HMI.Main.Symbols.SortingCycle {

 public class STATUS_UPDEventArgs : EventArgs {

  private readonly IHMIAccessorService service;

  private readonly int channel, cookie, index;

  public STATUS_UPDEventArgs(int c,int k,int i) { service=(IHMIAccessorService)ServiceProvider.GetService(typeof(IHMIAccessorService)); channel=c;cookie=k;index=i; }

  public long? State { get { long v=0; if(service==null || !service.GetInt64Value(channel,cookie,index,true,0,ref v)) return null; return v; } }

  public long? Route { get { long v=0; if(service==null || !service.GetInt64Value(channel,cookie,index,true,1,ref v)) return null; return v; } }

  public bool? Fault { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,2,ref v)) return null; return v; } }

  public bool? SlideBlocked { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,3,ref v)) return null; return v; } }

  public bool? RunPermit { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,4,ref v)) return null; return v; } }

  public bool? Automatic { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,5,ref v)) return null; return v; } }





   public bool? ResetLamp { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,6,ref v)) return null; return v; } }
  public bool? StartLamp { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,7,ref v)) return null; return v; } }
  public bool? SlideFullLamp { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,8,ref v)) return null; return v; } }
  public bool? StationOccupied { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,9,ref v)) return null; return v; } }
  public bool? ResetFinished { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,10,ref v)) return null; return v; } }
  public bool? CycleEnd { get { bool v=false; if(service==null || !service.GetBoolValue(channel,cookie,index,true,11,ref v)) return null; return v; } }
}

 partial class sDefault {

  private event EventHandler<STATUS_UPDEventArgs> STATUS_UPD_Fired;

  protected override void OnEndInit() { if(STATUS_UPD_Fired!=null) AttachEventInput(0); }

  protected override void FireEventCallback(int channel,int cookie,int index) { if(index==0 && STATUS_UPD_Fired!=null) STATUS_UPD_Fired(this,new STATUS_UPDEventArgs(channel,cookie,index)); }

  public bool FireEvent_COMMAND(int command) { return ((IHMIAccessorOutput)this).FireEvent(0,new object[]{command}); }

  public bool FireEvent_MODE(bool automatic) { return ((IHMIAccessorOutput)this).FireEvent(1,new object[]{automatic}); }

 }

}



#endregion #SortingCycle_HMI;

#endregion Definitions;

