using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvFrtPrintProcessParaDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyCode { get; set; }
        public string CompanyN { get; set; }
        public string AgencyN { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string InvMode { get; set; }
        public string InvModeXml { get; set; }
        public string InvModeList { get; set; }
        public string ShipType { get; set; }
        public string DteUpto { get; set; }
        public string FromInvNo { get; set; }
        public string ToInvNo { get; set; }
        public string DtFrom { get; set; }
        public string DtTo { get; set; }
        public string AwbNumber { get; set; }
        public int AllAwb { get; set; }
        public int IsCutormer { get; set; }
        public int IsPeriodic { get; set; }
        public int IsInvNumberRange { get; set; }
        public int IsInvDateRange { get; set; }
        public int UserID { get; set; }
        public string DocDate { get; set; }
        public string DocType { get; set; }
        public bool IsDirectPrint { get; set; }

         
       
        
    }
}
