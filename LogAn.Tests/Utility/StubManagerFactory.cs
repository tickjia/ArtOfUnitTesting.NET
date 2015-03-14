using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Utility
{
    public class StubManagerFactory : IManagerFactory
    {
        public IExtensionManager CreateExtensionManager()
        {
            var fakeExtManager = new StubExtensionManager();
            fakeExtManager.ShouldExtensionBeValid = true;
            return fakeExtManager;

        }

        public ISystemTimeManager CreateSystemTimeManager()
        {            
            var fakeSystemTimeManager = new StubSystemTimeManager();
            DateTime dt = DateTime.Now;
            fakeSystemTimeManager.AmericanTime = dt.AddHours(-14);
            fakeSystemTimeManager.ChineseTime = dt;
            fakeSystemTimeManager.NowTime = dt;
            return fakeSystemTimeManager;
        }
    }
}
