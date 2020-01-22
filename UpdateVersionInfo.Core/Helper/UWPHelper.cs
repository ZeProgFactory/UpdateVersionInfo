using System;
using System.IO;
using System.Text.RegularExpressions;

namespace UpdateVersionInfo.Core
{
   public class UWPHelper
   {
      public static String LastMessage = "";

      static String AssemblyFileVersionExpression = @"^\s*\[assembly:\s*(?<attribute>(?:System\.)?(?:Reflection\.)?AssemblyFileVersion(?:Attribute)?\s*\(\s*""(?<version>[^""]+)""\s*\)\s*)\s*\]\s*$";
      static String AssemblyVersionExpression = @"^\s*\[assembly:\s*(?<attribute>(?:System\.)?(?:Reflection\.)?AssemblyVersion(?:Attribute)?\s*\(\s*""(?<version>[^""]+)""\s*\)\s*)\s*\]\s*$";
      static readonly Regex assemblyVersionRegEx = new Regex(AssemblyVersionExpression, RegexOptions.Multiline | RegexOptions.Compiled);
      static readonly Regex assemblyFileVersionRegEx = new Regex(AssemblyFileVersionExpression, RegexOptions.Multiline | RegexOptions.Compiled);

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

         try
         {
            String contents;
            using (var reader = new StreamReader(path))
            {
               contents = reader.ReadToEnd();
            }

            if (assemblyVersionRegEx.IsMatch(contents))
            {
               return true;
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
         LastMessage = "";

         String contents = System.IO.File.ReadAllText(path);
         LastMessage = assemblyVersionRegEx.Matches(contents)[0].Value.Replace("[assembly: System.Reflection.AssemblyVersion(\"", "").Replace("\")]", "");

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

         String contents = System.IO.File.ReadAllText(path);

         if (MainViewModel.Current.AutoVersion)
         {
            //string b = doc.Root.Attribute(versionCodeAttributeName).Value;
            //string a = doc.Root.Attribute(versionNameAttributeName).Value;

            //var v = a.Split(new char[] { '.' });

            //string v2 = v[0] + "." + v[1] + "." + v[2] + "." + (int.Parse(v[3]) + 1).ToString();

            //doc.Root.SetAttributeValue(versionCodeAttributeName, b);
            //doc.Root.SetAttributeValue(versionNameAttributeName, v2);

            string v1 = assemblyVersionRegEx.Matches(contents)[0].Value.Replace("[assembly: System.Reflection.AssemblyVersion(\"", "").Replace("\")]", "");
            string v2 = MainViewModel.Current.IncVersion(v1);
            MainViewModel.Current.sAutoVersionV2 = v2;

            contents = assemblyVersionRegEx.Replace(contents, "[assembly: System.Reflection.AssemblyVersion(\"" + v2 + "\")]");

            if (assemblyFileVersionRegEx.IsMatch(contents))
            {
               contents = assemblyFileVersionRegEx.Replace(contents, "[assembly: System.Reflection.AssemblyFileVersion(\"" + v2 + "\")]");

               LastMessage = $"{v1} --> {v2}";
            }
         }
         else
         {
            contents = assemblyVersionRegEx.Replace(contents, "[assembly: System.Reflection.AssemblyVersion(\"" + version.ToString() + "\")]");

            if (assemblyFileVersionRegEx.IsMatch(contents))
            {
               contents = assemblyFileVersionRegEx.Replace(contents, "[assembly: System.Reflection.AssemblyFileVersion(\"" + version.ToString() + "\")]");

               //LastMessage = $"{st} --> {version.ToString()}";
               LastMessage = $"--> {version.ToString()}";
            }
         };

         using (StreamWriter writer = new StreamWriter(path, false))
         {
            writer.Write(contents);
         }
      }
   }
}
