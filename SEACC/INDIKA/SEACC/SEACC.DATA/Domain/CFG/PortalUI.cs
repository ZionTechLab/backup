using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.CFG
{
   public  class PortalUI
    {
        public tbl_genCompanyInfo CompanyInfo;
        public string BranchName;
        public List<tbl_securityFormCategory> Category;
        public List<tbl_securityFormMaster> Forms;
    }
}
