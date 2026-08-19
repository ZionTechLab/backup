using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.SAP.Models
{
    public class CurrencyAmount
    {
        public string ItemNoAcc { get; set; }
        public decimal BaseAmt { get; set; }
        public string CurrencyISO { get; set; }
        public decimal AmtDocCur { get; set; }
        public decimal TaxAmt { get; set; }
    }
}