using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //////
#if false
            BackupService s = new BackupService();
            s.Testdebug();
#else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new BackupService()
            };
            ServiceBase.Run(ServicesToRun);
           
#endif
            ////
        }
    }
}
