using MHE_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHE_Api.DAL
{
    public interface ISABMobileApp
    {
        IList<InvoiceInformation> GetInvoiceInformation(InvoiceRequest request);
        PaymentStatusResponse UpdatePaymentStatus(PaymentStatusRequest request);
        IList<object> GetInvoiceInformationByDate(InvoiceRequestDates request);
        IList<InvoicePDFView> GetInvoicePDF(InvoiceRequest request);
    }
}
