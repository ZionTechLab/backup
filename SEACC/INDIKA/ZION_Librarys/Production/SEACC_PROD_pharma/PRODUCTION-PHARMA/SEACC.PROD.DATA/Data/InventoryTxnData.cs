
using Dapper;
using SEACC.PROD.DATA.Domain;
using SEACC.PROD.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SEACC.PROD.DATA.Data.SCS
{
    public class InventoryTxnData
    {
        Dictionary<int, string> dict_SP = new Dictionary<int, string>();

        public InventoryTxnData()
        {
            dict_SP.Add(129, "[dbo].[sp_Update_InventoryTxn_GRN]");
            dict_SP.Add(130, "[dbo].[sp_Update_InventoryTxn_PRN]");
            dict_SP.Add(156, "[dbo].[sp_Update_InventoryTxn_sAdj]");
            dict_SP.Add(176, "[dbo].[sp_Update_InventoryTxn_SRN]");
            dict_SP.Add(7304, "[dbo].[sp_Update_InventoryTxn_PGIN]");
            dict_SP.Add(7309, "[dbo].[sp_Update_InventoryTxn_PFGTN]");
        }

        public ResponseMessage Update_InventoryTxn(int TxnType, string txnID, bool IsUpdate)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@TxnType", TxnType);
                    para.Add("@txnID", txnID);
                    para.Add("@IsUpdate", IsUpdate);
                    para.Add("@IsPostingEnable", true);
                    x = db.Query<ResponseMessage>(dict_SP[TxnType], para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage Update_InventoryTxn(int TxnType, string txnID)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@TxnType", TxnType);
                    para.Add("@txnID", txnID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Update_InventoryTxn]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage Delete_InventoryTxn(int TxnType, string txnID)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@TxnType", TxnType);
                    para.Add("@txnID", txnID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Delete_InventoryTxn]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage validate_ItemArray(List<StringArray> SA)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables(SA).AsTableValuedParameter("dbo.VarcharArray"));
                    x = db.Query<ResponseMessage>("[dbo].[sp_Validate_Ledger_GRN]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage Validate_Ledger_PurchaceAcc(List<StringArray> SA)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Header", cast.ToDataTables(SA).AsTableValuedParameter("dbo.VarcharArray"));
                    x = db.Query<ResponseMessage>("[dbo].[sp_Validate_Ledger_PurchaceAcc]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
