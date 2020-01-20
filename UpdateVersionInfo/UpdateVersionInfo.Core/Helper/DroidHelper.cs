using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UpdateVersionInfo.Core
{
   public class DroidHelper
   {
      /// <summary>
      /// IsValidAndroidManifest
      /// </summary>
      /// <param name="path"></param>
      /// <returns></returns>
      public static bool IsValid(String path)
      {
         if (!File.Exists(path)) return false;
         if ((new FileInfo(path).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) return false;

         try
         {
            // <manifest ...
            XDocument doc = XDocument.Load(path);
            var rootElement = doc.Root as XElement;
            if (rootElement != null && rootElement.Name == "manifest") return true;
         }
         catch (Exception e)
         {
            System.Diagnostics.Trace.TraceError(e.Message);
         }

         return false;
      }

      /// <summary>
      /// UpdateAndroidVersionInfo
      /// </summary>
      /// <param name="path"></param>
      /// <param name="version"></param>
      public static void Update(string path, Version version)
      {
         const string androidNS = "http://schemas.android.com/apk/res/android";
         XName versionCodeAttributeName = XName.Get("versionCode", androidNS);
         XName versionNameAttributeName = XName.Get("versionName", androidNS);
         XDocument doc = XDocument.Load(path);

         if (MainViewModel.Current.AutoVersion)
         {
            string b = doc.Root.Attribute(versionCodeAttributeName).Value;
            string a = doc.Root.Attribute(versionNameAttributeName).Value;

            var v = a.Split(new char[] { '.' });

            string v2 = "";

            if (string.IsNullOrEmpty(MainViewModel.Current.sAutoVersion))
            {
               v2 = v[0] + "." + v[1] + "." + (v.Count() < 3 ? "0" : v[2]) + "." + (int.Parse((v.Count() < 4 ? "0" : v[3])) + 1).ToString();
            }
            else
            {
               v2 = MainViewModel.Current.sAutoVersion;
            };

            doc.Root.SetAttributeValue(versionCodeAttributeName, b);
            doc.Root.SetAttributeValue(versionNameAttributeName, v2);
         }
         else
         {
            doc.Root.SetAttributeValue(versionCodeAttributeName, version.Build);
            doc.Root.SetAttributeValue(versionNameAttributeName, version);
         };

         doc.Save(path);
      }
   }
}
