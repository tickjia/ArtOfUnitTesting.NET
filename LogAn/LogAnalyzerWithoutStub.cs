using LogAn.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogAn
{
    public class LogAnalyzerWithoutStub
    {
        FileExtensionManager _extensionManager = new FileExtensionManager();
        protected virtual bool IsValid(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filename provided!");
            }
            if (!_extensionManager.IsValid(fileName))
            {
                return false;
            }
            return true;
        }

        protected virtual void WriteToFile(string fileName)
        {
            if (!File.Exists(fileName)) throw new System.IO.DirectoryNotFoundException("File not found!");
            using (FileStream stream = File.Open(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                    sw.Close();
                }
                stream.Close();

            }          
        }

        public bool SaveFile(string fileName)
        {
            if (!IsValid(fileName)) return false;
            WriteToFile(fileName);
            return true;
        }
    }
}
