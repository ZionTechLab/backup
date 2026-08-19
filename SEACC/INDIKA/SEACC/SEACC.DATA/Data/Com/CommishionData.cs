using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.Com;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SEACC.DATA.Data.Com
{
    public class CommishionData
    {
        public CommissionSalesRep get_CommissionSalesRep(int PeriodIndex, string SalesRep_ID,int dateSlab)
        {
            var xx = new CommissionSalesRep();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@ReportTy", "");
                para.Add("@SalesmanID", SalesRep_ID);
                para.Add("@AreaManger_ID", "");
                para.Add("@SalesManager_ID", "");
                para.Add("@itemType_IDPara", "");
                para.Add("@itemCategory_IDPara", "");
                para.Add("@PeriodIndex", PeriodIndex);
                para.Add("@dateSlab", dateSlab);
                para.Add("@ReportId", 110014);

                using (var multi = db.QueryMultiple("[dbo].[sp_GetRpt_Commission]", para, commandType: CommandType.StoredProcedure))
                {
                    xx.t1 = multi.Read<dynamic>().ToList();
                    xx.t2 = multi.Read<dynamic>().ToList();
                }
            }
            return xx;
        }

        public Commishion_Collectors get_CommissionCollecters(int PeriodIndex, string Collector_ID)
        {
            var xx = new Commishion_Collectors();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@PeriodIndex", PeriodIndex);
                para.Add("@Collector_ID", Collector_ID);

                using (var multi = db.QueryMultiple("[dbo].[sp_get_CommishionCollecters]", para, commandType: CommandType.StoredProcedure))
                {
                    xx.TotalCommishion = multi.Read<decimal>().First();
                    xx.dateSlab = multi.Read<CommishionDateSlab>().ToList();
                    xx.TxnList = multi.Read<comCommissionCalculation_Detail>().ToList();

                }
            }
            return xx;
        }

        public List<CommissionCalculation_Summary> CalculateCommishion_Collectors(int PeriodIndex)
        {
            var xx = new List<CommissionCalculation_Summary>();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@PeriodIndex", PeriodIndex);

                xx = db.Query<CommissionCalculation_Summary>("[dbo].[sp_Calculate_CollectorsCommishion]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return xx;
        }

        public List<tbl_comCommissionCalculation_Drivers_Summary> CalculateCommishion_Drivers(int PeriodIndex)
        {
            var xx = new List<tbl_comCommissionCalculation_Drivers_Summary>();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@PeriodIndex", PeriodIndex);

                xx = db.Query<tbl_comCommissionCalculation_Drivers_Summary>("[dbo].[sp_CalculateCommishion_Driver]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return xx;
        }

        public Dataset_Dynamic GetRpt_Collection_New(int PeriodIndex)
        {
            var xx = new Dataset_Dynamic();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@CommishionPeriod", PeriodIndex);


                using (var multi = db.QueryMultiple("[dbo].[sp_GetRPT_Commission_Collecters_Full]", para, commandType: CommandType.StoredProcedure))
                {
                    xx.dt1 = multi.Read<dynamic>().ToList();
                    xx.dt2 = multi.Read< dynamic>().ToList();
                    xx.dt3 = multi.Read< dynamic>().ToList();

                }
            }
            return xx;
        }

        public Dataset_Dynamic GetRpt_Driver_Commishion(int PeriodIndex)
        {
            var xx = new Dataset_Dynamic();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@CommishionPeriod", PeriodIndex);


                using (var multi = db.QueryMultiple("[dbo].[sp_GetRPT_Commission_Driver]", para, commandType: CommandType.StoredProcedure))
                {
                    xx.dt1 = multi.Read<dynamic>().ToList();
                    xx.dt2 = multi.Read<dynamic>().ToList();
                    xx.dt3 = multi.Read<dynamic>().ToList();

                }
            }
            return xx;
        }

        public ResponseMessage Save_CommissionCollecters(List<CommissionCalculation_Summary> Parm,int PeriodIndex)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    
                    para.Add("@Detail", cast.ToDataTables(Parm).AsTableValuedParameter("dbo.Tmptbl_CommissionCalculation_Summary"));
                    para.Add("@PeriodIndex", PeriodIndex);
                    x = db.Query<ResponseMessage>("[dbo].[sp_save_CommissionCalculation_Driver_Summary]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage Save_Commission_Drivers(List<tbl_comCommissionCalculation_Drivers_Summary> Parm, int PeriodIndex)
        {
            var x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();

                    para.Add("@Detail", cast.ToDataTables(Parm).AsTableValuedParameter("dbo.Tmptbl_comCommissionCalculation_Drivers_Summary"));
                    para.Add("@PeriodIndex", PeriodIndex);
                    x = db.Query<ResponseMessage>("[dbo].[sp_save_CommissionCalculation_Summary]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                x.OutMsg = ex.Message;
            }
            return x;
        }

        public ResponseMessage Approve_CommissionCollecters(int PeriodIndex,string Collector_ID)
        {
            ResponseMessage x = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
                {
                    var para = new DynamicParameters();
                    para.Add("@PeriodIndex", PeriodIndex);
                    para.Add("@Collector_ID", Collector_ID);
                   
                    x = db.Query<ResponseMessage>("[dbo].[Approve_CommissionCollecters]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
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