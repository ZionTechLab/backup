using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class PodScanUploadDomainView
    {
       
        public string ScanDateTimeObj { get; set; }
        public string EmployeeID { get; set; }
        public string RoutID { get; set; }
        public string ScanTypeP { get; set; }
        public string ScanTypeS { get; set; }
        public string Trackno { get; set; }     
        public string UploadTime { get; set; }         
        public string StatusCode { get; set; }
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public bool deleted { get; set; }
        public string ScanDescP { get;  set; }
        public string ScanDescS { get; set; }
        public string ScanCapture { get; set; }
        public string ScanProcess { get; set; }
        public string ScanProcessErr { get; set; }
        public string UserDate { get; set; }
        public int USM_ID { get; set; }
        public string UserN { get; set; }
    }
}
