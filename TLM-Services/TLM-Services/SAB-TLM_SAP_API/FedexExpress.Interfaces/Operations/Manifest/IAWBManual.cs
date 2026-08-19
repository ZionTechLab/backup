using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.Login;

using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IAWBManual
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);        
        IList<CountryDomainView> GetCountryList(string CountryCode);

        IList<CityDomainView> GetCityList(string CountryCode, string CityCode);

        IList<PackageDomainView> GetPackageList(string AgencyCode, string PackageCode);

        IList<ServiceDominView> GetServiceList(string AgencyCode, string ServiceCode);

        ResponseMessage SaveAWBD(AWBDomainView typePara);

        IList<ConsDomainView> GetConsoleList(int GroupID, int Company, int AgencyCode, string ConsoleID);


        IList<AWBDomainView> GetAWBList(string AWBNo);


        IList<CommonDomainView> GetUOMist(string UomCode);

        IList<CommonDomainView> GetDimVolUOMist(string UomCode);

        IList<CommonDomainView> BillChgTo(string Code);

        IList<AWBDomainView> GetAWBMPSList(string AWBNo, string ConsID, string ExpressID);

        ResponseMessage DeleteAWBD(AWBDomainView typePara);


        IList<RefLocationsDomainView> GetLocationList(string Country, string AgnLocation);

        IList<AWBDomainView> GetAWBBilledList(string AWBNo);
        IList<ConsDomainView> GetShipTypeList(int cmy, int AgencyCode, string OrgCountry, string DestCountry);
    }
}
