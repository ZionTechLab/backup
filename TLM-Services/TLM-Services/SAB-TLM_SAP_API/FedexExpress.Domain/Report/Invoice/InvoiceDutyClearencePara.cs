using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
   public  class InvoiceDutyClearencePara
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public string InvoiceNo { get; set; }
        public int UserID { get; set; }

        public string OutstandiY { get; set; }

    }
}
