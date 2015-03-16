using LogAn.Utility;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Mock
{
    class MockLogFileChecker : ILogFileChecker
    {
        public string LogMessage = null;

        public DateTime Now = DateTime.MinValue;

        public IExtensionManager GetExtensionManager()
        {
            return MockRepository.GenerateStub<IExtensionManager>();            
        }

        public DateTime GetNow()
        {
            return Now;
        }

        public void RecordLog(string message)
        {
            LogMessage = message;
        }
    }
}
