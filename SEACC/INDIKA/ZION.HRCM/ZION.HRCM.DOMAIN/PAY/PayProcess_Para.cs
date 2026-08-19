using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZION.HRCM.DOMAIN.PAY
{
	public class PayProcess_Para
	{
		public string processGroup_ID { get; set; }
		public int processPeriod_ID { get; set; }
		public int processPeriod_Sub_ID { get; set; }
		public string company_ID { get; set; }
		public string companyBranch_ID { get; set; }
		public string User_ID { get; set; }
		public string Terminal_ID { get; set; }

	}
}