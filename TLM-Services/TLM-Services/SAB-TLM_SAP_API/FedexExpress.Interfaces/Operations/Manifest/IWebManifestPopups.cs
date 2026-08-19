using Express.Domain.Message;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
   public interface IWebManifestPopups
    { //station , route , Clearence Type ,consol type ,Clearence status
        IList<StationDomainView> GetStations(int companyID);
        IList<RouteDomainView> GetRoute(int companyID);
        IList<ClearenceTypeDomainView> GetClearenceType();
        IList<ClearenceStatusDomainView> GetClearenceStatus();
        IList<ConsoleTypeDomainView> GetConsoleTypes();
        ResponseMessage UpdateAwbs(WebManiPopParamDomainView _para);


    }
}
