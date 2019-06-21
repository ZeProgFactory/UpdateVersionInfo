using EnvDTE;
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
            var commandId = new CommandID(PackageGuids.guidLittleHelpersCmdSet, PackageIds.CmdID_DiffFiles);
            var command = new OleMenuCommand(CommandCallback_DiffFiles, commandId);
            commandService.AddCommand(command);
         };

         {
            var commandId = new CommandID(PackageGuids.guidLittleHelpersCmdSet, PackageIds.CmdID_ProjectTool);
            var command = new OleMenuCommand(CommandCallback_ProjectTool, commandId);
            commandService.AddCommand(command);
         };

         {
            var commandId = new CommandID(PackageGuids.guidLittleHelpersCmdSet, PackageIds.CmdID_TOF);
            var command = new OleMenuCommand(CommandCallback_TOF, commandId);
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

      private void CommandCallback_DiffFiles(object sender, EventArgs e)
      {
         DiffFiles.DoIt(_dte);
      }

      private void CommandCallback_ProjectTool(object sender, EventArgs e)
      {
         var dialog = new ProjectToolDlg(_dte);
         dialog.ShowDialog();
      }

      private void CommandCallback_TOF(object sender, EventArgs e)
      {
      }
   }
}
