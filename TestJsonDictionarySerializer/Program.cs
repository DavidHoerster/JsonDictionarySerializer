using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJsonDictionarySerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Form LocalRunner";

            Trace.WriteLine("Starting web listener...");
            string baseUri = "http://localhost:55000";
            using (var _app = WebApp.Start<Startup>(url: baseUri))
            {
                Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseUri), "Information");

                Trace.TraceInformation("Cti.RegulatoryReporting.Service.Form is running. Press enter to terminate...");

                Console.ReadLine();
            }
            Trace.TraceInformation("Cti.RegulatoryReporting.Service.Form is stopping");
            Trace.TraceInformation("Cti.RegulatoryReporting.Service.Form has stopped");
        }
    }
}
