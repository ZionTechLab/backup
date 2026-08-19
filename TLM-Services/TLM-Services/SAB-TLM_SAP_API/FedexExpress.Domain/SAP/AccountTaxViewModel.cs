using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.View.Domain.SAP
{
    public class AccountTaxViewModel
    {
        public int ItemNoAcc { get; set; }
        public string GLAccount { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxRate { get; set; }
    }
}