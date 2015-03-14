using LogAn.Tests.Basecoat;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        LogAnalyzer analyzer = null;
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Function test start!");
            analyzer = new LogAnalyzer();
        }

        [TearDown]
        public void TearDown()
        {
            analyzer = null;
            Console.WriteLine("Function test end!");
        }

        [Test]
        [Category("正式测试")]
        public void IsValidLogFileName_ValidFile_ReturnTrue()
        {
            bool result = analyzer.IsValidLogFileName("whatever.slf");
            Assert.IsTrue(result,"filename show be valid!");           
        }

        [Test]
        [Category("正式测试")]
        public void IsValidLogFileName_FileNameLowerCase_ReturnTrue()
        {
            Assert.IsTrue(analyzer.IsValidLogFileName("whatever.slf"),"LowerCase filename show be valid!");
        }

        [Test]
        [Category("正式测试")]
        public void IsValidLogFileName_FileNameUpperCase_ReturnTrue()
        {
            Assert.IsTrue(analyzer.IsValidLogFileName("whatever.SLF"),"Uppercase filename show be valid!");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException),ExpectedMessage ="No filename provided!")]
        public void IsValidLogFileName_EmptyFileName_Exception()
        {
            analyzer.IsValidLogFileName(string.Empty);
        }

        [Test]
        public void IsValidLogFileName_validLowerName_RememberTrue()
        {
            analyzer.IsValidLogFileName("somefile.slf");
            Assert.IsTrue(analyzer.WasLastFileNameValid);
        }


        [Test]
        [Ignore("这是一个尝试指令的测试")]
        [Category("练习型")]
        public void TryCommand()
        {
            TestObject objA = new TestObject("1");
            TestObject objB = new TestObject("2");
            Assert.AreEqual(objA, objB, " value is equal!");
            Assert.AreSame(objA, objB);

        }
    }
}
