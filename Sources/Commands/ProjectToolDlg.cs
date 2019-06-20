using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LittleHelpers
{
   public partial class ProjectToolDlg : Form
   {
      private static DTE2 _dte;

      public ProjectToolDlg(DTE2 dte)
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

            //if (item.Object is EnvDTE.Solution)
            //{
            //   var s = item.Object as Solution;
            //   var fn = s.FileName;

            //}
         };

         tbSolution.Text = sName;
         lbSolution.Text = sFName;

         tbProject.Text = pName;
         lbProject.Text = pFName;

         ProjectTool.DoIt();
      }
   }
}
