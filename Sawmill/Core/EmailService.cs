using Humanizer;
using System.Net;
using System.Net.Mail;

namespace Sawmill.Core
{

    public class EmailService
    {
       
        static readonly EmailStrings e = new();
        static readonly string from = e.From;
        static readonly string to = e.To;
        static readonly string password = e.Password;
        static readonly string emailServ = e.Client;
        static readonly int port = int.Parse(e.Port);

        readonly SmtpClient smtpClient = new(emailServ, port)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(from, password),
            DeliveryMethod = SmtpDeliveryMethod.Network
        };

        public async Task<bool> SendEmailAsync(string email, string subject, string confirmlink)
        {
            try
            {
                MailMessage message = new()
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = confirmlink
                };
                message.To.Add(email);
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
                MailMessage message = new()
                {
                    From = new MailAddress(from),
                    Subject = "Поступило нове замовлення від: ",
                    IsBodyHtml = true,
                    Body = client
                };
                message.To.Add(to);

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
                MailMessage message = new()
                {
                    From = new MailAddress(from),
                    Subject = "Ваше замовлення пиломатеріалів №  " + order,
                    IsBodyHtml = true,
                    Body = answer
                };
                message.To.Add(email);

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

