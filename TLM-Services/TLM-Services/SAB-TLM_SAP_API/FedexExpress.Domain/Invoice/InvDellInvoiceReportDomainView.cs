using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDellInvoiceReportDomainView
    {
        public string AgnAWBNo { get; set; }

        public DateTime TransDate { get; set; }
        public DateTime LastScanDate { get; set; }

        public string ORGCOUNTRY { get; set; }

        public string DESCOUNTRY { get; set; }

        public decimal TotWgt { get; set; }

        public decimal DeliveryChg { get; set; }

        //------------------- summery
        public DateTime DOCDATE { get; set; }
        public decimal VALFC { get; set; }
        public decimal ConvRate { get; set; }
        public string OrgCode { get; set; }
        public string BillOrg { get; set; }
       // public DateTime TransDate { get; set; }
       // public decimal DeliveryChg { get; set; }
        public int TotPkgs { get; set; }
        public decimal BillWgt { get; set; }
        public decimal DeliveryCost { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceNo { get; set; }
        public int Pods { get; set; }
        public string CompName { get; set; }
        //------------------ detail

        public DateTime PODDate { get; set; }
        public string AWBNO { get; set; }
        public string CompanyName { get; set; }
        public string Remark { get; set; }
      //  public string InvoiceNo { get; set; }




    }
}
