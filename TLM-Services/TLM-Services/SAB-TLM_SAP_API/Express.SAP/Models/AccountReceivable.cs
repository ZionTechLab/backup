using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.SAP.Models
{
    public class AccountReceivable
    {
        public string ItemNoAcc { get; set; }
        public string Customer { get; set; }
        public string CompCode { get; set; }
        public string AllocNumber { get; set; }
        public string ItemText { get; set; }
        public string PaymentCurISO { get; set; }
        public string ProfitCntr { get; set; }
    }
}