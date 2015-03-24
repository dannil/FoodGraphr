using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Hosting;
using Nancy.Hosting.Self;

namespace FoodGraphr
{
    public class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:12116";

            var hostConfiguration = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            using (NancyHost host = new NancyHost(new Uri(uri), new Bootstrapper(), hostConfiguration))
            {
                Console.WriteLine("Starting server...");
                host.Start();
                Console.WriteLine("Started! Listening on " + uri + ", press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}