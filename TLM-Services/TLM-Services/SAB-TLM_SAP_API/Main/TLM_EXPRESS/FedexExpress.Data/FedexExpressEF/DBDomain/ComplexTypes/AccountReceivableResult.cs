using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class AccountReceivableResult
    {
        public int AutoId { get; set; }
        public string AcDocNo { get; set; }
        public int ItemNoAcc { get; set; }
        public string Customer { get; set; }
        public string CompCode { get; set; }
        public string AllocNmbr { get; set; }
        public string ItemText { get; set; }
        public string PymtCurISO { get; set; }
        public string ProfitCtr { get; set; }
        public string RefKey1 { get; set; }
        public string RefKey2 { get; set; }
        public string RefKey3 { get; set; }
        public string PmntTrms { get; set; }
        public string GlAccount { get; set; }

        public string PaymtRef {get;set;}
    }
}
