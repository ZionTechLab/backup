using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Zion.ERP.Reports.DataSets;

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
                //   tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReportID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, (int)AuditStatus.ExportReport);// (int)AuditStatus.ExportReport
                //    detail.Insert();
            }
        }

        private void tsItem_Click(object sender, EventArgs e)
        {
            if (sReportID != "")
            {
                //   tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReportID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, (int)AuditStatus.PrintReport);// (int)AuditStatus.PrintReport
                //    detail.Insert();
            }
        }

        private void frm_ReportViewer_Load(object sender, EventArgs e)
        {
            //     clsFormatter.setFormatForm(this, "Report Viewer", 2, 0);
        }

        public void print(string path, DataSet ReportDataSet, DataTable ParameterData, string _sReportID)//,string _sReportID
        {
            print(path, ReportDataSet, ParameterData, false, _sReportID);
        }
        //public void print(string path, DataTable ReportDataSet, DataTable ParameterData, string _sReportID)//,string _sReportID
        //{
        //    print(path, ReportDataSet, ParameterData, false, _sReportID);
        //}
        string fncsetstring(string sTemp)
        {
            return "'" + sTemp.Replace("'", "''").Trim() + "'";
        }
     
        public string print(string path, DataSet ReportDataSet, DataTable ParameterData, bool isExportToPDF, string _sReportID)
        {
            sReportID = _sReportID;
            string returnvalue = "";

            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";

                if (path != "")
                {
                    ReportDocument objRpt = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
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
                                objRpt.DataDefinition.FormulaFields[detail.FormulaFieldsName].Text = fncsetstring(detail.FormulaFieldsvalue);
                            }
                            catch (Exception)
                            {
                                //   MessageBox.Show("Crystal report Formula Field not found - " + detail.FormulaFieldsName);
                            }
                        }
                    }
                    #endregion

                    #region Normal Login
                    crystalReportViewer1.ReportSource = objRpt;

                    crystalReportViewer1.DisplayToolbar = true;
                    crystalReportViewer1.CloseView(true);
                    WindowState = FormWindowState.Maximized;
                    Show();
                    crystalReportViewer1.Refresh();
                    #endregion
               
                    //    objRpt.Close();
                    //   objRpt.Dispose();
                }
                else
                {
                    MessageBox.Show("Report dosen't exist", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return returnvalue;
        }


    }
}