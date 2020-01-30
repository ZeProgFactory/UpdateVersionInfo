﻿
public static class Template
{
   public static string Get = @"
// Generated by UpdateVersionInfo {2}
//# {0}
//# {1}

using System;

namespace ZPF
{{
   public static class VersionInfo
   {{
      public static string sVersion {{ get => ""{0}""; }}
      public static Version Version {{ get => new Version(sVersion); }}

      public static string BuildOn {{ get => DateTime.Now.ToString(""{1}""); }}
      public static int RevisionNumber {{ get => Version.Revision; }}
   }}
}}
";

}

