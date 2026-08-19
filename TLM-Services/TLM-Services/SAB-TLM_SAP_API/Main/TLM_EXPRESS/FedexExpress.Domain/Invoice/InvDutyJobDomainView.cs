using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDutyJobDomainView
    {
        public string SalesArea { get; set; }
        public DateTime TransDate { get; set; }
        public string ExpressID { get; set; }      
        public string RefNo1 { get; set; }
        public string RefNo2 { get; set; }
        public string RefNo3 { get; set; }
        public string JobNo { get; set; }
    }
}
