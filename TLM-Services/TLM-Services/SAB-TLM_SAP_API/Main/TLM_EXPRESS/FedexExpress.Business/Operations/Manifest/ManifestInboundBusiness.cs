using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Operation;

namespace Express.Business.Operations.Manifest
{
    public class ManifestInboundBusiness : IManifestInbound<ManifestInboundDomainView>
    {
        IManifestInbound<ManifestInboundDomainView> ManifestData;

        public ManifestInboundBusiness(IManifestInbound<ManifestInboundDomainView> _ManifestData)
        {
            this.ManifestData = _ManifestData;
        }

        public ResponseMessage DeleteDetail(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return ManifestData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<CfgDtaxCalDomainView> GetCfgDtaxCal()
        {
            return ManifestData.GetCfgDtaxCal();
        }

        public List<ManifestInboundDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestInboundDomainView> GetDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestInboundDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return ManifestData.GetGateways(CountryID);
        }

        public IList<RptManifestDomainView> GetManiferReport(RptManifestParaDomainView _para)
        {
            return ManifestData.GetManiferReport(_para);
        }

        public ManifestClearenceDomainView GetManifestClearenceConf(int companyID)
        {
            return ManifestData.GetManifestClearenceConf(companyID);
        }

        public IList<OpsConsAWBDomainView> GetOpsConsAWB(ManifestProcessParamDomainView typePara)
        {
            return ManifestData.GetOpsConsAWB(typePara);
        }

        public IList<OpsConsAWBDomainView> GetOpsConsAWB(string ConsId)
        {
            return ManifestData.GetOpsConsAWB(ConsId);
        }

        public IList<OpsConsMasterDomainView> GetOpsConsMaster(int AgncyID, int CMPY, string DesHubID, DateTime TransDate)
        {
            return ManifestData.GetOpsConsMaster(AgncyID, CMPY, DesHubID, TransDate);
        }

        public IList<RefExgRatesDomainView> GetRefExgRates(int CMPY, string Currency, DateTime EffectDate)
        {
            return ManifestData.GetRefExgRates(CMPY, Currency, EffectDate);
        }

        public ResponseMessage InvoiceProcess(ManifestProcessParamDomainView typePara)
        {
            return ManifestData.InvoiceProcess(typePara);
        }

        public ResponseMessage ProcessManifestClearence(ManifestProcessParamDomainView typePara)
        {
            return ManifestData.ProcessManifestClearence(typePara);
        }

        public ResponseMessage ProcessManifestInbound(OpsConsAWBDomainView typePara)
        {
            return ManifestData.ProcessManifestInbound(typePara);
        }

        public ResponseMessage SaveDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage UpdateManifestInboundDutyStatus(OpsConsAWBDomainView typePara)
        {
            return ManifestData.UpdateManifestInboundDutyStatus(typePara);
        }
    }
}
