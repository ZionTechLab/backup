using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class CreditPara
    {
        public int Mount_Code { get; set; }
    }
    public class CustPara
    {
        public int Customer_Code { get; set; }
    }

    public class UpdatedOnly
    {
        public DateTime? last_updated_at { get; set; }
    }

    public class CustCredRateInfo
    {
        public string OrgType { get; set; }
        public Int32 OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public string OrgCountry { get; set; }
        public string OrgCity { get; set; }
        public string OrgPhone { get; set; }
        public string OrgMobile { get; set; }
        public string SalesCode { get; set; }
        public string CredApprove { get; set; }
        public DateTime CredApproveDate { get; set; }
        public decimal CreditLimit { get; set; }
        public List<dynamic> Tariffs { get; set; }
    }
}