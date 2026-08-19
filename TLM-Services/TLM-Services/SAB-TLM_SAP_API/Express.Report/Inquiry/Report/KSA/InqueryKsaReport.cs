using Express.Report.Inquiry.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;

namespace Express.Report.Inquiry.Report.KSA
{
    public class InqueryKsaReport : IInqueryReportSelector
    {
        private static Dictionary<object, ReportDocument> reportContainer = null;
        public ReportDocument InqueryReportLocator(string _key)
        {
            #region inject services
            if (reportContainer == null)
            {
                reportContainer = new Dictionary<object, ReportDocument>();
                reportContainer.Add("clearanlysis", new ClearanceAnalysisKsaReport());
                reportContainer.Add("paysummery", new PaymetSummaryKsaReport());
                reportContainer.Add("invsummery", new InvoiceSummaryKsaReport());
                

            }

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
