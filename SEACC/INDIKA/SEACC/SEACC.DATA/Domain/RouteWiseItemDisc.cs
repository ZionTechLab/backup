using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain
{
    public class RouteWiseItemDisc_View
    {
        public int route_ID { get; set; }
        public string route_Code { get; set; }
        public decimal MaxDisc { get; set; }
    }

    public class RouteWiseItemDisc_Save
    {
        public int route_ID { get; set; }
        public decimal MaxDisc { get; set; }
    }
}