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
    /// Interaction logic for UC_Staff_Loan.xaml
    /// </summary>
    public partial class UC_Staff_Loan : UserControl
    {
        #region Class Variables
        DataTable dtMain_History = new DataTable();
        DataTable dtMain_Settlment = new DataTable();
        #endregion

        #region form Load
        public UC_Staff_Loan()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Staff_Loan;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables
            #region Table Loan History
            dtMain_History.Columns.Add("LoanID");
            dtMain_History.Columns.Add("Amount");
            dtMain_History.Columns.Add("Start_Date");
            dtMain_History.Columns.Add("Installment");
            dtMain_History.Columns.Add("Outstanding");
            #endregion

            #region table Settlment
            dtMain_Settlment.Columns.Add("LoanID");
            dtMain_Settlment.Columns.Add("Inst_Date");
            dtMain_Settlment.Columns.Add("Installment");
            dtMain_Settlment.Columns.Add("Outstanding");
            #endregion
            #endregion

            RefreshGrid();
            ClearFields();
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

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLoanID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpNO, true, false, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtAmount, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txt_No_of_Installment, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtInstallmetAmount, true, false, false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dtMain_History.Rows.Add("LN/001", "10,000.00", "04/25/2015", "05", "0.00");
            dtMain_History.Rows.Add("LN/002", "10,000.00", "10/25/2015", "05", "8,000.00");
            grd_History.ItemsSource = dtMain_History.DefaultView;

            dtMain_Settlment.Rows.Add("LN/002", "10/10/2015", "2,000.00", "8,000.00");
            grd_Settlment.ItemsSource = dtMain_Settlment.DefaultView;

        } 
        #endregion
    }
}
