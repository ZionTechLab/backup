using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace SEACC_PTS
{
    public partial class frm_ReportViewer : Form
    {
        public frm_ReportViewer()
        {
            InitializeComponent();
        }
        public string fncsetstring(string sTemp)
        {
            return "'" + sTemp.Replace("'", "''").Trim() + "'";
        }
        public string print(string path, DataSet ReportDataSet, DataTable ParameterData,bool bIsExport)
        {
            string sfilename="";
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataSet);
                //objRpt.Refresh();

                #region Add FormulaFields
                if (ParameterData != null)
                {
                    foreach (DataSets.dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = fncsetstring(detail.FormulaFieldsvalue);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Crystal report Formula Field not found - " + detail.FormulaFieldsName);
                            }
                        }
                        else
                        {

                        }
                    }
                }
                #endregion
                if (!bIsExport)
                {
                    #region Normal Login
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.DisplayToolbar = true;
                    crystalReportViewer1.CloseView(false);
                    WindowState = FormWindowState.Maximized;
                    ShowDialog();
                    #endregion
                }
                else
                {
                    sfilename = "ReportExport\\TimeSheet-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";                    
                    //sfilename = "ReportExport\\TimeSheet-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xls";
                    objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sfilename);
                }
                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return sfilename;
        }
        public string print2(string path, DataSet ReportDataSet1, DataTable ReportDataSet, DataTable ParameterData, bool bIsExport)
        {
            string sfilename = "";
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ReportDataSet1);
                objRpt.SetDataSource(ReportDataSet);
                //objRpt.Refresh();

                #region Add FormulaFields
                if (ParameterData != null)
                {
                    foreach (DataSets.dts_ReportExport.dt_rptParameterRow detail in ParameterData.Rows)
                    {
                        if (detail.isFormulaField)
                        {
                            try
                            {
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = fncsetstring(detail.FormulaFieldsvalue);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Crystal report Formula Field not found - " + detail.FormulaFieldsName);
                            }
                        }
                        else
                        {

                        }
                    }
                }
                #endregion
                if (!bIsExport)
                {
                    #region Normal Login
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.DisplayToolbar = true;
                    crystalReportViewer1.CloseView(false);
                    WindowState = FormWindowState.Maximized;
                    ShowDialog();
                    #endregion
                }
                else
                {
                    sfilename = "ReportExport\\TimeSheet-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
                    //sfilename = "ReportExport\\TimeSheet-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xls";
                    objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sfilename);
                }
                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return sfilename;
        }
    }
}
