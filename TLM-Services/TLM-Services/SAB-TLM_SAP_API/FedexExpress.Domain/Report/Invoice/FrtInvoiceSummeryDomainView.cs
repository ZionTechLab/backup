using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
   public class FrtInvoiceSummeryDomainView
    {
        public int numRowID { get; set; }
        public int GroupID { get; set; }
        public int CompanyID { get; set; }
        public DateTime InvDate { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string  InvNo { get; set; }
        public string AgnAWBNo { get; set; }
        public int OrgCode { get; set; }
        public string Organization { get; set; }
        public string InvPoduct { get; set; }
        public decimal ConvRate { get; set; }
        public string OrginCounty { get; set; }
        public string DestCountry { get; set; }
        public decimal FrtLCAmount { get; set; }
        public decimal FrtFCAmount { get; set; }
        public decimal FrtTaxCode1Val { get; set; }
        public decimal FrtTaxCode2Val { get; set; }
        public decimal FhgLCAmount { get; set; }
        public decimal FhgFCAmount { get; set; }
        public decimal FhgTaxCode1Val { get; set; }
        public decimal FhgTaxCode2Val { get; set; }
        public decimal RecFCCharge { get; set; }
        public decimal RecLCCharge { get; set; }
        public decimal OtherFCCharge { get; set; }
        public decimal OtherLCCharge { get; set; }
        public decimal BillWgt { get; set; }
        public decimal TotalFCValue { get; set; }
        public decimal LineLCTotalValue { get; set; }
        public decimal LineTotNBT { get; set; }
        public decimal DebtorFCTotAmount { get; set; }
        public decimal DebtorLCTotAmount { get; set; }

        public string ProductList { get; set; }
        public string ACCNo { get; set; }
        public decimal DimWgt { get; set; }
        public string BillTo { get; set; }
        public string SvcType { get; set; }
        public string PackType { get; set; }
        public decimal PostalTax { get; set; }
        public string BillAccountNo { get; set; }
        public string PayMode { get; set; }
        public decimal ActualWgt { get; set; }

    }
}
