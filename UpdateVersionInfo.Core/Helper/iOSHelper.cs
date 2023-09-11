using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;

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
               if (doc.ToString().Contains("<string>FMWK</string>"))
               {
                  return false;
               }
               else if (doc.ToString().Contains("<key>CFBundleVersion</key>")
                  || doc.ToString().Contains("<key>CFBundleShortVersionString</key>")
                  )
               {
                  /*
                  <key>CFBundleVersion</key>
                  <string>1.0.1.1</string>
                  <key>CFBundleShortVersionString</key>
                  <string>1.0.1</string>
                   */

                  return true;
               }
               else
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
               };
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
            if (doc.ToString().Contains("<string>FMWK</string>"))
            {
               // Do nothing it's a lib
            }
            else if (doc.ToString().Contains("<key>CFBundleVersion</key>")
               || doc.ToString().Contains("<key>CFBundleShortVersionString</key>")
               )
            {
               /*
               <key>CFBundleVersion</key>
               <string>1.0.1.1</string>
               <key>CFBundleShortVersionString</key>
               <string>1.0.1</string>
                */

               if (doc.ToString().Contains("<key>CFBundleVersion</key>"))
               {
                  var lines = doc.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                  var l = lines.Where(x => x.Contains("<key>CFBundleVersion</key>")).FirstOrDefault();
                  var ind = lines.IndexOf(l);
                  var version = lines[ind + 1].Replace(" ", "").Replace("/", "").Replace("<string>", "");

                  LastMessage = version;
                  return new Version(version);
               }
               else
               {

               };
            }
            else
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
               if (doc.ToString().Contains("<string>FMWK</string>"))
               {
                  // Do nothing it's a lib
               }
               else if (doc.ToString().Contains("<key>CFBundleVersion</key>")
                  || doc.ToString().Contains("<key>CFBundleShortVersionString</key>")
                  )
               {
                  /*
                  <key>CFBundleVersion</key>
                  <string>1.0.1.1</string>
                  <key>CFBundleShortVersionString</key>
                  <string>1.0.1</string>
                   */

                  var OldVersion = GetVersion(path);
                  var text = doc.ToString();

                  text = text.Replace($"<string>{OldVersion}</string>", $"<string>{version.ToString()}</string>");
                  text = text.Replace($"<string>{OldVersion.Major}.{OldVersion.Minor}.{OldVersion.MinorRevision}</string>", $"<string>{version.Major}.{version.Minor}.{version.MinorRevision}</string>");

                  LastMessage = $"{OldVersion} --> {version.ToString()}";

                  System.IO.File.WriteAllText(path, text);
                  return;
               }
               else
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
