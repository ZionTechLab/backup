using Dapper;
using SEACC.DATA.Domain.BSS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.BSS
{
   public  class DebtorOutstandingData
    {
        public List<DebtorOutstanding> GetDetails(string Customer_ID)
        {
            var lists = new List<DebtorOutstanding>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                // var para = new DynamicParameters();
                //   para.Add("@route_ID", route_ID);

                string Quary = "exec[sp_bssCustomerOutstanding] '%%','%%','%%','" + Customer_ID + "','%%','%%','1988-08-23','"+DateTime.Now.AddYears(1).ToString("yyyy-MM-dd")+"',0,0,0";
                lists = db.Query<DebtorOutstanding>(Quary,  commandType: CommandType.Text).ToList();
            }
            return lists;
        }
    }
}
