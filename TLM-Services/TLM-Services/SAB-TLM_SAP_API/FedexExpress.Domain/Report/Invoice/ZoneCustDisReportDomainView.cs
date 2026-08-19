using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
   public class ZoneCustDisReportDomainView
    {
        public int CompanyID { get; set; }
        public int SellCustRateTariffNo { get; set; }
        public int SellMastRateNo { get; set; }

        [StringLength(2)]
        public string RArea { get; set; }
        public decimal RWeight { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscPer { get; set; }
        public decimal DiscountedRate { get; set; }

        [StringLength(1)]
        public string Perkg { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public string ProductM { get; set; }
        public string ProductMN { get; set; }
        public string ProductS { get; set; }
        public string ProductSN { get; set; }
    }
}
