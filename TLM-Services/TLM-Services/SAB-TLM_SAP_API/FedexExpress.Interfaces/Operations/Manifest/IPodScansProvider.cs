using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using FedexExpress.View.Domain.AdminConfiguration;
using FedexExpress.View.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
   public interface IPodScansProvider
    {
        MapScanTypeDomainView GetScanTypes(int CompanyId, int AgencyId, string ScanTypeS);
        IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY);
        IList<CourrierDomainView> GetCourrier(string CountryID);
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<PodScanUploadDomainView> RetrivePods(PodScanUploadParaDomainView _para);
        ResponseMessage SavePods(IList<PodScanUploadDomainView> PodL);
        ResponseMessage ReprocessPods(PodScanUploadParaDomainView _para);
        IList<PodScanRptDomainView> GetPodScanReport(PodScanUploadParaDomainView para);

    }
}
