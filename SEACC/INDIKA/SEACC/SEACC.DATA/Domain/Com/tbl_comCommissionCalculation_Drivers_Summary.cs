using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.Com
{
    public class tbl_comCommissionCalculation_Drivers_Summary
    {
        public string driver_ID { get; set; }
        public string driverName { get; set; }
        public decimal totalCommishion { get; set; }
        public decimal deductions { get; set; }
        public decimal netCommishion { get; set; }
        public bool isDriver { get; set; }
    }
}