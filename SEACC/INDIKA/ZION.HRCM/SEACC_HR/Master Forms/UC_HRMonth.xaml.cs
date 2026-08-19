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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_HRMonth.xaml
    /// </summary>
    public partial class UC_HRMonth : UserControl
    {
        #region Form Load
        public UC_HRMonth()
        {
            #region Initialize Form
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_Month;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("YearID");
            dgr_Main.dt.Columns.Add("MonthID");
            dgr_Main.dt.Columns.Add("Title");
            dgr_Main.dt.Columns.Add("StartDate");
            dgr_Main.dt.Columns.Add("EndDate");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Year Code", "YearID", 80);
            dgr_Main.Add_DatagridColoumn("Month", "MonthID", 80);
            dgr_Main.Add_DatagridColoumn("Title", "Title", 100);
            dgr_Main.Add_DatagridColoumn("Start Date", "StartDate", 120);
            dgr_Main.Add_DatagridColoumn("End Date", "EndDate", 120);
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
                    if (txt_MonthID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_hrPeriod_Month Details = tbl_hrPeriod_Month.Select(int.Parse(txtYearID.Text), int.Parse(txt_MonthID.Text), clsSecurity.CompanyID, clsSecurity.BranchID);
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
                            tbl_hrPeriod_Month oldRecord = tbl_hrPeriod_Month.Select(int.Parse(txtYearID.Text), int.Parse(txt_MonthID.Text), clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (oldRecord != null)
                            {
                                tbl_hrPeriod_Month UpdateData = new tbl_hrPeriod_Month(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text), int.Parse(txt_MonthID.Text), txtTitle.Text, dtp_StartDate.GetDateTime(), dtp_EndDate.GetDateTime(), oldRecord.Status, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                UpdateData.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        tbl_hrPeriod_Month InsertData = new tbl_hrPeriod_Month(clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(txtYearID.Text), int.Parse(txt_MonthID.Text), txtTitle.Text, dtp_StartDate.GetDateTime(), dtp_EndDate.GetDateTime(), 0, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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

            dtp_EndDate.SetTime(DateTime.Now);
            dtp_StartDate.SetTime(DateTime.Now);
            cls_Formater.SetEnableDisable_LableTextbox(txt_MonthID, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtYearID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTitle, true, false, true);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtp_EndDate, true);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtp_StartDate, true);

            txt_MonthID.Text = "";
            txt_MonthID.Text = "";
            txt_MonthID.Tag = null;
            txtYearID.Text = "";
            txtTitle.Text = "";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dgr_Main.dt.Clear();
            foreach (tbl_hrPeriod_Month item in tbl_hrPeriod_Month.SelectAll().Where(p => p.IsCanceled == false))
            {
                dgr_Main.dt.Rows.Add(item.Year_ID, item.Month_ID.ToString("00"), item.Month_Name, item.Month_startDate.ToString(clsConfig.Format_Date), item.Month_endDate.ToString(clsConfig.Format_Date));
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
                if (CheckValidity_DuplicateFiled())
                {
                    if (CheckValidity_Date())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtYearID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txt_MonthID))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrPeriod_Month oDetail = tbl_hrPeriod_Month.Select(int.Parse(txtYearID.Text.Trim()), int.Parse(txt_MonthID.Text.Trim()), clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckValidity_Date()
        {
            bool bStatus = true;
            if (dtp_StartDate.GetDateTime() > dtp_EndDate.GetDateTime())
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops", "Invalied Date Range", MessageBoxButton.OK);
            }

            return bStatus;

        }
        #endregion

        #region Fill Details
        private void fillDetails(int sID1, int sID2)
        {
            try
            {
                tbl_hrPeriod_Month details = tbl_hrPeriod_Month.Select(sID1, sID2, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (details != null)
                {
                    SEACC_Form.IsUpdateMode = true;
                    txtYearID.Text = details.Year_ID.ToString();
                    txt_MonthID.IsEnabled = false;
                    txtYearID.Tag = details.Year_ID.ToString();
                    txt_MonthID.Text = details.Month_ID.ToString();
                    txt_MonthID.Tag = details.Month_ID.ToString();
                    txtTitle.Text = details.Month_Name;
                    dtp_StartDate.SetTime(details.Month_startDate);
                    dtp_EndDate.SetTime(details.Month_endDate);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void ddd_MouseLeftButtonUp1(object sender, EventArgs e)
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

        private void txt_MonthID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtYearID.Text != "")
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.HRMonth_BY_Year);
                if (RowDataSearch.DialogResult == true)
                {
                    txt_MonthID.Text = lstResult[0];
                    string s = lstResult[2];
                    fillDetails(int.Parse(lstResult[2]), int.Parse(lstResult[0]));
                }
            }
            else
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.HRMonth);
                if (RowDataSearch.DialogResult == true)
                {
                    txt_MonthID.Text = lstResult[0];
                    string s = lstResult[2];
                    fillDetails(int.Parse(lstResult[2]), int.Parse(lstResult[0]));
                }
            }
        }
        #endregion
    }
}
