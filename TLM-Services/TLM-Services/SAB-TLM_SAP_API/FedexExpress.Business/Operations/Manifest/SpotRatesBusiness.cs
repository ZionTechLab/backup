using Express.Interfaces.Pricing;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;

namespace Express.Business.Pricing
{
    public class SpotRatesBusiness : ISpotRates<SpotRatesDomainView>
    {
        private ISpotRates<SpotRatesDomainView> SpotDataProvider;

        public SpotRatesBusiness(ISpotRates<SpotRatesDomainView> _SpotDataProvider)
        {
            this.SpotDataProvider = _SpotDataProvider;
        }
        public ResponseMessage DeleteDetail(SpotRatesDomainView typePara)
        {
            return SpotDataProvider.DeleteDetail(typePara);
        }

        public ResponseMessage EditDetails(SpotRatesDomainView typePara)
        {
            return SpotDataProvider.EditDetails(typePara);
        }

        public IList<SpotRatesAWBDomainView> GetAwbDetails(string AWBNo)
        {
            return SpotDataProvider.GetAwbDetails(AWBNo);
        }

        public List<SpotRatesDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<SpotRatesDomainView> GetDetails(SpotRatesDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<SpotRatesDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<SpotRatesDomainView> GetSpotDataFromAwb(string AWBNo)
        {
            return SpotDataProvider.GetSpotDataFromAwb(AWBNo);
        }

        public IList<SpotRatesDomainView> GetSpotDataFromDateRange(string FDate, string ToDate)
        {
            return SpotDataProvider.GetSpotDataFromDateRange(FDate, ToDate);
        }

        public ResponseMessage SaveDetails(SpotRatesDomainView typePara)
        {
            return SpotDataProvider.SaveDetails(typePara);
        }
    }
}
