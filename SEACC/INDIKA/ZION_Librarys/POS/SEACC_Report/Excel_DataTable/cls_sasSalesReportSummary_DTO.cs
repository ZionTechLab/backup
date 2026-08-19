using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report
{
    public class cls_sasSalesReportSummary_DTO
    {
        public string TxType { get; set; }
        public string Branch { get; set; }
        public string Tx_ID { get; set; }
        public DateTime TxDate { get; set; }

        public string SalesRep { get; set; }
        public string Customer { get; set; }
        public string CustomerClass { get; set; }
        public string CustomerType { get; set; }
        public string CustomerCategory { get; set; }

        public decimal Sale { get; set; }
        public decimal SalesReturn { get; set; }
        public decimal CreditNote { get; set; }
        public decimal DebitNote { get; set; }

        public decimal SalesQty { get; set; }
        public decimal ReturnQty { get; set; }
    }
}
