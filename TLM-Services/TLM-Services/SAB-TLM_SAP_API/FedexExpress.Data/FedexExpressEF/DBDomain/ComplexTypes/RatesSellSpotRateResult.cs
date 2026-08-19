using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class RatesSellSpotRateResult
    {
        public int AutoID { get; set; }
        public bool Deleted { get; set; }
        public string ExpressID { get; set; }
        public string AgnAWBNo { get; set; }
        public string Remarks { get; set; }
        public DateTime EnterDate { get; set; }
        public decimal Rate { get; set; }
        public DateTime TransDate { get; set; }
        public int USM_ID { get; set; }
        public string FullName { get; set; }
        public DateTime USM_DATE { get; set; }
    }
}
