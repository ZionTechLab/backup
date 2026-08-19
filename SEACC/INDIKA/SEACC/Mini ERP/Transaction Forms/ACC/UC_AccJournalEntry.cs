using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using DataTire;
using Zion.ERP.Reports.DataSets;

namespace Digiteq
{
    public partial class UC_AccJournalEntry : SEACC_Form
    {
        
        DataTable dt_GLP;

        private bool bIsDebtorJE;
        private bool bIsAdvanceJE;
        private bool bIsHideCus_Sup;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Accounts glb_dts_Accounts = new dts_Accounts();

        public string glbJournalEntryID = "";
 

        #region Form Load
        public UC_AccJournalEntry(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
            CusDataGridViewFormat();
        }
        private void CusDataGridViewFormat()
        {
            if (enmForm == FormName.accJournalEntry_Creditor)
            {
                dgvDetail.Columns["cus_sup_Name"].HeaderText = "Supplier";
                bIsDebtorJE = false;
            }
            else if (enmForm == FormName.accJournalEntry_Debtor)
            {
                dgvDetail.Columns["cus_sup_Name"].HeaderText = "Customer";
                bIsDebtorJE = true;
            }
            else if (enmForm == FormName.accJournalEntry_Standard || enmForm == FormName.accJournalEntry_Bank)
            {
                bIsHideCus_Sup = true;
                dgvDetail.Columns["cus_sup_Name"].Visible = !bIsHideCus_Sup;
            }
            else if (enmForm == FormName.accJournalEntry_Advance)
            {
                dgvDetail.Columns["cus_sup_Name"].HeaderText = "Customer / Supplier";
                bIsAdvanceJE = true;
            }

        }
        private void UC_AccJournalEntry_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            CreateDataTable();
            ClearFields();

            if (glbJournalEntryID != null && glbJournalEntryID.Length > 0)
                FillDetails(glbJournalEntryID);
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dt_GLP = new DataTable();
            dt_GLP.Columns.Add("Line_No", typeof(int));
            dt_GLP.Columns.Add("AccCode", typeof(string));
            dt_GLP.Columns.Add("AccName", typeof(string));
            dt_GLP.Columns.Add("subAcc1_ID", typeof(string));
            dt_GLP.Columns.Add("subAcc1Name", typeof(string));
            dt_GLP.Columns.Add("subAcc2_ID", typeof(string));
            dt_GLP.Columns.Add("subAcc2Name", typeof(string));

            dt_GLP.Columns.Add("cus_sup_ID", typeof(string));
            dt_GLP.Columns.Add("cus_sup_Name", typeof(string));
            dt_GLP.Columns.Add("debitAmount", typeof(string));
            dt_GLP.Columns.Add("creditAmount", typeof(string));
            dt_GLP.Columns.Add("Remarks", typeof(string));
            dt_GLP.Columns.Add("Type", typeof(string));

            dgvDetail.DataSource = dt_GLP.DefaultView;
        }
        #endregion

