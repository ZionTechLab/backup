using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Domain.SCS
{
    public class ItemPricing
    {
        public string route_Code { get; set; }
        public string item_ID { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal maxDiscount { get; set; }

    }
}
