using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Filters
{
    public class RefOrganizationDomainView
    {
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public string OrgCity { get; set; }
        public string OrgCountry { get; set; }
        public string OrgCountryN { get; set; }
        public string OrgPhone { get; set; }
        public string OrgMobile { get; set; }
    }
}
