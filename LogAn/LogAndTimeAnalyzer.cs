using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace LogAn
{
    public class LogAndTimeAnalyzer
    {
        IExtensionManager _extManager = new FileExtensionManager();
        ISystemTimeManager _timeManager = new SystemTimeManager();

        //在AssemblyInfo.cs增加内部函数的可见程序集 "LogAn.Tests"
        internal LogAndTimeAnalyzer(IExtensionManager extManager, ISystemTimeManager timeManager)
        {
            this._extManager = extManager;
            this._timeManager = timeManager;
        }

#if DEBUG

        public LogAndTimeAnalyzer()
        {
        }
        public IExtensionManager ExtensionManager
        {
            get { return _extManager; }
            set { _extManager = value; }
        }

        public ISystemTimeManager SystemTimeManager
        {
            get { return _timeManager; }
            set { _timeManager = value; }
        }

        /// <summary>
        /// 参数对象重构
        /// </summary>
        /// <param name="utilities"></param>        
        public LogAndTimeAnalyzer(UtilityObject utilities)
        {
            this._extManager = utilities.ExtensionManager;
            this._timeManager = utilities.SystemTimeManager;
        }

#endif

        [Conditional("DEBUG")]
        public void SetExtensionManager(IExtensionManager mgr)
        {
            _extManager = mgr;
        }

        [Conditional("DEBUG")]
        public void SetSystemTimeManager(ISystemTimeManager mgr)
        {
            _timeManager = mgr;
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
