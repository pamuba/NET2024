using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int Adds(MyNumbers obj);

        [OperationContract]
        int Subtracts(MyNumbers obj);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class MyNumbers
    {
        [DataMember]
        public int Number1 { get; set; }
        [DataMember]
        public int Number2 { get; set; }
    }

}
