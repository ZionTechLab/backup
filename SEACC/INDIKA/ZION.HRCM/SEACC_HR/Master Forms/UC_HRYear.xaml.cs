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
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_HRYear.xaml
    /// </summary>
    public partial class UC_HRYear : UserControl
    {

        #region FormLoad
        public UC_HRYear()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll__Year;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("YearID");
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
            dgr_Main.Add_DatagridColoumn("Title", "Title", 100);
            dgr_Main.Add_DatagridColoumn("Start Date", "StartDate", 120);
            dgr_Main.Add_DatagridColoumn("End Date", "EndDate", 120); 
            #endregion

            RefreshGrid();
            ClearFields();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_HRYear_SizeChanged(object sender, SizeChangedEventArgs e)
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
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtYearID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (true)
                        {
                            int iYearID = int.Parse(txtYearID.Text.Trim());
                            tbl_hrPeriod_Year Details = tbl_hrPeriod_Year.Select(clsSecurity.CompanyID,clsSecurity.BranchID, iYearID);
                            if (Details != null)
                            {
                                Details.IsCanceled = true;
                                Details.UserID_Canceled = clsSecurity.UserIDLoged;
                                Details.Date_Canceled = clsSecurity.getServerDateTime();
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
                            int iYearID = int.Parse(txtYearID.Text.Trim());
                            tbl_hrPeriod_Year oldRecord = tbl_hrPeriod_Year.Select(clsSecurity.CompanyID,clsSecurity.BranchID, iYearID);
                            if (oldRecord != null)
                            {
                                tbl_hrPeriod_Year UpdateData = new tbl_hrPeriod_Year(clsSecurity.CompanyID,clsSecurity.BranchID, iYearID, txtTitle.Text, dtp_StartDate.GetDateTime(), dtp_EndDate.GetDateTime(), 1, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                UpdateData.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtYearID.Text = SEACC_Form.getAutoGeneratedCode();
                        int iYearID = int.Parse(txtYearID.Text.Trim());
                        tbl_hrPeriod_Year InsertData = new tbl_hrPeriod_Year(clsSecurity.CompanyID, clsSecurity.BranchID, iYearID, txtTitle.Text, dtp_StartDate.GetDateTime(), dtp_EndDate.GetDateTime(), 1, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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

            cls_Formater.SetEnableDisable_LableTextbox(txtYearID, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTitle, true, false, false);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtp_StartDate, true);
           // clsCommon.SetEnableDisable_LabelDateSelector(dtp_EndDate, true);
            dtp_EndDate.SetTime(DateTime.Now);
            dtp_StartDate.SetTime(DateTime.Now);

            txtTitle.Text = "";
            txtYearID.Tag = null;
            txtYearID.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtYearID.setReadOnlyStatus(true);
                txtYearID.Text = "<Auto Generate>";
            }
            else
                txtYearID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrPeriod_Year item in tbl_hrPeriod_Year.SelectAll().Where(x => x.IsCanceled == false && x.Year_ID !=0))
                {
                    dgr_Main.dt.Rows.Add(item.Year_ID, item.Year_Name, item.Year_startDate.ToString(clsConfig.Format_Date), item.Year_endDate.ToString(clsConfig.Format_Date));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                {
                    if (CheckValidity_Dates())
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
            if (!clsValidation.Validate_EmptyValue(txtTitle))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                int iYearID = int.Parse(txtYearID.Text.Trim());
                tbl_hrPeriod_Year oDetail = tbl_hrPeriod_Year.Select(clsSecurity.CompanyID,clsSecurity.BranchID, iYearID);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckValidity_Dates()
        {
            bool bStatus = true;
            if (dtp_StartDate.GetDateTime() > dtp_EndDate.GetDateTime())
            {
                bStatus = false;
                SEACCMessageBox.Show("Oops","Invalied Date Range",MessageBoxButton.OK);
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(int sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_hrPeriod_Year details = tbl_hrPeriod_Year.Select(clsSecurity.CompanyID,clsSecurity.BranchID, sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtYearID.Text = details.Year_ID.ToString();
                        txtYearID.IsEnabled = false;
                        txtYearID.Tag = details.Year_ID;
                        txtTitle.Text = details.Year_Name;
                        dtp_StartDate.SetTime(details.Year_startDate);
                        dtp_EndDate.SetTime(details.Year_endDate);
                    } 
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion
      
        #region Grid Event
        private void grd_HRYear_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    int GridID =int.Parse( (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    fillDetails(GridID);
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
                ClearFields();
                txtYearID.Text = lstResult[0];
                fillDetails(int.Parse( lstResult[0]));
            }
        }
        #endregion
    }
}
