using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.AdminConfiguration;
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
    public interface IWebManifest<T> : IDataAccess<WebManifestDomainView> where T : class
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<GatewayDomainView> GetGateways(string CountryID);
        IList<ServiceTypeDomainView> GetServiceType(int CMPY, int Agency);
        IList<CfgCountryDomainView> GetCountryList();
        ResponseMessage SaveWebAWBList(WebManufestUploadWrappingDoaminView typePara);
        IList<WebManifestDomainView> GetFilterResult(int CMPY, int Agency,string FilterStarte,string FDate,string ToDate,string OCountryCode,string DestinLoc,string ServiceType,string ManifestType,string FBill,string Dbill,string Cargodesc,string Consignee);

        IList<ClearenceStatusDomainView> GetClearenceStatus();
        IList<WebManiClearenceType> GetClearenceTypes();
        ManifestClearenceDomainView GetManifestClearenceConf(int companyID);
        IList<RefExgRatesDomainView> GetRefExgRates(int CMPY, string Currency, DateTime EffectDate);
        ResponseMessage ProcessManifestClearence(ManifestProcessParamDomainView typePara);
        IList<RptPreManifestDomainView> GetPreManifestReport(RptManifestParaDomainView _para);

    }
}
