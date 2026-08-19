using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Invoice;

namespace Express.Business.Inquiry
{
    public class InvoiceSummaryBusiness : IInvoiceSummary<InvoiceSummaryDomainView>
    {
        IInvoiceSummary<InvoiceSummaryDomainView> _invoiceSummary;
        public InvoiceSummaryBusiness(IInvoiceSummary<InvoiceSummaryDomainView> invoiceSummary)
        {
            this._invoiceSummary=invoiceSummary;
        }
        public ResponseMessage DeleteDetail(InvoiceSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(InvoiceSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
           return _invoiceSummary.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            return _invoiceSummary.GetCfgDoctypes(CMPY, AgncyCode);
        }

        public List<InvoiceSummaryDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<InvoiceSummaryDomainView> GetDetails(InvoiceSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<InvoiceSummaryDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _invoiceSummary.GetGateways(CountryID);
        }

        public IList<InvoiceSummaryDomainView> GetInvoiceList(string fDate, string frominvNo, string ToInvNo, string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType, bool isInvoiceRange)
        {
            return _invoiceSummary.GetInvoiceList(fDate, frominvNo, ToInvNo, todate, CMPY, agency, groupID, Gate, Station, InvoiceType, isInvoiceRange);
        }

        public IList<InvoiceTypeDomainView> GetInvoiceType()
        {
            return _invoiceSummary.GetInvoiceType();
        }

        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            return _invoiceSummary.GetStations(CountryID);
        }

        public ResponseMessage SaveDetails(InvoiceSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
