using System;

using NxtControl.GuiFramework;

namespace HMI.Main.Symbols.SortingCycle {

 partial class sDefault {

 private void InitializeComponent() {

this.title=new NxtControl.GuiFramework.Label();

this.title.Name="title";

this.title.Bounds=new NxtControl.Drawing.RectF(0,0,1160,42);

this.title.Text="SORTING";

this.title.Font=new NxtControl.Drawing.Font("Arial",22F,System.Drawing.FontStyle.Regular);

this.stationState=new NxtControl.GuiFramework.Label();

this.stationState.Name="stationState";

this.stationState.Bounds=new NxtControl.Drawing.RectF(0,60,560,38);

this.stationState.Text="State: waiting for connection";

this.stationState.Font=new NxtControl.Drawing.Font("Arial",18F,System.Drawing.FontStyle.Regular);

this.modeLabel=new NxtControl.GuiFramework.Label();

this.modeLabel.Name="modeLabel";

this.modeLabel.Bounds=new NxtControl.Drawing.RectF(600,60,560,38);

this.modeLabel.Text="Mode: --";

this.modeLabel.Font=new NxtControl.Drawing.Font("Arial",18F,System.Drawing.FontStyle.Regular);

this.routeLabel=new NxtControl.GuiFramework.Label();

this.routeLabel.Name="routeLabel";

this.routeLabel.Bounds=new NxtControl.Drawing.RectF(0,108,560,36);

this.routeLabel.Text="Route: --";

this.routeLabel.Font=new NxtControl.Drawing.Font("Arial",16F,System.Drawing.FontStyle.Regular);

this.permitLabel=new NxtControl.GuiFramework.Label();

this.permitLabel.Name="permitLabel";

this.permitLabel.Bounds=new NxtControl.Drawing.RectF(600,108,560,36);

this.permitLabel.Text="Run permit: --";

this.permitLabel.Font=new NxtControl.Drawing.Font("Arial",16F,System.Drawing.FontStyle.Regular);

this.alarmLabel=new NxtControl.GuiFramework.Label();

this.alarmLabel.Name="alarmLabel";

this.alarmLabel.Bounds=new NxtControl.Drawing.RectF(0,275,1160,48);

this.alarmLabel.Text="Waiting for station status";

this.alarmLabel.Font=new NxtControl.Drawing.Font("Arial",16F,System.Drawing.FontStyle.Regular);

this.message=new NxtControl.GuiFramework.Label();

this.message.Name="message";

this.message.Bounds=new NxtControl.Drawing.RectF(0,335,1160,42);

this.message.Text="Select mode, confirm clearance, Reset, then Start";

this.message.Font=new NxtControl.Drawing.Font("Arial",13F,System.Drawing.FontStyle.Regular);

this.startButton=new DrawnButton();

this.startButton.Name="startButton";

this.startButton.Bounds=new NxtControl.Drawing.RectF(0,165,170,60);

this.startButton.Text="START";

this.startButton.Brush=new NxtControl.Drawing.Brush("ButtonBrush");

this.startButton.Pen=new NxtControl.Drawing.Pen("ButtonPen");

this.startButton.TextColor=new NxtControl.Drawing.Color("ButtonTextColor");

this.startButton.Font=new NxtControl.Drawing.Font("Arial",14F,System.Drawing.FontStyle.Bold);

this.startButton.Click+=new EventHandler(this.StartClick);

this.stopButton=new DrawnButton();

this.stopButton.Name="stopButton";

this.stopButton.Bounds=new NxtControl.Drawing.RectF(190,165,170,60);

this.stopButton.Text="STOP";

this.stopButton.Brush=new NxtControl.Drawing.Brush("ButtonBrush");

this.stopButton.Pen=new NxtControl.Drawing.Pen("ButtonPen");

this.stopButton.TextColor=new NxtControl.Drawing.Color("ButtonTextColor");

this.stopButton.Font=new NxtControl.Drawing.Font("Arial",14F,System.Drawing.FontStyle.Bold);

this.stopButton.Click+=new EventHandler(this.StopClick);

this.resetButton=new DrawnButton();

this.resetButton.Name="resetButton";

this.resetButton.Bounds=new NxtControl.Drawing.RectF(380,165,170,60);

this.resetButton.Text="RESET";

this.resetButton.Brush=new NxtControl.Drawing.Brush("ButtonBrush");

this.resetButton.Pen=new NxtControl.Drawing.Pen("ButtonPen");

this.resetButton.TextColor=new NxtControl.Drawing.Color("ButtonTextColor");

this.resetButton.Font=new NxtControl.Drawing.Font("Arial",14F,System.Drawing.FontStyle.Bold);

this.resetButton.Click+=new EventHandler(this.ResetClick);

this.autoButton=new DrawnButton();

this.autoButton.Name="autoButton";

this.autoButton.Bounds=new NxtControl.Drawing.RectF(600,165,265,60);

this.autoButton.Text="AUTOMATIC";

this.autoButton.Brush=new NxtControl.Drawing.Brush("ButtonBrush");

this.autoButton.Pen=new NxtControl.Drawing.Pen("ButtonPen");

this.autoButton.TextColor=new NxtControl.Drawing.Color("ButtonTextColor");

this.autoButton.Font=new NxtControl.Drawing.Font("Arial",14F,System.Drawing.FontStyle.Bold);

this.autoButton.Click+=new EventHandler(this.AutoClick);

this.singleButton=new DrawnButton();

this.singleButton.Name="singleButton";

this.singleButton.Bounds=new NxtControl.Drawing.RectF(885,165,265,60);

this.singleButton.Text="SINGLE CYCLE";

this.singleButton.Brush=new NxtControl.Drawing.Brush("ButtonBrush");

this.singleButton.Pen=new NxtControl.Drawing.Pen("ButtonPen");

this.singleButton.TextColor=new NxtControl.Drawing.Color("ButtonTextColor");

this.singleButton.Font=new NxtControl.Drawing.Font("Arial",14F,System.Drawing.FontStyle.Bold);

this.singleButton.Click+=new EventHandler(this.SingleClick);















this.chartFlags=new NxtControl.GuiFramework.Label();this.chartFlags.Name="chartFlags";this.chartFlags.Bounds=new NxtControl.Drawing.RectF(0,380,1160,60);this.chartFlags.Font=new NxtControl.Drawing.Font("Arial",11F,System.Drawing.FontStyle.Regular);
this.Shapes.AddRange(new System.ComponentModel.IComponent[]{this.chartFlags,this.title,this.stationState,this.modeLabel,this.routeLabel,this.permitLabel,this.alarmLabel,this.message,this.startButton,this.stopButton,this.resetButton,this.autoButton,this.singleButton});

this.Name="sDefault";this.SymbolSize=new System.Drawing.Size(1160,445);

}


private NxtControl.GuiFramework.Label chartFlags;
private NxtControl.GuiFramework.Label title;

private NxtControl.GuiFramework.Label stationState;

private NxtControl.GuiFramework.Label modeLabel;

private NxtControl.GuiFramework.Label routeLabel;

private NxtControl.GuiFramework.Label permitLabel;

private NxtControl.GuiFramework.Label alarmLabel;

private NxtControl.GuiFramework.Label message;

private DrawnButton startButton;

private DrawnButton stopButton;

private DrawnButton resetButton;

private DrawnButton autoButton;

private DrawnButton singleButton;


}

}