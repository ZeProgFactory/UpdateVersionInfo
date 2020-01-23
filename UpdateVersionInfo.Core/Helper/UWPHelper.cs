using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using CSharpVerbalExpressions;

namespace UpdateVersionInfo.Core
{
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

         try
         {
            String contents = System.IO.File.ReadAllText(path);

            var verbEx = new VerbalExpressions()
                     .Anything()
                     .StartOfLine()
                     .Then("[assembly:")
                     .Anything()
                     .Then("AssemblyVersion(\"")
                     .Anything()
                     .Then("\")]")
                     .EndOfLine()
                     .Anything();

            if (verbEx.IsMatch(contents))
            {
               return true;
            };
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

         //var verbEx = new VerbalExpressions()
         //      .Anything()
         //      .StartOfLine(true)
         //      .Then("[assembly:")
         //      .Anything()
         //      .Then("AssemblyVersion(\"")
         //      .Anything()
         //      .Then("\")]")
         //      .EndOfLine()
         //      .Anything()
         //      ;

         // ^(.*)(\[assembly:)(.*)(AssemblyVersion\(")(.*)("\)])(.*)$
         //  (.*)  --> false

         //var verbEx = new VerbalExpressions()
         //      .StartOfLine(true)
         //      .Then("[assembly:")
         //      .Anything()
         //      .Then("AssemblyVersion(\"")
         //      .Anything()
         //      .Then("\")]")
         //      .EndOfLine()
         //      ;
         // OK but not on csharp

         var verbEx = new VerbalExpressions()
               .Then("\n")
               //.AnythingBut("\\")
               .Then("[assembly:")
               .Anything()
               .Then("AssemblyVersion(\"")
               .AnythingBut("\"")
               .Then("\")]")
               ;

         var x = verbEx.IsMatch(contents);
         Debug.WriteLine(x.ToString());

         var regex = verbEx.ToRegex();
         var m = regex.Match(contents);

         Debug.WriteLine(m.ToString());
         LastMessage = regex.Matches(contents)[0].Value;
         LastMessage = LastMessage.Replace("\n[assembly: AssemblyVersion(\"", "").Replace("\")]", "");

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

         var verbEx = new VerbalExpressions()
               .Then("\n")
               //.AnythingBut("\\")
               .Then("[assembly:")
               .Anything()
               .Then("AssemblyVersion(\"")
               .AnythingBut("\"")
               .Then("\")]")
               ;

         var regex = verbEx.ToRegex();

         string v1 = regex.Matches(contents)[0].Value.Replace("\n[assembly: AssemblyVersion(\"", "").Replace("\")]", "");

         if (MainViewModel.Current.AutoVersion)
         {
            string v2 = MainViewModel.Current.IncVersion(v1);
            MainViewModel.Current.sAutoVersionV2 = v2;

            //contents = assemblyVersionRegEx.Replace(contents, "[assembly: System.Reflection.AssemblyVersion(\"" + v2 + "\")]");
            contents = contents.Replace(v1, v2);
            LastMessage = $"{v1} --> {v2}";
         }
         else
         {
            string v2 = version.ToString();

            contents = contents.Replace(v1, v2);
            LastMessage = $"{v1} --> {v2}";
         };

         using (StreamWriter writer = new StreamWriter(path, false))
         {
            writer.Write(contents);
         }
      }
   }
}
