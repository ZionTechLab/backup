using System;
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
using Digiteq_Logic_POS;
using SEACC_POS.Common;

namespace SEACC_POS
{
    public partial class Frm_PosPayment_Sales : Window
    {
        #region Class Variable
        private BrushConverter bc = new BrushConverter();

        public decimal dTransactionGrandTotal = 0;

        public DataTable dtCardPayment = new DataTable();
        public DataTable dtGiftVoucherPayment = new DataTable();
        public DataTable dtChequePayment = new DataTable();
        public DataTable dtCRN_SalesReturn = new DataTable();
        public DataTable dtAdvance = new DataTable();

        public delegate void SaveEvent(object sender, RoutedEventArgs e);
        public SaveEvent TransactionSave;
        public SaveEvent TransactionPrint;
        public SaveEvent TransactionEnterAndTender;
        public SaveEvent PaymentSave;
        public SaveEvent MallRewards;
        #endregion

        #region Form Load
        public Frm_PosPayment_Sales()
        {
            InitializeComponent();

            #region Initialize Data Tables
            //Payment History
            dgrPayment_Receipts.dt.Columns.Add("LineNo");
            dgrPayment_Receipts.dt.Columns.Add("Receipt_ID");
            dgrPayment_Receipts.dt.Columns.Add("Receipt_Date");
            dgrPayment_Receipts.dt.Columns.Add("CashAmount", typeof(decimal));
            dgrPayment_Receipts.dt.Columns.Add("CashBalanceAmount", typeof(decimal));
            dgrPayment_Receipts.dt.Columns.Add("TotalAmount", typeof(decimal));

            //Card Payment
            dtCardPayment.Columns.Add("LineNo");
            dtCardPayment.Columns.Add("CardTypeID");
            dtCardPayment.Columns.Add("CardType");
            dtCardPayment.Columns.Add("NameOnCard");
            dtCardPayment.Columns.Add("LastFourDigits");
            dtCardPayment.Columns.Add("BankID");
            dtCardPayment.Columns.Add("Bank");
            dtCardPayment.Columns.Add("Amount", typeof(decimal));

            //Gift Voucher Payments
            dtGiftVoucherPayment.Columns.Add("LineNo");
            dtGiftVoucherPayment.Columns.Add("VoucherID");
            dtGiftVoucherPayment.Columns.Add("VoucherNo");//Serial No
            dtGiftVoucherPayment.Columns.Add("DateValidFrom");
            dtGiftVoucherPayment.Columns.Add("DateValidTo");
            dtGiftVoucherPayment.Columns.Add("VoucherAmount", typeof(decimal));

            //Cheque Payments
            dtChequePayment.Columns.Add("LineNo");
            dtChequePayment.Columns.Add("Account_No");
            dtChequePayment.Columns.Add("BankID");
            dtChequePayment.Columns.Add("Bank");
            dtChequePayment.Columns.Add("BankBranchID");
            dtChequePayment.Columns.Add("BankBranch");
            dtChequePayment.Columns.Add("ChequeNo");
            dtChequePayment.Columns.Add("ChequeDate");
            dtChequePayment.Columns.Add("ChequeAmount", typeof(decimal));

            //CRNs - Sales Returns
            dtCRN_SalesReturn.Columns.Add("LineNo");
            dtCRN_SalesReturn.Columns.Add("CRN_Index");
            dtCRN_SalesReturn.Columns.Add("CRN_ID");
            dtCRN_SalesReturn.Columns.Add("CRN_Amount", typeof(decimal));

            //Adavnce
            dtAdvance.Columns.Add("LineNo");
            dtAdvance.Columns.Add("Advance_Index");
            dtAdvance.Columns.Add("Advance_ID");
            dtAdvance.Columns.Add("Advance_Amount", typeof(decimal));

            #endregion

            #region Initialize Data Grids
            dgrPayment_Receipts.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LineNo", 25, true, true);
            dgrPayment_Receipts.Add_DatagridColoumn("ID", "Receipt_ID", 50, false);
            dgrPayment_Receipts.Add_DatagridColoumn("Date", "Receipt_Date", 85);
            dgrPayment_Receipts.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "TotalAmount", 85, true, true);

            //Initialize Data Payment Grids
            dgrCardPays.ItemsSource = dtCardPayment.DefaultView;
            dgrGiftVoucher.ItemsSource = dtGiftVoucherPayment.DefaultView;
            dgrCheques.ItemsSource = dtChequePayment.DefaultView;
            dgrCRN_SalesReturn.ItemsSource = dtCRN_SalesReturn.DefaultView;
            dgrAdvance.ItemsSource = dtAdvance.DefaultView;
            #endregion
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

        #region Payment Method Buttons
        private void btnCashPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(1);
        }

