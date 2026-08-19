using EmailServiceApp.Report.Invoice.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using EmailServiceApp.Domain;

namespace EmailServiceApp.Report.Invoice.Report.MHE
{
    public class InvoiceMheReport : IInvoiceReportSelector
    {
        private static Dictionary<object, ReportDocument> reportContainer = null;
        public IList<CompanyReportDomainView> GetCompany(int groupID, int companyID)
        {
            throw new NotImplementedException();
        }

        public IList<TaxInvoiceReportDomainView> GetInvTaxRep(int groupID, int companyID, int agencyID, string invoicNo)
        {
            throw new NotImplementedException();
        }

        public ReportDocument InvoiceReporLocator(string _key)
        {
            #region inject services
           
            reportContainer = new Dictionary<object, ReportDocument>();
            reportContainer.Add("dutyinv", new InvoiceFreightSummeryRpt());
            reportContainer.Add("frtinv", new InvoiceTaxRpt());
            reportContainer.Add("awbinv", new InvoiceAwbDetail());
           // reportContainer.Add("awbinv", new InvoiceFreightWPFRpt());
            reportContainer.Add("awbinv", new InvoiceFreightRpt2());
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

        public IList<FrtInvoiceReportDomainView> PrintFrtInvoiceForEmail(int groupID, int companyID, int agencyID, string invoicNo, string awb)
        {
            throw new NotImplementedException();
        }
    }
}
