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
    public class PaymetSummaryBusiness : IPaymnetSummary<PaymetSummaryDomainView>
    {
        IPaymnetSummary<PaymetSummaryDomainView> _paymetSummary;
        public PaymetSummaryBusiness(IPaymnetSummary<PaymetSummaryDomainView> paymetSummary)
        {
            this._paymetSummary = paymetSummary;
        }
        public ResponseMessage DeleteDetail(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _paymetSummary.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            return _paymetSummary.GetCfgDoctypes(CMPY, AgncyCode);
        }

        public List<PaymetSummaryDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<PaymetSummaryDomainView> GetDetails(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<PaymetSummaryDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _paymetSummary.GetGateways(CountryID);
        }

        public IList<PaymetSummaryDomainView> GetInvoiceList(string fDate, string frominvNo, string ToInvNo, string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType, bool isInvoiceRange, int payAcc, int IsPayRev)
        {
            return _paymetSummary.GetInvoiceList(fDate, frominvNo, ToInvNo, todate, CMPY, agency, groupID, Gate, Station, InvoiceType, isInvoiceRange, payAcc, IsPayRev);
        }

        public IList<InvoiceTypeDomainView> GetInvoiceType()
        {
            return _paymetSummary.GetInvoiceType();
        }

        public IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID)
        {
            return _paymetSummary.GetClrPayAccounts(companyID);
        }
        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            return _paymetSummary.GetStations(CountryID);
        }

        public ResponseMessage SaveDetails(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
