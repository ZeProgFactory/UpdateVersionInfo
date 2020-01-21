using System;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;

using ZPF;


/// <summary>
/// Summary description for Class1
/// </summary>
public class DataModul
{
   public delegate bool TDispatch( string URL );

   // - - - vvv The stuff for the Singleton vvv - - -
   
   private static DataModul _theUniqueInstance = null;

   private DataModul() { }

   public static DataModul GetInstance()
   {
      //creer une nouvelle instance s il n en existe pas deja une autre
      if(_theUniqueInstance == null)
         return _theUniqueInstance = new DataModul();
      else 
         return _theUniqueInstance;
   }

   // - - - ^^^ The stuff for the Singleton ^^^ - - -

   public int     LineNumbers;
   public bool    BlackWhite;
   public bool    ReloadFiles;
   public string  FileName1;
   public string  FileName2;

   public TStrings Params;
   public string  ProgramCaption;

   /// Database and local connection strings.
   ///

   public string  ProgramPath;
   public string  DatabaseFile;
   public string  IniFileName;
   public string  SchemaFile;

   public string  ConnectionString;
   public DataSet MyDataSet;
   public DataSet tmpDataSet;

   public int     TimeStamp;
   public string  TimeStamps;

   public string  UserName;

   public string  Version = "Version " + ZPF.ProjectInfo.ProductVersion();

   public void InitDataModul(string FileName)
   {
      ProgramCaption = "FileSync" + " - " + Version;

      // Sets the directory in which all the application files (database, images, and executable)
      // are located.
      //
      if ( Environment.OSVersion.Platform.ToString() == "Win32NT" )
      {
         this.ProgramPath = Directory.GetCurrentDirectory();
      }
      else
      {
         this.ProgramPath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).DirectoryName;
      };

      System.Configuration.ConfigurationSettings.AppSettings.Set( "WikiImages", "file://" + ProgramPath + "\\Images\\" );

      // Sets database file name.
      //
      this.DatabaseFile = ProgramPath + "\\" + FileName + ".xml";

      // Sets database file name.
      //
      this.SchemaFile = System.IO.Path.ChangeExtension( DatabaseFile, ".xsd");

      // Construct the connecting strings.
      //
      this.ConnectionString = @"Data Source=" + DatabaseFile;

      // Sets INI file name.
      //
      if ( Environment.OSVersion.Platform.ToString() == "Win32NT" )
      {
         DataModul.GetInstance().IniFileName = ProgramPath + "\\" + FileName + ".ini";
      }
      else
      {
         DataModul.GetInstance().IniFileName = "\\" + new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Name + ".ini";
      };

      //
      LoadConfig();
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

   public bool    Debug;

   public void LoadConfig()
   {
      TIniFile IniFile = new TIniFile( DataModul.GetInstance().IniFileName );

      Debug          = IniFile.ReadBool(     "General", "Debug",       false );
      LineNumbers    = IniFile.ReadInteger(  "General", "LineNumbers", 0 );
      BlackWhite     = IniFile.ReadBool(     "General", "BlackWhite", true );
      ReloadFiles    = IniFile.ReadBool(     "General", "ReloadFiles", true );
      FileName1      = IniFile.ReadString(   "General", "FileName1", "" );
      FileName2      = IniFile.ReadString(   "General", "FileName2", "" );
   }

   public void SaveConfig()
   {
      TIniFile IniFile = new TIniFile( DataModul.GetInstance().IniFileName );

      IniFile.WriteBool(      "General", "Debug",        Debug );
      IniFile.WriteInteger(   "General", "LineNumbers",   LineNumbers );
      IniFile.WriteBool(      "General", "BlackWhite", BlackWhite );
      IniFile.WriteBool(      "General", "ReloadFiles", ReloadFiles );
      IniFile.WriteString(    "General", "FileName1", FileName1 );
      IniFile.WriteString(    "General", "FileName2", FileName2 ); 

      IniFile.UpdateFile();
   }

   //
   // - - -  - - - 
}



