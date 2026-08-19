using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.ACC
{
  public   class AccountsMasterData
    {
        public List<dynamic> Get_GlAccounts()
        {
            var lists = new List<dynamic>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                lists = db.Query<dynamic>("[dbo].[sp_Get_GlAccounts]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
    }
}
