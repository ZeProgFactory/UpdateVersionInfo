namespace FileSync
{
   partial class wMain
   {
      /// <summary>
      /// Variable nécessaire au concepteur.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Nettoyage des ressources utilisées.
      /// </summary>
      /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
      protected override void Dispose( bool disposing )
      {
         if( disposing && (components != null) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Code généré par le Concepteur Windows Form

      /// <summary>
      /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
      /// le contenu de cette méthode avec l'éditeur de code.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( wMain ) );
         this.menuStrip = new System.Windows.Forms.MenuStrip();
         this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.changeFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
         this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.lineNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
         this.blackWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.reloadFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.helpOnWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItemNext = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItemPrev = new System.Windows.Forms.ToolStripMenuItem();
         this.statusStrip = new System.Windows.Forms.StatusStrip();
         this.listView = new System.Windows.Forms.ListView();
         this.columnHeaderIcon = new System.Windows.Forms.ColumnHeader();
         this.columnHeaderLines = new System.Windows.Forms.ColumnHeader();
         this.columnHeaderFile1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeaderFile2 = new System.Windows.Forms.ColumnHeader();
         this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
         this.copyLineLRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.copyLineLRToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
         this.editLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.editRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.changeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.imageList = new System.Windows.Forms.ImageList( this.components );
         this.listBox = new System.Windows.Forms.ListBox();
         this.panelBody = new System.Windows.Forms.Panel();
         this.panelSep = new System.Windows.Forms.Panel();
         this.whatsNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
         this.menuStrip.SuspendLayout();
         this.contextMenuStrip.SuspendLayout();
         this.panelBody.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip
         // 
         this.menuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItemNext,
            this.toolStripMenuItemPrev} );
         this.menuStrip.Location = new System.Drawing.Point( 0, 0 );
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.Size = new System.Drawing.Size( 791, 24 );
         this.menuStrip.TabIndex = 0;
         this.menuStrip.Text = "menuStrip1";
         // 
         // filesToolStripMenuItem
         // 
         this.filesToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.changeFilesToolStripMenuItem1,
            this.reloadToolStripMenuItem,
            this.saveChangesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.pageSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem} );
         this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
         this.filesToolStripMenuItem.Size = new System.Drawing.Size( 42, 20 );
         this.filesToolStripMenuItem.Text = "Files";
         // 
         // changeFilesToolStripMenuItem1
         // 
         this.changeFilesToolStripMenuItem1.Name = "changeFilesToolStripMenuItem1";
         this.changeFilesToolStripMenuItem1.Size = new System.Drawing.Size( 152, 22 );
         this.changeFilesToolStripMenuItem1.Text = "Change Files";
         this.changeFilesToolStripMenuItem1.Click += new System.EventHandler( this.changeFilesToolStripMenuItem_Click );
         // 
         // reloadToolStripMenuItem
         // 
         this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
         this.reloadToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
         this.reloadToolStripMenuItem.Text = "Reload";
         this.reloadToolStripMenuItem.Click += new System.EventHandler( this.reloadToolStripMenuItem_Click );
         // 
         // saveChangesToolStripMenuItem
         // 
         this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
         this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
         this.saveChangesToolStripMenuItem.Text = "Save changes";
         this.saveChangesToolStripMenuItem.Click += new System.EventHandler( this.saveChangesToolStripMenuItem_Click );
         // 
         // toolStripMenuItem3
         // 
         this.toolStripMenuItem3.Name = "toolStripMenuItem3";
         this.toolStripMenuItem3.Size = new System.Drawing.Size( 149, 6 );
         // 
         // pageSetupToolStripMenuItem
         // 
         this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
         this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
         this.pageSetupToolStripMenuItem.Text = "Page Setup...";
         this.pageSetupToolStripMenuItem.Click += new System.EventHandler( this.pageSetupToolStripMenuItem_Click );
         // 
         // printPreviewToolStripMenuItem
         // 
         this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
         this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
         this.printPreviewToolStripMenuItem.Text = "Print Preview...";
         this.printPreviewToolStripMenuItem.Click += new System.EventHandler( this.printPreviewToolStripMenuItem_Click );
         // 
         // printToolStripMenuItem1
         // 
         this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
         this.printToolStripMenuItem1.Size = new System.Drawing.Size( 152, 22 );
         this.printToolStripMenuItem1.Text = "Print";
         this.printToolStripMenuItem1.Click += new System.EventHandler( this.printToolStripMenuItem_Click );
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size( 149, 6 );
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
         // 
         // viewToolStripMenuItem
         // 
         this.viewToolStripMenuItem.Checked = true;
         this.viewToolStripMenuItem.CheckOnClick = true;
         this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.viewToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lineNumbersToolStripMenuItem,
            this.blackWhiteToolStripMenuItem,
            this.reloadFilesToolStripMenuItem} );
         this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
         this.viewToolStripMenuItem.Size = new System.Drawing.Size( 44, 20 );
         this.viewToolStripMenuItem.Text = "View";
         // 
         // lineNumbersToolStripMenuItem
         // 
         this.lineNumbersToolStripMenuItem.Items.AddRange( new object[] {
            "Count",
            "Left line numbers",
            "Right line numbers"} );
         this.lineNumbersToolStripMenuItem.Name = "lineNumbersToolStripMenuItem";
         this.lineNumbersToolStripMenuItem.Size = new System.Drawing.Size( 152, 23 );
         this.lineNumbersToolStripMenuItem.Text = "Line numbers";
         this.lineNumbersToolStripMenuItem.SelectedIndexChanged += new System.EventHandler( this.lineNumbersToolStripMenuItem_SelectedIndexChanged );
         // 
         // blackWhiteToolStripMenuItem
         // 
         this.blackWhiteToolStripMenuItem.Checked = true;
         this.blackWhiteToolStripMenuItem.CheckOnClick = true;
         this.blackWhiteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.blackWhiteToolStripMenuItem.Name = "blackWhiteToolStripMenuItem";
         this.blackWhiteToolStripMenuItem.Size = new System.Drawing.Size( 212, 22 );
         this.blackWhiteToolStripMenuItem.Text = "Black && White";
         this.blackWhiteToolStripMenuItem.CheckStateChanged += new System.EventHandler( this.blackWhiteToolStripMenuItem_CheckStateChanged );
         // 
         // reloadFilesToolStripMenuItem
         // 
         this.reloadFilesToolStripMenuItem.Name = "reloadFilesToolStripMenuItem";
         this.reloadFilesToolStripMenuItem.Size = new System.Drawing.Size( 212, 22 );
         this.reloadFilesToolStripMenuItem.Text = "Reload Files";
         this.reloadFilesToolStripMenuItem.Click += new System.EventHandler( this.reloadFilesToolStripMenuItem_Click );
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.helpOnWebToolStripMenuItem,
            this.whatsNewToolStripMenuItem,
            this.toolStripMenuItem5,
            this.aboutToolStripMenuItem} );
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size( 24, 20 );
         this.toolStripMenuItem2.Text = "?";
         // 
         // helpOnWebToolStripMenuItem
         // 
         this.helpOnWebToolStripMenuItem.Name = "helpOnWebToolStripMenuItem";
         this.helpOnWebToolStripMenuItem.Size = new System.Drawing.Size( 153, 22 );
         this.helpOnWebToolStripMenuItem.Text = "Help on web ...";
         this.helpOnWebToolStripMenuItem.Click += new System.EventHandler( this.helpOnWebToolStripMenuItem_Click );
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size( 153, 22 );
         this.aboutToolStripMenuItem.Text = "About ...";
         this.aboutToolStripMenuItem.Click += new System.EventHandler( this.aboutToolStripMenuItem_Click );
         // 
         // toolStripMenuItemNext
         // 
         this.toolStripMenuItemNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripMenuItemNext.Name = "toolStripMenuItemNext";
         this.toolStripMenuItemNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
         this.toolStripMenuItemNext.Size = new System.Drawing.Size( 43, 20 );
         this.toolStripMenuItemNext.Text = "Next";
         this.toolStripMenuItemNext.Click += new System.EventHandler( this.toolStripMenuItemNext_Click );
         // 
         // toolStripMenuItemPrev
         // 
         this.toolStripMenuItemPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripMenuItemPrev.Name = "toolStripMenuItemPrev";
         this.toolStripMenuItemPrev.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
         this.toolStripMenuItemPrev.Size = new System.Drawing.Size( 64, 20 );
         this.toolStripMenuItemPrev.Text = "Previous";
         this.toolStripMenuItemPrev.Click += new System.EventHandler( this.toolStripMenuItemPrev_Click );
         // 
         // statusStrip
         // 
         this.statusStrip.Location = new System.Drawing.Point( 0, 387 );
         this.statusStrip.Name = "statusStrip";
         this.statusStrip.Size = new System.Drawing.Size( 791, 22 );
         this.statusStrip.TabIndex = 1;
         this.statusStrip.Text = "statusStrip1";
         // 
         // listView
         // 
         this.listView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIcon,
            this.columnHeaderLines,
            this.columnHeaderFile1,
            this.columnHeaderFile2} );
         this.listView.ContextMenuStrip = this.contextMenuStrip;
         this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listView.Font = new System.Drawing.Font( "Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.listView.FullRowSelect = true;
         this.listView.Location = new System.Drawing.Point( 5, 5 );
         this.listView.Name = "listView";
         this.listView.OwnerDraw = true;
         this.listView.ShowItemToolTips = true;
         this.listView.Size = new System.Drawing.Size( 781, 299 );
         this.listView.SmallImageList = this.imageList;
         this.listView.TabIndex = 2;
         this.listView.UseCompatibleStateImageBehavior = false;
         this.listView.View = System.Windows.Forms.View.Details;
         this.listView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler( this.listView_DrawColumnHeader );
         this.listView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler( this.listView_DrawItem );
         this.listView.SelectedIndexChanged += new System.EventHandler( this.listView_SelectedIndexChanged );
         this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler( this.listView_MouseMove );
         this.listView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler( this.listView_DrawSubItem );
         // 
         // columnHeaderIcon
         // 
         this.columnHeaderIcon.Text = "";
         this.columnHeaderIcon.Width = 20;
         // 
         // columnHeaderLines
         // 
         this.columnHeaderLines.Text = "Lines";
         this.columnHeaderLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // columnHeaderFile1
         // 
         this.columnHeaderFile1.Width = 200;
         // 
         // columnHeaderFile2
         // 
         this.columnHeaderFile2.Width = 200;
         // 
         // contextMenuStrip
         // 
         this.contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.copyLineLRToolStripMenuItem,
            this.copyLineLRToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.editLeftToolStripMenuItem,
            this.editRightToolStripMenuItem,
            this.changeFilesToolStripMenuItem,
            this.printToolStripMenuItem} );
         this.contextMenuStrip.Name = "contextMenuStrip";
         this.contextMenuStrip.Size = new System.Drawing.Size( 165, 142 );
         // 
         // copyLineLRToolStripMenuItem
         // 
         this.copyLineLRToolStripMenuItem.Name = "copyLineLRToolStripMenuItem";
         this.copyLineLRToolStripMenuItem.Size = new System.Drawing.Size( 164, 22 );
         this.copyLineLRToolStripMenuItem.Text = "Copy line L --> R";
         this.copyLineLRToolStripMenuItem.Click += new System.EventHandler( this.copyLineLRToolStripMenuItem_Click );
         // 
         // copyLineLRToolStripMenuItem1
         // 
         this.copyLineLRToolStripMenuItem1.Name = "copyLineLRToolStripMenuItem1";
         this.copyLineLRToolStripMenuItem1.Size = new System.Drawing.Size( 164, 22 );
         this.copyLineLRToolStripMenuItem1.Text = "Copy line L <-- R";
         this.copyLineLRToolStripMenuItem1.Click += new System.EventHandler( this.copyLineRLToolStripMenuItem_Click );
         // 
         // toolStripMenuItem4
         // 
         this.toolStripMenuItem4.Name = "toolStripMenuItem4";
         this.toolStripMenuItem4.Size = new System.Drawing.Size( 161, 6 );
         // 
         // editLeftToolStripMenuItem
         // 
         this.editLeftToolStripMenuItem.Name = "editLeftToolStripMenuItem";
         this.editLeftToolStripMenuItem.Size = new System.Drawing.Size( 164, 22 );
         this.editLeftToolStripMenuItem.Text = "Edit left";
         this.editLeftToolStripMenuItem.Click += new System.EventHandler( this.editToolStripMenuItem_Click );
         // 
         // editRightToolStripMenuItem
         // 
         this.editRightToolStripMenuItem.Name = "editRightToolStripMenuItem";
         this.editRightToolStripMenuItem.Size = new System.Drawing.Size( 164, 22 );
         this.editRightToolStripMenuItem.Text = "Edit right";
         this.editRightToolStripMenuItem.Click += new System.EventHandler( this.editToolStripMenuItem_Click );
         // 
         // changeFilesToolStripMenuItem
         // 
         this.changeFilesToolStripMenuItem.Name = "changeFilesToolStripMenuItem";
         this.changeFilesToolStripMenuItem.Size = new System.Drawing.Size( 164, 22 );
         this.changeFilesToolStripMenuItem.Text = "Change Files";
         this.changeFilesToolStripMenuItem.Click += new System.EventHandler( this.changeFilesToolStripMenuItem_Click );
         // 
         // printToolStripMenuItem
         // 
         this.printToolStripMenuItem.Name = "printToolStripMenuItem";
         this.printToolStripMenuItem.Size = new System.Drawing.Size( 164, 22 );
         this.printToolStripMenuItem.Text = "Print";
         this.printToolStripMenuItem.Click += new System.EventHandler( this.printToolStripMenuItem_Click );
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList.ImageStream" )));
         this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
         this.imageList.Images.SetKeyName( 0, "Equal.bmp" );
         this.imageList.Images.SetKeyName( 1, "BuilderDialog_add.bmp" );
         this.imageList.Images.SetKeyName( 2, "BuilderDialog_remove.bmp" );
         this.imageList.Images.SetKeyName( 3, "Different.bmp" );
         // 
         // listBox
         // 
         this.listBox.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.listBox.Font = new System.Drawing.Font( "Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.listBox.FormattingEnabled = true;
         this.listBox.HorizontalScrollbar = true;
         this.listBox.ItemHeight = 15;
         this.listBox.Items.AddRange( new object[] {
            "1",
            "2"} );
         this.listBox.Location = new System.Drawing.Point( 5, 309 );
         this.listBox.Name = "listBox";
         this.listBox.Size = new System.Drawing.Size( 781, 49 );
         this.listBox.TabIndex = 3;
         // 
         // panelBody
         // 
         this.panelBody.Controls.Add( this.listView );
         this.panelBody.Controls.Add( this.panelSep );
         this.panelBody.Controls.Add( this.listBox );
         this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelBody.Location = new System.Drawing.Point( 0, 24 );
         this.panelBody.Name = "panelBody";
         this.panelBody.Padding = new System.Windows.Forms.Padding( 5 );
         this.panelBody.Size = new System.Drawing.Size( 791, 363 );
         this.panelBody.TabIndex = 4;
         // 
         // panelSep
         // 
         this.panelSep.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panelSep.Location = new System.Drawing.Point( 5, 304 );
         this.panelSep.Name = "panelSep";
         this.panelSep.Size = new System.Drawing.Size( 781, 5 );
         this.panelSep.TabIndex = 4;
         // 
         // whatsNewToolStripMenuItem
         // 
         this.whatsNewToolStripMenuItem.Name = "whatsNewToolStripMenuItem";
         this.whatsNewToolStripMenuItem.Size = new System.Drawing.Size( 153, 22 );
         this.whatsNewToolStripMenuItem.Text = "What\'s new ...";
         this.whatsNewToolStripMenuItem.Click += new System.EventHandler( this.whatsNewToolStripMenuItem_Click );
         // 
         // toolStripMenuItem5
         // 
         this.toolStripMenuItem5.Name = "toolStripMenuItem5";
         this.toolStripMenuItem5.Size = new System.Drawing.Size( 150, 6 );
         // 
         // wMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 791, 409 );
         this.Controls.Add( this.panelBody );
         this.Controls.Add( this.statusStrip );
         this.Controls.Add( this.menuStrip );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MainMenuStrip = this.menuStrip;
         this.Name = "wMain";
         this.Text = "File Sync";
         this.Load += new System.EventHandler( this.wMain_Load );
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.wMain_FormClosing );
         this.Resize += new System.EventHandler( this.wMain_Resize );
         this.menuStrip.ResumeLayout( false );
         this.menuStrip.PerformLayout();
         this.contextMenuStrip.ResumeLayout( false );
         this.panelBody.ResumeLayout( false );
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip;
      private System.Windows.Forms.StatusStrip statusStrip;
      private System.Windows.Forms.ListView listView;
      private System.Windows.Forms.ColumnHeader columnHeaderLines;
      private System.Windows.Forms.ColumnHeader columnHeaderFile1;
      private System.Windows.Forms.ColumnHeader columnHeaderFile2;
      private System.Windows.Forms.ListBox listBox;
      private System.Windows.Forms.Panel panelBody;
      private System.Windows.Forms.Panel panelSep;
      private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem changeFilesToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem editLeftToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem changeFilesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpOnWebToolStripMenuItem;
      private System.Windows.Forms.ColumnHeader columnHeaderIcon;
      private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripComboBox lineNumbersToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem blackWhiteToolStripMenuItem;
      private System.Windows.Forms.ImageList imageList;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNext;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPrev;
      private System.Windows.Forms.ToolStripMenuItem reloadFilesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem editRightToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
      private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem copyLineLRToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem copyLineLRToolStripMenuItem1;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem whatsNewToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
   }
}

