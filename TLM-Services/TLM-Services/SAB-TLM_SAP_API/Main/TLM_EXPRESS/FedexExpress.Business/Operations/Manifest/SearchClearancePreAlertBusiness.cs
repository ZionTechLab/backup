using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;

namespace Express.Business.Operations.Manifest
{
    public class SearchClearancePreAlertBusiness : ISearchClearancePreAlert<ClearancePreAlertDomainView>
    {
        ISearchClearancePreAlert<ClearancePreAlertDomainView> Serch = null;

        public SearchClearancePreAlertBusiness(ISearchClearancePreAlert<ClearancePreAlertDomainView> _Serch)
        {
            this.Serch = _Serch;
        }
        public ResponseMessage DeleteDetail(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<ClearancePreAlertDomainView> GetSerchResult(int GroupId, int CMPY, int AgencyId, string Console, string MAWB, string ConsoleNo)
        {
            return Serch.GetSerchResult(GroupId, CMPY, AgencyId, Console, MAWB, ConsoleNo);
        }

        public ResponseMessage SaveDetails(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
