using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Domain.SCS
{
    public class initializeResultView
    {
        public string route { get; set; } 
        public int userType { get; set; }
        public List<tbl_genItemMaster> Items { get; set; }
        public List<Customer> Customer { get; set; }
        public List<CustomerOutstanding> CustomerOutstanding { get; set; }
        public List<SalesHistory> SaleHistory { get; set; }
        public List<ItemPricing> ItemPricing { get; set; }
    }
}