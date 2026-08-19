using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
   public  class InvOrgnzCreditDomainView
    {
        public string IsDutyCredit { get; set; }
        public string IsFrtOutboundCredit { get; set; }
        public string IsFrtInboundCredit { get; set; }
        public string IsFrtTPartyCredit { get; set; }
        public string InvModeDuty { get; set; }
        public string InvModeFrtTpart { get; set; }
        public string InvModeInbound { get; set; }
        public string InvModeOutbound { get; set; }
    }
}
