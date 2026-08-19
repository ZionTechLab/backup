using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Report.Operation;

namespace Express.Business.Operations.Manifest
{
    public class WebManifestBusiness : IWebManifest<WebManifestDomainView>
    {
        IWebManifest<WebManifestDomainView> ManifestData;

        public WebManifestBusiness(IWebManifest<WebManifestDomainView> manifestData)
        {
            this.ManifestData = manifestData;
        }
        public ResponseMessage DeleteDetail(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return ManifestData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ClearenceStatusDomainView> GetClearenceStatus()
        {
            return ManifestData.GetClearenceStatus();
        }

        public IList<WebManiClearenceType> GetClearenceTypes()
        {
            return ManifestData.GetClearenceTypes();
        }

        public IList<CfgCountryDomainView> GetCountryList()
        {
            return ManifestData.GetCountryList();
        }

        public List<WebManifestDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<WebManifestDomainView> GetDetails(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<WebManifestDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<WebManifestDomainView> GetFilterResult(int CMPY, int Agency,string FilterStarte, string FDate, string ToDate, string OCountryCode, string DestinLoc, string ServiceType, string ManifestType, string FBill, string Dbill, string Cargodesc, string Consignee)
        {
            return ManifestData.GetFilterResult(CMPY, Agency, FilterStarte, FDate, ToDate, OCountryCode, DestinLoc, ServiceType, ManifestType, FBill, Dbill, Cargodesc, Consignee);
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return ManifestData.GetGateways(CountryID);
        }

        public IList<ServiceTypeDomainView> GetServiceType(int CMPY, int Agency)
        {
            return ManifestData.GetServiceType(CMPY, Agency);
        }

        public ResponseMessage SaveDetails(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SaveWebAWBList(WebManufestUploadWrappingDoaminView typePara)
        {
            return ManifestData.SaveWebAWBList(typePara);
        }

        public ManifestClearenceDomainView GetManifestClearenceConf(int companyID)
        {
            return ManifestData.GetManifestClearenceConf(companyID);
        }

        public IList<RefExgRatesDomainView> GetRefExgRates(int CMPY, string Currency, DateTime EffectDate)
        {
            return ManifestData.GetRefExgRates(CMPY, Currency, EffectDate);

        }

        public ResponseMessage ProcessManifestClearence(ManifestProcessParamDomainView typePara)
        {
            return ManifestData.ProcessManifestClearence(typePara);
        }

        public IList<RptPreManifestDomainView> GetPreManifestReport(RptManifestParaDomainView _para)
        {
            return ManifestData.GetPreManifestReport(_para);
        }
    }
}
