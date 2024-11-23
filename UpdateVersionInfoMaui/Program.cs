using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

namespace UpdateVersionInfo;

internal class Program
{
   static void Main(string[] args)
   {
      MainViewModel.Current.Config.ShowHelp = args.Where(x => x.Trim().ToLower() == "-?").Count() == 1;

      if (args.Length == 0 || MainViewModel.Current.Config.ShowHelp)
      {
         ShowHeader();
         ShowHelp();

         return;
      };

      // - - - retrieve args - - - 

      MainViewModel.Current.Config.Debug = args.Where(x => x.Trim().ToLower() == "-debug").Count() == 1;
      MainViewModel.Current.Config.ScanAndDisplay = args.Where(x => x.Trim().ToLower() == "-i").Count() == 1;
      MainViewModel.Current.Config.SubFolders = args.Where(x => x.Trim().ToLower() == "-s").Count() == 1;
      MainViewModel.Current.Config.UseIVersionInfo = args.Where(x => x.Trim().ToLower() == "-ui").Count() == 1;
      MainViewModel.Current.Config.BuildTimeStampOnly = args.Where(x => x.Trim().ToLower() == "-tso").Count() == 1;

      // - - -  - - - 

      if (Debugger.IsAttached)
      {
         MainViewModel.Current.WorkDir = System.IO.Directory.GetCurrentDirectory();

         //MainViewModel.Current.WorkDir = @"D:\GitWare\Apps\ZeScanner\ZeScanner.Maui9";
         MainViewModel.Current.WorkDir = @"D:\GitWare\Apps\ECO-SI.iZiBio\izimobile\Izibio.Maui9";
      }
      else
      {
         //MainViewModel.Current.WorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
         MainViewModel.Current.WorkDir = System.IO.Directory.GetCurrentDirectory();
      };

      // - - - scan folder(s) - - - 

      // Enumerate all files in the directory ( and subdirectories )
      if (MainViewModel.Current.Config.Debug) Console.WriteLine($"WorkDir {MainViewModel.Current.WorkDir}");

      var files = Directory.EnumerateFiles(MainViewModel.Current.WorkDir, "*", (MainViewModel.Current.Config.SubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
      MainViewModel.Current.GetWorkFiles(files);

      // - - - search & read VersionInfo.cs - - - 

      MainViewModel.Current.Config.HasVersionInfo = MainViewModel.Current.Files.Where(x => x.FileProcessor.GetType() == typeof(FileProcessor_VersionInfo)).Count() == 1;

      if (MainViewModel.Current.Config.HasVersionInfo)
      {
         var x = (MainViewModel.Current.Files.Where(x => x.FileProcessor.GetType() == typeof(FileProcessor_VersionInfo)).FirstOrDefault());

         MainViewModel.Current.PrevVersion = x.FileProcessor.GetVersion(x.FilePath);
      }
      else
      {
         // oups ...

         if (MainViewModel.Current.Files.Where(x => x.FileProcessor.GetType() == typeof(FileProcessor_VersionInfo)).Count() > 1)
         {
            ShowHeader();
            Console.WriteLine("Error: Found more than 1 'VersionInfo.cs'.");

            Environment.Exit(0);
         };
      };

      // - - -  - - - 

      if (MainViewModel.Current.Files.Count() == 0)
      {
         ShowHeader();
         Console.WriteLine("No files found to update.");

         Environment.Exit(0);
      };

      // - - -  - - - 

      ShowHeader();

      MainViewModel.Current.NewVersion = new Version(MainViewModel.Current.PrevVersion.ToString());
      if (!MainViewModel.Current.Config.BuildTimeStampOnly)
      {
         MainViewModel.Current.NewVersion.IncVersion();
      };

      Environment.SetEnvironmentVariable("PrevVersion", MainViewModel.Current.PrevVersion.ToString());
      Environment.SetEnvironmentVariable("NewVersion", MainViewModel.Current.NewVersion.ToString());

      MainViewModel.Current.BuildTimeStamp = DateTime.Now;
      Environment.SetEnvironmentVariable("BuildDateTime", MainViewModel.Current.BuildTimeStamp.ToString("yyMMdd HHmm"));
      Environment.SetEnvironmentVariable("BuildDate", MainViewModel.Current.BuildTimeStamp.ToString("yyMMdd"));

      // - - - do it - - - 

      foreach (var file in MainViewModel.Current.Files)
      {
         var OldVersion = file.FileProcessor.GetVersion(file.FilePath);

         if (!MainViewModel.Current.Config.Simulation)
         {
            if (!MainViewModel.Current.Config.HasVersionInfo)
            {
               MainViewModel.Current.NewVersion = new Version(OldVersion.ToString());

               if (!MainViewModel.Current.Config.BuildTimeStampOnly)
               {
                  MainViewModel.Current.NewVersion.IncVersion();
               };
            };

            var LastMessage = file.FileProcessor.Update(file.FilePath, MainViewModel.Current.NewVersion);
            Console.WriteLine($"{file.FileProcessor.Name}  {OldVersion} --> {MainViewModel.Current.NewVersion}");
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
      var propertiesWithAttribute = typeof(Params).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ParamAttributes.HelpAttribute)));

      foreach (var prop in propertiesWithAttribute)
      {
         UpdateVersionInfo.ParamAttributes.HelpAttribute attribute = (UpdateVersionInfo.ParamAttributes.HelpAttribute)prop.GetCustomAttribute(typeof(ParamAttributes.HelpAttribute));

         if (attribute.IsVisisible)
         {
            Console.WriteLine($"   {attribute.Param,-8} {attribute.HelpText}");
         };
      }

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
