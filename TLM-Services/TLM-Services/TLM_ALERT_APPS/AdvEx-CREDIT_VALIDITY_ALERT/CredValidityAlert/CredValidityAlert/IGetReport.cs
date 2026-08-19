using System;
using System.Collections.Generic;
using System.Text;

namespace CredValidityAlert
{
    interface IGetReport
    {		
	
		List<dynamic> GetSummaryBody();
		List<dynamic> GetExpiredList();		
	}
}
