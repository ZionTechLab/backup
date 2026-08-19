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
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_PayrollEarningsMaster.xaml
    /// </summary>
    public partial class UC_PayrollEarningsMaster : UserControl
    {
        DataTable dt = new DataTable();
        DataTable dt_Contain = new DataTable();
        public UC_PayrollEarningsMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_Earnings_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;

            dt.Columns.Add("EarningsCode");
            dt.Columns.Add("Type");
            dt.Columns.Add("Description");
            dt.Columns.Add("GLCode");
            dt.Columns.Add("Status");

            dt_Contain.Columns.Add("Code");
            dt_Contain.Columns.Add("Type");
            dt_Contain.Columns.Add("From");

        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearField();
            RefreshGrid();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearField()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEarningCodeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtGL, true, false, true);
           cls_Formater.SetEnableDisable_DataGrid(grd_PayrollEarning, true, "#FF41B1E1", "#FFFFFF");
           cls_Formater.SetEnableDisable_DataGrid(grd_Containings, true, "#FF41B1E1", "#FFFFFF");

            txtDescription.Text = "";
            txtType.Text = "";
            dt.Clear();
            dt_Contain.Clear();

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtEarningCodeID.setReadOnlyStatus(true);
                txtEarningCodeID.Text = "<Auto Generate>";
            }
            else
                txtEarningCodeID.setReadOnlyStatus(false);

            grd_Containings.Visibility = Visibility.Hidden;
            lblDeduction.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Hidden;


        }

        private void RefreshGrid()
        {
            dt.Clear();
            dt.Rows.Add("ERN/001", "Basic Salary", "Basic Salary", "451256", "Active");
            dt.Rows.Add("ERN/002", "Fixed Allowance", "Vehicle Rent Allowance", "451263", "Active");
            dt.Rows.Add("ERN/003", "Fixed Allowance", "Vehicle Fuel Allowance", "784256", "Active");
            dt.Rows.Add("ERN/004", "Fixed Allowance", "Communication Allowance", "784256", "Active");
            dt.Rows.Add("ERN/005", "Variable Allowance", "Attendance Incentive", "451475", "Active");

            grd_PayrollEarning.ItemsSource = dt.DefaultView;

        }

        private void SEACC_Form_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {

            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(550);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearField();
            RefreshGrid();
        }

        private void contains()
        {
            dt_Contain.Clear();
            dt_Contain.Rows.Add("PF1", "ETF3", "Employer");
            dt_Contain.Rows.Add("PF2", "EPF8", "Employee");
            dt_Contain.Rows.Add("PF1", "EPF12", "Employer");

            grd_Containings.ItemsSource = dt_Contain.DefaultView;
        }

        private void grd_PayrollEarning_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = grd_PayrollEarning.SelectedItem;
                if (item != null)
                {
                    string GridID = (grd_PayrollEarning.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (GridID == "ERN/001")
                    {
                        grd_Containings.Visibility = Visibility.Visible;
                        lblDeduction.Visibility = Visibility.Visible;
                        btnAdd.Visibility = Visibility.Visible;
                        btnSave.Visibility = Visibility.Visible;
                        contains();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

    }
}
