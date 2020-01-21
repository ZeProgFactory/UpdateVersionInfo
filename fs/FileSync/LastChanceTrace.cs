using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Management;

namespace ZPF
{
	/// <summary>
	/// LastChanceTrace is a trace for any exceptions not caught elsewhere in the application.
   /// 
   /// 13/10/06 - ME  - Created
   /// 
   /// <para>© 2006 ZePocketForge.com.</para>
   /// <example>
   ///static void Main()
   ///{
   ///   Application.EnableVisualStyles();
   ///   Application.SetCompatibleTextRenderingDefault(false);
   /// 
   ///   Application.ThreadException += new System.Threading.ThreadExceptionEventHandler( LastChanceTrace.Application_ThreadException );
   ///   try
   ///   {
   ///      LastChanceTrace.Version        = DataModul.GetInstance().Version;
   ///      LastChanceTrace.BuildTimeStamp = new BuildTimeStamp().Get();
   /// 
   ///      Application.Run(new wMain());
   ///   }
   ///   catch (Exception ex)
   ///   {
   ///      LastChanceTrace.Application_ThreadException( null, new System.Threading.ThreadExceptionEventArgs(ex) );
   ///   }
   ///}
   /// </example>
   /// </summary>
   /// 
   public partial class wLastChanceTrace : Form
   {
      public wLastChanceTrace()
      {
         InitializeComponent();
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
       Close();
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
         //message.To.Add( "Support@ZePocketForge.com" );
         //message.Subject = "This is the Subject line";
         //message.From = new System.Net.Mail.MailAddress("LastChance@ZePocketForge.com");
         //message.Body = "This is the message body";
         //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("yoursmtphost");
         //smtp.U
         //smtp.Send(message);

      }

      static private string GetOSandServicepack()
      {
         OperatingSystem os = Environment.OSVersion;
         string osText = "";

         if( os.Version.Major == 5 )
         {
            switch( os.Version.Minor )
            {
               case 0: osText = "Windows 2000";
                  break;
               case 1: osText = "Windows XP";
                  break;
               case 2: osText = "Windows Server 2003";
                  break;
               default: osText = os.ToString();
                  break;
            }
         }
         else
         {
            if( os.Version.Major == 6 )
               osText = "Windows Vista";
            else
               osText = os.ToString();
         }

         string osVersion = os.VersionString;
         string spText = os.ServicePack;
         // parameterweise zurück ..

         return string.Format( "{0} , {1}", osText, spText );
      }

