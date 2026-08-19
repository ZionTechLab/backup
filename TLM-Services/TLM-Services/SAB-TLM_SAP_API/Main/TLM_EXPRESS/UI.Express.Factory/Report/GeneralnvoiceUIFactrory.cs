using Express.Business.Report;
using Express.Data.Report;
using Express.Interfaces.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Report
{
   public  class GeneralnvoiceUIFactrory
    {
        public static Dictionary<object, object> servicecontainer = null;
        public GeneralnvoiceUIFactrory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IGeneralReport), new GeneralReportBusiness(new GeneralReportData()));

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
