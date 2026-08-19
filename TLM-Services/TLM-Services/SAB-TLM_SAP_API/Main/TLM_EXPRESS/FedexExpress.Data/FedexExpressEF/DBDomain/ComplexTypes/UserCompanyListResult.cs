using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class UserCompanyListResult
    {
        
        public int UsmId { get; set; }

        public int CompID { get; set; }

        public int ModuleID { get; set; }

        public int GroupID { get; set; }

        public string CompName { get; set; }

        public int MenuCode { get; set; }
     
        public int AgncyCode { get; set; }
   
        public string OptionList { get; set; }
   
        public string DefaultY { get; set; }
      
        public string AgncyName { get; set; }
    }
}
