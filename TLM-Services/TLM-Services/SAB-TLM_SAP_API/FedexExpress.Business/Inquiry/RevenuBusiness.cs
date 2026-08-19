using Express.Interfaces.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using Express.View.Domain.Inquiry;

namespace Express.Business.Inquiry
{
    public class RevenuBusiness :IRevenuRepo
    {
        private readonly IRevenuRepo _reveRepo;
        public RevenuBusiness(IRevenuRepo _reveRepo)
        {
            this._reveRepo = _reveRepo;
        }
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _reveRepo.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<RevenuDomainView > GetRevenu(RevenuPramDomainView _para)
        {
            return _reveRepo.GetRevenu(_para);
        }

        public IList<SalesAreaDomainView> GetSalesArea(int companyID, int agencyID)
        {
            return _reveRepo.GetSalesArea(companyID, agencyID);
        }
    }
}
