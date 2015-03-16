using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LogAnWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TimeService : ITimeService
    {
        const string logFileName = "c:\\a.txt";
        private void WriteALog(string message)
        {
            using (FileStream fs = new FileStream(logFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(string.Format("{0:yy-MM-dd HH:mm:ss}\t{1}", DateTime.Now, message));
                    sw.Close();
                }
                fs.Close();
            }
        }

        public void AddLog(string message)
        {
            WriteALog(message);
        }

        public GlobalDateTime GetAllTime()
        {
            GlobalDateTime times = new GlobalDateTime();
            times.ChineseTime = DateTime.Now;
            times.AmericanTime = DateTime.Now.AddHours(-14);
            return times;
        }

        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