        #region Btn New
        private void UC_AccJournalEntry_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void UC_AccJournalEntry_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    #region Update
                    if (IsUpdate)
                    {
                        tbl_accJournalEntry oldRecord = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished &&
                                !oldRecord.IsDeleted)
                            {
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtJournalID.Text))
                                {

                                    bool bIsSettled = false, bIsReconciled = false;
                                    foreach (tbl_accJournalEntry_Detail oJEDetail in tbl_accJournalEntry_Detail
                                        .SelectAll().Where(p => p.JournalEntry_ID == txtJournalID.Text.Trim() && (p.IsSeattled || p.SeattleAmount > 0)))
                                    {
                                        bIsSettled = true;
                                        break;
                                    }

                                    foreach (tbl_accJournalEntry_Detail oJEDetailRec in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(txtJournalID.Text.Trim()).Where(p => p.IsReconciled))
                                    {
                                        bIsReconciled = true;
                                        break;
                                    }

                                    if (!bIsReconciled)
                                    {
                                        if (!bIsSettled)
                                        {
                                            if (!oldRecord.IsChecked ||
                                                (oldRecord.IsChecked &&
                                                 clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                            {
                                                clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                                tbl_accJournalEntry_Detail.DeleteAllByJournalEntry_ID(
                                                    txtJournalID.Text.ToString());

                                                #region  Insert Detail - Journal

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    bool bIsCredit = true;
                                                    string sSupplier_ID = "", sCustomer_ID = "";

                                                    string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode",
                                                        row.Index, "");
                                                    string sCus_Sup_ID = clsValidate.ValidateGridValue(dgvDetail,
                                                        "cus_sup_ID", row.Index, "");
                                                    string sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail,
                                                        "subAcc1_ID", row.Index, "");
                                                    string sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail,
                                                        "subAcc2_ID", row.Index, "");
                                                    string sRemarks =
                                                        clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                    int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No",
                                                        row.Index, int.Parse("0"));
                                                    string sType =
                                                        clsValidate.ValidateGridValue(dgvDetail, "Type", row.Index, "");

                                                    string sAccountNo = "default";
                                                    int iCompanyAccID = -1;
                                                    foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank
                                                        .SelectAllByGl_ID(sGLCode))
                                                    {
                                                        foreach (tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount
                                                            .SelectAll()
                                                            .Where(p => p.AccountNumber == oGLBank.AccountNumber))
                                                        {
                                                            iCompanyAccID = oComAcc.CompanyAccount_ID;
                                                        }

                                                        sAccountNo = oGLBank.AccountNumber;
                                                    }

                                                    decimal dAmount = clsValidate.ValidateGridValue(dgvDetail,
                                                        "creditAmount", row.Index, decimal.Parse("0.00"));
                                                    if (dAmount == 0)
                                                    {
                                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount",
                                                            row.Index, decimal.Parse("0.00"));
                                                        bIsCredit = false;
                                                    }

                                                    if (bIsHideCus_Sup || sCus_Sup_ID == "")
                                                    {
                                                        sSupplier_ID = sCustomer_ID = "default";
                                                    }
                                                    else
                                                    {
                                                        if ((bIsAdvanceJE && sType == "Customer") || bIsDebtorJE)
                                                        {
                                                            sCustomer_ID = sCus_Sup_ID;
                                                            sSupplier_ID = "default";
                                                        }
                                                        else if ((bIsAdvanceJE && sType == "Supplier") || !bIsDebtorJE)
                                                        {

                                                            sCustomer_ID = "default";
                                                            sSupplier_ID = sCus_Sup_ID;
                                                        }
                                                        else
                                                        {
                                                            sCustomer_ID = "default";
                                                            sSupplier_ID = "default";
                                                        }
                                                    }

                                                    #region Insert tbl_accJournalEntry_Detail

                                                    tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(
                                                        iRow, txtJournalID.Text.Trim(), "default",
                                                        sGLCode, sCustomer_ID, sSupplier_ID, "default", sAccountNo,
                                                        sSubAcct1_ID, sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0,
                                                        clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                                    Insdetail.Insert();

                                                    #endregion
                                                }

                                                #endregion

                                                #region  Update Header - Journal

                                                tbl_accJournalEntry detail = new tbl_accJournalEntry(
                                                    txtJournalID.Text.ToString().Trim(), oldRecord.JournalEntryType_ID,
                                                    dtpJVDate.Value, txtNarration.Text.ToString().Trim(),
                                                    txtNarration.Text.ToString().Trim(), oldRecord.GlPosting_ID,
                                                    clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                                    clsSecurity.FinancialYearID, clsSecurity.CompanyID,
                                                    clsSecurity.BranchID,
                                                    decimal.Parse(txtTotCredit.Text.ToString().Trim()),
                                                    oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                    oldRecord.CheckedUser_ID,
                                                    oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID,
                                                    oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID,
                                                    clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID,
                                                    oldRecord.PrintedTerminal_ID,
                                                    oldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                    oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.DateDeleted,
                                                    oldRecord.DatePrinted, oldRecord.IsChecked, oldRecord.IsApproved,
                                                    oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked,
                                                    oldRecord.IsSeattled, oldRecord.PrintCount);
                                                detail.Update();

                                                #endregion

                                                clsMethods_GL.PostTransaction_Journal(txtJournalID.Text.Trim(), sSlotID);

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked),
                                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show("Can not Update \nThis Entry is already settled..",
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show("Can not Update \nThis Entry is already reconciled..",
                                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked),
                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        #region Genarate Journal ID
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtJournalID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtJournalID.Text)) //if (txtJournalID.Text.Length > 0)
                        {
                            #region  Insert Header - Journal
                            tbl_accJournalEntry detail = new tbl_accJournalEntry(txtJournalID.Text.ToString().Trim(), sFormConfigCode, dtpJVDate.Value, txtNarration.Text.ToString().Trim(),
                                                   txtNarration.Text.ToString().Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                                   decimal.Parse(txtTotCredit.Text.ToString().Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default",
                                                   "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                   clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, 0);
                            detail.Insert();
                            #endregion

                            #region  Insert Detail - Journal
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                bool bIsCredit = true;
                                string sSupplier_ID = "", sCustomer_ID = "";

                                string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                string sCus_Sup_ID = clsValidate.ValidateGridValue(dgvDetail, "cus_sup_ID", row.Index, "");
                                string sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc1_ID", row.Index, "");
                                string sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc2_ID", row.Index, "");
                                string sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                                string sType = clsValidate.ValidateGridValue(dgvDetail, "Type", row.Index, "");

                                string sAccountNo = "default";
                                int iCompanyAccID = -1;
                                foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLCode))
                                {
                                    foreach (tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount.SelectAll().Where(p => p.AccountNumber == oGLBank.AccountNumber))
                                    {
                                        iCompanyAccID = oComAcc.CompanyAccount_ID;
                                    }
                                    sAccountNo = oGLBank.AccountNumber;
                                }

                                decimal dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                if (dAmount == 0)
                                {
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                    bIsCredit = false;
                                }

                                if (bIsHideCus_Sup || sCus_Sup_ID == "")
                                {
                                    sSupplier_ID = sCustomer_ID = "default";
                                }
                                else
                                {
                                    if ((bIsAdvanceJE && sType == "Customer") || bIsDebtorJE)
                                    {
                                        sCustomer_ID = sCus_Sup_ID;
                                        sSupplier_ID = "default";
                                    }
                                    else if ((bIsAdvanceJE && sType == "Supplier") || !bIsDebtorJE)
                                    {

                                        sCustomer_ID = "default";
                                        sSupplier_ID = sCus_Sup_ID;
                                    }
                                    else
                                    {
                                        sCustomer_ID = "default";
                                        sSupplier_ID = "default";
                                    }
                                }

                                #region Insert tbl_accJournalEntry_Detail
                                tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(iRow, txtJournalID.Text.Trim(), "default",
                                    sGLCode, sCustomer_ID, sSupplier_ID, "default", sAccountNo, sSubAcct1_ID, sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0, clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            clsMethods_GL.PostTransaction_Journal(txtJournalID.Text.Trim(), sSlotID);
                            Attachments.Insert(txtJournalID.Text);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show(" Entry " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    tbl_accJournalEntry Fdetail = tbl_accJournalEntry.Select(txtJournalID.Text.ToString());
                    if (Fdetail != null)
                        FillDetails(txtJournalID.Text.ToString().Trim());
                }
            }
        }
        #endregion

        #region Btn Cancel
        private void UC_AccJournalEntry_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJournalID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_accJournalEntry detail = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                            if (detail != null)
                            {
                                bool bIsReconciled = false;
                                foreach (tbl_accJournalEntry_Detail oJEDetailRec in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(txtJournalID.Text.Trim()).Where(p => p.IsReconciled))
                                {
                                    bIsReconciled = true;
                                    break;
                                }

                                if (!bIsReconciled)
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Journal Voucher : " + detail.JournalEntry_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                if (clsHelpMethods_Local.RemoveSattlementsFrom_JournalEntryID(detail.JournalEntry_ID))
                                                {
                                                    clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                                    detail.IsDeleted = true;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();
                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show("Can not Cancel \nThis Entry is already reconciled..",
                                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
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
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Print
        private void UC_AccJournalEntry_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void UC_AccJournalEntry_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Add n Delete - Data Grid
        private void Btn_AddRow_Click(object sender, EventArgs e)
        {
            if (CheckValidity_AddNewRow())
            {
                dt_GLP.Rows.Add();

                int i = 1;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    row.Cells["Line_No"].Value = i++;
                }
            }
        }
        private void Btn_GridDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count > 0)
            {
                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                int i = 1;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    row.Cells["Line_No"].Value = i++;
                }
            }
        }
        #endregion

        #region Btn Temp
        private void UC_AccJournalEntry_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtJournalID.TextLength > 0 && txtJournalID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJournalID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblJournalID, true);

                txtJournalID.Tag = null;
                dtpJVDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtJournalID.Text = "<Auto Generate>";
                else
                    txtJournalID.Clear();
                if (txtJournalID.Enabled)
                {
                    txtJournalID.SelectAll();
                    txtJournalID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Event Double Click
        private void txtJournalID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_JournalEntry_Trasaction(ref txtJournalID, chkShowSettle.Checked, sFormConfigCode);
            if (txtJournalID.Text != null || txtJournalID.Text.Length > 0)
                FillDetails(txtJournalID.Text.ToString().Trim());
        }
        #endregion

        #region Event KeyDown
        private void txtJournalID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                txtJournalID_DoubleClick(sender, e);
        }
        #endregion

        #region Event Data Grid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region GL Account
                if (sColName == "accCode" || sColName == "accName")
                {
                    List<string> lstParameeters = new List<string>();
                    lstParameeters.Add("%");
                    if (enmForm == FormName.accJournalEntry_Bank)
                    {
                        lstParameeters.Add(clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank));
                        lstParameeters.Add(clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));
                    }
                    else
                    {
                        lstParameeters.Add("");
                        lstParameeters.Add("-");
                    }

                    frmSearch RowDataSearch = new frmSearch(lstParameeters);
                    List<string> lstResult = RowDataSearch.Show(Search.AccName);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        #region Supplier Contral Acc. Selected
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor) == lstResult[2])
                        {
                            if (enmForm == FormName.accJournalEntry_Creditor)
                            {
                                List<string> lstParameeters2 = new List<string>();
                                frmSearch oSearch = null;
                                lstParameeters2.Add(clsSecurity.BranchID);
                                lstParameeters2.Add(lstResult[0]);

                                oSearch = new frmSearch(lstParameeters2);
                                List<string> lstResult2 = oSearch.Show(Search.Supplier_ByControlAcc);

                                if (oSearch.DialogResult == DialogResult.OK)
                                {
                                    string sSupplier_ID = lstResult2[0];
                                    string sGlAcc_Supplier = clsMethods_GL.getAccountCode_Supplier(sSupplier_ID);
                                    if (sGlAcc_Supplier != "default")
                                    {
                                        dgvDetail["cus_sup_ID", e.RowIndex].Value = sSupplier_ID;
                                        dgvDetail["cus_sup_Name", e.RowIndex].Value = lstResult2[1];
                                        dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Supplier;
                                        dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Supplier);
                                    }
                                }
                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Invalid Gl Account Code.. ", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                        #endregion
                        #region Customer Contral Acc. Selected
                        else if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor) == lstResult[2])
                        {
                            if (enmForm == FormName.accJournalEntry_Debtor)
                            {
                                List<string> lstParameeters2 = new List<string>();
                                frmSearch oSearch = null;
                                lstParameeters2.Add(clsSecurity.BranchID);
                                lstParameeters2.Add(lstResult[0]);

                                oSearch = new frmSearch(lstParameeters2);
                                List<string> lstResult2 = oSearch.Show(Search.Customer_ByControlAcc);

                                if (oSearch.DialogResult == DialogResult.OK)
                                {
                                    string sCustomer_ID = lstResult2[0];
                                    string sGlAcc_Customer = clsMethods_GL.GetAccountCode_Customer(sCustomer_ID);
                                    if (sGlAcc_Customer != "default")
                                    {
                                        dgvDetail["cus_sup_ID", e.RowIndex].Value = sCustomer_ID;
                                        dgvDetail["cus_sup_Name", e.RowIndex].Value = lstResult2[1];
                                        dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Customer;
                                        dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Customer);
                                    }
                                }
                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Invalid Gl Account Code.. ", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                        #endregion
                        else
                        {
                            dgvDetail["AccCode", e.RowIndex].Value = lstResult[0];
                            dgvDetail["AccName", e.RowIndex].Value = lstResult[1];
                            dgvDetail["cus_sup_ID", e.RowIndex].Value = "";
                            dgvDetail["cus_sup_Name", e.RowIndex].Value = "";
                        }
                    }
                }
                #endregion

                #region Sub Account 1
                else if (sColName == "subAcc1Name")
                {
                    List<string> lstParameeters = new List<string>();
                    frmSearch RowDataSearch = null;

                    RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.CostCentre1);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        string sSubAcc1_ID = lstResult[0];
                        string sSubAcc1_Name = lstResult[1];
                        if (sSubAcc1_ID != "default")
                        {
                            dgvDetail["subAcc1_ID", e.RowIndex].Value = sSubAcc1_ID;
                            dgvDetail["subAcc1Name", e.RowIndex].Value = sSubAcc1_Name;
                        }
                    }
                }
                #endregion

                #region Sub Account 2
                else if (sColName == "subAcc2Name")
                {
                    List<string> lstParameeters = new List<string>();
                    frmSearch RowDataSearch = null;

                    RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.CostCentre2);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        string sSubAcc2_ID = lstResult[0];
                        string sSubAcc2_Name = lstResult[1];
                        if (sSubAcc2_ID != "default")
                        {
                            dgvDetail["subAcc2_ID", e.RowIndex].Value = sSubAcc2_ID;
                            dgvDetail["subAcc2Name", e.RowIndex].Value = sSubAcc2_Name;
                        }
                    }
                }
                #endregion

                #region Supplier
                else if (sColName == "cus_sup_Name")
                {
                    if (!bIsAdvanceJE)
                    {
                        #region Supplier Search
                        if (!bIsDebtorJE)
                        {
                            List<string> lstParameeters = new List<string>();
                            frmSearch RowDataSearch = null;
                            lstParameeters.Add(clsSecurity.BranchID);

                            RowDataSearch = new frmSearch(lstParameeters);
                            List<string> lstResult = RowDataSearch.Show(Search.Supplier);
                            if (RowDataSearch.DialogResult == DialogResult.OK)
                            {
                                string sSupplier_ID = lstResult[0];
                                string sGlAcc_Supplier = clsMethods_GL.getAccountCode_Supplier(sSupplier_ID);
                                if (sGlAcc_Supplier != "default")
                                {
                                    dgvDetail["cus_sup_ID", e.RowIndex].Value = sSupplier_ID;
                                    dgvDetail["cus_sup_Name", e.RowIndex].Value = lstResult[1];

                                    dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Supplier;
                                    dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Supplier);
                                }
                                else
                                    System.Windows.Forms.MessageBox.Show("Please Link control account to Supplier <" + sSupplier_ID + ">", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            }
                        }
                        #endregion

                        #region Customer Search
                        else
                        {
                            //frmSearch RowDataSearch = new frmSearch();
                            //List<string> lstResult = RowDataSearch.Show(Search.Customer);

                            List<string> lstParameeters = new List<string>();
                            lstParameeters.Add(clsSecurity.BranchID);
                            lstParameeters.Add("0");

                            frmSearch RowDataSearch = new frmSearch(lstParameeters);
                            List<string> lstResult = RowDataSearch.Show(Search.Customer);

                            if (RowDataSearch.DialogResult == DialogResult.OK)
                            {
                                string sCustomer_ID = lstResult[0];
                                string sGlAcc_Customer = clsMethods_GL.GetAccountCode_Customer(sCustomer_ID);
                                if (sGlAcc_Customer != "default")
                                {
                                    dgvDetail["cus_sup_ID", e.RowIndex].Value = sCustomer_ID;
                                    dgvDetail["cus_sup_Name", e.RowIndex].Value = lstResult[1];
                                    dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Customer;
                                    dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Customer);
                                }
                                else
                                    System.Windows.Forms.MessageBox.Show("Please Link control account to cutomer <" + sCustomer_ID + ">", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            }
                        }
                        #endregion
                    }

                    #region Advance Search
                    else
                    {
                        frmSearch RowDataSearch = null;
                        RowDataSearch = new frmSearch();
                        List<string> lstResult = RowDataSearch.Show(Search.Customer_Supplier);
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            string sCusSu_ID = lstResult[0];
                            string sGlAcc_Supplier = clsMethods_GL.getAccountCode_Supplier(sCusSu_ID);
                            string sGldAcc_Customer = clsMethods_GL.GetAccountCode_Customer(sCusSu_ID);
                            if (sGlAcc_Supplier != "default")
                            {
                                dgvDetail["cus_sup_ID", e.RowIndex].Value = sCusSu_ID;
                                dgvDetail["cus_sup_Name", e.RowIndex].Value = lstResult[1];
                                dgvDetail["Type", e.RowIndex].Value = lstResult[2];
                                dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Supplier;
                                dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Supplier);

                            }
                            else if (sGldAcc_Customer != "default")
                            {
                                dgvDetail["cus_sup_ID", e.RowIndex].Value = sCusSu_ID;
                                dgvDetail["cus_sup_Name", e.RowIndex].Value = lstResult[1];
                                dgvDetail["Type", e.RowIndex].Value = lstResult[2];
                                dgvDetail["AccCode", e.RowIndex].Value = sGldAcc_Customer;
                                dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGldAcc_Customer);

                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Please Link control account to <" + sCusSu_ID + ">", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                    }
                    #endregion
                }
                #endregion
            }
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                decimal dDebitAmount = 0, dCreditAmount = 0;
                string sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region Add Debit Amount
                if (sColName == "debitAmount")
                {
                    string sAccCode = dgvDetail["AccCode", e.RowIndex].Value.ToString();
                    if (sAccCode != "" && sAccCode.Length > 0)
                    {
                        dDebitAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", e.RowIndex, decimal.Parse("0.00"));
                        dgvDetail["debitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount);

                        if (dDebitAmount > 0)
                            dgvDetail["creditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                        dgvDetail["debitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                #endregion

                #region Credit Amount
                else if (sColName == "creditAmount")
                {
                    string sAccCode = dgvDetail["AccCode", e.RowIndex].Value.ToString();
                    if (sAccCode != "" && sAccCode.Length > 0)
                    {
                        dCreditAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", e.RowIndex, decimal.Parse("0.00"));
                        dgvDetail["creditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount);

                        if (dCreditAmount > 0)
                            dgvDetail["debitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                        dgvDetail["creditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                #endregion

                CalcualteCreditDebit();
            }
        }

        private void dgvDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            CalcualteCreditDebit();
        }
        #endregion

        #region Calculation Credit n Debit
        private void CalcualteCreditDebit()
        {
            try
            {
                decimal dCreditAmount = 0, dDebitAmount = 0;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dCreditAmount += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                    dDebitAmount += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                }

                txtTotCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount);
                txtTotCredit.Tag = dCreditAmount;

                txtTotDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount);
                txtTotDebit.Tag = dDebitAmount;

                txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount - dCreditAmount);
                txtDifferance.Tag = (dDebitAmount - dCreditAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Clear Field
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJournalID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblJournalID, true);
            clsCommon.SetEnableDisable_NormalCheckBox(chkShowSettle, true);

            txtJournalID.Tag = null;

            txtNarration.Text = "";
            txtTotCredit.Text = "0.00";
            txtTotDebit.Text = "0.00";
            txtDifferance.Text = "0.00";

            dtpJVDate.Value = clsSecurity.getServerDateTime();

            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtJournalID.Text = "<Auto Generate>";
            else
                txtJournalID.Clear();

            if (txtJournalID.Enabled)
            {
                txtJournalID.SelectAll();
                txtJournalID.Focus();
            }
            dt_GLP.Rows.Clear();

            dt_GLP.Rows.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sJournalID)
        {
            try
            {
                if (sJournalID.Length > 0 && sJournalID != "<Auto Generate>")
                {
                    ClearFields();
                    tbl_accJournalEntry detail = tbl_accJournalEntry.Select(sJournalID);
                    if (detail != null)
                    {
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJournalID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblJournalID, false);
                        clsCommon.SetEnableDisable_NormalCheckBox(chkShowSettle, false);

                        txtJournalID.Text = sJournalID;
                        dtpJVDate.Value = detail.JournalEntryDate;
                        txtNarration.Text = detail.Narration;
                        txtTotCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtTotDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal - detail.GrandTotal);

                        bHasApproved = detail.IsApproved;
                        bHasChecked = detail.IsChecked;

                        userDetailsColorChanges();

                        FillDetailGLCodes(sJournalID);

                        Attachments.FillAttachments(sJournalID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Detail GL Code
        private void FillDetailGLCodes(string sJournalEntry_ID)
        {
            dt_GLP.Rows.Clear();

            foreach (tbl_accJournalEntry_Detail detail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntry_ID))
            {
                decimal dDebitAmount = 0, dCreditAmount = 0;
                if (!detail.IsCredit)
                    dDebitAmount = detail.Amount;
                else
                    dCreditAmount = detail.Amount;

                if (bIsAdvanceJE)
                    dt_GLP.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.CostCenter1_ID, clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), detail.CostCenter2_ID, clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID),
                                   detail.Customer_ID != "default" ? detail.Customer_ID : detail.Supplier_ID != "default" ? detail.Supplier_ID : "default",
                                    detail.Customer_ID != "default" ? clsGenaralName.getName_Customer(detail.Customer_ID) : detail.Supplier_ID != "default" ? clsGenaralName.getName_Supplier(detail.Supplier_ID) : "",
                                   clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount), clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount), detail.Remarks,
                                   detail.Customer_ID != "default" ? "Customer" : detail.Supplier_ID != "default" ? "Supplier" : "");
                else
                    dt_GLP.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.CostCenter1_ID, clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), detail.CostCenter2_ID, clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID),
                                       bIsDebtorJE ? detail.Customer_ID : detail.Supplier_ID,
                                       bIsDebtorJE ? clsGenaralName.getName_Customer(detail.Customer_ID) : clsGenaralName.getName_Supplier(detail.Supplier_ID),
                                       clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount), clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount), detail.Remarks);
            }
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtJournalID.Text.Trim().Length > 0 && txtJournalID.Text.Trim() != "<Auto Generate>")
                {
                    Cursor = Cursors.WaitCursor;
                    glb_dts_Accounts.dt_acc_AccountJurnalVoucher.Clear();
                    glb_dts_Accounts.dt_acc_AccountJournalVoucher_Detail.Clear();
                    glb_dts_Accounts.dt_Company.Clear();

                    
                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDuplicateCopy = "", sCancel = "";
                    string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                    #endregion

                    if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_JournalVoucher), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                    {
                        bool bPermissinOkToPrint = true;

                        if (chkPrintOriginal.Checked)
                            bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_JournalVoucher));
                        if (bPermissinOkToPrint)
                        {
                            tbl_accJournalEntry oJV = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                            if (oJV != null)
                            {
                                #region Set Duplicate, Cancel and User Details
                                if (!bIsDraft)
                                {
                                    //if (oJV.PrintCount > 0)
                                    //    sDuplicateCopy = "Duplicate Copy " + oJV.PrintCount;

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicateCopy = (oJV.PrintCount > 0) ? "Duplicate Copy " + oJV.PrintCount : "";

                                    oJV.PrintCount++;
                                    oJV.Update();
                                }

                                sCreateUser = "[ " + clsGenaralName.getName_User(oJV.CreateUser_ID) + " ] [ " + oJV.DateCreate.ToShortDateString() + " ]";
                                if (oJV.IsChecked)
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(oJV.CheckedUser_ID) + " ] [ " + oJV.DateChecked.ToShortDateString() + " ]";
                                if (oJV.IsApproved)
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(oJV.ApprovedUser_ID) + " ] [ " + oJV.DateApproved.ToShortDateString() + " ]";
                                #endregion

                                #region Fill Dataset
                                glb_dts_Accounts.dt_acc_AccountJurnalVoucher.Adddt_acc_AccountJurnalVoucherRow(oJV.JournalEntry_ID, oJV.JournalEntryDate, oJV.JournalEntryType_ID, oJV.Narration, oJV.Remark, oJV.GrandTotal, oJV.IsDeleted);
                                foreach (tbl_accJournalEntry_Detail detail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(oJV.JournalEntry_ID))
                                {
                                    glb_dts_Accounts.dt_acc_AccountJournalVoucher_Detail.Adddt_acc_AccountJournalVoucher_DetailRow(oJV.JournalEntry_ID, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID),
                                        detail.Supplier_ID, clsGenaralName.getName_Supplier(detail.Supplier_ID), clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), detail.IsCredit, detail.Amount, detail.Remarks);
                                }
                                #endregion

                                #region Fill Parameters
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", clsGenaralName.getName_User(oJV.CreateUser_ID), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", clsGenaralName.getName_User(oJV.CheckedUser_ID), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", clsGenaralName.getName_User(oJV.ApprovedUser_ID), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oJV.IsDeleted ? "CANCELLED" : "", true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                #endregion

                                #region Company Details Fill
                                string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                byte[] bCompanyImage = clsCommon.getCompanyImage();
                                if (bIsDraft)
                                {
                                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                    {
                                        sCompanyName = "";
                                        sCompanyAddress1 = "";
                                        sCompanyAddress2 = "";
                                        bCompanyImage = null;
                                    }
                                }
                                glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                #endregion

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_JournalVoucher));
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Please Select the Journal Voucher To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                glb_dts_Accounts.dt_acc_AccountJurnalVoucher.Rows.Clear();
                Cursor = Cursors.Default;
            }
        }
      

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                    {
                        if (CheckValidity_Grid())
                            bStatus = true;
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_AddNewRow()
        {
            bool bStatus = true;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                decimal dAmountCr = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                decimal dAmountDb = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                if (sGLCode == "" || dAmountCr + dAmountDb == 0)
                {
                    MessageBox.Show("Please complete Transaction line " + iRow.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                    break;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_Grid()
        {
            bool bStatus = true;
            int iConAccCount_CR = 0, iConAccCount_DB = 0, iConAccCount_BE = 0; ;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                decimal dAmountCr = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                decimal dAmountDb = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                string sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc1_ID", row.Index, "");
                string sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc2_ID", row.Index, "");

                if (sGLCode == "" || dAmountCr + dAmountDb == 0)
                {
                    MessageBox.Show("Please complete Transaction line " + iRow.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                    break;
                }
                if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor) == clsGenaralName.getName_controlAccountTypeByGLID(sGLCode))
                    iConAccCount_CR++;

                if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor) == clsGenaralName.getName_controlAccountTypeByGLID(sGLCode))
                    iConAccCount_DB++;

                if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Bank) == clsGenaralName.getName_controlAccountTypeByGLID(sGLCode))
                    iConAccCount_BE++;

                if (sSubAcct1_ID == null || sSubAcct1_ID == "")
                    dgvDetail["subAcc1_ID", row.Index].Value = "default";

                if (sSubAcct2_ID == null || sSubAcct2_ID == "")
                    dgvDetail["subAcc2_ID", row.Index].Value = "default";
            }

            if (enmForm == FormName.accJournalEntry_Creditor)
            {
                if (iConAccCount_CR == 0)
                {
                    MessageBox.Show("Please select Creditor Account(s) to Proceed..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
                if (iConAccCount_DB != 0)
                {
                    MessageBox.Show("Sorry...!/nYou Cannot select Debter Account(s) in Crediter journal..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
            }
            else if (enmForm == FormName.accJournalEntry_Debtor)
            {
                if (iConAccCount_DB == 0)
                {
                    MessageBox.Show("Please select Debter Account(s) to Proceed..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
                if (iConAccCount_CR != 0)
                {
                    MessageBox.Show("Sorry...!/nYou Cannot select Crediter Account(s) in Crediter Debter journal..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
            }
            else if (enmForm == FormName.accJournalEntry_Bank)
            {
                if (iConAccCount_BE < 1)
                {
                    MessageBox.Show("Please add at least one Bank Account to Proceed..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            CalcualteCreditDebit();

            if (txtDifferance.Text == "" || decimal.Parse(txtDifferance.Text.Trim()) != 0)
            {
                strMessage += "\n" + "Debit totals should be same as credit totals to process this journal entry! ";
                bStatus = false;
            }
            if (dgvDetail.RowCount <= 0)
            {
                strMessage += "\n" + "Please enter entries to process this journal entry! ";
                bStatus = false;
            }

            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        #endregion

        #region Approved and Checked Details
        private void UC_AccJournalEntry_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void UC_AccJournalEntry_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtJournalID.Text != null && txtJournalID.TextLength > 0 && txtJournalID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
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
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_accJournalEntry objJV = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                                        if (objJV != null)
                                        {
                                            objJV.IsApproved = true;
                                            objJV.DateApproved = clsSecurity.getServerDateTime();
                                            objJV.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objJV.Update();
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CheckedBy()
        {
            try
            {
                if (txtJournalID.Text != null && txtJournalID.TextLength > 0 && txtJournalID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
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
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_accJournalEntry objJV = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                                        if (objJV != null)
                                        {
                                            objJV.IsChecked = true;
                                            objJV.DateChecked = clsSecurity.getServerDateTime();
                                            objJV.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objJV.Update();
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region User Details
        private void UC_AccJournalEntry_SF_History_Click(object sender, EventArgs e)
        {
            if (txtJournalID.Text != "" || txtJournalID.Text != "<Auto Generate>")
            {
                tbl_accJournalEntry detail = tbl_accJournalEntry.Select(txtJournalID.Text);
                if (detail != null)
                {
                    DataTable dt_UserDetails = new DataTable();
                    dt_UserDetails.Columns.Add("usertype", typeof(string));
                    dt_UserDetails.Columns.Add("Column1", typeof(string));
                    dt_UserDetails.Columns.Add("user", typeof(string));
                    dt_UserDetails.Columns.Add("Column2", typeof(string));
                    dt_UserDetails.Columns.Add("datetime", typeof(string));

                    dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                    if (detail.DateCreate != detail.DateModified)
                        dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                    if (detail.IsChecked)
                        dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                    if (detail.IsApproved)
                        dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                    if (detail.IsDeleted)
                        dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

                    Point startPoint = this.PointToScreen(new Point());

                    frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                    frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                }
            }
        }
        #endregion

        #endregion

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (xSetting.Visible == true)
                xSetting.Visible = false;
            else
            {
                xSetting.Visible = true;
                xSetting.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion
    }
}