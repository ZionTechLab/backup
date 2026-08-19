using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
   public class ClrInvOrgnPopParam
    {
        public int CompanyID { get; set; }
        public int AgencyCode { get; set; }
        public int UserID { get; set; }
        public string ExpressID { get; set; }
        public int InvoiceNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string IscrdAllow { get; set; }

        public string TaxRegNo { get; set; }

    }
}
