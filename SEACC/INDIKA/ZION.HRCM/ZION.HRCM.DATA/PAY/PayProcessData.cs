using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZION.HRCM.DATA.Helpers;
using ZION.HRCM.DOMAIN.Comon;
using ZION.HRCM.DOMAIN.PAY;

namespace ZION.HRCM.DATA.PAY
{
  public   class PayProcessData
    {
        public PayProcess_Result Save_PayRoll(PayProcess_Para Parm)
        {
            var xx = new PayProcess_Result();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@processGroup_ID", Parm.processGroup_ID);
                    para.Add("@processPeriod_ID", Parm.processPeriod_ID);
                    para.Add("@processPeriod_Sub_ID", Parm.processPeriod_Sub_ID);
                    para.Add("@company_ID", Parm.company_ID);
                    para.Add("@companyBranch_ID", Parm.companyBranch_ID);
                    para.Add("@User_ID", Parm.User_ID);
                    para.Add("@Terminal_ID", Parm.Terminal_ID);

                    using (var multi = db.QueryMultiple("[dbo].[sp_Save_PayrollData]", para, commandType: CommandType.StoredProcedure))
                    {  
                        xx.result = multi.Read<ResponseMessage>().FirstOrDefault();
                        xx.ShiftErrors = multi.Read<string>().ToList();
                        xx.AttendanceErrors = multi.Read<string>().ToList();
                     
                    }
                }
            }
            catch (Exception ex)
            {
              //  x.OutMsg = ex.Message;
            }
            return xx;
        }

        public ResponseMessage Update_SalaryAdjustment(List<tbl_payTxSalaryAdjustment> Parm)
        {
            var xx = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@Detail", cast.ToDataTables(Parm).AsTableValuedParameter("dbo.Tmptbl_payTxSalaryAdjustment"));

                    using (var multi = db.QueryMultiple("[dbo].[sp_Update_SalaryAdjustment]", para, commandType: CommandType.StoredProcedure))
                    {
                        xx = multi.Read<ResponseMessage>().FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                //  x.OutMsg = ex.Message;
            }
            return xx;
        }

        public PaySlip getReport_PaySlip(string processGroup_ID,int processPeriod_Sub_ID)
        {
            var xx = new PaySlip();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@processGroup_ID", processGroup_ID);
                    para.Add("@processPeriod_Sub_ID", processPeriod_Sub_ID);

                    using (var multi = db.QueryMultiple("[dbo].[sp_getRpt_PaySlip]", para, commandType: CommandType.StoredProcedure))
                    {
                        xx.Header = multi.Read<dt_EmpSalaryData>().ToList();
                        xx.PayItems = multi.Read<dt_EmpSalaryData_PayslipItems>().ToList();
                        xx.StatutaryItems = multi.Read<dt_EmpSalaryData_PayslipItems_Statutatry>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                //  x.OutMsg = ex.Message;
            }
            return xx;
        }
        public BankSalaryRegister getReport_BankSalaryRegister(string processGroup_ID, string processPeriod_Sub_ID)
        {
            var xx = new BankSalaryRegister();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@processGroup_ID", processGroup_ID);
                    para.Add("@processPeriod_Sub_ID", processPeriod_Sub_ID);
                    para.Add("@reportType", 2);

                    using (var multi = db.QueryMultiple("[dbo].[sp_getRpt_SalaryRegister]", para, commandType: CommandType.StoredProcedure))
                    {
                        xx.Basic = multi.Read<dynamic>().ToList();
                        xx.Allowance = multi.Read<dynamic>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                //  x.OutMsg = ex.Message;
            }
            return xx;
        }
    }
}
