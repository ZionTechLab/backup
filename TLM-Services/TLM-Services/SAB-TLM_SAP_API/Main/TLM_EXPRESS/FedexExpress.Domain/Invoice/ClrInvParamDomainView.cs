using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
   public class ClrInvParamDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FromInv { get; set; }
        public int ToInv { get; set; }
        public string InvDocTypes { get; set; }
        public string SearchType { get; set; }
        public int UserID { get; set; }
        public string Awbnumber { get; set; }

        public string OutstandingY { get; set; }
    }
}
