using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace UpdateVersionInfo;

public class FileProcessor_Nuget : IFileProcessor
{
   public string Name { get; set; } = "nupkg";

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public bool Check(string filePath)
   {
      bool IsOk = true;

      IsOk = IsOk && (filePath.ToLower().EndsWith(@".csproj"));
      IsOk = IsOk && SubCheck(filePath);

      return IsOk;
   }
   private bool SubCheck(string filePath)
   {
      try
      {
         var text = File.ReadAllText(filePath);

         return text.Contains("<IsPackable>True</IsPackable>");
      }
      catch (System.Xml.XmlException)
      {
      }
      catch (Exception ex)
      {
         Console.WriteLine($"FileProcessor_Nuget.Check {filePath} {ex.Message}");
      };

      return false;
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public Version GetVersion(string filePath)
   {
      XDocument doc = XDocument.Load(filePath);

      if (((System.Xml.Linq.XElement)doc.FirstNode).Name.LocalName == "Project")
      {
         {
            var n = doc.XPathSelectElement("Project/PropertyGroup/AssemblyVersion");
            if (n != null)
            {
               return new Version(n.Value);
            };
         }

         {
            var n = doc.XPathSelectElement("Project/PropertyGroup/FileVersion");
            if (n != null)
            {
               return new Version(n.Value);
            };
         }

         {
            var n = doc.XPathSelectElement("Project/PropertyGroup/Version");
            if (n != null)
            {
               return new Version(n.Value);
            };
         }

      }

      return new Version();
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public string Update(string filePath, Version newVersion)
   {
      XDocument doc = XDocument.Load(filePath);

      if (((System.Xml.Linq.XElement)doc.FirstNode).Name.LocalName == "Project")
      {
         var rootElement = doc.XPathSelectElement("Project/PropertyGroup");

         {
            var n = doc.XPathSelectElement("Project/PropertyGroup/AssemblyVersion");

            if (n == null)
            {
               rootElement.Add(new XElement("AssemblyVersion", newVersion.ToString()));
            }
            else
            {
               n.Value = newVersion.ToString();
            };
         }

         {
            var n = doc.XPathSelectElement("Project/PropertyGroup/FileVersion");

            if (n == null)
            {
               rootElement.Add(new XElement("FileVersion", newVersion.ToString()));
            }
            else
            {
               n.Value = newVersion.ToString();
            };
         }

         {
            var n = doc.XPathSelectElement("Project/PropertyGroup/Version");

            if (n == null)
            {
               rootElement.Add(new XElement("Version", newVersion.ToString()));
            }
            else
            {
               n.Value = newVersion.ToString();
            };
         }

         doc.Save(filePath);
      }

      return "ok";
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -
}

