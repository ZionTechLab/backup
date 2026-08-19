using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Operation.OpsHelper.POD
{
   public  interface IPodRetrive
    {
        
        List<PodScanUploadDomainView> RetrivePods(PodScanUploadParaDomainView _para);
        IList<CourrierDomainView> GetCourrier(string CountryID);

        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);

        IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY);
        void PrintSummery(PodScanUploadParaDomainView _para);
        void PrintDetail(PodScanUploadParaDomainView _para);
        int GetAwbCount(IList<PodScanUploadDomainView> PodL);
        void  GetPodScanReport(PodScanUploadParaDomainView para);

    }
}
