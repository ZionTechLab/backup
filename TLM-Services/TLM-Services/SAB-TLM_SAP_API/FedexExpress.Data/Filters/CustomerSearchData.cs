using Express.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Filters;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Filters
{
    public class CustomerSearchData : ICustomerSearch<RefOrganizationDomainView>
    {
        public ResponseMessage DeleteDetail(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetDetails(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public List<RefOrganizationDomainView> GetRefOrganizationOneTime(OrgSearchParamDomainView _param)
        {
            try
            {
                using (IExpressUnitOfWork<RefOrganizationResult> uof = new ExpressUnitOfWork<RefOrganizationResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                                new SqlParameter("@OrgCode", _param.OrgCode ),
                                  new SqlParameter("@OrgName", ( _param.OrgName ==null) ? "" :_param.OrgName  ),
                                    new SqlParameter("@OrgAddress1", (_param.OrgAdd1==null )? "" :_param.OrgAdd1   ),
                                      new SqlParameter("@OrgAddress2", (_param.OrgAdd1 ==null )? "":_param.OrgAdd1),

                          };
                    var RefOrganizationList = (from Ag in uof.Reposotery.GetDataBySp("[SharedMain].[TLM_GetRefOrganizationOneTime]", paraList)
                                               select new RefOrganizationDomainView
                                               {
                                                   OrgAddr1 = Ag.OrgAddr1,
                                                   OrgAddr2 = Ag.OrgAddr2,
                                                   OrgCity = Ag.OrgCity,
                                                   OrgCode = Ag.OrgCode,
                                                   OrgCountry = Ag.OrgCountry,
                                                   OrgMobile = Ag.OrgMobile,
                                                   OrgName = Ag.OrgName,
                                                   OrgPhone = Ag.OrgPhone,
                                                   OrgCountryN =Ag.OrgCountryN 

                                               }).ToList();

                    return RefOrganizationList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RefOrganizationDomainView> GetRefOrganizationRegular(OrgSearchParamDomainView _param)
        {
            try
            {
                using (IExpressUnitOfWork<RefOrganizationResult> uof = new ExpressUnitOfWork<RefOrganizationResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                               new SqlParameter("@OrgCode", _param.OrgCode ),
                                  new SqlParameter("@OrgName", ( _param.OrgName ==null) ? "" :_param.OrgName  ),
                                    new SqlParameter("@OrgAddress1", (_param.OrgAdd1==null )? "" :_param.OrgAdd1   ),
                                      new SqlParameter("@OrgAddress2", (_param.OrgAdd1 ==null )? "":_param.OrgAdd1),
                          };
                    var RefOrganizationList = (from Ag in uof.Reposotery.GetDataBySp("[SharedMain].[TLM_GetRefOrganizationRegular]", paraList)
                                               select new RefOrganizationDomainView
                                               {
                                                   OrgAddr1 = Ag.OrgAddr1,
                                                   OrgAddr2 = Ag.OrgAddr2,
                                                   OrgCity = Ag.OrgCity,
                                                   OrgCode = Ag.OrgCode,
                                                   OrgCountry = Ag.OrgCountry,
                                                   OrgMobile = Ag.OrgMobile,
                                                   OrgName = Ag.OrgName,
                                                   OrgPhone = Ag.OrgPhone,
                                                   OrgCountryN = Ag.OrgCountryN 

                                               }).ToList();

                    return RefOrganizationList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseMessage SaveDetails(RefOrganizationDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
