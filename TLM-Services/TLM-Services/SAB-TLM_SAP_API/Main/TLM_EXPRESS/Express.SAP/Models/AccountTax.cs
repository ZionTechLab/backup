using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.SAP.Models
{
    public class AccountTax
    {
        public string ItemNoAcc { get; set; }
        public string GLAccount { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxRate { get; set; }
       
    }
}