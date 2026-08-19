using CrystalDecisions.CrystalReports.Engine;
using EmailServiceApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Report.Invoice.ReportProxy
{
    public interface IInvoiceReportSelector
    {
        ReportDocument InvoiceReporLocator(string _key);
        //IList<TaxInvoiceReportDomainView> GetInvTaxRep(int groupID, int companyID, int agencyID, string invoicNo);
        //IList<CompanyReportDomainView> GetCompany(int groupID, int companyID);
        //IList<FrtInvoiceReportDomainView> PrintFrtInvoiceForEmail(int groupID, int companyID, int agencyID, string invoicNo, string awb);
    }
}
