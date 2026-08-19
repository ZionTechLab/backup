using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class ClrInvDomainView
    {
        public bool IsSelect { get; set; }
        public string ExpressID { get; set; }
        public string AgnAWBNo { get; set; }
        public string ConsId { get; set; }
        public string MAWBNo { get; set; }
        public string CusdecNo { get; set; }
        public string Doctype { get; set; }
        public decimal InvNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string PayMode { get; set; }
        public string SenRefNotes { get; set; }
        public string GateWayID { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }
        public decimal InvAmount { get; set; }
        public decimal InvBalance { get; set; }
        public string FlightNo { get; set; }
        public string RouteN { get; set; }
        public string BillTo { get; set; }
        public string TaxRegNo { get; set; }


    }
}
