using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;

namespace UpdateVersionInfo
{
   public class CommandLineArguments
   {
      private readonly OptionSet _options;
      public bool ShowHelp { get; private set; }
      public int Major { get; private set; }
      public int Minor { get; private set; }
      public int? Build { get; private set; }
      public int? Revision { get; private set; }
      public String VersionCsPath { get; private set; }
      public String AndroidManifestPath { get; private set; }
      public String TouchPListPath { get; private set; }
      public bool AutoVersion { get; private set; }

      private OptionSet Initialize()
      {
         AutoVersion = false;

         var options = new OptionSet {
                {
                    "?", "Shows help/usage information.", h => ShowHelp = true
                },
                {
                    "v|major=", "A numeric major version number greater than zero.", (int v) => Major = v
                },
                {
                    "m|minor=", "A numeric minor number greater than zero.", (int v) => Minor = v
                },
                {
                    "b|build=", "A numeric build number greater than zero.", (int v) => Build = v
                },
                {
                    "r|revision=", "A numeric revision number greater than zero.", (int v) => Revision = v
                },
                {
                    "p|path=", "The path to a C# file to update with version information.", p => VersionCsPath = p
                },
                {
                    "a|androidManifest=", "The path to an android manifest file to update with version information.", p => AndroidManifestPath = p
                },
                {
                    "t|touchPlist=", "The path to an iOS plist file to update with version information.", p => TouchPListPath = p
                }
            };

         return options;
      }

      public CommandLineArguments(IEnumerable<String> args)
      {
         Major = 1;
         Minor = 0;
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
               AutoVersion = true;

               _args2[_args2.IndexOf(st)] = "-v=1";

               _args2.Add("-m=0");
               _args2.Add("-b=0");
               _args2.Add("-r=0");
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
