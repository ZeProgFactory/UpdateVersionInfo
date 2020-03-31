using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace UpdateVersionInfo.Core
{
   public class iOSHelper
   {
      public static String LastMessage = "";

      /// <summary>
      /// IsValidTouchPList
      /// </summary>
      /// <param name="path"></param>
      /// <returns></returns>
      public static bool IsValid(String path)
      {
         if (MainViewModel.Current.Debug) Console.WriteLine($"iOSHelper.IsValid( {path} )");
         LastMessage = "";

         if (!File.Exists(path)) return false;
         if ((new FileInfo(path).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) return false;

         try
         {
            //<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
            XDocument doc = XDocument.Load(path);
            if (doc.DocumentType != null && doc.DocumentType.Name == "plist")
            {
               var shortVersionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleShortVersionString']");
               if (shortVersionElement != null)
               {
                  var valueElement = shortVersionElement.NextNode as XElement;
                  if (valueElement != null && valueElement.Name == "string") return true;
               }

               var versionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleVersion']");
               if (versionElement != null)
               {
                  var valueElement = versionElement.NextNode as XElement;
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

      public static Version GetVersion(string path)
      {
         if (MainViewModel.Current.Debug) Console.WriteLine($"iOSHelper.GetVersion( {path} )");
         LastMessage = "";

         XDocument doc = XDocument.Load(path);
         if (doc.DocumentType.Name == "plist")
         {
            var shortVersionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleShortVersionString']");
            if (shortVersionElement != null)
            {
               var valueElement = shortVersionElement.NextNode as XElement;
               LastMessage = valueElement.Value.ToString();
            }

            var versionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleVersion']");
            if (versionElement != null)
            {
               var valueElement = versionElement.NextNode as XElement;
               LastMessage = valueElement.Value.ToString();
            }
         }

         return new Version(LastMessage);
      }

      /// <summary>
      /// UpdateTouchVersionInfo
      /// </summary>
      /// <param name="path"></param>
      /// <param name="version"></param>
      public static void Update(string path, Version version)
      {
         if (MainViewModel.Current.Debug) Console.WriteLine($"iOSHelper.Update( {path} )");
         LastMessage = "";

         try
         {
            XDocument doc = XDocument.Load(path);
            if (doc.DocumentType.Name == "plist")
            {
               var shortVersionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleShortVersionString']");
               if (shortVersionElement != null)
               {
                  var valueElement = shortVersionElement.NextNode as XElement;

                  string v1 = valueElement.Value.ToString();
                  valueElement.Value = version.ToString();
                  LastMessage = $"{v1} --> {version.ToString()}";
               }

               var versionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleVersion']");
               if (versionElement != null)
               {
                  var valueElement = versionElement.NextNode as XElement;

                  string v1 = valueElement.Value.ToString();
                  valueElement.Value = version.ToString();
                  LastMessage = $"{v1} --> {version.ToString()}";
               }
            }

            doc.Save(path);
         }
         catch (Exception ex)
         {
            LastMessage = $"{path} {ex.Message}";
         };
      }

   }
}
