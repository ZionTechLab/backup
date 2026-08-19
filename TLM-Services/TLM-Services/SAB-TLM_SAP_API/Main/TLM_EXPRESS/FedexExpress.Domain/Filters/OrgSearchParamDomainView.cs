using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Filters
{
   public  class OrgSearchParamDomainView
    {
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgAdd1 { get; set; }
        public string OrgAdd2 { get; set; }

    }
}
