using System;
using System.Collections.Generic;
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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace Digiteq
{
    public partial class UC_Paymass_ProcessPeriod_Main : UserControl
    {
        #region Class Variables
        string sProcessGroup_ID = null;
        #endregion

        #region Form Load
        public UC_Paymass_ProcessPeriod_Main()
        {
            InitializeComponent();
            AppDomainInitializer(null);
        }

        public UC_Paymass_ProcessPeriod_Main(string processGroup_ID)
        {
            InitializeComponent();
            AppDomainInitializer(processGroup_ID);
        }

        private void AppDomainInitializer(string processGroup_ID)
        {
            #region Initialize Usercontrol
            SEACC_Form.enmFormName = FormName.Payroll_ProcessPeriod_Main;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ProcessGroupID");
            dgr_Main.dt.Columns.Add("ProcessGroupCode");
            dgr_Main.dt.Columns.Add("ProcessPeriodID");
            dgr_Main.dt.Columns.Add("ProcessPeriodTitle");
            dgr_Main.dt.Columns.Add("StartDate");
            dgr_Main.dt.Columns.Add("EndDate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Group ID", "ProcessGroupID", 100, false);
            dgr_Main.Add_DatagridColoumn("Process Group", "ProcessGroupCode", 250);
            dgr_Main.Add_DatagridColoumn("Period ID", "ProcessPeriodID", 70, false);
            dgr_Main.Add_DatagridColoumn("Period", "ProcessPeriodTitle", 75);
            dgr_Main.Add_DatagridColoumn("Period Start", "StartDate", 75);
            dgr_Main.Add_DatagridColoumn("Period End", "EndDate", 75);
            #endregion

            sProcessGroup_ID = processGroup_ID;
            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtPeriodTitle.Tag != null && txtPeriodTitle.Tag.ToString() != "")
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_ProcessPeriod_Main detail = tbl_payMas_ProcessPeriod_Main.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtPeriodTitle.Tag.ToString()));
                            if (detail != null)
                            {
                                //detail.IsCanceled = true;
                                //detail.Date_Canceled = clsSecurity.getServerDateTime();
                                //detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                //detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_payMas_ProcessPeriod_Main oldRecord = tbl_payMas_ProcessPeriod_Main.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtPeriodTitle.Tag.ToString()));
                            if (oldRecord != null && !oldRecord.IsClosedPeriod)
                            {
                                tbl_payMas_ProcessPeriod_Main detail = new tbl_payMas_ProcessPeriod_Main(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, txtProcessGroup.Tag.ToString(), int.Parse(txtPeriodTitle.Tag.ToString()), txtPeriodTitle.Text, dtpStartDate.GetDateTime(), dtpEndDate.GetDateTime(), chkIsClosedPeriod.IsChecked);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            else
                                SEACCMessageBox.Show(MessegeBoxType.AccessDenied,"Process Period Closed");
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        tbl_payMas_ProcessPeriod_Main detail = new tbl_payMas_ProcessPeriod_Main(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtPeriodTitle.Tag.ToString()), txtPeriodTitle.Text, dtpStartDate.GetDateTime(), dtpEndDate.GetDateTime(), chkIsClosedPeriod.IsChecked);
                        detail.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }

                finally
                {
                    ClearFields();
                    RefreshGrid();
                }
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProcessGroup, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPeriodTitle, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpStartDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpEndDate, true, false);
            txtPeriodTitle.setReadOnlyStatus(false);
            txtProcessGroup.Tag = null;
            txtPeriodTitle.Tag = null;

            txtProcessGroup.Text = "";
            txtPeriodTitle.Text = "";

            dtpStartDate.SetTime(DateTime.Now);
            dtpEndDate.SetTime(DateTime.Now);

            chkIsClosedPeriod.IsChecked = false;

            if (sProcessGroup_ID != null)
            {
                txtProcessGroup.Tag = sProcessGroup_ID;
                txtProcessGroup.Text = clsRef_Name.get_processGroup_Name(sProcessGroup_ID);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_payMas_ProcessPeriod_Main detail in tbl_payMas_ProcessPeriod_Main.SelectAll().OrderByDescending(r => r.StartDate.Date).ThenBy(r => r.ProcessGroup_ID))
                {
                    if (txtProcessGroup.Tag != null)
                    {
                        if (txtProcessGroup.Tag.ToString() != detail.ProcessGroup_ID)
                            continue;
                    }
                    dgr_Main.dt.Rows.Add(detail.ProcessGroup_ID, clsRef_Name.get_PayrollProcessGroup_Title(detail.ProcessGroup_ID), detail.ProcessPeriod_ID, detail.ProcessPeriod_Title, detail.StartDate.ToString(clsConfig.Format_Date), detail.EndDate.ToString(clsConfig.Format_Date));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
                if (!ChekValidity_DuplicateNames())
                    bStatus = false;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtPeriodTitle))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtPeriodTitle.Tag = SEACC_Form.getAutoGeneratedCode();
                tbl_payMas_ProcessPeriod_Main detail = tbl_payMas_ProcessPeriod_Main.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtPeriodTitle.Tag.ToString()));
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            //foreach (tbl_payMas_ProcessPeriod_Main detail1 in tbl_payMas_ProcessPeriod_Main.SelectAll().Where(p => p.ProcessPeriod_Title == txtPeriodTitle.Text && p.ProcessPeriod_ID != int.Parse(txtPeriodTitle.Tag.ToString())))
            //{
            //    if (detail1 != null)
            //    {
            //        SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
            //        bStatus = false;
            //        break;
            //    }
            //}
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sProsessGroup_ID, int sProcessPeriod_ID)
        {
            try
            {
                if (sProsessGroup_ID != null)
                {
                    tbl_payMas_ProcessPeriod_Main detail = tbl_payMas_ProcessPeriod_Main.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sProsessGroup_ID, sProcessPeriod_ID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtProcessGroup.IsEnabled = false;
                        //txtPeriodTitle.setReadOnlyStatus(true);

                        txtPeriodTitle.Tag = detail.ProcessPeriod_ID;
                        txtProcessGroup.Tag = detail.ProcessGroup_ID;

                        txtProcessGroup.Text = clsRef_Name.get_PayrollProcessGroup_Title(detail.ProcessGroup_ID);
                        txtPeriodTitle.Text = detail.ProcessPeriod_Title;
                        dtpStartDate.SetTime(detail.StartDate);
                        dtpEndDate.SetTime(detail.EndDate);

                        chkIsClosedPeriod.IsChecked = detail.IsClosedPeriod;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string sProcessGroupID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int iperiodID = int.Parse((dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);

                    fillDetails(sProcessGroupID, iperiodID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtPeriodTitle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtProcessGroup.Tag != null && txtProcessGroup.Text != "")
            {
                lstParameeters.Add(txtProcessGroup.Tag.ToString());
            }

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessPeriodMain);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0], int.Parse(lstResult[2]));
                RefreshGrid();
            }
        }

        private void txtProcessGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessGroup);
            if (RowDataSearch.DialogResult == true)
            {
                txtProcessGroup.Tag = lstResult[0];
                txtProcessGroup.Text = lstResult[1];
                RefreshGrid();
            }
        }
        #endregion

        private void lblProcessPeriod_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txtPeriodTitle.Tag != null)
            {
                UC_ProcessPeriod_Sub UC = new UC_ProcessPeriod_Sub(txtProcessGroup.Tag.ToString(), int.Parse(txtPeriodTitle.Tag.ToString()));
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
            else
            {
                SEACCMessageBox.Show("Oops....", " Please Select a Main Process Period...", MessageBoxButton.OK);
            }
        }
    }
}
