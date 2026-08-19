using System.Collections.Generic;

namespace SEACC.DATA.Domain.Com
{
   public class Commishion_Collectors
    {
        public decimal TotalCommishion { get; set; }
        public List<CommishionDateSlab> dateSlab { get; set; }
        //public List<dynamic> TxnList { get; set; }
        public List<comCommissionCalculation_Detail> TxnList { get; set; }
    }
}