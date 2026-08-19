using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Operation.OpsHelper.POD
{
    public sealed class PodScanSrvLocator 
    {
        private static Dictionary<object, object> servicecontainer = null;

       // private static Dictionary<object, Type> servicecontainer;
        private static ConstructorInfo constructor;
        private PodScanSrvLocator()
        {

        }
        public static T GetService<T>()
        {
            #region inject services

            servicecontainer = new Dictionary<object, object>();
            servicecontainer.Add(typeof(IPodRetrive), new PodRetrive());
            servicecontainer.Add(typeof(IPodCreate), new PodCreate());


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
