using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
   public class FedexReconReportDomainView
    {
        public string AgnAWBNo { get; set; }
        public string FedexInv { get; set; }
        public DateTime FedexInvDate { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal BillAmount { get; set; }
        public decimal FuelChg { get; set; }
        public decimal OtherChg { get; set; }
        public decimal FedexCost { get; set; }
        public decimal BillWeight { get; set; }
        public string ShipCounty { get; set; }
        public string ConCountry { get; set; }
        public string PackType { get; set; }
        public decimal  MheCost { get; set; }
        public decimal TrBillWgt { get; set; }
        public string MheShipCountry { get; set; }
        public string MheConCountry { get; set; }
        public string  TrPackType { get; set; }
        public string BillType { get; set; }
        public string ErrorMsg { get; set; }
        public string GspLocation { get; set; }
        public string CompanyName { get; set; }
        public string AgencyName { get; set; }
        public int AgencyID { get; set; }

        public int CompanyID { get; set; }
        public string TrType { get; set; }
        public string FromInvoice { get; set; }

        public string ToInvoice { get; set; }
        public decimal CostMinus { get; set; }
        public decimal CostPlus { get; set; }
        public decimal CostVariation { get; set; }
        public decimal FuelVariation { get; set; }
        public decimal TotVarian { get; set; }
        public decimal TotVarianGain { get; set; }
        public decimal TotVarianLost { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }


    }
}
