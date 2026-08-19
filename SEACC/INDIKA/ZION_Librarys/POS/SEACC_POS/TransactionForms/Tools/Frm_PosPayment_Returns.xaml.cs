using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SEACC_WPFControls;
using Digiteq_Logic;
using System.Data;
using SEACC_POS.Search_Forms;
using DataTire;
using System.Linq;

namespace SEACC_POS
{
    public partial class Frm_PosPayment_Returns : Window
    {
        #region Class Variable
        private BrushConverter bc = new BrushConverter();

        public decimal dTransactionGrandTotal = 0;

        public delegate void SaveEvent(object sender, RoutedEventArgs e);
        public SaveEvent TransactionSave;
        public SaveEvent TransactionPrint;
        public SaveEvent TransactionEnterAndTender;
        public SaveEvent PaymentSave;

        #endregion

        #region Form Load
        public Frm_PosPayment_Returns()
        {
            InitializeComponent();

            ClearFiels();
        }
        #endregion

        #region Form Usability Events / Form Responsiveness

        //Title Bar DragMove
        private void TitleGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Payment Window Close Button
        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        //Payment Window Key Press Event
        private void frmPayment_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }
        #endregion

        #region Button Events

        #region Transaction Action Buttons
        //Bill Print
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            TransactionPrint(sender, e);
        }

        //Transaction Save
        private void btnpaymentOk_Click(object sender, RoutedEventArgs e)
        {
            TransactionSave(sender, e);
        }

        //Transaction Save & Print Together
        private void btnPaymentEnterTender_Click(object sender, RoutedEventArgs e)
        {
            TransactionEnterAndTender(sender, e);
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFiels()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtCreditPeriod, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesRep, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerName, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerTelphone, true, false, false);

            txtCustomerName.Tag = clsHelpMethods_POS.Get_BranchCashCustomer_ID(clsSecurity.BranchID);
            txtCustomerName.Text = clsGenaralName.getName_Customer(txtCustomerName.Tag.ToString());
        }
        #endregion

        #region Search Events

        private void txtSalesRep_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.SalesRep);

            if (RowDataSearch.DialogResult == true)
            {
                txtSalesRep.Tag = lstResult[0];
                txtSalesRep.TextBox1.Text = lstResult[1];
            }
        }

        private void txtCustomerName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_CustomersWithBranches);

            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerName.Tag = lstResult[0];
                txtCustomerName.TextBox1.Text = lstResult[2];
                txtCustomerTelphone.TextBox1.Text = lstResult[5];
                txtCustomerAddress.TextBox1.Text = lstResult[6];

            }
        }

        private void txtCreditPeriod_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_CreditPeriod);

            if (RowDataSearch.DialogResult == true)
            {
                txtCreditPeriod.Text = lstResult[1];
            }
        }
        #endregion

        #region Key Press Events
        private void txtCustomerTelphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.SelectAll().FirstOrDefault(r => r.Telephone == txtCustomerTelphone.TextBox1.Text);
                if (oCustomer != null)
                {
                    txtCustomerName.Tag = oCustomer.Customer_ID;
                    txtCustomerName.TextBox1.Text = oCustomer.CustomerName;
                    txtCustomerTelphone.TextBox1.Text = oCustomer.Telephone;
                    txtCustomerAddress.TextBox1.Text = oCustomer.AddressRegister;
                }
                else
                {
                    txtCustomerName.Tag = null;
                    txtCustomerName.TextBox1.Text = "";
                    txtCustomerAddress.TextBox1.Text = "";

                    SEACCMessageBox.Show("Not Found...", "Customer details can not be found in the system.", MessageBoxButton.OK);

                }
            }
        }
        #endregion

    }
}
