using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for UC_PayrollControlPannel.xaml
    /// </summary>
    public partial class UC_PayrollControlPannel : UserControl
    {
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
            dgr_Sub_Period.dt.Columns.Add("IsClosed");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            #endregion

            #region Initialize Process Group DataGrid
            dgr_Main_Group.Add_DatagridColoumn("ID", "ProcessGroupID", 70);
            dgr_Main_Group.Add_DatagridColoumn("Group Title", "ProcessGroupTitle", 270);
            dgr_Main_Group.Add_DatagridColoumn("Pay Period", "PayPeriod", 70, false);
            dgr_Main_Group.grdMain.RowHeight = 20;
            #endregion

            #region Initialize Process  Period DataGrid
            dgr_Sub_Period.Add_DatagridColoumn("Group ID", "ProcessGroupID", 70, false);
            dgr_Sub_Period.Add_DatagridColoumn("Group Title", "ProcessGroupCode", 110);
            dgr_Sub_Period.Add_DatagridColoumn("Main Period ID", "ProcessMainPeriodID", 100, false);
            dgr_Sub_Period.Add_DatagridColoumn("Main Period", "ProcessMainPeriodTitle", 150);
            dgr_Sub_Period.Add_DatagridColoumn("Sub Period ID", "ProcessSubPeriodID", 100, false);
            dgr_Sub_Period.Add_DatagridColoumn("Sub Period", "ProcessSubPeriodTitle", 150);
            dgr_Sub_Period.Add_DatagridColoumn("Period Start", "StartDate", 100);
            dgr_Sub_Period.Add_DatagridColoumn("Period End", "EndDate", 100);
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

                foreach (tbl_payMas_ProcessGroup detail in tbl_payMas_ProcessGroup.SelectAll().Where(p => p.IsCanceled == false && p.ProcessGroup_ID != "Default"))
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
                foreach (tbl_payMas_ProcessPeriod_Sub detail in tbl_payMas_ProcessPeriod_Sub.SelectAll().Where(p => p.Company_ID == clsSecurity.CompanyID && p.CompanyBranch_ID == clsSecurity.BranchID && p.ProcessGroup_ID == sGrpID).OrderBy(r => r.StartDate))
                {
                    dgr_Sub_Period.dt.Rows.Add(detail.ProcessGroup_ID, clsRef_Name.get_PayrollProcessGroup_Title(detail.ProcessGroup_ID), detail.ProcessPeriod_ID, clsRef_Name.get_processPeriodMain_Name(detail.ProcessPeriod_ID.ToString()), detail.ProcessPeriod_Sub_ID, detail.ProcessPeriod_Sub_Title, detail.StartDate.ToString(clsConfig.Format_Date), detail.EndDate.ToString(clsConfig.Format_Date), (detail.IsClosedPeriod) ? "\uE0A2" : "\uE003");
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
                object item = dgr_Sub_Period.grdMain.SelectedItem;
                if (item != null)
                {
                    string sGrid_GroupID = (dgr_Sub_Period.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string sGrid_Period_MainID = (dgr_Sub_Period.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string sGrid_Period_SubID = (dgr_Sub_Period.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    string sClosed = (dgr_Sub_Period.grdMain.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
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
                        if ((iColumnIndex == 8 || iColumnIndex == 9) && !bClosed)
                        {
                            tbl_payMas_ProcessPeriod_Sub oSubPeriod = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sGrid_GroupID, int.Parse(sGrid_Period_MainID), int.Parse(sGrid_Period_SubID));
                            if (oSubPeriod != null )
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
                    else
                        SEACCMessageBox.Show("Attention!!!", "Please close the Previous Process Period", MessageBoxButton.OK, "Red");

                }
            }
            catch (Exception ex)
            {
                //SEACCExeption.Show(ex);
            }
        }
        #endregion
    }
}
