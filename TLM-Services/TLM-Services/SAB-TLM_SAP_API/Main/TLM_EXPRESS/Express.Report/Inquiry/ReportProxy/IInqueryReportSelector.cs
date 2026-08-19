using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Report.Inquiry.ReportProxy
{
   public interface IInqueryReportSelector
    {
        ReportDocument InqueryReportLocator(string _key);
    }
}
