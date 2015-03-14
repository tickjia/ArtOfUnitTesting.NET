using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Utility
{
    public class StubExtensionManager : IExtensionManager
    {
        public bool ShouldExtensionBeValid;
        public bool IsValid(string fileName)
        {
            return ShouldExtensionBeValid;

        }
    }
}
