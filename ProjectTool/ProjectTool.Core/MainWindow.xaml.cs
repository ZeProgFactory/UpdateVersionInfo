using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EnvDTE;
using EnvDTE80;
using ZPF;

namespace ProjectTool
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : System.Windows.Window
   {
      public MainWindow()
      {
         InitializeComponent();

         spBtn.IsEnabled = false;
      }

      private static DTE2 _dte;

      public MainWindow(DTE2 dte)
      {
         _dte = dte;

         // - - -  - - - 

         InitializeComponent();

         // - - -  - - - 

         string sName = System.IO.Path.GetFileNameWithoutExtension(_dte.Solution.FullName);
         string sFName = _dte.Solution.FullName;

         string pName = "";
         string pFName = "";

         var items = (Array)_dte.ToolWindows.SolutionExplorer.SelectedItems;
         var item = items.Cast<UIHierarchyItem>().FirstOrDefault();

         if (item != null)
         {
            if (item.Object is ProjectItem)
            {
               var pi = item.Object as ProjectItem;
               var fn = pi.FileNames[1];

               pName = pi.ContainingProject.Name;
               pFName = pi.ContainingProject.FileName;
            }

            if (item.Object is EnvDTE.Project)
            {
               var p = item.Object as Project;

               pName = p.Name;
               pFName = p.FileName;
            }
         };

         // - - -  - - - 

         btnSolution.Visibility = Visibility.Collapsed;

         tbSolution.Text = sName;
         lbSolution.Content = sFName;

         tbProject.Text = pName;
         lbProject.Content = pFName;

         tbTargetProject.Text = sName + "-Copy";
         tbTargetFolder.Text = System.IO.Path.GetDirectoryName(sFName) + "-Copy";
      }

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

      private void TextChanged(object sender, TextChangedEventArgs e)
      {
         btnGoSol.IsEnabled =
            !string.IsNullOrEmpty(tbTargetProject.Text) && tbTargetProject.Text.Trim().Length > 3
            && !string.IsNullOrEmpty(tbTargetFolder.Text) && tbTargetFolder.Text.Trim().Length > 6;
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         spBtn.IsEnabled = false;

         tbTargetProject.Text = tbTargetProject.Text.Trim();
         tbTargetFolder.Text = tbTargetFolder.Text.Trim();

         try
         {
            if (!System.IO.Directory.Exists(tbTargetFolder.Text))
            {
               System.IO.Directory.CreateDirectory(tbTargetFolder.Text);
            };

            if (!System.IO.Directory.Exists(tbTargetFolder.Text))
            {
               MessageBox.Show($"Folder '{tbTargetFolder.Text}' doesn't exsist!");
               return;
            };

            ZPF.ProjectTool.DoIt(tbSolution.Text, System.IO.Path.GetDirectoryName((string)lbSolution.Content), tbTargetProject.Text.Trim(), tbTargetFolder.Text);
         }
         catch { };

         spBtn.IsEnabled = true;
      }

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

      private void BtnSolution_Click(object sender, RoutedEventArgs e)
      {
         var fileDialog = new System.Windows.Forms.OpenFileDialog();
         fileDialog.Title = this.Title;
         fileDialog.Filter = "Solutions (.sln)|*.sln";
         fileDialog.DefaultExt = ".sln";

         var result = fileDialog.ShowDialog();

         if (result == System.Windows.Forms.DialogResult.OK)
         {
            string sName = System.IO.Path.GetFileNameWithoutExtension(fileDialog.FileName);
            string sFName = fileDialog.FileName;

            string[] filePaths = Directory.GetFiles(System.IO.Path.GetDirectoryName(sFName), "*.csproj", SearchOption.AllDirectories);
            var p = filePaths.Where(x => x.Contains("\\" + sName + ".")).FirstOrDefault();

            string pName = (p != null ? sName : "");
            string pFName = (p != null ? p : "");

            tbSolution.Text = sName;
            lbSolution.Content = sFName;

            tbProject.Text = pName;
            lbProject.Content = pFName;

            tbTargetProject.Text = sName + "-Copy";
            tbTargetFolder.Text = System.IO.Path.GetDirectoryName(sFName) + "-Copy";

            spBtn.IsEnabled = true;
         };
      }

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

      private void btnClean_Click(object sender, RoutedEventArgs e)
      {
         spBtn.IsEnabled = false;

         string[] filePaths = Directory.GetFiles(System.IO.Path.GetDirectoryName((string)(lbSolution.Content)), "*.csproj", SearchOption.AllDirectories);
         bool DidIt = false;

         foreach (var p in filePaths)
         {
            var encoding = ZPF.ProjectTool.GetEncoding(p);
            DidIt = false;

            TStrings text = new TStrings();
            text.Text = File.ReadAllText(p);

            for (int i = 0; i < text.Count; i++)
            {
               var st = text[i].ToLower();
               var ind = st.IndexOf(@"\packages\");

               if (ind > 2)
               {
                  if (st[ind - 1] == '.' && st[ind - 2] == '.')
                  {

                  }
                  else
                  {
                     // KO
                     Debug.WriteLine(">>> " + text[i]);

                     int b = FindBegin(text[i], ind, "'>");

                     if (b > -1)
                     {
                        var searchPattern = text[i].Substring(b + 1, (ind - b) + (@"\packages\").Length - 1);
                        Debug.WriteLine("    " + searchPattern);

                        text[i] = text[i].Replace(searchPattern, @"..\packages\");
                        DidIt = true;
                     };
                  };
               };
            };

            if (DidIt) File.WriteAllText(p, text.Text, encoding);
         };

         //ToDo: Progressbar or other feedback on progress ...

         //if (DidIt)
         //{
         MessageBox.Show("Clean projects terminated.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
         //}
         //else
         //{
         //   MessageBox.Show("Nothing to do ...", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
         //};

         spBtn.IsEnabled = true;
      }

      private int FindBegin(string line, int ind, string seperators)
      {
         for (int i = ind; i > -1; i--)
         {
            try
            {
               if (seperators.Contains(line[i]))
               {
                  return i;
               };
            }
            catch
            {
               return -1;
            };
         }

         return -1;
      }

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 
   }
}
