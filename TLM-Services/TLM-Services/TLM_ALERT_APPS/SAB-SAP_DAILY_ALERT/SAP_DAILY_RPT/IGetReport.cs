using System;
using System.Collections.Generic;
using System.Text;

namespace SAP_DAILY_RPT
{
    interface IGetReport
    {		
		List<dynamic> GetSuccessList(string Doctypes);	
		List<dynamic> GetFailedList(string Doctypes);		
		List<dynamic> GetPendingList(string Doctypes);		
		List<dynamic> GetAsAtDateFailedList(string Doctypes);		
		List<dynamic> GetSummaryBody(string Doctypes);
	}
}
