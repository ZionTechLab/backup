using Express.View.Domain.Report.General;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report.Invoice
{
    public interface IInvoiceReportProvider
    {
        void ClearenceDutyPrint(IList<TaxInvoiceReportDomainView> _rptData , IList<CompanyReportDomainView> _company);

        void ClearenceDutyPrintExport(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company,string InvNo);

        void ClearenceSummaryDutyPrint(IList<TaxInvoiceSummeryDomainView> _rptData, string rptPara);
    }
}
