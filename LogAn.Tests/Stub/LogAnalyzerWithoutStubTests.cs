using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Stub
{
    [TestFixture]
    public class LogAnalyzerWithoutStubTests
    {
        LogAnalyzerWithoutStubTestSubstitute analyzer = null;

        [SetUp]
        public void SetUp()
        {
            analyzer = new LogAnalyzerWithoutStubTestSubstitute();
        }
        public void TearDown()
        {
            analyzer = null;
        }

        [Test]
        [ExpectedException(typeof(System.IO.DirectoryNotFoundException),ExpectedMessage = "File not found!")]
        public void SaveFile_FileNotExists_ReturnTrue()
        {
            string fileName = "text.slf";
            analyzer.FileNameOK = true;
            analyzer.WriteException = new System.IO.DirectoryNotFoundException("File not found!");
            analyzer.SaveFile(fileName);
        }

    }
}
