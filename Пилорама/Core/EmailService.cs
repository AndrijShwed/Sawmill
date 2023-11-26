using MimeKit;
using System.Net;
using System.Net.Mail;

namespace Пилорама.Core
{
    public class EmailService
    {
        string from = "sawmill3011@gmail.com";
        string password = "pbdd akvh ehvr ltjk";

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
                smtpClient.Send(message);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
