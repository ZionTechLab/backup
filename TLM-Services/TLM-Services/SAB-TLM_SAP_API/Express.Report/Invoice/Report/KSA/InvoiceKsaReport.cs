using CrystalDecisions.CrystalReports.Engine;
using Express.Report.Invoice.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Report.Invoice.Report.KSA
{
    public class InvoiceKsaReport : IInvoiceReportSelector
    {
        private static Dictionary<object, ReportDocument> reportContainer = null;
        public ReportDocument InvoiceReporLocator(string _key)
        {
            #region inject services
            //if (reportContainer == null)
            //{
                reportContainer = new Dictionary<object, ReportDocument>();
                reportContainer.Add("dutyinv", new InvoiceKsaTaxRpt());
                reportContainer.Add("FrtDetail", new InvoiceFreightRpt());
                reportContainer.Add("FrtSubDetail", new InvoiceSubCharges());
                reportContainer.Add("FrtSummary", new InvoiceFreightSummeryRpt());
                
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
