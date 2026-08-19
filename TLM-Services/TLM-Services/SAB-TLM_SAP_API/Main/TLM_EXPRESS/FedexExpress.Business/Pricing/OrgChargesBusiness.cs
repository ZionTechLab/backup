using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.Pricing
{
    public class OrgChargesBusiness : IOrgCharges<OrgChargesView>
    {
        private IOrgCharges<OrgChargesView> OrgChargesDataProvider;

        public OrgChargesBusiness(IOrgCharges<OrgChargesView> orgCharges)
        {
            this.OrgChargesDataProvider = orgCharges;
        }

        public ResponseMessage DeleteDetail(OrgChargesView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(OrgChargesView typePara)
        {
            return OrgChargesDataProvider.EditDetails(typePara);
        }

        public IList<OrgChargesView> GetAdminChargesGrid(int orgCode)
        {
            return OrgChargesDataProvider.GetAdminChargesGrid(orgCode);
        }

        public List<OrgChargesView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<OrgChargesView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public List<OrgChargesView> GetDetails(OrgChargesView typePara)
        {
            throw new NotImplementedException();
        }
        //***
        public IList<OrgChargesCurrencyView> GetLocalCurrency(string Currency)
        {
            return OrgChargesDataProvider.GetLocalCurrency(Currency);
        }

        public IList<OrgChargesView> GetOrgCharges(string model)
        {
            throw new NotImplementedException();
        }
        //***
        public IList<OrgChargeSalseAreaNameView> GetSalesAreaName(int OrgCode)
        {
            return OrgChargesDataProvider.GetSalesAreaName(OrgCode);
        }

        public ResponseMessage SaveDetails(OrgChargesView typePara)
        {
            return OrgChargesDataProvider.SaveDetails(typePara);
        }
    }
}
