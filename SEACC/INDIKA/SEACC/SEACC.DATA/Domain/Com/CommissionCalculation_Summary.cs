using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.Com
{
	public class CommissionCalculation_Summary
	{
		public string collecter_ID { get; set; }
		public string collecterName { get; set; }
		public decimal totalCommishion { get; set; }
		public decimal deductions { get; set; }
		public decimal netCommishion { get; set; }
		public bool isApproved { get; set; }
	}
}
