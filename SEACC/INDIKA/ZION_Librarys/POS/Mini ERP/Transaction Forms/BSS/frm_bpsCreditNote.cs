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
using Digiteq.DataSets.BSS;
using Digiteq.DataSets;

namespace Digiteq
{
    // digiteq will note provide "open" credit note directly on customer's name in sales system. sales system is 
    // totally balsed on sales notes. this type of credit note could be done in GL module (journal voucher) 2011-12-16 (Asanka/Mr. Vijitha)
    public partial class frm_bpsCreditNote : SEACC_Form
    {
        #region Variables
        //to keep glob ref no        
        public string glbOrderRefNo = "", glbCreditNoteID = "";

        dts_Sales glb_dtsSales = new dts_Sales();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_CreditNote glb_dtsBills = new dts_CreditNote();

        decimal dNbtPresentage = 0, dVatPresentage = 0;
        bool bNBTApplicable = false, bVatApplicable = false, bSVatApplicable = false;
        #endregion

        #region Form Load
        public frm_bpsCreditNote(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_bpsCreditNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();

            if (glbCreditNoteID != null && glbCreditNoteID.Length > 0)
                FillDetails(glbCreditNoteID);

            foreach (tbl_zTax oTax in tbl_zTax.SelectAll())
            {
                if (oTax.TaxName == clsAutocode.getTaxType(Tax.NBT))
                    dNbtPresentage = oTax.TaxPesentage;
                else if (oTax.TaxName == clsAutocode.getTaxType(Tax.VAT))
                    dVatPresentage = oTax.TaxPesentage;
            }
        }
        #endregion

        #region Btn New
        private void frm_bpsCreditNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_bpsCreditNote_SF_cancelButton_Click(object sender, EventArgs e)
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
                                            if (clsHelpMethods.RemoveSattlementsFrom_CreditNoteID(detail.CreditNote_ID))
                                            {
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DeletedTerminal_ID = clsSecurity.TerminalID;
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
                                                clsAlerts_Email.createEmail_CreditNote(txtCreditNoteID.Text.Trim(), enum_Alerts.CreditNoteCancel);
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
        private void frm_bpsCreditNote_SF_saveButton_Click(object sender, EventArgs e)
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
                    string sOutstandingTrackingRemarks = string.Empty;

                    string sInvoiceId = "default", sSRNID = "default", sDoID = "default", sOrderRefNo = "default", sChequeRegisterId = "default";
                    decimal dAllocatedAmount = 0, dSubTotal = 0, dNbt = 0, dVat = 0, dDiscount = 0, dOtherTaxPresentage = 0, dOtherTax = 0;

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
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID,
                                            clsAutocode.GetProcessNoteID(ProcessNote.CreditNote),
                                            oldRecord.CreditNote_ID, "Credit Note");

                                        //Invoice Header

                                        #region Update Invoice Header

                                        bool bIsLocked = oldRecord.IsLocked;
                                        if (chkReverseCalculation.Checked)
                                            bIsLocked = true;

                                        if (dgvInvoice.Rows.Count == 1)
                                        {
                                            sSRNID = txtSalesReturnNoteID.Tag.ToString();
                                            sInvoiceId = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", 0,
                                                "default");
                                            sDoID = txtDeliveryOrderID.Tag.ToString();
                                            sOrderRefNo = glbOrderRefNo;
                                            sChequeRegisterId = txtChequeNo.Tag.ToString();
                                        }

