using System;
using System.Collections.Generic;

namespace MHE_Api.Models
{
    //public class BillingInformation
    //{
    //    public string InvoiceNo { get; set; }
    //    public string AccountNo { get; set; }
    //    public string StoreIDNo { get; set; }
    //    public string FedExTaxIDNo { get; set; }
    //    public string InvoiceDate { get; set; }
    //    public string DueDate { get; set; }
    //    public string PaymentStatus { get; set; }
    //    public string BalanceDueUSD { get; set; }
    //    public string BalanceDueLKR { get; set; }
    //}

    //public class ChargeSummary
    //{
    //    public string ChargeCode { get; set; }
    //    public string ChargeDesc { get; set; }
    //    public decimal AmountUSD { get; set; }
    //    public decimal AmountLKR { get; set; }
    //    private string BalanceUSD { get; set;}
    //}
    public class InvoiceDetailsDomainView
    {
        public decimal TotalPaymentsLKR { get; set; }
        public decimal TotalPaymentsUSD { get; set; }
        public decimal TotalBalanceDueLKR { get; set; }
        public decimal TotalBalanceDueUSD { get; set; }
        public object BillingInformation { get; set; }
        public List<object> ChargeSummary { get; set; }
      
    }
    public class InvoiceOutstanding
    {
        public decimal TotalPaymentsLKR { get; set; }
        public decimal TotalPaymentsUSD { get; set; }
        public decimal TotalBalanceDueLKR { get; set; }
        public decimal TotalBalanceDueUSD { get; set; }
    }



    public class InboundInvoiceDetails
    {
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string AWBNo { get; set; }
        public decimal DutyAmount { get; set; }
        public decimal DutyOSAmount { get; set; }
        public DateTime PODDate { get; set; }
    }
}