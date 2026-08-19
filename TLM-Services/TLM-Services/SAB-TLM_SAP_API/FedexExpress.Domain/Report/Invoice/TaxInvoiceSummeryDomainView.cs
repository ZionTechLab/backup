using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
    public class TaxInvoiceSummeryDomainView
    {
        public string RouteID { get; set; }
        public string CompanyN { get; set; }
        public string AgencyN { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public string PayMode { get; set; }
        public string AgnAWBNo { get; set; }
        public string OrgName { get; set; }
        public decimal InvAmount { get; set; }
        public decimal InvBalance { get; set; }

    }
}
