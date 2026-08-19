using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
    public class AWBCreditNoteWrappingDomainView  /*save*/
    {
        public int CMPY { get; set; }
        public decimal InvoiceNo { get; set; }
        public DateTime DocDate { get; set; }
        public string Naration { get; set; }
        public int UserID { get; set; }
        public List<AWBCreditNoteDetailDomainViewcs> CreditNoteList { get; set; }

    }
}
