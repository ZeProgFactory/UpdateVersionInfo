namespace LittleHelpers
{
   partial class ProjectToolDlg
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.tbSolution = new System.Windows.Forms.TextBox();
         this.tbProject = new System.Windows.Forms.TextBox();
         this.lbSolution = new System.Windows.Forms.Label();
         this.lbProject = new System.Windows.Forms.Label();
         this.btnGoSol = new System.Windows.Forms.Button();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.tbTargetProject = new System.Windows.Forms.TextBox();
         this.tbTargetFolder = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(9, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Solution";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(9, 70);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(40, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Project";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(183, 115);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(0, 13);
         this.label3.TabIndex = 2;
         // 
         // tbSolution
         // 
         this.tbSolution.Location = new System.Drawing.Point(79, 19);
         this.tbSolution.Name = "tbSolution";
         this.tbSolution.ReadOnly = true;
         this.tbSolution.Size = new System.Drawing.Size(172, 20);
         this.tbSolution.TabIndex = 3;
         // 
         // tbProject
         // 
         this.tbProject.Location = new System.Drawing.Point(79, 67);
         this.tbProject.Name = "tbProject";
         this.tbProject.ReadOnly = true;
         this.tbProject.Size = new System.Drawing.Size(172, 20);
         this.tbProject.TabIndex = 4;
         // 
         // lbSolution
         // 
         this.lbSolution.AutoSize = true;
         this.lbSolution.Location = new System.Drawing.Point(76, 43);
         this.lbSolution.Name = "lbSolution";
         this.lbSolution.Size = new System.Drawing.Size(53, 13);
         this.lbSolution.TabIndex = 5;
         this.lbSolution.Text = "lbSolution";
         // 
         // lbProject
         // 
         this.lbProject.AutoSize = true;
         this.lbProject.Location = new System.Drawing.Point(76, 91);
         this.lbProject.Name = "lbProject";
         this.lbProject.Size = new System.Drawing.Size(48, 13);
         this.lbProject.TabIndex = 6;
         this.lbProject.Text = "lbProject";
         // 
         // btnGoSol
         // 
         this.btnGoSol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnGoSol.Enabled = false;
         this.btnGoSol.Location = new System.Drawing.Point(550, 218);
         this.btnGoSol.Name = "btnGoSol";
         this.btnGoSol.Size = new System.Drawing.Size(143, 23);
         this.btnGoSol.TabIndex = 7;
         this.btnGoSol.Text = "copy and rename solution";
         this.btnGoSol.UseVisualStyleBackColor = true;
         this.btnGoSol.Click += new System.EventHandler(this.btnGoSol_Click);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(10, 49);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(67, 13);
         this.label5.TabIndex = 9;
         this.label5.Text = "Target folder";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(10, 22);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(58, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "New name";
         // 
         // tbTargetProject
         // 
         this.tbTargetProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbTargetProject.Location = new System.Drawing.Point(78, 19);
         this.tbTargetProject.Name = "tbTargetProject";
         this.tbTargetProject.ReadOnly = true;
         this.tbTargetProject.Size = new System.Drawing.Size(597, 20);
         this.tbTargetProject.TabIndex = 11;
         this.tbTargetProject.Text = "tbTargetProject";
         this.tbTargetProject.TextChanged += new System.EventHandler(this.TextChanged);
         // 
         // tbTargetFolder
         // 
         this.tbTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbTargetFolder.Location = new System.Drawing.Point(78, 45);
         this.tbTargetFolder.Name = "tbTargetFolder";
         this.tbTargetFolder.ReadOnly = true;
         this.tbTargetFolder.Size = new System.Drawing.Size(597, 20);
         this.tbTargetFolder.TabIndex = 12;
         this.tbTargetFolder.Text = "tbTargetFolder";
         this.tbTargetFolder.TextChanged += new System.EventHandler(this.TextChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tbSolution);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tbProject);
         this.groupBox1.Controls.Add(this.lbSolution);
         this.groupBox1.Controls.Add(this.lbProject);
         this.groupBox1.Location = new System.Drawing.Point(12, 11);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(681, 117);
         this.groupBox1.TabIndex = 13;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = " source ";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.tbTargetProject);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.tbTargetFolder);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Location = new System.Drawing.Point(12, 134);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(681, 76);
         this.groupBox2.TabIndex = 14;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = " target ";
         // 
         // ProjectToolDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(705, 253);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnGoSol);
         this.Controls.Add(this.label3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProjectToolDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Little Helpers - Project tool";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox tbSolution;
      private System.Windows.Forms.TextBox tbProject;
      private System.Windows.Forms.Label lbSolution;
      private System.Windows.Forms.Label lbProject;
      private System.Windows.Forms.Button btnGoSol;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox tbTargetProject;
      private System.Windows.Forms.TextBox tbTargetFolder;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
   }
}