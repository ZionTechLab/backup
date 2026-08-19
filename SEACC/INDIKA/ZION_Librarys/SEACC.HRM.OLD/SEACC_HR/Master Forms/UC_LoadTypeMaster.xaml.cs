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
    /// Interaction logic for UC_LoadTypeMaster.xaml
    /// </summary>
    public partial class UC_LoadTypeMaster : UserControl
    {

        #region From Load
        public UC_LoadTypeMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Loan_Type_Master;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("Code");
            dgr_Main.dt.Columns.Add("Name");
            dgr_Main.dt.Columns.Add("Rate");
            #endregion

            #region Initialize Action Buttons
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "Code", 100);
            dgr_Main.Add_DatagridColoumn("Type Name", "Code", 150);
            dgr_Main.Add_DatagridColoumn("Rate %", "Rate", 100);
            #endregion

            ClearFields();
            RefreshGrid();
        } 
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(472);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLoanTypeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLoanTypeName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLoanInterest, true, true, false);

            txtLoanTypeID.Text = "";
            txtLoanTypeName.Text = "";
            txtLoanInterest.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtLoanTypeID.setReadOnlyStatus(true);
                txtLoanTypeID.Text = "<Auto Generate>";
            }
            else
                txtLoanTypeID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dgr_Main.dt.Rows.Add("LT/001", "Bike Loan", "0.00");
            dgr_Main.dt.Rows.Add("LT/001", "Staff Loan", "0.00");
            //grd_LoanTypeMaster.ItemsSource = dt.DefaultView;
        } 
        #endregion
    }
}
