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
      IsOk = IsOk && (filePath.ToLower().Contains(@"ios"));
      IsOk = IsOk && (!filePath.ToLower().Contains(@"\obj\"));
      IsOk = IsOk && (!filePath.ToLower().Contains(@"/obj/"));
      IsOk = IsOk && SubCheck(filePath);

      return IsOk;
   }

   private bool SubCheck(string filePath)
   {
      try
      {
         //<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
         XDocument doc = XDocument.Load(filePath);
         if (doc.DocumentType != null && doc.DocumentType.Name == "plist" && doc.ToString().Contains("<key>LSRequiresIPhoneOS</key>"))
         {
            if (doc.ToString().Contains("<string>FMWK</string>"))
            {
               // Do nothing it's a lib
               return false;
            }
            else
            {
               return true;
            };
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"FileProcessor_iOS.Check {filePath} {ex.Message}");
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

               var OldVersion = GetVersion(filePath);
               var text = doc.ToString();

               text = text.Replace($"<string>{OldVersion}</string>", $"<string>{newVersion.ToString()}</string>");
               text = text.Replace($"<string>{OldVersion.Major}.{OldVersion.Minor}.{OldVersion.Revision}</string>", $"<string>{newVersion.Major}.{newVersion.Minor}.{newVersion.Revision}</string>");

               // LastMessage = $"{OldVersion} --> {version.ToString()}";

               System.IO.File.WriteAllText(filePath, text);
               return "ok";
            }
            else
            {
               var shortVersionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleShortVersionString']");
               if (shortVersionElement != null)
               {
                  var valueElement = shortVersionElement.NextNode as XElement;

                  string v1 = valueElement.Value.ToString();
                  valueElement.Value = newVersion.ToString();
                  // LastMessage = $"{v1} --> {version.ToString()}";
               }
               else
               {
                  var rootElement = doc.XPathSelectElement("plist/dict");

                  // Element is missing, so create it
                  {
                     XElement newElement = new XElement("key", "CFBundleShortVersionString");
                     rootElement.Add(newElement);
                  }

                  {
                     XElement newElement = new XElement("string", newVersion.ToString());
                     rootElement.Add(newElement);
                  }
               };

               var versionElement = doc.XPathSelectElement("plist/dict/key[string()='CFBundleVersion']");
               if (versionElement != null)
               {
                  var valueElement = versionElement.NextNode as XElement;

                  string v1 = valueElement.Value.ToString();
                  valueElement.Value = newVersion.ToString();
                  //LastMessage = $"{v1} --> {version.ToString()}";
               //}
               //else
               //{
               //   // Element is missing, so create it
               //   {
               //      XElement newElement = new XElement("key", "CFBundleVersion");
               //      doc.Root.Add(newElement);
               //   }

               //   {
               //      XElement newElement = new XElement("string", newVersion.ToString());
               //      doc.Root.Add(newElement);
               //   }
               };
            }
         }

         doc.Save(filePath);
      }
      catch (Exception ex)
      {
         Console.WriteLine($"FileProcessor_iOS.Update {filePath} {ex.Message}");
         return "ko";
      };

      return "ok";
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

}

