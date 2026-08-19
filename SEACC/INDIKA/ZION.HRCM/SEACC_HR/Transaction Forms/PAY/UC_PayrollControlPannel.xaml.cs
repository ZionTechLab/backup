using DataTire;
using Digiteq.Common;
using Digiteq.Reports;
using Digiteq_Logic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZION.HRCM.DATA.Helpers;
using ZION.HRCM.DATA.PAY;
using ZION.HRCM.DOMAIN.PAY;

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for UC_PayrollControlPannel.xaml
    /// </summary>
    public partial class UC_PayrollControlPannel : UserControl
    {
        PayProcessData odata = new PayProcessData();

        #region Form Load
        public UC_PayrollControlPannel()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_ControlPannel;
            SEACC_Form.Initialize();

            #region Initialize Process Group Table
            dgr_Main_Group.dt.Columns.Add("ProcessGroupID");
            dgr_Main_Group.dt.Columns.Add("ProcessGroupTitle");
            dgr_Main_Group.dt.Columns.Add("PayPeriod");
            #endregion

            #region Initialize Process Period Table
            dgr_Sub_Period.dt.Columns.Add("ProcessGroupID");
            dgr_Sub_Period.dt.Columns.Add("ProcessGroupCode");
            dgr_Sub_Period.dt.Columns.Add("ProcessMainPeriodID");
            dgr_Sub_Period.dt.Columns.Add("ProcessMainPeriodTitle");
            dgr_Sub_Period.dt.Columns.Add("ProcessSubPeriodID");
            dgr_Sub_Period.dt.Columns.Add("ProcessSubPeriodTitle");
            dgr_Sub_Period.dt.Columns.Add("StartDate");
            dgr_Sub_Period.dt.Columns.Add("EndDate");
            dgr_Sub_Period.dt.Columns.Add("Preview");

            dgr_Sub_Period.dt.Columns.Add("Adj");
            dgr_Sub_Period.dt.Columns.Add("Process");
            dgr_Sub_Period.dt.Columns.Add("IsClosed");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            #endregion

            #region Initialize Process Group DataGrid
            dgr_Main_Group.Add_DatagridColoumn("ID", "ProcessGroupID", 50, false);
            dgr_Main_Group.Add_DatagridColoumn("Group Title", "ProcessGroupTitle", 270);
            dgr_Main_Group.Add_DatagridColoumn("Pay Period", "PayPeriod", 70, false);
            dgr_Main_Group.grdMain.RowHeight = 20;
            #endregion

            #region Initialize Process  Period DataGrid
            dgr_Sub_Period.Add_DatagridColoumn("Group ID", "ProcessGroupID", 70, false);
            dgr_Sub_Period.Add_DatagridColoumn("Group Title", "ProcessGroupCode", 110, false);
            dgr_Sub_Period.Add_DatagridColoumn("Main Period ID", "ProcessMainPeriodID", 100, false);
            dgr_Sub_Period.Add_DatagridColoumn("Main Period", "ProcessMainPeriodTitle", 120);
            dgr_Sub_Period.Add_DatagridColoumn("Sub Period ID", "ProcessSubPeriodID", 100, false);
            dgr_Sub_Period.Add_DatagridColoumn("Sub Period", "ProcessSubPeriodTitle", 160);
            dgr_Sub_Period.Add_DatagridColoumn("Period Start", "StartDate", 80);
            dgr_Sub_Period.Add_DatagridColoumn("Period End", "EndDate", 80);
            dgr_Sub_Period.Add_DatagridColoumn(ColoumnType.Text, "Segoe MDL2 Assets", "Adj", "Adj", 40, false, true);
            dgr_Sub_Period.Add_DatagridColoumn(ColoumnType.Text, "Segoe MDL2 Assets", "Update", "Update", 40, false, true);
            dgr_Sub_Period.Add_DatagridColoumn(ColoumnType.Text, "Segoe MDL2 Assets", "Process", "Process", 50, false, true);
            dgr_Sub_Period.Add_DatagridColoumn(ColoumnType.Text, "Segoe MDL2 Assets", "Period Closed", "IsClosed", 90, true, true);
            #endregion

            RefreshProcessGrid();
        }
        #endregion

        #region Refresh Process Grid
        private void RefreshProcessGrid()
        {
            try
            {
                dgr_Main_Group.dt.Clear();

                foreach (tbl_payMas_ProcessGroup detail in tbl_payMas_ProcessGroup.SelectAll().Where(p => p.IsCanceled == false && p.ProcessGroup_ID != "default"))
                {
                    tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, detail.ProcessGroup_ID);
                    if (oGrpPermission != null && oGrpPermission.AllowView)
                        dgr_Main_Group.dt.Rows.Add(detail.ProcessGroup_ID, detail.ProcessGroup_Title, detail.Pay_Period);
                }
                dgr_Main_Group.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Fill Period Details
        private void FillPeriodGrid(string sGrpID)
        {
            try
            {
                dgr_Sub_Period.dt.Clear();



                foreach (tbl_payMas_ProcessPeriod_Main main in tbl_payMas_ProcessPeriod_Main.SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sGrpID).Where(p => !p.IsClosedPeriod))
                {
                    foreach (tbl_payMas_ProcessPeriod_Sub detail in tbl_payMas_ProcessPeriod_Sub.SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sGrpID, main.ProcessPeriod_ID).OrderBy(r => r.StartDate))
                    {
                        dgr_Sub_Period.dt.Rows.Add(detail.ProcessGroup_ID, clsRef_Name.get_PayrollProcessGroup_Title(detail.ProcessGroup_ID), detail.ProcessPeriod_ID, clsRef_Name.get_processPeriodMain_Name(detail.ProcessPeriod_ID.ToString()), detail.ProcessPeriod_Sub_ID, detail.ProcessPeriod_Sub_Title, detail.StartDate.ToString(clsConfig.Format_Date), detail.EndDate.ToString(clsConfig.Format_Date),
                            (detail.IsClosedPeriod) ? "" : "\uE773",
                            (detail.IsClosedPeriod) ? "" : "\uE771",
                            (detail.IsClosedPeriod) ? "" : "\uE792",
                            (detail.IsClosedPeriod) ? "\uE0A2" : "\uE003");
                    }
                }

                dgr_Sub_Period.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_Group_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main_Group.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main_Group.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    FillPeriodGrid(GridID);
                    ShowHideButtons(true);
                }
            }
            catch (Exception ex)
            {
                //SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_Period_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Sub_Period.GetCurrentCell();
                int iColumnIndex = vDG_Cell.Column.DisplayIndex;
                string ColomnHeader = vDG_Cell.Column.Header.ToString();
                object item = dgr_Sub_Period.grdMain.SelectedItem;
                if (item != null)
                {
                    string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    string sClosed = (dgr_Sub_Period.grdMain.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                    bool bClosed = (sClosed == "\uE0A2");

                    #region Check Previous Period Closed or not
                    string sQry = "exec sp_Payroll_CheckPreviousPeriodClosed '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + sGrid_GroupID + "' , '" + sGrid_Period_MainID + "', '" + sGrid_Period_SubID + "' ";
                    DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];
                    bool bProcessed_PreviosPeriod = true;
                    if (dt_result.Rows.Count > 0)
                        bProcessed_PreviosPeriod = bool.Parse(dt_result.Rows[0]["isClosedPeriod"].ToString());
                    #endregion

                    if (bProcessed_PreviosPeriod)
                    {
                        ShowHideButtons(bClosed);


                        if (ColomnHeader == "Period Closed" && !bClosed)
                        {
                            tbl_payMas_ProcessPeriod_Sub oSubPeriod = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGrid_GroupID, int.Parse(sGrid_Period_MainID), int.Parse(sGrid_Period_SubID));
                            if (oSubPeriod != null)
                            {
                                List<tbl_payTxSIPRawData> oRawData = tbl_payTxSIPRawData.SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID_ProcessPeriod_Sub_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sGrid_GroupID, int.Parse(sGrid_Period_MainID), int.Parse(sGrid_Period_SubID)).ToList();
                                if (oRawData.Count > 0)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "Are you sure you want to close this period " + oSubPeriod.ProcessPeriod_Sub_Title + " ?\n Once you close the period, you can not recover the payroll data", MessageBoxButton.YesNo, "#FF5B6B76");
                                    if (bMessegeBoxResult)
                                    {
                                        oSubPeriod.IsClosedPeriod = true;
                                        oSubPeriod.Update();
                                    }
                                    dgr_Main_Group_MouseLeftButtonUp1(null, null);
                                }
                                else
                                    SEACCMessageBox.Show("Attention!!!", "Please process the period before closed the period", MessageBoxButton.OK, "Red");
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                        SEACCMessageBox.Show("Attention!!!", "Please close the Previous Process Period", MessageBoxButton.OK, "Red");

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion


        private void ShowHideButtons(bool isPeriodClose)
        {
            btnProcess.IsEnabled = !isPeriodClose;
            btnAdj.IsEnabled = !isPeriodClose;
        }

        private void btnAdj_Click(object sender, RoutedEventArgs e)
        {
            //   var vDG_Cell = dgr_Sub_Period.GetCurrentCell();
            //    int iColumnIndex = vDG_Cell.Column.DisplayIndex;
            //    string ColomnHeader = vDG_Cell.Column.Header.ToString();
            object item = dgr_Sub_Period.grdMain.SelectedItem;
            if (item != null)
            {
                string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;


                var frm = new frm_Employee_SalaryAddustment(sGrid_GroupID, sGrid_Period_SubID);
                frm.ShowDialog();
            }
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            //      var vDG_Cell = dgr_Sub_Period.GetCurrentCell();
            //   int iColumnIndex = vDG_Cell.Column.DisplayIndex;
            //   string ColomnHeader = vDG_Cell.Column.Header.ToString();
            try
            {
                object item = dgr_Sub_Period.grdMain.SelectedItem;
                if (item != null)
                {
                    string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;


                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "Are you sure to procced?", MessageBoxButton.YesNo);
                        if (!bMessegeBoxResult)
                        {
                            return;
                        }
                        PayProcessData oData = new PayProcessData();

                        var para = new PayProcess_Para();
                        para.processGroup_ID = sGrid_GroupID;
                        para.processPeriod_ID = int.Parse(sGrid_Period_MainID);
                        para.processPeriod_Sub_ID = int.Parse(sGrid_Period_SubID);
                        para.company_ID = clsSecurity.CompanyID;
                        para.companyBranch_ID = clsSecurity.BranchID;
                        para.User_ID = clsSecurity.UserIDLoged;
                        para.Terminal_ID = clsSecurity.TerminalID;

                        var result = oData.Save_PayRoll(para);
                        if (result.ShiftErrors.Count > 0)
                        {
                            string sMessageBody_ShiftErrorEmployees = string.Join("\n", result.ShiftErrors);
                            SEACCMessageBox.Show("Something went wrong !", "Please check Following Employee's Shift\n" + sMessageBody_ShiftErrorEmployees, MessageBoxButton.OK);
                        }
                        else if (result.AttendanceErrors.Count > 0)
                        {
                            string sMessageBody_ShiftErrorEmployees = string.Join("\n", result.AttendanceErrors);
                            SEACCMessageBox.Show("Something went wrong !", "Please check Employee's Attandance\n" + sMessageBody_ShiftErrorEmployees, MessageBoxButton.OK);
                        }
                        else if (!result.result.IsSuccess)
                            SEACCMessageBox.Show("Something went wrong !", result.result.OutMsg, MessageBoxButton.OK);
                        else
                            SEACCMessageBox.Show("Success !", result.result.OutMsg, MessageBoxButton.OK);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnToExcel_Click(object sender, RoutedEventArgs e)
        {
            object item = dgr_Sub_Period.grdMain.SelectedItem;
            if (item != null)
            {
                string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string processGroup = (dgr_Sub_Period.grdMain.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string ProsessPeriod = (dgr_Sub_Period.grdMain.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                //     int CommishionPeriod = int.Parse(txtComPeriod.Tag.ToString());
                //   if (CommishionPeriod != -1)
                {
                    string sQry = "exec sp_getRpt_SalaryRegister '" + sGrid_GroupID + "' , " + sGrid_Period_SubID + ",1";
                    DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];

                    if (dt_result.Rows.Count == 0)
                    {
                        MessageBox.Show("No records selected");
                        return;
                    }
                    var dlg = new System.Windows.Forms.SaveFileDialog();
                    dlg.DefaultExt = ".xls";
                    dlg.Filter = "Text documents (.xls)|*.xlsx";

                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            FileInfo files = new FileInfo(dlg.FileName);

                            string filename = dlg.FileName;
                            using (ExcelPackage pck = new ExcelPackage(files))
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Summary");


                                ws.Cells["A1"].Value = clsSecurity.CompanyName;
                                ws.Cells["A1"].Style.Font.Size = 14;

                                ws.Cells["A3"].Value = "Salary Register";
                                ws.Cells["A3"].Style.Font.Size = 20;

                                ws.Cells["A4"].Value = processGroup + " - " + ProsessPeriod;
                                ws.Cells["A4"].Style.Font.Size = 12;

                                ws.Cells["A5"].Value = "Printed By : " + clsSecurity.UserNameLoged + " Date : " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
                                ws.Cells["A5"].Style.Font.Size = 7;

                                ws.Cells["A7"].LoadFromDataTable(dt_result, true);
                                ExcelRange range = ws.Cells[7, 1, dt_result.Rows.Count + 7, (dt_result.Columns.Count)];
                                ExcelTable Table = ws.Tables.Add(range, "Table1");
                                //      range.au
                                range.Style.Font.Size = 8;
                                ws.Cells["7:7"].Style.WrapText = true;
                                //    ws.Cells["7:7"].Style.ShrinkToFit = true;
                                Table.ShowFilter = true;
                                Table.ShowTotal = true;

                                ws.Column(1).Width = 7;
                                ws.Column(2).Width = 7;
                                ws.Column(3).Width = 25;
                                var style = pck.Workbook.Styles.CreateNamedStyle("Tot");

                                style.Style.Font.Size = 8;
                                Table.TotalsRowCellStyle = "Tot";

                                int i = 0;
                                foreach (DataColumn dtRow in dt_result.Columns)
                                {
                                    var x = dtRow.DataType.Name.ToString();


                                    //       Table.Columns[i].Name = dtRow.ColumnName;

                                    if (dtRow.DataType == typeof(decimal))
                                    {
                                        ws.Column(i + 1).Style.Numberformat.Format = "#,##0.00_);(#,##0.00)";
                                        ws.Column(i + 1).Width = 9;
                                        Table.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                    }
                                    else if (dtRow.DataType == typeof(Double))
                                    {
                                        Table.Columns[i + 1].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                    }
                                    else if (dtRow.DataType == typeof(string))
                                    {
                                        if (dtRow.ColumnName.Contains("Hrs."))
                                        {
                                            ws.Column(i + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        ws.Column(i + 1).Style.Numberformat.Format = "";
                                    }
                                    i++;
                                }

                                Table.Columns[0].TotalsRowLabel = "Total ";

                                Table.TableStyle = TableStyles.Light11;


                                var cel = (dt_result.Rows.Count + 11);

                                ws.Cells["B" + cel].Value = "Prepared By";
                                ws.Cells["D" + cel].Value = "Checked By";
                                ws.Cells["G" + cel].Value = "Approved By";
                                ws.Cells["J" + cel].Value = "Authorized By";

                                pck.Save();

                                System.Diagnostics.Process.Start(dlg.FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            SEACCMessageBox.Show("Something went wrong !", ex.Message, MessageBoxButton.OK);
                        }
                    }
                }
            }
        }

        private void btnDetail_Click_1(object sender, RoutedEventArgs e)
        {
            object item = dgr_Sub_Period.grdMain.SelectedItem;
            if (item != null)
            {
                string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;


                #region Open Paroll Raw Data / Saved Data
                bool bAllowSave = false;
                tbl_securityParollGroup_UserPermission oGrpPermission = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.UserIDLoged, sGrid_GroupID);
                if (oGrpPermission != null)
                    bAllowSave = oGrpPermission.AllowSave;

                frm_Employee_Payroll_RawData emp_PaySlipItems = new frm_Employee_Payroll_RawData(sGrid_GroupID, int.Parse(sGrid_Period_MainID), int.Parse(sGrid_Period_SubID), bAllowSave);
                if (emp_PaySlipItems.SEACC_Form.PermissionTO_Read)
                    emp_PaySlipItems.ShowDialog();
                dgr_Sub_Period.dt.Clear();
                dgr_Main_Group_MouseLeftButtonUp1(null, null);
                #endregion
            }
        }

        private void btnSH_Click(object sender, RoutedEventArgs e)
        {
            object item = dgr_Sub_Period.grdMain.SelectedItem;
            if (item == null)
                return;

            string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            string processGroup = (dgr_Sub_Period.grdMain.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            string ProsessPeriod = (dgr_Sub_Period.grdMain.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;

            int iReportID = 44;
            tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select((iReportID));
            tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.UserIDLoged, oReport.Function_ID);

            DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
            glb_dts_PAY.dt_EmpSalaryData.Clear();

            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
            glb_dts_ExportReport.dt_rptParameter.Clear();

            string sQry = "exec [dbo].[sp_getRpt_SignatureSheet] '" + sGrid_GroupID + "' , " + sGrid_Period_SubID;
            DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];
            glb_dts_PAY.dt_EmpSalaryData_Payroll.Merge(dt_result);

            glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), "", "", "", "", oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, processGroup + " - " + ProsessPeriod);

            frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
            frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
        }

        private void btnPS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgr_Sub_Period.grdMain.SelectedItem;
                if (item == null)
                    return;

                string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string processGroup = (dgr_Sub_Period.grdMain.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string ProsessPeriod = (dgr_Sub_Period.grdMain.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;

                int processPeriod_Sub = int.Parse(sGrid_Period_SubID);

                var Result = odata.getReport_PaySlip(sGrid_GroupID, processPeriod_Sub);
                if (Result != null)
                {
                    int iReportID = 74;
                    tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select((iReportID));
                    tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.UserIDLoged, oReport.Function_ID);

                    DataSets.dts_PAY glb_dts_PAY = new DataSets.dts_PAY();
                    glb_dts_PAY.dt_EmpSalaryData.Clear();

                    DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                    glb_dts_ExportReport.dt_rptParameter.Clear();

                    glb_dts_PAY.dt_EmpSalaryData.Merge(cast.ToDataTables(Result.Header));
                    glb_dts_PAY.dt_EmpSalaryData_PayslipItems.Merge(cast.ToDataTables(Result.PayItems));
                    glb_dts_PAY.dt_EmpSalaryData_PayslipItems_Statutatry.Merge(cast.ToDataTables(Result.StatutaryItems));

                    glb_dts_PAY.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), "", "", "", "", oReport.DisplayName, oReport.DisplayName2, ProsessPeriod, clsSecurity.UserNameLoged, ProsessPeriod + " - " + ProsessPeriod);

                    frm_ReportViwer_Winform frmViewer = new frm_ReportViwer_Winform();
                    frmViewer.print(oReport.ReportPath, glb_dts_PAY, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBankRegister_Click(object sender, RoutedEventArgs e)
        {
            object item = dgr_Sub_Period.grdMain.SelectedItem;
            if (item != null)
            {
                string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string processGroup = (dgr_Sub_Period.grdMain.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string ProsessPeriod = (dgr_Sub_Period.grdMain.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;

                var Result = odata.getReport_BankSalaryRegister(sGrid_GroupID, sGrid_Period_SubID);
                if (Result != null)
                {
                    var dt_result = Cast.ToDataTables(Result.Basic);
                    if (dt_result.Rows.Count == 0)
                    {
                        MessageBox.Show("No records selected");
                        return;
                    }
                    var dlg = new System.Windows.Forms.SaveFileDialog();
                    dlg.DefaultExt = ".xls";
                    dlg.Filter = "Text documents (.xls)|*.xlsx";

                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            FileInfo files = new FileInfo(dlg.FileName);

                            string filename = dlg.FileName;
                            using (ExcelPackage pck = new ExcelPackage(files))
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DETAILS SHEET");

                                ws.Cells["A1"].Value = clsSecurity.CompanyName;
                                ws.Cells["A1"].Style.Font.Size = 14;

                                ws.Cells["A3"].Value = "Salary Bank Register";
                                ws.Cells["A3"].Style.Font.Size = 20;

                                ws.Cells["A4"].Value = processGroup + " - " + ProsessPeriod;
                                ws.Cells["A4"].Style.Font.Size = 12;

                                ws.Cells["A5"].Value = "Printed By : " + clsSecurity.UserNameLoged + " Date : " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
                                ws.Cells["A5"].Style.Font.Size = 7;

                                ws.Cells["A7"].LoadFromDataTable(dt_result, true);
                                ExcelRange range = ws.Cells[7, 1, dt_result.Rows.Count + 7, (dt_result.Columns.Count)];
                                ExcelTable Table = ws.Tables.Add(range, "Table1");

                                range.Style.Font.Size = 8;
                                ws.Cells["7:7"].Style.WrapText = true;

                                Table.ShowFilter = true;
                                Table.ShowTotal = true;

                                ws.Column(1).Width = 25;
                                var style = pck.Workbook.Styles.CreateNamedStyle("Tot");

                                style.Style.Font.Size = 8;
                                Table.TotalsRowCellStyle = "Tot";

                                int i = 0;
                                foreach (DataColumn dtRow in dt_result.Columns)
                                {
                                    var x = dtRow.DataType.Name.ToString();

                                    if (dtRow.DataType == typeof(decimal))
                                    {
                                        ws.Column(i).Style.Numberformat.Format = "#,##0.00_);(#,##0.00)";
                                        ws.Column(i).Width = 9;
                                        Table.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                    }
                                    else if (dtRow.DataType == typeof(Double))
                                    {
                                        try
                                        {
                                            ws.Column(i).Style.Numberformat.Format = "#,##0.00_);(#,##0.00)";
                                            Table.Columns[i].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                    i++;
                                }

                                Table.Columns[0].TotalsRowLabel = "Total ";

                                Table.TableStyle = TableStyles.Light11;


                                var dt_result2 = Cast.ToDataTables(Result.Allowance);
                                var cel = 7 + Result.Basic.Count + 3;
                                ws.Cells["A" + cel].LoadFromDataTable(dt_result2, true);
                                ExcelRange range2 = ws.Cells[cel, 1, dt_result2.Rows.Count + cel, (dt_result2.Columns.Count)];
                                ExcelTable Table2 = ws.Tables.Add(range2, "Table2");
  
                                range2.Style.Font.Size = 8;
                                Table2.ShowFilter = true;
                                Table2.ShowTotal = true;
                                Table2.TotalsRowCellStyle = "Tot";

                                int j = 0;
                                foreach (DataColumn dtRow in dt_result2.Columns)
                                {
                                    var x = dtRow.DataType.Name.ToString();

                                    if (dtRow.DataType == typeof(decimal))
                                    {
                                        Table2.Columns[j].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                    }
                                    else if (dtRow.DataType == typeof(Double))
                                    {
                                        try
                                        {
                                            Table2.Columns[j].TotalsRowFormula = "SUBTOTAL(109,[" + dtRow.ColumnName + "])"; //102 = Count 
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }

                                    j++;
                                }

                                Table2.Columns[0].TotalsRowLabel = "Total ";

                                Table2.TableStyle = TableStyles.Light11;

                                var celX = (dt_result.Rows.Count+ dt_result2.Rows.Count + 14);

                                ws.Cells["B" + celX].Value = "Prepared By";
                                ws.Cells["D" + celX].Value = "Checked By";
                                ws.Cells["G" + celX].Value = "Approved By";
                                ws.Cells["J" + celX].Value = "Authorized By";



                                pck.Save();

                                System.Diagnostics.Process.Start(dlg.FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            SEACCMessageBox.Show("Something went wrong !", ex.Message, MessageBoxButton.OK);
                        }
                    }
                }
            }
        }
    }
}