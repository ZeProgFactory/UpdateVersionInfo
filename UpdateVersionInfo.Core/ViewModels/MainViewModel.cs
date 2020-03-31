using System;
using System.Collections.Generic;
using ZPF;

namespace UpdateVersionInfo.Core
{
   public class MainViewModel
   {
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

      // - - -  - - - 

      public String UpdateVersionInfoVersion { get; } = "1.0.14";

      // - - -  - - - 

      public bool Silent { get; set; } = false;

      // - - -  - - - 

      public bool ShowHelp { get; set; }
      public int Major { get; set; }
      public int Minor { get; set; }
      public int? Build { get; set; }
      public int? Revision { get; set; }

      public String VersionCsPath { get; set; }
      public String AndroidManifestPath { get; set; }
      public String TouchPListPath { get; set; }
      public String nuspecPath { get; set; }

      // - - -  - - - 

      public bool AutoVersion { get; set; }
      /// <summary>
      /// Holds the master version for all platforms based on the UWP version.
      /// </summary>
      public string sAutoVersionV2 { get; set; }

      /// <summary>
      /// Scan files & folder and sets paths automaticaly.
      /// </summary>
      public bool ScanFiles { get; set; } = false;
      public List<FileAndType> Files { get; set; } = new List<FileAndType>();

      /// <summary>
      /// Displays current version info.
      /// </summary>
      public bool Info { get; set; } = false;

      /// <summary>
      /// Displays more detailed info
      /// </summary>
      public bool Verbose { get; set; } = true;
      public bool Debug { get; internal set; } = false;
      public string WorkDir { get; internal set; } = System.IO.Directory.GetCurrentDirectory();

      // - - -  - - - 

      public string IncVersion(string v1)
      {
         var vl = v1.Split(new char[] { '.' });

         if (vl.Length == 3)
         {
            var v = new Version(v1 + ".0");
            return $"{v.Major}.{v.Minor}.{v.Build + 1}";
         }
         else
         {
            var v = new Version(v1);
            return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision + 1}";
         };
      }

      // - - -  - - - 
   }
}
