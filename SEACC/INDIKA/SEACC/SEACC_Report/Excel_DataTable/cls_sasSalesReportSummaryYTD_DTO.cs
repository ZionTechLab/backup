using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report
{
    public class cls_sasSalesReportSummaryYTD_DTO
    {
        public string Branch { get; set; }
        public string SalesRep { get; set; }
        public string CustomerClass { get; set; }
        public string CustomerType { get; set; }
        public string CustomerCategory { get; set; }
        
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }

        public decimal TotalQty { get; set; }
    }
}
