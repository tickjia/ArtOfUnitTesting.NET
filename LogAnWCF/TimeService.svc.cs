﻿using System;
using System.Collections.Generic;
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