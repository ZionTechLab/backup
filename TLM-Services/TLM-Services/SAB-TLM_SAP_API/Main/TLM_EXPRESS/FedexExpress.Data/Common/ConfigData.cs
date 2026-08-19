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
   public sealed class ConfigData
    {
        private ConfigData()
        {

        }
        /// <summary>
        /// Get Clearence Status 
        /// </summary>
        /// <returns></returns>
        internal static IList<ClearenceStatusDomainView> GetClearenceStatus()
        {
            try
            {
                using (IExpressUnitOfWork<ClearenceStatusResult> uof = new ExpressUnitOfWork<ClearenceStatusResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@statusCode", 1) };
                    var GatewayList = (from CSR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearenceStatus]", paraList)
                                       select new ClearenceStatusDomainView
                                       {
                                          ClearStatusID = CSR.ClearStatusID ,
                                          ClearStatusN = CSR.ClearStatusN 

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


        internal static IList<ClearenceTypeDomainView> GetClearenceType()
        {
            try
            {
                using (IExpressUnitOfWork<ClearenceTypeResult> uof = new ExpressUnitOfWork<ClearenceTypeResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ShipCate", 1) };
                    var GatewayList = (from CSR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearenceType]", paraList)
                                       select new ClearenceTypeDomainView
                                       {
                                           ShipValType = CSR.ShipValType,                                           

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



    }
}
