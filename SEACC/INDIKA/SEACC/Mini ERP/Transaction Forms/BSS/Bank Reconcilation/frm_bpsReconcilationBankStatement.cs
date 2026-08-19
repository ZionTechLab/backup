using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_bpsReconcilationBankStatement : SEACC_Form
    {
        
        public DataTable dtReconcilation = new DataTable();
        int iRecSerialNo = -1, iRowIndex = 0;


        #region Form Load
        //Update mode
        public frm_bpsReconcilationBankStatement(FormName _enmForm, int iCompanyAccountID, string sStatementNo, DateTime dtFromDate, DateTime dtStatementDate, decimal dStatementBalance, decimal glbdLastBalance)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            TxtStatementBal.Text = "0.00";
            try
            {
                this.Load += new EventHandler(frm_bpsReconcilationBankStatement_Load);

                txtStatementNo.Tag = sStatementNo;
                txtStatementNo.Text = sStatementNo;
                txtOPBL.Text = clsFormatter.FormatDecimalPlaces_Price(glbdLastBalance);
                txtStatementBalance.Text = clsFormatter.FormatDecimalPlaces_Price(dStatementBalance);
                dtpFromDate.Value = dtFromDate;
                dtpStatementDate.Value = dtStatementDate;

                tbl_genCompanyAccount oComAccount = tbl_genCompanyAccount.Select(iCompanyAccountID);
                if (oComAccount != null)
                {
                    txtAccountNo.Tag = iCompanyAccountID;
                    txtAccountNo.Text = oComAccount.AccountNumber;
                    txtBank.Tag = oComAccount.Bank_ID;
                    txtBank.Text = clsGenaralName.getName_Bank(oComAccount.Bank_ID);

                    tbl_accGLMaster_Bank oBank = tbl_accGLMaster_Bank.Select(oComAccount.AccountNumber);
                    if (oBank != null)
                    {
                        string sQuary = "SELECT dbo.[func_AccountOPBL2]('" + dtStatementDate.ToString("yyyy-MM-dd") + "','" + oBank.Gl_ID + "')";//"select opbl from dbo.func_AccountOPBL('1988-8-23','" + dtStatementDate.ToString("yyyy-MM-dd") + "','" + clsMethods_GL.getFinancialYear_ID(dtStatementDate.Date) + "','%') where gl_id='" + oBank.Gl_ID + "'";
                        txtLedgerBalance.Text = clsFormatter.FormatDecimalPlaces_Price(DBHandling.ExecQuery_ReturnDecimal(sQuary));
                    }
                }
                RefreshGrid(iCompanyAccountID, dtpStatementDate.Value);
                Calculate();
            }
            catch (Exception ex)
            {

                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        //for new reconcilation
        public frm_bpsReconcilationBankStatement(FormName _enmForm, int iCompanyAccountID, int iRecSerial_NO)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            TxtStatementBal.Text = "0.00";


            tbl_bpsBankReconciliation oBankRec = tbl_bpsBankReconciliation.Select(iCompanyAccountID, iRecSerial_NO);
            if (oBankRec != null && oBankRec.RecSerialNo != -1)
            {
                IsUpdate = true;

                iRecSerialNo = iRecSerial_NO;
                txtStatementNo.Tag = oBankRec.StatementNo;
                txtStatementNo.Text = oBankRec.StatementNo;
                txtOPBL.Text = clsFormatter.FormatDecimalPlaces_Price(oBankRec.OpeningBalance);
                txtStatementBalance.Text = clsFormatter.FormatDecimalPlaces_Price(oBankRec.StatementBalance);
                dtpFromDate.Value = oBankRec.DateFrom;
                dtpStatementDate.Value = oBankRec.DateTo;

                txtAccountNo.Tag = iCompanyAccountID;

                tbl_genCompanyAccount oComAccount = tbl_genCompanyAccount.Select(iCompanyAccountID);
                if (oComAccount != null)
                {
                    txtAccountNo.Text = oComAccount.AccountNumber;
                    txtBank.Tag = oComAccount.Bank_ID;
                    txtBank.Text = clsGenaralName.getName_Bank(oComAccount.Bank_ID);

                    tbl_accGLMaster_Bank oBank = tbl_accGLMaster_Bank.Select(oComAccount.AccountNumber);
                    if (oBank != null)
                    {
                        string sQuary1 = "SELECT dbo.[func_AccountOPBL2]('"+ oBankRec.DateTo.ToString("yyyy-MM-dd")+"','"+ oBank.Gl_ID + "')"; //"select opbl from dbo.func_AccountOPBL('1988-8-23','" + oBankRec.DateTo.ToString("yyyy-MM-dd") + "','" + clsMethods_GL.getFinancialYear_ID(oBankRec.DateTo.Date) + "','%') where gl_id='" + oBank.Gl_ID + "'";
                        txtLedgerBalance.Text = clsFormatter.FormatDecimalPlaces_Price(DBHandling.ExecQuery_ReturnDecimal(sQuary1));
                    }
                }

                if (oBankRec.IsApproved)
                {
                    bHasApproved = true;
                    glbApprovedDate = oBankRec.DateApproved;
                }
                if (oBankRec.IsChecked)
                {
                    bHasChecked = true;
                    glbCheckedDate = oBankRec.DateChecked;
                }
                userDetailsColorChanges();

                RefreshGrid(iCompanyAccountID, dtpStatementDate.Value);

                string sQuary = "SELECT dbo.GetLastReconcilation(" + iCompanyAccountID + ")";
                //int iLastRecID = DBHandling.ExecQuery_ReturnInt(sQuary);

                //if (iRecSerialNo != iLastRecID)
                //{
                //    btnSave.Enabled = false;
                //}
            }
            Calculate();
        }

        private void frm_bpsReconcilationBankStatement_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(false, false, false, true, false, true, true, false, false);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvDetail, clsFormatter.colorGrid, UI_Color);

            for (int i = 0; i < chkTxTypes.Items.Count; i++)
            {
                chkTxTypes.SetItemChecked(i, true);
            }
            chkTxTypes_SelectedIndexChanged(sender, e);

            ChangeColorForReturned_Cheque();
        }
        #endregion

        #region Action Buttons
        #region Btn New
        private void frm_bpsReconcilationBankStatement_SF_newButton_Click(object sender, EventArgs e)
        {
        }
        #endregion 

        #region Btn Save
        private void frm_bpsReconcilationBankStatement_SF_saveButton_Click(object sender, EventArgs e)
        {
            bool bStatus = true;
            int iCompanyAccNo = int.Parse(txtAccountNo.Tag.ToString());

            #region Validate reconcilation date
            if (IsUpdate)
            {
                tbl_bpsBankReconciliation oReconcilation = tbl_bpsBankReconciliation.Select(iCompanyAccNo, iRecSerialNo);
                if (oReconcilation != null && oReconcilation.RecSerialNo != -1)
                {
                    if (oReconcilation.IsApproved)
                    {
                        bStatus = false;
                        MessageBox.Show("Record already approved..");
                    }
                }
                else
                {
                    bStatus = false;
                    MessageBox.Show("Invalid reconcilation serial..");
                }
            }
            if (bStatus)
            {
                foreach (DataRow dtRow in dtReconcilation.Rows)
                {
                    bool bSelected = clsValidate.ValidateRowValue(dtRow, "IsSelected", false);
                    DateTime dtReconcilation = clsSecurity.getServerDateTime();
                    dtReconcilation = clsValidate.ValidateRowValue(dtRow, "RecDate", dtReconcilation);//   DateTime.Parse(clsValidate.ValidateRowValue(dtRow, "ReconcilationDate", ""));
                    if (bSelected)
                    {
                        if (dtReconcilation.Date < dtpFromDate.Value.Date || dtReconcilation.Date > dtpStatementDate.Value.Date)
                        {
                            string sTransactionID = clsValidate.ValidateRowValue(dtRow, "TxnID", "");
                            MessageBox.Show("Invalid reconcilation date <<" + sTransactionID + ">>");
                            bStatus = false;
                            break;
                        }
                    }
                }
            }
            #endregion

            if (bStatus)
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpStatementDate.Value.Date))
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                    {
                        int iNoOfAccCheques = 0, iNoOfBpsCheques = 0;
                        decimal dTotalAmountAccCheques = 0, dTotalAmountBpsCheques = 0;

                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            Calculate();

                            #region Remove Filters
                            txtFillter.Text = "";
                            txtFillter_KeyUp(null, null);
                            for (int i = 0; i < chkTxTypes.Items.Count; i++)
                            {
                                chkTxTypes.SetItemChecked(i, true);
                            }
                            chkTxTypes_SelectedIndexChanged(null, null);
                            FilterGrid();
                            #endregion

                            if (CheckValidityGridSelection())
                            {

                                if (!IsUpdate)
                                {
                                    #region New Mode - Genarate Serial #
                                    iRecSerialNo = clsAutocode.getAutoGeneratedCode_BankReconcilationCcounter(iCompanyAccNo);
                                    #endregion
                                }
                                else
                                {
                                    #region Update Mode - reverce saved Transactions
                                    #region Cash
                                    foreach (tbl_bpsCashDeposit oOldcashDeposit in tbl_bpsCashDeposit.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo))
                                    {
                                        oOldcashDeposit.IsReconciled = false;
                                        oOldcashDeposit.RecSerialNo = -1;
                                        oOldcashDeposit.Update();
                                    }
                                    #endregion

                                    #region ACC Cheque
                                    foreach (tbl_accChequeRegister oOldChequeRegister in tbl_accChequeRegister.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo))
                                    {
                                        oOldChequeRegister.IsLocked = false;

                                        oOldChequeRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.New);
                                        oOldChequeRegister.RecSerialNo = -1;
                                        oOldChequeRegister.Update();

                                    }

                                    foreach (tbl_accChequeReconciliation oRec in tbl_accChequeReconciliation.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo))
                                    {
                                        tbl_accChequeReconciliation_Detail.DeleteAllByReconciliation_ID(oRec.Reconciliation_ID);
                                        oRec.Delete();
                                    }
                                    #endregion

                                    #region Inward cheque
                                    foreach (tbl_bpsChequeDeposit_Detail oChequeDepositeDetail in tbl_bpsChequeDeposit_Detail.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo))
                                    {
                                        tbl_bpsChequeRegister oRegister = tbl_bpsChequeRegister.Select(oChequeDepositeDetail.ChequeRegister_ID);
                                        if (oRegister != null)
                                        {
                                            #region Realized
                                            oRegister.IsReconcilied = false;
                                            oRegister.RecSerialNo = -1;
                                            oRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID((oRegister.DepositCount > 1) ? ChequeStatus.ReDeposited : ChequeStatus.Deposited);
                                            oRegister.Update();
                                            #endregion
                                        }

                                        oChequeDepositeDetail.ChequeStatus_ID = oRegister.ChequeStatus_ID;
                                        oChequeDepositeDetail.RecSerialNo = -1;
                                        oChequeDepositeDetail.Update();
                                    }

                                    foreach (tbl_bpsChequeReconciliation_Detail oRec in tbl_bpsChequeReconciliation_Detail.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo))
                                    {
                                        if (oRec.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))

                                            oRec.Delete();
                                    }
                           
                                    #endregion
                                    #region JE
                                    foreach (tbl_accJournalEntry_Detail oJEDetail in tbl_accJournalEntry_Detail.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo))
                                    {
                                        oJEDetail.IsReconciled = false;
                                        oJEDetail.RecSerialNo = -1;
                                        oJEDetail.Update();
                                    }
                                    #endregion

                                    #region BT
                                    foreach (tbl_bpsChequeRegister oRegister in tbl_bpsChequeRegister.SelectAll().Where(p => p.CompanyAccount_ID == iCompanyAccNo && p.RecSerialNo == iRecSerialNo && (p.PaymentMethod_ID == (int)PaymentMethod.Bank_Transfer)))
                                    {
                                        #region Realized
                                        oRegister.IsReconcilied = false;
                                        oRegister.RecSerialNo = -1;
                                        oRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deposited);
                                        oRegister.Update();
                                        #endregion
                                    }
                                    #endregion
                                    #endregion
                                }


                                #region Save bpsBankReconciliation
                                tbl_bpsBankReconciliation oReconcilation;
                                if (!IsUpdate)
                                {
                                    oReconcilation = new tbl_bpsBankReconciliation(iCompanyAccNo, iRecSerialNo, txtStatementNo.Text, "", dtpFromDate.Value, dtpStatementDate.Value, decimal.Parse(txtOPBL.Text), decimal.Parse(txtReceipt.Text), decimal.Parse(txtPayment.Text), decimal.Parse(txtCLBL.Text), decimal.Parse(txtStatementBalance.Text),
                                               clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    oReconcilation.Insert();
                                }
                                else
                                {
                                    oReconcilation = tbl_bpsBankReconciliation.Select(iCompanyAccNo, iRecSerialNo);
                                    oReconcilation.DateModified = clsSecurity.getServerDateTime();
                                    oReconcilation.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                    oReconcilation.OpeningBalance = decimal.Parse(txtOPBL.Text);
                                    oReconcilation.Debit = decimal.Parse(txtReceipt.Text);
                                    oReconcilation.Credit = decimal.Parse(txtPayment.Text);
                                    oReconcilation.ClosingBalance = decimal.Parse(txtCLBL.Text);
                                    oReconcilation.StatementBalance = decimal.Parse(txtStatementBalance.Text);
                                    oReconcilation.Update();
                                }

                                #region Upadate Tables
                                foreach (DataRow dtRow in dtReconcilation.Rows)
                                {
                                    bool bSelected = clsValidate.ValidateRowValue(dtRow, "IsSelected", false);

                                    if (bSelected)
                                    {
                                        clsValidate.ValidateRowValue(dtRow, "TxnType", "");
                                        string sTransactionType = clsValidate.ValidateRowValue(dtRow, "TxnType", "");
                                        string sTransactionID = clsValidate.ValidateRowValue(dtRow, "TxnID", "");
                                        string sChequeRegID = clsValidate.ValidateRowValue(dtRow, "ChequeRegisterID", "");
                                        decimal dTransactionAmount = 0;
                                        DateTime dtRecDate = clsValidate.ValidateRowValue(dtRow, "RecDate", clsSecurity.getServerDateTime());
                                        dTransactionAmount = clsValidate.ValidateRowValue(dtRow, "Amount", dTransactionAmount);

                                        #region CASH
                                        if (sTransactionType == "CSH" && sTransactionID != "default")
                                        {
                                            tbl_bpsCashDeposit oCashDeposite = tbl_bpsCashDeposit.Select(sTransactionID);
                                            if (oCashDeposite != null)
                                            {
                                                oCashDeposite.IsReconciled = true;
                                                oCashDeposite.RecSerialNo = iRecSerialNo;
                                                oCashDeposite.DateReconcilied = dtRecDate;
                                                oCashDeposite.Update();

                                                foreach (tbl_bpsCashDeposit_Detail oCashDeposit_Detain in tbl_bpsCashDeposit_Detail.SelectAllByCashDeposit_ID(sTransactionID))
                                                {
                                                    tbl_bpsChequeRegister register = tbl_bpsChequeRegister.SelectAllByReceipt_ID(oCashDeposit_Detain.Receipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cash).FirstOrDefault();
                                                    if (register != null)
                                                    {
                                                        register.DateReconcilied = dtRecDate;
                                                        register.IsReconcilied = true;
                                                        register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                                        register.RecSerialNo = iRecSerialNo;
                                                        register.Update();
                                                    }
                                                }
                                            }
                                        }
                                        #endregion

                                        #region BT
                                        else if (sTransactionType == "BT" && sTransactionID != "default")
                                        {
                                            tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sTransactionID);
                                            if (register != null)
                                            {
                                                register.DateReconcilied = dtRecDate;
                                                register.IsReconcilied = true;
                                                register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                                register.RecSerialNo = iRecSerialNo;
                                                register.Update();
                                            }
                                        }
                                        #endregion

                                        #region Card
                                        else if (sTransactionType == "CRD" && sTransactionID != "default")
                                        {
                                            tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sTransactionID);
                                            if (register != null)
                                            {
                                                register.DateReconcilied = dtRecDate;
                                                register.IsReconcilied = true;
                                                register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                                register.RecSerialNo = iRecSerialNo;
                                                register.Update();
                                            }
                                        }
                                        #endregion

                                        #region ACC Cheque
                                        else if (sTransactionType == "PV" && sTransactionID != "default")
                                        {
                                            tbl_accChequeRegister oChequeRegister = tbl_accChequeRegister.Select(sTransactionID);
                                            if (oChequeRegister != null)
                                            {
                                                oChequeRegister.ReconcilationDate = dtRecDate;
                                                oChequeRegister.IsLocked = true;
                                                oChequeRegister.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                                oChequeRegister.RecSerialNo = iRecSerialNo;
                                                oChequeRegister.Update();

                                                iNoOfAccCheques++;
                                                dTotalAmountAccCheques += dTransactionAmount;
                                            }
                                        }
                                        #endregion

                                        #region BPS Cheque
                                        else if (sTransactionType == "CHQ" && sTransactionID != "default")
                                        {
                                            #region Update Cheque Deposite Detail / Cheque Register Detail
                                            if (sChequeRegID != "" && sChequeRegID != "default")
                                            {
                                                foreach (tbl_bpsChequeDeposit_Detail oChequeDepositeDetail in tbl_bpsChequeDeposit_Detail.SelectAllByChequeDeposit_ID(sTransactionID).Where(p => p.ChequeRegister_ID == sChequeRegID))
                                                {
                                                    tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(oChequeDepositeDetail.ChequeRegister_ID);
                                                    if (register != null)
                                                    {
                                                        #region Realized
                                                     //   clsDB.update_CustomerRealizedCheques(register.Customer_ID, register.Amount, register.AccountNumber);

                                                        register.DateReconcilied = dtRecDate;
                                                        register.IsReconcilied = true;
                                                        register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                                        register.Update();

                                                        iNoOfBpsCheques++;
                                                        dTotalAmountBpsCheques += dTransactionAmount;
                                                        #endregion
                                                    }
                                                    oChequeDepositeDetail.DateReconciliation = dtRecDate;
                                                    oChequeDepositeDetail.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                                    oChequeDepositeDetail.RecSerialNo = iRecSerialNo;
                                                    oChequeDepositeDetail.Update();
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion

                                        #region BE
                                        else if (sTransactionType == "BE" && sTransactionID != "default")
                                        {
                                            int iLineNo = int.Parse(sChequeRegID);
                                            foreach (tbl_accJournalEntry_Detail oJEDetail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sTransactionID).Where(p => p.Line_No == iLineNo))
                                            {
                                                oJEDetail.DateReconciled = dtRecDate;
                                                oJEDetail.IsReconciled = true;
                                                oJEDetail.RecSerialNo = iRecSerialNo;
                                                oJEDetail.Update();
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion

                                #region Save accChequeReconciliation
                                if (iNoOfAccCheques > 0)
                                {
                                    string sAccChequeReconciliationID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeReconsiliation));

                                    tbl_accChequeReconciliation detail = new tbl_accChequeReconciliation(sAccChequeReconciliationID, "", dtpStatementDate.Value, iNoOfAccCheques, dTotalAmountAccCheques,
                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                             false, false, false, false, false, iCompanyAccNo, iRecSerialNo, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    detail.Insert();

                                    int i = 0;
                                    foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAll().Where(p => p.RecSerialNo == iRecSerialNo && p.CompanyAccount_ID == iCompanyAccNo))
                                    {
                                        i++;
                                        tbl_accChequeReconciliation_Detail oChequeDetail = new tbl_accChequeReconciliation_Detail(i, sAccChequeReconciliationID, oCheque.ChequeRegister_ID, 0, clsAutocode.getChequeStatusID(ChequeStatus.Realized), oCheque.ReconcilationDate, iCompanyAccNo, iRecSerialNo);
                                        oChequeDetail.Insert();
                                    }
                                }
                                #endregion

                                #region Save bpsChequeReconciliation
                                if (iNoOfBpsCheques > 0)
                                {
                                    #region Cheque reconcilation Header
                                    string sBpsChequeReconciliationID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeReconsiliation));

                                    tbl_bpsChequeReconciliation detailBps = new tbl_bpsChequeReconciliation(sBpsChequeReconciliationID, "", dtpStatementDate.Value, decimal.Parse(iNoOfBpsCheques.ToString()), dTotalAmountBpsCheques, clsSecurity.UserIDLoged,
                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                        false, false, false, false, false, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    detailBps.Insert();
                                    #endregion

                                    foreach (tbl_bpsChequeDeposit_Detail oChequeDeposite in tbl_bpsChequeDeposit_Detail.SelectAll().Where(p => p.RecSerialNo == iRecSerialNo && p.CompanyAccount_ID == iCompanyAccNo))
                                    {
                                        tbl_bpsChequeReconciliation_Detail oChequeDetail = new tbl_bpsChequeReconciliation_Detail(sBpsChequeReconciliationID, oChequeDeposite.ChequeRegister_ID, 0, clsAutocode.getChequeStatusID(ChequeStatus.Realized), "default",
                                                                clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), oChequeDeposite.DateReconciliation, iCompanyAccNo, iRecSerialNo, oChequeDeposite.ChequeDeposit_ID);
                                        oChequeDetail.Insert();
                                    }
                                }
                                #endregion

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                            IsUpdate = true;
                            ClearFields();
                            RefreshGrid(iCompanyAccNo, dtpStatementDate.Value);
                            Calculate();
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(int iCompanyAccountNo, DateTime dtStatementDate)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dtReconcilation.Rows.Clear();

                if (IsUpdate)
                    dtReconcilation.Merge(DBHandling.ExecQuery("exec sp_BankReconcilation_SelectAll '" + iCompanyAccountNo + "','" + iRecSerialNo + "'").Tables[0]);

                dtReconcilation.Merge(DBHandling.ExecQuery("exec sp_BankReconcilation_preparation '" + iCompanyAccountNo + "','" + dtStatementDate + "','" + (IsUpdate ? 1 : 0) + "'").Tables[0]);
                dgvDetail.DataSource = dtReconcilation;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Key Events
        private void txtFillter_KeyUp(object sender, KeyEventArgs e)
        {
 
            if (e != null && e.KeyCode == Keys.Add)
            {
                if (dgvDetail.Rows.Count == 1)
                {
                    //var row = dgvDetail.Rows[0];
                    dgvDetail["IsSelected", 0].Value = true;
                    txtFillter.Text = "";
                }
                
            }
            else
            {
                FilterGrid();
            }
        }

        private void chkTxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrid();
        }

        private void chkTxTypes_DoubleClick(object sender, EventArgs e)
        {
            FilterGrid();
        }

        private void FilterGrid()
        {
            try
            {


                StringBuilder sFilter = new StringBuilder();
                List<string> list = new List<string>();
                List<string> chklist = new List<string>();
                string sTxtFilter = "", sChkFilter = "", finalFilter = "";

                string sTypeFilter = "";

                foreach (string item in this.chkTxTypes.CheckedItems)
                {
                    if (sTypeFilter != "")
                        sTypeFilter += " OR ";

                    sTypeFilter += " TxnType = '" + item.ToString() + "' ";
                }

                if (sTypeFilter == "")
                    sTypeFilter = " TxnType = '' ";

                if (txtFillter.Text.Trim().Length > 0)
                {
                  


                    string sFilteredValue = clsHelpMethods.CheckValue(txtFillter.Text.Trim());
                    
                    decimal de                             = 0;
                     decimal.TryParse(sFilteredValue,out de);

                    list.Add("TxnDate LIKE '%" + sFilteredValue + "%'");
                    list.Add("CustomerName LIKE '%" + sFilteredValue + "%'");
                    list.Add("ChequeNo LIKE '%" + sFilteredValue + "%'");
                    list.Add("ChequeDate LIKE '%" + sFilteredValue + "%'");
                    list.Add("Receipt LIKE '%" + sFilteredValue + "%'");
                    list.Add("Payment LIKE '%" + sFilteredValue + "%'");
                    list.Add("Remarks LIKE '%" + sFilteredValue + "%'");

                    sTxtFilter = String.Join(" OR ", list);
                }
                if (sTxtFilter != "")
                    sTypeFilter = "(" + sTypeFilter + ") AND (" + sTxtFilter + ")";


                dtReconcilation.DefaultView.RowFilter = sTypeFilter.ToString();

                ChangeColorForReturned_Cheque();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtStatementBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtStatementBalance.Text, e);
        }
        #endregion

        #region Grid Events
        private void dgvDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region Selection
                if (sColName == "IsSelected")
                {
                    string sStatusID = clsValidate.ValidateGridValue(dgvDetail, "ChqStatusID", e.RowIndex, "");
                    if (!(sStatusID == "4" || sStatusID == "5" || sStatusID == "6" || sStatusID == "9"))
                    {
                        bool bstatus = clsValidate.ValidateGridValue(dgvDetail, "IsSelected", e.RowIndex, false);
                        dgvDetail[e.ColumnIndex, e.RowIndex].Value = !bstatus;

                        Calculate();
                    }
                }
                #endregion

                #region Txn
                else if (sColName == "ChequeNo")
                {
                    string sTxnType = clsValidate.ValidateGridValue(dgvDetail, "TxnType", e.RowIndex, "");
                    string sTransactionID = clsValidate.ValidateGridValue(dgvDetail, "TxnID", e.RowIndex, "");
                    if (sTransactionID != null)
                    {
                        #region Cheque
                        if (sTxnType == "CHQ" || sTxnType == "BT")
                        {
                            string sChequeRegisterID = "";
                            if (sTxnType == "BT")
                                sChequeRegisterID = sTransactionID;
                            else
                                sChequeRegisterID = clsValidate.ValidateGridValue(dgvDetail, "ChequeRegisterID", e.RowIndex, "");

                            tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sChequeRegisterID);
                            if (oCheque != null)
                            {
                                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(oCheque.Receipt_ID);
                                if (detail != null)
                                {
                                    if (detail.IsSalesReceipt)
                                    {
                                        UC_bpsReceiptSales cheque = new UC_bpsReceiptSales(FormName.UCReceipt);
                                        cheque.glbReceiptID = detail.Receipt_ID;
                                        clsHelpMethods_Local.DisplayForm(cheque, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                                    }
                                    else
                                    {
                                        UC_bpsReceiptSales cheque = new UC_bpsReceiptSales(FormName.InterimReceipt);
                                        cheque.glbReceiptID = detail.Receipt_ID;
                                        clsHelpMethods_Local.DisplayForm(cheque, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                                    }
                                }
                            }
                        }
                        #endregion
                        #region PV
                        else if (sTxnType == "PV")
                        {
                            tbl_accChequeRegister detail = tbl_accChequeRegister.Select(sTransactionID);
                            if (detail.PaymentVoucher_ID != null)
                            {
                                frm_accPaymentVoucher frm = new frm_accPaymentVoucher(FormName.accPaymentVoucher);
                                frm.glbPamentVoucher = detail.PaymentVoucher_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion
                        #region Cash
                        else if (sTxnType == "CSH")
                        {
                            frm_bpsCashDepositSummary form = new frm_bpsCashDepositSummary(sTransactionID);
                            form.ShowDialog();
                        }
                        #endregion
                        #region BE
                        else if (sTxnType == "BE")
                        {
                            UC_AccJournalEntry form = new UC_AccJournalEntry(FormName.accJournalEntry_Bank);
                            form.glbJournalEntryID = sTransactionID;
                            clsHelpMethods_Local.DisplayForm(form, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                        }
                        #endregion
                    }
                }
                #endregion

                #region Cheque Status
                else if (sColName == "ChqStatus")
                {
                    string sStatus = clsValidate.ValidateGridValue(dgvDetail, "ChqStatus", e.RowIndex, "");
                    string sStatusID = clsValidate.ValidateGridValue(dgvDetail, "ChqStatusID", e.RowIndex, "");
                    string sTxnType = clsValidate.ValidateGridValue(dgvDetail, "TxnType", e.RowIndex, "");
                    if (sStatus != "-")
                    {
                        iRowIndex = e.RowIndex;

                        if (sTxnType == "CHQ")
                        {
                            if (!(sStatusID == "3" || sStatusID == "4" || sStatusID == "5" || sStatusID == "6"))
                            {
                                toolStripMenuItem_Returned_R.Visible = true;
                                toolStripMenuItem_Returned_NRC.Visible = true;
                              //  toolStripMenuItem_Returned_NRO.Visible = true;
                                toolStripMenuItem_PV_Returned.Visible = false;
                                toolStripMenuItem_PV_cancel.Visible = false;
                                oContextMenuChq.Show(Cursor.Position);
                            }
                        }
                        else if (sTxnType == "PV")
                        {
                            if (!(sStatusID == "3" || sStatusID == "4" || sStatusID == "9"))
                            {
                                toolStripMenuItem_Returned_R.Visible = true;
                                toolStripMenuItem_Returned_NRC.Visible = false;
                                //toolStripMenuItem_Returned_NRO.Visible = false;
                                toolStripMenuItem_PV_Returned.Visible = false;
                                toolStripMenuItem_PV_cancel.Visible = true;
                                oContextMenuChq.Show(Cursor.Position);
                            }
                        }
                    }
                }
                #endregion

                #region Reconsilation Date
                else if (sColName == "ReconcilationDate")
                {
                    DateTime sRecDate = clsValidate.ValidateGridValue(dgvDetail, "RecDate", e.RowIndex, DateTime.Now);
                    DateTime sTxnDate = clsValidate.ValidateGridValue(dgvDetail, "STxnDate", e.RowIndex, DateTime.Now);

                    string sStatusID = clsValidate.ValidateGridValue(dgvDetail, "ChqStatusID", e.RowIndex, "");

                    if (!(sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) ||
                        sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O) || sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Deleted)))
                    {
                        frm_Calendar RowDataSearch = new frm_Calendar();
                        RowDataSearch.dtDateValue = sRecDate.Date;
                        DateTime rDate = RowDataSearch.Show();
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            if (rDate.Date >= dtpFromDate.Value.Date && rDate <= dtpStatementDate.Value.Date)
                            {
                                if (rDate.Date >= sTxnDate.Date)
                                {    dgvDetail[e.ColumnIndex, e.RowIndex].Value = rDate.ToString("dd/MM/yyyy");
                                dgvDetail["RecDate", e.RowIndex].Value = rDate;
                                }
                                else
                                { MessageBox.Show("Invalied Rec. date......!", "Validation Error"); }
                            }
                            else
                            { MessageBox.Show("Invalied Rec. date......!", "Validation Error"); }

                          
                        }
                    }
                }
                #endregion
            }
            ChangeColorForReturned_Cheque();
        }
        #endregion

        #region Mouse events
        private void ContextMenuClick(Object sender, System.EventArgs e)
        {
            string sTxnType = clsValidate.ValidateGridValue(dgvDetail, "TxnType", dgvDetail.SelectedRows[0].Index, "");
            string sTxnID = clsValidate.ValidateGridValue(dgvDetail, "TxnID", dgvDetail.SelectedRows[0].Index, "");
            string sChequeRegisterId = clsValidate.ValidateGridValue(dgvDetail, "ChequeRegisterID", dgvDetail.SelectedRows[0].Index, "");

            string sSelectedStatus = sender.ToString();
            if (sSelectedStatus != null && sSelectedStatus != "")
            {
                string StatusId = "default";
                if (sSelectedStatus == "Returned [R]" || sSelectedStatus == "Returned")
                    StatusId = "4";
                else if (sSelectedStatus == "Returned [NR/C]")
                    StatusId = "5";
                else if (sSelectedStatus == "Returned [NR/O]")
                    StatusId = "6";
                else if (sSelectedStatus == "Canceled")
                    StatusId = "9";

                if (sTxnType == "CHQ" || sTxnType == "PV")
                {
                    frm_bpsReturnCheque frmReturn = new frm_bpsReturnCheque();
                    bool bIsChangeStatus = frmReturn.Show(true, sTxnID, sChequeRegisterId, StatusId, sTxnType);

                    //if (bIsChangeStatus)
                    //    dgvDetail["ChqStatus", iRowIndex].Value = sSelectedStatus;
                    //else
                    //    dgvDetail["ChqStatus", iRowIndex].Value = sSelectedStatus; 
                    int iCompanyAccNo = int.Parse(txtAccountNo.Tag.ToString());
                    RefreshGrid(iCompanyAccNo, dtpStatementDate.Value);
                    Calculate();
                }

                //else
                //    dgvDetail["ChqStatus", iRowIndex].Value = sSelectedStatus;

                //      ChangeColorForReturned_Cheque();

                //   dgvDetail.Rows[iRowIndex].DefaultCellStyle.ForeColor = clsFormatter.colorChequeNew;
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidityGridSelection()
        {
            bool bStatus = false;

            foreach (DataGridViewRow row1 in dgvDetail.Rows)
            {
                bool cb = (bool)row1.Cells["IsSelected"].FormattedValue;
                if (cb == true)
                {
                    bStatus = true;
                    break;
                }
            }
            if (!bStatus)
                MessageBox.Show("Please Tick the Checkbox to save......!", "Validation Error");
            return bStatus;
        }
        #endregion

        private void Calculate()
        {
            try
            {
                int iCountTot = 0, iCountSelected = 0;
                decimal dAmountReceipt = 0, dAmountPayment = 0, dAmountSelected_Receipt = 0, dAmountSelected_Payment = 0; ;
                decimal d = 0;


                decimal PVbal = 0, INBal = 0, otherBal = 0;
                foreach (DataRow dtRow in dtReconcilation.Rows)
                {
                    decimal dRecipt = clsValidate.ValidateRowValue(dtRow, "Receipt", 0M);
                    decimal dPaymnt= clsValidate.ValidateRowValue(dtRow, "Payment", 0M);
                    bool bSelected = clsValidate.ValidateRowValue(dtRow, "IsSelected", false);
                    string TxnType=clsValidate.ValidateRowValue(dtRow, "TxnType", "");
                    string Status = clsValidate.ValidateRowValue(dtRow, "ChqStatusID", "");

                    iCountTot++;
                    dAmountReceipt += dRecipt;
                    dAmountPayment += dPaymnt;

                    if (bSelected)
                    {
                        iCountSelected++;
                        dAmountSelected_Receipt += dRecipt;
                        dAmountSelected_Payment += dPaymnt; 
                    }
                   else
                    {
                        if (TxnType == "PV")
                        {
                            if (Status == "4")// || Status == "5" || Status == "6")
                            { }
                            else
                            {
                                PVbal += dPaymnt;
                            }
                        }
                        else if (TxnType == "CSH" || TxnType == "CHQ")
                        {
                            if (Status == "4" || Status == "5" || Status == "6")
                            { }
                            else
                            {
                                INBal += dRecipt;
                            }
                        }
                        else
                        {
                            otherBal += (dPaymnt - dRecipt);
                        }
                    }
                }

                decimal dOPBL = decimal.Parse(txtOPBL.Text);
                decimal dLedgerBalance = decimal.Parse(txtLedgerBalance.Text);
                decimal dClosingBalance = dOPBL + dAmountSelected_Receipt - dAmountSelected_Payment;

                decimal StatementBal = decimal.Parse(TxtStatementBal.Text);

                txtReceipt.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmountSelected_Receipt);
                txtPayment.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmountSelected_Payment);
                txtCLBL.Text = clsFormatter.FormatToCurrecyWithThousendSep(dClosingBalance);

                txtInWord.Text = clsFormatter.FormatToCurrecyWithThousendSep(INBal);
                TxtOutword.Text= clsFormatter.FormatToCurrecyWithThousendSep(PVbal);
                txtOther.Text= clsFormatter.FormatToCurrecyWithThousendSep(otherBal);



                txtDifference.Text = clsFormatter.FormatToCurrecyWithThousendSep(dLedgerBalance - (dClosingBalance + INBal - PVbal - otherBal)- StatementBal);   //dLedgerBalance - dClosingBalance);
    
                lblAmtRCP.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmountReceipt);
                lblAmtPAY.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmountPayment);
                lblCountCheques.Text = iCountTot.ToString();

                lblAmtRCPSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmountSelected_Receipt);
                lblAmtPAYSelected.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmountSelected_Payment);
                lblCountChequeSelected.Text = iCountSelected.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void ChangeColorForReturned_Cheque()
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                dgvDetail.Rows[i].DefaultCellStyle.ForeColor = GetColorForCheque(dgvDetail.Rows[i].Cells["ChqStatusID"].Value.ToString());
            }
        }

        private Color GetColorForCheque(string sStatusID)
        {
            Color col = Color.Black;

            if (sStatusID != null && sStatusID != "" && sStatusID != "-")
            {
                if (sStatusID == "4" || sStatusID == "5" || sStatusID == "6")
                    col = clsFormatter.colorChequeNew;
            }
            return col;
        }

        #region Btn events
        private void btnCashDeposite_Click(object sender, EventArgs e)
        {
            frm_bpsCashDeposit cheque = new frm_bpsCashDeposit(FormName.CashDepositeCode);
            clsHelpMethods_Local.DisplayForm_2(cheque, clsFormatter.colorBills);

            RefreshGrid(int.Parse(txtAccountNo.Tag.ToString()), dtpStatementDate.Value);
        }

        private void btnChequeDeposit_Click(object sender, EventArgs e)
        {
            frm_bpsChequeDeposit cheque = new frm_bpsChequeDeposit(FormName.ChequeDeposit);
            clsHelpMethods_Local.DisplayForm_2(cheque, clsFormatter.colorBills);

            RefreshGrid(int.Parse(txtAccountNo.Tag.ToString()), dtpStatementDate.Value);
        }

        private void btnBAE_Click(object sender, EventArgs e)
        {
            UC_AccJournalEntry form = new UC_AccJournalEntry(FormName.accJournalEntry_Bank);
            clsHelpMethods_Local.DisplayForm_2(form, clsFormatter.colorBills);

            RefreshGrid(int.Parse(txtAccountNo.Tag.ToString()), dtpStatementDate.Value);
        }

        private bool CheckValidity_ChequeReturnPosting()
        {
            bool bStatus = false;

            //if (clsConfig.bAutoPostingEnable)
            //{
            //    bool bSlotStatus_Bank = false, bSlotStatus_Debter = false;

            //    foreach (DataGridViewRow row1 in dgvInwardReconciliation.Rows)
            //    {
            //        bool bSelected = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reIsSelect", row1.Index, false);
            //        if (bSelected)
            //        {
            //            bool cb = (bool)row1.Cells[0].FormattedValue;
            //            string sAccount = row1.Cells[6].FormattedValue.ToString();
            //            string sStatusID = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reChequeStatusID", row1.Index, "");

            //            if (cb == true)
            //            {
            //                bSlotStatus_Bank = clsMethods_GL.CheckAccountLink_Bank(sAccount);
            //                if (!bSlotStatus_Bank)
            //                    break;
            //            }
            //            if (sStatusID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C))
            //            {
            //                string sRegisterCode = clsValidate.ValidateGridValue(dgvInwardReconciliation, "reRegisterCode", row1.Index, "");
            //                tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sRegisterCode);
            //                if (oCheque != null)
            //                {
            //                    bSlotStatus_Debter = clsMethods_GL.CheckAccountLink_Customer(oCheque.Customer_ID);// GetAccountCode_Customer(oCheque.Customer_ID);
            //                }
            //            }
            //        }

            //    }

            //    bool bSlotStatus_Cheque = clsMethods_GL.CheckAccountLink(AccSlot.ChequeReturned, false);

            //    if (bSlotStatus_Bank && bSlotStatus_Cheque)
            //        bStatus = true;
            //}
            //else
            bStatus = true;
            return bStatus;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row1 in dgvDetail.Rows)
            {
                string sStatusID = clsValidate.ValidateGridValue(dgvDetail, "ChqStatusID", row1.Index, "");
                if (!(sStatusID == "4" || sStatusID == "5" || sStatusID == "6" || sStatusID == "9"))
                {
                    dgvDetail["IsSelected", row1.Index].Value = chkSelectAll.Checked;
                }
            }
            Calculate();
        }

        #endregion





        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtAccountNo.Tag != null && iRecSerialNo != -1)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpStatementDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetApproved login = new frmSetApproved();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetApproved.bChecked)
                                {
                                    bHasApproved = true;
                                    glbApprovedDate = clsSecurity.getServerDateTime();
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_bpsBankReconciliation objBR = tbl_bpsBankReconciliation.Select(int.Parse(txtAccountNo.Tag.ToString()), iRecSerialNo);
                                        if (objBR != null)
                                        {
                                            objBR.IsApproved = true;
                                            objBR.DateApproved = clsSecurity.getServerDateTime();
                                            objBR.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objBR.Update();

                                            //ClearFields();
                                            //FillDetails(objBR.CreditNote_ID);
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CheckedBy()
        {
            try
            {
                if (txtAccountNo.Tag != null && iRecSerialNo != -1)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpStatementDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetChecked login = new frmSetChecked();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetChecked.bChecked)
                                {
                                    bHasChecked = true;
                                    glbCheckedDate = clsSecurity.getServerDateTime();

                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_bpsBankReconciliation objBR = tbl_bpsBankReconciliation.Select(int.Parse(txtAccountNo.Tag.ToString()), iRecSerialNo);
                                        if (objBR != null)
                                        {
                                            objBR.IsChecked = true;
                                            objBR.DateChecked = clsSecurity.getServerDateTime();
                                            objBR.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objBR.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void TxtStatementBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Keys.Enter.ToString())
            //{ Calculate(); }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-';

        }

        private void TxtStatementBal_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void TxtStatementBal_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
                Calculate();
        }

        private void frm_bpsReconcilationBankStatement_SF_approveButton_Click_1(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_bpsReconcilationBankStatement_SF_checkButton_Click_1(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                decimal dDiscountedPrice = clsValidate.ValidateGridValue(dgvDetail, "ReturnDate", e.RowIndex, decimal.Parse("0.00"));
            }
        }
    }
}