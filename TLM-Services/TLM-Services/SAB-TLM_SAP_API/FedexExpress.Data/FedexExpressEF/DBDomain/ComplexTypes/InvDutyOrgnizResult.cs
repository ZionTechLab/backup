using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class InvDutyOrgnizResult
    {
        public int OrgnizCode { get; set; }
        public string OrganizName { get; set; }
        public string IsDeptWise { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CntrCode { get; set; }
        public string CntrName { get; set; }
        public string SalesAreaID { get; set; }       
        public string VatRegNo { get; set; }
        public string SvatRegNo { get; set; }
        public string CityID { get; set; }
        public string CityName { get; set; }
        public string IsCredit { get; set; }
        public string InvDutax { get; set; }
         public string OrgPhone { get; set; }
        public string TaxCodeOne { get; set; }
    }
}
