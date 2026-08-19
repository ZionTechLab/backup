using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.TrScans")]
    public  class TrScan
    {
        public bool? Deleted { get; set; }   
      
       // public int ScanID { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string TrackNoScan { get; set; }
        public DateTime ScanDateTime { get; set; }
        public string EmployeeID { get; set; }
        public string ScanTypeS { get; set; }
        public string ScanTypeP { get; set; }
        public string ScanDescS { get; set; }
        public string ScanDescP { get; set; }
        public string ScanCapture { get; set; }
        public string ScanRoute { get; set; }
        public string ScanProcess { get; set; }
        public string StatusCode { get; set; }
        public string ScanProcessErr { get; set; }
        public int USM_ID { get; set; }
        public DateTime USM_DATE { get; set; }
    }
}
