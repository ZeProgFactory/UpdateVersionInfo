namespace FileSync
{
   partial class SelectFiles
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
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.labelFile1 = new System.Windows.Forms.Label();
         this.labelFile2 = new System.Windows.Forms.Label();
         this.buttonFile1 = new System.Windows.Forms.Button();
         this.comboBoxFile1 = new System.Windows.Forms.ComboBox();
         this.buttonFile2 = new System.Windows.Forms.Button();
         this.comboBoxFile2 = new System.Windows.Forms.ComboBox();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.SuspendLayout();
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point( 306, 140 );
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
         this.buttonOK.TabIndex = 0;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point( 387, 140 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // labelFile1
         // 
         this.labelFile1.AutoSize = true;
         this.labelFile1.Location = new System.Drawing.Point( 13, 13 );
         this.labelFile1.Name = "labelFile1";
         this.labelFile1.Size = new System.Drawing.Size( 29, 13 );
         this.labelFile1.TabIndex = 2;
         this.labelFile1.Text = "File1";
         // 
         // labelFile2
         // 
         this.labelFile2.AutoSize = true;
         this.labelFile2.Location = new System.Drawing.Point( 13, 76 );
         this.labelFile2.Name = "labelFile2";
         this.labelFile2.Size = new System.Drawing.Size( 29, 13 );
         this.labelFile2.TabIndex = 3;
         this.labelFile2.Text = "File2";
         // 
         // buttonFile1
         // 
         this.buttonFile1.Location = new System.Drawing.Point( 441, 30 );
         this.buttonFile1.Name = "buttonFile1";
         this.buttonFile1.Size = new System.Drawing.Size( 21, 21 );
         this.buttonFile1.TabIndex = 6;
         this.buttonFile1.UseVisualStyleBackColor = true;
         this.buttonFile1.Click += new System.EventHandler( this.buttonFile1_Click );
         // 
         // comboBoxFile1
         // 
         this.comboBoxFile1.FormattingEnabled = true;
         this.comboBoxFile1.Location = new System.Drawing.Point( 16, 30 );
         this.comboBoxFile1.Name = "comboBoxFile1";
         this.comboBoxFile1.Size = new System.Drawing.Size( 419, 21 );
         this.comboBoxFile1.TabIndex = 8;
         // 
         // buttonFile2
         // 
         this.buttonFile2.Location = new System.Drawing.Point( 441, 93 );
         this.buttonFile2.Name = "buttonFile2";
         this.buttonFile2.Size = new System.Drawing.Size( 21, 21 );
         this.buttonFile2.TabIndex = 9;
         this.buttonFile2.UseVisualStyleBackColor = true;
         this.buttonFile2.Click += new System.EventHandler( this.buttonFile2_Click );
         // 
         // comboBoxFile2
         // 
         this.comboBoxFile2.FormattingEnabled = true;
         this.comboBoxFile2.Location = new System.Drawing.Point( 16, 94 );
         this.comboBoxFile2.Name = "comboBoxFile2";
         this.comboBoxFile2.Size = new System.Drawing.Size( 419, 21 );
         this.comboBoxFile2.TabIndex = 10;
         // 
         // openFileDialog
         // 
         this.openFileDialog.FileName = "openFileDialog1";
         // 
         // SelectFiles
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 474, 175 );
         this.Controls.Add( this.comboBoxFile2 );
         this.Controls.Add( this.buttonFile2 );
         this.Controls.Add( this.comboBoxFile1 );
         this.Controls.Add( this.buttonFile1 );
         this.Controls.Add( this.labelFile2 );
         this.Controls.Add( this.labelFile1 );
         this.Controls.Add( this.buttonCancel );
         this.Controls.Add( this.buttonOK );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SelectFiles";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SelectFiles";
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label labelFile1;
      private System.Windows.Forms.Label labelFile2;
      private System.Windows.Forms.Button buttonFile1;
      private System.Windows.Forms.Button buttonFile2;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
      public System.Windows.Forms.ComboBox comboBoxFile1;
      public System.Windows.Forms.ComboBox comboBoxFile2;
   }
}