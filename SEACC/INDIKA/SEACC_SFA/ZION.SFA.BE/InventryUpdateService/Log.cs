using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace InventryUpdateService
{
  public   class Log
    {
        public static void WriteLog(string sError)
        {
            try
            {
                var y = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                string smsg = DateTime.Now.ToString() + " - " + sError  + Environment.NewLine + Environment.NewLine;

                string logFileName = Path.Combine(y, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
        }
        public static void WriteLog(string sError, int iformID, Exception ex)
        {
            try
            {
                var y = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                string smsg = DateTime.Now.ToString() + " - " + sError + " - " + iformID + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + "-" + Environment.NewLine + Environment.NewLine;

                //string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                //File.AppendAllText(logFileName_Local, smsg);

                string logFileName = Path.Combine(y, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
        }
    }
}
