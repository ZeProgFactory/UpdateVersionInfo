namespace ZPF
{
   partial class wLastChanceTrace
   {
      /// <summary>
      /// Required designer variable.
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wLastChanceTrace));
       textBoxMessage = new System.Windows.Forms.TextBox();
       textBoxType = new System.Windows.Forms.TextBox();
       textBoxStack = new System.Windows.Forms.TextBox();
       btnExit = new System.Windows.Forms.Button();
       btnSend = new System.Windows.Forms.Button();
       btnSave = new System.Windows.Forms.Button();
       panelBtn = new System.Windows.Forms.Panel();
       btnKill = new System.Windows.Forms.Button();
       panel2 = new System.Windows.Forms.Panel();
       pictureBox1 = new System.Windows.Forms.PictureBox();
       tabControl = new System.Windows.Forms.TabControl();
       tabPageMessage = new System.Windows.Forms.TabPage();
       richTextBox1 = new System.Windows.Forms.RichTextBox();
       tabPageDetails = new System.Windows.Forms.TabPage();
       tabPageSystem = new System.Windows.Forms.TabPage();
       textBoxSystem = new System.Windows.Forms.TextBox();
       panelBtn.SuspendLayout();
       panel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
       tabControl.SuspendLayout();
       tabPageMessage.SuspendLayout();
       tabPageDetails.SuspendLayout();
       tabPageSystem.SuspendLayout();
       SuspendLayout();
         // 
         // textBoxMessage
         // 
       textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
       textBoxMessage.Location = new System.Drawing.Point(114, 15);
       textBoxMessage.Name = "textBoxMessage";
       textBoxMessage.ReadOnly = true;
       textBoxMessage.Size = new System.Drawing.Size(333, 20);
       textBoxMessage.TabIndex = 0;
       textBoxMessage.Text = ".";
       textBoxMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // textBoxType
         // 
       textBoxType.AcceptsReturn = true;
       textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
       textBoxType.Location = new System.Drawing.Point(114, 41);
       textBoxType.Name = "textBoxType";
       textBoxType.ReadOnly = true;
       textBoxType.Size = new System.Drawing.Size(333, 20);
       textBoxType.TabIndex = 1;
       textBoxType.Text = ".";
       textBoxType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // textBoxStack
         // 
       textBoxStack.AcceptsReturn = true;
       textBoxStack.Dock = System.Windows.Forms.DockStyle.Fill;
       textBoxStack.Location = new System.Drawing.Point(5, 5);
       textBoxStack.Multiline = true;
       textBoxStack.Name = "textBoxStack";
       textBoxStack.ReadOnly = true;
       textBoxStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
       textBoxStack.Size = new System.Drawing.Size(439, 180);
       textBoxStack.TabIndex = 3;
       textBoxStack.WordWrap = false;
         // 
         // btnExit
         // 
       btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
       btnExit.Location = new System.Drawing.Point(302, 5);
       btnExit.Name = "btnExit";
       btnExit.Size = new System.Drawing.Size(75, 23);
       btnExit.TabIndex = 4;
       btnExit.Text = "Continue";
       btnExit.UseVisualStyleBackColor = true;
       btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // btnSend
         // 
       btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
       btnSend.Enabled = false;
       btnSend.Location = new System.Drawing.Point(221, 5);
       btnSend.Name = "btnSend";
       btnSend.Size = new System.Drawing.Size(75, 23);
       btnSend.TabIndex = 5;
       btnSend.Text = "Send";
       btnSend.UseVisualStyleBackColor = true;
       btnSend.Visible = false;
       btnSend.Click += new System.EventHandler(this.btnSend_Click);
         // 
         // btnSave
         // 
       btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
       btnSave.Location = new System.Drawing.Point(139, 5);
       btnSave.Name = "btnSave";
       btnSave.Size = new System.Drawing.Size(75, 23);
       btnSave.TabIndex = 6;
       btnSave.Text = "Save";
       btnSave.UseVisualStyleBackColor = true;
       btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // panelBtn
         // 
       panelBtn.Controls.Add(this.btnKill);
       panelBtn.Controls.Add(this.btnSend);
       panelBtn.Controls.Add(this.btnSave);
       panelBtn.Controls.Add(this.btnExit);
       panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
       panelBtn.Location = new System.Drawing.Point(10, 305);
       panelBtn.Name = "panelBtn";
       panelBtn.Size = new System.Drawing.Size(457, 28);
       panelBtn.TabIndex = 7;
         // 
         // btnKill
         // 
       btnKill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
       btnKill.Location = new System.Drawing.Point(382, 5);
       btnKill.Name = "btnKill";
       btnKill.Size = new System.Drawing.Size(75, 23);
       btnKill.TabIndex = 7;
       btnKill.Text = "Exit";
       btnKill.UseVisualStyleBackColor = true;
       btnKill.Click += new System.EventHandler(this.btnKill_Click);
         // 
         // panel2
         // 
       panel2.Controls.Add(this.pictureBox1);
       panel2.Controls.Add(this.textBoxMessage);
       panel2.Controls.Add(this.textBoxType);
       panel2.Dock = System.Windows.Forms.DockStyle.Top;
       panel2.Location = new System.Drawing.Point(10, 10);
       panel2.Name = "panel2";
       panel2.Size = new System.Drawing.Size(457, 72);
       panel2.TabIndex = 8;
         // 
         // pictureBox1
         // 
       pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
       pictureBox1.Location = new System.Drawing.Point(0, 0);
       pictureBox1.Name = "pictureBox1";
       pictureBox1.Size = new System.Drawing.Size(98, 61);
       pictureBox1.TabIndex = 2;
       pictureBox1.TabStop = false;
         // 
         // tabControl
         // 
       tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
       tabControl.Controls.Add(this.tabPageMessage);
       tabControl.Controls.Add(this.tabPageDetails);
       tabControl.Controls.Add(this.tabPageSystem);
       tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
       tabControl.Location = new System.Drawing.Point(10, 82);
       tabControl.Multiline = true;
       tabControl.Name = "tabControl";
       tabControl.Padding = new System.Drawing.Point(5, 5);
       tabControl.SelectedIndex = 0;
       tabControl.Size = new System.Drawing.Size(457, 223);
       tabControl.TabIndex = 1;
         // 
         // tabPageMessage
         // 
       tabPageMessage.Controls.Add(this.richTextBox1);
       tabPageMessage.Location = new System.Drawing.Point(4, 29);
       tabPageMessage.Name = "tabPageMessage";
       tabPageMessage.Padding = new System.Windows.Forms.Padding(3);
       tabPageMessage.Size = new System.Drawing.Size(449, 190);
       tabPageMessage.TabIndex = 0;
       tabPageMessage.Text = "Message";
       tabPageMessage.UseVisualStyleBackColor = true;
         // 
         // richTextBox1
         // 
       richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
       richTextBox1.Location = new System.Drawing.Point(11, 22);
       richTextBox1.Name = "richTextBox1";
       richTextBox1.ReadOnly = true;
       richTextBox1.Size = new System.Drawing.Size(423, 151);
       richTextBox1.TabIndex = 1;
       richTextBox1.Text = resources.GetString("richTextBox1.Text");
         // 
         // tabPageDetails
         // 
       tabPageDetails.Controls.Add(this.textBoxStack);
       tabPageDetails.Location = new System.Drawing.Point(4, 29);
       tabPageDetails.Name = "tabPageDetails";
       tabPageDetails.Padding = new System.Windows.Forms.Padding(5);
       tabPageDetails.Size = new System.Drawing.Size(449, 190);
       tabPageDetails.TabIndex = 1;
       tabPageDetails.Text = "Details";
       tabPageDetails.UseVisualStyleBackColor = true;
         // 
         // tabPageSystem
         // 
       tabPageSystem.Controls.Add(this.textBoxSystem);
       tabPageSystem.Location = new System.Drawing.Point(4, 29);
       tabPageSystem.Name = "tabPageSystem";
       tabPageSystem.Padding = new System.Windows.Forms.Padding(5);
       tabPageSystem.Size = new System.Drawing.Size(449, 190);
       tabPageSystem.TabIndex = 2;
       tabPageSystem.Text = "System";
       tabPageSystem.UseVisualStyleBackColor = true;
         // 
         // textBoxSystem
         // 
       textBoxSystem.AcceptsReturn = true;
       textBoxSystem.Dock = System.Windows.Forms.DockStyle.Fill;
       textBoxSystem.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
       textBoxSystem.Location = new System.Drawing.Point(5, 5);
       textBoxSystem.Multiline = true;
       textBoxSystem.Name = "textBoxSystem";
       textBoxSystem.ReadOnly = true;
       textBoxSystem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
       textBoxSystem.Size = new System.Drawing.Size(439, 180);
       textBoxSystem.TabIndex = 4;
       textBoxSystem.WordWrap = false;
         // 
         // wLastChanceTrace
         // 
       AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
       AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       ClientSize = new System.Drawing.Size(477, 343);
       Controls.Add(this.tabControl);
       Controls.Add(this.panel2);
       Controls.Add(this.panelBtn);
       Name = "wLastChanceTrace";
       Padding = new System.Windows.Forms.Padding(10);
       ShowIcon = false;
       ShowInTaskbar = false;
       StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
       Text = "LastChanceTrace";
       TopMost = true;
       panelBtn.ResumeLayout(false);
       panel2.ResumeLayout(false);
       panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
       tabControl.ResumeLayout(false);
       tabPageMessage.ResumeLayout(false);
       tabPageDetails.ResumeLayout(false);
       tabPageDetails.PerformLayout();
       tabPageSystem.ResumeLayout(false);
       tabPageSystem.PerformLayout();
       ResumeLayout(false);

      }

      #endregion

      internal System.Windows.Forms.TextBox textBoxMessage;
      internal System.Windows.Forms.TextBox textBoxType;
      internal System.Windows.Forms.TextBox textBoxStack;
      private System.Windows.Forms.Button btnExit;
      private System.Windows.Forms.Button btnSend;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Panel panelBtn;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button btnKill;
      private System.Windows.Forms.TabControl tabControl;
      private System.Windows.Forms.TabPage tabPageMessage;
      private System.Windows.Forms.TabPage tabPageDetails;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.TabPage tabPageSystem;
      internal System.Windows.Forms.TextBox textBoxSystem;

   }
}