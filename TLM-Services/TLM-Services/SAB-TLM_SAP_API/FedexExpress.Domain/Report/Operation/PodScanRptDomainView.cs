using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedexExpress.View.Domain.Operations
{
    public class PodScanRptDomainView
    {
        public DateTime TrDate { get; set; }
        public string AwbNo { get; set; }
        public string Country { get; set; }
        public string Shipper { get; set; }
        public string DeliveryDate { get; set; }
        public string CommDate { get; set; }
        public string DelStatus { get; set; }
        public string DelStatusRemark { get; set; }
        public string Remarks { get; set; }
        public string Company { get; set; }
        public string Agency { get; set; }
        public string Scans { get; set; }
    }
}
