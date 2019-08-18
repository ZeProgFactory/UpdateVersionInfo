namespace ZPF
{
    /// <summary>
    /// A simple dialog to find a supplied text string
    /// </summary>
    partial class wFindDlg
    {
        /// <summary>
        /// Required designer variable
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         searchButton = new System.Windows.Forms.Button();
         ignoreCaseCheckBox = new System.Windows.Forms.CheckBox();
         searchTypeComboBox = new System.Windows.Forms.ComboBox();
         searchHistoryComboBox = new System.Windows.Forms.ComboBox();
         label1 = new System.Windows.Forms.Label();
         label2 = new System.Windows.Forms.Label();
         replaceHistoryComboBox = new System.Windows.Forms.ComboBox();
         replaceButton = new System.Windows.Forms.Button();
         replaceAllButton = new System.Windows.Forms.Button();
         replaceModeCheckBox = new System.Windows.Forms.CheckBox();
         cancelButton = new System.Windows.Forms.Button();
         SuspendLayout();
           // 
           // searchButton
           // 
         searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         searchButton.Location = new System.Drawing.Point( 300, 24 );
         searchButton.Name = "searchButton";
         searchButton.Size = new System.Drawing.Size( 79, 23 );
         searchButton.TabIndex = 2;
         searchButton.Text = "&Search";
         searchButton.UseVisualStyleBackColor = true;
         searchButton.Click += new System.EventHandler( this.searchButton_Click );
         searchButton.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // ignoreCaseCheckBox
           // 
         ignoreCaseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         ignoreCaseCheckBox.AutoSize = true;
         ignoreCaseCheckBox.Checked = true;
         ignoreCaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
         ignoreCaseCheckBox.Location = new System.Drawing.Point( 11, 102 );
         ignoreCaseCheckBox.Name = "ignoreCaseCheckBox";
         ignoreCaseCheckBox.Size = new System.Drawing.Size( 82, 17 );
         ignoreCaseCheckBox.TabIndex = 3;
         ignoreCaseCheckBox.Text = "Ignore &case";
         ignoreCaseCheckBox.UseVisualStyleBackColor = true;
         ignoreCaseCheckBox.CheckedChanged += new System.EventHandler( this.ignoreCaseCheckBox_CheckedChanged );
         ignoreCaseCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // searchTypeComboBox
           // 
         searchTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         searchTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         searchTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         searchTypeComboBox.FormattingEnabled = true;
         searchTypeComboBox.Location = new System.Drawing.Point( 90, 100 );
         searchTypeComboBox.Name = "searchTypeComboBox";
         searchTypeComboBox.Size = new System.Drawing.Size( 119, 21 );
         searchTypeComboBox.TabIndex = 4;
         searchTypeComboBox.SelectedIndexChanged += new System.EventHandler( this.searchTypeComboBox_SelectedIndexChanged );
         searchTypeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // searchHistoryComboBox
           // 
         searchHistoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         searchHistoryComboBox.FormattingEnabled = true;
         searchHistoryComboBox.Location = new System.Drawing.Point( 6, 26 );
         searchHistoryComboBox.Name = "searchHistoryComboBox";
         searchHistoryComboBox.Size = new System.Drawing.Size( 288, 21 );
         searchHistoryComboBox.TabIndex = 5;
         searchHistoryComboBox.TextChanged += new System.EventHandler( this.searchHistoryComboBox_TextChanged );
         searchHistoryComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // label1
           // 
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point( 5, 10 );
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size( 47, 13 );
         label1.TabIndex = 6;
         label1.Text = "Find text";
           // 
           // label2
           // 
         label2.AutoSize = true;
         label2.Location = new System.Drawing.Point( 5, 50 );
         label2.Name = "label2";
         label2.Size = new System.Drawing.Size( 69, 13 );
         label2.TabIndex = 8;
         label2.Text = "Replace with";
           // 
           // replaceHistoryComboBox
           // 
         replaceHistoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         replaceHistoryComboBox.FormattingEnabled = true;
         replaceHistoryComboBox.Location = new System.Drawing.Point( 6, 64 );
         replaceHistoryComboBox.Name = "replaceHistoryComboBox";
         replaceHistoryComboBox.Size = new System.Drawing.Size( 288, 21 );
         replaceHistoryComboBox.TabIndex = 7;
           // 
           // replaceButton
           // 
         replaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         replaceButton.Location = new System.Drawing.Point( 300, 62 );
         replaceButton.Name = "replaceButton";
         replaceButton.Size = new System.Drawing.Size( 79, 23 );
         replaceButton.TabIndex = 2;
         replaceButton.Text = "&Replace";
         replaceButton.UseVisualStyleBackColor = true;
         replaceButton.Click += new System.EventHandler( this.replaceButton_Click );
         replaceButton.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // replaceAllButton
           // 
         replaceAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         replaceAllButton.Location = new System.Drawing.Point( 300, 100 );
         replaceAllButton.Name = "replaceAllButton";
         replaceAllButton.Size = new System.Drawing.Size( 79, 23 );
         replaceAllButton.TabIndex = 2;
         replaceAllButton.Text = "Replace &All";
         replaceAllButton.UseVisualStyleBackColor = true;
         replaceAllButton.Click += new System.EventHandler( this.replaceAllButton_Click );
         replaceAllButton.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // replaceModeCheckBox
           // 
         replaceModeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         replaceModeCheckBox.AutoSize = true;
         replaceModeCheckBox.Checked = true;
         replaceModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
         replaceModeCheckBox.Location = new System.Drawing.Point( 319, 5 );
         replaceModeCheckBox.Name = "replaceModeCheckBox";
         replaceModeCheckBox.Size = new System.Drawing.Size( 66, 17 );
         replaceModeCheckBox.TabIndex = 9;
         replaceModeCheckBox.Text = "Replace";
         replaceModeCheckBox.UseVisualStyleBackColor = true;
         replaceModeCheckBox.CheckedChanged += new System.EventHandler( this.replaceModeCheckBox_CheckedChanged );
           // 
           // cancelButton
           // 
         cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         cancelButton.Enabled = false;
         cancelButton.Location = new System.Drawing.Point( 215, 100 );
         cancelButton.Name = "cancelButton";
         cancelButton.Size = new System.Drawing.Size( 79, 23 );
         cancelButton.TabIndex = 2;
         cancelButton.Text = "&Cancel";
         cancelButton.UseVisualStyleBackColor = true;
         cancelButton.Click += new System.EventHandler( this.cancelButton_Click );
         cancelButton.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
           // 
           // wFindDlg
           // 
         AcceptButton = this.searchButton;
         AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size( 384, 130 );
         Controls.Add( this.replaceModeCheckBox );
         Controls.Add( this.label2 );
         Controls.Add( this.replaceHistoryComboBox );
         Controls.Add( this.label1 );
         Controls.Add( this.searchHistoryComboBox );
         Controls.Add( this.searchTypeComboBox );
         Controls.Add( this.cancelButton );
         Controls.Add( this.replaceAllButton );
         Controls.Add( this.replaceButton );
         Controls.Add( this.ignoreCaseCheckBox );
         Controls.Add( this.searchButton );
         FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         MaximizeBox = false;
         MaximumSize = new System.Drawing.Size( 800, 199 );
         MinimizeBox = false;
         MinimumSize = new System.Drawing.Size( 392, 26 );
         Name = "wFindDlg";
         Padding = new System.Windows.Forms.Padding( 2 );
         ShowInTaskbar = false;
         StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         Text = "Find Text";
         KeyDown += new System.Windows.Forms.KeyEventHandler( this.FindDialog_KeyDown );
         ResumeLayout( false );
         PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.CheckBox ignoreCaseCheckBox;
        private System.Windows.Forms.ComboBox searchTypeComboBox;
        private System.Windows.Forms.ComboBox searchHistoryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox replaceHistoryComboBox;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.CheckBox replaceModeCheckBox;
        private System.Windows.Forms.Button cancelButton;

    }
}