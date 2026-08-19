using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class InvDutyChargeResult
    {
        public string DocType { get; set; }
        public short? Seqno { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeDesc { get; set; }
        public string ChargMapCode { get; set; }
        public string GlRevAc { get; set; }
        public string GlCosAc { get; set; }
        public string TaxCode1 { get; set; }
        public string TaxCode2 { get; set; }
        public string TaxCode3 { get; set; }
        public decimal TaxCode1Rate { get; set; }
        public decimal TaxCode2Rate { get; set; }
        public decimal TaxCode3Rate { get; set; }
        public string TaxGroup1 { get; set; }
        public string TaxGroup2 { get; set; }
        public string TaxGroup3 { get; set; }
        public decimal SellLC { get; set; }
        public decimal SellFC { get; set; }
        public decimal PayLC { get; set; }
        public decimal PayFC { get; set; }
        public decimal ConvRate { get; set; }
        public string IsSellFix { get; set; }
        public string IsCostFix { get; set; }
    }
}
