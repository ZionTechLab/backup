using Dapper;
using SEACC.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.CFG
{
   public  class UserData
    {
        public ResponseMessage GetTheme_ID(string User_ID)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@User_ID", User_ID);

                    x = db.Query<ResponseMessage>("[dbo].[sp_Get_Theme_ID]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage Save_Theme_ID(string User_ID,int theme_ID)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@User_ID", User_ID);
                    para.Add("@theme_ID", theme_ID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Theme_ID]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
