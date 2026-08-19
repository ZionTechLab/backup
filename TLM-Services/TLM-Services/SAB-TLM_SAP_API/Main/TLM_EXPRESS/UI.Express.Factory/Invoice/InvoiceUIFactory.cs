using Express.Business.Invoice;
using Express.Data.Invoice;
using Express.Interfaces.Invoice;
using Express.View.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Invoice
{
    public sealed class InvoiceUIFactory
    {
        private  static Dictionary<object, object> servicecontainer = null;
        private InvoiceUIFactory()
        {

        }
        public static T GetService<T>()
        {
            #region inject services

            if(servicecontainer !=null)
            {
                servicecontainer.Clear();
                
            }
            
            //if (servicecontainer == null)
            //{
                servicecontainer = new Dictionary<object, object>();                
                servicecontainer.Add(typeof(IClrInvPrinting), new ClrInvPrintingBusiness(new ClrInvPrintingData()));
                servicecontainer.Add(typeof(IClrInvOpsInvoiceChg), new ClrInvOpsInvoiceChgBusiness(new ClrInvOpsInvoiceChgData()));
                servicecontainer.Add(typeof(IClrInvOpsRouteChg), new ClrInvOpsRouteChgBusiness(new ClrInvOpsRouteChgData()));
                servicecontainer.Add(typeof(IInvDutyProvider<InvDutyDomainView>), new InvDutyBusiness(new InvDutyData("Duty Invoice")));
                servicecontainer.Add(typeof(IDutyBulkInvoiceProvider), new InvoiceDutyBulkBusiness(new InvDutyBulkData()));
            //}

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
