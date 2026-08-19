using Express.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;

namespace Express.Business.Invoice
{
    public class InvPickProcessBusiness : IInvPickProcessRepo
    {
        private readonly IInvPickProcessRepo _pickProvider;
        public InvPickProcessBusiness(IInvPickProcessRepo _pickProvider)
        {
            this._pickProvider = _pickProvider;
        }
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _pickProvider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<InvDelDocTypes> GetPickDocTypes(int companyID, int agencyID, string category)
        {
            return _pickProvider.GetPickDocTypes(companyID, agencyID, category);
        }

        public InvPickProcessDomainView GetPickInvoiceDetail(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.GetPickInvoiceDetail(_para);
        }

        public InvPickProcessDomainView GetPickSummeryDetail(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.GetPickSummeryDetail(_para);
        }

        public IList<InvoicePickupRptDomainView> GetRptPickupBillingPending(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.GetRptPickupBillingPending(_para);
        }

        public IList<InvoicePickupRepDetailDomainView> GetRptPickupDetail(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.GetRptPickupDetail(_para);
        }

        public IList<InvoicePickupRptDomainView> GetRptPickupInvoicePending(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.GetRptPickupInvoicePending(_para);
        }

        public IList<InvoicePickupRepSummeryDomainView> GetRptPickupSummary(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.GetRptPickupSummary(_para);
        }

        public ResponseMessage PickBillingProcess(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.PickBillingProcess(_para);
        }

        public ResponseMessage PickInvoiceProcess(InvPickProcessPramDomainView _para)
        {
            return _pickProvider.PickInvoiceProcess(_para);
        }
    }
}
