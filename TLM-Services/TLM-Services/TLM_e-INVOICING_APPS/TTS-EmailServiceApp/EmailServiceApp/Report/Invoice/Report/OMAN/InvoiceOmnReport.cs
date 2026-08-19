using CrystalDecisions.CrystalReports.Engine;
using EmailServiceApp.Report.Invoice.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Report.Invoice.Report.OMAN
{
    public class InvoiceOmnReport : IInvoiceReportSelector
    {
        private static Dictionary<object, ReportDocument> reportContainer = null;
        public ReportDocument InvoiceReporLocator(string _key)
        {
            #region inject services
            //if (reportContainer == null)
            //{
            reportContainer = new Dictionary<object, ReportDocument>();
            reportContainer.Add("dutyinv", new InvoiceOmanTaxRpt());

            //}

            #endregion
            try
            {
                return (ReportDocument)reportContainer[_key];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Report not available.");
            }
        }
    }
}
