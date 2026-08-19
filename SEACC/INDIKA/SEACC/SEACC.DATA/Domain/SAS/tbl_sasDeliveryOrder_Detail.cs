using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SAS
{
	public class tbl_sasDeliveryOrder_Detail
	{
		public int line_No { get; set; }
		public string deliveryOrder_ID { get; set; }
		public string item_ID { get; set; }
		public string customerOrder_ID { get; set; }
		public string quotation_ID { get; set; }
		public string job_ID { get; set; }
		public string packingUom_ID { get; set; }
		public string carton_No { get; set; }
		public decimal qty { get; set; }
		public decimal weight { get; set; }
		public decimal unitPrice { get; set; }
		public decimal weightPrice { get; set; }
		public bool bIsFreeItem { get; set; }
		public decimal discountPresentage { get; set; }
		public decimal discountAmount { get; set; }
		public decimal tatalAmount { get; set; }
		public string remark { get; set; }
		public bool isWeightCalculation { get; set; }
		public decimal cost_FIFO { get; set; }
		public decimal weightedAvgCost { get; set; }
		public string store_ID { get; set; }
		public string 	uom_ID { get; set; }
	}

	public class tbl_sasDeliveryOrder_Detail_View : tbl_sasDeliveryOrder_Detail
	{
		public string storeName { get; set; }
		public bool isLocked { get; set; }
	}
}
