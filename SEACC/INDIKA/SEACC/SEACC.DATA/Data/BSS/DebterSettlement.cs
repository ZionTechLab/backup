using Dapper;
using SEACC.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.BSS
{
    public class DebterSettlement
    {
        public List<dynamic> Get_DebterSettlemet(string invoice_ID, string journalEntry_ID_DR, string receipt_ID, string creditNote_ID, string journalEntry_ID_CR,String chequeRegister_ID)
        {
            var lists = new List<dynamic>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@invoice_ID", invoice_ID);
                para.Add("@journalEntry_ID_DR", journalEntry_ID_DR);
                para.Add("@receipt_ID", receipt_ID);
                para.Add("@creditNote_ID", creditNote_ID);
                para.Add("@journalEntry_ID_CR", journalEntry_ID_CR);
     para.Add("@chequeRegister_ID", chequeRegister_ID);
                lists = db.Query<dynamic>("[dbo].[sp_Get_DebterSettlemet]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }

        public ResponseMessage Remove_DebterSettlemet(string settled_ID)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@settled_ID", settled_ID);
                  
                    x = db.Query<ResponseMessage>("[dbo].[sp_Remove_DebterSettlemet]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
