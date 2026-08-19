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

namespace Digiteq
{
    public partial class frmSupplierMaster : SEACC_Form
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;
        string s_FileName;

        //For Permision
        public bool bNoAccess = false;

        private BindingSource source = new BindingSource();
        private string sFilteQuary = "";
        public DataTable dtAllRecodes = new DataTable();

        //to keep form detail       
        //string sFormConfigCode;
        //public int iFormID;
        #endregion

        #region Form Load
        public frmSupplierMaster(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            //iFormID = clsSecurity.getFormID(FormName.SupplierMaster);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
        }
        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, false, false, true, true, false, false, false, false);

            //if (! bNoAccess)
            //{
            //    sFormConfigCode = clsAutocode.getFormConfigCode(FormName.SupplierMaster);

            //add data to the datagrid and format                          
            CusDataGridViewFormat();

            ClearFields();
            dgvDetail.DataSource = source;
            RefreshGrid();
            //}
            //else
            //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + this.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Btn New
        private void frmSupplierMaster_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frmSupplierMaster_SF_cancelButton_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
            {
                try
                {
                    if (txtSupplierID.TextLength > 0)
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;

                        tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(txtSupplierID.Text.Trim());

                        tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(detail.Store_ID);
                        if ((oStore != null) && (oStore.Store_ID != "default"))
                        {
                            oStore.IsDeleted = true;
                            oStore.Update();
                        }

                        detail.Delete();
                        clsHelpMethods.InsertTransactionHistory(iFormID, txtSupplierID.Text, TxnActivity.Cancel);

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    SEACCException.Show(ex);
                }
            }

        }
        #endregion

        #region Btn Save
        private void frmSupplierMaster_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
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
                            if (txtSupplierID.TextLength > 0)
                            {
                                #region Update
                                if (IsUpdate)  //update records
                                {
                                    tbl_genSupplierMaster oldRecord = tbl_genSupplierMaster.Select(txtSupplierID.Text.Trim());
                                    if (oldRecord != null)
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.SupplierMaster), oldRecord.Supplier_ID, "Supplier Master - Update ");

                                        if (s_FileName.Length > 0)
                                        {
                                            FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                            img = new Byte[fs.Length];
                                            fs.Read(img, 0, (int)fs.Length);
                                            fs.Close();
                                        }
                                        else if (oldRecord.Image != null && oldRecord.Image.Length > 0)
                                        {
                                            img = oldRecord.Image;
                                        }

                                        //Supplier Account
                                        //tbl_genSupplierAccount.DeleteAllBySupplier_ID(txtSupplierID.Text.Trim());
                                        //for (int x = 0; x < dgvAccounts.Rows.Count; x++)
                                        //{
                                        //    try
                                        //    {
                                        //        string BankID = dgvAccounts["BankName", x].Tag.ToString(), BranchID = dgvAccounts["BranchName", x].Tag.ToString(),
                                        //            AccountNo = dgvAccounts["AccountNo", x].Value.ToString();
                                        //        decimal AccountBalance = decimal.Parse(dgvAccounts["AccBalance", x].Value.ToString());
                                        //        tbl_genSupplierAccount account = new tbl_genSupplierAccount(txtSupplierID.Text.Trim(), AccountNo, BankID, BranchID, AccountBalance);
                                        //        account.Insert();
                                        //    }
                                        //    catch (Exception) { }//error may come because last row of the grid may not have information
                                        //}

                                        //Sub Contractor Store
                                        string sSubContractor_StoreID = oldRecord.Store_ID;
                                        if (chkSubContractor.Checked)
                                        {
                                            Save_SubContractorStore(ref sSubContractor_StoreID);
                                        }
                                        else
                                        {
                                            tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(sSubContractor_StoreID);
                                            if ((oStore != null) && (oStore.Store_ID != "default"))
                                            {
                                                oStore.IsDeleted = true;
                                                oStore.Update();
                                            }
                                        }

                                        //Supplier Master
                                        tbl_genSupplierMaster detail = new tbl_genSupplierMaster(txtSupplierID.Text.Trim(), txtSupplierName.Text.Trim(),
                                            txtAddressRegister.Text.Trim(), txtAddressDeliver.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(),
                                            txtEmail.Text.Trim(), txtUrl.Text.Trim(), txtBussinessRegNo.Text.Trim(), txtVatRegNo.Text.Trim(), txtNBTRegistrationNo.Text.Trim(),
                                            txtSVATRegistrationNo.Text.Trim(), txtPayee.Text, txtRemark.Text.Trim(), decimal.Parse(txtCreditLimit.Text.Trim()), decimal.Parse(txtCreditPeriod.Text.Trim()), oldRecord.OutstandingAmount, oldRecord.OutstandingBalance,
                                            decimal.Parse(txtBalance.Text.Trim()), chkBlacklisted.Checked, chkLocked.Checked, chkDeleted.Checked, txtCountryID.Tag.ToString(),
                                            txtProvinceID.Tag.ToString(), txtDistrictID.Tag.ToString(), txtCityID.Tag.ToString(), txtTownID.Tag.ToString(),
                                            txtAreaID.Tag.ToString(), txtRootID.Tag.ToString(), txtSupplierTypeID.Tag.ToString(), txtCategoryID.Tag.ToString(),
                                            txtSupplierClassID.Tag.ToString(), txtCurrencyID.Tag.ToString(), "default", img, decimal.Parse(txtDepositAmount.Text.Trim()),
                                            chkVATEnable.Checked, chkSVATEnable.Checked, chkNBTEnable.Checked, txtAccountType.Tag.ToString(), oldRecord.CompanyID, oldRecord.CompanyBranch_ID, oldRecord.IsOtherCreditor, chkSubContractor.Checked, sSubContractor_StoreID);
                                        detail.Update();

                                        //delete and update account code
                                        if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0 && txtAcctCode.Tag.ToString().Trim() != "default")
                                        {
                                            tbl_accGLMaster_Supplier.DeleteAllBySupplier_ID(txtSupplierID.Text.Trim());
                                            tbl_accGLMaster_Supplier oAcc = new tbl_accGLMaster_Supplier(txtAcctCode.Tag.ToString(), txtSupplierID.Text.Trim(), true);
                                            oAcc.Insert();
                                        }
                                        clsHelpMethods.InsertTransactionHistory(iFormID, txtSupplierID.Text, TxnActivity.Update);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                #endregion

                                #region Insert
                                else
                                {
                                    #region Genarate Serial no
                                    if (clsConfig.bBranchMaster_SerialNoActiveFor_SupplierMaster)
                                        txtSupplierID.Text = clsAutocode.getAutoGeneratedCode_FromCompanyBranch_SupplierMaster(clsSecurity.BranchID);
                                    else if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                        txtSupplierID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                                    #endregion

                                    //Write Audit Trial Log
                                    clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.SupplierMaster), txtSupplierID.Text.Trim(), "Supplier Master - Insert ");

                                    if (s_FileName.Length > 0)
                                    {
                                        FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                        img = new Byte[fs.Length];
                                        fs.Read(img, 0, (int)fs.Length);
                                        fs.Close();
                                    }

                                    //Sub Contractor Store
                                    string sSubContractor_StoreID = "default";
                                    if (chkSubContractor.Checked)
                                    {
                                        Save_SubContractorStore(ref sSubContractor_StoreID);
                                    }

                                    //Supplier Master
                                    tbl_genSupplierMaster detail = new tbl_genSupplierMaster(txtSupplierID.Text.Trim(), txtSupplierName.Text.Trim(),
                                             txtAddressRegister.Text.Trim(), txtAddressDeliver.Text.Trim(), txtTelephone.Text.Trim(), txtFax.Text.Trim(),
                                             txtEmail.Text.Trim(), txtUrl.Text.Trim(), txtBussinessRegNo.Text.Trim(), txtVatRegNo.Text.Trim(), txtNBTRegistrationNo.Text.Trim(),
                                             txtSVATRegistrationNo.Text.Trim(), txtPayee.Text, txtRemark.Text.Trim(), decimal.Parse(txtCreditLimit.Text.Trim()), decimal.Parse(txtCreditPeriod.Text.Trim()), 0, 0,
                                             decimal.Parse(txtBalance.Text.Trim()), chkBlacklisted.Checked, chkLocked.Checked, chkDeleted.Checked, txtCountryID.Tag.ToString(),
                                             txtProvinceID.Tag.ToString(), txtDistrictID.Tag.ToString(), txtCityID.Tag.ToString(), txtTownID.Tag.ToString(),
                                             txtAreaID.Tag.ToString(), txtRootID.Tag.ToString(), txtSupplierTypeID.Tag.ToString(), txtCategoryID.Tag.ToString(),
                                             txtSupplierClassID.Tag.ToString(), txtCurrencyID.Tag.ToString(), "default", img, decimal.Parse(txtDepositAmount.Text.Trim()),
                                             chkVATEnable.Checked, chkSVATEnable.Checked, chkNBTEnable.Checked, txtAccountType.Tag.ToString(), clsSecurity.CompanyID, clsSecurity.BranchID, false, chkSubContractor.Checked, sSubContractor_StoreID);
                                    detail.Insert();
                                    //Supplier Account                                
                                    //for (int x = 0; x > dgvAccounts.Rows.Count; x++)
                                    //{
                                    //    try
                                    //    {
                                    //        string BankID = dgvAccounts["BankName", x].Tag.ToString(), BranchID = dgvAccounts["BranchName", x].Tag.ToString(),
                                    //            AccountNo = dgvAccounts["AccountNo", x].Value.ToString();
                                    //        decimal AccountBalance = decimal.Parse(dgvAccounts["AccBalance", x].Value.ToString());
                                    //        tbl_genSupplierAccount account = new tbl_genSupplierAccount(txtSupplierID.Text.Trim(), AccountNo, BankID, BranchID, AccountBalance);
                                    //        account.Insert();
                                    //    }
                                    //    catch (Exception) { }//error may come because last row of the grid may not have information
                                    //}

                                    //delete and update account code
                                    if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0 && txtAcctCode.Tag.ToString().Trim() != "default")
                                    {
                                        tbl_accGLMaster_Supplier.DeleteAllBySupplier_ID(txtSupplierID.Text.Trim());
                                        tbl_accGLMaster_Supplier oAcc = new tbl_accGLMaster_Supplier(txtAcctCode.Tag.ToString(), txtSupplierID.Text.Trim(), true);
                                        oAcc.Insert();
                                    }
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtSupplierID.Text, TxnActivity.Insert);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                #endregion
                            }
                            else
                            {
                                MessageBox.Show("Supplier " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            RefreshGrid();
                            ClearFields();
                        }
                    }
                }
            }
        }
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

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvDetail, clsFormatter.colorGrid, UI_Color);
            //    clsFormatter.ApplyGridFormat_New(dgvAccounts, clsFormatter.colorGrid, UI_Color);
            //clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMaster);
            //clsFormatter.ApplyGridFormatModify(dgvAccounts, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMaster, clsFormatter.colorDigiteqTheamColorMasterBackColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            txtSupplierID.Enabled = true;

            //txtSupplierID.Tag = null;
            txtCategoryID.Tag = null;
            txtCurrencyID.Tag = null;
            txtSupplierClassID.Tag = null;
            txtSupplierTypeID.Tag = null;
            txtAreaID.Tag = null;
            txtCityID.Tag = null;
            txtCountryID.Tag = null;
            txtDistrictID.Tag = null;
            txtProvinceID.Tag = null;
            txtRootID.Tag = null;
            txtAcctCode.Tag = null;
            txtAccountType.Tag = null;


            txtAddressDeliver.Clear();
            txtAddressRegister.Clear();
            txtAreaID.Clear();
            txtBalance.Text = "0";
            txtBussinessRegNo.Clear();
            txtCategoryID.Clear();
            txtCityID.Clear();
            txtCountryID.Clear();
            txtCreditLimit.Text = "0";
            txtCreditPeriod.Text = "0";
            txtDepositAmount.Text = "0";
            txtCurrencyID.Clear();
            txtDebtorCode.Clear();
            txtDistrictID.Clear();
            txtFax.Clear();
            txtProvinceID.Clear();
            txtRemark.Clear();
            txtPayee.Clear();
            txtRootID.Clear();
            txtSupplierClassID.Clear();
            txtSupplierName.Clear();
            txtSupplierTypeID.Clear();
            txtTelephone.Clear();
            txtSVATRegistrationNo.Clear();
            txtTownID.Clear();
            txtUrl.Clear();
            txtVatRegNo.Clear();
            txtNBTRegistrationNo.Clear();
            txtEmail.Clear();
            txtAcctCode.Clear();
            txtAccountType.Clear();

            chkSubContractor.Checked = false;
            chkBlacklisted.Checked = false;
            chkDeleted.Checked = false;
            chkLocked.Checked = false;

            chkNBTEnable.Checked = false;
            chkVATEnable.Checked = false;
            chkSVATEnable.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtSupplierID.Text = "<Auto Generate>";
            else
                txtSupplierID.Clear();

            source.Filter = "";
            RefreshGrid();
            pbxImage.Image = null;
            //   dgvAccounts.Rows.Clear();
            //  dgvAccounts.Rows.Add();
            s_FileName = "";
            txtColourCorporateSupplier.ForeColor = clsFormatter.colorCorporateSupplier;
            txtColourGeneralSupplier.ForeColor = clsFormatter.colorGeneralSupplier;
            txtColourSalesRep.ForeColor = clsFormatter.colorSalesRep;

            if (txtSupplierID.Enabled)
            {
                txtSupplierID.SelectAll();
                txtSupplierID.Focus();

            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            //int iRow;
            //dgvDetail.Rows.Clear();

            //List<vw_searchGenSupplierMaster> details = vw_searchGenSupplierMaster.SelectAll();
            //foreach (vw_searchGenSupplierMaster detail in details)
            //{
            //    dgvDetail.Rows.Add();
            //    iRow = dgvDetail.Rows.Count - 1;
            //    dgvDetail["SupplierCode", iRow].Value = detail.Supplier_ID;
            //    dgvDetail["SupplierName", iRow].Value = detail.SupplierName;
            //    dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = GetColorForSupplier(detail.Supplier_ID);
            //}
            //List<tbl_genSupplierMaster> details = tbl_genSupplierMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => p.Supplier_ID != "default").ToList();
            //foreach (tbl_genSupplierMaster detail in details)
            //{
            //    dgvDetail.Rows.Add();
            //    iRow = dgvDetail.Rows.Count - 1;
            //    dgvDetail["SupplierCode", iRow].Value = detail.Supplier_ID;
            //    dgvDetail["SupplierName", iRow].Value = detail.SupplierName;
            //    dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = GetColorForSupplier(detail.Supplier_ID);
            //}

            try
            {
                dtAllRecodes.Clear();
                dtAllRecodes.Merge(DBHandling.ExecQuery("exec tbl_genSupplierMasterBy_BranchID '" + clsSecurity.BranchID + "'").Tables[0]);
                source.DataSource = dtAllRecodes;

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("SupplierCode", typeof(string));
            dtAllRecodes.Columns.Add("SupplierName", typeof(string));
        }
        private void RefreshGrid_Account()
        {
            int iRow;
            //dgvAccounts.Rows.Clear();

            //List<tbl_genSupplierAccount> details = tbl_genSupplierAccount.SelectAllBySupplier_ID(txtSupplierID.Text.Trim());
            //foreach (tbl_genSupplierAccount detail in details)
            //{
            //    dgvAccounts.Rows.Add();
            //    iRow = dgvAccounts.Rows.Count - 1;
            //    dgvAccounts["BankName", iRow].Value = clsGenaralName.getName_Bank(detail.Bank_ID);
            //    dgvAccounts["BankName", iRow].Tag = detail.Bank_ID;
            //    dgvAccounts["BranchName", iRow].Value = clsGenaralName.getName_BankBranch(detail.Branch_ID);
            //    dgvAccounts["BranchName", iRow].Tag = detail.Branch_ID;
            //    dgvAccounts["AccountNo", iRow].Value = detail.AccountNumber;
            //    dgvAccounts["AccBalance", iRow].Value = detail.BalanceAmount.ToString();
            //}
            //dgvAccounts.Rows.Add();
        }
        private void RefreshGridSearchBySupplierID(string sSupplierID)
        {
            #region old
            //int iRow;
            //dgvDetail.Rows.Clear();

            //List<vw_searchGenSupplierMaster> details = vw_searchGenSupplierMaster.SearchAllBySupplierID(sSupplierID);
            //foreach (vw_searchGenSupplierMaster detail in details)
            //{
            //    dgvDetail.Rows.Add();
            //    iRow = dgvDetail.Rows.Count - 1;
            //    dgvDetail["SupplierCode", iRow].Value = detail.Supplier_ID;
            //    dgvDetail["SupplierName", iRow].Value = detail.SupplierName;
            //    dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = GetColorForSupplier(detail.Supplier_ID);
            //} 
            #endregion

            string value = txtSupplierID.Text.Trim();
            string sCheckedValue = clsHelpMethods.CheckValue(value);
            source.Filter = " SupplierCode LIKE '%" + sCheckedValue + "%'";
        }
        private void RefreshGridSearchBySupplierName(string sSupplierName)
        {
            #region old
            //int iRow;
            //dgvDetail.Rows.Clear();
            //List<vw_searchGenSupplierMaster> details = vw_searchGenSupplierMaster.SearchAllBySupplierName(sSupplierName);
            //foreach (vw_searchGenSupplierMaster detail in details)

            //{
            //    dgvDetail.Rows.Add();
            //    iRow = dgvDetail.Rows.Count - 1;
            //    dgvDetail["SupplierCode", iRow].Value = detail.Supplier_ID;
            //    dgvDetail["SupplierName", iRow].Value = detail.SupplierName;
            //    dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = GetColorForSupplier(detail.Supplier_ID);
            //} 
            #endregion

            string value = txtSupplierName.Text.Trim();
            string sCheckedValue = clsHelpMethods.CheckValue(value);
            source.Filter = " SupplierName LIKE '%" + sCheckedValue + "%'";
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    txtSupplierID.Enabled = false;

                    //asign values                    
                    txtCategoryID.Tag = detail.SupplierCategory_ID;
                    txtCurrencyID.Tag = detail.Currency_ID;
                    txtSupplierClassID.Tag = detail.SupplierClass_ID;
                    txtSupplierTypeID.Tag = detail.SupplierType_ID;
                    txtAreaID.Tag = detail.Area_ID;
                    txtCityID.Tag = detail.City_ID;
                    txtCountryID.Tag = detail.Country_ID;
                    txtProvinceID.Tag = detail.Province_ID;
                    txtRootID.Tag = detail.Route_ID;
                    txtTownID.Tag = detail.Town_ID;
                    txtDistrictID.Tag = detail.District_ID;
                    txtAccountType.Tag = detail.SupplierAccountType_ID;

                    txtSupplierID.Text = detail.Supplier_ID;
                    txtAreaID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Area(detail.Area_ID));
                    txtCategoryID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SupplierCategory(detail.SupplierCategory_ID));
                    txtCityID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_City(detail.City_ID));
                    txtCountryID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Country(detail.Country_ID));
                    txtCurrencyID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Currency(detail.Currency_ID));
                    txtProvinceID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Province(detail.Province_ID));
                    txtRootID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Route(detail.Route_ID));
                    txtSupplierClassID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SupplierClass(detail.SupplierClass_ID));
                    txtSupplierTypeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SupplierType(detail.SupplierType_ID));
                    txtTownID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(detail.Town_ID));
                    txtDistrictID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_District(detail.District_ID));
                    // txtAccountType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccountType_Supplier(detail.SupplierAccountType_ID));
                    txtAddressDeliver.Text = detail.AddressDelivery;
                    txtAddressRegister.Text = detail.AddressRegister;
                    txtBalance.Text = detail.OutstandingBalance.ToString();
                    txtBussinessRegNo.Text = detail.BusinessRegistraionNo;
                    txtCreditLimit.Text = detail.CreditLimit.ToString();
                    txtCreditPeriod.Text = detail.CreditPeriod.ToString();
                    txtFax.Text = detail.Fax;
                    txtRemark.Text = detail.Remark;
                    txtSupplierName.Text = detail.SupplierName;
                    txtPayee.Text = detail.Payee;
                    txtTelephone.Text = detail.Telephone;
                    txtUrl.Text = detail.Url;
                    txtNBTRegistrationNo.Text = detail.NbtRegistrationNo;
                    txtVatRegNo.Text = detail.VatRegistrationNo;
                    txtSVATRegistrationNo.Text = detail.SvatRegistrationNo;
                    txtEmail.Text = detail.Email;
                    txtDepositAmount.Text = detail.DepositAmount.ToString();

                    chkSubContractor.Checked = detail.IsSubContractor;
                    chkBlacklisted.Checked = detail.IsBlacklisted;
                    chkDeleted.Checked = detail.IsDeleted;
                    chkLocked.Checked = detail.IsLocked;

                    chkNBTEnable.Checked = detail.IsNBTenable;
                    chkVATEnable.Checked = detail.IsVATenable;
                    chkSVATEnable.Checked = detail.IsSVATenable;

                    txtAcctCode.Tag = null;
                    txtAcctCode.Clear();
                    List<tbl_accGLMaster_Supplier> oAccs = tbl_accGLMaster_Supplier.SelectAllBySupplier_ID(detail.Supplier_ID);
                    if (oAccs.Count > 1)
                        MessageBox.Show("There are more than 1 GL codes are taged with this supplier, Please contact the accountant", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        foreach (tbl_accGLMaster_Supplier oAcc in tbl_accGLMaster_Supplier.SelectAllBySupplier_ID(detail.Supplier_ID))
                        {
                            txtAcctCode.Tag = oAcc.Gl_ID;
                            txtAcctCode.Text = clsGenaralName.getName_AccountName(oAcc.Gl_ID);
                            break;
                        }
                    }

                    //Image                    
                    if (detail.Image != null)
                    {
                        if (detail.Image.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(detail.Image);
                            pbxImage.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pbxImage.Image = pbxImage.InitialImage;
                        }
                    }
                    else
                    {
                        pbxImage.Image = pbxImage.InitialImage;
                    }

                    //fill stock details
                    //    RefreshGrid_Account();
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtSupplierName.TextLength == 0)
            {
                strMessage += "\n" + "Supplier Name ";
                bStatus = false;
            }
            if (txtSupplierTypeID.TextLength == 0)
            {
                strMessage += "\n" + "Supplier Type ";
                bStatus = false;
            }
            if (txtSupplierClassID.TextLength == 0)
            {
                strMessage += "\n" + "Supplier Class ";
                bStatus = false;
            }
            if (txtCategoryID.TextLength == 0)
            {
                strMessage += "\n" + "Supplier Category ";
                bStatus = false;
            }

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtBalance.Text.Trim()))
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
                if (!clsCommon.isCurrency(txtDepositAmount.Text.Trim()))
                {
                    strMessage += "\n Deposit Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
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
            clsCommon.ValidateForeignKey(ref txtCountryID);
            clsCommon.ValidateForeignKey(ref txtProvinceID);
            clsCommon.ValidateForeignKey(ref txtDistrictID);
            clsCommon.ValidateForeignKey(ref txtCityID);
            clsCommon.ValidateForeignKey(ref txtTownID);
            clsCommon.ValidateForeignKey(ref txtAreaID);
            clsCommon.ValidateForeignKey(ref txtRootID);
            clsCommon.ValidateForeignKey(ref txtCurrencyID);
            clsCommon.ValidateForeignKey(ref txtSupplierTypeID);
            clsCommon.ValidateForeignKey(ref txtCategoryID);
            clsCommon.ValidateForeignKey(ref txtSupplierClassID);
            clsCommon.ValidateForeignKey(ref txtAccountType);
        }
        #endregion



        #region Get Colour For Supplier
        private Color GetColorForSupplier(string sSupplierID)
        {
            Color col = Color.FromArgb(99, 50, 50);
            tbl_genSupplierMaster supplier = tbl_genSupplierMaster.Select(sSupplierID);
            tbl_zSupplierCategory detail = tbl_zSupplierCategory.Select(supplier.SupplierCategory_ID);
            if (detail != null)
            {
                if (detail.SupplierCategory_ID == "1")
                    col = clsFormatter.colorGeneralSupplier;
                if (detail.SupplierCategory_ID == "2")
                    col = clsFormatter.colorSalesRep;
                if (detail.SupplierCategory_ID == "3")
                    col = clsFormatter.colorCorporateSupplier;
            }
            return col;
        }
        #endregion

        #region Events KeyDown
        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SupplierID();
            }
        }

        private void txtSupplierTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SupplierTypeID();
            }
        }

        private void txtSupplierClassID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SupplierClassID();
            }
        }

        private void txtCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SupplierCategoryID();
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AreaID();
            }
        }

        private void txtRoot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_RouteID();
            }
        }

        private void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CountryID();
            }
        }

        private void txtProvince_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ProvinceID();
            }
        }

        private void txtDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DistrictID();
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CityID();
            }
        }

        private void txtTown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_TownID();
            }
        }

        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CurrencyID();
            }
        }
        private void txtAcctCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                SearchAcctType();
        }
        private void txtAccountType_KeyDown(object sender, KeyEventArgs e)
        {
            Search_AccountTypes_Supplier();
        }
        private void frmSupplierMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierID();
        }

        private void txtSupplierTypeID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierTypeID();
        }

        private void txtSupplierClassID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierClassID();
        }

        private void txtCategoryID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierCategoryID();
        }

        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_CurrencyID();
        }

        private void txtArea_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaID();
        }

        private void txtRoot_DoubleClick(object sender, EventArgs e)
        {
            Search_RouteID();
        }

        private void txtCountry_DoubleClick(object sender, EventArgs e)
        {
            Search_CountryID();
        }

        private void txtProvince_DoubleClick(object sender, EventArgs e)
        {
            Search_ProvinceID();
        }

        private void txtDistrict_DoubleClick(object sender, EventArgs e)
        {
            Search_DistrictID();
        }

        private void txtCity_DoubleClick(object sender, EventArgs e)
        {
            Search_CityID();
        }

        private void txtTown_DoubleClick(object sender, EventArgs e)
        {
            Search_TownID();
        }
        private void txtAcctCode_DoubleClick(object sender, EventArgs e)
        {
            SearchAcctType();
        }
        private void txtAccountType_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountTypes_Supplier();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["SupplierCode", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeachAccountDetail(e.ColumnIndex, e.RowIndex);
        }

        //private void dgvAccounts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    dgvAccounts["AccBalance", e.RowIndex].Value = 0;
        //}

        //private void dgvAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    bool bIsCorrect = false;
        //    try
        //    {
        //        string BankID = dgvAccounts["BankName", e.RowIndex].Tag.ToString(),
        //            BranchID = dgvAccounts["BranchName", e.RowIndex].Tag.ToString(),
        //            AccountNo = dgvAccounts["AccountNo", e.RowIndex].Value.ToString();
        //        if (BankID.Length > 0 && BranchID.Length > 0 && AccountNo.Length > 0)
        //            bIsCorrect = true;
        //    }
        //    catch (Exception)
        //    {
        //        bIsCorrect = false;
        //    }
        //    if (bIsCorrect)
        //        dgvAccounts.Rows.Add();
        //}

        private void dgvAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            //have to develop later
        }

        private void SeachAccountDetail(int ColumnIndex, int RowIndex)
        {
            if (ColumnIndex == 0)
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Bank();
                frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchText.Length > 0)
                //    dgvAccounts["BankName", RowIndex].Value = frmSearchMaster.s_SearchText;
                //if (frmSearchMaster.s_SearchID.Length > 0)
                //    dgvAccounts["BankName", RowIndex].Tag = frmSearchMaster.s_SearchID;
            }
            if (ColumnIndex == 1)
            {
                string sBankID = "";
                try
                {
                    // sBankID = dgvAccounts["BankName", RowIndex].Tag.ToString();
                }
                catch (Exception) { }
                if (sBankID.Length <= 0)
                    MessageBox.Show("Please Select the Bank Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    Form frmhelpsearch = new frmSearchMaster();
                    clsSearch.passValue_BankBranchesByBankID(sBankID);
                    frmhelpsearch.ShowDialog();

                    //if (frmSearchMaster.s_SearchText.Length > 0)
                    //    dgvAccounts["BranchName", RowIndex].Value = frmSearchMaster.s_SearchText;
                    //if (frmSearchMaster.s_SearchID.Length > 0)
                    //    dgvAccounts["BranchName", RowIndex].Tag = frmSearchMaster.s_SearchID;
                }
            }
            if (ColumnIndex == 2)
            {
                string sBranchID = "";
                try
                {
                    //   sBranchID = dgvAccounts["BranchName", RowIndex].Tag.ToString();
                }
                catch (Exception) { }
                if (sBranchID.Length <= 0)
                    MessageBox.Show("Please Select the Branch Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Search Methods
        private void Search_SupplierID()
        {
            Form frmhelpsearch = new frmSearchTransaction();
            clsSearch.passValue_Supplier_ByCompanyBranchID(clsSecurity.BranchID);
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
            {
                txtSupplierID.Text = frmSearchTransaction.s_SearchID;
                FillDetails(frmSearchTransaction.s_SearchID);
            }
        }
        private void Search_SupplierTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupplierTypeID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupplierTypeID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_SupplierClassID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupplierClassID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupplierClassID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_SupplierCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCategoryID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCategoryID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_AreaID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Area();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtAreaID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtAreaID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_RouteID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Route();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtRootID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtRootID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CountryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CountryID();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCountryID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCountryID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_ProvinceID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            if (txtCountryID.Tag != null && txtCountryID.Tag.ToString().Length > 0)
                clsSearch.passValue_ProvinceByCountryID(txtCountryID.Tag.ToString());
            else
                clsSearch.passValue_Province();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtProvinceID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtProvinceID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_DistrictID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            if (txtProvinceID.Tag != null && txtProvinceID.Tag.ToString().Length > 0)
                clsSearch.passValue_DistrictByProvinceID(txtProvinceID.Tag.ToString());
            else
                clsSearch.passValue_District();

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtDistrictID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtDistrictID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CityID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            if (txtDistrictID.Tag != null && txtDistrictID.Tag.ToString().Length > 0)
                clsSearch.passValue_CityByDistrictID(txtDistrictID.Tag.ToString());
            else
                clsSearch.passValue_City();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCityID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCityID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_TownID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Town();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtTownID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtTownID.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CurrencyID()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);

            //Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Currency();
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchText.Length > 0)
            //    txtCurrencyID.Text = frmSearchMaster.s_SearchText;
            //if (frmSearchMaster.s_SearchID.Length > 0)
            //    txtCurrencyID.Tag = frmSearchMaster.s_SearchID;
        }
        private void SearchAcctType()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor));

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AccountTypes_Supplier()
        {
            try
            {
                clsSearch.Search_TransactionAccountTypeSupplier(ref txtAccountType);
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
            RefreshGridSearchBySupplierID(txtSupplierID.Text.Trim());
        }

        private void txtSupplierName_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshGridSearchBySupplierName(txtSupplierName.Text.Trim());
        }
        #endregion

        #region Events KeyLeave
        private void txtSupplierID_Leave(object sender, EventArgs e)
        {
            if (txtSupplierID.TextLength > 0 && txtSupplierID.Text != "<Auto Generate>")
            {
                tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(txtSupplierID.Text.Trim());
                if (detail != null)
                {
                    FillDetails(txtSupplierID.Text.Trim());
                }
            }
        }
        #endregion

        #region VAT check change events
        private void chkVATEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVATEnable.Checked)
                chkSVATEnable.Checked = false;
        }

        private void chkSVATEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSVATEnable.Checked)
                chkVATEnable.Checked = false;
        }
        #endregion

        private void dgvAccounts_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 2)
            //{
            //    try
            //    {
            //        MessageBox.Show("awa");
            //        dgvAccounts.Rows.Add();
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
        }

        private void Save_SubContractorStore(ref string sStore_ID)
        {
            #region old
            //tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(sStore_ID);
            //if (oStore != null && oStore.Store_ID != null)
            //{
            //    tbl_genStoreMaster oSubContractor_Store = new tbl_genStoreMaster(0, txtSupplierID.Text, txtSupplierName.Text, txtAddressRegister.Text, txtTelephone.Text, txtFax.Text, txtSupplierName.Text, false, false, false, false, false, false, false, false, clsSecurity.CompanyID, clsSecurity.BranchID, false, true);
            //    oSubContractor_Store.Insert();
            //    sStore_ID = oSubContractor_Store.Store_ID;
            //}
            //else
            //{
            //    oStore.IsDeleted = false;
            //    oStore.Update();
            //} 
            #endregion

            tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(sStore_ID);
            if (oStore != null && oStore.Store_ID != null && sStore_ID != "default")
            {
                oStore.IsDeleted = false;
                oStore.Update();
            }
            else
            {
                tbl_genStoreMaster oSubContractor_Store = new tbl_genStoreMaster(0, txtSupplierID.Text, txtSupplierName.Text, txtAddressRegister.Text, txtTelephone.Text, txtFax.Text, txtSupplierName.Text, false, false, false, false, false, false, false, false, clsSecurity.CompanyID, clsSecurity.BranchID, false, true);
                oSubContractor_Store.Insert();
                sStore_ID = oSubContractor_Store.Store_ID;
            }
        }
    }
}
