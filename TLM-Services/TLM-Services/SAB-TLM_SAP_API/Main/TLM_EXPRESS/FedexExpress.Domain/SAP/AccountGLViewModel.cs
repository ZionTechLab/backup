using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.View.Domain.SAP
{ 
    public class AccountGLViewModel
    {
        public int ItemNoAcc { get; set; }
        public string GLAccount { get; set; }
        public string ItemText { get; set; }
        public string AccType { get; set; }
        public int FisPeriod { get; set; }
        public string TaxCode { get; set; }
        public string ProfitCntr { get; set; }

        public string RefKey1 { get; set; }

        public string RefKey2 { get; set; }

        public string RefKey3 { get; set; }

        public string CostObject { get; set; }


        public string AllocNum { get; set; }



    }
}