using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UpdateVersionInfo.Core
{
   //  .vdproj
   //
   //
   //
   // "ProductVersion" = "8:1.0.0"
   //
   // major.minor.build[.revision]


   public class DeployProjectHelper
   {
      public static String LastMessage = "";

      /// <summary>
      /// IsValidAndroidManifest
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
            string text = System.IO.File.ReadAllText(path);
            text = text.Trim(new char[] { '\r', '\n' });
            var lines = text.Split(new char[] { '\n' });
            if (lines[0].Contains("DeployProject")) return true;
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

         try
         {
            string text = System.IO.File.ReadAllText(path);
            text = text.Trim(new char[] { '\r', '\n' });
            var lines = text.Split(new char[] { '\n' });

            for (int i = 0; i < lines.Length; i++)
            {
               if (lines[i].Contains("ProductVersion"))
               {
                  var st = lines[i];

                  st = st.Substring(st.IndexOf("\"8:") + 3);
                  st = st.TrimEnd(new char[] { '"', '\r', '\n' });

                  LastMessage = st;
                  return new Version(LastMessage);
               };
            };

         }
         catch (Exception e)
         {
            System.Diagnostics.Trace.TraceError(e.Message);
         }

         return new Version(LastMessage);
      }

      /// <summary>
      /// UpdateAndroidVersionInfo
      /// </summary>
      /// <param name="path"></param>
      /// <param name="version"></param>
      public static void Update(string path, Version version)
      {
         LastMessage = "";

         try
         {
            string text = System.IO.File.ReadAllText(path);
            text = text.Trim(new char[] { '\r', '\n' });
            var lines = text.Split(new char[] { '\n' });

            for (int i = 0; i < lines.Length; i++)
            {
               if (lines[i].Contains("ProductVersion"))
               {
                  var st = lines[i];

                  st = st.Substring(st.IndexOf("\"8:") + 3);
                  st = st.TrimEnd(new char[] { '"', '\r', '\n' });

                  string v1 = st;

                  if (MainViewModel.Current.AutoVersion)
                  {
                     string v2 = MainViewModel.Current.IncVersion(v1);

                     if (!string.IsNullOrEmpty(MainViewModel.Current.sAutoVersionV2))
                     {
                        v2 = MainViewModel.Current.sAutoVersionV2;
                     };

                     var v = new Version(v2);
                     v2 = $"{v.Major}.{v.Minor}.{v.Build}";

                     var old = lines[i].Trim(new char[] { ' ', '\r', '\n' });
                     lines[i] = lines[i].Replace(v1, v2).Trim(new char[] { ' ', '\r', '\n' });

                     text = text.Replace(old, lines[i]);
                     System.IO.File.WriteAllText(path, text);

                     LastMessage = $"{v1} --> {v2}";
                  }
                  else
                  {
                     string v2 = $"{version.Major}.{version.Minor}.{version.Build}";

                     var old = lines[i].Trim(new char[] { ' ', '\r', '\n' });
                     lines[i] = lines[i].Replace(v1, v2).Trim(new char[] { ' ', '\r', '\n' });

                     text = text.Replace(old, lines[i]);
                     System.IO.File.WriteAllText(path, text);

                     LastMessage = $"{v1} --> {v2}";
                  };

               };
            };

         }
         catch (Exception e)
         {
            System.Diagnostics.Trace.TraceError(e.Message);
         }
      }

   }
}
