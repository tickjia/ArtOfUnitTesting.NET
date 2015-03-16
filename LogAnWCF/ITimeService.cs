using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LogAnWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITimeService
    {

        [OperationContract]
        DateTime GetTime();

        [OperationContract]
        GlobalDateTime GetAllTime();

        [OperationContract]
        void AddLog(string message);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class GlobalDateTime
    {       
        [DataMember]
        public DateTime ChineseTime
        {
            get;
            set;
        }

        [DataMember]
        public DateTime AmericanTime
        {
            get;
            set;
        }
    }
}
