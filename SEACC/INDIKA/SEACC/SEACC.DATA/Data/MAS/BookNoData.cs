using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.MAS;
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
   public class BookNoData
    {
        public List<tbl_ZEmpSalesRep> GetUI()
        {
            var xx = new List<tbl_ZEmpSalesRep>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                using (var multi = db.QueryMultiple("[dbo].[sp_GetUi_BookNo] "))
                {
                    xx = multi.Read<tbl_ZEmpSalesRep>().ToList();
                }
            }
            return xx;
        }

        public ResponseMessage CheckValidity_BookNo(string BookNo)
        {
            var ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@BookNo", BookNo);

                ret = db.Query<ResponseMessage>("[dbo].[sp_CheckValidity_BookNo]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }
        public ResponseMessage CheckValidity_BookNo_Receipt(string PageNo, string selesRep_ID,string receipt_ID, bool isUpdate)
        {
            var ret = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@PageNo", PageNo);
   para.Add("@selesRep_ID", selesRep_ID);
                para.Add("@receipt_ID", receipt_ID);
                para.Add("@isUpdate", isUpdate);

                ret = db.Query<ResponseMessage>("[dbo].[sp_CheckValidity_BookNo_Receipt]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return ret;
        }
        public ResponseMessage SaveBookNo(List<tbl_RefBooks_Receipt_Pages> param, string createUser_ID, string createTerminal_ID, DateTime dateCreate,string book_No,string selesRep_ID, string Remarks)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Hed", cast.ToDataTables(param).AsTableValuedParameter("dbo.Tmptbl_tbl_RefBooks_Receipt_Pages"));
                    para.Add("@book_No", book_No);
                    para.Add("@selesRep_ID", selesRep_ID);
                    para.Add("@Remarks", Remarks);
                    para.Add("@createUser_ID", createUser_ID);
                    para.Add("@createTerminal_ID", createTerminal_ID);
                    para.Add("@dateCreate", dateCreate);
                    x = db.Query<ResponseMessage>("[dbo].[sp_SaveBookNo]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
