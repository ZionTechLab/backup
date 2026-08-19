using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Inquiry
{
   public  interface IShipmentHeld
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<InqShipmetHeldDomainView> GetShipmetHeld(InqShipmentHeldPara para);
        IList<GatewaysDomainView> GetGateways(int companyID);
        IList<StationDomainView> GetStations(int companyID);
    }
}
