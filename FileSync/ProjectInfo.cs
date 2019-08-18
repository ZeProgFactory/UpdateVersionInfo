using System;
using System.Runtime.InteropServices;

namespace ZPF
{
   /// <summary>
   /// <para>© ZePocketForge.com.</para>
   /// </summary>
   
   class ProjectInfo
   {
      private const string _BuildTimeStamp = "20/09/2012 20:12:13";
      private const string _ProductVersion = "1.0.79";

      /// <summary>
      /// Retrieves the current product version 
      /// </summary>
      
      public static string ProductVersion( ) 
      {
         return _ProductVersion;
      }
      
      /// <summary>
      /// Retrieves the current build timestamp as string 
      /// </summary>
      
      public static string BuildTimeStamp( ) 
      {
         return _BuildTimeStamp;
      }
   }
}
