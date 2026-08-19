using Express.Interfaces.Common;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Inquiry
{
    public interface IDutyOutstanding
      
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);


        IList<GatewayDomainView> GetGateways(string CountryID);


        IList<GatewayDomainView> GetStations(string CountryID);


        IList<RefSvcRootsDomainView> GetRoutes(string CountryID);


         IList<DutyOutstandingViewModel> GetOutstaindingInvoice(DateTime fromDate, DateTime todate, int CMPY, int agency, int groupID, string Gate, string Station, string Route, string Courier, string PayMode, bool DelPackg, bool OutstandingOnly, bool GateWayAll, bool StationAll, bool RouteAll, bool CourierAll,bool AgencyAll);


        IList<CourrierDomainView> GetCourrier(string CountryID);
    }
}
