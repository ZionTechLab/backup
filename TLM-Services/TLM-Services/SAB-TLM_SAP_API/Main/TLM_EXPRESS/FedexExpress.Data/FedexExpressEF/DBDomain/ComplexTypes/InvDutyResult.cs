using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class InvDutyResult
    {
        public int CMPY { get; set; }
        public string CompanyN { get; set; }
        public int AgncyCode { get; set; }
        public string AgencyN { get; set; }       
        public string ExpressID { get; set; }
        public string AgnAWBNo { get; set; }
        public string ShipType { get; set; }
        public string ShipTypeN { get; set; }
        public string MissRoute { get; set; }
        public string BillTo { get; set; }
        public string PayBy { get; set; }
        public string FlightNo { get; set; }
        public string ConsId { get; set; }
        public string MasterAwbNo { get; set; }
        public string CusdecNo { get; set; }
        public string GoodDescp { get; set; }
        public decimal ShipperValue { get; set; }
        public string ManiCurrCode { get; set; }
        public decimal ManiConvRate { get; set; }
        public decimal CustomVal { get; set; }
        public string CustomValCur { get; set; }
        public string Doctype { get; set; }
        public Int64 JobNo { get; set; }
        public decimal InvNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgPerson { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public int OrgCityCode { get; set; }
        public string OrgCity { get; set; }
        public string SalesArea { get; set; }
        public string OrgCntrCode { get; set; }
        public string OrgCntrN { get; set; }
        public string Remarks { get; set; }
        public string TaxCodeOne { get; set; }
        public string PayMode { get; set; }
        public string InvMode { get; set; }
        public DateTime TransDate { get; set; }
        public string SenRefNotes { get; set; }
        public string GateWayID { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }
        public string PayRefNo { get; set; }
        public decimal  PayNo { get; set; }
        public DateTime PayDate { get; set; }
        public int PayAccount { get; set; }


    }
}
