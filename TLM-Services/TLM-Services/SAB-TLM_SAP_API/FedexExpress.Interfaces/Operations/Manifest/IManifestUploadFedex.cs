using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IManifestUploadFedex<T> : IDataAccess<ManifestUploadFedexDomainView> where T : class
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<GatewayDomainView> GetGateways(string CountryID);
        ResponseMessage SaveCons(ConsMasterDomainView typePara);
        IList<ConsMasterDomainView> GetConsDetail(int CompanyId, int GroupId, int AgencyId, string TransDate, string ShipType);
        IList<OpsConsAWBDomainView> GetOpsConsAWBDetail(int CompanyId, int GroupId, int AgencyId, string ConsId);
        string GetCountryCodeFromLocation(string HubId);
        ResponseMessage SaveAwbList(ManifestUploadWrappingDomain typePara);
        ResponseMessage EditDetails(ConsMasterDomainView typePara);

    }
}
