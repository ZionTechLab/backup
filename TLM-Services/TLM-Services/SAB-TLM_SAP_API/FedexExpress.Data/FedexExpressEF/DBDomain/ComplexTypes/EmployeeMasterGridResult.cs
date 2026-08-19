using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class EmployeeMasterGridResult
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Remarks { get; set; }
        public string Active { get; set; }
    }
}