        private void btnCardPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(2);
        }

        private void btnPDCheques_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(4);
        }

        private void btnGiftVouchers_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(3);
        }
        #endregion

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

        #region Card Payment Grid Buttons
        private void btnCardPaymentDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrCardPays.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrCardPays.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtCardPayment.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtCardPayment.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtCardPayment);
                Refresh_SelectedPosReceiptDetails();
            }
        }
        private void btnCardPaymentAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity_CardPayment())
                dtCardPayment.Rows.Add("0", cmbCardType.GetSelectedIndex(), cmbCardType.GetSelectedValue(),
                    txtNameOnCard.Text, txtCardLast4Digits.Text, txtCardBank.Tag.ToString(), txtCardBank.Text,
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtCardPayAmount.Text), clsConfig.sPOSBillDecimalPoint));

            Refresh_SelectedPosReceiptDetails();
            ClearFields_CardPayments();
        }
        #endregion

        #region Cheque payment Grid Buttons
        private void btnChequePaymentAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity_EmptyField_PDCheque())
            {
                dtChequePayment.Rows.Add("0", txtChequeAccoutNo.Text, txtChequeBankName.Tag.ToString(), txtChequeBankName.Text,
                    txtChequeBankBranch.Tag.ToString(), txtChequeBankBranch.Text, txtChequeNo.Text, dtpChequeDate.GetDateTime().ToString(cls_Formater.Format_Date2),
                    cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(txtChequeAmount.Text), clsConfig.sPOSBillDecimalPoint));

                Refresh_SelectedPosReceiptDetails();
                ClearFields_ChequePayments();
            }
        }

        private void btnChequePaymentDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrCheques.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrCheques.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtChequePayment.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtChequePayment.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtChequePayment);

                Refresh_SelectedPosReceiptDetails();
            }
        }
        #endregion

        #region Gift Voucher Grid Buttons
        private void btnGiftVoucherDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrGiftVoucher.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrGiftVoucher.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtGiftVoucherPayment.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtGiftVoucherPayment.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtGiftVoucherPayment);

                Refresh_SelectedPosReceiptDetails();
            }
        }

        private void btnGiftVoucherAdd_Click(object sender, RoutedEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.Pos_GiftVouchers_Issued);

            if (rowDataSearch.DialogResult == true)
            {
                DataRow[] items = dtGiftVoucherPayment.Select("VoucherID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                {
                    dtGiftVoucherPayment.Rows.Add("0", lstResult[0], lstResult[1], "", "",
                        cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(lstResult[4]),
                            clsConfig.sPOSBillDecimalPoint));
                }
                else
                {
                    SEACCMessageBox.Show("Gift Voucher Already Exist",
                        "", MessageBoxButton.YesNo, "Red");
                }
            }

            Refresh_SelectedPosReceiptDetails();
        }
        #endregion

        #region POS Receipt Action Buttons
        //New POS Receipt 
        private void btnNewpayment_Click(object sender, RoutedEventArgs e)
        {
            ClearFields_forReceiptDetails();
            Refresh_SelectedPosReceiptDetails();
        }

        //Save or Update New POS Receipt
        private void btnSavepayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentSave(sender, e);
        }
        #endregion

        #endregion

        #region Clear Fields
        public void ClearFields_forReceiptDetails()
        {
            #region Commons
            //Payment Common
            cls_Formater.SetEnableDisable_LableTextbox(txtWarrantyDescription, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGreetngDescription, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCreditPeriod, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesRep, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerName, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerTelphone, true, false, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReceipt_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCashPaymentstotal, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCardPaymentsTotal, true, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtChequesAmountTotal, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGiftVoucherTotal, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCRN_Total, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAdvance_Total, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRewardTotal, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReceiptTenderedTotal, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAllReceiptTotal, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReceiptBalance, true, true, false);

            tbGrandtotal.Tag = null;
            txtReceipt_ID.Tag = null;
            txtCashPaymentstotal.Tag = null;
            txtCardPaymentsTotal.Tag = null;
            txtChequesAmountTotal.Tag = null;
            txtGiftVoucherTotal.Tag = null;
            txtCRN_Total.Tag = null;
            txtAdvance_Total.Tag = null;
            txtRewardTotal.Tag = null;
            txtReceiptTenderedTotal.Tag = null;
            txtAllReceiptTotal.Tag = null;
            txtReceiptBalance.Tag = null;

            tbGrandtotal.Text = cls_Formater.FormatDecimal(dTransactionGrandTotal, clsConfig.sPOSBillDecimalPoint);
            txtReceipt_ID.TextBox1.Text = "";
            txtCashPaymentstotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtCardPaymentsTotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtChequesAmountTotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtGiftVoucherTotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtCRN_Total.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtAdvance_Total.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtRewardTotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtReceiptTenderedTotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtAllReceiptTotal.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            txtReceiptBalance.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            //Payemt Mode----------------------------
            rdoFullPayment.IsChecked = true;
            rdoPartPayment.IsChecked = false;
            rdoAdavancePayment.IsChecked = false;

            rdoFullPayment.IsEnabled = true;
            rdoPartPayment.IsEnabled = true;
            rdoAdavancePayment.IsEnabled = true;

            if (clsConfig_POS.bHide_AdvancePartPayment_Option)
            {
                rdoFullPayment.IsChecked = true;
                rdoPartPayment.IsChecked = false;
                rdoAdavancePayment.IsChecked = false;

                rdoFullPayment.IsEnabled = false;
                rdoPartPayment.IsEnabled = false;
                rdoAdavancePayment.IsEnabled = false;

                rdoPartPayment.Visibility = Visibility.Hidden;
                rdoAdavancePayment.Visibility = Visibility.Hidden;
            }

            //-----------------------------------------

            chkDefaultReportPrint.IsChecked = true;

            txtSalesRep.Tag = null;
            txtCustomerName.Tag = null;
            txtCustomerTelphone.Tag = null;
            txtCustomerAddress.Tag = null;

            txtSalesRep.TextBox1.Text = "";
            txtCustomerName.TextBox1.Text = "";
            txtCustomerTelphone.TextBox1.Text = "";
            txtCustomerAddress.TextBox1.Text = "";

            txtWarrantyDescription.TextBox1.Text = "";
            txtGreetngDescription.TextBox1.Text = "";
            txtCreditPeriod.TextBox1.Text = "0";

            if (clsConfig_POS.bCapslockLtterst_R2_Pos_Textbox)
            {
                txtCustomerName.TextBox1.CharacterCasing = CharacterCasing.Upper;
                txtCustomerAddress.TextBox1.CharacterCasing = CharacterCasing.Upper;
            }

            txtCustomerName.Tag = null;
            txtCustomerName.Tag = clsHelpMethods_POS.Get_BranchCashCustomer_ID(clsSecurity.BranchID);
            txtCustomerName.TextBox1.Text = clsGenaralName.getName_Customer(txtCustomerName.Tag.ToString());

            #endregion

            #region Cash
            // Payment Cash
            cls_Formater.SetEnableDisable_LableTextbox(txtCashReceived, true, true, false);

            txtCashReceived.Tag = null;
            txtCashReceived.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            PaymentMethodsVisibility(1);
            #endregion

            #region Payment Card
            // Payment Card
            ClearFields_CardPayments();
            dtCardPayment.Rows.Clear();
            #endregion

            #region Gift Voucher
            //Gift Voucher Payments
            dtGiftVoucherPayment.Rows.Clear();
            #endregion

            #region Cheques
            //Cheques
            ClearFields_ChequePayments();
            dtChequePayment.Rows.Clear();
            #endregion

            #region Credit Notes
            //CRN Payments
            dtCRN_SalesReturn.Rows.Clear();
            #endregion

            #region Advance Payments
            //CRN Payments
            dtAdvance.Rows.Clear();
            #endregion

            #region One GalleFace Rewards
            // Payment Rewards
            cls_Formater.SetEnableDisable_LableTextbox(txtRewardAmount, true, true, false);

            txtRewardAmount.Tag = null;
            txtRewardAmount.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            #endregion
        }

        private void ClearFields_ChequePayments()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeAccoutNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtChequeBankName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtChequeBankBranch, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeNo, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeAmount, true, true, false);

            txtChequeAccoutNo.Tag = null;
            txtChequeBankName.Tag = null;
            txtChequeBankBranch.Tag = null;
            txtChequeNo.Tag = null;
            txtChequeAmount.Tag = null;

            txtChequeAccoutNo.TextBox1.Text = "";
            txtChequeBankName.TextBox1.Text = "<Select Bank>";
            txtChequeBankBranch.TextBox1.Text = "<Select Bank Branch>";
            txtChequeNo.TextBox1.Text = "";
            txtChequeAmount.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
        }

        private void ClearFields_CardPayments()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMerchantDevice, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNameOnCard, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCardLast4Digits, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCardBank, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCardPayAmount, true, true, false);

            txtMerchantDevice.Tag = null;
            txtNameOnCard.Tag = null;
            txtCardLast4Digits.Tag = null;
            txtCardBank.Tag = null;
            txtCardPayAmount.Tag = null;

            txtMerchantDevice.TextBox1.Text = "";
            txtNameOnCard.TextBox1.Text = "";
            txtCardBank.TextBox1.Text = "<Select Bank>";
            txtCardPayAmount.TextBox1.Text = "";
            txtCardLast4Digits.TextBox1.Text = "";
            txtCardPayAmount.TextBox1.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);

            txtCardLast4Digits.TextBox1.MaxLength = 4;

            cmbCardType.comboBox.ItemsSource = clsHelpMethods_POS.GetEnumDescription_List(typeof(PaymentCardTypes));
            cmbCardType.SetSelectedIndex((int)PaymentCardTypes.Visa);

            tbl_genMerchantDeviceMaster oDefaultDevice = tbl_genMerchantDeviceMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.IsActive && r.IsDefaultMachine && !r.IsCanceled);
            if (oDefaultDevice != null)
            {
                txtMerchantDevice.Tag = oDefaultDevice.Merchant_DeviceID;
                txtMerchantDevice.TextBox1.Text = oDefaultDevice.Device_Name;
            }
        }

        #endregion

        #region Refresh Window
        //Refresh with selected POS Receipt (POS Receipt Detail Section)
        public void Refresh_SelectedPosReceiptDetails()
        {
            decimal dCashReceived = clsValidation.Validate_DecimalNumber(txtCashReceived.TextBox1.Text);
            decimal dCashPaymentstotal = dCashReceived;
            decimal dCardPaymentsTotal = clsValidation.Validate_DecimalNumber(dtCardPayment.Compute("SUM(Amount)", "").ToString());
            decimal dChequesTotal = clsValidation.Validate_DecimalNumber(dtChequePayment.Compute("SUM(ChequeAmount)", "").ToString());
            decimal dGiftVoucherTotal = clsValidation.Validate_DecimalNumber(dtGiftVoucherPayment.Compute("SUM(VoucherAmount)", "").ToString());
            decimal dCRNTotal = clsValidation.Validate_DecimalNumber(dtCRN_SalesReturn.Compute("SUM(CRN_Amount)", "").ToString());
            decimal dAdvanceTotal = clsValidation.Validate_DecimalNumber(dtAdvance.Compute("SUM(Advance_Amount)", "").ToString());
            decimal dRewardAmount = clsValidation.Validate_DecimalNumber(txtRewardAmount.TextBox1.Text);

            txtCashPaymentstotal.TextBox1.Text = cls_Formater.FormatDecimal(dCashPaymentstotal, clsConfig.sPOSBillDecimalPoint);
            txtCardPaymentsTotal.TextBox1.Text = cls_Formater.FormatDecimal(dCardPaymentsTotal, clsConfig.sPOSBillDecimalPoint);
            txtChequesAmountTotal.TextBox1.Text = cls_Formater.FormatDecimal(dChequesTotal, clsConfig.sPOSBillDecimalPoint);
            txtGiftVoucherTotal.TextBox1.Text = cls_Formater.FormatDecimal(dGiftVoucherTotal, clsConfig.sPOSBillDecimalPoint);
            txtCRN_Total.TextBox1.Text = cls_Formater.FormatDecimal(dCRNTotal, clsConfig.sPOSBillDecimalPoint);
            txtAdvance_Total.TextBox1.Text = cls_Formater.FormatDecimal(dAdvanceTotal, clsConfig.sPOSBillDecimalPoint);
            txtRewardTotal.TextBox1.Text = cls_Formater.FormatDecimal(dRewardAmount, clsConfig.sPOSBillDecimalPoint);

            decimal dReceiptTotal = dCashPaymentstotal + dCardPaymentsTotal + dChequesTotal + dGiftVoucherTotal + dCRNTotal + dAdvanceTotal + dRewardAmount;
            txtReceiptTenderedTotal.TextBox1.Text = cls_Formater.FormatDecimal(dReceiptTotal, clsConfig.sPOSBillDecimalPoint);

            Refresh_PosTransactionSummary();
        }

        //Refresh POS Transaction Summary Section
        public void Refresh_PosTransactionSummary()
        {
            decimal dGrandTotal = clsValidation.Validate_DecimalNumber(tbGrandtotal.Text);
            decimal dAdvanceTotal = clsValidation.Validate_DecimalNumber(dgrPayment_Receipts.dt.Compute("SUM(TotalAmount)", "").ToString());
            decimal dBalance = dGrandTotal - dAdvanceTotal;

            txtAllReceiptTotal.TextBox1.Text = cls_Formater.FormatDecimal(dAdvanceTotal, clsConfig.sPOSBillDecimalPoint);

            //Customer Setup
            DataRow dr = dgrPayment_Receipts.dt.Select().FirstOrDefault();
            if (dr != null)
            {
                tbl_posReceipt oReceipt = tbl_posReceipt.Select(dr["Receipt_ID"].ToString());
                if (oReceipt != null)
                {
                    txtCustomerName.Tag = oReceipt.Customer_ID;
                    txtCustomerName.TextBox1.Text = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                    PayOptionRadioButtonSetup(oReceipt.Customer_ID);
                }
            }
        }
        #endregion

        #region Check validity

        #region Card Payment Validity
        private bool CheckValidity_CardPayment()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField_Card())
            {
                if (CheckValidity_CardNuumber())
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField_Card()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtCardLast4Digits))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCardBank) || txtCardBank.Tag == null)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCardPayAmount))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_CardNuumber()
        {
            bool bStatus = true;

            if (txtCardLast4Digits.TextBox1.Text.Length != 4)
            {
                SEACCMessageBox.Show("Ops..!", "Last 4 digites of card are not valid...", MessageBoxButton.OK, "Red");
                bStatus = false;
            }

            return bStatus;
        }
        #endregion

        #region Cheque Payment Validity
        private bool CheckValidity_EmptyField_PDCheque()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtChequeBankName) || txtChequeBankName.Tag == null)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtChequeBankBranch) || txtChequeBankBranch.Tag == null)
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtChequeNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtChequeAmount))
                bStatus = false;

            return bStatus;
        }
        #endregion

        #endregion

        #region Fill Details
        public void FillDetails_PosReceipts(tbl_posTransaction oPoSTx)
        {

            //Grand Total
            tbGrandtotal.Text = cls_Formater.FormatDecimal(oPoSTx.GrandTotal, clsConfig.sPOSBillDecimalPoint);

            //Full Payment Identity
            bool bFullPayment = false;

            dgrPayment_Receipts.dt.Clear();
            foreach (tbl_posReceipt oTxReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPoSTx.PosTransaction_Index).OrderByDescending(r => r.PosReceiptDate))
            {
                tbl_posReceipt oReceipt = tbl_posReceipt.Select(oTxReceipt.PosReceipt_ID);
                bFullPayment = oReceipt.IsFullPayment;

                dgrPayment_Receipts.dt.Rows.Add("0", oReceipt.PosReceipt_ID,
                    oReceipt.PosReceiptDate.ToString(cls_Formater.Format_Date2),
                    cls_Formater.FormatDecimal(oReceipt.CashAmount, clsConfig.sPOSBillDecimalPoint),
                    cls_Formater.FormatDecimal(oReceipt.PosTxBalanceAmount, clsConfig.sPOSBillDecimalPoint),
                    cls_Formater.FormatDecimal(oReceipt.TotalAmount, clsConfig.sPOSBillDecimalPoint));
            }

            dgrPayment_Receipts.RefreshGrid();
            clsHelpMethods_POS.OrderBy_DataGrid(dgrPayment_Receipts.dt);

            decimal dAdvanceTotal = clsValidation.Validate_DecimalNumber(dgrPayment_Receipts.dt.Compute("SUM(TotalAmount)", "").ToString());
            decimal dBalance = oPoSTx.GrandTotal - dAdvanceTotal;
            txtAllReceiptTotal.TextBox1.Text = cls_Formater.FormatDecimal(dAdvanceTotal, clsConfig.sPOSBillDecimalPoint);

            if (dgrPayment_Receipts.dt.Rows.Count > 0 && !bFullPayment)
            {
                btnNewReceipt.Visibility = Visibility.Visible;
                btnSaveReceipt.Visibility = Visibility.Visible;
            }
            else
            {
                btnNewReceipt.Visibility = Visibility.Hidden;
                btnSaveReceipt.Visibility = Visibility.Hidden;
            }

            //Selected Grid Row
            if (dgrPayment_Receipts.dt.Rows.Count > 0)
            {
                dgrPayment_Receipts.grdMain.SelectedIndex = 0;
                string sID = dgrPayment_Receipts.dt.Rows[0]["Receipt_ID"].ToString();

                tbl_posReceipt oPosReceipt = tbl_posReceipt.Select(sID);
                if (oPosReceipt != null)
                {
                    tbl_posTransaction oPosTransaction = tbl_posTransaction.Select(oPosReceipt.PosTransaction_Index);

                    ClearFields_forReceiptDetails();
                    FillDetails_PaymentRegisterDetails_SelectedReceipt(oPosTransaction, oPosReceipt);
                }
                else
                {
                    ClearFields_forReceiptDetails();
                }
            }

            //Customer
            txtCustomerName.Tag = oPoSTx.Customer_ID;
            txtCustomerName.TextBox1.Text = clsGenaralName.getName_Customer(oPoSTx.Customer_ID);
            txtCustomerAddress.TextBox1.Text = clsGenaralName.getName_CustomerRegisterAddress(oPoSTx.Customer_ID);
            txtCustomerTelphone.TextBox1.Text = clsGenaralName.getName_CustomerTelephone(oPoSTx.Customer_ID);
            PayOptionRadioButtonSetup(oPoSTx.Customer_ID);
        }

        public void FillDetails_PaymentRegisterDetails_SelectedReceipt(tbl_posTransaction oPoSTx, tbl_posReceipt oPoSReceipt)
        {
            txtReceipt_ID.Tag = oPoSReceipt.PosReceipt_ID;

            //tbGrandtotal
            tbGrandtotal.Text = cls_Formater.FormatDecimal(oPoSTx.GrandTotal, clsConfig.sPOSBillDecimalPoint);
            txtReceipt_ID.TextBox1.Text = oPoSReceipt.PosReceipt_ID;
            txtReceiptTenderedTotal.TextBox1.Text = cls_Formater.FormatDecimal(oPoSReceipt.TotalAmount, clsConfig.sPOSBillDecimalPoint);

            //Cash Payment
            txtCashReceived.TextBox1.Text = cls_Formater.FormatDecimal(oPoSReceipt.CashAmount, clsConfig.sPOSBillDecimalPoint);
            txtReceiptBalance.TextBox1.Text = cls_Formater.FormatDecimal(oPoSReceipt.PosTxBalanceAmount, clsConfig.sPOSBillDecimalPoint);

            //Card Payments
            foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Card && r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString() && r.PosReceipt_ID == oPoSReceipt.PosReceipt_ID))
            {
                string sCardOwnerName = !string.IsNullOrEmpty(oPaymentReg.CardOwnerName) ? clsSecurity.decryptPassword(oPaymentReg.CardOwnerName) : oPaymentReg.CardOwnerName;
                string sLastFourDigits = !string.IsNullOrEmpty(oPaymentReg.LastFourDigits) ? clsSecurity.decryptPassword(oPaymentReg.LastFourDigits) : oPaymentReg.LastFourDigits;

                dtCardPayment.Rows.Add("0", oPaymentReg.CardType,
                    clsHelpMethods_POS.GetEnumDescription((PaymentCardTypes)oPaymentReg.CardType),
                    sCardOwnerName,
                    sLastFourDigits,
                    oPaymentReg.Bank_ID,
                    clsGenaralName.getShortName_Bank(oPaymentReg.Bank_ID), cls_Formater.FormatDecimal(oPaymentReg.Amount, clsConfig.sPOSBillDecimalPoint));
            }
            dgrCardPays.ItemsSource = dtCardPayment.DefaultView;

            //Gift Voucher Payments
            foreach (tbl_bpsChequeRegister oPaymentReg in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher && r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString() && r.PosReceipt_ID == oPoSReceipt.PosReceipt_ID))
            {
                tbl_bpsGiftVoucher oGiftVoucher = tbl_bpsGiftVoucher.Select(oPaymentReg.GiftVoucherID);
                if (oGiftVoucher != null)
                    dtGiftVoucherPayment.Rows.Add("0", oPaymentReg.GiftVoucherID, oGiftVoucher.SerialNo,
                        oGiftVoucher.DateValidFrom.ToString(cls_Formater.Format_Date2), oGiftVoucher.ExpiryDate.ToString(cls_Formater.Format_Date2),
                        cls_Formater.FormatDecimal(oGiftVoucher.VoucherAmount, clsConfig.sPOSBillDecimalPoint));
            }
            dgrGiftVoucher.ItemsSource = dtGiftVoucherPayment.DefaultView;

            //Cheque Payments
            foreach (tbl_bpsChequeRegister oCheqPaymentReg in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Cheque && r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString() && r.PosReceipt_ID == oPoSReceipt.PosReceipt_ID))
            {
                dtChequePayment.Rows.Add("0", oCheqPaymentReg.AccountNumber, oCheqPaymentReg.Bank_ID, clsGenaralName.getShortName_Bank(oCheqPaymentReg.Bank_ID), oCheqPaymentReg.Branch_ID, clsGenaralName.getName_BankBranch(oCheqPaymentReg.Branch_ID), oCheqPaymentReg.ChequeNumber, oCheqPaymentReg.DateCheque.ToString(cls_Formater.Format_Date2), cls_Formater.FormatDecimal(oCheqPaymentReg.Amount, clsConfig.sPOSBillDecimalPoint));
            }
            dgrCheques.ItemsSource = dtChequePayment.DefaultView;

            //Credit Note Payments
            dtCRN_SalesReturn.Rows.Clear();
            foreach (tbl_bpsChequeRegister oPCRN_Payment in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Credit_Note && r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString() && r.PosReceipt_ID == oPoSReceipt.PosReceipt_ID))
            {
                tbl_posTransaction oPCRN = tbl_posTransaction.Select(oPCRN_Payment.PosReturnTransaction_Index);
                if (oPCRN != null)
                {
                    //CRNs
                    dtCRN_SalesReturn.Rows.Add("0", oPCRN_Payment.PosReturnTransaction_Index, oPCRN.PosTransaction_ID, cls_Formater.FormatDecimal(oPCRN_Payment.Amount, clsConfig.sPOSBillDecimalPoint));
                }
            }
            dgrCRN_SalesReturn.ItemsSource = dtCRN_SalesReturn.DefaultView;

            //Advance Payments
            dtAdvance.Rows.Clear();
            foreach (tbl_bpsChequeRegister oPCRN_Payment in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Advance_Receive && r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString() && r.PosReceipt_ID == oPoSReceipt.PosReceipt_ID))
            {
                tbl_posAdvanceReceived oAdvance = tbl_posAdvanceReceived.Select(oPCRN_Payment.AdvanceReceived_Index);
                if (oAdvance != null)
                {
                    //CRNs
                    dtAdvance.Rows.Add("0", oPCRN_Payment.AdvanceReceived_Index, oAdvance.AdvanceReceived_ID, cls_Formater.FormatDecimal(oPCRN_Payment.Amount, clsConfig.sPOSBillDecimalPoint));
                }
            }
            dgrAdvance.ItemsSource = dtAdvance.DefaultView;

            //One Galleface Rewards Payments
            foreach (tbl_bpsChequeRegister oMall_RewardPayment in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPoSReceipt.PosReceipt_ID).Where(r => r.PaymentMethod_ID == (int)PaymentMethod.OneGalleFaceRwards && r.PosTransaction_ID == oPoSTx.PosTransaction_Index.ToString()))
            {
                txtRewardAmount.TextBox1.Text = cls_Formater.FormatDecimal(oMall_RewardPayment.Amount, clsConfig.sPOSBillDecimalPoint);
            }

            Refresh_SelectedPosReceiptDetails();

            //Customer
            txtCustomerName.Tag = oPoSTx.Customer_ID;
            txtCustomerName.TextBox1.Text = clsGenaralName.getName_Customer(oPoSTx.Customer_ID);
            txtCustomerAddress.TextBox1.Text = clsGenaralName.getName_CustomerRegisterAddress(oPoSTx.Customer_ID);
            txtCustomerTelphone.TextBox1.Text = clsGenaralName.getName_CustomerTelephone(oPoSTx.Customer_ID);
            PayOptionRadioButtonSetup(oPoSTx.Customer_ID);


            if (oPoSReceipt.IsAdvance)
                rdoAdavancePayment.IsChecked = oPoSReceipt.IsAdvance;
            if (oPoSReceipt.IsPartPayment)
                rdoPartPayment.IsChecked = oPoSReceipt.IsPartPayment;
            if (oPoSReceipt.IsFullPayment)
                rdoFullPayment.IsChecked = oPoSReceipt.IsFullPayment;

        }
        #endregion

        #region Grid Events

        #region Main Grid - POS Receipts
        private void dgr_Payment_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgrPayment_Receipts.grdMain.SelectedItem;
                if (item != null)
                {
                    string sID = (dgrPayment_Receipts.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;

                    tbl_posReceipt oPosReceipt = tbl_posReceipt.Select(sID);
                    if (oPosReceipt != null)
                    {
                        tbl_posTransaction oPosTransaction = tbl_posTransaction.Select(oPosReceipt.PosTransaction_Index);

                        ClearFields_forReceiptDetails();
                        FillDetails_PaymentRegisterDetails_SelectedReceipt(oPosTransaction, oPosReceipt);
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private void dgr_Payment_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dgrPayment_Receipts.dt);
        }
        #endregion

        #region Grids Payment Types
        private void dgrCheques_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtChequePayment);
        }

        private void dgrGiftVoucher_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtGiftVoucherPayment);
        }

        private void dgrCardPays_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtCardPayment);
        }

        private void dgrAdvance_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtAdvance);
        }
        #endregion

        #endregion

        #region Search Events
        private void txtCardBank_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.Banks);

            if (rowDataSearch.DialogResult == true)
            {
                txtCardBank.Tag = lstResult[0];
                txtCardBank.Text = lstResult[1];
            }
        }

        private void txtMerchantDevice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_Merchant_Device);

            if (RowDataSearch.DialogResult == true)
            {
                txtMerchantDevice.Tag = lstResult[0];
                txtMerchantDevice.TextBox1.Text = lstResult[2];
            }
        }

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

                PayOptionRadioButtonSetup(lstResult[0]);
            }
        }

        private void txtAccoutNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void txtChequeBankName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.Banks);

            if (rowDataSearch.DialogResult == true)
            {
                txtChequeBankName.Tag = lstResult[0];
                txtChequeBankName.Text = lstResult[1];

                txtChequeBankBranch.Tag = null;
                txtChequeBankBranch.Text = "<Select Bank Branch>";
            }
        }

        private void txtChequeBankBranch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtChequeBankName.Tag != null && txtChequeBankName.Text != "")
                lstParameeters.Add(txtChequeBankName.Tag.ToString());

            frmSearchForm rowDataSearch = new frmSearchForm(lstParameeters);
            List<string> lstResult = rowDataSearch.Show(Search.BankBranch);

            if (rowDataSearch.DialogResult == true)
            {
                txtChequeBankName.Tag = lstResult[0];
                txtChequeBankName.Text = lstResult[1];

                txtChequeBankBranch.Tag = lstResult[2];
                txtChequeBankBranch.Text = lstResult[3];
            }
        }

        private void txtWarrantyDescription_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_ItemRemarks);

            if (RowDataSearch.DialogResult == true)
            {
                txtWarrantyDescription.Text = lstResult[1];
            }
        }

        private void txtGreetngDescription_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.Pos_SesonalGreeting);

            if (RowDataSearch.DialogResult == true)
            {
                txtGreetngDescription.Text = lstResult[1];
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

        #region Text Boxes - Other Events
        private void txtCashReceived_TextBox_TextChanged(object sender, EventArgs e)
        {
            Refresh_SelectedPosReceiptDetails();
        }

        private void txtReceiptTotal_TextBox_TextChanged(object sender, EventArgs e)
        {
            txtReceiptBalance.TextBox1.Text = cls_Formater.FormatDecimal(CalculateReceipt_Blance_Amount(), clsConfig.sPOSBillDecimalPoint);
        }
        #endregion

        #region Radio Button Event
        private void rdoPayment_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomerName.Tag != null)
                PayOptionRadioButtonSetup(txtCustomerName.Tag.ToString());
        }
        #endregion

        #region Help Methods
        //Payment Method Visibility Format Changes
        private void PaymentMethodsVisibility(int iPayMethod)
        {
            grdCashPayment.Visibility = Visibility.Hidden;
            grdCardPayment.Visibility = Visibility.Hidden;
            grdGiftVoucher.Visibility = Visibility.Hidden;
            grdChequePayment.Visibility = Visibility.Hidden;
            grdCRNs_SalesReturn.Visibility = Visibility.Hidden;
            grdAdavnce.Visibility = Visibility.Hidden;
            grdOneGalleFace.Visibility = Visibility.Hidden;

            btnCashPayment.Background = (Brush)bc.ConvertFrom("#FF0091EA");
            btnCardPayment.Background = (Brush)bc.ConvertFrom("#FF0091EA");
            btnGiftVouchers.Background = (Brush)bc.ConvertFrom("#FF0091EA");
            btnPDCheques.Background = (Brush)bc.ConvertFrom("#FF0091EA");
            btnCRNs_salesReturn.Background = (Brush)bc.ConvertFrom("#FF0091EA");
            btnAdvancePayment.Background = (Brush)bc.ConvertFrom("#FF0091EA");
            btnOneGalleFace.Background = (Brush)bc.ConvertFrom("#FF0091EA");

            switch (iPayMethod)
            {
                case 1: //Cash Payment
                    grdCashPayment.Visibility = Visibility.Visible;
                    btnCashPayment.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    break;

                case 2: //Card Payment
                    grdCardPayment.Visibility = Visibility.Visible;
                    btnCardPayment.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    break;

                case 3: //Gift Voucher Payment
                    grdGiftVoucher.Visibility = Visibility.Visible;
                    btnGiftVouchers.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    break;

                case 4: //Cheque Payment
                    bool bChequePayActivate = true;
                    if (clsConfig_POS.bDisableChequePaymentsFor_POS_Customers)
                    {
                        bChequePayActivate = false;
                        if (txtCustomerName.Tag != null)
                        {
                            tbl_genCustomerMaster oERP_Customer = tbl_genCustomerMaster.Select(txtCustomerName.Tag.ToString());
                            if (oERP_Customer != null && oERP_Customer.Customer_ID != "default" && !oERP_Customer.IsPOSCustomer && !oERP_Customer.IsCashCustomer && !oERP_Customer.IsDeleted)
                                bChequePayActivate = true;
                        }
                    }

                    if (txtCustomerTelphone.TextBox1.Text.Length > 3 && bChequePayActivate)
                    {
                        grdChequePayment.Visibility = Visibility.Visible;
                        btnPDCheques.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    }
                    break;

                case 5: //CRN
                        //if (txtCustomerTelphone.TextBox1.Text.Length > 3 || txtCustomerName.Tag != null)
                        //{
                        //    if (txtCustomerName.Tag.ToString() != "default" && !clsHelpMethods_POS.Is_CashCustomer(txtCustomerName.Tag.ToString()))
                        //    {
                    grdCRNs_SalesReturn.Visibility = Visibility.Visible;
                    btnCRNs_salesReturn.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    //}
                    //}
                    break;

                case 6: //Advance
                        //if (txtCustomerTelphone.TextBox1.Text.Length > 3 || txtCustomerName.Tag != null)
                        //{
                        //    if (txtCustomerName.Tag.ToString() != "default" && !clsHelpMethods_POS.Is_CashCustomer(txtCustomerName.Tag.ToString()))
                        //    {
                    grdAdavnce.Visibility = Visibility.Visible;
                    btnAdvancePayment.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    //    }
                    //}
                    break;
                case 7:
                    grdOneGalleFace.Visibility = Visibility.Visible;
                    btnOneGalleFace.Background = (Brush)bc.ConvertFrom("#FFAAAAAA");
                    break;
            }
        }

        //Payment Option Radio Button Enable/Disable
        private void PayOptionRadioButtonSetup(string sCustomer_ID)
        {
            if (!clsConfig_POS.bHide_AdvancePartPayment_Option)
            {
                if (clsHelpMethods_POS.Is_CashCustomer(sCustomer_ID))
                {
                    rdoFullPayment.IsChecked = true;
                    rdoFullPayment.IsEnabled = false;
                    rdoPartPayment.IsEnabled = false;
                    rdoAdavancePayment.IsEnabled = false;
                }
                else
                {
                    rdoFullPayment.IsEnabled = true;
                    rdoPartPayment.IsEnabled = true;
                    rdoAdavancePayment.IsEnabled = true;

                    if (dgrPayment_Receipts.dt.Rows.Count > 0 && txtReceipt_ID.Tag == null)
                    {
                        rdoFullPayment.IsEnabled = false;

                        rdoFullPayment.IsChecked = false;
                        rdoPartPayment.IsChecked = true;
                    }
                }
            }
            else
            {
                rdoFullPayment.IsChecked = true;
                rdoFullPayment.IsEnabled = false;
                rdoPartPayment.IsEnabled = false;
                rdoAdavancePayment.IsEnabled = false;
            }
        }

        //Calculate Receipt Balance
        private decimal CalculateReceipt_Blance_Amount()
        {
            decimal dBalance_Amount = 0;
            decimal dAllReceiptTotal = (from t in dgrPayment_Receipts.dt.AsEnumerable()
                                        where t["Receipt_ID"].ToString().Trim() != txtReceipt_ID.TextBox1.Text
                                        select Convert.ToDecimal(t["TotalAmount"])).Sum();
            decimal dGrandTotal = clsValidation.Validate_DecimalNumber(tbGrandtotal.Text);

            dBalance_Amount = dAllReceiptTotal + clsValidation.Validate_DecimalNumber(txtReceiptTenderedTotal.TextBox1.Text) - dGrandTotal;

            //Gift Vouchers doesn't have balance amount
            //if (clsValidation.Validate_DecimalNumber(txtCashPaymentstotal.TextBox1.Text) == 0 &&
            //    clsValidation.Validate_DecimalNumber(txtCardPaymentsTotal.TextBox1.Text) == 0 &&
            //    clsValidation.Validate_DecimalNumber(txtChequesAmountTotal.TextBox1.Text) == 0 &&
            //     clsValidation.Validate_DecimalNumber(txtGiftVoucherTotal.TextBox1.Text) != 0
            //    )
            //{
            //    dBalance_Amount = 0;
            //}

            return dBalance_Amount;
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

                    SEACCMessageBox.Show("Not Found...", "Customer details can not be found in the system.\nPlease enter new customer details here...", MessageBoxButton.OK);

                }
            }
        }
        #endregion

        private void btnCRNAdd_Click(object sender, RoutedEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            List<string> lstResult = RowDataSearch.Show(Search.POS_CRNs_NotRedeem);

            if (RowDataSearch.DialogResult == true)
            {
                try
                {
                    DataRow[] items = dtCRN_SalesReturn.Select("CRN_Index ='" + lstResult[0] + "'");
                    if (items.Length == 0)
                    {
                        dtCRN_SalesReturn.Rows.Add("0", lstResult[0], lstResult[1], cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(lstResult[3]), clsConfig.sPOSBillDecimalPoint));
                    }
                    else
                    {
                        SEACCMessageBox.Show("Sales Return Credit Note Already Exist", "", MessageBoxButton.YesNo, "Red");
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }

                Refresh_SelectedPosReceiptDetails();
            }
        }

        private void btnCRNDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrCRN_SalesReturn.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrCRN_SalesReturn.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtCRN_SalesReturn.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtCRN_SalesReturn.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtCRN_SalesReturn);

                Refresh_SelectedPosReceiptDetails();
            }
        }

        private void dgrCRN_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_POS.OrderBy_DataGrid(dtCRN_SalesReturn);
        }

        private void btnCRNs_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(5);
        }

        private void btnAdvanceAdd_Click(object sender, RoutedEventArgs e)
        {
            frmSearchForm rowDataSearch = new frmSearchForm();
            List<string> lstResult = rowDataSearch.Show(Search.POS_Advance_NotRedeem);

            if (rowDataSearch.DialogResult == true)
            {
                DataRow[] items = dtAdvance.Select("Advance_Index ='" + lstResult[0] + "'");
                if (items.Length == 0)
                {
                    dtAdvance.Rows.Add("0", lstResult[0], lstResult[1],
                        cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(lstResult[3]), clsConfig.sPOSBillDecimalPoint));
                }
                else
                {
                    SEACCMessageBox.Show("Advance Payment Already Exist", "", MessageBoxButton.YesNo, "Red");
                }
            }

            Refresh_SelectedPosReceiptDetails();
        }

        private void btnAdvanceDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrAdvance.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrAdvance.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtAdvance.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtAdvance.Rows.Remove(item);
                }
                clsHelpMethods_POS.OrderBy_DataGrid(dtAdvance);

                Refresh_SelectedPosReceiptDetails();
            }
        }

        private void btnAdvancePayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(6);
        }

        private void btnOneGalleFace_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethodsVisibility(7);
        }

        private void frmPayment_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Refresh_SelectedPosReceiptDetails();
            txtReceiptTotal_TextBox_TextChanged(sender, null);
        }

        private void txtRewardAmount_TextBox_TextChanged(object sender, EventArgs e)
        {
            Refresh_SelectedPosReceiptDetails();
        }

        private void btnRewardSend_Click(object sender, RoutedEventArgs e)
        {
            MallRewards(sender, e);
        }
    }
}
