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
    /// Interaction logic for UC_SalarySheet.xaml
    /// </summary>
    public partial class UC_SalarySheet : UserControl
    {
        #region Class Variables
        DataTable dt_Attendance = new DataTable(); 
        #endregion

        #region Form Load
        public UC_SalarySheet()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Salary_Sheet_Detailed;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt_Attendance.Columns.Add("Day");
            dt_Attendance.Columns.Add("Shift");
            dt_Attendance.Columns.Add("Worked");
            dt_Attendance.Columns.Add("NoPay");
            dt_Attendance.Columns.Add("OT");
            #endregion

            dt_Attendance.Rows.Add("1", "General-09", "12.00", "-", "3.00");
            dt_Attendance.Rows.Add("2", "General-09", "12.00", "-", "3.00");
            dt_Attendance.Rows.Add("3", "General-09", "12.00", "-", "3.00");
            dt_Attendance.Rows.Add("4", "General-09", "12.00", "-", "3.00");
            dt_Attendance.Rows.Add("5", "General-09", "10.00", "-", "1.00");
            dt_Attendance.Rows.Add("6", "General-4.5", "4.50", "-", "0.00");
            dt_Attendance.Rows.Add("7", "-", "-", "-", "-");
            dt_Attendance.Rows.Add("8", "General-09", "9.00", "-", "0.00");
            dt_Attendance.Rows.Add("9", "General-09", "9.00", "-", "0.00");
            dt_Attendance.Rows.Add("10", "General-09", "9.00", "-", "0.00");
            dt_Attendance.Rows.Add("11", "General-09", "9.00", "-", "0.00");
            dt_Attendance.Rows.Add("12", "General-09", "9.00", "-", "0.00");
            dt_Attendance.Rows.Add("13", "General-4.5", "4.50", "-", "0.00");
            dt_Attendance.Rows.Add("14", "-", "-", "-", "-");
            dt_Attendance.Rows.Add("15", "General-09", "11.00", "-", "2.00");
            dt_Attendance.Rows.Add("16", "General-09", "11.00", "-", "2.00");
            dt_Attendance.Rows.Add("17", "General-09", "11.00", "-", "1.00");
            dt_Attendance.Rows.Add("18", "General-09", "11.00", "-", "1.00");
            dt_Attendance.Rows.Add("19", "General-09", "11.00", "-", "1.00");
            dt_Attendance.Rows.Add("20", "General-4.5", "4.50", "-", "0.00");
            dt_Attendance.Rows.Add("21", "-", "-", "-", "-");
            dt_Attendance.Rows.Add("22", "General-09", "00.00", "-", "-");
            dt_Attendance.Rows.Add("23", "General-09", "00.00", "-", "-");
            dt_Attendance.Rows.Add("24", "General-09", "11.00", "-", "2.00");
            dt_Attendance.Rows.Add("25", "General-09", "11.00", "-", "2.00");
            dt_Attendance.Rows.Add("26", "General-09", "11.00", "-", "2.00");
            dt_Attendance.Rows.Add("27", "General-4.5", "4.50", "-", "0.00");
            dt_Attendance.Rows.Add("28", "-", "-", "-", "-");
            dt_Attendance.Rows.Add("29", "General-09", "09.00", "-", "-");
            dt_Attendance.Rows.Add("30", "General-09", "09.00", "-", "-");
            dt_Attendance.Rows.Add("31", "General-09", "09.00", "-", "-");

            grdBalanceLeave.ItemsSource = dt_Attendance.DefaultView;
        } 
        #endregion
    }
}
