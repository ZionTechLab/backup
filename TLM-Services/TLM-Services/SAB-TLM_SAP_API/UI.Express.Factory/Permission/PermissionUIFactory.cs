using Express.Business.Permission;
using Express.Data.Permission;
using Express.Interfaces.Permission;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Permission
{
    public sealed class PermissionUIFactory
    {
        private static Dictionary<object, object> servicecontainer = null;
        private  PermissionUIFactory()
        {

        }

        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();              
                servicecontainer.Add(typeof(IPermissionRepository), new PermissionBusiness(new PermissionData()));
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
