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
    /// Interaction logic for UC_LumpSum.xaml
    /// </summary>
    public partial class UC_LumpSum : UserControl
    {
        #region Class Variales
        DataTable dt; 
	    #endregion

        #region Form Load
        public UC_LumpSum()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Lump_Sum_Earnings_Creation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable
            dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Type");
            dt.Columns.Add("Description");
            dt.Columns.Add("Status");
            dt.Columns.Add("GLCode");
            #endregion

            #region Initialize Action buttons
            SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            clearFields();
            RefreshGrid();
        } 
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(500);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
            RefreshGrid();
        } 
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGLCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtType, true, false, false);
           cls_Formater.SetEnableDisable_DataGrid(grd_lumpsum, true, "#FF41B1E1", "#FFFFFF");

            txtDescription.Text = "";
            txtGLCode.Text = "";
            txtType.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCode.setReadOnlyStatus(true);
                txtCode.Text = "<Auto Generate>";
            }
            else
                txtCode.setReadOnlyStatus(false);
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dt.Clear();
            dt.Rows.Add("LS/001", "Bonus", "Sales Bonus", "Active", "78956425");
            dt.Rows.Add("LS/001", "Bonus", "Annual Bonus", "Active", "78956425");
            dt.Rows.Add("LS/001", "Incentive", "Production Incentive", "Active", "78956425");

            grd_lumpsum.ItemsSource = dt.DefaultView;
        } 
        #endregion

    }
}
