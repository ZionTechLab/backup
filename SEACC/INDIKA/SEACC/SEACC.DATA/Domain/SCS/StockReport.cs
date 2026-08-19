using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SCS
{
    public class StockReport
    {   public string Item_ID { get; set; }
        public string Item_Name { get; set; }
        public string Store_ID { get; set; }
        public string Store_Name { get; set; }
        public string Item_Class_ID { get; set; }
        public string Item_Class_Name { get; set; }
        public string Item_Type_ID { get; set; }
        public string Item_Type_Name { get; set; }
        public string Item_Category_ID { get; set; }
        public string Item_Category_Name { get; set; }
        public string Uom_ID { get; set; }
        public string Uom_Name { get; set; }
        public decimal QTY { get; set; }
    }
}