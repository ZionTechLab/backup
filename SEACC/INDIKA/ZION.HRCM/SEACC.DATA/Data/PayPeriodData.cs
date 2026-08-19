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
    public class PayPeriodData
    {
        public ResponseMessage ClosePeriod(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID, int processPeriod_Sub_ID, string User_ID)
        {
            var x = new ResponseMessage();

            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@company_ID", company_ID);
                    para.Add("@companyBranch_ID", companyBranch_ID);
                    para.Add("@processGroup_ID", processGroup_ID);
                    para.Add("@processPeriod_ID", processPeriod_ID);
                    para.Add("@processPeriod_Sub_ID", processPeriod_Sub_ID);
                    para.Add("@User_ID", User_ID);

                    x = db.Query<ResponseMessage>("[dbo].[sp_CloseProcessPeriod]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage OpenPeriod(DateTime  processPeriod_Sub_startDate, DateTime processPeriod_Sub_endDate, string processGroup_ID)
        {
            var x = new ResponseMessage();

            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@processPeriod_Sub_startDate", processPeriod_Sub_startDate);
                    para.Add("@processPeriod_Sub_endDate", processPeriod_Sub_endDate);
                    para.Add("@processGroup_ID", processGroup_ID);

                    x = db.Query<ResponseMessage>("[dbo].[payrollFlushGroup]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
