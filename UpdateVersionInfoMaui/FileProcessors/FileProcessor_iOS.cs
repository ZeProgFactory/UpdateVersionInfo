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

      //try
      //{
      //   const string androidNS = "http://schemas.android.com/apk/res/android";
      //   XName versionCodeAttributeName = XName.Get("version", androidNS);
      //   XName versionNameAttributeName = XName.Get("versionName", androidNS);
      //   XDocument doc = XDocument.Load(filePath);

      //   var x = doc.Root.Attribute(versionNameAttributeName);

      //   if (x == null)
      //   {
      //      version = "versionName AttributeName not found";
      //      return new Version();
      //   }
      //   else
      //   {
      //      version = (x == null ? "versionName AttributeName not found" : x.Value);
      //   };
      //}
      //catch (Exception ex)
      //{
      //   Console.WriteLine($"FileProcessor_Droid.GetVersion {filePath} {ex.Message}");

      //   version = ex.Message;
      //   return new Version();
      //};

               return new Version(version);
            };
         }
      }

      return new Version();
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public string Update(string filePath, Version newVersion)
   {
      //try
      //{
      //   const string androidNS = "http://schemas.android.com/apk/res/android";
      //   XName versionCodeAttributeName = XName.Get("versionCode", androidNS);
      //   XName versionNameAttributeName = XName.Get("versionName", androidNS);
      //   XDocument doc = XDocument.Load(filePath);

               var OldVersion = GetVersion(filePath);
               var text = doc.ToString();

      //   //   var v = v1.Split(new char[] { '.' });

      //   //   string v2 = "";

      //   //   if (string.IsNullOrEmpty(MainViewModel.Current.sAutoVersionV2))
      //   //   {
      //   //      v2 = v[0] + "." + v[1] + "." + (v.Count() < 3 ? "0" : v[2]) + "." + (int.Parse((v.Count() < 4 ? "0" : v[3])) + 1).ToString();
      //   //   }
      //   //   else
      //   //   {
      //   //      v2 = MainViewModel.Current.sAutoVersionV2;
      //   //   };

      //   //   doc.Root.SetAttributeValue(versionCodeAttributeName, b);
      //   //   doc.Root.SetAttributeValue(versionNameAttributeName, v2);
      //   //}
      //   //else
      //   {
      //      doc.Root.SetAttributeValue(versionCodeAttributeName, newVersion.Build);
      //      doc.Root.SetAttributeValue(versionNameAttributeName, newVersion.ToString());
      //   };

      //   doc.Save(filePath);
      //}
      //catch (Exception ex)
      //{
      //   Console.WriteLine($"FileProcessor_Droid.GetVersion {filePath} {ex.Message}");
      //   return "ko";
      //};

      return "ok";
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

}

