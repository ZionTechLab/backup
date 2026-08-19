using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
  public  class ModulesDomainView
    {
        
        public ModulesDomainView()
        {
            ModuleView = new HashSet<UserCompanyModuleDomainView>();
        }

        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int SequenceNo { get; set; }


        public virtual ICollection<UserCompanyModuleDomainView> ModuleView { get; set; }
    }
}
