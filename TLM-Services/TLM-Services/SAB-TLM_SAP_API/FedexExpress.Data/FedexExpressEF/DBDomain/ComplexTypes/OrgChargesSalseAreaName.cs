using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
  public class OrgChargesSalseAreaName
    {
        public string SalesAreaID { get; set; }
        public string SalesAreaName { get; set; }
    }
}
