using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogAn.Utility;
using LogAn.Tests.Utility;

namespace LogAn.Tests.Stub
{
    class TestableLogAnalyzerV : LogAnalyzerV
    {
        protected override IExtensionManager GetExtensionManager()
        {
            var stub = new StubExtensionManager();
            stub.ShouldExtensionBeValid = true;
            return stub;
        }
    }
}
