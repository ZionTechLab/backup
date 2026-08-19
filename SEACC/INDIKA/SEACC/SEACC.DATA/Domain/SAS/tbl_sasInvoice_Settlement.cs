using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SAS
{
    public class tbl_sasInvoice_Settlement
    {
        public string Txn_ID { get; set; }
        public DateTime Txn_Date { get; set; }
        public decimal UnsettledAmount { get; set; }
    }
}