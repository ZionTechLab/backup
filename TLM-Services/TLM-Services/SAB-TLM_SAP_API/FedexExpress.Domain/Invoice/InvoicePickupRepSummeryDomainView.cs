using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedexExpress.View.Domain.Pricing
{
    public class InvoicePickupRepSummeryDomainView
    {
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public DateTime InvDate { get; set; }
        public DateTime TransDate { get; set; }
        public int InvNo  {get; set;}
        public int OrgCode { get; set; }
        public string BillOrg { get; set; }
        public	decimal ConvRate { get; set; }
        public decimal  LineSumFCAmount{ get; set; }
        public string DebtorFLCurrency { get; set; }
        public decimal  DebtorFCTotAmount{ get; set; }
        public decimal  TotBillWgt{ get; set; }
        public int ShipmentCount { get; set; }
        public string DoctypeN { get; set; }
        public string BillOrgCountry { get; set; }
        public string AgencyName { get; set; }
    }
}
