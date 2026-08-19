using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Express.View.Domain.Invoice
{
    public class InvDutyBulkInvoiceParaDomainView
    {
        public int CompanyID { get; set; }
        public int AgencyID { get; set; }
        public int UserID { get; set; }
        public DateTime UptoDate { get; set; }
        public string GatewayCode { get; set; }

        [Required(ErrorMessage ="Please select station code" )]
        public string StationCode { get; set; }
        public string  IsAllGateway {get;set;}
        public string IsAllStation { get; set; }
        public string IsAllAgency { get; set; }

    }
}
