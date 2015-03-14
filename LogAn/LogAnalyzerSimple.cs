using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LogAn
{
    public class LogAnalyzerSimple
    {

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
            if (!fileName.EndsWith(".slf"))
            {
                return false;
            }
            wasLastFileNameValid = true;
            return true;
        }
    }
}
