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
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace Digiteq.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_HRWeek.xaml
    /// </summary>
    public partial class UC_HRWeek : UserControl
    {
        #region Form Load
        public UC_HRWeek()
        {
            #region Initialize Form
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_Week;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("YearID");
            dgr_Main.dt.Columns.Add("WeekID");
            dgr_Main.dt.Columns.Add("StartDate");
            dgr_Main.dt.Columns.Add("WorkingDays");
            dgr_Main.dt.Columns.Add("Target");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Year Code", "YearID", 80);
            dgr_Main.Add_DatagridColoumn("Week", "WeekID", 80);
            dgr_Main.Add_DatagridColoumn("Start Date", "StartDate", 120);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Working Days", "WorkingDays", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Target", "Target", 120, true, true);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_HRMonth_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txt_WeekID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_hrPeriod_Week Details = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text), int.Parse(txt_WeekID.Text));
                            if (Details != null)
                            {
                                Details.IsCanceled = true;
                                Details.Date_Canceled = clsSecurity.getServerDateTime();
                                Details.UserID_Canceled = clsSecurity.UserIDLoged;
                                Details.TerminalID_Canceled = clsSecurity.TerminalID;
                                Details.Update();

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
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
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
                            if (CheckParollStarted_CC())
                            {
                                tbl_hrPeriod_Week oldRecord = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text), int.Parse(txt_WeekID.Text));
                                if (oldRecord != null)
                                {
                                    tbl_hrPeriod_Week UpdateData = new tbl_hrPeriod_Week(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text), int.Parse(txt_WeekID.Text), dtp_StartDate.GetDateTime().Date, dtp_EndDate.GetDateTime().Date, decimal.Parse(txtWorkingdaysMan.Text), decimal.Parse(txtTarget.Text), oldRecord.WeekStatus_ID, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                    UpdateData.Update();
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        tbl_hrPeriod_Week InsertData = new tbl_hrPeriod_Week(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text), int.Parse(txt_WeekID.Text), dtp_StartDate.GetDateTime().Date, dtp_EndDate.GetDateTime().Date, decimal.Parse(txtWorkingdaysMan.Text), decimal.Parse(txtTarget.Text), (int)CC_WeekStatus.New, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        InsertData.Insert();
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
                    RefreshGrid();
                    ClearFields();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dtp_StartDate.SetTime(DateTime.Now);
            dtp_EndDate.SetTime(DateTime.Now);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txt_WeekID, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtYearID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWorkingdaysMan, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtTarget, true, true, true);

            txt_WeekID.Text = "";
            txt_WeekID.Tag = null;
            txtYearID.Text = "";
            txtWorkingdaysMan.Text = "0";
            txtTarget.Text = "0";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dgr_Main.dt.Clear();
            foreach (tbl_hrPeriod_Week item in tbl_hrPeriod_Week.SelectAll().Where(p => p.IsCanceled == false))
            {
                dgr_Main.dt.Rows.Add(item.Year_ID, item.Week_ID.ToString("00"), item.StartDate.ToString(clsConfig.Format_Date), item.WerkingDays_Mandatory, item.Target);
            }
            dgr_Main.RefreshGrid();
        }
        #endregion

        #region Check Validity
        public bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtYearID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txt_WeekID))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrPeriod_Week oDetail = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text.Trim()), int.Parse(txt_WeekID.Text.Trim()));
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckParollStarted_CC()
        {
            bool bStatus = true;
            try
            {
                if (tbl_ccTxDailyWorkingProgress.SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Tag.ToString()), int.Parse(txt_WeekID.Tag.ToString())).Count > 0)
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Data Already Processed!", "Data Already Processed for this period", MessageBoxButton.OK, "Red");
                }
            } catch (Exception ex)
            {}

            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails(int sIDy, int sIDw)
        {
            try
            {
                tbl_hrPeriod_Week details = tbl_hrPeriod_Week.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sIDy, sIDw);
                if (details != null)
                {
                    SEACC_Form.IsUpdateMode = true;
                    txt_WeekID.IsEnabled = false;

                    txtYearID.Text = details.Year_ID.ToString();
                    txtYearID.Tag = details.Year_ID.ToString();

                    txt_WeekID.Text = details.Week_ID.ToString();
                    txt_WeekID.Tag = details.Week_ID.ToString();

                    dtp_StartDate.SetTime(details.StartDate.Date);
                    dtp_EndDate.SetTime(details.EndDate.Date);
                    txtWorkingdaysMan.Text = details.WerkingDays_Mandatory.ToString();
                    txtTarget.Text = details.Target.ToString();


                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string GridID1 = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(int.Parse(GridID), int.Parse(GridID1));
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtYearID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txtYearID.Text = lstResult[0];
            }
        }
        private void txt_WeekID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtYearID.Text != "")
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.HRWeek);
                if (RowDataSearch.DialogResult == true)
                {
                    txt_WeekID.Text = lstResult[1];
                    string s = lstResult[2];
                    fillDetails(int.Parse(lstResult[0]), int.Parse(lstResult[1]));
                }
            }
            else
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.HRWeek);
                if (RowDataSearch.DialogResult == true)
                {
                    txt_WeekID.Text = lstResult[0];
                    string s = lstResult[2];
                    fillDetails(int.Parse(lstResult[0]), int.Parse(lstResult[1]));
                }
            }
        }
        #endregion

    }
}
