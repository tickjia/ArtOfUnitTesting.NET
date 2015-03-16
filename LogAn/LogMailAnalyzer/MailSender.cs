using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LogAn.LogMailAnalyzer
{
    public class MailSender : IMailSender
    {
        public void SenderAMail(string title, string content)
        {
            MailMessage msg = new MailMessage();
            msg.Body = content;
            msg.Subject = title;
            msg.From = new MailAddress("sys@163.com");
            msg.To.Add(new MailAddress("admin@163.com"));
            SmtpClient client = new SmtpClient("smpt.163.com");
            client.Credentials = new NetworkCredential("test163@163.com", "testpwd");
            client.Send(msg);
        }
    }
}
