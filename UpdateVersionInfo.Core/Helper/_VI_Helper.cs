using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateVersionInfo.Core
{
   public class _VI_Helper
   {
      public static String LastMessage = "";

      public static Version GetVersion(string path)
      {
         LastMessage = "0.1.0.0";

         string text = System.IO.File.ReadAllText(path);
         var lines = text.Split(new char[] { '\n' });

         if (lines.Length > 3 && lines[0].Contains("UpdateVersionInfo"))
         {
            LastMessage = lines[1].Trim().Substring(4);
         };

         return new Version(LastMessage);
      }
   }
}
