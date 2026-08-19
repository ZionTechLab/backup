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
using System.Data;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_ShiftMaster.xaml
    /// </summary>
    public partial class UC_ShiftMaster : UserControl
    {
        #region Form Load
        public UC_ShiftMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Shift_Creation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("ShiftID");
            dgr_Main.dt.Columns.Add("ShiftName");
            dgr_Main.dt.Columns.Add("StartTime");
            dgr_Main.dt.Columns.Add("ShiftHours");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Shift Code", "ShiftID", 80);
            dgr_Main.Add_DatagridColoumn("Name", "ShiftName", 120);
            dgr_Main.Add_DatagridColoumn("Sart Time", "StartTime", 100);
            dgr_Main.Add_DatagridColoumn("End Time", "ShiftHours", 100);
            #endregion

            ClearFields();
            RefreshGrid();

            FillDetails_ComboBox();
            FillDetails_cmb_ShiftType();
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

        #region Action Button
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
                    if (txtShiftID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_tasShiftMaster detail = tbl_tasShiftMaster.Select(txtShiftID.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
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
                SEACCExeption.Show(ex);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Variables - ShiftStatus and OT Applicable
                    bool isSundaySpecialWH = false;
                    bool isMondaySpecialWH = false;
                    bool isTuesdaySpecialWH = false;
                    bool isWednsdaySpecialWH = false;
                    bool isThusedaySpecialWH = false;
                    bool isFridaySpecialWH = false;
                    bool isSaturdaySpecialWH = false;
                    bool isOTApplicableH = false;
                    bool isEarlyOTApplicable = false;
                    bool isWeekdaySpecialOT = false;
                    bool isSaturdaySpecialOT = false;
                    bool isSundaySpecialOT = false;
                    bool isPoyaDaySpecialOT = false;
                    bool isCompanyHolidaySpecialOT = false;
                    bool isActive = false;

                    bool isOTLunchDeduction_Weekday = chk_OTLunchDeduction_Weekday.IsChecked == true ? true : false; ;
                    bool isOTLunchDeduction_Satureday = chk_OTLunchDeduction_Satureday.IsChecked == true ? true : false; ;
                    bool isOTLunchDeduction_Sunday = chk_OTLunchDeduction_Sunday.IsChecked == true ? true : false; ;
                    bool isOTLunchDeduction_Poyaday = chk_OTLunchDeduction_Poyaday.IsChecked == true ? true : false; ;
                    bool isOTLunchDeduction_ComHoliday = chk_OTLunchDeduction_CompanyHoliday.IsChecked == true ? true : false; ;

                    //isOTLunchDeduction_Weekday = chk_OTLunchDeduction_Weekday.IsChecked == true ? true : false;

                    if (chk_Sunday.IsChecked == true)
                    {
                        isSundaySpecialWH = true;
                    }
                    if (chk_Monday.IsChecked == true)
                    {
                        isMondaySpecialWH = true;
                    }
                    if (chk_Tuesday.IsChecked == true)
                    {
                        isTuesdaySpecialWH = true;
                    }
                    if (chk_Wednsday.IsChecked == true)
                    {
                        isWednsdaySpecialWH = true;
                    }
                    if (chk_Thursday.IsChecked == true)
                    {
                        isThusedaySpecialWH = true;
                    }
                    if (chk_friday.IsChecked == true)
                    {
                        isFridaySpecialWH = true;
                    }
                    if (chk_Saturday.IsChecked == true)
                    {
                        isSaturdaySpecialWH = true;
                    }
                    if (chk_OtApplicable.IsChecked == true)
                    {
                        isOTApplicableH = true;
                    }
                    if (chk_Weekday_OT.IsChecked == true)
                    {
                        isWeekdaySpecialOT = true;
                    }
                    if (chk_Saturday_OT.IsChecked == true)
                    {
                        isSaturdaySpecialOT = true;
                    }
                    if (chk_Sunday_OT.IsChecked == true)
                    {
                        isSundaySpecialOT = true;
                    }
                    if (chk_PoyaDay_OT.IsChecked == true)
                    {
                        isPoyaDaySpecialOT = true;
                    }
                    if (chk_CompanyHoliday_OT.IsChecked == true)
                    {
                        isCompanyHolidaySpecialOT = true;
                    }
                    if (shiftStatus.IsChecked == true)
                    {
                        isActive = true;
                    }
                    if (shiftStatus.IsChecked == false)
                    {
                        isActive = false;
                    }
                    if (chk_EarlyOTApplicable.IsChecked == true)
                    {
                        isEarlyOTApplicable = true;
                    }
                    #endregion

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_tasShiftMaster oldRecord = tbl_tasShiftMaster.Select(txtShiftID.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (oldRecord != null)
                            {
                                tbl_tasShiftMaster oShiftMaster = new tbl_tasShiftMaster(clsSecurity.CompanyID, clsSecurity.BranchID, txtShiftID.Text.Trim(), txtShiftName.Text, txtShiftRemarks.Text, cmb_ShiftType.GetSelectedIndex(), tp_ShiftStartTime.GetDateTime(), ts_ShiftHours.GetMinutes(), ts_ShiftHours_Min.GetMinutes(), ts_NextShiftHours.GetMinutes(), decimal.Parse(txtBaseRate.Text), ts_ShiftGracePeriod.GetMinutes(),
                                    isSundaySpecialWH, ts_sunday_ShiftHours.GetMinutes(), ts_sunday_ShiftHours_min.GetMinutes(), ts_sunday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Sunday_BaseRate.Text), ts_sunday_Sft_grace.GetMinutes(), false, false,
                                    isMondaySpecialWH, ts_Monday_ShiftHours.GetMinutes(), ts_Monday_ShiftHours_min.GetMinutes(), decimal.Parse(txt_Monday_BaseRate.Text), ts_Monday_Nxt_Shift_Hours.GetMinutes(), ts_Monday_Sft_grace.GetMinutes(), false, false,
                                    isTuesdaySpecialWH, ts_Tuesday_ShiftHours.GetMinutes(), ts_Tuesday_ShiftHours_min.GetMinutes(), ts_Tuesday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Tuesday_BaseRate.Text), ts_Tuesday_Sft_grace.GetMinutes(), false, false,
                                    isWednsdaySpecialWH, ts_Wednsday_ShiftHours.GetMinutes(), ts_Wednsday_ShiftHours_min.GetMinutes(), ts_Wednsday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Wednsday_BaseRate.Text), ts_Wednsday_Sft_grace.GetMinutes(), false, false,
                                    isThusedaySpecialWH, ts_Thuseday_ShiftHours.GetMinutes(), ts_Thuseday_ShiftHours_min.GetMinutes(), ts_Thuseday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Thuseday_BaseRate.Text), ts_Thuseday_Sft_grace.GetMinutes(), false, false,
                                    isFridaySpecialWH, ts_friday_ShiftHours.GetMinutes(), ts_friday_ShiftHours_min.GetMinutes(), ts_friday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Friday_BaseRate.Text), ts_friday_Sft_grace.GetMinutes(), false, false,
                                    isSaturdaySpecialWH, ts_saturday_ShiftHours.GetMinutes(), ts_saturday_ShiftHours_min.GetMinutes(), ts_saturday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Saturday_BaseRate.Text), ts_saturday_Sft_grace.GetMinutes(), false, false,
                                    isOTApplicableH, isEarlyOTApplicable, cmb_OTRoundMode.GetSelectedIndex(), ts_OTRoundMinutes.GetMinutes(), decimal.Parse(txtOTRate.Text), ts_OT_GracePeriod.GetMinutes(), ts_EOT_GracePeriod.GetMinutes(), ts_ShiftOtMin.GetMinutes(), ts_ShiftOTMax.GetMinutes(), isWeekdaySpecialOT, decimal.Parse(txt_Weekday_OTRate.Text), ts_Weekday_OT_grace.GetMinutes(), ts_Weekday_OT_min.GetMinutes(), ts_Weekday_OT_max.GetMinutes(), isOTLunchDeduction_Weekday,
                                    isSaturdaySpecialOT, decimal.Parse(txt_Saturday_OTRate.Text), ts_Saturday_OT_grace.GetMinutes(), ts_Saturday_OT_min.GetMinutes(), ts_Saturday_OT_max.GetMinutes(), isOTLunchDeduction_Satureday,
                                    isSundaySpecialOT, decimal.Parse(txt_Sunday_OTRate.Text), ts_Sunday_OT_grace.GetMinutes(), ts_Sunday_OT_min.GetMinutes(), ts_Sunday_OT_max.GetMinutes(), isOTLunchDeduction_Sunday,
                                    isPoyaDaySpecialOT, decimal.Parse(txt_Poyaday_OTRate.Text), ts_PoyaDay_OT_grace.GetMinutes(), ts_Poyaday_OT_min.GetMinutes(), ts_Poyaday_OT_max.GetMinutes(), isOTLunchDeduction_Poyaday,
                                    isCompanyHolidaySpecialOT, decimal.Parse(txt_CompanyHoliday_OTRate.Text), ts_CompanyHoliday_OT_grace.GetMinutes(), ts_CompanyHoliday_OT_min.GetMinutes(), ts_CompanyHoliday_OT_max.GetMinutes(), isOTLunchDeduction_ComHoliday,
                                    dtp_EffictiveDate.GetDateTime(), dtp_ExpDate.GetDateTime(), isActive,
                                    tp_LunchStartTime.GetDateTime(), ts_LunchDuration.GetMinutes(),
                                    oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                int c = cmb_ShiftType.GetSelectedIndex();

                                oShiftMaster.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtShiftID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_tasShiftMaster oShiftMaster = new tbl_tasShiftMaster(clsSecurity.CompanyID, clsSecurity.BranchID, txtShiftID.Text.Trim(), txtShiftName.Text, txtShiftRemarks.Text, cmb_ShiftType.GetSelectedIndex(), tp_ShiftStartTime.GetDateTime(), ts_ShiftHours.GetMinutes(), ts_ShiftHours_Min.GetMinutes(), ts_NextShiftHours.GetMinutes(), decimal.Parse(txtBaseRate.Text), ts_ShiftGracePeriod.GetMinutes(),
                                   isSundaySpecialWH, ts_sunday_ShiftHours.GetMinutes(), ts_sunday_ShiftHours_min.GetMinutes(), ts_sunday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Sunday_BaseRate.Text), ts_sunday_Sft_grace.GetMinutes(), false, false,
                                   isMondaySpecialWH, ts_Monday_ShiftHours.GetMinutes(), ts_Monday_ShiftHours_min.GetMinutes(), decimal.Parse(txt_Monday_BaseRate.Text), ts_Monday_Nxt_Shift_Hours.GetMinutes(), ts_Monday_Sft_grace.GetMinutes(), false, false,
                                   isTuesdaySpecialWH, ts_Tuesday_ShiftHours.GetMinutes(), ts_Tuesday_ShiftHours_min.GetMinutes(), ts_Tuesday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Tuesday_BaseRate.Text), ts_Tuesday_Sft_grace.GetMinutes(), false, false,
                                   isWednsdaySpecialWH, ts_Wednsday_ShiftHours.GetMinutes(), ts_Wednsday_ShiftHours_min.GetMinutes(), ts_Wednsday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Wednsday_BaseRate.Text), ts_Wednsday_Sft_grace.GetMinutes(), false, false,
                                   isThusedaySpecialWH, ts_Thuseday_ShiftHours.GetMinutes(), ts_Thuseday_ShiftHours_min.GetMinutes(), ts_Thuseday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Thuseday_BaseRate.Text), ts_Thuseday_Sft_grace.GetMinutes(), false, false,
                                   isFridaySpecialWH, ts_friday_ShiftHours.GetMinutes(), ts_friday_ShiftHours_min.GetMinutes(), ts_friday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Friday_BaseRate.Text), ts_friday_Sft_grace.GetMinutes(), false, false,
                                   isSaturdaySpecialWH, ts_saturday_ShiftHours.GetMinutes(), ts_saturday_ShiftHours_min.GetMinutes(), ts_saturday_Nxt_Shift_Hours.GetMinutes(), decimal.Parse(txt_Saturday_BaseRate.Text), ts_saturday_Sft_grace.GetMinutes(), false, false,
                                   isOTApplicableH, isEarlyOTApplicable, cmb_OTRoundMode.GetSelectedIndex(), ts_OTRoundMinutes.GetMinutes(), decimal.Parse(txtOTRate.Text), ts_OT_GracePeriod.GetMinutes(), ts_EOT_GracePeriod.GetMinutes(), ts_ShiftOtMin.GetMinutes(), ts_ShiftOTMax.GetMinutes(), isWeekdaySpecialOT, decimal.Parse(txt_Weekday_OTRate.Text), ts_Weekday_OT_grace.GetMinutes(), ts_Weekday_OT_min.GetMinutes(), ts_Weekday_OT_max.GetMinutes(), isOTLunchDeduction_Weekday,
                                   isSaturdaySpecialOT, decimal.Parse(txt_Saturday_OTRate.Text), ts_Saturday_OT_grace.GetMinutes(), ts_Saturday_OT_min.GetMinutes(), ts_Saturday_OT_max.GetMinutes(), isOTLunchDeduction_Satureday,
                                   isSundaySpecialOT, decimal.Parse(txt_Sunday_OTRate.Text), ts_Sunday_OT_grace.GetMinutes(), ts_Sunday_OT_min.GetMinutes(), ts_Sunday_OT_max.GetMinutes(), isOTLunchDeduction_Sunday,
                                   isPoyaDaySpecialOT, decimal.Parse(txt_Poyaday_OTRate.Text), ts_PoyaDay_OT_grace.GetMinutes(), ts_Poyaday_OT_min.GetMinutes(), ts_Poyaday_OT_max.GetMinutes(), isOTLunchDeduction_Poyaday,
                                   isCompanyHolidaySpecialOT, decimal.Parse(txt_CompanyHoliday_OTRate.Text), ts_CompanyHoliday_OT_grace.GetMinutes(), ts_CompanyHoliday_OT_min.GetMinutes(), ts_CompanyHoliday_OT_max.GetMinutes(), isOTLunchDeduction_ComHoliday, dtp_EffictiveDate.GetDateTime(), dtp_ExpDate.GetDateTime(), isActive,
                                   tp_LunchStartTime.GetDateTime(), ts_LunchDuration.GetMinutes(),
                                   false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime);

                        oShiftMaster.Insert();
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtShiftID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShiftName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShiftRemarks, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOTRate, true, false, false);

            cls_Formater.SetEnableDisable_LableTimePicker(tp_ShiftStartTime, true, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_ShiftHours, true);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_ShiftHours_Min, true);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_NextShiftHours, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtBaseRate, true, true, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_ShiftGracePeriod, true);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_OT_GracePeriod, true);

            cls_Formater.SetEnableDisable_CheckBox(chk_Sunday, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Monday, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Tuesday, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Wednsday, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Thursday, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_friday, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Saturday, true);

            cls_Formater.SetEnableDisable_TimeSpan(ts_sunday_ShiftHours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Monday_ShiftHours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Tuesday_ShiftHours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Wednsday_ShiftHours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Thuseday_ShiftHours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_friday_ShiftHours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_saturday_ShiftHours, false);

            cls_Formater.SetEnableDisable_TimeSpan(ts_sunday_ShiftHours_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Monday_ShiftHours_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Tuesday_ShiftHours_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Wednsday_ShiftHours_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Thuseday_ShiftHours_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_friday_ShiftHours_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_saturday_ShiftHours_min, false);

            cls_Formater.SetEnableDisable_TimeSpan(ts_sunday_Nxt_Shift_Hours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Monday_Nxt_Shift_Hours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Tuesday_Nxt_Shift_Hours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Wednsday_Nxt_Shift_Hours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Thuseday_Nxt_Shift_Hours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_friday_Nxt_Shift_Hours, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_saturday_Nxt_Shift_Hours, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Sunday_BaseRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Monday_BaseRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Tuesday_BaseRate, false, true, false);//txt_Wednsday_BaseRate
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Wednsday_BaseRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Thuseday_BaseRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Friday_BaseRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Saturday_BaseRate, false, true, false);

            cls_Formater.SetEnableDisable_TimeSpan(ts_sunday_Sft_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Monday_Sft_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Tuesday_Sft_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Wednsday_Sft_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Thuseday_Sft_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_friday_Sft_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_saturday_Sft_grace, false);

            /*** edited by Gayan ***
             * Add lunch start time and lunch duration 2016-06-16***/
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_LunchDuration, true);
            cls_Formater.SetEnableDisable_LableTimePicker(tp_LunchStartTime, true, false);
            /**********/

            cls_Formater.SetEnableDisable_LableTextbox(txtOTRate, false, false, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_OTRoundMinutes, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_OT_GracePeriod, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_ShiftOtMin, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_ShiftOTMax, false);
            cls_Formater.SetEnableDisable_LableTimeSpan(ts_EOT_GracePeriod, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Sunday_OTRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Weekday_OTRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Poyaday_OTRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_CompanyHoliday_OTRate, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txt_Saturday_OTRate, false, true, false);

            cls_Formater.SetEnableDisable_CheckBox(chk_Sunday_OT, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Weekday_OT, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_PoyaDay_OT, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_Saturday_OT, true);
            cls_Formater.SetEnableDisable_CheckBox(chk_CompanyHoliday_OT, true);

            cls_Formater.SetEnableDisable_TimeSpan(ts_Weekday_OT_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_PoyaDay_OT_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Saturday_OT_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Sunday_OT_grace, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_CompanyHoliday_OT_grace, false);

            cls_Formater.SetEnableDisable_TimeSpan(ts_Weekday_OT_max, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Poyaday_OT_max, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_CompanyHoliday_OT_max, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Saturday_OT_max, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Sunday_OT_max, false);

            cls_Formater.SetEnableDisable_TimeSpan(ts_Saturday_OT_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Sunday_OT_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Poyaday_OT_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_Weekday_OT_min, false);
            cls_Formater.SetEnableDisable_TimeSpan(ts_CompanyHoliday_OT_min, false);

            //cls_Formater.SetEnableDisable_CheckBox(chk_OtApplicable, true);
            //cls_Formater.SetEnableDisable_CheckBox(radActive, true);
            //cls_Formater.SetEnableDisable_CheckBox(radInactive, true);
            //cls_Formater.SetEnableDisable_DatePicker(dtp_EffictiveDate, true);
            //cls_Formater.SetEnableDisable_DatePicker(dtp_ExpDate, true);
            dtp_EffictiveDate.SetTime(clsSecurity.getServerDateTime());
            dtp_ExpDate.SetTime(clsSecurity.getServerDateTime());
            shiftStatus.IsChecked = true;

            txt_Sunday_BaseRate.Text = "0.00";
            txt_Monday_BaseRate.Text = "0.00";
            txt_Tuesday_BaseRate.Text = "0.00";
            txt_Wednsday_BaseRate.Text = "0.00";
            txt_Thuseday_BaseRate.Text = "0.00";
            txt_Friday_BaseRate.Text = "0.00";
            txt_Saturday_BaseRate.Text = "0.00";

            txtOTRate.Text = "0.00";
            txt_Weekday_OTRate.Text = "0.00";
            txt_Saturday_OTRate.Text = "0.00";
            txt_Sunday_OTRate.Text = "0.00";
            txt_Poyaday_OTRate.Text = "0.00";
            txt_CompanyHoliday_OTRate.Text = "0.00";

            txtShiftID.Text = "";
            txtShiftID.Tag = null;
            txtShiftName.Text = "";
            txtShiftRemarks.Text = "";

            chk_OtApplicable.IsChecked = false;
            chk_EarlyOTApplicable.IsChecked = false;
            chk_Sunday.IsChecked = false;
            chk_Monday.IsChecked = false;
            chk_Tuesday.IsChecked = false;
            chk_Wednsday.IsChecked = false;
            chk_Thursday.IsChecked = false;
            chk_friday.IsChecked = false;
            chk_Saturday.IsChecked = false;

            chk_Weekday_OT.IsChecked = false;
            chk_Saturday_OT.IsChecked = false;
            chk_Sunday_OT.IsChecked = false;
            chk_PoyaDay_OT.IsChecked = false;
            chk_CompanyHoliday_OT.IsChecked = false;

            chk_OTLunchDeduction_Weekday.IsChecked = false;
            chk_OTLunchDeduction_Satureday.IsChecked = false;
            chk_OTLunchDeduction_Sunday.IsChecked = false;
            chk_OTLunchDeduction_Poyaday.IsChecked = false;
            chk_OTLunchDeduction_CompanyHoliday.IsChecked = false;

            shiftStatus.IsChecked = true;

            ts_EOT_GracePeriod.Visibility = Visibility.Collapsed;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtShiftID.setReadOnlyStatus(true);
                txtShiftID.Text = "<Auto Generate>";
            }
            else
                txtShiftID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_tasShiftMaster detail in tbl_tasShiftMaster.SelectAll().Where(p => p.Shift_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(detail.Shift_ID, detail.Shift_Name, detail.ShiftStartTime.ToString(clsConfig.Format_Time), (detail.ShiftStartTime).AddMinutes(detail.ShiftMinutes).ToString(clsConfig.Format_Time));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
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
                    if (ChekValidity_DuplicateNames())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtShiftID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtShiftName))
                bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(ts_ShiftHours))
            //    bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_tasShiftMaster detail = tbl_tasShiftMaster.Select(txtShiftID.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
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
            foreach (tbl_tasShiftMaster detail1 in tbl_tasShiftMaster.SelectAll().Where(p => p.Shift_Name == txtShiftName.Text && p.IsCanceled == false && p.Shift_ID != txtShiftID.Text))
            {
                if (detail1 != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist, "Shift Name");
                    break;
                }
            }
            return bStatus;
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    ClearFields();
                    tbl_tasShiftMaster detail = tbl_tasShiftMaster.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtShiftID.IsEnabled = false;
                        txtShiftID.Text = detail.Shift_ID;
                        txtShiftID.Tag = detail.Shift_ID;
                        txtShiftName.Text = detail.Shift_Name;
                        txtShiftRemarks.Text = detail.Shift_Remarks;
                        cmb_ShiftType.SetSelectedIndex(detail.ShiftType);
                        cmb_ShiftType.SetSelectedIndex(detail.ShiftType);

                        if (detail.IsEarlyOtApplicable == true)
                        {
                            chk_EarlyOTApplicable.IsChecked = true;
                        }
                        else
                        {
                            chk_EarlyOTApplicable.IsChecked = false;
                        }

                        cmb_OTRoundMode.SetSelectedIndex(detail.Shift_OTRoundMode);
                        cmb_OTRoundMode.SetSelectedIndex(detail.Shift_OTRoundMode);
                        ts_OTRoundMinutes.setMinutes(detail.Shift_OTRoundMinutes);
                        tp_ShiftStartTime.SetTime(detail.ShiftStartTime);
                        ts_ShiftHours.setMinutes(detail.ShiftMinutes);
                        ts_ShiftHours_Min.setMinutes(detail.ShiftMinutesMin);
                        ts_NextShiftHours.setMinutes(detail.NextShiftMinutes);
                        txtBaseRate.Text = detail.ShiftBaseRate.ToString();
                        ts_ShiftGracePeriod.setMinutes(detail.ShiftGracePeriod);

                        if (detail.IsSundaySpecialWH == true)
                        {
                            chk_Sunday.IsChecked = true;
                        }
                        else
                        {
                            chk_Sunday.IsChecked = false;
                        }
                        ts_sunday_ShiftHours.setMinutes(detail.ShiftMinutes_Sunday);
                        ts_sunday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Sunday);
                        ts_sunday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Sunday);
                        txt_Sunday_BaseRate.Text = detail.ShiftBaseRate_Sunday.ToString();
                        ts_sunday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Sunday);
                        if (detail.IsMondaySpecialWH == true)
                        {
                            chk_Monday.IsChecked = true;
                        }
                        else
                        {
                            chk_Monday.IsChecked = false;
                        }
                        ts_Monday_ShiftHours.setMinutes(detail.ShiftMinutes_Monday);
                        ts_Monday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Monday);
                        ts_Monday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Monday);
                        txt_Monday_BaseRate.Text = detail.ShiftBaseRate_Monday.ToString();
                        ts_Monday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Monday);
                        if (detail.IsTuesdaySpecialWH == true)
                        {
                            chk_Tuesday.IsChecked = true;
                        }
                        else
                        {
                            chk_Tuesday.IsChecked = false;
                        }
                        ts_Tuesday_ShiftHours.setMinutes(detail.ShiftMinutes_Tuesday);
                        ts_Tuesday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Tuesday);
                        ts_Tuesday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Tuesday);
                        txt_Tuesday_BaseRate.Text = detail.ShiftBaseRate_Tuesday.ToString();
                        ts_Tuesday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Tuesday);
                        if (detail.IsWednesdaySpecialWH == true)
                        {
                            chk_Wednsday.IsChecked = true;
                        }
                        else
                        {
                            chk_Wednsday.IsChecked = false;
                        }
                        ts_Wednsday_ShiftHours.setMinutes(detail.ShiftMinutes_Wednesday);
                        ts_Wednsday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Wednesday);
                        ts_Wednsday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Wednesday);
                        txt_Wednsday_BaseRate.Text = detail.ShiftBaseRate_Wednesday.ToString();
                        ts_Wednsday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Wednesday);
                        if (detail.IsThursdaySpecialWH == true)
                        {
                            chk_Thursday.IsChecked = true;
                        }
                        else
                        {
                            chk_Thursday.IsChecked = false;
                        }
                        ts_Thuseday_ShiftHours.setMinutes(detail.ShiftMinutes_Thursday);
                        ts_Thuseday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Thursday);
                        ts_Thuseday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Thursday);
                        txt_Thuseday_BaseRate.Text = detail.ShiftBaseRate_Thursday.ToString();
                        ts_Thuseday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Thursday);
                        if (detail.IsFridaySpecialWH == true)
                        {
                            chk_friday.IsChecked = true;
                        }
                        else
                        {
                            chk_friday.IsChecked = false;
                        }
                        ts_friday_ShiftHours.setMinutes(detail.ShiftMinutes_Friday);
                        ts_friday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Friday);
                        ts_friday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Friday);
                        txt_Friday_BaseRate.Text = detail.ShiftBaseRate_Friday.ToString();
                        ts_friday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Friday);
                        if (detail.IsSaturdaySpecialWH == true)
                        {
                            chk_Saturday.IsChecked = true;
                        }
                        else
                        {
                            chk_Saturday.IsChecked = false;
                        }
                        ts_saturday_ShiftHours.setMinutes(detail.ShiftMinutes_Saturday);
                        ts_saturday_ShiftHours_min.setMinutes(detail.ShiftMinutesMin_Saturday);
                        ts_saturday_Nxt_Shift_Hours.setMinutes(detail.NextShiftMinutes_Saturday);
                        txt_Saturday_BaseRate.Text = detail.ShiftBaseRate_Saturday.ToString();
                        ts_saturday_Sft_grace.setMinutes(detail.ShiftGracePeriod_Saturday);
                        if (detail.IsOT_Applicable == true)
                        {
                            chk_OtApplicable.IsChecked = true;
                        }
                        else
                        {
                            chk_OtApplicable.IsChecked = false;
                        }
                        txtOTRate.Text = detail.Shift_OTRate.ToString();
                        ts_OT_GracePeriod.setMinutes(detail.Shift_OTGracePeroiod);
                        ts_EOT_GracePeriod.setMinutes(detail.Shift_EarlyOTGracePeroiod);
                        ts_ShiftOtMin.setMinutes(detail.Shift_OTMinuteMin);
                        ts_ShiftOTMax.setMinutes(detail.Shift_OTMinuteMax);
                        if (detail.IsWeekdaySpecialOT == true)
                        {
                            chk_Weekday_OT.IsChecked = true;
                        }
                        else
                        {
                            chk_Weekday_OT.IsChecked = false;
                        }
                        txt_Weekday_OTRate.Text = detail.Shift_OTRate_Weekday.ToString();
                        ts_Weekday_OT_grace.setMinutes(detail.Shift_OTGracePeroiod_Weekday);
                        ts_Weekday_OT_min.setMinutes(detail.Shift_OTMinuteMin_Weekday);
                        ts_Weekday_OT_max.setMinutes(detail.Shift_OTMinuteMax_Weekday);
                        chk_OTLunchDeduction_Weekday.IsChecked = detail.IsOTLunchDeduction_Weekday;
                        if (detail.IsSaturdaySpecialOT == true)
                        {
                            chk_Saturday_OT.IsChecked = true;
                        }
                        else
                        {
                            chk_Saturday_OT.IsChecked = false;
                        }
                        txt_Saturday_OTRate.Text = detail.Shift_OTRate_Saturday.ToString();
                        ts_Saturday_OT_grace.setMinutes(detail.Shift_OTGracePeroiod_Saturday);
                        ts_Saturday_OT_min.setMinutes(detail.Shift_OTMinuteMin_Saturday);
                        ts_Saturday_OT_max.setMinutes(detail.Shift_OTMinuteMax_Saturday);
                        chk_OTLunchDeduction_Satureday.IsChecked = detail.IsOTLunchDeduction_Saturday;
                        if (detail.IsSundaySpecialOT == true)
                        {
                            chk_Sunday_OT.IsChecked = true;
                        }
                        else
                        {
                            chk_Sunday_OT.IsChecked = false;
                        }
                        txt_Sunday_OTRate.Text = detail.Shift_OTRate_Sunday.ToString();
                        ts_Sunday_OT_grace.setMinutes(detail.Shift_OTGracePeroiod_Sunday);
                        ts_Sunday_OT_min.setMinutes(detail.Shift_OTMinuteMin_Sunday);
                        ts_Sunday_OT_max.setMinutes(detail.Shift_OTMinuteMax_Sunday);
                        chk_OTLunchDeduction_Sunday.IsChecked = detail.IsOTLunchDeduction_Sundy;
                        if (detail.IsPoyadaySpecialOT == true)
                        {
                            chk_PoyaDay_OT.IsChecked = true;
                        }
                        else
                        {
                            chk_PoyaDay_OT.IsChecked = false;
                        }

                        txt_Poyaday_OTRate.Text = detail.Shift_OTRate_Poyaday.ToString();
                        ts_PoyaDay_OT_grace.setMinutes(detail.Shift_OTGracePeroiod_Poyaday);
                        ts_Poyaday_OT_min.setMinutes(detail.Shift_OTMinuteMin_Poyaday);
                        ts_Poyaday_OT_max.setMinutes(detail.Shift_OTMinuteMax_Poyaday);
                        chk_OTLunchDeduction_Poyaday.IsChecked = detail.IsOTLunchDeduction_Poyaday;
                        if (detail.IsCompanyHolidaySpecialOT == true)
                        {
                            chk_CompanyHoliday_OT.IsChecked = true;
                        }
                        else
                        {
                            chk_CompanyHoliday_OT.IsChecked = false;
                        }
                        txt_CompanyHoliday_OTRate.Text = detail.Shift_OTRate_CompanyHoliday.ToString();
                        ts_CompanyHoliday_OT_grace.setMinutes(detail.Shift_OTGracePeroiod_CompanyHoliday);
                        ts_CompanyHoliday_OT_min.setMinutes(detail.Shift_OTMinuteMin_CompanyHoliday);
                        ts_CompanyHoliday_OT_max.setMinutes(detail.Shift_OTMinuteMax_CompanyHoliday);
                        chk_OTLunchDeduction_CompanyHoliday.IsChecked = detail.IsOTLunchDeduction_CompanyHoliday;

                        if (detail.Shift_Status == true)
                        {
                            shiftStatus.IsChecked = true;
                        }
                        else
                        {
                            shiftStatus.IsChecked = false;
                        }

                        dtp_EffictiveDate.SetTime(detail.Shift_Status_Effective_Date);
                        dtp_ExpDate.SetTime(detail.Shift_Status_ExpireDate);

                        tp_LunchStartTime.SetTime(detail.LunchStartTime);
                        ts_LunchDuration.setMinutes(detail.LunchDurationMins);
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
        private void ddd_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
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
        private void txtShiftID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Shift);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtShiftID.Text = lstResult[0];
                fillDetails(txtShiftID.Text);
            }
        }
        #endregion

        #region ChekBoxses Event
        private void chk_Sunday_Checked(object sender, RoutedEventArgs e)
        {
            ts_sunday_ShiftHours.IsEnabled = true;
            ts_sunday_ShiftHours_min.IsEnabled = true;
            ts_sunday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Sunday_BaseRate.IsEnabled = true;
            ts_sunday_Sft_grace.IsEnabled = true;

            ts_sunday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_sunday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_sunday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Sunday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_sunday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_Monday_Checked(object sender, RoutedEventArgs e)
        {
            ts_Monday_ShiftHours.IsEnabled = true;
            ts_Monday_ShiftHours_min.IsEnabled = true;
            ts_Monday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Monday_BaseRate.IsEnabled = true;
            ts_Monday_Sft_grace.IsEnabled = true;

            ts_Monday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_Monday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_Monday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Monday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_Monday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            ts_Tuesday_ShiftHours.IsEnabled = true;
            ts_Tuesday_ShiftHours_min.IsEnabled = true;
            ts_Tuesday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Tuesday_BaseRate.IsEnabled = true;
            ts_Tuesday_Sft_grace.IsEnabled = true;

            ts_Tuesday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_Tuesday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_Tuesday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Tuesday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_Tuesday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_Wednsday_Checked(object sender, RoutedEventArgs e)
        {
            ts_Wednsday_ShiftHours.IsEnabled = true;
            ts_Wednsday_ShiftHours_min.IsEnabled = true;
            ts_Wednsday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Wednsday_BaseRate.IsEnabled = true;
            ts_Wednsday_Sft_grace.IsEnabled = true;

            ts_Wednsday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_Wednsday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_Wednsday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Wednsday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_Wednsday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_Thursday_Checked(object sender, RoutedEventArgs e)
        {
            ts_Thuseday_ShiftHours.IsEnabled = true;
            ts_Thuseday_ShiftHours_min.IsEnabled = true;
            ts_Thuseday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Thuseday_BaseRate.IsEnabled = true;
            ts_Thuseday_Sft_grace.IsEnabled = true;


            ts_Thuseday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_Thuseday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_Thuseday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Thuseday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_Thuseday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_friday_Checked(object sender, RoutedEventArgs e)
        {
            ts_friday_ShiftHours.IsEnabled = true;
            ts_friday_ShiftHours_min.IsEnabled = true;
            ts_friday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Friday_BaseRate.IsEnabled = true;
            ts_friday_Sft_grace.IsEnabled = true;

            ts_friday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_friday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_friday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Friday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_friday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_Saturday_Checked(object sender, RoutedEventArgs e)
        {
            ts_saturday_ShiftHours.IsEnabled = true;
            ts_saturday_ShiftHours_min.IsEnabled = true;
            ts_saturday_Nxt_Shift_Hours.IsEnabled = true;
            txt_Saturday_BaseRate.IsEnabled = true;
            ts_saturday_Sft_grace.IsEnabled = true;

            ts_saturday_ShiftHours.setMinutes(ts_ShiftHours.GetMinutes());
            ts_saturday_ShiftHours_min.setMinutes(ts_ShiftHours_Min.GetMinutes());
            ts_saturday_Nxt_Shift_Hours.setMinutes(ts_NextShiftHours.GetMinutes());
            txt_Saturday_BaseRate.Text = txtBaseRate.Text.ToString();
            ts_saturday_Sft_grace.setMinutes(ts_ShiftGracePeriod.GetMinutes());
        }

        private void chk_Sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_sunday_ShiftHours.IsEnabled = false;
            ts_sunday_ShiftHours_min.IsEnabled = false;
            ts_sunday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Sunday_BaseRate.IsEnabled = false;
            ts_sunday_Sft_grace.IsEnabled = false;
        }

        private void chk_Monday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_Monday_ShiftHours.IsEnabled = false;
            ts_Monday_ShiftHours_min.IsEnabled = false;
            ts_Monday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Monday_BaseRate.IsEnabled = false;
            ts_Monday_Sft_grace.IsEnabled = false;
        }

        private void chk_Tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_Tuesday_ShiftHours.IsEnabled = false;
            ts_Tuesday_ShiftHours_min.IsEnabled = false;
            ts_Tuesday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Tuesday_BaseRate.IsEnabled = false;
            ts_Tuesday_Sft_grace.IsEnabled = false;
        }

        private void chk_Wednsday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_Wednsday_ShiftHours.IsEnabled = false;
            ts_Wednsday_ShiftHours_min.IsEnabled = false;
            ts_Wednsday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Wednsday_BaseRate.IsEnabled = false;
            ts_Wednsday_Sft_grace.IsEnabled = false;
        }

        private void chk_Thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_Thuseday_ShiftHours.IsEnabled = false;
            ts_Thuseday_ShiftHours_min.IsEnabled = false;
            ts_Thuseday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Thuseday_BaseRate.IsEnabled = false;
            ts_Thuseday_Sft_grace.IsEnabled = false;
        }

        private void chk_friday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_friday_ShiftHours.IsEnabled = false;
            ts_friday_ShiftHours_min.IsEnabled = false;
            ts_friday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Friday_BaseRate.IsEnabled = false;
            ts_friday_Sft_grace.IsEnabled = false;
        }

        private void chk_Saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            ts_saturday_ShiftHours.IsEnabled = false;
            ts_saturday_ShiftHours_min.IsEnabled = false;
            ts_saturday_Nxt_Shift_Hours.IsEnabled = false;
            txt_Saturday_BaseRate.IsEnabled = false;
            ts_saturday_Sft_grace.IsEnabled = false;
        }

        private void chk_OtApplicable_checkBox_Checked(object sender, EventArgs e)
        {
            ts_OT_GracePeriod.IsEnabled = true;
            ts_ShiftOtMin.IsEnabled = true;
            ts_ShiftOTMax.IsEnabled = true;
            txtOTRate.IsEnabled = true;
        }

        private void chk_OtApplicable_checkBox_Unchecked(object sender, EventArgs e)
        {
            txtOTRate.IsEnabled = false;
            ts_OT_GracePeriod.IsEnabled = false;
            ts_ShiftOtMin.IsEnabled = false;
            ts_ShiftOTMax.IsEnabled = false;
        }

        private void chk_Sunday_OT_Checked(object sender, RoutedEventArgs e)
        {
            txt_Sunday_OTRate.IsEnabled = true;
            ts_Weekday_OT_grace.IsEnabled = true;
            ts_Weekday_OT_max.IsEnabled = true;
            ts_Weekday_OT_min.IsEnabled = true;
        }

        private void chk_Weekday_OT_Checked(object sender, RoutedEventArgs e)
        {
            txt_Weekday_OTRate.IsEnabled = true;
            ts_Weekday_OT_grace.IsEnabled = true;
            ts_Weekday_OT_min.IsEnabled = true;
            ts_Weekday_OT_max.IsEnabled = true;
        }

        private void chk_Weekday_OT_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_Weekday_OTRate.IsEnabled = false;
            ts_Weekday_OT_grace.IsEnabled = false;
            ts_Weekday_OT_min.IsEnabled = false;
            ts_Weekday_OT_max.IsEnabled = false;
        }

        private void chk_Saturday_OT_Checked(object sender, RoutedEventArgs e)
        {
            txt_Saturday_OTRate.IsEnabled = true;
            ts_Saturday_OT_grace.IsEnabled = true;
            ts_Saturday_OT_min.IsEnabled = true;
            ts_Saturday_OT_max.IsEnabled = true;
        }

        private void chk_Saturday_OT_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_Saturday_OTRate.IsEnabled = false;
            ts_Saturday_OT_grace.IsEnabled = false;
            ts_Saturday_OT_min.IsEnabled = false;
            ts_Saturday_OT_max.IsEnabled = false;
        }

        private void chk_Sunday_OT_Checked_1(object sender, RoutedEventArgs e)
        {
            txt_Sunday_OTRate.IsEnabled = true;
            ts_Sunday_OT_grace.IsEnabled = true;
            ts_Sunday_OT_min.IsEnabled = true;
            ts_Sunday_OT_max.IsEnabled = true;
        }

        private void chk_Sunday_OT_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_Sunday_OTRate.IsEnabled = false;
            ts_Sunday_OT_grace.IsEnabled = false;
            ts_Sunday_OT_min.IsEnabled = false;
            ts_Sunday_OT_max.IsEnabled = false;
        }

        private void chk_PoyaDay_OT_Checked(object sender, RoutedEventArgs e)
        {
            txt_Poyaday_OTRate.IsEnabled = true;
            ts_PoyaDay_OT_grace.IsEnabled = true;
            ts_Poyaday_OT_min.IsEnabled = true;
            ts_Poyaday_OT_max.IsEnabled = true;
        }

        private void chk_PoyaDay_OT_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_Poyaday_OTRate.IsEnabled = false;
            ts_PoyaDay_OT_grace.IsEnabled = false;
            ts_Poyaday_OT_min.IsEnabled = false;
            ts_Poyaday_OT_max.IsEnabled = false;
        }

        private void chk_CompanyHoliday_OT_Checked(object sender, RoutedEventArgs e)
        {
            txt_CompanyHoliday_OTRate.IsEnabled = true;
            ts_CompanyHoliday_OT_grace.IsEnabled = true;
            ts_CompanyHoliday_OT_min.IsEnabled = true;
            ts_CompanyHoliday_OT_max.IsEnabled = true;
        }

        private void chk_CompanyHoliday_OT_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_CompanyHoliday_OTRate.IsEnabled = false;
            ts_CompanyHoliday_OT_grace.IsEnabled = false;
            ts_CompanyHoliday_OT_min.IsEnabled = false;
            ts_CompanyHoliday_OT_max.IsEnabled = false;
        }
        #endregion

        #region ComboBoxEvent
        private void FillDetails_ComboBox()
        {
            List<string> roundingModes = new List<string>();
            foreach (var oRoundingModes in Enum.GetValues(typeof(OTRoundingMode)))
            {
                roundingModes.Add(oRoundingModes.ToString());
            }
            cmb_OTRoundMode.SetValues(roundingModes);
        }

        private void FillDetails_cmb_ShiftType()
        {
            List<string> shiftTypes = new List<string>();
            foreach (var oShiftTypes in Enum.GetValues(typeof(ShiftTypes)))
            {
                shiftTypes.Add(oShiftTypes.ToString());
            }
            cmb_ShiftType.SetValues(shiftTypes);
        }

        private void cmb_OTRoundMode_CmbSelectionChanged(object sender, EventArgs e)
        {
            if (cmb_OTRoundMode.GetSelectedIndex() != 0)
            {
                cls_Formater.SetEnableDisable_LableTimeSpan(ts_OTRoundMinutes, true);
            }
            else
            {
                cls_Formater.SetEnableDisable_LableTimeSpan(ts_OTRoundMinutes, false);
            }
        }
        #endregion

        #region CheckBox Checked
        private void chk_EarlyOTApplicable_checkBox_Checked(object sender, EventArgs e)
        {
            try
            {
                if (chk_EarlyOTApplicable.IsChecked)
                {
                    ts_EOT_GracePeriod.Visibility = Visibility.Visible;
                    ts_EOT_GracePeriod.IsEnabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void chk_EarlyOTApplicable_checkBox_Unchecked(object sender, EventArgs e)
        {
            try
            {
                if (!chk_EarlyOTApplicable.IsChecked)
                {
                    ts_EOT_GracePeriod.Visibility = Visibility.Collapsed;
                    ts_EOT_GracePeriod.IsEnabled = false;
                }
            }
            catch (Exception)
            {
            }
        } 
        #endregion

    }
}