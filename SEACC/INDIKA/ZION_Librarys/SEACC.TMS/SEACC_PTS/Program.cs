using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SEACC_PTS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MessageBox.Show("Hello Form");
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}

