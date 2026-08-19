using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Factory.Operations;
using Express.View.Domain.Login;
using Express.UI.Common.Helpers;
using Express.UI.Helpers;
using Express.UI.Factory.Report.Operation;
using Express.Interfaces.Report.Operation;

namespace Express.UI.Operation.OpsHelper.POD
{
    public class PodRetrive : IPodRetrive
    {
        private readonly IPodScansProvider _podscanprovider;
      
        public  PodRetrive()
        {
            _podscanprovider = OperationsUIFacotry.GetService<IPodScansProvider>();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _podscanprovider.GetAgencyDetail( UserId,  ModuleId,  MenueId);
        }

        public int GetAwbCount(IList<PodScanUploadDomainView> PodL)
        {
            if(PodL ==null)
            {
                return 0;
            }
            return PodL.Count;
        }

        public IList<CourrierDomainView> GetCourrier(string CountryID)
        {
            return _podscanprovider.GetCourrier(CountryID);
        }

        public void GetPodScanReport(PodScanUploadParaDomainView para)
        {
            var podReport = RptOperationUIFactory.GetService<IOperationReportProvider>();
            podReport.GetPodScanReport(_podscanprovider.GetPodScanReport(para));
        }

        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
           return  _podscanprovider.GetRefSvcRoots(CMPY);
        }

        public void PrintDetail(PodScanUploadParaDomainView _para)
        {
            throw new NotImplementedException();
        }

        public void PrintSummery(PodScanUploadParaDomainView _para)
        {
            throw new NotImplementedException();
        }

       
        public List<PodScanUploadDomainView> RetrivePods(PodScanUploadParaDomainView _para)
        {
            if(_para.AgencyID ==0)
            {
                MessageNotification.MessageBoxError("Please select agency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }
            if(_para.CompanyID ==0)
            {
                MessageNotification.MessageBoxError("Please select company", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }
            return _podscanprovider.RetrivePods(_para).ToList();
        }
    }
}
