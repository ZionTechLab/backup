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
    /// Interaction logic for UC_EmployeeSalaryMaster.xaml
    /// </summary>
    public partial class UC_EmployeeSalaryMaster : UserControl
    {
        DataTable dt_Leave = new DataTable();
        DataTable dt_FixedPayemnt = new DataTable();
        DataTable dt_LumpSum = new DataTable();
        DataTable dt_StatDeduction = new DataTable();
        DataTable dt_Eduction = new DataTable();
        DataTable dt_Other = new DataTable();
        public UC_EmployeeSalaryMaster()
        {
            InitializeComponent();
          //  SEACC_Form.enmFormName = FormName.Employee_Salary_Master;
          //  SEACC_Form.Initialize();

            //Leaves
            dt_Leave.Columns.Add("LeaveType");
            dt_Leave.Columns.Add("EntitleLeave");
            dt_Leave.Columns.Add("PerMonth");
            dt_Leave.Columns.Add("OTable");
            dt_Leave.Columns.Add("OTRate");

            //FixedPayemnt
            dt_FixedPayemnt.Columns.Add("Amount");
            dt_FixedPayemnt.Columns.Add("EarningItem");
            dt_FixedPayemnt.Columns.Add("Period");
            dt_FixedPayemnt.Columns.Add("PF1");
            dt_FixedPayemnt.Columns.Add("PF2");
            dt_FixedPayemnt.Columns.Add("PF3");
            dt_FixedPayemnt.Columns.Add("Tax");
            dt_FixedPayemnt.Columns.Add("Printable");
            dt_FixedPayemnt.Columns.Add("GLCode");

            //Lump Sum
            dt_LumpSum.Columns.Add("Amount");
            dt_LumpSum.Columns.Add("EarnItem");
            dt_LumpSum.Columns.Add("Period");
            dt_LumpSum.Columns.Add("PF1");
            dt_LumpSum.Columns.Add("PF2");
            dt_LumpSum.Columns.Add("PF3");
            dt_LumpSum.Columns.Add("Tax");
            dt_LumpSum.Columns.Add("Printable");

            //Statutery Deduction
            dt_StatDeduction.Columns.Add("DeductFrom");
            dt_StatDeduction.Columns.Add("Item");
            dt_StatDeduction.Columns.Add("Percentage");
            dt_StatDeduction.Columns.Add("StartDate");
            dt_StatDeduction.Columns.Add("EndDate");
            dt_StatDeduction.Columns.Add("GLCOde");

            //Eduction
            dt_Eduction.Columns.Add("Amount");
            dt_Eduction.Columns.Add("PayType");
            dt_Eduction.Columns.Add("Valuedate");
            dt_Eduction.Columns.Add("StartDate");
            dt_Eduction.Columns.Add("EndDate");
            dt_Eduction.Columns.Add("Remarks");
            dt_Eduction.Columns.Add("Country");
            dt_Eduction.Columns.Add("BankCode");
            dt_Eduction.Columns.Add("BranchCode");
            dt_Eduction.Columns.Add("Account");
            dt_Eduction.Columns.Add("AccountName");
            dt_Eduction.Columns.Add("GLCode");


            //Other
            dt_Other.Columns.Add("DeductFrom");
            dt_Other.Columns.Add("Deductitem");
            dt_Other.Columns.Add("Percentage");
            dt_Other.Columns.Add("SatrtDate");
            dt_Other.Columns.Add("GLCode");
        }

        private void LeaveTable()
        {
            dt_Leave.Clear();
            dt_Leave.Rows.Add("Annual/Vacation", "14.00", "16 hrs", "Yes", "1.5");
            dt_Leave.Rows.Add("Casual", "07.00", "08 hrs", "Yes", "1.5");
            dt_Leave.Rows.Add("Medical", "07.00", "16 hrs", "Yes", "1.5");
            dt_Leave.Rows.Add("Maternity (Pre)", "14.00", "28 hrs", "Yes", "1.5");
            dt_Leave.Rows.Add("Maternity (Post)", "70.00", "200 hrs", "Yes", "1.5");
            dt_Leave.Rows.Add("Maternity (Baby Nursing)", "27.00", "31 hrs", "No", "0.0");
            dt_Leave.Rows.Add("Product Research & Dev.", "4.00", "32 hrs", "No", "0.0");

          //  grdBalanceLeave.ItemsSource = dt_Leave.DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //clsCommon.SetEnableDisable_DataGrid_NewGrid(grd_FixedPayement, true, "#FF009688", "#FFFFFF");
            //clsCommon.SetEnableDisable_DataGrid_NewGrid(grd_Institute, true, "#FF009688", "#FFFFFF");
            //clsCommon.SetEnableDisable_DataGrid_NewGrid(grd_lumpSum, true, "#FF009688", "#FFFFFF");
            //clsCommon.SetEnableDisable_DataGrid_NewGrid(grd_other, true, "#FF009688", "#FFFFFF");
            //clsCommon.SetEnableDisable_DataGrid_NewGrid(grd_StatDeduction, true, "#FF009688", "#FFFFFF");
            //clsCommon.SetEnableDisable_DataGrid_NewGrid(grdBalanceLeave, true, "#FF009688", "#FFFFFF");

            LeaveTable();
            FixedPayemnt();
            LumpSum();
            StatuteryDeduction();
            Institute();
            OtherDeduction();
        }

        private void FixedPayemnt()
        {
            dt_FixedPayemnt.Clear();
            dt_FixedPayemnt.Rows.Add("1,000,000.00", "Basic Salary", "Monthly", "ETF3", "EPF8", "EPF12", "PAYT1", "Yes", "4514525");
            dt_FixedPayemnt.Rows.Add("120,000.00", "Allowance-1", "Monthly", "ETF3", "EPF8", "EPF12", "PAYT1", "Yes", "4575825");
            dt_FixedPayemnt.Rows.Add("140,000.00", "Allowance-2", "Monthly", "None", "None", "None", "None", "No", "4512565");
            dt_FixedPayemnt.Rows.Add("160,000.00", "Allowance-3", "Monthly", "None", "None", "None", "None", "No", "7541256");
            dt_FixedPayemnt.Rows.Add("175,000.00", "Allowance-4", "Monthly", "None", "None", "None", "None", "No", "4751256");
            dt_FixedPayemnt.Rows.Add("180,000.00", "Allowance-5", "Monthly", "None", "None", "None", "None", "No", "75425625");

          //  grd_FixedPayement.ItemsSource = dt_FixedPayemnt.DefaultView;

        }

        private void LumpSum()
        {
            dt_LumpSum.Rows.Add("140,000.00", "Qtrly Sales Bonus", "2015-01-01", "None", "None", "None", "None", "No");
            dt_LumpSum.Rows.Add("750,000.00", "Annual Bonus", "2015-04-01", "None", "None", "None", "None", "No");

          //  grd_lumpSum.ItemsSource = dt_LumpSum.DefaultView;

        }

        private void StatuteryDeduction()
        {
            dt_StatDeduction.Clear();
            dt_StatDeduction.Rows.Add("Employer", "ETF3", "03.00", "2015-01-01", "2015-12-31", "1245263");
            dt_StatDeduction.Rows.Add("Employee", "ETF8", "08.00", "2015-01-01", "2015-12-31", "1245263");
            dt_StatDeduction.Rows.Add("Employer", "EPF12", "12.00", "2015-01-01", "2015-12-31", "4256248");
            dt_StatDeduction.Rows.Add("Employee", "Pension", "05.00", "2015-01-01", "2015-12-31", "78956");


         //   grd_StatDeduction.ItemsSource = dt_StatDeduction.DefaultView;
        }

        private void Institute()
        {
            dt_Eduction.Clear();
            dt_Eduction.Rows.Add("909,909.00", "Cheque", "2018-01-07", "2015-01-07", "2018-01-07", "Lease-Car", "Sri Lanka", "None", "None", "None", "HNB -O/A S.A.Fernando","152542");
            dt_Eduction.Rows.Add("100,000.00", "SLIPS", "2016-01-07", "2015-01-07", "2016-01-07", "Home Loan", "Sri Lanka", "7056", "010", "12542556", "HNB -O/A S.A.Fernando","49856");
            dt_Eduction.Rows.Add("100,000.00", "SWIFT", "2018-01-07", "2015-01-07", "2015-06-07", "Family Acct", "Australia", "3030", "112", "758458655", "CWB -O/A S.A.Fernando","452565");
            dt_Eduction.Rows.Add("100,000.00", "SLIPS", "2015-01-07", "2015-01-07", "2015-12-07", "Investment", "United Kingdom", "0101", "308", "4545758", "BAR -O/A S.A.Fernando","985645");

        //    grd_Institute.ItemsSource = dt_Eduction.DefaultView;
        }

        private void OtherDeduction()
        {
            dt_Other.Clear();
            dt_Other.Rows.Add("Employee", "Staff Welfare Fund", "01.00", "2015-01-01", "1245245");
            dt_Other.Rows.Add("Employee", "Death & Emerg Fund", "01.00", "2015-01-01", "457544245");

            //grd_other.ItemsSource = dt_Other.DefaultView;
        }

    }
}
