using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.BSS
{
   public class DebtorOutstanding
    {
        public string transactionCode { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
