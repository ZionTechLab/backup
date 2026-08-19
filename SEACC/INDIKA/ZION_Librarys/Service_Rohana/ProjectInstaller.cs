using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using Digiteq_Logic;
using System.IO;
using System.Windows.Forms;

namespace Digiteq_Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
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
        public ProjectInstaller()
        {
            try
            {
                string settingsPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + @"\settings.ini";
                if (File.Exists(settingsPath))
                {
                    string[] lines = System.IO.File.ReadAllLines(settingsPath);
                    clsSecurity.SoftwareModle = lines[0];
                }
                else
                {
                    WriteErrorLog("Settings.ini file not exist", -1, null);
                }

                //  string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"\Digiteq_Service.exe", ""); ;
                //  string[] lines = System.IO.File.ReadAllLines(path + "/settings.ini");
                //  clsSecurity.SoftwareModle = lines[0];
                InitializeComponent();

                string ServiceNAme = "SEACC Support - " + clsSecurity.SoftwareModle; //+ DateTime.Now.ToString("yyyyMMddhhmmss");
                this.serviceInstaller1.Description = "Provide auto alert, error support, and other support services";

              //  this.serviceInstaller1.ServiceName = ServiceNAme;
              //  this.serviceInstaller1.DisplayName = ServiceNAme;
            }
            catch (Exception ex)
            {
                WriteErrorLog("", -1, ex);
            }
        }
    }
}
