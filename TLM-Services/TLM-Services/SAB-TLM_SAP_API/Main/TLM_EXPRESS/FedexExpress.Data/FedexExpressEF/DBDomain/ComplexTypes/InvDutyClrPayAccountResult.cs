using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class InvDutyClrPayAccountResult
    {
        public int AccountCode { get; set; }
        public string AccDesc { get; set; }
        public string DefV { get; set; }
    }
}
