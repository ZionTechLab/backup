using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class InvoiceInformation
    {
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string DocType { get; set; }
        public string AWBNo { get; set; }
        public long InvoiceNo { get; set; }
        public string FedExId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string CourierId { get; set; }
        public string IssuedBy { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string InvoicePDF { get; set; }
        public int? UserId { get; set; }
    }

    public class InvoicePDFView
    {     
        public long InvoiceNo { get; set; }       
        public string InvoicePDF { get; set; }
    }


    public class InvoiceRequest
    {
        public string AWBNo { get; set; }
        public long InvoiceNo { get; set; }
    }

    public class InvoiceRequestDates
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}