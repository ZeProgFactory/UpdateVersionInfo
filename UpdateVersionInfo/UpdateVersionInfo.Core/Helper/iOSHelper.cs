using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace UpdateVersionInfo.Core
{
   public class iOSHelper
   {
      /// <summary>
      /// IsValidTouchPList
      /// </summary>
      /// <param name="path"></param>
      /// <returns></returns>
      public static bool IsValid(String path)
      {
         if (!File.Exists(path)) return false;
         if ((new FileInfo(path).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) return false;

         try
         {
            //<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
            XDocument doc = XDocument.Load(path);
            if (doc.DocumentType.Name == "plist")
            {
               var shortVersionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleShortVersionString']");
               if (shortVersionElement != null)
               {
                  var valueElement = shortVersionElement.NextNode as XElement;
                  if (valueElement != null && valueElement.Name == "string") return true;
               }
            }
         }
         catch (Exception e)
         {
            System.Diagnostics.Trace.TraceError(e.Message);
         }

         return false;
      }

      /// <summary>
      /// UpdateTouchVersionInfo
      /// </summary>
      /// <param name="path"></param>
      /// <param name="version"></param>
      public static void Update(string path, Version version)
      {
         XDocument doc = XDocument.Load(path);
         var shortVersionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleShortVersionString']");
         var versionElement = shortVersionElement.NextNode as XElement;
         versionElement.Value = version.ToString();
         doc.Save(path);
      }
   }
}
