using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class ManifestClearenceResult
    {
        public string ClearanceCurrency { get; set; }
        public int ClearanceExgRatTarif { get; set; }
        public int ClearanceValue { get; set; }
    }
}
