using System.Diagnostics;
using System.Reflection;

namespace UpdateVersionInfo;

internal class Program
{
   static void Main(string[] args)
   {
      MainViewModel.Current.Config.Debug = args.Where(x => x.Trim().ToLower() == "-debug").Count() == 1;
      MainViewModel.Current.Config.ShowHelp = args.Where(x => x.Trim().ToLower() == "-?").Count() == 1;

      if (args.Length == 0 || MainViewModel.Current.Config.ShowHelp)
      {
         ShowHeader();
         ShowHelp();
      };

      // - - -  - - - 

      if (Debugger.IsAttached)
      {
         MainViewModel.Current.WorkDir = System.IO.Directory.GetCurrentDirectory();
      }
      else
      {
         MainViewModel.Current.WorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
      };

      MainViewModel.Current.WorkDir = @"D:\GitWare\Apps\ZeScanner\ZeScanner.Maui9";

      // - - - scan folder(s) - - - 

      // Enumerate all files in the directory ( and subdirectories )
      var files = Directory.EnumerateFiles(MainViewModel.Current.WorkDir, "*", (MainViewModel.Current.Config.SubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
      MainViewModel.Current.GetWorkFiles(files);

      // - - - read VersionInfo.cs - - - 

      if (MainViewModel.Current.Files.Where(x => x.FileProcessor.GetType() == typeof(FileProcessor_VersionInfo)).Count() == 1)
      {
         var x = (MainViewModel.Current.Files.Where(x => x.FileProcessor.GetType() == typeof(FileProcessor_VersionInfo)).FirstOrDefault());

         MainViewModel.Current.PrevVersion = x.FileProcessor.GetVersion(x.FilePath);
      }
      else
      {
         // oups ...

         Console.WriteLine("Error: Found more than 1 'VersionInfo.cs'.");

         Environment.Exit(0);
      };

      // - - -  - - - 

      ShowHeader();

      MainViewModel.Current.NewVersion = new Version(MainViewModel.Current.PrevVersion.ToString());
      MainViewModel.Current.NewVersion.IncVersion();

      Environment.SetEnvironmentVariable("PrevVersion", MainViewModel.Current.PrevVersion.ToString());
      Environment.SetEnvironmentVariable("NewVersion", MainViewModel.Current.NewVersion.ToString());

      // - - - do it - - - 

      foreach (var file in MainViewModel.Current.Files)
      {
         Console.WriteLine($"{file.FileProcessor.Name}  {file.FileProcessor.GetVersion(file.FilePath)} --> {MainViewModel.Current.NewVersion}");

         if (!MainViewModel.Current.Config.Simulation)
         {
            var LastMessage = file.FileProcessor.Update(file.FilePath, MainViewModel.Current.NewVersion);
         };
      };

      // - - -  - - - 
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

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

   private static void ShowHelp()
   {
      Console.WriteLine("  -?                         Shows help/usage information.");
      Console.WriteLine("");
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   private static void ShowHeader()
   {
      Console.WriteLine("");
      Console.WriteLine($"UpdateVersionInfo - V{MainViewModel.Current.UpdateVersionInfoVersion}");
      Console.WriteLine("");
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -
}
