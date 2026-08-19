using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Inquiry
{
    [NotMapped]
    public class SalesAreaDomainView
    {
             
        public string SalesAreaID { get; set; }
        public string SalesAreaName { get; set; }     
        public string SalesPerID { get; set; }
        public string Remarks { get; set; }
        public string Active { get; set; }     
        public string BranchCode { get; set; }
        public string SalesPerName { get; set; }
        public bool IsActive { get; set; }
    }
}
