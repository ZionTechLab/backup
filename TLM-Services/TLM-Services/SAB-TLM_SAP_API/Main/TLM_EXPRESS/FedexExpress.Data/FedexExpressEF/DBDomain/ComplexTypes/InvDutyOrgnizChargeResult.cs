using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class InvDutyOrgnizChargeResult
    {
        [Column(TypeName = "char")]
        public string ChargeCode { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }
    }
}
