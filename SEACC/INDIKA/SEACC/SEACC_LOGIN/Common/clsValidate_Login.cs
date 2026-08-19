using System;
using System.IO;
using System.Windows.Forms;

namespace SEACC_LOGIN
{
    public class clsValidate_Login
    {
        #region Error Log
        public static void WriteErrorLog(string sError)
        {
            try
            {
                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);
            }
            catch { }
        }
        public static void WriteErrorLog(string sError, string sModuleID)
        {
            try
            {
                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, DateTime.Now.ToString() + " - " + sError + " - " + sModuleID + Environment.NewLine + "-" + Environment.NewLine);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + " - " + sModuleID + Environment.NewLine + "-" + Environment.NewLine);
            }
            catch { }
        }
        #endregion
    }
}
