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
    /// Interaction logic for UC_PayrollDeductionCreation.xaml
    /// </summary>
    public partial class UC_PayrollDeductionCreation : UserControl
    {
        #region Class Variables
        DataTable dt = new DataTable();
        #endregion

        #region From Load
        public UC_PayrollDeductionCreation()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_Deduction_Creation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("Type");
            dt.Columns.Add("Code");
            dt.Columns.Add("Rate");
            dt.Columns.Add("DudctFrom");
            dt.Columns.Add("GLCode");
            #endregion

            #region Initialize Action Buttons
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        } 
        #endregion

        #region From Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
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
            RefreshGrid();
        }
        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region clear Fields

        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRate, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCode, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtGLCode, true, false, false);
           cls_Formater.SetEnableDisable_DataGrid(grd_PayrollDeduction, true, "#FF41B1E1", "#FFFFFF");

            txtCode.Text = "";
            txtGLCode.Text = "";
            txtRate.Text = "";
            txtType.Text = "";
            rad_Employee.IsChecked = true;

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtType.setReadOnlyStatus(true);
                txtType.Text = "<Auto Generate>";
            }
            else
                txtType.setReadOnlyStatus(false);

            dt.Clear();
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dt.Rows.Add("PF/001", "ETF3", "3.00", "Employer", "01234567890");
            dt.Rows.Add("PF/002", "EPF8", "8.00", "Employee", "01234567891");
            dt.Rows.Add("PF/003", "EPF12", "12.00", "Employer", "01234567892");
            dt.Rows.Add("PF/004", "SCF8", "8.00", "Employee", "01234567892");

            grd_PayrollDeduction.ItemsSource = dt.DefaultView;
        } 
        #endregion
    }
}
