using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFLibrary;
using CalcServiceLibrary;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceHost1 = new ServiceHost(typeof(MathService));
            {
                ServiceEndpoint BasicHttpEndPoint1 = serviceHost1.AddServiceEndpoint(
                    typeof(IMathService),
                    new BasicHttpBinding(),
                    "http://localhost:4444/MathService"
                );
                serviceHost1.Open();
            }
            var serviceHost2 = new ServiceHost(typeof(CalcService));
            {
                ServiceEndpoint BasicHttpEndPoint2 = serviceHost2.AddServiceEndpoint(
                    typeof(ICalcService),
                    new BasicHttpBinding(),
                    "http://localhost:5555/CalcService"
                );
                serviceHost2.Open();
            }

            Console.ReadKey();
        }
    }
}
