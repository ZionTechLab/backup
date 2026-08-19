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
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_BirthdayEmailSender.xaml
    /// </summary>
    public partial class frm_BirthdayEmailSender : Window
    {
        public DataTable dt_EmpBirthdays = new DataTable();

        public frm_BirthdayEmailSender()
        {
            InitializeComponent();

            dt_EmpBirthdays.Columns.Add("Line No" , typeof(int));
            dt_EmpBirthdays.Columns.Add("IsSelect");
            dt_EmpBirthdays.Columns.Add("Emp No");
            dt_EmpBirthdays.Columns.Add("EPF No");
            dt_EmpBirthdays.Columns.Add("Employee Name");
            dt_EmpBirthdays.Columns.Add("Alias Name");
            dt_EmpBirthdays.Columns.Add("Age");
        }

        public void RefreshGrid(DateTime dtm)
        {
            dt_EmpBirthdays.Clear();

            lbl_popupHeader.Content = "Employee Birthdays on " + dtm.Date.ToString(cls_Formater.Format_Date2);
            int iCount = 0;
            foreach (tbl_genMasEmployee oEmployee in tbl_genMasEmployee.SelectAll().Where(r => r.DateOfBirth.Date != clsValidation.defaultDateTime.Date &&
                                                                                                 r.DateOfBirth.Month == dtm.Date.Month &&
                                                                                                 r.DateOfBirth.Day == dtm.Date.Day &&
                                                                                                 r.Emp_statusID != ((int)(EmployeeStatus.Resigned)).ToString() &&
                                                                                                 !r.IsCanceled))
            {
                dt_EmpBirthdays.Rows.Add(++iCount, "\uE003", oEmployee.Employee_ID, oEmployee.EpfNo, oEmployee.Initails + " " + oEmployee.SurName, oEmployee.AliasName, (dtm.Date.Date - oEmployee.DateOfBirth.Date).Days / 365);
            }
            dgr_Birthdays.ItemsSource = dt_EmpBirthdays.DefaultView;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void dgr_Birthdays_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Birthdays.SelectedIndex;
            var vDG_Cell = dgr_Birthdays.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                {
                    bool bIsChecked = false;
                    bIsChecked = dt_EmpBirthdays.Rows[irowID]["IsSelect"].ToString() == "\uE0A2" ? true : false;
                    dt_EmpBirthdays.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";
                }
            }
            catch (Exception) { }
        }

        private void chk_selectAllEmployees_Checked(object sender, RoutedEventArgs e)
        {
            dt_EmpBirthdays.Select().ToList<DataRow>().ForEach(r => { r["IsSelect"] = "\uE0A2"; });
        }

        private void chk_selectAllEmployees_Unchecked(object sender, RoutedEventArgs e)
        {
            dt_EmpBirthdays.Select().ToList<DataRow>().ForEach(r => { r["IsSelect"] = "\uE003"; });
        }
    }
}
