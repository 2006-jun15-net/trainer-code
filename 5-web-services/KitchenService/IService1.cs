using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KitchenService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    // WCF configures the WSDL (and its own message-processing pipeline)
    // based on various attributes in System.ServiceModel.
    // ServiceContractAttribute: mark an interface as a service, which contains operations
    // OperationContractAttribute: mark one method in a service interface as a reachable operation through the WSDL
    // in System.Runtime.Serialization:
    // DataContractAttribute: mark a user-defined type as a type that will be part of some operation's parameters/return.
    // DataMemberAttribute: opt-in a member of a datacontract class to serialization.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
