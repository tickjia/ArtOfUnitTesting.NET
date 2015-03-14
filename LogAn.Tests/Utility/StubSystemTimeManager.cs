using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Utility
{
    internal class StubSystemTimeManager : ISystemTimeManager
    {
        public DateTime AmericanTime = DateTime.Now.AddHours(-14), ChineseTime = DateTime.Now, NowTime = DateTime.Now;

        public DateTime GetAmericanTime()
        {
            return AmericanTime;
        }

        public DateTime GetChineseTime()
        {
            return ChineseTime;
        }

        public DateTime GetNow()
        {
            return NowTime;
        }
    }

}
