using Express.Business.SAP;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Data.SAP;
using Express.Interfaces.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.SAP
{
    public sealed class SAPFactory
    {
        private static Dictionary<object, object> servicecontainer = null;
        private SAPFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();

                servicecontainer.Add(typeof(ISAPInvoice), new InvoiceHeaderBusiness(new SAPInvoiceData()));

            }

            #endregion
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available.");
            }

        }
    }
}
