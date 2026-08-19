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
using SEACC_WPFControls;
using DataTire;
using SEACC_Tender.UserControls;
using System.Data;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;

namespace SEACC_Tender.Transactions
{
    /// <summary>
    /// Interaction logic for UC_TenderSecurity.xaml
    /// </summary>
    public partial class UC_TenderSecurity : UserControl
    {
        DataTable dt = new DataTable();
        public UC_TenderSecurity()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.TenderSecurity;
            SEACC_Form.Initialize();

            dt.Columns.Add("LineNo", typeof(int));
            dt.Columns.Add("IndentNo", typeof(string));
            dt.Columns.Add("SecurityTypeID", typeof(int));
            dt.Columns.Add("SecurityType", typeof(string));
            dt.Columns.Add("RefNo", typeof(int));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("BankID", typeof(string));
            dt.Columns.Add("Bank", typeof(string));
            dt.Columns.Add("BranchID", typeof(string));
            dt.Columns.Add("Branch", typeof(string));
            dt.Columns.Add("Account", typeof(string));
            dgv_SecType.ItemsSource = dt.DefaultView;

            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            //this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;

            ClearFields();
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //private void Btn_Print_Click(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClearFields()
        {
            dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);

            txtCustomer.Text = "";
            txtTenderID.Text = "";

            txtCustomer.Tag = null;
            txtTenderID.Tag = null;

            //List<string> items = new List<string>();
            //object obj = typeof(SecurityItems).;
            //items.Add(obj);
            //lstSecurityItems.Items.Add(obj);
            //lstSecurityItems.ItemsSource = items;


            lstSecurityItems.Items.Clear();
            lstSecurityItems.ItemsSource = Common.clsHelpMethods.GetEnumDescription(typeof(SecurityItems));
            
        }

        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                ColumnA.Width = new GridLength(200);
            else
                ColumnA.Width = new GridLength(310);
        }

        private void txtTenderID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                txtTenderID.Tag = lstResult[0];
                txtTenderID.Text = lstResult[1];
                txtCustomer.Tag = lstResult[4];
                txtCustomer.Text = lstResult[5];
            }
        }

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerList);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Text = lstResult[1];
            }
        }

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            //Search_Forms.frmSearch RowDataSearch = new frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    txtItemCategory.Text = lstResult[0];
            //}
            if (txtTenderID.Text != "" && txtTenderID.Tag != null)
            {
                pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                pop_Event.IsOpen = true;
            }
            else
            {
                SEACCMessageBox.Show("Error", "Please Select the Tender Number...", MessageBoxButton.OK);
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgv_SecType.SelectedItem;
            if (selectedItem != null)
            {
                ((DataRowView)(dgv_SecType.SelectedItem)).Row.Delete();
            }
        }

        private void btn_PoPAdd_Click(object sender, RoutedEventArgs e)
        {
            //int irowID = dgv_SecType.SelectedIndex;
            //dt.Rows[irowID]["SecurityType"] = lstSecurityItems.SelectedValue;
            
            string sResult = lstSecurityItems.SelectedItem.ToString();
            int iResultID = lstSecurityItems.SelectedIndex;

            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            int iRow = dt.Rows.Count + 1;
            dt.Rows.Add(iRow, txtTenderID.Text, iResultID, sResult.ToString(), 0, 0, "", "", "","","");
            pop_Event.IsOpen = false;
            
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event.IsOpen = false;
        }

        private void dgv_SecType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var vDgv_Cell = dgv_SecType.CurrentCell;
            object item = dgv_SecType.SelectedItem;

            if (vDgv_Cell.Column.Header.ToString() == "Bank")
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.FactoringBanks);
                if (RowDataSearch.DialogResult == true)
                {
                    int irowID = dgv_SecType.SelectedIndex;
                    dt.Rows[irowID]["Bank"] = lstResult[1];
                    dt.Rows[irowID]["BankID"] = lstResult[0];
                }
            }
            else if (vDgv_Cell.Column.Header.ToString() == "Branch")
            {
                List<string> lstParameeters = new List<string>();
                string GridID = (dgv_SecType.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                if (GridID != null)
                {
                    lstParameeters.Add(GridID);
                }

                frmSearch RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.FactoringBankBranch);
                if (RowDataSearch.DialogResult == true)
                {
                    int irowID = dgv_SecType.SelectedIndex;
                    dt.Rows[irowID]["Branch"] = lstResult[4];
                    dt.Rows[irowID]["BranchID"] = lstResult[0];
                    dt.Rows[irowID]["Bank"] = lstResult[2];
                    dt.Rows[irowID]["BankID"] = lstResult[1];
                }
            }
        }

    }
}
