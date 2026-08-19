using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
   public  class InvoicePickupRptDomainView
    {
        
        public string AgnAWBNo { get; set; }

        public DateTime TransDate { get; set; }  

        public string ORGCOUNTRY { get; set; }

        public string DESCOUNTRY { get; set; }

        public decimal TotWgt { get; set; }

        public decimal Pickupchg { get; set; }
    }
}
