using System;
using NxtControl.GuiFramework;
using NxtControl.Services;


#region Definitions;
#region Actuator2OpBase_HMI;

namespace Flexbridge.FestoMPS400.Symbols.Actuator2OpBase
{
  partial class sDefault
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend();

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

namespace Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase
{
  partial class fpDefault
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend();

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

namespace Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase
{
  partial class fpParameter
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend();

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

namespace Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase
{
  partial class fpTrend
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.ConnectionSymbolPath, this.ChannelId, this.ParentType);

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter();

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

namespace Flexbridge.FestoMPS400.Symbols.Actuator2OpBase
{
  partial class sDamper
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend();

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

namespace Flexbridge.FestoMPS400.Symbols.Actuator2OpBase
{
  partial class sDiverter
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend();

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

namespace Flexbridge.FestoMPS400.Symbols.Actuator2OpBase
{
  partial class sInstanceName
  {

    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault fpDefault
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpDefault();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter fpParameter
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpParameter();

          faceplate.SetConnectionInfo(this.TagName, this.SymbolPath, this.ChannelId, GetType());

          if (hmiManagementService != null)
            hmiManagementService.RegisterHMIFaceplate(faceplate);
        }
        return faceplate;
      }
    }
     
    private Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend fpTrend
    {
      get
      { 
        if (IsOpenFaceplateSecure() == false)
          return null;

        Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend faceplate = null;
        
        IHMIManagementService hmiManagementService = (IHMIManagementService)ServiceProvider.GetService(typeof(IHMIManagementService));
        if (hmiManagementService != null)
          faceplate = (Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend)hmiManagementService.GetRegisteredHMIFaceplate(MapPath, typeof(Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend));
        
        if (faceplate == null)
        {
          faceplate = new Flexbridge.FestoMPS400.Faceplates.Actuator2OpBase.fpTrend();

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
#endregion Actuator2OpBase_HMI;

#endregion Definitions;

