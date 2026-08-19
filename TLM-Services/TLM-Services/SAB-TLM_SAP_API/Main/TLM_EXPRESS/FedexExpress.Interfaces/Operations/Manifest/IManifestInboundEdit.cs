using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IManifestInboundEdit<T> : IDataAccess<ManifestInboundDomainView> where T : class
    {
        ResponseMessage UpdateManifestInbound(OpsConsAWBDomainView typePara);
        IList<CfgDtaxCalDomainView> GetCfgDtaxCal();
        IList<RefLocationsDomainView> GetRefLocationsStations();
        IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY);
        IList<CurrencyDetailDomainView> GetCurrencyDetail(string para);
    }
}
