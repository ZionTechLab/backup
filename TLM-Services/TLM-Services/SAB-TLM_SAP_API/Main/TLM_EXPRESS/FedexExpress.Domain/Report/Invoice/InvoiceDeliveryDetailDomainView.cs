using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
    public class InvoiceDeliveryDetailDomainView
    {
        public DateTime  PODDate { get; set; }
        public string AWBNO { get; set; }
        public string CompanyName { get; set; }
        public string Remark { get; set; }
        public string InvoiceNo { get; set; }
    }
}
