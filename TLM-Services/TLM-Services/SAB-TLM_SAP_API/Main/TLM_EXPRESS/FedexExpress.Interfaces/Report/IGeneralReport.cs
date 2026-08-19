using Express.View.Domain.Report.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report
{
    public interface IGeneralReport
    {
        IList<CompanyReportDomainView> GetCompany( int companyID);
    }
}
