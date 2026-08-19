using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class ClearancePreAlertDomainView
    {
        public bool Deleted { get; set; }
        public int GroupID { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string AgncyID { get; set; }
        public string ShipType { get; set; }
        public string TransMode { get; set; }
        [Required(ErrorMessage = "Please enter Console No")]
        public string ConsId { get; set; }
        public DateTime TransDate { get; set; }
        public string VisaRootID { get; set; }
        [Required(ErrorMessage = "Please enter Origin")]
        public string OrgHubID { get; set; }
        [Required(ErrorMessage = "Please enter Destination")]
        public string DesHubID { get; set; }
        public string AlNumCode { get; set; }
        [Required(ErrorMessage = "Please enter Flight No")]
        public string FlightNo { get; set; }
        public DateTime AriDate { get; set; }
        public DateTime DepDate { get; set; }
        public TimeSpan AriTime { get; set; }
        public TimeSpan DepTime { get; set; }
        [Required(ErrorMessage = "Please enter Master No")]
        public string MAWBNo { get; set; }
        public decimal ALActWgt { get; set; }
        public decimal ALChgWgt { get; set; }
        public decimal AlFreightChg { get; set; }
        public string Currency { get; set; }
        public string Remarks { get; set; }
        public bool HighValueY { get; set; }
        public string ExpressCons { get; set; }
    }
}
