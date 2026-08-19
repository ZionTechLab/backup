using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using DataTire;
//using Zion.ERP.Reports.DataSets.ACC;
using Zion.ERP.Reports.DataSets;
using CrystalDecisions.CrystalReports.Engine;
using ZION.ERP.Reports.DataSets.ACC;

namespace Digiteq
{
    public partial class frm_accAccountpayableNote_NEW : SEACC_Form
    {
           
        public string glbAPNID = "";

        dts_Apn glb_dts_Apn = new dts_Apn();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        DataTable dt_GLP;
        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_accAccountpayableNote_NEW(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_accAccountpayableNote_NEW_Load(object sender, EventArgs e)
        {

            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();

            if (glbAPNID.Length > 0)
                FillDetails(glbAPNID);

            if (clsConfig.bHideGRNNo_APN)
            {
                lblGRNNo.Visible = false;
                txtGRNNo.Visible = false;

                lblPONo.Visible = false;
                txtPONo.Visible = false;
            }
        }
        #endregion

        #region Btn New
        private void frm_accAccountpayableNote_NEW_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_accAccountpayableNote_NEW_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAPNID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                    {
                        if (ValidateForDependancies())
                        {
                            if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                            {
                                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                                if (detail != null && !detail.IsDeleted)
                                {
                                    if (!detail.IsReturnCheque)
                                    {
                                        if (!detail.IsLocked)
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "  Account Payable Note : " + txtAPNID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                detail.IsDeleted = true;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();

                                                clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                                clsHelpMethods_Local.RemovePVSattlementsFrom_APNID(detail.AccountPayableNote_ID);

                                                #region unsettle PO
                                                tbl_scsPurchaseOrder oPo = tbl_scsPurchaseOrder.Select(detail.PurchaseOrder_ID);
                                                if (oPo != null && oPo.PurchaseOrder_ID != "default")
                                                {
                                                    oPo.SeattleAmount = oPo.SeattleAmount - detail.GrandTotal;
                                                    oPo.IsSeattled = false;
                                                    oPo.Update();
                                                }
                                                #endregion

                                                #region unsettle GRN
                                                tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(detail.ExternalGoodReceivedNote_ID);
                                                if (oGRN != null && oGRN.ExternalGoodReceivedNote_ID != "default")
                                                {
                                                    oGRN.SeattleAmount = oGRN.SeattleAmount - detail.GrandTotal;
                                                    oGRN.IsSeattled = false;
                                                    oGRN.Update();
                                                }
                                                #endregion

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();

                                      
                                                email.createEmail_APN(detail.AccountPayableNote_ID, enum_Alerts.AccountPayableNoteDeleted);
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }
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
        private void frm_accAccountpayableNote_NEW_SF_saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateSave())
                {
                    #region update records
                    if (IsUpdate)
                    {
                        tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtAPNID.Text))
                                {

                                    tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                    tbl_accAccountPayableNote_SubTotal.DeleteAllByAccountPayableNote_ID(txtAPNID.Text);

                                    #region Header

                                    tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(
                                        txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(),
                                        txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(),
                                        txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(),
                                        txtGRNNo.Tag.ToString().Trim(), txtPONo.Tag.ToString().Trim(),
                                        "default", uC_Supplier.Supplier_ID, "default", "default",
                                        txtNoteType.Tag.ToString(), "default", "default", oldRecord.GlPosting_ID,
                                        clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                        clsSecurity.FinancialYearID, uC_ExchangeRate1.CurrencyCode,
                                        uC_ExchangeRate1.ExchangeRate, decimal.Parse(txtCreditDays.Text.Trim()),
                                        uC_TotalCalc1.DiscountPresentage, uC_TotalCalc1.NbtPresentage,
                                        uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage,
                                        uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount, uC_TotalCalc1.NbtAmount,
                                        uC_TotalCalc1.VatAmount, uC_TotalCalc1.OtherTaxAmount, uC_TotalCalc1.GrandTotal,
                                        oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                        oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                        oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                        oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                        oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked,
                                        oldRecord.DateApproved, oldRecord.DateDeleted, oldRecord.DatePrinted,
                                        oldRecord.IsAdvancePayment, oldRecord.IsPartPayment, oldRecord.IsChecked,
                                        oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                        oldRecord.IsLocked, oldRecord.IsPettyCashReimbursment, oldRecord.IsSAPN, 0,
                                        oldRecord.IsSeattled, oldRecord.ChequeRegister_ID, oldRecord.IsReturnCheque,
                                        oldRecord.PrintCount, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    AccAPN.Update();

                                    #endregion

                                    #region  Insert Detail - APN Details

                                    int iRow;
                                    string sGLCode = "",
                                        sCategoryID = "",
                                        sRemarks = "",
                                        sSubAcct1_ID = "",
                                        sSubAcct2_ID = "";
                                    bool bIsCredit = false;
                                    decimal dAmount;

                                    foreach (DataGridViewRow row in uC_DoubleEntry1.dgvDetail.Rows)
                                    {
                                        iRow = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Line_No",
                                            row.Index, int.Parse("0"));
                                        sGLCode = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "accCode",
                                            row.Index, "");
                                        sCategoryID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                            "TxnCategory_ID", row.Index, "");
                                        sRemarks = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail, "Remarks",
                                            row.Index, "");
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

                                        #region Insert tbl_accAccountPayableNote_SubTotal

                                        tbl_accAccountPayableNote_SubTotal Insdetail =
                                            new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(),
                                                sCategoryID,
                                                sGLCode, "default", uC_Supplier.Supplier_ID, "default", "default",
                                                sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                        Insdetail.Insert();

                                        #endregion
                                    }

                                    #endregion

                                    if (txtGRNNo.Text.Trim() != "" && txtGRNNo.Text.Trim() != "default")
                                        clsProcessMethods.SetSettle_GRN_From_APN(txtGRNNo.Tag.ToString().Trim(),
                                            clsHelpMethods_Local.getDisplayPrice(
                                                uC_TotalCalc1.GrandTotal - oldRecord.GrandTotal,
                                                uC_ExchangeRate1.ExchangeRate));

                                    //Attachments.Insert(txtAPNID.Text.ToString());

                                    clsMethods_GL.PostTransaction_APN(txtAPNID.Text.Trim());
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone),
                                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    email.createEmail_APN(AccAPN.AccountPayableNote_ID,
                                        enum_Alerts.AccountPayableNoteCreated);
                                }
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    #endregion
                    #region insert records
                    else
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtAPNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtAPNID.Text)) //if (txtAPNID.Text.Trim().Length > 0)
                        {
                            #region Header
                            tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(), txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(), txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(), txtGRNNo.Tag.ToString().Trim(), txtPONo.Tag.ToString().Trim(),
                                                   "default", uC_Supplier.Supplier_ID, "default", "default", txtNoteType.Tag.ToString(), "default", "default", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, uC_ExchangeRate1.CurrencyCode,
                                                   uC_ExchangeRate1.ExchangeRate, decimal.Parse(txtCreditDays.Text.Trim()), uC_TotalCalc1.DiscountPresentage, uC_TotalCalc1.NbtPresentage, uC_TotalCalc1.VatPresentage, uC_TotalCalc1.OtherTaxPresentage,
                                                   uC_TotalCalc1.SubTotal, uC_TotalCalc1.DiscountAmount, uC_TotalCalc1.NbtAmount, uC_TotalCalc1.VatAmount, uC_TotalCalc1.OtherTaxAmount, uC_TotalCalc1.GrandTotal,
                                                   clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, false, bHasChecked, bHasApproved, false, false, false, false, true, 0, false, "default", false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                            AccAPN.Insert();
                            #endregion

                            #region  Insert Detail - APN Details
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

                                #region Insert tbl_accAccountPayableNote_SubTotal
                                tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(), sCategoryID,
                                    sGLCode, "default", uC_Supplier.Supplier_ID, "default", "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            if (txtGRNNo.Text.Trim() != "" && txtGRNNo.Text.Trim() != "default")
                                clsProcessMethods.SetSettle_GRN_From_APN(txtGRNNo.Tag.ToString().Trim(), clsHelpMethods_Local.getDisplayPrice(uC_TotalCalc1.GrandTotal, uC_ExchangeRate1.ExchangeRate));

                            Attachments.Insert(txtAPNID.Text.ToString());

                            clsMethods_GL.PostTransaction_APN(txtAPNID.Text.Trim());
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            email.createEmail_APN(AccAPN.AccountPayableNote_ID, enum_Alerts.AccountPayableNoteCreated);
                        }
                        //else
                        //    MessageBox.Show("APN No " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
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
                tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                if (oldRecord != null)
                    FillDetails(txtAPNID.Text.Trim());
            }
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_accAccountpayableNote_NEW_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_accAccountpayableNote_NEW_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_accAccountpayableNote_NEW_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Print/Draft
        private void frm_accAccountpayableNote_NEW_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void frm_accAccountpayableNote_NEW_SF_printButton_Click(object sender, EventArgs e)
        {


            Print(false);
        }
        #endregion

        #region Btn Temp
        private void frm_accAccountpayableNote_NEW_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblJobDate, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, true);

                txtAPNID.Tag = null;
                dtpAPNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtAPNID.Text = "<Auto Generate>";
                else
                    txtAPNID.Clear();
                if (txtAPNID.Enabled)
                {
                    txtAPNID.SelectAll();
                    txtAPNID.Focus();
                }
                uC_Supplier.UnlockFields();
                Attachments.Clear();
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, true);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpAPNDate, true);
            clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblApnDate, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtGRNNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPONo, true);

            txtAPNID.Tag = null;
            txtAPNType.Tag = null;
            txtBillNo.Tag = null;
            txtNoteType.Tag = null;
            txtAWB.Tag = null;
            txtLCNo.Tag = null;
            txtDeliveryOrderID.Tag = null;
            txtNarration.Tag = null;
            txtCreditDays.Tag = null;
            txtGRNNo.Tag = null;
            txtPONo.Tag = null;

            txtAPNType.Clear();
            txtNarration.Clear();
            txtBillNo.Clear();
            txtNoteType.Clear();
            txtAWB.Clear();
            txtLCNo.Clear();
            txtDeliveryOrderID.Clear();
            txtNarration.Clear();
            txtCreditDays.Clear();
            txtGRNNo.Clear();
            txtPONo.Clear();

            txtCreditDays.Enabled = true;
            chkShowSettle.Checked = false;

            chkPrintOriginal.Checked = false;

            bHasChecked = false;
            bHasApproved = false;
            userDetailsColorChanges();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtAPNID.Text = "<Auto Generate>";
            else
                txtAPNID.Clear();

            if (txtAPNID.Enabled)
            {
                txtAPNID.SelectAll();
                txtAPNID.Focus();
            }

            txtAPNType.Text = clsGenaralName.getName_APNType(clsConfig.sDefaultAPNTypeID);
            txtAPNType.Tag = clsConfig.sDefaultAPNTypeID;

            dtpAPNDate.Value = clsSecurity.getServerDateTime();
            dtpBillDate.Value = clsSecurity.getServerDateTime();

            txtGRNNo.Visible = true;
            lblGRNNo.Visible = true;
            txtPONo.Visible = true;
            lblPONo.Visible = true;

            uC_ExchangeRate1.ClearFields();

            uC_Supplier.ClearFields();
            uC_TotalCalc1.ClearFields();
            uC_DoubleEntry1.ClearFields();
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
                    tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;
                        uC_TotalCalc1.ClearFields();
                        uC_DoubleEntry1.ClearFields();

                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                            this.btnDraft.Enabled = false;
                        }
                        else
                            this.btnDraft.Enabled = true;

                        clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAPNType, false);

                        txtAPNID.Tag = detail.AccountPayableNote_ID;
                        txtAPNType.Tag = detail.ApnType_ID;
                        txtNoteType.Tag = detail.StockNoteType_ID;

                        txtAPNID.Text = detail.AccountPayableNote_ID;
                        dtpAPNDate.Value = detail.AccountPayableNoteDate;
                        txtBillNo.Text = detail.BillNo;
                        dtpBillDate.Value = detail.BillDate;
                        txtNarration.Text = detail.Narration;
                        txtAWB.Text = detail.NoAWB;
                        txtLCNo.Text = detail.NoLC;
                        txtDeliveryOrderID.Text = detail.NoDeliveryOrder;
                        txtCreditDays.Text = detail.CreditDays.ToString();
                        txtAPNType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_APNType(detail.ApnType_ID));
                        txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                        txtGRNNo.Text = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);
                        txtGRNNo.Tag = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);

                        txtPONo.Text = clsCommon.GetForeignKeyValue(detail.PurchaseOrder_ID);
                        txtPONo.Tag = detail.PurchaseOrder_ID;

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

                        if (detail.PurchaseOrder_ID != "default")
                        {
                            txtGRNNo.Visible = false;
                            lblGRNNo.Visible = false;
                        }
                        if (detail.ExternalGoodReceivedNote_ID != "default")
                        {
                            txtPONo.Visible = false;
                            lblPONo.Visible = false;
                        }

                        userDetailsColorChanges();
                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        uC_Supplier.SetSupplier(detail.Supplier_ID, IsUpdate);
                        uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.Supplier_ID, "default", detail.CurrencyRate);

                        foreach (tbl_accAccountPayableNote_SubTotal oAPNDetail in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(detail.AccountPayableNote_ID))
                        {
                            uC_TotalCalc1.SetGL(oAPNDetail.Line_No, int.Parse(oAPNDetail.Tc_ID), oAPNDetail.Gl_ID, oAPNDetail.Amount, oAPNDetail.IsCredit, oAPNDetail.CostCenter1_ID, oAPNDetail.CostCenter2_ID, "");
                        }

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

        #region Fill Tax Detail By GRN
        private void FillTaxDetailByGRN(string sGRNID)
        {
            try
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sGRNID);
                string sPONo = detail.PurchaseOrder_ID != "default" ? detail.PurchaseOrder_ID : "";
                if (detail != null)
                {
                    #region MyRegion
                    //txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    //txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    //txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

                    //txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    //txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    //txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                    //txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                    //txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);
                    //txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal); 
                    #endregion

                    foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGRNID))
                    {
                        if (oGRNDetail.PurchaseOrder_ID != sPONo)
                        {
                            sPONo = "Multiple POs";
                            break;
                        }
                    }

                    //lblPoNo.Text = sPONo;
                    //lblPoNo.Visible = true;

                    //txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    //txtSupplierID.Tag = detail.Supplier_ID;
                    //rdoSupplier.Checked = (detail.Supplier_ID != "default") ? true : false;

                    txtNoteType.Tag = detail.StockNoteType_ID;
                    txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                    if (detail.CreditPeriod == "")
                    {
                        uC_Supplier.CreditPeriod = 0;
                    }
                    else
                        uC_Supplier.CreditPeriod = decimal.Parse(detail.CreditPeriod);

                    uC_Supplier.IsNBTenable = (detail.NbtTotal > 0) ? true : false;
                    uC_Supplier.IsVATenable = (detail.VatTotal > 0) ? true : false;
                    uC_Supplier.IsSVATenable = (detail.OtherTaxTotal > 0) ? true : false;

                    //CalculateTaxesAndGrandTotal();
                    //FillDetailsCurrency(txtCurCode.Tag.ToString());

                    uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                    //uC_TotalCalc1.SubTotal = detail.SubTotal - detail.DiscountTotal;
                    uC_TotalCalc1.SubTotal = detail.SubTotal;
                    //uC_TotalCalc1.SetEnableTax(uC_Supplier.IsNBTenable, uC_Supplier.IsVATenable, uC_Supplier.IsSVATenable, uC_Supplier.Supplier_ID, "default", "default", uC_ExchangeRate1.ExchangeRate);

                    uC_Supplier.SetSupplier(detail.Supplier_ID, IsUpdate);
                    uC_Supplier1_SupplierChanged();

                    uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.Supplier_ID, "default", detail.CurrencyRate);

                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By PO
        private void FillTaxDetailByPO(string sPurchaseOrderID)
        {
            try
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sPurchaseOrderID);
                if (detail != null)
                {
                    #region MyRegion
                    //txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    //txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    //txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    //txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

                    //txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal-detail.DiscountTotal, detail.ForexRate));
                    //txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal - detail.DiscountTotal, detail.ForexRate));
                    ////txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.ForexRate));
                    //txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.ForexRate));
                    //txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.ForexRate));
                    //txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.ForexRate));
                    //txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.ForexRate));
                    //txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    //txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    //txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                    //txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                    //txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);
                    //txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal); 
                    #endregion

                    //FillDetailsCurrency(txtCurCode.Tag.ToString());
                    uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, uC_ExchangeRate1.ExchangeRate);

                    //txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    //txtSupplierID.Tag = detail.Supplier_ID;
                    //rdoSupplier.Checked = (detail.Supplier_ID != "default") ? true : false;
                    

                    //add 201-09-21 by janith
                    //txtCreditDays.Text = detail.BalanceDays.ToString();                    
                    uC_Supplier.CreditPeriod = detail.BalanceDays;
                    //txtCreditDays.Enabled = false;

                    txtNoteType.Tag = detail.StockNoteType_ID;
                    txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                    //chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    //chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    //chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    //chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                    //CalculateTaxesAndGrandTotal();
                    //uC_TotalCalc1.SubTotal = detail.SubTotal - detail.DiscountTotal;
                    uC_TotalCalc1.SubTotal = detail.SubTotal;

                    uC_Supplier.SetSupplier(detail.Supplier_ID, IsUpdate);
                    uC_Supplier1_SupplierChanged();

                    uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.Supplier_ID, "default", uC_ExchangeRate1.ExchangeRate);


                    //change 201-09-21 by janith
                    //tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString().Trim());
                    //if (osup != null && osup.CreditPeriod > 0)
                    //    txtCreditDays.Text = osup.CreditPeriod.ToString();
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
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (uC_TotalCalc1.CheckValidity_DoubleEntry())
            {
                if (CheckValidity_EmptyField())
                {
                    if (CheckValiditySettleAmmount())
                    {
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                        {
                            if (uC_DoubleEntry1.CheckValidity_DebitCredit())
                            {
                                bIsOk = true;
                            }

                        }
                    }
                }
            }
            return bIsOk;
        }

        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtAPNID);
                clsCommon.ValidateForeignKey(ref txtDeliveryOrderID);
                clsCommon.ValidateForeignKey(ref txtNoteType);
                clsCommon.ValidateForeignKey(ref txtGRNNo);
                clsCommon.ValidateForeignKey(ref txtPONo);

                if (txtCreditDays.Text.Trim().Length == 0)
                    txtCreditDays.Text = "0";
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private bool ValidateForDependancies()
        {
            bool bValue = true;

            try
            {
                foreach (tbl_accPaymentVoucher_Detail oDBN_Detail in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(txtAPNID.Text.Trim()).Where(p => p.PaymentVoucher_ID == "default"))
                {
                    tbl_accDebitNote detail = tbl_accDebitNote.Select(oDBN_Detail.DebitNote_ID);
                    if (detail != null && detail.DebitNote_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.DebitNote_ID + "] SRN is already created for this APN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;

            if (uC_Supplier.CheckValidity_EmptyField())
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtAPNType, "APN Type"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtBillNo, "Bill No"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtCreditDays, "Credit days"))
                        {
                            bStatus = true;
                            ValidateEmptyForeignKey();
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValiditySettleAmmount()
        {
            bool bSettoffOk = false;

            try
            {
                decimal dOldGrandTotal = 0;
                if (txtAPNID.Tag != null)
                {
                    tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                    if (oldRecord != null)
                        dOldGrandTotal = oldRecord.GrandTotal;
                }

                if (txtGRNNo.Tag != null && txtGRNNo.Tag.ToString().Trim().Length > 0 && txtGRNNo.Tag.ToString().Trim() != "default")
                    bSettoffOk = clsProcessMethods.Check_ARNTotal_With_GRNTotal(txtGRNNo.Text.ToString().Trim(), clsHelpMethods_Local.getDisplayPrice(uC_TotalCalc1.GrandTotal - dOldGrandTotal, uC_ExchangeRate1.ExchangeRate));//dSettleAmount - dOldGrandTotal is it OK            
                else
                    bSettoffOk = true;

                if (!bSettoffOk)
                    MessageBox.Show("APN Amount cannot be greater than unsettled PO/GRN Amount....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bSettoffOk;
        }
        #endregion

        #region  Event Double Click
        private void txtAPNType_DoubleClick(object sender, EventArgs e)
        {
            Search_APN_Type();
        }

        private void txtAPNID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, chkShowSettle.Checked, "", "", false, false, true, false);
                if (txtAPNID.Tag != null)
                    FillDetails(txtAPNID.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyPress
        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        #endregion

        #region Search Methods
        private void Search_APN_Type()
        {
            clsSearch.Search_AccountPayableNoteType_New(ref txtAPNType);
        }

        private void txtGRNNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_TransactionExternalGoodReceivedNote_Direct(ref txtGRNNo, false, true, uC_Supplier.Tag != null ? uC_Supplier.Tag.ToString() : "", "");
                if (txtGRNNo.Tag != null && txtGRNNo.Tag.ToString().Trim().Length > 0)
                {
                    FillTaxDetailByGRN(txtGRNNo.Tag.ToString().Trim());
                    //RefreshGridByGRN(txtGRN.Tag.ToString().Trim());
                    //Disable_POGRN();
                    //setEnableArea_StockNoteType(false);

                    txtGRNNo.Enabled = false;
                    txtPONo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtPONo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPONo, uC_Supplier.Tag != null ? uC_Supplier.Tag.ToString() : "", false, true);
            if (txtPONo.Tag != null && txtPONo.Tag.ToString().Trim().Length > 0)
            {
                FillTaxDetailByPO(txtPONo.Text.Trim());
                //RefreshGridByPRN(txtPONo.Text.Trim());
                //Disable_POGRN();
                //setEnableArea_StockNoteType(false);

                txtPONo.Enabled = false;
                txtGRNNo.Enabled = false;
            }
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtAPNID.Text.Trim().Length > 0 && txtAPNID.Text.Trim() != "<Auto Generate>")
                {
                    Cursor = Cursors.WaitCursor;
                    glb_dts_Apn.Clear();

                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDraff = "";
                    string sDuplicateCopy = "";
                    bool bApprovalDone = true, bCheckingDone = true, bIsAllocatedGRN = false;

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                        if (oAPN != null)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintAPN)
                                {
                                    if (!oAPN.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the APN Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion

                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintAPN)
                                {
                                    if (!oAPN.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the APN Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            tbl_genSupplierMaster oSup = tbl_genSupplierMaster.Select(oAPN.Customer_ID);
                            List<tbl_accAccountPayableNote_SubTotal> oAPN_SubTotals = tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(oAPN.AccountPayableNote_ID);
                            if (oSup != null && oAPN_SubTotals != null)
                            {
                                glb_dts_Apn.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(oAPN.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, clsGenaralName.getName_APNType(oAPN.ApnType_ID), oAPN.Narration, clsGenaralName.getName_Supplier(oAPN.Supplier_ID),
                                    oAPN.BillNo, oAPN.BillDate, oAPN.PurchaseOrder_ID, oAPN.ExternalGoodReceivedNote_ID, oAPN.NoDeliveryOrder, oAPN.NoAWB, oAPN.NoLC, oAPN.CreditDays.ToString(),
                                    oAPN.DiscountTotal, oAPN.NbtTotal, oAPN.VatTotal, oAPN.OtherTaxTotal, oAPN.SubTotal, oAPN.GrandTotal, 0, "", "", 0, 0, "", oAPN.CreditDays, oAPN.IsDeleted, clsGenaralName.getName_SupplierPayee(oAPN.Supplier_ID), clsGenaralName.getSupplierAddressRegister(oAPN.Supplier_ID),
                                    oAPN.DiscountPercentage, oAPN.VatPercentage, oAPN.NbtPercentage, oAPN.OtherTaxPercentage);

                                foreach (tbl_accAccountPayableNote_SubTotal oAPN_SubTotal in oAPN_SubTotals)
                                {
                                    decimal dCreditVal = (oAPN_SubTotal.IsCredit ? oAPN_SubTotal.Amount : 0);
                                    decimal dDebetVal = oAPN_SubTotal.IsCredit ? 0 : oAPN_SubTotal.Amount;

                                    glb_dts_Apn.dts_AccountPaybleNoteDetail.Adddts_AccountPaybleNoteDetailRow(oAPN.AccountPayableNote_ID, oAPN_SubTotal.Gl_ID, clsGenaralName.getName_AccountName(oAPN_SubTotal.Gl_ID), clsGenaralName.getName_AccCostCenter1(oAPN_SubTotal.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oAPN_SubTotal.CostCenter2_ID), "", oAPN_SubTotal.IsCredit, oAPN_SubTotal.Amount);
                                }

                                //List<tbl_accAccountPayableNote_Allocation> oAllDetail = tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.AccountPayableNote_ID == oAPN.AccountPayableNote_ID).ToList();
                                //var oAllocation = oAllDetail.GroupBy(gb => new { gb.ExternalGoodReceivedNote_ID }, (Key, group) =>
                                //                    new { ExternalGoodReceivedNote_ID = Key.ExternalGoodReceivedNote_ID, SettledAmount = group.Sum(p => p.AllocatedAmount) });

                                //foreach (var oGRNAllocation in oAllocation.OrderBy(p => (p.ExternalGoodReceivedNote_ID)))
                                //{
                                //    bIsAllocatedGRN = true;
                                //    string sPOID = "";
                                //    foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRNAllocation.ExternalGoodReceivedNote_ID))
                                //    {
                                //        sPOID = oGRNDetail.PurchaseOrder_ID;
                                //    }
                                //    tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(oGRNAllocation.ExternalGoodReceivedNote_ID);
                                //    tbl_scsPurchaseOrder oPO = tbl_scsPurchaseOrder.Select(sPOID);
                                //    if (oGRN != null && oPO != null)
                                //    {
                                //        glb_dts_Apn.dt_GrnDetail.Adddt_GrnDetailRow(oAPN.AccountPayableNote_ID, oPO.PurchaseOrderDate, sPOID, oGRN.ExternalGoodReceivedNoteDate, oGRN.ExternalGoodReceivedNote_ID, oGRN.DeliveryOrderNumber, oPO.GrandTotal, oGRNAllocation.SettledAmount, oGRNAllocation.SettledAmount);

                                //    }
                                //}

                                #region Print The Doc
                                if (bApprovalDone && bCheckingDone)
                                {
                                    if (!bIsDraft)
                                    {
                                        //sDuplicateCopy = oAPN.PrintCount > 0 ? "Duplicate Copy " + oAPN.PrintCount : "";

                                        if (!chkPrintOriginal.Checked)
                                            sDuplicateCopy = (oAPN.PrintCount > 0) ? "Duplicate Copy " + oAPN.PrintCount : "";

                                        oAPN.PrintCount++;
                                        oAPN.Update();
                                    }

                                    sCreateUser = "[ " + clsGenaralName.getName_User(oAPN.CreateUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(oAPN.DateCreate) + " ]";
                                    if (oAPN.CheckedUser_ID != "default")
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(oAPN.CheckedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(oAPN.DateChecked) + " ]";
                                    if (oAPN.ApprovedUser_ID != "default")
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(oAPN.ApprovedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(oAPN.DateApproved) + " ]";

                                    string s_Path = "", sReportTitle = "";
                                    sReportTitle = clsHelpMethods_Local.GetReportDisplayName(clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));
                                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                    string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));

                                    if (sGetRptPath != null && sGetRptPath.Length > 0)
                                        s_Path = sGetRptPath;

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HideGRNSummery", bIsAllocatedGRN ? "" : "Hide", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true);

                                    if (oAPN.IsDeleted)
                                    {
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", "Canceled", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", "", true);
                                    }
                                    else
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", "", true);

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

                                    glb_dts_Apn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle, "", "", clsSecurity.UserNameLoged, "");

                                    #endregion

                                    frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                    ReportViewer.print(s_Path, glb_dts_Apn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));
                                }
                                #endregion
                            }
                        }
                        // Sent Maill
                        email.createEmail_APN(txtAPNID.Text.Trim(), enum_Alerts.AccountPayableNotePrinted);
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
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Search Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtAPNID.Text != null && txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
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

                                        tbl_accAccountPayableNote objAPN = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                                        if (objAPN != null)
                                        {
                                            objAPN.IsApproved = true;
                                            objAPN.DateApproved = clsSecurity.getServerDateTime();
                                            objAPN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objAPN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtAPNID.Text != null && txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
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

                                        tbl_accAccountPayableNote objAPN = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                                        if (objAPN != null)
                                        {
                                            objAPN.IsChecked = true;
                                            objAPN.DateChecked = clsSecurity.getServerDateTime();
                                            objAPN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objAPN.Update();
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

        private void UserDetails()
        {
            try
            {
                if (txtAPNID.Text != "" || txtAPNID.Text != "<Auto Generate>")
                {
                    tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtAPNID.Text);
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

        private void uC_Supplier1_SupplierChanged()
        {
            txtCreditDays.Text = uC_Supplier.CreditPeriod.ToString();
            uC_TotalCalc1.SetEnableTax(uC_Supplier.IsNBTenable, uC_Supplier.IsVATenable, uC_Supplier.IsSVATenable, uC_Supplier.Supplier_ID, "default", "default", uC_ExchangeRate1.ExchangeRate);
        }

        private void uC_TotalCalc1_DoubleEntryUpdataed(DataTable dt)
        {
            uC_DoubleEntry1.Refresh(dt);
        }

        private void uC_ExchangeRate1_ExRateChanged()
        {
            uC_TotalCalc1.SetEnableTax(uC_Supplier.IsNBTenable, uC_Supplier.IsVATenable, uC_Supplier.IsSVATenable, uC_Supplier.Supplier_ID, "default", "default", uC_ExchangeRate1.ExchangeRate);
        }

        private void uC_DoubleEntry1_Clicked(TransactionCategory TxnCat)
        {
            uC_TotalCalc1.UpdateAccCode(TxnCat);
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