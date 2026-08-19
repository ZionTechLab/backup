using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class OrgChargeGetCurrency
    {
        public string Currency { get; set; }
        public int CompID { get; set; }
    }
}
