using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MHE_Api
{
    public class Log
    {
        public  void RaiseException()
        {
            //try
            //{
            //    int i = int.Parse("Mudassar");
            //}
            //catch (Exception ex)
            //{
            //    LogError(ex);
            //}
        }


        public static void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;

            string serverpath = HttpContext.Current.Server.MapPath("~");

            serverpath += @"\Log.txt";

            using (StreamWriter writer = new StreamWriter(serverpath, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}






