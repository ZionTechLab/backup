using Express.Business.Report.Operation;
using Express.Data.Report.Operation;
using Express.Interfaces.Report.Operation;
using Express.Report.Operation.ReportProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Report.Operation
{
    public sealed class RptOperationUIFactory
    {
        public static Dictionary<object, object> servicecontainer = null;
        private  RptOperationUIFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();               
                servicecontainer.Add(typeof(IOperationReportProvider), new OperationReports());

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
