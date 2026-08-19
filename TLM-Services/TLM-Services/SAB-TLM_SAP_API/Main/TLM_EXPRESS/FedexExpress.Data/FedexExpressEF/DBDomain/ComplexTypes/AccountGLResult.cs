using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class AccountGLResult
    {
        public int AutoId { get; set; }
        public string AcDocNo { get; set; }
        public int ItemNoAcc { get; set; }
        public string GLAccount { get; set; }
        public string ItemText { get; set; }
        public string AcctType { get; set; }
        public int FisPeriod { get; set; }
        public string TaxCode { get; set; }
        public string ProfitCtr { get; set; }

        public string RefKey1 { get; set; }

        public string RefKey2 { get; set; }

        public string RefKey3 { get; set; }

        public string CostObject { get; set; }

        public string AllocNum { get; set; }


    }
}
