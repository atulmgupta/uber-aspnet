using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace FindCaabs
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(FindCaabs.AddCustomerService));
                host.Open();
                Console.WriteLine("ECS Service Started");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                
            }
            
        }
    }
}
