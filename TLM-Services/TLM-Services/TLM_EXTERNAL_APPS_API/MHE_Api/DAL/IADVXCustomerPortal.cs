using MHE_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHE_Api.DAL
{
    public interface IADVXCustomerPortal
    {
        List<object> AccountSummary(object request);
        List<object> AccountSummaryAging(object request);

        List<object> GetInvoiceList(object request);
        InvoiceDetailsDomainView InvoiceDetailsView(object request);
        List<object> GetInboundInvoiceData(object request);
        List<object> GetInvoiceListByStatus(string ICPC, string InvoiceType, DateTime fromDate, DateTime toDate, string status);
    }
}
