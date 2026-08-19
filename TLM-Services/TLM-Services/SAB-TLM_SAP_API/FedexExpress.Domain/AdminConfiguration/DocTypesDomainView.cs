using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.AdminConfiguration
{
    public class DocTypesDomainView
    {

        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string DocType { get; set; }
        public string DocTypeName { get; set; }
        public string DocCategory { get; set; }
        public string PaidLF { get; set; }
        public int BillOrgCode { get; set; }
        public string Detain { get; set; }
        public string Misrote { get; set; }
        public int ExgRateTarif { get; set; }

        public int ShipValueTypeCata { get; set; }
        public string ShipValuType { get; set; }
        public int IsHighValue { get; set; }
        public string Active  {get;set;}
    }
}
