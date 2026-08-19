using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.AdminConfiguration;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;

namespace Express.Business.Operations.Manifest
{
    public class WebManifestPopupBusiness : IWebManifestPopups
    {
        private readonly IWebManifestPopups _webpop;
        public WebManifestPopupBusiness(IWebManifestPopups _webpop)
        {
            this._webpop = _webpop;
        }
        public IList<ClearenceStatusDomainView> GetClearenceStatus()
        {
           return  _webpop.GetClearenceStatus() ;
        }

        public IList<ClearenceTypeDomainView> GetClearenceType()
        {
            return _webpop.GetClearenceType();
        }

        public IList<ConsoleTypeDomainView> GetConsoleTypes()
        {
            return _webpop.GetConsoleTypes();
        }

        public IList<RouteDomainView> GetRoute(int companyID)
        {
            return _webpop.GetRoute(companyID);
        }

        public IList<StationDomainView> GetStations(int companyID)
        {
            return _webpop.GetStations(companyID);
        }

        public ResponseMessage UpdateAwbs(WebManiPopParamDomainView _para)
        {
            return _webpop.UpdateAwbs(_para);
        }
    }
}
