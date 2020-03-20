using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;
using UpdateVersionInfo.Core;
using ZPF;

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
                    "v|major=", "auto | A numeric major version number greater than zero.", (int v) => MainViewModel.Current.Major = v
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
                    "vi=", "The path to a 'VersionInfo.cs' file to update with version information.",
                                 vi => MainViewModel.Current.Files.Add(new FileAndType { Name = "vi", Target = vi })
                },
                {
                    "p|path=", "scan | The path to a C# file to update with version information.",
                                 p => MainViewModel.Current.Files.Add(new FileAndType { Name = "UWP", Target = p })
                },
                {
                    "a|androidManifest=", "The path to an android manifest file to update with version information.", 
                                 a => MainViewModel.Current.Files.Add(new FileAndType { Name = "Droid", Target = a })
                },
                {
                    "t|touchPlist=", "The path to an iOS plist file to update with version information.", 
                                 t => MainViewModel.Current.Files.Add(new FileAndType { Name = "iOS", Target = t })
                },
                {
                    "n|nuspec=", "The path to an nuspec file to update with version information.", 
                                 n => MainViewModel.Current.Files.Add(new FileAndType { Name = "Nuget", Target = n })
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
               MainViewModel.Current.Files.Clear();

               var allFiles = System.IO.Directory.EnumerateFiles(System.IO.Directory.GetCurrentDirectory(), "*.*", System.IO.SearchOption.AllDirectories);

               var files = allFiles.Where(
                  x => x.ToLower().Contains(@"\properties\")
                  || x.ToLower().EndsWith(@"\info.plist")
                  || x.ToLower().EndsWith(@"\package.appxmanifest")
                  || x.ToLower().EndsWith(@"\versioninfo.cs")
                  || x.ToLower().EndsWith(@".vdproj")
                  || x.ToLower().EndsWith(@".csproj")
                  || x.ToLower().EndsWith(@".nuspec")
                  ).ToList();

               foreach (var f in files)
               {
                  if (f.ToLower().EndsWith(@"\versioninfo.cs"))
                  {
                     MainViewModel.Current.Files.Insert(0, new FileAndType { Name = "vi", Target = f });
                  };

                  if (f.StartsWith(@"D:\GitWare\_Nugets_\ZPF_Basics_XF\ZPF_Basics_XF_Sample\ZPF_Basics_XF_Sample.UWP\Properties"))
                  {
                     Debugger.Break();
                  };

                  if (UWPHelper.IsValid(f))
                  {
                     if (f.ToLower().EndsWith(@"\assemblyinfo.cs"))
                     {
                        if (System.IO.Directory.EnumerateFiles(System.IO.Path.GetDirectoryName(f), "Default.rd.xml", System.IO.SearchOption.TopDirectoryOnly).Count() == 1)
                        {
                           MainViewModel.Current.Files.Add(new FileAndType { Name = "UWP", Target = f });
                           //MainViewModel.Current.VersionCsPath = f;

                           try
                           {
                              _args2[_args2.IndexOf(st)] = $"-p={f}";
                           }
                           catch { };
                        };
                     };

                     if (f.ToLower().EndsWith(@"\package.appxmanifest"))
                     {
                        MainViewModel.Current.Files.Add(new FileAndType { Name = "UWP", Target = f });
                        //MainViewModel.Current.VersionCsPath = f;

                        //try
                        //{
                        //   _args2[_args2.IndexOf(st)] = $"-p={f}";
                        //}
                        //catch { };
                     };
                  };

                  if (DroidHelper.IsValid(f))
                  {
                     if (System.IO.Directory.EnumerateFiles(System.IO.Path.GetDirectoryName(f), "AndroidManifest.xml", System.IO.SearchOption.TopDirectoryOnly).Count() == 1)
                     {
                        MainViewModel.Current.Files.Add(new FileAndType { Name = "Droid", Target = f });
                        //MainViewModel.Current.AndroidManifestPath = f;
                     };
                  };

                  //if (WPFHelper.IsValid(f))
                  //{
                  //if (System.IO.Directory.EnumerateFiles(System.IO.Path.GetDirectoryName(f), "Settings.settings", System.IO.SearchOption.TopDirectoryOnly).Count() == 1)
                  //{
                  //   MainViewModel.Current.WPFAssemblyInfoPath = f;
                  //MainViewModel.Current.Files.Add(new FileAndType { Name = "WPF", Value = f });
                  //};
                  //};

                  if (iOSHelper.IsValid(f))
                  {
                     if (System.IO.File.ReadAllText(f).ToLower().Contains("minimumosversion"))
                     {
                        MainViewModel.Current.Files.Add(new FileAndType { Name = "iOS", Target = f });
                        //MainViewModel.Current.TouchPListPath = f;
                     };
                  };

                  //if (MacHelper.IsValid(f))
                  //{
                  //   if (System.IO.File.ReadAllText(f).ToLower().Contains("lsminimumsystemversion"))
                  //   {
                  //      MainViewModel.Current.MacPListPath = f;
                  //MainViewModel.Current.Files.Add(new FileAndType { Name = "MacOS", Value = f });
                  //   };
                  //};

                  if (NugetHelper.IsValid(f))
                  {
                     //MainViewModel.Current.nuspecPath = f;
                     MainViewModel.Current.Files.Add(new FileAndType { Name = "Nuget", Target = f });
                  }; 
                  
                  if ( DeployProjectHelper.IsValid(f))
                  {
                     MainViewModel.Current.Files.Add(new FileAndType { Name = "Setup", Target = f });
                  };
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

