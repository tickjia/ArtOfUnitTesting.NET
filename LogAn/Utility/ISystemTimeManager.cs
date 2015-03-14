using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public interface ISystemTimeManager
    {
        DateTime GetChineseTime();
        DateTime GetAmericanTime();

        DateTime GetNow();
    }
}
