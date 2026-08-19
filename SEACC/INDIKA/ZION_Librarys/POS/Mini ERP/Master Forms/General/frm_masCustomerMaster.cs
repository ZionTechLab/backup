using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;
using Digiteq.DataSets;
using System.Text.RegularExpressions;
using SEACC_WPFControls;

namespace Digiteq
{
    public partial class frm_masCustomerMaster : SEACC_Form
    {
        #region Variable

        //to manage update and insert
        //static bool IsUpdate = false;
        bool IsUpdateAddressBook = false;
        //static bool IsUpdateRoute = false;
        bool IsUpdateBranche = false;
        string s_FileName;

        //to keep form detail       
        //string sFormConfigCode;
        //public int iFormID;
        public bool bNoAccess;
        DataTable dt;

        //To keep Global information
        public bool glb_bIsCustomerOrderMode = false;
        public static string glb_sCustomerID = string.Empty;

        private BindingSource sourceCustomerMaster = new BindingSource();

        dts_Master glbdts_Master = new dts_Master();
        DataTable glbParameter = new DataTable();
        #endregion

        #region Form Load
        public frm_masCustomerMaster(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CustomerMaster);
            //iFormID = clsSecurity.getFormID(FormName.CustomerMaster);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            HideSalesRepDetails();
        }
        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format  
            SetVisibility_ActionButons(true, true, false, true, false, false, false, false, false);
            CreateDataTable();
            CusDataGridViewFormat();
            ClearFields();
            dgvDetail.DataSource = sourceCustomerMaster;

