using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZPF;

namespace FileSync
{
   static class Program
   {
      /// <summary>
      /// Point d'entrée principal de l'application.
      /// </summary>
      [STAThread]
      static int Main( string[] args )
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault( false );

         Application.ThreadException += new System.Threading.ThreadExceptionEventHandler( LastChanceTrace.Application_ThreadException );
         try
         {
            LastChanceTrace.Version        = ZPF.ProjectInfo.ProductVersion();
            LastChanceTrace.BuildTimeStamp = ZPF.ProjectInfo.BuildTimeStamp();

            Application.Run( new wMain( args ) );
         }
         catch( Exception ex )
         {
            LastChanceTrace.Application_ThreadException( null, new System.Threading.ThreadExceptionEventArgs( ex ) );
         }

         return 0;
      }
   }
}