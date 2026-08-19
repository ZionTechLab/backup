using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
   public class InvDutyExtrateResult
    {      
        public int ExgRatTarif { get; set; }
        public string BaseCurrency { get; set; }
        public string DefCurrency { get; set; }
        public string Currency { get; set; }
        public DateTime EffectDate { get; set; }
        public decimal ExgRate { get; set; }
        public string ClearCurrency { get; set; }
    }
}
