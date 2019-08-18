partial class PrintPreview
{
   /// <summary>
   /// Required designer variable.
   /// </summary>
   private System.ComponentModel.IContainer components = null;

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   protected override void Dispose( bool disposing )
   {
      if( disposing && (components != null) )
      {
         components.Dispose();
      }
      base.Dispose( disposing );
   }

   #region Windows Form Designer generated code

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   private void InitializeComponent()
   {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PrintPreview ) );
    printPreviewControl = new System.Windows.Forms.PrintPreviewControl();
    toolStrip = new System.Windows.Forms.ToolStrip();
    printToolStripButton = new System.Windows.Forms.ToolStripButton();
    toolStripButtonPageSetup = new System.Windows.Forms.ToolStripButton();
    toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
    toolStripButton1Page = new System.Windows.Forms.ToolStripButton();
    toolStripButton2Pages = new System.Windows.Forms.ToolStripButton();
    toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
    toolStripMenuItemAuto = new System.Windows.Forms.ToolStripMenuItem();
    toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
    toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
    toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
    toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
    toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
    toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
    toolStripButtonPrev = new System.Windows.Forms.ToolStripButton();
    toolStripTextBoxPage = new System.Windows.Forms.ToolStripTextBox();
    toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
    toolStrip.SuspendLayout();
    SuspendLayout();
      // 
      // printPreviewControl
      // 
    printPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
    printPreviewControl.Location = new System.Drawing.Point( 0, 25 );
    printPreviewControl.Name = "printPreviewControl";
    printPreviewControl.Size = new System.Drawing.Size( 557, 246 );
    printPreviewControl.TabIndex = 0;
    printPreviewControl.UseAntiAlias = true;
      // 
      // toolStrip
      // 
    toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
          printToolStripButton,
          toolStripButtonPageSetup,
          toolStripSeparator,
          toolStripButton1Page,
          toolStripButton2Pages,
          toolStripDropDownButton1,
          toolStripSeparator1,
          toolStripButtonPrev,
          toolStripTextBoxPage,
          toolStripButtonNext} );
    toolStrip.Location = new System.Drawing.Point( 0, 0 );
    toolStrip.Name = "toolStrip";
    toolStrip.Size = new System.Drawing.Size( 557, 25 );
    toolStrip.TabIndex = 1;
    toolStrip.Text = "toolStrip1";
      // 
      // printToolStripButton
      // 
    printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject( "printToolStripButton.Image" )));
    printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
    printToolStripButton.Name = "printToolStripButton";
    printToolStripButton.Size = new System.Drawing.Size( 23, 22 );
    printToolStripButton.Text = "&Print";
    printToolStripButton.Click += new System.EventHandler( this.printToolStripButton_Click );
      // 
      // toolStripButtonPageSetup
      // 
    toolStripButtonPageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    toolStripButtonPageSetup.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButtonPageSetup.Image" )));
    toolStripButtonPageSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
    toolStripButtonPageSetup.Name = "toolStripButtonPageSetup";
    toolStripButtonPageSetup.Size = new System.Drawing.Size( 23, 22 );
    toolStripButtonPageSetup.Text = "Page setup";
    toolStripButtonPageSetup.Click += new System.EventHandler( this.toolStripButtonPageSetup_Click );
      // 
      // toolStripSeparator
      // 
    toolStripSeparator.Name = "toolStripSeparator";
    toolStripSeparator.Size = new System.Drawing.Size( 6, 25 );
      // 
      // toolStripButton1Page
      // 
    toolStripButton1Page.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
    toolStripButton1Page.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButton1Page.Image" )));
    toolStripButton1Page.ImageTransparentColor = System.Drawing.Color.Magenta;
    toolStripButton1Page.Name = "toolStripButton1Page";
    toolStripButton1Page.Size = new System.Drawing.Size( 58, 22 );
    toolStripButton1Page.Text = "One page";
    toolStripButton1Page.Click += new System.EventHandler( this.toolStripButton1Page_Click );
      // 
      // toolStripButton2Pages
      // 
    toolStripButton2Pages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
    toolStripButton2Pages.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButton2Pages.Image" )));
    toolStripButton2Pages.ImageTransparentColor = System.Drawing.Color.Magenta;
    toolStripButton2Pages.Name = "toolStripButton2Pages";
    toolStripButton2Pages.Size = new System.Drawing.Size( 63, 22 );
    toolStripButton2Pages.Text = "Two pages";
    toolStripButton2Pages.Click += new System.EventHandler( this.toolStripButton2Pages_Click );
      // 
      // toolStripDropDownButton1
      // 
    toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    toolStripDropDownButton1.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
          toolStripMenuItemAuto,
          toolStripMenuItem2,
          toolStripMenuItem3,
          toolStripMenuItem4,
          toolStripMenuItem5,
          toolStripMenuItem6} );
    toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripDropDownButton1.Image" )));
    toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
    toolStripDropDownButton1.Name = "toolStripDropDownButton1";
    toolStripDropDownButton1.Size = new System.Drawing.Size( 29, 22 );
    toolStripDropDownButton1.Text = "Zoom";
      // 
      // toolStripMenuItemAuto
      // 
    toolStripMenuItemAuto.Name = "toolStripMenuItemAuto";
    toolStripMenuItemAuto.Size = new System.Drawing.Size( 117, 22 );
    toolStripMenuItemAuto.Tag = "-1";
    toolStripMenuItemAuto.Text = "Auto";
    toolStripMenuItemAuto.Click += new System.EventHandler( this.toolStripMenuItemZoom_Click );
      // 
      // toolStripMenuItem2
      // 
    toolStripMenuItem2.Name = "toolStripMenuItem2";
    toolStripMenuItem2.Size = new System.Drawing.Size( 117, 22 );
    toolStripMenuItem2.Tag = "200";
    toolStripMenuItem2.Text = "200 %";
    toolStripMenuItem2.Click += new System.EventHandler( this.toolStripMenuItemZoom_Click );
      // 
      // toolStripMenuItem3
      // 
    toolStripMenuItem3.Name = "toolStripMenuItem3";
    toolStripMenuItem3.Size = new System.Drawing.Size( 117, 22 );
    toolStripMenuItem3.Tag = "100";
    toolStripMenuItem3.Text = "100 %";
    toolStripMenuItem3.Click += new System.EventHandler( this.toolStripMenuItemZoom_Click );
      // 
      // toolStripMenuItem4
      // 
    toolStripMenuItem4.Name = "toolStripMenuItem4";
    toolStripMenuItem4.Size = new System.Drawing.Size( 117, 22 );
    toolStripMenuItem4.Tag = "75";
    toolStripMenuItem4.Text = "75 %";
    toolStripMenuItem4.Click += new System.EventHandler( this.toolStripMenuItemZoom_Click );
      // 
      // toolStripMenuItem5
      // 
    toolStripMenuItem5.Name = "toolStripMenuItem5";
    toolStripMenuItem5.Size = new System.Drawing.Size( 117, 22 );
    toolStripMenuItem5.Tag = "50";
    toolStripMenuItem5.Text = "50 %";
    toolStripMenuItem5.Click += new System.EventHandler( this.toolStripMenuItemZoom_Click );
      // 
      // toolStripMenuItem6
      // 
    toolStripMenuItem6.Name = "toolStripMenuItem6";
    toolStripMenuItem6.Size = new System.Drawing.Size( 117, 22 );
    toolStripMenuItem6.Tag = "25";
    toolStripMenuItem6.Text = "25 %";
    toolStripMenuItem6.Click += new System.EventHandler( this.toolStripMenuItemZoom_Click );
      // 
      // toolStripSeparator1
      // 
    toolStripSeparator1.Name = "toolStripSeparator1";
    toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
      // 
      // toolStripButtonPrev
      // 
    toolStripButtonPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    toolStripButtonPrev.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButtonPrev.Image" )));
    toolStripButtonPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
    toolStripButtonPrev.Name = "toolStripButtonPrev";
    toolStripButtonPrev.Size = new System.Drawing.Size( 23, 22 );
    toolStripButtonPrev.Text = "Previous page";
    toolStripButtonPrev.Click += new System.EventHandler( this.toolStripButtonPrev_Click );
      // 
      // toolStripTextBoxPage
      // 
    toolStripTextBoxPage.Name = "toolStripTextBoxPage";
    toolStripTextBoxPage.Size = new System.Drawing.Size( 30, 25 );
      // 
      // toolStripButtonNext
      // 
    toolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    toolStripButtonNext.Image = ((System.Drawing.Image)(resources.GetObject( "toolStripButtonNext.Image" )));
    toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
    toolStripButtonNext.Name = "toolStripButtonNext";
    toolStripButtonNext.Size = new System.Drawing.Size( 23, 22 );
    toolStripButtonNext.Text = "Next page";
    toolStripButtonNext.Click += new System.EventHandler( this.toolStripButtonNext_Click );
      // 
      // PrintPreview
      // 
    AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    ClientSize = new System.Drawing.Size( 557, 271 );
    Controls.Add( this.printPreviewControl );
    Controls.Add( this.toolStrip );
    Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
    Name = "PrintPreview";
    ShowInTaskbar = false;
    Text = "Preview";
    FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.PrintPreview_FormClosing );
    Load += new System.EventHandler( this.PrintPreview_Load );
    toolStrip.ResumeLayout( false );
    toolStrip.PerformLayout();
    ResumeLayout( false );
    PerformLayout();

   }

   #endregion

   public System.Windows.Forms.PrintPreviewControl printPreviewControl;
   private System.Windows.Forms.ToolStrip toolStrip;
   private System.Windows.Forms.ToolStripButton printToolStripButton;
   private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
   private System.Windows.Forms.ToolStripButton toolStripButton1Page;
   private System.Windows.Forms.ToolStripButton toolStripButton2Pages;
   private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
   private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAuto;
   private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
   private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
   private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
   private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
   private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
   private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
   private System.Windows.Forms.ToolStripButton toolStripButtonPrev;
   private System.Windows.Forms.ToolStripButton toolStripButtonNext;
   private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPage;
   private System.Windows.Forms.ToolStripButton toolStripButtonPageSetup;
}
