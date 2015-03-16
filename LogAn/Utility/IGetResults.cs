using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public interface IGetResults
    {
        int GetSomeNumber(string key);
        string Version { get; }
        string CacheNumber { get; set; }
    }
}
