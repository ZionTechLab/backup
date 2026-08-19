using CrystalDecisions.CrystalReports.Engine;
using ZION.PCB.Reports.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZION.PCB.Reports
{

    public partial class frm_ReportViewer : Form
    {
        DateTime dtmSvrDate = DateTime.Now;// clsSecurity.getServerDateTime();
        string UserIDLoged = "";// clsSecurity.UserIDLoged
        public frm_ReportViewer()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }


        public void print(string path, DataSet ReportDataSet, DataTable ParameterData)
        {
            print(path, ReportDataSet, ParameterData,  false);
        }
        public static string fncsetstring(string sTemp)
        {
            return "'" + sTemp.Replace("'", "''").Trim() + "'";
        }
        public string print(string path, DataSet ReportDataSet, DataTable ParameterData, bool isExportToPDF)
        {
            string returnvalue = "";
            //if (!clsConfig.bProductActivated)
            //{
            //    MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //else
            //{
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\SEACC_PCB\\bin\\Debug", "\\SeaccReports");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataSet);

                #region Set Server Detail for Report
              //  ConnectionInfo connInfo = new ConnectionInfo();
                //connInfo.ServerName = clsSecurity.getRegServerName();
                //connInfo.DatabaseName = clsSecurity.decryptPassword(clsSecurity.getRegDatabaseName());
                //connInfo.UserID = clsSecurity.decryptPassword(clsSecurity.getRegDBUserName());
                //connInfo.Password = clsSecurity.decryptPassword(clsSecurity.getRegDBUserPassword());
              //  connInfo.IntegratedSecurity = false;

             //   TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
              //  tableLogOnInfo.ConnectionInfo = connInfo;
               // objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
               // objRpt.VerifyDatabase();
                #endregion

                #region Add FormulaFields
                foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                {
                    if (detail.isFormulaField)
                    {
                        try
                        {
                            objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = fncsetstring(detail.FormulaFieldsvalue);
                        }
                        catch (Exception)
                        {
                            //   MessageBox.Show("Crystal report Formula Field not found - " + detail.FormulaFieldsName);
                        }
                    }
                    else
                    {
                        // objRpt.DataDefinition.ParameterFields[detail.FormulaFieldsName].CurrentValues.Add(clsCommon.fncsetstring(detail.FormulaFieldsvalue));
                    }
                }
                #endregion


                if (isExportToPDF)
                {
                    returnvalue = ExporttoPDF(objRpt);
                }
                else
                {
                    //string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                    //if ((clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods_PCB.GetHostName() == Split[0]))
                    //{
                    //    if (clsSecurity.UserIDLoged == "digiteq")
                    //    {
                    //        DialogResult dialogResult = MessageBox.Show("Click “yes” to preview report in remote desktop or “no” to view report on SEACC remote desktop printer", "", MessageBoxButtons.YesNo);
                    //        if (dialogResult == DialogResult.Yes)
                    //            PrintNormal(objRpt, oPermission);
                    //    }

                    //}
                    //else
                       PrintNormal(objRpt);
                }

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Something went wrong...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            //}
            return returnvalue;
        }

        private string ExporttoPDF(ReportDocument objRpt)
        {
            #region Remort Desktop Login
          

            string sFilePath = "ReportExportTemp\\" + UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
            objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sFilePath);

            #endregion

            return sFilePath;
        }

        private void PrintNormal(ReportDocument objRpt)
        {
            #region Login & Permission SetUp

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ShowExportButton = true; /*oPermission.AllowExport;*/
            crystalReportViewer1.ShowCopyButton = true; /*oPermission.AllowExport;*/
            crystalReportViewer1.ShowPrintButton = true; /*oPermission.AllowPrint;*/
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.CloseView(true);
            WindowState = FormWindowState.Maximized;
            ShowDialog();

            #endregion
        }

        //internal void Print(string p, dts_PettyCash glb_dts_Expenditure, dts_ReportExport.dt_rptParameterDataTable dt_rptParameterDataTable, tbl_securityFunctionMaster_Permission oRepPermission)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
