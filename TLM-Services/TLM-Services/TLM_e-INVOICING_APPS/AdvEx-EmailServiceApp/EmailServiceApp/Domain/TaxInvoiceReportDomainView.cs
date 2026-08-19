using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class TaxInvoiceReportDomainView
    {
        public int GroupID { get; set; }
        public string AgncyID { get; set; }
        public int CompanyID { get; set; }
        public string DocReference { get; set; }
        public string RefNo1 { get; set; }
        public string RefNo2 { get; set; }
        public string RefNo3 { get; set; }
        public DateTime DocDate { get; set; }
        public decimal JobNo { get; set; }
        public string InvNo { get; set; }
        public string OrgName { get; set; }

        // New Add
        public string OrgContact { get; set; }
        //
        public string OrgCountry { get; set; }
        //
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public string OrgCity { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeDesc { get; set; }
        //
        public string ChargeArabic { get; set; }
        //

        public decimal ConvRate { get; set; }
        public string LC { get; set; }
        public string FC { get; set; }
        public decimal LineAmount { get; set; }
        public decimal LineTaxTotal { get; set; }
        public decimal LineTotalAmount { get; set; }
        public string DocType { get; set; }
        public string Remarks { get; set; }

        public decimal CustomVal { get; set; }
        public decimal TAX1 { get; set; }
        public decimal TAX2 { get; set; }
        public decimal TAX3 { get; set; }

        public string SVATNO { get; set; }
        public string VATNO { get; set; }

        public string Detain { get; set; }

        public string GoodDescp { get; set; }
        public decimal VALFC { get; set; }

       // public string OrgContact { get; set; }
        public string BillOrgCountry { get; set; }

        public string PayMode { get; set; }

        public string SenRefNotes { get; set; }
        public string PrintUser { get; set; }
        public string ManCurrency { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        //public string ChargeArabic { get; set; }

        public string PayRefNo { get; set; }
        public string CusdecNo { get; set; }
        public DateTime Paydate { get; set; }

        public string ExpressID { get; set; }

        public string SenCompany { get; set; }

        public string SenCityN { get; set; }
        public string RecCompany { get; set; }
        public string RecCityN { get; set; }
        public decimal CustomsPkgVal { get; set; }
        public decimal TotWgt { get; set; }
        public int TotPkgs { get; set; }
        
        
        public DateTime ShipDate { get; set; }

        
        



    }
}
