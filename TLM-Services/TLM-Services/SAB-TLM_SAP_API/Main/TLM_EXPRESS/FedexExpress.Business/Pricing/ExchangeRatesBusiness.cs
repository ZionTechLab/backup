
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.AdminConfiguration;
using Express.Interfaces.Pricing;
using Express.View.Domain.Pricing;
using Express.View.Domain.Operations.Manifest;

namespace Express.Business.Pricing
{
    public class ExchangeRatesBusiness : IExchangeRatesDataProvider<ExchangeRatesView>
    {
        private IExchangeRatesDataProvider<ExchangeRatesView> ExchageRateBisDataProvider;

        public ExchangeRatesBusiness(IExchangeRatesDataProvider<ExchangeRatesView> ExchangeRateType)
        {
            this.ExchageRateBisDataProvider = ExchangeRateType;
        }
       
        public ResponseMessage DeleteDetail(ExchangeRatesView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ExchangeRatesView typePara)
        {
            return ExchageRateBisDataProvider.EditDetails(typePara);
        }

        public List<ExchangeRatesView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ExchangeRatesView> GetDetails(ExchangeRatesView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ExchangeRatesView> GetDetails(string code)
        {
            return ExchageRateBisDataProvider.GetDetails(code);
        }

        public IList<ExchaneRateTarifTypeView> GetExchangeRateTypes(string model)
        {
            return ExchageRateBisDataProvider.GetExchangeRateTypes(model);
        }

        public IList<CurrencyDetailDomainView> GetCurrencyDetail(string para)
        {
            return ExchageRateBisDataProvider.GetCurrencyDetail(para);
        }

        public ResponseMessage SaveDetails(ExchangeRatesView typePara)
        {
            return ExchageRateBisDataProvider.SaveDetails(typePara);
        }

        public IList<ExchangeRatesView> GetExchangeRate(int tarrifNo, string cCurrency)
        {
            return ExchageRateBisDataProvider.GetExchangeRate( tarrifNo,  cCurrency);
        }

        public ManifestClearenceDomainView GetManifestClearenceConf(int companyID)
        {
            return ExchageRateBisDataProvider.GetManifestClearenceConf(companyID);
        }
    }
}
