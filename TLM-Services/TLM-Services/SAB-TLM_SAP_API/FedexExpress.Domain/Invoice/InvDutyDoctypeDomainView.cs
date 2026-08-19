using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    [NotMapped]
    public class InvDutyDoctypeDomainView
    {
        public string DocType { get; set; }
        public string DoctypeN { get; set; }
        public string DocCata { get; set; }
        public string PaidLF { get; set; }
        public int BillOrgCode { get; set; }
        public int ExgRateTarif { get; set; }
        public int ShipValueTypeCata { get; set; }
        public string ShipValuType { get; set; }
        public int IsHighValue { get; set; }
        public string Active { get; set; }
        public string BillDtaxChg { get; set; }
    }
}
