using System;

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

      public bool ShowHelp { get; set; }
      public int Major { get; set; }
      public int Minor { get; set; }
      public int? Build { get; set; }
      public int? Revision { get; set; }
      public String VersionCsPath { get; set; }
      public String AndroidManifestPath { get; set; }
      public String TouchPListPath { get; set; }

      // - - -  - - - 

      public bool AutoVersion { get; set; }
      /// <summary>
      /// Holds the master version for all platforms based on the UWP version.
      /// </summary>
      public string sAutoVersion { get; set; }

      // - - -  - - - 
   }
}
