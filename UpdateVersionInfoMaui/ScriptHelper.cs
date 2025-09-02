using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace UpdateVersionInfo;

// Requires the following NuGet package: Microsoft.CodeAnalysis.CSharp.Scripting
// https://itnext.io/getting-start-with-roslyn-c-scripting-api-d2ea10338d2b

public static class ScriptHelper
{
   public static async void Run(string scriptFileName)
   {
      //string code = "int x = 10; int y = 20; x + y;";

      string code =
@"
var txt = System.IO.File.ReadAllText(""D:\GitWare\Apps\ZeCalculator\ZeCalculator.Maui9\LastUpdate.Win.json"");
";

      //code = System.IO.File.ReadAllText(scriptFileName);

      await CSharpScript.EvaluateAsync(code);
   }
}