                                        dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                                        dNbt = decimal.Parse(txtNBT.Text.Trim());
                                        dVat = decimal.Parse(txtVat.Text.Trim());
                                        dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                                        dOtherTax = decimal.Parse(txtOtherTax.Text.Trim());
                                        dAllocatedAmount = decimal.Parse(txtGrandTotal.Text.Trim());

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
                                            oldRecord.FinancialYear_ID, txtCurrencyID.Tag.ToString(),
                                            txtSalesNoteType.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()),
                                            decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                            decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            decimal.Parse(txtPercentageVat.Text.Trim()),
                                            decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                            clsHelpMethods.getSavePrice(dSubTotal, txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(dDiscount, txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(dNbt, txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(dVat, txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(dOtherTax, txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(dAllocatedAmount, txtCurrencyRate),
                                            oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                            oldRecord.ApprovedUser_ID,
                                            oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                            oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                            glbApprovedDate, oldRecord.IsChecked, oldRecord.IsApproved,
                                            oldRecord.IsFinished,
                                            oldRecord.IsDeleted, oldRecord.IsLocked, !chkUnitPricing.Checked,
                                            oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.PrintCount,
                                            oldRecord.CompanyID, oldRecord.CompanyBranch_ID, bWriteOff,
                                            oldRecord.PosReturnTransaction_Index, oldRecord.AdvanceReceived_Index);
                                        detail.Update();

                                        // Outstanding Tracking //01
                                        string sNoteType =
                                            clsProcessMethods.getCreditNoteTypeTracking(
                                                txtCreditNoteType.Tag.ToString());
                                        string sTransaction_ID =
                                            clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal) ==
                                            txtCreditNoteType.Tag.ToString()
                                                ? sSRNID
                                                : sInvoiceId;


                                        foreach (tbl_bpsCreditNote_Invoice oInvDetail in tbl_bpsCreditNote_Invoice
                                            .SelectAllByCreditNote_ID(txtCreditNoteID.Text.Trim()))
                                        {
                                            oInvDetail.Delete();
                                        }

                                        int i = 0;
                                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                                        {
                                            string sInvoice = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID",
                                                row.Index, "default");
                                            if (sInvoice.Length > 1 && sInvoice != "default")
                                            {
                                                tbl_bpsCreditNote_Invoice oCndetail =
                                                    new tbl_bpsCreditNote_Invoice(txtCreditNoteID.Text.Trim(), i,
                                                        sInvoice,
                                                        clsValidate.ValidateGridValue(dgvInvoice, "OrderRefNo",
                                                            row.Index, "default"), 0);
                                                oCndetail.Insert();
                                                i += 1;
                                            }
                                        }

                                        //  clsMethods_GL.PostTransaction_SRN(txtCreditNoteID.Text);
                                        clsMethods_GL.PostTransaction_CRNOld(txtCreditNoteID.Text);

                                        #endregion

                                        if (!bisCheckin)
                                        {
                                            dgvInvoice.Rows.Clear();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
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
                        int i = 0;

                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        {
                            if (clsConfig.bBranchMaster_SerialNoActiveFor_CreditNote)
                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode_FromCompanyBranch_CreditNote(clsSecurity.BranchID);
                            else if (clsConfig.bSalesNoteType_SerialNoActiveFor_CreditNote)
                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode_FromSalesNoteType_CreditNote(txtSalesNoteType.Tag.ToString());
                            else
                                txtCreditNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        }

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtCreditNoteID.Text)) //if (txtCreditNoteID.TextLength > 0)
                        {
                            if (dgvInvoice.Rows.Count == 1)
                            {
                                sSRNID = txtSalesReturnNoteID.Tag.ToString();
                                sInvoiceId = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", 0, "default");
                                sDoID = txtDeliveryOrderID.Tag.ToString();
                                sOrderRefNo = glbOrderRefNo;
                                sChequeRegisterId = txtChequeNo.Tag.ToString();
                            }

                            dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                            dNbt = decimal.Parse(txtNBT.Text.Trim());
                            dVat = decimal.Parse(txtVat.Text.Trim());
                            dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                            dOtherTax = decimal.Parse(txtOtherTax.Text.Trim());
                            dAllocatedAmount = decimal.Parse(txtGrandTotal.Text.Trim());

                            bool bWriteOff = false;
                            if (rdoWriteOff.Checked)
                                bWriteOff = true;
                            else
                                bWriteOff = false;

                            #region CreditNote Header
                            tbl_bpsCreditNote detail = new tbl_bpsCreditNote(txtCreditNoteID.Text.Trim(), dtpCreditNoteDate.Value, txtRemark.Text.Trim(), sSRNID, sInvoiceId, txtCustomerID.Tag.ToString(), sDoID, sOrderRefNo, sChequeRegisterId, txtCreditNoteType.Tag.ToString(), "default",
                                                    clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtCurrencyID.Tag.ToString(), txtSalesNoteType.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                    decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods.getSavePrice(dSubTotal, txtCurrencyRate), clsHelpMethods.getSavePrice(dDiscount, txtCurrencyRate),
                                                    clsHelpMethods.getSavePrice(dNbt, txtCurrencyRate), clsHelpMethods.getSavePrice(dVat, txtCurrencyRate), clsHelpMethods.getSavePrice(dOtherTax, txtCurrencyRate), clsHelpMethods.getSavePrice(dAllocatedAmount, txtCurrencyRate), clsSecurity.UserIDLoged, "default", "default", "default",
                                                    clsSecurity.TerminalID, "default", "default", "default",
                                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, !chkUnitPricing.Checked, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, bWriteOff, (-1), (-1));
                            detail.Insert();
                            #endregion

                            string sNoteType = clsProcessMethods.getCreditNoteTypeTracking(txtCreditNoteType.Tag.ToString());
                            string sTransaction_ID = clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal) == txtCreditNoteType.Tag.ToString() ? sSRNID : sInvoiceId;
                            sOutstandingTrackingRemarks = "Credit Note for " + sNoteType + " " + sTransaction_ID;

                            //CreditNote  Detail   
                            i += 0;
                            foreach (DataGridViewRow row in dgvInvoice.Rows)
                            {
                                tbl_bpsCreditNote_Invoice oCndetail = new tbl_bpsCreditNote_Invoice(txtCreditNoteID.Text.Trim(), i, clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default"), clsValidate.ValidateGridValue(dgvInvoice, "OrderRefNo", row.Index, "default"), 0);
                                oCndetail.Insert();
                                i += 1;
                            }

                            Attachments.Insert(txtCreditNoteID.Text.ToString());
                            //     clsMethods_GL.PostTransaction_SRN(txtCreditNoteID.Text);
                            clsMethods_GL.PostTransaction_CRNOld(txtCreditNoteID.Text);
                            clsAlerts_Email.createEmail_CreditNote(txtCreditNoteID.Text.Trim(), enum_Alerts.CreditNoteCreated);



                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvInvoice.Rows.Clear();
                        }
                        //else
                        //    MessageBox.Show("Credit Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Btn Print
        private void frm_bpsCreditNote_SF_printButton_Click(object sender, EventArgs e)
        {
            //Print(false);
            tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
            if (detail != null && detail.IsApproved)
            {
                Print(false);
            }
            else
            {
                MessageBox.Show("Please Approve the Credit Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Draft
        private void frm_bpsCreditNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Add Invoice
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
                {
                    txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment);
                    txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment));

                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByInvoice_ID(detail.Invoice_ID);

                        //disable controls
                        SetDisableControl(false);

                        CalcualteSubTotal(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        CalculateTaxesAndGrandTotal();
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
                    txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal);
                    txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal));

                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSalesReturnNoteID.Tag.ToString());
                    if (detail != null)
                    {
                        //add currency detail
                        FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
                        FillTaxDetailByInvoice_ID(detail.SalesReturnedNote_ID);

                        //disable controls
                        SetDisableControl(false);

                        CalcualteSubTotal(detail.SubTotal);
                        CalculateTaxesAndGrandTotal();
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
                {
                    //frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
        }
        #endregion

        #region Btn Temp
        private void frm_bpsCreditNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtCreditNoteID.TextLength > 0 && txtCreditNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
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

                //Reset Order Ref No
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
        #endregion

        #region Invoice Settlement
        private void settleInvoicesWithCreditNote(string sCNID, string sUserID)
        {
            tbl_bpsCreditNote oCreditNoteOld = tbl_bpsCreditNote.Select(sCNID);
            if (oCreditNoteOld != null && oCreditNoteOld.CreditNote_ID != "default")
            {
                if (ValidateSettlement_CreditNote(oCreditNoteOld.CreditNote_ID) && !oCreditNoteOld.IsSeattled && oCreditNoteOld.CreditNoteType_ID != "default")
                {
                    if (!oCreditNoteOld.IsApproved && oCreditNoteOld.CurrencyRate > 0)
                    {
                        if (decimal.Parse(txtGrandTotal.Text.Trim()) > 0)
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
                                dAllocatedAmmount = clsHelpMethods.AutoSettledInvoiceWithCreditNote(sInvoiceID, oCreditNoteOld.CreditNote_ID, dAllocatedAmmount, sAllocationID, false, false);
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
        #endregion

        #region Print report
        //private void print(string path, string sReportTitle, DataSet ojbDataSet, string sDraff, string sCreateUser, string sCheckedUser, string sApprovedUser)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        string s_Path = "";
        //        ReportDocument objRpt = new ReportDocument();

        //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
        //        s_Path += path;

        //        objRpt.Load(s_Path);
        //        objRpt.SetDataSource(ojbDataSet);

        //        objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //        objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //        objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //        objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //        objRpt.DataDefinition.FormulaFields["IsDraft"].Text = clsCommon.fncsetstring(sDraff);
        //        objRpt.DataDefinition.FormulaFields["IDTitle"].Text = clsCommon.fncsetstring("CRN No");
        //        objRpt.DataDefinition.FormulaFields["IDDateTitle"].Text = clsCommon.fncsetstring("CRN Date");
        //        objRpt.DataDefinition.FormulaFields["NumberID"].Text = clsCommon.fncsetstring("Inv / Debit Note No");
        //        objRpt.DataDefinition.FormulaFields["NumberDate"].Text = clsCommon.fncsetstring("Inv / Debit Note Date");
        //        objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
        //        objRpt.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
        //        objRpt.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
        //        objRpt.DataDefinition.FormulaFields["IsCreditNote"].Text = clsCommon.fncsetstring("True");

        //        frm_ReportViewer ReportViewer = new frm_ReportViewer();
        //        ReportViewer.crystalReportViewer1.ReportSource = objRpt;
        //        ReportViewer.crystalReportViewer1.Refresh();
        //        ReportViewer.crystalReportViewer1.DisplayToolbar = true;
        //        ReportViewer.crystalReportViewer1.CloseView(false);
        //        ReportViewer.WindowState = FormWindowState.Maximized;
        //        ReportViewer.ShowDialog();

        //        objRpt.Close();
        //        objRpt.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //}
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCreditNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
            btnSave.Enabled = true;

            SetDisableControl(true);

            txtCreditNoteID.Tag = null;
            txtCustomerID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtCreditNoteType.Tag = null;
            txtSalesReturnNoteID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtChequeNo.Tag = null;

            txtCurrencyID.Tag = null;
            txtCurrencyCode.Tag = null;
            txtSalesNoteType.Tag = null;

            txtRemark.Clear();
            txtCustomerID.Clear();
            txtSalesExecutiveID.Clear();
            txtDeliveryOrderID.Clear();
            txtOrderRefNo.Clear();
            txtCreditNoteType.Clear();
            txtSalesReturnNoteID.Clear();
            txtInvoiceID.Clear();
            txtChequeNo.Clear();
            dtpCreditNoteDate.Value = clsSecurity.getServerDateTime();
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkPrintOriginal.Checked = false;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            txtSalesNoteType.Clear();

            rdoNormalSales.Checked = true;
            rdoWriteOff.Checked = false;

            txtDiscount.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtVat.Text = "0.00";

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            DisableMoneyControls();
            chkShowSettle.Checked = false;


            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkReverseCalculation.Enabled = true;
            chkSettings.Checked = true;
            dgvInvoice.Rows.Clear();
            btnClear_Click(null, null);

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
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreditNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCerditNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);

                        SetDisableControl(false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, true);

                        //asign values
                        txtCreditNoteID.Tag = detail.CreditNote_ID;
                        txtDeliveryOrderID.Tag = detail.DeliveryOrder_ID;
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        txtCreditNoteType.Tag = detail.CreditNoteType_ID;
                        txtSalesReturnNoteID.Tag = detail.SalesReturnedNote_ID;
                        txtInvoiceID.Tag = detail.Invoice_ID;
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtChequeNo.Tag = detail.ChequeRegister_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;

                        txtCreditNoteID.Text = detail.CreditNote_ID;
                        txtDeliveryOrderID.Text = clsCommon.GetForeignKeyValue(detail.DeliveryOrder_ID);
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtCreditNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_CreditNoteType(detail.CreditNoteType_ID));
                        txtSalesReturnNoteID.Text = clsCommon.GetForeignKeyValue(detail.SalesReturnedNote_ID);
                        txtInvoiceID.Text = clsCommon.GetForeignKeyValue(detail.Invoice_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtChequeNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeNo(detail.ChequeRegister_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        if (detail.Is_WriteOff == true)
                            rdoWriteOff.Checked = true;
                        else
                            rdoNormalSales.Checked = true;

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        //fill Invoices
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
                                dgvInvoice["AllocatedAmount", iLineno].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(oInvDetail.AlocatedAmount, oInvoice.CurrencyRate));

                                //if (iLineno != oInvDetail.Line_No)
                                //{
                                //    oInvDetail.Line_No = iLineno;
                                //    oInvDetail.Update();
                                //}

                                iLineno += 1;
                            }
                        }
                        CalculateInvoiceTotal();

                        dtpCreditNoteDate.Value = detail.CreditNoteDate;
                        txtRemark.Text = detail.Remark;
                        txtRemark.Text = detail.Remark;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();

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

                        //Asign Taxes
                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtSubTotal.Tag = clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate);
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtDiscount.Tag = clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate);
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtNBT.Tag = clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate);
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtOtherTax.Tag = clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate);
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtVat.Tag = clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate);
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate));

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;

                        chkNBT.Enabled = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Enabled = (detail.VatTotal > 0) ? true : false;


                        //  CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();

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
        #endregion

        #region Fill Customer Detials
        private void FillDetailsCustomer(string sCustomerID)
        {
            try
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();

                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    txtCustomerID.Tag = customer.Customer_ID;
                    txtCustomerID.Text = clsGenaralName.getName_Customer(customer.Customer_ID);
                    //tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(customer.Customer_ID);
                    //if (oCusFin != null)
                    //{
                    //    txtCreditPeriod.Text = oCusFin.CreditPeriod.ToString();
                    //}
                    txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(customer.SalesRep_ID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By DeliveryOrderID
        private void FillTaxDetailByDeliveryOrderID(string DeliveryOrderID)
        {
            tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(DeliveryOrderID);

            if (detail != null)
            {
                txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal);
                txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);


                if (detail.DiscountTotal > 0)
                    chkDiscount.Checked = true;
                else
                    chkDiscount.Checked = false;
                if (detail.NbtTotal > 0)
                    chkNBT.Checked = true;
                else
                    chkNBT.Checked = false;
                if (detail.VatTotal > 0)
                    chkVat.Checked = true;
                else
                    chkVat.Checked = false;
                if (detail.OtherTaxTotal > 0)
                    chkOtherTax.Checked = true;
                else
                    chkOtherTax.Checked = false;

                txtRemark.Text = detail.Remark;
            }
        }
        #endregion

        #region Fill Tax Detail By Invoice_ID
        private void FillTaxDetailByInvoice_ID(string Invoice_ID)
        {
            decimal dCurrencyRate = 0;// dNbtTotal = 0, dVatTotal = 0, dSVatTotal = 0;dAllocateAmmount = 0,
            dCurrencyRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            tbl_sasInvoice detail = tbl_sasInvoice.Select(Invoice_ID);
            if (detail != null)
            {
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));

                txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);

                txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
                txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
                txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

                txtRemark.Text = detail.Remark;

                if (decimal.Parse(txtDiscount.Text.Trim()) > 0)
                    chkDiscount.Checked = true;
                else
                    chkDiscount.Checked = false;
                if (decimal.Parse(txtNBT.Text.Trim()) > 0)
                    chkNBT.Checked = true;
                else
                    chkNBT.Checked = false;
                if (decimal.Parse(txtVat.Text.Trim()) > 0)
                    chkVat.Checked = true;
                else
                    chkVat.Checked = false;
                if (decimal.Parse(txtOtherTax.Text.Trim()) > 0)
                    chkOtherTax.Checked = true;
                else
                    chkOtherTax.Checked = false;
            }
        }
        #endregion

        #region Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurrencyID.Tag = null;
                txtCurrencyID.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurrencyCode.Text = currency.CurrencyCode;
                        txtCurrencyID.Tag = currency.Currency_ID;
                        txtCurrencyID.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = currency.CurrencyRate.ToString();
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
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (CheckItemSettleValidity())
                    {
                        //if (CheckOutstandingValidity())
                        //{
                        if (checkCurrancyTypeValidity())
                        {
                            if (checkInvoiceTypeValidity())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpCreditNoteDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (CheckValidity_Posting())
                                            bStatus = true;
                                    }
                                }
                            }
                        }
                        //}
                    }
                }
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

        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            //   string sItemCode = "", sDoCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            //  decimal dQuantity = 0, dWeight = 0;

            //if ((!clsAutocode.getItemExceed(ConfigItemExceedLock.Invoice)) && (!IsUpdate))
            //{
            //    foreach (DataGridViewRow row in dgvDetail.Rows)
            //    {
            //        try
            //        {
            //            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
            //            sDoCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
            //            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
            //            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
            //            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
            //            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
            //            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
            //            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

            //            tbl_sasDeliveryOrder_Detail DoDetail = tbl_sasDeliveryOrder_Detail.Select(sDoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
            //            if (DoDetail != null)
            //            {
            //                if (chkUnitPricing.Checked)
            //                {
            //                    if (IsUpdate)
            //                    {
            //                        if (DoDetail.Qty < dQuantity)
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (DoDetail.Qty < (DoDetail.QtySettle + dQuantity))
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity  \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (IsUpdate)
            //                    {
            //                        if (DoDetail.Weight < dWeight)
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Weight cannot Exceed the Delivery Order Weight \n";
            //                            rtn = false;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (DoDetail.Weight < (DoDetail.WeightSettle + dWeight))
            //                        {
            //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Weight cannot Exceed the Delivery Order Weight\n";
            //                            rtn = false;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            clsValidate.WriteErrorLog("", iFormID,ex);
            //            SEACCException.Show(ex);
            //        }
            //    }
            //    if (!rtn)
            //    {
            //        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            return rtn;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                {
                    strMessage += "\n Sub Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Pasentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtVat.Text.Trim()))
                {
                    strMessage += "\n VAT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n VAT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtNBT.Text.Trim()))
                {
                    strMessage += "\n NBT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n NBT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtGrandTotal.Text.Trim()))
                {
                    strMessage += "\n Grand Total";
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

        private bool CheckOutstandingValidity()
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
                            if (clsConfig.bCreditBalanceInvoice_Message) //security 1 - Message
                            {
                                dCreditBalance = clsHelpMethods.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                                if (txtGrandTotal.TextLength > 0)
                                    dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());
                                if (dCreditBalance < dAmountDue) //Condition
                                {
                                    bOk = false;
                                    if (clsConfig.bCreditBalanceInvoice_Lock) //security 2 - Lock
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    else
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            bOk = true;
                                        }
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
        private bool checkInvoiceTypeValidity()
        {
            bool isValid = false;

            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
            {
                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    string sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "");
                    if (sInvoiceID.Length > 0)
                    {
                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                        if (oInvoice != null && oInvoice.Invoice_ID != "default")
                        {
                            if (oInvoice.Quotation_ID != "default")
                            {
                                if (chkNBT.Checked)
                                {
                                    isValid = false;
                                    break;
                                }
                                else
                                    isValid = true;

                            }
                            else
                                isValid = true;
                        }
                    }
                }
            }
            else
                isValid = true;

            if (!isValid)
                MessageBox.Show("Block invoice Can't have NBT", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return isValid;

        }
        private bool checkCurrancyTypeValidity()
        {
            bool isValid = false;
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
                        if (oInvoice.Currency_ID != txtCurrencyID.Tag.ToString() || oInvoice.CurrencyRate != decimal.Parse(txtCurrencyRate.Text))
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
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtDeliveryOrderID);
                clsCommon.ValidateForeignKey(ref txtSalesReturnNoteID);
                clsCommon.ValidateForeignKey(ref txtChequeNo);
                clsCommon.ValidateForeignKey(ref txtCreditNoteType);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtCreditNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNote();
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Invoice(sender);
        }
        private void txtSalesReturnNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesReturnNoteID(sender);
        }
        private void txtCreditNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNoteType();
        }
        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Cheque(sender);
        }
        private void txtDeliveryOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DeliveryOrder(sender);
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search_SalesExecutiveID();
        }
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }
        #endregion

        #region Events Double Click
        private void txtCreditNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNote();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_Invoice(sender);
        }
        private void txtChequeNo_DoubleClick(object sender, EventArgs e)
        {
            Search_Cheque(sender);
        }
        private void txtDeliveryOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_DeliveryOrder(sender);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtSalesReturnNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesReturnNoteID(sender);
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtCreditNoteType_DoubleClick_1(object sender, EventArgs e)
        {
            Search_CreditNoteType();
        }
        #endregion

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0.00";
                txtDiscount.Tag = "0";
                CalculateTaxesAndGrandTotal();
            }
        }

        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked && chkVat.Enabled)
                chkVat.Checked = true;
        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                txtPercentageOtherTax.Enabled = true;
                chkVat_CheckedChanged(chkVat, new EventArgs());
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageOtherTax.Enabled = false;
                txtPercentageOtherTax.Text = clsCommon.getPesentageOtherTax().ToString();
                chkVat_CheckedChanged(chkVat, new EventArgs());
                txtOtherTax.Text = "0";
                CalculateTaxesAndGrandTotal();
            }
        }

        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkReverseCalculation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReverseCalculation.Checked)
            {
                chkReverseCalculation.Enabled = false;
                chkNBT.Checked = true;
                chkVat.Checked = true;
            }
        }

        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSettings.Checked)
            //{

            //    chkSettings.Image = Digiteq.Properties.Resources.network;
            //}
            //else
            //{
            //    xSetting.SendToBack();
            //    chkSettings.Image = Digiteq.Properties.Resources.settings;
            //}
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

        #region Event Key Press
        private void txtGrandTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtGrandTotal.Text, e);
        }
        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtSubTotal.Text, e);
        }
        #endregion

        #region Event Mouse Down
        private void txtSubTotal_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtSubTotal.Select(0, txtSubTotal.Text.Length);
        }
        #endregion

        #region Disable Money Controls
        private void DisableMoneyControls()
        {
            txtDiscount.Enabled = false;
            txtPercentageDiscount.Enabled = false;
            txtPercentageVat.Enabled = false;
            txtPercentageNBT.Enabled = false;
            txtPercentageOtherTax.Enabled = false;
            txtOtherTax.Enabled = false;
        }
        #endregion

        #region Search Methods
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
        private void Search_CustomerID()
        {
            try
            {
                if (dgvInvoice.RowCount == 0)
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
                else
                    MessageBox.Show("Please remove Invoices to change Customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), false, "", false, true, true, true, true, txtSalesNoteType.Tag == null ? "" : txtSalesNoteType.Tag.ToString());

                else
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, "", false, "", false, true, true, true, true, txtSalesNoteType.Tag == null ? "" : txtSalesNoteType.Tag.ToString());

                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
                    AddNewInvoice();
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
        private void Search_Cheque(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionChequeByCustomerID_Use(ref txtChequeNo, txtCustomerID.Tag.ToString(), false, "", true);
                else
                    clsSearch.Search_TransactionCheque_Use(ref txtChequeNo, false, "", true);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_DeliveryOrder(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrderID, txtCustomerID.Tag.ToString(), true);
                else
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrderID, "", true);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);
            if (txtCurrencyID.Tag != null)
                FillDetailsCurrency(txtCurrencyID.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
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
            if (dgvInvoice.RowCount == 0)
            {
                clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
                if (txtSalesNoteType.Tag != null && txtSalesNoteType.Text != "")
                {
                    tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                    if (oNoteType != null)
                    {
                        chkVat.Enabled = oNoteType.IsPostingEnable_VAT ? true : false;
                        chkNBT.Enabled = oNoteType.IsPostingEnable_NBT ? true : false;

                        chkVat.Checked = oNoteType.IsPostingEnable_VAT ? true : false;
                        chkNBT.Checked = oNoteType.IsPostingEnable_NBT ? true : false;
                    }
                }
            }
            else
                MessageBox.Show("Please remove Invoices to change Note Type..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
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
                    //  bool bIsDataset = false;
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
                                string s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                string sReportTitle = "CREDIT NOTE";

                                string sDbPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_CreditNote));
                                if (sDbPath != null && sDbPath.Length > 0)
                                {
                                    sReportPath = sDbPath;
                                    // bIsDataset = true;
                                }
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                    s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote_WD.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                    s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                    s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                                    s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote.rpt";
                                else
                                {
                                    bRptSVat = CreditNote.OtherTaxTotal == 0 ? false : true;
                                    if (bRptSVat)
                                    {
                                        sReportPath = "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote_AKT_SVAT.rpt";
                                        sReportTitle = "CREDIT NOTE - SVAT ";
                                    }
                                    else
                                        sReportPath = "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote_AKT.rpt";
                                    //  bIsDataset = true;
                                }
                                #endregion

                                #region Check Duplicate Copy
                                if (!bIsDraft)
                                {
                                    //if (CreditNote.PrintCount > 0)
                                    //    sDuplicate = "Duplicate Copy " + CreditNote.PrintCount;

                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (CreditNote.PrintCount > 0) ? "Duplicate Copy " + CreditNote.PrintCount : "";

                                    CreditNote.PrintCount++;
                                    CreditNote.PrintedTerminal_ID = clsSecurity.TerminalID;
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
                                    if (CreditNote.NbtTotal > 0 || CreditNote.VatTotal > 0 || CreditNote.OtherTaxTotal > 0)
                                        sTaxType = "TAX ";
                                    else
                                        sTaxType = "";
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

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", "", true,false);
                                        }
                                    }
                                    glb_dtsBills.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sTaxType + " " + sReportTitle, "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    ds_CreditNote = AdvancedPrint_CreditNote(CreditNote);
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

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", "", true,false);
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
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsSecurity.DigiteqEmail, true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("InvoiceID", sInvoiceID, true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IDTitle", "CRN No", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IDDateTitle", "CRN Date", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NumberID", "Inv / Debit Note No", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NumberDate", "Inv / Debit Note Date", true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUserName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUserName, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreateDate, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sCheckedDate, true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsCreditNote", "True", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TAX", sTaxType, true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", CreditNote.IsDeleted ? "CANCELLED" : "", true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.getCompanyVAT(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true,false);
                                #endregion

                                #region View
                                //else
                                //{
                                //    #region vw
                                //    string sFormula = "";
                                //    if (txtCreditNoteID.TextLength > 0)
                                //        sFormula = "{vw_rpt_bpsCreditNote.creditNote_ID} = '" + txtCreditNoteID.Text.Trim() + "'";
                                //    ReportDocument RD = new ReportDocument();

                                //    frm_ReportViewer viewer = new frm_ReportViewer();
                                //    viewer.crystalReportViewer1.ShowExportButton = false;
                                //    RD.Load(s_Path);
                                //    clsSecurity.LogonServer(ref RD);
                                //    RD.Refresh();

                                //    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                //    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                //    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                                //    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                //    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                //    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                //    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                                //    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                //    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                                //    viewer.crystalReportViewer1.ReportSource = RD;
                                //    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                //    viewer.crystalReportViewer1.Visible = true;
                                //    viewer.crystalReportViewer1.DisplayToolbar = true;
                                //    viewer.crystalReportViewer1.CloseView(false);
                                //    viewer.WindowState = FormWindowState.Maximized;

                                //    viewer.ShowDialog();

                                //    RD.Close();
                                //    RD.Dispose();
                                //    #endregion
                                //} 
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

        private DataSet Print_CreditNote(tbl_bpsCreditNote CreditNote, ref string sInvoiceID, ref string sCrInvoice, bool bRptSVat)
        {
            if (CreditNote != null)
            {
                #region Fill Header
                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(CreditNote.Invoice_ID);
                if (oInvoice != null)
                {
                    sInvoiceID = CreditNote.Invoice_ID;
                    glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(CreditNote.CreditNote_ID, CreditNote.CreditNoteDate, clsGenaralName.getName_Customer(CreditNote.Customer_ID), CreditNote.TotalAmount,
                              CreditNote.SubTotal, CreditNote.CreditNoteType_ID, CreditNote.Invoice_ID, oInvoice.InvoiceDate, CreditNote.VatTotal, CreditNote.NbtTotal, CreditNote.NbtTotal, clsGenaralName.getName_CurrencyCode(CreditNote.Currency_ID),
                              CreditNote.CurrencyRate, clsHelpMethods.getDisplayPrice(CreditNote.SubTotal, CreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(CreditNote.VatTotal, CreditNote.CurrencyRate),
                              CreditNote.SubTotal, clsGenaralName.getName_CustomerRegisterAddress(CreditNote.Customer_ID), CreditNote.IsDeleted, CreditNote.PrintCount, "", 0, CreditNote.Remark, "", clsSecurity.getServerDateTime().Date, CreditNote.TotalAmount,
                              //CreditNote.VatTotal, CreditNote.NbtTotal, CreditNote.SubTotal, 1, clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID), CreditNote.SalesReturnedNote_ID, oInvoice.OtherTaxTotal, oInvoice.DiscountTotal);
                              CreditNote.VatTotal, CreditNote.NbtTotal, CreditNote.SubTotal, 1, clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID), CreditNote.SalesReturnedNote_ID, CreditNote.OtherTaxTotal, oInvoice.DiscountTotal, "");
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

                        //if(CreditNote.Invoice_ID == "" || CreditNote.Invoice_ID == "default")
                        sCrInvoice += oDetail.Invoice_ID + ", ";

                        glb_dtsSales.dt_sasCreditNote_InvoiceAllocation.Adddt_sasCreditNote_InvoiceAllocationRow(oDetail.CreditNote_ID, oDetail.Invoice_ID, "", "", oInvoice.InvoiceDate, clsHelpMethods.getDisplayPrice(dAmountSubTotal, CreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(dAmountNBT, CreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(dAmountVat, CreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(oDetail.AlocatedAmount, CreditNote.CurrencyRate));
                    }
                }
                #endregion
            }

            return glb_dtsSales;
        }

        private DataSet AdvancedPrint_CreditNote(tbl_bpsCreditNote oCreditNote)
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
                glb_dtsBills.dt_bpsCreditNote.Adddt_bpsCreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCreditNote.Customer_ID, clsGenaralName.getName_Customer(oCreditNote.Customer_ID),
                                                oCustomer.AddressRegister, oCustomer.Telephone, sBranchId, sSalesmanName, sDeliveryAddress, sDeliveryTel, oCreditNote.IsDeleted,
                                                sInvoiceID, dInvoiceDate,
                                                sDOID, sCOID,
                                                oCreditNote.SalesReturnedNote_ID != "default" ? oCreditNote.SalesReturnedNote_ID : "-",
                                                sPoNO,
                                                clsHelpMethods.getDisplayPrice(oCreditNote.SubTotal, oCreditNote.CurrencyRate),
                                                oCreditNote.DiscountPercentage, clsHelpMethods.getDisplayPrice(oCreditNote.DiscountTotal, oCreditNote.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCreditNote.SubTotal, oCreditNote.CurrencyRate),
                                                oCreditNote.NbtPercentage, clsHelpMethods.getDisplayPrice(oCreditNote.NbtTotal, oCreditNote.CurrencyRate),
                                                oCreditNote.VatPercentage, clsHelpMethods.getDisplayPrice(oCreditNote.VatTotal, oCreditNote.CurrencyRate),
                                                oCreditNote.OtherTaxPercentage, clsHelpMethods.getDisplayPrice(oCreditNote.OtherTaxTotal, oCreditNote.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCreditNote.TotalAmount, oCreditNote.CurrencyRate),
                                                oCreditNote.OrderRefNo_ID,
                                                oCustomer.SvatRegistrationNo, oCustomer.VatRegistrationNo, oCustomer.NbtRegistrationNo, sTaxType,
                                                 //clsCommon.CurrencyToWord(oCreditNote.TotalAmount),
                                                 clsCommon.CurrencyToWord(decimal.Parse(txtGrandTotal.Text)),
                                                oCreditNote.Remark,
                                                oCreditNote.Currency_ID, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID));
                #endregion

                #region Fill Details
                decimal dInvoiceSubTotal = clsHelpMethods.getDisplayPrice(oCreditNote.SubTotal, oCreditNote.CurrencyRate);
                foreach (tbl_sasSalesReturnedNote_Detail oSRN_Detail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oCreditNote.SalesReturnedNote_ID))
                {
                    decimal dUnitPrice = 0;

                    tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(oSRN_Detail.Item_ID);
                    tbl_zUom oUom = tbl_zUom.Select(oItmaster.Uom_ID);
                    if (oUom != null && oItmaster != null)
                    {
                        decimal dAmount = clsHelpMethods.getDisplayPrice(oSRN_Detail.TatalAmount, oCreditNote.CurrencyRate);
                        decimal dLineDiscount = oSRN_Detail.DiscountAmount;
                        dUnitPrice = oSRN_Detail.UnitPrice;

                        if (!oSRN_Detail.BIsFreeItem)
                        {
                            decimal dRatio = (dInvoiceSubTotal != 0) ? (dAmount / dInvoiceSubTotal) : 0;
                            dAmount = dInvoiceSubTotal * dRatio;
                            dLineDiscount = (dAmount * oSRN_Detail.DiscountPresentage) / (100 - oSRN_Detail.DiscountPresentage);
                            dUnitPrice = (dAmount + dLineDiscount) / oSRN_Detail.Qty;
                        }
                        glb_dtsBills.dt_dpsCreditNote_Detail.Adddt_dpsCreditNote_DetailRow(oCreditNote.CreditNote_ID, oSRN_Detail.Item_ID, "",
                            dUnitPrice, oSRN_Detail.Qty, dAmount, oSRN_Detail.Remark, oUom.UomCode, oSRN_Detail.DiscountPresentage, dLineDiscount, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID));
                    }
                }
                #endregion

                #endregion
            }

            return glb_dtsBills;
        }
        #endregion

        #region Settle Delivery Order
        private void SetDeliveryOrderSettle(string sDeliveryOrderID)
        {
            bool bIsSettle = false, bLocked = false;
            if (clsConfig.bAutoSettleHideDeliveryOrder)
            {
                List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID);
                foreach (tbl_sasDeliveryOrder_Detail detail in details)
                {
                    bIsSettle = true;
                    if (chkUnitPricing.Checked)
                    {
                        if (detail.QtySettle < detail.Qty)
                        {
                            bIsSettle = false;
                            break;
                        }
                        if (detail.QtySettle > 0)
                            bLocked = true;
                    }
                    else
                    {
                        if (detail.WeightSettle < detail.Weight)
                        {
                            bIsSettle = false;
                            break;
                        }
                        if (detail.WeightSettle > 0)
                            bLocked = true;
                    }
                }

                tbl_sasDeliveryOrder DeliveryOrder = tbl_sasDeliveryOrder.Select(sDeliveryOrderID);
                if (DeliveryOrder != null)
                {
                    DeliveryOrder.IsSeattled = bIsSettle;
                    DeliveryOrder.IsLocked = bLocked;
                    DeliveryOrder.Update();
                }
            }
        }
        #endregion

        #region Calculate Taxes and GrandTotal
        private void CalcualteSubTotal(decimal dAmount)
        {
            try
            {
                txtSubTotal.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dAmount);
                txtSubTotal.Tag = dAmount;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Set Disable Control
        private void SetDisableControl(bool bEnable)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDeliveryOrderID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesReturnNoteID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtChequeNo, bEnable);

            clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesReturnNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblChequeNo, bEnable);
        }
        #endregion

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.TextLength > 0 && clsCommon.isCurrency(txtDiscount.Text.Trim()) && decimal.Parse(txtDiscount.Text.Trim()) > 0)
            {
                txtDiscount.Tag = txtDiscount.Text.Trim();
                txtPercentageDiscount.Text = "0";
            }
            else
                txtDiscount.Tag = "0";

            CalculateTaxesAndGrandTotal();
        }

        private void txtSubTotal_Leave(object sender, EventArgs e)
        {
            CalcualteSubTotal(decimal.Parse(txtSubTotal.Text));
            CalculateTaxesAndGrandTotal();
        }


        #region Btn Invoice Add
        private void AddNewInvoice()
        {
            if (CheckInvoiceValidity())
            {
                txtCreditNoteType.Enabled = true;
                if (txtCreditNoteType.Tag != null && txtCreditNoteType.Tag.ToString().Length > 0)
                    txtCreditNoteType.Enabled = false;
                else
                {
                    txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment);
                    txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment));
                }

                tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                if (detail != null && detail.Invoice_ID != "default")
                {
                    #region Validate Currency
                    bool bCurrencyTypeOk = true;
                    if (txtCurrencyID.Tag == null)
                    {
                        txtCurrencyID.Tag = detail.Currency_ID;
                        txtCurrencyID.Text = clsGenaralName.getName_Currency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        txtCurrencyCode.Text = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                    }
                    else
                    {
                        if (txtCurrencyID.Tag.ToString().Trim() != detail.Currency_ID || decimal.Parse(txtCurrencyRate.Text.Trim()) != decimal.Parse(detail.CurrencyRate.ToString()))
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

                        CalculateInvoiceTotal();

                        txtCustomerID.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                        txtCustomerID.Tag = detail.Customer_ID;

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                        if (oNoteType != null)
                        {
                            chkVat.Enabled = oNoteType.IsPostingEnable_VAT ? true : false;
                            chkNBT.Enabled = oNoteType.IsPostingEnable_NBT ? true : false;

                            chkVat.Checked = oNoteType.IsPostingEnable_VAT ? true : false;
                            chkNBT.Checked = oNoteType.IsPostingEnable_NBT ? true : false;
                        }

                        //add order ref detail
                        //     FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

                        //add currency detail
                        //  FillDetailsCurrency(detail.Currency_ID);

                        //FillTaxDetailByInvoice_ID(detail.Invoice_ID);

                        //disable controls
                        //   SetDisableControl(false);

                        CalcualteSubTotal(clsHelpMethods.getDisplayPrice((detail.GrandTotal - detail.SeattleAmount), detail.CurrencyRate));
                        CalculateTaxesAndGrandTotal();


                        //ClearFieldContact();

                        ////set the orderdetail/salesrep                        
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            glbOrderRefNo = detail.OrderRefNo_ID;
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        if (dgvInvoice.Rows.Count > 4)
                        {
                            dgvInvoice.Columns["InvoiceAmount"].Width = 92;
                            dgvInvoice.Columns["AllocatedAmount"].Width = 92;
                        }
                    }
                }
            }
            // }
        }
        #endregion

        #region Btn invoice Remove
        private void button2_Click(object sender, EventArgs e)
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
        #endregion

        #region Btn Invoice Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvInvoice.Rows.Clear();
            txtInvoiceID.Text = null;
            txtBalanceAmount.Text = null;
            txtTotalAllocated.Text = null;
        }
        #endregion

        #region Check Invoice Validity
        private bool CheckInvoiceValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    if (clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "").ToString() == txtInvoiceID.Text.Trim())
                    {
                        strMessage += "\n" + "You have already entered this invoice  " + txtInvoiceID.Text.Trim();
                        bStatus = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return bStatus;
        }
        #endregion

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

        private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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

        private bool ValidateSettlement_CreditNote(String CreditNote_ID)
        {
            bool bIsSettlementOk = true;

            foreach (tbl_bpsCreditNote_Invoice oInvDetail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(CreditNote_ID))
            {
                if (oInvDetail.AlocatedAmount != 0)
                {
                    bIsSettlementOk = false;
                    MessageBox.Show("One or more invoices already allocated to this Credit note...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }

            return bIsSettlementOk;
        }

        #region User Checked Approve Details

        private void frm_bpsCreditNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_bpsCreditNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
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

        private void frm_bpsCreditNote_SF_History_Click(object sender, EventArgs e)
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


        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.ForestGreen;
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        //this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.ForestGreen;
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnChecked.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnApproved.BackColor = System.Drawing.Color.LightGray;
        //        this.btnChecked.BackColor = System.Drawing.Color.LightGray;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion
        #endregion

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (panel3.Visible == true)
                panel3.Visible = false;
            else
            {
                panel3.Visible = true;
                panel3.Focus();
            }
        }
        private void panel3_Leave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        #endregion

    }
}

#region Fill OrderRefNo
//private void FillOrderRefNo(string sOrderRefID, string sCustomerID, decimal dAmount)
//{
//    glbOrderRefNo = sOrderRefID;
//    tbl_genCustomerMaster cus = tbl_genCustomerMaster.Select(sCustomerID);
//    if (cus != null)
//    {
//        txtCustomerID.Tag = cus.Customer_ID;
//        txtCustomerID.Text = cus.CustomerName;
//    }

//    tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(sOrderRefID);
//    if (detail != null && detail.OrderRefNo_ID != "default")
//    {
//        txtOrderRefNo.Text = detail.OrderRefNo;
//        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
//    }

//    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
//}
#endregion

#region Events Mouseclick
//private void txtFlowInquiry_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Inquiry(sender, e, glbOrderRefNo);
//}

//private void txtFlowSalesReturned_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_SalesReturned(sender, e, glbOrderRefNo);
//}
//private void txtFlowCustomerOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_CustomerOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowDeliveryOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_DeliveryOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowInvoice_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Invoice(sender, e, glbOrderRefNo);
//}

//private void txtFlowReceipt_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Receipt(sender, e, glbOrderRefNo);
//}
#endregion