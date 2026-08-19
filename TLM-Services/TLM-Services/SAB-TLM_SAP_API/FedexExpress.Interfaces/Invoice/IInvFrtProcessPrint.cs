using Express.Domain.Message;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Invoice
{
   public  interface IInvFrtProcessPrint
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<InvProcessModeDomainView> GetInvProcessMode();
        IList<InvoiceTypeCategoryDomainView> DocumentTypes(int companyId, int agencyID);
        IList<InvFrtPrintProcessDomainView> GetFrtBillingDetail(InvFrtPrintProcessParaDomainView _para);
        ResponseMessage InvBulkProcess(InvFrtPrintProcessParaDomainView para);
        IList<InvFrtPrintProcessDomainView> GetFrtInvoiceDetail(InvFrtPrintProcessParaDomainView _para);
        IList<FrtInvoiceReportDomainView> GetIFrtRptInvoiceDetail(InvFrtPrintProcessParaDomainView _para);
        IList<FrtInvoiceSummeryDomainView> GetIFrtRptInvoiceSummary(InvFrtPrintProcessParaDomainView _para);

    }
}
