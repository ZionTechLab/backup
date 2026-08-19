using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
   public class UserAccessDomainView
    {

        public int UsmId { get; set; }
        public int CompID { get; set; }
        public int ModuleID { get; set; }
        public int MenuCode { get; set; }
        public string OptionList { get; set; }

        //public bool? OView { get; set; }
        //public bool? ONew { get; set; }
        //public bool? OEdit { get; set; }
        //public bool? ODelete { get; set; }
        //public bool? OPrint { get; set; }
        //public bool? OPrivew { get; set; }
        //public bool? OProcess { get; set; }
        //public bool? OImport { get; set; }
        //public bool? OExport { get; set; }
    }
}
