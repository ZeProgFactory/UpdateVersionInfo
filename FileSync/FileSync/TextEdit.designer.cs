
   partial class TextEdit
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
       components = new System.ComponentModel.Container();
       contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
       cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
       findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
       clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
       pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
       wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
       pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
       openFileDialog = new System.Windows.Forms.OpenFileDialog();
       printDialog = new System.Windows.Forms.PrintDialog();
       saveFileDialog = new System.Windows.Forms.SaveFileDialog();
       fontDialog = new System.Windows.Forms.FontDialog();
       contextMenuStrip.SuspendLayout();
       SuspendLayout();
         // 
         // contextMenuStrip
         // 
       contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
          cutToolStripMenuItem,
          copyToolStripMenuItem,
          pasteToolStripMenuItem,
          toolStripMenuItem2,
          findToolStripMenuItem,
          replaceToolStripMenuItem,
          toolStripMenuItem4,
          clearToolStripMenuItem,
          openToolStripMenuItem,
          saveToolStripMenuItem,
          saveAsToolStripMenuItem,
          toolStripMenuItem1,
          pageSetupToolStripMenuItem,
          printToolStripMenuItem,
          toolStripMenuItem3,
          wordWrapToolStripMenuItem,
          fontToolStripMenuItem} );
       contextMenuStrip.Name = "contextMenuStrip";
       contextMenuStrip.Size = new System.Drawing.Size( 159, 314 );
         // 
         // cutToolStripMenuItem
         // 
       cutToolStripMenuItem.Name = "cutToolStripMenuItem";
       cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
       cutToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       cutToolStripMenuItem.Text = "Cut";
       cutToolStripMenuItem.Click += new System.EventHandler( this.cutToolStripMenuItem_Click );
         // 
         // copyToolStripMenuItem
         // 
       copyToolStripMenuItem.Name = "copyToolStripMenuItem";
       copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
       copyToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       copyToolStripMenuItem.Text = "Copy";
       copyToolStripMenuItem.Click += new System.EventHandler( this.copyToolStripMenuItem_Click );
         // 
         // pasteToolStripMenuItem
         // 
       pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
       pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
       pasteToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       pasteToolStripMenuItem.Text = "Paste";
       pasteToolStripMenuItem.Click += new System.EventHandler( this.pasteToolStripMenuItem_Click );
         // 
         // toolStripMenuItem2
         // 
       toolStripMenuItem2.Name = "toolStripMenuItem2";
       toolStripMenuItem2.Size = new System.Drawing.Size( 155, 6 );
         // 
         // findToolStripMenuItem
         // 
       findToolStripMenuItem.Name = "findToolStripMenuItem";
       findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
       findToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       findToolStripMenuItem.Text = "Find";
       findToolStripMenuItem.Click += new System.EventHandler( this.findToolStripMenuItem_Click );
         // 
         // replaceToolStripMenuItem
         // 
       replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
       replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
       replaceToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       replaceToolStripMenuItem.Text = "Replace";
       replaceToolStripMenuItem.Click += new System.EventHandler( this.replaceToolStripMenuItem_Click );
         // 
         // toolStripMenuItem4
         // 
       toolStripMenuItem4.Name = "toolStripMenuItem4";
       toolStripMenuItem4.Size = new System.Drawing.Size( 155, 6 );
         // 
         // clearToolStripMenuItem
         // 
       clearToolStripMenuItem.Name = "clearToolStripMenuItem";
       clearToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       clearToolStripMenuItem.Text = "Clear";
       clearToolStripMenuItem.Click += new System.EventHandler( this.clearToolStripMenuItem_Click );
         // 
         // openToolStripMenuItem
         // 
       openToolStripMenuItem.Name = "openToolStripMenuItem";
       openToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       openToolStripMenuItem.Text = "Open...";
       openToolStripMenuItem.Click += new System.EventHandler( this.openToolStripMenuItem_Click );
         // 
         // saveToolStripMenuItem
         // 
       saveToolStripMenuItem.Name = "saveToolStripMenuItem";
       saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
       saveToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       saveToolStripMenuItem.Text = "Save";
       saveToolStripMenuItem.Click += new System.EventHandler( this.saveToolStripMenuItem_Click );
         // 
         // saveAsToolStripMenuItem
         // 
       saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
       saveAsToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       saveAsToolStripMenuItem.Text = "Save As...";
       saveAsToolStripMenuItem.Click += new System.EventHandler( this.saveAsToolStripMenuItem_Click );
         // 
         // toolStripMenuItem1
         // 
       toolStripMenuItem1.Name = "toolStripMenuItem1";
       toolStripMenuItem1.Size = new System.Drawing.Size( 155, 6 );
         // 
         // pageSetupToolStripMenuItem
         // 
       pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
       pageSetupToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       pageSetupToolStripMenuItem.Text = "Page Setup...";
       pageSetupToolStripMenuItem.Click += new System.EventHandler( this.pageSetupToolStripMenuItem_Click );
         // 
         // printToolStripMenuItem
         // 
       printToolStripMenuItem.Name = "printToolStripMenuItem";
       printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
       printToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       printToolStripMenuItem.Text = "&Print";
       printToolStripMenuItem.Click += new System.EventHandler( this.printToolStripMenuItem_Click );
         // 
         // toolStripMenuItem3
         // 
       toolStripMenuItem3.Name = "toolStripMenuItem3";
       toolStripMenuItem3.Size = new System.Drawing.Size( 155, 6 );
         // 
         // wordWrapToolStripMenuItem
         // 
       wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
       wordWrapToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       wordWrapToolStripMenuItem.Text = "Word Wrap";
       wordWrapToolStripMenuItem.Click += new System.EventHandler( this.wordWrapToolStripMenuItem_Click );
         // 
         // fontToolStripMenuItem
         // 
       fontToolStripMenuItem.Name = "fontToolStripMenuItem";
       fontToolStripMenuItem.Size = new System.Drawing.Size( 158, 22 );
       fontToolStripMenuItem.Text = "Font...";
       fontToolStripMenuItem.Click += new System.EventHandler( this.fontToolStripMenuItem_Click );
         // 
         // saveFileDialog
         // 
       saveFileDialog.FileName = "doc1";
         // 
         // TextEdit
         // 
       ContextMenuStrip = this.contextMenuStrip;
       Font = new System.Drawing.Font( "Courier New", 9F );
       Multiline = true;
       Size = new System.Drawing.Size( 100, 20 );
       WordWrap = false;
       contextMenuStrip.ResumeLayout( false );
       ResumeLayout( false );

      }

      #endregion

      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
      private System.Windows.Forms.PageSetupDialog pageSetupDialog;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
      private System.Windows.Forms.PrintDialog printDialog;
      private System.Windows.Forms.SaveFileDialog saveFileDialog;
      private System.Windows.Forms.FontDialog fontDialog;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
   }
