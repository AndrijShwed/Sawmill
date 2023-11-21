using System.Net;
using System.Net.Mail;

namespace Пилорама
{

    public class EmailService 
    {

        private const string from = "sawmill3011@gmail.com";
        private const string password = "fxkh gnyp vzkm nfrh";



        private bool SendEmailAsync(string email, string subject, string confirmlink)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                message.From = new MailAddress(from);
                message.To.Add(email);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = confirmlink;

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
