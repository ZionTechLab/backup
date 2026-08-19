using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
    public class PrincipleReconFedexDetailDomainView
    {
        public string InvoiceNo { get; set; }
        public DateTime  InvoiceDate { get; set; }
        public string AwbNumber { get; set; }
        public DateTime  ShipDate { get; set; }
        public string OrgnCountry { get; set; }        
        public string DestCountry { get; set; }     
        public string Service { get; set; }
        public string Package { get; set; }
        public decimal BillWeight { get; set; }
        public decimal NetRev { get; set; }
        public decimal FrtChg { get; set; }   
        
        public decimal DisChg { get; set; }  
        public decimal FuelAmt { get; set; }
      
        public string ErrorMsg { get; set; }
    }
}
