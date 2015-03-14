using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LogAn
{
    public class LogAndTimeAnalyzerF
    {
        IExtensionManager _extManager =null;
        ISystemTimeManager _timeManager = null;

        public LogAndTimeAnalyzerF()
        {            
            _extManager = Factories.ManagerFactory.CreateExtensionManager();
            _timeManager = Factories.ManagerFactory.CreateSystemTimeManager();
        }

        public bool MoreThanChineseTime(DateTime dateTime)
        {
            return dateTime > _timeManager.GetChineseTime();
        }

        public bool MoreThanAmericanTime(DateTime dateTime)
        {
            return dateTime > _timeManager.GetAmericanTime();
        }

        public bool IsValid(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filename provided!");
            }
            if (!_extManager.IsValid(fileName))
            {
                return false;
            }           
            return true;
        }
    }
}
