using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report.Excel_DataTable
{
    class cls_sasPendingOrders_DTO
    {
        public DateTime CODate { get; set; }
        public string CONo { get; set; }
        public string CustomerName { get; set; }
        public string Branch { get; set; }

        public string CustomerType { get; set; }
        public string CustomerCategory { get; set; }
        public string SalesRep { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }

        public decimal COQty { get; set; }
        public decimal DOQty { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetPrice { get; set; }

        public DateTime DeliveryDate { get; set; }

        public cls_sasPendingOrders_DTO(DateTime _CODate, string _CO_No, string _CustomerName, string _Branch, string _CustomerType, string _CustomerCategory,
            string _SalesRep, string _ItemCode, string _ItemDescription, decimal _COQty, decimal _DOQty, decimal _SellingPrice, decimal _DiscountPercentage, decimal _DiscountAmount, DateTime _DeliveryDate, decimal _NetPrice)
        {
            CODate = _CODate;
            CONo = _CO_No;
            CustomerName = _CustomerName;
            Branch = _Branch;
            CustomerType = _CustomerType;
            CustomerCategory = _CustomerCategory;
            SalesRep = _SalesRep;
            ItemCode = _ItemCode;
            ItemDescription = _ItemDescription;
            COQty = _COQty;
            DOQty = _DOQty;
            SellingPrice = _SellingPrice;
            DiscountPercentage = _DiscountPercentage;
            DiscountAmount = _DiscountAmount;
            DeliveryDate = _DeliveryDate;
            NetPrice = _NetPrice;
        }

        public cls_sasPendingOrders_DTO()
        {

        }
    }
}
