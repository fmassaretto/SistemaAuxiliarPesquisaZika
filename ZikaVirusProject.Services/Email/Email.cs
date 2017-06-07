using System;
using System.Net;
using System.Net.Mail;

namespace ZikaVirusProject.Services.Email
{
    public class Email
    {
        private const string _sender = "fmassaretto@outlook.com";
        private const string _password = "1zxB6o@#";

        public void SendEmail(string emailTo, string subject, string message)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            var credentials =
                new NetworkCredential(_sender, _password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage(_sender.Trim(), emailTo.Trim());
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }   
    }
}
