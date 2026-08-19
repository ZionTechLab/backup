using Express.Interfaces.Report.Pricing;
using Express.Report.Pricing.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Report.Pricing
{
  public  class RptPricingUIFactory
    {
        public static Dictionary<object, object> servicecontainer = null;
        public RptPricingUIFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IPricingReport), new PricingReports());

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

