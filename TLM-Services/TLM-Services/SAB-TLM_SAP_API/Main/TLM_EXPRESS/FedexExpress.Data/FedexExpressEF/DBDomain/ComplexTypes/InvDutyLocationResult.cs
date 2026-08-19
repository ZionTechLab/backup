using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
   public  class InvDutyLocationResult
    {
        public string Country { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public String BranchCode { get; set; }
        public string Hub { get; set; }
        public string GateWay { get; set; }
        public string Station { get; set; }
        public string Remarks { get; set; }
        public string Active { get; set; }
    }
}
