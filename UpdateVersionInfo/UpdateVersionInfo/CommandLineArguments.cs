using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;
using UpdateVersionInfo.Core;

namespace UpdateVersionInfo
{
   public class CommandLineArguments
   {
      private readonly OptionSet _options;

      private OptionSet Initialize()
      {
         MainViewModel.Current.AutoVersion = false;

         var options = new OptionSet {
                {
                    "?", "Shows help/usage information.", h => MainViewModel.Current.ShowHelp = true
                },
                {
                    "s", "silent/verbus", s => MainViewModel.Current.Silent = true
                },
                {
                    "i", "Displays current version info", i => MainViewModel.Current.Info = true
                },
                {
                    "v|major=", "A numeric major version number greater than zero.", (int v) => MainViewModel.Current.Major = v
                },
                {
                    "m|minor=", "A numeric minor number greater than zero.", (int v) => MainViewModel.Current.Minor = v
                },
                {
                    "b|build=", "A numeric build number greater than zero.", (int v) => MainViewModel.Current.Build = v
                },
                {
                    "r|revision=", "A numeric revision number greater than zero.", (int v) => MainViewModel.Current.Revision = v
                },
                {
                    "p|path=", "The path to a C# file to update with version information.", p => MainViewModel.Current.VersionCsPath = p
                },
                {
                    "a|androidManifest=", "The path to an android manifest file to update with version information.", p => MainViewModel.Current.AndroidManifestPath = p
                },
                {
                    "t|touchPlist=", "The path to an iOS plist file to update with version information.", p => MainViewModel.Current.TouchPListPath = p
                }
            };

         return options;
      }

      public CommandLineArguments(IEnumerable<String> args)
      {
         MainViewModel.Current.Major = 1;
         MainViewModel.Current.Minor = 0;
         _options = Initialize();

         // - - -  - - - 

         List<string> _args = args.ToList();
         List<string> _args2 = args.ToList();

         foreach (var st in _args)
         {
            if (st.ToLower().StartsWith("-v") && st.Contains("."))
            {
               var a = st.Split(new char[] { '=', '.' });

               if (a.Length == 5)
               {
                  _args2[_args2.IndexOf(st)] = "-v=" + a[1];

                  _args2.Add("-m=" + a[2]);
                  _args2.Add("-b=" + a[3]);
                  _args2.Add("-r=" + a[4]);
               };
            };

            if (st.ToLower().StartsWith("-v") && st.ToLower().Contains("auto"))
            {
               MainViewModel.Current.AutoVersion = true;

               _args2[_args2.IndexOf(st)] = "-v=1";

               _args2.Add("-m=0");
               _args2.Add("-b=0");
               _args2.Add("-r=0");
            };

            if (st.ToLower().StartsWith("-p") && (st.ToLower().Contains("scan") || st.ToLower().Contains("auto")))
            {
               MainViewModel.Current.ScanFiles = true;

               var allFiles = System.IO.Directory.EnumerateFiles(System.IO.Directory.GetCurrentDirectory(), "*.*", System.IO.SearchOption.AllDirectories);

               var files = allFiles.Where(x => x.ToLower().Contains(@"\properties\") || x.ToLower().EndsWith(@"\info.plist")).ToList();

               foreach (var f in files)
               {
                  if (UWPHelper.IsValid(f))
                  {
                     if (System.IO.Directory.EnumerateFiles(System.IO.Path.GetDirectoryName(f), "Default.rd.xml", System.IO.SearchOption.TopDirectoryOnly).Count() == 1)
                     {
                        MainViewModel.Current.VersionCsPath = f;
                        _args2[_args2.IndexOf(st)] = $"-p={f}";
                     };
                  };

                  if (DroidHelper.IsValid(f))
                  {
                     if (System.IO.Directory.EnumerateFiles(System.IO.Path.GetDirectoryName(f), "AndroidManifest.xml", System.IO.SearchOption.TopDirectoryOnly).Count() == 1)
                     {
                        MainViewModel.Current.AndroidManifestPath = f;
                     };
                  };

                  //if (WPFHelper.IsValid(f))
                  //{
                  //if (System.IO.Directory.EnumerateFiles(System.IO.Path.GetDirectoryName(f), "Settings.settings", System.IO.SearchOption.TopDirectoryOnly).Count() == 1)
                  //{
                  //   MainViewModel.Current.WPFAssemblyInfoPath = f;
                  //};
                  //};

                  if (iOSHelper.IsValid(f))
                  {
                     if (System.IO.File.ReadAllText(f).ToLower().Contains("minimumosversion"))
                     {
                        MainViewModel.Current.TouchPListPath = f;
                     };
                  };

                  //if (MacHelper.IsValid(f))
                  //{
                  //   if (System.IO.File.ReadAllText(f).ToLower().Contains("lsminimumsystemversion"))
                  //   {
                  //      MainViewModel.Current.MacPListPath = f;
                  //   };
                  //};
               };
            };
         };

         // - - -  - - - 

         _options.Parse(_args2);
      }

      public void WriteHelp(System.IO.TextWriter writer)
      {
         _options.WriteOptionDescriptions(writer);
      }
   }
}
