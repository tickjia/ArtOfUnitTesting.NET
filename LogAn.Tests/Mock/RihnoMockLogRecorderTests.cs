using LogAn.Utility;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Mock
{
    [TestFixture]
    public class RihnoMockLogRecorderTests
    {
        [Test]
        public void IsValid_FileNameLessLength_SaveToLogger()
        {
            MockRepository mocks = new MockRepository();
            ILogFileChecker checker = mocks.StrictMock<ILogFileChecker>();
            using (mocks.Record())
            {
                checker.RecordLog("b.lsf:file extension error or the length of file name is less 6!");
            }
            LogRecorder recorder = new LogRecorder(checker);
            recorder.IsValid("b.lsf");//有Record()录掉没有预置(且要用using) 或 record预置预期不对时，这里异常
            mocks.Verify(checker);//没有Record()或没有using时这里异常
        }

        [Test]
        public void Save_FileNameLessLength_SaveLoggerAndRetureFalse()
        {
            MockRepository mocks = new MockRepository();
            ILogFileChecker checker = mocks.StrictMock<ILogFileChecker>();
            LogRecorder recorder = new LogRecorder(checker);
            bool result=recorder.Save("b.lsf", "This a Message");            
            Assert.IsFalse(result, "less filename and can not save!");
        }

        [Test]
        public void IsValid_FileNameLessLengthUnStrick_SaveToLogger()
        {
            MockRepository mocks = new MockRepository();
            ILogFileChecker checker = mocks.DynamicMock<ILogFileChecker>();
            using (mocks.Record())
            {
                checker.RecordLog("c.lsf:file extension error or the length of file name is less 6!");
            }
            LogRecorder recorder = new LogRecorder(checker);
            recorder.IsValid("b.lsf"); //如果为非严格模拟对象，调用正常进行，还出现异常
            //mocks.VerifyAll();
           // mocks.Verify(checker);//非严格模拟对象，只有在Verify时，对未达到预期时才出现异常
        }

    }
}
