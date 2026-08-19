using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    [NotMapped]
    public class InvDutyBulkInvoiceDomainView
    {   
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }       
        public string GateWayID { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }   
        public string MissRoute { get; set; }
        public string ExpressID { get; set; }      
        public string AgnAWBNo { get; set; }      
        public string AgnTrackNo { get; set; }    
        public string ORGCOUNTRY { get; set; }
        public string DESCOUNTRY { get; set; }          
        public string PackType { get; set; }
        public decimal? TotWgt { get; set; }         
        public decimal? CustomVal { get; set; }
        public string CustomValCur { get; set; }
        public string Descrip { get; set; }       
        public string DocNdoc { get; set; }     
        public string DutyExcemptY { get; set; }
        public string DetainedY { get; set; }
        public string BillDTaxChgY { get; set; }       
        public decimal? InvNoDTaxChg { get; set; }
      
        public string ShipValueType { get; set; }
        public decimal? ConvRate { get; set; }
        public decimal? CustomsPkgVal { get; set; }
        public string CustomsCurr { get; set; }
        public decimal? TotalDutyVal { get; set; }       
        public string ShoOvr { get; set; }
        public int? BillOrgCode { get; set; }
        public string BillOrgName { get; set; }   
        public decimal  PayNoDTaxChg { get; set; }
        public string BillOrgAddr1 { get; set; }
        public string BillOrgAddr2 { get; set; }
        public string BillOrgCity { get; set; }
        public string RecCompany { get; set; }
    }
}
