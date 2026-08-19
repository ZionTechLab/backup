using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class CustomerCpd
    {

      public string AcDocNo { get; set; }
      public string CustName { get; set; }
      public string CustCity { get; set; }
      public string CustCountry { get; set; }
        
    }
}
