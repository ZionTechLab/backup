using Dapper;
using SEACC.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data
{
   public  class FYValidationData
    {
        public ResponseMessage FYCheckValidityByDate( DateTime Txndate,DateTime Systemdate)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Txndate", Txndate);
                    para.Add("@Systemdate", Systemdate);
                    x = db.Query<ResponseMessage>("[dbo].[sp_Ctl_FYCheckValidityByDate2]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage FYupdate_opbl(string financialYear_ID)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@financialYear_ID", financialYear_ID);
   
                    x = db.Query<ResponseMessage>("[dbo].[sp_Ctl_FYupdate_opbl]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
