using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
   public class InvDutyOrgnizDomainView
    {
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string IsDeptInv { get; set; }
        public string ContactPerson { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string SalesAreaID { get; set; }      
        public string VatRegNo { get; set; }
        public string SvatRegNo { get; set; }
        public string PayType { get; set; }
        public string CurrencyType { get; set; }
        public string InvMode { get; set; }
        public string IsCredit { get; set; }

        public string OrgPhone { get; set; }
        public string TaxCodeOne { get; set; }
    }
}
