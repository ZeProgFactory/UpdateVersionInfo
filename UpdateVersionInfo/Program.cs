﻿using System;
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
            if (!MainViewModel.Current.Silent)
            {
               Console.WriteLine("");
               Console.WriteLine($"UpdateVersionInfo - V{MainViewModel.Current.UpdateVersionInfoVersion}");
               Console.WriteLine("");
            };

            if (MainViewModel.Current.Info)
            {
               if (!String.IsNullOrEmpty(MainViewModel.Current.VersionCsPath) && MainViewModel.Current.VersionCsPath.ToLower() != "scan")
               {
                  UWPHelper.GetVersion(MainViewModel.Current.VersionCsPath);

                  if (!MainViewModel.Current.Silent)
                  {
                     Console.WriteLine($"UWP   {UWPHelper.LastMessage}");
                  };
               }

               if (!String.IsNullOrEmpty(MainViewModel.Current.AndroidManifestPath))
               {
                  DroidHelper.GetVersion(MainViewModel.Current.AndroidManifestPath);

                  if (!MainViewModel.Current.Silent)
                  {
                     Console.WriteLine($"Droid {DroidHelper.LastMessage}");
                  };
               }

               if (!String.IsNullOrEmpty(MainViewModel.Current.TouchPListPath))
               {
                  iOSHelper.GetVersion(MainViewModel.Current.TouchPListPath);

                  if (!MainViewModel.Current.Silent)
                  {
                     Console.WriteLine($"iOS   {iOSHelper.LastMessage}");
                  };
               }

               if (!String.IsNullOrEmpty(MainViewModel.Current.nuspecPath))
               {
                  NugetHelper.GetVersion(MainViewModel.Current.nuspecPath);

                  if (!MainViewModel.Current.Silent)
                  {
                     Console.WriteLine($"Nuget {NugetHelper.LastMessage}");
                  };
               }
            }
            else
            {
               try
               {
                  Version version = new Version(
                      MainViewModel.Current.Major,
                      MainViewModel.Current.Minor,
                      MainViewModel.Current.Build.Value,
                      MainViewModel.Current.Revision.HasValue ? MainViewModel.Current.Revision.Value : 0);

                  if (MainViewModel.Current.VersionCsPath.ToLower() != "scan")
                  {
                     UWPHelper.Update(MainViewModel.Current.VersionCsPath, version);
                     if (!MainViewModel.Current.Silent)
                     {
                        Console.WriteLine($"UWP   {UWPHelper.LastMessage}");
                     };

                     if (MainViewModel.Current.AutoVersion)
                     {
                        version = new Version(MainViewModel.Current.sAutoVersionV2);
                     };
                  }
                  else
                  {
                     if (MainViewModel.Current.AutoVersion)
                     {
                        version = null;
                     };
                  };

                  if (!String.IsNullOrEmpty(MainViewModel.Current.AndroidManifestPath))
                  {
                     DroidHelper.Update(MainViewModel.Current.AndroidManifestPath, version);

                     if (!MainViewModel.Current.Silent)
                     {
                        Console.WriteLine($"Droid {DroidHelper.LastMessage}");
                     };
                  }

                  if (!String.IsNullOrEmpty(MainViewModel.Current.TouchPListPath))
                  {
                     iOSHelper.Update(MainViewModel.Current.TouchPListPath, version);

                     if (!MainViewModel.Current.Silent)
                     {
                        Console.WriteLine($"iOS   {iOSHelper.LastMessage}");
                     };
                  }

                  if (!String.IsNullOrEmpty(MainViewModel.Current.nuspecPath))
                  {
                     NugetHelper.Update(MainViewModel.Current.nuspecPath, version);

                     if (!MainViewModel.Current.Silent)
                     {
                        Console.WriteLine($"Nuget {NugetHelper.LastMessage}");
                     };
                  }
               }
               catch (Exception e)
               {
                  WriteHelp(commandLine, "An unexpected error was encountered:" + e.Message);
               }
            };

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

         if (!MainViewModel.Current.Build.HasValue && !MainViewModel.Current.Info)
         {
            errors.AppendLine("You must supply a numeric build number.");
         }

         if (String.IsNullOrEmpty(MainViewModel.Current.VersionCsPath) || !UWPHelper.IsValid(MainViewModel.Current.VersionCsPath))
         {
            if (!MainViewModel.Current.Info && !MainViewModel.Current.ScanFiles)
            {
               errors.AppendLine("You must supply valid path to a writable C# file containing assembly version information.");
            };
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
         Console.WriteLine("");
         Console.WriteLine($"UpdateVersionInfo - V{MainViewModel.Current.UpdateVersionInfoVersion}");
         Console.WriteLine("");


         if (!String.IsNullOrEmpty(message))
         {
            Console.WriteLine(message);
         }

         commandLine.WriteHelp(Console.Out);
      }
   }
}
