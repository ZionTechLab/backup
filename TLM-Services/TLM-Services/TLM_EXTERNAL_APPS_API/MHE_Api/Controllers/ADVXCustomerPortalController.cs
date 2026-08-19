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
    public class ADVXCustomerPortalController : ApiController, IADVXCustomerPortal
    {
        private ADVXCustomerPortalData _Data;

        public ADVXCustomerPortalController()
        {
            _Data = new ADVXCustomerPortalData();
        }

        [Authorize, HttpPost, Route("PortalAccountSummary")]
        public List<object> AccountSummary(object request)
        {
            return _Data.AccountSummary(request);
        }

        [Authorize, HttpPost, Route("PortalAccountSummaryAging")]
        public List<object> AccountSummaryAging(object request)
        {
            return _Data.AccountSummaryAging(request);
        }

        [Authorize, HttpPost, Route("PortalInboundInvoiceData")]
        public List<object> GetInboundInvoiceData(object request)
        {
            return _Data.GetInboundInvoiceData(request);
        }

        [Authorize, HttpPost, Route("PortalGetInvoiceList")]
        public List<object> GetInvoiceList(object request)
        {
            return _Data.GetInvoiceList(request);
        }

        [Authorize, HttpPost, Route("PortalInvoiceDetailsView")]
        public InvoiceDetailsDomainView InvoiceDetailsView(object request)
        {
            return _Data.InvoiceDetailsView(request);
        }

        [Authorize, HttpGet, Route("PortalGetInvoiceListByStatus")]
        public List<object> GetInvoiceListByStatus(string ICPC, string InvoiceType, DateTime fromDate, DateTime toDate, string IsPaid)
        {
            return _Data.GetInvoiceListByStatus(ICPC, InvoiceType ,fromDate,toDate,IsPaid);
        }
    }
}
