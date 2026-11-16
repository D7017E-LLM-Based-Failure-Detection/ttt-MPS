/* StartCanvas.cnv.Designer.cs */
/* =====================================================================$
 * Copyright © {2022} Schneider Electric.   All rights reserved.
 * The contents of this file is subject to confidentiality.
 *
 * =====================================================================$
 */

/*
 * Created by HMI.Main.
 * User: kovaivo
 * Date: 18.09.2008
 * Time: 17:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

using NxtControl.GuiFramework;

namespace HMI.Main.Canvases
{
  /// <summary>
  /// Summary description for StartCanvas.
  /// </summary>
  partial class StartCanvas
  {
    #region Component Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
    	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartCanvas));
    	this.canvasTopologySeparator1 = new NxtControl.GuiFramework.CanvasTopologySeparator();
    	this.canvasTopologySeparator2 = new NxtControl.GuiFramework.CanvasTopologySeparator();
    	this.workArea = new NxtControl.GuiFramework.WorkAreaControl();
    	this.header1 = new NxtControl.GuiFramework.Rectangle();
    	this.siblingsPanel = new NxtControl.GuiFramework.CanvasTopologyPanel();
    	this.childrenPanel = new NxtControl.GuiFramework.CanvasTopologyPanel();
    	this.logo = new NxtControl.GuiFramework.Rectangle();
    	this.login1 = new NxtControl.GuiFramework.Login();
    	this.language1 = new NxtControl.GuiFramework.LanguageSwitcher();
    	this.currentUser1 = new NxtControl.GuiFramework.CurrentUser();
    	this.runtimeConnection1 = new NxtControl.GuiFramework.RuntimeConnection();
    	this.newVersionDeployment1 = new NxtControl.GuiFramework.HMIDeployment();
    	this.canvasTopologyNavigation = new NxtControl.GuiFramework.CanvasTopologyRose();
    	this.logState1 = new NxtControl.GuiFramework.LogState();
    	this.aliasNameToggleButton1 = new NxtControl.GuiFramework.AliasNameToggleButton();
    	// 
    	// canvasTopologySeparator1
    	// 
    	this.canvasTopologySeparator1.Anchor = NxtControl.Drawing.AnchorStyles.Left;
    	this.canvasTopologySeparator1.Bounds = new NxtControl.Drawing.RectF(((float)(119D)), ((float)(0D)), ((float)(2D)), ((float)(80D)));
    	this.canvasTopologySeparator1.Brush = new NxtControl.Drawing.Brush("CanvasTopologySeparatorBrush");
    	this.canvasTopologySeparator1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.canvasTopologySeparator1.LookAndFeel = "Theme";
    	this.canvasTopologySeparator1.Name = "canvasTopologySeparator1";
    	this.canvasTopologySeparator1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 1F, NxtControl.Drawing.DashStyle.Solid);
    	// 
    	// canvasTopologySeparator2
    	// 
    	this.canvasTopologySeparator2.Anchor = NxtControl.Drawing.AnchorStyles.Left;
    	this.canvasTopologySeparator2.Bounds = new NxtControl.Drawing.RectF(((float)(1080D)), ((float)(0D)), ((float)(2D)), ((float)(80D)));
    	this.canvasTopologySeparator2.Brush = new NxtControl.Drawing.Brush("CanvasTopologySeparatorBrush");
    	this.canvasTopologySeparator2.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.canvasTopologySeparator2.LookAndFeel = "Theme";
    	this.canvasTopologySeparator2.Name = "canvasTopologySeparator2";
    	this.canvasTopologySeparator2.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 1F, NxtControl.Drawing.DashStyle.Solid);
    	// 
    	// workArea
    	// 
    	this.workArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
    	this.workArea.AutoScroll = true;
    	this.workArea.AutoScrollPosition = new System.Drawing.Point(0, 0);
    	this.workArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    	this.workArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
    	this.workArea.Dock = System.Windows.Forms.DockStyle.None;
    	this.workArea.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.workArea.ForeColor = System.Drawing.SystemColors.ControlText;
    	this.workArea.Location = new System.Drawing.Point(0, 112);
    	this.workArea.Name = "workArea";
    	this.workArea.Size = new System.Drawing.Size(1280, 868);
    	this.workArea.Text = null;
    	// 
    	// header1
    	// 
    	this.header1.Anchor = ((NxtControl.Drawing.AnchorStyles)((NxtControl.Drawing.AnchorStyles.Left | NxtControl.Drawing.AnchorStyles.Right)));
    	this.header1.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1280D)), ((float)(80D)));
    	this.header1.Brush = new NxtControl.Drawing.Brush("CanvasTopologyHeaderBrush");
    	this.header1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.header1.Name = "header1";
    	this.header1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 0F, NxtControl.Drawing.DashStyle.Solid);
    	// 
    	// siblingsPanel
    	// 
    	this.siblingsPanel.BeginInit();
    	this.siblingsPanel.Anchor = ((NxtControl.Drawing.AnchorStyles)((NxtControl.Drawing.AnchorStyles.Left | NxtControl.Drawing.AnchorStyles.Right)));
    	this.siblingsPanel.Bounds = new NxtControl.Drawing.RectF(((float)(199D)), ((float)(0D)), ((float)(881D)), ((float)(40D)));
    	this.siblingsPanel.BtnColor = new NxtControl.Drawing.Color(((byte)(255)), ((byte)(255)), ((byte)(0)));
    	this.siblingsPanel.BtnHeight = 30;
    	this.siblingsPanel.BtnWidth = 140;
    	this.siblingsPanel.CurrentBtnColor = new NxtControl.Drawing.Color(((byte)(255)), ((byte)(255)), ((byte)(0)));
    	this.siblingsPanel.LookAndFeel = "Theme";
    	this.siblingsPanel.Name = "siblingsPanel";
    	this.siblingsPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
    	this.siblingsPanel.TopologyType = NxtControl.GuiFramework.CanvasTopologyType.Sibling;
    	this.siblingsPanel.WorkArea = this.workArea;
    	this.siblingsPanel.EndInit();
    	// 
    	// childrenPanel
    	// 
    	this.childrenPanel.BeginInit();
    	this.childrenPanel.Anchor = ((NxtControl.Drawing.AnchorStyles)((NxtControl.Drawing.AnchorStyles.Left | NxtControl.Drawing.AnchorStyles.Right)));
    	this.childrenPanel.Bounds = new NxtControl.Drawing.RectF(((float)(199D)), ((float)(39D)), ((float)(881D)), ((float)(40D)));
    	this.childrenPanel.BtnColor = new NxtControl.Drawing.Color(((byte)(255)), ((byte)(255)), ((byte)(0)));
    	this.childrenPanel.BtnHeight = 30;
    	this.childrenPanel.BtnWidth = 140;
    	this.childrenPanel.CurrentBtnColor = new NxtControl.Drawing.Color(((byte)(255)), ((byte)(255)), ((byte)(0)));
    	this.childrenPanel.LookAndFeel = "Theme";
    	this.childrenPanel.Name = "childrenPanel";
    	this.childrenPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
    	this.childrenPanel.TopologyType = NxtControl.GuiFramework.CanvasTopologyType.Child;
    	this.childrenPanel.WorkArea = this.workArea;
    	this.childrenPanel.EndInit();
    	// 
    	// logo
    	// 
    	this.logo.Anchor = NxtControl.Drawing.AnchorStyles.Left;
    	this.logo.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(119D)), ((float)(80D)));
    	this.logo.Brush = new NxtControl.Drawing.Brush(new NxtControl.Drawing.Color("Transparent"));
    	this.logo.Font = new NxtControl.Drawing.Font("HeaderFont");
    	this.logo.ImageBytes = resources.GetString("logo.ImageBytes");
    	this.logo.Name = "logo";
    	this.logo.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 1F, NxtControl.Drawing.DashStyle.Solid);
    	// 
    	// login1
    	// 
    	this.login1.Anchor = NxtControl.Drawing.AnchorStyles.Right;
    	this.login1.AngleIgnore = true;
    	this.login1.Bounds = new NxtControl.Drawing.RectF(((float)(1200D)), ((float)(0D)), ((float)(40D)), ((float)(40D)));
    	this.login1.Brush = new NxtControl.Drawing.Brush("CanvasTopologyButtonBrush");
    	this.login1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.login1.LookAndFeel = "Theme";
    	this.login1.Name = "login1";
    	this.login1.Pen = new NxtControl.Drawing.Pen("CanvasTopologyButtonPen");
    	this.login1.Radius = 2D;
    	this.login1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
    	this.login1.TextColor = new NxtControl.Drawing.Color("CanvasTopologyButtonColor");
    	this.login1.Use3DEffect = false;
    	// 
    	// language1
    	// 
    	this.language1.Anchor = NxtControl.Drawing.AnchorStyles.Right;
    	this.language1.Bounds = new NxtControl.Drawing.RectF(((float)(1240D)), ((float)(0D)), ((float)(40D)), ((float)(40D)));
    	this.language1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.language1.LookAndFeel = "Theme";
    	this.language1.Name = "language1";
    	this.language1.Pen = new NxtControl.Drawing.Pen("CanvasTopologyButtonPen");
    	this.language1.Radius = 2D;
    	this.language1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
    	this.language1.Use3DEffect = false;
    	// 
    	// currentUser1
    	// 
    	this.currentUser1.Anchor = NxtControl.Drawing.AnchorStyles.Right;
    	this.currentUser1.AngleIgnore = true;
    	this.currentUser1.BorderStyle = System.Windows.Forms.BorderStyle.None;
    	this.currentUser1.Bounds = new NxtControl.Drawing.RectF(((float)(1180D)), ((float)(40D)), ((float)(100D)), ((float)(40D)));
    	this.currentUser1.Brush = new NxtControl.Drawing.Brush(true);
    	this.currentUser1.Font = new NxtControl.Drawing.Font("HeaderFont");
    	this.currentUser1.LookAndFeel = "Theme";
    	this.currentUser1.Name = "currentUser1";
    	this.currentUser1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 1F, NxtControl.Drawing.DashStyle.Solid);
    	this.currentUser1.Text = "currentUser1";
    	this.currentUser1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
    	this.currentUser1.TextColor = new NxtControl.Drawing.Color("LabelTextColor");
    	// 
    	// runtimeConnection1
    	// 
    	this.runtimeConnection1.Anchor = NxtControl.Drawing.AnchorStyles.Right;
    	this.runtimeConnection1.Bounds = new NxtControl.Drawing.RectF(((float)(1160D)), ((float)(0D)), ((float)(40D)), ((float)(40D)));
    	this.runtimeConnection1.ConnectedColor = new NxtControl.Drawing.Color("RuntimeConnectionConnected");
    	this.runtimeConnection1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.runtimeConnection1.MibErrorColor = new NxtControl.Drawing.Color(((byte)(255)), ((byte)(0)), ((byte)(0)));
    	this.runtimeConnection1.Name = "runtimeConnection1";
    	this.runtimeConnection1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 1F, NxtControl.Drawing.DashStyle.Solid);
    	this.runtimeConnection1.Radius = 0D;
    	// 
    	// newVersionDeployment1
    	// 
    	this.newVersionDeployment1.Anchor = NxtControl.Drawing.AnchorStyles.Right;
    	this.newVersionDeployment1.Bounds = new NxtControl.Drawing.RectF(((float)(1120D)), ((float)(0D)), ((float)(40D)), ((float)(40D)));
    	this.newVersionDeployment1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.newVersionDeployment1.LookAndFeel = "Theme";
    	this.newVersionDeployment1.Name = "newVersionDeployment1";
    	this.newVersionDeployment1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("Transparent"), 1F, NxtControl.Drawing.DashStyle.Solid);
    	this.newVersionDeployment1.Radius = 2D;
    	this.newVersionDeployment1.Use3DEffect = false;
    	// 
    	// canvasTopologyNavigation
    	// 
    	this.canvasTopologyNavigation.BeginInit();
    	this.canvasTopologyNavigation.Brush = new NxtControl.Drawing.Brush("CanvasTopologyRoseBrush");
    	this.canvasTopologyNavigation.Color = new NxtControl.Drawing.Color(((byte)(255)), ((byte)(255)), ((byte)(0)));
    	this.canvasTopologyNavigation.DesignMatrix = new NxtControl.Drawing.Matrix2D(0.879120879120879D, 0D, 0D, 0.919540229885057D, 111.967032967033D, -1.83908045977011D);
    	this.canvasTopologyNavigation.LookAndFeel = "Theme";
    	this.canvasTopologyNavigation.Name = "canvasTopologyNavigation";
    	this.canvasTopologyNavigation.Tooltip = "Navigation to Canvases";
    	this.canvasTopologyNavigation.WorkArea = this.workArea;
    	this.canvasTopologyNavigation.EndInit();
    	// 
    	// logState1
    	// 
    	this.logState1.Anchor = NxtControl.Drawing.AnchorStyles.Right;
    	this.logState1.Bounds = new NxtControl.Drawing.RectF(((float)(1080D)), ((float)(0D)), ((float)(40D)), ((float)(40D)));
    	this.logState1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.logState1.Name = "logState1";
    	this.logState1.Pen = new NxtControl.Drawing.Pen(new NxtControl.Drawing.Color("FaceplateBackColor"), 0F, NxtControl.Drawing.DashStyle.Solid);
    	this.logState1.Radius = 0D;
    	// 
    	// aliasNameToggleButton1
    	// 
    	this.aliasNameToggleButton1.Bounds = new NxtControl.Drawing.RectF(((float)(1040D)), ((float)(8D)), ((float)(32D)), ((float)(32D)));
    	this.aliasNameToggleButton1.Brush = new NxtControl.Drawing.Brush("CanvasTopologyButtonBrush");
    	this.aliasNameToggleButton1.Font = new NxtControl.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
    	this.aliasNameToggleButton1.LookAndFeel = "normal";
    	this.aliasNameToggleButton1.Name = "aliasNameToggleButton1";
    	this.aliasNameToggleButton1.Pen = new NxtControl.Drawing.Pen("Transparent");
    	this.aliasNameToggleButton1.Radius = 0D;
    	this.aliasNameToggleButton1.TextAlignment = NxtControl.Drawing.ContentAlignment.MiddleCenter;
    	// 
    	// StartCanvas
    	// 
    	this.Bounds = new NxtControl.Drawing.RectF(((float)(0D)), ((float)(0D)), ((float)(1280D)), ((float)(980D)));
    	this.Shapes.AddRange(new System.ComponentModel.IComponent[] {
			this.header1,
			this.siblingsPanel,
			this.childrenPanel,
			this.logo,
			this.login1,
			this.language1,
			this.currentUser1,
			this.runtimeConnection1,
			this.newVersionDeployment1,
			this.canvasTopologyNavigation,
			this.logState1,
			this.canvasTopologySeparator1,
			this.canvasTopologySeparator2,
			this.workArea,
			this.aliasNameToggleButton1});
    	this.Size = new System.Drawing.Size(1280, 980);

    }
    
    private NxtControl.GuiFramework.Rectangle header1;
			private NxtControl.GuiFramework.CanvasTopologyPanel siblingsPanel;
			private NxtControl.GuiFramework.CanvasTopologyPanel childrenPanel;
private NxtControl.GuiFramework.Rectangle logo;
private NxtControl.GuiFramework.Login login1;
private NxtControl.GuiFramework.LanguageSwitcher language1;
private NxtControl.GuiFramework.CurrentUser currentUser1;
private NxtControl.GuiFramework.RuntimeConnection runtimeConnection1;
private NxtControl.GuiFramework.HMIDeployment newVersionDeployment1;
 private NxtControl.GuiFramework.CanvasTopologyRose canvasTopologyNavigation;
private NxtControl.GuiFramework.LogState logState1;

    private NxtControl.GuiFramework.WorkAreaControl workArea;    
    private NxtControl.GuiFramework.CanvasTopologySeparator canvasTopologySeparator1;
    private NxtControl.GuiFramework.CanvasTopologySeparator canvasTopologySeparator2; 
    private NxtControl.GuiFramework.AliasNameToggleButton aliasNameToggleButton1;
    #endregion
  }
}
