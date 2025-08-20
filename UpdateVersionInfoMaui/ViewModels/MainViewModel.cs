
using ZPF;

namespace UpdateVersionInfo;

public class MainViewModel
{
   public String UpdateVersionInfoVersion { get; } = $"{VersionInfo.Current.sVersion} alpha (Maui) - {VersionInfo.Current.LongBuildOn}";

   // - - -  - - - 

   #region Singleton 
   static MainViewModel _Current = null;

   public static MainViewModel Current
   {
      get
      {
         if (_Current == null)
         {
            _Current = new MainViewModel();
         };

         return _Current;
      }
   }
   #endregion

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public MainViewModel()
   {
      FileProcessors.Add(new FileProcessor_VersionInfo());
      FileProcessors.Add(new FileProcessor_LastUpdate());
      FileProcessors.Add(new FileProcessor_Droid());
      FileProcessors.Add(new FileProcessor_iOS());
      //ToDo: FileProcessors.Add(new FileProcessor_Mac());
      FileProcessors.Add(new FileProcessor_UAP());
      FileProcessors.Add(new FileProcessor_Nuget());
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public string WorkDir { get; internal set; } = System.IO.Directory.GetCurrentDirectory();

   // - - -  - - - 

   public Params Config { get; internal set; } = new Params();

   // - - -  - - - 

   public Version PrevVersion { get; set; } = new Version();
   public Version NewVersion { get; set; } = new Version();

   // - - -  - - - 

   public List<IFileProcessor> FileProcessors { get; set; } = new List<IFileProcessor>();

   //public bool Silent { get; set; } = false;
   //public bool ShowHelp { get; set; }

   // - - -  - - - 



   // - - -  - - - 

   //public String VersionCsPath { get; set; }
   //public String AndroidManifestPath { get; set; }
   //public String TouchPListPath { get; set; }
   //public String nuspecPath { get; set; }

   // - - -  - - - 

   //public bool AutoVersion { get; set; }
   ///// <summary>
   ///// Holds the master version for all platforms based on the UWP version.
   ///// </summary>
   //public string sAutoVersionV2 { get; set; }

   ///// <summary>
   ///// Scan files & folder and sets paths automaticaly.
   ///// </summary>
   //public bool ScanFiles { get; set; } = false;
   //public List<FileAndType> Files { get; set; } = new List<FileAndType>();

   ///// <summary>
   ///// Displays current version info.
   ///// </summary>
   //public bool Info { get; set; } = false;

   ///// <summary>
   ///// Displays more detailed info
   ///// </summary>
   //public bool Verbose { get; set; } = true;

   // - - -  - - - 

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  

   public List<WorkFile> Files { get; internal set; } = new List<WorkFile>();
   public DateTime BuildTimeStamp { get; internal set; }

   public void GetWorkFiles(IEnumerable<string> files)
   {
      Files.Clear();

      foreach (var file in files)
      {

         foreach (var fp in FileProcessors)
         {
            if (fp.Check(file))
            {
               Files.Add(new WorkFile
               {
                  FilePath = file,
                  FileProcessor = (IFileProcessor)fp,
               });
            }
         }
      }
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

}
