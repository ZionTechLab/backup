using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zion.ERP.Reports.DataSets;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using ZION.ERP.Reports.DataSets;

namespace Digiteq
{
    public partial class frm_bpsDebitNote_New : SEACC_Form
    {
           
        public string glbOrderRefNo = "", glbInvoiceID = "";
        public bool gbl_bIsRefundableNote = false;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Sales glb_dtsSales = new dts_Sales();
        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_bpsDebitNote_New(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_bpsDebitNote_New_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();
        }
        #endregion

        #region Btn New
        private void frm_bpsDebitNote_New_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_bpsDebitNote_New_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebitNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_bpsDebitNote oDBN = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                            tbl_sasInvoice oINV = tbl_sasInvoice.Select(txtDebitNoteID.Text.Trim());
                            if (oDBN != null)
                            {
                                if (!oDBN.IsLocked)
                                {
                                    if (!oDBN.IsDeleted)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Debit Note : " + txtDebitNoteID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            if (oINV != null && oINV.Invoice_ID != "default")
                                            {
                                                clsHelpMethods_Local.RemoveSattlementsFrom_InvoiceID(oINV.Invoice_ID);
                                                oINV.IsDeleted = true;
                                                oINV.DateModified = clsSecurity.getServerDateTime();
                                                oINV.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                oINV.Update();
                                            }
                                            clsMethods_GL.GLPosting_Delete(oDBN.GlPosting_ID);
                                            oDBN.IsDeleted = true;
                                            oDBN.DateModified = clsSecurity.getServerDateTime();
                                            oDBN.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            oDBN.Update();

                                            email.createEmail_DebitNote(txtDebitNoteID.Text.Trim(), enum_Alerts.DebitNoteCancel);
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

        #region Btn Save
        private void frm_bpsDebitNote_New_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    string sRemarks = string.Empty;
                    string sSalesNoteType_ID = txtSalesNoteType.Tag.ToString().Trim();

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_bpsDebitNote oldRecord = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                        if (oldRecord != null && CheckValidity_Printing(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                            {
                                if (!oldRecord.IsChecked ||
                                    (oldRecord.IsChecked &&
                                     clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtDebitNoteID.Text))
                                    {
                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                        tbl_bpsDebitNote_SubTotal.DeleteAllByDebitNote_ID(txtDebitNoteID.Text);

                                        clsLog.Process_Modify(iFormID,
                                            clsAutocode.GetProcessNoteID(ProcessNote.bssDebitNote),
                                            oldRecord.DebitNote_ID, "Debit Note");

                                        #region Update DebitNote Header

                                        bool bIsLocked = oldRecord.IsLocked;

                                        tbl_bpsDebitNote detail = new tbl_bpsDebitNote(txtDebitNoteID.Text.Trim(),
                                            dtpDabitNoteDate.Value, txtRemark.Text.Trim(),
                                            txtSalesReturnNoteID.Tag.ToString(),
                                            txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), "default",
                                            glbOrderRefNo, "default", txtDebitNoteType.Tag.ToString(),
                                            "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                            uC_ExchangeRate1.CurrencyCode, sSalesNoteType_ID,
                                            uC_ExchangeRate1.ExchangeRate,
                                            uC_TotalCalc1.DiscountPresentage, uC_TotalCalc1.NbtPresentage,
                                            uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage,
                                            uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount,
                                            uC_TotalCalc1.NbtAmount, uC_TotalCalc1.VatAmount,
                                            uC_TotalCalc1.OtherTaxAmount,
                                            uC_TotalCalc1.GrandTotal, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                            glbApprovedDate, oldRecord.IsChecked, oldRecord.IsApproved,
                                            oldRecord.IsFinished,
                                            oldRecord.IsDeleted, oldRecord.IsLocked, false, oldRecord.SeattleAmount,
                                            oldRecord.IsSeattled, oldRecord.PrintCount, "default", "default",
                                            gbl_bIsRefundableNote, "default");
                                        detail.Update();

                                        #endregion

                                        #region Update Invoice Header

                                        bool bIsLocked1 = oldRecord.IsLocked;

                                        tbl_sasInvoice Invdetail = new tbl_sasInvoice(txtDebitNoteID.Text.Trim(),
                                            "default", dtpDabitNoteDate.Value, txtRemark.Text.Trim(),
                                            "", "default", txtCustomerID.Tag.ToString(), "default", "default",
                                            "default", "default", txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo,
                                            "default",
                                            uC_ExchangeRate1.CurrencyCode, "default",
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            txtDebitNoteType.Tag.ToString(), sSalesNoteType_ID,
                                            uC_ExchangeRate1.ExchangeRate, uC_TotalCalc1.DiscountPresentage, 0, 0, 0,
                                            uC_TotalCalc1.NbtPresentage, uC_TotalCalc1.VatPresentage,
                                            uC_TotalCalc1.OtherTaxPresentage,
                                            uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount, 0, 0, 0,
                                            uC_TotalCalc1.NbtAmount,
                                            uC_TotalCalc1.VatAmount, uC_TotalCalc1.OtherTaxAmount,
                                            uC_TotalCalc1.GrandTotal, uC_TotalCalc1.GrandTotal,
                                            uC_TotalCalc1.GrandTotal, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                            glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(),
                                            clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                            false, "", "", "", clsSecurity.getServerDateTime(), bIsLocked, 0, false,
                                            false, 0, true,
                                            false, false, false, false, false, false,
                                            uC_TotalCalc1.IsVatEnable, //clsHelpMethods.isTaxActiveNote(txtVat), 
                                            uC_TotalCalc1.IsSvatEnable, //clsHelpMethods.isTaxActiveNote(txtOtherTax), 
                                            "default", "", "default", false, clsSecurity.CompanyID,
                                            clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1);
                                        Invdetail.Update();

                                        #endregion

                                        #region Insert DBN Details

                                        int iRow;
                                        string sGLCode = "",
                                            sCategoryID = "",
                                            sRemark = "",
                                            sSubAcct1_ID = "",
                                            sSubAcct2_ID = "";
                                        bool bIsCredit = false;
                                        decimal dAmount;

                                        foreach (DataGridViewRow row in uC_DoubleEntry1.dgvDetail.Rows)
                                        {
                                            iRow = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Line_No",
                                                row.Index, int.Parse("0"));
                                            sGLCode = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                "accCode", row.Index, "");
                                            sCategoryID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                "TxnCategory_ID", row.Index, "");
                                            sRemark = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                "Remarks", row.Index, "");
                                            sSubAcct1_ID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                "SubAcct1_ID", row.Index, "default");
                                            sSubAcct2_ID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                "SubAcct2_ID", row.Index, "default");
                                            dAmount = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                "creditAmount", row.Index, decimal.Parse("0.00"));

