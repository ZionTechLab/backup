using Express.Interfaces.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Report.General;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using System.Data.Entity;

namespace Express.Data.Report
{
    public class GeneralReportData : IGeneralReport
    {
        public IList<CompanyReportDomainView> GetCompany( int companyID)
        {
            try
            {
                using (IExpressUnitOfWork<ConCompany> uof = new ExpressUnitOfWork<ConCompany>())
                {

                    return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
                            where ST.Active == "Y"  && ST.CompID == companyID

                            select new CompanyReportDomainView
                            {
                                GroupID = ST.GroupID,
                                CompanyID = ST.CompID,
                                CompanySortName = ST.CompNameSort,
                                CompanyName = ST.CompName,
                                Address1 = ST.Address1,
                                Address2 = ST.Address2,
                                CompanyLogo = ST.Logo,
                                Email = ST.Email,
                                Fax = ST.Fax,
                                Telephone = ST.Telephone,
                                TaxRegNo = ST.TaxRegNo,
                               

                            }).ToList();

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "General Report", updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
