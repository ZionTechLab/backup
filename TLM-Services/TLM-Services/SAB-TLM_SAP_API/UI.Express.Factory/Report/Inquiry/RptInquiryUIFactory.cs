using Express.Interfaces.Report.Inquiry;
using Express.Report.Inquiry.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Report.Inquiry
{
    public class RptInquiryUIFactory
    {
        public static Dictionary<object, object> servicecontainer = null;
        public RptInquiryUIFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IInquiryReportProvider), new InquiryReport());

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
