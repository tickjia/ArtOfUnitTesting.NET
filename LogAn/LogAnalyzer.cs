using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager ExtensionManager = new FileExtensionManager();

        public LogAnalyzer() { }
        
        /// <summary>
        /// 为单元测试，扩展桩接缝
        /// </summary>
        /// <param name="manager"></param>
        public LogAnalyzer(IExtensionManager manager)
        {
            this.ExtensionManager = manager;
        }

        private bool wasLastFileNameValid;
        public bool WasLastFileNameValid
        {
            get { return wasLastFileNameValid; }
            set { wasLastFileNameValid = value; }
        }
        public bool IsValidLogFileName(string fileName)
        {
            wasLastFileNameValid = false;
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filename provided!");
            }
            if (!ExtensionManager.IsValid(fileName))
            {
                return false;
            }
            wasLastFileNameValid = true;
            return true;
        }
    }
}
