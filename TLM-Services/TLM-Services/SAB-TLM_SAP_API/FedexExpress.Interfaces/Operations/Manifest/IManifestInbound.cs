using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IManifestInbound<T> : IDataAccess<ManifestInboundDomainView> where T : class
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);

        IList<GatewayDomainView> GetGateways(string CountryID);

        IList<OpsConsMasterDomainView> GetOpsConsMaster(int AgncyID, int CMPY, string DesHubID, DateTime TransDate);

        IList<OpsConsAWBDomainView> GetOpsConsAWB(string ConsId);

        IList<OpsConsAWBDomainView> GetOpsConsAWBEx(string ConsId, string ExpressCons);

        IList<RefExgRatesDomainView> GetRefExgRates(int CMPY, string Currency, DateTime EffectDate);

        IList<CfgDtaxCalDomainView> GetCfgDtaxCal();

        ResponseMessage ProcessManifestInbound(OpsConsAWBDomainView typePara);

        ResponseMessage UpdateManifestInboundDutyStatus(OpsConsAWBDomainView typePara);

        ResponseMessage ProcessManifestClearence(ManifestProcessParamDomainView typePara);
        IList<OpsConsAWBDomainView> GetOpsConsAWB(ManifestProcessParamDomainView typePara);
        ResponseMessage InvoiceProcess(ManifestProcessParamDomainView typePara);
        IList<RptManifestDomainView> GetManiferReport(RptManifestParaDomainView _para);

        ManifestClearenceDomainView GetManifestClearenceConf(int companyID);

    }
}
