using MakeMyTrip.BrowserFactory;
using System;
using System.Net;
using System.Net.Mail;

namespace MakeMyTrip.Email
{
    public class SendEmailMain
    {
        public static Credentials credentials = new Credentials();
        public static void SendEmail(String Subject, String contentBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                String fromEmail = credentials.email;
                String password = credentials.sendPassword;
                String ToEmail = credentials.recEmail;
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(ToEmail);
                mail.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
                mail.Body = contentBody;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\Users\Kis\source\repos\MakeMyTrip\MakeMyTrip\Report\index.html"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (BrowserFactoryException exception)
            {
                throw new BrowserFactoryException("Mail cant be send", BrowserFactoryException.ExceptionType.MAIL_NOT_SEND);
            }
        }
    }
}