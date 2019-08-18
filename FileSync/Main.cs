using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZPF;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Diagnostics;

//Todo: Icon
//ToDo: ExamDiff Pro: http://www.prestosoft.com/ps.asp?page=edp_screenshots

namespace FileSync
{
   public partial class wMain : Form
   {
      TStrings Lines = new TStrings();

      static string FileName1 = "";
      TStrings File1 = new TStrings();
      bool File1Modified = false;

      static string FileName2 = "";
      TStrings File2 = new TStrings();
      bool File2Modified = false;

      public wMain(string[] args)
      {
         if (args.Length == 2)
         {
            FileName1 = args[0];
            FileName2 = args[1];
         };

         InitializeComponent();
      }

      private void wMain_Load(object sender, EventArgs e)
      {
         DataModul.GetInstance().InitDataModul("FileSync");
         DataModul.GetInstance().LoadConfig();

         Basics.ReadFormPos(DataModul.GetInstance().IniFileName, this);

         lineNumbersToolStripMenuItem.SelectedIndex = DataModul.GetInstance().LineNumbers;
         blackWhiteToolStripMenuItem.Checked = DataModul.GetInstance().BlackWhite;
         reloadFilesToolStripMenuItem.Checked = DataModul.GetInstance().ReloadFiles;

         //ToDo: Options 

         //
         // - - -  - - - 

         listBox.Items[0] = "";
         listBox.Items[1] = "";

         wMain_Resize(sender, e);

         //
         // - - -  - - - 

         if (System.IO.File.Exists(FileName1)
            && System.IO.File.Exists(FileName2))
         {
         }
         else
         {
            FileName1 = DataModul.GetInstance().FileName1;
            FileName2 = DataModul.GetInstance().FileName2;

            //FileName1 = @"D:\Software\V9.00\Projets\Kiosk\Sources.CF1\Kiosk.ini";
            //FileName2 = @"E:\Software\___\Projets\Kiosk\Sources.CF1\Kiosk.ini";

            //FileName1 = @"L:\CESetup\BuildTimeStamp.cs";
            //FileName2 = @"L:\CESetup.CE\BuildTimeStamp.cs";
         };

         if (reloadFilesToolStripMenuItem.Checked)
         {
            LoadFiles();
         }
         else
         {
         };

         //
         // - - -  - - - 

         CompareFiles.Exec(Lines, File1, File2);

         //
         // - - -  - - - 

         DisplayCompareFiles();

         // PatchListView( listView );
      }

      //protected override void OnHandleCreated( EventArgs e )
      protected void PatchListView(ListView listView)
      {
         // In order to receive the WM_DRAWITEM message, the ListView common control
         // must have the following styles:
         //#define LVS_OWNERDRAWFIXED      0x0400
         //#define LVS_REPORT              0x0001
         //#define GWL_STYLE           (-16)
         int lStyle = Win32.GetWindowLong(listView.Handle, -16);
         lStyle |= (0x0400 | 0x0001);
         long lRet = Win32.SetWindowLong(listView.Handle, -16, lStyle);
      }

      private void LoadFiles()
      {
         Lines.Clear();

         // File1.LoadFromFile( FileName1, System.Text.Encoding.Unicode );
         File1.LoadFromFile(FileName1);
         for (int i = 0; i < File1.Count; i++)
         {
            File1.SetObject(i, (int)i + 1);
         };

         // File2.LoadFromFile( FileName2, System.Text.Encoding.Unicode );
         File2.LoadFromFile(FileName2);
         for (int i = 0; i < File2.Count; i++)
         {
            File2.SetObject(i, (int)i + 1);
         };

         columnHeaderFile1.Text = FileName1;
         columnHeaderFile2.Text = FileName2;

         File1Modified = false;
         File2Modified = false;
      }

