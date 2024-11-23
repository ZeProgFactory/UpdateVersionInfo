using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateVersionInfo;

public class WorkFile
{
   public string FilePath { get; set; }
   public string ShortenedFilePath { get; set; }
   public IFileProcessor FileProcessor { get; set; }

   // - - -  - - - 

   public override string ToString()
   {
      return $"{System.IO.Path.GetFileName(FilePath)}";
   }
}
