using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class ExchangeRateValueResult
    {
        public int ExgRateTarif { get; set; }     
        public string Currency { get; set; }       
        public DateTime EffectDate { get; set; }     
        public decimal  ExgRate { get; set; }
        public string Remarks { get; set; }
        public int UserID { get; set; }
    }
}
