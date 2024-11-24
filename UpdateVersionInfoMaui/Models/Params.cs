using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateVersionInfo;

/*
  -?                         Shows help/usage information.
  -s                         silent/verbus
  -i                         Displays current version info
  -v, --major=VALUE          auto | A numeric major version number greater
                             than zero.
  -m, --minor=VALUE          A numeric minor number greater than zero.
  -b, --build=VALUE          A numeric build number greater than zero.
  -r, --revision=VALUE       A numeric revision number greater than zero.
      --vi=VALUE             The path to a 'VersionInfo.cs' file to update
                             with version information.
  -p, --path=VALUE           scan | The path to a C# file to update with
                             version information.
  -a, --androidManifest=VALUE
                             The path to an android manifest file to update
                             with version information.
  -t, --touchPlist=VALUE     The path to an iOS plist file to update with
                             version information.
  -n, --nuspec=VALUE         The path to an nuspec file to update with
                             version information.
 */


public class Params
{
   public bool HasVersionInfo { get; internal set; }


   [ParamAttributes.Help(true,"-?", "Shows help/usage information.")]
   public bool ShowHelp { get; set; } = true;


   [ParamAttributes.Help(true, "-sim", "Apply no changes")]
   public bool Simulation { get; set; } = false;


   [ParamAttributes.Help(false, "-debug", "Shows debug information")]
   public bool Debug { get; set; } = false;


   [ParamAttributes.Help(true, "-i", "Displays current version info")]
   public bool ScanAndDisplay { get; set; } = false;


   [ParamAttributes.Help(true, "-s", "Scan subfolders")]
   public bool SubFolders { get; set; } = true;


   [ParamAttributes.Help(true, "-ui", "Use IVersionInfo interface")]
   public bool UseIVersionInfo { get; set; } = false;


   [ParamAttributes.Help(true, "-tso", "Update build TimeStamp Only")]
   public bool BuildTimeStampOnly { get; set; } = false;

   public bool DisplayFilePath { get; internal set; } = true;


   [ParamAttributes.Help(true, "-gvi", "Generate VersionInfo.cs")]
   public bool GenerateVersionInfo { get; set; } = false;

}
