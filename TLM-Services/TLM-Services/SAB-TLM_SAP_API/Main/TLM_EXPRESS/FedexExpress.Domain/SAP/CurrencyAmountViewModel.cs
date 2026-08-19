using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.View.Domain.SAP
{
    public class CurrencyAmountViewModel
    {
        public int ItemNoAcc { get; set; }
        public decimal BaseAmt { get; set; }
        public string CurrencyISO { get; set; }
        public decimal AmtDocCur { get; set; }
        public decimal TaxAmt { get; set; }

    }
}