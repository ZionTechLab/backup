using Express.Business.Inquiry;
using Express.Data.Inquiry;
using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Inquiry
{
    public sealed class InquryUIFacotry
    {
        private static Dictionary<object, object> servicecontainer = null;
        public InquryUIFacotry()
        {

        }

        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IInvoiceSummary<InvoiceSummaryDomainView>), new InvoiceSummaryBusiness(new InvoiceSummaryData()));
                servicecontainer.Add(typeof(IPaymnetSummary<PaymetSummaryDomainView>), new PaymetSummaryBusiness(new PaymetSummaryData()));
                servicecontainer.Add(typeof(INotInvoice<NotInvoiceReportDomainView>), new NotInvoiceBusiness(new NotInvoiceData()));
                servicecontainer.Add(typeof(IShipmentHeld), new ShipmentHeldBusiness(new ShipmentHeldData()));
                servicecontainer.Add(typeof(IDutyOutstanding), new DutyOutStandingBusiness(new DutyOutstandingData()));
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
