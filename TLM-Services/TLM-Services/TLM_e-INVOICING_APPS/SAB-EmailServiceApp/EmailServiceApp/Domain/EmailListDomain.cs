using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class EmailListDomain
    {
        public int AutoID { get; set; }
        public decimal? InvoiceNo { get; set; }
        public string Area { get; set; }
        public string SendEmail { get; set; }
        public string ReceivedEmail { get; set; }
        public string ErrorStatus { get; set; }
        public string NewEmail { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public int? OrgCode { get; set; }
        public DateTime? UserDate { get; set; }
        public string ReSend { get; set; }
        public string DocType { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }

    }
}
