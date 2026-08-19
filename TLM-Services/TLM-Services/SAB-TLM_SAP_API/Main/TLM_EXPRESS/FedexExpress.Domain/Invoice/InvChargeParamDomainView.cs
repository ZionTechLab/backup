using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvChargeParamDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public string  InvDocType { get; set; }
        public string PayDocType { get; set; }
        public DateTime DocDate { get; set; }
        public decimal ClrShipValue { get; set; }
        public int ShipValCat { get; set; }
        public string ExpressID { get; set; }
        public string InvoiceNo { get; set; }
        public string paymentNo { get; set; }
        public int OrgCode { get; set; }
        public string IsDutyExcempt { get; set; }
       
    }
}
