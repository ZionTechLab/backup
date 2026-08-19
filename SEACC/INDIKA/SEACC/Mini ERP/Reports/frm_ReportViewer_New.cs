using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Zion.ERP.Reports.DataSets;
using Digiteq.Reports;
using CrystalDecisions.Shared;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_ReportViewer_New : Form
    {
        private string sReportID = "";
        public frm_ReportViewer_New()
        {
            InitializeComponent();

            foreach (Control control in crystalReportViewer1.Controls)
            {
                if (control is System.Windows.Forms.ToolStrip)
                {
                    ToolStripItem tsItem = ((ToolStrip)control).Items[1];
                    tsItem.Click += new EventHandler(tsItem_Click);

                    ToolStripItem tsItems = ((ToolStrip)control).Items[0];
                    tsItems.Click += new EventHandler(tsItems_Click);
                }
            }
        }

        private void tsItems_Click(object sender, EventArgs e)
        {
            if (sReportID != "")
            {
                tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReportID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, (int)AuditStatus.ExportReport);// (int)AuditStatus.ExportReport
                detail.Insert();
            }
        }

        private void tsItem_Click(object sender, EventArgs e)
        {
            if (sReportID != "")
            {
                tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReportID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, (int)AuditStatus.PrintReport);// (int)AuditStatus.PrintReport
                detail.Insert();
            }
        }

        private void frm_ReportViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Report Viewer", 2, 0);
        }

        public void print(string path, DataSet ReportDataSet, DataTable ParameterData, string _sReportID)//,string _sReportID
        {
            print(path, ReportDataSet, ParameterData, false, _sReportID);
        }
        public void print(string path, DataTable ReportDataSet, DataTable ParameterData, string _sReportID)//,string _sReportID
        {
            print(path, ReportDataSet, ParameterData, false, _sReportID);
        }

        public string print(string path, DataTable ReportDataSet, DataTable ParameterData, bool isExportToPDF, string sReportID)
        {
            string returnvalue = "";

            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";

                if (path != "")
                {
                    ReportDocument objRpt = new ReportDocument();

                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += path;

                    objRpt.Load(s_Path);
                    ReportDataSet.TableName = " vw_rpt_bpsChequeRegister";
                    objRpt.SetDataSource(ReportDataSet);
                   // objRpt.SetDataSource()


                    if (sReportID != "")
                    {
                        tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReportID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, (int)AuditStatus.ViewReport);// (int)AuditStatus.ViewReport
                        detail.Insert();
                    }

                    #region Add FormulaFields
                    foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = clsCommon.fncsetstring(detail.FormulaFieldsvalue);
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
                        string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                        if ((clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods_Local.GetHostName() == Split[0]))
                        {
                            if (clsSecurity.UserIDLoged == "digiteq")
                            {
                                DialogResult dialogResult = MessageBox.Show("Click “yes” to preview report in remote desktop or “no” to view report on SEACC remote desktop printer", "", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                    PrintNormal(objRpt);
                                else if (dialogResult == DialogResult.No)
                                    PrintRemort(objRpt);
                            }
                            else
                                PrintRemort(objRpt);
                        }
                        else
                            PrintNormal(objRpt);
                    }

                    objRpt.Close();
                    objRpt.Dispose();
                }
                else
                {
                    MessageBox.Show("Report dosen't exist", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return returnvalue;
        }

        public string print(string path, DataSet ReportDataSet, DataTable ParameterData, bool isExportToPDF, string _sReportID)
        {
            sReportID = _sReportID;
            string returnvalue = "";
            //if (clsSecurity.UserIDLoged.Trim().ToUpper() != "DIGITEQ")
            //{
            //    //if (!clsConfig.bProductActivated)
            //    //{
            //    //    MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    //    return returnvalue;
            //    //}
            //}


            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";

                if (path != "")
                {
                    ReportDocument objRpt = new ReportDocument();

                    s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "");
                    s_Path += "\\ZION.ERP.Reports";
                    s_Path += path;

                    objRpt.Load(s_Path);
                    objRpt.SetDataSource(ReportDataSet);

                    if (sReportID != "")
                    {
                        tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReportID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, (int)AuditStatus.ViewReport);// (int)AuditStatus.ViewReport
                        detail.Insert();
                    }

                    #region Add FormulaFields
                    foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = clsCommon.fncsetstring(detail.FormulaFieldsvalue);
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
                        string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                        if ((clsConfig.sRemortDesktopExportPath.Length > 0) && (clsHelpMethods_Local.GetHostName() == Split[0]))
                        {
                            if (clsSecurity.UserIDLoged == "digiteq")
                            {
                                DialogResult dialogResult = MessageBox.Show("Click “yes” to preview report in remote desktop or “no” to view report on SEACC remote desktop printer", "", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                    PrintNormal(objRpt);
                                else if (dialogResult == DialogResult.No)
                                    PrintRemort(objRpt);
                            }
                            else
                                PrintRemort(objRpt);
                        }
                        else
                            PrintNormal(objRpt);
                    }

                    objRpt.Close();
                    objRpt.Dispose();
                }
                else
                {
                    MessageBox.Show("Report dosen't exist", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return returnvalue;
        }

        private void PrintNormal(ReportDocument objRpt)
        {
            #region Normal Login
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.CloseView(true);
            WindowState = FormWindowState.Maximized;
            ShowDialog();
            #endregion
        }

        private void PrintRemort(ReportDocument objRpt)
        {
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();

            string sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".rpt";
            objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, sFilePath);
            System.IO.File.Move(sFilePath, sFilePath.Replace("ReportExportTemp\\", clsConfig.sRemortDesktopExportPath));

            MessegeBox mess = new MessegeBox();
            mess.Show();
        }

        private string ExporttoPDF(ReportDocument objRpt)
        {
            #region Remort Desktop Login
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();

            string sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
            objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sFilePath);
            #endregion

            return sFilePath;
        }
    }
}