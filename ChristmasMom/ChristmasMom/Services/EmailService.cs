using ChristmasMom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ChristmasMom.Services
{
    public class EmailService
    {
        public void SendMail(EmailModel model)
        {
            MailMessage Message = new MailMessage();
            Message.Subject = "some subject";
            Message.Body = "some message";
            Message.IsBodyHtml = true;
            Message.From = new MailAddress("someAddress@mail.com");
            Message.To.Add(new MailAddress(model.Address));


            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new NetworkCredential("user", "pass")
            };
            client.Send(Message);
        }
    }
}
