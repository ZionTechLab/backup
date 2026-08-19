using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Inquiry
{
    public class RevenuPramDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public DateTime TrDateFrom { get; set; }
        public DateTime TrDateTo { get; set; }
        public int RevImport { get; set; }
        public int RevPickUp { get; set; }
        public int Rev3rdParty { get; set; }
        public int RevExport { get; set; }
        public int RevDelivery { get; set; }
        public int InvInvoiced { get; set; }
        public int InvUnbill { get; set; }
        public int InvUninvoiced { get; set; }
        public  int CustomerCode { get; set; }
        public DateTime InvDateFrom { get; set; }
        public DateTime InvDateTo { get; set; }

        public DateTime PrnInvDateFrom { get; set; }
        public DateTime PrnInvDateTo { get; set; }
        public string SalesArea { get; set; }
        public int IsAllRevType { get; set; }
        public int IsAllInvType { get; set; }
        public int IsAllCust { get; set; }
        public int IsAllInvDate { get; set; }
        public int IsAllInvPrnDate { get; set; }
        public int IsAllSalesArea { get; set; }

    }
}
