using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class BatchResponse
    {
        public long batch_id { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
    public class ReceiptResponseView
    {
        public BatchResponse batch { get; set; }      
        public List<ReceiptLog> data { get; set; }
    }
    public class ReceiptLog
    {
        public long batch_id { get; set; }
        public string id { get; set; }
        public string tlm_sid { get; set; }
        public string message { get; set; }
    }
    public class ReceiptsDomainView
    {
        public string id { get; set; }
        public string type { get; set; }
        public decimal total_amount { get; set; }
        public string courier_remarks { get; set; }
        public string courier_name { get; set; }
        public string route_no { get; set; }
        public int customer_code { get; set; }
        public string customer_name { get; set; }
        public string invoice { get; set; }
        public decimal paid_amount { get; set; }
        public ReceiptAttributes attributes { get; set; }
        public string supervisor_name { get; set; }
        public long batch_id { get; set; }
        public string awb_number { get; set; }
        public int credit { get; set; }
        public decimal cash_amount { get; set; }
        public decimal cheque_amount { get; set; }
        public string cheque_number { get; set; }
        public string cheque_bank { get; set; }
        public decimal momo_amount { get; set; }
        public string momo_referance { get; set; }
        public string cashire_name { get; set; }
        public string status { get; set; }
        public string collected_date { get; set; }

    }

    public class CollectionBatchHedDomainView
    {
        public string id { get; set; }
        public string type { get; set; }
        public decimal total_amount { get; set; }
        public string courier_remarks { get; set; }
        public string courier_name { get; set; }
        public string route_no { get; set; }
        public int customer_code { get; set; }
        public string customer_name { get; set; }
        public string invoice { get; set; }
        public decimal paid_amount { get; set; }        
        public string supervisor_name { get; set; }
        public long batch_id { get; set; }
        public string awb_number { get; set; }
        public int credit { get; set; }
        public decimal cash_amount { get; set; }
        public decimal cheque_amount { get; set; }
        public string cheque_number { get; set; }
        public string cheque_bank { get; set; }
        public decimal momo_amount { get; set; }
        public string momo_referance { get; set; }
        public string cashire_name { get; set; }
        public string status { get; set; }
        public string collected_date { get; set; }

    }

    public class BatchAttributes
    {
        public string id { get; set; }
        public decimal? freight { get; set; }
        public decimal? handling { get; set; }
        public decimal? insurance { get; set; }
        public decimal? others { get; set; }
    }

    public class BatchUpload
    {
        public List<CollectionBatchHedDomainView> BatchData { get; set; }
        public List<BatchAttributes> Attributes { get; set; }
    }

    public class ReceiptAttributes
    {
        public decimal? freight { get; set; }
        public decimal? handling { get; set; }
        public decimal? insurance { get; set; }
        public decimal? others { get; set; }
    }
}