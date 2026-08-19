using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Invoice
{
    public class FedexReconSummeryReportDomainView
    {
        public string ErrorMsg { get; set; }
        public string TrType { get; set; }
        public string FromInvoice { get; set; }
        public string ToInvoice { get; set; }
        public string AgencyName { get; set; }
        public string CompanyName { get; set; }
        public decimal TotCostMinus { get; set; }
        public decimal TotCostPlus { get; set; }
        public decimal TotCostVariation { get; set; }
        public decimal TotFuelVariation { get; set; }
        public decimal TotVarianGain { get; set; }
        public decimal TotVarianLost { get; set; }
        public decimal TotVarian { get; set; }
        public decimal TotCostFuelFtr { get; set; }

    }
}
