using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class PaymentStatusRequest
    {
        public string AWBNo { get; set; }
        public long InvoiceNo { get; set; }     
        public string FedExID { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string PaymentTrxID { get; set; }
        public string DeliveryDate { get; set; }
    }

    public class PaymentStatusResponse
    {     
        public long InvoiceNo { get; set; }
        public long TransactionId { get; set; }
        public string Message { get; set; }
    }
}