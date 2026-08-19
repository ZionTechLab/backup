using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class AWBCreditNoteDataResult
    {
        public string ExpressID { get; set; }

        public int AutoId { get; set; }

        public int CMPY { get; set; }

        public int AgncyCode { get; set; }

        public string AWBNo { get; set; }

        public decimal AWBLCAmount { get; set; }

        public decimal CRDLCAmount { get; set; }

        public bool IsCreditabil { get; set; }
        public string AgnAWBNo { get; set; }

    }
}
