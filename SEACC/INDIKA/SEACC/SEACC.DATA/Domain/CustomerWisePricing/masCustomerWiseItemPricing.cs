using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.CustomerWisePricing
{
  public   class masCustomerWiseItemPricing
    {
        public string item_ID { get; set; }
        public string customer_ID { get; set; }
        public string itemName { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal maxDiscount { get; set; }
        public bool Active { get; set; }
    }
    public class masCustomerWiseItemPricing_Save
    {
        public string item_ID { get; set; }
        public string customer_ID { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal maxDiscount { get; set; }
    }
}
