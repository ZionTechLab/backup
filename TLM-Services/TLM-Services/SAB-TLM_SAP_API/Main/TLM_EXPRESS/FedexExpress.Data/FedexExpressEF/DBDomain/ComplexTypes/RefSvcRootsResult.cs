using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class RefSvcRootsResult
    {
        public int CMPY { get; set; }
        public string SvcRootID { get; set; }
        public string SvcRootName { get; set; }
        public string Remarks { get; set; }
        public string Active { get; set; }
    }
}
