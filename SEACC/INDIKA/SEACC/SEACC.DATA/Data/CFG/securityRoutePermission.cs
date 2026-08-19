using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.CFG;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.CFG
{
   public  class securityRoutePermission
    {
        public ResponseMessage Save(List<tbl_securityRoutePermission> Parm)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                 
                    para.Add("@Detail", cast.ToDataTables(Parm).AsTableValuedParameter("dbo.Tmptbl_securityRoutePermission"));
                    x = db.Query<ResponseMessage>("[dbo].[sp_save_securityRoutePermission]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }
    }
}
