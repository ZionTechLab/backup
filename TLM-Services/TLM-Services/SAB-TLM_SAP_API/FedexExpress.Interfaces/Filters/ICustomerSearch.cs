using Express.Interfaces.Common;
using Express.View.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Filters
{
    public interface ICustomerSearch<T> : IDataAccess<RefOrganizationDomainView> where T : class
    {
        List<RefOrganizationDomainView> GetRefOrganizationRegular(OrgSearchParamDomainView _param);
        List<RefOrganizationDomainView> GetRefOrganizationOneTime(OrgSearchParamDomainView _param);
    }
}
