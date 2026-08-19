using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.PickupInvioceProcess
{
    public interface IPickInvoicePreview
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<InvDelDocTypes> GetPickDocTypes(int companyID ,int agencyID , string category);
        InvPickProcessDomainView GetPickSummeryDetail(InvPickProcessPramDomainView _para);
        InvPickProcessDomainView GetPickInvoiceDetail(InvPickProcessPramDomainView _para);
        void GetRptPickupBillingPending(InvPickProcessPramDomainView _para);
        void GetRptPickupInvoicePending(InvPickProcessPramDomainView _para);
        void GetRptPickupSummary(InvPickProcessPramDomainView _para);
        void GetRptPickupDetail(InvPickProcessPramDomainView _para);

    }
}
