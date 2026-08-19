using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Inquiry
{
    public interface IRevenuRepo
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<RevenuDomainView> GetRevenu(RevenuPramDomainView _para);
        IList<SalesAreaDomainView> GetSalesArea(int companyID, int agencyID);
    }
}
