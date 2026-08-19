using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public  class RptManifestResult
    {
        public int SerialNo { get; set; }
        public string AirwaybilNo { get; set; }
        public string RecieverName { get; set; }
        public int NoOfPkgs { get; set; }
        public decimal TotWeight { get; set; }
        public decimal ShipValueFc { get; set; }
        public string ManCurrencyFc { get; set; }
        public string StationID { get; set; }
        public string Terms { get; set; }
        public string SenderReference { get; set; }
        public string MasterAwbNo { get; set; }
        public decimal ShipValuLc { get; set; }
        public string ShipValType { get; set; }
        public decimal DutyValue { get; set; }
        public int InvoiceNo { get; set; }
        public string ConsolID { get; set; }
        public DateTime TransDate { get; set; }
        public string CompanyName { get; set; }
        public string AgencyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ShipDate { get; set; }
    }
}
