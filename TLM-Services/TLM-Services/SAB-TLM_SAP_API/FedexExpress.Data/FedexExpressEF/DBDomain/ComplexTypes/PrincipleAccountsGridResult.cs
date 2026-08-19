using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class PrincipleAccountsGridResult
    {
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string AgncyName { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string AcNo { get; set; }
        public string Active { get; set; }
        public string Remarks { get; set; }

        public DateTime USM_Date { get; set; }
        public Nullable<DateTime> DelUSM_Date { get; set; }
        public int USM_ID { get; set; }

    }
}
