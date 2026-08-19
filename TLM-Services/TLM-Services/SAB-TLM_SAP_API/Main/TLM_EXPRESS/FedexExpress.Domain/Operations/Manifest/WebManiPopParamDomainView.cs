using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class WebManiPopParamDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }

        [Required(ErrorMessage = "Airwabil no can't be empty")]
        public string AgnTrackNum { get; set; }

       // [Required(ErrorMessage = "Please select station ")]
        public string StationID { get; set; }

       // [Required(ErrorMessage = "Please select route")]
        public string RouteID { get; set; }
        public string DustyExempt { get; set; }
        public decimal DutyValue { get; set; }

        [Required(ErrorMessage = "Please select organization")]
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgAdd1 { get; set; }
        public string OrgAdd2 { get; set; }
        public string OrgCity { get; set; }

       // [Required(ErrorMessage = "Please select route")]
        public int ConsolType { get; set; }
        public string IsCredit { get; set; }
        public decimal DutyTreshold { get; set; }
        public string ClearenceStatus { get; set; }

        //[Required(ErrorMessage = "Please select route")]
        public string ClearenceType { get; set; } // ShipmentType
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Shipment type can't be empty")]
        public string ShipType { get; set; }

        [Required(ErrorMessage = "Please select Currency")]
        public string CurrCode { get; set; }

    }
}