            #region discount datagrid
            bool bHasPermissionCustomerWiceDiscount = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Customer_wice_discount_Permishion));

            if (!clsConfig.bIsEnabledMultiple_Discount)
            {
                pnlDiscount.Enabled = false;
                lblDiscount.Visible = true;
                lblDiscount.Text = "This feature is not enabled";
            }
            else
            {
                if (bHasPermissionCustomerWiceDiscount)
                    lblDiscount.Visible = false;
                else
                {
                    pnlDiscount.Enabled = false;
                    lblDiscount.Visible = true;
                    lblDiscount.Text = "You don’t have permission to access this function";
                }
            }
            #endregion

            HideSalesRepDetails();
        }
        #endregion

        #region Btn New
        private void frm_masCustomerMaster_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void frm_masCustomerMaster_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckTaxValidity())
                {
                    if (CheckNumberValidity())
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                Byte[] img = new byte[0];
                                ValidateEmptyForeignKey();
                                DateTime btLoyalityStartDate = DateTime.Parse("1900/01/01");

                                #region Update Method
                                if (IsUpdate)  //update records
                                {
                                    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                                    {
                                        tbl_genCustomerMaster oldRecord = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                                        if (oldRecord != null)
                                        {
                                            //Write Audit Trial Log
                                            clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CustomerMaster), oldRecord.Customer_ID, "Customer Master - Modify");

                                            tbl_genCustomerMaster_Image cImage = tbl_genCustomerMaster_Image.Select(oldRecord.Customer_ID);
                                            if (cImage != null)
                                            {
                                                if (s_FileName.Length > 0)
                                                {
                                                    FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                                    img = new Byte[fs.Length];
                                                    fs.Read(img, 0, (int)fs.Length);
                                                    fs.Close();
                                                }
                                                else if (cImage.Image != null && cImage.Image.Length > 0)
                                                {
                                                    img = cImage.Image;
                                                }

                                                tbl_genCustomerMaster_Image imageRecord = new tbl_genCustomerMaster_Image(oldRecord.Customer_ID, img);
                                                imageRecord.Update();
                                            }

                                            UpdateContactDetails();
                                            UpdateDiscounts();

                                            //Customer Master  ----
                                            tbl_genCustomerMaster detail = new tbl_genCustomerMaster(txtCustomerID.Tag.ToString().Trim(), txtCustomerID.Tag.ToString().Trim(), txtCustomerName.Text.Trim(),
                                                txtAddressRegister.Text.Trim(), txtAddressDeliver.Text.Trim(), txtTelephone.Text.Trim(), txtMobile.Text.Trim(), txtFax.Text.Trim(),
                                                txtEmail.Text.Trim(), txtUrl.Text.Trim(), txtBussinessRegNo.Text.Trim(), txtVatRegNo.Text.Trim(), txtNBTRegistrationNo.Text.Trim(),
                                                txtSVATRegistrationNo.Text.Trim(), txtRemark.Text.Trim(), chkBlacklisted.Checked, chkLocked.Checked, chkDeleted.Checked,
                                                "default", "default", "default", "default", "default", "default", "default",
                                                txtCustomerTypeID.Tag.ToString(), txtCategoryID.Tag.ToString(), txtCustomerClassID.Tag.ToString(), txtCurrencyID.Tag.ToString(), txtSalesManagerID.Tag.ToString(),
                                                txtAreaManagerID.Tag.ToString(), txtSalesRepID.Tag.ToString(), txtSalesManagerID.Tag.ToString(),
                                                txtDebtorCode.Text.Trim(), chkVATEnable.Checked, chkSVATEnable.Checked, chkNBTEnable.Checked, false, chkCuswiseItemCodeEnable.Checked, txtTitle.Text.Trim(), txtNICNo.Text.Trim(), dtDateOfBirth.Value, txtAccountType.Tag.ToString(), chkIsPostingEnable_Vat.Checked, chkIsPostingEnable_NBT.Checked, txtSalesReturnGLID.Tag.ToString(), oldRecord.IsCashCustomer, clsSecurity.CompanyID, clsSecurity.BranchID, cmbPriceMode.SelectedIndex, (cmbItemPrice.SelectedIndex != -1) ? ((ComboBoxItem)cmbItemPrice.SelectedItem).Value : "default", oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.DeletedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateDeleted, txtSalesAcctCode.Tag.ToString(), chkPosCustomer.Checked, false, 0);
                                            detail.Update();

                                            if (txtConsigneeName.Text != "" && txtConsigneeName.Text.Length > 0)
                                            {
                                                tbl_genCustomerMaster_Consignee oData = tbl_genCustomerMaster_Consignee.Select(1, txtCustomerID.Tag.ToString());
                                                tbl_genCustomerMaster_Consignee oConsignee = new tbl_genCustomerMaster_Consignee(1, txtCustomerID.Tag.ToString(), txtConsigneeName.Text, txtConsigneeAddress.Text, txtConsigneeVATNo.Text, txtConsigneeSVATNo.Text, chkMainConsignee.Checked);
                                                if (oData != null)
                                                    oConsignee.Update();
                                                else
                                                    oConsignee.Insert();
                                            }

                                            //Customer Finance 

                                            tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(txtCustomerID.Tag.ToString().Trim());
                                            if (finance != null)
                                            {
                                                finance.DepositAmount = decimal.Parse(txtDepositAmount.Text.Trim());
                                                finance.CreditLimit = decimal.Parse(txtCreditLimit.Text.Trim());
                                                finance.CreditPeriod = decimal.Parse(txtCreditPeriod.Text.Trim());
                                                finance.CommissionCreditPeriod = decimal.Parse(txtCreditPeriod_Commisstion.Text.Trim());
                                                finance.LoyaltyAmount = decimal.Parse(txtLoyaltyAmount.Text.Trim());
                                                finance.LoyalityStartDate = finance.LoyalityStartDate;
                                                finance.LoyalityCardNo = txtLoyalityCardNo.Text;
                                                finance.Update();
                                            }
                                            else
                                            {
                                                tbl_genCustomerFinance newFinance = new tbl_genCustomerFinance(txtCustomerID.Tag.ToString().Trim(), decimal.Parse(txtDepositAmount.Text.Trim()),
                                                    decimal.Parse(txtCreditPeriod.Text.Trim()), decimal.Parse(txtCreditLimit.Text.Trim()), decimal.Parse(txtSalesDues.Text.Trim()),
                                                    decimal.Parse(txtCreditBalance.Text.Trim()), decimal.Parse(txtTotalSales.Text.Trim()), decimal.Parse(txtChequeDeposittedCount.Text.Trim()),
                                                    decimal.Parse(txtChequeRealizedCount.Text.Trim()), decimal.Parse(txtChequeReturnedCount.Text.Trim()), decimal.Parse(txtChequeDeposittedAmount.Text.Trim()),
                                                    decimal.Parse(txtChequeRealizedAmount.Text.Trim()), decimal.Parse(txtChequeReturnedAmount.Text.Trim()), 0, clsSecurity.getServerDateTime(), 0,
                                                    decimal.Parse(txtLoyaltyAmount.Text.Trim()), btLoyalityStartDate, txtLoyalityCardNo.Text, 0, 0, decimal.Parse(txtCreditPeriod_Commisstion.Text.Trim()));
                                                newFinance.Insert();
                                            }

                                            //Customer Branches
                                            #region tbl_genCustomerMaster_Branches
                                            //foreach (tbl_genCustomerMaster_Branches oldBranch in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString().Trim()))
                                            //{
                                            //    string sBranchName = "", sAddress = "", sTelephone = "", sFax = "", sEmail = "";
                                            //    bool bisBillToHO = false, bHasItemInDB = false;
                                            //    int iLineNo = 0;

                                            //    foreach (DataGridViewRow row in dgvBranches.Rows)
                                            //    {
                                            //        iLineNo = clsValidate.ValidateGridValue(dgvBranches, "lineNo", row.Index, int.Parse("0"));
                                            //        sBranchName = dgvBranches["branchName1", row.Index].Value.ToString();
                                            //        sAddress = dgvBranches["address", row.Index].Value.ToString();
                                            //        sTelephone = dgvBranches["telephone1", row.Index].Value.ToString();
                                            //        sFax = dgvBranches["fax1", row.Index].Value.ToString();
                                            //        sEmail = dgvBranches["email1", row.Index].Value.ToString();
                                            //        bisBillToHO = clsValidate.ValidateGridValue(dgvBranches, "isBillToHeadOffice", row.Index, false);

                                            //        if (oldBranch.Customer_ID == txtCustomerID.Tag.ToString() && oldBranch.Line_No == iLineNo)
                                            //        {
                                            //            bHasItemInDB = true;
                                            //            dgvBranches.Rows.RemoveAt(row.Index);
                                            //            break; //database contain this item
                                            //        }

                                            //        #region Not use
                                            //        // tbl_genCustomerMaster_Branches branch = tbl_genCustomerMaster_Branches.Select(txtCustomerID.Tag.ToString().Trim(),row.Index);                                                
                                            //        // if (branch != null)
                                            //        // {                                                
                                            //        //     branch.BranchName = dgvBranches["branchName1", row.Index].Value.ToString();
                                            //        //     branch.Address = dgvBranches["address", row.Index].Value.ToString();
                                            //        //     branch.Telephone = dgvBranches["telephone1", row.Index].Value.ToString();
                                            //        //     branch.Fax = dgvBranches["fax1", row.Index].Value.ToString();
                                            //        //     branch.Email = dgvBranches["email1", row.Index].Value.ToString();
                                            //        //     branch.IsBillltoHeadOffice = clsValidate.ValidateGridValue(dgvBranches, "isBillToHeadOffice", row.Index, false);
                                            //        //     branch.Update();
                                            //        // }
                                            //        // else
                                            //        // {
                                            //        //     string sBranchName = dgvBranches["branchName1", row.Index].Value.ToString();
                                            //        //     string sAddress = dgvBranches["address", row.Index].Value.ToString();
                                            //        //     string sTelephone = dgvBranches["telephone1", row.Index].Value.ToString();
                                            //        //     string sFax = dgvBranches["fax1", row.Index].Value.ToString();
                                            //        //     string sEmail = dgvBranches["email1", row.Index].Value.ToString();
                                            //        //     bool BisBillToHO = clsValidate.ValidateGridValue(dgvBranches, "isBillToHeadOffice", row.Index, false);

                                            //        //     tbl_genCustomerMaster_Branches newBranch = new tbl_genCustomerMaster_Branches(row.Index, txtCustomerID.Tag.ToString().Trim(), sBranchName, sAddress, sTelephone,
                                            //        //         sFax, sEmail, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            //        //         clsSecurity.TerminalID,clsSecurity.TerminalID,clsSecurity.TerminalID,clsSecurity.getServerDateTime(),clsSecurity.getServerDateTime(),clsSecurity.getServerDateTime(),clsSecurity.getServerDateTime(),clsSecurity.getServerDateTime(),
                                            //        //         clsSecurity.getServerDateTime(),false,false,false,false,false,BisBillToHO);
                                            //        //     newBranch.Insert();
                                            //        //}
                                            //        #endregion
                                            //    }

                                            //    if (bHasItemInDB)
                                            //    {
                                            //        oldBranch.Line_No = iLineNo;
                                            //        oldBranch.BranchName = sBranchName;
                                            //        oldBranch.Address = sAddress;
                                            //        oldBranch.Telephone = sTelephone;
                                            //        oldBranch.Fax = sFax;
                                            //        oldBranch.Email = sEmail;
                                            //        oldBranch.IsBillltoHeadOffice = bisBillToHO;
                                            //        oldBranch.Update();

                                            //    }
                                            //    else
                                            //    {
                                            //        oldBranch.Delete();
                                            //    }
                                            //}

                                            #endregion

                                            #region Customer Branch Default Branch
                                            if (dgvBranches.Rows.Count <= 0)
                                            {
                                                tbl_genCustomerMaster_Branches newBranch = new tbl_genCustomerMaster_Branches(1, txtCustomerID.Tag.ToString().Trim(), "Head Office", txtAddressRegister.Text.Trim(), "",
                                                    "", "", -1, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                                    clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                    clsSecurity.getServerDateTime(), false, false, false, false, false, false);
                                                newBranch.Insert();
                                            }
                                            #endregion 

                                            //delete and update account code
                                            if (txtControlAcctCode.Tag != null && txtControlAcctCode.Tag.ToString().Trim().Length > 0 && txtControlAcctCode.Tag.ToString().Trim() != "default")
                                            {
                                                tbl_accGLMaster_Customer.DeleteAllByCustomer_ID(txtCustomerID.Tag.ToString());
                                                tbl_accGLMaster_Customer oAcc = new tbl_accGLMaster_Customer(txtCustomerID.Tag.ToString(), txtControlAcctCode.Tag.ToString(), true);
                                                oAcc.Insert();
                                            }
                                            clsHelpMethods.InsertTransactionHistory(iFormID, txtCustomerID.Text, TxnActivity.Update);
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                #endregion

                                #region Insert Method
                                else  //insert records
                                {
                                    #region Serial no
                                    if (clsConfig.bBranchMaster_SerialNoActiveFor_CustomerMaster)
                                    {
                                        txtCustomerID.Tag = clsAutocode.getAutoGeneratedCode_FromCompanyBranch_CustomerMaster(clsSecurity.BranchID);
                                        txtCustomerID.Text = txtCustomerID.Tag.ToString();
                                    }
                                    else if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    {
                                        txtCustomerID.Tag = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                        txtCustomerID.Text = txtCustomerID.Tag.ToString();
                                    }
                                    else
                                        txtCustomerID.Tag = txtCustomerID.Text;
                                    #endregion

                                    if (txtCustomerID.Text.Trim().Length > 0)
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CustomerMaster), txtCustomerID.Tag.ToString(), "Customer Master - Insert");

                                        if (s_FileName.Length > 0)
                                        {
                                            FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                            img = new Byte[fs.Length];
                                            fs.Read(img, 0, (int)fs.Length);
                                            fs.Close();

                                            tbl_genCustomerMaster_Image imageRecord = new tbl_genCustomerMaster_Image(txtCustomerID.Tag.ToString(), img);
                                            imageRecord.Insert();
                                        }
                                        //Customer Master
                                        tbl_genCustomerMaster detail = new tbl_genCustomerMaster(txtCustomerID.Tag.ToString().Trim(), txtCustomerID.Tag.ToString().Trim(), txtCustomerName.Text.Trim(),
                                                txtAddressRegister.Text.Trim(), txtAddressDeliver.Text.Trim(), txtTelephone.Text.Trim(), txtMobile.Text.Trim(), txtFax.Text.Trim(),
                                                txtEmail.Text.Trim(), txtUrl.Text.Trim(), txtBussinessRegNo.Text.Trim(), txtVatRegNo.Text.Trim(), txtNBTRegistrationNo.Text.Trim(),
                                                txtSVATRegistrationNo.Text.Trim(), txtRemark.Text.Trim(), chkBlacklisted.Checked, chkLocked.Checked, chkDeleted.Checked,
                                                "default", "default", "default", "default", "default", "default", "default",
                                                txtCustomerTypeID.Tag.ToString(), txtCategoryID.Tag.ToString(), txtCustomerClassID.Tag.ToString(), txtCurrencyID.Tag.ToString(), txtSalesManagerID.Tag.ToString(),
                                                txtAreaManagerID.Tag.ToString(), txtSalesRepID.Tag.ToString(), txtSalesManagerID.Tag.ToString(),
                                                txtDebtorCode.Text.Trim(), chkVATEnable.Checked, chkSVATEnable.Checked, chkNBTEnable.Checked, false, chkCuswiseItemCodeEnable.Checked, txtTitle.Text.Trim(), txtNICNo.Text.Trim(), dtDateOfBirth.Value, txtAccountType.Tag.ToString(), chkIsPostingEnable_Vat.Checked, chkIsPostingEnable_NBT.Checked, txtSalesReturnGLID.Tag.ToString(), false, clsSecurity.CompanyID, clsSecurity.BranchID, cmbPriceMode.SelectedIndex, (cmbItemPrice.SelectedIndex != -1) ? ((ComboBoxItem)cmbItemPrice.SelectedItem).Value : "default", clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), txtSalesAcctCode.Tag.ToString(), chkPosCustomer.Checked, false, 0);
                                        detail.Insert();

                                        if (txtConsigneeName.Text != "" && txtConsigneeName.Text.Length > 0)
                                        {
                                            tbl_genCustomerMaster_Consignee oConsignee = new tbl_genCustomerMaster_Consignee(1, txtCustomerID.Tag.ToString(), txtConsigneeName.Text, txtConsigneeAddress.Text, txtConsigneeVATNo.Text, txtConsigneeSVATNo.Text, chkMainConsignee.Checked);
                                            oConsignee.Insert();
                                        }

                                        //Customer Finance 
                                        tbl_genCustomerFinance finance = new tbl_genCustomerFinance(txtCustomerID.Tag.ToString().Trim(), decimal.Parse(txtDepositAmount.Text.Trim()),
                                            decimal.Parse(txtCreditPeriod.Text.Trim()), decimal.Parse(txtCreditLimit.Text.Trim()), decimal.Parse(txtSalesDues.Text.Trim()),
                                            decimal.Parse(txtCreditBalance.Text.Trim()), decimal.Parse(txtTotalSales.Text.Trim()), decimal.Parse(txtChequeDeposittedCount.Text.Trim()),
                                            decimal.Parse(txtChequeRealizedCount.Text.Trim()), decimal.Parse(txtChequeReturnedCount.Text.Trim()), decimal.Parse(txtChequeDeposittedAmount.Text.Trim()),
                                            decimal.Parse(txtChequeRealizedAmount.Text.Trim()), decimal.Parse(txtChequeReturnedAmount.Text.Trim()), 0, clsSecurity.getServerDateTime(), 0,
                                            decimal.Parse(txtLoyaltyAmount.Text.Trim()), btLoyalityStartDate, txtLoyalityCardNo.Text, 0, 0, decimal.Parse(txtCreditPeriod_Commisstion.Text.Trim()));
                                        finance.Insert();


                                        UpdateContactDetails();

                                        UpdateDiscounts();

                                        //Route                                    
                                        //foreach (DataGridViewRow row in dgvRoute.Rows)
                                        //{
                                        //    tbl_genCustomerMaster_Route route = new tbl_genCustomerMaster_Route(txtCustomerID.Tag.ToString(), sRouteID, true);
                                        //    route.Insert();
                                        //}

                                        #region Head Office Create
                                        tbl_genCustomerMaster_Branches newBranch = new tbl_genCustomerMaster_Branches(1, txtCustomerID.Tag.ToString().Trim(), "Head Office", txtAddressRegister.Text.Trim(), "",
                                            "", "", -1, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                            clsSecurity.getServerDateTime(), false, false, false, false, false, false);
                                        newBranch.Insert();
                                        #endregion

                                        //delete and update account code
                                        if (txtControlAcctCode.Tag != null && txtControlAcctCode.Tag.ToString().Trim().Length > 0 && txtControlAcctCode.Tag.ToString().Trim() != "default")
                                        {
                                            tbl_accGLMaster_Customer.DeleteAllByCustomer_ID(txtCustomerID.Tag.ToString());
                                            tbl_accGLMaster_Customer oAcc = new tbl_accGLMaster_Customer(txtCustomerID.Tag.ToString(), txtControlAcctCode.Tag.ToString(), true);
                                            oAcc.Insert();
                                        }


                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtCustomerID.Text, TxnActivity.Insert);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show("Customer " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                #endregion

                            }
                            catch (Exception ex)
                            {
                                SEACCException.Show(ex);
                                clsValidate.WriteErrorLog("", iFormID, ex);
                            }
                            finally
                            {
                                Cursor = Cursors.Default;

                                if (glb_bIsCustomerOrderMode)
                                {
                                    glb_sCustomerID = txtCustomerID.Text.Trim();
                                    //this.Close();
                                }
                                else
                                {
                                    RefreshGrid();
                                    ClearFields();
                                }
                            }
                        }
                    }
                }
            }
        }

        #region Update Contact Details
        private void UpdateContactDetails()
        {

            tbl_genCustomerAddressBook.DeleteAllByCustomer_ID(txtCustomerID.Tag.ToString().Trim());
            int iIndex = 0;
            foreach (DataGridViewRow row in dgvAddressBook.Rows)
            {
                string sContactName = "", sDesignation = "", sTelephone = "", sMobile = "", sFax = "", sEmail = "";

                sContactName = dgvAddressBook["ContactName", row.Index].Value.ToString();
                sDesignation = dgvAddressBook["Designation", row.Index].Value.ToString();
                sTelephone = dgvAddressBook["Telephone", row.Index].Value.ToString();
                sMobile = dgvAddressBook["Mobile", row.Index].Value.ToString();
                sFax = dgvAddressBook["Fax", row.Index].Value.ToString();
                sEmail = dgvAddressBook["Email", row.Index].Value.ToString();

                tbl_genCustomerAddressBook address = new tbl_genCustomerAddressBook(iIndex, txtCustomerID.Tag.ToString().Trim(), sContactName, sDesignation, sTelephone, sMobile, sFax, sEmail);
                address.Insert();
                iIndex++;

                //if (dgvAddressBook["ContactName", row.Index].Value != null && dgvAddressBook["ContactName", row.Index].Value.ToString().Length > 0)
                //    sContactName = dgvAddressBook["ContactName", row.Index].Value.ToString();
                //if (dgvAddressBook["Designation", row.Index].Value != null && dgvAddressBook["Designation", row.Index].Value.ToString().Length > 0)
                //    sDesignation = dgvAddressBook["Designation", row.Index].Value.ToString();
                //if (dgvAddressBook["Telephone", row.Index].Value != null && dgvAddressBook["Telephone", row.Index].Value.ToString().Length > 0)
                //    sTelephone = dgvAddressBook["Telephone", row.Index].Value.ToString();
                //if (dgvAddressBook["Mobile", row.Index].Value != null && dgvAddressBook["Mobile", row.Index].Value.ToString().Length > 0)
                //    sMobile = dgvAddressBook["Mobile", row.Index].Value.ToString();
                //if (dgvAddressBook["Fax", row.Index].Value != null && dgvAddressBook["Fax", row.Index].Value.ToString().Length > 0)
                //    sFax = dgvAddressBook["Fax", row.Index].Value.ToString();
                //if (dgvAddressBook["Email", row.Index].Value != null && dgvAddressBook["Email", row.Index].Value.ToString().Length > 0)
                //    sEmail = dgvAddressBook["Email", row.Index].Value.ToString();
                //tbl_genCustomerAddressBook address = new tbl_genCustomerAddressBook(row.Index, txtCustomerID.Tag.ToString().Trim(), sContactName,
                //    sDesignation, sTelephone, sMobile, sFax, sEmail);
                //address.Insert();
            }
        }
        #endregion

        #region Update Discount
        private void UpdateDiscounts()
        {
            try
            {
                tbl_genCustomerDiscount.DeleteAllByCustomer_ID(txtCustomerID.Tag.ToString().Trim());

                int iIndex = 0;
                foreach (DataGridViewRow row in dgvDiscount.Rows)
                {
                    string sDiscount_ID = "";
                    //  decimal dDiscountPresentage = 0;
                    bool bIsActive = false;
                    bool bIsRateLocked = false;

                    sDiscount_ID = dgvDiscount["DiscountType", row.Index].Tag.ToString();

                    string DiscountPresentage = clsValidate.ValidateGridValue(dgvDiscount, "DiscountPresentage", row.Index, "0.00").Replace(" %", "");
                    decimal dDiscountPresentage = decimal.Parse(DiscountPresentage);


                    //    dDiscountPresentage = clsValidate.ValidateGridValue(dgvDiscount, "DiscountPresentage", row.Index, decimal.Parse("0.00"));
                    bIsActive = (clsValidate.ValidateGridValue(dgvDiscount, "isActive", row.Index, "") == "True") ? true : false;
                    bIsRateLocked = (clsValidate.ValidateGridValue(dgvDiscount, "IsRateLocked", row.Index, "") == "True") ? true : false;

                    tbl_genCustomerDiscount discount = new tbl_genCustomerDiscount(txtCustomerID.Tag.ToString(), sDiscount_ID, dDiscountPresentage, bIsRateLocked, bIsActive);
                    discount.Insert();
                    iIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region Btn ImageLoad
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();

            filedialog.Filter = "JPG Files|*.Jpg|" + "JPEG Files|*.Jpeg";
            filedialog.ShowDialog();
            s_FileName = filedialog.FileName;
            pbxImage.ImageLocation = s_FileName;
        }
        #endregion

        #region Btn Add Contact
        private void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtcon_ContactName.Text.Length > 0 || txtcon_Designation.Text.Length > 0 ||
                  txtcon_Mobile.Text.Length > 0 || txtcon_Telephone.Text.Length > 0 ||
                  txtcon_Fax.Text.Length > 0 || txtcon_Email.Text.Length > 0)
                {
                    int iRow = 0;
                    if (IsUpdateAddressBook)
                        iRow = int.Parse(txtRowNo.Text.Trim());
                    else
                    {
                        dgvAddressBook.Rows.Add();
                        iRow = dgvAddressBook.Rows.Count - 1;
                    }


                    dgvAddressBook["ContactName", iRow].Value = txtcon_ContactName.Text.Trim();
                    dgvAddressBook["Designation", iRow].Value = txtcon_Designation.Text.Trim();
                    dgvAddressBook["Telephone", iRow].Value = txtcon_Telephone.Text.Trim();
                    dgvAddressBook["Mobile", iRow].Value = txtcon_Mobile.Text.Trim();
                    dgvAddressBook["Fax", iRow].Value = txtcon_Fax.Text.Trim();
                    dgvAddressBook["Email", iRow].Value = txtcon_Email.Text.Trim();

                    ClearFieldContact();
                    IsUpdateAddressBook = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        #endregion

        #region Btn Remove Contact
        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAddressBook.SelectedCells.Count != 0)
                {
                    if (dgvAddressBook.Rows.Count > 1)
                        dgvAddressBook.Rows.RemoveAt(dgvAddressBook.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Btn Clear Contact
        private void btnClearContact_Click(object sender, EventArgs e)
        {
            ClearFieldContact();
        }
        #endregion

        #region Btn Add Branches
        private void btnAddBranches_Click(object sender, EventArgs e)
        {
            #region old
            //int iRow;
            //if (IsUpdateBranche)
            //{
            //    iRow = int.Parse(txtBranchesRowNo.Tag.ToString());
            //    dgvBranches["lineNo", iRow].Value = int.Parse(txtBranchesRowNo.Text.Trim());
            //}
            //else
            //{
            //    dgvBranches.Rows.Add();
            //    int iLine = 0;
            //    //List<tbl_genCustomerMaster_Branches> Detail = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
            //    //if (Detail.Count > 0)
            //    //    iLine = Detail.Max(p => p.Line_No);

            //    if (dgvBranches.RowCount > 1)
            //        iLine = dgvBranches.RowCount - 1;

            //    iRow = dgvBranches.Rows.Count - 1;
            //    dgvBranches["lineNo", iRow].Value = ++iLine;
            //}

            //dgvBranches["branchName1", iRow].Value = txtBra_BranchesName.Text.Trim();
            //dgvBranches["address", iRow].Value = txtBra_Address.Text.Trim();
            //dgvBranches["telephone1", iRow].Value = txtBranches_Telephone.Text.Trim();
            //dgvBranches["fax1", iRow].Value = txtBra_FaxNo.Text.Trim();
            //dgvBranches["email1", iRow].Value = txBranchEmail.Text.Trim();
            //dgvBranches["isBillToHeadOffice", iRow].Value = chkBillToHeadOffice.Checked;

            //ClearFieldBranch(); 
            #endregion

            try
            {
                int iRow;
                int iRouteID = -1;
                if (int.Parse(txtRouteID.Tag.ToString()) >= 0)
                    iRouteID = int.Parse(txtRouteID.Tag.ToString());

                #region Update - Customer Branch
                if (IsUpdateBranche)
                {
                    iRow = int.Parse(txtBranchesRowNo.Tag.ToString());
                    //dgvBranches["lineNo", iRow].Value = int.Parse(txtBranchesRowNo.Text.Trim());

                    int iLineNo = int.Parse(txtBranchesRowNo.Text.Trim());
                    string sBranchName = txtBra_BranchesName.Text.Trim();
                    string sAddress = txtBra_Address.Text.Trim();
                    string sTelephone = txtBranches_Telephone.Text.Trim();
                    string sFax = txtBra_FaxNo.Text.Trim();
                    string sEmail = txBranchEmail.Text.Trim();

                    bool bisBillToHO = chkBillToHeadOffice.Checked;

                    tbl_genCustomerMaster_Branches newBranch = new tbl_genCustomerMaster_Branches(iLineNo, txtCustomerID.Tag.ToString().Trim(), sBranchName, sAddress, sTelephone,
                                                                 sFax, sEmail, iRouteID, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                                                 clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                 clsSecurity.getServerDateTime(), false, false, false, false, false, bisBillToHO);
                    newBranch.Update();

                    dgvBranches["lineNo", iRow].Value = iLineNo;
                    dgvBranches["branchName1", iRow].Value = sBranchName;
                    dgvBranches["address", iRow].Value = sAddress;
                    dgvBranches["telephone1", iRow].Value = sTelephone;
                    dgvBranches["fax1", iRow].Value = sFax;
                    dgvBranches["email1", iRow].Value = sEmail;
                    dgvBranches["isBillToHeadOffice", iRow].Value = bisBillToHO;

                    dgvBranches["RouteID", iRow].Tag = iRouteID;
                    dgvBranches["RouteID", iRow].Value = txtRouteID.Text.Trim();
                }
                #endregion

                #region Insert - Customer Branch
                else
                {
                    string sBranchName = txtBra_BranchesName.Text.Trim();
                    if (sBranchName != "")
                    {
                        int iLineNo = 0;
                        dgvBranches.Rows.Add();
                        iRow = dgvBranches.Rows.Count - 1;

                        if (dgvBranches.RowCount >= 1)
                        {
                            //iLineNo = dgvBranches.RowCount;
                            List<tbl_genCustomerMaster_Branches> oCusBranches = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString().Trim()).OrderBy(o => o.Line_No).ToList();
                            if (oCusBranches.Count > 0)
                                iLineNo = oCusBranches.Last().Line_No;
                        }

                        ++iLineNo;

                        string sAddress = txtBra_Address.Text.Trim();
                        string sTelephone = txtBranches_Telephone.Text.Trim();
                        string sFax = txtBra_FaxNo.Text.Trim();
                        string sEmail = txBranchEmail.Text.Trim();
                        //int iRouteID = int.Parse(txtRouteID.Tag.ToString());
                        bool bisBillToHO = chkBillToHeadOffice.Checked;

                        tbl_genCustomerMaster_Branches newBranch = new tbl_genCustomerMaster_Branches(iLineNo, txtCustomerID.Tag.ToString().Trim(), sBranchName, sAddress, sTelephone,
                                                                     sFax, sEmail, iRouteID, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                                                     clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                     clsSecurity.getServerDateTime(), false, false, false, false, false, bisBillToHO);
                        newBranch.Insert();

                        dgvBranches["lineNo", iRow].Value = iLineNo;
                        dgvBranches["branchName1", iRow].Value = sBranchName;
                        dgvBranches["address", iRow].Value = sAddress;
                        dgvBranches["telephone1", iRow].Value = sTelephone;
                        dgvBranches["fax1", iRow].Value = sFax;
                        dgvBranches["email1", iRow].Value = sEmail;
                        dgvBranches["isBillToHeadOffice", iRow].Value = bisBillToHO;

                        dgvBranches["RouteID", iRow].Tag = iRouteID;
                        dgvBranches["RouteID", iRow].Value = txtRouteID.Text.Trim();

                        //if (dgvBranches.RowCount > 1)
                        //    iLine = dgvBranches.RowCount - 1;

                        //iRow = dgvBranches.Rows.Count - 1;
                        //dgvBranches["lineNo", iRow].Value = ++iLine;
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            ClearFieldBranch();

        }
        #endregion

        #region Btn Remove Branches
        private void btnRemoveBranches_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBranches.SelectedCells.Count != 0)
                {
                    if (dgvBranches.Rows.Count > 1)
                    {
                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (msgResult == DialogResult.Yes)
                        {
                            int iRow = dgvBranches.SelectedCells[0].RowIndex;
                            int iLineNo = int.Parse(dgvBranches["lineNo", iRow].Value.ToString());
                            try
                            {
                                tbl_genCustomerMaster_Branches oBranches = tbl_genCustomerMaster_Branches.Select(txtCustomerID.Tag.ToString(), iLineNo);
                                if (oBranches != null)
                                {
                                    oBranches.Delete();

                                }
                            }
                            catch (Exception ex)
                            {
                                clsValidate.WriteErrorLog("", iFormID, ex);
                                SEACCException.Show(ex);
                            }
                            dgvBranches.Rows.RemoveAt(dgvBranches.SelectedCells[0].RowIndex);
                            ClearFieldBranch();
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Btn Clear Branches
        private void btnClearBranches_Click(object sender, EventArgs e)
        {
            ClearFieldBranch();
        }
        #endregion

        #region Btn Print
        private void frm_masCustomerMaster_SF_printButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                glbdts_Master.Clear();

                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.Mas_Customer)))
                {
                    string sCreditLimit = "", sCreditPeriod = "";
                    int iCount = 0;

                    string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                    if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.Mas_Customer), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                    {
                        if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                        {
                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                            if (oCustomer != null && oCustomer.Customer_ID != "default")
                            {
                                #region Get Finance Detail
                                tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                                if (finance != null && finance.Customer_ID != "default")
                                {
                                    sCreditLimit = finance.CreditLimit.ToString();
                                    sCreditPeriod = finance.CreditPeriod.ToString();
                                }
                                #endregion

                                glbdts_Master.dt_masCustomerNotePrint.Adddt_masCustomerNotePrintRow(oCustomer.Customer_ID, oCustomer.CustomerCode, oCustomer.CustomerName, clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID), oCustomer.DateOfBirth, oCustomer.AddressRegister, oCustomer.AddressDelivery, oCustomer.Telephone, oCustomer.Mobile, oCustomer.Fax, oCustomer.Url, oCustomer.Email, clsGenaralName.getName_Currency(oCustomer.Currency_ID), decimal.Parse(sCreditLimit), decimal.Parse(sCreditPeriod), oCustomer.VatRegistrationNo, oCustomer.SvatRegistrationNo, clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID));

                                foreach (tbl_genCustomerAddressBook oItem in tbl_genCustomerAddressBook.SelectAllByCustomer_ID(oCustomer.Customer_ID))
                                {
                                    iCount++;
                                    glbdts_Master.dt_masCustomerAddressBook.Adddt_masCustomerAddressBookRow(iCount, oCustomer.Customer_ID, oItem.ContactName, oItem.Designation, oItem.Telephone, oItem.Mobile, oItem.Fax, oItem.Email);
                                }

                                glbdts_Master.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, glbdts_Master, glbParameter, clsAutocode.getReportID(enum_ReportName.Mas_Customer));
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtCustomerID.Text, TxnActivity.PrintOriginal);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glbdts_Master.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvBranches, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvAddressBook, clsFormatter.colorGrid, UI_Color);

            //clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));

            //clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMaster);
            //clsFormatter.ApplyGridFormat(dgvBranches, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMaster);
            //clsFormatter.ApplyGridFormat(dgvAddressBook, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMaster);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            txtCustomerID.Enabled = true;
            clsCommon.SetEnableDisable_NormalTextbox(txtCustomerCode, false);

            pnlBranch.Visible = true;

            txtCategoryID.Tag = null;
            txtCurrencyID.Tag = null;
            txtTitle.Tag = null;
            dtDateOfBirth.Tag = null;
            txtCustomerClassID.Tag = null;
            txtCustomerTypeID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtSalesManagerID.Tag = null;
            txtAreaManagerID.Tag = null;
            txtSalesRepID.Tag = null;
            txtBranchName.Tag = null;
            txtControlAcctCode.Tag = null;
            txtAccountType.Tag = null;
            txtSalesReturnGLID.Tag = null;
            txtSalesAcctCode.Tag = null;

            txtAddressDeliver.Clear();
            txtAddressRegister.Clear();
            txtTitle.Clear();
            txtNICNo.Clear();
            txtBussinessRegNo.Clear();
            txtCategoryID.Clear();
            txtCurrencyID.Clear();
            txtDebtorCode.Clear();
            txtFax.Clear();
            txtRemark.Clear();
            txtSalesManagerID.Clear();
            txtAreaManagerID.Clear();
            txtSalesRepID.Clear();
            txtSalesExecutiveID.Clear();
            txtCustomerClassID.Clear();
            txtCustomerName.Clear();
            txtCustomerCode.Clear();
            txtCustomerTypeID.Clear();
            txtTelephone.Clear();
            txtMobile.Clear();
            txtSVATRegistrationNo.Clear();
            txtUrl.Clear();
            txtVatRegNo.Clear();
            txtNBTRegistrationNo.Clear();
            txtEmail.Clear();
            txtAccountType.Clear();
            txtControlAcctCode.Clear();
            txtSalesAcctCode.Clear();
            txtCreditLimit.Text = "0.00";
            txtCreditPeriod.Text = "0";
            txtCreditPeriod_Commisstion.Text = "0";
            txtDepositAmount.Text = "0.00";
            txtSalesDues.Text = "0.00";
            txtCreditBalance.Text = "0.00";
            txtTotalSales.Text = "0.00";
            txtChequeDeposittedAmount.Text = "0.00";
            txtChequeDeposittedCount.Text = "0";
            txtChequeRealizedAmount.Text = "0.00";
            txtChequeRealizedCount.Text = "0";
            txtChequeReturnedAmount.Text = "0.00";
            txtChequeReturnedCount.Text = "0";
            txtBranchName.Clear();
            txtLoyaltyAmount.Text = "0.00";
            dtpLoyaltyDate.Value = clsSecurity.getServerDateTime();
            txtLoyalityCardNo.Clear();
            txtOutstandingAmount.Text = "0";
            txtChequeInHandAmount.Text = "0";
            txtSalesReturnGLID.Clear();
            txtConsigneeName.Text = "";
            txtConsigneeAddress.Text = "";
            txtConsigneeVATNo.Text = "";
            txtConsigneeSVATNo.Text = "";

            chkBlacklisted.Checked = false;
            chkDeleted.Checked = false;
            chkLocked.Checked = false;
            chkBillToHeadOffice.Checked = false;
            chkMainConsignee.Checked = false;
            chkCuswiseItemCodeEnable.Checked = false;
            chkPosCustomer.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCustomerID.Text = "<Auto Generate>";
            else
                txtCustomerID.Clear();

            dgvAddressBook.Rows.Clear();
            dgvBranches.Rows.Clear();
            dgvDiscount.Rows.Clear();

            ClearFieldContact();
            ClearFieldBranch();

            RefreshGrid();
            pbxImage.Image = null;
            s_FileName = "";
            txtColourCorporateSupplier.ForeColor = clsFormatter.colorCorporateCustomer;
            txtColourGeneralSupplier.ForeColor = clsFormatter.colorGeneralCustomer;
            txtColourSalesRep.ForeColor = clsFormatter.colorSalesRepCustomer;

            if (txtCustomerID.Enabled)
            {
                txtCustomerID.SelectAll();
                txtCustomerID.Focus();
            }
            sourceCustomerMaster.Filter = null;

            IsUpdateAddressBook = false;
            chkIsPostingEnable_NBT.Checked = false;
            chkIsPostingEnable_Vat.Checked = false;
            chkNonTAX.Checked = false;
            chkVATEnable.Checked = false;
            chkNBTEnable.Checked = false;
            chkSVATEnable.Checked = false;

            txtBranchName.Tag = "default";
            txtBranchName.Text = "default";
            dtDateOfBirth.Value = clsValidation.defaultDateTime;
            dtCreatedDate.Value = clsValidation.defaultDateTime;
            clsFill.FillEnumDescription(typeof(enum_CustomerPrice_Mode), ref cmbPriceMode); // Fill Customer Price Modes
            clsFill.Fill_ItemPrices(ref cmbItemPrice); //Fill Item Price Categories
            EnableDisablePriceCategory();

            HideSalesRepDetails();
        }
        #endregion

        #region Clear Field Contact
        private void ClearFieldContact()
        {
            //set the flag and enble the id

            txtcon_ContactName.Clear();
            txtcon_Designation.Clear();
            txtcon_Mobile.Clear();
            txtcon_Telephone.Clear();
            txtcon_Fax.Clear();
            txtcon_Email.Clear();
        }
        #endregion

        #region Clear Fields Branch
        private void ClearFieldBranch()
        {
            //set the flag and enble the id
            IsUpdateBranche = false;

            txtBranchesRowNo.Tag = null;
            txtBranchesRowNo.Clear();
            txtBra_BranchesName.Clear();
            txtBra_Address.Clear();
            txtBranches_Telephone.Clear();
            txtBra_FaxNo.Clear();
            txBranchEmail.Clear();
            txtBranches_Telephone.Clear();
            chkBillToHeadOffice.Checked = false;

            txtRouteID.Tag = -1;
            txtRouteID.Text = "";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            dt.Rows.Clear();

            dt.Merge(DBHandling.ExecQuery("exec tbl_genCustomerMasterBy_BranchID '" + clsSecurity.BranchID + "'").Tables[0]);

            if (dt.Rows.Count > 0)
            {
                sourceCustomerMaster.DataSource = dt;
            }
        }

        private void RefreshGrid_Branch()
        {
            int iRow;
            dgvBranches.Rows.Clear();
            List<tbl_genCustomerMaster_Branches> details = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
            if (details != null)
            {
                foreach (tbl_genCustomerMaster_Branches detail in details)
                {
                    dgvBranches.Rows.Add();
                    iRow = dgvBranches.Rows.Count - 1;
                    dgvBranches["lineNo", iRow].Value = detail.Line_No;
                    dgvBranches["branchName1", iRow].Value = detail.BranchName;
                    dgvBranches["address", iRow].Value = detail.Address;
                    dgvBranches["telephone1", iRow].Value = detail.Telephone;
                    dgvBranches["fax1", iRow].Value = detail.Fax;
                    dgvBranches["email1", iRow].Value = detail.Email;
                    dgvBranches["isBillToHeadOffice", iRow].Value = detail.IsBillltoHeadOffice;

                    dgvBranches["RouteID", iRow].Tag = detail.Route_ID;
                    dgvBranches["RouteID", iRow].Value = clsGenaralName.getCode_Route(detail.Route_ID);
                }
            }
        }

        private void RefreshGrid_Account()
        {

        }

        private void RefreshGrid_AddressBook()
        {
            int iRow, iRowCount = 0;

            dgvAddressBook.Rows.Clear();
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
            {
                List<tbl_genCustomerAddressBook> details = tbl_genCustomerAddressBook.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString().Trim());
                foreach (tbl_genCustomerAddressBook detail in details)
                {
                    dgvAddressBook.Rows.Add();
                    iRow = dgvAddressBook.Rows.Count - 1;
                    dgvAddressBook["line_No", iRow].Value = detail.Email;
                    dgvAddressBook["ContactName", iRow].Value = detail.ContactName;
                    dgvAddressBook["Designation", iRow].Value = detail.Designation;
                    dgvAddressBook["Telephone", iRow].Value = detail.Telephone;
                    dgvAddressBook["Mobile", iRow].Value = detail.Mobile;
                    dgvAddressBook["Fax", iRow].Value = detail.Fax;
                    dgvAddressBook["Email", iRow].Value = detail.Email;

                    // iRowCount++;
                }
                ClearFieldContact(); //this is need
            }
        }
        public string FormatToCurrecyWithThousendSep(decimal dWeight)
        {
            string value = "0 %";
            value = String.Format("{0:0.00}", dWeight) + " %";
            return value;
        }
        private void RefreshGrid_Discount()
        {
            int iRow;
            dgvDiscount.Rows.Clear();
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
            {
                foreach (tbl_zDiscount oDiscount in tbl_zDiscount.SelectAll().Where(p => !p.IsDeleted))
                {
                    decimal dDiscountPresentage = 0;
                    bool bIsEnaable = false, bIsRateLocked = false;

                    tbl_genCustomerDiscount detail = tbl_genCustomerDiscount.Select(txtCustomerID.Tag.ToString(), oDiscount.Discount_Id);
                    if (detail != null && detail.Discount_Id != "default")
                    {
                        dDiscountPresentage = detail.DiscountPresentage;
                        bIsEnaable = detail.IsActive;
                        bIsRateLocked = detail.IsRateLocked;
                    }

                    dgvDiscount.Rows.Add();
                    iRow = dgvDiscount.Rows.Count - 1;

                    dgvDiscount["DiscountType", iRow].Value = oDiscount.DiscountName;
                    dgvDiscount["DiscountType", iRow].Tag = oDiscount.Discount_Id;
                    dgvDiscount["DiscountPresentage", iRow].Value = FormatToCurrecyWithThousendSep(dDiscountPresentage);
                    dgvDiscount["DiscountPresentage", iRow].Tag = dDiscountPresentage;
                    dgvDiscount["isActive", iRow].Value = bIsEnaable;
                    dgvDiscount["IsRateLocked", iRow].Value = clsConfig.bIsRateLocked_Multiple_Discount ? true : bIsRateLocked;
                }
            }
        }


        private void RefreshGridSearchByCustomerID(string sCustomerID)
        {
            sourceCustomerMaster.Filter = " CustomerID LIKE '%" + sCustomerID.Trim() + "%'";
        }

        private void RefreshGridSearchByCustomerName(string sCustomerName)
        {
            string value = sCustomerName.Trim();
            string sCheckedValue = CheckValue(value);
            sourceCustomerMaster.Filter = " CustomerName LIKE '%" + sCheckedValue + "%'";
        }

        #endregion

        #region CheckValue
        private string CheckValue(string value)
        {
            StringBuilder sBuilder = new StringBuilder(value);
            string pattern = @"([-\]\[<>\?\*\\\""/\|\~\(\)\#/=><+\%&\^\'])";
            Regex expression = new Regex(pattern);

            if (expression.IsMatch(value))
            {
                sBuilder.Replace("[", "[[]");
                sBuilder.Replace("]", "[]]");
                sBuilder.Replace("[[[]]", "[[]");

                sBuilder.Replace("'", "''");
                sBuilder.Replace("*", "[*]");
                sBuilder.Replace("%", "[%]");
            }
            return sBuilder.ToString();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(sID);
                if (detail != null)
                {
                    IsUpdate = true;

                    txtCustomerID.Enabled = false;
                    pnlBranch.Visible = false;
                    //asign values                    
                    txtCategoryID.Tag = detail.CustomerCategory_ID;
                    txtCurrencyID.Tag = detail.Currency_ID;
                    txtTitle.Tag = detail.Title;
                    txtSalesManagerID.Tag = detail.SalesManager_ID;
                    txtAreaManagerID.Tag = detail.AreaManager_ID;
                    txtSalesRepID.Tag = detail.SalesRep_ID;
                    txtSalesExecutiveID.Tag = detail.SalesExecutive_ID;
                    txtCustomerClassID.Tag = detail.CustomerClass_ID;
                    txtCustomerTypeID.Tag = detail.CustomerType_ID;
                    txtCustomerID.Tag = detail.Customer_ID;
                    txtBranchName.Tag = detail.CompanyBranch_ID;
                    txtSalesAcctCode.Tag = detail.Sales_Gl_ID;

                    txtCustomerID.Text = detail.Customer_ID;
                    txtCategoryID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CustomerCategory(detail.CustomerCategory_ID));
                    txtTitle.Text = detail.Title;
                    dtDateOfBirth.Text = detail.DateOfBirth.Date == detail.DateCreate.Date ? Convert.ToDateTime(clsValidation.defaultDateTime).ToString() : Convert.ToDateTime(detail.DateOfBirth).ToString();
                    dtCreatedDate.Text = Convert.ToDateTime(detail.DateCreate).ToString();
                    txtNICNo.Text = detail.NicNo;
                    txtCurrencyID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Currency(detail.Currency_ID));
                    txtCustomerClassID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CustomerClass(detail.CustomerClass_ID));
                    txtCustomerTypeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CustomerType(detail.CustomerType_ID));
                    txtSalesManagerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesManager(detail.SalesManager_ID));
                    txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesExecutive(detail.SalesExecutive_ID));
                    txtSalesRepID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(detail.SalesRep_ID));
                    txtAreaManagerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AreaManager(detail.AreaManager_ID));
                    txtBranchName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CompanyBranchMaster(detail.CompanyBranch_ID));
                    txtAddressDeliver.Text = detail.AddressDelivery;
                    txtAddressRegister.Text = detail.AddressRegister;
                    txtEmail.Text = detail.Email;
                    txtUrl.Text = detail.Url;
                    txtFax.Text = detail.Fax;
                    txtRemark.Text = detail.Remark;
                    txtCustomerName.Text = detail.CustomerName;
                    txtCustomerCode.Text = detail.CustomerCode;
                    txtTelephone.Text = detail.Telephone;
                    txtMobile.Text = detail.Mobile;
                    txtSalesAcctCode.Text = clsGenaralName.getName_AccountName(detail.Sales_Gl_ID);

                    txtBussinessRegNo.Text = detail.BusinessRegistraionNo;
                    txtVatRegNo.Text = detail.VatRegistrationNo;
                    txtSVATRegistrationNo.Text = detail.SvatRegistrationNo;
                    txtNBTRegistrationNo.Text = detail.NbtRegistrationNo;
                    txtDebtorCode.Text = detail.Gl_ID;


                    //rdoNonTax.Checked = true;
                    //chkNonTAX.Checked = detail.
                    chkSVATEnable.Checked = detail.IsSVATenable;
                    chkVATEnable.Checked = detail.IsVATenable;
                    chkNBTEnable.Checked = detail.IsNBTenable;

                    if (chkSVATEnable.Checked || chkVATEnable.Checked || chkNBTEnable.Checked)
                        chkNonTAX.Checked = false;
                    else
                        chkNonTAX.Checked = true;

                    chkBlacklisted.Checked = detail.IsBlacklisted;
                    chkDeleted.Checked = detail.IsDeleted;
                    chkLocked.Checked = detail.IsLocked;
                    chkIsPostingEnable_NBT.Checked = detail.IsPostingEnable_NBT;
                    chkIsPostingEnable_Vat.Checked = detail.IsPostingEnable_VAT;
                    chkCuswiseItemCodeEnable.Checked = detail.IsCustomerWiseItemCode;
                    chkPosCustomer.Checked = detail.IsPOSCustomer;

                    tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(sID);
                    if (finance != null)
                    {
                        //clsFormatter.FormatToCurrecyWithThousendSep added by Gayan 2016.08.04
                        txtCreditLimit.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.CreditLimit);
                        txtCreditPeriod.Text = finance.CreditPeriod.ToString();
                        txtCreditPeriod_Commisstion.Text = finance.CommissionCreditPeriod.ToString();

                        txtDepositAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.DepositAmount);
                        txtSalesDues.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.SalesDues);
                        txtCreditBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.CreditBalance);
                        txtTotalSales.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.TotalSales);

                        txtChequeDeposittedAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.DeposittedChequeAmount);
                        txtChequeDeposittedCount.Text = finance.DeposittedChequeCount.ToString();
                        txtChequeRealizedAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.RealizedChequeAmount);
                        txtChequeRealizedCount.Text = finance.RealizedChequeCount.ToString();
                        txtChequeReturnedAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.ReturnedChequeAmount);
                        txtChequeReturnedCount.Text = finance.ReturnedChequeCount.ToString();
                        txtLoyaltyAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.LoyaltyAmount);
                        dtpLoyaltyDate.Value = finance.LoyalityStartDate;
                        txtLoyalityCardNo.Text = finance.LoyalityCardNo;
                        txtOutstandingAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.OutstandingAmount);
                        txtChequeInHandAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(finance.ChequeInHandAmount);
                    }
                }

                //cmbItemPrice
                if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
                {
                    foreach (ComboBoxItem d in cmbItemPrice.Items)
                    {
                        if (d.Value == detail.ItemPriceCategory)
                        {
                            cmbItemPrice.SelectedItem = d;
                            break;
                        }
                    }
                }

                //cmbPriceMode
                cmbPriceMode.SelectedIndex = detail.ItemPriceMode;

                //Image 
                if (detail != null && detail.Customer_ID.Length > 0)
                {
                    tbl_genCustomerMaster_Image cImage = tbl_genCustomerMaster_Image.Select(detail.Customer_ID);
                    if (cImage != null && cImage.Image != null)
                    {
                        if (cImage.Image.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(cImage.Image);
                            pbxImage.Image = Image.FromStream(ms);
                        }
                        else
                            pbxImage.Image = pbxImage.InitialImage;
                    }
                    else
                        pbxImage.Image = pbxImage.InitialImage;
                }


                //Fill Sales Return Account Code 
                txtSalesReturnGLID.Tag = detail.SalesReturnedGL_ID;
                txtSalesReturnGLID.Text = clsGenaralName.getName_AccountName(detail.SalesReturnedGL_ID);

                //fill GL code
                txtAccountType.Tag = detail.CustomerAccountType_ID;

                txtControlAcctCode.Tag = null;
                txtControlAcctCode.Clear();

                List<tbl_accGLMaster_Customer> oAccs = tbl_accGLMaster_Customer.SelectAllByCustomer_ID(detail.Customer_ID);
                if (oAccs != null)
                {
                    if (oAccs.Count > 1)
                        MessageBox.Show("There are more than 1 GL codes are taged with this customer, Please contact the accountant", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (oAccs.Count > 0)
                        {
                            txtControlAcctCode.Tag = oAccs.FirstOrDefault().Gl_ID;
                            txtControlAcctCode.Text = clsGenaralName.getName_AccountName(oAccs.FirstOrDefault().Gl_ID);
                        }
                    }
                }

                //Fill consignee Detail
                tbl_genCustomerMaster_Consignee oConsignee = tbl_genCustomerMaster_Consignee.Select(1, detail.Customer_ID);
                if (oConsignee != null && oConsignee.Customer_ID != "default")
                {
                    txtConsigneeName.Text = oConsignee.ConsigneeName;
                    txtConsigneeAddress.Text = oConsignee.ConsigneeAddress;
                    txtConsigneeVATNo.Text = oConsignee.VatRegistrationNo;
                    txtConsigneeSVATNo.Text = oConsignee.SvatRegistrationNo;
                }
                else
                {
                    txtConsigneeName.Text = "";
                    txtConsigneeAddress.Text = "";
                    txtConsigneeVATNo.Text = "";
                    txtConsigneeSVATNo.Text = "";
                }


                EnableDisablePriceCategory();
                //fill stock details
                RefreshGrid_Account();
                RefreshGrid_AddressBook();
                RefreshGrid_Discount();
                RefreshGrid_Branch();
                //RefreshGrid_BranchByCustomer();
            }
        }
        #endregion

        #region Fill Branches
        private void FillDetailsBranches(int iRow)
        {
            try
            {
                //set the update flag and Locked
                IsUpdateBranche = true;
                txtBranchesRowNo.Text = dgvBranches["lineNo", iRow].Value.ToString();
                txtBranchesRowNo.Tag = iRow;
                txtBra_BranchesName.Text = dgvBranches["branchName1", iRow].Value.ToString();
                txtBra_Address.Text = dgvBranches["address", iRow].Value.ToString();
                txtBranches_Telephone.Text = dgvBranches["telephone1", iRow].Value.ToString();
                txtBra_FaxNo.Text = dgvBranches["fax1", iRow].Value.ToString();
                txBranchEmail.Text = dgvBranches["email1", iRow].Value.ToString();
                chkBillToHeadOffice.Checked = clsValidate.ValidateGridValue(dgvBranches, "isBillToHeadOffice", iRow, true);

                txtRouteID.Tag = dgvBranches["RouteID", iRow].Tag.ToString();
                txtRouteID.Text = dgvBranches["RouteID", iRow].Value.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Address Book
        private void FillDetailsAddressBook(int iRow)
        {
            try
            {
                //set the update flag and Locked
                IsUpdateAddressBook = true;
                txtcon_ContactName.Text = dgvAddressBook["ContactName", iRow].Value.ToString();
                txtcon_Designation.Text = dgvAddressBook["Designation", iRow].Value.ToString();
                txtcon_Telephone.Text = dgvAddressBook["Telephone", iRow].Value.ToString();
                txtcon_Mobile.Text = dgvAddressBook["Mobile", iRow].Value.ToString();
                txtcon_Fax.Text = dgvAddressBook["Fax", iRow].Value.ToString();
                txtcon_Email.Text = clsValidate.ValidateGridValue(dgvAddressBook, "Email", iRow, "");
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Sales Rep
        private void FillDetailsSalesRep(string sSalesRep_ID)
        {
            try
            {
                tbl_ZEmpSalesRep detail = tbl_ZEmpSalesRep.Select(sSalesRep_ID); //District
                if (detail != null)
                {
                    txtSalesRepID.Tag = detail.SelesRep_ID;
                    txtSalesRepID.Text = clsCommon.GetForeignKeyValue(detail.SelesRepName);

                    tbl_ZEmpAreaManager oAreaManagers = tbl_ZEmpAreaManager.Select(detail.AreaManager_ID);
                    if (oAreaManagers != null)
                    {
                        txtAreaManagerID.Tag = oAreaManagers.AreaManager_ID;
                        txtAreaManagerID.Text = clsCommon.GetForeignKeyValue(oAreaManagers.AreaManagerName);

                        tbl_ZEmpSalesManager oSalesManager = tbl_ZEmpSalesManager.Select(oAreaManagers.SalesManager_ID);
                        if (oSalesManager != null)
                        {
                            txtSalesManagerID.Tag = oSalesManager.SalesManager_ID;
                            txtSalesManagerID.Text = clsCommon.GetForeignKeyValue(oSalesManager.SalesManagerName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtCustomerName.TextLength == 0)
            {
                strMessage += "\n" + "Customer Name ";
                bStatus = false;
            }
            if (txtCustomerTypeID.TextLength == 0)
            {
                strMessage += "\n" + "Customer Type ";
                bStatus = false;
            }
            if (txtCustomerClassID.TextLength == 0)
            {
                strMessage += "\n" + "Customer Class ";
                bStatus = false;
            }
            if (txtCategoryID.TextLength == 0)
            {
                strMessage += "\n" + "Customer Category ";
                bStatus = false;
            }
            if (txtBranchName.TextLength == 0)
            {
                strMessage += "\n" + "Branch ";
                bStatus = false;
            }
            if (txtSalesAcctCode.Tag == null)
            {
                txtSalesAcctCode.Tag = "default";
            }
            if (!IsUpdate)
            {
                foreach (tbl_genCustomerMaster detail in tbl_genCustomerMaster.SelectAll())
                {
                    if (txtCustomerName.Text == detail.CustomerName)
                    {
                        strMessage += "\n" + "Please do not Enter an existing Customer's name";
                        bStatus = false;
                    }
                }
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckTaxValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (chkVATEnable.Checked == true && txtVatRegNo.TextLength == 0)
            {
                strMessage += "\n" + "VAT Registration Number ";
                bStatus = false;
            }
            if (chkSVATEnable.Checked == true && txtSVATRegistrationNo.TextLength == 0)
            {
                strMessage += "\n" + "SVAT Registration Number ";
                bStatus = false;
            }


            if (bStatus == false)
            {
                MessageBox.Show(strMessage + " is Required ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtSalesDues.Text.Trim()))
                {
                    strMessage += "\n Balance";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtCreditLimit.Text.Trim()))
                {
                    strMessage += "\n Credit Limit";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtCreditPeriod.Text.Trim()))
                {
                    strMessage += "\n Credit Period";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtCreditPeriod_Commisstion.Text.Trim()))
                {
                    strMessage += "\n Commission Credit Period";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtDepositAmount.Text.Trim()))
                {
                    strMessage += "\n Deposit Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtSalesManagerID);
            clsCommon.ValidateForeignKey(ref txtAreaManagerID);
            clsCommon.ValidateForeignKey(ref txtSalesRepID);
            clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
            clsCommon.ValidateForeignKey(ref txtCurrencyID);
            clsCommon.ValidateForeignKey(ref txtCustomerTypeID);
            clsCommon.ValidateForeignKey(ref txtCategoryID);
            clsCommon.ValidateForeignKey(ref txtCustomerClassID);
            clsCommon.ValidateForeignKey(ref txtAccountType);
            clsCommon.ValidateForeignKey(ref txtSalesReturnGLID);

        }
        #endregion


        #region Get Colour For Customer
        private Color GetColorForCustomer(string sCustomerID)
        {
            Color col = Color.FromArgb(99, 50, 50);
            tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
            tbl_zCustomerCategory detail = tbl_zCustomerCategory.Select(customer.CustomerCategory_ID);
            if (detail != null)
            {
                if (detail.CustomerCategory_ID == "1")
                    col = clsFormatter.colorGeneralCustomer;
                if (detail.CustomerCategory_ID == "2")
                    col = clsFormatter.colorSalesRep;
                if (detail.CustomerCategory_ID == "3")
                    col = clsFormatter.colorCorporateCustomer;
            }
            return col;
        }
        #endregion

        #region Events KeyDown
        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }

        private void txtSupplierTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerTypeID();
        }

        private void txtSupplierClassID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerClassID();
        }

        private void txtCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerCategoryID();
        }


        private void txtSalesManagerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesManagerID();
        }
        private void txtAreaManagerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_AreaManagerID();
        }

        private void txtSalesRepID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRep();
        }

        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesExecutive();
        }

        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }

        private void frmSupplierMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_BranchID();
        }

        private void txtAcctCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                SearchAcctType();
        }

        private void txtAccountType_KeyDown(object sender, KeyEventArgs e)
        {
            Search_AccountTypes_Customer();
        }

        private void txtSalesReturnGLID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesReturnAccount_Name();
        }
        private void txtRouteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtRouteID_DoubleClick(sender, e);
        }
        #endregion

        #region Events DoubleClick
        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtSupplierTypeID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerTypeID();
        }

        private void txtSupplierClassID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerClassID();
        }

        private void txtCategoryID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerCategoryID();
        }

        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }

        private void txtSalesManagerID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesManagerID();
        }
        private void txtAreaManagerID_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaManagerID();
        }

        private void txtSalesRepID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRep();
        }

        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutive();
        }
        private void txtBranchName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_BranchID();
        }

        private void txtAcctCode_DoubleClick(object sender, EventArgs e)
        {
            SearchAcctType();
        }
        private void txtAccountType_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountTypes_Customer();
        }
        private void txtSalesReturnGLID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesReturnAccount_Name();
        }
        private void txtSalesAcctCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtSalesAcctCode, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.SalesAccount));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterRoute(ref txtRouteID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["CustomerCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        FillDetails(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvAddressBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAddressBook_CellClick(sender, e);
        }
        private void dgvAddressBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    FillDetailsAddressBook(e.RowIndex);
                    txtRowNo.Text = e.RowIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  SeachAccountDetail(e.ColumnIndex, e.RowIndex);
        }

        private void dgvBranches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillDetailsBranches(e.RowIndex);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvBranches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBranches_CellClick(sender, e);
        }
        private void dgvDiscount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvDiscount.Columns[e.ColumnIndex].Name;
                if (sColName == "DiscountPresentage")
                {
                    string DiscountPresentage = clsValidate.ValidateGridValue(dgvDiscount, "DiscountPresentage", e.RowIndex, "0.00").Replace(" %", "");
                    decimal dDiscountPresentage = decimal.Parse(DiscountPresentage);

                    dgvDiscount["DiscountPresentage", e.RowIndex].Value = FormatToCurrecyWithThousendSep(dDiscountPresentage);
                    dgvDiscount["DiscountPresentage", e.RowIndex].Tag = dDiscountPresentage;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvDiscount.Columns[e.ColumnIndex].Name;

                    if (sColName == "isActive")
                    {
                        bool bIsActive = (clsValidate.ValidateGridValue(dgvDiscount, "isActive", e.RowIndex, "") == "True") ? true : false;
                        dgvDiscount["isActive", e.RowIndex].Value = bIsActive ? false : true;
                    }
                    else if (sColName == "IsRateLocked")
                    {
                        if (!clsConfig.bIsRateLocked_Multiple_Discount)
                        {
                            bool bIsRateLocked = (clsValidate.ValidateGridValue(dgvDiscount, "IsRateLocked", e.RowIndex, "") == "True") ? true : false;
                            dgvDiscount["IsRateLocked", e.RowIndex].Value = bIsRateLocked ? false : true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            clsSearch.Search_MasterCustomer(ref txtCustomerID, true);
            if (txtCustomerID.Tag != null && txtCustomerID.Text.Length > 0)
            {
                string sCustomerID = txtCustomerID.Tag.ToString();
                FillDetails(sCustomerID);
            }
        }
        private void Search_CustomerTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCustomerTypeID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCustomerTypeID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);
        }
        private void Search_CustomerClassID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCustomerClassID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCustomerClassID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CustomerCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCategoryID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCategoryID.Tag = frmSearchMaster.s_SearchID;
        }



        private void Search_SalesManagerID()
        {
            clsSearch.Search_SalesManager(ref txtSalesManagerID);
        }
        private void Search_AreaManagerID()
        {
            clsSearch.Search_AreaManager(ref txtAreaManagerID);
        }
        private void Search_SalesExecutive()
        {
            clsSearch.Search_SalesExecutive(ref txtSalesExecutiveID);
        }
        private void Search_SalesRep()
        {
            clsSearch.Search_MasterSalesRep(ref txtSalesRepID);
            if (txtSalesRepID.Tag != null && txtSalesRepID.Tag.ToString().Trim().Length > 0 && txtSalesRepID.Tag.ToString().Trim() != "default")
                FillDetailsSalesRep(txtSalesRepID.Tag.ToString().Trim());

        }




        private void Search_BranchID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CompanyBranch();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtBranchName.Tag = frmSearchMaster.s_SearchID;
                    txtBranchName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CompanyBranchMaster(frmSearchMaster.s_SearchID));
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SearchAcctType()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtControlAcctCode, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AccountTypes_Customer()
        {
            try
            {
                clsSearch.Search_MasterAccountTypeCustomer(ref txtAccountType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesReturnAccount_Name()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtSalesReturnGLID, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyUp
        private void txtSupplierID_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshGridSearchByCustomerID(txtCustomerID.Text.Trim());
        }

        private void txtSupplierName_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshGridSearchByCustomerName(txtCustomerName.Text.Trim());
        }
        #endregion

        #region Events KeyLeave
        private void txtSupplierID_Leave(object sender, EventArgs e)
        {
            if (txtCustomerID.TextLength > 0 && txtCustomerID.Text != "<Auto Generate>")
            {
                List<tbl_genCustomerMaster> details = tbl_genCustomerMaster.SelectAll();
                foreach (tbl_genCustomerMaster detail in details)
                {
                    if (detail.CustomerCode == txtCustomerID.Text.Trim())
                    {
                        FillDetails(detail.Customer_ID);
                    }
                }
            }
        }
        #endregion

        #region Event KeyPress
        private void txtLoyaltyAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtLoyaltyAmount.Text, e);
        }

        //Added by Gayan 2016-08-04
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("CustomerName", typeof(string));
        }
        #endregion

        private void cmbPriceMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisablePriceCategory();
        }
        private void EnableDisablePriceCategory()
        {
            if (cmbPriceMode.SelectedIndex != (int)enum_CustomerPrice_Mode.Customer_Wise_PriceCategory)
            {
                cmbItemPrice.Enabled = false;
                cmbItemPrice.SelectedIndex = -1;
            }
            else
                cmbItemPrice.Enabled = true;
        }

        #region Clear Fields Sales Rep
        private void btnClearSalesRep_Click(object sender, EventArgs e)
        {
            ClearSalesRep();
        }

        private void ClearSalesRep()
        {
            txtSalesManagerID.Text = "";
            txtSalesRepID.Text = "";
            txtSalesExecutiveID.Text = "";
            txtAreaManagerID.Text = "";

            txtSalesManagerID.Tag = null;
            txtSalesRepID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtAreaManagerID.Tag = null;
        }
        #endregion

        #region Hide Sales Rep Details
        private void HideSalesRepDetails()
        {
            btnAddSalesRep.Visible = false;
            btnSaveSalesRep.Visible = false;
            dgvSalesRep.Visible = false;
        }

        #endregion

        private void dgvDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (bool.Parse(dgvDetail.Rows[e.RowIndex].Cells[2].Value.ToString()))
            {
                dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
            else
            {
                dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = dgvDetail.DefaultCellStyle;
            }
        }

        private void chkNonTAX_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNonTAX.Checked)
            {
                chkNBTEnable.Checked = false;
                chkVATEnable.Checked = false;
                chkSVATEnable.Checked = false;
            }
        }

        private void chkNBTEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBTEnable.Checked)
                chkNonTAX.Checked = false;
            else
                chkNonTAX.Checked = true;
        }

        private void chkVATEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVATEnable.Checked)
                chkNonTAX.Checked = false;
            else
                chkNonTAX.Checked = true;
        }

        private void chkSVATEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSVATEnable.Checked)
                chkNonTAX.Checked = false;
            else
                chkNonTAX.Checked = true;
        }
    }
}