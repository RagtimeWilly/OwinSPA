using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace OwinSPA.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var port = ConfigurationManager.AppSettings["Port"];

            var options = new StartOptions($"http://*:{port}")
            {
                ServerFactory = "Microsoft.Owin.Host.HttpListener"
            };

            // Start OWIN host 
            using (WebApp.Start<Startup>(options))
            {
                foreach (var url in options.Urls)
                {
                    Console.WriteLine($"Service listening on {url}");
                }

                Console.ReadLine();
            }
        }
    }
}
