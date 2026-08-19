using Dapper;
using SEACC.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data
{
   public  class RouteLockData
    {
        public ResponseMessage CheckValidity_RouteLock(int Route_ID)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Route_ID", Route_ID);

                    x = db.Query<ResponseMessage>("[dbo].[sp_CheckRouteLockStatus]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
