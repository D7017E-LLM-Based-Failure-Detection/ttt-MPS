/*
 * Created by EcoStruxure Automation Expert.
 * User:  
 * Date: 7/10/2026
 * Time: 2:48 PM
 * 
 */
using System;
using NxtControl.GuiFramework;
using NxtControl.Services;

#region Definitions;
#region #TransportGeneral1_HMI;

namespace HMI.Main.Symbols.TransportGeneral1
{

  public class REQEventArgs : System.EventArgs
  {
    IHMIAccessorService accessorService;
    int channelId;
    int cookie; 
    int eventIndex;

    public REQEventArgs(int channelId, int cookie, int eventIndex)
    {
      this.accessorService = (IHMIAccessorService)ServiceProvider.GetService(typeof(IHMIAccessorService));
      this.channelId = channelId;
      this.cookie = cookie;
      this.eventIndex = eventIndex;
    }

  }

}

namespace HMI.Main.Symbols.TransportGeneral1
{

  public class CNFEventArgs : System.EventArgs
  {
    public CNFEventArgs()
    {
    }
    private System.Boolean? Enabled_field = null;
    public System.Boolean? Enabled
    {
       get { return Enabled_field; }
       set { Enabled_field = value; }
    }

  }

}

namespace HMI.Main.Symbols.TransportGeneral1
{
  partial class sDefault
  {

    private event EventHandler<HMI.Main.Symbols.TransportGeneral1.REQEventArgs> REQ_Fired;

    protected override void OnEndInit()
    {
      if (REQ_Fired != null)
        AttachEventInput(0);

    }

    protected override void FireEventCallback(int channelId, int cookie, int eventIndex)
    {
      switch(eventIndex)
      {
        default:
          break;
        case 0:
          if (REQ_Fired != null)
          {
            try
            {
              REQ_Fired(this, new HMI.Main.Symbols.TransportGeneral1.REQEventArgs(channelId, cookie, eventIndex));
            }
            catch (System.Exception e)
            {
              NxtControl.Services.LoggingService.ErrorFormatted(@"In Event Callback for event:'{0}' Type:'{1}' CAT:'{2}' came exception:{3}
stack Trace:
{4}","REQ_Fired", this.GetType().Name, this.CATName, e.Message, e.StackTrace);
            }
          }
        break; 

      }
    }
    public bool FireEvent_CNF(System.Boolean Enabled)
    {
      return ((IHMIAccessorOutput)this).FireEvent(0, new object[] {Enabled});
    }
    public bool FireEvent_CNF(HMI.Main.Symbols.TransportGeneral1.CNFEventArgs ea)
    {
      object[] _values_ = new object[1];
      if (ea.Enabled.HasValue) _values_[0] = ea.Enabled.Value;
      return ((IHMIAccessorOutput)this).FireEvent(0, _values_);
    }
    public bool FireEvent_CNF(System.Boolean Enabled, bool ignore_Enabled)
    {
      object[] _values_ = new object[1];
      if (!ignore_Enabled) _values_[0] = Enabled;
      return ((IHMIAccessorOutput)this).FireEvent(0, _values_);
    }

  }
}
#endregion #TransportGeneral1_HMI;

#endregion Definitions;
