using Express.Domain.Message;
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
   public interface IInvPickProcessRepo
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<InvDelDocTypes> GetPickDocTypes(int companyID, int agencyID, string category);
        InvPickProcessDomainView GetPickSummeryDetail(InvPickProcessPramDomainView _para);
        ResponseMessage PickBillingProcess(InvPickProcessPramDomainView _para);
        ResponseMessage PickInvoiceProcess(InvPickProcessPramDomainView _para);
        InvPickProcessDomainView GetPickInvoiceDetail(InvPickProcessPramDomainView _para);
        IList<InvoicePickupRptDomainView> GetRptPickupBillingPending(InvPickProcessPramDomainView _para);
        IList<InvoicePickupRptDomainView> GetRptPickupInvoicePending(InvPickProcessPramDomainView _para);
        IList<InvoicePickupRepSummeryDomainView> GetRptPickupSummary(InvPickProcessPramDomainView _para);
        IList<InvoicePickupRepDetailDomainView> GetRptPickupDetail(InvPickProcessPramDomainView _para);
    }
}
