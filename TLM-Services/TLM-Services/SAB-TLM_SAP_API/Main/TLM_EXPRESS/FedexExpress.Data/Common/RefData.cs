using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.View.Domain.AdminConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.Common
{
    public sealed class RefData
    {
        private RefData()
        {

        }

        /// <summary>
        /// Console Type
        /// </summary>
        /// <returns></returns>
        internal static IList<ConsoleTypeDomainView> GetConsoleType(string status)
        {
            try
            {
                using (IExpressUnitOfWork<ConsoleTypeResult> uof = new ExpressUnitOfWork<ConsoleTypeResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@actrive", status) };
                    var GatewayList = (from CSR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetConsoleType]", paraList)
                                       select new ConsoleTypeDomainView
                                       {
                                           ConsoleT  = CSR.ConsoleT,
                                           ConsoleTypeN = CSR.ConsoleTypeN ,
                                           Remark = CSR.Remark

                                       }).ToList();

                    return GatewayList;
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

        /// <summary>
        /// Get Root from Service roots
        /// </summary>
        /// <returns></returns>
        internal static IList<RouteDomainView> GetRoots(int companyID)
        {
            try
            {
                using (IExpressUnitOfWork<RefSvcRootsResult> uof = new ExpressUnitOfWork<RefSvcRootsResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CompanyID", companyID) };
                    var GatewayList = (from CSR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetRoots]", paraList)
                                       select new RouteDomainView
                                       {
                                           RouteID = CSR.SvcRootID,
                                           RouteN = CSR.SvcRootName

                                       }).ToList();

                    return GatewayList;
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


        /// <summary>
        /// Get Station from ref location
        /// </summary>
        /// <returns></returns>
        internal static IList<StationDomainView> GetStation(int companyID)
        {
            try
            {
                using (IExpressUnitOfWork<RefLocationsResult> uof = new ExpressUnitOfWork<RefLocationsResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CompanyID", companyID) };
                    var GatewayList = (from CSR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetLocationStations]", paraList)
                                       select new StationDomainView
                                       {
                                           StationID = CSR.LocationID,
                                           StationN = CSR.LocationName

                                       }).ToList();

                    return GatewayList;
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


        /// <summary>
        /// Get Gateway from ref location
        /// </summary>
        /// <returns></returns>
        internal static IList<GatewaysDomainView> GetGateways(int companyID)
        {
            try
            {
                using (IExpressUnitOfWork<CfgGatewayResult> uof = new ExpressUnitOfWork<CfgGatewayResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CompanyID", companyID) };
                    var GatewayList = (from CSR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetLocationGateway]", paraList)
                                       select new GatewaysDomainView
                                       {
                                           GatewayID = CSR.LocationID,
                                           GatewayN = CSR.LocationName

                                       }).ToList();

                    return GatewayList;
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
    }
}
