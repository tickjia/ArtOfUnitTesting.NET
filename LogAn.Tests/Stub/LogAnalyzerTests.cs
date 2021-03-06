﻿using LogAn.Utility;
using LogAn.Tests.Basecoat;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogAn.Tests.Utility;

namespace LogAn.Tests.Stub
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        LogAnalyzer analyzer = null;
        [SetUp]
        public void SetUp()
        {
            //用桩，解除文件系统的依赖
            var fakeManager = new StubExtensionManager();
            fakeManager.ShouldExtensionBeValid = true;
            analyzer = new LogAnalyzer(fakeManager);
        }

        [TearDown]
        public void TearDown()
        {
            analyzer = null;           
        }

        [Test]
        public void IsValidLogFileName_ValidFile_ReturnTrue()
        {
            bool result = analyzer.IsValidLogFileName("whatever.slf");
            Assert.IsTrue(result,"filename show be valid!");           
        }

        [Test]
        public void IsValidLogFileName_FileNameLowerCase_ReturnTrue()
        {
            Assert.IsTrue(analyzer.IsValidLogFileName("whatever.slf"),"LowerCase filename show be valid!");
        }

        [Test]
        public void IsValidLogFileName_FileNameUpperCase_ReturnTrue()
        {
            Assert.IsTrue(analyzer.IsValidLogFileName("whatever.SLF"),"Uppercase filename show be valid!");
        }

      
        [Test]
        public void IsValidLogFileName_validLowerName_RememberTrue()
        {
            analyzer.IsValidLogFileName("somefile.slf");
            Assert.IsTrue(analyzer.WasLastFileNameValid);
        }

        

    }
}
