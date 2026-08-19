using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class CompanyReportDomainView
    {
        public int GroupID { get; set; }
        public int CompanyID { get; set; }
        public string CompanySortName { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string TaxRegNo { get; set; }
        public string ReportPath { get; set; }

    }
}
