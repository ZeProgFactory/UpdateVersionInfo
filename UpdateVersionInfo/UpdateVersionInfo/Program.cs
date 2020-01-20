using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using UpdateVersionInfo.Core;

namespace UpdateVersionInfo
{
   // https://github.com/soltechinc/soltechxf/
   // http://stackoverflow.com/questions/27058172/xamarin-mobile-app-version-number-scheme-across-3-platforms

   internal class Program
   {
      static CommandLineArguments commandLine = null;

      static void Main(string[] args)
      {
         commandLine = new CommandLineArguments(args);

         if (ValidateCommandLine(commandLine))
         {
            try
            {
               Version version = new Version(
                   MainViewModel.Current.Major,
                   MainViewModel.Current.Minor,
                   MainViewModel.Current.Build.Value,
                   MainViewModel.Current.Revision.HasValue ? MainViewModel.Current.Revision.Value : 0);

               UWPHelper.Update(MainViewModel.Current.VersionCsPath, version);

               if (!String.IsNullOrEmpty(MainViewModel.Current.AndroidManifestPath))
               {
                  DroidHelper.Update(MainViewModel.Current.AndroidManifestPath, version);
               }

               if (!String.IsNullOrEmpty(MainViewModel.Current.TouchPListPath))
               {
                  iOSHelper.Update(MainViewModel.Current.TouchPListPath, version);
               }
            }
            catch (Exception e)
            {
               WriteHelp(commandLine, "An unexpected error was encountered:" + e.Message);
            }
         };

         if (Debugger.IsAttached)
         {
            Console.Read();
         };
      }

      private static bool ValidateCommandLine(CommandLineArguments commandLine)
      {
         if (MainViewModel.Current.ShowHelp)
         {
            WriteHelp(commandLine);
            return true;
         }

         var errors = new System.Text.StringBuilder();
         if (MainViewModel.Current.Major < 0)
         {
            errors.AppendLine("You must supply a positive major version number.");
         }

         if (MainViewModel.Current.Minor < 0)
         {
            errors.AppendLine("You must supply a positive minor version number.");
         }

         if (!MainViewModel.Current.Build.HasValue)
         {
            errors.AppendLine("You must supply a numeric build number.");
         }

         if (String.IsNullOrEmpty(MainViewModel.Current.VersionCsPath) || ! UWPHelper.IsValid(MainViewModel.Current.VersionCsPath))
         {
            errors.AppendLine("You must supply valid path to a writable C# file containing assembly version information.");
         }

         if (!String.IsNullOrEmpty(MainViewModel.Current.AndroidManifestPath) && !DroidHelper.IsValid(MainViewModel.Current.AndroidManifestPath))
         {
            errors.AppendLine("You must supply valid path to a writable android manifest file.");
         }

         if (!String.IsNullOrEmpty(MainViewModel.Current.TouchPListPath) && !iOSHelper.IsValid(MainViewModel.Current.TouchPListPath))
         {
            errors.AppendLine("You must supply valid path to a writable plist file containing version information.");
         }

         if (errors.Length > 0)
         {
            WriteHelp(commandLine, "Invalid command line:\n" + errors.ToString());
         }

         return errors.Length == 0;
      }

      private static void WriteHelp(CommandLineArguments commandLine, String message = null)
      {
         if (!String.IsNullOrEmpty(message))
         {
            Console.WriteLine(message);
         }

         commandLine.WriteHelp(Console.Out);
      }
   }
}
