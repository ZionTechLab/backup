using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class RefEmployeeResult
    {
        public string EmployeeID{get;set;}

        public string EmployeeName { get; set; }

        public string Remarks { get; set; }

        public string Active { get; set; }
    }
}
