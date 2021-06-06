using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Cinema_App
{
    class MailSender
    {
        string Server = Settings.SMTPServer;
        string Username = Settings.SMTPUser;
        string Password = Settings.SMTPPass;
        int Port = 587;
        SmtpClient SmtpClient;

        public MailSender()
        {
            SmtpClient = new SmtpClient(Server)
            {
                Port = Port,
                Credentials = new NetworkCredential(Username, Password),
                EnableSsl = false,
            };
        }

        public void SendOrderMail(Order order, User user)
        {
            string body = Strings.ConfirmEmail;
            body = body.Replace("{{name}}", user.Name);
            body = body.Replace("{{user}}", user.Username);
            body = body.Replace("{{code}}", order.OrderId.ToString());

            var mailMessage = new MailMessage
            {
                From = new MailAddress(Username),
                Subject = "Cinema App - Your order has been placed!",
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(user.EmailAddress);

            SmtpClient.Send(mailMessage);
        }
    }
}
