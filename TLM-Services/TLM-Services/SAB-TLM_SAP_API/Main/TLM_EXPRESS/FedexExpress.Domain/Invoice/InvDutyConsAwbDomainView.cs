using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDutyConsAwbDomainView
    {
        public int GroupID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string ConsID { get; set; }
        public DateTime TransDate { get; set; }
        public string ShipType { get; set; }
        public string ShipTypeN { get; set; }     
        public string ExpressID { get; set; }
        public string AirWayBillNo { get; set; }
        public string GoodDescp { get; set; }
        public string ShipCntr { get; set; }
        public string DestiCntr { get; set; }
        public string ShipCntrN { get; set; }
        public string DestiCntrN { get; set; }
        public string AccountNo { get; set; }
        public string PayBy { get; set; }       
        public string MasterAwbNo { get; set; }     
        public string CusdecNo { get; set; }
        public string BillTaxChgType { get; set; }
        public string OrgName { get; set; }
        public string ContactPerson { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; } 
        public string City { get; set; }
        public decimal ShipperValue { get; set; }
        public string ManiCurrCode { get; set; }
        public string DutyExcemptY { get; set; }
        public string StationID { get; set; }
        public string SenRefNotes { get; set; }
        public string DestGateWay { get; set; }
        public string OrginGateWay { get; set; }
        public string ClrShipCurr { get; set; }
        public decimal  ClrShipValue { get; set; }
        public string CountryC { get; set; }
        public string CountryN { get; set; }
        public string PhoneN { get; set; }
        public string GateWayID { get; set; }
        public string RouteID { get; set; }
        public string OrgStation { get;set;}
        public string DesStation { get; set; }
        public string ConsoleID { get; set; }

    }
}
