using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic;
using Digiteq.DataSets;
using System.Linq;
using System.Drawing;

namespace Digiteq
{
    public partial class frm_accJournalVoucher : SEACC_Form
    {
        #region Variables
        //public FormName glbFormName = FormName.accJournalEntry;
        int sSlotID;
        //string sFormConfigCode;

        private BindingSource source = new BindingSource();
        private DataTable dtAllRecodes = new DataTable();

        public string glbJournalEntryID = "";
        //to manage update and insert
        //static bool IsUpdate = false;

        decimal dTotCredit;
        decimal dTotDebit;

        //for security handle
        //public int iFormID;
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;

        //    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        DataTable glb_dtCreditEntry;
        DataTable glb_dtDebitEntry;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Accounts glb_dts_Accounts = new dts_Accounts();
        #endregion

        #region From Load
        public frm_accJournalVoucher(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            //glbFormName = _glbFormName;
            //iFormID = clsSecurity.getFormID(glbFormName);

            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            #region get transaction Code
            tbl_securityFormMaster oForm = tbl_securityFormMaster.Select(iFormID);
            if (oForm != null)
            {
                foreach (tbl_securityConfigForms detail in tbl_securityConfigForms.SelectAll().Where(p => p.DocumentCode == oForm.DocumentCode))
                {
                    txtTxnType.Text = detail.TxnCode;
                    txtTxnType.Tag = detail.ConfigForm_ID;
                    break;
                }
            }
            #endregion
        }

        private void frm_accJournalVoucher_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, false);

            CreateDataTable(TransactionCategory.CreditEntry);
            CreateDataTable(TransactionCategory.DebitEntry);

            #region format Form
            if (enmForm == FormName.accJournalEntry_Bank)
            {
                //clsFormatter.setFormatForm(this, "Journal Entry (BE)", 2, iFormID);
                sSlotID = clsAutocode.getAccSlotID(AccSlot.BankAdjustmentEntries);
                //sFormConfigCode = clsAutocode.getFormConfigCode(glbFormName);
            }
            else
            {
                //clsFormatter.setFormatForm(this, "Journal Entry (JE)", 2, iFormID);
                sSlotID = clsAutocode.getAccSlotID(AccSlot.JournalVoucher);
                //sFormConfigCode = clsAutocode.getFormConfigCode(glbFormName);
            }
            #endregion

            CusDataGridViewFormat();
            ClearFields();

