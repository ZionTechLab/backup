using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZION.HRCM.DOMAIN.PAY
{
   public  class PaySlip
    {
        public List<dt_EmpSalaryData> Header { get; set; }
        public List<dt_EmpSalaryData_PayslipItems> PayItems { get; set; }
        public List<dt_EmpSalaryData_PayslipItems_Statutatry> StatutaryItems { get; set; }
    }
}
