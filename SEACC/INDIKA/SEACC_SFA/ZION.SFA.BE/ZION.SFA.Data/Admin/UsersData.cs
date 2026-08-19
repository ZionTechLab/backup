using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZION.SFA.Domain.Admin;
using ZION.SFA.Domain.Message;

namespace ZION.SFA.Data.Admin
{
    public class UsersData
    {
        public List<object> Get_Users()
        {
            var lists = new List<object>();
            using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            {
                var para = new DynamicParameters();
                lists = db.Query<object>("[dbo].[sp_Get_Users]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public List<object> Get_SalesMen()
        {
            var lists = new List<object>();
            using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            {
                var para = new DynamicParameters();
                lists = db.Query<object>("[dbo].[sp_Get_SalesMen]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public ResponseMessage Update_User(UserData param)
        {
            var lists = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            {
                var para = new DynamicParameters();
                para.Add("@user_ID", param.user_ID);
                para.Add("@userName", param.userName);
                para.Add("@email", param.email);
                para.Add("@moible", param.moible);
                para.Add("@employee_ID", param.employee_ID);
                para.Add("@password", param.password);
                para.Add("@isActive", param.isActive);  
                para.Add("@userType", param.userType);
        para.Add("@isNewMode", param.isNewMode);
                lists = db.Query<ResponseMessage>("[dbo].[sp_Update_User]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return lists;
        }
    }
}