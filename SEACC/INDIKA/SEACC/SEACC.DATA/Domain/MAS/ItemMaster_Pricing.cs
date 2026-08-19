using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.MAS
{
    public class ItemMaster_Pricing
	{
		public string item_ID { get; set; }
		public decimal costPrice1 { get; set; }
		public decimal costPrice2 { get; set; }
		public decimal lifoCostPrice { get; set; }
		public decimal fifoCostPrice { get; set; }
		public decimal weightedAverageCostPrice { get; set; }
		public decimal highestPurchaseCostPrice { get; set; }
		public decimal lowestPurchaseCostPrice { get; set; }
		public decimal sellingPrice1 { get; set; }
		public decimal sellingPrice2 { get; set; }
		public decimal sellingPrice3 { get; set; }
		public decimal sellingPrice4 { get; set; }
		public decimal sellingPrice5 { get; set; }
		public decimal sellingPrice6 { get; set; }
		public bool isVATinclusive { get; set; }
		public bool isNBTinclusive { get; set; }
		public decimal maxDiscountPct { get; set; }
		public decimal maxDiscountAmt { get; set; }
		public string createUser_ID { get; set; }
		public string createTerminal_ID { get; set; }
	}
}