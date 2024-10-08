using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Windows.Forms;

namespace Site_Yönetim_Sistemi.AfetYonetimi
{
    public static class MailYardimcisi
    {
        //smpt settings
        private static readonly string smtpServer = "-----";
        private static readonly int smtpPort = 587;
        private static readonly bool enableSsl = true;
        private static readonly string smtpUsername = "-------";
        private static readonly string smtpPassword = "-------";
        private static readonly List<string> toEmails = new List<string> 
        {
            "guvnrdvan@gmail.com",
            "ibrahim.ozturk1502@gmail.com"
        };
        public static void Gonder(string subject, string body, bool isBodyHtml = false)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(smtpUsername);
                    foreach(var toEmail in toEmails)
                    {
                        mail.To.Add(toEmail);
                    }
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = isBodyHtml;

                    using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtp.EnableSsl = enableSsl;
                        smtp.Send(mail);
                        MessageBox.Show("Mail gönderildi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Hata işleme kodu (örneğin, loglama)
                Console.WriteLine("Mail gönderilirken hata oluştu: " + ex.Message);
            }
        }
    }
}
