using System.Net;
using System.Net.Mail;

namespace Sawmill.Core
{

    public class EmailService
    {
        string from = "sawmill3011@gmail.com";
        string to = "a_shwed@ukr.net";
        string password = "rrdr fjsh eofp raic";

        public async Task<bool> SendEmailAsync(string email, string subject, string confirmlink)
        {
            try
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress(from);
                message.To.Add(email);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = confirmlink;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(from, password);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
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
                MailMessage message = new MailMessage();

                message.From = new MailAddress(from);
                message.To.Add(to);
                message.Subject = "Поступило нове замовлення від: ";
                message.IsBodyHtml = true;
                message.Body = client;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(from, password);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
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
                MailMessage message = new MailMessage();

                message.From = new MailAddress(from);
                message.To.Add(email);
                message.Subject = "Ваше замовлення пиломатеріалів №  " + order;
                message.IsBodyHtml = true;
                message.Body = answer;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(from, password);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
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

