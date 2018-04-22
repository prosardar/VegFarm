using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VegFarm.App_Start;

namespace VegFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            Stop();
        }

        private static void Start()
        {
            string baseAddress = Properties.Settings.Default.ListenAddress;
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Server was started");
                Console.ReadLine();
            }
        }

        private static void Stop()
        {
           
        }
    }
}
