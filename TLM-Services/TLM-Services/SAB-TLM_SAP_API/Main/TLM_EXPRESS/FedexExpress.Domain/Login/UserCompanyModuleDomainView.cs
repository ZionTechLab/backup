using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
   public class UserCompanyModuleDomainView
    {
       

        public int CompanyID { get; set; }
        public string  CompanyName { get; set; }
        public bool DefalutCompany { get; set; }
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }


        ////public virtual ModulesDomainView ModuleView { get; set; }
        ////public virtual UserRolesDomainView RolleView { get; set; }
        ////public virtual UserView UserDetail { get; set; }


    


    }
}
