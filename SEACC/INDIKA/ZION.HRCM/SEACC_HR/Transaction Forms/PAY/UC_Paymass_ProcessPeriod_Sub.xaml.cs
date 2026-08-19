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
    /// <summary>
    /// Interaction logic for UC_ProcessPeriod_Sub.xaml
    /// </summary>
    public partial class UC_ProcessPeriod_Sub : UserControl
    {
        #region Class Variables
        string sProcessGroup_ID = null;
        int iPeriod_ID_Main = -1;
        #endregion

        #region Form Load
        public UC_ProcessPeriod_Sub()
        {
            InitializeComponent();
            AppDomainInitializer(null, -1);
        }

        public UC_ProcessPeriod_Sub(string processGroup_ID, int processPeriodMain)
        {
            InitializeComponent();
            sProcessGroup_ID = processGroup_ID;
            iPeriod_ID_Main = processPeriodMain;
            AppDomainInitializer(processGroup_ID, processPeriodMain);
        }

        private void AppDomainInitializer(string processGroup_ID, int processPeriodMain)
        {
            #region Initialize Usercontrol
            SEACC_Form.enmFormName = FormName.Payroll_ProcessPeriod_Sub;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ProcessGroupID");
            dgr_Main.dt.Columns.Add("ProcessGroupCode");
            dgr_Main.dt.Columns.Add("ProcessPeriodID");
            dgr_Main.dt.Columns.Add("ProcessPeriodTitle");
            dgr_Main.dt.Columns.Add("ProcessPeriodSubID");
            dgr_Main.dt.Columns.Add("ProcessPeriodSubTitle");
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
            dgr_Main.Add_DatagridColoumn("Group Code", "ProcessGroupCode", 200);
            dgr_Main.Add_DatagridColoumn("Main Period ID", "ProcessPeriodID", 75, false);
            dgr_Main.Add_DatagridColoumn("Main Period", "ProcessPeriodTitle", 75);
            dgr_Main.Add_DatagridColoumn("Sub Period ID", "ProcessPeriodSubID", 70, false);
            dgr_Main.Add_DatagridColoumn("Sub Period", "ProcessPeriodSubTitle", 75);
            dgr_Main.Add_DatagridColoumn("Period Start", "StartDate", 75);
            dgr_Main.Add_DatagridColoumn("Period End", "EndDate", 75);
            #endregion

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
                    if (txtPeriodSubTitle.Tag != null && txtPeriodSubTitle.Tag.ToString() != "")
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_ProcessPeriod_Sub detail = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtProcessPeriod.Tag.ToString()), int.Parse(txtPeriodSubTitle.Tag.ToString()));
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
                            tbl_payMas_ProcessPeriod_Sub oldRecord = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtProcessPeriod.Tag.ToString()), int.Parse(txtPeriodSubTitle.Tag.ToString()));
                            if (oldRecord != null && !oldRecord.IsClosedPeriod )
                            {
                                tbl_payMas_ProcessPeriod_Sub detail = new tbl_payMas_ProcessPeriod_Sub(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, txtProcessGroup.Tag.ToString(), int.Parse(txtProcessPeriod.Tag.ToString()), int.Parse(txtPeriodSubTitle.Tag.ToString()), txtPeriodSubTitle.Text, dtpStartDate.GetDateTime(), dtpEndDate.GetDateTime(), chkIsClosedPeriod.IsChecked);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            else
                                SEACCMessageBox.Show(MessegeBoxType.AccessDenied, "Process Period Closed");
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        tbl_payMas_ProcessPeriod_Sub detail = new tbl_payMas_ProcessPeriod_Sub(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtProcessPeriod.Tag.ToString()), int.Parse(txtPeriodSubTitle.Tag.ToString()), txtPeriodSubTitle.Text, dtpStartDate.GetDateTime(), dtpEndDate.GetDateTime(), chkIsClosedPeriod.IsChecked);
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProcessPeriod, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPeriodSubTitle, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpStartDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpEndDate, true, false);

            txtProcessGroup.Tag = null;
            txtProcessPeriod.Tag = null;
            txtPeriodSubTitle.Tag = null;

            txtProcessGroup.Text = "";
            txtProcessPeriod.Text = "";
            txtPeriodSubTitle.Text = "";

            dtpStartDate.SetTime(DateTime.Now);
            dtpEndDate.SetTime(DateTime.Now);

            chkIsClosedPeriod.IsChecked = false;

            if (sProcessGroup_ID != null)
            {
                txtProcessGroup.Tag = sProcessGroup_ID;
                txtProcessGroup.Text = clsRef_Name.get_processGroup_Name(sProcessGroup_ID);

                if (iPeriod_ID_Main >= 0)
                {
                    txtProcessPeriod.Tag = iPeriod_ID_Main;
                    txtProcessPeriod.Text = clsRef_Name.get_processPeriodMain_Name(iPeriod_ID_Main.ToString());
                }
            }

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();


                foreach (tbl_payMas_ProcessPeriod_Sub detail in tbl_payMas_ProcessPeriod_Sub.SelectAll().Where(p=>p.ProcessPeriod_Sub_Title!="default").OrderByDescending(r => r.StartDate.Date).ThenBy(r => r.ProcessGroup_ID))
                {
                    if (txtProcessGroup.Tag != null)
                    {
                        if (txtProcessGroup.Tag.ToString() != detail.ProcessGroup_ID)
                            continue;
                    }

                    if (txtProcessPeriod.Tag != null)
                    {
                        if (txtProcessPeriod.Tag.ToString() != detail.ProcessPeriod_ID.ToString())
                            continue;
                    }

                    dgr_Main.dt.Rows.Add(detail.ProcessGroup_ID, clsRef_Name.get_PayrollProcessGroup_Title(detail.ProcessGroup_ID), detail.ProcessPeriod_ID, clsRef_Name.get_PayrollProcessGroup_SubTitle(detail.ProcessPeriod_ID.ToString()), detail.ProcessPeriod_Sub_ID, detail.ProcessPeriod_Sub_Title, detail.StartDate.ToString(clsConfig.Format_Date), detail.EndDate.ToString(clsConfig.Format_Date));
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
                if (!clsValidation.Validate_EmptyValue(txtPeriodSubTitle))
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
                    txtPeriodSubTitle.Tag = SEACC_Form.getAutoGeneratedCode();
                tbl_payMas_ProcessPeriod_Sub detail = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtProcessGroup.Tag.ToString(), int.Parse(txtProcessPeriod.Tag.ToString()), int.Parse(txtPeriodSubTitle.Tag.ToString()));
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
            //foreach (tbl_payMas_ProcessPeriod_Sub detail1 in tbl_payMas_ProcessPeriod_Sub.SelectAll().Where(p => p.ProcessPeriod_Sub_Title == txtPeriodSubTitle.Text && p.ProcessPeriod_Sub_ID != int.Parse(txtPeriodSubTitle.Tag.ToString())))
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
        private void fillDetails(string sID, int pID, int psID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_payMas_ProcessPeriod_Sub detail = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID, pID, psID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtPeriodSubTitle.Tag = detail.ProcessPeriod_Sub_ID;
                        txtProcessGroup.Tag = detail.ProcessGroup_ID;
                        txtProcessPeriod.Tag = detail.ProcessPeriod_ID;

                        txtProcessGroup.Text = clsRef_Name.get_PayrollProcessGroup_Title(detail.ProcessGroup_ID);
                        txtProcessPeriod.Text = clsRef_Name.get_PayrollProcessGroup_SubTitle(detail.ProcessPeriod_ID.ToString());
                        txtPeriodSubTitle.Text = detail.ProcessPeriod_Sub_Title;
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
                    string GID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int pID = int.Parse((dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                    int psID = int.Parse((dgr_Main.grdMain.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);

                    fillDetails(GID, pID, psID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
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

        private void txtProcessPeriod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtProcessGroup.Tag != null)
            {
                lstParameeters.Add(txtProcessGroup.Tag.ToString());
            }

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessPeriodMain);
            if (RowDataSearch.DialogResult == true)
            {
                txtProcessGroup.Tag = lstResult[0];
                txtProcessGroup.Text = lstResult[1];
                txtProcessPeriod.Tag = lstResult[2];
                txtProcessPeriod.Text = lstResult[3];
                RefreshGrid();
            }

        }

        private void txtPeriodSubTitle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            List<string> lstParameeters = new List<string>();
            if (txtProcessGroup.Tag != null)
            {
                lstParameeters.Add(txtProcessGroup.Tag.ToString());
                if (txtProcessPeriod.Tag != null)
                    lstParameeters.Add(txtProcessPeriod.Tag.ToString());
            }

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessPeriodSub);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0], int.Parse(lstResult[2]), int.Parse(lstResult[4]));
            }
        }

        #endregion       

        #region DateTime Change
        private void dtpStartDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (clsConfig.bEnable_MonthPayrollPeriod)
            {
                DateTime dtFromDate = dtpStartDate.GetDateTime();
                DateTime dtFirstDate = new DateTime(dtFromDate.Year, dtFromDate.Month, 1);
                DateTime dtLastDate = dtFirstDate.AddMonths(1).AddDays(-1);

                if (dtpStartDate.GetDateTime().Date == dtFirstDate.Date)
                    dtpEndDate.SetTime(dtLastDate.Date);
            }
        }

        private void dtpEndDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (clsConfig.bEnable_MonthPayrollPeriod)
            {
                DateTime dtToDate = dtpEndDate.GetDateTime();
                DateTime dtFirstDate = new DateTime(dtToDate.Year, dtToDate.Month, 1);
                DateTime dtLastDate = dtFirstDate.AddMonths(1).AddDays(-1);

                if (dtpEndDate.GetDateTime().Date == dtLastDate.Date)
                    dtpStartDate.SetTime(dtFirstDate.Date);
            }
        } 
        #endregion

    }
}
