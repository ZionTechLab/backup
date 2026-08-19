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
    public class ManifestUploadBusiness : IManifestUpload<ManifestUploadDomainView>
    {
        IManifestUpload<ManifestUploadDomainView> _ManifestData;
        public ManifestUploadBusiness(IManifestUpload<ManifestUploadDomainView> ManifestData)
        {
            this._ManifestData = ManifestData;
        }
        public ResponseMessage DeleteDetail(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ConsMasterDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _ManifestData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ConsMasterDomainView> GetConsDetail(int CompanyId, int GroupId, int AgencyId, string TransDate, string Gate)
        {
            return _ManifestData.GetConsDetail(CompanyId, GroupId, AgencyId, TransDate, Gate);
        }

        public string GetCountryCodeFromLocation(string HubId)
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadDomainView> GetDetails(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _ManifestData.GetGateways(CountryID);
        }

        public IList<OpsConsAWBDomainView> GetOpsAWBDetailFromDupliacte(int CompanyId, int AgencyId, string ConsId)
        {
            return _ManifestData.GetOpsAWBDetailFromDupliacte(CompanyId, AgencyId, ConsId);
        }
        public IList<OpsConsAWBDomainView> GetOpsConsAWBDetail(int CompanyId, int GroupId, int AgencyId, string ConsId)
        {
            return _ManifestData.GetOpsConsAWBDetail(CompanyId,GroupId,AgencyId,ConsId);
        }

        public ResponseMessage SaveCons(ConsMasterDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SaveDetails(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SaveFedexAwbList(ManifestUploadWrappingDomain typePara)
        {
            return _ManifestData.SaveFedexAwbList(typePara);
        }

        public ResponseMessage SaveTntAwbList(ManifestUploadWrappingDomain typePara)
        {
            return _ManifestData.SaveTntAwbList(typePara);
        }
    }
}
