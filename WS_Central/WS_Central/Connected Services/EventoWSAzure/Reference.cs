//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Central.EventoWSAzure {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/")]
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EventoS", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class EventoS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CapacidadeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocalizacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LotacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
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
        public int Capacidade {
            get {
                return this.CapacidadeField;
            }
            set {
                if ((this.CapacidadeField.Equals(value) != true)) {
                    this.CapacidadeField = value;
                    this.RaisePropertyChanged("Capacidade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
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
        public string Localizacao {
            get {
                return this.LocalizacaoField;
            }
            set {
                if ((object.ReferenceEquals(this.LocalizacaoField, value) != true)) {
                    this.LocalizacaoField = value;
                    this.RaisePropertyChanged("Localizacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Lotacao {
            get {
                return this.LotacaoField;
            }
            set {
                if ((this.LotacaoField.Equals(value) != true)) {
                    this.LotacaoField = value;
                    this.RaisePropertyChanged("Lotacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EventoWSAzure.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        WS_Central.EventoWSAzure.CompositeType GetDataUsingDataContract(WS_Central.EventoWSAzure.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WS_Central.EventoWSAzure.CompositeType> GetDataUsingDataContractAsync(WS_Central.EventoWSAzure.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CriarEvento", ReplyAction="http://tempuri.org/IService/CriarEventoResponse")]
        string CriarEvento(string nome, string data, string local, int lotacao, int capacidade);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CriarEvento", ReplyAction="http://tempuri.org/IService/CriarEventoResponse")]
        System.Threading.Tasks.Task<string> CriarEventoAsync(string nome, string data, string local, int lotacao, int capacidade);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EliminaEvento", ReplyAction="http://tempuri.org/IService/EliminaEventoResponse")]
        string EliminaEvento(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EliminaEvento", ReplyAction="http://tempuri.org/IService/EliminaEventoResponse")]
        System.Threading.Tasks.Task<string> EliminaEventoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllEvents", ReplyAction="http://tempuri.org/IService/GetAllEventsResponse")]
        WS_Central.EventoWSAzure.EventoS[] GetAllEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllEvents", ReplyAction="http://tempuri.org/IService/GetAllEventsResponse")]
        System.Threading.Tasks.Task<WS_Central.EventoWSAzure.EventoS[]> GetAllEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EscolherEvento", ReplyAction="http://tempuri.org/IService/EscolherEventoResponse")]
        WS_Central.EventoWSAzure.EventoS EscolherEvento(string nome);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EscolherEvento", ReplyAction="http://tempuri.org/IService/EscolherEventoResponse")]
        System.Threading.Tasks.Task<WS_Central.EventoWSAzure.EventoS> EscolherEventoAsync(string nome);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEvento", ReplyAction="http://tempuri.org/IService/GetEventoResponse")]
        WS_Central.EventoWSAzure.EventoS GetEvento(int id, string nome, string data, string local, int lotacao, int capacidade);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEvento", ReplyAction="http://tempuri.org/IService/GetEventoResponse")]
        System.Threading.Tasks.Task<WS_Central.EventoWSAzure.EventoS> GetEventoAsync(int id, string nome, string data, string local, int lotacao, int capacidade);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WS_Central.EventoWSAzure.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WS_Central.EventoWSAzure.IService>, WS_Central.EventoWSAzure.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WS_Central.EventoWSAzure.CompositeType GetDataUsingDataContract(WS_Central.EventoWSAzure.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WS_Central.EventoWSAzure.CompositeType> GetDataUsingDataContractAsync(WS_Central.EventoWSAzure.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string CriarEvento(string nome, string data, string local, int lotacao, int capacidade) {
            return base.Channel.CriarEvento(nome, data, local, lotacao, capacidade);
        }
        
        public System.Threading.Tasks.Task<string> CriarEventoAsync(string nome, string data, string local, int lotacao, int capacidade) {
            return base.Channel.CriarEventoAsync(nome, data, local, lotacao, capacidade);
        }
        
        public string EliminaEvento(int id) {
            return base.Channel.EliminaEvento(id);
        }
        
        public System.Threading.Tasks.Task<string> EliminaEventoAsync(int id) {
            return base.Channel.EliminaEventoAsync(id);
        }
        
        public WS_Central.EventoWSAzure.EventoS[] GetAllEvents() {
            return base.Channel.GetAllEvents();
        }
        
        public System.Threading.Tasks.Task<WS_Central.EventoWSAzure.EventoS[]> GetAllEventsAsync() {
            return base.Channel.GetAllEventsAsync();
        }
        
        public WS_Central.EventoWSAzure.EventoS EscolherEvento(string nome) {
            return base.Channel.EscolherEvento(nome);
        }
        
        public System.Threading.Tasks.Task<WS_Central.EventoWSAzure.EventoS> EscolherEventoAsync(string nome) {
            return base.Channel.EscolherEventoAsync(nome);
        }
        
        public WS_Central.EventoWSAzure.EventoS GetEvento(int id, string nome, string data, string local, int lotacao, int capacidade) {
            return base.Channel.GetEvento(id, nome, data, local, lotacao, capacidade);
        }
        
        public System.Threading.Tasks.Task<WS_Central.EventoWSAzure.EventoS> GetEventoAsync(int id, string nome, string data, string local, int lotacao, int capacidade) {
            return base.Channel.GetEventoAsync(id, nome, data, local, lotacao, capacidade);
        }
    }
}
