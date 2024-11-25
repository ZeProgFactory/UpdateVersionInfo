using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace UpdateVersionInfo;

public class FileProcessor_iOS : IFileProcessor
{
   public string Name { get; set; } = "iOS  ";

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public bool Check(string filePath)
   {
      bool IsOk = true;

      IsOk = IsOk && (filePath.ToLower().EndsWith("info.plist"));
      IsOk = IsOk && (!filePath.ToLower().Contains(@"\obj\"));
      IsOk = IsOk && (!filePath.ToLower().Contains(@"/obj/"));
      IsOk = IsOk && SubCheck(filePath);

      return IsOk;
   }

   private bool SubCheck(string filePath)
   {
      try
      {
         // <manifest ...
         XDocument doc = XDocument.Load(filePath);
         var rootElement = doc.Root as XElement;

         if (rootElement != null && rootElement.Name == "plist")
         {
            if (doc.ToString().Contains("<string>FMWK</string>"))
            {
               // Do nothing it's a lib
               return false;
            };

            if (doc.ToString().Contains("LSRequiresIPhoneOS"))
            {
               return true;
            };

            return false;
         };
      }
      catch (System.Xml.XmlException)
      {
      }
      catch (Exception ex)
      {
         Console.WriteLine($"FileProcessor_Droid.Check {filePath} {ex.Message}");
      };

      return false;
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public Version GetVersion(string filePath)
   {
      var version = "";

      XDocument doc = XDocument.Load(filePath);
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
               version = lines[ind + 1].Replace(" ", "").Replace("/", "").Replace("<string>", "");

               return new Version(version);
            };

            if (doc.ToString().Contains("<key>CFBundleShortVersionString</key>"))
            {
               var lines = doc.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
               var l = lines.Where(x => x.Contains("<key>CFBundleShortVersionString</key>")).FirstOrDefault();
               var ind = lines.IndexOf(l);
               version = lines[ind + 1].Replace(" ", "").Replace("/", "").Replace("<string>", "");

               return new Version(version);
            };
         }
      }

      return new Version();
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public string Update(string filePath, Version newVersion)
   {
      try
      {
         XDocument doc = XDocument.Load(filePath);

         if (doc.DocumentType.Name == "plist")
         {
            if (doc.ToString().Contains("<string>FMWK</string>"))
            {
               // Do nothing it's a lib
               return "";
            };

            /*
            <key>CFBundleVersion</key>
            <string>1.0.1.1</string>
            <key>CFBundleShortVersionString</key>
            <string>1.0.1</string>
             */

            // https://developer.apple.com/documentation/bundleresources/information-property-list/cfbundleversion
            // https://developer.apple.com/documentation/bundleresources/information-property-list/cfbundleshortversionstring

            if (doc.ToString().Contains("<key>CFBundleVersion</key>")
               || doc.ToString().Contains("<key>CFBundleShortVersionString</key>")
               )
            {

               var OldVersion = GetVersion(filePath);
               var text = doc.ToString();

               text = text.Replace($"<string>{OldVersion}</string>", $"<string>{newVersion.ToString()}</string>");
               text = text.Replace($"<string>{OldVersion.Major}.{OldVersion.Minor}.{OldVersion.Build}</string>", $"<string>{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}</string>");

               System.IO.File.WriteAllText(filePath, text);
               return "ok";
            }
            else
            {
               var rootElement = doc.XPathSelectElement("plist/dict");

               if( rootElement != null) 
               {
                  rootElement.Add(new XElement("key", "CFBundleVersion"));
                  rootElement.Add(new XElement("string", newVersion.ToString()));

                  rootElement.Add(new XElement("key", "CFBundleShortVersionString"));
                  rootElement.Add(new XElement("string", $"{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}"));
               }
            }
         }

         doc.Save(filePath);
      }
      catch (Exception ex)
      {
         return $"{filePath} {ex.Message}";
      };

      return "ok";
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

}

