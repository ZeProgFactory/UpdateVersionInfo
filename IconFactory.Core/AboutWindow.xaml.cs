using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ZPF;

namespace IconFactory
{
   /// <summary>
   /// Interaction logic for AboutWindow.xaml
   /// </summary>
   public partial class AboutWindow : Window
   {
      //private string EmailAddress = "support@zpf.fr";
      //private string WebSiteUrl = "www.ZPF.fr";
      //private string Version = "1.000";
      public static string ResourceName = "IconFactory._History_.txt";

      public AboutWindow()
      {
         InitializeComponent();

         //lbVersion.Content = AnalyticsHelper.DeviceInfo.AV;

         using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName))
         using (StreamReader reader = new StreamReader(stream))
         {
            TStrings text = new TStrings();
            text.Text = reader.ReadToEnd();

            tbText.Inlines.Clear();
            for (int i = 0; i < text.Count; i++)
            {
               if (text[i].TrimStart().StartsWith("#"))
               {
                  tbText.Inlines.Add(new Run() { Text = text[i].TrimStart().Substring(1), FontWeight = FontWeights.Bold });
               }
               else if (text[i].TrimStart().StartsWith("!"))
               {
                  tbText.Inlines.Add(new Run() { Text = text[i].TrimStart().Substring(1), FontWeight = FontWeights.Bold, Foreground = Brushes.Red });
               }
               else
               {
                  tbText.Inlines.Add(text[i]);
               };
            };
         };
      }

      private void Label_Web(object sender, object e)
      {
         System.Diagnostics.Process process = new System.Diagnostics.Process();
         process.StartInfo.FileName = "http://www.ZPF.fr";
         process.Start();
      }

      private void Label_Support(object sender, object e)
      {
         System.Diagnostics.Process process = new System.Diagnostics.Process();
         process.StartInfo.FileName = "mailto:support@ZPF.fr?subject=CRVisites";
         process.Start();
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         DialogResult = true;
      }

      private void SendTrace_Click(object sender, RoutedEventArgs e)
      {
   //      //Send Trace
   //      System.Net.Mail.MailMessage Mail = new System.Net.Mail.MailMessage();

   //      System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.Gloups.Name");
   //      SmtpServer.Credentials = new System.Net.NetworkCredential("EuroGold@Gloups.Name", "MossIsTheBoss");
   //      SmtpServer.Port = 25;

   //      Mail.From = new MailAddress("ZPF@Gloups.Name" );
   //      Mail.To.Add("Support@ZPF.fr");
   //      Mail.Subject = "Panic mail from CRVisites - " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
   //      Mail.Body = Mail.Subject + " Version : " + lbVersion.Content;

   //      System.Net.Mail.Attachment Attachment = new System.Net.Mail.Attachment(@AuditTrail.FileName);

   //      Mail.Attachments.Add(Attachment);
			 
			//SmtpServer.Send(Mail); 

   //      //Clear Audit Trail file
   //      AuditTrail.Clear();

   //      DialogResult = true;
      }
   }
}
