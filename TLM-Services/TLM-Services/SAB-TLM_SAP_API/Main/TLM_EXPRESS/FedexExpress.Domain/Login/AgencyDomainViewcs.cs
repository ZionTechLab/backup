using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Login
{
    [NotMapped]
    public class AgencyDomainViewcs
    {
        public int CompID { get; set; }      
        public string CompName { get; set; }      
        public int ModuleID { get; set; }       
        public int UsmId { get; set; }     
        public int MenuCode { get; set; }       
        public int GroupID { get; set; }
        public int AgncyCode { get; set; }       
        public string AgncyName { get; set; }
        public string CountryCode { get; set; }
        public string AgncyID { get; set; }
        public string DefaultY { get; set; }
        public string LocalCurrency { get; set; }
    }
}
