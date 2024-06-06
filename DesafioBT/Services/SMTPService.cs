using DesafioBT.Model;
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
        public void SendEmail(bool compra, AlphaServiceResponse response) 
        {
            MailMessage mail = MakeStructure(compra, response);

            try {

                using (SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtpAdress"], int.Parse(ConfigurationManager.AppSettings["portNumber"])))
                {
                    smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailFrom"], ConfigurationManager.AppSettings["password"]);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    Console.WriteLine("Emails enviado com sucesso!");
                }
            }
            catch (Exception err) 
            {
                throw new Exception(err.ToString());
            }
        }

        private MailMessage MakeStructure(bool compra, AlphaServiceResponse serviceResponse)
        {
            MailMessage mailMessage = new MailMessage();
            string textBody = compra ? " entrou em baixa e este é um momento excelente para considerar a compra!" : " entrou em alta e este é um momento excelente para considerar a venda!";
            string textTitle = compra ? "Compra!" : "Venda!";

            mailMessage.Subject = compra ? $"Ativo {serviceResponse.Ativo} em baixa!" : $"Ativo {serviceResponse.Ativo} em alta!"; 

            mailMessage.Body = $@"
              <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Oportunidade de {textTitle}</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f4f4f4;
                        }}
                        .email-container {{
                            max-width: 600px;
                            margin: 20px auto;
                            background-color: #ffffff;
                            padding: 20px;
                            border-radius: 5px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }}
                        .header {{
                            background-color: #dc3545;
                            color: #ffffff;
                            padding: 10px;
                            text-align: center;
                            border-radius: 5px 5px 0 0;
                        }}
                        .content {{
                            padding: 20px;
                        }}
                        .footer {{
                            background-color: #f4f4f4;
                            color: #888888;
                            padding: 10px;
                            text-align: center;
                            font-size: 12px;
                            border-radius: 0 0 5px 5px;
                        }}
                        a {{
                            color: #007BFF;
                            text-decoration: none;
                        }}
                        a:hover {{
                            text-decoration: underline;
                        }}
                    </style>
                </head>
                <body>
                    <div class='email-container'>
                        <div class='header'>
                            <h1>Aviso de Oportunidade de Venda</h1>
                        </div>
                        <div class='content'>
                            <p>Prezado(a),</p>
                            <p>Gostaríamos de informar que o ativo <strong>{serviceResponse.Ativo}</strong>{textBody}</p>
                            <h2>Detalhes do Ativo</h2>
                            <p><strong>Valor Inicial:</strong> {serviceResponse.Open}</p>
                            <p><strong>Valor Final:</strong> {serviceResponse.Close}</p>
                            <p><strong>Horário:</strong> {serviceResponse.Date}</p>

                            <p>Atenciosamente,</p>
                            <p>Inoa Services</p>
                        </div>
                        <div class='footer'>
                          <br><br>
                          <p><strong>OBS:</strong> Caso você não queira mais receber esse tipo de mensagem, por favor entre em contato conosco pelo email: 
                            <a href=""mailto:inoaservicesdesafio@gmail.com"">inoaservicesdesafio@gmail.com</a>
                          </p>
                        </div>
                    </div>
                </body>
                </html> ";

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
