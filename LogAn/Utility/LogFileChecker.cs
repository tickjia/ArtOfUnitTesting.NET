using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public class LogFileChecker : ILogFileChecker
    {
        SystemTimeManager mgr = new SystemTimeManager();
        IExtensionManager extesionMgr = new FileExtensionManager();
        public IExtensionManager GetExtensionManager()
        {
            return extesionMgr;
        }

        public DateTime GetNow()
        {
            return mgr.GetNow();
        }

        public void RecordLog(string message)
        {
            mgr.AddLog(message);
        }
    }
}
