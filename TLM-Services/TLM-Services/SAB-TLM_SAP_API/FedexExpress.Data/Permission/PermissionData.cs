using Express.Interfaces.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Permission;
using System.Data;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF;
using Dapper;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Permission
{
    public class PermissionData : IPermissionRepository
    {
        public PermissionDomainView GetButtonPermission(PermissionParaDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@companyID", _para.CompanyID );
                    para.Add("@userID", _para.UserID);
                    para.Add("@mouduleID", _para.ModuleCode );
                    para.Add("@menuID", _para.MenuCode);
                    // return   (PermissionDomainView)conn.Query<PermissionDomainView>("[Project].[TLM_CheckUserPermission]", para, commandType: CommandType.StoredProcedure);
                    var values = (IList<PermissionDomainView>)conn.Query<PermissionDomainView>("[Project].[TLM_CheckUserPermission]", para, commandType: CommandType.StoredProcedure).ToList();
                    return values.FirstOrDefault();
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
