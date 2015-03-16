using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.LogMailAnalyzer
{
    public interface IMailSender
    {
        void SenderAMail(string title,string content);
    }
}
