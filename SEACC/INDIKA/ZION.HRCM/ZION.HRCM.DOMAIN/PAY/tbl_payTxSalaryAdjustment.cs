using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZION.HRCM.DOMAIN.PAY
{
	public class tbl_payTxSalaryAdjustment
	{
		public string company_ID { get; set; }
		public string companyBranch_ID { get; set; }
		public string processGroup_ID { get; set; }
		public int processPeriod_ID { get; set; }
		public int processPeriod_Sub_ID { get; set; }
		public string employee_ID { get; set; }
		public decimal amountAdvance { get; set; }
		public decimal amountLoan { get; set; }
		public decimal amountAdjustment { get; set; }
		public decimal amountTelephone { get; set; }
	}
}