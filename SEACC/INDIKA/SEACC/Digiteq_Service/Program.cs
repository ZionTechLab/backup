using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Digiteq_Logic;

namespace Digiteq_Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"\Digiteq_Service.exe", ""); ;
            string[] lines = System.IO.File.ReadAllLines(path + "/settings.ini");
            clsSecurity.SoftwareModle = lines[0];
#if false
                        SEACC s = new SEACC();
                        s.Testdebug();
#else
            ServiceBase[] ServicesToRun;
                                    ServicesToRun = new ServiceBase[] 
                                    { 
                                        new SEACC() 
                                    };
                                    ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}