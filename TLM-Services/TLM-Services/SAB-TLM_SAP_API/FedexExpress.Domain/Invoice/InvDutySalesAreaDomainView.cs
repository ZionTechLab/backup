using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDutySalesAreaDomainView
    {
        public string SalesAreaID { get; set; }
        public string SalesAreaName { get; set; }
        public bool Active { get; set; }
        public string BranchCode { get; set; }
    }
}
