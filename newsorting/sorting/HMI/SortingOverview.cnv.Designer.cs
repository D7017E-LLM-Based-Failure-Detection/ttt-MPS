using System;
using NxtControl.GuiFramework;
namespace HMI.Main.Canvases {
 partial class SortingOverview {
 private void InitializeComponent() {
 	this.operatorPanel = new HMI.Main.Symbols.SortingCycle.sDefault();
 	this.conveyor = new SE.App2CommonProcess.Symbols.Motor.sConveyor();
 	this.branch1 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
 	this.branch2 = new SE.App2CommonProcess.Symbols.Valve.sDefault();
 	this.stopper = new SE.App2CommonProcess.Symbols.DigitalOutput.sDefault();
 	this.part = new SE.App2CommonProcess.Symbols.DigitalInput.sIndicator();
 	this.black = new SE.App2CommonProcess.Symbols.DigitalInput.sIndicator();
 	this.metal = new SE.App2CommonProcess.Symbols.DigitalInput.sIndicator();
 	this.full = new SE.App2CommonProcess.Symbols.DigitalInput.sIndicator();
 	this.equipment = new NxtControl.GuiFramework.Label();
 	this.conveyorText = new NxtControl.GuiFramework.Label();
 	this.branch1Text = new NxtControl.GuiFramework.Label();
 	this.branch2Text = new NxtControl.GuiFramework.Label();
 	this.stopperText = new NxtControl.GuiFramework.Label();
 	this.sensors = new NxtControl.GuiFramework.Label();
 	this.partText = new NxtControl.GuiFramework.Label();
 	this.blackText = new NxtControl.GuiFramework.Label();
 	this.metalText = new NxtControl.GuiFramework.Label();
 	this.fullText = new NxtControl.GuiFramework.Label();
 	// 
 	// operatorPanel
 	// 
 	this.operatorPanel.BeginInit();
 	this.operatorPanel.DesignMatrix = new NxtControl.Drawing.Matrix2D(1.0068965517241379D, 0D, 0D, 1.0530503978779842D, 32D, 0D);
 	this.operatorPanel.Name = "operatorPanel";
 	this.operatorPanel.SecurityToken = ((uint)(4294967295u));
 	this.operatorPanel.TagName = "98A898AABF344ACB.Cycle";
 	this.operatorPanel.EndInit();
 	// 
 	// conveyor
 	// 
 	this.conveyor.BeginInit();
 	this.conveyor.DefaultInstanceName = null;
 	this.conveyor.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 80D, 500D);
 	this.conveyor.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.conveyor.MyTagDisplayName = null;
 	this.conveyor.Name = "conveyor";
 	this.conveyor.SecurityToken = ((uint)(4294967295u));
 	this.conveyor.TagName = "98A898AABF344ACB.Conveyor";
 	this.conveyor.EndInit();
 	// 
 	// branch1
 	// 
 	this.branch1.BeginInit();
 	this.branch1.DefaultInstanceName = null;
 	this.branch1.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 420D, 500D);
 	this.branch1.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.branch1.MyTagDisplayName = null;
 	this.branch1.Name = "branch1";
 	this.branch1.SecurityToken = ((uint)(4294967295u));
 	this.branch1.TagName = "98A898AABF344ACB.Branch1";
 	this.branch1.EndInit();
 	// 
 	// branch2
 	// 
 	this.branch2.BeginInit();
 	this.branch2.DefaultInstanceName = null;
 	this.branch2.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 659D, 496D);
 	this.branch2.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.branch2.MyTagDisplayName = null;
 	this.branch2.Name = "branch2";
 	this.branch2.SecurityToken = ((uint)(4294967295u));
 	this.branch2.TagName = "98A898AABF344ACB.Branch2";
 	this.branch2.Click += new System.EventHandler(this.Branch2Click);
 	this.branch2.EndInit();
 	// 
 	// stopper
 	// 
 	this.stopper.BeginInit();
 	this.stopper.DefaultInstanceName = null;
 	this.stopper.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 900D, 500D);
 	this.stopper.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
 	this.stopper.FalseText = "TxtOFF";
 	this.stopper.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.stopper.MyTagDisplayName = null;
 	this.stopper.Name = "stopper";
 	this.stopper.SecurityToken = ((uint)(4294967295u));
 	this.stopper.TagName = "98A898AABF344ACB.Stopper";
 	this.stopper.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
 	this.stopper.TrueText = "TxtON";
 	this.stopper.EndInit();
 	// 
 	// part
 	// 
 	this.part.BeginInit();
 	this.part.DefaultInstanceName = null;
 	this.part.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 80D, 690D);
 	this.part.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
 	this.part.FalseText = "TxtOFF";
 	this.part.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.part.MyTagDisplayName = null;
 	this.part.Name = "part";
 	this.part.SecurityToken = ((uint)(4294967295u));
 	this.part.TagName = "98A898AABF344ACB.PartAvailable";
 	this.part.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
 	this.part.TrueText = "TxtON";
 	this.part.EndInit();
 	// 
 	// black
 	// 
 	this.black.BeginInit();
 	this.black.DefaultInstanceName = null;
 	this.black.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 380D, 690D);
 	this.black.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
 	this.black.FalseText = "TxtOFF";
 	this.black.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.black.MyTagDisplayName = null;
 	this.black.Name = "black";
 	this.black.SecurityToken = ((uint)(4294967295u));
 	this.black.TagName = "98A898AABF344ACB.NotBlack";
 	this.black.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
 	this.black.TrueText = "TxtON";
 	this.black.EndInit();
 	// 
 	// metal
 	// 
 	this.metal.BeginInit();
 	this.metal.DefaultInstanceName = null;
 	this.metal.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 680D, 690D);
 	this.metal.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
 	this.metal.FalseText = "TxtOFF";
 	this.metal.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.metal.MyTagDisplayName = null;
 	this.metal.Name = "metal";
 	this.metal.SecurityToken = ((uint)(4294967295u));
 	this.metal.TagName = "98A898AABF344ACB.Metal";
 	this.metal.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
 	this.metal.TrueText = "TxtON";
 	this.metal.EndInit();
 	// 
 	// full
 	// 
 	this.full.BeginInit();
 	this.full.DefaultInstanceName = null;
 	this.full.DesignMatrix = new NxtControl.Drawing.Matrix2D(1D, 0D, 0D, 1D, 980D, 690D);
 	this.full.FalseColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyPassive");
 	this.full.FalseText = "TxtOFF";
 	this.full.Instancelayer = SE.App2Base.SupportClasses.InstanceLayer.Base;
 	this.full.MyTagDisplayName = null;
 	this.full.Name = "full";
 	this.full.SecurityToken = ((uint)(4294967295u));
 	this.full.TagName = "98A898AABF344ACB.SlideFull";
 	this.full.TrueColor = new NxtControl.Drawing.Color("SE.App2Base.aaLibSymBodyActive");
 	this.full.TrueText = "TxtON";
 	this.full.EndInit();
 	// 
 	// equipment
 	// 
 	this.equipment.AngleIgnore = true;
 	this.equipment.Bounds = new NxtControl.Drawing.RectF(((float)(40D)), ((float)(420D)), ((float)(1160D)), ((float)(35D)));
 	this.equipment.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.equipment.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.equipment.Name = "equipment";
 	this.equipment.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.equipment.Text = "EQUIPMENT - select a symbol for its standard faceplate";
 	// 
 	// conveyorText
 	// 
 	this.conveyorText.AngleIgnore = true;
 	this.conveyorText.Bounds = new NxtControl.Drawing.RectF(((float)(60D)), ((float)(465D)), ((float)(250D)), ((float)(30D)));
 	this.conveyorText.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.conveyorText.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.conveyorText.Name = "conveyorText";
 	this.conveyorText.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.conveyorText.Text = "Conveyor";
 	// 
 	// branch1Text
 	// 
 	this.branch1Text.AngleIgnore = true;
 	this.branch1Text.Bounds = new NxtControl.Drawing.RectF(((float)(400D)), ((float)(465D)), ((float)(200D)), ((float)(30D)));
 	this.branch1Text.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.branch1Text.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.branch1Text.Name = "branch1Text";
 	this.branch1Text.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.branch1Text.Text = "Branch 1";
 	// 
 	// branch2Text
 	// 
 	this.branch2Text.AngleIgnore = true;
 	this.branch2Text.Bounds = new NxtControl.Drawing.RectF(((float)(630D)), ((float)(465D)), ((float)(200D)), ((float)(30D)));
 	this.branch2Text.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.branch2Text.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.branch2Text.Name = "branch2Text";
 	this.branch2Text.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.branch2Text.Text = "Branch 2";
 	// 
 	// stopperText
 	// 
 	this.stopperText.AngleIgnore = true;
 	this.stopperText.Bounds = new NxtControl.Drawing.RectF(((float)(890D)), ((float)(465D)), ((float)(220D)), ((float)(30D)));
 	this.stopperText.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.stopperText.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.stopperText.Name = "stopperText";
 	this.stopperText.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.stopperText.Text = "Stopper";
 	// 
 	// sensors
 	// 
 	this.sensors.AngleIgnore = true;
 	this.sensors.Bounds = new NxtControl.Drawing.RectF(((float)(40D)), ((float)(610D)), ((float)(1160D)), ((float)(35D)));
 	this.sensors.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.sensors.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.sensors.Name = "sensors";
 	this.sensors.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.sensors.Text = "SENSORS";
 	// 
 	// partText
 	// 
 	this.partText.AngleIgnore = true;
 	this.partText.Bounds = new NxtControl.Drawing.RectF(((float)(60D)), ((float)(650D)), ((float)(250D)), ((float)(30D)));
 	this.partText.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.partText.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.partText.Name = "partText";
 	this.partText.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.partText.Text = "Part available";
 	// 
 	// blackText
 	// 
 	this.blackText.AngleIgnore = true;
 	this.blackText.Bounds = new NxtControl.Drawing.RectF(((float)(360D)), ((float)(650D)), ((float)(250D)), ((float)(30D)));
 	this.blackText.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.blackText.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.blackText.Name = "blackText";
 	this.blackText.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.blackText.Text = "Not black";
 	// 
 	// metalText
 	// 
 	this.metalText.AngleIgnore = true;
 	this.metalText.Bounds = new NxtControl.Drawing.RectF(((float)(660D)), ((float)(650D)), ((float)(250D)), ((float)(30D)));
 	this.metalText.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.metalText.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.metalText.Name = "metalText";
 	this.metalText.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.metalText.Text = "Metal";
 	// 
 	// fullText
 	// 
 	this.fullText.AngleIgnore = true;
 	this.fullText.Bounds = new NxtControl.Drawing.RectF(((float)(960D)), ((float)(650D)), ((float)(260D)), ((float)(30D)));
 	this.fullText.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color(((byte)(240)), ((byte)(240)), ((byte)(240))));
 	this.fullText.Font = new NxtControl.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
 	this.fullText.Name = "fullText";
 	this.fullText.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color(((byte)(0)), ((byte)(0)), ((byte)(0))), 1F, NxtControl.Drawing.DashStyle.Solid);
 	this.fullText.Text = "Slide full (raw input)";
 	// 
 	// SortingOverview
 	// 
 	this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1280D)), ((float)(868D)));
 	this.Brush = new NxtControl.Drawing.Brush("CanvasBrush");
 	this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.operatorPanel,
			this.conveyor,
			this.branch1,
			this.branch2,
			this.stopper,
			this.part,
			this.black,
			this.metal,
			this.full,
			this.equipment,
			this.conveyorText,
			this.branch1Text,
			this.branch2Text,
			this.stopperText,
			this.sensors,
			this.partText,
			this.blackText,
			this.metalText,
			this.fullText});
 	this.Size = new System.Drawing.Size(1280, 868);

 }
