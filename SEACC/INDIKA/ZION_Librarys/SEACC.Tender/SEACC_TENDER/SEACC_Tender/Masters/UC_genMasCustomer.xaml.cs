using DataTire;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace SEACC_Tender
{
    /// <summary>
    /// Interaction logic for UC_CustomerMaster.xaml
    /// </summary>
    public partial class UC_genMasCustomer : UserControl
    {
        #region Class Variables
        private DataTable dt = new DataTable();
        bool bIsItemChanged = false;
        #endregion

        #region Form Load
        public UC_genMasCustomer()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Customer;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Customer_ID");
            dgr_Main.dt.Columns.Add("Customer_Code");
            dgr_Main.dt.Columns.Add("Customer_Name");

            dt.Columns.Add("LineNo");
            dt.Columns.Add("ContactName");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Telephone");
            dt.Columns.Add("Mobil");
            dt.Columns.Add("FaxNo");
            dt.Columns.Add("Email");
            dgr_Contact.ItemsSource = dt.DefaultView;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Customer ID", "Customer_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Customer Code", "Customer_Code", 90);
            dgr_Main.Add_DatagridColoumn("Customer Name", "Customer_Name", 200);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                coloumnA.Width = new GridLength(200);
            else
                coloumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons

        #region Button New
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Button Cancel
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtCustomer_ID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_genCustomerMaster Details = tbl_genCustomerMaster.Select(txtCustomer_ID.Tag.ToString());
                            if (Details != null)
                            {
                                Details.IsDeleted = true;
                                Details.DateDeleted = clsSecurity.getServerDateTime();
                                Details.DeletedUser_ID = clsSecurity.UserIDLoged;
                                Details.DeletedTerminal_ID = clsSecurity.TerminalID;
                                Details.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Button Print
        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Print Failed", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

        }
        
        #endregion

        #region Button Save
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    string sSd = "";
                    try
                    {
                        int nItemPrice = 0;
                        if (cmbPrice_mode.GetSelectedIndex() == ((int)PricingMode.Standard_Price - 1))
                            nItemPrice = (int)PricingMode.Standard_Price;
                        else if (cmbPrice_mode.GetSelectedIndex() == ((int)PricingMode.Customer_Wise_PriceCategory - 1))
                            nItemPrice = (int)PricingMode.Customer_Wise_PriceCategory;
                        else if (cmbPrice_mode.GetSelectedIndex() == ((int)PricingMode.Customer_Wise_Price - 1))
                            nItemPrice = (int)PricingMode.Customer_Wise_Price;

                        Cursor = Cursors.Wait;
                        sSd = txtCustomer_ID.Tag.ToString(); ;

                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_genCustomerMaster OldRecord = tbl_genCustomerMaster.Select(txtCustomer_ID.Tag.ToString());
                            if (OldRecord != null)
                            {
                                tbl_genCustomerMaster odetail = new tbl_genCustomerMaster(txtCustomer_ID.Tag.ToString(), txtCustomer_code.Text, txtName.Text, txtReg_Address.Text, txtDel_Address.Text, txtTel.Text, txtMob.Text, txtFax.Text, txtEmail.Text,
                                    txtWeb_URL.Text, txtBusReg_No.Text, txtVATReg_No.Text, txtNBTReg_No.Text, txtSVATReg_No.Text, txtRemarks.Text, chkIsBlackListed.IsChecked, chkIsSuspended.IsChecked, chkIsDeactivated.IsChecked,
                                    "default", "default", "default", "default", "default", "default", "default",
                                    txtCustomer_tp.Tag.ToString(), txtCategory.Tag.ToString(), txtCustomer_cls.Tag.ToString(), txtMain_cur.Tag.ToString(),
                                    "default", "default", "default", "default", "",
                                    chkIsNonTax.IsChecked, chkIsVAT.IsChecked, chkIsNBT.IsChecked, false, "", txtNIC.Text, dtp_DOB.GetDateTime().Date, txtSalesAcc_Type.Tag.ToString(), chkIsVATEnable.IsChecked, chkIsNBTEnable.IsChecked, txtSalesRetAcc_code.Tag.ToString(),
                                    OldRecord.IsCashCustomer, clsSecurity.CompanyID, clsSecurity.BranchID, nItemPrice, "default",
                                OldRecord.CreateUser_ID, clsSecurity.UserIDLoged, OldRecord.DeletedUser_ID,
                                OldRecord.CreateTerminal_ID, clsSecurity.TerminalID, OldRecord.DeletedTerminal_ID, OldRecord.DateCreate,
                               clsSecurity.getServerDateTime(), OldRecord.DateDeleted);
                                odetail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            tbl_genCustomerMaster odetail = new tbl_genCustomerMaster(txtCustomer_ID.Tag.ToString(), txtCustomer_ID.Text, txtName.Text, txtReg_Address.Text, txtDel_Address.Text, txtTel.Text, txtMob.Text, txtFax.Text, txtEmail.Text,
                                    txtWeb_URL.Text, txtBusReg_No.Text, txtVATReg_No.Text, txtNBTReg_No.Text, txtSVATReg_No.Text, txtRemarks.Text, chkIsBlackListed.IsChecked, chkIsSuspended.IsChecked, chkIsDeactivated.IsChecked,
                                    "default", "default", "default", "default", "default", "default", "default",
                                    txtCustomer_tp.Tag.ToString(), txtCategory.Tag.ToString(), txtCustomer_cls.Tag.ToString(), txtMain_cur.Tag.ToString(),
                                    "default", "default", "default", "default", "",
                                    chkIsNonTax.IsChecked, chkIsVAT.IsChecked, chkIsNBT.IsChecked, false, "", txtNIC.Text, dtp_DOB.GetDateTime().Date, "default", chkIsVATEnable.IsChecked, chkIsNBTEnable.IsChecked, "default",
                                    false, clsSecurity.CompanyID, clsSecurity.BranchID, nItemPrice, "default",
                                clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default",
                               clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            odetail.Insert();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Arrow;
                        ClearFields();
                        RefreshGrid();
                        fillDetails(sSd);
                    }
                }
            }
        } 
        #endregion
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dt.Clear();

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCustomer_ID, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCustomer_code, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtTitle, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer_cls, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer_tp, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);
           // cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBranch, true, false, false);
            chkIsBlackListed.IsChecked = false;
            chkIsSuspended.IsChecked = false;
            chkIsDeactivated.IsChecked = false;

            //General
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_DOB, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTel, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMob, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNIC, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtWeb_URL, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReg_Address, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDel_Address, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            //Finanance 1
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMain_cur, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDep_amnt, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_limit, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_period, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCommission, true, false, false);

            cmbPrice_mode.SetValues(typeof(PricingMode));
            cmbPrice_mode.SetSelectedIndex(-1);
            //cmbPrice_mode.comboBox.ItemsSource = clsCommon.getEnumDescription(typeof(PricingMode));
            //cmbPrice_mode.SetSelectedIndex(-1);

            //txtDep_amnt.SetValues(typeof(Gender));
            //txtDep_amnt.SetSelectedIndex(-1);
            cls_Formater.SetEnableDisable_LableTextbox(txtSales_dues, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_balance, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTot_sales, true, false, false);
            chkIsNonTax.IsChecked = false;
            chkIsNBT.IsChecked = false;
            chkIsVAT.IsChecked = false;
            chkIsSVAT.IsChecked = false;
            cls_Formater.SetEnableDisable_LableTextbox(txtBusReg_No, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNBTReg_No, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtVATReg_No, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSVATReg_No, true, false, false);

            //Finance 2
            cls_Formater.SetEnableDisable_LableTextbox(txtLoyalty_amount, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCard_no, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_Date, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOutstandng_amnt, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtChqInHnd_amnt, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesAcc_Type, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesRetAcc_code, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSaleAcc_code, true, false, false);
            chkIsVATEnable.IsChecked = false;
            chkIsNBTEnable.IsChecked = false;


            //Address Book
            //cls_Formater.SetEnableDisable_LableTextbox(txtContact_name, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtDesignation, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtContact_mob, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtContact_tel, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtContact_fax, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtContact_emaill, true, false, false);


            txtCustomer_ID.Tag = null;
            txtCustomer_ID.Text = "";
            txtCustomer_code.Text = "";
            //txtTitle.Text = "";
            txtName.Text = "";
            txtCustomer_cls.Text = "";
            txtCustomer_cls.Tag = null;
            txtCustomer_tp.Text = "";
            txtCustomer_tp.Tag = null;
            txtCategory.Text = "";
            txtCategory.Tag = null;
            //txtBranch.Text = "";
            //txtBranch.Tag = null;

            txtTel.Text = "";
            txtMob.Text = "";
            txtNIC.Text = "";
            txtFax.Text = "";
            txtWeb_URL.Text = "";
            txtEmail.Text = "";
            txtReg_Address.Text = "";
            txtDel_Address.Text = "";
            txtRemarks.Text = "";

            dtp_DOB.SetTime(DateTime.Now);

            txtMain_cur.Tag = null;
            txtMain_cur.Text = "";
            txtDep_amnt.Text = "00.00";
            txtCredit_limit.Text = "00.00";
            txtCredit_period.Text = "00.00";
            txtCommission.Text = "00.00";

            txtSales_dues.Text = "00.00";
            txtCredit_balance.Text = "00.00";
            txtTot_sales.Text = "00.00";
            txtBusReg_No.Text = "";
            txtNBTReg_No.Text = "";
            txtVATReg_No.Text = "";
            txtSVATReg_No.Text = "";
                       
            txtLoyalty_amount.Text = "00.00";
            txtCard_no.Text = "";
            dtp_Date.SetTime(DateTime.Now);
            txtOutstandng_amnt.Text = "00.00";
            txtChqInHnd_amnt.Text = "00.00";
            txtSalesAcc_Type.Text = "";
            txtSalesAcc_Type.Tag = null;
            txtSalesRetAcc_code.Text = "";
            txtSalesRetAcc_code.Tag = null;
            txtSaleAcc_code.Text = "";
            txtSaleAcc_code.Tag =null;

            //txtContact_name.Text = "";
            //txtDesignation.Text = "";
            //txtContact_mob.Text = "";
            //txtContact_tel.Text = "";
            //txtContact_fax.Text = "";
            //txtContact_emaill.Text = "";
                        
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_genCustomerMaster detail in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted))
                {
                    dgr_Main.dt.Rows.Add(detail.Customer_ID, detail.CustomerCode, detail.CustomerName);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (CheckValidity_DuplicateKey())
                {
                    if (CheckNumberValidity())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyValue(txtCustomer_code, ref strMessage))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtName, ref strMessage))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomer_cls, ref strMessage))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomer_tp, ref strMessage))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCategory, ref strMessage))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMain_cur, ref strMessage))
                bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtBranch, ref strMessage))
            //    bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage);

            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtCustomer_ID.Text = SEACC_Form.getAutoGeneratedCode();

                txtCustomer_ID.Tag = txtCustomer_ID.Text;

                if (txtCustomer_ID.Tag.ToString() != "")
                {
                    tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(txtCustomer_ID.Tag.ToString());
                    if (detail != null)
                    {
                        bStatus = false;
                        SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    }
                }
                else
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Fields cannot be Empty", "Customer ID", MessageBoxButton.OK);
                }
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsValidation.isCurrency(txtDep_amnt, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtCredit_limit, ref strMessage))
                    bStatus = false;
                //if (!clsValidation.isInteger(txtCredit_period, ref strMessage))
                //    bStatus = false;
                //if (!clsValidation.isInteger(txtCommission, ref strMessage))
                //    bStatus = false;
                if (!clsValidation.isCurrency(txtSales_dues, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtCredit_balance, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtTot_sales, ref strMessage))
                    bStatus = false;
                
                if (bStatus == false)
                    SEACCMessageBox.Show("invalied curency value", strMessage);
            }
            catch (Exception ex)
            {
                //  clsValidate.WriteErrorLog(ex.Message, iFormID);
                //   MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (bStatus == false)
            {
                //  MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genCustomerMaster details = tbl_genCustomerMaster.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtCustomer_ID.IsEnabled = false;

                        txtCustomer_code.Text = details.CustomerCode;
                        txtCustomer_ID.Tag = details.Customer_ID;

                        txtCustomer_cls.Tag = details.CustomerClass_ID;
                        txtCustomer_cls.Text = clsRef_Name.get_Customer_Class(details.CustomerClass_ID);
                        txtCustomer_tp.Tag = details.CustomerType_ID;
                        txtCustomer_tp.Text = clsRef_Name.get_Customer_Type(details.CustomerType_ID);
                        txtCategory.Tag = details.CustomerCategory_ID;
                        txtCategory.Text = clsRef_Name.get_Customer_Category(details.CustomerCategory_ID);
                        //txtBranch.Tag = details.CompanyBranch_ID;
                        //txtBranch.Text = clsRef_Name.get_Company_Branch(details.CompanyBranch_ID);

                        //txtTitle.Text = details.Title;
                        txtName.Text = details.CustomerName;

                        chkIsBlackListed.IsChecked = details.IsBlacklisted;
                        chkIsSuspended.IsChecked = details.IsLocked;
                        chkIsDeactivated.IsChecked = details.IsDeleted;

                        dtp_DOB.SetTime(details.DateOfBirth);
                        txtTel.Text = details.Telephone;
                        txtMob.Text = details.Mobile;
                        txtNIC.Text = details.NicNo;
                        txtFax.Text = details.Fax;
                        txtWeb_URL.Text = details.Url;
                        txtEmail.Text = details.Email;
                        txtReg_Address.Text = details.AddressRegister;
                        txtDel_Address.Text = details.AddressDelivery;
                        txtRemarks.Text = details.Remark;

                        #region Pricing Mode
                        if (details.ItemPriceMode == (int)PricingMode.Standard_Price)
                            cmbPrice_mode.SetSelectedIndex((int)PricingMode.Standard_Price - 1);
                        else if (details.ItemPriceMode == (int)PricingMode.Customer_Wise_PriceCategory)
                            cmbPrice_mode.SetSelectedIndex((int)PricingMode.Customer_Wise_PriceCategory - 1);
                        else if (details.ItemPriceMode == (int)PricingMode.Customer_Wise_Price)
                            cmbPrice_mode.SetSelectedIndex((int)PricingMode.Customer_Wise_Price - 1);
                        else
                            cmbPrice_mode.SetSelectedIndex(-1);
                        #endregion
                        //cmbPrice_mode.SetSelectedIndex((int)details.ItemPriceMode);

                        //Pricing Category
                        //if (details.ItemPriceCategory.Length > 0 && details.ItemPriceCategory != "default")
                        //{
                        //    foreach (ComboBoxItem d in cmbPrice_cat.Items)
                        //    {
                        //        if (d.Value == details.ItemPriceCategory)
                        //        {
                        //            cmbPrice_cat.SelectedItem = d;
                        //            break;
                        //        }
                        //    }
                        //}

                        chkIsNonTax.IsChecked = true;
                        chkIsNBT.IsChecked = details.IsNBTenable;
                        chkIsVAT.IsChecked = details.IsVATenable;
                        chkIsSVAT.IsChecked = details.IsSVATenable;
                        txtBusReg_No.Text = details.BusinessRegistraionNo;
                        txtNBTReg_No.Text = details.NbtRegistrationNo;
                        txtVATReg_No.Text = details.VatRegistrationNo;
                        txtSVATReg_No.Text = details.SvatRegistrationNo;

                        txtSalesAcc_Type.Text = details.CustomerAccountType_ID;
                        txtSalesAcc_Type.Tag = details.CustomerAccountType_ID;
                        txtSalesRetAcc_code.Tag = details.SalesReturnedGL_ID;
                        txtSalesRetAcc_code.Text = details.SalesReturnedGL_ID;
                        

                        txtSaleAcc_code.Tag = null;
                        txtSaleAcc_code.Text = "";
                        List<tbl_accGLMaster_Customer> oAccs = tbl_accGLMaster_Customer.SelectAllByCustomer_ID(details.Customer_ID);
                        if (oAccs.Count > 1)
                            SEACCMessageBox.Show("Error", "There are more than 1 GL codes are taged with this customer, Please contact the accountant", MessageBoxButton.OK, "");
                        else
                        {
                            foreach (tbl_accGLMaster_Customer oAcc in tbl_accGLMaster_Customer.SelectAllByCustomer_ID(details.Customer_ID))
                            {
                                txtSaleAcc_code.Tag = oAcc.Gl_ID;
                                txtSaleAcc_code.Text = clsGenaralName.getName_AccountName(oAcc.Gl_ID);
                                break;
                            }
                        }

                        txtMain_cur.Tag = details.Currency_ID;
                        txtMain_cur.Text = details.Currency_ID;                        

                        tbl_genCustomerFinance oFinance = tbl_genCustomerFinance.Select(sID);
                        if (oFinance != null)
                        {
                            txtDep_amnt.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.DepositAmount.ToString()), 2);
                            txtCredit_limit.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.CreditLimit.ToString()), 0);
                            txtCredit_period.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.CreditPeriod.ToString()), 0);
                            txtCommission.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.CommissionCreditPeriod.ToString()), 0);

                            txtSales_dues.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.SalesDues.ToString()), 2);
                            txtCredit_balance.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.CreditBalance.ToString()), 2);
                            txtTot_sales.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.TotalSales.ToString()), 2);

                            txtLoyalty_amount.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.LoyaltyAmount.ToString()), 2);
                            txtCard_no.Text = oFinance.LoyalityCardNo;
                            dtp_Date.SetTime(oFinance.LoyalityStartDate);
                            txtOutstandng_amnt.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.OutstandingAmount.ToString()), 2);
                            txtChqInHnd_amnt.Text = cls_Formater.FormatDecimal(decimal.Parse(oFinance.ChequeInHandAmount.ToString()), 2);

                        }                        
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string periodID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    fillDetails(periodID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtCustomer_cls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer_cls.Tag = lstResult[0];
                txtCustomer_cls.Text = lstResult[1];
            }
        }
        
        private void txtCustomer_tp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerType);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer_tp.Tag = lstResult[0];
                txtCustomer_tp.Text = lstResult[1];
            }
        }

        private void txtCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtCategory.Tag = lstResult[0];
                txtCategory.Text = lstResult[1];
            }
        }

        private void txtMain_cur_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Currency);
            if (RowDataSearch.DialogResult == true)
            {
                txtMain_cur.Tag = lstResult[0];
                txtMain_cur.Text = lstResult[1];
            }
        }

        #endregion

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            int iRow = dt.Rows.Count + 1;
            dt.Rows.Add(iRow, "","","","","","");
        }
        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object oselectedItem = dgr_Contact.SelectedItem;
            if (oselectedItem != null)
                ((DataRowView)(dgr_Contact.SelectedItem)).Row.Delete();
        }

        #region Expander Class
        private void expanAD2_Expanded(object sender, RoutedEventArgs e)
        {
            expanAB.IsExpanded = false;
            expanAD1.IsExpanded = false;
            expanGeneral.IsExpanded = false;
        }

        private void expanAB_Expanded(object sender, RoutedEventArgs e)
        {
            expanAD2.IsExpanded = false;
            expanAD1.IsExpanded = false;
            expanGeneral.IsExpanded = false;
        }

        private void expanAD1_Expanded(object sender, RoutedEventArgs e)
        {
            expanAB.IsExpanded = false;
            expanAD2.IsExpanded = false;
            expanGeneral.IsExpanded = false;
        }

        private void expanGeneral_Expanded(object sender, RoutedEventArgs e)
        {
            expanAB.IsExpanded = false;
            expanAD1.IsExpanded = false;
            expanAD2.IsExpanded = false;
        } 
        #endregion
        
    }
}
