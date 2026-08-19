using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.CFG
{
    public class tbl_securityRoutePermission
    {
        public string user_ID { get; set; }
        public int route_ID { get; set; }
        public bool allowRead { get; set; }
        public bool allowWrite { get; set; }
        public bool allowDelete { get; set; }
        public bool allowApprovable { get; set; }
        public bool allowCheckable { get; set; }
        public bool allowUpdate { get; set; }
    }
}