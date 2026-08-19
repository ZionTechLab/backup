using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    [NotMapped]
    public class CfgDtaxCalDomainView
    {
        public decimal ShipValueFrom { get; set; }
        public decimal ShipValueTo { get; set; }
        public string ShipValueType { get; set; }
        public int ShipValueTypeCata { get; set; }
        public string DutyExcempt { get; set; }
        public decimal CostValueP { get; set; }
        public decimal CostValueF { get; set; }
    }
}
