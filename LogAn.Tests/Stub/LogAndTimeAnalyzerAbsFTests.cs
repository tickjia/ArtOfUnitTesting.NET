using LogAn.Tests.Utility;
using LogAn.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Stub
{
    [TestFixture]
    public class LogAndTimeAnalyzerAbsFTests
    {
        LogAndTimeAnalyzerF analyzer = null;
        [SetUp]
        public void SetUp()
        {
            Factories.ManagerFactory = new StubManagerFactory();
            analyzer = new LogAndTimeAnalyzerF();
        }

        [TearDown]
        public void TearDown()
        {
            analyzer = null;
            
        }
        [Test]
        public void IsValid_LowerCaseFileName_ReturnTrue()
        {
            Assert.IsTrue(analyzer.IsValid("Test.slf"), "valid extension file name!");
        }

        [Test]
        public void MoreThanChineseTime_NowPassOneMinute_ReturnTrue()
        {
            Assert.IsTrue(analyzer.MoreThanChineseTime(DateTime.Now.AddMinutes(1)), "More than chinese time!");
        }

        [Test]
        public void MoreThanAmericanTime_Now_ReturnTrue()
        {
            Assert.IsTrue(analyzer.MoreThanAmericanTime(DateTime.Now), "More than americal time!");
        }

    }
}
