using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhlektFTP
{
    public static class Logger
    {
        public static void LogToFile(string destinfile, string logtext)
        {
            using (StreamWriter w = File.AppendText(destinfile))
            {
                Log(logtext, w);
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {           
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }
    }
}
