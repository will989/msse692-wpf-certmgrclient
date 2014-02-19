﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CertificateManagerClient.CertificateManagerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/CertificateManager")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CertificateManagerService.ICertificateManagerService")]
    public interface ICertificateManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/ListCertificatesInStore", ReplyAction="http://tempuri.org/ICertificateManagerService/ListCertificatesInStoreResponse")]
        System.Security.Cryptography.X509Certificates.X509Certificate2[] ListCertificatesInStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/ListCertificatesInRemoteStore", ReplyAction="http://tempuri.org/ICertificateManagerService/ListCertificatesInRemoteStoreRespon" +
            "se")]
        System.Security.Cryptography.X509Certificates.X509Certificate2[] ListCertificatesInRemoteStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, string serverName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/ListExpiringCertificatesInStore", ReplyAction="http://tempuri.org/ICertificateManagerService/ListExpiringCertificatesInStoreResp" +
            "onse")]
        System.Security.Cryptography.X509Certificates.X509Certificate2[] ListExpiringCertificatesInStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, int days);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/PrintCertificateInfo", ReplyAction="http://tempuri.org/ICertificateManagerService/PrintCertificateInfoResponse")]
        void PrintCertificateInfo(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/EnumCertificatesByStoreName", ReplyAction="http://tempuri.org/ICertificateManagerService/EnumCertificatesByStoreNameResponse" +
            "")]
        void EnumCertificatesByStoreName(System.Security.Cryptography.X509Certificates.StoreName name, System.Security.Cryptography.X509Certificates.StoreLocation location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/EnumCertificates", ReplyAction="http://tempuri.org/ICertificateManagerService/EnumCertificatesResponse")]
        void EnumCertificates(string name, System.Security.Cryptography.X509Certificates.StoreLocation location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/InstallCertificateLocal", ReplyAction="http://tempuri.org/ICertificateManagerService/InstallCertificateLocalResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.StoreLocation))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.X509Certificate2[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.X509Certificate2))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.X509Certificate))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.StoreName))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CertificateManagerClient.CertificateManagerService.CompositeType))]
        bool InstallCertificateLocal(System.Security.Cryptography.X509Certificates.X509Store store, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/DeleteCertificate", ReplyAction="http://tempuri.org/ICertificateManagerService/DeleteCertificateResponse")]
        bool DeleteCertificate(string certificateName, string storeName, System.Security.Cryptography.X509Certificates.StoreLocation location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/DeleteCertificateByThumbprint", ReplyAction="http://tempuri.org/ICertificateManagerService/DeleteCertificateByThumbprintRespon" +
            "se")]
        bool DeleteCertificateByThumbprint(string certificateName, string thumbprint, string storeName, System.Security.Cryptography.X509Certificates.StoreLocation location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/RemoveCertificateLocal", ReplyAction="http://tempuri.org/ICertificateManagerService/RemoveCertificateLocalResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.StoreLocation))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.X509Certificate2[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.X509Certificate2))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.X509Certificate))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Security.Cryptography.X509Certificates.StoreName))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CertificateManagerClient.CertificateManagerService.CompositeType))]
        bool RemoveCertificateLocal(System.Security.Cryptography.X509Certificates.X509Store store, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/CompareCertificatesInStore", ReplyAction="http://tempuri.org/ICertificateManagerService/CompareCertificatesInStoreResponse")]
        System.Security.Cryptography.X509Certificates.X509Certificate2[] CompareCertificatesInStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, string serverA, string serverB);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/GetData", ReplyAction="http://tempuri.org/ICertificateManagerService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateManagerService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICertificateManagerService/GetDataUsingDataContractResponse")]
        CertificateManagerClient.CertificateManagerService.CompositeType GetDataUsingDataContract(CertificateManagerClient.CertificateManagerService.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICertificateManagerServiceChannel : CertificateManagerClient.CertificateManagerService.ICertificateManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CertificateManagerServiceClient : System.ServiceModel.ClientBase<CertificateManagerClient.CertificateManagerService.ICertificateManagerService>, CertificateManagerClient.CertificateManagerService.ICertificateManagerService {
        
        public CertificateManagerServiceClient() {
        }
        
        public CertificateManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CertificateManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CertificateManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CertificateManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Security.Cryptography.X509Certificates.X509Certificate2[] ListCertificatesInStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation) {
            return base.Channel.ListCertificatesInStore(storeName, storeLocation);
        }
        
        public System.Security.Cryptography.X509Certificates.X509Certificate2[] ListCertificatesInRemoteStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, string serverName) {
            return base.Channel.ListCertificatesInRemoteStore(storeName, storeLocation, serverName);
        }
        
        public System.Security.Cryptography.X509Certificates.X509Certificate2[] ListExpiringCertificatesInStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, int days) {
            return base.Channel.ListExpiringCertificatesInStore(storeName, storeLocation, days);
        }
        
        public void PrintCertificateInfo(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) {
            base.Channel.PrintCertificateInfo(certificate);
        }
        
        public void EnumCertificatesByStoreName(System.Security.Cryptography.X509Certificates.StoreName name, System.Security.Cryptography.X509Certificates.StoreLocation location) {
            base.Channel.EnumCertificatesByStoreName(name, location);
        }
        
        public void EnumCertificates(string name, System.Security.Cryptography.X509Certificates.StoreLocation location) {
            base.Channel.EnumCertificates(name, location);
        }
        
        public bool InstallCertificateLocal(System.Security.Cryptography.X509Certificates.X509Store store, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) {
            return base.Channel.InstallCertificateLocal(store, certificate);
        }
        
        public bool DeleteCertificate(string certificateName, string storeName, System.Security.Cryptography.X509Certificates.StoreLocation location) {
            return base.Channel.DeleteCertificate(certificateName, storeName, location);
        }
        
        public bool DeleteCertificateByThumbprint(string certificateName, string thumbprint, string storeName, System.Security.Cryptography.X509Certificates.StoreLocation location) {
            return base.Channel.DeleteCertificateByThumbprint(certificateName, thumbprint, storeName, location);
        }
        
        public bool RemoveCertificateLocal(System.Security.Cryptography.X509Certificates.X509Store store, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) {
            return base.Channel.RemoveCertificateLocal(store, certificate);
        }
        
        public System.Security.Cryptography.X509Certificates.X509Certificate2[] CompareCertificatesInStore(string storeName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, string serverA, string serverB) {
            return base.Channel.CompareCertificatesInStore(storeName, storeLocation, serverA, serverB);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public CertificateManagerClient.CertificateManagerService.CompositeType GetDataUsingDataContract(CertificateManagerClient.CertificateManagerService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
    }
}