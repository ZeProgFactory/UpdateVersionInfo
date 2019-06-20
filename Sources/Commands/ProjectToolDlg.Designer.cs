namespace LittleHelpers.Commands
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
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Solution";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 64);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(40, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Project";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(183, 111);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(0, 13);
         this.label3.TabIndex = 2;
         // 
         // tbSolution
         // 
         this.tbSolution.Location = new System.Drawing.Point(64, 13);
         this.tbSolution.Name = "tbSolution";
         this.tbSolution.ReadOnly = true;
         this.tbSolution.Size = new System.Drawing.Size(172, 20);
         this.tbSolution.TabIndex = 3;
         // 
         // tbProject
         // 
         this.tbProject.Location = new System.Drawing.Point(64, 61);
         this.tbProject.Name = "tbProject";
         this.tbProject.ReadOnly = true;
         this.tbProject.Size = new System.Drawing.Size(172, 20);
         this.tbProject.TabIndex = 4;
         // 
         // lbSolution
         // 
         this.lbSolution.AutoSize = true;
         this.lbSolution.Location = new System.Drawing.Point(61, 36);
         this.lbSolution.Name = "lbSolution";
         this.lbSolution.Size = new System.Drawing.Size(53, 13);
         this.lbSolution.TabIndex = 5;
         this.lbSolution.Text = "lbSolution";
         // 
         // lbProject
         // 
         this.lbProject.AutoSize = true;
         this.lbProject.Location = new System.Drawing.Point(61, 84);
         this.lbProject.Name = "lbProject";
         this.lbProject.Size = new System.Drawing.Size(48, 13);
         this.lbProject.TabIndex = 6;
         this.lbProject.Text = "lbProject";
         // 
         // ProjectToolDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(705, 182);
         this.Controls.Add(this.lbProject);
         this.Controls.Add(this.lbSolution);
         this.Controls.Add(this.tbProject);
         this.Controls.Add(this.tbSolution);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProjectToolDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Little Helpers - Project tool";
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
   }
}