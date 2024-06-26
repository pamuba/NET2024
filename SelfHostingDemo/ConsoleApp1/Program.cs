using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFLibrary;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var serviceHost = new ServiceHost(typeof(MathService))) {
                ServiceEndpoint BasicHttpEndPoint1 = serviceHost.AddServiceEndpoint(
                    typeof(IMathService),
                    new BasicHttpBinding(),
                    "http://localhost:4444/MathService"
                );

                ServiceEndpoint BasicHttpEndPoint2 = serviceHost.AddServiceEndpoint(
                    typeof(IMathService),
                    new BasicHttpBinding(),
                    "http://localhost:5555/MathService"
                );
                ServiceEndpoint NettcpEndPoint = serviceHost.AddServiceEndpoint(
                    typeof(IMathService),
                    new NetTcpBinding(),
                    "net.tcp://localhost:6667/MathService"
                );

                serviceHost.Open();

                Console.WriteLine("YOUR SEVICE IS RUNNING");
                Console.WriteLine("SEVICE IS LISTENING ON BELOW ENDPOINTS:");
                Console.WriteLine("{0} ({1})", BasicHttpEndPoint1.Address.ToString(), BasicHttpEndPoint1.Binding.Name);

                foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints) {
                    Console.WriteLine("Address: {0} Binding Name : {1}", 
                        endpoint.Address.ToString(), endpoint.Binding.Name);
                }
                Console.WriteLine();
                Console.WriteLine("Press Any Key to Stop");
                Console.ReadKey();

                serviceHost.Close();
            }
        }
    }
}
