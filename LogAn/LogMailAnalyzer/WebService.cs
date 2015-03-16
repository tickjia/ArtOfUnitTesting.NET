using LogAn.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace LogAn.LogMailAnalyzer
{
    
    public class WebService : IWebService
    {
        const int MSG_MAX_SIZE = int.MaxValue;
        static TimeServiceClient _service = null;
        public WebService()
        {
            if (_service == null)
            {
                string remoteAddress = System.Configuration.ConfigurationSettings.AppSettings["TimeServiceHost"];
                if (remoteAddress == null) remoteAddress = "http://localhost:4160/TimeService.svc";
                EndpointAddress address = new EndpointAddress(remoteAddress);
                BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                _service = new TimeServiceClient(binding, address);
            }
        }
        public DateTime GetTime()
        {
            return _service.GetTime();
        }
    }
}
