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
            using (var serviceHost1 = new ServiceHost(typeof(MathService)))
            {

                serviceHost1.Open();

                foreach (ServiceEndpoint ep in serviceHost1.Description.Endpoints)
                {
                    Console.WriteLine(ep.Address.ToString() + " " + ep.Binding.Name);
                }
            }
            using (var serviceHost2 = new ServiceHost(typeof(CalcService)))
            {

                serviceHost2.Open();


                foreach (ServiceEndpoint ep in serviceHost2.Description.Endpoints)
                {
                    Console.WriteLine(ep.Address.ToString() + " " + ep.Binding.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
