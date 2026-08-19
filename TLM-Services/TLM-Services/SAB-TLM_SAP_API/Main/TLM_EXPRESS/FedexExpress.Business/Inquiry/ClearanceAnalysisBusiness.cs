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
    public class ClearanceAnalysisBusiness : IClearanceAnalysis<ClearanceAnalysisDomainView>
    {
        IClearanceAnalysis<ClearanceAnalysisDomainView> _ClearnceAnlysisSummary;
        public ClearanceAnalysisBusiness(IClearanceAnalysis<ClearanceAnalysisDomainView> ClearnceAnlysisSummary)
        {
            this._ClearnceAnlysisSummary = ClearnceAnlysisSummary;
        }
        public ResponseMessage DeleteDetail(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
           return _ClearnceAnlysisSummary.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            return _ClearnceAnlysisSummary.GetCfgDoctypes(CMPY, AgncyCode);
        }

        public List<ClearanceAnalysisDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ClearanceAnalysisDomainView> GetDetails(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ClearanceAnalysisDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _ClearnceAnlysisSummary.GetGateways(CountryID);
        }

        public IList<ClearanceAnalysisDomainView> GetInvoiceList(string fDate, string frominvNo, string ToInvNo, string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType, bool isInvoiceRange)
        {
            return _ClearnceAnlysisSummary.GetInvoiceList(fDate, frominvNo, ToInvNo, todate, CMPY, agency, groupID, Gate, Station, InvoiceType, isInvoiceRange);
        }

        public IList<InvoiceTypeDomainView> GetInvoiceType()
        {
            return _ClearnceAnlysisSummary.GetInvoiceType();
        }

        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            return _ClearnceAnlysisSummary.GetStations(CountryID);
        }

        public ResponseMessage SaveDetails(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
