using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report
{
    public class cls_sasSalesReportDetail_InvoiceItemWise_DTO
    {
        public string TxType { get; set; }
        public string Branch { get; set; }
        public string Tx_ID { get; set; }
        public DateTime TxDate { get; set; }
        public string SalesRep { get; set; }
        public string Customer { get; set; }
        public string CustomerClass { get; set; }
        public string CustomerType { get; set; }
        public string CustomerCategory { get; set; }
        public string Item_ID { get; set; }
        public string ItemName { get; set; }

        public decimal SellingPrice { get; set; }
        public decimal TotalQty { get; set; }
        public decimal ItemTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }

        public decimal NBTAmount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal SVATAmount { get; set; }

        public bool IsReturnedPOS_Invoice { get; set; }
    }
}
