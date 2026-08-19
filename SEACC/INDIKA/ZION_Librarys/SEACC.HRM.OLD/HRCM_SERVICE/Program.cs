using HRCM_SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HRCM_SERVICE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new HR_SERVICE()
            //};
            //ServiceBase.Run(ServicesToRun);
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            #if false
                SEACC_HRCMT_SERVICE s = new SEACC_HRCMT_SERVICE();
                s.Testdebug();
            #else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                 { 
                     new SEACC_HRCMT_SERVICE() 
                 };
                ServiceBase.Run(ServicesToRun);
            #endif

        }
    }
}
