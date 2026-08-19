using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public  class ExtRatesTypesResult
    {
      public int ExgRatTarif { get; set; }
      public string ExgRatTarifN { get; set; }
      public string BaseCurrency { get; set; }
      public string DefCurrency { get; set; }
        public string CurrencyN { get; set; }
      public string Active { get; set; }
    }
}
