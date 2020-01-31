using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
//using CSharpVerbalExpressions;

namespace UpdateVersionInfo.Core
{
   // Package.appxmanifest
   // (AssemblyInfo.cs)
   //
   // https://docs.microsoft.com/en-us/windows/uwp/publish/package-version-numbering?redirectedfrom=MSDN#version-numbering-for-windows10-packages
   // For Windows 10 (UWP) packages, the last (fourth) section of the version number is reserved for Store use 
   // and must be left as 0 when you build your package (although the Store may change the value in this section). 
   // The other sections must be set to an integer between 0 and 65535 (except for the first section, which cannot be 0).
   //
   // Major.Minor.Build.0


   public class UWPHelper
   {
      public static String LastMessage = "";

      // VerbalExpressions-netstandard16
      // https://github.com/VerbalExpressions/CSharpVerbalExpressions
      // https://www.nuget.org/packages/VerbalExpressions-official/

      /// <summary>
      /// IsValidCSharpVersionFile
      /// </summary>
      /// <param name="path"></param>
      /// <returns></returns>
      public static bool IsValid(String path)
      {
         LastMessage = "";

         if (!File.Exists(path)) return false;
         if ((new FileInfo(path).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) return false;

         if (path.ToLower().EndsWith(@"\assemblyinfo.cs"))
         {
            //String contents = System.IO.File.ReadAllText(path);

            //try
            //{
            //   var verbEx = new VerbalExpressions()
            //            .Anything()
            //            .StartOfLine()
            //            .Then("[assembly:")
            //            .Anything()
            //            .Then("AssemblyVersion(\"")
            //            .Anything()
            //            .Then("\")]")
            //            .EndOfLine()
            //            .Anything();

            //   if (verbEx.IsMatch(contents))
            //   {
            //      return true;
            //   };
            //}
            //catch (Exception e)
            //{
            //   System.Diagnostics.Trace.TraceError(e.Message);
            //}
         };

         if (path.ToLower().EndsWith(@"\package.appxmanifest"))
         {
            XDocument doc = XDocument.Load(path);
            var rootElement = doc.Root as XElement;
            if (rootElement != null && rootElement.Name.LocalName == "Package") return true;
         };

         return false;
      }

      public static Version GetVersion(string path)
      {
         LastMessage = "";

         if (!File.Exists(path)) return null;

         if (path.ToLower().EndsWith(@"\assemblyinfo.cs"))
         {
            //String contents = System.IO.File.ReadAllText(path);

            ////var verbEx = new VerbalExpressions()
            ////      .Anything()
            ////      .StartOfLine(true)
            ////      .Then("[assembly:")
            ////      .Anything()
            ////      .Then("AssemblyVersion(\"")
            ////      .Anything()
            ////      .Then("\")]")
            ////      .EndOfLine()
            ////      .Anything()
            ////      ;

            //// ^(.*)(\[assembly:)(.*)(AssemblyVersion\(")(.*)("\)])(.*)$
            ////  (.*)  --> false

            ////var verbEx = new VerbalExpressions()
            ////      .StartOfLine(true)
            ////      .Then("[assembly:")
            ////      .Anything()
            ////      .Then("AssemblyVersion(\"")
            ////      .Anything()
            ////      .Then("\")]")
            ////      .EndOfLine()
            ////      ;
            //// OK but not on csharp

            //var verbEx = new VerbalExpressions()
            //      .Then("\n")
            //      //.AnythingBut("\\")
            //      .Then("[assembly:")
            //      .Anything()
            //      .Then("AssemblyVersion(\"")
            //      .AnythingBut("\"")
            //      .Then("\")]")
            //      ;

            //var x = verbEx.IsMatch(contents);
            //Debug.WriteLine(x.ToString());

            //var regex = verbEx.ToRegex();
            //var m = regex.Match(contents);

            //Debug.WriteLine(m.ToString());
            //LastMessage = regex.Matches(contents)[0].Value;
            //LastMessage = LastMessage.Replace("\n[assembly: System.Reflection.AssemblyVersion(\"", "").Replace("\n[assembly: AssemblyVersion(\"", "").Replace("\")]", "");
         };

         if (path.ToLower().EndsWith(@"\package.appxmanifest"))
         {
            XDocument doc = XDocument.Load(path);
            var rootElement = doc.Root as XElement;
            if (rootElement != null && rootElement.Name.LocalName == "Package")
            {
               LastMessage = (rootElement.FirstNode as XElement).Attribute("Version").Value.ToString();
            };
         };

         return new Version(LastMessage);
      }

      /// <summary>
      /// UpdateCSVersionInfo
      /// </summary>
      /// <param name="path"></param>
      /// <param name="version"></param>
      public static void Update(string path, Version version)
      {
         LastMessage = "";

         if (path.ToLower().EndsWith(@"\assemblyinfo.cs"))
         {
            //String contents = System.IO.File.ReadAllText(path);

            //var verbEx = new VerbalExpressions()
            //      .Then("\n")
            //      //.AnythingBut("\\")
            //      .Then("[assembly:")
            //      .Anything()
            //      .Then("AssemblyVersion(\"")
            //      .AnythingBut("\"")
            //      .Then("\")]")
            //      ;

            //var regex = verbEx.ToRegex();

            //string v1 = regex.Matches(contents)[0].Value.Replace("\n[assembly: System.Reflection.AssemblyVersion(\"", "").Replace("\n[assembly: AssemblyVersion(\"", "").Replace("\")]", "");

            //if (MainViewModel.Current.AutoVersion)
            //{
            //   string v2 = MainViewModel.Current.IncVersion(v1);

            //   if (!string.IsNullOrEmpty(MainViewModel.Current.sAutoVersionV2))
            //   {
            //      v2 = MainViewModel.Current.sAutoVersionV2;
            //   };

            //   //contents = assemblyVersionRegEx.Replace(contents, "[assembly: System.Reflection.AssemblyVersion(\"" + v2 + "\")]");
            //   contents = contents.Replace(v1, v2);
            //   LastMessage = $"{v1} --> {v2}";
            //}
            //else
            //{
            //   string v2 = version.ToString();

            //   contents = contents.Replace(v1, v2);
            //   LastMessage = $"{v1} --> {v2}";
            //};

            //using (StreamWriter writer = new StreamWriter(path, false))
            //{
            //   writer.Write(contents);
            //}
         }

         if (path.ToLower().EndsWith(@"\package.appxmanifest"))
         {
            XDocument doc = XDocument.Load(path);
            var rootElement = doc.Root as XElement;
            if (rootElement != null && rootElement.Name.LocalName == "Package")
            {
               string v1 = (rootElement.FirstNode as XElement).Attribute("Version").Value.ToString();

               if (MainViewModel.Current.AutoVersion)
               {
                  string v2 = MainViewModel.Current.IncVersion(v1);

                  if (!string.IsNullOrEmpty(MainViewModel.Current.sAutoVersionV2))
                  {
                     v2 = MainViewModel.Current.sAutoVersionV2;
                  };

                  var v = new Version(v2);
                  v2 = $"{v.Major}.{v.Minor}.{v.Build}.0";

                  (rootElement.FirstNode as XElement).Attribute("Version").Value = v2;
                  doc.Save(path);

                  LastMessage = $"{v1} --> {v2}";
               }
               else
               {
                  string v2 = $"{version.Major}.{version.Minor}.{version.Build}.0";

                  (rootElement.FirstNode as XElement).Attribute("Version").Value = v2;
                  doc.Save(path);

                  LastMessage = $"{v1} --> {v2}";
               };
            };
         };
      }
   }
}
