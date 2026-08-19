using Express.Interfaces.Common;

using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Pricing
{
    public interface IExchangeRatesDataProvider<T> : IDataAccess<T> where T : class
    {
        IList<ExchaneRateTarifTypeView> GetExchangeRateTypes(string model);
        IList<CurrencyDetailDomainView> GetCurrencyDetail(string para);
        IList<ExchangeRatesView> GetExchangeRate(int tarrifNo, string cCurrency);
        ManifestClearenceDomainView GetManifestClearenceConf(int companyID);
    }
}
