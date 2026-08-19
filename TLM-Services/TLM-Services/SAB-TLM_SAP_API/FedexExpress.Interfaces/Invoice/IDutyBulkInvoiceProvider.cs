using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Invoice
{

   public interface IDutyBulkInvoiceProvider
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<RefLocationsDomainView> GetRefLocationsStations();
        IList<GatewayDomainView> GetGateways(string CountryID);
        IList<InvDutyBulkInvoiceDomainView> GetNotInvoice(InvDutyBulkInvoiceParaDomainView _param);

        IList<InvDutyBulkInvoiceDomainView> GetInvoiced(InvDutyBulkInvoiceParaDomainView _param);
        ResponseMessage ProccessLVInvoiceses(InvDutyBulkInvoiceParaDomainView _param);

    } 
}
