using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class ExchangeRateResult
    {
        public int ExgRatTarif { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public DateTime EffectDate { get; set; }
        public decimal ExgRate { get; set; }
    }
}
