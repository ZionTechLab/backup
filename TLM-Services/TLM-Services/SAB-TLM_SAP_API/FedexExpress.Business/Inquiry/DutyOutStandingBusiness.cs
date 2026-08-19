using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.Inquiry
{
    public class DutyOutStandingBusiness: IDutyOutstanding
    {
        IDutyOutstanding _iDutyOutstanding;
        public DutyOutStandingBusiness(IDutyOutstanding _iDutyOutstanding)
        {
            this._iDutyOutstanding = _iDutyOutstanding;
        }


        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _iDutyOutstanding.GetAgencyDetail(UserId, ModuleId, MenueId);
        }


        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _iDutyOutstanding.GetGateways(CountryID);
        }


        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            return _iDutyOutstanding.GetStations(CountryID);
        }

        public IList<RefSvcRootsDomainView> GetRoutes(string CountryID)
        {
            return _iDutyOutstanding.GetRoutes(CountryID);
        }


        public  IList<DutyOutstandingViewModel> GetOutstaindingInvoice(DateTime fromDate, DateTime todate, int CMPY, int agency, int groupID, string Gate, string Station, string Route, string Courier, string PayMode, bool DelPackg, bool OutstandingOnly, bool GateWayAll, bool StationAll, bool RouteAll, bool CourierAll,bool AgencyAll)
        {
            return _iDutyOutstanding.GetOutstaindingInvoice(fromDate, todate, CMPY, agency, groupID, Gate, Station, Route, Courier, PayMode, DelPackg, OutstandingOnly, GateWayAll, StationAll, RouteAll, CourierAll, AgencyAll);
        }



       public  IList<CourrierDomainView> GetCourrier(string CountryID)
        {
            return _iDutyOutstanding.GetCourrier(CountryID);
        }

    }
}
