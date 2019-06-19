﻿using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace LittleHelpers
{
   internal sealed class LittleHelpersCommand
   {
      private readonly DTE2 _dte;

      private LittleHelpersCommand(OleMenuCommandService commandService, DTE2 dte)
      {
         _dte = dte;

         {
            var commandId = new CommandID(PackageGuids.guidLittleHelpersCmdSet, PackageIds.LittleHelpersCommandId);
            var command = new OleMenuCommand(CommandCallback, commandId);
            commandService.AddCommand(command);
         };
      }

      public static LittleHelpersCommand Instance { get; private set; }

      public static async Task InitializeAsync(AsyncPackage package)
      {
         var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
         var dte = await package.GetServiceAsync(typeof(DTE)) as DTE2;
         Instance = new LittleHelpersCommand(commandService, dte);
      }

      private void CommandCallback(object sender, EventArgs e)
      {

         if (CanFilesBeCompared(out string file1, out string file2))
         {
            if (!DiffFileUsingCustomTool(file1, file2))
            {
               LittleHelpersUsingDefaultTool(file1, file2);
            }
         }
      }

      private void LittleHelpersUsingDefaultTool(string file1, string file2)
      {
         // This is the guid and id for the Tools.LittleHelpers command
         string diffFilesCmd = "{5D4C0442-C0A2-4BE8-9B4D-AB1C28450942}";
         int diffFilesId = 256;
         object args = $"\"{file1}\" \"{file2}\"";

         _dte.Commands.Raise(diffFilesCmd, diffFilesId, ref args, ref args);
      }

      //Visual Studio allows replacing the default diff tool with a custom one.
      //See, for example:
      //Using WinMerge: https://blog.paulbouwer.com/2010/01/31/replace-diffmerge-tool-in-visual-studio-team-system-with-winmerge/
      //Using BeyondCompare: http://stackoverflow.com/questions/4466238/how-to-configure-visual-studio-to-use-beyond-compare
      private bool DiffFileUsingCustomTool(string file1, string file2)
      {
         try
         {
            //Checking the registry to see if a custom tool is configured
            //Relevant information: https://social.msdn.microsoft.com/Forums/vstudio/en-US/37a26013-2f78-4519-85e5-d896ac27f31e/see-what-default-visual-studio-tfexe-compare-tool-is-set-to-using-visual-studio-api?forum=vsx
            string registryFolder = $"{_dte.RegistryRoot}\\TeamFoundation\\SourceControl\\DiffTools\\.*\\Compare";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryFolder))
            {
               string command = key?.GetValue("Command") as string;
               if (string.IsNullOrEmpty(command)) return false;

               string args = key.GetValue("Arguments") as string;
               if (string.IsNullOrEmpty(args)) return false;

               //Understanding the arguments: https://msdn.microsoft.com/en-us/library/ms181446(v=vs.100).aspx
               args =
                   args.Replace("%1", $"\"{file1}\"")
                       .Replace("%2", $"\"{file2}\"")
                       .Replace("%5", string.Empty)
                       .Replace("%6", $"\"{file1}\"")
                       .Replace("%7", $"\"{file2}\"");
               System.Diagnostics.Process.Start(command, args);
            }
            return true;
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Write(ex);
            return false;
         }
      }

      private bool CanFilesBeCompared(out string file1, out string file2)
      {
         IEnumerable<string> items = GetSelectedFiles();

         file1 = items.ElementAtOrDefault(0);
         file2 = items.ElementAtOrDefault(1);

         if (items.Count() == 1)
         {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = Path.GetDirectoryName(file1);
            dialog.ShowDialog();

            file2 = dialog.FileName;
         }

         return !string.IsNullOrEmpty(file1) && !string.IsNullOrEmpty(file2);
      }

      public IEnumerable<string> GetSelectedFiles()
      {
         var items = (Array)_dte.ToolWindows.SolutionExplorer.SelectedItems;

         return from item in items.Cast<UIHierarchyItem>()
                let pi = item.Object as ProjectItem
                select pi.FileNames[1];
      }
   }
}
