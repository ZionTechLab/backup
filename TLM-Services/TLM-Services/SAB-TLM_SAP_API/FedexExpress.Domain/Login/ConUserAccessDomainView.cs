using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
    public class ConUserAccessDomainView
    {
        public int UsmId { get; set; }

        public int CompanyID { get; set; }

        public int ModuleID { get; set; }

        public int MenuCode { get; set; }

        public int GroupId { get; set; }

        public string OptionList { get; set; }

        public string Company  { get; set; }

        public string Module { get; set; }

        public int AgncyID { get; set; }

        public string Agncy  { get; set; }

        public bool DefaultCompany { get; set; }
    }
}
