using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Inquiry
{
    public class ClearanceAnalysisDomainView
    {
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string ExpressID { get; set; }
        public DateTime TransDate { get; set; }
        public string ShipType { get; set; }
        public decimal CustomVal { get; set; }
        public decimal InvNo { get; set; }
        public decimal PayNo { get; set; }
        public decimal Vat { get; set; }
        public decimal Duty { get; set; }
        public decimal ADMIN { get; set; }
        public decimal TotalDutyVal { get; set; }
        public decimal PayAmt { get; set; }
        public decimal InvAmt { get; set; }
        public string FilterValue { get; set; }
        public string CompanyName { get; set; }
        public bool Deleted { get; set; }
        public int GroupID { get; set; }
       
        public string AgncyID { get; set; }
     
        public string AgnAWBNo { get; set; }
     
        public string MissRoute { get; set; }
        public string Detain { get; set; }
        public string BillTo { get; set; }
        public string ConsId { get; set; }
        public string MAWBNo { get; set; }
        public string CusdecNo { get; set; }
        public string Descrip { get; set; }
        public string HSCODE { get; set; }
        public decimal ManifestVal { get; set; }
        public string ManifestValCur { get; set; }
        public decimal ConvRate { get; set; }
       
        public string CustomValCur { get; set; }
        public string Remarks { get; set; }
        public string VATRegNo { get; set; }
        public string SVATRegNo { get; set; }
        public string Doctype { get; set; }
        public long JobNo { get; set; }
       
        public DateTime InvDate { get; set; }
        public DateTime PayDate { get; set; }
        public int PayAccount { get; set; }
        public string PayRefNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgPerson { get; set; }
        public decimal OtherCharges { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public int OrgCityCode { get; set; }
        public string OrgCity { get; set; }
        public string OrgCountry { get; set; }
        public string SalesCode { get; set; }
        public string PayMode { get; set; }
        public string InvMode { get; set; }
        public string FlightNo { get; set; }
        public string SenRefNotes { get; set; }
        public string GateWayID { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }
       
    }
}
