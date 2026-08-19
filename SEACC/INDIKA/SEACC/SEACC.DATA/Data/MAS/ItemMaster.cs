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
    public class ItemMaster
    {
        public ResponseMessage Update(ItemMaster_Pricing param)
        {
            ResponseMessage ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@item_ID", param.item_ID);
                para.Add("@costPrice1", param.costPrice1);
                para.Add("@costPrice2", param.costPrice2);
                para.Add("@lifoCostPrice", param.lifoCostPrice);
                para.Add("@fifoCostPrice", param.fifoCostPrice);
                para.Add("@weightedAverageCostPrice", param.weightedAverageCostPrice);
                para.Add("@highestPurchaseCostPrice", param.highestPurchaseCostPrice);
                para.Add("@lowestPurchaseCostPrice", param.lowestPurchaseCostPrice);
                para.Add("@sellingPrice1", param.sellingPrice1);
                para.Add("@sellingPrice2", param.sellingPrice2);
                para.Add("@sellingPrice3", param.sellingPrice3);
                para.Add("@sellingPrice4", param.sellingPrice4);
                para.Add("@sellingPrice5", param.sellingPrice5);
                para.Add("@sellingPrice6", param.sellingPrice6);
                para.Add("@isVATinclusive", param.isVATinclusive);
                para.Add("@isNBTinclusive", param.isNBTinclusive);
                para.Add("@maxDiscountPct", param.maxDiscountPct);
                para.Add("@maxDiscountAmt", param.maxDiscountAmt);
                para.Add("@createUser_ID", param.maxDiscountAmt);
                para.Add("@createTerminal_ID", param.maxDiscountAmt);
                ret = db.Query<ResponseMessage>("[dbo].[sp_UpdateItemPricing]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }

        public ResponseMessage Update_Route(tbl_genRoute param)
        {
            ResponseMessage ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@RouteID", param.route_ID);
                para.Add("@RouteCode", param.route_Code);
                para.Add("@RouteName", param.routeName);
                para.Add("@IsLocked", param.isLocked);
                para.Add("@SalesManagerID", param.salesManager_ID);
                para.Add("@AreaManagerID", param.areaManager_ID);
                para.Add("@SalesRepID", param.salesRep_ID);
             
                ret = db.Query<ResponseMessage>("[dbo].[sp_Update_Route]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }

        public tbl_genRoute get_route(int route_ID)
        {
            var ret = new tbl_genRoute();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@route_ID", route_ID);
               
                ret = db.Query<tbl_genRoute>("[dbo].[sp_get_route]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }
    }
}