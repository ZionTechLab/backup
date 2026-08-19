using Express.Data.Invoice;
using Express.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Invoice;
using Express.Domain.Message;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;

namespace Express.Business.Invoice
{
    public class InvFrtInvPorcessPrintBusiness : IInvFrtProcessPrint
    {
        private readonly IInvFrtProcessPrint _inv_Proces;
        public InvFrtInvPorcessPrintBusiness(IInvFrtProcessPrint _inv_Proces)
        {
            this._inv_Proces = _inv_Proces;

        }

        public IList<InvoiceTypeCategoryDomainView> DocumentTypes(int companyId, int agencyID)
        {
            return _inv_Proces.DocumentTypes(companyId, agencyID);
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _inv_Proces.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<InvFrtPrintProcessDomainView> GetFrtBillingDetail(InvFrtPrintProcessParaDomainView _para)
        {
            return _inv_Proces.GetFrtBillingDetail(_para);
        }

        public IList<InvFrtPrintProcessDomainView> GetFrtInvoiceDetail(InvFrtPrintProcessParaDomainView _para)
        {
            return _inv_Proces.GetFrtInvoiceDetail(_para);
        }

        public IList<FrtInvoiceReportDomainView> GetIFrtRptInvoiceDetail(InvFrtPrintProcessParaDomainView _para)
        {
            return _inv_Proces.GetIFrtRptInvoiceDetail(_para);
        }

        public IList<FrtInvoiceSummeryDomainView> GetIFrtRptInvoiceSummary(InvFrtPrintProcessParaDomainView _para)
        {
            return _inv_Proces.GetIFrtRptInvoiceSummary(_para);
        }

        public IList<InvProcessModeDomainView> GetInvProcessMode()
        {
            return _inv_Proces.GetInvProcessMode();
        }

        public ResponseMessage InvBulkProcess(InvFrtPrintProcessParaDomainView para)
        {
            return _inv_Proces.InvBulkProcess(para);
        }
    }
}
