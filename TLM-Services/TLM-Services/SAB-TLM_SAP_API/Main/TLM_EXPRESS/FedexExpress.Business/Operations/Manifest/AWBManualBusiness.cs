using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.Operations.Manifest
{
    public class AWBManualBusiness : IAWBManual
    {

        private readonly IAWBManual AWBManualData;


        public AWBManualBusiness(IAWBManual _AWBManualData)
        {
            this.AWBManualData = _AWBManualData;
        }


        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return AWBManualData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }


        public IList<CountryDomainView> GetCountryList(string CountryCode)
        {
            return AWBManualData.GetCountryList(CountryCode);
        }


        public IList<CityDomainView> GetCityList(string CountryCode, string CityCode)
        {
            return AWBManualData.GetCityList(CountryCode, CityCode);
        }

        public IList<PackageDomainView> GetPackageList(string AgencyCode, string PackageCode)
        {
            return AWBManualData.GetPackageList(AgencyCode, PackageCode);
        }

        public IList<ServiceDominView> GetServiceList(string AgencyCode, string ServieCode)
        {
            return AWBManualData.GetServiceList(AgencyCode, ServieCode);
        }

        public ResponseMessage SaveAWBD(AWBDomainView typePara)
        {
            return AWBManualData.SaveAWBD(typePara);
        }
        public IList<ConsDomainView> GetConsoleList(int GroupID, int Company, int AgencyCode, string ConsoleID)
        {
            return AWBManualData.GetConsoleList(GroupID, Company, AgencyCode, ConsoleID);
        }
        public IList<AWBDomainView> GetAWBList(string AWBCode)
        {
            return AWBManualData.GetAWBList(AWBCode);
        }

        public IList<CommonDomainView> GetUOMist(string UOMCode)
        {
            return AWBManualData.GetUOMist(UOMCode);
        }


        public IList<CommonDomainView> BillChgTo(string Code)
        {
            return AWBManualData.BillChgTo(Code);
        }

        public IList<AWBDomainView> GetAWBMPSList(string AWBNo, string ConsID, string ExpressID)
        {
            return AWBManualData.GetAWBMPSList(AWBNo, ConsID, ExpressID);
        }

        public ResponseMessage DeleteAWBD(AWBDomainView typePara)
        {
            return AWBManualData.DeleteAWBD(typePara);
        }


        public IList<RefLocationsDomainView> GetLocationList(string Country, string AgnLocation)
        {
            return AWBManualData.GetLocationList(Country, AgnLocation);
        }


        public IList<CommonDomainView> GetDimVolUOMist(string UomCode)
        {
            return AWBManualData.GetDimVolUOMist(UomCode);
        }


        public IList<AWBDomainView> GetAWBBilledList(string AWBNo)
        {
            return AWBManualData.GetAWBBilledList(AWBNo);
        }




       

    }
}
