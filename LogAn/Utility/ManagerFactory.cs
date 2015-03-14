using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public class ManagerFactory : IManagerFactory
    {
         IExtensionManager _extManager=null;
         ISystemTimeManager _timeManager = null;

        public void SetExtensionManager(IExtensionManager mgr) { _extManager = mgr; }
        public void SetSystemTimeManager(ISystemTimeManager mgr) { _timeManager = mgr; }
        public IExtensionManager CreateExtensionManager()
        {
            if (_extManager != null) return _extManager;
            return new FileExtensionManager();
        }
        public ISystemTimeManager CreateSystemTimeManager()
        {
            if (_timeManager != null) return _timeManager;
            return new SystemTimeManager();
        }

    }
}
