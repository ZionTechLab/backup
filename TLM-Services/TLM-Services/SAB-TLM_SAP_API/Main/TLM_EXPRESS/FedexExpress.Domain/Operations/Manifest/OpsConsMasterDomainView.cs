using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class OpsConsMasterDomainView
    {
        public bool? Deleted { get; set; }
        public int GroupID { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string ConsId { get; set; }
        public DateTime TransDate { get; set; }
        public string VisaRootID { get; set; }
        public string OrgHubID { get; set; }
        public string ShipType { get; set; }
        public string DesHubID { get; set; }
        public string AlNumCode { get; set; }
        public string FlightNo { get; set; }
        public DateTime AriDate { get; set; }
        public DateTime DepDate { get; set; }
        public TimeSpan AriTime { get; set; }
        public TimeSpan DepTime { get; set; }
        public string MAWBNo { get; set; }
        public decimal ALActWgt { get; set; }
        public decimal ALChgWgt { get; set; }
        public decimal AlFreightChg { get; set; }
        public string Currency { get; set; }
        public string Remarks { get; set; }
        public string HighValueY { get; set; }
        public string TransMode { get; set; }
    }
}
