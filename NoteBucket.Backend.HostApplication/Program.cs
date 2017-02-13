using Nancy.Hosting.Self;
using NoteBucket.Backend.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBucket.Backend.HostApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new HostConfiguration
            {
                UrlReservations = new UrlReservations { CreateAutomatically = true }
            };

            var bootstrapper = new Bootstrapper();

            using (var host = new NancyHost(bootstrapper, configuration, new Uri("http://localhost:5000")))
            {
                host.Start();

                Console.WriteLine("### Note Bucket Sample API Host ###");
                Console.WriteLine();
                Console.WriteLine("Now running on localhost:5000...");
                Console.WriteLine("Happy RESTing :)");
                Console.ReadLine();
            }
        }
    }
}
