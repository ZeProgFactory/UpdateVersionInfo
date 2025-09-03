using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace UpdateVersionInfo;

// Requires the following NuGet package: Microsoft.CodeAnalysis.CSharp.Scripting
// https://itnext.io/getting-start-with-roslyn-c-scripting-api-d2ea10338d2b
// https://www.daveaglick.com/posts/compiler-platform-scripting

public static class ScriptHelper
{
   public static async void Run(string scriptFileName)
   {
      //string code = "int x = 10; int y = 20; x + y;";

      var code = System.IO.File.ReadAllText(scriptFileName);

      Console.WriteLine(code);
      Console.WriteLine();
      Console.WriteLine(typeof(object).Assembly.Location);
      Console.WriteLine(typeof(File).Assembly.Location);
      Console.WriteLine(System.AppContext.BaseDirectory);
      Console.WriteLine();
      try
      {
         //var options = ScriptOptions.Default
         //    .AddReferences(typeof(System.IO.File).Assembly)
         //    .AddImports("System", "System.IO");

         var options = ScriptOptions.Default
             .AddReferences(
                 MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                 MetadataReference.CreateFromFile(typeof(File).Assembly.Location)
             )
             .AddImports("System", "System.IO");

         var result = await CSharpScript.EvaluateAsync(code, options);
         Console.WriteLine(result);
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.ToString());
      }

      try
      {
         // D:\GitWare\Apps\UpdateVersionInfo\UpdateVersionInfoMaui\ScriptHelper.cs(...):
         // warning IL3000: 'System.Reflection.Assembly.Location.get' always returns an empty string
         // for assemblies embedded in a single-file app. If the path to the app directory is needed,
         // consider calling 'System.AppContext.BaseDirectory'.


         //var options = ScriptOptions.Default
         //    .AddReferences(typeof(System.IO.File).Assembly)
         //    .AddImports("System", "System.IO");

         var options = ScriptOptions.Default
             .AddReferences(
                 MetadataReference.CreateFromFile(System.AppContext.BaseDirectory+ @"\System.Private.CoreLib.dll")
             )
             .AddImports("System", "System.IO");

         var result = await CSharpScript.EvaluateAsync(code, options);
         Console.WriteLine(result);
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.ToString());
      }
   }
}
