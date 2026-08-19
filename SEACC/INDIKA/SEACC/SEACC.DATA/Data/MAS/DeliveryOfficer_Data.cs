using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.MAS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.MAS
{
    public class DeliveryOfficer_Data
    {
        public List<tbl_zDeliveryOfficer> GetDetails()
        {
            var lists = new List<tbl_zDeliveryOfficer>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                // para.Add("@Customer_ID", Customer_ID);
                lists = db.Query<tbl_zDeliveryOfficer>("[dbo].[sp_Get_DeliveryOfficer]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
        public ResponseMessage Delete(string DeliveryOfficer_ID)
        {
            ResponseMessage ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@DeliveryOfficer_ID", DeliveryOfficer_ID);

                ret = db.Query<ResponseMessage>("[dbo].[sp_Delete_DeliveryOfficer]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }
        public ResponseMessage Save(string DeliveryOfficer_ID, string DeliveryOfficerName, bool isUpdate)
        {
            ResponseMessage ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@DeliveryOfficer_ID", DeliveryOfficer_ID);
                para.Add("@DeliveryOfficerName", DeliveryOfficerName);
                para.Add("@isUpdate", isUpdate);
                ret = db.Query<ResponseMessage>("[dbo].[sp_Save_DeliveryOfficer]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }
    }
}