            if (glbJournalEntryID.Length > 0)
                FillDetails(glbJournalEntryID);
        }
        #endregion

        #region Btn Remove
        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count >= 1)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                    CalculateBalance();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Btn Save
        private void frm_accJournalVoucher_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_accJournalEntry oldRecord = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                if (!oldRecord.IsChecked ||
                                    (oldRecord.IsChecked &&
                                     clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtJournalID.Text))
                                    {

                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                        tbl_accJournalEntry_Detail
                                            .DeleteAllByJournalEntry_ID(oldRecord.JournalEntry_ID);

                                        #region  Insert Detail - Journal

                                        string sGLCode = "",
                                            sSubAcct1 = "",
                                            sSubAcct2 = "",
                                            sSubAcct1_ID = "",
                                            sSubAcct2_ID = "",
                                            sEmployee_ID = "",
                                            sOtherCr = "",
                                            sCategoryID = "",
                                            sRemarks = ""; // sEmployee = "", 
                                        bool bIsCredit;
                                        decimal dAmount;

                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            int iRow, iCompanyAccID = -1;
                                            sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index,
                                                "");
                                            sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index,
                                                "");
                                            sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index,
                                                "");
                                            sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID",
                                                row.Index, "");
                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index,
                                                "");
                                            sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index,
                                                "default");
                                            sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index,
                                                "default");
                                            sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index,
                                                "default");
                                            sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index,
                                                "default");
                                            bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index,
                                                true);
                                            iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                int.Parse("0"));
                                            if (bIsCredit)
                                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount",
                                                    row.Index, decimal.Parse("0.00"));
                                            else
                                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount",
                                                    row.Index, decimal.Parse("0.00"));

                                            string sAccoNumber = "default";
                                            foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank
                                                .SelectAllByGl_ID(sGLCode))
                                            {
                                                foreach (tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount
                                                    .SelectAll().Where(p => p.AccountNumber == oGLBank.AccountNumber))
                                                {
                                                    iCompanyAccID = oComAcc.CompanyAccount_ID;
                                                }

                                                sAccoNumber = oGLBank.AccountNumber;
                                            }

                                            #region Insert tbl_accJournalEntry_Detail

                                            tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(iRow,
                                                txtJournalID.Text.Trim(), sCategoryID,
                                                sGLCode, sOtherCr, "Default", sEmployee_ID, sAccoNumber, sSubAcct1_ID,
                                                sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0,
                                                clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                            Insdetail.Insert();

                                            #endregion
                                        }

                                        #endregion



                                        //foreach (tbl_accJournalEntry_Detail JEdetail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(txtJournalID.Text.ToString()))
                                        //{
                                        //    int iRow = 0;
                                        //    string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee = "", sEmployee_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";
                                        //    bool bIsCredit = false;
                                        //    decimal dAmount = 0;
                                        //    bool bHasItemInDB = false;

                                        //    foreach (DataGridViewRow row in dgvDetail.Rows)
                                        //    {
                                        //        sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                        //        sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                        //        sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                        //        sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                        //        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                        //        sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index, "default");
                                        //        sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index, "default");
                                        //        sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
                                        //        sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index, "default");
                                        //        bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);
                                        //        iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));

                                        //        if (bIsCredit)
                                        //            dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                        //        else
                                        //            dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));


                                        //        if (iRow == JEdetail.Line_No && JEdetail.JournalEntry_ID == txtJournalID.Text.Trim() && sCategoryID == JEdetail.Tc_ID && sGLCode == JEdetail.Gl_ID)
                                        //        {
                                        //            bHasItemInDB = true;
                                        //            dgvDetail.Rows.RemoveAt(row.Index);
                                        //            break; //database contain this item
                                        //        }
                                        //    }
                                        //    if (bHasItemInDB)
                                        //    {
                                        //        JEdetail.Line_No = iRow;
                                        //        JEdetail.Gl_ID = sGLCode;
                                        //        JEdetail.CostCenter1_ID = sSubAcct1_ID;
                                        //        JEdetail.CostCenter2_ID = sSubAcct2_ID;
                                        //        JEdetail.Employee_ID = sEmployee_ID;
                                        //        JEdetail.Customer_ID = sOtherCr;
                                        //        JEdetail.Tc_ID = sCategoryID;
                                        //        JEdetail.Amount = dAmount;
                                        //        JEdetail.Remarks = sRemarks;
                                        //        JEdetail.Update();
                                        //    }
                                        //    else
                                        //    {
                                        //        JEdetail.Delete();
                                        //    }
                                        //}

                                        //#region  newly Insert Detail - Journal Details
                                        //foreach (DataGridViewRow row in dgvDetail.Rows)
                                        //{
                                        //    int iRow, iCompanyAccID = -1;
                                        //    string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";//sEmployee = "",
                                        //    bool bIsCredit;
                                        //    decimal dAmount;

                                        //    sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                        //    sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                        //    sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                        //    sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                        //    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                        //    sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index, "default");
                                        //    sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index, "default");
                                        //    sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
                                        //    sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index, "default");
                                        //    bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);
                                        //    iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                        //    if (bIsCredit)
                                        //        dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                        //    else
                                        //        dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                                        //    foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLCode))
                                        //    {                                            
                                        //        foreach(tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount.SelectAll().Where(p=> p.AccountNumber == oGLBank.AccountNumber))
                                        //        {
                                        //            iCompanyAccID = oComAcc.CompanyAccount_ID;
                                        //        }                                            
                                        //    }

                                        //    #region Insert tbl_accJournalEntry_Detail
                                        //    tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(iRow, txtJournalID.Text.Trim(), sCategoryID,
                                        //        sGLCode, sOtherCr, "Default", sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0, clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                        //    Insdetail.Insert();
                                        //    #endregion

                                        //    #region GL Posting Detail
                                        //    //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.PaymetVoucher), txtJournalID.Text.Trim(), sGLCode,
                                        //    //                    sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtJournalID.Text.Trim(), "default",
                                        //    //                    dtpJVDate.Value, txtNarration.Text.Trim(), dAmount, bIsCredit,"default", "default");
                                        //    //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, sSlotID, txtJournalID.Text.Trim(), sGLCode,
                                        //    //                    sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtJournalID.Text.Trim(), "default",
                                        //    //                    dtpJVDate.Value, txtNarration.Text.Trim(), dAmount, bIsCredit, "default", "default");
                                        //    #endregion
                                        //}
                                        //#endregion

                                        #region  Update Header - Journal Details

                                        tbl_accJournalEntry detail = new tbl_accJournalEntry(
                                            txtJournalID.Text.ToString().Trim(), oldRecord.JournalEntryType_ID,
                                            dtpJVDate.Value, txtNarration.Text.ToString().Trim(),
                                            txtNarration.Text.ToString().Trim(), oldRecord.GlPosting_ID,
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                            decimal.Parse(txtTotCredit.Text.ToString().Trim()), oldRecord.CreateUser_ID,
                                            clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
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
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        #region Genarate Journal ID
                        string sJournalEntryTypeID = txtTxnType.Tag.ToString();

                        if (clsAutocode.IsAutoGenerated(sJournalEntryTypeID))
                            txtJournalID.Text = clsAutocode.getAutoGeneratedCode(sJournalEntryTypeID);
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtJournalID.Text))// if (txtJournalID.Text.Length > 0)
                        {
                            #region  Insert Header - Journal
                            //2017-06-15 set narration value to remarks also - Thilini
                            tbl_accJournalEntry detail = new tbl_accJournalEntry(txtJournalID.Text.ToString().Trim(), sJournalEntryTypeID, dtpJVDate.Value, txtNarration.Text.ToString().Trim(),
                                                   txtNarration.Text.ToString().Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                                   decimal.Parse(txtTotCredit.Text.ToString().Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default",
                                                   "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                   clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false, false, false, false, 0);
                            detail.Insert();
                            #endregion

                            #region  Insert Detail - Journal

                            string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";// sEmployee = "", 
                            bool bIsCredit;
                            decimal dAmount;

                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                int iRow, iCompanyAccID = -1;
                                sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index, "default");
                                sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index, "default");
                                sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
                                sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index, "default");
                                bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);
                                iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                if (bIsCredit)
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                else
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                                string sAccoNumber = "default";
                                foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLCode))
                                {
                                    foreach (tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount.SelectAll().Where(p => p.AccountNumber == oGLBank.AccountNumber))
                                    {
                                        iCompanyAccID = oComAcc.CompanyAccount_ID;
                                    }
                                    sAccoNumber = oGLBank.AccountNumber;
                                }

                                #region Insert tbl_accJournalEntry_Detail
                                tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(iRow, txtJournalID.Text.Trim(), sCategoryID,
                                    sGLCode, sOtherCr, "Default", sEmployee_ID, sAccoNumber, sSubAcct1_ID, sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0, clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            clsMethods_GL.PostTransaction_Journal(txtJournalID.Text.Trim(), sSlotID);
                            Attachments.Insert(txtJournalID.Text);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_accJournalEntry Fdetail = tbl_accJournalEntry.Select(txtJournalID.Text.ToString());
                    if (Fdetail != null)
                        FillDetails(txtJournalID.Text.ToString().Trim());
                }
            }
        }
        #endregion

        #region Btn New
        private void frm_accJournalVoucher_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Print
        private void frm_accJournalVoucher_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_accJournalVoucher_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Cancel
        private void frm_accJournalVoucher_SF_cancelButton_Click(object sender, EventArgs e)
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
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Journal Voucher : " + detail.JournalEntry_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {

                                            #region Reverce Posting
                                            //List<tbl_accJournalEntry_Detail> JEdetails = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(txtJournalID.Text.ToString());
                                            //foreach (tbl_accJournalEntry_Detail JEdetail in JEdetails)
                                            //{
                                            //    clsMethods_Fin.GLPostingDetailTempDelete(JEdetail.Line_No, detail.GlPosting_ID);
                                            //}

                                            clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);
                                            #endregion

                                            detail.IsDeleted = true;
                                            detail.DateDeleted = clsSecurity.getServerDateTime();
                                            detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                            detail.Update();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Btn Checked, Approved and History
        private void frm_accJournalVoucher_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_accJournalVoucher_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_accJournalVoucher_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJournalID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTxnType, true);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtJournalID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblJournalID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblJournalID, true);

            txtTxnType.Tag = null;
            txtJournalID.Tag = null;

            txtTxnType.Text = "";
            txtAcctCode.Text = "";
            txtAcctCode.Tag = null;
            txtAcctCodeName.Text = "";
            txtCerditAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";

            txtNarration.Text = "";
            txtRemarks.Text = "";
            txtDifferance.Text = "0.00";
            txtTotCredit.Text = "0.00";
            txtTotDebit.Text = "0.00";
            lblIsCredit.Visible = false;
            lblIsCredit.Text = "";
            chkShowSettle.Checked = false;

            bHasChecked = false;
            bHasApproved = false;
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

            dgvDetail.Rows.Clear();
            glb_dtDebitEntry.Rows.Clear();
            glb_dtCreditEntry.Rows.Clear();

            clsEvent.GLCode_TextChanged(pbxDebitEntry, "");
            clsEvent.GLCode_TextChanged(pbxCreditEntry, "");

            Attachments.Clear();

        }
        private void ClearFieldsAccount()
        {
            txtAcctCode.Text = "";
            txtAcctCodeName.Text = "";
            txtCerditAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sEmployee = "", sOtherCr = "", sCategoryID = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sRemarks = "";

                if (glb_dtDebitEntry.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxDebitEntry, glb_dtDebitEntry, txtDebitAmount, null);
                    foreach (DataRow row in glb_dtDebitEntry.Rows)
                    {
                        //int iRow;
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        sGLCode = row["GLCode"].ToString();
                        sSubAcct1 = row["SubAcct1"].ToString();
                        sSubAcct2 = row["SubAcct2"].ToString();
                        sSubAcct1_ID = row["SubAcct1_ID"].ToString();
                        sSubAcct2_ID = row["SubAcct2_ID"].ToString();
                        sEmployee = row["Employee"].ToString();
                        sEmployee_ID = row["Employee_ID"].ToString();
                        sOtherCr = row["OtherCr"].ToString();
                        sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, false, dAmount);
                    }
                }
                if (glb_dtCreditEntry.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxCreditEntry, glb_dtCreditEntry, txtCerditAmount, null);
                    foreach (DataRow row in glb_dtCreditEntry.Rows)
                    {
                        //int iRow;
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        sGLCode = row["GLCode"].ToString();
                        sSubAcct1 = row["SubAcct1"].ToString();
                        sSubAcct2 = row["SubAcct2"].ToString();
                        sSubAcct1_ID = row["SubAcct1_ID"].ToString();
                        sSubAcct2_ID = row["SubAcct2_ID"].ToString();
                        sEmployee = row["Employee"].ToString();
                        sEmployee_ID = row["Employee_ID"].ToString();
                        sOtherCr = row["OtherCr"].ToString();
                        sCategoryID = row["CategoryID"].ToString();
                        sRemarks = row["Remarks"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount);
                    }
                }
                CalculateBalance();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

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
                        txtJournalID.Text = sJournalID;
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJournalID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtTxnType, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtJournalID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblJournalID, false);

                        txtTxnType.Tag = detail.JournalEntryType_ID;

                        tbl_securityConfigForms de = tbl_securityConfigForms.Select(detail.JournalEntryType_ID);
                        if (de != null)
                            txtTxnType.Text = de.TxnCode;

                        dtpJVDate.Value = detail.JournalEntryDate;
                        txtNarration.Text = detail.Narration;
                        txtRemarks.Text = detail.Remark;
                        txtTotCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtTotDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal - detail.GrandTotal);
                        txtDebitAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtCerditAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }
                        userDetailsColorChanges();

                        FillDetailGLCodes(sJournalID);
                        //RefreshGrid(sJournalID);  
                        RefreshGrid();

                        Attachments.FillAttachments(sJournalID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsAcctCode(string sAcct)
        {
            try
            {
                if (sAcct.Length > 0)
                {
                    tbl_accGLMaster detail = tbl_accGLMaster.Select(sAcct);
                    if (detail != null)
                    {
                        //asign values                             
                        txtAcctCode.Text = detail.Gl_ID;
                        txtAcctCodeName.Text = detail.GlName;
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

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string sGLCode, string sSubAcct1, string sSubAcct2, string sSubAcct1_ID, string sSubAcct2_ID, string sEmployee, string sEmployee_ID, string sOtherCr, string sCategoryID, string Remarks, bool bIsCredit, decimal dAmount)
        {
            try
            {
                dgvDetail["accCode", iRow].Value = sGLCode;
                dgvDetail["accName", iRow].Value = clsGenaralName.getName_AccountName(sGLCode);
                dgvDetail["subAcc1", iRow].Value = sSubAcct1;
                dgvDetail["subAcc2", iRow].Value = sSubAcct2;
                dgvDetail["employee", iRow].Value = sEmployee;
                dgvDetail["otherCr", iRow].Value = sOtherCr;
                dgvDetail["CategoryID", iRow].Value = sCategoryID;
                dgvDetail["Remarks", iRow].Value = Remarks;
                dgvDetail["IsCredit", iRow].Value = bIsCredit;
                dgvDetail["LineNo", iRow].Value = iRow + 1;
                dgvDetail["Remarks", iRow].Value = Remarks;

                dgvDetail["subAcc1", iRow].Tag = sSubAcct1_ID;
                dgvDetail["subAcc2", iRow].Tag = sSubAcct2_ID;
                dgvDetail["employee", iRow].Tag = sEmployee_ID;


                if (bIsCredit)
                {
                    dgvDetail["creditAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["debitAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                else
                {
                    dgvDetail["debitAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["creditAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtAcctCode_DoubleClick(object sender, EventArgs e)
        {
            SearchAcctTypeToAccountCode();
        }
        #endregion

        #region Events KeyPress
        private void txtCerditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtCerditAmount, e, 9, 2);
        }

        private void txtDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtDebitAmount, e, 9, 2);
        }
        #endregion

        #region Events KeyDown
        private void frm_accJournalVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtJournalID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtJournalID_DoubleClick(null, null);
        }
        private void txtAcctCode_KeyDown(object sender, KeyEventArgs e)
        {
            SearchAcctTypeToAccountCode();
        }
        #endregion

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                        bStatus = true;
                }
            }
            return bStatus;

        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            if (decimal.Parse(txtDifferance.Text.Trim()) > 0)
            {
                strMessage += "\n" + "Debit totals should be same as credit totals to process this journal entry! ";
                bStatus = false;
            }
            if (dgvDetail.RowCount <= 0)
            {
                strMessage += "\n" + "Please enter entries to process this journal entry! ";
                bStatus = false;
            }
            if (txtTxnType.Text == "")
            {
                strMessage += "\n" + "Please select transacton type! ";
                bStatus = false;
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtAcctCode);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Methods
        private void SearchAcctTypeToAccountCode()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode(ref txtAcctCode, "", "");

                if (txtAcctCode.Tag != null && txtAcctCode.Tag.ToString().Trim().Length > 0)
                    FillDetailsAcctCode(txtAcctCode.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void CalculateBalance()
        {
            try
            {
                decimal dCredit = 0, dDebit = 0, dAmount = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dCredit += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                    dDebit += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                }

                txtTotCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCredit);
                txtTotDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebit);

                dAmount = dCredit - dDebit;

                if (dAmount > 0)
                {
                    txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    lblIsCredit.Visible = true;
                    lblIsCredit.Text = "Cr.";
                }
                else
                {
                    txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount * (-1));
                    lblIsCredit.Visible = true;
                    lblIsCredit.Text = "Dr.";
                }

                if (dAmount == 0)
                {
                    txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    lblIsCredit.Visible = false;
                    lblIsCredit.Text = "";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
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
                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDuplicateCopy = "", sCancel = "";
                    tbl_accJournalEntry JV = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                    if (JV != null)
                    {
                        if (!bIsDraft)
                        {
                            if (JV.PrintCount > 0)
                                sDuplicateCopy = "Duplicate Copy " + JV.PrintCount;

                            JV.PrintCount++;
                            JV.Update();
                        }

                        sCreateUser = "[ " + clsGenaralName.getName_User(JV.CreateUser_ID) + " ] [ " + JV.DateCreate.ToShortDateString() + " ]";
                        if (JV.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(JV.CheckedUser_ID) + " ] [ " + JV.DateChecked.ToShortDateString() + " ]";
                        if (JV.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(JV.ApprovedUser_ID) + " ] [ " + JV.DateApproved.ToShortDateString() + " ]";

                        #region Print The Doc

                        string s_Path = "", sReportTitle = "";

                        #region Report Title
                        sReportTitle = clsGenaralName.getName_ConfigForm(txtTxnType.Tag.ToString());
                        #endregion

                        string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_JournalVoucher));

                        if (sGetRptPath != null && sGetRptPath.Length > 0)
                            s_Path += sGetRptPath;
                        else
                            s_Path += "\\Reports\\ACC\\NotePrinting\\rpt_accJournalVoucher_Genaral.rpt";

                        Cursor = Cursors.WaitCursor;
                        glb_dts_Accounts.Clear();

                        #region Fill Dataset
                        glb_dts_Accounts.dt_acc_AccountJurnalVoucher.Adddt_acc_AccountJurnalVoucherRow(JV.JournalEntry_ID, JV.JournalEntryDate, JV.JournalEntryType_ID, JV.Narration, JV.Remark, JV.GrandTotal, JV.IsDeleted);
                        foreach (tbl_accJournalEntry_Detail detail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(JV.JournalEntry_ID))
                        {
                            glb_dts_Accounts.dt_acc_AccountJournalVoucher_Detail.Adddt_acc_AccountJournalVoucher_DetailRow(JV.JournalEntry_ID, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID),
                                detail.Supplier_ID, clsGenaralName.getName_Supplier(detail.Supplier_ID), clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), detail.IsCredit, detail.Amount, detail.Remarks);
                        }
                        #endregion

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", clsGenaralName.getName_User(JV.CreateUser_ID), true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", clsGenaralName.getName_User(JV.CheckedUser_ID), true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", clsGenaralName.getName_User(JV.ApprovedUser_ID), true,false);


                        #region Report Feald Names Gen
                        // if (JournalEntryType.StandardJournalEntry == glb_JournalEntryType)
                        {
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NoColoumn", "Txn ID", true,false);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateColoumn", "Txn Date", true,false);
                        }
                        //else if (JournalEntryType.BankAdjustmentEntry == glb_JournalEntryType)
                        //{
                        //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NoColoumn", "BE No", true,false);
                        //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateColoumn", "BE Date", true,false);
                        //}
                        //else
                        //{
                        //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NoColoumn", "JV No", true,false);
                        //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateColoumn", "JV Date", true,false);

                        //}
                        #endregion

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", sCancel, true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", JV.IsDeleted ? "CANCELLED" : "", true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);


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

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                            }
                        }
                        glb_dts_Accounts.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "", "", "", clsSecurity.UserNameLoged, "");
                        #endregion

                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                        rpt.print(s_Path, glb_dts_Accounts, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_JournalVoucher));
                        #endregion
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
        #endregion

        #region Fill Detail GL Code
        private void FillDetailGLCodes(string sJournalEntry_ID)
        {
            try
            {
                //Clear GLs
                glb_dtDebitEntry.Rows.Clear();
                glb_dtCreditEntry.Rows.Clear();

                //Fill GLs
                List<tbl_accJournalEntry_Detail> details = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntry_ID);
                foreach (tbl_accJournalEntry_Detail detail in details)
                {
                    if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.DebitEntry).ToString())
                    {
                        glb_dtDebitEntry.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, detail.Tc_ID
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, detail.Remarks);
                        clsEvent.GLCode_TextChanged(pbxDebitEntry, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.CreditEntry).ToString())
                    {
                        glb_dtCreditEntry.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, detail.Tc_ID
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, detail.Remarks);
                        clsEvent.GLCode_TextChanged(pbxCreditEntry, "Accept");
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

        #region Events DoubleClick
        private void txtJournalID_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditeTxnType())
            {
                string sJournalEntryTypeID = txtTxnType.Tag.ToString(); ;

                clsSearch.Search_TransactionJournalVoucher_Direct(ref txtJournalID, chkShowSettle.Checked, sJournalEntryTypeID);
                FillDetails(txtJournalID.Text.ToString().Trim());
            }
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable(TransactionCategory eTCategory)
        {
            if (TransactionCategory.CreditEntry == eTCategory)
            {
                glb_dtCreditEntry = new DataTable();
                glb_dtCreditEntry.Columns.Add("Line_No", typeof(int));
                glb_dtCreditEntry.Columns.Add("GLCode", typeof(string));
                glb_dtCreditEntry.Columns.Add("GLName", typeof(string));
                glb_dtCreditEntry.Columns.Add("GLAmount", typeof(decimal));
                glb_dtCreditEntry.Columns.Add("SubAcct1", typeof(string));
                glb_dtCreditEntry.Columns.Add("SubAcct2", typeof(string));
                glb_dtCreditEntry.Columns.Add("Employee", typeof(string));
                glb_dtCreditEntry.Columns.Add("OtherCr", typeof(string));
                glb_dtCreditEntry.Columns.Add("CategoryID", typeof(int));
                glb_dtCreditEntry.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtCreditEntry.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtCreditEntry.Columns.Add("Employee_ID", typeof(string));
                glb_dtCreditEntry.Columns.Add("Remarks", typeof(string));
            }
            else if (TransactionCategory.DebitEntry == eTCategory)
            {
                glb_dtDebitEntry = new DataTable();
                glb_dtDebitEntry.Columns.Add("Line_No", typeof(int));
                glb_dtDebitEntry.Columns.Add("GLCode", typeof(string));
                glb_dtDebitEntry.Columns.Add("GLName", typeof(string));
                glb_dtDebitEntry.Columns.Add("GLAmount", typeof(decimal));
                glb_dtDebitEntry.Columns.Add("SubAcct1", typeof(string));
                glb_dtDebitEntry.Columns.Add("SubAcct2", typeof(string));
                glb_dtDebitEntry.Columns.Add("Employee", typeof(string));
                glb_dtDebitEntry.Columns.Add("OtherCr", typeof(string));
                glb_dtDebitEntry.Columns.Add("CategoryID", typeof(int));
                glb_dtDebitEntry.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtDebitEntry.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtDebitEntry.Columns.Add("Employee_ID", typeof(string));
                glb_dtDebitEntry.Columns.Add("Remarks", typeof(string));
            }
        }
        #endregion

        private void pbxDebitEntry_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtDebitAmount.Text.Trim()) && decimal.Parse(txtDebitAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtDebitEntry, decimal.Parse(txtDebitAmount.Text.Trim()), TransactionCategory.DebitEntry, iFormID, "", 1);
                if (glb_dtDebitEntry != null && glb_dtDebitEntry.Rows.Count > 0)
                    RefreshGrid();
            }
        }

        private void pbxCreditEntry_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtCerditAmount.Text.Trim()) && decimal.Parse(txtCerditAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtCreditEntry, decimal.Parse(txtCerditAmount.Text.Trim()), TransactionCategory.CreditEntry, iFormID, "", 1);
                if (glb_dtCreditEntry != null && glb_dtCreditEntry.Rows.Count > 0)
                    RefreshGrid();
            }
        }

        private void txtTxnType_DoubleClick(object sender, EventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(iFormID.ToString());

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Txn_Code);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtTxnType.Tag = lstResult[0];
                txtTxnType.Text = lstResult[2];
            }
        }

        private void txtTxnType_TextChanged(object sender, EventArgs e)
        {
            if (txtJournalID.Enabled == true && txtTxnType.Tag != null)
            {
                if (clsAutocode.IsAutoGenerated(txtTxnType.Tag.ToString()))
                    txtJournalID.Text = "<Auto Generate>";
                else
                    txtJournalID.Clear();
            }
        }


        #region Validite Txn Type
        private bool CheckValiditeTxnType()
        {
            bool rtn = true;
            if (txtTxnType.Tag == null)
            {
                rtn = false;
                MessageBox.Show("Please Select the Txn Type..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTxnType.Focus();
            }
            return rtn;
        }
        #endregion

        #region User Checked Approve Details
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
                                    glbApprovedDate = clsSecurity.getServerDateTime();
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
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                                    glbCheckedDate = clsSecurity.getServerDateTime();

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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void UserDetails()
        {
            try
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.Color.Red;
        //        this.btnChecked.ForeColor = System.Drawing.Color.Red;
        //        this.btnApproved.BackColor = System.Drawing.Color.White;
        //        this.btnChecked.BackColor = System.Drawing.Color.White;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion
        #endregion

    }
}

