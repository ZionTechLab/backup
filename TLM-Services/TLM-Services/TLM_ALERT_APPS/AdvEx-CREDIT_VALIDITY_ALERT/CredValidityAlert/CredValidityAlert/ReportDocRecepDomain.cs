using System;
using System.Collections.Generic;
using System.Text;

namespace CredValidityAlert
{
	public class ReportDocRecepDomain
	{
		public string fromemail{get;set;}

		public string fromname { get; set; }

		public string toemail { get; set; }

		public string toname { get; set; }

		public string smtp { get; set; }

		public int port { get; set; }

		public string subject { get; set; }

		public string username { get; set; }

		public string password { get; set; }

		public bool? ssl { get; set; }

		public string header { get; set; }

		public string footer { get; set; }

		public string cc { get; set; }

		public string bcc { get; set; }
		
	}
}
