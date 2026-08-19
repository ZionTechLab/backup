using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
   public class PrincipleReconDomainView
    {
        public int  GroupID { get; set;  }
        public int AgencyCode { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public string InvoiceNoFrom { get; set; }
        public string InvoiceNoTo{ get; set; }
        public string InvoiceDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
      ////  public DateTime ToDate { get; set; }
        public int FromYear { get; set; }
        ///// public int ToYear { get; set; }

       // [Required(ErrorMessage = "Please enter week number")]
        public string FromWeek { get; set; }
        public string ToWeek { get; set; }
        ///// public string ToWeek { get; set; }
       // [Required(ErrorMessage = "Please select product type")]
        public string ProductMain { get; set; }

        public DataTable PrintReconDataTable;
        public List<PrincipleReconDetailDomainView> PrincReconImport { get; set; }
        public List<PrincipleReconFedexDetailDomainView> FedexReconImport { get; set; }
        public string PrincReconXml { get; set; }
        public string FedexReconXml { get; set; }

        public int IsByDate { get; set; }
        public int IsByInvoice { get; set; }

        public string AgencyName { get; set; }
        public bool IsSummeryRpt { get; set; }
    }
}
