using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateVersionInfo
{
   public class Version
   {
      public Version() { }

      public Version(string version)
      {
         version = version.Trim();

         var vl = _Version.Split(new char[] { '.' }).Length;

         if (vl == 3 || vl == 4)
         {
            _Version = version;
         };
      }

      // - - -  - - - 

      #region - - - Major . Minor . Build . Revision - - -

      /// <summary>
      /// The value of the major component of the version number (Major.Minor.Build.Revision)
      /// </summary>
      public int Major
      {
         get
         {
            try
            {
               var vl = _Version.Split(new char[] { '.' });
               return int.Parse(vl[0]);
            }
            catch
            {
               return 0;
            };
         }

         set
         {
            var vl = _Version.Split(new char[] { '.' });

            if (vl.Length == 3)
            {
               _Version = $"{value}.{Minor}.{Build}";
            }
            else
            {
               _Version = $"{value}.{Minor}.{Build}.{Revision}";
            };
         }
      }

      /// <summary>
      /// The value of the minor component of the version number (Major.Minor.Build.Revision)
      /// </summary>
      public int Minor
      {
         get
         {
            try
            {
               var vl = _Version.Split(new char[] { '.' });
               return int.Parse(vl[1]);
            }
            catch
            {
               return 0;
            };
         }

         set
         {
            var vl = _Version.Split(new char[] { '.' });

            if (vl.Length == 3)
            {
               _Version = $"{Major}.{value}.{Build}";
            }
            else
            {
               _Version = $"{Major}.{value}.{Build}.{Revision}";
            };
         }
      }

      /// <summary>
      /// The value of the build component of the version number (Major.Minor.Build.Revision)
      /// </summary>
      public int? Build
      {
         get
         {
            try
            {
               var vl = _Version.Split(new char[] { '.' });
               return int.Parse(vl[2]);
            }
            catch
            {
               return 0;
            };
         }

         set
         {
            var vl = _Version.Split(new char[] { '.' });

            if (vl.Length == 3)
            {
               _Version = $"{Major}.{Minor}.{value}";
            }
            else
            {
               _Version = $"{Major}.{Minor}.{value}.{Revision}";
            };
         }
      }

      /// <summary>
      /// The value of the revision component of the version number (Major.Minor.Build.Revision)
      /// </summary>
      public int? Revision
      {
         get
         {
            try
            {
               var vl = _Version.Split(new char[] { '.' });
               return int.Parse(vl[3]);
            }
            catch
            {
               return 0;
            };
         }

         set
         {
            var vl = _Version.Split(new char[] { '.' });

            if (vl.Length == 3)
            {
               _Version = $"{Major}.{Minor}.{Build}";
            }
            else
            {
               _Version = $"{Major}.{Minor}.{Build}.{value}";
            };
         }
      }

      #endregion

      // - - -  - - - 

      string _Version = "0.0.0";

      // - - -  - - - 

      public void IncVersion()
      {
         var vl = _Version.Split(new char[] { '.' });

         if (vl.Length == 3)
         {
            Build++;
            _Version = $"{Major}.{Minor}.{Build}";
         }
         else
         {
            Revision++;
            _Version = $"{Major}.{Minor}.{Build}.{Revision}";
         };
      }

      // - - -  - - - 

      public override string ToString()
      {
         return _Version;
      }
   }
}
