using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace UpdateVersionInfo.Core
{
   class NugetHelper
   {
      public static String LastMessage = "";

      /// <summary>
      /// IsValidTouchPList
      /// </summary>
      /// <param name="path"></param>
      /// <returns></returns>
      public static bool IsValid(String path)
      {
         LastMessage = "";

         if (!File.Exists(path)) return false;
         if ((new FileInfo(path).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) return false;

         try
         {
            // <package ...
            XDocument doc = XDocument.Load(path);
            var rootElement = doc.Root as XElement;
            if (rootElement != null && rootElement.Name == "package") return true;
         }
         catch (Exception e)
         {
            System.Diagnostics.Trace.TraceError(e.Message);
         }

         return false;
      }

      public static Version GetVersion(string path)
      {
         LastMessage = "";

         XDocument doc = XDocument.Load(path);
         var versionElement = doc.XPathSelectElement("package/metadata/version");
         LastMessage = versionElement.Value.ToString();

         return new Version(LastMessage);
      }

      /// <summary>
      /// UpdateTouchVersionInfo
      /// </summary>
      /// <param name="path"></param>
      /// <param name="version"></param>
      public static void Update(string path, Version version)
      {
         LastMessage = "";

         XDocument doc = XDocument.Load(path);
         var versionElement = doc.XPathSelectElement("package/metadata/version");

         string v1 = versionElement.Value.ToString();

         if (MainViewModel.Current.AutoVersion)
         {
            string v2 = MainViewModel.Current.IncVersion(v1);
            versionElement.Value = v2;
            LastMessage = $"{v1} --> {v2}";
         }
         else
         {
            versionElement.Value = version.ToString();
            LastMessage = $"{v1} --> {version.ToString()}";
         };

         doc.Save(path);
      }
   }
}
