using Express.Interfaces.Common;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Login;

namespace Express.Business.Operations.Manifest
{
    public class ClearancePreAlertBusiness : IClearancePreAlert<ClearancePreAlertDomainView>
    {
        IClearancePreAlert<ClearancePreAlertDomainView> PreAlert = null;
        public ClearancePreAlertBusiness(IClearancePreAlert<ClearancePreAlertDomainView> _PreAlert)
        {
            this.PreAlert = _PreAlert;
        }
        public ResponseMessage DeleteDetail(ClearancePreAlertDomainView typePara)
        {
            return PreAlert.DeleteDetail(typePara);
        }

        public ResponseMessage EditDetails(ClearancePreAlertDomainView typePara)
        {
            return PreAlert.EditDetails(typePara);
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return PreAlert.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public List<ClearancePreAlertDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails(ClearancePreAlertDomainView typePara)
        {
            return PreAlert.GetDetails(typePara);
        }

        public List<ClearancePreAlertDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return PreAlert.GetGateways(CountryID);
        }

        //public IList<ClearancePreAlertDomainView> GetSerchResult(int GroupId, int CMPY, int AgencyId, string Console, string MAWB, string ConsoleNo)
        //{
        //    throw new NotImplementedException();
        //}

        public ResponseMessage SaveDetails(ClearancePreAlertDomainView typePara)
        {
            return PreAlert.SaveDetails(typePara);
        }
    }
}
