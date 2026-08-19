using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.CustomerWisePricing;
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
   public class masCustomerWiseItemPricingData
    {
        public List<masCustomerWiseItemPricing> GetDetails(string Customer_ID)
        {
           var lists = new List<masCustomerWiseItemPricing>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@Customer_ID", Customer_ID);
                lists = db.Query<masCustomerWiseItemPricing>("[dbo].[sp_Get_AllCustomerWiseItemPricing]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
        //public decimal GetRouteWisePrice(string Customer_ID, string item_ID)
        //{
        //    decimal ret = 0;
        //    //  var lists = new List<RouteWiseItemDisc_View>();
        //    using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
        //    {
        //        var para = new DynamicParameters();
        //        para.Add("@Customer_ID", Customer_ID);
        //        para.Add("@item_ID", item_ID);
        //        ret = db.Query<decimal>("[dbo].[sp_Get_RouteWiseItemPrice]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    }
        //    return ret;
        //}

        public decimal GetMaxDiscount(string Customer_ID, string item_ID)
        {
            decimal ret = 0;
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@Customer_ID", Customer_ID);
                para.Add("@item_ID", item_ID);
                ret = db.Query<decimal>("[dbo].[sp_Get_RouteWiseItemDiscount]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }

        public ResponseMessage CheckValidity(string Customer_ID, int Route_ID, string item_ID, decimal Discount)
        {
            ResponseMessage ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@Customer_ID", Customer_ID);
                para.Add("@Route_ID", Route_ID);
                para.Add("@item_ID", item_ID);
                para.Add("@Discount", Discount);
                ret = db.Query<ResponseMessage>("[dbo].[sp_Check_ItemDiscount]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }
        public ResponseMessage SaveDetails(List<masCustomerWiseItemPricing_Save> param, string createUser_ID, string createTerminal_ID, DateTime dateCreate)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Hed", cast.ToDataTables(param).AsTableValuedParameter("dbo.Tmptbl_genItemMaster_CustomerPricing"));
                    para.Add("@createUser_ID", createUser_ID);
                    para.Add("@createTerminal_ID", createTerminal_ID);
                    para.Add("@dateCreate", dateCreate);
                    x = db.Query<ResponseMessage>("[dbo].[sp_saveCustomerWiseItemPricing]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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