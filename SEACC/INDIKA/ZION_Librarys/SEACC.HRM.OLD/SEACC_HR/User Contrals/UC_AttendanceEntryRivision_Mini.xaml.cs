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
using System.IO;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_AttendanceEntryRivision_Mini.xaml
    /// </summary>
    public partial class UC_AttendanceEntryRivision_Mini : UserControl
    {
        DataTable dt_RivisionDate = new DataTable();
        public UC_AttendanceEntryRivision_Mini()
        {
            InitializeComponent();
            dt_RivisionDate.Columns.Add("EmpID");
            dt_RivisionDate.Columns.Add("EmpName");
            dt_RivisionDate.Columns.Add("AttendaceDate");
            dt_RivisionDate.Columns.Add("InDate");
            dt_RivisionDate.Columns.Add("INTime");
            dt_RivisionDate.Columns.Add("OutDate");
            dt_RivisionDate.Columns.Add("OutTime");
            dt_RivisionDate.Columns.Add("WorkedMinutes");
            dt_RivisionDate.Columns.Add("OTMinutes");
            dt_RivisionDate.Columns.Add("OTMinutesApproved");
            dt_RivisionDate.Columns.Add("DoubleOTMinutes");         //Double OT
            dt_RivisionDate.Columns.Add("DoubleOTMinutesApproved"); //Double OT
            dt_RivisionDate.Columns.Add("TripleOTMinutes");         //Triple OT
            dt_RivisionDate.Columns.Add("TripleOTMinutesApproved"); //Triple OT

            dt_RivisionDate.Columns.Add("LateMinutes"); 
            dt_RivisionDate.Columns.Add("LateMinutesApproved"); 
            dt_RivisionDate.Columns.Add("NopayMinutes");
            dt_RivisionDate.Columns.Add("NopayMinutesApproved"); 

        }

        public void ClearData()
        {
            dt_RivisionDate.Clear();
        }

        public void RefreshGrid(string EmpID, DateTime Date)
        {
            try
            {
                dt_RivisionDate.Clear();
                foreach (tbl_tasTxDailyAttendance_revision oAttendanceRivision in tbl_tasTxDailyAttendance_revision.SelectAll().Where(p => p.AttendenceDate.Date >= Date && p.AttendenceDate.Date <= Date && p.Employee_ID == EmpID).OrderByDescending(d=> d.Attendance_revision_index))
                {

                    string sWorkedDuration = (TimeSpan.FromMinutes(oAttendanceRivision.WorkedMinutes).ToString(@"hh\:mm"));
                    string sOTDuration = (TimeSpan.FromMinutes(oAttendanceRivision.OTMinutes).ToString(@"hh\:mm"));
                    string sOTDurationApproved = (TimeSpan.FromMinutes(oAttendanceRivision.OTMinutesApproved).ToString(@"hh\:mm"));

                    string sDoubleOtDuration = (TimeSpan.FromMinutes(oAttendanceRivision.DOTMinutes).ToString(@"hh\:mm"));
                    string sDoubleOtDurationApproved = (TimeSpan.FromMinutes(oAttendanceRivision.DOTMinutesApproved).ToString(@"hh\:mm"));

                    string sTripleOtDuration = (TimeSpan.FromMinutes(oAttendanceRivision.TOTMinutes).ToString(@"hh\:mm"));
                    string sTripleOtDurationApproved = (TimeSpan.FromMinutes(oAttendanceRivision.TOTMinutesApproved).ToString(@"hh\:mm"));


                    string sLateDuration = (TimeSpan.FromMinutes(oAttendanceRivision.LateMinutes).ToString(@"hh\:mm"));
                    string sLateDurationApproved = (TimeSpan.FromMinutes(oAttendanceRivision.LateMinutesApproved).ToString(@"hh\:mm"));

                    string sNopayDuration = (TimeSpan.FromMinutes(oAttendanceRivision.NoPayMinutes).ToString(@"hh\:mm"));
                    string sNopayDurationApproved = (TimeSpan.FromMinutes(oAttendanceRivision.NoPayMinutesApproved).ToString(@"hh\:mm"));

                    dt_RivisionDate.Rows.Add(oAttendanceRivision.Employee_ID, clsRef_Name.get_EmployeeName(oAttendanceRivision.Employee_ID), oAttendanceRivision.AttendenceDate.ToString(clsConfig.Format_Date), oAttendanceRivision.TimeIn_DateTime.ToString(clsConfig.Format_Date), oAttendanceRivision.TimeIn_DateTime.ToString(clsConfig.Format_Time), oAttendanceRivision.TimeOut_DateTime.ToString(clsConfig.Format_Date), oAttendanceRivision.TimeOut_DateTime.ToString(clsConfig.Format_Time), sWorkedDuration, sOTDuration, sOTDurationApproved, sDoubleOtDuration, sDoubleOtDurationApproved, sTripleOtDuration, sTripleOtDurationApproved, sLateDuration, sLateDurationApproved, sNopayDuration, sNopayDurationApproved );
                }
                grd_AttendaceRivision.ItemsSource = dt_RivisionDate.DefaultView;

                if (dt_RivisionDate.Rows.Count > 0)
                       this.Height = grd_AttendaceRivision.Height+35;
                else
                    this.Height = 0;
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
    }
}
