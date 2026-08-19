using Express.Interfaces.Common;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Pricing
{
    public interface ISpotRates<T> : IDataAccess<T> where T : class
    {
        IList<SpotRatesAWBDomainView> GetAwbDetails(string AWBNo);
        IList<SpotRatesDomainView> GetSpotDataFromAwb(string AWBNo);
        IList<SpotRatesDomainView> GetSpotDataFromDateRange(string FDate,string ToDate);
    }
}
