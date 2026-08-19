using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.SAS;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.SAS
{
    public class SasDeliveryOrder_data
    {
        public ResponseMessage Save_DO(Para_DeliveryOrder_Save Parm)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables(new List<tbl_sasDeliveryOrder>() { Parm.Header }).AsTableValuedParameter("dbo.Tmptbl_sasDeliveryOrder"));
                    para.Add("@Detail", cast.ToDataTables(Parm.Detail).AsTableValuedParameter("dbo.Tmptbl_sasDeliveryOrder_Detail"));
                    para.Add("@User_ID", Parm.User_ID);
                    para.Add("@Terminal_ID", Parm.Terminal_ID);
                    para.Add("@IsUpdate", Parm.IsUpdate);
                    para.Add("@configForm_ID", Parm.configForm_ID);
                    para.Add("@IsPostingEnable", true);
                    x = db.Query<ResponseMessage>("[dbo].[sp_save_sasDeliveryOrder]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }
        public ResponseMessage Save_AllInDO(Para_DeliveryOrder_Save Parm)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables(new List<tbl_sasDeliveryOrder>() { Parm.Header }).AsTableValuedParameter("dbo.Tmptbl_sasDeliveryOrder"));
                    para.Add("@Detail", cast.ToDataTables(Parm.Detail).AsTableValuedParameter("dbo.Tmptbl_sasDeliveryOrder_Detail"));
                    para.Add("@User_ID", Parm.User_ID);
                    para.Add("@Terminal_ID", Parm.Terminal_ID);
                    para.Add("@IsUpdate", Parm.IsUpdate);
                    para.Add("@configForm_ID", Parm.configForm_ID);
                    para.Add("@IsPostingEnable", true);
                    para.Add("@orderRefNo", Parm.orderRefNo);
                    x = db.Query<ResponseMessage>("[dbo].[sp_save_sasAllInDo]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }
        public ResponseMessage Reverce_BulkPrint(List<StringArray> invList,int Form_ID,string User_ID,string Terminal_ID)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables( invList ).AsTableValuedParameter("dbo.VarcharArray"));
                     para.Add("@Form_ID", Form_ID);
                    para.Add("@User_ID", User_ID);
                    para.Add("@Terminal_ID", Terminal_ID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Reverce_BulkPrint]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }
        public ResponseMessage_Value GetAvailableStore(string Item_Id, decimal Qty)
        {
            var x = new ResponseMessage_Value();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Item_Id", Item_Id);
                    para.Add("@Qty", Qty);

                    x = db.Query<ResponseMessage_Value>("[dbo].[sp_Get_AvailableStore]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }
        public ResponseMessage CheckForUnsettledReturnCheques(string customer_ID)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@customer_ID", customer_ID);

                    x = db.Query<ResponseMessage>("[dbo].[sp_Get_CheckForUnsettledReturnCheques]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage sp_CheckValidity_Order(string customer_ID,decimal InvAmount,decimal OldAmount)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@customer_ID", customer_ID);
                    para.Add("@InvAmount", InvAmount);
                    para.Add("@OldAmount", OldAmount);
                    x = db.Query<ResponseMessage>("[dbo].[sp_CheckValidity_Order]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }



        public List<tbl_sasDeliveryOrder_Detail_View> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID)
        {
            var lists = new List<tbl_sasDeliveryOrder_Detail_View>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@deliveryOrder_ID", deliveryOrder_ID);
                lists = db.Query<tbl_sasDeliveryOrder_Detail_View>("[dbo].[sp_Get_DeliveryOrder_Detail_By_deliveryOrder_ID]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public List<tbl_sasDeliveryOrder> Get_DeliveryOrder_ALL_In_ONE()
        {
            var lists = new List<tbl_sasDeliveryOrder>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
              //  para.Add("@deliveryOrder_ID", deliveryOrder_ID);
                lists = db.Query<tbl_sasDeliveryOrder>("[dbo].[sp_Get_DeliveryOrder_ALL_In_ONE]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
    }
}