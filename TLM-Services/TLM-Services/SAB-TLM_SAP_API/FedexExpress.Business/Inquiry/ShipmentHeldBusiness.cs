using Express.Interfaces.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Inquiry;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Login;

namespace Express.Business.Inquiry
{
   public class ShipmentHeldBusiness: IShipmentHeld
    {
        private readonly IShipmentHeld _inqShipHeld;
        public ShipmentHeldBusiness(IShipmentHeld _inqShipHeld)
        {
            this._inqShipHeld = _inqShipHeld;
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _inqShipHeld.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<GatewaysDomainView> GetGateways(int companyID)
        {
            return _inqShipHeld.GetGateways(companyID);
        }

        public IList<InqShipmetHeldDomainView> GetShipmetHeld(InqShipmentHeldPara para)
        {
            return _inqShipHeld.GetShipmetHeld(para);
        }

        public IList<StationDomainView> GetStations(int companyID)
        {
            return _inqShipHeld.GetStations(companyID);
        }
    }
}
