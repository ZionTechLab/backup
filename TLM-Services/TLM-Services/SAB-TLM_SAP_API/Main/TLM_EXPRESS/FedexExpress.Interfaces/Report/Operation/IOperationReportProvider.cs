using Express.View.Domain.Report.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report.Operation
{
    public interface IOperationReportProvider
    {
        void GetManiferReport(IList<RptManifestDomainView> _para ,string _searchStr);
        void GetPreManifestReport(IList<RptPreManifestDomainView> _para ,string _searchStr);
        //IList<TaxInvoiceReportDomainView> PrintInvTaxRep(InvoiceBulkPrintDomainView para);
    }
}
