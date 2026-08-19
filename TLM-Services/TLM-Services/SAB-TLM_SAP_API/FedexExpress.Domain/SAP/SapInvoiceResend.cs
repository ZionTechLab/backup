using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.SAP
{
    public class SapInvoiceResend
    {
        public List<SapResend> ResendList { get; set; }

        public string Message { get; set; }
    }
}
