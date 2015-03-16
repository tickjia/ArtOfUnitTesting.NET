using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Mock
{
    [TestFixture]
    public class LogRecorderTests
    {
        [Test]
        public void IsValid_FileNameLessLength_SaveToLogger()
        {
            var logFileChecker = new MockLogFileChecker();
            LogRecorder recorder = new LogRecorder(logFileChecker);
            recorder.IsValid("a.lsf");
            Assert.AreEqual("a.lsf:file extension error or the length of file name is less 6!", logFileChecker.LogMessage);

        }

        [Test]
        public void Save_FileNameLessLength_SaveLoggerAndRetureFalse()
        {
            LogRecorder recorder = new LogRecorder(new MockLogFileChecker());
            bool result=recorder.Save("b.lsf", "This a Message");            
            Assert.IsFalse(result, "less filename and can not save!");
        }

    }
}
