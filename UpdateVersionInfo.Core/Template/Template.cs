﻿
public static class Template
{
   public static string Get = @"
// Updated by UpdateVersionInfo {2}. Please don't delete or modify.
//# {0}
//# {1}

using System;

namespace ZPF
{{
   public class VersionInfo : IVersionInfo
   {{
      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

      static VersionInfo _Current = null;

      public static VersionInfo Current
      {{
         get
         {{
            if (_Current == null)
            {{
               _Current = new VersionInfo();
            }};

            return _Current;
         }}

         set
         {{
            _Current = value;
         }}
      }}

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

      public string sVersion {{ get => ""{0}""; }}
      public Version Version {{ get => new Version(sVersion); }}

      public string BuildOn {{ get => DateTime.Now.ToString(""{1}""); }}
      public int RevisionNumber {{ get => Version.Revision; }}

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -
   }}
}}
";

}

