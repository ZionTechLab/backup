using System.Collections.Generic;
using MHE_Api.Models;

namespace MHE_Api.DAL
{
    public interface IRateData
    {
        RatesFindResultView GetRates(RatesFind_Parameters _Para);
        CreditInfoResultView GetCreditInfo(int Mount_Code);

        List<dynamic> GetESMRevWgt(IList<ESMRevWGTReqTypeDomainView> _data);
        List<dynamic> get_customer_list(UpdatedOnly upd);
        List<CustCredRateInfo> get_customer_credit(CustPara Org);
        List<dynamic> get_customer_rates(CustPara Org);
    }
}