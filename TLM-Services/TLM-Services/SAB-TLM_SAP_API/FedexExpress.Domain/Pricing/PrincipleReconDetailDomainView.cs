using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
   public class PrincipleReconDetailDomainView
    {
       
        public DateTime TrDate { get; set; }
        public string AwbNumber { get; set; }
        public string InvNo { get; set; }
        public string OrgnCountry { get; set; }
        public string OrgnDepot { get; set; }
        public string DestCountry { get; set; }
        public string DestDeport { get; set; }
        public string ProductSub { get; set; }
        public decimal  BillWeight { get; set; }
        public decimal FrtChg { get; set; }
        public decimal FciChg { get; set; }
        public decimal EssChg { get; set; }
        public decimal TotRev { get; set; }// Frt+Fci+Ess

        public string Remarks { get; set; }
        public string ZoneCode { get; set; }
        public int weekNum { get; set; }

        public string RemarksAR { get; set; }
        public string ReasonReject { get; set; }
        public decimal FRT_USD { get; set; }
        public decimal FCI_USD { get; set; }
        public decimal ESS_USD { get; set; }
        public decimal NetRev { get; set; } // FrtChg*ExtRate

        public string ErrorMsg { get; set; }
    }
}
