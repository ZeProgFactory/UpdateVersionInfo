using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZPF
{
   public partial class wNotePadDlg : Form
   {
      public wNotePadDlg()
      {
         InitializeComponent();
      }

      static public void Exec( string FileName )
      {
         wNotePadDlg dlg = new wNotePadDlg();

         dlg.panelBtn.Visible = false;
         dlg.Text = FileName;
         dlg.textEdit.FileName = FileName;
         dlg.textEdit.LoadFile( FileName );
         dlg.ShowDialog();
      }

      static public string Exec( string Caption, string Text )
      {
         string Result = Text;

         wNotePadDlg dlg = new wNotePadDlg();

         dlg.panelBtn.Visible = true;
         dlg.Text = Caption;
         dlg.textEdit.Text = Result;

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            Result = dlg.textEdit.Text;
         };

         return Result;
      }

      private void wNotePadDlg_Load( object sender, EventArgs e )
      {
         textEdit.SelectionLength = 0;
         textEdit.HideSelection = false;
      }

      private void exitToolStripMenuItem_Click( object sender, EventArgs e )
      {
         this.Close();
      }

      private void pageSetupToolStripMenuItem_Click( object sender, EventArgs e )
      {
         PrintString ps = new PrintString();
         ps.Text = textEdit.Text;
         ps.Font = textEdit.Font;
         ps.DocumentName = textEdit.FileName;

         pageSetupDialog.Document = ps;
         if( pageSetupDialog.ShowDialog() == DialogResult.OK )
         {
            ps.Print();
         };
      }

      private void printPreviewToolStripMenuItem_Click( object sender, EventArgs e )
      {
         PrintString ps = new PrintString();
         ps.Text = textEdit.Text;
         ps.Font = textEdit.Font;
         ps.DocumentName = textEdit.FileName;

         printPreviewDialog.Document = ps;
         printPreviewDialog.ShowDialog();
      }

      private void printToolStripMenuItem_Click( object sender, EventArgs e )
      {
         PrintString ps = new PrintString();
         ps.Text = textEdit.Text;
         ps.Font = textEdit.Font;
         ps.DocumentName = textEdit.FileName;

         printDialog.Document = ps;
         if ( printDialog.ShowDialog() == DialogResult.OK )
         {
            ps.Print();
         };
      }

      private void saveAsToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.SaveAs();
      }

      private void saveToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Save( textEdit.FileName );
      }

      private void openToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Open();
      }

      private void newToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Text = "";
         textEdit.FileName = "";
      }

      private void undoToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Undo();
      }

      private void redoToolStripMenuItem_Click( object sender, EventArgs e )
      {
      }

      private void cutToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Cut();
      }

      private void copyToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Copy();
      }

      private void pasteToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.Paste();
      }

      private void selectAllToolStripMenuItem_Click( object sender, EventArgs e )
      {
         textEdit.SelectAll();
      }

      private void findToolStripMenuItem_Click( object sender, EventArgs e )
      {
         wFindDlg.Find( textEdit );
      }

      private void replaceToolStripMenuItem_Click( object sender, EventArgs e )
      {
         wFindDlg.Replace( textEdit );
      }

      private void menuStrip_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
      {

      }
   }
}