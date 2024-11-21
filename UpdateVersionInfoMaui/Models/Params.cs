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
   //"-?", "Shows help/usage information."
   public bool ShowHelp { get; set; } = true;

   //"-debug", "Shows debug information."
   public bool Debug { get; set; } = false;


   public bool Simulation { get; set; } = false;


   //"-i", "Displays current version info"
   public bool ScanAndDisplay { get; set; } = false;

   //"-s", "Scan subfolders"
   public bool SubFolders { get; set; } = true;

}
