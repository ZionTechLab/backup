using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.Com
{
    public class CommissionCollectors_SavePara
    {
        public int PeriodIndex;
        public string Collector_ID;
        public decimal totalAmount;
        public decimal dateDeduction;
        public decimal securityDeduction;
        public decimal advDeduction;
        public decimal loanDeduction;
        public decimal netAmount;
        public string User_ID;
        public string Terminal_ID;

        public List<CommishionDateSlab> DateSlab;
        public List<comCommissionCalculation_Detail> Detail;
    }
}
