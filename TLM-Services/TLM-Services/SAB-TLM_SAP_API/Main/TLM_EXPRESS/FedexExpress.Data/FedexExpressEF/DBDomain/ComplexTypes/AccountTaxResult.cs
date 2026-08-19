using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class AccountTaxResult
    {
        public int AutoId { get; set; }
        public string AcDocNo { get; set; }
        public int ItemNoAcc { get; set; }
        public string GLAccount { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxRate { get; set; }
       
    }
}
