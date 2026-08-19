using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.Com;
//using SEACC.DATA.Domain.a;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.Com
{
    public class ComPercentageDefinition_Data
    {
        public ResponseMessage Save(tbl_comCollectorsPercentageDef Parm, bool IsUpdate)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@IsUpdate", IsUpdate);
                    para.Add("@Txn_ID", Parm.p_ID);
                    para.Add("@Collector1_ID", Parm.collector_ID1);
                    para.Add("@Collector2_ID", Parm.collector_ID2);
                    para.Add("@Percentage1", Parm.percentage1);
                    para.Add("@Percentage2", Parm.percentage2);
                    para.Add("@Active", Parm.isActive);
                    para.Add("@User_ID", Parm.user_ID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_save_comPercentageDefinition]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        //public ResponseMessage_Value GetAvailableStore(string Item_Id, decimal Qty)
        //{
        //    var x = new ResponseMessage_Value();
        //    try
        //    {
        //        using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
        //        {
        //            var para = new DynamicParameters();
        //            para.Add("@Item_Id", Item_Id);
        //            para.Add("@Qty", Qty);

        //            x = db.Query<ResponseMessage_Value>("[dbo].[sp_Get_AvailableStore]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        x.OutMsg = ex.Message;
        //    }
        //    return x;
        //}

        public List<tbl_comCollectorsPercentageDef> SelectAll()
        {
            var lists = new List<tbl_comCollectorsPercentageDef>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                //var para = new DynamicParameters();
                //para.Add("@deliveryOrder_ID", deliveryOrder_ID);
                lists = db.Query<tbl_comCollectorsPercentageDef>("[dbo].[sp_Get_CollectorPercentage]", commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public List<tbl_comCollectorsPercentageDef> SelectAllBy_Collecor_ID(int pID, string collector1_ID, string collector2_ID)
        {
            var lists = new List<tbl_comCollectorsPercentageDef>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@p_ID", pID);
                para.Add("@collector1_ID", collector1_ID);
                para.Add("@collector2_ID", collector2_ID);
                lists = db.Query<tbl_comCollectorsPercentageDef>("[dbo].[sp_Get_CollectorPercentage_By_Collector_ID]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
    }
}
