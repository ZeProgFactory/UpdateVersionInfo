using System;
using System.Diagnostics;
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

         if (!MainViewModel.Current.Silent)
         {
            Console.WriteLine("");
            Console.WriteLine($"UpdateVersionInfo - V{MainViewModel.Current.UpdateVersionInfoVersion}");
            Console.WriteLine("");
         };

         if (ValidateCommandLine(commandLine))
         {
            if (MainViewModel.Current.Info)
            {
               string formatStr = (MainViewModel.Current.Verbose
                  ? "{0,6} {1,-10} - {2}"
                  : "{0,6} {1,-10}");
               
               
               foreach (var f in MainViewModel.Current.Files)
               {
                  switch (f.Name)
                  {
                     case "vi":
                        _VI_Helper.GetVersion(f.Target);

                        if (!MainViewModel.Current.Silent)
                        {
                           Console.WriteLine(formatStr, "", _VI_Helper.LastMessage, f.Target);
                        };
                        break;

                     case "UWP":
                        UWPHelper.GetVersion(f.Target);

                        if (!MainViewModel.Current.Silent)
                        {
                           Console.WriteLine(formatStr, "UWP", UWPHelper.LastMessage, f.Target);
                        };
                        break;

                     case "Droid":
                        DroidHelper.GetVersion(f.Target);

                        if (!MainViewModel.Current.Silent)
                        {
                           Console.WriteLine(formatStr, "Droid", DroidHelper.LastMessage, f.Target);
                        };
                        break;

                     case "WPF":
                        break;

                     case "iOS":
                        iOSHelper.GetVersion(f.Target);

                        if (!MainViewModel.Current.Silent)
                        {
                           Console.WriteLine(formatStr, "iOS", iOSHelper.LastMessage, f.Target);
                        };
                        break;

                     case "MacOS":
                        break;

                     case "Nuget":
                        NugetHelper.GetVersion(f.Target);

                        if (!MainViewModel.Current.Silent)
                        {
                           Console.WriteLine(formatStr, "Nuget", NugetHelper.LastMessage, f.Target);
                        };
                        break;
                  };
               };
            }
            else
            {
               string formatStr = (MainViewModel.Current.Verbose
                  ? "{0,6} {1,-24} - {2}"
                  : "{0,6} {1,-24}");


               try
               {
                  Version version = new Version(
                      MainViewModel.Current.Major,
                      MainViewModel.Current.Minor,
                      MainViewModel.Current.Build.Value,
                      MainViewModel.Current.Revision.HasValue ? MainViewModel.Current.Revision.Value : 0);

                  foreach (var f in MainViewModel.Current.Files)
                  {
                     switch (f.Name)
                     {
                        case "vi":
                           version = _VI_Helper.Update(f.Target);
                           if (!MainViewModel.Current.Silent)
                           {
                              Console.WriteLine(formatStr, "", _VI_Helper.LastMessage, f.Target);
                           };
                           break;

                        case "UWP":
                           UWPHelper.Update(f.Target, version);
                           if (!MainViewModel.Current.Silent)
                           {
                              Console.WriteLine(formatStr, "UWP", UWPHelper.LastMessage, f.Target);
                           };

                           //if (MainViewModel.Current.AutoVersion)
                           //{
                           //   version = new Version(MainViewModel.Current.sAutoVersionV2);
                           //};
                           break;

                        case "Droid":
                           DroidHelper.Update(f.Target, version);

                           if (!MainViewModel.Current.Silent)
                           {
                              Console.WriteLine(formatStr, "Droid", DroidHelper.LastMessage, f.Target);
                           };
                           break;

                        case "WPF":
                           break;

                        case "iOS":
                           iOSHelper.Update(f.Target, version);

                           if (!MainViewModel.Current.Silent)
                           {
                              Console.WriteLine(formatStr, "iOS", iOSHelper.LastMessage, f.Target);
                           };
                           break;

                        case "MacOS":
                           break;

                        case "Nuget":
                           NugetHelper.Update(f.Target, version);

                           if (!MainViewModel.Current.Silent)
                           {
                              Console.WriteLine(formatStr, "Nuget", NugetHelper.LastMessage, f.Target);
                           };
                           break;
                     };
                  };

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

         if (!MainViewModel.Current.ScanFiles)
         {
            if (!String.IsNullOrEmpty(MainViewModel.Current.VersionCsPath) && !UWPHelper.IsValid(MainViewModel.Current.VersionCsPath))
            {
               errors.AppendLine("You must supply valid path to a writable C# file containing assembly version information.");
            };

            if (!String.IsNullOrEmpty(MainViewModel.Current.AndroidManifestPath) && !DroidHelper.IsValid(MainViewModel.Current.AndroidManifestPath))
            {
               errors.AppendLine("You must supply valid path to a writable android manifest file.");
            };

            if (!String.IsNullOrEmpty(MainViewModel.Current.TouchPListPath) && !iOSHelper.IsValid(MainViewModel.Current.TouchPListPath))
            {
               errors.AppendLine("You must supply valid path to a writable plist file containing version information.");
            };
         };

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
