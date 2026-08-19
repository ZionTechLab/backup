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
    public class ManifestUploadFedexBusiness : IManifestUploadFedex<ManifestUploadFedexDomainView>
    {
        IManifestUploadFedex<ManifestUploadFedexDomainView> _FedexmanifestData;
        public ManifestUploadFedexBusiness(IManifestUploadFedex<ManifestUploadFedexDomainView> FedexmanifestData)
        {
            _FedexmanifestData = FedexmanifestData;
        }
        public ResponseMessage DeleteDetail(ManifestUploadFedexDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ConsMasterDomainView typePara)
        {
            return _FedexmanifestData.EditDetails(typePara);
        }

        public ResponseMessage EditDetails(ManifestUploadFedexDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _FedexmanifestData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ConsMasterDomainView> GetConsDetail(int CompanyId, int GroupId, int AgencyId, string TransDate, string ShipType)
        {
            return _FedexmanifestData.GetConsDetail(CompanyId,GroupId,AgencyId,TransDate,ShipType);
        }

        public string GetCountryCodeFromLocation(string HubId)
        {
            return _FedexmanifestData.GetCountryCodeFromLocation(HubId);
        }

        public List<ManifestUploadFedexDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadFedexDomainView> GetDetails(ManifestUploadFedexDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadFedexDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _FedexmanifestData.GetGateways(CountryID);
        }

        public IList<OpsConsAWBDomainView> GetOpsConsAWBDetail(int CompanyId, int GroupId, int AgencyId, string ConsId)
        {
            return _FedexmanifestData.GetOpsConsAWBDetail(CompanyId,GroupId,AgencyId,ConsId);
        }

        public ResponseMessage SaveAwbList(ManifestUploadWrappingDomain typePara)
        {
            return _FedexmanifestData.SaveAwbList(typePara);
        }

        public ResponseMessage SaveCons(ConsMasterDomainView typePara)
        {
            return _FedexmanifestData.SaveCons(typePara);
        }

        //public ResponseMessage SaveConsList(ConsMasterDomainView typePara)
        //{
        //    return _FedexmanifestData.SaveConsList(typePara);
        //}

        public ResponseMessage SaveDetails(ManifestUploadFedexDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
