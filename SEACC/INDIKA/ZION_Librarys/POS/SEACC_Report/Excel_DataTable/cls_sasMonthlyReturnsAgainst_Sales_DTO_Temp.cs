using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report.Excel_DataTable
{
    public class cls_sasMonthlyReturnsAgainst_Sales_DTO_Temp
    {
        public string Route { get; set; }
        public string SalesRep { get; set; }
        
        public decimal MonthOneGross { get; set; }
        public decimal MonthOneReturn { get; set; }
        public decimal MonthTwoGross { get; set; }
        public decimal MonthTwoReturn { get; set; }
        public decimal MonthThreeGross { get; set; }
        public decimal MonthThreeReturn { get; set; }
        public decimal MonthFourGross { get; set; }
        public decimal MonthFourReturn { get; set; }
        public decimal MonthFiveGross { get; set; }
        public decimal MonthFiveReturn { get; set; }
    }
}