      private void DisplayCompareFiles()
      {
         listView.OwnerDraw = !blackWhiteToolStripMenuItem.Checked;

         listView.Items.Clear();
         for (int i = 0; i < Lines.Count; i++)
         {
            ListViewItem lvi = listView.Items.Add("");

            try
            {
               if (Lines[i] == " ") lvi.ImageIndex = 0;
               if (Lines[i] == "=") lvi.ImageIndex = 0;
               if (Lines[i] == "<") lvi.ImageIndex = 1;
               if (Lines[i] == ">") lvi.ImageIndex = 2;
               if (Lines[i] == "#") lvi.ImageIndex = 3;
            }
            catch { };

            lvi.SubItems.Add("");
            DisplayCompareFilesLineNo(lvi, i);

            ListViewItem.ListViewSubItem SubItem;

            if (i < File1.Count)
            {
               SubItem = lvi.SubItems.Add(File1[i]);
               SubItem.Tag = File1.GetObject(i);
            }
            else
            {
               SubItem = lvi.SubItems.Add("");
               //SubItem.Tag = File1.GetObject( i );
               lvi.ImageIndex = 2;
            };

            if (i < File2.Count)
            {
               SubItem = lvi.SubItems.Add(File2[i]);
               SubItem.Tag = File2.GetObject(i);
            }
            else
            {
               SubItem = lvi.SubItems.Add("");
               //SubItem.Tag = File1.GetObject( i );
               lvi.ImageIndex = 1;
            };
         };
      }

      private void DisplayCompareFilesLineNo(ListViewItem lvi, int i)
      {
         switch (lineNumbersToolStripMenuItem.SelectedIndex)
         {
            case 1:
               {
                  if (File1.GetObject(i) != null)
                  {
                     lvi.SubItems[1].Text = ((int)File1.GetObject(i)).ToString();
                  }
                  else
                  {
                     lvi.SubItems[1].Text = "";
                  };
                  break;
               }
            case 2:
               {
                  if (File2.GetObject(i) != null)
                  {
                     lvi.SubItems[1].Text = ((int)File2.GetObject(i)).ToString();
                  }
                  else
                  {
                     lvi.SubItems[1].Text = "";
                  };
                  break;
               }
            default:
               {
                  lvi.SubItems[1].Text = (i + 1).ToString();
                  break;
               }
         };
      }

      private void wMain_Resize(object sender, EventArgs e)
      {
         columnHeaderFile1.Width = (listView.ClientSize.Width - columnHeaderLines.Width) / 2;
         columnHeaderFile2.Width = columnHeaderFile1.Width;
      }

      private void listView_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (listView.SelectedIndices.Count == 1)
         {
            int Ind = listView.SelectedIndices[0];

            listBox.Items[0] = listView.Items[Ind].SubItems[2].Text;
            listBox.Items[1] = listView.Items[Ind].SubItems[3].Text;

            toolStripMenuItemPrev.Enabled = (FindPrev(Ind) != Ind);
            toolStripMenuItemNext.Enabled = (FindNext(Ind) != Ind);
         };
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void editToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (sender == editLeftToolStripMenuItem)
         {
            wNotePadDlg.Exec(FileName1);
         }
         else
         {
            wNotePadDlg.Exec(FileName2);
         };
      }

      private void changeFilesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SelectFiles dlg = new SelectFiles();

         dlg.comboBoxFile1.Text = FileName1;
         dlg.comboBoxFile2.Text = FileName2;

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            FileName1 = dlg.comboBoxFile1.Text;
            FileName2 = dlg.comboBoxFile2.Text;

