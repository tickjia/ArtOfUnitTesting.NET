using LogAn.LogMailAnalyzer;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.LogMailAnalyzer
{
    [TestFixture]
    public class LogMailAnalyzerTests
    {
        LogAn.LogMailAnalyzer.LogMailAnalyzer _analyzer = null;
        MockRepository _mockRepo = null;
        [SetUp]
        public void SetUp()
        {
            _mockRepo = new MockRepository();
            _analyzer = new LogAn.LogMailAnalyzer.LogMailAnalyzer();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepo = null;
            _analyzer = null;
        }


        [Test]
        public void GetServerTime_GetTime_NoException()
        {
            IWebService service = _mockRepo.Stub<IWebService>();
            DateTime dt = DateTime.Now;
            using (_mockRepo.Record())
            {
                service.GetTime();
                LastCall.Return(dt);
            }
            _analyzer.SetMailSender(_mockRepo.Stub<IMailSender>());
            _analyzer.SetWebService(service);
            var result = _analyzer.GetServerTime();
            Assert.AreEqual(dt, result);
        }

        [Test]
        public void TestServerOnLine_NoConnect_RecieveAMail()
        {
            IMailSender sender = _mockRepo.StrictMock<IMailSender>();
            IWebService webService = _mockRepo.Stub<IWebService>();
            _analyzer.SetMailSender(sender);
            _analyzer.SetWebService(webService);
            using (_mockRepo.Record())
            {
                webService.GetTime();               
                LastCall.Throw(new Exception("my error"));
                sender.SenderAMail("Web Service Error",string.Empty);//异常内容可能不相同，用下面的约束忽略第二个参数
                LastCall.Constraints(Rhino.Mocks.Constraints.Is.Equal("Web Service Error"), Rhino.Mocks.Constraints.Is.Anything());
            }
            _analyzer.TestServerOnLine();
            _mockRepo.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(System.Net.Mail.SmtpException),ExpectedMessage ="Send Mail Error:test")]
        public void TestServerOnLine_NoConnectNoMail_GetAException()
        {
            IMailSender sender = _mockRepo.Stub<IMailSender>();
            IWebService webService = _mockRepo.Stub<IWebService>();
            _analyzer.SetMailSender(sender);
            _analyzer.SetWebService(webService);
            using (_mockRepo.Record())
            {
                webService.GetTime();
                LastCall.Throw(new Exception(string.Empty));
                sender.SenderAMail(string.Empty, string.Empty);//不考虑邮件的内容
                LastCall.Constraints(Rhino.Mocks.Constraints.Is.Anything(), Rhino.Mocks.Constraints.Is.Anything());                
                LastCall.Throw(new Exception("test"));                
            }
            _analyzer.TestServerOnLine();
            _mockRepo.VerifyAll();
        }

    }
}
