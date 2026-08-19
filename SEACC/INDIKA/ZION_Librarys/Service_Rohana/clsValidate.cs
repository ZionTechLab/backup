using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq_Service1
{
   public class clsValidate1
    {
        public static void WriteErrorLog(string sError, int iformID, Exception ex)
        {
            try
            {

                string smsg = DateTime.Now.ToString() + " - " + sError + " - " + iformID;


                if (ex != null)
                    smsg += Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + "-" + Environment.NewLine + Environment.NewLine;

                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, smsg);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
        }
    }
}
