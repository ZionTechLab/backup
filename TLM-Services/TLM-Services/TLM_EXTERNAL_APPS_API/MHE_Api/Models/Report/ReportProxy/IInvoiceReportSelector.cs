using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHE_Api.Report.Invoice.ReportProxy
{
    public interface IInvoiceReportSelector
    {
        ReportDocument InvoiceReporLocator(string _key);
    }
}
