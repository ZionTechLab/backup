using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDutyAutoChargeDomainView
    {
       public string DocId { get; set; }
        public int ShipValueTypeCata { get; set; }
        public string DocType { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeCodeCal { get; set; }
        public decimal ValueP { get; set; }
    }
}
