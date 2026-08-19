using Dapper;
using SEACC.DATA.Domain;
using SEACC.DATA.Domain.SCS;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SEACC.DATA.Data.SCS
{
    public class StockReportsData
    {
    //    public object DapperConnection { get; private set; }

        public StockReportUiDomain GetUI()
        {
            var xx = new StockReportUiDomain();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                using (var multi = db.QueryMultiple("[dbo].[sp_Getgi_StockReport]"))
                {
                    xx.Store = multi.Read<tbl_genStoreMaster>().ToList();
                    xx.ItemClass = multi.Read<tbl_zItemClass>().ToList();
                    xx.ItemType = multi.Read<tbl_zItemType>().ToList();
                    xx.ItemCategory = multi.Read<tbl_zItemCategory>().ToList();
                }
            }
            return xx;
        }

        public List<StockReport> getReport(int reportID,List<SelectionList> SelectionList,string ItemName,bool HideZero,bool QtyRange, int Qty)
        {
            var lists = new List<StockReport>();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@ReportID", reportID);
                para.Add("@ItemName", ItemName);
                para.Add("@HideZero", HideZero);
                para.Add("@QtyRange", QtyRange);
                para.Add("@Qty", Qty);
                para.Add("@SelectionList", cast.ToDataTables(SelectionList).AsTableValuedParameter("[dbo].[SelectionList]"));
                //para.Add("@LocationID", param.LocationID);
                //para.Add("@UpToDate", param.UpToDate);

                lists = db.Query<StockReport>("[dbo].[sp_GetRpt_FloreStock_ALL]", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return lists;
        }
    }
}
