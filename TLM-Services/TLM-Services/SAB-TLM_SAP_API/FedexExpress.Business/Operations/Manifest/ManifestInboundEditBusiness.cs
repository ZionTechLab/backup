using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.AdminConfiguration;

namespace Express.Business.Operations.Manifest
{
    public class ManifestInboundEditBusiness : IManifestInboundEdit<ManifestInboundDomainView>
    {
        IManifestInboundEdit<ManifestInboundDomainView> ManifestDataEdit;
        public ManifestInboundEditBusiness(IManifestInboundEdit<ManifestInboundDomainView> _ManifestDataEdit)
        {
            this.ManifestDataEdit = _ManifestDataEdit;
        }
        public ResponseMessage DeleteDetail(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<CfgDtaxCalDomainView> GetCfgDtaxCal()
        {
            return ManifestDataEdit.GetCfgDtaxCal();
        }

        public IList<CurrencyDetailDomainView> GetCurrencyDetail(string para)
        {
            return ManifestDataEdit.GetCurrencyDetail(para);
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

        public IList<RefLocationsDomainView> GetRefLocationsStations()
        {
            return ManifestDataEdit.GetRefLocationsStations();
        }

        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
            return ManifestDataEdit.GetRefSvcRoots(CMPY);
        }

        public ResponseMessage SaveDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage UpdateManifestInbound(OpsConsAWBDomainView typePara)
        {
            return ManifestDataEdit.UpdateManifestInbound(typePara);
        }
    }
}
