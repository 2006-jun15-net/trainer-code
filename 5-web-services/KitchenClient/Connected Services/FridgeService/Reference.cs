﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KitchenClient.FridgeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FoodItem", Namespace="http://schemas.datacontract.org/2004/07/KitchenService.Models")]
    [System.SerializableAttribute()]
    public partial class FoodItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ExpirationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public int Id {
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FridgeService.IFridge")]
    public interface IFridge {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFridge/GetAllContents", ReplyAction="http://tempuri.org/IFridge/GetAllContentsResponse")]
        KitchenClient.FridgeService.FoodItem[] GetAllContents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFridge/GetAllContents", ReplyAction="http://tempuri.org/IFridge/GetAllContentsResponse")]
        System.Threading.Tasks.Task<KitchenClient.FridgeService.FoodItem[]> GetAllContentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFridge/Clean", ReplyAction="http://tempuri.org/IFridge/CleanResponse")]
        KitchenClient.FridgeService.FoodItem[] Clean();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFridge/Clean", ReplyAction="http://tempuri.org/IFridge/CleanResponse")]
        System.Threading.Tasks.Task<KitchenClient.FridgeService.FoodItem[]> CleanAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFridgeChannel : KitchenClient.FridgeService.IFridge, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FridgeClient : System.ServiceModel.ClientBase<KitchenClient.FridgeService.IFridge>, KitchenClient.FridgeService.IFridge {
        
        public FridgeClient() {
        }
        
        public FridgeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FridgeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FridgeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FridgeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public KitchenClient.FridgeService.FoodItem[] GetAllContents() {
            return base.Channel.GetAllContents();
        }
        
        public System.Threading.Tasks.Task<KitchenClient.FridgeService.FoodItem[]> GetAllContentsAsync() {
            return base.Channel.GetAllContentsAsync();
        }
        
        public KitchenClient.FridgeService.FoodItem[] Clean() {
            return base.Channel.Clean();
        }
        
        public System.Threading.Tasks.Task<KitchenClient.FridgeService.FoodItem[]> CleanAsync() {
            return base.Channel.CleanAsync();
        }
    }
}
