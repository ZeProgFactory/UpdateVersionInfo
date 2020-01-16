using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZPF
{
   public class ProjectTool
   {
      class TFiles
      {
         public string sourceFile { get; set; }
         public string targetFile { get; set; }
      };

      class TGuid
      {
         public string Old { get; set; }
         public string New { get; set; }
      };

      static void LogLine(string Text)
      {
         Debug.WriteLine(Text);
      }

      private static System.Threading.EventWaitHandle waitHandle = new System.Threading.AutoResetEvent(false);

      public static void DoIt(
         string sourceProject = "XFTestPlatformes",
         string sourcePath = @"D:\SoftWare2\MyProjects\XFTestPlatformes",

         string targetProject = "MSBuildSdkExtrasTest",
         string targetPath = @"D:\SoftWare2\MyProjects\MSBuildSdkExtrasTest")
      {
         Task task = Task.Run(() => DoIt_sub(sourceProject, sourcePath, targetProject, targetPath));
         waitHandle.WaitOne();

         //ToDo: Progressbar or other feedback on progress ...
         MessageBox.Show("Copy and rename solution terminated.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
      }

      static void DoIt_sub(
         string sourceProject = "XFTestPlatformes",
         string sourcePath = @"D:\SoftWare2\MyProjects\XFTestPlatformes",

         string targetProject = "MSBuildSdkExtrasTest",
         string targetPath = @"D:\SoftWare2\MyProjects\MSBuildSdkExtrasTest")
      {
         List<TFiles> files = new List<TFiles>();

         // - - - clean target - - - 

         LogLine("clean target ...");

         {
            var tmpFiles = System.IO.Directory.EnumerateFiles(targetPath, "*.*", System.IO.SearchOption.AllDirectories);

            foreach (var f in tmpFiles)
            {
               try
               {
                  System.IO.File.Delete(f);
               }
               catch { };
            };
         };

         // - - -  - - - 

         LogLine("Analyse files ...");

         {
            bool IsOK(string path)
            {
               path = path.ToUpper();

               if (path.Contains(@"\BIN\")) return false;
               if (path.Contains(@"\OBJ\")) return false;
               if (path.Contains(@"\.VS\")) return false;

               if (path.Contains(@"\PACKAGES\")) return false; // ???
               if (path.Contains(@"\.GIT\")) return false; // ???

               if (path.EndsWith(".USER")) return false;

               return true;
            };

            var tmpFiles = System.IO.Directory.EnumerateFiles(sourcePath, "*", System.IO.SearchOption.AllDirectories);

            LogLine($"# all files {tmpFiles.Count()}");

            tmpFiles = tmpFiles.Where(x => IsOK(x)).ToList();

            LogLine($"# clean files {tmpFiles.Count()}");

            foreach (var f in tmpFiles)
            {
               string st = f;
               st = st.Replace(sourcePath, targetPath);
               st = st.Replace(sourceProject, targetProject);

               files.Add(new TFiles { sourceFile = f, targetFile = st });
            };
         };

         // - - -  - - - 

         LogLine("Copy files ...");

         List<TGuid> guids = new List<TGuid>();

         {
            foreach (var f in files)
            {
               try
               {
                  var directory = System.IO.Path.GetDirectoryName(f.targetFile);

                  if (!Directory.Exists(directory))
                  {
                     Directory.CreateDirectory(directory);
                  };

                  System.IO.File.Copy(f.sourceFile, f.targetFile, true);

                  // - - - update textes - - - 

                  if (".sln.csproj.cs.plist.xml.xaml.appxmanifest.".Contains(System.IO.Path.GetExtension(f.targetFile).ToLower() + "."))
                  {
                     if (f.targetFile == @"D:\SoftWare2\Syscall\Test\Syscall\Syscall.MacOS\Syscall.MacOS.csproj")
                     {

                     };

                     var encoding = GetEncoding(f.targetFile);
                     var text = File.ReadAllText(f.targetFile);
                     text = text.Replace(sourceProject, targetProject);
                     File.WriteAllText(f.targetFile, text, encoding);
                  };

                  // - - -  update project GUIDs - - - 

                  if (System.IO.Path.GetExtension(f.targetFile).Length > 0 && ".csproj.".Contains(System.IO.Path.GetExtension(f.targetFile).ToLower() + "."))
                  {
                     var encoding = GetEncoding(f.targetFile);
                     var text = File.ReadAllText(f.targetFile);

                     if (text.IndexOf("<ProjectGuid>") > -1)
                     {
                        var oldGuid = text.Substring(text.IndexOf("<ProjectGuid>") + 13, 38);
                        var newGuid = "{" + Guid.NewGuid().ToString().ToUpper() + "}";

                        guids.Add(new TGuid { Old = oldGuid, New = newGuid });

                        text = text.Replace(oldGuid, newGuid);

                        File.WriteAllText(f.targetFile, text, encoding);
                     };
                  };

                  // - - -  - - - 

                  System.IO.File.SetAttributes(f.targetFile, System.IO.File.GetAttributes(f.sourceFile));

                  System.IO.File.SetCreationTime(f.targetFile, System.IO.File.GetCreationTime(f.sourceFile));
                  System.IO.File.SetLastAccessTime(f.targetFile, System.IO.File.GetCreationTime(f.sourceFile));
                  System.IO.File.SetLastWriteTime(f.targetFile, System.IO.File.GetCreationTime(f.sourceFile));
               }
               catch (Exception ex)
               {
                  Debug.WriteLine(ex.Message);
               }
            };
         };

         // - - -  update GUIDs in files - - - 

         {
            bool IsOK(string path)
            {
               path = path.ToLower();

               if (path.EndsWith(".sln")) return true;
               if (path.EndsWith(".csproj")) return true;
               if (path.EndsWith(".appxmanifest")) return true;
               if (path.EndsWith(".xml")) return true;
               if (path.EndsWith(".vdproj")) return true;

               return false;
            };

            files = files.Where(x => IsOK(x.targetFile)).ToList();

            foreach (var f in files)
            {
               try
               {
                  bool DitIt = false;
                  var encoding = GetEncoding(f.targetFile);
                  var text = File.ReadAllText(f.targetFile);

                  foreach (var g in guids)
                  {
                     if (text.IndexOf(g.Old) > -1)
                     {
                        text = text.Replace(g.Old, g.New);
                        DitIt = true;
                     };
                  };

                  if (DitIt)
                  {
                     File.WriteAllText(f.targetFile, text, encoding);
                     Debug.WriteLine($"UpdateWithGUIDs {f.targetFile}");
                  };
               }
               catch (Exception ex)
               {
                  Debug.WriteLine(ex.Message);
               }
            };
         };

         // - - -  - - - 

         waitHandle.Set();
      }

      /// <summary>
      /// Determines a text file's encoding by analyzing its byte order mark (BOM).
      /// Defaults to ASCII when detection of the text file's endianness fails.
      /// </summary>
      /// <param name="filename">The text file to analyze.</param>
      /// <returns>The detected encoding.</returns>
      public static Encoding GetEncoding(string filename)
      {
         // Read the BOM
         var bom = new byte[4];
         using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
         {
            file.Read(bom, 0, 4);
         }

         // Analyze the BOM
         if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
         if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
         if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
         if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
         if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
         return Encoding.ASCII;
      }
   }
}
