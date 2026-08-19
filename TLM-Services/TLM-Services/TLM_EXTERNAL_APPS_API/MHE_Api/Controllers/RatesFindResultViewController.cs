using System.Collections.Generic;
using System.Web.Http;
using MHE_Api.DAL;
using MHE_Api.Models;


namespace MHE_Api.Controllers
{
    public class RatesFindResultViewController : ApiController
    {
        private IRateData _RateData;
        public RatesFindResultViewController()
        {
            _RateData = new RateData();
        }

        [Route("GetRates")]
        [HttpPost]
        [Authorize]
        public RatesFindResultView Post([FromBody]RatesFind_Parameters obj)
        {

            // Log log = new Log();
            // log.RaiseException();
            return _RateData.GetRates(obj);
        }
        [Route("GetCreditInfo")]
        [HttpPost]
        [Authorize]
        public CreditInfoResultView GetcreditInfo([FromBody]CreditPara obj )
        {

            // Log log = new Log();
            // log.RaiseException();
            return _RateData.GetCreditInfo(obj.Mount_Code);
        }

        [Route("get_previous_month_potential_revenue_and_weight")]
        [HttpPost]
        [Authorize]
        public List<dynamic> GetPrevRevWgt([FromBody]IList<ESMRevWGTReqTypeDomainView> obj)
        {

            // Log log = new Log();
            // log.RaiseException();
            return _RateData.GetESMRevWgt(obj);
        }

        [Route("get_customer_list")]
        [HttpPost]
        [Authorize]
        public List<dynamic> get_customer_list(UpdatedOnly upd)
        {

            // Log log = new Log();
            // log.RaiseException();
            return _RateData.get_customer_list( upd);
        }

        [Route("get_customer_credit")]
        [HttpPost]
        [Authorize]
        public List<CustCredRateInfo> get_customer_credit(CustPara Org)
        {

            // Log log = new Log();
            // log.RaiseException();
            var cust = _RateData.get_customer_credit(Org);
            var rates = _RateData.get_customer_rates(Org);

            cust[0].Tariffs = rates;

            return cust;

        }
    }
}



   