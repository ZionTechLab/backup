using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using FedexExpress.View.Domain.AdminConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Operation.OpsHelper.POD
{
    public interface IPodCreate
    {
       
        List<PodScanUploadDomainView> ImportPods(int CompanyID , int AgencyCode ,string ScanType);
        ResponseMessage ReprocessPods( IList<PodScanUploadDomainView> PodL , PodScanUploadParaDomainView _para);
        ResponseMessage SavePods(IList<PodScanUploadDomainView> PodL);
        void CancelPods();
        void NewPods();
        PodScanUploadDomainView AddPods(PodScanUploadDomainView _para , IList<PodScanUploadDomainView> _existPods);
        IList<PodScanUploadDomainView> DeletePod(IList<PodScanUploadDomainView> _existPods , int _sRowIdx);
        



    }
}
