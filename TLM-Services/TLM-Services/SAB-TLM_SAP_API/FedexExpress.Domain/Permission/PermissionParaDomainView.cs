using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Permission
{
    public class PermissionParaDomainView
    {
        public int CompanyID { get; set; }
        public int MenuCode { get; set; }
        public int ModuleCode { get; set; }
        public int UserID { get; set; }
        public string Option { get; set; }
    }
}
