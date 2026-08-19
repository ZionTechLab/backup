using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.BSS;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.BSS
{
   public  class ChequeData
    {
        public ResponseMessage Save_DebitNoteForRC(ReturnedCheque Parm)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Txn_ID", Parm.Txn_ID);
                    para.Add("@Txn_Date", Parm.Txn_Date);
                    para.Add("@Customer_ID", Parm.Customer_ID);
                    para.Add("@employee_ID", Parm.employee_ID);
                    para.Add("@OrderRefNo_ID", Parm.OrderRefNo_ID);
                    para.Add("@ChequeRegister_ID", Parm.ChequeRegister_ID);
                    para.Add("@CurrencyCode", Parm.CurrencyCode);
                    para.Add("@FinancialYearID", Parm.FinancialYearID);
                    para.Add("@SalesNoteType_ID", Parm.SalesNoteType_ID);
                    para.Add("@Amount", Parm.Amount);
                    para.Add("@UserID", Parm.UserID);
                    para.Add("@TerminalID", Parm.TerminalID);
                    para.Add("@CompanyID", Parm.CompanyID);
                    para.Add("@CompanyBranch_ID", Parm.CompanyBranch_ID);
                    para.Add("@chequeStatus_ID", Parm.chequeStatus_ID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Save_DebitNoteForRC]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public List<dynamic> Get_ReturnedCheques()
        {
            var lists = new List<dynamic>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
             //   para.Add("@invoice_ID", invoice_ID);

                lists = db.Query<dynamic>("[dbo].[sp_Get_ReturnedCheques]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public ResponseMessage Save_RepresentableDate(string chequeRegister_ID, DateTime date_Representable, string Remarks_Representable)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@chequeRegister_ID", chequeRegister_ID);
                    para.Add("@date_Representable", date_Representable);
                    para.Add("@Remarks_Representable", Remarks_Representable);
                  
                    x = db.Query<ResponseMessage>("[dbo].[sp_Save_RepresentableDate]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }
        public ResponseMessage Save_ReturnedCheques(List<tmptbl_ChqReconcilation> Parm, string Remarks, DateTime date_Representable, string UserID, string TerminalID, string companyID, string companyBranch_ID)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Detail", cast.ToDataTables(Parm).AsTableValuedParameter("tmptbl_ChqReconcilation"));
                    para.Add("@Remarks", Remarks);
                    para.Add("@dateReconciliation", date_Representable);
                    para.Add("@UserID", UserID);
                    para.Add("@TerminalID", TerminalID);
                    para.Add("@companyID", companyID);
                    para.Add("@companyBranch_ID", companyBranch_ID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Save_ReturnedCheques]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
