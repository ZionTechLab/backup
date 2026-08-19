using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class RefSalesAreaResult
    {
       
        public int CMPY { get; set; }

        public string SalesAreaGroup { get; set; }
       
        public string SalesAreaID { get; set; }
    
        public string SalesAreaName { get; set; }
      
        public string SalesPerID { get; set; }
      
        public string BranchCode { get; set; }
    
        public string Remarks { get; set; }

        public string SalesPerName { get; set; }

        public string Active { get; set; }

    }
}
