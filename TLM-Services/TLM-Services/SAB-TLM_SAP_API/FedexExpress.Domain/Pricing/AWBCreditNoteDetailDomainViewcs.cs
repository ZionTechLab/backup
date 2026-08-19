using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;

namespace Express.View.Domain.Pricing
{
    public class AWBCreditNoteDetailDomainViewcs  /*Grid*/
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

        public ResponseMessage SaveCreditNoteDetails(AWBCreditNoteDetailDomainViewcs scn)
        {
            return SaveCreditNoteDetails(scn);
        }

    }
}
