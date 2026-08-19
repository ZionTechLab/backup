using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SAS
{
   public class tbl_sasDeliveryOrder
    {
		public string deliveryOrder_ID{ get; set; }
		public DateTime deliveryOrderDate{ get; set; }
		public string remark{ get; set; }
		public string deliveryAddress{ get; set; }
		public string vehicle_No{ get; set; }
		public DateTime dateIn{ get; set; }
		public DateTime dateOut{ get; set; }
		public DateTime customerDeliveryDate{ get; set; }
		public string receiptBy{ get; set; }
		public string customer_ID{ get; set; }
		public string customerOrder_ID{ get; set; }
		public string quotation_ID{ get; set; }
		public string job_ID{ get; set; }
		public string driver_ID{ get; set; }
		public string vehicle_ID{ get; set; }
		public string assitant_ID{ get; set; }
		public string store_ID{ get; set; }
		public string employee_ID{ get; set; }
		public string orderRefNo_ID{ get; set; }
		public string currency_ID{ get; set; }
		public string salesNoteType_ID{ get; set; }
		public decimal currencyRate{ get; set; }
		public decimal discountPercentage{ get; set; }
		public decimal nbtPercentage{ get; set; }
		public decimal vatPercentage{ get; set; }
		public decimal otherTaxPercentage{ get; set; }
		public decimal subTotal{ get; set; }
		public decimal discountTotal{ get; set; }
		public decimal nbtTotal{ get; set; }
		public decimal vatTotal{ get; set; }
		public decimal otherTaxTotal{ get; set; }
		public decimal grandTotal{ get; set; }
		public bool isWeightCalculation{ get; set; }
		public bool isTaxReverseCalulation{ get; set; }
		public bool isFreeOrder{ get; set; }
		public bool isVAT{ get; set; }
		public bool isSVAT{ get; set; }
		public string batchNo{ get; set; }
		public string branch_ID{ get; set; }
		public bool isReplacementOrder{ get; set; }
		public string itemPriceCategory{ get; set; }
		public string companyID{ get; set; }
		public string companyBranch_ID{ get; set; }
		public int route_ID{ get; set; }
    }
}
