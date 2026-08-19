using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class CurrencyAmountResult
    {
        public int AutoId { get; set; }
        public string AcDocNo { get; set; }
        public int ItemNoAcc { get; set; }
        public string Currency { get; set; }
        public string CurrencyISO { get; set; }
        public decimal AmtDocCur { get; set; }
        public decimal BaseAmt { get; set; }
        public decimal TaxAmt { get; set; }


    }
}
