using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class SpotRatesAWBResult
    {
        public int? CMPY { get; set; }
        public int? AgncyCode { get; set; }
        public string ExpressID { get; set; }
        public string AgnAWBNo { get; set; }
        public DateTime TransDate { get; set; }
        public string AgnTrackNo { get; set; }
        public string BillTransChgY { get; set; }
        public decimal InvNoTransChg { get; set; }
    }
}
