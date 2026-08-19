using Dapper;
using SEACC.DATA.Domain.CFG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.CFG
{
  public   class SecurityData
    {
        public PortalUI get_PortalUI(string BranchID)
        {
            var xx = new PortalUI();

            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@BranchID", BranchID);

                using (var multi = db.QueryMultiple("[dbo].[sp_get_PortalUI]", para, commandType: CommandType.StoredProcedure))
                {
                    xx.CompanyInfo= multi.Read<tbl_genCompanyInfo>().First();
                    xx.BranchName = multi.Read<string>().First();
                    xx.Category = multi.Read<tbl_securityFormCategory>().ToList();
                    xx.Forms = multi.Read<tbl_securityFormMaster>().ToList();
                   // xx.dateSlab = multi.Read<CommishionDateSlab>().ToList();
                 //   xx.TxnList = multi.Read<comCommissionCalculation_Detail>().ToList();

                }
            }
            return xx;
        }
    }
}
