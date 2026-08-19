using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedexExpress.View.Domain.Report.Invoice
{
   public  class InvoiceRepAwbDetailDomainView
    {
        public int RowID { get; set; }
        public string InvoiceType { get; set; }
        public int GroupID { get; set; }
        public int CompanyID { get; set; }
        public int AgncyID { get; set; }
        public DateTime TransDate { get; set; }
        public string  InvNo { get; set; }
        public string AgnAWBNo { get; set; }
        public string GoodDescrip { get; set; }
        public string ShipCntPer { get; set; }
        public string ShipCompany { get; set; }      
        public string ConsigName { get; set; }
        public string ConsigCompany { get; set; }
        public string ConsingAdd1 { get; set; }
        public string ConsingAdd2 { get; set; }
        public string PackType { get; set; }
        public decimal RecFCCharge { get; set; }
        public decimal RecLCCharge { get; set; }
        public decimal OtherFCCharge { get; set; }
        public decimal OtherLCCharge { get; set; }
        public decimal BillWgt { get; set; }

        public string DestCountry { get; set; }
        public decimal LineLCTotalValue { get; set; }

        public decimal FrtFCAmount { get; set; }
        public decimal FhgFCAmount { get; set; }
        public decimal DebtorFCTotAmount { get; set; }
        public string ConsingCityName { get; set; }
        public decimal LineFCTotalValue { get; set; }
        public decimal DECV { get; set; }
        public decimal PACKCHG { get; set; }
        public string InvPrntCur { get; set; }
    }
}
