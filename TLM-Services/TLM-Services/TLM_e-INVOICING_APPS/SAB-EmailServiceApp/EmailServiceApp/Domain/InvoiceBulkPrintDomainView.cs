using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class InvoiceBulkPrintDomainView
    {
        public decimal InvNumFrom { get; set; }
        public decimal InvNumTo { get; set; }
        public int CompanyID { get; set; }
        public int AgencyCode { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public string InvoiceType { get; set; }
        public bool IsDirect { get; set; }

    }
}
