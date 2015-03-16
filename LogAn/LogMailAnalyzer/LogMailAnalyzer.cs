using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace LogAn.LogMailAnalyzer
{
    public class LogMailAnalyzer
    {
        IMailSender _mailSender = new MailSender();
        IWebService _webService = new WebService();
        public LogMailAnalyzer() { }
        
        [Conditional("DEBUG")]
        public void SetMailSender(IMailSender sender)
        {
            this._mailSender = sender;
        }

        [Conditional("DEBUG")]
        public void SetWebService(IWebService service)
        {
            this._webService = service;
        }
     
        public DateTime GetServerTime()
        {
            return _webService.GetTime();
        }

        public void TestServerOnLine()
        {
            try
            {
                _webService.GetTime();
            }
            catch(Exception ex)
            {
                try
                {
                    _mailSender.SenderAMail("Web Service Error", ex.Message);
                }
                catch(Exception ex1)
                {
                    throw new SmtpException("Send Mail Error:"+ex1.Message);
                }
            }
        }

    }
}
