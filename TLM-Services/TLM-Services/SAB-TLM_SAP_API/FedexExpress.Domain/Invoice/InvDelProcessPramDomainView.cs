using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDelProcessPramDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public string Uptodate { get; set; }
        public string DocDate { get; set; }
        public int UserID { get; set; }
        public string InvoiceNo { get; set; }
        public int BillOrgCode { get; set; }
        public string DocType { get; set; }
        public int ToBillAwbCount { get; set; }
        



    }
}
