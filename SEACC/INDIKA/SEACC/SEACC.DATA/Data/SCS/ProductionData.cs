using Dapper;
using SEACC.DATA.Domain.SCS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.SCS
{
   public class ProductionData
    {
        public tbl_genItemMaster get_all_FinishGoods()
        {
            var x = new tbl_genItemMaster();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
    
                 //   x = db.Query<tbl_genItemMaster>(dict_SP[TxnType], para, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
               // x.OutMsg = ex.Message;
            }
            return x;
        }

        public FinishGood get_FinishGood(string item_ID)
        {
            var x = new FinishGood();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@item_ID", item_ID);
                  //  x = db.Query<FinishGood>(dict_SP[TxnType], para, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                // x.OutMsg = ex.Message;
            }
            return x;
        }
    }
}
