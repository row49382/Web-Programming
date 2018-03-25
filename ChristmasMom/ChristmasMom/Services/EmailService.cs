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
            Message.Subject = "Christmas Email For Mom";
            Message.Body = "Hey Mom!<br /><br />I thought you would appreciate some creativity :). You will find your gift at the following location: <a href='https://anokahennepin.cr3.rschooltoday.com/public/costoption/class_id/26756/public/1/sp/'>Click me!</a><br/><br/> Merry Christmas! <br />Love Bobby";
            Message.IsBodyHtml = true;
            Message.From = new MailAddress("rwroblew610@gmail.com");
            Message.To.Add(new MailAddress(model.Address));


            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new NetworkCredential("rwroblew610", "Jesus610!")
            };
            client.Send(Message);
        }
    }
}
