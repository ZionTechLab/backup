using Express.Interfaces.Common;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations
{
   public interface IPrincipleAccounts<T> : IDataAccess<T> where T : class
    {
        IList<PrincipleAccountsView> GetPrincipleAccountGrid(int Agency,int OrgCode,string AccountNo);

        IList<PrincipleAccountsView> DeleteData(string AccountNo);

        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
    }
}
