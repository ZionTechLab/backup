using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FedexExpress.View.Domain.AdminConfiguration;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Login;
using Express.Domain.Message;
using FedexExpress.View.Domain.Operations;

namespace Express.Business.Operations.Manifest
{
    public class PodScanBusiness : IPodScansProvider
    {
        private  readonly IPodScansProvider _podscans;
        public PodScanBusiness(IPodScansProvider _podscans)
        {
            this._podscans = _podscans;
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _podscans.GetAgencyDetail( UserId,  ModuleId,  MenueId);
        }

        public IList<CourrierDomainView> GetCourrier(string CountryID)
        {
            return _podscans.GetCourrier(CountryID);
        }

        public IList<PodScanRptDomainView> GetPodScanReport(PodScanUploadParaDomainView para)
        {
            return _podscans.GetPodScanReport(para);
        }

        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
            return _podscans.GetRefSvcRoots(CMPY);
        }

        public MapScanTypeDomainView GetScanTypes(int CompanyId, int AgencyId, string ScanTypeS)
        {
            return _podscans.GetScanTypes(CompanyId, AgencyId, ScanTypeS);
        }

        public ResponseMessage ReprocessPods(PodScanUploadParaDomainView _para)
        {
            return _podscans.ReprocessPods(_para);
        }

        public IList<PodScanUploadDomainView> RetrivePods(PodScanUploadParaDomainView _para)
        {
            return _podscans.RetrivePods(_para);
        }

        public ResponseMessage SavePods(IList<PodScanUploadDomainView> PodL)
        {
            return _podscans.SavePods(PodL);
        }
    }
}
