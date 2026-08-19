using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZION.ERP.Reports
{
    public class PdfExport
    {
        public string PDF_Export(string sRptFilePath, DataSet ReportDataSet, DateTime date, string ExportPath)
        {
            string returnPath = "";
            //if (!clsConfig.bProductActivated)
            //{
            //    MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //else
            // {
            try
            {
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += sRptFilePath;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataSet);

                #region Set Server Detail for Report
                //  ConnectionInfo connInfo = new ConnectionInfo();
                //   connInfo.IntegratedSecurity = false;
                //  TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                //    tableLogOnInfo.ConnectionInfo = connInfo;
                //   objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
                objRpt.VerifyDatabase();
                #endregion

                DateTime dtmSvrDate = date;
                returnPath = ExportPath + "POSDetails" + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
                objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, returnPath);
                //   clsValidate.WriteErrorLog(" Report Generation Successfully (" + returnPath + ")", -1, null);

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                //  clsValidate.WriteErrorLog(" Report Generation Failed (" + sRptFilePath + ") - ", -1, ex);
            }
            // }   
            return returnPath;
        }

        public string PDF_Export(string sRptFilePath, DataTable ReportDataSet, DateTime date, string ExportPath)
        {
            string returnPath = "";
            string s_Path = "";
            try
            {

                ReportDocument objRpt = new ReportDocument();
                //  var x = "";// @"D:\Digiteq\Repositary\INDIKA_ERP\INDIKA\SEACC\ZION.ERP.Reports\";
                s_Path = Application.StartupPath.Replace("bin\\Debug", "");
                s_Path += "\\" + sRptFilePath;
                //   WriteErrorLog(s_Path, -1, null);
                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataSet);






                #region Set Server Detail for Report
                //  ConnectionInfo connInfo = new ConnectionInfo();
                //   connInfo.IntegratedSecurity = false;
                //  TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                //    tableLogOnInfo.ConnectionInfo = connInfo;
                //   objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
                objRpt.VerifyDatabase();
                #endregion

                DateTime dtmSvrDate = date;
                returnPath = Application.StartupPath + "\\" + ExportPath + "flore-stock" + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
                objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, returnPath);
                //   clsValidate.WriteErrorLog(" Report Generation Successfully (" + returnPath + ")", -1, null);

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                WriteErrorLog(" Report Generation Failed (" + s_Path + ") - ", -1, ex);
            }
            // }   
            return returnPath;
        }

        public void WriteErrorLog(string sError, int iformID, Exception ex)
        {
            try
            {
                string smsg = DateTime.Now.ToString() + " - " + sError + " - " + iformID + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + "-" + Environment.NewLine + Environment.NewLine;

                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, smsg);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
        }
    }
}