using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Threading;

using Zion.ERP.Reports.DataSets;
using ZION.ERP.Reports.DataSets;

namespace Digiteq
{
    public partial class frm_bpsDebitNote : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //public int iFormID;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbDeliveryOrderID = "", glbInvoiceID = "", glbReceiptID = "", glbDebiNoteID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        public bool gbl_bIsRefundableNote = false;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Sales glb_dtsSales = new dts_Sales();

        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_bpsDebitNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.bssDebitNote);
            //iFormID = clsSecurity.getFormID(FormName.bssDebitNote);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        //public frm_bpsDebitNote(FormName enmForm)
        //{
        //    sFormConfigCode = clsAutocode.getFormConfigCode(FormName.bssCustomerRefundableNote);

        //    iFormID = clsSecurity.getFormID(enmForm);
        //    if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
        //        bNoAccess = true;

        //    InitializeComponent();
        //}
        //public frm_bpsDebitNote(bool bIsRefundableNote)
        //{
        //gbl_bIsRefundableNote = bIsRefundableNote;

        //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.bssCustomerRefundableNote);
        //iFormID = clsSecurity.getFormID(FormName.bssCustomerRefundableNote);
        //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
        //    bNoAccess = true;

        //InitializeComponent();
        //}
        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            //string sFormName = "Debit Note";
            //format Form
            if (iFormID == (int)FormName.bssCustomerRefundableNote)
            {
                //sFormName = "Customer Refundable Note ";
                lblDebitNoteID.Text = "Refundable Note No.";
                lblCreditNoteDate.Text = "Refundable Note Date";
                lblCreditNoteType.Text = "Refundable Note Type";

                xCustomerRefundable.Visible = true;
                gbl_bIsRefundableNote = true;
            }

            //clsFormatter.setFormatForm(this, sFormName, 2, iFormID);
            xCustomerRefundable.Location = xpanel1.Location;
            ClearFields();

            if (glbDebiNoteID != null && glbDebiNoteID.Length > 0)
                FillDetails(glbDebiNoteID);

            if (glbReceiptID.Length > 0)
            {
                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(glbReceiptID);
                if (detail != null)
                {
                    txtReceiptNoteID.Tag = detail.Receipt_ID;
                    txtReceiptNoteID.Text = detail.Receipt_ID;
                    btnAddReceipt_Click(sender, new EventArgs());
                }
            }
        }

        #endregion

        #region Btn New
        private void frm_bpsDebitNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_bpsDebitNote_SF_cancelButton_Click(object sender, EventArgs e)
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
                                        // if (clsValidate.CheckPostingValidity(oDBN.PostingStatus_ID))
                                        //  {
                                        //if (CheckValidity_Allocation())
                                        //{
                                        //delete one record
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

                                            #region Remove Allocation
                                            clsHelpMethods_Local.RemoveSattlementsFrom_ReceiptID(txtReceiptNoteID.Text.Trim());
                                            #endregion
                                        
                                            email.createEmail_DebitNote(txtDebitNoteID.Text.Trim(), enum_Alerts.DebitNoteCancel);
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                        }
                                        //}
                                        //  }
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
        private void frm_bpsDebitNote_SF_saveButton_Click(object sender, EventArgs e)
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
                    string sSalesNoteType_ID = gbl_bIsRefundableNote ? txtSalesNoteType2.Tag.ToString().Trim() : txtSalesNoteType.Tag.ToString().Trim();

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

                                        clsLog.Process_Modify(iFormID,
                                            clsAutocode.GetProcessNoteID(ProcessNote.bssDebitNote),
                                            oldRecord.DebitNote_ID, "Debit Note");

                                        #region Update DebitNote Header

                                        bool bIsLocked = oldRecord.IsLocked;
                                        if (chkReverseCalculation.Checked)
                                            bIsLocked = true;

                                        tbl_bpsDebitNote detail = new tbl_bpsDebitNote(txtDebitNoteID.Text.Trim(),
                                            dtpDabitNoteDate.Value, txtRemark.Text.Trim(),
                                            txtSalesReturnNoteID.Tag.ToString(),
                                            txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(),
                                            txtDeliveryOrderID.Tag.ToString(), glbOrderRefNo,
                                            txtChequeNo.Tag.ToString(), txtDebitNoteType.Tag.ToString(),
                                            oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                            oldRecord.FinancialYear_ID, oldRecord.CompanyID, oldRecord.CompanyBranch_ID,
                                            txtCurrencyID.Tag.ToString(), sSalesNoteType_ID,
                                            decimal.Parse(txtCurrencyRate.Text.Trim()),
                                            decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                            decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            decimal.Parse(txtPercentageVat.Text.Trim()),
                                            decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                            glbApprovedDate, oldRecord.IsChecked, oldRecord.IsApproved,
                                            oldRecord.IsFinished,
                                            oldRecord.IsDeleted, oldRecord.IsLocked, !chkUnitPricing.Checked,
                                            oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.PrintCount,
                                            txtCreditNoteID.Tag.ToString(), txtReceiptNoteID.Tag.ToString(),
                                            gbl_bIsRefundableNote, "default");
                                        detail.Update();

                                        #endregion

                                        #region Update Invoice Header

                                        bool bIsLocked1 = oldRecord.IsLocked;
                                        if (chkReverseCalculation.Checked)
                                            bIsLocked1 = true;

                                        tbl_sasInvoice Invdetail = new tbl_sasInvoice(txtDebitNoteID.Text.Trim(),
                                            "default", dtpDabitNoteDate.Value, txtRemark.Text.Trim(),
                                            "", "default", txtCustomerID.Tag.ToString(), "default", "default",
                                            txtDeliveryOrderID.Tag.ToString(), "default",
                                            txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default",
                                            txtCurrencyID.Tag.ToString(), "default",
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            txtDebitNoteType.Tag.ToString(), "default",
                                            decimal.Parse(txtCurrencyRate.Text.Trim()),
                                            decimal.Parse(txtPercentageDiscount.Text.Trim()), 0, 0, 0,
                                            decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            decimal.Parse(txtPercentageVat.Text.Trim()),
                                            decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()),
                                                txtCurrencyRate), 0, 0, 0,
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate),
                                            clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                            glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(),
                                            clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                            false, "", "", "", clsSecurity.getServerDateTime(), bIsLocked, 0, false,
                                            false, 0, true,
                                            false, false, false, false, !chkUnitPricing.Checked,
                                            chkReverseCalculation.Checked, clsHelpMethods.isTaxActiveNote(txtVat),
                                            clsHelpMethods.isTaxActiveNote(txtOtherTax), "default", "", "default",
                                            false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, -1);
                                        Invdetail.Update();

                                        #endregion

                                        clsMethods_GL.PostTransaction_CustomerDBN(txtDebitNoteID.Text);

                                        #region Remove Allocation

                                        clsHelpMethods_Local.RemoveSattlementsFrom_ReceiptID(
                                            txtReceiptNoteID.Text.Trim());

                                        #endregion

                                        #region Allocation

                                        if (txtReceiptNoteID.Tag != null)
                                            setPaymentAllocation(txtReceiptNoteID.Text, txtDebitNoteID.Text,
                                                decimal.Parse(txtGrandTotal.Text));
                                        //setAllocation(txtReceiptNoteID.Text, txtDebitNoteID.Text, decimal.Parse(txtGrandTotal.Text));

                                        #endregion

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
                            if (chkReverseCalculation.Checked)
                                bIsLocked = true;

                            #region DebitNote
                            tbl_bpsDebitNote detail = new tbl_bpsDebitNote(txtDebitNoteID.Text.Trim(), dtpDabitNoteDate.Value, txtRemark.Text.Trim(), txtSalesReturnNoteID.Tag.ToString(),
                                txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), txtDeliveryOrderID.Tag.ToString(), glbOrderRefNo, txtChequeNo.Tag.ToString(), txtDebitNoteType.Tag.ToString(),
                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID, txtCurrencyID.Tag.ToString(), sSalesNoteType_ID, decimal.Parse(txtCurrencyRate.Text.Trim()),
                                decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate),
                                clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, !chkUnitPricing.Checked, 0, false, 0, txtCreditNoteID.Tag.ToString(), txtReceiptNoteID.Tag.ToString(), gbl_bIsRefundableNote, "default");
                            detail.Insert();
                            #endregion

                            #region Invoice
                            tbl_sasInvoice INVdetail = new tbl_sasInvoice(txtDebitNoteID.Text.Trim(), "default", dtpDabitNoteDate.Value, txtRemark.Text.Trim(),
                                   "", "default", txtCustomerID.Tag.ToString(), "default", "default",
                                   txtDeliveryOrderID.Tag.ToString(), "default", txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default",
                                    txtCurrencyID.Tag.ToString(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), txtDebitNoteType.Tag.ToString(), sSalesNoteType_ID,
                                    decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), 0, 0, 0, decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()),
                                    decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate), 0, 0, 0, clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()), txtCurrencyRate),
                                   clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                   "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                   false, "", "", "", clsSecurity.getServerDateTime(), bIsLocked, 0, false, false, 0, true,
                                   false, false, false, false, !chkUnitPricing.Checked, chkReverseCalculation.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), "default", "", "default", false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1);
                            INVdetail.Insert();
                            #endregion

                            Attachments.Insert(txtDebitNoteID.Text);
                            clsMethods_GL.PostTransaction_CustomerDBN(txtDebitNoteID.Text);
                            email.createEmail_DebitNote(txtDebitNoteID.Text.Trim(), enum_Alerts.DebitNoteCreate);

                            #region Allocation
                            if (txtReceiptNoteID.Tag != null)
                                setPaymentAllocation(txtReceiptNoteID.Text, txtDebitNoteID.Text, decimal.Parse(txtGrandTotal.Text));
                            //setAllocation(txtReceiptNoteID.Text, txtDebitNoteID.Text, decimal.Parse(txtGrandTotal.Text));
                            #endregion

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
                        FillDetails(detail.DebitNote_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_bpsDebitNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_bpsDebitNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
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
                    //clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this);
                    this.Show();
                }
            }
        }
        #endregion

        #region Btn Add Receipt
        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNoteID.Tag != null && txtReceiptNoteID.Tag.ToString().Length > 0)
                {
                    if (!gbl_bIsRefundableNote)
                    {
                        txtDebitNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.AdvanceRefund);
                        txtDebitNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.AdvanceRefund));
                    }
                    else
                    {
                        txtDebitNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.Inter_Company_Transfer);
                        txtDebitNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.Inter_Company_Transfer));
                    }

                    tbl_bpsReceipt detail = tbl_bpsReceipt.Select(txtReceiptNoteID.Tag.ToString());
                    if (detail != null)
                    {

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();



                        txtSalesNoteType2.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        //disable controls
                        SetDisableControl(false);

                        decimal dTmpSubTotal = 0;
                        if (detail.CashAmount > 0)
                            dTmpSubTotal += detail.CashAmount - detail.SeattleAmount;
                        if (detail.ChequeAmount > 0)
                        {
                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID))
                            {
                                dTmpSubTotal += oCheque.Amount - oCheque.SetteledAmount;
                            }
                        }

                        CalcualteSubTotal(clsHelpMethods_Local.getDisplayPrice(dTmpSubTotal, detail.CurrencyRate));

                        //add order ref detail
                        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, dTmpSubTotal);

                        tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                        if (customer != null)
                        {
                            chkOtherTax.Checked = customer.IsSVATenable ? true : false;
                            chkVat.Checked = customer.IsVATenable ? true : false;
                            chkNBT.Checked = customer.IsNBTenable ? true : false;
                        }
                        //CalculateTaxesAndGrandTotal();
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

        #region Btn Add CreditNote
        private void btnAddCreditNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditNoteID.Tag != null && txtCreditNoteID.Tag.ToString().Length > 0)
                {
                    txtDebitNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.OverpaymentRefund);
                    txtDebitNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.OverpaymentRefund));

                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Tag.ToString());
                    if (detail != null)
                    {
                        //add order ref detail
                        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.TotalAmount);

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();

                        if (detail.Invoice_ID != "default")
                            FillTaxDetailByInvoice_ID(detail.Invoice_ID);
                        else
                        {
                            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate));
                            txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                            txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                            txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                            txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));


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
                        }


                        txtSalesNoteType2.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                        //disable controls
                        SetDisableControl(false);

                        CalcualteSubTotal(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
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

        #region Btn Add Invoice
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
                        //add order ref detail
                        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByInvoice_ID(detail.Invoice_ID);

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        //disable controls
                        SetDisableControl(false);

                        CalcualteSubTotal(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
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

        #region Btn Add DeliveryOrder
        private void btnAddDO_Click(object sender, EventArgs e)
        {
            //if (txtDeliveryOrderID.Tag != null && txtDeliveryOrderID.Tag.ToString().Trim().Length > 0)
            //{
            //    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Tag.ToString());
            //    if (detail != null)
            //    {
            //        //add order ref detail
            //        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

            //        //disable controls
            //        SetDisableControl(false);

            //        //add item details
            //        RefreshGridByDeliveryOrderID(detail.DeliveryOrder_ID);

            //        txtCreditNoteType.Tag = clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment);
            //        txtCreditNoteType.Text = clsGenaralName.getName_CreditNoteType(clsAutocode.getCreditNoteTypeID(CreditNoteType.InvoiceAdjustment));
            //    }
            //}
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
                        //add order ref detail
                        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.GrandTotal);

                        //add currency detail
                        FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
                        //txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByInvoice_ID(detail.SalesReturnedNote_ID);

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

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

        #region Btn Add Cheque
        private void btnAddCheque_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtChequeNo.Tag != null && txtChequeNo.Tag.ToString().Trim().Length > 0)
                {
                    tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(txtChequeNo.Tag.ToString());
                    if (detail != null)
                    {
                        if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            //add order ref detail
                            FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, detail.Amount);

                            //disable controls
                            SetDisableControl(false);

                            txtDebitNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.ChequeReturns);
                            txtDebitNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.ChequeReturns));
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
        private void frm_bpsDebitNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;
                btnSave.Enabled = true;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType2, false);
                clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType2, false);
                SetDisableControl(true);

                txtDebitNoteID.Tag = null;
                dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                //Reset Primary Key
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

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType2, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType2, false);

            SetDisableControl(true);
            txtSalesNoteType.Visible = false;
            lblSalesNoteType.Visible = false;
            txtDebitNoteID.Tag = null;
            txtCustomerID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtDebitNoteType.Tag = null;
            txtSalesReturnNoteID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtChequeNo.Tag = null;

            txtSalesNoteType.Tag = null;
            txtSalesNoteType2.Tag = null;
            txtCreditNoteID.Tag = null;
            txtReceiptNoteID.Tag = null;

            txtRemark.Clear();
            txtCustomerID.Clear();
            txtSalesExecutiveID.Clear();
            txtDeliveryOrderID.Clear();
            txtOrderRefNo.Clear();
            txtDebitNoteType.Clear();
            txtSalesReturnNoteID.Clear();
            txtInvoiceID.Clear();
            txtChequeNo.Clear();
            txtSalesNoteType.Clear();
            txtSalesNoteType2.Clear();
            txtCreditNoteID.Clear();
            txtReceiptNoteID.Clear();

            dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkPrintOriginal.Checked = false;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

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

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDebitNoteID.Text = "<Auto Generate>";
            else
                txtDebitNoteID.Clear();
            if (txtDebitNoteID.Enabled)
            {
                txtDebitNoteID.SelectAll();
                txtDebitNoteID.Focus();
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
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType2, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType2, false);
                        SetDisableControl(false);

                        //asign values
                        txtDeliveryOrderID.Tag = detail.DeliveryOrder_ID;
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        txtDebitNoteType.Tag = detail.DebitNoteType_ID;
                        txtSalesReturnNoteID.Tag = detail.SalesReturnedNote_ID;
                        txtInvoiceID.Tag = detail.Invoice_ID;
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtChequeNo.Tag = detail.ChequeRegister_ID;
                        txtDebitNoteID.Tag = detail.DebitNote_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType2.Tag = detail.SalesNoteType_ID;
                        txtCreditNoteID.Tag = detail.CreditNoteID;

                        txtDeliveryOrderID.Text = clsCommon.GetForeignKeyValue(detail.DeliveryOrder_ID);
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtDebitNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_DebitNoteType(detail.DebitNoteType_ID));
                        txtSalesReturnNoteID.Text = clsCommon.GetForeignKeyValue(detail.SalesReturnedNote_ID);
                        txtInvoiceID.Text = clsCommon.GetForeignKeyValue(detail.Invoice_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtChequeNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeNo(detail.ChequeRegister_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                        txtSalesNoteType2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                        txtReceiptNoteID.Text = clsCommon.GetForeignKeyValue(detail.ReceiptNoteID);
                        txtCreditNoteID.Text = detail.CreditNoteID;

                        //fill order detials
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
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate));

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;


                        // CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();
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

        #region Fill OrderRefNo
        private void FillOrderRefNo(string sOrderRefID, string sCustomerID, decimal dAmount)
        {
            try
            {
                glbOrderRefNo = sOrderRefID;
                tbl_genCustomerMaster cus = tbl_genCustomerMaster.Select(sCustomerID);
                if (cus != null)
                {
                    txtCustomerID.Tag = cus.Customer_ID;
                    txtCustomerID.Text = cus.CustomerName;
                }

                tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(sOrderRefID);
                if (detail != null && detail.OrderRefNo_ID != "default")
                {
                    txtOrderRefNo.Text = detail.OrderRefNo;
                    txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                }

                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);

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

        #region Fill Tax Detail By DeliveryOrderID
        private void FillTaxDetailByDeliveryOrderID(string DeliveryOrderID)
        {
            try
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
                {
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));


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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By CredeitNote_ID
        private void FillTaxDetailByCredeitNote_ID(string CRN_ID)
        {
            try
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(CRN_ID);

                if (detail != null)
                {
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));


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
                if (CheckValidity_Number())
                {
                    //if (CheckValidity_Outstanding())
                    //{
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            if (CheckValidity_Posting())
                                bStatus = true;
                        }
                    }
                    //}
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
                bool bSlotStatus_Credit = clsMethods_GL.CheckAccountLink(AccSlot.Customer_DebitNote, true);

                if (bSlotStatus_Customer && bSlotStatus_Credit)
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
                if (clsValidate.ValidateTextBox_EmptyValue(txtDebitNoteType, "Debit Note Type"))
                {
                    if (gbl_bIsRefundableNote)
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType2, "Sales Note Type 2"))
                            bStatus = true;
                    }
                    else
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Sales Note Type"))
                            bStatus = true;
                    }
                }
            }
            if (txtSalesExecutiveID.Tag == null)
                txtSalesExecutiveID.Tag = "default";


            return bStatus;
        }
        private bool CheckValidity_Allocation()
        {
            bool isSettled = true;
            foreach (tbl_sasInvoice_Sattled pInv in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(txtDebitNoteID.Text.Trim()))
            {
                isSettled = false;
                MessageBox.Show("Cannot delete. This document is settled !");
                break;
            }
            return isSettled;
        }
        private bool CheckValidity_Number()
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
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                            if (clsConfig.bCreditBalanceInvoice_Message) //security 1 - Message
                            {
                                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                                {
                                    dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
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
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bOk;
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
                clsCommon.ValidateForeignKey(ref txtDeliveryOrderID);
                clsCommon.ValidateForeignKey(ref txtSalesReturnNoteID);
                clsCommon.ValidateForeignKey(ref txtCreditNoteID);
                clsCommon.ValidateForeignKey(ref txtReceiptNoteID);
                clsCommon.ValidateForeignKey(ref txtChequeNo);
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

        #region Events KeyDown
        private void txtSalesNoteType2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }

        private void txtCreditNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CreditNote(sender);
        }

        private void txtReceiptNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Receipt(sender);
        }
        private void txtDebitNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DebitNoteType();
        }
        private void txtDebitNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DebitNote();
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
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CheckedBy();
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ApprovedBy();
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
        private void txtDebitNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_DebitNoteType();
        }

        private void txtCreditNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_CreditNote(sender);
        }

        private void txtReceiptNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_Receipt(sender);
        }

        private void txtSalesNoteType2_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtDebitNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_DebitNote();
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
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
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
            if (chkNBT.Checked)
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
                {
                    btnAddInvoice_Click(sender, new EventArgs());
                }
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
                {
                    btnAddSRN_Click(sender, new EventArgs());
                }
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
        private void Search_Cheque(object sender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionChequeByCustomerID_Use(ref txtChequeNo, txtCustomerID.Tag.ToString(), false, "", true);
                else
                    clsSearch.Search_TransactionCheque_Use(ref txtChequeNo, false, "", true);

                btnAddCheque_Click(sender, new EventArgs());
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

                btnAddDO_Click(sender, new EventArgs());

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
        private void Search_Currency()
        {
            try
            {
                clsSearch.Search_MasterCurrency(ref txtCurrencyID);
                if (txtCurrencyID.Tag != null)
                    FillDetailsCurrency(txtCurrencyID.Tag.ToString());
                else
                    FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType2);
        }
        private void Search_CreditNote(object sender)
        {
            try
            {
                string sCustomerID = txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0 ? txtCustomerID.Tag.ToString() : "";

                clsSearch.Search_TransactionCreditNoteByCustomerID_Use(ref txtCreditNoteID, sCustomerID, false, "", false);

                if (txtCreditNoteID.Tag != null && txtCreditNoteID.Tag.ToString().Length > 0)
                {
                    btnAddCreditNote_Click(sender, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Receipt(object sender)
        {
            try
            {
                string sCustomerID = txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0 ? txtCustomerID.Tag.ToString() : "";

                clsSearch.Search_Receipt(ref txtReceiptNoteID, true);

                if (txtReceiptNoteID.Tag != null && txtReceiptNoteID.Tag.ToString().Length > 0)
                {
                    btnAddReceipt_Click(sender, new EventArgs());
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
                if (txtDebitNoteID.Text.Trim().Length > 0 && txtDebitNoteID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
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
                            //if (CreditNote.PrintCount > 0) // if already printed before
                            //{
                            //    sDuplicateCopy = "Duplicate Copy";
                            //    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                            //    {
                            //        bOkToPrint = true;
                            //        if (chkPrintOriginal.Checked)
                            //            sDuplicateCopy = "";
                            //    }
                            //    else
                            //    {
                            //        frmSetApproved login = new frmSetApproved();
                            //        login.iFormID = iFormID;
                            //        login.ShowDialog();
                            //        if (frmSetApproved.bChecked)
                            //        {
                            //            bOkToPrint = true;
                            //        }
                            //    }
                            //}
                            //else
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
                                    glb_dtsSales.dt_sasTaxDetails_DebitNote.Adddt_sasTaxDetails_DebitNoteRow(oDebiNote.DebitNote_ID, oDebiNote.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebiNote.DebitNoteType_ID), oDebiNote.SalesReturnedNote_ID, oDebiNote.Invoice_ID, oDebiNote.Currency_ID, clsGenaralName.getName_Customer(oDebiNote.Customer_ID), clsGenaralName.getName_CustomerRegisterAddress(oDebiNote.Customer_ID), oDebiNote.DeliveryOrder_ID, oDebiNote.OrderRefNo_ID, oDebiNote.Remark, oDebiNote.SubTotal, oDebiNote.DiscountTotal, oDebiNote.NbtTotal, oDebiNote.VatTotal, oDebiNote.OtherTaxTotal, oDebiNote.TotalAmount, "");

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
                                    #region Views
                                    string s_Path = "", sReportTitle = gbl_bIsRefundableNote ? txtDebitNoteType.Text.Trim() : "DEBIT NOTE", sFormula = "";
                                    if (txtDebitNoteID.TextLength > 0)
                                        sFormula = "{vw_rpt_bpsDebitNote.debitNote_ID} = '" + txtDebitNoteID.Text.Trim() + "'";

                                    //Write Audit Trial Log
                                    clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.bssDebitNote), DeditNote.DebitNote_ID);
                                    ReportDocument RD = new ReportDocument();
                                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                                    if (sDbPath == "")
                                    {
                                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote_WD.rpt";
                                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote_Akt.rpt";
                                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote.rpt";
                                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote.rpt";
                                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote.rpt";
                                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote.rpt";
                                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote_ITC.rpt";
                                        else
                                            s_Path += "\\Reports\\BSS\\NotePrinting\\rpt_bpsDebitNote.rpt";
                                    }
                                    else
                                    {
                                        s_Path += sDbPath;
                                    }

                                    frm_ReportViewer viewer = new frm_ReportViewer();
                                    viewer.crystalReportViewer1.ShowExportButton = false;
                                    RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                                        //   clsSecurity.LogonServer(ref RD);
                                        RD.Refresh();

                                    //RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                                    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                    //RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                                    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);

                                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());

                                    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                                    RD.DataDefinition.FormulaFields["Cancel"].Text = DeditNote.IsDeleted ? "CANCELLED" : "";
                                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                                    //RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? "DRAFT" : "";
                                    RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? clsCommon.fncsetstring("DRAFT") : "";

                                    #region Company Details Fill
                                    if (bIsDraft)
                                    {
                                        if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                        {
                                            RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                                            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                                            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                                            RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
                                        }
                                    }
                                    #endregion

                                    viewer.crystalReportViewer1.ReportSource = RD;
                                    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                    viewer.crystalReportViewer1.Visible = true;
                                    viewer.crystalReportViewer1.DisplayToolbar = true;
                                    viewer.crystalReportViewer1.CloseView(false);
                                    viewer.WindowState = FormWindowState.Maximized;

                                    viewer.ShowDialog();

                                    //viewer.MdiParent = this.MdiParent;
                                    //viewer.Show();

                                    RD.Close();
                                    RD.Dispose();
                                    #endregion
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
            }
        }
        #endregion

        #region Receipt Settlement
        //private void setPaymentAllocation(string sReceiptID, bool bIsCheckByAllocation)
        //private void setAllocation(string sReceiptID, string sInvoiceID, decimal dAmount)
        //{
        //    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sReceiptID);
        //    if (oReceipt != null && oReceipt.Receipt_ID != "default")
        //    {
        //        //string sAllocationID = "";
        //        //if (bIsCheckByAllocation)
        //        string sAllocationID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment));

        //        //else
        //        //{
        //        //    if (frm_toolPaymentAllocate.sAllocateCode.Length == 0)
        //        //    {
        //        //        string sFormConfigCode1 = frm_toolPaymentAllocate.bAdvancePayment ? clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_AdvancePyament) : frm_toolPaymentAllocate.bPartPayment ? clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment) : frm_toolPaymentAllocate.bOverPayment ? clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_OverPayment) : clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment);
        //        //        sAllocationID = clsAutocode.getAutoGeneratedCode(sFormConfigCode1);
        //        //    }
        //        //    else
        //        //        sAllocationID = frm_toolPaymentAllocate.sAllocateCode;
        //        //}

        //        //#region Settle Invoices
        //        //foreach (DataGridViewRow row in dgvInvoice.Rows)
        //        //{
        //        //string sInvoiceID = "";
        //        //decimal dAmount = 0;
        //        bool bAllocationCompleted = false;

        //        //sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
        //        //dAmount = clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", row.Index, decimal.Parse("0.0"));

        //        #region Invoice Settlement - With Cash
        //        if (oReceipt.CashAmount > 0)
        //        {
        //            tbl_sasInvoice_Sattled oSettlement = tbl_sasInvoice_Sattled.Select(sInvoiceID, txtReceiptNoteID.Text.Trim(), "default", "default", "default", clsAutocode.getPaymentMethodCode(PaymentMethods.Cash), "default");
        //            if (oSettlement == null)
        //            {
        //                dAmount = dAmount > 0 ? dAmount * oReceipt.CurrencyRate : 0;
        //                dAmount -= clsHelpMethods_Local.AutoSettledInvoiceWithCash(sInvoiceID, txtReceiptNoteID.Text.Trim(), dAmount, sAllocationID, frm_toolPaymentAllocate.bAdvancePayment, frm_toolPaymentAllocate.bOverPayment);
        //                bAllocationCompleted = dAmount == 0 ? true : false;
        //            }
        //        }
        //        #endregion

        //        #region Invoice Settlement - With Cheque
        //        foreach (tbl_bpsChequeRegister objCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
        //        {
        //            tbl_sasInvoice_Sattled oSettlement = tbl_sasInvoice_Sattled.Select(sInvoiceID, txtReceiptNoteID.Text.Trim(), objCheque.ChequeRegister_ID, "default", "default", clsAutocode.getPaymentMethodCode(PaymentMethods.Cheque), "default");
        //            if (oSettlement == null)
        //            {
        //                dAmount = dAmount < 0 ? 0 : dAmount;
        //                dAmount -= clsHelpMethods_Local.AutoSettledInvoiceWithCheque(sInvoiceID, objCheque.ChequeRegister_ID, dAmount, sAllocationID, frm_toolPaymentAllocate.bAdvancePayment, frm_toolPaymentAllocate.bOverPayment);
        //                bAllocationCompleted = dAmount == 0 ? true : false;
        //            }
        //        }
        //        #endregion
        //        //}
        //        //#endregion
        //    }
        //}
        #endregion

        #region Calcualte Values
        private decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
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
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtChequeNo, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCreditNoteID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtReceiptNoteID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesReturnNoteID, bEnable);

            clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesReturnNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblChequeNo, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblCreditNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblReceiptNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType2, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesReturnNoteID, bEnable);
            btnAddDO.Enabled = bEnable;
        }
        #endregion

        #region Events Leave
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
            if (txtSubTotal.Text != "" && txtSubTotal.Text.Length > 0)
            {
                CalcualteSubTotal(decimal.Parse(txtSubTotal.Text));
                CalculateTaxesAndGrandTotal();
            }
        }
        #endregion

        #region Text Changed
        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Key Press
        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtSubTotal.Text, e);
        }
        #endregion

        #region Allocation With Receipt
        private void setPaymentAllocation(string sReceiptID, string sInvoiceID, decimal dAmount)
        {
            try
            {
                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sReceiptID);
                if (oReceipt != null && oReceipt.Receipt_ID != "default")
                {
                    string sAllocationID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment));
                    // DateTime dtmAllocationDate = oReceipt.ReceiptDate;
                    bool bAllocationCompleted = false;

                    #region Invoice Settlement - With Cash
                    //if (oReceipt.CashAmount > 0)
                    //{

                    //    tbl_sasInvoice_Sattled oSettlement = tbl_sasInvoice_Sattled.Select(sInvoiceID, sReceiptID, "default", "default", "default", clsAutocode.getPaymentMethodCode(PaymentMethods.Cash), "default");
                    //    if (oSettlement == null)
                    //    {
                    //        dAmount -= clsHelpMethods_Local.AutoSettledInvoiceWithCash(sInvoiceID, sReceiptID, dAmount,  sAllocationID, false, false);
                    //        bAllocationCompleted = dAmount == 0 ? true : false;
                    //    }
                    //}
                    #endregion

                    #region Invoice Settlement - With Cheque
                    foreach (tbl_bpsChequeRegister objCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                    {
                        tbl_sasInvoice_Sattled oSettlement = tbl_sasInvoice_Sattled.Select(sInvoiceID, sReceiptID, objCheque.ChequeRegister_ID, "default", "default", ((int)PaymentMethod.Cheque).ToString(), "default");
                        if (oSettlement == null)
                        {
                            dAmount = dAmount < 0 ? 0 : dAmount;
                            dAmount -= clsHelpMethods_Local.AutoSettledInvoiceWithCheque(sInvoiceID, objCheque.ChequeRegister_ID, dAmount, sAllocationID, frm_toolPaymentAllocate.bAdvancePayment, frm_toolPaymentAllocate.bOverPayment);
                            bAllocationCompleted = dAmount == 0 ? true : false;
                        }
                    }
                    #endregion

                    //MessageBox.Show("successfuly allocated.....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region User Checked Approve Details
        private void frm_bpsDebitNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        
        private void frm_bpsDebitNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_bpsDebitNote_SF_History_Click(object sender, EventArgs e)
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

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        //this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
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