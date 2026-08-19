using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using FedexExpress.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.FrightInvoiceProcess
{
    public interface IFrtProcessLoad
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<InvProcessModeDomainView> GetInvProcessMode();
        IList<InvoiceTypeCategoryDomainView> DocumentTypes(int companyId, int agencyID);
        IList<InvFrtPrintProcessDomainView> GetFrtBillingDetail(InvFrtPrintProcessParaDomainView _para , InvFrtShipTypes _shipType );
        IList<InvFrtPrintProcessDomainView> GetFrtInvoiceDetail(InvFrtPrintProcessParaDomainView _para, InvFrtShipTypes _shipType);
    }
}
