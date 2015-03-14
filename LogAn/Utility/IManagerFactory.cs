using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public interface IManagerFactory
    {
        IExtensionManager CreateExtensionManager();
        ISystemTimeManager CreateSystemTimeManager();
    }
}
