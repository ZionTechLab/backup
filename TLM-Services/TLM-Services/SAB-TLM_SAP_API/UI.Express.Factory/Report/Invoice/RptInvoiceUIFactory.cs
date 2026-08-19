using Express.Interfaces.Report.Invoice;
using Express.Report.Invoice.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Report.Invoice
{
    public class RptInvoiceUIFactory
    {
        public static Dictionary<object, object> servicecontainer = null;
        public RptInvoiceUIFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IInvoiceReportProvider), new InvoiceReport());
                
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
