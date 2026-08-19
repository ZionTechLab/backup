using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ZION.SFA.Data.Helpers;
using ZION.SFA.Domain.Message;
using ZION.SFA.Domain.SCS;
using System.Linq;

namespace ZION.SFA.Data.SCS
{
 public    class InventoryData
    {
        public ResponseMessage Update_Inventory(List<StoreStock> Para)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables(Para).AsTableValuedParameter("[dbo].[tmptbl_SFA_Inventory]"));
                    x = db.Query<ResponseMessage>("[dbo].[sp_Update_Inventory]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.IsSuccess = false;
                x.varOutMsg = ex.ToString();
            }
            return x;
        }
        public ResponseMessage Login(login_para Param)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@user_id", Param.user_id);
                    para.Add("@password", Param.password);
                    x = db.Query<ResponseMessage>("[dbo].[Validate_Login]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.IsSuccess = false;
                x.varOutMsg = ex.ToString();
            }
            return x;
        }

        public ResponseMessage Update_ItemMaster(List<tbl_genItemMaster> Para)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables(Para).AsTableValuedParameter("[dbo].[tmptbl_genItemMaster]"));
                    x = db.Query<ResponseMessage>("[dbo].[sp_Update_ItemMaster]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.IsSuccess = false;
                x.varOutMsg = ex.ToString();
            }
            return x;
        } 
        public ResponseMessage Update_Masters(MasterData Para)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@Items", cast.ToDataTables(Para.Items).AsTableValuedParameter("[dbo].[tmptbl_genItemMaster]"));
                    para.Add("@Customer", cast.ToDataTables(Para.Customer).AsTableValuedParameter("[dbo].[tmptbl_customer]"));
                    para.Add("@CustomerOutstanding", cast.ToDataTables(Para.CustomerOutstanding).AsTableValuedParameter("[dbo].[tmptbl_customerOutstanding]"));
                    para.Add("@ItemPricing", cast.ToDataTables(Para.ItemPricing).AsTableValuedParameter("[dbo].[tmptbl_ItemPricing]"));
                    x = db.Query<ResponseMessage>("[dbo].[sp_Update_Masters]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.IsSuccess = false;
                x.varOutMsg = ex.ToString();
            }
            return x;
        }  
        
        public ResponseMessage Update_Image(ItemImage Para)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@item_ID", Para.item_ID);
                    para.Add("@imagePath", Para.imagePath);
                    x = db.Query<ResponseMessage>("[dbo].[Update_ItemImage]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.IsSuccess = false;
                x.varOutMsg = ex.ToString();
            }
            return x;
        }
        public string get_Imagepath(string item_ID)
        {
            string x = "";//new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@item_ID", item_ID);
                    x = db.Query<string>("[dbo].[get_Imagepath]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
              //  x.IsSuccess = false;
             //   x.varOutMsg = ex.ToString();
            }
            return x;
        }
        public List<StoreStock> Get_Inventory()
        {
          var lists = new List<StoreStock>();
            using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            {
                var para = new DynamicParameters();
                lists = db.Query<StoreStock>("[dbo].[sp_Get_Inventory]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public initializeResultView initialize(InitPara param)
        {
            var xx = new initializeResultView();

            using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            {
                var para = new DynamicParameters();
                para.Add("@user_id", param.user_id);

                using (var multi = db.QueryMultiple("[dbo].[sp_Initialize]", para, commandType: CommandType.StoredProcedure))
                {
                    // xx.Stock = multi.Read<StoreStock>().ToList();
               
                  //  xx.userType = multi.Read<int>().FirstOrDefault();
                    xx.Items = multi.Read<tbl_genItemMaster>().ToList();
                    xx.Customer = multi.Read<Customer>().ToList();
                    xx.CustomerOutstanding = multi.Read<CustomerOutstanding>().ToList();
                   // xx.SaleHistory = multi.Read<SalesHistory>().ToList();
                   xx.ItemPricing = multi.Read<ItemPricing>().ToList();
                    xx.route = multi.Read<string>().FirstOrDefault();
                }
            }
            return xx;
        }
    }
}
