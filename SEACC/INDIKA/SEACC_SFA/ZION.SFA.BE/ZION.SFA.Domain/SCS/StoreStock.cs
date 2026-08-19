using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Domain.SCS
{
    public class StoreStock
    {
      //  public string store_ID { get; set; }
        public string item_ID { get; set; }
        public decimal qty { get; set; }
       // public decimal UnitPrice { get; set; }
    }
    public class StoreStock_Ex: StoreStock
    {
        public string itemName { get; set; }
    }
}