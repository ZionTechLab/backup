using DataTire;
using Zion.ERP.Reports.DataSets;
using Digiteq_Logic;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using SEACC.DATA.Data.Com;
using SEACC.DATA.Domain.Com;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.COM
{
    public partial class frm_txComComissionCalculation_Collector : MettroForm
    {
        //public int iFormID;
        //public bool bNoAccess;
        //private bool IsUpdateMode = false;

        CommishionData commishion = new CommishionData();
        dts_Unspecified glb_dts_Unspecified = new dts_Unspecified();

        public frm_txComComissionCalculation_Collector()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.Com_ComissionCalculation_Collectors);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }

        private void txtComPeriod_DoubleClick(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            clsSearch.Search_MasterComissionPeriod(ref txtComPeriod);
            if (txtComPeriod.Tag.ToString() != "")
            {
                string sQuary = "exec sp_Get_comCommissionCalculation_Summary " + txtComPeriod.Tag.ToString();
                dgvMain.DataSource = DBHandling.ExecQuery(sQuary).Tables[0];
            }
        }
        private void frm_txComComissionCalculation_Collectors_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtComPeriod.Clear();
            txtComPeriod.Tag = null;
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtComPeriod.Tag.ToString() != "")
            {

                if (e.ColumnIndex == 1)
                {
                    string selesRep_ID = clsValidate.ValidateGridValue(dgvMain, "selesRep_ID", e.RowIndex, "");
                    if (selesRep_ID != "")
                    {
                        var frmCollecterCom = new frm_txComComissionCalculation_Collectors(selesRep_ID, int.Parse(txtComPeriod.Tag.ToString()));
                        frmCollecterCom.ShowDialog();
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    var Approve = clsValidate.ValidateGridValue(dgvMain, "isApproved", e.RowIndex, false);
                    var Collecter = clsValidate.ValidateGridValue(dgvMain, "selesRep_ID", e.RowIndex, "");
                    if (!Approve)
                    {
                        DialogResult msgResult = MessageBox.Show("Do you want to approve this transaction", clsFormatter.GetMessageCaption(), MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                        if (msgResult == DialogResult.OK)
                        {
                            int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());
                            var result = commishion.Approve_CommissionCollecters(CommishionPeriod, Collecter);

                            if (result.IsSuccess)
                            {
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadGrid();
                            }
                            else
                                MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            dgvMain["isApproved", e.RowIndex].Value = true;
                        }

                    }


                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtComPeriod.Text != "")
            {
                if (dgvMain.Rows.Count > 0)
                {
                    DialogResult msgResult = MessageBox.Show("This process will override already processed data \nPlease click ok to proceed", clsFormatter.GetMessageCaption(), MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    if (msgResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    var approve = clsValidate.ValidateGridValue(dgvMain, "isApproved", row.Index, false);
                    if (approve)
                    {
                        MessageBox.Show("Recalculation is not allowed as one or more transactions are approved");
                        return;
                    }
                }

                int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());
                if (CommishionPeriod != -1)
                {
                    var xx = commishion.CalculateCommishion_Collectors(CommishionPeriod);
                    var json = JsonConvert.SerializeObject(xx);
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                    dgvMain.DataSource = dt;
                }
            }
            else
                MessageBox.Show("Please select the period");
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string sColName = dgvMain.Columns[e.ColumnIndex].Name;

                #region Add Debit Amount
                if (sColName == "deductions")
                {
                    var CommishionAmount = clsValidate.ValidateGridValue(dgvMain, "totalAmount", e.RowIndex, decimal.Parse("0.00"));
                    var Deduction = clsValidate.ValidateGridValue(dgvMain, "deductions", e.RowIndex, decimal.Parse("0.00"));

                    dgvMain["deductions", e.RowIndex].Value = Deduction;
                    dgvMain["netAmount", e.RowIndex].Value = (CommishionAmount - Deduction);
                }
                #endregion

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtComPeriod.Text == "")
            {
                MessageBox.Show("Please select the period");
                return;
            }

            if (dgvMain.Rows.Count == 0)
            {
                MessageBox.Show("Please calculate before save");
                return;
            }
            DialogResult msgResult = MessageBox.Show("Do you want to save above records", clsFormatter.GetMessageCaption(), MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (msgResult == DialogResult.Cancel)
            {
                return;
            }

            var json = JsonConvert.SerializeObject(dgvMain.DataSource);
            var dt = (List<CommissionCalculation_Summary>)JsonConvert.DeserializeObject(json, (typeof(List<CommissionCalculation_Summary>)));
            int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());
            var result = commishion.Save_CommissionCollecters(dt, CommishionPeriod);

            if (result.IsSuccess)
            {
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            else
                MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMain_KeyPress(object sender, KeyPressEventArgs e)
        {


            var Approve = clsValidate.ValidateGridValue(dgvMain, "isApproved", dgvMain.SelectedRows[0].Index, false);
            if (Approve)
                e.Handled = true;
        }

        private void dgvMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var Approve = clsValidate.ValidateGridValue(dgvMain, "isApproved", dgvMain.SelectedRows[0].Index, false);
            if (Approve)
                e.Cancel = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtComPeriod.Text == "")
            {
                MessageBox.Show("Records not found..!");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                string sDuplicate = "";
                string Report_ID = clsAutocode.getReportID(enum_ReportName.COM_Commission_Collecter);
                glb_dts_Unspecified.Clear();
                int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());

                if (clsHelpMethods_Local.GetReportPath(Report_ID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                {
                    Cursor = Cursors.WaitCursor;

                    glb_dts_Unspecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");

                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                    string sQuary = "exec sp_GetRPT_Commission_Collecters " + CommishionPeriod + ",1";

                    glb_dts_Unspecified.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                    glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("ComPeriod", txtComPeriod.Text, true);

                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                    CRViwer.print(sReportPath, glb_dts_Unspecified, glb_dts_ExportReport.dt_rptParameter, Report_ID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtComPeriod.Text == "")
            {
                MessageBox.Show("Records not found..!");
                return;
            }


            int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());
            if (CommishionPeriod != -1)
            {
                var xx = commishion.GetRpt_Collection_New(CommishionPeriod);
                var json = JsonConvert.SerializeObject(xx.dt1);
                DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                //dgvMain.DataSource = dt;
                var json2 = JsonConvert.SerializeObject(xx.dt2);
                DataTable dt2 = (DataTable)JsonConvert.DeserializeObject(json2, (typeof(DataTable)));

                var json3 = JsonConvert.SerializeObject(xx.dt3);
                DataTable dt3 = (DataTable)JsonConvert.DeserializeObject(json3, (typeof(DataTable)));

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Text documents (.xls)|*.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo files = new FileInfo(dlg.FileName);

                        string filename = dlg.FileName;
                        using (ExcelPackage pck = new ExcelPackage(files))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Summary");

                            ws.Cells["A2"].Value = "Collectors Commishion "+txtComPeriod.Text;


                            ws.Cells["A4"].LoadFromDataTable(dt2, true);
                            ExcelRange range = ws.Cells[4, 1, dt2.Rows.Count+5, (dt2.Columns.Count )];
                            ExcelTable tab = ws.Tables.Add(range, "Table1");

                            tab.ShowFilter = true;
                            tab.ShowTotal = true;

                            int i = 0;
                            foreach (DataColumn dtRow in dt2.Columns)
                            {
                                var x = dtRow.DataType.Name.ToString();

                                tab.Columns[i].Name = dtRow.ColumnName;
                                if (dtRow.DataType == typeof(decimal) || dtRow.DataType == typeof(Double))
                                {
                                    tab.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                }
                                i++;
                            }

                            tab.Columns[0].TotalsRowLabel = "Total ";

                            tab.TableStyle = TableStyles.Medium2;


                            var cel = "A" + (dt2.Rows.Count + 9);

                            ws.Cells[cel].LoadFromDataTable(dt1, true);
                            ExcelRange range2 = ws.Cells[dt2.Rows.Count + 9, 1, dt1.Rows.Count+ dt2.Rows.Count + 8, dt1.Columns.Count ];
                            ExcelTable tab2 = ws.Tables.Add(range2, "Table2");

                            tab2.ShowFilter = true;
                            tab2.ShowTotal = true;

                            int j = 0;
                            foreach (DataColumn dtRow in dt1.Columns)
                            {
                                // var x = dtRow.DataType.Name.ToString();

                                tab2.Columns[j].Name = dtRow.ColumnName+"_";
                                if (dtRow.DataType == typeof(decimal) || dtRow.DataType == typeof(Double))
                                {
                                    tab2.Columns[j].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName+"_])"; //102 = Count 
                                }
                                j++;
                            }

                     

                            tab2.Columns[0].TotalsRowLabel = "Total_";

                            tab2.TableStyle = TableStyles.Medium2;

                            //   var StartCell = "A" +( i+5);
                            //   ws.Cells[StartCell].LoadFromDataTable(dt2, true);

                            ExcelWorksheet ws3 = pck.Workbook.Worksheets.Add("Detail");
                            //   DataTable dt = ((DataTable)this.DataSource);
                            ws3.Cells["A1"].LoadFromDataTable(dt3, true);

                            pck.Save();
                            System.Diagnostics.Process.Start(dlg.FileName);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                 
                }




            }
        }
    }
}