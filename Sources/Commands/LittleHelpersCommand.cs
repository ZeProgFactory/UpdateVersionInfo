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
            var commandId = new CommandID(PackageGuids.guidLittleHelpersCmdSet, PackageIds.CmdID_IconFactory);
            var command = new OleMenuCommand(CommandCallback_IconFactory, commandId);
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
      
      private void CommandCallback_IconFactory(object sender, EventArgs e)
      {
         var dialog = new IconFactory.MainWindow();
         dialog.ShowDialog();
      }

      private void CommandCallback_TOF(object sender, EventArgs e)
      {
         // https://www.visualstudiogeeks.com/extensibility/visual%20studio/options-for-displaying-modal-dialogs-in-visual-studio-extensions
         // https://docs.microsoft.com/en-us/visualstudio/extensibility/creating-and-managing-modal-dialog-boxes?view=vs-2019

         var xamlDialog = new XamlDialogInVSExtensionDemo.XamlDialog("Microsoft.VisualStudio.PlatformUI.DialogWindow");
         xamlDialog.HasMinimizeButton = false;
         xamlDialog.HasMaximizeButton = false;
         // xamlDialog.ShowModal();

         //IVsUIShell uiShell = (IVsUIShell)ServiceProvider.GetService(typeof(SVsUIShell));

         //TestDialogWindow2 xamlDialog = new TestDialogWindow2(uiShell);
         //get the owner of this dialog
         //IntPtr hwnd;
         //uiShell.GetDialogOwnerHwnd(out hwnd);
         xamlDialog.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
         //uiShell.EnableModeless(0);
         try
         {
            //Microsoft.Internal.VisualStudio.PlatformUI.WindowHelper.ShowModal(xamlDialog, hwnd);
            Microsoft.Internal.VisualStudio.PlatformUI.WindowHelper.ShowModal(xamlDialog);
         }
         finally
         {
            // This will take place after the window is closed.
            //uiShell.EnableModeless(1);
         }
      }
   }
}
