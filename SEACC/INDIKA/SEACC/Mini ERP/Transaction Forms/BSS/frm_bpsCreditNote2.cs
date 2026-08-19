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
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets.BSS;
using Zion.ERP.Reports.DataSets;
using SEACC.WinFormControls.Forms;
using ZION.ERP.Reports.DataSets;

namespace Digiteq
{
    public partial class frm_bpsCreditNote2 : SEACC_Form
    {
           
        public string glbOrderRefNo = "", glbCreditNoteID = "";

        dts_Sales glb_dtsSales = new dts_Sales();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_CreditNote glb_dtsBills = new dts_CreditNote();
        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_bpsCreditNote2(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            if(clsSecurity.UserIDLoged.Trim().ToUpper() != "DIGITEQ")
                button2.Visible = false;
        }

        private void frm_bpsCreditNote2_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();

            if (glbCreditNoteID != null && glbCreditNoteID.Length > 0)
                FillDetails(glbCreditNoteID);
        }
        #endregion

        #region Btn New
        private void frm_bpsCreditNote2_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_bpsCreditNote2_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpCreditNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Credit Note : " + txtCreditNoteID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            if (clsHelpMethods_Local.RemoveSattlementsFrom_CreditNoteID(detail.CreditNote_ID))
                                            {
                                                if (clsSecurity.Permission_Route(clsSecurity.UserIDLoged, txtCustomerID.Tag.ToString()))
                                                {
                                                    detail.IsDeleted = true;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();

                                                    #region Remove SRN Approval
                                                    if (detail.SalesReturnedNote_ID != "default")
                                                    {
                                                        tbl_sasSalesReturnedNote oSRN = tbl_sasSalesReturnedNote.Select(detail.SalesReturnedNote_ID);
                                                        if (oSRN != null)
                                                        {
                                                            oSRN.CreditNote_ID = "default";
                                                            oSRN.IsApproved = false;
                                                            oSRN.ApprovedUser_ID = "default";
                                                            oSRN.Update();
                                                        }
                                                    }
                                                    #endregion

                                                    clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);
                                                    email.createEmail_CreditNote(txtCreditNoteID.Text.Trim(), enum_Alerts.CreditNoteCancel);
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                            }
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
        private void frm_bpsCreditNote2_SF_saveButton_Click(object sender, EventArgs e)
        {
            bool bisCheckin = false;
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    string sInvoiceId = "default", sSRNID = "default", sDoID = "default", sOrderRefNo = "default", sChequeRegisterId = "default";
                    decimal dAllocatedAmount = 0;

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_bpsCreditNote oldRecord = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                        if (oldRecord != null && CheckPrintingValidity(oldRecord.PrintCount) && ValidateSettlement_CreditNote(oldRecord.CreditNote_ID))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtCreditNoteID.Text))
                                    {
                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                        tbl_bpsCreditNote_SubTotal.DeleteAllByCreditNote_ID(txtCreditNoteID.Text);

                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CreditNote), oldRecord.CreditNote_ID, "Credit Note");

                                        #region Update Invoice Header
                                        if (dgvInvoice.Rows.Count == 1)
                                        {
                                            sInvoiceId = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", 0,
                                                "default");
                                            sOrderRefNo = glbOrderRefNo;
                                        }

                                        bool bWriteOff = false;
                                        if (rdoWriteOff.Checked)
                                            bWriteOff = true;
                                        else
                                            bWriteOff = false;

                                        tbl_bpsCreditNote detail = new tbl_bpsCreditNote(txtCreditNoteID.Text.Trim(),
                                            dtpCreditNoteDate.Value, txtRemark.Text.Trim(), sSRNID, sInvoiceId,
                                            txtCustomerID.Tag.ToString(), sDoID, sOrderRefNo, sChequeRegisterId,
                                            txtCreditNoteType.Tag.ToString(), oldRecord.GlPosting_ID,
                                            oldRecord.PostingStatus_ID,
                                            oldRecord.FinancialYear_ID, uC_ExchangeRate1.CurrencyCode,
                                            txtSalesNoteType.Tag.ToString(), uC_ExchangeRate1.ExchangeRate,
                                            uC_TotalCalc1.DiscountPresentage, uC_TotalCalc1.NbtPresentage,
                                            uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage,
                                            uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount,
                                            uC_TotalCalc1.NbtAmount, uC_TotalCalc1.VatAmount,
                                            uC_TotalCalc1.OtherTaxAmount,
                                            uC_TotalCalc1.GrandTotal, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                            oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                            glbApprovedDate, oldRecord.IsChecked, oldRecord.IsApproved,
                                            oldRecord.IsFinished,
                                            oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsWeightCalculation,
                                            oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.PrintCount,
                                            oldRecord.CompanyID, oldRecord.CompanyBranch_ID, bWriteOff,
                                            oldRecord.PosReturnTransaction_Index, oldRecord.AdvanceReceived_Index);
                                        detail.Update();

                                        #endregion

                                        #region  Insert Detail - CRN Details
                                        foreach (tbl_bpsCreditNote_Invoice oInvDetail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(txtCreditNoteID.Text.Trim()))
                                        {
                                            oInvDetail.Delete();
                                        }

                                        int i = 0;
                                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                                        {
                                            string sInvoice = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
                                            if (sInvoice.Length > 1 && sInvoice != "default")
                                            {
                                                tbl_bpsCreditNote_Invoice oCndetail = new tbl_bpsCreditNote_Invoice(txtCreditNoteID.Text.Trim(), i, sInvoice, clsValidate.ValidateGridValue(dgvInvoice, "OrderRefNo", row.Index, "default"), 0);
                                                oCndetail.Insert();
                                                i += 1;
                                            }
                                        }

                                        int iRow;
                                        string sGLCode = "", sCategoryID = "", sRemarks = "", sSubAcct1_ID = "", sSubAcct2_ID = "";
                                        bool bIsCredit = false;
                                        decimal dAmount;

                                        foreach (DataGridViewRow row in uC_DoubleEntry1.dgvDetail.Rows)
                                        {
                                            iRow = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Line_No", row.Index, int.Parse("0"));
                                            sGLCode = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "accCode", row.Index, "");
                                            sCategoryID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "TxnCategory_ID", row.Index, "");
                                            sRemarks = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Remarks", row.Index, "");
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

                                            tbl_bpsCreditNote_SubTotal Insdetail = new tbl_bpsCreditNote_SubTotal(iRow, txtCreditNoteID.Text.Trim(), sCategoryID, sGLCode, txtCustomerID.Tag.ToString(), "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit, sRemarks);
                                            Insdetail.Insert();
                                            #endregion
                                        }
                                        #endregion

                                        clsMethods_GL.PostTransaction_CRN(txtCreditNoteID.Text, AccSlot.Customer_CreditNote);

                                        if (!bisCheckin)
                                        {
                                            dgvInvoice.Rows.Clear();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (!bisCheckin)
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        #region genarate Serial
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        {
                            if (clsConfig.bBranchMaster_SerialNoActiveFor_CreditNote)
                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode_FromCompanyBranch_CreditNote(clsSecurity.BranchID);
                            else if (clsConfig.bSalesNoteType_SerialNoActiveFor_CreditNote)
                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode_FromSalesNoteType_CreditNote(txtSalesNoteType.Tag.ToString());
                            else
                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        }
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtCreditNoteID.Text))
                        {
                            if (dgvInvoice.Rows.Count == 1)
                            {
                                sInvoiceId = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", 0, "default");
                                sOrderRefNo = glbOrderRefNo;
                            }

                            bool bWriteOff = false;
                            if (rdoWriteOff.Checked)
                                bWriteOff = true;
                            else
                                bWriteOff = false;

                            #region CreditNote Header
                            tbl_bpsCreditNote detail = new tbl_bpsCreditNote(txtCreditNoteID.Text.Trim(), dtpCreditNoteDate.Value, txtRemark.Text.Trim(), sSRNID, sInvoiceId, txtCustomerID.Tag.ToString(), sDoID, sOrderRefNo, sChequeRegisterId, txtCreditNoteType.Tag.ToString(), "default",
                                                    clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, uC_ExchangeRate1.CurrencyCode, txtSalesNoteType.Tag.ToString(), uC_ExchangeRate1.ExchangeRate,
                                                    uC_TotalCalc1.DiscountPresentage, uC_TotalCalc1.NbtPresentage, uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage, uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount,
                                                    uC_TotalCalc1.NbtAmount, uC_TotalCalc1.VatAmount, uC_TotalCalc1.OtherTaxAmount, uC_TotalCalc1.GrandTotal, clsSecurity.UserIDLoged, "default", "default", "default",
                                                     clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(),
                                                    clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, false, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, bWriteOff, (-1), (-1));
                            detail.Insert();
                            #endregion

                            #region Creditnote Settlements
                            int i = 0;
                            foreach (DataGridViewRow row in dgvInvoice.Rows)
                            {
                                tbl_bpsCreditNote_Invoice oCndetail = new tbl_bpsCreditNote_Invoice(txtCreditNoteID.Text.Trim(), i++, clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default"), clsValidate.ValidateGridValue(dgvInvoice, "OrderRefNo", row.Index, "default"), 0);
                                oCndetail.Insert();
                            }
                            #endregion

                            #region  Insert Detail - CRN Details
                            int iRow;
                            string sGLCode = "", sCategoryID = "", sRemarks = "", sSubAcct1_ID = "", sSubAcct2_ID = "";
                            bool bIsCredit = false;
                            decimal dAmount;

                            foreach (DataGridViewRow row in uC_DoubleEntry1.dgvDetail.Rows)
                            {
                                iRow = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Line_No", row.Index, int.Parse("0"));
                                sGLCode = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "accCode", row.Index, "");
                                sCategoryID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "TxnCategory_ID", row.Index, "");
                                sRemarks = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Remarks", row.Index, "");
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
                                tbl_bpsCreditNote_SubTotal Insdetail = new tbl_bpsCreditNote_SubTotal(iRow, txtCreditNoteID.Text.Trim(), sCategoryID,
                                    sGLCode, txtCustomerID.Tag.ToString(), "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit, sRemarks);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            Attachments.Insert(txtCreditNoteID.Text.ToString());
                      
                            clsMethods_GL.PostTransaction_CRN(txtCreditNoteID.Text, AccSlot.Customer_CreditNote);
                            email.createEmail_CreditNote(txtCreditNoteID.Text.Trim(), enum_Alerts.CreditNoteCreated);

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvInvoice.Rows.Clear();
                        }
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
                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                    if (detail != null)
                    {
                        if (!bisCheckin)
                        {
                            ClearFields();
                            FillDetails(detail.CreditNote_ID);
                        }
                    }
                }
            }
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
                    if (CheckValidity_Curency())
                    {
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpCreditNoteDate.Value.Date))
                        {
                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                            {
                                if (clsSecurity.Permission_Route(clsSecurity.UserIDLoged, txtCustomerID.Tag.ToString()))
                                {
                                    if (uC_DoubleEntry1.CheckValidity_DebitCredit())
                                    {
                                        if (CheckValidity_Posting())
                                            bStatus = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Note Type"))
                    bStatus = true;
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

        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
                bool bSlotStatus_debit = clsMethods_GL.CheckAccountLink(AccSlot.Customer_CreditNote, false);
                bool bSlotStatus_NBT = clsMethods_GL.CheckAccountLink_NBTReceivable();
                bool bSlotStatus_VAT = clsMethods_GL.CheckAccountLink_VATReceivable();

                if (bSlotStatus_Customer && bSlotStatus_debit && bSlotStatus_NBT && bSlotStatus_VAT)
                    bStatus = true;
            }
            else
                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_Outstanding()
        {
            bool bOk = true;
            decimal dCreditBalance = 0, dAmountDue = 0;
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                    if (customer != null && customer.Customer_ID != "default")
                    {
                        if (customer.IsBlacklisted)
                        {
                            bOk = false;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (clsConfig.bCreditBalanceInvoice_Message)
                            {
                                dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                                if (dCreditBalance < uC_TotalCalc1.GrandTotal) //Condition
                                {
                                    bOk = false;
                                    if (clsConfig.bCreditBalanceInvoice_Lock) //security 2 - Lock
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    else
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                            bOk = true;
                                    }
                                }
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

            return bOk;
        }

        private bool CheckValidity_Curency()
        {
            bool isValid = false;
            try
            {
                int iRowCount = 0;

                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    iRowCount++;
                    string sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "");
                    if (sInvoiceID.Length > 0)
                    {
                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                        if (oInvoice != null && oInvoice.Invoice_ID != "default")
                        {
                            if (oInvoice.Currency_ID != uC_ExchangeRate1.CurrencyCode || oInvoice.CurrencyRate != uC_ExchangeRate1.ExchangeRate)
                            {
                                isValid = false;
                                break;
                            }
                            else
                                isValid = true;
                        }
                    }
                }

                if (!isValid && iRowCount != 0)
                    MessageBox.Show("Currancy Rate(s) are not match with Invoice(s) ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (iRowCount == 0)
                    isValid = true;//For Sarandib Request (Create CRN without Select Invoice)
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return isValid;

        }

        private bool CheckPrintingValidity(int iPrintCount)
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

        private bool ValidateSettlement_CreditNote(String CreditNote_ID)
        {
            bool bIsSettlementOk = true;
            try
            {
                foreach (tbl_bpsCreditNote_Invoice oInvDetail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(CreditNote_ID))
                {
                    if (oInvDetail.AlocatedAmount != 0)
                    {
                        bIsSettlementOk = false;
                        MessageBox.Show("One or more invoices already allocated to this Credit note...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            return bIsSettlementOk;
        }

        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtCreditNoteType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Btn Print
        private void frm_bpsCreditNote2_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_bpsCreditNote2_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCreditNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            uC_ExchangeRate1.Enabled = true;
            clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);

            btnSave.Enabled = true;

            txtCreditNoteID.Tag = null;
            txtCustomerID.Tag = null;
            txtCreditNoteType.Tag = null;
            txtOrderRefNo.Tag = null;
            txtSalesNoteType.Tag = null;

            txtRemark.Clear();
            txtCustomerID.Clear();
            txtOrderRefNo.Clear();
            txtCreditNoteType.Clear();
            dtpCreditNoteDate.Value = clsSecurity.getServerDateTime();
            txtSalesNoteType.Clear();
            txtBalanceAmount.Text = "0.00";
            txtTotalAllocated.Text = "0.00";

            rdoNormalSales.Checked = true;
            rdoWriteOff.Checked = false;
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            dgvInvoice.Rows.Clear();

            uC_ExchangeRate1.ClearFields();
            uC_TotalCalc1.ClearFields();
            uC_DoubleEntry1.ClearFields();
            dtpCreditNoteDate.Enabled = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 1350);
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtCreditNoteID.Text = "<Auto Generate>";
            else
                txtCreditNoteID.Clear();
            if (txtCreditNoteID.Enabled)
            {
                txtCreditNoteID.SelectAll();
                txtCreditNoteID.Focus();
            }
        }
        #endregion

        private void frm_bpsCreditNote2_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_bpsCreditNote2_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtCreditNoteID.Text != null && txtCreditNoteID.TextLength > 0 && txtCreditNoteID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpCreditNoteDate.Value.Date))
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
                                        settleInvoicesWithCreditNote(txtCreditNoteID.Text.Trim(), clsSecurity.UserIDLoged);

                                        tbl_bpsCreditNote objCN = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                                        if (objCN != null)
                                        {
                                            objCN.IsApproved = true;
                                            objCN.DateApproved = clsSecurity.getServerDateTime();
                                            objCN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objCN.Update();

                                            MessageBox.Show(" Invoices allocated successfully...!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                            FillDetails(objCN.CreditNote_ID);
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
                if (txtCreditNoteID.Text != null && txtCreditNoteID.TextLength > 0 && txtCreditNoteID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpCreditNoteDate.Value.Date))
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

                                        tbl_bpsCreditNote objCN = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                                        if (objCN != null)
                                        {
                                            objCN.IsChecked = true;
                                            objCN.DateChecked = clsSecurity.getServerDateTime();
                                            objCN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objCN.Update();
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

        private void frm_bpsCreditNote2_SF_History_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditNoteID.Text != "" || txtCreditNoteID.Text != "<Auto Generate>")
                {
                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        #region Invoice Settlement
        private void settleInvoicesWithCreditNote(string sCNID, string sUserID)
        {
            try
            {
                tbl_bpsCreditNote oCreditNoteOld = tbl_bpsCreditNote.Select(sCNID);
                if (oCreditNoteOld != null && oCreditNoteOld.CreditNote_ID != "default")
                {
                    if (ValidateSettlement_CreditNote(oCreditNoteOld.CreditNote_ID) && !oCreditNoteOld.IsSeattled && oCreditNoteOld.CreditNoteType_ID != "default")
                    {
                        if (!oCreditNoteOld.IsApproved && oCreditNoteOld.CurrencyRate > 0)
                        {
                            if (oCreditNoteOld.TotalAmount > 0)
                            {
                                #region Settle Invoices
                                string sFormConfigCode1 = clsAutocode.getFormConfigCode(FormName.CreditNoteAllocation);
                                string sAllocationID = clsAutocode.getAutoGeneratedCode(sFormConfigCode1);

                                foreach (DataGridViewRow row in dgvInvoice.Rows)
                                {
                                    string sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
                                    decimal dAllocatedAmmount = clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", row.Index, decimal.Parse("0.0"));

                                    #region Invoice Settlement - With Credit Note
                                    dAllocatedAmmount = dAllocatedAmmount * oCreditNoteOld.CurrencyRate;
                                    dAllocatedAmmount = clsHelpMethods_Local.AutoSettledInvoiceWithCreditNote(sInvoiceID, oCreditNoteOld.CreditNote_ID, dAllocatedAmmount, sAllocationID, false, false);
                                    #endregion

                                    tbl_bpsCreditNote_Invoice oCrnInv = tbl_bpsCreditNote_Invoice.Select(sCNID, row.Index);
                                    if (oCrnInv != null)
                                    {
                                        oCrnInv.AlocatedAmount = dAllocatedAmmount;
                                        oCrnInv.Update();
                                    }
                                }
                                #endregion
                            }
                            else
                                MessageBox.Show("Credit note amount should be greater than Zero...!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                            MessageBox.Show("This Credit note has been locked", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        private void frm_bpsCreditNote2_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtCreditNoteID.TextLength > 0 && txtCreditNoteID.Text != "<Auto Generate>")
            {
                IsUpdate = false;
                lblCancelled.Visible = false;
                btnSave.Enabled = true;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCreditNoteType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
                SetDisableControl(true);

                txtCreditNoteID.Tag = null;
                dtpCreditNoteDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtCreditNoteID.Text = "<Auto Generate>";
                else
                    txtCreditNoteID.Clear();
                if (txtCreditNoteID.Enabled)
                {
                    txtCreditNoteID.SelectAll();
                    txtCreditNoteID.Focus();
                }

                Attachments.Clear();
            }
        }

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;
                        uC_TotalCalc1.ClearFields();
                        uC_DoubleEntry1.ClearFields();

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCreditNoteType, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        uC_ExchangeRate1.Enabled = false;
                        clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCreditNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);

                        //asign values
                        txtCreditNoteID.Tag = detail.CreditNote_ID;
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        txtCreditNoteType.Tag = detail.CreditNoteType_ID;
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;

                        txtCreditNoteID.Text = detail.CreditNote_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtCreditNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CreditNoteType(detail.CreditNoteType_ID));
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        if (detail.Is_WriteOff == true)
                            rdoWriteOff.Checked = true;
                        else
                            rdoNormalSales.Checked = true;

                        int iLineno = 0;
                        foreach (tbl_bpsCreditNote_Invoice oInvDetail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(sID))
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oInvDetail.Invoice_ID);
                            if (oInvoice != null)
                            {
                                decimal dBalanceAmount = detail.CurrencyRate != 0 && (oInvoice.GrandTotal - oInvoice.SeattleAmount) > 0 ? (oInvoice.GrandTotal - oInvoice.SeattleAmount) / oInvoice.CurrencyRate : 0;
                                dgvInvoice.Rows.Add();
                                dgvInvoice["InvoiceID", iLineno].Value = oInvDetail.Invoice_ID;
                                dgvInvoice["OrderRefNo", iLineno].Value = oInvDetail.OrderRef_ID;
                                dgvInvoice["InvoiceAmount", iLineno].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalanceAmount);
                                dgvInvoice["AllocatedAmount", iLineno].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(oInvDetail.AlocatedAmount, oInvoice.CurrencyRate));

                                iLineno += 1;
                            }
                        }
                        CalculateInvoiceTotal();

                        dtpCreditNoteDate.Value = detail.CreditNoteDate;
                        txtRemark.Text = detail.Remark;
                        txtRemark.Text = detail.Remark;
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        
                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.TotalAmount, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, "default", detail.Customer_ID, detail.CurrencyRate);

                        foreach (tbl_bpsCreditNote_SubTotal oCRNDetail in tbl_bpsCreditNote_SubTotal.SelectAllByCreditNote_ID(detail.CreditNote_ID))
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

                        if (detail.SalesReturnedNote_ID != "default")
                            btnSave.Enabled = false;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sCustomerID = "";
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    sCustomerID = txtCustomerID.Tag.ToString();

                string sInvoice_ID = clsSearch.Search_TransactionInvoiceByCustomerID_Use(sCustomerID, false, "", false, true, true, true, true, "");

                if (sInvoice_ID != null && sInvoice_ID.Length > 0)
                    AddNewInvoice(sInvoice_ID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.SelectedCells.Count != 0)
                {
                    if (dgvInvoice.Rows.Count > 0)
                    {
                        dgvInvoice.Rows.RemoveAt(dgvInvoice.SelectedCells[0].RowIndex);
                        CalculateInvoiceTotal();
                    }
                }
            }
            catch (Exception) { }
        }

        #region Btn Invoice Add
        private void AddNewInvoice(string sInvoice_ID)
        {
            try
            {
                bool bStatus = true;
                #region Validate Invoive Duplication
                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    if (clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "").ToString() == sInvoice_ID)
                    {
                        MessageBox.Show("\n" + "You have already entered this invoice  " + sInvoice_ID, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bStatus = false;
                        break;
                    }
                }
                #endregion

                if (bStatus)
                {
                    txtCreditNoteType.Enabled = true;

                    if (txtCreditNoteType.Tag != null && txtCreditNoteType.Tag.ToString().Length > 0)
                        txtCreditNoteType.Enabled = false;
                    else
                    {
                        txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment);
                        txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment));
                    }

                    tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoice_ID);
                    if (detail != null && detail.Invoice_ID != "default")
                    {
                        #region Validate Currency
                        bool bCurrencyTypeOk = true;

                        if (dgvInvoice.RowCount == 0)
                            uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        else
                        {
                            if (uC_ExchangeRate1.CurrencyCode != detail.Currency_ID || uC_ExchangeRate1.ExchangeRate != detail.CurrencyRate)
                            {
                                bCurrencyTypeOk = false;
                                MessageBox.Show("Cannot add Invoice currency.type or rate not matching", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        #endregion

                        if (bCurrencyTypeOk)
                        {
                            int iRow = 0;
                            dgvInvoice.Rows.Add();
                            iRow = dgvInvoice.Rows.Count - 1;

                            decimal dAllocatedAmount = 0;
                            decimal dBalanceAmount = detail.CurrencyRate > 0 && (detail.GrandTotal - detail.SeattleAmount) > 0 ? (detail.GrandTotal - detail.SeattleAmount) / detail.CurrencyRate : 0;

                            dgvInvoice["InvoiceID", iRow].Value = detail.Invoice_ID;
                            dgvInvoice["OrderRefNo", iRow].Value = detail.OrderRefNo_ID;
                            dgvInvoice["InvoiceAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalanceAmount);
                            dgvInvoice["AllocatedAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);

                            txtCustomerID.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                            txtCustomerID.Tag = detail.Customer_ID;
                            AfterCustomerChanged();
                            txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                            txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                            CalculateInvoiceTotal();

                            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                            if (order != null)
                            {
                                glbOrderRefNo = detail.OrderRefNo_ID;
                                txtOrderRefNo.Tag = detail.OrderRefNo_ID;

                                txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            }

                            if (dgvInvoice.Rows.Count > 4)
                            {
                                dgvInvoice.Columns["InvoiceAmount"].Width = 92;
                                dgvInvoice.Columns["AllocatedAmount"].Width = 92;
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
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            bool bTaxTypeSelection_OK = false;
            frm_TaxSelecion oTax = new frm_TaxSelecion(false);

            if (clsConfig.bEnable_CreditNoteWithSalesReturnItem)
            {
                #region Tax Type Selection
                if (uC_TotalCalc1.IsSvatEnable)
                {
                    bTaxTypeSelection_OK = true;
                    oTax.bSVatSelected = true;
                    oTax.bNbtSelected = true;
                }
                else
                {
                    oTax.ShowDialog();
                    if (oTax.DialogResult == DialogResult.OK)
                        bTaxTypeSelection_OK = true;
                }
                #endregion
            }
            else
                bTaxTypeSelection_OK = true;

            if (bTaxTypeSelection_OK)
            {
                try
                {
                    if (txtCreditNoteID.Text.Trim().Length > 0 && txtCreditNoteID.Text.Trim() != "<Auto Generate>")
                    {
                        Cursor = Cursors.WaitCursor;

                        glb_dtsSales.Clear();
                        glb_dtsBills.Clear();
                        glb_dtsReportExport.Clear();

                        string sCreateUser = "", sCheckedUser = "", sCreateUserName = "[ None ]", sCheckedUserName = "[ None ]", sApprovedUser = "", sReportPath = "", sTaxType = "", sDuplicate = "", sCreateDate = "", sCheckedDate = "";
                        bool bApprovalDone = true, bRptSVat = false;

                        bool bPermissinOkToPrint = true;
                        if (chkPrintOriginal.Checked)
                            bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_CreditNote));
                        if (bPermissinOkToPrint)
                        {
                            tbl_bpsCreditNote CreditNote = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                        if (CreditNote != null)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintCreditNote)
                                {
                                    if (!CreditNote.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion

                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintCreditNote)
                                {
                                    if (!CreditNote.IsChecked)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Check the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            if (bApprovalDone)
                            {
                                string sInvoiceID = "", sCrInvoice = "";

                                #region Report Path
                              //  string s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                    string s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                                    string sReportTitle = "CREDIT NOTE";

                                sReportPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_CreditNote));
                                #endregion

                                #region Check Duplicate Copy
                                if (!bIsDraft)
                                {
                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (CreditNote.PrintCount > 0) ? "Duplicate Copy " + CreditNote.PrintCount : "";

                                    //if (CreditNote.PrintCount > 0)
                                    //    sDuplicate = "Duplicate Copy " + CreditNote.PrintCount;

                                    CreditNote.PrintCount++;
                                    CreditNote.Update();
                                }
                                #endregion

                                #region User Details
                                sCreateUser = "[ " + clsGenaralName.getName_User(CreditNote.CreateUser_ID) + " ] [ " + CreditNote.DateCreate.ToShortDateString() + " ]";
                                if (CreditNote.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(CreditNote.CheckedUser_ID) + " ] [ " + CreditNote.DateChecked.ToShortDateString() + " ]";
                                if (CreditNote.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(CreditNote.ApprovedUser_ID) + " ] [ " + CreditNote.DateApproved.ToShortDateString() + " ]";

                                sCreateUserName = "[ " + clsGenaralName.getName_User(CreditNote.CreateUser_ID) + " ]";
                                sCreateDate = CreditNote.DateCreate.ToString("dd/MM/yyyy hh:mm:ss tt");
                                if (CreditNote.IsChecked)
                                {
                                    sCheckedUserName = "[ " + clsGenaralName.getName_User(CreditNote.CheckedUser_ID) + " ]";
                                    sCheckedDate = CreditNote.DateChecked.ToString("dd/MM/yyyy hh:mm:ss tt");
                                }
                                #endregion

                                #region Tax Type Selection
                                if (clsConfig.bDisplay_TaxCreditNote)
                                {
                                    if (CreditNote.NbtTotal > 0 || CreditNote.VatTotal > 0)
                                        sTaxType = "TAX ";
                                    else if (CreditNote.OtherTaxTotal > 0)
                                        sTaxType = "SVAT ";
                                    else
                                        sTaxType = "NON TAX ";
                                }
                                else
                                {
                                    bool bistaxInvoice = false;
                                    sTaxType = "";

                                    if (oTax.bSVatSelected)
                                        sTaxType = "SVAT";
                                    else if (!oTax.bVatSelected && !oTax.bNbtSelected && !oTax.bSVatSelected)
                                        sTaxType = "NON TAX";
                                    else
                                    {
                                        sTaxType = "TAX";
                                        bistaxInvoice = true;
                                    }
                                }
                                #endregion

                                DataSet ds_CreditNote = new DataSet();
                                if (clsConfig.bEnable_CreditNoteWithSalesReturnItem)
                                {
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
                                    glb_dtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sTaxType + " " + sReportTitle, "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    ds_CreditNote = AdvancedPrint_CreditNote(CreditNote, oTax.bVatSelected, oTax.bNbtSelected, oTax.bSVatSelected);
                                }
                                else
                                {
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

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", "", true);
                                        }
                                    }
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sTaxType + " " + sReportTitle, "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    ds_CreditNote = Print_CreditNote(CreditNote, ref sInvoiceID, ref sCrInvoice, bRptSVat);
                                    if (CreditNote.Invoice_ID == "" || CreditNote.Invoice_ID == "default")
                                        sInvoiceID = sCrInvoice;
                                    else
                                        sInvoiceID = sInvoiceID;
                                }

                                #region Add Formula Field
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("InvoiceID", sInvoiceID, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IDTitle", "CRN No", true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IDDateTitle", "CRN Date", true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NumberID", "Inv / Debit Note No", true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NumberDate", "Inv / Debit Note Date", true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUserName, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUserName, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreateDate, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sCheckedDate, true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsCreditNote", "True", true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TAX", sTaxType, true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", CreditNote.IsDeleted ? "CANCELLED" : "", true);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.getCompanyVAT(), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);
                                #endregion

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, ds_CreditNote, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_CreditNote));

                                clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CreditNote), CreditNote.CreditNote_ID);
                            }
                        }
                    }
                    }
                    else
                        MessageBox.Show("Please Select the Credit Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("", iFormID, ex);
                }
                finally
                {
                    glb_dtsSales.Clear();
                    Cursor = Cursors.Default;
                }
            }

        }

        private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Decimal dAllocated = clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", e.RowIndex, decimal.Parse("0.00"));
                    Decimal dBalance = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceAmount", e.RowIndex, decimal.Parse("0.00"));
                    if (dAllocated <= dBalance)
                        dgvInvoice["AllocatedAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", e.RowIndex, decimal.Parse("0.00")));
                    else
                    {
                        MessageBox.Show("Allocate amount cannot be greater than Balance amount ...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvInvoice["AllocatedAmount", e.RowIndex].Value = "00.00";
                    }
                    CalculateInvoiceTotal();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            if (dgvInvoice.RowCount < 1)
                Search_CustomerID();
            else
                MessageBox.Show("Please remove Invoices to change Customer ...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        #endregion

        #region Set Disable Control
        private void SetDisableControl(bool bEnable)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bEnable);
        }
        #endregion

        private void Search_CustomerID()
        {
            try
            {
                clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString() != "default")
                    AfterCustomerChanged();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        public void AfterCustomerChanged()
        {
            try
            {
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                if (oCustomer != null)
                {
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

        private void txtCreditNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNote();
        }

        private void txtCreditNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNote();
        }

        private void Search_CreditNote()
        {
            try
            {
                clsSearch.Search_TransactionCreditNote_Direct(ref txtCreditNoteID, chkShowSettle.Checked);
                if (txtCreditNoteID.Tag != null && txtCreditNoteID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtCreditNoteID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCreditNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNoteType();
        }

        private void txtCreditNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNoteType();
        }

        private void Search_CreditNoteType()
        {
            try
            {
                clsSearch.Search_MasterCreditNoteType(ref txtCreditNoteType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }

        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }

        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }

        private void uC_ExchangeRate1_ExRateChanged()
        {
            if (txtCustomerID.Tag != null)
            {
                string sSalesNotetype_ID = txtSalesNoteType.Tag != null ? txtSalesNoteType.Tag.ToString() : "default";
                uC_TotalCalc1.SetEnableTax(uC_TotalCalc1.IsNBTenable, uC_TotalCalc1.IsVatEnable, uC_TotalCalc1.IsSvatEnable, "default", txtCustomerID.Tag.ToString(), sSalesNotetype_ID, uC_ExchangeRate1.ExchangeRate);
            }
        }

        private void uC_TotalCalc1_DoubleEntryUpdataed(DataTable dt)
        {
            uC_DoubleEntry1.Refresh(dt);
        }

        #region Calculate InvoiceTotal
        private void CalculateInvoiceTotal()
        {
            decimal dAllocatedAmount = 0, dInvoiceAmount = 0;
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                dInvoiceAmount += clsValidate.ValidateGridValue(dgvInvoice, "InvoiceAmount", row.Index, decimal.Parse("0.00"));
                dAllocatedAmount += clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", row.Index, decimal.Parse("0.00"));
            }
            txtTotalAllocated.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);
            txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dInvoiceAmount);
        }
        #endregion

        private DataSet Print_CreditNote(tbl_bpsCreditNote CreditNote, ref string sInvoiceID, ref string sCrInvoice, bool bRptSVat)
        {
            try
            {
                if (CreditNote != null)
                {
                    #region Fill Header
                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(CreditNote.Invoice_ID);
                    if (oInvoice != null)
                    {
                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(CreditNote.Customer_ID);
                        if (oCustomer != null)
                            sInvoiceID = CreditNote.Invoice_ID;
                        glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(CreditNote.CreditNote_ID, CreditNote.CreditNoteDate, clsGenaralName.getName_Customer(CreditNote.Customer_ID), CreditNote.TotalAmount,
                                  CreditNote.SubTotal, CreditNote.CreditNoteType_ID, CreditNote.Invoice_ID, oInvoice.InvoiceDate, CreditNote.VatTotal, CreditNote.NbtTotal, CreditNote.NbtTotal, clsGenaralName.getName_CurrencyCode(CreditNote.Currency_ID),
                                  CreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(CreditNote.SubTotal, CreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(CreditNote.VatTotal, CreditNote.CurrencyRate),
                                  CreditNote.SubTotal, clsGenaralName.getName_CustomerRegisterAddress(CreditNote.Customer_ID), CreditNote.IsDeleted, CreditNote.PrintCount, "", 0, CreditNote.Remark, "", clsSecurity.getServerDateTime().Date, CreditNote.TotalAmount,
                                                                  CreditNote.VatTotal, CreditNote.NbtTotal, CreditNote.SubTotal, 1, clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID), CreditNote.SalesReturnedNote_ID, CreditNote.OtherTaxTotal, oInvoice.DiscountTotal, oCustomer.SvatRegistrationNo);
                    }
                    #endregion

                    #region Fill Details
                    foreach (tbl_bpsCreditNote_Invoice oDetail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(CreditNote.CreditNote_ID))
                    {
                        oInvoice = null;
                        oInvoice = tbl_sasInvoice.Select(oDetail.Invoice_ID);
                        if (oInvoice != null)
                        {
                            decimal dAmountWithNBT = 0, dAmountSubTotal = 0, dAmountNBT = 0, dAmountVat = 0;
                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oDetail.AlocatedAmount, (CreditNote.VatTotal != 0 ? CreditNote.VatPercentage : 0), (CreditNote.NbtTotal != 0 ? CreditNote.NbtPercentage : 0), ref dAmountWithNBT, ref dAmountSubTotal, ref dAmountNBT, ref dAmountVat);

                            if (bRptSVat)
                                dAmountVat = oDetail.AlocatedAmount != 0 ? oDetail.AlocatedAmount * CreditNote.OtherTaxPercentage / 100 : 0;

                            sCrInvoice += oDetail.Invoice_ID + ", ";

                            string sItems = "";
                            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CreditNote_ID == CreditNote.CreditNote_ID))
                            {
                                foreach (tbl_sasSalesReturnedNote_Detail oSRNDetails in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                                {
                                    sItems += clsGenaralName.getName_Item(oSRNDetails.Item_ID) + " , ";
                                }
                            }
                            glb_dtsSales.dt_sasCreditNote_InvoiceAllocation.Adddt_sasCreditNote_InvoiceAllocationRow(oDetail.CreditNote_ID, oDetail.Invoice_ID, "", sItems, oInvoice.InvoiceDate, clsHelpMethods_Local.getDisplayPrice(dAmountSubTotal, CreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dAmountNBT, CreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dAmountVat, CreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oDetail.AlocatedAmount, CreditNote.CurrencyRate));
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return glb_dtsSales;
        }

        private void uC_DoubleEntry1_Clicked(TransactionCategory TxnCat)
        {
            uC_TotalCalc1.UpdateAccCode(TxnCat);
        }

        private DataSet AdvancedPrint_CreditNote(tbl_bpsCreditNote oCreditNote, bool IsVATSelected, bool IsNBTSelected, bool IsSVATSelected)
        {
            try
            {
                string sTaxType = "", sDuplicate = "";
                if (oCreditNote != null)
                {
                    #region Fill Details
                    string sPoNO = "-", sCusAddress = "", sDeliveryAddress = "", sDeliveryTel = "", sSalesmanName = "", sBranchId = "";
                    string sInvoiceID = "", sCOID = "", sDOID = "";
                    DateTime dInvoiceDate = DateTime.Now;

                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
                    if (oCustomer != null)
                    {
                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                        if (oInvoice != null)
                        {
                            sInvoiceID = oInvoice.Invoice_ID;
                            dInvoiceDate = oInvoice.InvoiceDate;

                            #region Get PO No
                            foreach (tbl_sasCustomerOrder oCo in tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(oInvoice.OrderRefNo_ID))
                            {
                                if (oCo.PurchaseOrder_ID != "default")
                                    sPoNO = oCo.PurchaseOrder_ID;
                            }
                            #endregion

                            #region Get Customer Branch
                            if (oInvoice.Branch_ID != null && oInvoice.Branch_ID != "default")
                            {
                                tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oCustomer.Customer_ID, Convert.ToInt16(oInvoice.Branch_ID));
                                sBranchId = oBranch.BranchName;
                                sDeliveryAddress = oBranch.Address;
                                sDeliveryTel = oBranch.Telephone;
                            }
                            if (sDeliveryAddress == "")
                            {
                                sDeliveryAddress = oCustomer.AddressRegister;
                                sDeliveryTel = oCustomer.Telephone;
                            }
                            #endregion

                            #region Get Salesman
                            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                            if (oRef != null && oRef.OrderRefNo_ID != "default")
                            {
                                sSalesmanName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                            }
                            #endregion

                            #region Get CO No and DO No
                            List<tbl_sasInvoice_Detail> oDOList = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID);
                            var oDOs = oDOList.GroupBy(gb => new { gb.DeliveryOrder_ID }, (Key, group) => new { DOID = Key.DeliveryOrder_ID });
                            foreach (var oDO in oDOs.OrderBy(p => (p.DOID)))
                            {
                                sDOID += oDO.DOID + " ";
                            }

                            var oCOs = oDOList.GroupBy(gb => new { gb.CustomerOrder_ID }, (Key, group) => new { COID = Key.CustomerOrder_ID });
                            foreach (var oCO in oCOs.OrderBy(p => (p.COID)))
                            {
                                sCOID += oCO.COID + " ";
                            }
                            #endregion
                        }
                    }

                    #region Tax Type Selection
                    if (clsConfig.bDisplay_TaxCreditNote)
                    {
                        if (oCreditNote.NbtTotal > 0 || oCreditNote.VatTotal > 0)
                            sTaxType = "TAX ";
                        else if (oCreditNote.OtherTaxTotal > 0)
                            sTaxType = "SVAT ";
                        else
                            sTaxType = "NON TAX ";
                    }
                    else
                    {
                        if (oCreditNote.NbtTotal > 0 || oCreditNote.VatTotal > 0 || oCreditNote.OtherTaxTotal > 0)
                            sTaxType = "TAX ";
                        else
                            sTaxType = "";
                    }
                    #endregion

                    #region Fill Header

                    decimal dDiscountTotal = oCreditNote.DiscountTotal;

                    decimal dDiscountPresentage = (oCreditNote.SubTotal == 0) ? 0 : (dDiscountTotal * 100 / oCreditNote.SubTotal);
                    decimal dSubTotal = clsHelpMethods_Local.getDisplayPrice(oCreditNote.SubTotal, oCreditNote.CurrencyRate);
                    dDiscountTotal = clsHelpMethods_Local.getDisplayPrice(dDiscountTotal, oCreditNote.CurrencyRate);
                    decimal dNbtAmout = clsHelpMethods_Local.getDisplayPrice(oCreditNote.NbtTotal, oCreditNote.CurrencyRate);
                    decimal dvatAmount = clsHelpMethods_Local.getDisplayPrice(oCreditNote.VatTotal, oCreditNote.CurrencyRate);
                    decimal dSvatAmount = clsHelpMethods_Local.getDisplayPrice(oCreditNote.OtherTaxTotal, oCreditNote.CurrencyRate);
                    decimal dGrandToatal = clsHelpMethods_Local.getDisplayPrice(oCreditNote.TotalAmount, oCreditNote.CurrencyRate);

                    clsHelpMethods.CalculateGrandTotalReverce(dGrandToatal, ref dvatAmount, oCreditNote.VatPercentage, IsVATSelected, ref dSvatAmount, oCreditNote.OtherTaxPercentage, IsSVATSelected, ref dNbtAmout, oCreditNote.NbtPercentage, IsNBTSelected, ref dDiscountTotal, dDiscountPresentage, ref dSubTotal);

                    glb_dtsBills.dt_bpsCreditNote.Adddt_bpsCreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCreditNote.Customer_ID, clsGenaralName.getName_Customer(oCreditNote.Customer_ID),
                                                    oCustomer.AddressRegister, oCustomer.Telephone, sBranchId, sSalesmanName, sDeliveryAddress, sDeliveryTel, oCreditNote.IsDeleted,
                                                    sInvoiceID, dInvoiceDate, sDOID, sCOID, oCreditNote.SalesReturnedNote_ID != "default" ? oCreditNote.SalesReturnedNote_ID : "-", sPoNO,
                                                    dSubTotal, dDiscountPresentage, dDiscountTotal,
                                                    dSubTotal, oCreditNote.NbtPercentage, dNbtAmout,
                                                    oCreditNote.VatPercentage, dvatAmount,
                                                    oCreditNote.OtherTaxPercentage, dSvatAmount, dGrandToatal,
                                                    oCreditNote.OrderRefNo_ID,
                                                    oCustomer.SvatRegistrationNo, oCustomer.VatRegistrationNo, oCustomer.NbtRegistrationNo, sTaxType,
                                                    clsCommon.CurrencyToWord(decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(oCreditNote.TotalAmount))),
                                                    oCreditNote.Remark,
                                                    oCreditNote.Currency_ID, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID));

                    #endregion

                    #region Fill Details
                    decimal dInvoiceSubTotal = clsHelpMethods_Local.getDisplayPrice(oCreditNote.SubTotal, oCreditNote.CurrencyRate);
                    foreach (tbl_sasSalesReturnedNote_Detail oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oCreditNote.SalesReturnedNote_ID))
                    {
                        decimal dUnitPrice = 0;

                        tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                        tbl_zUom oUom = tbl_zUom.Select(oItmaster.Uom_ID);
                        if (oUom != null && oItmaster != null)
                        {
                            decimal dAmount = clsHelpMethods_Local.getDisplayPrice(oSRN_Detail.TatalAmount, oCreditNote.CurrencyRate);
                            decimal dLineDiscount = oSRN_Detail.DiscountAmount;
                            dUnitPrice = oSRN_Detail.UnitPrice;

                            if (!oSRN_Detail.BIsFreeItem)
                            {
                                decimal dRatio = (dInvoiceSubTotal != 0) ? (dAmount / dInvoiceSubTotal) : 0;
                                dAmount = dSubTotal * dRatio;
                                dLineDiscount = (dAmount * oSRN_Detail.DiscountPresentage) / (100 - oSRN_Detail.DiscountPresentage);
                                dUnitPrice = (dAmount + dLineDiscount) / oSRN_Detail.Qty;
                            }
                            glb_dtsBills.dt_dpsCreditNote_Detail.Adddt_dpsCreditNote_DetailRow(oCreditNote.CreditNote_ID, oSRN_Detail.Item_ID, oItmaster.ItemName,
                                dUnitPrice, oSRN_Detail.Qty, dAmount, oSRN_Detail.Remark, oUom.UomCode, oSRN_Detail.DiscountPresentage, dLineDiscount, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID));
                        }
                    }
                    #endregion
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return glb_dtsBills;
        }
              
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
        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsMethods_GL.PostTransaction_CRN(txtCreditNoteID.Text, AccSlot.Customer_CreditNote);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion
    }
}