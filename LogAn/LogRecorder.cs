using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn
{
    public class LogRecorder
    {
        ILogFileChecker _checker = new LogFileChecker();
        internal LogRecorder() { }
        internal LogRecorder(ILogFileChecker checker)
        {
            this._checker = checker;
        }
        public bool IsValid(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentException("No FileName Provided!");
            if (!fileName.EndsWith(".lsf") || fileName.Length < 6)
            {
                //做一个交互，把日志记录到web服务中
                _checker.RecordLog(fileName + ":file extension error or the length of file name is less 6!");
                return false;
            }
            return true;
        }

        public bool Save(string fileName,string message)
        {
            if (!IsValid(fileName)) return false;
            Console.Write("save the message to file!");
            return true;
        }

    }
}
