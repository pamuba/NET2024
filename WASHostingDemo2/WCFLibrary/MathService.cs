using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MathService : IMathService
    {
        public int Add(MyNumbers obj)
        {
            return (obj.Number1 + obj.Number2);
        }

        public void SignIn(string UserName)
        {
            System.Threading.Thread.Sleep(5000);
            var str = new StringWriter();
            str.WriteLine("{0} has loaded from at {1:t}", UserName, DateTime.Now.ToString("hh:mm:ss tt"));
            File.AppendAllText(@"D:\dotnet\feb\consoleapps\WASHostingDemo2\CLIENT_1\log.txt", str.ToString());
        }

        public void SignOut(string UserName)
        {
            System.Threading.Thread.Sleep(5000);
            var str = new StringWriter();
            str.WriteLine("{0} has closed from at {1:t}", UserName, DateTime.Now.ToString("hh:mm:ss tt"));
            File.AppendAllText(@"D:\dotnet\feb\consoleapps\WASHostingDemo2\CLIENT_1\log1.txt", str.ToString());

        }

        public void StartPrintingLogFiles(string message)
        {
            IMathServiceCallback MSCallback = OperationContext.Current.GetCallbackChannel<IMathServiceCallback>();

            //Printing Files
            System.Threading.Thread.Sleep(5000);

            var str = new StringWriter();
            str.WriteLine("{0}", message, DateTime.Now.ToString("hh:mm:ss tt"));
            File.AppendAllText(@"D:\dotnet\feb\consoleapps\WASHostingDemo2\CLIENT_1\log3.txt", str.ToString());


            MSCallback.NotifyClientWhenPrintingIsDone(message);
        }

        public int Subtract(MyNumbers obj)
        {
            return (obj.Number1 - obj.Number2);
        }
    }
}
