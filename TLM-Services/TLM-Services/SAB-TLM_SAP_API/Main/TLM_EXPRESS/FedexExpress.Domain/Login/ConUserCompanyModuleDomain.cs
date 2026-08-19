using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
 
    public class ConUserCompanyModuleDomain
    {
        public int UsmId { get; set; }

        public int ModuleID { get; set; }
       
        public int CompID { get; set; }
       
        public int AgncyCode { get; set; }

        public int UserRollId { get; set; }

        public bool DefaultY { get; set; }
    }
}
