using Digiteq_Logic;
using System;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataTire;
using SEACC_POS.DataSet;
using SEACC_WPFControls;
using Digiteq_Logic_POS;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SEACC_POS.Reports
{
    public partial class frm_ReportViewer : Form
    {
        public frm_ReportViewer()
        {
            InitializeComponent();
        }

        public string PDF_Export(string path, System.Data.DataSet ReportDataSet, DataTable ParameterData)
        {
            string returnPath = "";
            if (!clsConfig.bProductActivated)
            {
                MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string s_Path = "";
                    ReportDocument objRpt = new ReportDocument();

                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += path;

                    objRpt.Load(s_Path);
                    objRpt.SetDataSource(ReportDataSet);

                    #region Set Server Detail for Report
                    ConnectionInfo connInfo = new ConnectionInfo();
                    connInfo.IntegratedSecurity = false;
                    TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                    tableLogOnInfo.ConnectionInfo = connInfo;
                    objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
                    objRpt.VerifyDatabase();
                    #endregion

                    #region Add FormulaFields
                    foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = cls_Formater.fncsetstring(detail.FormulaFieldsvalue);
                            }
                            catch (Exception)
                            { }
                        }
                    }
                    #endregion

                    DateTime dtmSvrDate = clsSecurity.getServerDateTime();
                    string sFilePath = clsConfig_POS.sPOSAttachmentPath_Server + "POSDetails" + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
                    objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sFilePath);

                    objRpt.Close();
                    objRpt.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            return returnPath;
        }

        public void print(string path, System.Data.DataSet ReportDataSet, DataTable ParameterData, tbl_securityFunctionMaster_Permission oPermission)
        {
            print(path, ReportDataSet, ParameterData, oPermission, false,true);
        }

        public void print(string path, System.Data.DataSet ReportDataSet, DataTable ParameterData, tbl_securityFunctionMaster_Permission oPermission, bool isExportToPDF,bool isShowPreview)
        {
            if (!clsConfig.bProductActivated)
            {
                MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sPaperName = "";
                    ReportDocument objRpt = new ReportDocument();

                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += path;

                    objRpt.Load(s_Path);
                    objRpt.SetDataSource(ReportDataSet);

                    #region Set Server Detail for Report
                    //ConnectionInfo connInfo = new ConnectionInfo();
                    ////connInfo.ServerName = clsSecurity.getRegServerName();
                    ////connInfo.DatabaseName = clsSecurity.decryptPassword(clsSecurity.getRegDatabaseName());
                    ////connInfo.UserID = clsSecurity.decryptPassword(clsSecurity.getRegDBUserName());
                    ////connInfo.Password = clsSecurity.decryptPassword(clsSecurity.getRegDBUserPassword());
                    //connInfo.IntegratedSecurity = false;

                    //TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                    //tableLogOnInfo.ConnectionInfo = connInfo;
                    //objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
                    //objRpt.VerifyDatabase();
                    #endregion

                    #region Add FormulaFields
                    foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = cls_Formater.fncsetstring(detail.FormulaFieldsvalue);
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
                        ExporttoPDF(objRpt);
                    }
                    else
                    {
                        tbl_securityPaperMaster oPaper = tbl_securityPaperMaster.Select(clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (oPaper == null && clsConfig.sRemortDesktopExportPath.Length > 0)
                        {
                            SEACCMessageBox.Show("Something went wrong...", "Please Set Paper Size to the Selected Branch...", MessageBoxButton.OK, "Red");
                            return;
                        }
                        else
                            sPaperName = oPaper.PaperName.ToString().Trim();

                        #region Empty Remote Path
                        if (clsConfig.sRemortDesktopExportPath.Length == 0)
                        {
                            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                            objRpt.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;

                            int i = 0;
                            for (i = 0; i < printDocument.PrinterSettings.PaperSizes.Count; i++)
                            {
                                int rawKind = 0;
                                if (printDocument.PrinterSettings.PaperSizes[i].PaperName == oPaper.PaperName.ToString().Trim())
                                {
                                    rawKind = Convert.ToInt32(printDocument.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(printDocument.PrinterSettings.PaperSizes[i]));
                                    objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                    break;
                                }
                            }
                        }
                        #endregion

                        string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });

                        if ((clsConfig.sRemortDesktopExportPath.Length > 0) && clsRemoteLogin.GetTerminalServerClientNameWTSAPI() != "" && clsSecurity.TerminalID == clsRemoteLogin.GetTerminalServerClientNameWTSAPI())
                        {
                            if (clsSecurity.UserIDLoged == "digiteq")
                            {
                                DialogResult dialogResult = MessageBox.Show("Click “yes” to preview report in remote desktop or “no” to view report on SEACC remote desktop printer", "", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                    PrintNormal(objRpt, oPermission,true);
                                else if (dialogResult == DialogResult.No)
                                    PrintRemort(objRpt, sPaperName);
                            }
                            else
                                PrintRemort(objRpt, sPaperName);
                        }
                        else
                        {
                            PrintNormal(objRpt, oPermission, isShowPreview);
                        }
                    }

                    objRpt.Close();
                    objRpt.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        public void DirectPrint(string path, System.Data.DataSet ReportDataSet, DataTable ParameterData, tbl_securityFunctionMaster_Permission oPermission)
        {
            if (!clsConfig.bProductActivated)
            {
                MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                #region Crystal Report Bill Print
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sPaperName = "";
                    ReportDocument objRpt = new ReportDocument();

                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += path;

                    objRpt.Load(s_Path);
                    objRpt.SetDataSource(ReportDataSet);

                    #region Add FormulaFields
                    foreach (dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = cls_Formater.fncsetstring(detail.FormulaFieldsvalue);
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    }
                    #endregion


                    tbl_securityPaperMaster oPaper = tbl_securityPaperMaster.Select(clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oPaper == null && clsConfig.sRemortDesktopExportPath.Length > 0)
                    {
                        SEACCMessageBox.Show("Something went wrong...", "Please Set Paper Size to the Selected Branch...", MessageBoxButton.OK, "Red");
                        return;
                    }
                    else
                        sPaperName = oPaper.PaperName.ToString().Trim();

                    #region Empty Remote Path
                    if (clsConfig.sRemortDesktopExportPath.Length == 0)
                    {
                        System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                        objRpt.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;

                        int i = 0;
                        for (i = 0; i < printDocument.PrinterSettings.PaperSizes.Count; i++)
                        {
                            int rawKind = 0;
                            if (printDocument.PrinterSettings.PaperSizes[i].PaperName == oPaper.PaperName.ToString().Trim())
                            {
                                rawKind = Convert.ToInt32(printDocument.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(printDocument.PrinterSettings.PaperSizes[i]));
                                objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                break;
                            }
                        }
                    }
                    #endregion

                    string[] Split = clsSecurity.Server.Split(new Char[] { '\\' });
                    if ((clsConfig.sRemortDesktopExportPath.Length > 0) && clsRemoteLogin.GetTerminalServerClientNameWTSAPI() != "" && clsSecurity.TerminalID == clsRemoteLogin.GetTerminalServerClientNameWTSAPI())
                    {
                        if (clsSecurity.UserIDLoged == "digiteq")
                        {
                            DialogResult dialogResult = MessageBox.Show("Click “yes” to preview report in remote desktop or “no” to view report on SEACC remote desktop printer", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                                objRpt.PrintToPrinter(1, false, 0, 30);
                            else if (dialogResult == DialogResult.No)
                                PrintRemort_Direct(objRpt, sPaperName);
                        }
                        else
                            PrintRemort_Direct(objRpt, sPaperName);
                    }
                    else
                    {
                        objRpt.PrintToPrinter(1, false, 0, 30);
                    }


                    objRpt.Close();
                    objRpt.Dispose();
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
                #endregion
            }
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

        private void PrintNormal(ReportDocument objRpt, tbl_securityFunctionMaster_Permission oPermission,bool bShowPreview)
        {
            #region Login & Permission SetUp
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ShowExportButton = true;// oPermission != null ? oPermission.AllowExport : false;
            crystalReportViewer1.ShowCopyButton = true;// oPermission != null ? oPermission.AllowExport : false;
            crystalReportViewer1.ShowPrintButton = true;// oPermission != null ? oPermission.AllowPrint : false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.CloseView(true);
            WindowState = FormWindowState.Maximized;

            if (bShowPreview)
            {
                ShowDialog();
            }
            else
            {
                objRpt.PrintToPrinter(1, false, 0, 30);
            }
            #endregion
        }

        private void PrintRemort(ReportDocument objRpt, string PaperName)
        {
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();
            string sFilePath = "";
            if (PaperName != "")
                sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ",normal," + PaperName + ".rpt";
            else
                sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ",normal.rpt";

            PrintRemorts(objRpt, sFilePath);
        }

        private void PrintRemorts(ReportDocument objRpt, string sFilePath)
        {
            objRpt.ExportToDisk(ExportFormatType.CrystalReport, sFilePath);
            System.IO.File.Move(sFilePath, sFilePath.Replace("ReportExportTemp\\", clsConfig.sRemortDesktopExportPath));
        }

        private void PrintRemort_Direct(ReportDocument objRpt, string PaperName)
        {
            DateTime dtmSvrDate = clsSecurity.getServerDateTime();
            string sFilePath = "";
            if (PaperName != "")
                sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ",direct," + PaperName + ".rpt";
            else
                sFilePath = "ReportExportTemp\\" + clsSecurity.UserIDLoged + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ",direct.rpt";

            PrintRemort_Directs(objRpt, sFilePath);
        }

        private void PrintRemort_Directs(ReportDocument objRpt, string sFilePath)
        {
            objRpt.ExportToDisk(ExportFormatType.CrystalReport, sFilePath);
            System.IO.File.Move(sFilePath, sFilePath.Replace("ReportExportTemp\\", clsConfig.sRemortDesktopExportPath));
        }
    }
}