#region MyRegion
//private void RefreshGridGeneralLedger()
//{

//    int iRow;
//    //dgvDetail.Rows.Clear();

//    if (txtAcctCode.Text != null)
//    {
//        dgvDetail.Rows.Add();
//        iRow = dgvDetail.Rows.Count - 1;
//        dgvDetail["AcctCode", iRow].Value = txtAcctCode.Text.Trim();
//        dgvDetail["AcctCodeName", iRow].Value = txtAcctCodeName.Text.Trim();
//        if (decimal.Parse(txtCerditAmount.Text.Trim()) > 0)
//        {
//            dgvDetail["Credit", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtCerditAmount.Text));
//            dTotCredit += decimal.Parse(txtCerditAmount.Text.Trim());
//        }
//        else if (decimal.Parse(txtDebitAmount.Text.Trim()) > 0)
//        {
//            dgvDetail["Debit", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtDebitAmount.Text));
//            dTotDebit += decimal.Parse(txtDebitAmount.Text.Trim());
//        }
//        CalculateBalance();
//    }
//    ClearFieldsAccount();

//}
//private void RefreshGrid(string sJournalVoucherID)
//{
//    try
//    {
//        int iRow;
//        dgvDetail.Rows.Clear();
//        //List<tbl_accJournalEntry_Detail> details = tbl_accJournalEntry_Detail.Select(sJournalVoucherID);
//        List<tbl_accJournalEntry_Detail> details = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalVoucherID);
//        foreach (tbl_accJournalEntry_Detail detail in details)
//        {
//            dgvDetail.Rows.Add();
//            iRow = dgvDetail.Rows.Count - 1;

