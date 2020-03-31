using System;

namespace UpdateVersionInfo.Core
{
   public class _VI_Helper
   {
      public static String LastMessage = "";

      public static Version GetVersion(string path)
      {
         if (MainViewModel.Current.Debug) Console.WriteLine($"_VI_Helper.GetVersion( {path} )");
         LastMessage = "0.1.0.0";

         string text = System.IO.File.ReadAllText(path);
         text = text.Trim(new char[] { '\r', '\n' });
         var lines = text.Split(new char[] { '\n' });

         if (lines.Length > 3 && lines[0].Contains("UpdateVersionInfo"))
         {
            LastMessage = lines[1].Trim().Substring(4);
         };

         return new Version(LastMessage);
      }

      public static Version Update(string path)
      {
         if (MainViewModel.Current.Debug) Console.WriteLine($"_VI_Helper.Update( {path} )");
         LastMessage = "0.1.0.0";

         string text = System.IO.File.ReadAllText(path);
         text = text.Trim(new char[] { '\r', '\n' });
         var lines = text.Split(new char[] { '\n' });

         if (lines.Length > 3 && lines[0].Contains("UpdateVersionInfo"))
         {
            string v1 = lines[1].Trim().Substring(4);
            string v2 = MainViewModel.Current.IncVersion(v1);

            // - - -

            string temp = Template.Get;

            System.IO.File.WriteAllText(path,
               string.Format(temp, v2, DateTime.Now.ToString("dd.MM.yyyy"), MainViewModel.Current.UpdateVersionInfoVersion));

            // - - -

            LastMessage = $"{v1} --> {v2}";

            if (MainViewModel.Current.AutoVersion)
            {
               MainViewModel.Current.sAutoVersionV2 = v2;
            };

            return new Version(v2);
         };

         return new Version(LastMessage);
      }
   }
}
