﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogAn.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GlobalDateTime", Namespace="http://schemas.datacontract.org/2004/07/LogAnWCF")]
    [System.SerializableAttribute()]
    public partial class GlobalDateTime : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime AmericanTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ChineseTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime AmericanTime {
            get {
                return this.AmericanTimeField;
            }
            set {
                if ((this.AmericanTimeField.Equals(value) != true)) {
                    this.AmericanTimeField = value;
                    this.RaisePropertyChanged("AmericanTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ChineseTime {
            get {
                return this.ChineseTimeField;
            }
            set {
                if ((this.ChineseTimeField.Equals(value) != true)) {
                    this.ChineseTimeField = value;
                    this.RaisePropertyChanged("ChineseTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ITimeService")]
    public interface ITimeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimeService/GetTime", ReplyAction="http://tempuri.org/ITimeService/GetTimeResponse")]
        System.DateTime GetTime();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimeService/GetAllTime", ReplyAction="http://tempuri.org/ITimeService/GetAllTimeResponse")]
        LogAn.ServiceReference1.GlobalDateTime GetAllTime();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITimeServiceChannel : global::LogAn.ServiceReference1.ITimeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TimeServiceClient : System.ServiceModel.ClientBase<global::LogAn.ServiceReference1.ITimeService>, global::LogAn.ServiceReference1.ITimeService {
        
        public TimeServiceClient() {
        }
        
        public TimeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TimeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TimeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TimeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.DateTime GetTime() {
            return base.Channel.GetTime();
        }
        
        public LogAn.ServiceReference1.GlobalDateTime GetAllTime() {
            return base.Channel.GetAllTime();
        }
    }
}
