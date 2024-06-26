using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalcServiceLibrary
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        int Mult(MyNumbers obj);

        [OperationContract]
        int Div(MyNumbers obj);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class MyNumbers
    {

        [DataMember]
        public int Number1 { get; set; }

        [DataMember]
        public int Number2 { get; set; }
    }
}
