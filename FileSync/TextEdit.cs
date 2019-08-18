using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

using ZPF;

// http://www.codeproject.com/csharp/mishramynotepad.asp
// http://www.codeproject.com/csharp/methodfinder.asp

//public partial class TextEdit : TextBox
public partial class TextEdit : RichTextBox
{
   public TextEdit()
   {
      InitializeComponent();
   }

   bool TextWasChanged = false;
   public string FileName = "";

   private void textBox_TextChanged( object sender, EventArgs e )
   {
      TextWasChanged = true;
   }

   public void Save( string FileName )
   {
      StreamWriter sw = new StreamWriter( FileName );
      sw.WriteLine( this.Text );
      sw.Flush();
      sw.Close();
      TextWasChanged = false;
   }

   public void SaveAs()
   {
      saveFileDialog.Filter = "Text Files|*.txt";
      saveFileDialog.FileName = FileName;
      DialogResult res = saveFileDialog.ShowDialog();

      if( res == DialogResult.Cancel )
      {
         return;
      }

      FileName = saveFileDialog.FileName;
      MessageBox.Show( FileName );

      Save( FileName );
   }

   private void checkTextWasChanged()
   {
      if( TextWasChanged )
      {
         DialogResult click = MessageBox.Show( this, "Do You wish to save this Document?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );

         if( click == DialogResult.Yes )
         {
            SaveAs();
          Text="";
            FileName = "";
            TextWasChanged = false;
         };

         if( click == DialogResult.No )
         {
          Text="";
            FileName = "";
            TextWasChanged = false;
         };
      }
      else
      {
       Text = "";
         FileName = "";
      }
   }

   private void clearToolStripMenuItem_Click( object sender, EventArgs e )
   {
      checkTextWasChanged();
   }

   private void openToolStripMenuItem_Click( object sender, EventArgs e )
   {
      Open();
   }

   public void Open()
   {
      openFileDialog.Multiselect = false;
      openFileDialog.Filter = "Text Files|*.txt";
      openFileDialog.ShowDialog();

      if( File.Exists( openFileDialog.FileName ) )
      {
         LoadFile( openFileDialog.FileName );
      }
   }

   public new void LoadFile( string FileName )
   {
      StreamReader sr = new StreamReader( FileName );

      try
      {
       Text=sr.ReadToEnd();
         TextWasChanged = false;
      }
      finally
      {
         sr.Close();
      }
   }

   private void saveToolStripMenuItem_Click( object sender, EventArgs e )
   {
      SaveAs();
   }

   private void saveAsToolStripMenuItem_Click( object sender, EventArgs e )
   {
      saveFileDialog.Filter = "Text Files|*.txt";
      saveFileDialog.ShowDialog();
      FileName = saveFileDialog.FileName;
      SaveAs();
   }

   private void pageSetupToolStripMenuItem_Click( object sender, EventArgs e )
   {
      PrintString ps = new PrintString();
      ps.Text           = this.Text;
      ps.Font           = this.Font;
      ps.DocumentName   = FileName;

      pageSetupDialog.Document = ps;

      if( pageSetupDialog.ShowDialog() == DialogResult.OK )
      {
         ps.Print();
      };

   }

   private void printToolStripMenuItem_Click( object sender, EventArgs e )
   {
      Print();
   }

   public void Print()
   {
      PrintString ps = new PrintString();
      ps.Text           = this.Text;
      ps.Font           = this.Font;
      ps.DocumentName   = FileName;

      printDialog.Document = ps;
      printDialog.AllowSomePages = true;
      printDialog.AllowPrintToFile = true;

      if( printDialog.ShowDialog() == DialogResult.OK )
      {
         ps.Print();
      };
   }

   private void cutToolStripMenuItem_Click( object sender, EventArgs e )
   {
    Cut();
      TextWasChanged = true;
   }

   private void copyToolStripMenuItem_Click( object sender, EventArgs e )
   {
      Clipboard.SetDataObject( this.SelectedText, true );
   }

   private void pasteToolStripMenuItem_Click( object sender, EventArgs e )
   {
      IDataObject iData = Clipboard.GetDataObject();

      if( iData.GetDataPresent( DataFormats.Text ) )
      {
       SelectedText = iData.GetData( DataFormats.Text ).ToString();
      }
   }

   private void wordWrapToolStripMenuItem_Click( object sender, EventArgs e )
   {
      wordWrapToolStripMenuItem.Checked = !(wordWrapToolStripMenuItem.Checked);
    WordWrap = wordWrapToolStripMenuItem.Checked;
   }

   private void fontToolStripMenuItem_Click( object sender, EventArgs e )
   {
      fontDialog.Font = this.Font;
      fontDialog.ShowColor = true;
      fontDialog.ShowDialog();
    Font = fontDialog.Font;
    ForeColor=fontDialog.Color;
   }

   private void findToolStripMenuItem_Click( object sender, EventArgs e )
   {
      // wFindDlg.Find( this );
      // http://www.codeproject.com/cs/miscctrl/SearchableControls.asp
   }

   private void replaceToolStripMenuItem_Click( object sender, EventArgs e )
   {
      // wFindDlg.Replace( this );
   }
}
