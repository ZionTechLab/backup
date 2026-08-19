using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Mail
{
    public class SendMailDomainView
    {
        public string FromEmail { get; set; }
        public string FromEmailPassword { get; set; }
        public string ToEmail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public byte[] Attachment { get; set; }
        public string EmailCoppyTo { get; set; }
        public string EmailGenarateArea { get; set; }
        public decimal ReferenceNo { get; set; }
        public string Email_Area { get; set; }
        public DateTime USM_DATE { get; set; }
        public int USM_ID { get; set; }
    }
}
