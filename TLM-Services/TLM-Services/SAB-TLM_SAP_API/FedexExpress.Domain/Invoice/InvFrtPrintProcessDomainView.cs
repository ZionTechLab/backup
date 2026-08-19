using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvFrtPrintProcessDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyCode { get; set; }
        public string ShipType { get; set; }
        public string TransDate { get; set; }
        public string AWBNumber { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string SrvType { get; set; }
        public string PackType { get; set; }
        public string InvoiceNo { get; set; }
    }
}
