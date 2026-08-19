using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiteq.Classes
{
  public   class ReportHelper
    {
        #region Logon Report
        public static void LogonServer(ref ReportDocument crReportDocument)
        {

            CrystalDecisions.CrystalReports.Engine.Database oCRDb = crReportDocument.Database;
            CrystalDecisions.CrystalReports.Engine.Tables oCRTables = crReportDocument.Database.Tables;


            CrystalDecisions.Shared.TableLogOnInfo oCRTableLogonInfo;


            CrystalDecisions.Shared.ConnectionInfo oCRConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
            int iCnt;


            #region Set Connection Parameters for View Reports
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(DBHandling.DBConnection);
            //Server = builder.DataSource;
            //Database = builder.InitialCatalog;
            //UserName = builder.UserID;
            //Password = builder.Password;
            #endregion

            //plese change back to this
            oCRConnectionInfo.DatabaseName = clsSecurity.Database;
            oCRConnectionInfo.ServerName = builder.DataSource;// Server;
            oCRConnectionInfo.UserID = builder.UserID;// UserName;
            oCRConnectionInfo.Password = builder.Password;// Password;
            //oCRConnectionInfo.DatabaseName = getRegDatabaseName();
            //oCRConnectionInfo.ServerName = getRegServerName();
            //oCRConnectionInfo.UserID = getRegDBUserName(); ;
            //oCRConnectionInfo.Password = getRegDBUserPassword();


            foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTable in oCRTables)
            {
                oCRTableLogonInfo = oCRTable.LogOnInfo;
                oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;
                oCRTable.ApplyLogOnInfo(oCRTableLogonInfo);
            }


            //Setting Sub Report Log on information
            for (iCnt = 0; iCnt <= crReportDocument.Subreports.Count - 1; iCnt++)
            {

                oCRTables = crReportDocument.Subreports[iCnt].Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTable in oCRTables)
                {
                    oCRTableLogonInfo = oCRTable.LogOnInfo;
                    oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;
                    oCRTable.ApplyLogOnInfo(oCRTableLogonInfo);
                }
            }

        }
        #endregion
    }
}