private HMI.Main.Symbols.SortingCycle.sDefault operatorPanel;
private SE.App2CommonProcess.Symbols.Motor.sConveyor conveyor;
private SE.App2CommonProcess.Symbols.Valve.sDefault branch1;
private SE.App2CommonProcess.Symbols.Valve.sDefault branch2;
private SE.App2CommonProcess.Symbols.DigitalOutput.sDefault stopper;
private SE.App2CommonProcess.Symbols.DigitalInput.sIndicator part;
private SE.App2CommonProcess.Symbols.DigitalInput.sIndicator black;
private SE.App2CommonProcess.Symbols.DigitalInput.sIndicator metal;
private SE.App2CommonProcess.Symbols.DigitalInput.sIndicator full;
private NxtControl.GuiFramework.Label equipment;
private NxtControl.GuiFramework.Label conveyorText;
private NxtControl.GuiFramework.Label branch1Text;
private NxtControl.GuiFramework.Label branch2Text;
private NxtControl.GuiFramework.Label stopperText;
private NxtControl.GuiFramework.Label sensors;
private NxtControl.GuiFramework.Label partText;
private NxtControl.GuiFramework.Label blackText;
private NxtControl.GuiFramework.Label metalText;
private NxtControl.GuiFramework.Label fullText;
}
}
