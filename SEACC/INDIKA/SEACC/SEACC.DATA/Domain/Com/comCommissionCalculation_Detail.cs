
using System;

namespace SEACC.DATA.Domain.Com
{
    public class comCommissionCalculation_Detail
    {
        public string receipt_ID { get; set; }
        public DateTime receiptDate { get; set; }
        public string invoice_ID { get; set; }
        public DateTime invoiceDate { get; set; }
        public string chequeNumber { get; set; }
        public decimal setteledAmount { get; set; }
        public decimal TotalCommishion { get; set; }
        public int noOfCollecters { get; set; }
        public string dateSlab { get; set; }
        public decimal presentage { get; set; }
        public decimal devidedCommishion { get; set; }
    }
}