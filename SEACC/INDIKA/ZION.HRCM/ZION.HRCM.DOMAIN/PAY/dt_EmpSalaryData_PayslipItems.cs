using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZION.HRCM.DOMAIN.PAY
{
    public class dt_EmpSalaryData_PayslipItems
    {
        public string SID { get; set; }
        public string PayItem_ID { get; set; }
        public string PayItem_Name { get; set; }
        public string PayItem_Code { get; set; }
        public bool IsEarning { get; set; }
        public decimal Amount { get; set; }

    }
}