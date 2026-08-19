using Express.Interfaces.Common;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Pricing
{
   public interface IOrgCharges<T> : IDataAccess<T> where T : class
    {
        IList<OrgChargesView> GetOrgCharges(string model);
        IList<OrgChargesCurrencyView> GetLocalCurrency(string Currency);
        IList<OrgChargeSalseAreaNameView> GetSalesAreaName(int OrgCode);
        IList<OrgChargesView> GetAdminChargesGrid(int orgCode);

    }
}
