using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;
using System.Reflection;

namespace ZION.EmailService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-i":
                        {
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            break;
                        }
                    case "-u":
                        {
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                            break;
                        }
                }
            }
            else
            {

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
}