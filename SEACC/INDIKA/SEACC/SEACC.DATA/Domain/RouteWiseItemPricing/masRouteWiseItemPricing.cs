using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain
{
    public  class masRouteWiseItemPricing
    {
        public string item_ID { get; set; }
        public int route_ID { get; set; }
        public string itemName { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal maxDiscount { get; set; }
    }
    public class masRouteWiseItemPricing_Save
    {
        public string item_ID { get; set; }
        public int route_ID { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal maxDiscount { get; set; }
    }
}