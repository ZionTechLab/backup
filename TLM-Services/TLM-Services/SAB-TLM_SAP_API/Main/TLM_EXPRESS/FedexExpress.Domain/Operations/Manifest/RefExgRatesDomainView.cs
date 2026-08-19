using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class RefExgRatesDomainView
    {
        
        public string Currency { get; set; }
        public DateTime EffectDate { get; set; }
        public decimal ExgRate { get; set; }
        public string Remarks { get; set; }       
        public int CMPY { get; set; }
        public string ClearanceCurrency { get; set; }
    }
}
