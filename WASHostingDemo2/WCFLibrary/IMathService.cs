﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMathServiceCallback))]
    public interface IMathService
    {
        [OperationContract]
        int Add(MyNumbers obj);

        [OperationContract]
        int Subtract(MyNumbers obj);

        [OperationContract(IsOneWay = true)]
        void SignIn(string UserName);

        [OperationContract(IsOneWay = true)]
        void SignOut(string UserName);

        [OperationContract(IsOneWay = true)]
        void StartPrintingLogFiles(string message);
    }

    public interface IMathServiceCallback {

        [OperationContract(IsOneWay = true)]
        void NotifyClientWhenPrintingIsDone(string message);
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
