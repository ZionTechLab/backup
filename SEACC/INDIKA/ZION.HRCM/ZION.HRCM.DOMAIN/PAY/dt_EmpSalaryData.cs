using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZION.HRCM.DOMAIN.PAY
{
    public class dt_EmpSalaryData
    {
        public string SIP_ID { get; set; }
        public string Emp_ID { get; set; }
        public string NIC_No { get; set; }
        public string EmpFullName { get; set; }
        public string Designation { get; set; }
        public decimal Work_Mand_Hrs { get; set; }
        public decimal Work_Act_Hrs { get; set; }
        public decimal Nopay_Rate { get; set; }
        public decimal Nopay_Hrs { get; set; }
        public decimal Late_Hrs { get; set; }
        public decimal OT_Hrs { get; set; }
        public decimal DoubleOT_Hrs { get; set; }
        public decimal TripleOT_Hrs { get; set; }

        public string Division_ID { get; set; }
        public string Division_Name { get; set; }
        public string Department_ID { get; set; }
        public string Department_Name { get; set; }

    }
}