using System.Net.Mail;

namespace ZikaVirusProject.Services.Email
{
    public class Email
    {
        public Email()
        {
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("seu email", "sua senha")
            };
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("email que vai enviar", "Remetente");
            mail.From = new MailAddress("de quem", "Remetente");
            mail.To.Add(new MailAddress("paraquem", "Destinatario"));
            mail.Subject = "Assunto";
            mail.Body = " Mensagem";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }
        }
    }
}
