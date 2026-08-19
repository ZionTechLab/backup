using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Threading;

using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_bpsIntercompanyTransactions : SEACC_Form
    {
        #region Variables
        //static bool IsUpdate = false;

        public string glbOrderRefNo = "", glbDeliveryOrderID = "", glbInvoiceID = "", glbReceiptID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //     DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //     DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        public bool gbl_bIsRefundableNote = false;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Sales glb_dtsSales = new dts_Sales();

        #endregion

        #region Form Load
        public frm_bpsIntercompanyTransactions(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, false);
            ClearFields();

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
        private void frm_bpsIntercompanyTransactions_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_bpsIntercompanyTransactions_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRefundableNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpRefundableNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_bpsDebitNote oDBN = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
                            tbl_sasInvoice oINV = tbl_sasInvoice.Select(txtRefundableNoteID.Text.Trim());
                            if (oDBN != null)
                            {
                                if (!oDBN.IsLocked)
                                {
                                    if (!oDBN.IsDeleted)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Refundable Note : " + txtRefundableNoteID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            if (oINV != null && oINV.Invoice_ID != "default")
                                            {
                                                clsHelpMethods.RemoveSattlementsFrom_InvoiceID(oINV.Invoice_ID);
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

                                            clsAlerts_Email.createEmail_DebitNote(txtRefundableNoteID.Text.Trim(), enum_Alerts.DebitNoteCancel);
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
        private void frm_bpsIntercompanyTransactions_SF_saveButton_Click(object sender, EventArgs e)
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
                    //string sSalesNoteType_ID = gbl_bIsRefundableNote ? txtSalesNoteType2.Tag.ToString().Trim() : txtSalesNoteType.Tag.ToString().Trim();

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_bpsDebitNote oldRecord = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
                        if (oldRecord != null && CheckValidity_Printing(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                            {
                                if (!oldRecord.IsChecked ||
                                    (oldRecord.IsChecked &&
                                     clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtRefundableNoteID.Text))
                                    {

                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                        clsLog.Process_Modify(iFormID,
                                            clsAutocode.GetProcessNoteID(ProcessNote.bssDebitNote),
                                            oldRecord.DebitNote_ID, "Debit Note");
                                        clsHelpMethods.RemoveSattlementsFrom_InvoiceID(txtRefundableNoteID.Text
                                            .Trim());

                                        #region Update DebitNote Header

                                        bool bIsLocked = oldRecord.IsLocked;

                                        tbl_bpsDebitNote detail = new tbl_bpsDebitNote(txtRefundableNoteID.Text.Trim(),
                                            dtpRefundableNoteDate.Value, txtRemark.Text.Trim(), "default",
                                            oldRecord.Invoice_ID, txtCustomerID.Tag.ToString(), "default",
                                            glbOrderRefNo, "default", txtRefundableNoteType.Tag.ToString(),
                                            oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                            oldRecord.FinancialYear_ID, oldRecord.CompanyID, oldRecord.CompanyBranch_ID,
                                            txtCurrencyID.Tag.ToString(), txtSalesNoteType2.Tag.ToString().Trim(),
                                            decimal.Parse(txtCurrencyRate.Text.Trim()),
                                            decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                            decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            decimal.Parse(txtPercentageVat.Text.Trim()),
                                            decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                            glbApprovedDate, oldRecord.IsChecked, oldRecord.IsApproved,
                                            oldRecord.IsFinished,
                                            oldRecord.IsDeleted, oldRecord.IsLocked, false, oldRecord.SeattleAmount,
                                            oldRecord.IsSeattled, oldRecord.PrintCount, oldRecord.CreditNoteID,
                                            txtReceiptNoteID.Tag.ToString(), true, txtGlAcctNo.Tag.ToString());
                                        detail.Update();

                                        #endregion

                                        #region Update Invoice Header

                                        bool bIsLocked1 = oldRecord.IsLocked;

                                        tbl_sasInvoice Invdetail = new tbl_sasInvoice(txtRefundableNoteID.Text.Trim(),
                                            "default", dtpRefundableNoteDate.Value, txtRemark.Text.Trim(),
                                            "", "default", txtCustomerID.Tag.ToString(), "default", "default",
                                            "default", "default", txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo,
                                            "default",
                                            txtCurrencyID.Tag.ToString(), "default",
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                            clsSecurity.FinancialYearID, txtRefundableNoteType.Tag.ToString(),
                                            decimal.Parse(txtCurrencyRate.Text.Trim()),
                                            decimal.Parse(txtPercentageDiscount.Text.Trim()), 0, 0, 0,
                                            decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            decimal.Parse(txtPercentageVat.Text.Trim()),
                                            decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()),
                                                txtCurrencyRate), 0, 0, 0,
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate),
                                            clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()),
                                                txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                            oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                                            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                            glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(),
                                            clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                            false, "", "", "", clsSecurity.getServerDateTime(), bIsLocked, 0, false,
                                            false, 0, true,
                                            false, false, false, false, false, false,
                                            clsHelpMethods.isTaxActiveNote(txtVat),
                                            clsHelpMethods.isTaxActiveNote(txtOtherTax), "default", "", "default",
                                            false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, -1);
                                        Invdetail.Update();

                                        #endregion

                                        clsMethods_GL.PostTransaction_InterCompanyTransfer(txtRefundableNoteID.Text);

                                        #region Allocation

                                        if (txtReceiptNoteID.Tag != null)
                                            setPaymentAllocation(txtReceiptNoteID.Text, txtRefundableNoteID.Text,
                                                decimal.Parse(txtGrandTotal.Text));

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
                            txtRefundableNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtRefundableNoteID.Text)) //if (txtRefundableNoteID.TextLength > 0)
                        {
                            bool bIsLocked = false;

                            #region DebitNote
                            tbl_bpsDebitNote detail = new tbl_bpsDebitNote(txtRefundableNoteID.Text.Trim(), dtpRefundableNoteDate.Value, txtRemark.Text.Trim(), "default",
                                "default", txtCustomerID.Tag.ToString(), "default", glbOrderRefNo, "default", txtRefundableNoteType.Tag.ToString(),
                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID, txtCurrencyID.Tag.ToString(), txtSalesNoteType2.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()),
                                decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate),
                                clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, false, 0, false, 0, "default", txtReceiptNoteID.Tag.ToString(), true, txtGlAcctNo.Tag.ToString());
                            detail.Insert();
                            #endregion

                            #region Invoice
                            tbl_sasInvoice INVdetail = new tbl_sasInvoice(txtRefundableNoteID.Text.Trim(), "default", dtpRefundableNoteDate.Value, txtRemark.Text.Trim(),
                                   "", "default", txtCustomerID.Tag.ToString(), "default", "default",
                                  "default", "default", txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default",
                                    txtCurrencyID.Tag.ToString(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtSalesNoteType2.Tag.ToString(),
                                    decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), 0, 0, 0, decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()),
                                    decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate), 0, 0, 0, clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()), txtCurrencyRate),
                                   clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                   "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                   false, "", "", "", clsSecurity.getServerDateTime(), bIsLocked, 0, false, false, 0, true,
                                   false, false, false, false, false, false, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), "default", "", "default", false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1);
                            INVdetail.Insert();
                            #endregion

                            Attachments.Insert(txtRefundableNoteID.Text);

                            clsMethods_GL.PostTransaction_InterCompanyTransfer(txtRefundableNoteID.Text);
                            clsAlerts_Email.createEmail_DebitNote(txtRefundableNoteID.Text.Trim(), enum_Alerts.DebitNoteCreate);

                            #region Allocation
                            if (txtReceiptNoteID.Tag != null)
                                setPaymentAllocation(txtReceiptNoteID.Text, txtRefundableNoteID.Text, decimal.Parse(txtGrandTotal.Text));
                            #endregion

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Refundable Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
                    if (detail != null)
                        FillDetails(detail.DebitNote_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_bpsIntercompanyTransactions_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_bpsIntercompanyTransactions_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Checked
        private void frm_bpsIntercompanyTransactions_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        #endregion

        #region Btn Approved
        private void frm_bpsIntercompanyTransactions_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        #endregion

        #region Btn Histroy
        private void frm_bpsIntercompanyTransactions_SF_History_Click(object sender, EventArgs e)
        {
            User_Details();
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

        #region Btn Add Receipt
        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNoteID.Tag != null && txtReceiptNoteID.Tag.ToString().Length > 0)
                {
                    txtRefundableNoteType.Tag = clsAutocode.getDebitNoteTypeID(DebitNoteType.Inter_Company_Transfer);
                    txtRefundableNoteType.Text = clsGenaralName.getName_DebitNoteType(clsAutocode.getDebitNoteTypeID(DebitNoteType.Inter_Company_Transfer));

                    tbl_bpsReceipt detail = tbl_bpsReceipt.Select(txtReceiptNoteID.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();

                        txtSalesNoteType2.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        SetDisableControl(false);

                        decimal dTmpSubTotal = 0;

                        foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID))
                        {
                            dTmpSubTotal += oCheque.Amount - oCheque.SetteledAmount;
                        }

                        CalcualteSubTotal(clsHelpMethods.getDisplayPrice(dTmpSubTotal, detail.CurrencyRate));

                        FillOrderRefNo(detail.OrderRefNo_ID, detail.Customer_ID, dTmpSubTotal);
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


        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtRefundableNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);


            SetDisableControl(true);

            txtRefundableNoteID.Tag = null;
            txtCustomerID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtRefundableNoteType.Tag = null;
            txtOrderRefNo.Tag = null;
            txtGlAcctNo.Tag = null;
            txtReceiptNoteID.Tag = null;


            txtRemark.Clear();
            txtCustomerID.Clear();
            txtSalesExecutiveID.Clear();
            txtGlAcctNo.Clear();
            txtOrderRefNo.Clear();
            txtRefundableNoteType.Clear();
            //  txtChequeNo.Clear();
            txtReceiptNoteID.Clear();

            dtpRefundableNoteDate.Value = clsSecurity.getServerDateTime();

            //   chkUnitPricing.Checked = true;
            //chkReverseCalculation.Checked = false;
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

            chkPrintOriginal.Checked = false;

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            //chkReverseCalculation.Enabled = true;
            chkSettings.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtRefundableNoteID.Text = "<Auto Generate>";
            else
                txtRefundableNoteID.Clear();

            if (txtRefundableNoteID.Enabled)
            {
                txtRefundableNoteID.SelectAll();
                txtRefundableNoteID.Focus();
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

                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtRefundableNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType2, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType2, false);
                        SetDisableControl(false);

                        //asign values
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        txtRefundableNoteType.Tag = detail.DebitNoteType_ID;
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtRefundableNoteID.Tag = detail.DebitNote_ID;
                        txtSalesNoteType2.Tag = detail.SalesNoteType_ID;
                        txtReceiptNoteID.Tag = detail.ReceiptNoteID;
                        txtGlAcctNo.Tag = detail.Gl_ID;

                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtRefundableNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_DebitNoteType(detail.DebitNoteType_ID));
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesNoteType2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                        txtReceiptNoteID.Text = clsCommon.GetForeignKeyValue(detail.ReceiptNoteID);
                        txtGlAcctNo.Text = clsGenaralName.getName_AccountName(detail.Gl_ID);
                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        dtpRefundableNoteDate.Value = detail.DebitNoteDate;
                        txtRefundableNoteID.Text = detail.DebitNote_ID;
                        txtRemark.Text = detail.Remark;
                        txtRemark.Text = detail.Remark;
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
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate));

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

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_Number())
                {
                    if (CheckSubTotal())
                    {
                        //if (CheckValidity_Outstanding())
                        //{
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpRefundableNoteDate.Value.Date))
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
            }
            return bStatus;
        }
        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
                bool bSlotStatus_Credit = clsMethods_GL.CheckAccountValidity(txtGlAcctNo.Tag.ToString(), true);

                if (bSlotStatus_Customer && bSlotStatus_Credit)
                    bStatus = true;
            }
            else
                bStatus = true;

            return bStatus;
        }
        private bool CheckSubTotal()
        {
            bool bStatus = false;
            try
            {
                decimal dAmount = 0;

                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(txtReceiptNoteID.Text.ToString()))
                {
                    dAmount += (oCheque.Amount - oCheque.SetteledAmount);
                }

                if (IsUpdate)
                {
                    foreach (tbl_sasInvoice_Sattled pInv in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(txtRefundableNoteID.Text.Trim()))
                    {
                        dAmount += pInv.SattledAmount;
                    }
                }

                if (decimal.Parse(txtSubTotal.Text) <= 0)
                    MessageBox.Show("Transfer amount cannot be zero");
                else if (dAmount < decimal.Parse(txtSubTotal.Text))
                    MessageBox.Show("Transfer amount cannot be greater than unsettled receipt amount");
                else
                    bStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtGlAcctNo, "GL Account No"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType2, "Sales Note Type"))
                        bStatus = true;
                }
            }
            if (txtSalesExecutiveID.Tag == null)
                txtSalesExecutiveID.Tag = "default";


            return bStatus;
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
                clsCommon.ValidateForeignKey(ref txtReceiptNoteID);
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
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
        private void txtGlAcctNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ControlAccount();
        }
        #endregion

        #region Events Double Click
        private void txtDebitNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_DebitNoteType();
        }


        private void txtReceiptNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_Receipt(sender);
        }

        private void txtDebitNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_DebitNote();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtGlAcctNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_ControlAccount();
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
                clsSearch.Search_TransactionRefundableNote_Direct(ref txtRefundableNoteID, chkShowSettle.Checked);
                if (txtRefundableNoteID.Tag != null && txtRefundableNoteID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtRefundableNoteID.Tag.ToString());
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
        private void Search_DebitNoteType()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_DebitNoteTypeID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtRefundableNoteType.Text = frmSearchMaster.s_SearchText;
                    txtRefundableNoteType.Tag = frmSearchMaster.s_SearchID;
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
        private void Search_ControlAccount()
        {
            try
            {
                clsSearch.Search_MasterAccountGLCode_Intercompany(ref txtGlAcctNo);
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
                if (txtRefundableNoteID.Text.Trim().Length > 0 && txtRefundableNoteID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "", sIsDelete = "";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true;
                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_DebitNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_bpsDebitNote oDeditNote = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
                        if (oDeditNote != null)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintDebitNote)
                                {
                                    if (!oDeditNote.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the DebitNote Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion

                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintDebitNote)
                                {
                                    if (!oDeditNote.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the DebitNote Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            if (bApprovalDone && bCheckingDone)
                            {
                                bOkToPrint = true;

                                sCreateUser = "[ " + clsGenaralName.getName_User(oDeditNote.CreateUser_ID) + " ] [ " + oDeditNote.DateCreate.ToShortDateString() + " ]";
                                if (oDeditNote.IsChecked && oDeditNote.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(oDeditNote.CheckedUser_ID) + " ] [ " + oDeditNote.DateChecked.ToShortDateString() + " ]";
                                if (oDeditNote.IsApproved && oDeditNote.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(oDeditNote.ApprovedUser_ID) + " ] [ " + oDeditNote.DateApproved.ToShortDateString() + " ]";

                                string sDbPath = "";
                                sDbPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DebitNote));

                                #region Print The Doc
                                if (bOkToPrint && bApprovalDone)
                                {
                                    #region For check Duplicate copy
                                    if (!bIsDraft)
                                    {
                                        //if (oDeditNote.PrintCount > 0)
                                        //    sDuplicateCopy = "Duplicate Copy " + oDeditNote.PrintCount;

                                        if (!chkPrintOriginal.Checked)
                                            sDuplicateCopy = (oDeditNote.PrintCount > 0) ? "Duplicate Copy " + oDeditNote.PrintCount : "";

                                        oDeditNote.PrintCount++;
                                        oDeditNote.Update();
                                    }

                                    #endregion

                                    #region Datasets
                                    tbl_bpsDebitNote oDebiNote = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
                                    glb_dtsSales.dt_sasTaxDetails_DebitNote.Adddt_sasTaxDetails_DebitNoteRow(oDebiNote.DebitNote_ID,
                                        oDebiNote.DebitNoteDate, clsGenaralName.getName_DebitNoteType(oDebiNote.DebitNoteType_ID), 
                                        oDebiNote.SalesReturnedNote_ID, oDebiNote.Invoice_ID, oDebiNote.Currency_ID, 
                                        clsGenaralName.getName_Customer(oDebiNote.Customer_ID),
                                        clsGenaralName.getName_CustomerRegisterAddress(oDebiNote.Customer_ID), 
                                        oDebiNote.DeliveryOrder_ID, oDebiNote.OrderRefNo_ID, oDebiNote.Remark, oDebiNote.SubTotal, 
                                        oDebiNote.DiscountTotal, oDebiNote.NbtTotal, oDebiNote.VatTotal, oDebiNote.OtherTaxTotal, 
                                        oDebiNote.TotalAmount, "","","");

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.getCompanyVAT(), true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true,false);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicateCopy, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsCanceled", oDeditNote.IsDeleted ? "CANCELLED" : "", true,false);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);

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

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", "", true,false);
                                        }
                                    }
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "REFUNDABLE NOTE", "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sDbPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_DebitNote));
                                    #endregion
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
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, bEnable);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtReceiptNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblReceiptNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType2, bEnable);
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

                    bool bAllocationCompleted = false;

                    #region Invoice Settlement - With Cheque
                    foreach (tbl_bpsChequeRegister objCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                    {
                        tbl_sasInvoice_Sattled oSettlement = tbl_sasInvoice_Sattled.Select(sInvoiceID, sReceiptID, objCheque.ChequeRegister_ID, "default", "default", ((int)PaymentMethod.Cheque).ToString(), "default");
                        if (oSettlement == null)
                        {
                            dAmount = dAmount < 0 ? 0 : dAmount;
                            dAmount -= clsHelpMethods.AutoSettledInvoiceWithCheque(sInvoiceID, objCheque.ChequeRegister_ID, dAmount, sAllocationID, frm_toolPaymentAllocate.bAdvancePayment, frm_toolPaymentAllocate.bOverPayment);
                            bAllocationCompleted = dAmount == 0 ? true : false;
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
        }       
        #endregion

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpRefundableNoteDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtRefundableNoteID.Text != null && txtRefundableNoteID.TextLength > 0 && txtRefundableNoteID.Text != "<Auto Generate>")
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

                                        tbl_bpsDebitNote objDN = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpRefundableNoteDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtRefundableNoteID.Text != null && txtRefundableNoteID.TextLength > 0 && txtRefundableNoteID.Text != "<Auto Generate>")
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

                                        tbl_bpsDebitNote objDN = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
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

        #region User Details
        private void User_Details()
        {
            try
            {
                if (txtRefundableNoteID.Text != "" || txtRefundableNoteID.Text != "<Auto Generate>")
                {
                    tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(txtRefundableNoteID.Text.Trim());
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
        #endregion

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
        private void button1_Click(object sender, EventArgs e)
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