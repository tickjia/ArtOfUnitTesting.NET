using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LogAn
{
    public class LogAnalyzerV
    {
        protected virtual IExtensionManager GetExtensionManager()
        {
            return new FileExtensionManager();
        }
                
        public bool IsValidLogFileName(string fileName)
        {           
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filename provided!");
            }
            if (!GetExtensionManager().IsValid(fileName))
            {
                return false;
            }           
            return true;
        }
    }
}