//            dgvDetail["AcctCode", iRow].Value = detail.Gl_ID;
//            dgvDetail["AcctCodeName", iRow].Value = clsGenaralName.getName_AccountName(detail.Gl_ID);
//            if (detail.IsCredit == true)
//            {
//                dgvDetail["Credit", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
//            }
//            else if (detail.IsCredit == false)
//            {
//                dgvDetail["Debit", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        SEACCException.Show(ex);
//        clsValidate.WriteErrorLog("", iFormID,ex);
//    }
//}




//private bool CheckValidityAcct()
//{
//    string strMessage = "";
//    bool bStatus = true;

//    if (txtAcctCode.TextLength == 0)
//    {
//        strMessage += "\n" + "Acct. Code ";
//        bStatus = false;
//    }

//    if (txtAcctCodeName.TextLength == 0)
//    {
//        strMessage += "\n" + "Acct. Name ";
//        bStatus = false;
//    }

//    if (decimal.Parse(txtCerditAmount.Text.Trim()) <= 0 && decimal.Parse(txtDebitAmount.Text.Trim()) <= 0)
//    {
//        strMessage += "\n" + "Credit Amount " + "or " + "Debit Amount ";
//        bStatus = false;
//    }

//    if (bStatus == false)
//    {
//        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//    return bStatus;
//}
//private bool CheckStatusValidityAcct()
//{
//    string strMessage = "";
//    bool bStatus = true;

//    try
//    {


//    }
//    catch (Exception ex)
//    {
//        SEACCException.Show(ex);
//    }
//    if (bStatus == false)
//    {
//        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//    return bStatus;
//}


//private bool ValidateGridIsExsistingRow(DataGridView dgvDataGrid, string sNewAcctCode)
//{
//    bool isExisting = false;
//    foreach (DataGridViewRow row in dgvDetail.Rows)
//    {
//        string sAcctCode = "";
//        sAcctCode = clsValidate.ValidateGridValue(dgvDetail, "AcctCode", row.Index, "default");

//        if (sAcctCode == sNewAcctCode)
//        {
//            isExisting = true;
//            break;
//        }
//    }
//    if (isExisting)
//    {
//        MessageBox.Show("Value is existing", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
//        ClearFieldsAccount();
//    }
//    return isExisting;
//} 
#endregion