using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using Digiteq_Logic;

namespace Digiteq_Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {      string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"\Digiteq_Service.exe", ""); ;
            string[] lines = System.IO.File.ReadAllLines(path + "/settings.ini");
            clsSecurity.SoftwareModle = lines[0];
            InitializeComponent();
      
            string ServiceNAme = "SEACC Support - " + clsSecurity.SoftwareModle; //+ DateTime.Now.ToString("yyyyMMddhhmmss");
            this.serviceInstaller1.Description = "Provide auto alert, error support, and other support services";

            this.serviceInstaller1.ServiceName = ServiceNAme;
            this.serviceInstaller1.DisplayName = ServiceNAme;
        }
    }
}
