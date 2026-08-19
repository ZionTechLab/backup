using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;

namespace Express.Business.Inquiry
{
    public class NotInvoiceBusiness : INotInvoice<NotInvoiceReportDomainView>
    {
        INotInvoice<NotInvoiceReportDomainView> notInvoice;
        public NotInvoiceBusiness(INotInvoice<NotInvoiceReportDomainView> _notInvoice)
        {
            this.notInvoice = _notInvoice;
        }
        public ResponseMessage DeleteDetail(NotInvoiceReportDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(NotInvoiceReportDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return notInvoice.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            return notInvoice.GetCfgDoctypes(CMPY, AgncyCode);
        }

        public List<NotInvoiceReportDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<NotInvoiceReportDomainView> GetDetails(NotInvoiceReportDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<NotInvoiceReportDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return notInvoice.GetGateways(CountryID);
        }

        public IList<NotInvoiceReportDomainView> GetInvoiceList(string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType)
        {
            return notInvoice.GetInvoiceList( todate, CMPY, agency, groupID, Gate, Station, InvoiceType);
        }

        public IList<InvoiceTypeDomainView> GetInvoiceType()
        {
            return notInvoice.GetInvoiceType();
        }

        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            return notInvoice.GetStations(CountryID);
        }

        public ResponseMessage SaveDetails(NotInvoiceReportDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
