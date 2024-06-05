using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;


namespace DesafioBT.Services
{
    public class SMTPService
    {
        public bool SendEmail(bool compra) 
        {
            MailMessage mail = MakeStructure(compra);

            try {

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Credentials = new NetworkCredential();
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    Console.WriteLine($"Emails enviado com sucesso!");
                }
            }
            catch (Exception err) 
            {
                throw new Exception(err.ToString());
            }
            return true;
        }

        private MailMessage MakeStructure(bool compra)
        {
            MailMessage mailMessage = new MailMessage();

            if (compra) 
            {
                mailMessage.Subject = ConfigurationManager.AppSettings["subjectUp"];
                mailMessage.Body = ConfigurationManager.AppSettings["bodyUp"];    
            } else {
                mailMessage.Subject = ConfigurationManager.AppSettings["subjectDown"];
                mailMessage.Body = ConfigurationManager.AppSettings["bodyDown"];
            }
            
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["emailFrom"]);
            mailMessage.IsBodyHtml = true;

            foreach (string email in GetEmails()) {
                mailMessage.To.Add(email);
            }

            return mailMessage;
        }

        private List<String> GetEmails()
        {
            string emailsCsv = ConfigurationManager.AppSettings["emailsTo"];
            List<string> emailsTo = emailsCsv.Split(',').ToList();
            return emailsTo;
        }
    }
}
