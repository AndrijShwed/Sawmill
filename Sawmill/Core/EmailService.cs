using System.Net;
using System.Net.Mail;

namespace Sawmill.Core
{

    public class EmailService
    {
        static EmailStrings e = new();
        string from = e.From;
        string to = e.To;
        string password = e.Password;
        string emailServ = e.Client;
        int port = int.Parse(e.Port);

        public async Task<bool> SendEmailAsync(string email, string subject, string confirmlink)
        {
            try
            {
                MailMessage message = new();

                message.From = new MailAddress(from);
                message.To.Add(email);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = confirmlink;

                SmtpClient smtpClient = new(emailServ, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> SendEmailAsync_Order(string client)
        {
            try
            {
                MailMessage message = new();

                message.From = new MailAddress(from);
                message.To.Add(to);
                message.Subject = "Поступило нове замовлення від: ";
                message.IsBodyHtml = true;
                message.Body = client;

                SmtpClient smtpClient = new(emailServ, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendEmailAsync_Answer(string email, int order, string answer)
        {
            try
            {
                MailMessage message = new();

                message.From = new MailAddress(from);
                message.To.Add(email);
                message.Subject = "Ваше замовлення пиломатеріалів №  " + order;
                message.IsBodyHtml = true;
                message.Body = answer;

                SmtpClient smtpClient = new(emailServ, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
   

}

