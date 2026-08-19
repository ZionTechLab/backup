using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Threading;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_bpsChequeManagement : MettroForm
    {
        
        //to manage update and insert
        static bool IsUpdateDeposit = false;
        static bool IsUpdateReDeposit = false;
        static bool IsUpdateReIssue = false;
        static bool IsUpdateInwardReConsiliation = false;
        static bool IsUpdateOutwardReConsiliation = false;
        static bool IsUpdateBEReConsiliation = false;
        static bool IsUpdateCashDeposite = false;
        public int iFormID;
        //form manage
        string sFormConfigCodeDeposit;
        string sFormConfigCodeReDeposit;
        string sFormConfigCodeCashDeposite;
        string sFormConfigCodeReIssue;
        string sFormConfigCodeInwardReConsiliation;
        string sFormConfigCodeOutwardReConsiliation;
        string sFormConfigCodeBEReConsiliation;
        string sFormConfigReturnedCheque;
        string sFormConfigBatchCode;
        int iReDepositFormID, iChequeDeposite, iReissue, iCashDeposite, iInwardReconsilation, iOutwardReconsilation, iBEReconsilation;


        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        public bool bNoAccessChequeDeposite;
        public bool bNoAccessReissue;
        public bool bNoAccessCashDeposite;
        public bool bNoAccessInwardReconsilation;
        public bool bNoAccessOutwardReconsilation;
        public bool bNoAccessBEReconsilation;
        public bool bNoAccessReDepositFormID;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        private string sFilteQuary = "";

        public DataTable dtReDeposit = new DataTable();
        private BindingSource sourceReDeposit = new BindingSource();

        public DataTable dtChequeDeposit = new DataTable();
        private BindingSource sourceChequeDeposit = new BindingSource();

        public DataTable dtReIssue = new DataTable();
        private BindingSource sourceReIssue = new BindingSource();

        public DataTable dtInwardReconsiliation = new DataTable();
        private BindingSource sourceInwardReconsiliation = new BindingSource();

        public DataTable dtOutwardReconsiliation = new DataTable();
        private BindingSource sourceOutwardReconsiliation = new BindingSource();

        public DataTable dtBEReconsiliation = new DataTable();
        private BindingSource sourceBEReconsiliation = new BindingSource();

        public DataTable dtCashDeposite = new DataTable();
        private BindingSource sourceCashDeposite = new BindingSource();

 

        #region Form Load
        public frm_bpsChequeManagement()
        {
            sFormConfigCodeDeposit = clsAutocode.getFormConfigCode(FormName.ChequeDeposit);
            sFormConfigCodeReDeposit = clsAutocode.getFormConfigCode(FormName.ChequeReDeposit);
            sFormConfigCodeReIssue = clsAutocode.getFormConfigCode(FormName.ChequeReIssue);
            sFormConfigCodeInwardReConsiliation = clsAutocode.getFormConfigCode(FormName.ChequeReconsiliation);
            sFormConfigCodeOutwardReConsiliation = clsAutocode.getFormConfigCode(FormName.ChequeReconsiliation);
            sFormConfigCodeBEReConsiliation = clsAutocode.getFormConfigCode(FormName.ChequeReconsiliation);
            sFormConfigReturnedCheque = clsAutocode.getFormConfigCode(FormName.RetruendChequeDebitInvoice);
            sFormConfigCodeCashDeposite = clsAutocode.getFormConfigCode(FormName.CashDepositeCode);

            iFormID = clsSecurity.getFormID(FormName.ChequeManage);
            iChequeDeposite = clsSecurity.getFormID(FormName.ChequeDeposit);
            iReDepositFormID = clsSecurity.getFormID(FormName.ChequeReDeposit);
            iReissue = clsSecurity.getFormID(FormName.ChequeReIssue);
            iInwardReconsilation = clsSecurity.getFormID(FormName.ChequeReconsiliation);
            iOutwardReconsilation = clsSecurity.getFormID(FormName.ChequeReconsiliation); //-K-
            iBEReconsilation = clsSecurity.getFormID(FormName.ChequeReconsiliation);
            iCashDeposite = clsSecurity.getFormID(FormName.CashDepositeCode);

            sFormConfigBatchCode = clsAutocode.getFormConfigCode(FormName.accBatchPosting);  // Gihan

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iChequeDeposite))
                bNoAccessChequeDeposite = true;

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iCashDeposite))
                bNoAccessCashDeposite = true;

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iReissue))
                bNoAccessReissue = true;

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iInwardReconsilation))
                bNoAccessInwardReconsilation = true;

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iOutwardReconsilation))
                bNoAccessOutwardReconsilation = true; //-K- CHK

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iBEReconsilation))
                bNoAccessBEReconsilation = true;

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iReDepositFormID))
                bNoAccessReDepositFormID = true;

            InitializeComponent();
            dgvInwardReconciliation.AutoGenerateColumns = false;
        }

        private void frm_bpsChequeManagement_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Bank Management", 2, 0);
            CusDataGridViewFormat();

            CreateDataTableReIssue();
            dgvDetail.DataSource = sourceReIssue;

            CreateDataTableChequeDeposit();
            dgvDetail.DataSource = sourceChequeDeposit;

            CreateDataTableCashDeposite();
            dgvCashDeposite.DataSource = sourceCashDeposite;

            CreateDataTableReturnToSender();
            dgvReDeposit.DataSource = sourceReDeposit;

            CreateDataTableInwardReconsiliation();
            dgvInwardReconciliation.DataSource = sourceInwardReconsiliation;

            CreateDataTableOutwardReconsiliation();
            dgvOutwardReconciliation.DataSource = sourceOutwardReconsiliation;

            CreateDataTableBEReconsiliation();
            dgvBEReconciliation.DataSource = sourceBEReconsiliation;

            ClearFields();
            tabControl.SelectTab(0);
            SetFormForDeposit();
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBEClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn New Deposit

        private void btnNewDeposit_Click(object sender, EventArgs e)
        {
            SetFormForDeposit();
        }

        #endregion

        #region Btn Save Deposit
        private void btnSaveDeposit_Click(object sender, EventArgs e)
        {
            if (CheckValidityDeposit_EmptiField())
            {
                if (CheckNumberValidityDeposit())
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDepositDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdateDeposit))
                        {
                            if (CheckSelectedChequeCount(dgvDetail))
                            {
                                if (CheckValidity_ChequeDepositPosting())
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        ValidateEmptyForeignKeyDeposit();

                                        txtDepositID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeDeposit);
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtDepositID.Text))// if (txtDepositID.TextLength > 0)
                                        {
                                            #region Deposit Header
                                            tbl_bpsChequeDeposit detail = new tbl_bpsChequeDeposit(txtDepositID.Text.Trim(), txtDepositRemark.Text.Trim(), dtpDepositDate.Value,
                                                                               decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()), txtDepositAccountHolder.Text.Trim(),
                                                                               txtDepositAccountNo.Text.Trim(), txtDepositBankName.Tag.ToString(), txtDepositBranchName.Tag.ToString(), clsSecurity.UserIDLoged,
                                                                               clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, false);
                                            detail.Insert();
                                            #endregion

                                            #region Cheque Deposit Detail
                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                try
                                                {
                                                    decimal dChequeAmount = 0;
                                                    bool bIsSelected = false;
                                                    try
                                                    {
                                                        bIsSelected = bool.Parse(dgvDetail["IsSelected", row.Index].Value.ToString());
                                                    }
                                                    catch (Exception) { }

                                                    if (!bIsSelected)
                                                        continue;

                                                    string sRegisterCode = "";
                                                    if (dgvDetail["RegisterCode", row.Index].Value != null)
                                                        sRegisterCode = dgvDetail["RegisterCode", row.Index].Value.ToString();

                                                    if (sRegisterCode.Length > 0)
                                                    {
                                                        int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(txtDepositAccountNo.Tag.ToString());
                                                        tbl_bpsChequeDeposit_Detail items = new tbl_bpsChequeDeposit_Detail(txtDepositID.Text.Trim(), sRegisterCode, dtpDepositDate.Value,
                                                            "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, false, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getChequeStatusID(ChequeStatus.Deposited), "default", "default", clsSecurity.getServerDateTime(), iCompanyAccount_ID, 1);
                                                        items.Insert();

                                                        //update Cheque Register

                                                        tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sRegisterCode);
                                                        if (register != null)
                                                        {
                                                            dChequeAmount = register.Amount;
                                                            register.IsDepositted = true;
                                                            register.DateDeposited = dtpDepositDate.Value;
                                                            register.DepositedBank_ID = txtDepositBankName.Tag.ToString();
                                                            register.DepositedBranch_ID = txtDepositBranchName.Tag.ToString();
                                                            register.DepositedAccountNumber = txtDepositAccountNo.Text.Trim();
                                                            register.IsLocked = true;
                                                            register.DepositCount += 1;
                                                            register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deposited);
                                                            register.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                          //  clsDB.update_CustomerDeposittedCheques(register.Customer_ID, register.Amount, register.AccountNumber);
                                                            register.Update();
                                                        }
                                                    }

                                                    clsMethods_GL.PostTransaction_chequeDeposit(txtDepositID.Text.Trim(), sRegisterCode, dtpDepositDate.Value, dChequeAmount, txtDepositAccountNo.Text);
                                                }
                                                catch (Exception ex)
                                                {
                                                    SEACCException.Show(ex);
                                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                                }
                                            }
                                            #endregion
                                            MessageBox.Show("Record Saved Successfully....\nPlease Write Down The Deposit Reference Number In Your Bank Slip \n\nCHEQUE DEPOSIT REF NO : " + txtDepositID.Text.Trim(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //else
                                        //    MessageBox.Show("Cheque Deposit " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        ClearFields();
                                        SetFormForDeposit();
                                    }
                                }
                            }
                            else
                                MessageBox.Show("please Select the Cheques");
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn New Cash Deposite

        private void btnNewCashDeposite_Click(object sender, EventArgs e)
        {
            SetFormForCashDeposit();
        }

        #endregion

        #region Btn Save Cash Deposite
        private bool CheckValidity_CashDepositPosting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                bool bSlotStatus_Bank = clsMethods_GL.CheckAccountLink_Bank(txtCashDepositeAccountNo.Text);
                bool bSlotStatus_Cash = clsMethods_GL.CheckAccountLink(AccSlot.CashDeposit, true);

                if (bSlotStatus_Bank && bSlotStatus_Cash)
                    bStatus = true;
            }
            else
                bStatus = true;
            return bStatus;
        }
        private bool CheckValidity_ChequeDepositPosting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                bool bSlotStatus_Bank = clsMethods_GL.CheckAccountLink_Bank(txtDepositAccountNo.Text);
                bool bSlotStatus_Cheque = clsMethods_GL.CheckAccountLink(AccSlot.ChequeDeposit, true);

                if (bSlotStatus_Bank && bSlotStatus_Cheque)
                    bStatus = true;
            }
            else
                bStatus = true;
            return bStatus;
        }
        private bool CheckValidity_ChequeREDepositPosting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                bool bSlotStatus_Bank = clsMethods_GL.CheckAccountLink_Bank(txtReDepositAccountName.Text);
                bool bSlotStatus_Cheque = clsMethods_GL.CheckAccountLink(AccSlot.ChequeReDeposit, true);

                if (bSlotStatus_Bank && bSlotStatus_Cheque)
                    bStatus = true;
            }
            else
                bStatus = true;
            return bStatus;
        }
        private bool CheckValidity_ChequeReturnPosting()
        {
            bool bStatus = false;

            if (clsConfig.bAutoPostingEnable)
            {
                bool bSlotStatus_Bank = false, bSlotStatus_Debter = false;

                foreach (DataGridViewRow row1 in dgvInwardReconciliation.Rows)
                {
                    bool bSelected = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reIsSelect", row1.Index, false);
                    if (bSelected)
                    {
                        bool cb = (bool)row1.Cells[0].FormattedValue;
                        string sAccount = row1.Cells[6].FormattedValue.ToString();
                        string sStatusID = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reChequeStatusID", row1.Index, "");

                        if (cb == true)
                        {
                            bSlotStatus_Bank = clsMethods_GL.CheckAccountLink_Bank(sAccount);
                            if (!bSlotStatus_Bank)
                                break;
                        }
                        if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C))
                        {
                            string sRegisterCode = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reRegisterCode", row1.Index, "");
                            tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sRegisterCode);
                            if (oCheque != null)
                            {
                                bSlotStatus_Debter = clsMethods_GL.CheckAccountLink_Customer(oCheque.Customer_ID);// GetAccountCode_Customer(oCheque.Customer_ID);
                            }
                        }
                    }

                }

                bool bSlotStatus_Cheque = clsMethods_GL.CheckAccountLink(AccSlot.ChequeReturned, false);

                if (bSlotStatus_Bank && bSlotStatus_Cheque)
                    bStatus = true;
            }
            else
                bStatus = true;
            return bStatus;
        }
        private void btnSaveCashDeposite_Click(object sender, EventArgs e)
        {
            if (CheckValidityCashDeposit_EmptyField())
            {
                if (CheckSelectedChequeCount(dgvCashDeposite))
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpCashDepositeDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdateCashDeposite))
                        {
                            if (CheckValidity_CashDepositPosting())
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    ValidateEmptyForeignKeyDeposit();

                                    try
                                    {
                                        txtCashDepositeID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeCashDeposite);

                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtCashDepositeID.Text))  //if (txtCashDepositeID.TextLength > 0)
                                        {
                                            int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(txtCashDepositeBranchName.Tag.ToString());

                                            //tbl_bpsCashDeposit detail = new tbl_bpsCashDeposit(txtCashDepositeID.Text.Trim(), txtCashDepositeRemarks.Text.Trim(), dtpCashDepositeDate.Value, decimal.Parse(txtCountCheques.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()),
                                            //     txtCashDepositeAccountNo.Text.Trim(), txtCashDepositeBankName.Tag.ToString(), txtCashDepositeBranchName.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(),
                                            //    clsSecurity.getServerDateTime(), clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                                            //detail.Insert();
                                            tbl_bpsCashDeposit detail = new tbl_bpsCashDeposit(txtCashDepositeID.Text.Trim(), txtCashDepositeRemarks.Text.Trim(), dtpCashDepositeDate.Value, decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtTotDepAmount.Text.Trim()), decimal.Parse(txtTotDepAmount.Text.Trim()),
                                                 txtCashDepositeAccountNo.Text.Trim(), txtCashDepositeBankName.Tag.ToString(), txtCashDepositeBranchName.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(),
                                                clsSecurity.getServerDateTime(), false, clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, iCompanyAccount_ID, -1, clsSecurity.getServerDateTime());
                                            detail.Insert();

                                            foreach (DataGridViewRow row in dgvCashDeposite.Rows)
                                            {
                                                if (!bool.Parse(dgvCashDeposite["Select", row.Index].Value.ToString()))
                                                    continue;

                                                string ReceiptID = "";

                                                ReceiptID = dgvCashDeposite["Receipt", row.Index].Value.ToString();
                                                if (ReceiptID.Length > 0)
                                                {
                                                    decimal dAmount = 0;
                                                    decimal dDepCashAount = decimal.Parse(dgvCashDeposite["DepositedAmount", row.Index].Value.ToString());

                                                    tbl_bpsCashDeposit_Detail Ddetial = new tbl_bpsCashDeposit_Detail(row.Index, txtCashDepositeID.Text.Trim(), ReceiptID.Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), dDepCashAount);
                                                    Ddetial.Insert();

                                                    //Sales Receipt
                                                    List<tbl_bpsChequeRegister> oChqList = tbl_bpsChequeRegister.SelectAllByReceipt_ID(ReceiptID).ToList();
                                                    foreach (tbl_bpsChequeRegister oDetail in oChqList.Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cash))
                                                    {
                                                        if (oDetail != null && oDetail.Receipt_ID != "default")
                                                        {
                                                            oDetail.DepositedCashAmount += Ddetial.DepositedAmount;
                                                            if (oDetail.Amount == oDetail.DepositedCashAmount)
                                                                oDetail.IsDepositted = true;

                                                            oDetail.DateDeposited = dtpCashDepositeDate.Value;
                                                            oDetail.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                            oDetail.Update();

                                                            //dAmount = oDetail.DepositedCashAmount;
                                                            dAmount = Ddetial.DepositedAmount;
                                                        }
                                                    }

                                                    //Account Receipt
                                                    List<tbl_bpsChequeRegister> oARChqList = tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(ReceiptID).ToList();
                                                    foreach (tbl_bpsChequeRegister oDetail in oARChqList.Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cash))
                                                    {
                                                        if (oDetail != null && oDetail.AccountReceipt_ID != "default")
                                                        {
                                                            oDetail.DepositedCashAmount += Ddetial.DepositedAmount;
                                                            if (oDetail.Amount == oDetail.DepositedCashAmount)
                                                                oDetail.IsDepositted = true;

                                                            oDetail.DateDeposited = dtpCashDepositeDate.Value;
                                                            oDetail.Update();
                                                            
                                                            dAmount = Ddetial.DepositedAmount;
                                                        }
                                                    }

                                                    tbl_accAccountReceipt ARdetail = tbl_accAccountReceipt.Select(ReceiptID);
                                                    if (ARdetail != null && ARdetail.AccountReceipt_ID != "default")
                                                    {
                                                        //dAmount = ARdetail.CashAmount;

                                                        ARdetail.DepositedCashAmount += Ddetial.DepositedAmount;
                                                        if (ARdetail.CashAmount == ARdetail.DepositedCashAmount)
                                                            ARdetail.IsCashDeposited = true;
                                                        ARdetail.DateDeposited = dtpCashDepositeDate.Value;
                                                        ARdetail.Update();

                                                        dAmount = Ddetial.DepositedAmount;
                                                    }

                                                    clsMethods_GL.PostTransaction_cashDeposit(ReceiptID, txtCashDepositeID.Text.Trim(), dtpCashDepositeDate.Value, dAmount, txtCashDepositeAccountNo.Text);
                                                }
                                            }
                                            MessageBox.Show("Record Saved Successfully....\nPlease Write Down The Deposit Reference Number In Your Bank Slip \n\nCHEQUE DEPOSIT REF NO : " + txtCashDepositeID.Text.Trim(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //else
                                        //    MessageBox.Show("Record Save failed....", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                }
                                //   }

                                //  #endregion

                                catch (Exception ex)
                                {
                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                    SEACCException.Show(ex);
                                }
                                finally
                                {
                                    Cursor = Cursors.Default;
                                    ClearFields();
                                    SetFormForCashDeposit();
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Save ReDeposit
        private void btnSaveRTS_Click(object sender, EventArgs e)
        {
            if (CheckValidityReDeposit())// empty fields
            {
                if (CheckNumberValidityReDeposit())
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpReDepositDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iReDepositFormID, IsUpdateReDeposit))
                        {
                            if (CheckSelectedChequeCount(dgvReDeposit))
                            {
                                if (CheckValidity_ChequeREDepositPosting())
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        ValidateEmptyForeignKeyDeposit();

                                        txtReDepositID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeReDeposit);
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtReDepositID.Text)) //if (txtReDepositID.TextLength > 0)
                                        {
                                            #region Re-Deposit Header
                                            tbl_bpsChequeDeposit detail = new tbl_bpsChequeDeposit(txtReDepositID.Text.Trim(), txtReDepositRemark.Text.Trim(), dtpReDepositDate.Value,
                                                decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()), txtReDepositAccountHolder.Text.Trim(),
                                                txtReDepositAccountName.Text.Trim(), txtReDepositBankName.Tag.ToString(), txtReDepositBranchName.Tag.ToString(), clsSecurity.UserIDLoged,
                                                clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, false);
                                            detail.Insert();
                                            #endregion

                                            #region Re-Deposit Detail
                                            foreach (DataGridViewRow row in dgvReDeposit.Rows)
                                            {
                                                try
                                                {
                                                    bool bSelected = false;
                                                    if (dgvReDeposit["RTSIsSelected", row.Index].Value != null)
                                                        bSelected = bool.Parse(dgvReDeposit["RTSIsSelected", row.Index].Value.ToString());
                                                    if (bSelected)
                                                    {
                                                        string sRegisterCode = "";
                                                        if (dgvReDeposit["RTSRegisterCode", row.Index].Value != null)
                                                            sRegisterCode = dgvReDeposit["RTSRegisterCode", row.Index].Value.ToString();

                                                        if (sRegisterCode.Length > 0)
                                                        {
                                                            int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(txtReDepositAccountName.Tag.ToString());
                                                            tbl_bpsChequeDeposit_Detail items = new tbl_bpsChequeDeposit_Detail(txtReDepositID.Text.Trim(), sRegisterCode, dtpReDepositDate.Value,
                                                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, true, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited), "default", "default", clsSecurity.getServerDateTime(), iCompanyAccount_ID, 1);
                                                            items.Insert();

                                                            //update Cheque Register
                                                            tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sRegisterCode);
                                                            if (register != null)
                                                            {
                                                                register.IsDepositted = true;
                                                                register.DateDeposited = clsSecurity.getServerDateTime();
                                                                register.IsLocked = true;
                                                                register.DepositCount += 1;
                                                                register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited);
                                                             //   clsDB.update_CustomerDeposittedCheques(register.Customer_ID, register.Amount, register.AccountNumber);
                                                                register.Update();

                                                                #region Credit Note Creatation
                                                                string sCRN_ID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ReDepositeChequeCreditNote));

                                                                tbl_bpsCreditNote oldCreditNote = tbl_bpsCreditNote.Select(sCRN_ID);
                                                                if (oldCreditNote == null)
                                                                {
                                                                    tbl_bpsCreditNote cNote = new tbl_bpsCreditNote(sCRN_ID, clsSecurity.getServerDateTime(), "", "default",
                                                                    "default", register.Customer_ID, "default", register.OrderRefNo_ID, register.ChequeRegister_ID, clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit),
                                                                    "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsConfig.sLocalCurrencyCode, "default", 1,
                                                                    0, 0, 0, 0, register.Amount, 0, 0, 0, 0, register.Amount, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                    clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, false, (-1), (-1));
                                                                    cNote.Insert();


                                                                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByChequeRegister_ID(register.ChequeRegister_ID).Where(p => p.Invoice_ID != "default" && p.SeattleAmount == 0 && !p.IsDeleted && !p.IsSeattled && p.IsReturnedCheque))
                                                                    {
                                                                        decimal dAllocatedAmmount = oInvoice.GrandTotal;
                                                                        string sFormConfigCode1 = clsAutocode.getFormConfigCode(FormName.CreditNoteAllocation);
                                                                        string sAllocationID = clsAutocode.getAutoGeneratedCode(sFormConfigCode1);

                                                                        dAllocatedAmmount = dAllocatedAmmount > 0 ? dAllocatedAmmount : 0;
                                                                        dAllocatedAmmount = clsHelpMethods_Local.AutoSettledInvoiceWithCreditNote(oInvoice.Invoice_ID, sCRN_ID, dAllocatedAmmount, sAllocationID, false, false);

                                                                        tbl_bpsCreditNote_Invoice oCrnInv = tbl_bpsCreditNote_Invoice.Select(sCRN_ID, row.Index);
                                                                        if (oCrnInv != null)
                                                                        {
                                                                            oCrnInv.AlocatedAmount = dAllocatedAmmount;
                                                                            oCrnInv.Update();
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                    MessageBox.Show("Credit Note No is Already Taken......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                #endregion
                                                                clsMethods_GL.PostTransaction_chequeReDeposit(txtReDepositID.Text.Trim(), sRegisterCode, dtpReDepositDate.Value, register.Amount, txtReDepositAccountName.Text);
                                                            }
                                                        }
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    SEACCException.Show(ex);
                                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                                }//error may come because last row of the grid may not have information
                                            }
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //else
                                        //    MessageBox.Show("Cheque Deposit " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        ClearFieldsReDeposit();
                                        SetFormForReDeposit();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Btn New ReIssue

        private void btnNewReIssue_Click(object sender, EventArgs e)
        {
            SetFormForReIssue();
        }

        #endregion

        #region Btn Save ReIssue

        private void btnSaveReIssu_Click(object sender, EventArgs e)
        {
            if (CheckValidityReIssue())
            {
                if (CheckNumberValidityReIssue())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdateReIssue))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            ValidateEmptyForeignKeyReIssue();
                            if (IsUpdateReIssue)  //update records
                            {
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                #region comments
                                //tbl_bpsChequeReIssue oldRecord = tbl_bpsChequeReIssue.Select(txtReIssueID.Text.Trim());
                                //if (oldRecord != null)
                                //{
                                //    //Cheque Deposit Detail
                                //    tbl_bpsChequeReIssue_Detail.DeleteAllByReIssue_ID(txtReIssueID.Text.Trim());
                                //    foreach (DataGridViewRow row in dgvDetail.Rows)
                                //    {
                                //        try
                                //        {
                                //            bool bSelected = false;
                                //            if (dgvDetail["IsSelected", row.Index].Value != null)
                                //                bSelected = bool.Parse(dgvDetail["IsSelected", row.Index].Value.ToString());
                                //            if (bSelected)
                                //            {
                                //                string sRegisterCode = "";
                                //                if (dgvDetail["RegisterCode", row.Index].Value != null)
                                //                    sRegisterCode = dgvDetail["RegisterCode", row.Index].Value.ToString();


                                //                if (sRegisterCode.Length > 0)
                                //                {
                                //                    tbl_bpsChequeReIssue_Detail items = new tbl_bpsChequeReIssue_Detail(row.Index, txtReIssueID.Text.Trim(), sRegisterCode);
                                //                    items.Insert();

                                //                    //update Cheque Register
                                //                    tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sRegisterCode);
                                //                    if (register != null)
                                //                    {
                                //                        register.IsReIssued = true;
                                //                        register.IsLocked = true;
                                //                        register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.ReIssued);
                                //                        register.Update();
                                //                    }
                                //                }
                                //            }
                                //        }
                                //        catch (Exception) { }//error may come because last row of the grid may not have information
                                //    }

                                //    //ReIssue Header
                                //    tbl_bpsChequeReIssue detail = new tbl_bpsChequeReIssue(txtReIssueID.Text.Trim(), txtReIssueRemak.Text.Trim(), dtpReIssueDate.Value,
                                //        decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()), txtReIssueSupplierID.Tag.ToString(),
                                //        txtReIssueReceiverName.Text.Trim(), txtReIssueNICNo.Text.Trim(), txtReIssueIssuerName.Text.Trim(), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                //            txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), oldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                //            glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked);                                 
                                //    detail.Update();

                                //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //} 
                                #endregion
                            }

                            #region Save Records

                            else  //insert records
                            {
                                bool bIsRecordsSelected = false;

                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    if (dgvDetail["IsSelected", row.Index].Value != null)
                                    {
                                        if (bool.Parse(dgvDetail["IsSelected", row.Index].Value.ToString()))
                                        {
                                            bIsRecordsSelected = true;
                                            break;
                                        }
                                    }
                                }

                                if (bIsRecordsSelected)
                                {
                                    if (clsAutocode.IsAutoGenerated(sFormConfigCodeReIssue))
                                        txtReIssueID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeReIssue);

                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtReIssueID.Text)) //if (txtReIssueID.TextLength > 0)
                                    {
                                        //ReIssue Header
                                        tbl_bpsChequeReIssue detail = new tbl_bpsChequeReIssue(txtReIssueID.Text.Trim(), txtReIssueRemak.Text.Trim(), dtpReIssueDate.Value,
                                            decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()), txtReIssueSupplierID.Tag.ToString(),
                                            txtReIssueReceiverName.Text.Trim(), txtReIssueNICNo.Text.Trim(), txtReIssueIssuerName.Text.Trim(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                                        detail.Insert();

                                        //Cheque Deposit Detail                                    
                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            try
                                            {
                                                bool bSelected = false;
                                                if (dgvDetail["IsSelected", row.Index].Value != null)
                                                    bSelected = bool.Parse(dgvDetail["IsSelected", row.Index].Value.ToString());
                                                if (bSelected)
                                                {
                                                    string sRegisterCode = "";
                                                    if (dgvDetail["RegisterCode", row.Index].Value != null)
                                                        sRegisterCode = dgvDetail["RegisterCode", row.Index].Value.ToString();


                                                    if (sRegisterCode.Length > 0)
                                                    {
                                                        tbl_bpsChequeReIssue_Detail items = new tbl_bpsChequeReIssue_Detail(row.Index, txtReIssueID.Text.Trim(), sRegisterCode);
                                                        items.Insert();

                                                        //update Cheque Register
                                                        tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sRegisterCode);
                                                        if (register != null)
                                                        {
                                                            register.DateReIssued = clsSecurity.getServerDateTime();
                                                            register.IsReIssued = true;
                                                            register.IsLocked = true;
                                                            register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.ReIssued);
                                                            register.Update();
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                clsValidate.WriteErrorLog("", iFormID, ex);
                                                SEACCException.Show(ex);
                                            }//error may come because last row of the grid may not have information
                                        }
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    //else
                                    //{
                                    //    MessageBox.Show("Cheque ReIssue " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //}
                                }
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            SetFormForReIssue();
                        }
                    }
                }
            }
        }

        #endregion

        #region Btn New Recon
        private void btnNewRecon_Click(object sender, EventArgs e)
        {
            SetFormForInwardReconciliation();
        }

        #endregion

        #region Btn Save Recon
        private void btnSaveInwardRecon_Click(object sender, EventArgs e)
        {
            if (CheckValidityGridSelection())
            {
                // if (CheckValidityReconciliation())
                {
                    if (CheckNumberValidityReconciliation())
                    {
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpReconciliationDateIN.Value.Date))
                        {
                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdateInwardReConsiliation))
                            {
                                if (CheckValidity_ChequeReturnPosting())
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        ValidateEmptyForeignKeyReConciliation();

                                        bool bChequeReturnedAutoPostingStatus = false;

                                        txtReconciliationIDIN.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeInwardReConsiliation);

                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtReconciliationIDIN.Text)) //if (txtReconciliationIDIN.TextLength > 0)
                                        {
                                            #region Reconciliation Header
                                            tbl_bpsChequeReconciliation detail = new tbl_bpsChequeReconciliation(txtReconciliationIDIN.Text.Trim(), txtReconRemakIN.Text.Trim(), dtpReconciliationDateIN.Value,
                                                                                decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                                    txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                                    glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                                            detail.Insert();
                                            #endregion

                                            #region Cheque Reconcilate
                                            foreach (DataGridViewRow row in dgvInwardReconciliation.Rows)
                                            {
                                                try
                                                {
                                                    bool bSelected = false;
                                                    string sStatusID = "default", sSalesNoteType = "default";
                                                    decimal dPenalty = 0;

                                                    bSelected = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reIsSelect", row.Index, false);
                                                    if (bSelected)
                                                    {
                                                        string sRegisterCode = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reRegisterCode", row.Index, "");

                                                        try
                                                        {
                                                            sStatusID = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reChequeStatusID", row.Index, "");
                                                            dPenalty = clsValidate.ValidateGridValue(dgvInwardReconciliation, "rePanalty", row.Index, 0.00m);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                                            SEACCException.Show(ex);
                                                        }

                                                        if (sRegisterCode.Length > 0 && (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Realized)))
                                                        {
                                                            #region Update Cheque Register Detail
                                                            tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sRegisterCode);
                                                            if (register != null)
                                                            {
                                                                tbl_bpsChequeReconciliation_Detail items = new tbl_bpsChequeReconciliation_Detail(txtReconciliationIDIN.Text.Trim(), sRegisterCode, dPenalty, sStatusID, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), dtpReconciliationDateIN.Value, clsGenaralName.getName_CompanyAccount_IDByAccountNo(register.DepositedAccountNumber), 1,"default");
                                                                items.Insert();


                                                                #region Realized
                                                                if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))
                                                                {
                                                                //    clsDB.update_CustomerRealizedCheques(register.Customer_ID, register.Amount, register.AccountNumber);

                                                                    register.DateReconcilied = dtpReconciliationDateIN.Value;
                                                                    register.IsReconcilied = true;
                                                                    register.IsLocked = true;
                                                                    register.ChequeStatus_ID = sStatusID;
                                                                    register.Update();
                                                                }
                                                                #endregion

                                                                #region Returned
                                                                else if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                                                {
                                                                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(register.Receipt_ID);
                                                                    if (oReceipt != null)
                                                                        sSalesNoteType = oReceipt.SalesNoteType_ID;

                                                                    #region Retern Cheque - Debit Note
                                                                    register.IsReturned = true;
                                                                    string sDebitNoteID = "";
                                                                    sDebitNoteID = clsAutocode.getAutoGeneratedCode(sFormConfigReturnedCheque);

                                                                    //Invoice Header
                                                                    tbl_sasInvoice objInvoice = new tbl_sasInvoice(sDebitNoteID, "default", dtpReconciliationDateIN.Value, "Returned Cheque / Deibt Note",
                                                                         "", clsCommon.CurrencyToWord(register.Amount), register.Customer_ID, "default", "default", "default", "default", clsHelpMethods_Local.getEmployeeIDFromReceiptID(register.Receipt_ID), register.OrderRefNo_ID, register.ChequeRegister_ID,
                                                                         clsConfig.sLocalCurrencyCode, "default",
                                                                         clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                                                         clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                                                         clsSecurity.FinancialYearID, sSalesNoteType, 1, 0, 0, 0, 0, 0, 0, 0, register.Amount, 0, 0, 0, 0, 0, 0, 0, register.Amount, 0, 0,
                                                                         clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(),
                                                                         clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                                         clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                         bHasChecked, bHasApproved, true, false, "", "", "", clsSecurity.getServerDateTime().AddDays(30), true, 0, false, false, 0, false, false, true, false, false, false, false, false, false, "default", "", "default", false, register.CompanyID, register.CompanyBranch_ID, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1);
                                                                    objInvoice.Insert();

                                                                //   clsDB.update_CustomerReturnedCheques(register.Customer_ID, register.Amount, register.AccountNumber);
                                                                 //   clsDB.update_CustomerDeposittedChequesFromReturns(register.Customer_ID, register.Amount, register.AccountNumber);
                                                                    #endregion

                                                                    register.DateReconcilied = dtpReconciliationDateIN.Value;
                                                                    register.IsReconcilied = true;
                                                                    register.IsLocked = true;
                                                                    register.ChequeStatus_ID = sStatusID;
                                                                    register.Update();

                                                                    bChequeReturnedAutoPostingStatus = clsMethods_GL.PostTransaction_chequeReturned(txtReconciliationIDIN.Text, sRegisterCode, dtpReconciliationDateIN.Value, register.Amount);
                                                                }
                                                                #endregion
                                                            }
                                                            #endregion
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

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //else
                                        //    MessageBox.Show("Cheque Reconciliation " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        ClearFields();
                                        SetFormForInwardReconciliation();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn New Outward Recon
        private void btnNewOutRecon_Click(object sender, EventArgs e)
        {
            SetFormForOutwardReconciliation();
        }
        #endregion

        #region Btn Save Outward Recon
        private void btnSaveOutwardRecon_Click(object sender, EventArgs e)
        {
            if (CheckValidity_OutwordReconciliation())
            {
                if (CheckNumberValidityReconciliation())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdateOutwardReConsiliation))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            ValidateEmptyForeignKeyReConciliation();

                            #region insert Records
                            {
                                string sErrorCheqes = "";

                                if (clsAutocode.IsAutoGenerated(sFormConfigCodeOutwardReConsiliation))
                                    txtReconciliationIDOUT.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeOutwardReConsiliation);

                                if (clsValidate.CheckValidity_TransactionCodeLength(txtReconciliationIDOUT.Text)) //if (txtReconciliationIDOUT.TextLength > 0)
                                {
                                    tbl_accChequeReconciliation detail = new tbl_accChequeReconciliation(txtReconciliationIDOUT.Text.Trim(), txtReconRemakOUT.Text.Trim(), dateTimePicker1.Value,
                                        decimal.Parse(txtCountChequeSelected.Text.Trim()), decimal.Parse(txtAmountChequeSelected.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                            txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, -1, 1, clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                                    detail.Insert();

                                    #region Cheque Reconcilate
                                    foreach (DataGridViewRow row in dgvOutwardReconciliation.Rows)
                                    {
                                        try
                                        {
                                            bool bSelected = false;
                                            string sStatusID = "default";
                                            decimal dPenalty = 0;

                                            if (dgvOutwardReconciliation["owIsSelect", row.Index].Value != null)
                                                bSelected = bool.Parse(dgvOutwardReconciliation["owIsSelect", row.Index].Value.ToString());

                                            if (!bSelected)
                                                continue;

                                            string sRegisterCode = "default";

                                            if (dgvOutwardReconciliation["owRegisterCode", row.Index].Value != null)
                                                sRegisterCode = dgvOutwardReconciliation["owRegisterCode", row.Index].Value.ToString();

                                            tbl_accChequeRegister oCheque = tbl_accChequeRegister.Select(sRegisterCode);
                                            if (oCheque != null)
                                            {
                                                try
                                                {
                                                    if (dgvOutwardReconciliation["owChequeStatusID", row.Index].Value != null && dgvOutwardReconciliation["owChequeStatusID", row.Index].Value.ToString().Trim() != "")
                                                        sStatusID = dgvOutwardReconciliation["owChequeStatusID", row.Index].Value.ToString();
                                                    if (dgvOutwardReconciliation["owPanalty", row.Index].Value != null && dgvOutwardReconciliation["owPanalty", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owPanalty", row.Index].Value.ToString()))
                                                        dPenalty = decimal.Parse(dgvOutwardReconciliation["owPanalty", row.Index].Value.ToString());
                                                }
                                                catch (Exception ex)
                                                {
                                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                                    SEACCException.Show(ex);
                                                }

                                                if (sRegisterCode.Length > 0 && sStatusID != clsAutocode.getChequeStatusID(ChequeStatus.Default))
                                                {
                                                    tbl_accChequeReconciliation_Detail items = new tbl_accChequeReconciliation_Detail(row.Index, txtReconciliationIDOUT.Text.Trim(), sRegisterCode, dPenalty, sStatusID, dateTimePicker1.Value, oCheque.CompanyAccount_ID, 1);
                                                    items.Insert();

                                                    #region Update Cheque Register Detail
                                                    oCheque.ReconcilationDate = dateTimePicker1.Value;
                                                    //  oCheque.IsReconcilied = true;
                                                    oCheque.PrintCount = 1;
                                                    oCheque.IsLocked = true;
                                                    oCheque.ChequeStatus_ID = sStatusID;
                                                    oCheque.Update();
                                                    #endregion

                                                    #region Outward Cheques Cancellation
                                                    if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Deleted))
                                                    {
                                                        if (oCheque.PaymentVoucher_ID != null && oCheque.PaymentVoucher_ID != "default")
                                                        {
                                                            tbl_accPaymentVoucher detailPV = tbl_accPaymentVoucher.Select(oCheque.PaymentVoucher_ID);
                                                            if (detailPV != null)
                                                            {
                                                                #region Cheque Return
                                                                if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                                                                {
                                                                    clsMethods_GL.ReversePostTransaction_PV(detailPV.PaymentVoucher_ID, dateTimePicker1.Value, false);

                                                                    #region APN Create
                                                                    string sAPNID = txtReconciliationIDOUT.Text;
                                                                    //string sFormConfigCode;
                                                                    //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accAccountpayableNote);
                                                                    //sAPNID = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                                                    tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(sAPNID, clsSecurity.getServerDateTime(), "", "", clsSecurity.getServerDateTime(), "default", "", "", "default", "default", "default",
                                                                        "default", detailPV.Supplier_ID, "default", "default", "default", "default", "default".Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsConfig.sLocalCurrencyCode,
                                                                        1, 0, 0, 0, 0, 0, oCheque.ChequeAmount, 0, 0, 0, 0, oCheque.ChequeAmount,
                                                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, false, false, false, false, false, false, false, false, 0, false, oCheque.ChequeRegister_ID, true, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                                                                    AccAPN.Insert();

                                                                    //  Insert supplier outstanding amount
                                                                    //       clsBackProcess.UpdateSupplierMaster_OutstandingAmount(detailPV.Supplier_ID.Trim(), oCheque.ChequeAmount, 0, true); 
                                                                    #endregion
                                                                }
                                                                #endregion

                                                                #region Cheque Cancel
                                                                else if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Deleted))
                                                                {
                                                                    clsMethods_GL.ReversePostTransaction_PV(detailPV.PaymentVoucher_ID, dateTimePicker1.Value, true);

                                                                    #region tbl acc ChequeRegister Delete
                                                                    oCheque.IsDeleted = true;
                                                                    oCheque.DateModified = dateTimePicker1.Value;
                                                                    oCheque.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                                    oCheque.Update();
                                                                    #endregion                                                                

                                                                    #region PV Cancel
                                                                    detailPV.IsDeleted = true;
                                                                    detailPV.IsSeattled = false;
                                                                    detailPV.SettledAmount = 0;
                                                                    detailPV.DateDeleted = dateTimePicker1.Value;
                                                                    detailPV.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                                    detailPV.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                                    detailPV.Update();
                                                                    #endregion

                                                                    #region  Un Settle Account Payable Note
                                                                    clsHelpMethods_Local.RemoveAPNSattlementsFrom_PaymentVoucherID(detailPV.PaymentVoucher_ID);
                                                                    #endregion

                                                                }
                                                                #endregion

                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                }
                                                else
                                                    sErrorCheqes += sRegisterCode + ",";
                                            }
                                            else
                                                sErrorCheqes += sRegisterCode + ",";
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        }
                                    }
                                    #endregion

                                    foreach (tbl_accChequeReconciliation_Detail oChequeReqDetail in tbl_accChequeReconciliation_Detail.SelectAllByReconciliation_ID(txtReconciliationIDOUT.Text.Trim()))
                                    {
                                        tbl_accChequeReconciliation oChequeReq = tbl_accChequeReconciliation.Select(oChequeReqDetail.Reconciliation_ID);
                                        if (oChequeReq != null)
                                        {
                                            oChequeReq.CompanyAccount_ID = oChequeReqDetail.CompanyAccount_ID;
                                            oChequeReq.Update();
                                            break;
                                        }
                                    }
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (sErrorCheqes != "")
                                        MessageBox.Show("Following cheques are not updated " + sErrorCheqes);
                                }
                                //else
                                //    MessageBox.Show("Cheque Reconciliation " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            //  SetFormForOutwardReconciliation();
                        }
                    }
                }
            }
        }
        #endregion

        #region Datagrid Format

        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatNoReadOnly(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormatNoReadOnly(dgvInwardReconciliation, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormatNoReadOnly(dgvOutwardReconciliation, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormatNoReadOnly(dgvBEReconciliation, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormatNoReadOnly(dgvReDeposit, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormatNoReadOnly(dgvCashDeposite, clsFormatter.colorDigiteqTheamColorSales1, Color.FromArgb(99, 50, 50));
        }

        #endregion

        #region Clear Fields

        private void ClearFields()
        {
            try
            {
                txtGenAccountID.Clear();
                txtGenChequeNo.Clear();
                txtCountCheques.Clear();
                txtAmountCheques.Clear();
                chkGenDateRange.Checked = false;

                txtCountChequeSelected.Clear();
                txtAmountChequeSelected.Clear();
                txtCountChequeSelected.Text = "0";
                txtAmountChequeSelected.Text = "0.00";

                Refresh_BranchCmb();
                ClearFieldsDeposit();

                //   tabControl.TabPages.Remove(tbpReIssue);

                if (tabControl.SelectedTab == tbpDeposit)
                    SetFormForDeposit();
                else if (tabControl.SelectedTab == tbpReIssue)
                    SetFormForReIssue();
                else if (tabControl.SelectedTab == tbpInwardReconciliation)
                    SetFormForInwardReconciliation();
                else if (tabControl.SelectedTab == tbpOutwardReconciliation)
                    SetFormForOutwardReconciliation();
                else if (tabControl.SelectedTab == tbpBEReconcilation)
                    SetFormForBEReconciliation();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void ClearFieldsDeposit()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateDeposit = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDepositID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDepositID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                txtDepositBankName.Tag = null;
                txtDepositBranchName.Tag = null;
                txtDepositID.Clear();
                txtDepositAccountHolder.Clear();
                txtDepositAccountNo.Clear();
                txtDepositBankName.Clear();
                txtDepositBranchName.Clear();
                txtDepositRemark.Clear();
                txtPreparedBy.Clear();
                dtpDepositDate.Value = clsSecurity.getServerDateTime();

                txtCountChequeSelected.Text = "0";
                txtAmountChequeSelected.Text = "0.00";

                xBE.Visible = false;
                x2.Visible = true;

                if (clsAutocode.IsAutoGenerated(sFormConfigCodeDeposit))
                    txtDepositID.Text = "<Auto Generate>";
                else
                    txtDepositID.Clear();
                if (txtDepositID.Enabled)
                {
                    txtDepositID.SelectAll();
                    txtDepositID.Focus();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void ClearFieldsCashDeposit()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateDeposit = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCashDepositeID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCashDepositeID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                txtCashDepositeID.Tag = null;
                txtCashDepositeBankName.Tag = null;
                txtCashDepositeID.Clear();
                txtcashDepositeAccountHolder.Clear();
                txtCashDepositeAccountNo.Clear();
                txtCashDepositeBankName.Clear();
                txtCashDepositeBranchName.Clear();
                txtCashDepositeRemarks.Clear();
                txtPreparedBy.Clear();
                dtpCashDepositeDate.Value = clsSecurity.getServerDateTime();

                xBE.Visible = false;
                x2.Visible = true;

                if (clsAutocode.IsAutoGenerated(sFormConfigCodeCashDeposite))
                    txtCashDepositeID.Text = "<Auto Generate>";
                else
                    txtCashDepositeID.Clear();
                if (txtCashDepositeID.Enabled)
                {
                    txtCashDepositeID.SelectAll();
                    txtCashDepositeID.Focus();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void ClearFieldsReDeposit()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateDeposit = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReDepositID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReDepositID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                txtReDepositBankName.Tag = null;
                txtReDepositBranchName.Tag = null;
                txtReDepositID.Clear();
                txtReDepositAccountHolder.Clear();
                txtReDepositAccountName.Clear();
                txtReDepositBankName.Clear();
                txtReDepositBranchName.Clear();
                txtReDepositRemark.Clear();
                txtPreparedBy.Clear();
                dtpReDepositDate.Value = clsSecurity.getServerDateTime();

                txtCountChequeSelected.Text = "0";
                txtAmountChequeSelected.Text = "0.00";

                xBE.Visible = false;
                x2.Visible = true;

                if (clsAutocode.IsAutoGenerated(sFormConfigCodeReDeposit))
                    txtReDepositID.Text = "<Auto Generate>";
                else
                    txtReDepositID.Clear();
                if (txtReDepositID.Enabled)
                {
                    txtReDepositID.SelectAll();
                    txtReDepositID.Focus();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void ClearFieldsReIssue()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateReIssue = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReIssueID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReIssueID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                txtReIssueSupplierID.Tag = null;
                txtReIssueID.Clear();
                txtReIssueIssuerName.Clear();
                txtReIssueNICNo.Clear();
                txtReIssueReceiverName.Clear();
                txtReIssueRemak.Clear();
                txtReIssueSupplierID.Clear();
                dtpReIssueDate.Value = clsSecurity.getServerDateTime();

                txtCountChequeSelected.Text = "0";
                txtAmountChequeSelected.Text = "0.00";

                xBE.Visible = false;
                x2.Visible = true;

                if (clsAutocode.IsAutoGenerated(sFormConfigCodeReIssue))
                    txtReIssueID.Text = "<Auto Generate>";
                else
                    txtReIssueID.Clear();
                if (txtReIssueID.Enabled)
                {
                    txtReIssueID.SelectAll();
                    txtReIssueID.Focus();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }

        private void ClearFieldsInwardReconciliation()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateInwardReConsiliation = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReconciliationIDIN, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReconciliationID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                txtReconciliationIDIN.Clear();
                txtReconRemakIN.Clear();
                dtpReconciliationDateIN.Value = clsSecurity.getServerDateTime();
                //txtiRealizedIN.Text = "0";
                //txtiReturnedNRCIN.Text = "0";
                //txtiReturnedNROIN.Text = "0";
                //txtiReturnedRIN.Text = "0";
                //txtdRealizedIN.Text = "0.00";
                //txtdReturnedNRCIN.Text = "0.00";
                //txtdReturnedNROIN.Text = "0.00";
                //txtdReturnedRIN.Text = "0.00";

                txtCountChequeSelected.Text = "0";
                txtAmountChequeSelected.Text = "0.00";

                xBE.Visible = false;
                x2.Visible = true;

                if (clsAutocode.IsAutoGenerated(sFormConfigCodeInwardReConsiliation))
                    txtReconciliationIDIN.Text = "<Auto Generate>";
                else
                    txtReconciliationIDIN.Clear();
                if (txtReconciliationIDIN.Enabled)
                {
                    txtReconciliationIDIN.SelectAll();
                    txtReconciliationIDIN.Focus();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private void ClearFieldsOutwardReconciliation()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateOutwardReConsiliation = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReconciliationIDIN, true);
                clsCommon.SetEnableDisable_NormalLabel(lblReconciliationID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                txtReconciliationIDIN.Clear();
                txtReconRemakIN.Clear();
                dtpReconciliationDateIN.Value = clsSecurity.getServerDateTime();
                //txtiRealizedIN.Text = "0";
                //txtiReturnedNRCIN.Text = "0";
                //txtiReturnedNROIN.Text = "0";
                //txtiReturnedRIN.Text = "0";
                //txtdRealizedIN.Text = "0.00";
                //txtdReturnedNRCIN.Text = "0.00";
                //txtdReturnedNROIN.Text = "0.00";
                //txtdReturnedRIN.Text = "0.00";

                txtCountChequeSelected.Text = "0";
                txtAmountChequeSelected.Text = "0.00";

                xBE.Visible = false;
                x2.Visible = true;

                if (clsAutocode.IsAutoGenerated(sFormConfigCodeOutwardReConsiliation))
                    txtReconciliationIDIN.Text = "<Auto Generate>";
                else
                    txtReconciliationIDIN.Clear();
                if (txtReconciliationIDIN.Enabled)
                {
                    txtReconciliationIDIN.SelectAll();
                    txtReconciliationIDIN.Focus();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private void ClearFieldsBEReconciliation()
        {
            try
            {
                //set the flag and enble the id
                IsUpdateBEReConsiliation = false;
                //clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReconciliationIDIN, true);
                //clsCommon.SetEnableDisable_NormalLabel(lblReconciliationID, true);

                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                bHasApproved = false;
                bHasChecked = false;

                //txtReconciliationIDIN.Clear();
                //txtReconRemakIN.Clear();
                dtpRecBE.Value = clsSecurity.getServerDateTime();

                xBE.Visible = true;

                //txtCountChequeSelected.Text = "0";
                //txtAmountChequeSelected.Text = "0.00";

                //if (clsAutocode.IsAutoGenerated(sFormConfigCodeOutwardReConsiliation))
                //    txtReconciliationIDIN.Text = "<Auto Generate>";
                //else
                //    txtReconciliationIDIN.Clear();
                //if (txtReconciliationIDIN.Enabled)
                //{
                //    txtReconciliationIDIN.SelectAll();
                //    txtReconciliationIDIN.Focus();
                //}
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private void ClearSerchTexBox(TextBox textbox)
        {
            if (textbox.Name != "txtDepositDate")
                txtDepositDate.Clear();
            if (textbox.Name != "txtChequeDate")
                txtChequeDate.Clear();
            if (textbox.Name != "txtCustomerID")
                txtCustomerID.Clear();
            if (textbox.Name != "txtReceiptID")
                txtReceiptID.Clear();
            if (textbox.Name != "txtGenChequeNo")
                txtGenChequeNo.Clear();
            if (textbox.Name != "txtBEDate")
                txtBEDate.Clear();
            if (textbox.Name != "txtBENo")
                txtBENo.Clear();
            if (textbox.Name != "txtBEAmount")
                txtBEAmount.Clear();
        }

        #endregion

        #region Refresh Grid

        #region Create Data Table
        private void CreateDataTableReturnToSender()
        {
            dtReDeposit.Columns.Clear();

        }
        private void CreateDataTableChequeDeposit()
        {
            dtChequeDeposit.Columns.Clear();

        }
        private void CreateDataTableCashDeposite()
        {
            dtCashDeposite.Columns.Clear();
            dtCashDeposite.Columns.Add("IsSelected", typeof(bool));
            dtCashDeposite.Columns.Add("ReceiptID", typeof(string));
            dtCashDeposite.Columns.Add("ReceiptDate", typeof(string));
            dtCashDeposite.Columns.Add("CustomerName", typeof(string));
            dtCashDeposite.Columns.Add("Amount", typeof(string));
            dtCashDeposite.Columns.Add("DepositedAmount", typeof(string));
            dtCashDeposite.Columns.Add("InvoiceList", typeof(string));
            dtCashDeposite.Columns.Add("CSdate", typeof(DateTime));
            dtCashDeposite.Columns.Add("IsAccRecipt", typeof(bool));
        }
        private void CreateDataTableReIssue()
        {
            dtReIssue.Columns.Clear();
            dtReIssue.Columns.Add("IsSelected", typeof(bool));
            dtReIssue.Columns.Add("RegisterCode", typeof(string));
            dtReIssue.Columns.Add("CustomerName", typeof(string));
            dtReIssue.Columns.Add("ReceiptID", typeof(string));
            dtReIssue.Columns.Add("AccountNo", typeof(string));
            dtReIssue.Columns.Add("ChequeNo", typeof(string));
            dtReIssue.Columns.Add("ChequeDate", typeof(string));
            dtReIssue.Columns.Add("Amount", typeof(string));
            dtReIssue.Columns.Add("GridChequeStatus", typeof(string));
            dtReIssue.Columns.Add("Sdate", typeof(DateTime));
        }
        private void CreateDataTableInwardReconsiliation()
        {
            dtInwardReconsiliation.Columns.Clear();

        }
        private void CreateDataTableOutwardReconsiliation()
        {
            dtOutwardReconsiliation.Columns.Clear();
            dtOutwardReconsiliation.Columns.Add("owIsSelect", typeof(bool));
            dtOutwardReconsiliation.Columns.Add("owRegisterCode", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owChequeDate", typeof(DateTime));
            dtOutwardReconsiliation.Columns.Add("owCreditor_SupplierName", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owBankName_AccNo", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owChequeNo", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owAmount", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owChequeStatusID", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owChequeStatus", typeof(string));
            dtOutwardReconsiliation.Columns.Add("owPanalty", typeof(string));
        }

        private void CreateDataTableBEReconsiliation()
        {
            //dtOutwardReconsiliation.Columns.Clear();
            //dtOutwardReconsiliation.Columns.Add("owIsSelect", typeof(bool));
            //dtOutwardReconsiliation.Columns.Add("owRegisterCode", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owChequeDate", typeof(DateTime));
            //dtOutwardReconsiliation.Columns.Add("owCreditor_SupplierName", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owBankName_AccNo", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owChequeNo", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owAmount", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owChequeStatusID", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owChequeStatus", typeof(string));
            //dtOutwardReconsiliation.Columns.Add("owPanalty", typeof(string));
        }

        #endregion

        private void RefreshGridAllForReDeposit()
        {
            try
            {
                if (!bNoAccessReDepositFormID)
                {
                    sourceReDeposit.Filter = "";
                    dtReDeposit.Rows.Clear();
                    dgvReDeposit.Columns["SRSdate"].ValueType = typeof(DateTime);
                    dtReDeposit.Rows.Clear();

                    dtReDeposit.Merge(DBHandling.ExecQuery("exec sp_ChequeRegister_ToBeDeposit '" + clsSecurity.CompanyID + "','" + ((ComboBoxItem)cmbComBranch.SelectedItem).Value + "',1").Tables[0]);

                    sourceReDeposit.DataSource = dtReDeposit;
                    dgvReDeposit.DataSource = sourceReDeposit;
                    //changeGridChequeDeposit();
                    // CalculateCheque();
                    dgvReDeposit.Sort(this.dgvReDeposit.Columns["SRSdate"], ListSortDirection.Ascending);


                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllCashDeposite()
        {
            try
            {
                if (!bNoAccessCashDeposite)
                {
                    sourceCashDeposite.Filter = "";
                    dtCashDeposite.Rows.Clear();
                    dgvCashDeposite.Columns["CSdate"].ValueType = typeof(DateTime);
                    if (clsConfig.bAdvanceCashDepositeEnable)
                        dgvCashDeposite.Columns["DepositedAmount"].Visible = true;

                    //Sales Receipt
                    foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAll().Where(c => c.PaymentMethod_ID == (int)PaymentMethod.Cash && !c.IsDeleted && c.PosReceipt_ID == "default" && c.AccountReceipt_ID == "default" && c.CompanyID.ToUpper() == clsSecurity.CompanyID.ToUpper() && c.CompanyBranch_ID == ((ComboBoxItem)cmbComBranch.SelectedItem).Value))
                    {
                        if (detail != null)
                        {
                            if ((detail.Amount - detail.DepositedCashAmount) > 0)
                            {
                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                                dtCashDeposite.Rows.Add(false, detail.Receipt_ID, clsFormatter.FormatDate_Short(oReceipt.ReceiptDate),
                                    clsGenaralName.getName_Customer(detail.Customer_ID), clsFormatter.FormatDecimalPlaces_Price(detail.Amount - detail.DepositedCashAmount),
                                    clsFormatter.FormatDecimalPlaces_Price(detail.Amount - detail.DepositedCashAmount), oReceipt.InvoiceList, detail.DateRegister, 0);
                            }
                        }
                    }

                    // IReceipt
                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(c => c.CompanyID.ToUpper() == clsSecurity.CompanyID.ToUpper() && !c.IsDeleted && c.CompanyBranch_ID == ((ComboBoxItem)cmbComBranch.SelectedItem).Value && c.CashAmount > 0))
                    {
                        if (detail != null)
                        {
                            if ((detail.CashAmount - detail.DepositedCashAmount) > 0)
                            {
                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                                dtCashDeposite.Rows.Add(false, detail.Receipt_ID, clsFormatter.FormatDate_Short(oReceipt.ReceiptDate),
                                    clsGenaralName.getName_Customer(detail.Customer_ID), clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount - detail.DepositedCashAmount),
                                    clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount - detail.DepositedCashAmount), oReceipt.InvoiceList, detail.ReceiptDate, 0);
                            }
                        }
                    }

                    //Account Receipt
                    string sCustomerName = "";
                    if (clsConfig.bDisplayBankManagemnet_CashDeposit_Account)
                    {
                        foreach (tbl_accAccountReceipt detail in tbl_accAccountReceipt.SelectAll().Where(p => p.CashAmount > 0 && p.ChequeAmount == 0 && !p.IsDeleted && !p.IsCashDeposited))
                        {
                            if (detail.Customer_ID != "default")
                                sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                            else
                                sCustomerName = detail.Receivedof;

                            //dtCashDeposite.Rows.Add(false, detail.AccountReceipt_ID, clsFormatter.FormatDate_Short(detail.AccountReceiptDate), 
                            //    sCustomerName, clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount), 0, "", detail.AccountReceiptDate, 1);
                            dtCashDeposite.Rows.Add(false, detail.AccountReceipt_ID, clsFormatter.FormatDate_Short(detail.AccountReceiptDate),
                                sCustomerName, clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount - detail.DepositedCashAmount), clsFormatter.FormatDecimalPlaces_Price(detail.CashAmount - detail.DepositedCashAmount), "", detail.AccountReceiptDate, 1);
                        }
                    }

                    sourceCashDeposite.DataSource = dtCashDeposite;
                    dgvCashDeposite.DataSource = sourceCashDeposite;
                    dgvCashDeposite.Sort(this.dgvCashDeposite.Columns["CSdate"], ListSortDirection.Ascending);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridAllForDeposit()
        {
            try
            {
                if (!bNoAccessChequeDeposite)
                {
                    sourceChequeDeposit.Filter = "";
                    dtReIssue.Rows.Clear();
                    dgvDetail.Columns["Sdate"].ValueType = typeof(DateTime);
                    dtChequeDeposit.Rows.Clear();

                    dtChequeDeposit.Merge(DBHandling.ExecQuery("exec sp_ChequeRegister_ToBeDeposit '" + clsSecurity.CompanyID + "','" + ((ComboBoxItem)cmbComBranch.SelectedItem).Value + "',0").Tables[0]);

                    sourceChequeDeposit.DataSource = dtChequeDeposit;
                    dgvDetail.DataSource = sourceChequeDeposit;
                    //changeGridChequeDeposit();
                    CalculateCheque();
                    dgvDetail.Sort(this.dgvDetail.Columns["Sdate"], ListSortDirection.Ascending);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void RefreshGridAllForReIssue()
        {
            try
            {
                if (!bNoAccessReissue)
                {
                    sourceReIssue.Filter = "";
                    dtReIssue.Rows.Clear();
                    dgvDetail.Columns["Sdate"].ValueType = typeof(DateTime);
                    dtChequeDeposit.Rows.Clear();
                    List<vw_searchChequeRegister> details = vw_searchChequeRegister.SelectAll(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                    foreach (vw_searchChequeRegister detail in details)
                    {
                        if (detail.StatusName.Trim() == "New" && !detail.IsDeleted)
                        {
                            bool bDateOk = true;
                            string sReceviedFrom = "", sReceiptID = "";
                            if (chkGenDateRange.Checked)
                            {
                                if (detail.DateCheque.Date >= dtpGenChequeDateFrom.Value.Date && detail.DateCheque.Date <= dtpGenChequeDateTo.Value.Date)
                                    bDateOk = true;
                                else
                                    bDateOk = false;
                            }

                            if (bDateOk)
                            {
                                if (detail.AccountReceipt_ID != "default")
                                {
                                    tbl_accAccountReceipt oAccountReceipt = tbl_accAccountReceipt.Select(detail.AccountReceipt_ID);
                                    if (oAccountReceipt != null)
                                    {
                                        sReceiptID = oAccountReceipt.AccountReceipt_ID;
                                        sReceviedFrom = oAccountReceipt.Receivedof;
                                    }
                                }
                                else
                                {
                                    sReceiptID = detail.Receipt_ID;
                                    sReceviedFrom = detail.CustomerName;
                                }

                                dtReIssue.Rows.Add(false, detail.ChequeRegister_ID, sReceviedFrom, sReceiptID, detail.AccountNumber, detail.ChequeNumber,
                                clsFormatter.FormatDate_Short(detail.DateCheque).ToString(), clsFormatter.FormatDecimalPlaces_Price(detail.ChequeAmount).ToString(), detail.StatusName, detail.DateCheque);
                            }
                        }
                    }
                    sourceReIssue.DataSource = dtReIssue;
                    dgvDetail.DataSource = sourceReIssue;
                    dgvDetail.Sort(this.dgvDetail.Columns["Sdate"], ListSortDirection.Ascending);
                    //changeGridReIssue();
                    CalculateCheque();
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllForInwardReconsiliation()
        {
            try
            {
                if (!bNoAccessInwardReconsilation)
                {
                    sourceInwardReconsiliation.Filter = "";
                    dtInwardReconsiliation.Rows.Clear();
                    dgvInwardReconciliation.Columns["RCSdate"].ValueType = typeof(DateTime);

                    //DataGridViewCellStyle dgvcsNumaric = new DataGridViewCellStyle();
                    //dgvcsNumaric.Format = "N2";
                    //dgvcsNumaric.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dgvInwardReconciliation.Columns["reAmount"].DefaultCellStyle = dgvcsNumaric;

                    dtInwardReconsiliation.Merge(DBHandling.ExecQuery("exec sp_ChequeRegister_ToBeReconcile '" + clsSecurity.CompanyID + "','" + ((ComboBoxItem)cmbComBranch.SelectedItem).Value + "'").Tables[0]);

                    sourceInwardReconsiliation.DataSource = dtInwardReconsiliation;
                    dgvInwardReconciliation.DataSource = sourceInwardReconsiliation;
                    CalculateInwardChequeReconsiliation();
                    dgvInwardReconciliation.Sort(this.dgvInwardReconciliation.Columns["RCSdate"], ListSortDirection.Ascending);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllForOutwardReconsiliation()
        {
            try
            {
                if (!bNoAccessOutwardReconsilation)
                {
                    sourceOutwardReconsiliation.Filter = "";
                    dtOutwardReconsiliation.Rows.Clear();

                    #region OLD
                    //foreach (tbl_accChequeRegister detail in tbl_accChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default")) //TODO: Use Linq
                    //{
                    //    //Add tbl_accPaymentVoucher for filtering the company branch
                    //    //Gayan 2016-11-28

                    //    tbl_accPaymentVoucher oVoucher = tbl_accPaymentVoucher.Select(detail.PaymentVoucher_ID);
                    //    if (oVoucher != null && oVoucher.CompanyID.ToUpper() == clsSecurity.CompanyID.ToUpper() && oVoucher.CompanyBranch_ID == ((ComboBoxItem)cmbComBranch.SelectedItem).Value)
                    //    {
                    //        if (detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized)
                    //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C)
                    //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O)
                    //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R)
                    //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Default))
                    //        {
                    //            if (chkGenDateRange.Checked)
                    //            {
                    //                if (!detail.IsReconcilied)
                    //                {
                    //                    if (!(detail.DateCheque.Date >= dtpGenChequeDateFrom.Value.Date && detail.DateCheque.Date <= dtpGenChequeDateTo.Value.Date))
                    //                        continue;
                    //                }
                    //            }

                    //            string sDateDeposited = "", sBankName_AccNo = "";

                    //            DateTime ChequeDate = clsSecurity.getServerDateTime();

                    //            //if (!detail.IsReconcilied)
                    //            //{
                    //            sDateDeposited = clsFormatter.FormatDate_Short(detail.DateCheque).ToString();
                    //            if (detail.Bank_ID != null)
                    //                sBankName_AccNo = clsGenaralName.getName_Bank(detail.Bank_ID) + "-" + detail.AccountNumber;
                    //            //}
                    //            dtOutwardReconsiliation.Rows.Add(false, detail.ChequeRegister_ID, detail.DateCheque, detail.Payee, sBankName_AccNo, detail.ChequeNumber, clsFormatter.FormatDecimalPlaces_Price(detail.ChequeAmount).ToString(), detail.ChequeStatus_ID, clsGenaralName.getName_ChequeStatus(detail.ChequeStatus_ID), string.Empty);
                    //        }
                    //    }

                    //} 
                    #endregion

                    //dtOutwardReconsiliation.Merge(DBHandling.ExecQuery("exec sp_ChequeRegister_ToBeOutwardReconcile '" + clsSecurity.CompanyID + "','" + ((ComboBoxItem)cmbComBranch.SelectedItem).Value + "'").Tables[0]);
                    string GenDateRange = "0";
                    if (chkGenDateRange.Checked)
                        GenDateRange = "1";

                    dtOutwardReconsiliation.Merge(DBHandling.ExecQuery("exec sp_ChequeRegister_ToBeOutwardReconcile '" + clsSecurity.CompanyID + "','" + ((ComboBoxItem)cmbComBranch.SelectedItem).Value + "','" + GenDateRange + "','" + dtpGenChequeDateFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpGenChequeDateTo.Value.Date.ToString("yyyy-MM-dd") + "'").Tables[0]);

                    sourceOutwardReconsiliation.DataSource = dtOutwardReconsiliation;
                    CalculateOutwardChequeReconsiliation();
                    dgvOutwardReconciliation.Sort(this.dgvOutwardReconciliation.Columns["owChequeDate"], ListSortDirection.Ascending);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllForBEReconsiliation()
        {
            try
            {
                if (!bNoAccessBEReconsilation)
                {
                    sourceBEReconsiliation.Filter = "";
                    dtBEReconsiliation.Rows.Clear();
                    //    dgvDetail.Columns["Sdate"].ValueType = typeof(DateTime);
                    //   dtChequeDeposit.Rows.Clear();

                    dtBEReconsiliation.Merge(DBHandling.ExecQuery("exec [dbo].[sp_BE_ToBeEeconcile]").Tables[0]);

                    sourceBEReconsiliation.DataSource = dtBEReconsiliation;
                    dgvBEReconciliation.DataSource = sourceBEReconsiliation;
                    //changeGridChequeDeposit();
                    //  CalculateCheque();
                    //   dgvBEReconciliation.Sort(this.dgvDetail.Columns["beDate"], ListSortDirection.Ascending);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }



            //try
            //{
            //    if (!bNoAccessBEReconsilation)
            //    {
            //        sourceBEReconsiliation.Filter = "";
            //        dtBEReconsiliation.Rows.Clear();

            //        //foreach (tbl_bpsChequeReconcilation_BE detail in tbl_bpsChequeReconcilation_BE.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default")) //TODO: Use Linq
            //        //{
            //        //    //Add tbl_accPaymentVoucher for filtering the company branch
            //        //    //Gayan 2016-11-28

            //        //    tbl_accPaymentVoucher oVoucher = tbl_accPaymentVoucher.Select(detail.PaymentVoucher_ID);
            //        //    if (oVoucher != null && oVoucher.CompanyID.ToUpper() == clsSecurity.CompanyID.ToUpper() && oVoucher.CompanyBranch_ID == ((ComboBoxItem)cmbComBranch.SelectedItem).Value)
            //        //    {
            //        //        if (detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Realized)
            //        //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C)
            //        //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O)
            //        //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Returned_R)
            //        //                && detail.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Default))
            //        //        {
            //        //            if (chkGenDateRange.Checked)
            //        //            {
            //        //                if (!detail.IsReconcilied)
            //        //                {
            //        //                    if (!(detail.DateCheque.Date >= dtpGenChequeDateFrom.Value.Date && detail.DateCheque.Date <= dtpGenChequeDateTo.Value.Date))
            //        //                        continue;
            //        //                }
            //        //            }

            //        //            string sDateDeposited = "", sBankName_AccNo = "";

            //        //            DateTime ChequeDate = clsSecurity.getServerDateTime();

            //        //            //if (!detail.IsReconcilied)
            //        //            //{
            //        //            sDateDeposited = clsFormatter.FormatDate_Short(detail.DateCheque).ToString();
            //        //            if (detail.Bank_ID != null)
            //        //                sBankName_AccNo = clsGenaralName.getName_Bank(detail.Bank_ID) + "-" + detail.AccountNumber;
            //        //            //}
            //        //            dtOutwardReconsiliation.Rows.Add(false, detail.ChequeRegister_ID, detail.DateCheque, detail.Payee, sBankName_AccNo, detail.ChequeNumber, clsFormatter.FormatDecimalPlaces_Price(detail.ChequeAmount).ToString(), detail.ChequeStatus_ID, clsGenaralName.getName_ChequeStatus(detail.ChequeStatus_ID), string.Empty);
            //        //        }
            //        //    }

            //        //}
            //        sourceBEReconsiliation.DataSource = dtBEReconsiliation;
            //        //CalculateOutwardChequeReconsiliation();
            //        //dgvBEReconciliation.Sort(this.dgvBEReconciliation.Columns["beDate"], ListSortDirection.Ascending);
            //    }
            //    else
            //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    SEACCException.Show(ex);
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //}
        }
        private void RefreshGridAllForReIssueByIssueID(string sReIssueID)
        {
            try
            {
                sourceReIssue.Filter = "";
                dtReIssue.Rows.Clear();
                dtChequeDeposit.Rows.Clear();
                List<tbl_bpsChequeReIssue_Detail> details = tbl_bpsChequeReIssue_Detail.SelectAllByReIssue_ID(sReIssueID);
                foreach (tbl_bpsChequeReIssue_Detail detail in details)
                {
                    tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(detail.ChequeRegister_ID);
                    if (register != null && register.CompanyID.ToLower() == clsSecurity.CompanyID.ToLower() && register.CompanyBranch_ID == ((ComboBoxItem)cmbComBranch.SelectedItem).Value)
                    {
                        if (register.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            dtReIssue.Rows.Add(false, detail.ChequeRegister_ID, clsGenaralName.getName_Customer(register.Customer_ID), register.Receipt_ID, register.AccountNumber, register.ChequeNumber,
                               register.DateCheque.ToShortDateString(), register.Amount.ToString(), clsGenaralName.getName_ChequeStatus(register.ChequeStatus_ID));
                        }
                    }
                }
                sourceReIssue.DataSource = dtReIssue;
                dgvDetail.DataSource = sourceReIssue;
                //changeGridReIssue();
                CalculateCheque();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllForReconciliationByReconciliationID(string sReconciliationID)
        {
            try
            {
                sourceInwardReconsiliation.Filter = "";
                dtInwardReconsiliation.Rows.Clear();
                string sDepositDate = "", sBankName = "";
                List<tbl_bpsChequeReconciliation_Detail> details = tbl_bpsChequeReconciliation_Detail.SelectAllByReconciliation_ID(sReconciliationID);
                foreach (tbl_bpsChequeReconciliation_Detail detail in details)
                {
                    if (detail != null)
                    {
                        vw_searchBpsChequeDepositAndReIssue register = vw_searchBpsChequeDepositAndReIssue.Select(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, detail.ChequeRegister_ID);
                        if (register != null)
                        {
                            if (register.IsDepositted)
                            {
                                sDepositDate = register.DateDeposit.ToShortDateString();
                                sBankName = register.BankName;
                            }
                            else if (register.IsReIssued)
                            {
                                sDepositDate = register.DateReIssued.ToShortDateString();
                                sBankName = register.SupplierName;
                            }
                            dtInwardReconsiliation.Rows.Add(register.ChequeRegister_ID, false, sDepositDate, sBankName, register.CustomerName, register.AccountNumber, register.ChequeNumber, register.ChequeAmount.ToString(), "", register.StatusName, "0.00", clsSecurity.getServerDateTime());
                        }
                    }
                }
                sourceInwardReconsiliation.DataSource = dtInwardReconsiliation;
                CalculateInwardChequeReconsiliation();
                //     changeGridReconciliation();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGrid_ByBankName(string sBankName, bool bReturn)
        {
            try
            {
                sourceInwardReconsiliation.Filter = "";
                dtInwardReconsiliation.Rows.Clear();
                string sDepositDate = "", sBankName1 = "";
                List<vw_searchBpsChequeDepositAndReIssue> details = vw_searchBpsChequeDepositAndReIssue.SelectAllByBankName(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, sBankName);
                foreach (vw_searchBpsChequeDepositAndReIssue detail in details)
                {
                    if (!detail.IsReconcilied)
                    {
                        if (detail.IsDepositted || detail.IsReIssued)
                        {
                            bool bDateOk = true;
                            if (chkGenDepositDateRange.Checked)
                            {
                                if (detail.IsDepositted)
                                {
                                    if (detail.DateDeposit.Date >= dtpGenDepositDateFrom.Value.Date && detail.DateDeposit.Date <= dtpGenDepositDateTo.Value.Date) { }
                                    else
                                        bDateOk = false;
                                }
                                else if (detail.IsReIssued)
                                {
                                    if (detail.DateReIssued.Date >= dtpGenDepositDateFrom.Value.Date && detail.DateReIssued.Date <= dtpGenDepositDateTo.Value.Date) { }
                                    else
                                        bDateOk = false;
                                }
                            }
                            if (bDateOk)
                            {
                                if (detail.IsDepositted)
                                {
                                    sDepositDate = detail.DateDeposit.ToShortDateString();
                                    sBankName1 = detail.BankName;
                                }
                                else if (detail.IsReIssued)
                                {
                                    sDepositDate = detail.DateDeposit.ToShortDateString();
                                    sBankName1 = detail.BankName;
                                }
                                dtInwardReconsiliation.Rows.Add(detail.ChequeRegister_ID, false, sBankName1, detail.AccountNumber, detail.ChequeAmount.ToString(), detail.ChequeAmount.ToString(), detail.DateDeposit.ToShortDateString(), detail.StatusName);
                            }
                        }
                    }
                }
                sourceInwardReconsiliation.DataSource = dtInwardReconsiliation;
                CalculateInwardChequeReconsiliation();
                //changeGridReconciliation();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGrid_ByAccountNo(string sAccountNo, bool bReturn)
        {
            try
            {
                sourceInwardReconsiliation.Filter = "";
                dtInwardReconsiliation.Rows.Clear();
                List<vw_searchBpsChequeDepositAndReIssue> details = vw_searchBpsChequeDepositAndReIssue.SelectAllByAccountNo(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, sAccountNo);
                foreach (vw_searchBpsChequeDepositAndReIssue detail in details)
                {
                    if (!detail.IsReconcilied)
                    {
                        if (detail.IsDepositted || detail.IsReIssued)
                        {
                            bool bDateOk = true;
                            if (chkGenDepositDateRange.Checked)
                            {
                                if (detail.IsDepositted)
                                {
                                    if (detail.DateDeposit.Date >= dtpGenDepositDateFrom.Value.Date && detail.DateDeposit.Date <= dtpGenDepositDateTo.Value.Date) { }
                                    else
                                        bDateOk = false;
                                }
                                else if (detail.IsReIssued)
                                {
                                    if (detail.DateReIssued.Date >= dtpGenDepositDateFrom.Value.Date && detail.DateReIssued.Date <= dtpGenDepositDateTo.Value.Date) { }
                                    else
                                        bDateOk = false;
                                }
                            }
                            if (bDateOk)
                            {

                                string sBankName = "", sDepositDate = "";

                                if (detail.IsDepositted)
                                {
                                    sDepositDate = detail.DateDeposit.ToShortDateString();
                                    sBankName = detail.BankName;
                                }
                                else if (detail.IsReIssued)
                                {
                                    sDepositDate = detail.DateReIssued.ToShortDateString();
                                    sBankName = detail.SupplierName;
                                }
                                dtInwardReconsiliation.Rows.Add(detail.ChequeRegister_ID, false, sBankName, detail.AccountNumber, detail.ChequeNumber, detail.ChequeNumber, sDepositDate, detail.StatusName);

                            }
                        }
                    }
                }
                sourceInwardReconsiliation.DataSource = dtInwardReconsiliation;
                CalculateInwardChequeReconsiliation();
                //changeGridReconciliation();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllForDepositByDepositID(string sDepositID)
        {
            try
            {
                sourceChequeDeposit.Filter = "";
                dtReIssue.Rows.Clear();
                dtChequeDeposit.Rows.Clear();
                List<tbl_bpsChequeDeposit_Detail> details = tbl_bpsChequeDeposit_Detail.SelectAllByChequeDeposit_ID(sDepositID);
                foreach (tbl_bpsChequeDeposit_Detail detail in details)
                {
                    vw_searchChequeRegister register = vw_searchChequeRegister.Select(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, detail.ChequeRegister_ID);
                    if (register != null)
                    {
                        dtChequeDeposit.Rows.Add(true, detail.ChequeRegister_ID, register.CustomerName, register.Receipt_ID, register.AccountNumber, register.ChequeNumber,
                            clsFormatter.FormatDate_Short(register.DateCheque).ToString(), register.ChequeAmount.ToString(), register.StatusName);
                    }
                }
                sourceChequeDeposit.DataSource = dtChequeDeposit;
                dgvDetail.DataSource = sourceChequeDeposit;
                //changeGridChequeDeposit();
                CalculateCheque();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridAllForCashDepositByDepositID(string sCashDepositID)
        {
            try
            {
                sourceCashDeposite.Filter = "";
                dtCashDeposite.Rows.Clear();
                //dtChequeDeposit.Rows.Clear();
                tbl_bpsCashDeposit Hdetail = tbl_bpsCashDeposit.Select(sCashDepositID);
                if (Hdetail != null)
                {
                    List<tbl_bpsCashDeposit_Detail> details = tbl_bpsCashDeposit_Detail.SelectAllByCashDeposit_ID(sCashDepositID);
                    foreach (tbl_bpsCashDeposit_Detail detail in details)
                    {
                        if (detail != null)
                        {
                            tbl_bpsReceipt RDetial = tbl_bpsReceipt.Select(detail.Receipt_ID);
                            if (RDetial.CompanyID == clsSecurity.CompanyID && RDetial.CompanyBranch_ID == ((ComboBoxItem)cmbComBranch.SelectedItem).Value)
                                dtCashDeposite.Rows.Add(false, detail.Receipt_ID, RDetial.ReceiptDate, clsGenaralName.getName_Customer(RDetial.Customer_ID),
                                    Hdetail.TotalAmount, RDetial.InvoiceList, Hdetail.DateDeposit, RDetial.IsSalesReceipt);
                        }
                    }
                }
                sourceCashDeposite.DataSource = dtCashDeposite;
                dgvCashDeposite.DataSource = sourceCashDeposite;
                //changeGridChequeDeposit();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        #endregion

        #region Fill Details
        private void FillDetailsDeposit(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsChequeDeposit detail = tbl_bpsChequeDeposit.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateDeposit = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDepositID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDepositID, false);

                        //asign values                    
                        txtDepositBankName.Tag = detail.Bank_ID;
                        txtDepositBranchName.Tag = detail.Branch_ID;

                        txtDepositBankName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Bank(detail.Bank_ID));
                        txtDepositBranchName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BankBranch(detail.Branch_ID));
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));

                        txtDepositID.Text = detail.ChequeDeposit_ID;
                        txtDepositRemark.Text = detail.Remark;
                        dtpDepositDate.Value = detail.DateDeposit;
                        txtDepositAccountNo.Text = detail.AccountNumber;
                        txtDepositAccountHolder.Text = detail.AccountHolder;

                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

                        //RefreshGridAllForCashDepositByDepositID(detail.ChequeDeposit_ID);
                        RefreshGridAllForDepositByDepositID(detail.ChequeDeposit_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void FillDetailsCashDeposit(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsCashDeposit detail = tbl_bpsCashDeposit.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateCashDeposite = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCashDepositeID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCashDepositeID, false);

                        //asign values                    
                        txtDepositBankName.Tag = detail.Bank_ID;
                        txtDepositBranchName.Tag = detail.Branch_ID;

                        txtCashDepositeBankName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Bank(detail.Bank_ID));
                        txtCashDepositeBranchName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BankBranch(detail.Branch_ID));
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));

                        txtCashDepositeID.Text = detail.CashDeposit_ID;
                        txtCashDepositeRemarks.Text = detail.Remark;
                        dtpCashDepositeDate.Value = detail.DateDeposit;
                        txtCashDepositeAccountNo.Text = detail.AccountNumber;
                        //  txtcashDepositeAccountHolder.Text = detail.AccountHolder;

                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

                        RefreshGridAllForCashDepositByDepositID(detail.CashDeposit_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void FillDetailsReIssue(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsChequeReIssue detail = tbl_bpsChequeReIssue.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateReIssue = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReIssueID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblReIssueID, false);

                        //asign values
                        txtReIssueSupplierID.Tag = detail.Supplier_ID;
                        txtReIssueSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                        txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));

                        txtReIssueID.Text = detail.ReIssue_ID;
                        txtReIssueIssuerName.Text = detail.IssuerName;
                        txtReIssueNICNo.Text = detail.ReceiverNIC;
                        txtReIssueReceiverName.Text = detail.ReceiverName;
                        txtReIssueRemak.Text = detail.Remark;
                        dtpReIssueDate.Value = detail.DateReIssued;

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                            dtpDateApprovedBy.Value = detail.DateApproved;
                            dtpTimeApprovedBy.Value = detail.DateApproved;
                            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            dtpTimeCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                        }

                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;


                        RefreshGridAllForReIssueByIssueID(detail.ReIssue_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void FillDetailsInwardReConciliation(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsChequeReconciliation detail = tbl_bpsChequeReconciliation.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateInwardReConsiliation = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReconciliationIDIN, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblReconciliationID, false);

                        //asign values                    
                        txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                        txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));

                        txtReconciliationIDIN.Text = detail.Reconciliation_ID;
                        txtReconRemakIN.Text = detail.Remark;
                        dtpReconciliationDateIN.Value = detail.DateReconciliation;

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                            dtpDateApprovedBy.Value = detail.DateApproved;
                            dtpTimeApprovedBy.Value = detail.DateApproved;
                            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            dtpTimeCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                        }

                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

                        RefreshGridAllForReconciliationByReconciliationID(detail.Reconciliation_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void FillDetailsOutwardReConciliation(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_accChequeReconciliation detail = tbl_accChequeReconciliation.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdateOutwardReConsiliation = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReconciliationIDIN, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblReconciliationID, false);

                        //asign values                    
                        txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                        txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));

                        txtReconciliationIDIN.Text = detail.Reconciliation_ID;
                        txtReconRemakIN.Text = detail.Remark;
                        dtpReconciliationDateIN.Value = detail.DateReconciliation;

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                            dtpDateApprovedBy.Value = detail.DateApproved;
                            dtpTimeApprovedBy.Value = detail.DateApproved;
                            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            dtpTimeCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                        }

                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

                        RefreshGridAllForReconciliationByReconciliationID(detail.Reconciliation_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void FillBankAndBranch(string sAccountNo, TextBox DepositBankName, TextBox DepositBranchName)
        {
            try
            {
                tbl_genCompanyAccount Adetail = tbl_genCompanyAccount.Select(sAccountNo);

                tbl_zBank detail = tbl_zBank.Select(Adetail.Bank_ID);
                if (detail != null)
                {
                    DepositBankName.Text = detail.BankName;
                    DepositBankName.Tag = detail.Bank_ID;
                }
                tbl_zBankBranches details = tbl_zBankBranches.Select(Adetail.Branch_ID);
                if (detail != null)
                {
                    DepositBranchName.Text = details.BranchName;
                    DepositBranchName.Tag = details.Branch_ID;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Fill Account Detail

        private void FillAccountDetails(string sCustomerID, string sAccountID)
        {
            try
            {
                tbl_genCustomerAccount detail = tbl_genCustomerAccount.Select(sCustomerID, sAccountID);
                if (detail != null)
                {
                    txtGenBankID.Tag = detail.Bank_ID;
                    txtGenBankID.Text = clsGenaralName.getName_Bank(detail.Bank_ID);
                }
                else
                {
                    txtGenBankID.Tag = null;
                    txtGenBankID.Text = "";
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidityDeposit_EmptiField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtDepositAccountNo, "Account Number"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtDepositBankName, "Bank Name"))
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidityCashDeposit_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCashDepositeAccountNo, "Account Number"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtCashDepositeBankName, "Bank Name"))
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidityReDeposit()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtReDepositAccountName, "Account Number"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtReDepositBankName, "Bank Name"))
                    bStatus = true;
            }
            return bStatus;



        }
        private bool CheckNumberValidityDeposit()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtCountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Count";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtAmountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private bool CheckNumberValidityReDeposit()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtCountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Count";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtAmountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Amount";
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
        private bool CheckValidityReIssue()
        {
            string strMessage = "";
            bool bStatus = true;

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckNumberValidityReIssue()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtCountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Count";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtAmountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValidity_OutwordReconciliation()
        {
            bool bStatus = true;
            try
            {
                string strMessage = "";
                int iSelectedRowCount = 0;
                string sRegisterCode = "", sStatusID = "";

                foreach (DataGridViewRow row in dgvOutwardReconciliation.Rows)
                {
                    if (bool.Parse(dgvOutwardReconciliation["owIsSelect", row.Index].Value.ToString()))
                    {
                        iSelectedRowCount++;
                        sStatusID = "";
                        sRegisterCode = "";

                        sRegisterCode = dgvOutwardReconciliation["owRegisterCode", row.Index].Value.ToString();
                        tbl_accChequeRegister oCheque = tbl_accChequeRegister.Select(sRegisterCode);
                        if (oCheque != null)
                        {
                            if (dgvOutwardReconciliation["owChequeStatus", row.Index].Tag != null)
                                sStatusID = dgvOutwardReconciliation["owChequeStatus", row.Index].Tag.ToString();

                            if ((sStatusID == oCheque.ChequeStatus_ID) || sStatusID == "")
                            {
                                bStatus = false;
                                strMessage = "Please Change the cheque status <<" + oCheque.ChequeNumber + ">>";
                                break;
                            }
                        }
                        else
                        {
                            bStatus = false;
                            strMessage = "Invalid Cheque <<" + sRegisterCode + ">>";
                            break;
                        }
                    }
                }

                if (iSelectedRowCount == 0)
                {
                    bStatus = false;
                    strMessage = "Please select cheques to reconcile";
                }


                if (bStatus == false)
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        //private bool CheckValidityReconciliation()
        //{
        //    string strMessage = "";
        //    bool bStatus = true;

        //    if (bStatus == false)
        //        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    return bStatus;
        //}
        private bool CheckValidityGridSelection()
        {
            bool bStatus = false;
            try
            {
                foreach (DataGridViewRow row1 in dgvInwardReconciliation.Rows)
                {
                    bool cb = (bool)row1.Cells[0].FormattedValue;
                    if (cb == true)
                    {
                        bStatus = true;
                        break;
                    }
                }
                if (!bStatus)
                    MessageBox.Show("Please Tick the Checkbox to save......!", "Validation Error");

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

            return bStatus;
        }
        private bool CheckNumberValidityReconciliation()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtCountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Count";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtAmountChequeSelected.Text.Trim()))
                {
                    strMessage += "\n Selected Cheque Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckValidity_ReturnPosting()
        {
            bool bStatus = true;
            try
            {
                foreach (DataGridViewRow row in dgvInwardReconciliation.Rows)
                {
                    if (dgvInwardReconciliation["reIsSelect", row.Index].Value != null)
                    {
                        if (bool.Parse(dgvInwardReconciliation["reIsSelect", row.Index].Value.ToString()))
                        {
                            string sStatusID = "";
                            if (dgvInwardReconciliation["reChequeStatusID", row.Index].Value != null && dgvInwardReconciliation["reChequeStatusID", row.Index].Value.ToString().Trim() != "")
                                sStatusID = dgvInwardReconciliation["reChequeStatusID", row.Index].Value.ToString();

                            if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
                            {
                                //    tbl_bpsChequeDeposit_Detail oDeposit =tbl_bpsChequeDeposit_Detail.se
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return bStatus;
        }
        #endregion


        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKeyDeposit()
        {
            clsCommon.ValidateForeignKey(ref txtDepositBankName);
            clsCommon.ValidateForeignKey(ref txtDepositBranchName);
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);
        }
        private void ValidateEmptyForeignKeyReIssue()
        {
            clsCommon.ValidateForeignKey(ref txtReIssueSupplierID);
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);
        }
        private void ValidateEmptyForeignKeyReConciliation()
        {
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);
        }
        #endregion

        #region Get Colour For Cheque Types

        private Color GetColorForCheque(string sRegisterID)
        {
            Color col = Color.FromArgb(99, 50, 50);

            try
            {
                tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sRegisterID);
                if (detail != null)
                {
                    if (detail.ChequeStatus_ID != null && detail.ChequeStatus_ID.Length > 0)
                    {
                        if (detail.ChequeStatus_ID == "0")
                            col = clsFormatter.colorChequeNew;
                        else if (detail.ChequeStatus_ID == "1")
                            col = clsFormatter.colorChequeDeposited;
                        else if (detail.ChequeStatus_ID == "2")
                            col = clsFormatter.colorChequeReleasedToSup;
                        else if (detail.ChequeStatus_ID == "3")
                            col = clsFormatter.colorChequeRealized;
                        else if (detail.ChequeStatus_ID == "4")
                            col = clsFormatter.colorChequeReturned_R;
                        else if (detail.ChequeStatus_ID == "5")
                            col = clsFormatter.colorChequeReturned_NR_C;
                        else if (detail.ChequeStatus_ID == "6")
                            col = clsFormatter.colorChequeReturned_NR_O;
                        else if (detail.ChequeStatus_ID == "7")
                            col = clsFormatter.colorChequeReDeposit;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return col;
        }

        #endregion


        #region Events DataGrid
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sColName = "";
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex >= 0)
                sColName = dgv.Columns[e.ColumnIndex].Name;


            if (sColName == "RegisterCode" || sColName == "RTSRegisterCode" || sColName == "ReceiptID")
                Cursor = Cursors.Hand;
        }

        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            string sColName = "";
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex >= 0)
                sColName = dgv.Columns[e.ColumnIndex].Name;


            if (sColName == "RegisterCode" || sColName == "RTSRegisterCode" || sColName == "ReceiptID")
                Cursor = Cursors.Default;
        }

        private void dgvReturnToSender_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;


                if (sColName == "RegisterCode" || sColName == "RTSRegisterCode")
                {
                    string sRegisterID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                    tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sRegisterID);
                    if (detail != null)
                    {
                        frm_bpsChequeViewer cheque = new frm_bpsChequeViewer();
                        cheque.glbChequeRegisterID = detail.ChequeRegister_ID;
                        cheque.ShowDialog();
                    }
                }

                if (sColName == "ReceiptID" || sColName == "RTSReceiptID")
                {
                    //string sReceiptID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                    //tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
                    //if (detail != null)
                    //{
                    //    if (detail.IsSalesReceipt)
                    //    {
                    //        UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
                    //        frm.glbReceiptID = detail.Receipt_ID;
                    //        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, this.MdiParent);
                    //    }
                    //    else
                    //    {
                    //        UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.InterimReceipt);
                    //        frm.glbReceiptID = detail.Receipt_ID;
                    //        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, this.MdiParent);
                    //    }
                    //}
                }
            }
        }
        #endregion

        #region Events KeyDown
        private void txtGenBankID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CompanyBankID(txtGenBankID);
                if (txtGenBankID.TextLength > 0)
                    RefreshGrid_ByBankName(txtGenBankID.Text, true);
            }
        }
        private void txtDepositID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ChequeDeposit();
            }
        }
        private void txtGenAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AccountForDeposit(txtGenAccountID, txtDepositBankName, txtDepositBranchName);
                if (txtGenAccountID.TextLength > 0)
                    RefreshGrid_ByAccountNo(txtGenAccountID.Text.Trim(), true);
            }
        }
        private void txtDepositAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AccountForDeposit(txtDepositAccountNo, txtDepositBankName, txtDepositBranchName);
            }
        }
        private void txtDepositBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CompanyBankID(txtDepositBankName);
            }
        }
        private void txtDepositBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtDepositBankName.Tag != null && txtDepositBankName.Tag.ToString().Length > 0)
                    Search_CompanyBranchID(txtDepositBranchName, txtDepositBankName.Tag.ToString());
                else
                    Search_CompanyBranchID(txtDepositBranchName, "");
            }
        }
        private void txtReIssueID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ChequeReIssue();
            }
        }
        private void txtReIssueSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SupplierID();
            }
        }
        private void txtReconciliationIDIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ChequeInwardReconciliation();
            }
        }
        private void txtReconciliationIDOUT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ChequeOutwardReconciliation();
            }
        }
        private void txtReDepositBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CompanyBankID(txtReDepositBankName);
            }
        }
        private void txtReDepositBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtReDepositBankName.Tag != null && txtReDepositBankName.Tag.ToString().Length > 0)
                    Search_CompanyBranchID(txtReDepositBranchName, txtReDepositBankName.Tag.ToString());
                else
                    Search_CompanyBranchID(txtReDepositBranchName, "");
            }
        }
        private void txtReDepositAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AccountForDeposit(txtReDepositAccountName, txtReDepositBankName, txtReDepositBranchName);
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtGenBankID_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyBankID(txtGenBankID);
            if (txtGenBankID.TextLength > 0)
                RefreshGrid_ByBankName(txtGenBankID.Text, true);
        }
        private void txtDepositID_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeDeposit();
        }
        private void txtDepositAccountName_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountForDeposit(txtDepositAccountNo, txtDepositBankName, txtDepositBranchName);
        }
        private void txtDepositBankName_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyBankID(txtDepositBankName);
        }
        private void txtDepositBranchName_DoubleClick(object sender, EventArgs e)
        {
            if (txtDepositBankName.Tag != null && txtDepositBankName.Tag.ToString().Length > 0)
                Search_CompanyBranchID(txtDepositBranchName, txtDepositBankName.Tag.ToString());
            else
                Search_CompanyBranchID(txtDepositBranchName, "");
        }
        private void txtGenAccountID_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountForDeposit(txtGenAccountID, txtDepositBankName, txtDepositBranchName);
            if (txtGenAccountID.TextLength > 0)
                RefreshGrid_ByAccountNo(txtGenAccountID.Text.Trim(), true);
        }
        private void txtReIssueID_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeReIssue();
        }
        private void txtReIssueSupplierID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierID();
        }
        private void txtReconciliationIDIN_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeInwardReconciliation();
        }
        private void txtReconciliationIDOut_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeOutwardReconciliation();
        }
        private void txtReDepositBankName_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyBankID(txtReDepositBankName);
        }
        private void txtReDepositBranchName_DoubleClick(object sender, EventArgs e)
        {
            if (txtReDepositBankName.Tag != null && txtReDepositBankName.Tag.ToString().Length > 0)
                Search_CompanyBranchID(txtReDepositBranchName, txtReDepositBankName.Tag.ToString());
            else
                Search_CompanyBranchID(txtReDepositBranchName, "");
        }
        private void txtReDepositAccountName_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountForDeposit(txtReDepositAccountName, txtReDepositBankName, txtReDepositBranchName);
        }
        private void txtCashDepositeBankName_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_Bank(ref txtCashDepositeBankName);
        }
        private void txtCashDepositeBranchName_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_BankBranch(ref txtCashDepositeBranchName, txtCashDepositeBankName.Tag.ToString());

            clsSearch.Search_BankBranch(ref txtCashDepositeBranchName, txtCashDepositeBankName.Tag.ToString());

        }
        private void txtCashDepositeID_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_CashDeposite(ref txtCashDepositeID);
            clsSearch.Search_CashDeposite(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, ref txtCashDepositeID);
            FillDetailsCashDeposit(txtCashDepositeID.Tag.ToString());
        }
        private void txtCashDepositeID_KeyDown(object sender, KeyEventArgs e)
        {
            clsSearch.Search_CashDeposite(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value, ref txtCashDepositeID);
            FillDetailsCashDeposit(txtCashDepositeID.Tag.ToString());
        }
        private void txtCashDepositeAccountNo_DoubleClick(object sender, EventArgs e)
        {
            Search_AccountForDeposit(txtCashDepositeAccountNo, txtCashDepositeBankName, txtCashDepositeBranchName);
        }
        private void dgvCashDeposite_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            CalculateCashDeposaite();
        }
        private void dgvOutwardReconciliation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvOutwardReconciliation.Columns[e.ColumnIndex].Name;

                if (sColName == "owChequeStatus")
                {
                    #region Old search
                    //Form frmhelpsearch = new frmSearchMaster();
                    //clsSearch.passValue_ChequeStatus();
                    //frmhelpsearch.ShowDialog();
                    //if (frmSearchMaster.s_SearchText.Length > 0)
                    //    dgvOutwardReconciliation["owChequeStatus", e.RowIndex].Value = frmSearchMaster.s_SearchText;
                    //if (frmSearchMaster.s_SearchID.Length > 0)
                    //{
                    //    dgvOutwardReconciliation["owChequeStatus", e.RowIndex].Tag = frmSearchMaster.s_SearchID;
                    //    dgvOutwardReconciliation["owChequeStatusID", e.RowIndex].Value = frmSearchMaster.s_SearchID;
                    //} 
                    #endregion

                    string sStatusID = "", sStatusName = "";

                    clsSearch.ChequeStatus_Outward(ref sStatusName, ref sStatusID);

                    if (sStatusName.Length > 0)
                        dgvOutwardReconciliation["owChequeStatus", e.RowIndex].Value = sStatusName;
                    if (sStatusID.Length > 0)
                    {
                        dgvOutwardReconciliation["owChequeStatus", e.RowIndex].Tag = sStatusID;
                        dgvOutwardReconciliation["owChequeStatusID", e.RowIndex].Value = sStatusID;
                    }
                    dgvOutwardReconciliation["owIsSelect", e.RowIndex].Value = true;
                    calculateSelectedOutwardReconsiliationCheques();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Events SelectedIndexChange
        private void tbcChequeManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDate.Visible = true;

            if (tabControl.SelectedTab == tbpDeposit)
                SetFormForDeposit();
            else if (tabControl.SelectedTab == tbpCashDeposite)
                SetFormForCashDeposit();
            else if (tabControl.SelectedTab == tbpReIssue)
                SetFormForReIssue();
            else if (tabControl.SelectedTab == tbpInwardReconciliation)
                SetFormForInwardReconciliation();
            else if (tabControl.SelectedTab == tbpOutwardReconciliation)
                SetFormForOutwardReconciliation();
            else if (tabControl.SelectedTab == tbpBEReconcilation)
                SetFormForBEReconciliation();
            else if (tabControl.SelectedTab == tbpChequeReDeposit)
                SetFormForReDeposit();
        }
        #endregion

        #region Search Methods
        private void Search_ChequeDeposit()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ChequeDeposit(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtDepositID.Text = frmSearchTransaction.s_SearchID;
                    FillDetailsDeposit(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void Search_ChequeReIssue()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ChequeReIssue(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtReIssueID.Text = frmSearchTransaction.s_SearchID;
                    FillDetailsReIssue(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void Search_ChequeInwardReconciliation()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ChequeInwardReconciliation(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtReconciliationIDIN.Text = frmSearchTransaction.s_SearchID;
                    FillDetailsInwardReConciliation(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);

            }
        }
        private void Search_ChequeOutwardReconciliation()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ChequeOutwardReconciliation(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtReconciliationIDOUT.Text = frmSearchTransaction.s_SearchID;
                    FillDetailsOutwardReConciliation(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);

            }

        }
        private void Search_AccountForDeposit(TextBox myTextBox, TextBox DepositBankName, TextBox DepositBranchName)
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                //if (DepositBankName.Tag != null && DepositBankName.Tag.ToString().Length > 0 && DepositBranchName.Tag != null && DepositBranchName.Tag.ToString().Length > 0)
                //    clsSearch.passValue_CompanyAccountByBranchID(DepositBranchName.Tag.ToString());
                //else if (DepositBankName.Tag != null && DepositBankName.Tag.ToString().Length > 0)
                //    clsSearch.passValue_CompanyAccountByBankID(DepositBankName.Tag.ToString());
                //else
                clsSearch.passValue_CompanyAccount();

                frmhelpsearch.ShowDialog();
                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        myTextBox.Text = frmSearchTransaction.s_SearchID;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        myTextBox.Tag = frmSearchTransaction.s_SearchID;

                    FillBankAndBranch(myTextBox.Tag.ToString(), DepositBankName, DepositBranchName);
                }
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);

            }
        }
        private void Search_SupplierID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_SupplierMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtReIssueSupplierID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtReIssueSupplierID.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);

            }
        }
        private void Search_CompanyBankID(TextBox myTextBox)
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_BankCompany();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        myTextBox.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        myTextBox.Tag = frmSearchMaster.s_SearchID;
                }
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }
        private void Search_CompanyBranchID(TextBox myTextBox, string sBankID)
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                if (sBankID.Length > 0)
                    clsSearch.passValue_CompanyBankBranchesByBankID(sBankID);
                else
                    clsSearch.passValue_CompanyBankBranches();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        myTextBox.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        myTextBox.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);

            }
        }
        #endregion

        #region Set Form Design

        private void SetFormForDeposit()
        {
            try
            {
                pnlDate.Visible = false;
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = true;
                dgvInwardReconciliation.Visible = false;
                dgvOutwardReconciliation.Visible = false;
                dgvBEReconciliation.Visible = false;
                dgvReDeposit.Visible = false;
                dgvCashDeposite.Visible = false;

                ClearFieldsDeposit();

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenBankID, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenAccountID, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenBankID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGenAccountID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGenChequeNo, true);

                chkGenDepositDateRange.Enabled = false;
                clsCommon.SetEnableDisable_NormalLabel(lblDepositDate, false);
                chkGenDateRange.Enabled = true;
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, true);
                dtpGenChequeDateFrom.Enabled = true;
                dtpGenChequeDateTo.Enabled = true;
                dtpGenDepositDateFrom.Enabled = false;
                dtpGenDepositDateTo.Enabled = false;

                RefreshGridAllForDeposit();

                clsCommon.SetEnableDisable_NormalTextbox(txtAmount, true);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, true);

                txtReceiptID.Enabled = true;
                txtChequeDate.Enabled = true;
                txtCustomerID.Enabled = true;
                txtDepositDate.Enabled = false;
                ClearSerchTexBox(txtGenChequeNo);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SetFormForCashDeposit()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = false;
                dgvInwardReconciliation.Visible = false;
                dgvOutwardReconciliation.Visible = false;
                dgvBEReconciliation.Visible = false;
                dgvReDeposit.Visible = false;
                dgvCashDeposite.Visible = true;

                ClearFieldsCashDeposit();

                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtChequeDate, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtReceiptID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtCustomerID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtDepositDate, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtAmount, false);

                clsCommon.SetEnableDisable_NormalLabel(lblGenBankID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGenAccountID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGenChequeNo, false);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, false);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, false);

                txtReceiptID.Clear();

                if (clsConfig.bAdvanceCashDepositeEnable)
                {
                    txtTotDepAmount.Visible = true;
                    lblTotDepAmount.Visible = true;
                }

                clsCommon.SetEnableDisable_NormalTextbox(txtTotDepAmount, false);
                txtTotDepAmount.Text = "0.00";

                chkGenDepositDateRange.Enabled = false;
                clsCommon.SetEnableDisable_NormalLabel(lblDepositDate, false);
                chkGenDateRange.Enabled = true;
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, true);
                dtpGenChequeDateFrom.Enabled = true;
                dtpGenChequeDateTo.Enabled = true;
                dtpGenDepositDateFrom.Enabled = false;
                dtpGenDepositDateTo.Enabled = false;

                RefreshGridAllCashDeposite();
                CalculateCashDeposaiteTotal();
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SetFormForReDeposit()
        {
            try
            {
                pnlDate.Visible = false;
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = false;
                dgvInwardReconciliation.Visible = false;
                dgvOutwardReconciliation.Visible = false;
                dgvBEReconciliation.Visible = false;
                dgvReDeposit.Visible = true;
                dgvCashDeposite.Visible = false;

                ClearFieldsReDeposit();

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtReDepositID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblReDepositID, false);

                clsCommon.SetEnableDisable_NormalTextbox(txtAmount, false);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, false);

                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenChequeNo, true);

                chkGenDepositDateRange.Enabled = false;
                clsCommon.SetEnableDisable_NormalLabel(lblDepositDate, false);
                chkGenDateRange.Enabled = true;
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, true);
                dtpGenChequeDateFrom.Enabled = true;
                dtpGenChequeDateTo.Enabled = true;
                dtpGenDepositDateFrom.Enabled = false;
                dtpGenDepositDateTo.Enabled = false;

                txtReceiptID.Enabled = true;
                txtChequeDate.Enabled = true;
                txtCustomerID.Enabled = true;
                txtDepositDate.Enabled = false;

                RefreshGridAllForReDeposit();

                ClearSerchTexBox(txtGenChequeNo);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SetFormForReIssue()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = true;
                dgvInwardReconciliation.Visible = false;
                dgvOutwardReconciliation.Visible = false;
                dgvBEReconciliation.Visible = false;
                dgvReDeposit.Visible = false;
                dgvCashDeposite.Visible = false;

                ClearFieldsReIssue();

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenBankID, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenAccountID, false);
                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtAmount, false);

                clsCommon.SetEnableDisable_NormalLabel(lblGenBankID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGenAccountID, false);
                clsCommon.SetEnableDisable_NormalLabel(lblGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, false);

                chkGenDepositDateRange.Enabled = false;
                clsCommon.SetEnableDisable_NormalLabel(lblDepositDate, false);
                chkGenDateRange.Enabled = true;
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, true);
                dtpGenChequeDateFrom.Enabled = true;
                dtpGenChequeDateTo.Enabled = true;
                dtpGenDepositDateFrom.Enabled = false;
                dtpGenDepositDateTo.Enabled = false;

                txtReceiptID.Enabled = true;
                txtChequeDate.Enabled = true;
                txtCustomerID.Enabled = true;
                txtDepositDate.Enabled = false;

                RefreshGridAllForReIssue();
                ClearSerchTexBox(txtGenChequeNo);
                Cursor = Cursors.Default;
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SetFormForInwardReconciliation()
        {
            try
            {
                pnlDate.Visible = false;
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = false;
                dgvInwardReconciliation.Visible = true;
                dgvOutwardReconciliation.Visible = false;
                dgvBEReconciliation.Visible = false;
                dgvReDeposit.Visible = false;
                dgvCashDeposite.Visible = false;

                ClearFieldsInwardReconciliation();

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenBankID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenAccountID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtAmount, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenBankID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenAccountID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, true);

                chkGenDepositDateRange.Enabled = true;
                clsCommon.SetEnableDisable_NormalLabel(lblDepositDate, true);
                chkGenDateRange.Enabled = false;
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, false);
                dtpGenChequeDateFrom.Enabled = false;
                dtpGenChequeDateTo.Enabled = false;
                dtpGenDepositDateFrom.Enabled = true;
                dtpGenDepositDateTo.Enabled = true;

                txtReceiptID.Enabled = false;
                txtChequeDate.Enabled = false;
                txtCustomerID.Enabled = false;
                txtDepositDate.Enabled = true;

                RefreshGridAllForInwardReconsiliation();
                ClearSerchTexBox(txtGenChequeNo);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SetFormForOutwardReconciliation()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = false;
                dgvInwardReconciliation.Visible = false;
                dgvOutwardReconciliation.Visible = true;
                dgvBEReconciliation.Visible = false;
                dgvReDeposit.Visible = false;
                dgvCashDeposite.Visible = false;

                ClearFieldsOutwardReconciliation();

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenBankID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGenAccountID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtAmount, true);

                clsCommon.SetEnableDisable_NormalLabel(lblGenBankID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenAccountID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblGenChequeNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, true);

                chkGenDepositDateRange.Enabled = false;
                clsCommon.SetEnableDisable_NormalLabel(lblDepositDate, false);
                chkGenDateRange.Enabled = true;
                clsCommon.SetEnableDisable_NormalLabel(lblChequeDate, true);
                dtpGenChequeDateFrom.Enabled = true;
                dtpGenChequeDateTo.Enabled = true;
                dtpGenDepositDateFrom.Enabled = false;
                dtpGenDepositDateTo.Enabled = false;

                txtReceiptID.Enabled = false;
                txtChequeDate.Enabled = false;
                txtCustomerID.Enabled = false;
                txtDepositDate.Enabled = true;

                RefreshGridAllForOutwardReconsiliation();
                ClearSerchTexBox(txtGenChequeNo);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void SetFormForBEReconciliation()
        {
            try
            {
                pnlDate.Visible = false;
                Cursor = Cursors.WaitCursor;
                dgvDetail.Visible = false;
                dgvInwardReconciliation.Visible = false;
                dgvOutwardReconciliation.Visible = false;
                dgvBEReconciliation.Visible = true;
                dgvReDeposit.Visible = false;
                dgvCashDeposite.Visible = false;

                ClearFieldsBEReconciliation();

                RefreshGridAllForBEReconsiliation();
                ClearSerchTexBox(txtGenChequeNo);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Calculate Cheque
        private void CalculateCheque()
        {
            try
            {
                int iCount = 0;
                decimal dAmount = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        if (dgvDetail["RegisterCode", row.Index].Value != null && dgvDetail["RegisterCode", row.Index].Value.ToString().Length > 0)
                        {
                            iCount++;
                            if (dgvDetail["Amount", row.Index].Value != null && dgvDetail["Amount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvDetail["Amount", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvDetail["Amount", row.Index].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
                txtAmountCheques.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                txtCountCheques.Text = iCount.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }

        private void CalculateCashDeposaite()
        {
            try
            {
                #region Old
                //int iCount = 0;
                //decimal dAmount = 0;
                //foreach (DataGridViewRow row in dgvCashDeposite.Rows)
                //{
                //    try
                //    {
                //        if (dgvCashDeposite["Select", row.Index].Value != null && Convert.ToBoolean(dgvCashDeposite["Select", row.Index].Value) == true)
                //        {
                //            iCount++;
                //            if (dgvCashDeposite["Amounts", row.Index].Value != null && dgvCashDeposite["Amounts", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvCashDeposite["Amounts", row.Index].Value.ToString()))
                //                dAmount += decimal.Parse(dgvCashDeposite["Amounts", row.Index].Value.ToString());
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        clsValidate.WriteErrorLog("", iFormID,ex);
                //        SEACCException.Show(ex);
                //    }
                //}
                //txtAmountChequeSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                //txtCountChequeSelected.Text = iCount.ToString(); 
                #endregion

                int iCount = 0;
                decimal dAmount = 0;
                decimal dDepCashAmount = 0;
                foreach (DataGridViewRow row in dgvCashDeposite.Rows)
                {
                    try
                    {
                        if (dgvCashDeposite["Select", row.Index].Value != null && Convert.ToBoolean(dgvCashDeposite["Select", row.Index].Value) == true)
                        {
                            iCount++;
                            if (dgvCashDeposite["Amounts", row.Index].Value != null && dgvCashDeposite["Amounts", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvCashDeposite["Amounts", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvCashDeposite["Amounts", row.Index].Value.ToString());

                            if (dgvCashDeposite["DepositedAmount", row.Index].Value != null && dgvCashDeposite["DepositedAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvCashDeposite["DepositedAmount", row.Index].Value.ToString()))
                            {
                                dDepCashAmount += decimal.Parse(dgvCashDeposite["DepositedAmount", row.Index].Value.ToString());

                            }
                            else
                            {
                                //MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, "\n Deposited Amount"), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvCashDeposite["DepositedAmount", row.Index].Value = dgvCashDeposite["Amounts", row.Index].Value;
                                //break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
                txtAmountChequeSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                txtCountChequeSelected.Text = iCount.ToString();

                txtTotDepAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDepCashAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void CalculateInwardChequeReconsiliation()
        {
            try
            {
                int iCount = 0;
                decimal dAmount = 0;
                foreach (DataGridViewRow row in dgvInwardReconciliation.Rows)
                {
                    try
                    {
                        if (dgvInwardReconciliation["reRegisterCode", row.Index].Value != null && dgvInwardReconciliation["reRegisterCode", row.Index].Value.ToString().Length > 0)
                        {
                            iCount++;
                            if (dgvInwardReconciliation["reAmount", row.Index].Value != null && dgvInwardReconciliation["reAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvInwardReconciliation["reAmount", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvInwardReconciliation["reAmount", row.Index].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
                txtAmountCheques.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                txtCountCheques.Text = iCount.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void CalculateOutwardChequeReconsiliation()
        {
            try
            {
                int iCount = 0;
                decimal dAmount = 0;
                foreach (DataGridViewRow row in dgvOutwardReconciliation.Rows)
                {
                    try
                    {
                        if (dgvOutwardReconciliation["owRegisterCode", row.Index].Value != null && dgvOutwardReconciliation["owRegisterCode", row.Index].Value.ToString().Length > 0)
                        {
                            iCount++;
                            if (dgvOutwardReconciliation["owAmount", row.Index].Value != null && dgvOutwardReconciliation["owAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
                txtAmountCheques.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                txtCountCheques.Text = iCount.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void calculateSelectedCheques()
        {

            int iCount = 0;
            decimal dAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                try
                {
                    if (dgvDetail["IsSelected", row.Index].Value != null && dgvDetail["IsSelected", row.Index].Value.ToString().Length > 0)
                    {
                        if (bool.Parse(dgvDetail["IsSelected", row.Index].Value.ToString()) == true)
                        {
                            iCount++;
                            if (dgvDetail["Amount", row.Index].Value != null && dgvDetail["Amount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvDetail["Amount", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvDetail["Amount", row.Index].Value.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
            }
            txtAmountChequeSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            txtCountChequeSelected.Text = iCount.ToString();
        }

        private void calculateSelectedInwardReconsiliationCheques()
        {
            int iCount = 0, iRealized = 0, iReturnedR = 0, iReturnedNRC = 0, iReturnedNRO = 0;
            decimal dAmount = 0, dRealized = 0, dReturnedR = 0, dReturnedNRC = 0, dReturnedNRO = 0;
            foreach (DataGridViewRow row in dgvInwardReconciliation.Rows)
            {
                try
                {
                    if (dgvInwardReconciliation["reIsSelect", row.Index].Value != null && dgvInwardReconciliation["reIsSelect", row.Index].Value.ToString().Length > 0)
                    {
                        if (bool.Parse(dgvInwardReconciliation["reIsSelect", row.Index].Value.ToString()) == true)
                        {
                            if (dgvInwardReconciliation["reChequeStatus", row.Index].Value.ToString().Trim() == "Realized")
                            {
                                iRealized++;
                                if (dgvInwardReconciliation["reAmount", row.Index].Value != null && dgvInwardReconciliation["reAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvInwardReconciliation["reAmount", row.Index].Value.ToString()))
                                    dRealized += decimal.Parse(dgvInwardReconciliation["reAmount", row.Index].Value.ToString());
                            }
                            if (dgvInwardReconciliation["reChequeStatus", row.Index].Value.ToString().Trim() == "Returned [R]")
                            {
                                iReturnedR++;
                                if (dgvInwardReconciliation["reAmount", row.Index].Value != null && dgvInwardReconciliation["reAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvInwardReconciliation["reAmount", row.Index].Value.ToString()))
                                    dReturnedR += decimal.Parse(dgvInwardReconciliation["reAmount", row.Index].Value.ToString());
                            }
                            if (dgvInwardReconciliation["reChequeStatus", row.Index].Value.ToString().Trim() == "Returned [NR/C]")
                            {
                                iReturnedNRC++;
                                if (dgvInwardReconciliation["reAmount", row.Index].Value != null && dgvInwardReconciliation["reAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvInwardReconciliation["reAmount", row.Index].Value.ToString()))
                                    dReturnedNRC += decimal.Parse(dgvInwardReconciliation["reAmount", row.Index].Value.ToString());
                            }
                            if (dgvInwardReconciliation["reChequeStatus", row.Index].Value.ToString().Trim() == "Returned [NR/O]")
                            {
                                iReturnedNRO++;
                                if (dgvInwardReconciliation["reAmount", row.Index].Value != null && dgvInwardReconciliation["reAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvInwardReconciliation["reAmount", row.Index].Value.ToString()))
                                    dReturnedNRO += decimal.Parse(dgvInwardReconciliation["reAmount", row.Index].Value.ToString());
                            }
                            iCount++;
                            if (dgvInwardReconciliation["reAmount", row.Index].Value != null && dgvInwardReconciliation["reAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvInwardReconciliation["reAmount", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvInwardReconciliation["reAmount", row.Index].Value.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
            }
            txtAmountChequeSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            txtCountChequeSelected.Text = iCount.ToString();
        }

        private void calculateSelectedOutwardReconsiliationCheques()
        {
            int iCount = 0, iRealized = 0, iReturnedR = 0, iReturnedNRC = 0, iReturnedNRO = 0;
            decimal dAmount = 0, dRealized = 0, dReturnedR = 0, dReturnedNRC = 0, dReturnedNRO = 0;
            foreach (DataGridViewRow row in dgvOutwardReconciliation.Rows)
            {
                try
                {
                    if (dgvOutwardReconciliation["owIsSelect", row.Index].Value != null && dgvOutwardReconciliation["owIsSelect", row.Index].Value.ToString().Length > 0)
                    {
                        if (bool.Parse(dgvOutwardReconciliation["owIsSelect", row.Index].Value.ToString()) == true)
                        {
                            if (dgvOutwardReconciliation["owChequeStatus", row.Index].Value.ToString().Trim() == "Realized")
                            {
                                iRealized++;
                                if (dgvOutwardReconciliation["owAmount", row.Index].Value != null && dgvOutwardReconciliation["owAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString()))
                                    dRealized += decimal.Parse(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString());
                            }
                            if (dgvOutwardReconciliation["owChequeStatus", row.Index].Value.ToString().Trim() == "Returned [R]")
                            {
                                iReturnedR++;
                                if (dgvOutwardReconciliation["owAmount", row.Index].Value != null && dgvOutwardReconciliation["owAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString()))
                                    dReturnedR += decimal.Parse(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString());
                            }
                            if (dgvOutwardReconciliation["owChequeStatus", row.Index].Value.ToString().Trim() == "Returned [NR/C]")
                            {
                                iReturnedNRC++;
                                if (dgvOutwardReconciliation["owAmount", row.Index].Value != null && dgvOutwardReconciliation["owAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString()))
                                    dReturnedNRC += decimal.Parse(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString());
                            }
                            if (dgvOutwardReconciliation["owChequeStatus", row.Index].Value.ToString().Trim() == "Returned [NR/O]")
                            {
                                iReturnedNRO++;
                                if (dgvOutwardReconciliation["owAmount", row.Index].Value != null && dgvOutwardReconciliation["owAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString()))
                                    dReturnedNRO += decimal.Parse(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString());
                            }
                            iCount++;
                            if (dgvOutwardReconciliation["owAmount", row.Index].Value != null && dgvOutwardReconciliation["owAmount", row.Index].Value.ToString().Length > 0 && clsCommon.isCurrency(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString()))
                                dAmount += decimal.Parse(dgvOutwardReconciliation["owAmount", row.Index].Value.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
            }

            txtAmountChequeSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            txtCountChequeSelected.Text = iCount.ToString();
        }

        private void CalculateCashDeposaiteTotal()
        {
            try
            {
                int iCount = 0;
                decimal dAmount = 0;
                foreach (DataGridViewRow row in dgvCashDeposite.Rows)
                {
                    try
                    {
                        iCount++;
                        dAmount += decimal.Parse(dgvCashDeposite["Amounts", row.Index].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
                txtAmountCheques.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                txtCountCheques.Text = iCount.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyUp

        private void txtGenChequeNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                createFilterQuaryReturnToSender(txtGenChequeNo);
                createFilterQuaryChequeDeposit(txtGenChequeNo);
                createFilterReIssue(txtGenChequeNo);
                createFilterReconciliation(txtGenChequeNo);
                createFilterOutwardReconciliation(txtGenChequeNo);
                ClearSerchTexBox(txtGenChequeNo);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }
        private void txtReceiptID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuaryReturnToSender(txtReceiptID);
            createFilterQuaryChequeDeposit(txtReceiptID);
            createFilterReIssue(txtReceiptID);
            createFilterQuaryCashDeposit(txtReceiptID);

            ClearSerchTexBox(txtReceiptID);
        }
        private void txtChequeDate_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuaryReturnToSender(txtChequeDate);
            createFilterQuaryChequeDeposit(txtChequeDate);
            createFilterReIssue(txtChequeDate);
            ClearSerchTexBox(txtChequeDate);

        }
        private void txtDepositDate_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterReconciliation(txtDepositDate);
            ClearSerchTexBox(txtDepositDate);
            createFilterQuaryCashDeposit(txtDepositDate);
        }
        private void txtCustomerID_KeyUp(object sender, KeyEventArgs e)
        {
            //createFilterQuaryChequeDeposit(sender as TextBox);
            //createFilterReIssue(sender as TextBox);
            //ClearSerchTexBox(sender as TextBox);
            //createFilterReconciliation(sender as TextBox);
            //createFilterOutwardReconciliation(sender as TextBox);

            createFilterQuaryChequeDeposit(txtCustomerID);
            createFilterReIssue(txtCustomerID);
            ClearSerchTexBox(txtCustomerID);
            createFilterReconciliation(txtCustomerID);
            createFilterOutwardReconciliation(txtCustomerID);
            createFilterQuaryCashDeposit(txtCustomerID);
            createFilterQuaryReturnToSender(txtCustomerID);
        }

        private void txtBEDate_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterBEReconciliation(txtBEDate);
            ClearSerchTexBox(txtBEDate);
        }

        private void txtBEAmount_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterBEReconciliation(txtBEAmount);
            ClearSerchTexBox(txtBEAmount);
        }

        private void txtBENo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterBEReconciliation(txtBENo);
            ClearSerchTexBox(txtBENo);
        }

        #endregion

        #region Events ChackedChange

        private void chkGenDateRangeAndBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tbpDeposit)
                SetFormForDeposit();
            else if (tabControl.SelectedTab == tbpReIssue)
                SetFormForReIssue();
            else if (tabControl.SelectedTab == tbpInwardReconciliation)
                SetFormForInwardReconciliation();
            else if (tabControl.SelectedTab == tbpOutwardReconciliation)
                SetFormForOutwardReconciliation();
        }
        private void chkGenDepositDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tbpDeposit)
                SetFormForDeposit();
            else if (tabControl.SelectedTab == tbpReIssue)
                SetFormForReIssue();
            else if (tabControl.SelectedTab == tbpInwardReconciliation)
                SetFormForInwardReconciliation();
        }
        private void chkGenChequeNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenChequeNo.Checked)
            {
                txtGenChequeNo.Enabled = false;
            }
            else
            {
                txtGenChequeNo.Enabled = true;
                txtGenChequeNo.Text = "";
                sFilteQuary = "";
                createFilterQuaryChequeDeposit(txtGenChequeNo);
                createFilterQuaryReturnToSender(txtGenChequeNo);
                createFilterReIssue(txtGenChequeNo);
                createFilterReconciliation(txtGenChequeNo);
            }
        }

        #endregion

        #region Events Datagrid
        private void dgvReconciliation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string sColName = "", sChequeStatus = "", sChequeStatusID = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvInwardReconciliation.Columns[e.ColumnIndex].Name;

                if (sColName == "reChequeStatus")
                {
                    clsSearch.ChequeStatus(ref sChequeStatus, ref sChequeStatusID);

                    if (sChequeStatus.Length > 0)
                        dgvInwardReconciliation["reChequeStatus", e.RowIndex].Value = sChequeStatus;
                    if (sChequeStatusID.Length > 0)
                    {
                        dgvInwardReconciliation["reChequeStatus", e.RowIndex].Tag = sChequeStatusID;
                        dgvInwardReconciliation["reChequeStatusID", e.RowIndex].Value = sChequeStatusID;
                    }
                    dgvInwardReconciliation["reIsSelect", e.RowIndex].Value = true;
                    calculateSelectedInwardReconsiliationCheques();

                    //Form frmhelpsearch = new frmSearchMaster();
                    //clsSearch.passValue_ChequeStatus();
                    //frmhelpsearch.ShowDialog();

                    //if (frmSearchMaster.s_SearchText.Length > 0)
                    //    dgvInwardReconciliation["reChequeStatus", e.RowIndex].Value = frmSearchMaster.s_SearchText;
                    //if (frmSearchMaster.s_SearchID.Length > 0)
                    //{
                    //    dgvInwardReconciliation["reChequeStatus", e.RowIndex].Tag = frmSearchMaster.s_SearchID;
                    //    dgvInwardReconciliation["reChequeStatusID", e.RowIndex].Value = frmSearchMaster.s_SearchID;
                    //}
                    //dgvInwardReconciliation["reIsSelect", e.RowIndex].Value = true;
                    //calculateSelectedInwardReconsiliationCheques();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        //private void dgvReconciliation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    calculateSelectedInwardReconsiliationCheques();
        //}
        //private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        //string sRegisterCode = dgvDetail["RegisterCode", e.RowIndex].Value.ToString();
        //        //if (sRegisterCode.Length > 0)
        //        //{
        //        //    tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sRegisterCode);
        //        //    if (detail != null)
        //        //    {
        //        //        txtRTSCustomer.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
        //        //        txtRTSReceverName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
        //        //    }
        //        //    txtIssuerName.Text = clsSecurity.UserIDLoged;

        //        //}
        //    }
        //}
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dgvDetail_CellClick(dgvDetail, e);
        }

        private void dgvDetail_KeyUp(object sender, KeyEventArgs e)
        {
            calculateSelectedCheques();
        }
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateSelectedCheques();
        }

        #endregion


        #region Selected Chques Count
        private bool CheckSelectedChequeCount(DataGridView dgv)
        {
            bool bStatus = false, bSelected = false;
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (dgv.Name == "dgvDetail" && dgv["IsSelected", row.Index].Value != null)
                    {
                        if (bool.Parse(dgv["IsSelected", row.Index].Value.ToString()))
                            bStatus = true;
                    }
                    else if (dgv.Name == "dgvReDeposit" && dgv["RTSIsSelected", row.Index].Value != null)
                    {
                        bSelected = bool.Parse(dgv["RTSIsSelected", row.Index].Value.ToString());
                        if (bSelected)
                            bStatus = true;
                    }

                    else if (dgv.Name == dgvCashDeposite.Name && dgv["Select", row.Index].Value != null)
                    {
                        bSelected = bool.Parse(dgv["Select", row.Index].Value.ToString());
                        if (bSelected)
                            bStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        #endregion

        #region BindingSource Filtering

        private void createFilterQuaryReturnToSender(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == "txtGenChequeNo" && txtGenChequeNo.TextLength > 0)
                sTemp = " ChequeNo LIKE '%" + txtGenChequeNo.Text.Trim() + "%'";

            if (argText.Name == "txtChequeDate" && txtChequeDate.TextLength > 0)
                sTemp = " ChequeDate LIKE '%" + txtChequeDate.Text.Trim() + "%'";

            if (argText.Name == "txtCustomerID" && txtCustomerID.TextLength > 0)
                sTemp = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";

            if (argText.Name == "txtReceiptID" && txtReceiptID.TextLength > 0)
                sTemp = " ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            sourceReDeposit.Filter = "";
            if (sFilteQuary.Trim().Length > 0)
                sourceReDeposit.Filter = sFilteQuary;
            else
                sourceReDeposit.Filter = sTemp;
        }

        private void createFilterQuaryChequeDeposit(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == "txtGenChequeNo" && txtGenChequeNo.TextLength > 0)
                sTemp = " ChequeNo LIKE '%" + txtGenChequeNo.Text.Trim() + "%'";

            if (argText.Name == "txtChequeDate" && txtChequeDate.TextLength > 0)
                sTemp = " ChequeDate LIKE '%" + txtChequeDate.Text.Trim() + "%'";

            if (argText.Name == "txtCustomerID" && txtCustomerID.TextLength > 0)
                sTemp = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";

            if (argText.Name == "txtReceiptID" && txtReceiptID.TextLength > 0)
                sTemp = " ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";

            if (argText.Name == "txtAmount" && txtAmount.TextLength > 0)
                sTemp = " Amount LIKE '%" + txtAmount.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            //sourceChequeDeposit.Filter = "";
            if (sFilteQuary.Trim().Length > 0)
                sourceChequeDeposit.Filter = sFilteQuary;
            else
                sourceChequeDeposit.Filter = sTemp;

        }

        private void createFilterReIssue(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == "txtGenChequeNo" && txtGenChequeNo.TextLength > 0)
                sTemp = " ChequeNo LIKE '%" + txtGenChequeNo.Text.Trim() + "%'";

            if (argText.Name == "txtChequeDate" && txtChequeDate.TextLength > 0)
                sTemp = " ChequeDate LIKE '%" + txtChequeDate.Text.Trim() + "%'";

            if (argText.Name == "txtCustomerID" && txtCustomerID.TextLength > 0)
                sTemp = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";

            if (argText.Name == "txtReceiptID" && txtReceiptID.TextLength > 0)
                sTemp = " ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            sourceReIssue.Filter = "";
            if (sFilteQuary.Trim().Length > 0)
                sourceReIssue.Filter = sFilteQuary;
            else
                sourceReIssue.Filter = sTemp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    bool bIsSelected = false;
                    string sBankEntry_ID = "";

                    string sBErec_Id = clsAutocode.getAutoGeneratedCode(sFormConfigCodeBEReConsiliation);
                    try
                    {
                        bIsSelected = bool.Parse(dgvBEReconciliation["beIsSelect", row.Index].Value.ToString());
                    }
                    catch (Exception) { }

                    if (!bIsSelected)
                        continue;

                    if (dgvBEReconciliation["beID", row.Index].Value != null)
                        sBankEntry_ID = dgvBEReconciliation["beID", row.Index].Value.ToString();
                    if (sBankEntry_ID.Length > 0)
                    {
                        tbl_bpsBEReconcilation oBERec = new tbl_bpsBEReconcilation(sBErec_Id, dtpRecBE.Value.Date, "", sBankEntry_ID, clsSecurity.UserIDLoged,
                                                                               clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, true, true, false, true, "", "");
                        oBERec.Insert();

                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally { SetFormForBEReconciliation(); }

        }

        private void createFilterReconciliation(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == "txtGenChequeNo" && txtGenChequeNo.TextLength > 0)
                sTemp = " ChequeNo LIKE '%" + txtGenChequeNo.Text.Trim() + "%'";

            if (argText.Name == "txtDepositDate" && txtDepositDate.TextLength > 0)
                sTemp = " DepositDate LIKE '%" + txtDepositDate.Text.Trim() + "%'";

            if (argText.Name == "txtAmount" && txtAmount.TextLength > 0)
                sTemp = " Amount LIKE '%" + txtAmount.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            sourceInwardReconsiliation.Filter = "";

            if (sFilteQuary.Trim().Length > 0)
                sourceInwardReconsiliation.Filter = sFilteQuary;
            else
                sourceInwardReconsiliation.Filter = sTemp;

        }

        private void createFilterOutwardReconciliation(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == "txtGenChequeNo" && txtGenChequeNo.TextLength > 0)
                sTemp = " owChequeNo LIKE '%" + txtGenChequeNo.Text.Trim() + "%'";

            if (argText.Name == "txtChequeDate" && txtChequeDate.TextLength > 0)
                sTemp = " owChequeDate LIKE '%" + txtChequeDate.Text.Trim() + "%'";

            if (argText.Name == "txtAmount" && txtAmount.TextLength > 0)
                sTemp = " owAmount LIKE '%" + txtAmount.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            sourceOutwardReconsiliation.Filter = "";

            if (sFilteQuary.Trim().Length > 0)
                sourceOutwardReconsiliation.Filter = sFilteQuary;
            else
                sourceOutwardReconsiliation.Filter = sTemp;

        }

        private void createFilterQuaryCashDeposit(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == txtCustomerID.Name && txtCustomerID.TextLength > 0)
                sTemp = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";

            if (argText.Name == txtReceiptID.Name && txtReceiptID.TextLength > 0)
                sTemp = " ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";

            if (argText.Name == txtDepositDate.Name && txtDepositDate.TextLength > 0)
                sTemp = " ReceiptDate LIKE '%" + txtDepositDate.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            sourceCashDeposite.Filter = "";
            if (sFilteQuary.Trim().Length > 0)
                sourceCashDeposite.Filter = sFilteQuary;
            else
                sourceCashDeposite.Filter = sTemp;
        }

        private void createFilterBEReconciliation(TextBox argText)
        {
            string sTemp = "";
            string sFilteQuary = "";

            if (argText.Name == "txtBENo" && txtBENo.TextLength > 0)
                sTemp = " beID LIKE '%" + txtBENo.Text.Trim() + "%'";

            if (argText.Name == "txtBEDate" && txtBEDate.TextLength > 0)
                sTemp = " beDate LIKE '%" + txtBEDate.Text.Trim() + "%'";

            if (argText.Name == "txtBEAmount" && txtBEAmount.TextLength > 0)
                sTemp = " beAmount LIKE '%" + txtBEAmount.Text.Trim() + "%'";

            if (sTemp.Trim().Length > 0)
                sFilteQuary = sTemp;

            sourceBEReconsiliation.Filter = "";

            if (sFilteQuary.Trim().Length > 0)
                sourceBEReconsiliation.Filter = sFilteQuary;
            else
                sourceBEReconsiliation.Filter = sTemp;

        }
        #endregion

        #region Grid Color

        private void dtpGenChequeDateFromTo_ValueChanged(object sender, EventArgs e)
        {
            if (chkGenDateRange.Checked == true)
                chkGenDateRangeAndBranch_CheckedChanged(sender, e);
        }

        private void dtpGenDepositDateFromTo_ValueChanged(object sender, EventArgs e)
        {
            if (chkGenDepositDateRange.Checked == true)
                chkGenDepositDateRange_CheckedChanged(sender, e);
        }
        #endregion

        private void Refresh_BranchCmb()
        {
            cmbComBranch.Items.Clear();
            cmbComBranch.DisplayMember = "Value";
            cmbComBranch.ValueMember = "Text";

            foreach (tbl_genCompanyBranchMaster oDetail in tbl_genCompanyBranchMaster.SelectAll())
            {
                if (oDetail.CompanyBranch_ID != "default")
                    cmbComBranch.Items.Add(new ComboBoxItem(oDetail.CompanyBranch_ID, oDetail.BranchName));
            }
            if (cmbComBranch.Items.Count > 0)
                cmbComBranch.SelectedIndex = cmbComBranch.FindStringExact(clsSecurity.BranchName);
        }

        private void btnNewRTS_Click(object sender, EventArgs e)
        {
            SetFormForReDeposit();
        }

        private void dgvCashDeposite_CellEndEdit(object sender, DataGridViewCellEventArgs e)

        {


            //try
            //{                
            //    int iColIndex = 0;


            //    if (e.ColumnIndex >= 0)
            //        iColIndex = e.ColumnIndex;

            //    if (bool.Parse(dgvCashDeposite["Select", e.RowIndex].Value.ToString()))
            //    {
            //        //if (sColName == "DepositedAmount")
            //        if (iColIndex == 5)
            //        {
            //            dTotDepositedAmnt += decimal.Parse(dgvCashDeposite["DepositedAmount", e.RowIndex].Value.ToString());

            //        }
            //    }
            //    txtTotDepAmount.Text = dTotDepositedAmnt.ToString();
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //}
        }

        private void dgvCashDeposite_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvCashDeposite_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //clsEvent.SalesGrid_CellParsing(sender, e, dgvCashDeposite);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}

#region Update Auto Posting Document Tables
//private bool UpdateDocumentTables(string sDocumentID, string sAccSlot)
//{
//    bool bStatus = false;
//    if (sAccSlot == clsAutocode.getAccSlotID(AccSlot.CashDeposit).ToString())
//    {
//        #region Cash Deposit
//        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sDocumentID);
//        tbl_accAccountReceipt oAR = tbl_accAccountReceipt.Select(sDocumentID);
//        if (oReceipt != null)
//        {
//            oReceipt.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
//            oReceipt.Update();
//            bStatus = true;
//        }
//        else if (oAR != null)
//        {
//            oAR.PostingStatus_CashDeposit = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
//            oAR.Update();
//            bStatus = true;
//        }
//        #endregion
//    }
//    if (sAccSlot == clsAutocode.getAccSlotID(AccSlot.ChequeDeposit).ToString())
//    {
//        #region Cheque Deposit
//        tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sDocumentID);
//        if (detail != null)
//        {
//            detail.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
//            detail.Update();
//            bStatus = true;
//        }
//        #endregion
//    }
//    if (sAccSlot == clsAutocode.getAccSlotID(AccSlot.ChequeReturned).ToString())
//    {
//        #region Cheque Returned
//        tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sDocumentID);
//        if (detail != null)
//        {
//            detail.PostingStatus_ChequeReturned = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
//            detail.Update();
//            bStatus = true;
//        }
//        #endregion
//    }
//    return bStatus;
//}
#endregion

#region Cheque deposit fill
//List<vw_searchChequeRegister> details = vw_searchChequeRegister.SelectAll(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
//foreach (vw_searchChequeRegister detail in details)
//{
//    if (!detail.IsDepositted && !detail.IsDeleted && !detail.IsReconcilied && !detail.IsReturned && !detail.IsReturnedToSender && detail.ChequeStatus_ID == "0")
//    {
//        bool bDateOk = true;
//        string sReceviedFrom = "", sReceiptID = "";
//        if (chkGenDateRange.Checked)
//        {
//            if (detail.DateCheque.Date >= dtpGenChequeDateFrom.Value.Date && detail.DateCheque.Date <= dtpGenChequeDateTo.Value.Date)
//                bDateOk = true;
//            else
//                bDateOk = false;
//        }

//        if (bDateOk)
//        {
//            if (detail.AccountReceipt_ID != "default")
//            {
//                tbl_accAccountReceipt oAccountReceipt = tbl_accAccountReceipt.Select(detail.AccountReceipt_ID);
//                if (oAccountReceipt != null)
//                {
//                    if (!clsConfig.bDisplayBankManagemnet_ChequeDeposit_Account)
//                        continue;
//                    sReceiptID = oAccountReceipt.AccountReceipt_ID;
//                    sReceviedFrom = oAccountReceipt.Receivedof;
//                }
//            }
//            else
//            {
//                sReceiptID = detail.Receipt_ID;
//                sReceviedFrom = detail.CustomerName;
//            }

//            dtChequeDeposit.Rows.Add(false, detail.ChequeRegister_ID, sReceviedFrom, sReceiptID, detail.AccountNumber, detail.ChequeNumber,
//                clsFormatter.FormatDate_Short(detail.DateCheque), detail.ChequeAmount.ToString(), detail.StatusName, detail.DateCheque);
//        }
//    }
//} 
#endregion

#region cheque return posting
//bool bPostingStatus = false, bPostingStatus2 = false, bPostingStatus3 = false;
//string sCusSupEmpName = "", sMainTransactionID = "";
//string sCustomerGL_ID = "", sPostingID = "", sNarration = "CHEQ.RETURNDED : ";

//#region Insert Posting Header
//sPostingID = clsProcessMethods.GLPostingPosting(clsSecurity.getServerDateTime(), "Cheque Returned", "default", false, "default");
//#endregion

//tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sChequeRegCode);
//if (register != null)
//{
//    #region Insert Posting Details
//    sCustomerGL_ID = clsMethods_GL.getAccountCode_Bank(register.DepositedAccountNumber).Length > 0 ? clsMethods_GL.getAccountCode_Bank(register.DepositedAccountNumber).Trim() : "";
//    if (sCustomerGL_ID != "default")
//    {
//        tbl_accGLMaster_Bank GLBankdetail = tbl_accGLMaster_Bank.Select(sCustomerGL_ID, register.DepositedAccountNumber);
//        if (GLBankdetail != null)
//        {
//            int iLine = 0;
//            if (register.Receipt_ID != "default")
//            {
//                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(register.Receipt_ID);
//                if (oReceipt != null)
//                {
//                    sMainTransactionID = oReceipt.Receipt_ID;
//                    sCusSupEmpName = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
//                    //sNarration = bpsSabeelReceipt.Remarks;
//                }
//            }
//            else if (register.AccountReceipt_ID != "default")
//            {
//                tbl_accAccountReceipt accAccountReceipts = tbl_accAccountReceipt.Select(register.AccountReceipt_ID);
//                if (accAccountReceipts != null)
//                {
//                    sMainTransactionID = register.AccountReceipt_ID;
//                    sCusSupEmpName = accAccountReceipts.Receivedof;
//                    //sNarration = accAccountReceipts.Narration;
//                }
//            }

//            string sDebitAccountGLCode = "";
//            List<tbl_accGLPosting_Detail> oPosts = tbl_accGLPosting_Detail.SelectAllByTransaction_ID(register.ChequeRegister_ID);
//            foreach (tbl_accGLPosting_Detail oPost in oPosts)
//            {
//                if (oPost.Slot_ID == clsAutocode.getAccSlotID(AccSlot.AdvancePaymentReceipt_Cheque) || oPost.Slot_ID == clsAutocode.getAccSlotID(AccSlot.PartPaymentReceiptCheque) || oPost.Slot_ID == clsAutocode.getAccSlotID(AccSlot.AccountReceipt))
//                {
//                    if (oPost.IsCredit)
//                        sDebitAccountGLCode = oPost.Gl_ID;
//                }
//            }
//            if (sDebitAccountGLCode.Length > 0)
//            {
//                //Credit Transaction
//                bPostingStatus = clsProcessMethods.GLPostingDetail(iLine, sPostingID, "default", clsAutocode.getAccSlotID(AccSlot.ChequeReturned), sChequeRegCode, GLBankdetail.Gl_ID, "default", "default", "default", "default", "default", "default", sCusSupEmpName, sChequeRegCode, sMainTransactionID, dDate, sNarration, register.ChequeAmount, true, register.ChequeNumber, sCusSupEmpName);

//                //Debit Transaction
//                iLine++;
//                bPostingStatus2 = clsProcessMethods.GLPostingDetail(iLine, sPostingID, "default", clsAutocode.getAccSlotID(AccSlot.ChequeReturned), sChequeRegCode, sDebitAccountGLCode, "default", "default", "default", "default", "default", "default", sCusSupEmpName, sChequeRegCode, sMainTransactionID, dDate, sNarration, register.ChequeAmount, false, register.ChequeNumber, sCusSupEmpName);
//            }
//            else
//                MessageBox.Show("There is no Debit Account Code For this Cheque Detail" + sChequeRegCode, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);


//            if (bPostingStatus && bPostingStatus2)
//            {
//                bPostingStatus3 = UpdateDocumentTables(sChequeRegCode, clsAutocode.getAccSlotID(AccSlot.ChequeReturned).ToString());
//                if (bPostingStatus3)
//                    bStatus = true;
//                //iCount++;
//            }


//            /*  //Don't use this code
//            //Credit Transaction
//            bPostingStatus = clsProcessMethods.GLPostingDetail(iLine, sPostingID, sbatchPostingID, clsAutocode.getAccSlotID(AccSlot.ChequeReturned), sChequeRegCode, GLBankdetail.Gl_ID, "default", "default", "default", "default", "default", "default", sCusSupEmpName, sChequeRegCode, sMainTransactionID, dDate, sNarration, register.ChequeAmount, true, register.ChequeNumber, register.Remark);

//            List<tbl_accDoubleEntrySlotDetails> oSlots = tbl_accDoubleEntrySlotDetails.SelectAllBySlot_ID(clsAutocode.getAccSlotID(AccSlot.ChequeReturned));
//            foreach (tbl_accDoubleEntrySlotDetails oSlot in oSlots)
//            {
//                iLine++;

//                //Debit Transaction                            
//                bPostingStatus2 = clsProcessMethods.GLPostingDetail(iLine, sPostingID, sbatchPostingID, clsAutocode.getAccSlotID(AccSlot.ChequeReturned), sChequeRegCode, oSlot.Gl_ID, "default", "default", "default", "default", "default", "default", sCusSupEmpName, sChequeRegCode, sMainTransactionID, dDate, sNarration, register.ChequeAmount, false, register.ChequeNumber, register.Remark);
//            }

//            if (bPostingStatus && bPostingStatus2)
//            {
//                bPostingStatus3 = UpdateDocumentTables(sChequeRegCode, clsAutocode.getAccSlotID(AccSlot.ChequeReturned).ToString());
//                if (bPostingStatus3)
//                    bStatus = true;
//            }*/
//        }
//        else
//        {
//            MessageBox.Show("Please Link Bank GL Code(s)", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//            //break;
//        }
//    }  
//    #endregion
//} 
#endregion

#region Btn Print Recon


#endregion

#region Btn Print ReIssue




#endregion

#region MyRegion
//dtChequeDeposit.Columns.Add("IsSelected");
//dtChequeDeposit.Columns.Add("RegisterCode", typeof(string));
//dtChequeDeposit.Columns.Add("CustomerName", typeof(string));
//dtChequeDeposit.Columns.Add("ReceiptID", typeof(string));
//dtChequeDeposit.Columns.Add("AccountNo", typeof(string));
//dtChequeDeposit.Columns.Add("ChequeNo", typeof(string));
//dtChequeDeposit.Columns.Add("ChequeDate", typeof(string));
//dtChequeDeposit.Columns.Add("Amount", typeof(string));
//dtChequeDeposit.Columns.Add("GridChequeStatus", typeof(string));
//dtChequeDeposit.Columns.Add("Sdate", typeof(DateTime));

//dtReDeposit.Columns.Add("RTSIsSelected", typeof(bool));
//dtReDeposit.Columns.Add("RTSRegisterCode", typeof(string));
//dtReDeposit.Columns.Add("RTSCustomerName", typeof(string));
//dtReDeposit.Columns.Add("RTSReceiptID", typeof(string));
//dtReDeposit.Columns.Add("RTSAccountNo", typeof(string));
//dtReDeposit.Columns.Add("RTSChequeNo", typeof(string));
//dtReDeposit.Columns.Add("RTSChequeDate", typeof(string));
//dtReDeposit.Columns.Add("RTSAmount", typeof(string));
//dtReDeposit.Columns.Add("RTSGridChequeStatus", typeof(string));
//dtReDeposit.Columns.Add("SRSdate", typeof(DateTime));

//dtInwardReconsiliation.Columns.Add("reRegisterCode", typeof(string));
//dtInwardReconsiliation.Columns.Add("reIsSelect", typeof(bool));
//dtInwardReconsiliation.Columns.Add("reDepositDate", typeof(string));
//dtInwardReconsiliation.Columns.Add("reBankName", typeof(string));
//dtInwardReconsiliation.Columns.Add("reCustomerName", typeof(string));
//dtInwardReconsiliation.Columns.Add("reAccountNo", typeof(string));
//dtInwardReconsiliation.Columns.Add("reDepositedAccNo", typeof(string));
//dtInwardReconsiliation.Columns.Add("reChequeNo", typeof(string));
//dtInwardReconsiliation.Columns.Add("reChequeDate", typeof(string));
//dtInwardReconsiliation.Columns.Add("reAmount", typeof(string));
//dtInwardReconsiliation.Columns.Add("reChequeStatusID", typeof(string));
//dtInwardReconsiliation.Columns.Add("reChequeStatus", typeof(string));
//dtInwardReconsiliation.Columns.Add("rePanalty", typeof(string));
//dtInwardReconsiliation.Columns.Add("RCSdate", typeof(string)); 
#endregion

#region refresh grid redeposit
//sourceReDeposit.Filter = "";
//dtReDeposit.Rows.Clear();
//dgvReDeposit.Columns["SRSdate"].ValueType = typeof(DateTime);
//List<vw_searchChequeRegister> details = vw_searchChequeRegister.SelectAll(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value);
//foreach (vw_searchChequeRegister detail in details)
//{
//    if (detail.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R))
//    {
//        bool bDateOk = true;
//        string sReceviedFrom = "", sReceiptID = "";
//        if (chkGenDateRange.Checked)
//        {
//            if (detail.DateCheque.Date >= dtpGenChequeDateFrom.Value.Date && detail.DateCheque.Date <= dtpGenChequeDateTo.Value.Date)
//                bDateOk = true;
//            else
//                bDateOk = false;
//        }

//        if (bDateOk)
//        {
//            if (detail.AccountReceipt_ID != "default")
//            {
//                tbl_accAccountReceipt oAccountReceipt = tbl_accAccountReceipt.Select(detail.AccountReceipt_ID);
//                if (oAccountReceipt != null)
//                {
//                    sReceiptID = oAccountReceipt.AccountReceipt_ID;
//                    sReceviedFrom = oAccountReceipt.Receivedof;
//                }
//            }
//            else
//            {
//                sReceiptID = detail.Receipt_ID;
//                sReceviedFrom = detail.CustomerName;
//            }

//            dtReDeposit.Rows.Add(false, detail.ChequeRegister_ID, sReceviedFrom, sReceiptID, detail.AccountNumber,
//            detail.ChequeNumber, clsFormatter.FormatDate_Short(detail.DateCheque).ToString(), detail.ChequeAmount.ToString(), detail.StatusName, detail.DateCheque);
//        }
//    }
//}
//sourceReDeposit.DataSource = dtReDeposit;
////changeGridColorReturnToSender();
//CalculateCheque();
//dgvReDeposit.Sort(this.dgvReDeposit.Columns["SRSdate"], ListSortDirection.Ascending); 
#endregion

#region refresh grid inward reconcilation
//sourceInwardReconsiliation.Filter = "";
//dtInwardReconsiliation.Rows.Clear();
//dgvInwardReconciliation.Columns["RCSdate"].ValueType = typeof(DateTime);

//DataTable dt_Result = DBHandling.ExecQuery("exec sp_ChequeRegisterSelectAll_WithDepositedAccount '" + clsSecurity.CompanyID + "' , '" + ((ComboBoxItem)cmbComBranch.SelectedItem).Value + "'").Tables[0];
//foreach (DataRow row in dt_Result.Select("(chequeStatus_ID ='" + clsAutocode.getChequeStatusID(ChequeStatus.Deposited) + "' OR chequeStatus_ID = '" + clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited) + "') AND isDeleted = false AND isDepositted =true "))
//{
//    DateTime dDepositedDate = clsValidate.ValidateRowValue(row, "dateDeposited", DateTime.Now);
//    DateTime dChequeDate = clsValidate.ValidateRowValue(row, "dateCheque", DateTime.Now);

//    bool bDateOk = true;
//    if (chkGenDepositDateRange.Checked)
//    {
//        if (dDepositedDate.Date >= dtpGenDepositDateFrom.Value.Date && dDepositedDate.Date <= dtpGenDepositDateTo.Value.Date) { }
//        else
//            bDateOk = false;
//    }
//    if (bDateOk)
//    {
//        string sDateDeposited = "", sDateReconciliation = "", sBankName = "", sChequeRegister_ID = "", sStatusID = "", sStatusName = "", sChequeNumber = "", sDateCheque = "",sChequeAmount = "", sAccountNumber = "", sDepositedAccNo = "", sPaneltyAmt = "", sCustomerName = string.Empty;//sDateReIssued = "",

//        sDateDeposited = clsFormatter.FormatDate_Short(dDepositedDate).ToString();
//        sDateReconciliation = clsFormatter.FormatDate_Short(clsValidate.ValidateRowValue(row, "dateReconcilied", DateTime.Now)).ToString();
//        sBankName = clsValidate.ValidateRowValue(row, "bankName", "-");
//        sCustomerName = clsValidate.ValidateRowValue(row, "customerName", "-");
//        sChequeRegister_ID = clsValidate.ValidateRowValue(row, "chequeRegister_ID", "-");
//        sChequeNumber = clsValidate.ValidateRowValue(row, "chequeNumber", "-");
//        sDateCheque = clsFormatter.FormatDate_Short(dChequeDate).ToString();
//        sChequeAmount = clsFormatter.FormatDecimalPlaces_UnitPrice(clsValidate.ValidateRowValue(row, "chequeAmount", 0));
//        sStatusID = clsValidate.ValidateRowValue(row, "chequeStatus_ID", "default");
//        sStatusName = clsValidate.ValidateRowValue(row, "statusName", "default");
//        sAccountNumber = clsValidate.ValidateRowValue(row, "accountNumber", "-");
//        sDepositedAccNo = clsValidate.ValidateRowValue(row, "depositedAccountNumber", "-");
//        sPaneltyAmt = clsFormatter.FormatDecimalPlaces_UnitPrice(clsValidate.ValidateRowValue(row, "paneltyAmount", 0));

//        dtInwardReconsiliation.Rows.Add(sChequeRegister_ID, false, sDateDeposited, sBankName, sCustomerName, sAccountNumber, sDepositedAccNo, sChequeNumber, sDateCheque, sChequeAmount, sStatusID, sStatusName, sPaneltyAmt, sDateReconciliation);
//    }
//    sourceInwardReconsiliation.DataSource = dtInwardReconsiliation;
//    CalculateInwardChequeReconsiliation();
//    dgvInwardReconciliation.Sort(this.dgvInwardReconciliation.Columns["RCSdate"], ListSortDirection.Ascending);

//}

//foreach (vw_searchChequeRegister detail in vw_searchChequeRegister.SelectAll(clsSecurity.CompanyID, ((ComboBoxItem)cmbComBranch.SelectedItem).Value).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && p.IsDepositted
//    && (p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Deposited) || p.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.ReDeposited))))
//{
//    bool bDateOk = true;
//    if (chkGenDepositDateRange.Checked)
//    {
//        if (detail.DateDeposited.Date >= dtpGenDepositDateFrom.Value.Date && detail.DateDeposited.Date <= dtpGenDepositDateTo.Value.Date) { }
//        else
//            bDateOk = false;
//    }

//    if (bDateOk)
//    {
//        string sDateDeposited = "", sDateReconciliation = "", sBankName = "", sChequeRegister_ID = "", sStatusID = "", sStatusName = "", sChequeNumber = "", sChequeAmount = "", sAccountNumber = "", sDepositedAccNo = "", sCustomerName = string.Empty;//sDateReIssued = "",

//        sDateDeposited = clsFormatter.FormatDate_Short(detail.DateDeposited).ToString();
//        sDateReconciliation = clsFormatter.FormatDate_Short(detail.DateReconcilied).ToString();
//        sBankName = detail.BankName;
//        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
//        sChequeRegister_ID = detail.ChequeRegister_ID;
//        sChequeNumber = detail.ChequeNumber;
//        sChequeAmount = clsFormatter.FormatDecimalPlaces_UnitPrice(detail.ChequeAmount);
//        sStatusID = detail.ChequeStatus_ID;
//        sStatusName = detail.StatusName;
//        sAccountNumber = detail.AccountNumber;
//        //sDepositedAccNo = 

//        dtInwardReconsiliation.Rows.Add(sChequeRegister_ID, false, sDateDeposited, sBankName, sCustomerName, sAccountNumber, sChequeNumber, sChequeAmount, sStatusID, sStatusName, detail.PaneltyAmount.ToString(), sDateReconciliation);
//        //dgvReconciliation.Rows[iRow].DefaultCellStyle.ForeColor = GetColorForCheque(detail.ChequeRegister_ID);
//    }
//    sourceInwardReconsiliation.DataSource = dtInwardReconsiliation;
//    CalculateInwardChequeReconsiliation();
//    //  changeGridReconciliation();
//    dgvInwardReconciliation.Sort(this.dgvInwardReconciliation.Columns["RCSdate"], ListSortDirection.Ascending);
//} 
#endregion

//private void Search_Account(TextBox myTextBox)
//{
//    try
//    {
//        Form frmhelpsearch = new frmSearchTransaction();
//        if (txtGenBankID.Tag != null && txtGenBankID.Tag.ToString().Length > 0)
//            clsSearch.passValue_CompanyAccountByBankID(txtGenBankID.Tag.ToString());
//        else
//            clsSearch.passValue_CompanyAccount();

//        frmhelpsearch.ShowDialog();
//        if (frmSearchTransaction.s_SearchID.Length > 0)
//        {
//            if (frmSearchTransaction.s_SearchText.Length > 0)
//                myTextBox.Text = frmSearchTransaction.s_SearchID;
//            if (frmSearchTransaction.s_SearchID.Length > 0)
//                myTextBox.Tag = frmSearchTransaction.s_SearchID;
//        }
//    }
//    catch (Exception ex)
//    {
//        SEACCException.Show(ex);
//        clsValidate.WriteErrorLog("", iFormID,ex);
//    }
//}