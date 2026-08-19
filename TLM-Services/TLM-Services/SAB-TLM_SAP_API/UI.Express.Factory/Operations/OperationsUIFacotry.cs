using Express.Business.Operations.Manifest;
using Express.Data.Operations.Manifest;
using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Operations
{
    public sealed class  OperationsUIFacotry
    {
        private  static Dictionary<object, object> servicecontainer = null;
        private OperationsUIFacotry()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IManifestUpload<ManifestUploadDomainView>), new ManifestUploadBusiness(new ManifestUploadData()));
                servicecontainer.Add(typeof(ISearchClearancePreAlert<ClearancePreAlertDomainView>), new SearchClearancePreAlertBusiness(new SearchClearancePreAlertData()));
                servicecontainer.Add(typeof(IClearancePreAlert<ClearancePreAlertDomainView>), new ClearancePreAlertBusiness(new ClearancePreAlertData()));
                servicecontainer.Add(typeof(IManifestUploadTNT<ManifestUploadTNTDomainView>), new ManifestUploadTNTBusiness(new ManifestUploadTNTData()));
                servicecontainer.Add(typeof(IManifestUploadFedex<ManifestUploadFedexDomainView>), new ManifestUploadFedexBusiness(new ManifestUploadFedexData()));
                servicecontainer.Add(typeof(IWebManifest<WebManifestDomainView>), new WebManifestBusiness(new WebManifestData()));
                servicecontainer.Add(typeof(IManifestInboundEdit<ManifestInboundDomainView>), new ManifestInboundEditBusiness(new ManifestInboundEditData()));
                servicecontainer.Add(typeof(IManifestInbound<ManifestInboundDomainView>), new ManifestInboundBusiness(new ManifestInboundData()));
                servicecontainer.Add(typeof(IManifestInboundInvPopup), new ManifestInboundInbPopupBusiness(new ManifestInboundInvPopupData()));

                servicecontainer.Add(typeof(IWebManifestPopups), new WebManifestPopupBusiness(new WebManifestPopUpData()));
                servicecontainer.Add(typeof(IAWBManual), new AWBManualBusiness(new AWBManualData()));
                servicecontainer.Add(typeof(IRouteMaster<RouteMasterView>), new RouteMasterBusiness(new RouteMasterData()));
                servicecontainer.Add(typeof(IEmployeeMaster<EmployeeMasterView>), new EmployeeMasterBusiness(new EmployeeMasterData()));
                servicecontainer.Add(typeof(IPodScansProvider), new PodScanBusiness(new PodScanData()));

            }

            #endregion
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
        
    }
}
