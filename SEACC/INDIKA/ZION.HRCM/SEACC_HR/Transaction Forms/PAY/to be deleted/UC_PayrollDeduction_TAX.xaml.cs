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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_PayrollDeduction_TAX.xaml
    /// </summary>
    public partial class UC_PayrollDeduction_TAX : UserControl
    {
        #region Class Variables
        DataTable dt = new DataTable();
        DataTable dt_TaxTable1 = new DataTable();
        DataTable dt_TaxTable2 = new DataTable(); 
        #endregion

        #region Form Load
        public UC_PayrollDeduction_TAX()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Payroll_Deduction_Taxes;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables
            dt.Columns.Add("Type");
            dt.Columns.Add("Code");
            dt.Columns.Add("PaidBY");

            //Tax Table
            dt_TaxTable1.Columns.Add("EarnCode");
            dt_TaxTable1.Columns.Add("Range1");
            dt_TaxTable1.Columns.Add("Range2");
            dt_TaxTable1.Columns.Add("Tax");
            dt_TaxTable1.Columns.Add("Rebart");

            //Tax Table2
            dt_TaxTable2.Columns.Add("EarnCode");
            dt_TaxTable2.Columns.Add("Range1");
            dt_TaxTable2.Columns.Add("Range2");
            dt_TaxTable2.Columns.Add("Tax");
            dt_TaxTable2.Columns.Add("Rebart");
            #endregion

            #region Initialize Action Buttons
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
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
                coloumnA.Width = new GridLength(470);
        } 
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //  throw new NotImplementedException();
        }
        
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRate, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCode, true, true, true);
           cls_Formater.SetEnableDisable_DataGrid(grd_taxtable, true, "#FF41B1E1", "#FFFFFF");
           cls_Formater.SetEnableDisable_DataGrid(Grd_TaxTable2, true, "#FF41B1E1", "#FFFFFF");
           cls_Formater.SetEnableDisable_DataGrid(grd_PayrollDeduction_TAX, true, "#FF41B1E1", "#FFFFFF");


            txtRate.Text = "";
            txtType.Text = "";
            dt.Clear();

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtType.setReadOnlyStatus(true);
                txtType.Text = "<Auto Generate>";
            }
            else
                txtType.setReadOnlyStatus(false);

            lblTable2Header.Visibility = Visibility.Hidden;
            Grd_TaxTable2.Visibility = Visibility.Hidden;

            lblTable1Header.Visibility = Visibility.Hidden;
            grd_taxtable.Visibility = Visibility.Hidden;

            btnAdd_tbl2.Visibility = Visibility.Hidden;
            btnSave_tbl_2.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Hidden;
            btnSave_tbl_2.Visibility = Visibility.Hidden;

        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dt.Rows.Add("TAX/001", "PAYE 1", "Employee");
            dt.Rows.Add("TAX/002", "PAYE 2", "Employee");
            dt.Rows.Add("TAX/003", "PAYE 3", "Employee");
            dt.Rows.Add("TAX/004", "PAYE 4", "Employee");
            dt.Rows.Add("TAX/005", "PAYE 5", "Employee");

            grd_PayrollDeduction_TAX.ItemsSource = dt.DefaultView;
        } 
        #endregion

        #region Grid Event - Grid Mouse Click
        private void grd_PayrollDeduction_TAX_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = grd_PayrollDeduction_TAX.SelectedItem;
                if (item != null)
                {
                    string GridID = (grd_PayrollDeduction_TAX.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (GridID == "TAX/001")
                    {
                        lblTable2Header.Visibility = Visibility.Hidden;
                        Grd_TaxTable2.Visibility = Visibility.Hidden;
                        lblTable1Header.Content = "Regular Profits From Employment";
                        lblTable1Header.Visibility = Visibility.Visible;
                        grd_taxtable.Visibility = Visibility.Visible;
                        btnAdd.Visibility = Visibility.Visible;
                        btnSave.Visibility = Visibility.Visible;
                        TaxTable1();
                    }
                    if (GridID == "TAX/004")
                    {
                        lblTable2Header.Visibility = Visibility.Visible;
                        Grd_TaxTable2.Visibility = Visibility.Visible;
                        lblTable1Header.Visibility = Visibility.Visible;
                        grd_taxtable.Visibility = Visibility.Visible;
                        btnAdd.Visibility = Visibility.Visible;
                        btnSave.Visibility = Visibility.Visible;
                        btnAdd_tbl2.Visibility = Visibility.Visible;
                        btnSave_tbl_2.Visibility = Visibility.Visible;
                        lblTable1Header.Content = "Non Citizens-Resident in country";
                        lblTable2Header.Content = "Non Citizens-Non Resident";
                        TaxTable1();
                        Taxtable2();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        private void TaxTable1()
        {
            dt_TaxTable1.Clear();
            dt_TaxTable1.Rows.Add("PAY/001","50,000.00","91,667.00","4.00","2,000.00");
            dt_TaxTable1.Rows.Add("PAY/002", "91,667.00", "133,337.00", "8.00", "5,667.00");
            dt_TaxTable1.Rows.Add("PAY/003", "133,337.00", "175,000.00", "12.00", "11,000.00");
            dt_TaxTable1.Rows.Add("PAY/004", "175,000.00", "216,667.00", "16.00", "18,000.00");
            dt_TaxTable1.Rows.Add("PAY/005", "216,667.00", "300,000.00", "20.00", "26,667.00");
            dt_TaxTable1.Rows.Add("PAY/006", "300,00.00", "   ", "34.00", "38,667.00");

            grd_taxtable.ItemsSource = dt_TaxTable1.DefaultView;
        }

        private void Taxtable2()
        {
            dt_TaxTable2.Clear();
            dt_TaxTable2.Rows.Add("PAY/001", "8,333.00", "50,000.00", "4.00", "333.00");
            dt_TaxTable2.Rows.Add("PAY/002", "50,000.00", "91,667.00", "8.00", "2,333.00");
            dt_TaxTable2.Rows.Add("PAY/003", "91,667.00", "133,333.00", "12.00", "6,000.00");
            dt_TaxTable2.Rows.Add("PAY/004", "133,333.00", "175,000.00", "16.00", "11,333.00");
            dt_TaxTable2.Rows.Add("PAY/005", "175,000.00", "258,334.00", "20.00", "18,33.00");
            dt_TaxTable2.Rows.Add("PAY/006", "258,334.00", "   ", "24.00", "28,666.00");

            Grd_TaxTable2.ItemsSource = dt_TaxTable2.DefaultView;
        }
    }
}