      static internal TStrings GetConfig( TStrings Log )
      {
         String Format = "{0,20} {1}";

         if( Log == null )
         {
            Log = new TStrings();
         };

         Log.Add( String.Format( Format, "OS", GetOSandServicepack() ) );
         Log.Add( "" );

         ManagementObjectSearcher query1 = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem") ;
         ManagementObjectCollection queryCollection1 = query1.Get();
         foreach( ManagementObject mo in queryCollection1 ) 
         {
            Log.Add( String.Format( Format, "Name", mo["name"].ToString()) );
            Log.Add( String.Format( Format, "Version", mo["version"].ToString()));
            Log.Add( "" );
            Log.Add( String.Format( Format, "Manufacturer", mo["Manufacturer"].ToString()));
            Log.Add( String.Format( Format, "Computer Name", mo["csname"].ToString()) );
            Log.Add( String.Format( Format, "Windows Directory", mo["WindowsDirectory"].ToString()) );
         }                  

         Log.Add( "" );

         query1 = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem") ;
         queryCollection1 = query1.Get();
         foreach( ManagementObject mo in queryCollection1 ) 
         {
            Log.Add( String.Format( Format, "Manufacturer", mo["manufacturer"].ToString()) );
            Log.Add( String.Format( Format, "Model", mo["model"].ToString()) );
            Log.Add( String.Format( Format, "", mo["systemtype"].ToString()) );
            Log.Add( String.Format( Format, "Total Physical Memory", mo["totalphysicalmemory"].ToString()) );
         }  

         query1 = new ManagementObjectSearcher("SELECT * FROM Win32_processor") ;
         queryCollection1 = query1.Get();
         foreach( ManagementObject mo in queryCollection1 ) 
         {
            Log.Add( String.Format( Format, "", mo["caption"].ToString()) );
         }                       

         Log.Add( "" );

         query1 = new ManagementObjectSearcher("SELECT * FROM Win32_bios") ;
         queryCollection1 = query1.Get();
         foreach( ManagementObject mo in queryCollection1 ) 
         {
            Log.Add( String.Format( Format, "", mo["version"].ToString()) );
         }                                   

         try
         {
            query1 = new ManagementObjectSearcher("SELECT * FROM Win32_timezone") ;
            queryCollection1 = query1.Get();
            foreach( ManagementObject mo in queryCollection1 ) 
            {
               Log.Add( String.Format( Format, "", mo["caption"].ToString()) );
            };
         }
         catch {};

         return Log;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         // 
         // saveFileDialog
         // 
         System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
         saveFileDialog.DefaultExt = "Log";
         saveFileDialog.Filter = "Log files|*.Log";
         saveFileDialog.Title = "Save to file";

         if ( saveFileDialog.ShowDialog() == DialogResult.OK )
         {
            String Format = "{0,20} {1}";
            TStrings Log = new TStrings();

            Log.Add( new String( '-', 80 ) );
            Log.Add( "" );

            Log.Add( String.Format( Format, "Who", System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString() ) );
            Log.Add( String.Format( Format, "Version", LastChanceTrace.Version  ) );
            Log.Add( String.Format( Format, "Internal build", Assembly.GetExecutingAssembly().GetName().Version.ToString()  ) );
            if( System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed )
            {
               System.Deployment.Application.ApplicationDeployment appDeploy;

               appDeploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;

               Log.Add( String.Format( Format, "ClickOnce V", appDeploy.CurrentVersion  ) );
            };

            Log.Add( String.Format( Format, "BuildTimeStamp", LastChanceTrace.BuildTimeStamp ) );
            Log.Add( String.Format( Format, "When", DateTime.Now.ToString() ) );
            Log.Add( String.Format( Format, "What", textBoxMessage.Text ) );
            Log.Add( String.Format( Format, "Type", textBoxType.Text ) );

            Log.Add( "" );
            Log.Add( new String( '-', 80 ) );
            Log.Add( "" );

            Log.Add( textBoxStack.Text );

            Log.Add( "" );
            Log.Add( new String( '-', 80 ) );

            try
            {
               Log.Add( "" );

               Log = GetConfig( Log );

               Log.Add( "" );
               Log.Add( new String( '-', 80 ) );
            }
            catch {};

            Log.SaveToFile( saveFileDialog.FileName );
         };
      }

      private void btnKill_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }
   }

   public class LastChanceTrace
   {
      public static string Version        = "";
      public static string BuildTimeStamp = "";

      public static void Show(object sender, System.Threading.ThreadExceptionEventArgs e)
      {
         wLastChanceTrace dlg = new wLastChanceTrace();

         dlg.textBoxMessage.Text = e.Exception.Message; 
         dlg.textBoxType.Text    = e.Exception.GetType().ToString();

         dlg.textBoxStack.Text   = e.Exception.StackTrace;
         if( e.Exception.InnerException != null )
         {
            dlg.textBoxStack.Text   += Basics.CRLF;
            dlg.textBoxStack.Text   += new String( '-', 80 ) + Basics.CRLF;
            dlg.textBoxStack.Text   += Basics.CRLF;
            dlg.textBoxStack.Text   += e.Exception.InnerException.StackTrace;
         };

         dlg.Text                = dlg.Text + " - " + e.Exception.Source;

         dlg.textBoxSystem.Text = wLastChanceTrace.GetConfig( null ).Text.Replace( "\n", "\r\n"); 

         dlg.ShowDialog();
      }

      /// <summary>
      /// Occurs when an untrapped thread exception is thrown.
      /// Handler for any exceptions not caught elsewhere in the application.
      /// </summary>
      /// <param name="sender">The source Application object for this event.</param>
      /// <param name="e">The System.Threading.ThreadExceptionEventArgs object that contains the event data.</param>
      public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
      {
         LastChanceTrace.Show( sender, e );
      }
   }
}