using Express.Business.Filters;
using Express.Data.Filters;
using Express.Interfaces.Filters;
using Express.View.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Filter
{
    public sealed class SearchFilterUIFactory
    {
        private  static Dictionary<object, object> servicecontainer = null;
        private SearchFilterUIFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();                
                servicecontainer.Add(typeof(ICustomerSearch<RefOrganizationDomainView>), new CustomerSearchBusiness(new CustomerSearchData()));
              
            }

            #endregion
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }
}
