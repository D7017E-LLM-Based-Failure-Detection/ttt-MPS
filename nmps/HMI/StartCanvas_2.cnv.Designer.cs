/* StartCanvas.cnv.Designer.cs */
/* =====================================================================$
 * Copyright © {2022} Schneider Electric.   All rights reserved.
 * The contents of this file is subject to confidentiality.
 *
 * =====================================================================$
 */

/*
 * Created by HMI.Main.
 * User:  
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
  /// Summary description for StartCanvas_2.
  /// </summary>
  partial class StartCanvas_2
  {
    #region Component Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartCanvas_2));         
      this.canvasTopologySeparator1 = new NxtControl.GuiFramework.CanvasTopologySeparator();      
      this.canvasTopologySeparator2 = new NxtControl.GuiFramework.CanvasTopologySeparator();      
      this.workArea = new NxtControl.GuiFramework.WorkAreaControl();
            
      // 
      // canvasTopologySeparator1
      //
      this.canvasTopologySeparator1.Anchor = NxtControl.Drawing.AnchorStyles.Left; 
      this.canvasTopologySeparator1.Bounds = new NxtControl.Drawing.RectF(((float)(0)), ((float)(0)), ((float)(2)), ((float)(0)));
      this.canvasTopologySeparator1.Name = "canvasTopologySeparator1";
      this.canvasTopologySeparator1.LookAndFeel = "Theme";
      this.canvasTopologySeparator1.Visible = true;
      // 
      // canvasTopologySeparator2
      //
      this.canvasTopologySeparator2.Anchor = NxtControl.Drawing.AnchorStyles.Right; 
      this.canvasTopologySeparator2.Bounds = new NxtControl.Drawing.RectF(((float)(800)), ((float)(0)), ((float)(2)), ((float)(0)));
      this.canvasTopologySeparator2.Name = "canvasTopologySeparator2";
      this.canvasTopologySeparator2.LookAndFeel = "Theme";
      this.canvasTopologySeparator2.Visible = false;      
      // 
      // workArea
      // 
      this.workArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.workArea.AutoScroll = true;
      this.workArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.workArea.Location = new System.Drawing.Point(0, 0);
      this.workArea.Name = "workArea";
      this.workArea.RuntimeMode = true;
      this.workArea.Size = new System.Drawing.Size(800, 480);
      this.workArea.TabIndex = 0;
      this.workArea.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
      
      // 
      // StartCanvas_2
      // 
      this.Bounds = new NxtControl.Drawing.RectF(((float)(0)), ((float)(0)), ((float)(800)), ((float)(480)));
      this.Name = "StartCanvas_2";
      this.ResizeBehavior = NxtControl.GuiFramework.ResizeBehavior.Standard;
      this.Shapes.AddRange(new System.ComponentModel.IComponent[] {                 
                  
                  this.canvasTopologySeparator1,
				  this.canvasTopologySeparator2,
				  this.workArea});
      this.Size = new System.Drawing.Size(800, 480);
    }
    
    private NxtControl.GuiFramework.WorkAreaControl workArea;    
    private NxtControl.GuiFramework.CanvasTopologySeparator canvasTopologySeparator1;
    private NxtControl.GuiFramework.CanvasTopologySeparator canvasTopologySeparator2; 
    #endregion
  }
}
