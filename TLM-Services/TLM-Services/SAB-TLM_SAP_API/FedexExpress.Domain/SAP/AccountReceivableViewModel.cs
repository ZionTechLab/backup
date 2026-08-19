using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.View.Domain.SAP
{
    public class AccountReceivableViewModel
    {
        public int ItemNoAcc { get; set; }
        public string Customer { get; set; }
        public string CompCode { get; set; }
        public string AllocNumber { get; set; }
        public string ItemText { get; set; }
        public string PaymentCurISO { get; set; }
        public string ProfitCntr { get; set; }
        public string RefKey1 { get; set; }
        public string RefKey2 { get; set; }
        public string RefKey3 { get; set; }
        public string PmntTrms { get; set; }
        public string GlAccount { get; set; }

        public string PaymtRef { get; set; }

       
    }
}