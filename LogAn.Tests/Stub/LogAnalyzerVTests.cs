using LogAn.Utility;
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
    public class LogAnalyzerVTests : LogAnalyzerV
    {
        protected override IExtensionManager GetExtensionManager()
        {
            var stub =new StubExtensionManager();
            stub.ShouldExtensionBeValid = true;
            return stub;
        }

        [Test]
        public void IsValidLogFileName_ValidFile_ReturnTrue()
        {
            bool result = this.IsValidLogFileName("whatever.slf");
            Assert.IsTrue(result,"filename show be valid!");           
        }

        [Test]
        public void IsValidLogFileName_FileNameLowerCase_ReturnTrue()
        {
            Assert.IsTrue(this.IsValidLogFileName("whatever.slf"),"LowerCase filename show be valid!");
        }

        [Test]
        public void IsValidLogFileName_FileNameUpperCase_ReturnTrue()
        {
            Assert.IsTrue(this.IsValidLogFileName("whatever.SLF"),"Uppercase filename show be valid!");
        }
        

    }
}
