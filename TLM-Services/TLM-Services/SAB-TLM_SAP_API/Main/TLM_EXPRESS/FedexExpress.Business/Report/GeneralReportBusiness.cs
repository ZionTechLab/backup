using Express.Interfaces.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Report.General;

namespace Express.Business.Report
{
    public class GeneralReportBusiness : IGeneralReport
    {
        private readonly IGeneralReport _generalRpt;
        public GeneralReportBusiness(IGeneralReport _generalRpt)
        {
            this._generalRpt = _generalRpt;
        }
        public IList<CompanyReportDomainView> GetCompany( int companyID)
        {
            return _generalRpt.GetCompany( companyID);
        }
    }
}
