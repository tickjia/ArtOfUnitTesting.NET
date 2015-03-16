using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public interface ILogFileChecker
    {
        void RecordLog(string message);
        DateTime GetNow();
        IExtensionManager GetExtensionManager();
    }
}
