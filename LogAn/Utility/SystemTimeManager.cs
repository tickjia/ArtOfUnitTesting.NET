using LogAn.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace LogAn.Utility
{
    public class SystemTimeManager : ISystemTimeManager
    {
        const int MSG_MAX_SIZE = int.MaxValue;
        // static ITimeService _service = null;
        static TimeServiceClient _service = null;
        public SystemTimeManager()
        {
            if (_service == null)
            {
                string remoteAddress = System.Configuration.ConfigurationSettings.AppSettings["TimeServiceHost"];
                if (remoteAddress == null) remoteAddress = "http://localhost:4160/TimeService.svc";
                EndpointAddress address = new EndpointAddress(remoteAddress);
                BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                _service = new TimeServiceClient(binding, address);
                /*
             
                WSHttpBinding binder = new WSHttpBinding(SecurityMode.None);
                binder.MaxBufferPoolSize = MSG_MAX_SIZE;
                binder.MaxReceivedMessageSize = MSG_MAX_SIZE;                                
                ChannelFactory<ITimeService> factory = new ChannelFactory<ITimeService>(binder, remoteAddress);
                _service = factory.CreateChannel();
                */
            }
        }

        public DateTime GetAmericanTime()
        {
            return _service.GetAllTime().AmericanTime;
        }

        public DateTime GetChineseTime()
        {
            return _service.GetAllTime().ChineseTime;
        }

        public DateTime GetNow()
        {
            return _service.GetTime();
        }

        public void AddLog(string message)
        {
            _service.AddLog(message);
        }
    }
}
