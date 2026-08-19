using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;

namespace Express.Business.Operations.Manifest
{
    public class ManifestUploadTNTBusiness : IManifestUploadTNT<ManifestUploadTNTDomainView>
    {
        IManifestUploadTNT<ManifestUploadTNTDomainView> _TNTmanifestData;
        public ManifestUploadTNTBusiness(IManifestUploadTNT<ManifestUploadTNTDomainView> TNTmanifestData)
        {
            _TNTmanifestData = TNTmanifestData;
        }

        public ConsMasterDomainView CheckConsExist(int CompanyId, int GroupId, int AgencyId, string ConsId)
        {
            return _TNTmanifestData.CheckConsExist(CompanyId,GroupId,AgencyId,ConsId);
        }

        public ResponseMessage DeleteDetail(ManifestUploadTNTDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ConsMasterDomainView typePara)
        {
            return _TNTmanifestData.EditDetails(typePara);
        }

        public ResponseMessage EditDetails(ManifestUploadTNTDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _TNTmanifestData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ConsMasterDomainView> GetConsDetail(int CompanyId, int GroupId, int AgencyId, string TransDate, string ShipType)
        {
            return _TNTmanifestData.GetConsDetail(CompanyId, GroupId, AgencyId, TransDate, ShipType);
        }

        public string GetCountryCodeFromLocation(string HubId)
        {
            return _TNTmanifestData.GetCountryCodeFromLocation(HubId);
        }

        public List<ManifestUploadTNTDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadTNTDomainView> GetDetails(ManifestUploadTNTDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadTNTDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _TNTmanifestData.GetGateways(CountryID);
        }

        public IList<OpsConsAWBDomainView> GetOpsConsAWBDetail(int CompanyId, int GroupId, int AgencyId, string ConsId)
        {
            return _TNTmanifestData.GetOpsConsAWBDetail(CompanyId, GroupId, AgencyId, ConsId);
        }

        public ResponseMessage SaveAwbList(ManifestUploadWrappingDomain typePara)
        {
            return _TNTmanifestData.SaveAwbList(typePara);
        }

        public ResponseMessage SaveCons(ConsMasterDomainView typePara)
        {
            return _TNTmanifestData.SaveCons(typePara);
        }

        public ResponseMessage SaveConsList(ManifestUploadWrappingDomain typePara)
        {
            return _TNTmanifestData.SaveConsList(typePara);
        }

        public ResponseMessage SaveDetails(ManifestUploadTNTDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
