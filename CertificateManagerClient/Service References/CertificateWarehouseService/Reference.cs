﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CertificateManagerClient.CertificateWarehouseService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrganizationCertificate", Namespace="http://schemas.datacontract.org/2004/07/CertificateManager.Data.Entities")]
    [System.SerializableAttribute()]
    public partial class OrganizationCertificate : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CertificateManagerClient.CertificateWarehouseService.ObjectId CertificateIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PurposeField;
        
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
        public bool Active {
            get {
                return this.ActiveField;
            }
            set {
                if ((this.ActiveField.Equals(value) != true)) {
                    this.ActiveField = value;
                    this.RaisePropertyChanged("Active");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CertificateManagerClient.CertificateWarehouseService.ObjectId CertificateId {
            get {
                return this.CertificateIdField;
            }
            set {
                if ((this.CertificateIdField.Equals(value) != true)) {
                    this.CertificateIdField = value;
                    this.RaisePropertyChanged("CertificateId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Purpose {
            get {
                return this.PurposeField;
            }
            set {
                if ((this.PurposeField.Equals(value) != true)) {
                    this.PurposeField = value;
                    this.RaisePropertyChanged("Purpose");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ObjectId", Namespace="http://schemas.datacontract.org/2004/07/MongoDB.Bson")]
    [System.SerializableAttribute()]
    public partial struct ObjectId : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int _incrementField;
        
        private int _machineField;
        
        private short _pidField;
        
        private int _timestampField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _increment {
            get {
                return this._incrementField;
            }
            set {
                if ((this._incrementField.Equals(value) != true)) {
                    this._incrementField = value;
                    this.RaisePropertyChanged("_increment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _machine {
            get {
                return this._machineField;
            }
            set {
                if ((this._machineField.Equals(value) != true)) {
                    this._machineField = value;
                    this.RaisePropertyChanged("_machine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public short _pid {
            get {
                return this._pidField;
            }
            set {
                if ((this._pidField.Equals(value) != true)) {
                    this._pidField = value;
                    this.RaisePropertyChanged("_pid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _timestamp {
            get {
                return this._timestampField;
            }
            set {
                if ((this._timestampField.Equals(value) != true)) {
                    this._timestampField = value;
                    this.RaisePropertyChanged("_timestamp");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MongoEntity", Namespace="http://schemas.datacontract.org/2004/07/CertificateManager.Data.Entities")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CertificateManagerClient.CertificateWarehouseService.Certificate))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CertificateManagerClient.CertificateWarehouseService.Organization))]
    public partial class MongoEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CertificateManagerClient.CertificateWarehouseService.ObjectId IdField;
        
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
        public CertificateManagerClient.CertificateWarehouseService.ObjectId Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Certificate", Namespace="http://schemas.datacontract.org/2004/07/CertificateManager.Data.Entities")]
    [System.SerializableAttribute()]
    public partial class Certificate : CertificateManagerClient.CertificateWarehouseService.MongoEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ExpirationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDeletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ThumbprintField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ExpirationDate {
            get {
                return this.ExpirationDateField;
            }
            set {
                if ((this.ExpirationDateField.Equals(value) != true)) {
                    this.ExpirationDateField = value;
                    this.RaisePropertyChanged("ExpirationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDeleted {
            get {
                return this.IsDeletedField;
            }
            set {
                if ((this.IsDeletedField.Equals(value) != true)) {
                    this.IsDeletedField = value;
                    this.RaisePropertyChanged("IsDeleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Thumbprint {
            get {
                return this.ThumbprintField;
            }
            set {
                if ((object.ReferenceEquals(this.ThumbprintField, value) != true)) {
                    this.ThumbprintField = value;
                    this.RaisePropertyChanged("Thumbprint");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Organization", Namespace="http://schemas.datacontract.org/2004/07/CertificateManager.Data.Entities")]
    [System.SerializableAttribute()]
    public partial class Organization : CertificateManagerClient.CertificateWarehouseService.MongoEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CertificateManagerClient.CertificateWarehouseService.OrganizationCertificate[] OrganizationCertificatesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CertificateManagerClient.CertificateWarehouseService.OrganizationCertificate[] OrganizationCertificates {
            get {
                return this.OrganizationCertificatesField;
            }
            set {
                if ((object.ReferenceEquals(this.OrganizationCertificatesField, value) != true)) {
                    this.OrganizationCertificatesField = value;
                    this.RaisePropertyChanged("OrganizationCertificates");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CertificateWarehouseService.ICertificateWarehouseService")]
    public interface ICertificateWarehouseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/AddCertificateToOrganization", ReplyAction="http://tempuri.org/ICertificateWarehouseService/AddCertificateToOrganizationRespo" +
            "nse")]
        bool AddCertificateToOrganization(string organizationId, CertificateManagerClient.CertificateWarehouseService.OrganizationCertificate organizationCertificate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/AddOrganizationToDatabase", ReplyAction="http://tempuri.org/ICertificateWarehouseService/AddOrganizationToDatabaseResponse" +
            "")]
        bool AddOrganizationToDatabase(CertificateManagerClient.CertificateWarehouseService.Organization organization);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/AddCertificateToDatabase", ReplyAction="http://tempuri.org/ICertificateWarehouseService/AddCertificateToDatabaseResponse")]
        bool AddCertificateToDatabase(CertificateManagerClient.CertificateWarehouseService.Certificate certificate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/GetCertificateById", ReplyAction="http://tempuri.org/ICertificateWarehouseService/GetCertificateByIdResponse")]
        CertificateManagerClient.CertificateWarehouseService.Certificate GetCertificateById(string certificateId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/GetCertificateByName", ReplyAction="http://tempuri.org/ICertificateWarehouseService/GetCertificateByNameResponse")]
        CertificateManagerClient.CertificateWarehouseService.Certificate GetCertificateByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/GetCertificateByThumbprint", ReplyAction="http://tempuri.org/ICertificateWarehouseService/GetCertificateByThumbprintRespons" +
            "e")]
        CertificateManagerClient.CertificateWarehouseService.Certificate GetCertificateByThumbprint(string thumbprint);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/GetCertificatesDetails", ReplyAction="http://tempuri.org/ICertificateWarehouseService/GetCertificatesDetailsResponse")]
        CertificateManagerClient.CertificateWarehouseService.Certificate[] GetCertificatesDetails(int limit, int skip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICertificateWarehouseService/DoWork", ReplyAction="http://tempuri.org/ICertificateWarehouseService/DoWorkResponse")]
        void DoWork();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICertificateWarehouseServiceChannel : CertificateManagerClient.CertificateWarehouseService.ICertificateWarehouseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CertificateWarehouseServiceClient : System.ServiceModel.ClientBase<CertificateManagerClient.CertificateWarehouseService.ICertificateWarehouseService>, CertificateManagerClient.CertificateWarehouseService.ICertificateWarehouseService {
        
        public CertificateWarehouseServiceClient() {
        }
        
        public CertificateWarehouseServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CertificateWarehouseServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CertificateWarehouseServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CertificateWarehouseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddCertificateToOrganization(string organizationId, CertificateManagerClient.CertificateWarehouseService.OrganizationCertificate organizationCertificate) {
            return base.Channel.AddCertificateToOrganization(organizationId, organizationCertificate);
        }
        
        public bool AddOrganizationToDatabase(CertificateManagerClient.CertificateWarehouseService.Organization organization) {
            return base.Channel.AddOrganizationToDatabase(organization);
        }
        
        public bool AddCertificateToDatabase(CertificateManagerClient.CertificateWarehouseService.Certificate certificate) {
            return base.Channel.AddCertificateToDatabase(certificate);
        }
        
        public CertificateManagerClient.CertificateWarehouseService.Certificate GetCertificateById(string certificateId) {
            return base.Channel.GetCertificateById(certificateId);
        }
        
        public CertificateManagerClient.CertificateWarehouseService.Certificate GetCertificateByName(string name) {
            return base.Channel.GetCertificateByName(name);
        }
        
        public CertificateManagerClient.CertificateWarehouseService.Certificate GetCertificateByThumbprint(string thumbprint) {
            return base.Channel.GetCertificateByThumbprint(thumbprint);
        }
        
        public CertificateManagerClient.CertificateWarehouseService.Certificate[] GetCertificatesDetails(int limit, int skip) {
            return base.Channel.GetCertificatesDetails(limit, skip);
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
    }
}