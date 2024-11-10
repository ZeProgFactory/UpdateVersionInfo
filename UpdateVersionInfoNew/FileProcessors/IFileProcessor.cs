using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateVersionInfo;

public interface IFileProcessor
{
   string Name { get; set; }

   public bool Check(string file);

   public Version GetVersion(string filePath);
   public string Update(string filePath, Version newVersion);
}


