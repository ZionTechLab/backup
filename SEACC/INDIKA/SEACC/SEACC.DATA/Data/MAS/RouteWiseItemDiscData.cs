using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.MAS
{
  public   class RouteWiseItemDiscData
    {
        public List<RouteWiseItemDisc_View> GetDetails()
        {
          var lists = new List<RouteWiseItemDisc_View>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
             //   para.Add("@route_ID", route_ID);
                lists = db.Query<RouteWiseItemDisc_View>("[dbo].[sp_Get_AllRouteWiseDiscount]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
      
        public decimal GetDiscount(int route_ID)
        {
            decimal ret = 0;
          //  var lists = new List<RouteWiseItemDisc_View>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@route_ID", route_ID);
                ret = db.Query<decimal>("[dbo].[sp_Get_RouteWiseDiscount]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }

        public ResponseMessage SaveDetails(List<RouteWiseItemDisc_Save> param, string createUser_ID, string createTerminal_ID, DateTime dateCreate)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Hed", cast.ToDataTables(param).AsTableValuedParameter("dbo.Tmptbl_RouteWiseDisc"));
                    para.Add("@createUser_ID", createUser_ID);
                    para.Add("@createTerminal_ID", createTerminal_ID);
                    para.Add("@dateCreate", dateCreate);
                    x = db.Query<ResponseMessage>("[dbo].[sp_saveRouteWiseDiscount]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
