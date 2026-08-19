using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public  class RefATFEmployee
    {
        public int EmpNo { get; set; }

        public string EmpName { get; set; }
        public string AuthAllow { get; set; }
        public int USM_ID { get; set; }
        public decimal AuthAmount { get; set; }
        public string Active { get; set; }
        public string CurrencyCode { get; set; }

        public int CMPY { get; set; }

    }
}
