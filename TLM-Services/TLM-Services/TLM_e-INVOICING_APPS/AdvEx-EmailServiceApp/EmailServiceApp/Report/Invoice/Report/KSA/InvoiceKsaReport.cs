using CrystalDecisions.CrystalReports.Engine;
using EmailServiceApp.Report.Invoice.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailServiceApp.Domain;

namespace EmailServiceApp.Report.Invoice.Report.KSA
{
    public class InvoiceKsaReport : IInvoiceReportSelector
    {
        private static Dictionary<object, ReportDocument> reportContainer = null;

        //public IList<CompanyReportDomainView> GetCompany(int groupID, int companyID)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<TaxInvoiceReportDomainView> GetInvTaxRep(int groupID, int companyID, int agencyID, string invoicNo)
        //{
        //    throw new NotImplementedException();
        //}

        public ReportDocument InvoiceReporLocator(string _key)
        {
            #region inject services
            //if (reportContainer == null)
            //{
            reportContainer = new Dictionary<object, ReportDocument>();
            reportContainer.Add("dutyinv", new InvoiceKsaTaxRpt());
            reportContainer.Add("frtinv", new InvoiceFreightRptksa());

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

        //public IList<FrtInvoiceReportDomainView> PrintFrtInvoiceForEmail(int groupID, int companyID, int agencyID, string invoicNo, string awb)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
