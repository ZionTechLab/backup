using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Inquiry
{
    [NotMapped]
    public class RevenuDomainView
    {
        public string  TrDate { get; set; }
        public string AirwaybillNo { get; set; }
        public string Route { get; set; }
        public string Getway { get; set; }
        public string Station { get; set; }
        public string OrginCntr { get; set; }
        public string DestinCntry { get; set; }
        public string Service { get; set; }
        public string Package { get; set; }
        public  decimal Weight { get; set; }
        public string RevType { get; set; }
        public string InvStatus { get; set; }
        public string PrnAccNo { get; set; }
        public int CustomerCode { get; set; }
        public string CustomerN { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Currency { get; set; }
        public string SalesArea { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal GdrCost { get; set; }
        public decimal FuelSurCharge { get; set; }
        public decimal OtherChg { get; set; }
        public decimal GrossProfit { get; set; }

        public string  RecInvDate { get; set; }
        public string RecInvoiceNo { get; set; }
        public string RecCurrency { get; set; }
        public decimal RecFrtAmount { get; set; }
        public decimal RecFuelSurCharge { get; set; }
        public decimal RecOtherChg { get; set;  }
        public decimal RecDecAmount { get; set; }
        public decimal CostDifference { get; set; }



    }
}
