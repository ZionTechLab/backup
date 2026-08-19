using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
   public class InvDutyChargeDomainView
    {
        public string ChargeCode { get; set; }
        public string ChargeDesc { get; set; }
        public string DocType { get; set; }
        public short? Seqno { get; set; }       
        public decimal SellLC { get; set; } 
        public decimal PayLC { get; set; }       
        public string LCurrType { get; set; }
        public decimal SellFC { get; set; }
        public decimal PayFC { get; set; }
        public string FCurrType { get; set; }
        public decimal CurrencyRate { get; set; }
        public string GlRevAc { get; set; }
        public string GlCosAc { get; set; }
        public string TaxCode1 { get; set; }
        public string TaxCode2 { get; set; }
        public string TaxCode3 { get; set; }

        public decimal TaxCode1Rate { get; set; }
        public decimal TaxCode2Rate { get; set; }
        public decimal TaxCode3Rate { get; set; }

        public decimal TaxCode1Value { get; set; }
        public decimal TaxCode2Value { get; set; }
        public decimal TaxCode3Value { get; set; }
        public decimal ConvRate { get; set; }
        public string IsSellFix { get; set; }
        public string IsCostFix { get; set; }

    }
}
