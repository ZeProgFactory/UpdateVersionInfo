using System;
using System.IO;
using System.Xml.Linq;

namespace UpdateVersionInfo;

public class FileProcessor_UAP : IFileProcessor
{
   public string Name { get; set; } = "UAP  ";

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public bool Check(string filePath)
   {
      bool IsOk = true;

      IsOk = IsOk && (filePath.ToLower().EndsWith("package.appxmanifest"));
      IsOk = IsOk && (!filePath.ToLower().Contains(@"\obj\"));
      IsOk = IsOk && (!filePath.ToLower().Contains(@"/obj/"));
      IsOk = IsOk && SubCheck(filePath);

      return IsOk;
   }

   private bool SubCheck(string filePath)
   {
      try
      {
         XDocument doc = XDocument.Load(filePath);
         var rootElement = doc.Root as XElement;
         if (rootElement != null && rootElement.Name.LocalName == "Package") return true;
      }
      catch (System.Xml.XmlException)
      {
      }
      catch (Exception ex)
      {
         Console.WriteLine($"FileProcessor_UAP.Check {filePath} {ex.Message}");
      };

      return false;
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public Version GetVersion(string filePath)
   {
      var version = "";

      try
      {
         XDocument doc = XDocument.Load(filePath);
         var rootElement = doc.Root as XElement;
         if (rootElement != null && rootElement.Name.LocalName == "Package")
         {
            var v = new System.Version( (rootElement.FirstNode as XElement).Attribute("Version").Value );
            version = $"{v.Major}.{v.Minor}.{v.Build}";
         };
      }
      catch (Exception ex)
      {
         Console.WriteLine($"FileProcessor_UAP.GetVersion {filePath} {ex.Message}");

         version = ex.Message;
         return new Version();
      };

      return new Version(version);
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public string Update(string filePath, Version newVersion)
   {
      XDocument doc = XDocument.Load(filePath);
      var rootElement = doc.Root as XElement;

      if (rootElement != null && rootElement.Name.LocalName == "Package")
      {
         string v1 = (rootElement.FirstNode as XElement).Attribute("Version").Value.ToString();

         //if (MainViewModel.Current.AutoVersion)
         //{
         //   string v2 = MainViewModel.Current.IncVersion(v1);

         //   if (!string.IsNullOrEmpty(MainViewModel.Current.sAutoVersionV2))
         //   {
         //      v2 = MainViewModel.Current.sAutoVersionV2;
         //   };

         //   var v = new Version(v2);
         //   v2 = $"{v.Major}.{v.Minor}.{v.Build}.0";

         //   (rootElement.FirstNode as XElement).Attribute("Version").Value = v2;
         //   doc.Save(filePath);

         //   LastMessage = $"{v1} --> {v2}";
         //}
         //else
         {
            string v2 = $"{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}.0";

            (rootElement.FirstNode as XElement).Attribute("Version").Value = v2;
            doc.Save(filePath);
         };
      };

      return "ok";
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

}

