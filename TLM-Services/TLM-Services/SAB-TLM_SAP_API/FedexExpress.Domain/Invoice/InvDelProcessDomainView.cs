using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDelProcessDomainView
    {
        public string AirwaybillNo { get; set; }
        public string TrDate { get; set; }
        public int  InvoiceNo { get; set; }

        public int CountNonDelAwb { get; set; }
        public decimal CountNonDelWgt { get; set; }

        public int CountPendingAwb { get; set; }
        public decimal CountPendingWgt { get; set; }

        public int CountBillAwb { get; set; }
        public decimal  CountBillWgt { get; set; }
        public decimal CountBillAmt { get; set; }
        
        public int  LastInvoiceNo { get; set; }
        public string DteInvoiced { get; set; }
        public string BillParty { get; set; }
       
        public string BillOrgName { get; set; }
        public string BillOrgAdd1 { get; set; }
        public string BillOrgAdd2 { get; set; }
        public string BillOrgCity { get; set; }
        public string BillOrgCountry { get; set; }
        public int BillOrgCode { get; set; }
        public int CountInvAwb { get; set; }
        public decimal CountInvWght { get; set; }
        public decimal CountInvRev { get; set; }
        public string SellCurrencyFC { get; set; }
        public string SellCurrencyLC { get; set; }
        public int SellExgRateTarif { get; set; }
        public decimal ExtRate { get; set; }
        public string DocType { get; set; }

        public int InvoiceAWBCount { get; set; }
        public decimal  InvoiceBillWgt { get; set; }
        public decimal  InvoiceFCValue { get; set; }
        public decimal InvoiceLCValue { get; set; }
        public DateTime InvoiceDate { get; set; }
        






    }
}
