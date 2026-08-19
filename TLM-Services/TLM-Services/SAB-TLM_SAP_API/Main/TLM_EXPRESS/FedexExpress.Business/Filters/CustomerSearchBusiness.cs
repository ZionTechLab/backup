using Express.Interfaces.Filters;
using Express.View.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;

namespace Express.Business.Filters
{
    public class CustomerSearchBusiness : ICustomerSearch<RefOrganizationDomainView>
    {
        ICustomerSearch<RefOrganizationDomainView> CustomerSearch;

        public CustomerSearchBusiness(ICustomerSearch<RefOrganizationDomainView> _CustomerSearch)
        {
            this.CustomerSearch = _CustomerSearch;
        }

        public ResponseMessage DeleteDetail(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetDetails(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetRefOrganizationOneTime(OrgSearchParamDomainView _param)
        {
            return CustomerSearch.GetRefOrganizationOneTime( _param);
        }

        public List<RefOrganizationDomainView> GetRefOrganizationRegular(OrgSearchParamDomainView _param)
        {
            return CustomerSearch.GetRefOrganizationRegular( _param);
        }

        public ResponseMessage SaveDetails(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
