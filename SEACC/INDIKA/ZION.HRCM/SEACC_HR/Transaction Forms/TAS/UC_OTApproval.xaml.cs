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
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Digiteq
{
    public partial class UC_OTApproval : UserControl
    {
        #region Form Load
        public UC_OTApproval()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.OT_Approval;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Approved");
            dgr_Main.dt.Columns.Add("Rejected");
            dgr_Main.dt.Columns.Add("AttendanceDate");
            dgr_Main.dt.Columns.Add("employee_ID");
            dgr_Main.dt.Columns.Add("EmpName");
            dgr_Main.dt.Columns.Add("ShiftID");
            dgr_Main.dt.Columns.Add("ShiftName");
            dgr_Main.dt.Columns.Add("StartTime");
            dgr_Main.dt.Columns.Add("EndTime");
            dgr_Main.dt.Columns.Add("InDate");
            dgr_Main.dt.Columns.Add("InTime");
            dgr_Main.dt.Columns.Add("OutDate");
            dgr_Main.dt.Columns.Add("OutTime");
            dgr_Main.dt.Columns.Add("WorkMinutes");
            dgr_Main.dt.Columns.Add("OTMinutes");
            dgr_Main.dt.Columns.Add("DOTMinutes");
            dgr_Main.dt.Columns.Add("TOTMinutes");
            dgr_Main.dt.Columns.Add("OTApplicable");//bool
            dgr_Main.dt.Columns.Add("OTApproved");
            dgr_Main.dt.Columns.Add("DOTApproved");
            dgr_Main.dt.Columns.Add("TOTApproved");
            dgr_Main.dt.Columns.Add("LateMinutes");
            dgr_Main.dt.Columns.Add("LateApproved");
            dgr_Main.dt.Columns.Add("NOPayMinutes");
            dgr_Main.dt.Columns.Add("NOPayApproved");
            #endregion

            #region Initialize Acction Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Approved", "Approved", 75, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Rejected", "Rejected", 75, true, false);
            dgr_Main.Add_DatagridColoumn("Date", "AttendanceDate", 75);
            dgr_Main.Add_DatagridColoumn("Emp No.", "employee_ID", 55);
            dgr_Main.Add_DatagridColoumn("Name", "EmpName", 120);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "shift ID", "ShiftID", 110, false, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Shift", "ShiftName", 130, false, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Shift Start", "StartTime", 130, false, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Shift End", "EndTime", 130, false, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Date", "InDate", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "In Time", "InTime", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Date", "OutDate", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Out Time", "OutTime", 80, true, true);
            dgr_Main.Add_DatagridColoumn("Hrs Wkd.", "WorkMinutes", 80);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs OT", "OTMinutes", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs D.OT", "DOTMinutes", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs T.OT", "TOTMinutes", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "OT", "OTApplicable", 25, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs OT Aprd.", "OTApproved", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs D.OT Aprd.", "DOTApproved", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs T.OT Aprd.", "TOTApproved", 80, true, true);

            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Late", "LateMinutes", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Late Aprd.", "LateApproved", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Nopay", "NOPayMinutes", 80, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Hrs Nopay Aprd.", "NOPayApproved", 80, true, true);
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Button
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    DateTime dtmAttendanceDate = clsValidation.Validate_DateTime(row["AttendanceDate"].ToString());
                    string sEmployee_ID = row["employee_ID"].ToString();
                    bool bIsApproved = row["Approved"].ToString() == "True" ? true : false;
                    bool bIsRejected = row["Rejected"].ToString() == "True" ? true : false;

                    if (bIsApproved || bIsRejected)
                    {
                        foreach (tbl_tasTxDailyAttendance_revision oRev in tbl_tasTxDailyAttendance_revision.SelectAll_Advanced(dtmAttendanceDate.Date, sEmployee_ID).Where(p => !p.IsCanceled && !p.IsOverride && p.ApprovalStatus != (int)ApprovalStatus.Rejected && p.ApprovalStatus != (int)ApprovalStatus.Approved))
                        {
                            tbl_tasTxDailyAttendance oOldRecord = tbl_tasTxDailyAttendance.Select_Advanced(dtmAttendanceDate.Date, sEmployee_ID);
                            if (oOldRecord != null)
                            {
                                if (bIsApproved)
                                {
                                    //oOldRecord.Attendance_index = oRev.Attendance_revision_index;
                                    oOldRecord.TimeIn_ID = oRev.TimeIn_ID;
                                    oOldRecord.TimeIn_DateTime = oRev.TimeIn_DateTime;
                                    oOldRecord.TimeOut_ID = oRev.TimeOut_ID;
                                    oOldRecord.TimeOut_DateTime = oRev.TimeOut_DateTime;
                                    oOldRecord.WorkedMinutes = oRev.WorkedMinutes;
                                    oOldRecord.OTMinutes = oRev.OTMinutes;
                                    oOldRecord.IsOT_Applicable = oRev.IsOT_Applicable;
                                    oOldRecord.OTMinutesApproved = oRev.OTMinutesApproved;
                                    oOldRecord.DOTMinutesApproved = oRev.DOTMinutesApproved;
                                    oOldRecord.TOTMinutesApproved = oRev.TOTMinutesApproved;
                                    oOldRecord.LateMinutes = oRev.LateMinutes;
                                    oOldRecord.LateMinutesApproved = oRev.LateMinutesApproved;
                                    oOldRecord.NoPayMinutes = oRev.NoPayMinutes;
                                    oOldRecord.NoPayMinutesApproved = oRev.NoPayMinutesApproved;
                                    oOldRecord.Update();
                                }
                            }

                            if (bIsApproved)
                                oRev.ApprovalStatus = (int)ApprovalStatus.Approved;
                            if (bIsRejected)
                                oRev.ApprovalStatus = (int)ApprovalStatus.Rejected;

                            oRev.Date_Approvad = clsSecurity.getServerDateTime();
                            oRev.UserID_Approvad = clsSecurity.UserIDLoged;
                            oRev.TerminalID_Approvad = clsSecurity.TerminalID;
                            oRev.Update();
                        }
                    }
                }
                SEACCMessageBox.Show("Successfully Saved", "", MessageBoxButton.OK);
                ClearFields();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                ClearFields();
            }
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            dgr_Main.dt.Clear();
            foreach (tbl_tasTxDailyAttendance_revision oAttendaceEntryRivi in tbl_tasTxDailyAttendance_revision.SelectAll().Where(p => p.ApprovalStatus != (int)ApprovalStatus.Rejected && p.ApprovalStatus != (int)ApprovalStatus.Approved && p.AttendenceDate.Date >= dtp_FromDate.GetDateTime().Date && p.AttendenceDate.Date <= dtptoDate.GetDateTime().Date && !p.IsOverride))
            {
                tbl_genMasEmployee oEmployee = tbl_genMasEmployee.Select(oAttendaceEntryRivi.Employee_ID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oEmployee != null)
                {
                    // DateTime a = oAttendaceEntryRivi.AttendenceDate;
                    //   string b = oAttendaceEntryRivi.Employee_ID;
                    dgr_Main.dt.Rows.Add("", "", oAttendaceEntryRivi.AttendenceDate.ToString(clsConfig.Format_Date), oAttendaceEntryRivi.Employee_ID, oEmployee.Initails + " " + oEmployee.SurName, "", "", "", "", oAttendaceEntryRivi.TimeIn_DateTime.ToString(clsConfig.Format_Date), oAttendaceEntryRivi.TimeIn_DateTime.ToString(clsConfig.Format_Time), (oAttendaceEntryRivi.TimeOut_DateTime.ToString(clsConfig.Format_Date)), (oAttendaceEntryRivi.TimeOut_DateTime.ToString(clsConfig.Format_Time)), (oAttendaceEntryRivi.WorkedMinutes / 60).ToString("00.00"), (oAttendaceEntryRivi.OTMinutes / 60).ToString("00.00"), (oAttendaceEntryRivi.DOTMinutes / 60).ToString("00.00"), (oAttendaceEntryRivi.TOTMinutes / 60).ToString("00.00"), oAttendaceEntryRivi.IsOT_Applicable, (oAttendaceEntryRivi.OTMinutesApproved / 60).ToString("00.00"), (oAttendaceEntryRivi.DOTMinutesApproved / 60).ToString("00.00"), (oAttendaceEntryRivi.TOTMinutesApproved / 60).ToString("00.00"), (oAttendaceEntryRivi.LateMinutes / 60).ToString("00.00"), (oAttendaceEntryRivi.LateMinutesApproved / 60).ToString("00.00"), (oAttendaceEntryRivi.NoPayMinutes / 60).ToString("00.00"), (oAttendaceEntryRivi.NoPayMinutesApproved / 60).ToString("00.00"));
                }
            }
            dgr_Main.RefreshGrid();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dgr_Main.dt.Clear();

            dtp_FromDate.SetTime(DateTime.Now);
            dtptoDate.SetTime(DateTime.Now);
        }
        #endregion

        #region Grid Event
        private void grd_Main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumnIndex = e.Column.DisplayIndex;
            DataRowView rowView = (DataRowView)e.Row.DataContext;
            int irowID = dgr_Main.SelectedIndex;

            if (iColumnIndex == 8 || iColumnIndex == 9 || iColumnIndex == 11 || iColumnIndex == 12)
            {
                DateTime dtDate = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());
                string sShiftID = dgr_Main.dt.Rows[irowID]["shift_ID"].ToString();

                DateTime IN_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InDate_E"].ToString());
                DateTime IN_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InTime_E"].ToString());
                DateTime Out_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutDate_E"].ToString());
                DateTime Out_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutTime_E"].ToString());

                #region Format DateTime
                DateTime dtTemp = clsConfig.defaultDateTime;
                TextBox t = e.EditingElement as TextBox;
                if (t.Text != "-")
                {
                    #region Validate Date In
                    if (iColumnIndex == 8)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            IN_Date = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Date);
                            dgr_Main.dt.Rows[irowID]["InDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format - Date In", MessageBoxButton.OK);
                            t.Text = (IN_Date == clsConfig.defaultDateTime) ? "-" : IN_Date.ToString(clsConfig.Format_Date);
                        }
                    }
                    #endregion

                    #region Validate Date out
                    else if (iColumnIndex == 11)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            Out_Date = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Date);
                            dgr_Main.dt.Rows[irowID]["OutDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format - Date Out", MessageBoxButton.OK);
                            t.Text = (Out_Date == clsConfig.defaultDateTime) ? "-" : Out_Date.ToString(clsConfig.Format_Date);
                        }
                    }
                    #endregion

                    #region Validate Time in
                    else if (iColumnIndex == 9)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            IN_Time = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Time);
                            dgr_Main.dt.Rows[irowID]["InDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format - Time In", MessageBoxButton.OK);
                            t.Text = (IN_Time == clsConfig.defaultDateTime) ? "-" : IN_Time.ToString(clsConfig.Format_Time);
                        }
                    }
                    #endregion

                    #region Validate Time out
                    else if (iColumnIndex == 12)
                    {
                        try
                        {
                            dtTemp = DateTime.Parse(t.Text);
                            Out_Time = dtTemp;
                            t.Text = dtTemp.ToString(clsConfig.Format_Time);
                            dgr_Main.dt.Rows[irowID]["OutDateTime_ID_E"] = 1;
                        }
                        catch (Exception)
                        {
                            SEACCMessageBox.Show("Oops..!", "Unsupported Date Time Format - Time Out", MessageBoxButton.OK);
                            t.Text = (Out_Time == clsConfig.defaultDateTime) ? "-" : Out_Time.ToString(clsConfig.Format_Time);
                        }
                    }
                    #endregion
                }
                #endregion

                #region Update hors wkd & ot
                DateTime dtmTimeIn = clsValidation.Merge_DateAndTime(IN_Date, IN_Time);
                DateTime dtmOutTime = clsValidation.Merge_DateAndTime(Out_Date, Out_Time);
                // updateRow(false, e.Row.GetIndex(), dtDate, dtmTimeIn, dtmOutTime, sShiftID);
                #endregion
            }
        }

        private void grd_Main_DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_Main.GetCurrentCell();
                if (vDG_Cell.Column.SortMemberPath == "ShiftName")
                {
                    int irowID = dgr_Main.SelectedIndex;
                    string sEmployeeID = "";
                    try
                    {
                        sEmployeeID = dgr_Main.dt.Rows[irowID]["employee_ID"].ToString();
                    }
                    catch (Exception) { }

                    if (sEmployeeID != "")
                    {
                        frmSearch RowDataSearch = new frmSearch();
                        List<string> lstResult = RowDataSearch.Show(Search.Shift);
                        if (RowDataSearch.DialogResult == true)
                        {
                            string sShiftName = "";
                            int iInDateTime_Id = 0, iOutDateTime_ID = 0;
                            DateTime dtDate = DateTime.Parse(dgr_Main.dt.Rows[irowID]["attendenceDate"].ToString());

                            iInDateTime_Id = int.Parse(dgr_Main.dt.Rows[irowID]["InDateTime_ID_E"].ToString());
                            iOutDateTime_ID = int.Parse(dgr_Main.dt.Rows[irowID]["OutDateTime_ID_E"].ToString());

                            DateTime IN_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InDate_E"].ToString());
                            DateTime IN_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["InTime_E"].ToString());
                            DateTime Out_Date = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutDate_E"].ToString());
                            DateTime Out_Time = clsValidation.Validate_DateTime(dgr_Main.dt.Rows[irowID]["OutTime_E"].ToString());

                            DateTime dtmTimeIn = clsValidation.Merge_DateAndTime(IN_Date, IN_Time);
                            DateTime dtmOutTime = clsValidation.Merge_DateAndTime(Out_Date, Out_Time);

                            //updateRow(false, irowID, dtDate, dtmTimeIn, dtmOutTime, lstResult[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            #region Approved
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Approved")
                {
                    bool bIsChecked = false;
                    bIsChecked = dgr_Main.dt.Rows[irowID]["Approved"].ToString() == "True" ? true : false;

                    bool bIsRejected = false;
                    bIsRejected = dgr_Main.dt.Rows[irowID]["Rejected"].ToString() == "True" ? true : false;

                    dgr_Main.dt.Rows[irowID]["Approved"] = bIsChecked ? false : true;
                    dgr_Main.dt.Rows[irowID]["Rejected"] = bIsChecked;
                }
            }
            catch (Exception) { }
            #endregion

            #region Rejected
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Rejected")
                {
                    bool bIsChecked = false;
                    bIsChecked = dgr_Main.dt.Rows[irowID]["Approved"].ToString() == "True" ? true : false;

                    bool bIsRejected = false;
                    bIsRejected = dgr_Main.dt.Rows[irowID]["Rejected"].ToString() == "True" ? true : false;

                    dgr_Main.dt.Rows[irowID]["Rejected"] = bIsRejected ? false : true;
                    dgr_Main.dt.Rows[irowID]["Approved"] = bIsRejected;
                }
            }
            catch (Exception) { }
            #endregion
        }
        #endregion

        #region Approve|Reject Select All
        #region Check All_Approve
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_RejectAll.IsChecked != true)
            {
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    bool bIsApproved = row["Approved"].ToString() == "True" ? true : false;

                    if (!bIsApproved)
                        row["Approved"] = true;
                }
            }
            else
            {
                chk_RejectAll.IsChecked = false;
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    bool bIsRejected = row["Rejected"].ToString() == "True" ? true : false;
                    if (bIsRejected)
                        row["Rejected"] = false;

                    bool bIsApproved = row["Approved"].ToString() == "True" ? true : false;

                    if (!bIsApproved)
                        row["Approved"] = true;

                }
            }
        }
        #endregion

        #region UnCheckAll_Approve
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool bIsApproved = row["Approved"].ToString() == "True" ? true : false;
                if (bIsApproved)
                {
                    row["Approved"] = false;
                }
            }
        }
        #endregion

        #region CheckAll_Reject
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (chk_ApproveAll.IsChecked != true)
            {
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    bool bIsRejected = row["Rejected"].ToString() == "True" ? true : false;
                    if (!bIsRejected)
                    {
                        row["Rejected"] = true;
                    }
                }
            }
            else
            {
                chk_ApproveAll.IsChecked = false;
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    bool bIsApproved = row["Approved"].ToString() == "True" ? true : false;
                    if (bIsApproved)
                    {
                        row["Approved"] = false;
                    }
                    bool bIsRejected = row["Rejected"].ToString() == "True" ? true : false;
                    if (!bIsRejected)
                    {
                        row["Rejected"] = true;
                    }

                }

            }
        }
        #endregion

        #region UnCheckAll_Reject
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool bIsRejected = row["Rejected"].ToString() == "True" ? true : false;
                if (bIsRejected)
                {
                    row["Rejected"] = false;
                }
            }
        }
        #endregion 
        #endregion
    }
}