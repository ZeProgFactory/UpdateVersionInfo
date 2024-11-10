using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UpdateVersionInfo;

public class FileProcessor_VersionInfo : IFileProcessor
{
   public string Name { get; set; } = "VInfo";

   public bool Check(string filePath)
   {
      bool IsOk = true;

      IsOk = IsOk && (filePath.ToLower().EndsWith("versioninfo.cs"));

      return IsOk;
   }

   public Version GetVersion(string filePath)
   {
      string text = System.IO.File.ReadAllText(filePath);
      text = text.Trim(new char[] { '\r', '\n' });
      var lines = text.Split(new char[] { '\n' });

      if (lines.Length > 3)
      {
         return new Version(lines[1].Trim().Substring(4));
      };

      return new Version();
   }

   public string Update(string filePath, Version newVersion)
   {
      var file = GetStringRessource("UpdateVersionInfoMaui.Template.VersionInfo.txt");

      file = file.Replace("#UpdateVersion#", MainViewModel.Current.UpdateVersionInfoVersion);
      file = file.Replace("#Version#", newVersion.ToString());
      file = file.Replace("#BuildDate#", DateTime.Now.ToString("dd.MM.yyyy"));
      file = file.Replace("#BuildTime#", DateTime.Now.ToString("HH:mm"));

      try
      {
         System.IO.File.WriteAllText(filePath, file);
      }
      catch (Exception ex)
      {
         return ex.Message;
      };

      return "ok";
   }

   string GetStringRessource(string resourceName)
   {
      var assembly = Assembly.GetExecutingAssembly();

      using (Stream stream = assembly.GetManifestResourceStream(resourceName))
      using (StreamReader reader = new StreamReader(stream))
      {
         string result = reader.ReadToEnd();
         return result;
      }
   }
}

