using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public class UtilityObject
    {
        public ISystemTimeManager SystemTimeManager { get; set; }
        public IExtensionManager ExtensionManager { get; set; }
    }
}