                                            if (dAmount > 0)
                                                bIsCredit = true;
                                            else
                                            {
                                                bIsCredit = false;
                                                dAmount = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                    "debitAmount", row.Index, decimal.Parse("0.00"));
                                            }

                                            #region Insert tbl_bpsCreditNote_SubTotal

                                            tbl_bpsDebitNote_SubTotal Insdetail = new tbl_bpsDebitNote_SubTotal(iRow,
                                                txtDebitNoteID.Text.Trim(), sCategoryID,
                                                sGLCode, txtCustomerID.Tag.ToString(), "default", sSubAcct1_ID,
                                                sSubAcct2_ID, dAmount, bIsCredit, sRemark);
                                            Insdetail.Insert();

                                            #endregion
                                        }

                                        #endregion
                                        
                                        clsMethods_GL.PostTransaction_CustomerDBN(txtDebitNoteID.Text);
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
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        {
                            if (clsConfig.bBranchMaster_SerialNoActiveFor_DebitNote)
                                txtDebitNoteID.Text = clsAutocode.getAutoGeneratedCode_FromCompanyBranch_DebitNote(clsSecurity.BranchID);
                            else if (clsConfig.bDebitnoteType_SerialNoActiveFor_DebitNote)
                                txtDebitNoteID.Text = clsAutocode.getAutoGeneratedCode_FromDebitNoteType_DebitNote(txtDebitNoteType.Tag.ToString());
                            else if (clsConfig.bSalesNoteType_SerialNoActiveFor_DebitNote)
                                txtDebitNoteID.Text = clsAutocode.getAutoGeneratedCode_FromSalesNoteType_DebitNote(sSalesNoteType_ID);
                            else
                                txtDebitNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        }

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtDebitNoteID.Text)) //if (txtDebitNoteID.TextLength > 0)
                        {
                            bool bIsLocked = false;
                            #region DebitNote
                            tbl_bpsDebitNote detail = new tbl_bpsDebitNote(txtDebitNoteID.Text.Trim(), dtpDabitNoteDate.Value, txtRemark.Text.Trim(), txtSalesReturnNoteID.Tag.ToString(),
                                txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), "default", glbOrderRefNo, "default", txtDebitNoteType.Tag.ToString(),
                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID, uC_ExchangeRate1.CurrencyCode, sSalesNoteType_ID, uC_ExchangeRate1.ExchangeRate,
                                uC_TotalCalc1.DiscountPresentage, uC_TotalCalc1.NbtPresentage, uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage,
                                uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount, uC_TotalCalc1.NbtAmount, uC_TotalCalc1.VatAmount, uC_TotalCalc1.OtherTaxAmount,
                                uC_TotalCalc1.GrandTotal, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, false, 0, false, 0, "default", "default", gbl_bIsRefundableNote, "default");
                            detail.Insert();
                            #endregion

                            #region Invoice
                            tbl_sasInvoice INVdetail = new tbl_sasInvoice(txtDebitNoteID.Text.Trim(), "default", dtpDabitNoteDate.Value, txtRemark.Text.Trim(),
                                   "", "default", txtCustomerID.Tag.ToString(), "default", "default", "default", "default", txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default",
                                    uC_ExchangeRate1.CurrencyCode, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), txtDebitNoteType.Tag.ToString(), sSalesNoteType_ID,
                                    uC_ExchangeRate1.ExchangeRate, uC_TotalCalc1.DiscountPresentage, 0, 0, 0, uC_TotalCalc1.NbtPresentage, uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage,
                                    uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount, 0, 0, 0, uC_TotalCalc1.NbtAmount,
                                uC_TotalCalc1.VatAmount, uC_TotalCalc1.OtherTaxAmount, uC_TotalCalc1.GrandTotal, uC_TotalCalc1.GrandTotal, uC_TotalCalc1.GrandTotal, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                   "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                   false, "", "", "", clsSecurity.getServerDateTime(), bIsLocked, 0, false, false, 0, true,
                                   false, false, false, false, false, false,
                                   uC_TotalCalc1.IsVatEnable, //clsHelpMethods.isTaxActiveNote(txtVat), 
                                        uC_TotalCalc1.IsSvatEnable, /*clsHelpMethods.isTaxActiveNote(txtOtherTax), */
                                        "default", "", "default", false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1);
                            INVdetail.Insert();
                            #endregion

                            #region  Insert Detail - DBN Details
                            int iRow;
                            string sGLCode = "", sCategoryID = "", sRemark = "", sSubAcct1_ID = "", sSubAcct2_ID = "";
                            bool bIsCredit = false;
                            decimal dAmount;

                            foreach (DataGridViewRow row in uC_DoubleEntry1.dgvDetail.Rows)
                            {
                                iRow = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Line_No", row.Index, int.Parse("0"));
                                sGLCode = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "accCode", row.Index, "");
                                sCategoryID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "TxnCategory_ID", row.Index, "");
                                sRemark = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Remarks", row.Index, "");
                                sSubAcct1_ID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "SubAcct1_ID", row.Index, "default");
                                sSubAcct2_ID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "SubAcct2_ID", row.Index, "default");
                                dAmount = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));

                                if (dAmount > 0)
                                    bIsCredit = true;
                                else
                                {
                                    bIsCredit = false;
                                    dAmount = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                }

                                #region Insert tbl_bpsCreditNote_SubTotal
                                tbl_bpsDebitNote_SubTotal Insdetail = new tbl_bpsDebitNote_SubTotal(iRow, txtDebitNoteID.Text.Trim(), sCategoryID,
                                    sGLCode, txtCustomerID.Tag.ToString(), "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit, sRemark);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            Attachments.Insert(txtDebitNoteID.Text.ToString());
                        
                            clsMethods_GL.PostTransaction_CustomerDBN(txtDebitNoteID.Text);
                            email.createEmail_DebitNote(txtDebitNoteID.Text.Trim(), enum_Alerts.DebitNoteCreate);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Debit Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                    if (detail != null)
                    {
                        ClearFields();
                        FillDetails(detail.DebitNote_ID);
                    }
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_bpsDebitNote_New_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_bpsDebitNote_New_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);

            SetDisableControl(true);

            txtDebitNoteID.Tag = null;
            txtCustomerID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtDebitNoteType.Tag = null;
            txtSalesReturnNoteID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtSalesNoteType.Tag = null;

            txtRemark.Clear();
            txtCustomerID.Clear();
            txtSalesExecutiveID.Clear();
            txtOrderRefNo.Clear();
            txtDebitNoteType.Clear();
            txtSalesReturnNoteID.Clear();
            txtInvoiceID.Clear();
            txtSalesNoteType.Clear();

            dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

            bHasApproved = false;
            bHasChecked = false;
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            userDetailsColorChanges();

            uC_ExchangeRate1.ClearFields();
            uC_TotalCalc1.ClearFields();
            uC_DoubleEntry1.ClearFields();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDebitNoteID.Text = "<Auto Generate>";
            else
                txtDebitNoteID.Clear();
            if (txtDebitNoteID.Enabled)
            {
                txtDebitNoteID.SelectAll();
                txtDebitNoteID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);

                        SetDisableControl(false);

                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        txtDebitNoteType.Tag = detail.DebitNoteType_ID;
                        txtSalesReturnNoteID.Tag = detail.SalesReturnedNote_ID;
                        txtInvoiceID.Tag = detail.Invoice_ID;
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtDebitNoteID.Tag = detail.DebitNote_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;

                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtDebitNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_DebitNoteType(detail.DebitNoteType_ID));
                        txtSalesReturnNoteID.Text = clsCommon.GetForeignKeyValue(detail.SalesReturnedNote_ID);
                        txtInvoiceID.Text = clsCommon.GetForeignKeyValue(detail.Invoice_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        dtpDabitNoteDate.Value = detail.DebitNoteDate;
                        txtDebitNoteID.Text = detail.DebitNote_ID;
                        txtRemark.Text = detail.Remark;
                        txtRemark.Text = detail.Remark;
                        glbOrderRefNo = detail.OrderRefNo_ID;

                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.TotalAmount, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, "default", detail.Customer_ID, detail.CurrencyRate);

                        foreach (tbl_bpsDebitNote_SubTotal oCRNDetail in tbl_bpsDebitNote_SubTotal.SelectAllByDebitNote_ID(detail.DebitNote_ID))
                        {
                            uC_TotalCalc1.SetGL(oCRNDetail.Line_No, int.Parse(oCRNDetail.Tc_ID), oCRNDetail.Gl_ID, oCRNDetail.Amount, oCRNDetail.IsCredit, oCRNDetail.CostCenter1_ID, oCRNDetail.CostCenter2_ID, detail.Remark);
                        }

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

                        Attachments.FillAttachments(sID);
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

        #region Fill Tax Detail By Invoice_ID
        private void FillTaxDetailByInvoice_ID(string Invoice_ID)
        {
            try
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(Invoice_ID);
                if (detail != null)
                    txtRemark.Text = detail.Remark;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By SRN_ID
        private void FillTaxDetailBySRN_ID(string SRN_ID)
        {
            try
            {
                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(SRN_ID);
                if (detail != null)
                    txtRemark.Text = detail.Remark;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Customer View
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
            {
                frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                frm.glbCustomerID = txtCustomerID.Tag.ToString();
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
        }
        #endregion

        #region Btn Add SRN
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
                {
                    txtDebitNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.UnderInvoice);
                    txtDebitNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.UnderInvoice));

                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCustomer(detail.Customer_ID);
                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        FillTaxDetailByInvoice_ID(detail.Invoice_ID);

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        SetDisableControl(false);
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

        #region Btn Add SRN
        private void btnAddSRN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesReturnNoteID.Tag != null && txtSalesReturnNoteID.Tag.ToString().Length > 0)
                {
                    txtDebitNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.UnderInvoice);
                    txtDebitNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.UnderInvoice));

                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSalesReturnNoteID.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCustomer(detail.Customer_ID);
                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        FillTaxDetailBySRN_ID(detail.SalesReturnedNote_ID);

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        SetDisableControl(false);
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

        #region Fill Customer Detials
        private void FillDetailsCustomer(string sCustomerID)
        {
            try
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();

                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                if (oCustomer != null)
                {
                    txtCustomerID.Tag = oCustomer.Customer_ID;
                    txtCustomerID.Text = clsGenaralName.getName_Customer(oCustomer.Customer_ID);
                    txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                    string sSalesNotetype_ID = txtSalesNoteType.Tag != null ? txtSalesNoteType.Tag.ToString() : "default";
                    uC_TotalCalc1.SetEnableTax(oCustomer.IsNBTenable, oCustomer.IsVATenable, oCustomer.IsSVATenable, "default", oCustomer.Customer_ID, sSalesNotetype_ID, uC_ExchangeRate1.ExchangeRate);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Calculate Taxes and GrandTotal
        private void CalcualteSubTotal(decimal dAmount)
        {
            try
            {
                uC_TotalCalc1.SubTotal = dAmount;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Set Disable Control
        private void SetDisableControl(bool bEnable)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesReturnNoteID, bEnable);

            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesReturnNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesReturnNoteID, bEnable);
        }
        #endregion

        #region Events Double Click
        private void txtDebitNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_DebitNote();
        }

        private void txtSalesNoteType2_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_Invoice(sender);
        }

        private void txtSalesReturnNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesReturnNoteID(sender);
        }

        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }

        private void txtDebitNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_DebitNoteType();
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_SubTotal())
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            if (uC_DoubleEntry1.CheckValidity_DebitCredit())
                            {
                                /// if (CheckValidity_Posting())
                                bStatus = true;
                            }
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_SubTotal()
        {
            bool bStatus = true;
            if (uC_TotalCalc1.SubTotal <= 0)
            {
                bStatus = false;
                MessageBox.Show("Sub Total should be greater than 0...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtDebitNoteType, "Debit Note Type"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Sales Note Type"))
                        bStatus = true;
                }
            }
            if (txtSalesExecutiveID.Tag == null)
                txtSalesExecutiveID.Tag = "default";

            return bStatus;
        }
        private bool CheckValidity_Allocation()
        {
            bool isSettled = true;
            try
            {
                foreach (tbl_sasInvoice_Sattled pInv in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(txtDebitNoteID.Text.Trim()))
                {
                    isSettled = false;
                    MessageBox.Show("Cannot delete. This document is settled !");
                    break;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return isSettled;
        }
        private bool CheckValidity_Printing(int iPrintCount)
        {
            bool bOk = true;
            try
            {
                if (iPrintCount > 0)
                {
                    bOk = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bOk;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtSalesReturnNoteID);
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtInvoiceID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Methods
        private void Search_DebitNote()
        {
            try
            {
                clsSearch.Search_TransactionDebitNote_Direct(ref txtDebitNoteID, chkShowSettle.Checked, false, gbl_bIsRefundableNote);
                if (txtDebitNoteID.Tag != null && txtDebitNoteID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtDebitNoteID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCustomerID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                        FillDetailsCustomer(frmSearchMaster.s_SearchID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Invoice(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), false, "", true, true, false, false, true, "");
                else
                    clsSearch.Search_TransactionInvoice_Use(ref txtInvoiceID, false, "", true, true, false, true);

                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
                    btnAddInvoice_Click(sender, new EventArgs());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesReturnNoteID(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionSalesReturnNote(ref txtSalesReturnNoteID, txtCustomerID.Tag.ToString(), true, false, false);
                else
                    clsSearch.Search_TransactionSalesReturnNote(ref txtSalesReturnNoteID, "", true, false, false);

                if (txtSalesReturnNoteID.Tag != null && txtSalesReturnNoteID.Tag.ToString().Length > 0)
                    btnAddSRN_Click(sender, new EventArgs());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_DebitNoteType()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_DebitNoteTypeID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtDebitNoteType.Text = frmSearchMaster.s_SearchText;
                    txtDebitNoteType.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtDebitNoteID.Text.Trim().Length > 0 && txtDebitNoteID.Text.Trim() != "<Auto Generate>")
                {
                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true;
                    bool bPermissinOkToPrint = true;

                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_DebitNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_bpsDebitNote DeditNote = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                        if (DeditNote != null)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintDebitNote)
                                {
                                    if (!DeditNote.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the DebitNote Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion

                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintDebitNote)
                                {
                                    if (!DeditNote.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the DebitNote Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            if (bApprovalDone && bCheckingDone)
                            {
                                bOkToPrint = true;

                                sCreateUser = "[ " + clsGenaralName.getName_User(DeditNote.CreateUser_ID) + " ] [ " + DeditNote.DateCreate.ToShortDateString() + " ]";
                                if (DeditNote.IsChecked && DeditNote.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(DeditNote.CheckedUser_ID) + " ] [ " + DeditNote.DateChecked.ToShortDateString() + " ]";
                                if (DeditNote.IsApproved && DeditNote.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(DeditNote.ApprovedUser_ID) + " ] [ " + DeditNote.DateApproved.ToShortDateString() + " ]";

                                string sDbPath = "";
                                sDbPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DebitNote));

                                #region Print The Doc
                                if (bOkToPrint && bApprovalDone)
                                {
                                    #region Check Duplicate copy
                                    if (!bIsDraft)
                                    {
                                        //if (DeditNote.PrintCount > 0)
                                        //    sDuplicateCopy = "Duplicate Copy " + DeditNote.PrintCount;

                                        if (!chkPrintOriginal.Checked)
                                            sDuplicateCopy = (DeditNote.PrintCount > 0) ? "Duplicate Copy " + DeditNote.PrintCount : "";

                                        DeditNote.PrintCount++;
                                        DeditNote.Update();
                                    }
                                    #endregion

                                    if (clsConfig.bisDatasetActive_DebitNotePrinting)
                                    {
                                        #region Datasets
                                        tbl_bpsDebitNote oDebiNote = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        glb_dtsSales.dt_sasTaxDetails_DebitNote.Adddt_sasTaxDetails_DebitNoteRow(oDebiNote.DebitNote_ID, oDebiNote.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebiNote.DebitNoteType_ID), oDebiNote.SalesReturnedNote_ID, oDebiNote.Invoice_ID, oDebiNote.Currency_ID, clsGenaralName.getName_Customer(oDebiNote.Customer_ID), clsGenaralName.getName_CustomerRegisterAddress(oDebiNote.Customer_ID), oDebiNote.DeliveryOrder_ID, oDebiNote.OrderRefNo_ID, oDebiNote.Remark, oDebiNote.SubTotal, oDebiNote.DiscountTotal, oDebiNote.NbtTotal, oDebiNote.VatTotal, oDebiNote.OtherTaxTotal, oDebiNote.TotalAmount, oDebiNote.ChequeRegister_ID);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.getCompanyVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicateCopy, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsCanceled", DeditNote.IsDeleted ? "CANCELLED" : "", true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

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

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", "", true);
                                            }
                                        }
                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "DEBIT NOTE", "", "", clsSecurity.UserNameLoged, "");
                                        #endregion

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sDbPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_DebitNote));
                                        #endregion
                                    }
                                    else
                                    {
            

                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Please Select the DebitNote To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glb_dtsSales.Clear();
            }
        }
        #endregion

        #region Btn Payment Voucher
        private void btnPV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebitNoteID.Tag != null && txtDebitNoteID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(txtDebitNoteID.Tag.ToString());
                    if (detail != null && detail.DebitNote_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";

                        if (detail.IsSeattled)
                        {
                            bAllowDetail = false;
                            message = "Already Settled";
                        }

                        if (bAllowDetail)
                        {
                            int iFormID_pv = 410;

                            frm_accPaymentVoucher frm = new frm_accPaymentVoucher((FormName)iFormID_pv);
                            frm.glbRefundableID = detail.DebitNote_ID;
                            frm.glbOrderRefNo = detail.OrderRefNo_ID;
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                        }
                        else
                            MessageBox.Show(message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Temp
        private void frm_bpsDebitNote_New_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
            {
                IsUpdate = false;
                lblCancelled.Visible = false;
                btnSave.Enabled = true;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                SetDisableControl(true);

                txtDebitNoteID.Tag = null;
                dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtDebitNoteID.Text = "<Auto Generate>";
                else
                    txtDebitNoteID.Clear();
                if (txtDebitNoteID.Enabled)
                {
                    txtDebitNoteID.SelectAll();
                    txtDebitNoteID.Focus();
                }
                Attachments.Clear();
            }
        }
        #endregion

        #region User Checked Approve Details
        private void frm_bpsDebitNote_New_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_bpsDebitNote_New_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDebitNoteID.Text != null && txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
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

                                        tbl_bpsDebitNote objDN = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        if (objDN != null)
                                        {
                                            objDN.IsApproved = true;
                                            objDN.DateApproved = clsSecurity.getServerDateTime();
                                            objDN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDN.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDebitNoteID.Text != null && txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
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

                                        tbl_bpsDebitNote objDN = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        if (objDN != null)
                                        {
                                            objDN.IsChecked = true;
                                            objDN.DateChecked = clsSecurity.getServerDateTime();
                                            objDN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDN.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion

        private void frm_bpsDebitNote_New_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebitNoteID.Text != "" || txtDebitNoteID.Text != "<Auto Generate>")
                {
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(txtDebitNoteID.Text.Trim());
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

        private void uC_ExchangeRate1_ExRateChanged()
        {
            if (txtCustomerID.Tag != null)
            {
                string sSalesNotetype_ID = txtSalesNoteType.Tag != null ? txtSalesNoteType.Tag.ToString() : "default";
                uC_TotalCalc1.SetEnableTax(uC_TotalCalc1.IsNBTenable, uC_TotalCalc1.IsVatEnable, uC_TotalCalc1.IsSvatEnable, "default", txtCustomerID.Tag.ToString(), sSalesNotetype_ID, uC_ExchangeRate1.ExchangeRate);
            }
        }

        private void uC_DoubleEntry1_Clicked(TransactionCategory TxnCat)
        {
            uC_TotalCalc1.UpdateAccCode(TxnCat);
        }
        
        private void uC_TotalCalc1_DoubleEntryUpdataed(DataTable dt)
        {
            uC_DoubleEntry1.Refresh(dt);
        }

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
            else
            {
                panel1.Visible = true;
                panel1.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void panel1_Leave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        #endregion
    }
}

//private bool CheckValidity_Posting()
//{
//    bool bStatus = false;
//    if (clsConfig.bAutoPostingEnable)
//    {
//        bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
//        bool bSlotStatus_Credit = clsMethods_GL.CheckAccountLink(AccSlot.Customer_DebitNote, true);

//        if (bSlotStatus_Customer && bSlotStatus_Credit)
//            bStatus = true;
//    }
//    else
//        bStatus = true;

//    return bStatus;
//}