            reloadToolStripMenuItem_Click(sender, e);
         };
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //ToDO: About.Execute( DataModul.GetInstance().Version );
      }

      private void helpOnWebToolStripMenuItem_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start("IExplore", "http://www.zepocketforge.com/Wiki/Default.aspx?No=177");
      }

      private void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
      {
         if ((e.State & ListViewItemStates.Selected) != 0)
         {
            // Draw the background and focus rectangle for a selected item.
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
            e.DrawFocusRectangle();
         }
         else
         {
            switch (e.Item.ImageIndex)
            {
               case 1:
                  {
                     // Draw the background and focus rectangle for a selected item.
                     e.Graphics.FillRectangle(Brushes.LightCoral, e.Bounds);
                     e.Item.Tag = null; // Bugfix: --> Refresh text
                     break;
                  };
            };
         };

         e.Graphics.DrawImage(listView.SmallImageList.Images[e.Item.ImageIndex], new Point(e.Bounds.X + 3, e.Bounds.Y));
      }

      private void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
      {
         e.DrawText();
      }

      private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
      {
         e.DrawDefault = true;
      }

      // Forces each row to repaint itself the first time the mouse moves over 
      // it, compensating for an extra DrawItem event sent by the wrapped Win32 control.
      private void listView_MouseMove(object sender, MouseEventArgs e)
      {
         ListViewItem item = listView.GetItemAt(e.X, e.Y);

         if (item != null && item.Tag == null)
         {
            listView.Invalidate(item.Bounds);
            item.Tag = true;
         }
      }

      private void wMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         DataModul.GetInstance().LineNumbers = lineNumbersToolStripMenuItem.SelectedIndex;
         DataModul.GetInstance().BlackWhite = blackWhiteToolStripMenuItem.Checked;
         DataModul.GetInstance().ReloadFiles = reloadFilesToolStripMenuItem.Checked;
         DataModul.GetInstance().FileName1 = FileName1;
         DataModul.GetInstance().FileName2 = FileName2;


         DataModul.GetInstance().SaveConfig();

         Basics.WriteFormPos(DataModul.GetInstance().IniFileName, this);
      }

      private void lineNumbersToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
      {
         viewToolStripMenuItem.HideDropDown();

         for (int i = 0; i < File1.Count; i++)
         {
            ListViewItem lvi = listView.Items[i];
            DisplayCompareFilesLineNo(lvi, i);
         };

         listView.Refresh();
      }

      private void blackWhiteToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
      {
         DisplayCompareFiles();
      }

      private void toolStripMenuItemPrev_Click(object sender, EventArgs e)
      {
         int Ind = listView.FocusedItem.Index;

         Ind = FindPrev(Ind);

         listView.FocusedItem = listView.Items[Ind];
         listView.SelectedItems.Clear();
         listView.Items[Ind].Selected = true;

         Ind -= 5;
         if (Ind < 0) Ind = 0;

         listView.TopItem = listView.Items[Ind];
      }

      private int FindPrev(int Ind)
      {
         int Old = Ind;

         while ((listView.Items[Ind].ImageIndex != 0) && (Ind > 0))
         {
            Ind -= 1;
         };

         while ((listView.Items[Ind].ImageIndex == 0) && (Ind > 0))
         {
            Ind -= 1;
         };

         if (listView.Items[Ind].ImageIndex == 0)
         {
            Ind = Old;
         };

         return Ind;
      }

      private void toolStripMenuItemNext_Click(object sender, EventArgs e)
      {
         int Ind = listView.FocusedItem.Index;

         Ind = FindNext(Ind);

         listView.FocusedItem = listView.Items[Ind];
         listView.SelectedItems.Clear();
         listView.Items[Ind].Selected = true;

         Ind -= 5;
         if (Ind < 0) Ind = 0;

         listView.TopItem = listView.Items[Ind];
      }

      private int FindNext(int Ind)
      {
         int Old = Ind;

         while ((listView.Items[Ind].ImageIndex != 0) && (Ind + 1 < listView.Items.Count))
         {
            Ind += 1;
         };

         while ((listView.Items[Ind].ImageIndex == 0) && (Ind + 1 < listView.Items.Count))
         {
            Ind += 1;
         };

         if (listView.Items[Ind].ImageIndex == 0)
         {
            Ind = Old;
         };

         return Ind;
      }

      private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //   PrintListView plv = new PrintListView();
         //   plv.ListView = listView;
         //   plv.DocumentName = this.Text;
         //   plv.FitToPage = true;
         //   plv.Borders = false;

         //   PageSetupDialog pageSetupDialog = new PageSetupDialog();
         //   pageSetupDialog.PageSettings.Landscape = true;
         //   pageSetupDialog.AllowOrientation = true;

         //   pageSetupDialog.Document = plv;
         //   if( pageSetupDialog.ShowDialog() == DialogResult.OK )
         //   {
         //      plv.Print();
         //   };
      }

      private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //   // Speed Up Printing with the PrintPreviewDialog
         //   // http://www.codeproject.com/cs/miscctrl/SUPrintPreviewDialog.asp

         //   PrintListView plv = new PrintListView();
         //   plv.ListView = listView;
         //   plv.DocumentName = this.Text;
         //   plv.FitToPage = true;
         //   plv.Borders = false;

         //   //PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
         //   //printPreviewDialog.Document = plv;
         //   //printPreviewDialog.ShowDialog();

         //   PrintPreview dlg = new PrintPreview( DataModul.GetInstance().IniFileName );
         //   dlg.printPreviewControl.Document = plv;
         //   dlg.ShowDialog();
      }

      private void printToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //   PrintListView plv = new PrintListView();
         //   plv.ListView = listView;
         //   plv.DocumentName = this.Text;
         //   plv.FitToPage = true;
         //   plv.Borders = false;

         //   PrintDialog printDialog = new PrintDialog();
         //   printDialog.AllowSelection = true;

         //   printDialog.Document = plv;
         //   if( printDialog.ShowDialog() == DialogResult.OK )
         //   {
         //      plv.PrintSelectedItems = printDialog.PrinterSettings.PrintRange==PrintRange.Selection;
         //      plv.Print();
         //   };
      }

      private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // TStrings File = 

         if (File1Modified)
         {
            TStrings File = new TStrings();

            for (int i = 0; i < File1.Count; i++)
            {
               if (File1.GetObject(i) != null)
               {
                  File.Add(File1[i]);
               };
            };

            File.SaveToFile(FileName1, System.Text.Encoding.Unicode);
            File1Modified = false;
         };

         if (File2Modified)
         {
            TStrings File = new TStrings();

            for (int i = 0; i < File2.Count; i++)
            {
               if (File2.GetObject(i) != null)
               {
                  File.Add(File2[i]);
               };
            };

            File.SaveToFile(FileName2, System.Text.Encoding.Unicode);
            File2Modified = false;
         };
      }

      private void SubcopyLineLR(int Ind)
      {
         File2[Ind] = File1[Ind];
         listView.Items[Ind].SubItems[3].Text = File2[Ind];
         listView.Items[Ind].ImageIndex = 0;

         if (File2.GetObject(Ind) == null)
         {
            File2.SetObject(Ind, -1);
         };

         File2Modified = true;
      }

      private void copyLineLRToolStripMenuItem_Click(object sender, EventArgs e)
      {
         for (int i = 0; i < listView.SelectedIndices.Count; i++)
         {
            SubcopyLineLR(listView.SelectedIndices[i]);
         };
      }

      private void SubcopyLineRL(int Ind)
      {
         File1[Ind] = File2[Ind];
         listView.Items[Ind].SubItems[2].Text = File1[Ind];
         listView.Items[Ind].ImageIndex = 0;

         if (File1.GetObject(Ind) == null)
         {
            File1.SetObject(Ind, -1);
         };

         File1Modified = true;
      }

      private void copyLineRLToolStripMenuItem_Click(object sender, EventArgs e)
      {
         for (int i = 0; i < listView.SelectedIndices.Count; i++)
         {
            SubcopyLineRL(listView.SelectedIndices[i]);
         };
      }

      private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadFiles();
         Lines.Clear();
         CompareFiles.Exec(Lines, File1, File2);
         DisplayCompareFiles();
      }

      private void reloadFilesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //PrintListView plv = new PrintListView();
         //plv.ListView = listView;
         //plv.DocumentName = this.Text;
         //plv.FitToPage = true;
         //plv.Borders = false;

         //PageSetupDialog pageSetupDialog = new PageSetupDialog();
         //pageSetupDialog.PageSettings.Landscape = true;
         //pageSetupDialog.AllowOrientation = true;

         //pageSetupDialog.Document = plv;
         //if (pageSetupDialog.ShowDialog() == DialogResult.OK)
         //{
         //   plv.Print();
         //};
      }

      private void whatsNewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\History.txt");
      }
   }
}
