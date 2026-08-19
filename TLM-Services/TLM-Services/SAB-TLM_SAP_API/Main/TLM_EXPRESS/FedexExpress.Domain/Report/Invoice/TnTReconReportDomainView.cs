using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
    public class TnTReconReportDomainView
    {
        public string AwbNumber { get; set; }
        public DateTime TrDate { get; set; }
        public string  InvNo { get; set; }
        public string OrgnCountry { get; set; }
        public string DestCountry { get; set; }
        public string ProductSub { get; set; }
        public decimal BillWeight { get; set; }
        public string Remarks { get; set; }
        public string RemarksAR { get; set; }
        public string ReasonReject { get; set; }
        public decimal FRT_USD { get; set; }
        public decimal FCI_USD { get; set; }
        public decimal ESS_USD { get; set; }
        public decimal NetRev { get; set; }
        public string ErrorMsg { get; set; }
        public string TrInvNo { get; set; }
        public decimal  TrBillWgt { get; set; }
        public string TrProductMain { get; set; }
        public string TrProductSub { get; set; }
        public string TrOrgCountry { get; set; }
        public string TrDesCountry { get; set; }
        public decimal  TrFrtCostFC { get; set; }
        public string AgencyName { get; set; }
        public string CompanyName { get; set; }
        public string TrType { get; set; }
        public decimal CostMinDiff { get; set; }
        public decimal CostPlusDiff { get; set; }
        public string MaxWeek { get; set; }
        public string MinWeek { get; set; }
        public int ZoneCode { get; set; }
        public int weekNum { get; set; }
        public decimal TotVarian { get; set; }
        public decimal TrFrtFuel { get; set; }
        public decimal FuelDiff { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public decimal MHEESS { get; set; }
        public decimal ESS_DIFF { get; set; }
        public decimal TOT_DIFF { get; set; }

    }
}
