using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class ClrInvPrintResult
    {
        //public string ExpressID { get; set; }
        //public string AgnAWBNo { get; set; }     
        //public string ConsId { get; set; }
        //public string MAWBNo { get; set; }
        //public string CusdecNo { get; set; }           
        //public string Doctype { get; set; }      
        //public decimal InvNo { get; set; }
        //public int OrgCode { get; set; }
        //public string OrgName { get; set; }    
        //public string PayMode { get; set; }   
        //public string SenRefNotes { get; set; }
        //public string GateWayID { get; set; }
        //public string StationID { get; set; }
        //public string RouteID { get; set; }
        //public decimal InvAmount { get; set; }
        //public decimal InvBalance { get; set; }
        //public string FlightNo { get; set; }
        //public string RouteN { get; set; }
        //public string BillTo { get; set; }

        [Column(TypeName = "char")]
        public string ExpressID { get; set; }
        [Column(TypeName = "char")]
        public string AgnAWBNo { get; set; }
        [Column(TypeName = "varchar")]
        public string ConsId { get; set; }
        [Column(TypeName = "varchar")]
        public string MAWBNo { get; set; }
        [Column(TypeName = "varchar")]
        public string CusdecNo { get; set; }
        [Column(TypeName = "char")]
        public string Doctype { get; set; }
        public decimal InvNo { get; set; }
        [Column(TypeName = "int")]
        public int OrgCode { get; set; }
        [Column(TypeName = "varchar")]
        public string OrgName { get; set; }
        [Column(TypeName = "char")]
        public string PayMode { get; set; }
        [Column(TypeName = "nvarchar")]
        public string SenRefNotes { get; set; }
        [Column(TypeName = "varchar")]
        public string GateWayID { get; set; }
        [Column(TypeName = "varchar")]
        public string StationID { get; set; }
        [Column(TypeName = "varchar")]
        public string RouteID { get; set; }
        public decimal InvAmount { get; set; }
        public decimal InvBalance { get; set; }
        [Column(TypeName = "nchar")]
        public string FlightNo { get; set; }
        [Column(TypeName = "varchar")]
        public string RouteN { get; set; }
        [Column(TypeName = "char")]
        public string BillTo { get; set; }

    }
}
