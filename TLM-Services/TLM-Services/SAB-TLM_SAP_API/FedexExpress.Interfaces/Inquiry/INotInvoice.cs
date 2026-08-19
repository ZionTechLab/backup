using Express.Interfaces.Common;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Inquiry
{
    public interface INotInvoice<T> : IDataAccess<NotInvoiceReportDomainView> where T : class
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<GatewayDomainView> GetGateways(string CountryID);
        IList<GatewayDomainView> GetStations(string CountryID);
        IList<InvoiceTypeDomainView> GetInvoiceType();
        IList<NotInvoiceReportDomainView> GetInvoiceList(string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType);
        IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode);
    }
}
