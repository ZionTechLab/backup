using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
   public  class InvDutyJobtransactDomainView
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime PayDocDate { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymentNo { get; set; }
        public string PayDocType { get; set; }
        public string SellDocType { get; set; }
        public DateTime TransDate { get; set; }
    }
}
