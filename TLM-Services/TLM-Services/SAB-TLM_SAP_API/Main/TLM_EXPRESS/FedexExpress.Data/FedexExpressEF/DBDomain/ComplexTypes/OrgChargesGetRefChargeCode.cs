using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
   public class OrgChargesGetRefChargeCode
    {
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public decimal Amount { get; set; }
        public string excemptY { get; set; }
        public string SalesAreaID { get; set; }
        public string SalesAreaName { get; set; }
        public string ChargeCode { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public string OrgCity { get; set; }
    }
}
