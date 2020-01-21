using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZPF;

public partial class PrintPreview : Form
{
   string _IniFileName = "";

   public PrintPreview( string IniFileName )
   {
      _IniFileName = IniFileName;

      InitializeComponent();
   }

   private void toolStripButton1Page_Click( object sender, EventArgs e )
   {
    printPreviewControl.Columns = 1;
    printPreviewControl.Rows = 1;
   }

   private void toolStripButton2Pages_Click( object sender, EventArgs e )
   {
    printPreviewControl.Columns = 2;
    printPreviewControl.Rows = 1;
   }

   private void toolStripMenuItemZoom_Click( object sender, EventArgs e )
   {
      int ZoomFactor = int.Parse( (sender as ToolStripMenuItem).Tag.ToString() );

      if( ZoomFactor == -1 )
      {
       printPreviewControl.AutoZoom = true;
      }
      else
      {
       printPreviewControl.Zoom = ZoomFactor / 100.0;
      }
   }

   private void toolStripButtonPrev_Click( object sender, EventArgs e )
   {
      if( 0 < printPreviewControl.StartPage )
      {
         printPreviewControl.StartPage -= 1;
         printPreviewControl.Invalidate();
         UpdatePageLabel();
      }
   }

   int _TotalNumberOfPages = 9999;

   private void toolStripButtonNext_Click( object sender, EventArgs e )
   {
      if( printPreviewControl.StartPage < _TotalNumberOfPages - 1 )
      {
         printPreviewControl.StartPage += 1;
         printPreviewControl.Invalidate();
         UpdatePageLabel();
      }
   }

   /// <summary>
   /// Update page Y of Z label.
   /// </summary>
   private void UpdatePageLabel()
   {
      toolStripTextBoxPage.Text = string.Format( "{0}", (printPreviewControl.StartPage + 1).ToString(), _TotalNumberOfPages.ToString() );

      // Update next/prev buttons at the same time
      toolStripButtonPrev.Enabled = (printPreviewControl.StartPage > 0);
      toolStripButtonNext.Enabled = (printPreviewControl.StartPage < _TotalNumberOfPages - 1);
   }

   private void printToolStripButton_Click( object sender, EventArgs e )
   {
      PrintDialog printDlg = new PrintDialog();
      printDlg.Document = printPreviewControl.Document;
      printDlg.AllowCurrentPage = false;
      printDlg.AllowSelection = false;
      printDlg.AllowSomePages = true;
      printDlg.UseEXDialog = true;

      if( DialogResult.OK == printDlg.ShowDialog() )
      {
         printPreviewControl.Document.PrinterSettings = printDlg.PrinterSettings;
         printPreviewControl.Document.Print();
      }
   }

   private void PrintPreview_Load( object sender, EventArgs e )
   {
      if ( String.IsNullOrEmpty( _IniFileName ) ) Basics.ReadFormPos( _IniFileName, this );

      UpdatePageLabel();
   }

   private void PrintPreview_FormClosing( object sender, FormClosingEventArgs e )
   {
      if( String.IsNullOrEmpty( _IniFileName ) ) Basics.WriteFormPos( _IniFileName, this );
   }

   private void toolStripButtonPageSetup_Click( object sender, EventArgs e )
   {
      PageSetupDialog pageSetupDialog = new PageSetupDialog();
      pageSetupDialog.AllowOrientation = false;
      pageSetupDialog.EnableMetric = true;

      pageSetupDialog.PageSettings = printPreviewControl.Document.DefaultPageSettings;

      pageSetupDialog.Document = printPreviewControl.Document;

      if( pageSetupDialog.ShowDialog() == DialogResult.OK )
      {
         System.Drawing.Printing.PrintDocument printDocument = printPreviewControl.Document;

         printPreviewControl.Dispose();
         printPreviewControl = null;

         printPreviewControl = new PrintPreviewControl();
         Controls.Add( printPreviewControl );

         printPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
         printPreviewControl.Location = new System.Drawing.Point( 0, 25 );
         printPreviewControl.UseAntiAlias = true;
         printPreviewControl.BringToFront();

         printPreviewControl.Document = printDocument;
      };
   }
}
