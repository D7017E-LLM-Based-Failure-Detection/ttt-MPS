using System;
using NxtControl.GuiFramework;
using NxtControl.Services;


#region Definitions;
#region ActuatorBase_HMI;

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sDefault
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Faceplates.ActuatorBase
{
  partial class fpDefault
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Faceplates.ActuatorBase
{
  partial class fpParameter
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sLflValve
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Faceplates.ActuatorBase
{
  partial class fpTrend
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sLflVert
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sLflHorz
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sDamper
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sDiverter
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}

namespace Flexbridge.FestoMPS400.Symbols.ActuatorBase
{
  partial class sInstanceName
  {

    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.ActuatorBase.fpTrend();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    protected override void DoOpenFaceplate(OpenFaceplate openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == (string)openFaceplate.FaceplateType)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

    public override void DoOpenFaceplate(string openFaceplate)
    {
      NxtControl.GuiFramework.HMIFaceplate hmiFaceplate = null;

      if ("fpDefault" == openFaceplate)
        hmiFaceplate = fpDefault;

      if ("fpParameter" == openFaceplate)
        hmiFaceplate = fpParameter;

      if ("fpTrend" == openFaceplate)
        hmiFaceplate = fpTrend;

      if (hmiFaceplate != null)
      {
        if (hmiFaceplate.Initialized == true)
          hmiFaceplate.Activate();
        else
        {
          OnInitializeFaceplate(hmiFaceplate);
          hmiFaceplate.Show(this);
        }
      }
    }

  }
}
#endregion ActuatorBase_HMI;

#endregion Definitions;

