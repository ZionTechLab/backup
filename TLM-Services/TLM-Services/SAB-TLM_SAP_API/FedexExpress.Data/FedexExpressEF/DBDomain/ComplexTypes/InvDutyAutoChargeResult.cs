using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public  class InvDutyAutoChargeResult
    {
        public string DocId { get; set; }
        public int ShipValueTypeCata { get; set; }
        public string DocType { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeCodeCal { get; set; }
        public decimal ValueP { get; set; }
    }
}
