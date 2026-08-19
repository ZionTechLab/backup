using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Domain.SCS
{
	public class CustomerOutstanding
	{
		public string customerID { get; set; }
		public int TransactionType { get; set; }
		public string transactionCode { get; set; }	
		public string transactionRemark { get; set; }
		public DateTime transactionDate { get; set; }
		public decimal TotalAmount { get; set; }
		public decimal Amount { get; set; }
		public bool IsChequeInHand { get; set; }
		public bool isCredit { get; set; }
        public int age { get; set; }
    }
}