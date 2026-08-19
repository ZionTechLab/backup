using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.SAP.Models
{
    public class AccountGL
    {
        public string ItemNoAcc { get; set; }
        public string GLAccount { get; set; }
        public string ItemText { get; set; }
        public string AccType { get; set; }
        public int FisPeriod { get; set; }
        public string TaxCode { get; set; }
        public string ProfitCntr { get; set; }
    }
}