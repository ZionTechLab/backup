using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.ACC
{
    public class AccChequeDate_Data
    {
        public ResponseMessage Save(tbl_accChequeDate Parm, bool IsUpdate)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@chequeRegister_ID", Parm.chequeRegister_ID);
                   // para.Add("@dateChequeOld", Parm.dateRegister_Old);
                    para.Add("@dateCheque", Parm.dateRegister_New);
                    para.Add("@User_ID", Parm.modifiedUser_ID);
                    para.Add("@Terminal_ID", Parm.modifiedTerminal_ID);
                    x = db.Query<ResponseMessage>("[dbo].[sp_updateDate_AccChequeRegister]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
