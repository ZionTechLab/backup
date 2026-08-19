using Express.View.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();

                Application.SetCompatibleTextRenderingDefault(false);
                LoginInfoView.PROJECTNAME = "EXPRESS";
                //Application.Run(new ExchangeRates());
                //Application.Run(new Express.UI.Operation.View.Manifest_Inbound());
                LoginInfoView.USERID = 1;
                LoginInfoView.COMPANYID = 201;
                LoginInfoView.MODULEID = 200;
                LoginInfoView.MENUCODE = 1002;
                LoginInfoView.ONECUSTCODE = 100000000;
                LoginInfoView.REPORTPATH = "OMAN";
                Application.Run(new TLMExpress());
            }
            catch(Exception ex)
            {

            }

        }
    }
}
