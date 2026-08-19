using MHE_Api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MHE_Api.Models;

namespace MHE_Api.Controllers
{
    public class SABMobileAppController : ApiController, ISABMobileApp
    {
        private SABMobileAppData _Data;

        public SABMobileAppController()
        {
            _Data = new SABMobileAppData();
        }

        [Authorize, HttpPost, Route("GetInvoiceInformation")]
        public IList<InvoiceInformation> GetInvoiceInformation(InvoiceRequest request)
        {
            return _Data.GetInvoiceInformation(request);
        }

        [Authorize, HttpPost, Route("SAB/GetInvoiceInformationByDate")]
        public IList<object> GetInvoiceInformationByDate(InvoiceRequestDates request)
        {
            return _Data.GetInvoiceInformationByDate(request);
        }

        [Authorize, HttpPost, Route("SAB/GetInvoicePDF")]
        public IList<InvoicePDFView> GetInvoicePDF(InvoiceRequest request)
        {
            return _Data.GetInvoicePDF(request);
        }



        [Authorize, HttpPost, Route("SAB/UpdatePaymentStatus")]
        public PaymentStatusResponse UpdatePaymentStatus(PaymentStatusRequest request)
        {
            return _Data.UpdatePaymentStatus(request);
        }
    }
}
