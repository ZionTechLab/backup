using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.SAP
{
    public class InvoiceResendHeader
    {
        public string AcDocNo { get; set; }
       
        public string ErrorMessage { get; set; }
      
        public string Customer { get; set; }
        public string TransDate { get; set; }
    }
}
