using Express.Interfaces.Operations;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;

namespace Express.Business.Operations.Manifest
{
    public class PrincipleAccountBusiness : IPrincipleAccounts<PrincipleAccountsView>
    {

        private IPrincipleAccounts<PrincipleAccountsView> principleAccountsDataProvider;

        public PrincipleAccountBusiness(IPrincipleAccounts<PrincipleAccountsView> principleAccounts)
        {
            this.principleAccountsDataProvider = principleAccounts;
        }

        public IList<PrincipleAccountsView> DeleteData(string AccountNo)
        {
            return principleAccountsDataProvider.DeleteData(AccountNo);
        }

        public ResponseMessage DeleteDetail(PrincipleAccountsView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(PrincipleAccountsView typePara)
        {
            return principleAccountsDataProvider.EditDetails(typePara);
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return principleAccountsDataProvider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public List<PrincipleAccountsView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<PrincipleAccountsView> GetDetails(PrincipleAccountsView typePara)
        {
            throw new NotImplementedException();
        }

        public List<PrincipleAccountsView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<PrincipleAccountsView> GetPrincipleAccountGrid(int Agency, int OrgCode, string AccountNo)
        {
            return principleAccountsDataProvider.GetPrincipleAccountGrid(Agency, OrgCode, AccountNo);
        }

        public ResponseMessage SaveDetails(PrincipleAccountsView typePara)
        {
            return principleAccountsDataProvider.SaveDetails(typePara);
        }
    }
}
