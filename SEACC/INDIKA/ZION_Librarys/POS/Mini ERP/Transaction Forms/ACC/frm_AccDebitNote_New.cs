using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic;
using System.Data;
using CrystalDecisions.Shared;
using Digiteq.DataSets.ACC;
using DataTire;
using CrystalDecisions;
using System.Drawing;
using Digiteq.DataSets;
using System.Linq;

namespace Digiteq
{
    public partial class frm_AccDebitNote_New : SEACC_Form
    {
        #region Variables

        public decimal dExRate = 0;

        dts_DebitNote glb_dts_DebitNote = new dts_DebitNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        public string glbDebitNoteID = "";

        //for subTotal
        DataTable glb_dtGrandTotal;
        DataTable glb_dtSubTotal;
        DataTable glb_dtNBT;
        DataTable glb_dtVAT;
        DataTable glb_dtSubTotal_Temp;
        DataTable glb_dtSubTotal_Temp2;

        public DateTime glbApprovedDate;
        public DateTime glbCheckedDate;
        #endregion

        #region Form Load
        public frm_AccDebitNote_New(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_AccDebitNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();

            if (glbDebitNoteID != null && glbDebitNoteID.Length > 0)
                FillDetails(glbDebitNoteID);
        }
        #endregion

        #region Events Click
        #region Button New
        private void frm_AccDebitNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Button Save
        private void frm_AccDebitNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    try
                    {
                        decimal dSettleAmount = 0;
                        string sPRNID = rdoReturnGoods.Checked ? (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0) ? txtSPRNNo.Tag.ToString() : "default" : "default";
                        string sAPNID = (txtPRNNo.Tag != null && txtPRNNo.Tag.ToString().Length > 0) ? txtPRNNo.Tag.ToString().Trim() : "default";

                        #region update records
                        if (IsUpdate)  //update records
                        {
                            tbl_accDebitNote oOldRecord = tbl_accDebitNote.Select(txtDebitNoteID.Tag.ToString().Trim());
                            if (oOldRecord != null && clsValidate.CheckPrintingValidity(oOldRecord.PrintCount))
                            {
                                if (!oOldRecord.IsLocked && !oOldRecord.IsApproved && !oOldRecord.IsFinished && !oOldRecord.IsDeleted)
                                {
                                    if (!oOldRecord.IsChecked ||
                                        (oOldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtDebitNoteID.Text))
                                        {

                                            #region debit Note Header update

                                            tbl_accDebitNote AccDBN = new tbl_accDebitNote(txtDebitNoteID.Text.Trim(),
                                                dtpDabitNoteDate.Value, txtNarration.Text, sPRNID, sAPNID,
                                                oOldRecord.PaymentVoucher_ID, oOldRecord.Invoice_ID,
                                                oOldRecord.CreditNote_ID, uC_Supplier1.Supplier_ID,
                                                uC_ExchangeRate1.CurrencyCode,
                                                uC_ExchangeRate1.ExchangeRate, uC_TotalCalc1.GrandTotal,
                                                uC_TotalCalc1.OtherTaxAmount, uC_TotalCalc1.VatAmount,
                                                uC_TotalCalc1.NbtAmount, uC_TotalCalc1.DiscountAmount,
                                                uC_TotalCalc1.SubTotal, uC_TotalCalc1.OtherTaxPresentage,
                                                uC_TotalCalc1.VatPresentage, uC_TotalCalc1.NbtPresentage,
                                                uC_TotalCalc1.DiscountPresentage,
                                                oOldRecord.CompanyID, oOldRecord.CompanyBranch_ID,
                                                oOldRecord.FinancialYear_ID, oOldRecord.PostingStatus_ID,
                                                oOldRecord.GlPosting_ID, oOldRecord.CostCenter1_ID,
                                                oOldRecord.CostCenter2_ID, oOldRecord.CreateUser_ID,
                                                clsSecurity.UserIDLoged, oOldRecord.CheckedUser_ID,
                                                oOldRecord.ApprovedUser_ID, oOldRecord.DeletedUser_ID,
                                                oOldRecord.PrintedUser_ID,
                                                clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                oOldRecord.DeletedTerminal_ID, oOldRecord.PrintedTerminal_ID,
                                                oOldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                oOldRecord.DateChecked, oOldRecord.DateApproved, oOldRecord.DateDeleted,
                                                oOldRecord.DatePrinted,
                                                oOldRecord.IsChecked, oOldRecord.IsApproved, oOldRecord.IsFinished,
                                                oOldRecord.IsDeleted, rdoReturnGoods.Checked, oOldRecord.IsSalesNote,
                                                rdoAPNAdjustment.Checked, oOldRecord.SettledAmount,
                                                oOldRecord.IsSettled, oOldRecord.IsLocked, oOldRecord.PrintCount);
                                            AccDBN.Update();

                                            #endregion

                                            #region Insert Debit Note Detail

                                            #region Reverce APN/SRN settlement

                                            foreach (tbl_accPaymentVoucher_Detail oPvdetailOld in
                                                tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(txtDebitNoteID.Tag
                                                    .ToString().Trim()))
                                            {
                                                if (oPvdetailOld.AccountPayableNote_ID != "default"
                                                ) //reverce APN Settlement
                                                {
                                                    tbl_accAccountPayableNote detail =
                                                        tbl_accAccountPayableNote.Select(oPvdetailOld
                                                            .AccountPayableNote_ID);
                                                    if (detail != null)
                                                    {
                                                        detail.SettledAmount -= oPvdetailOld.SettleAmount;
                                                        detail.IsSeattled = false;
                                                        detail.Update();
                                                    }
                                                }
                                                else // reverce srn settlement
                                                {
                                                    //Check This 
                                                    // tbl_scsPurchaseReturnedNote oPrn = tbl_scsPurchaseReturnedNote.Select(oOldRecord.PurchaseReturnedNote_ID);
                                                    //if (oPrn != null && oPrn.PurchaseReturnedNote_ID != "default")
                                                    //{
                                                    // oPrn.SeattleAmount
                                                    //}



                                                    //need to fill
                                                }
                                            }

                                            #endregion

                                            #region Delete and recreate payment voucher detail records

                                            tbl_accPaymentVoucher_Detail.DeleteAllByDebitNote_ID(
                                                oOldRecord.DebitNote_ID);

                                            string sApnId = "", sPrnId = "";
                                            decimal dApnAmount = 0;
                                            decimal dTotalApnAmount = 0;
                                            int iRowCount = 0;
                                            foreach (DataGridViewRow row in dgvAPN.Rows)
                                            {
                                                iRowCount = int.Parse(clsAutocode.getAutoGeneratedCode(
                                                    clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));

                                                sApnId = rdoAPNAdjustment.Checked
                                                    ? clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "")
                                                    : clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                                                sPrnId = !rdoAPNAdjustment.Checked
                                                    ? (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0
                                                        ? txtPRNNo.Tag.ToString()
                                                        : "default")
                                                    : "default";

                                                dApnAmount = clsHelpMethods.getSavePrice(
                                                    decimal.Parse(clsValidate.ValidateGridValue(dgvAPN, "APNAmount",
                                                        row.Index, "0.00")), uC_ExchangeRate1.ExchangeRate);
                                                dTotalApnAmount += dApnAmount;
                                                tbl_accPaymentVoucher_Detail oPvDetail =
                                                    new tbl_accPaymentVoucher_Detail(iRowCount, "default", sApnId,
                                                        "default", txtDebitNoteID.Text.Trim(), "default", "default", -1,
                                                        "default", -1, "", dApnAmount, true);
                                                oPvDetail.Insert();
                                                //iRowCount++;

                                                if (sApnId != "default" && sApnId.Length > 0)
                                                {
                                                    tbl_accAccountPayableNote detail =
                                                        tbl_accAccountPayableNote.Select(sApnId);
                                                    if (detail != null)
                                                    {
                                                        detail.SettledAmount += dApnAmount;
                                                        if (detail.GrandTotal <= detail.SettledAmount)
                                                            detail.IsSeattled = true;
                                                        detail.Update();
                                                    }
                                                }

                                                if (sPrnId != "default" && sPrnId.Length > 0)
                                                {
                                                    tbl_scsPurchaseReturnedNote detail =
                                                        tbl_scsPurchaseReturnedNote.Select(sPrnId);
                                                    if (detail != null)
                                                    {
                                                        detail.SeattleAmount += dApnAmount;
                                                        if (detail.GrandTotal <= detail.SeattleAmount)
                                                            detail.IsSeattled = true;
                                                        detail.Update();
                                                    }
                                                }
                                            }

                                            if (dTotalApnAmount == AccDBN.GrandTotal)
                                            {
                                                AccDBN.IsSettled = true;
                                                AccDBN.Update();
                                            }

                                            #endregion

                                            #endregion

                                            #region  Insert Detail - DEBIT NOTE Account Details

                                            clsMethods_GL.GLPosting_Delete(oOldRecord.GlPosting_ID);
                                            tbl_accDebitNote_SubTotal.DeleteAllByDebitNote_ID(oOldRecord.DebitNote_ID);

                                            int iRow;
                                            string sGLCode = "",
                                                sSubAcct1 = "",
                                                sSubAcct2 = "",
                                                sSubAcct1_ID = "",
                                                sSubAcct2_ID = "",
                                                sOtherCr = "",
                                                sCategoryID = "",
                                                sRemarks = "";
                                            bool bIsCredit;
                                            decimal dAmount;

                                            foreach (DataGridViewRow row in uC_DoubleEntry1.dgvDetail.Rows)
                                            {
                                                iRow = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                    "Line_No", row.Index, int.Parse("0"));
                                                sGLCode = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                    "accCode", row.Index, "");
                                                sCategoryID = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
                                                    "TxnCategory_ID", row.Index, "");
                                                sRemarks = clsValidate.ValidateGridValue(uC_DoubleEntry1.dgvDetail,
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

                                                #region Insert Debit Note SubTotal

                                                tbl_accDebitNote_SubTotal Insdetail = new tbl_accDebitNote_SubTotal(
                                                    iRow, txtDebitNoteID.Text.Trim(), sCategoryID, sGLCode,
                                                    uC_Supplier1.Supplier_ID, sSubAcct1_ID, sSubAcct2_ID, dAmount,
                                                    bIsCredit);
                                                Insdetail.Insert();

                                                #endregion

                                            }

                                            #endregion

                                            #region Debit Note settlement

                                            //need to implement -atp-

                                            #endregion

                                            clsMethods_GL.PostTransaction_SuplierDBN(txtDebitNoteID.Text.Trim());

                                            //Attachments.Insert(iFormID, oOldRecord.DebitNote_ID);
                                            //Attachments.Remove(iFormID, oOldRecord.DebitNote_ID);

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);//locked                                                               
                            }
                        }
                        #endregion

                        #region insert records
                        else
                        {
                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                txtDebitNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                            if (clsValidate.CheckValidity_TransactionCodeLength(txtDebitNoteID.Text)) //if (txtDebitNoteID.Text.Trim().Length > 0)
                            {
                                #region debit Note Header
                                tbl_accDebitNote AccDBN = new tbl_accDebitNote(txtDebitNoteID.Text.Trim(), dtpDabitNoteDate.Value, txtNarration.Text, sPRNID, sAPNID, "default", "default", "default", uC_Supplier1.Supplier_ID, uC_ExchangeRate1.CurrencyCode,
                                   uC_ExchangeRate1.ExchangeRate, uC_TotalCalc1.GrandTotal, uC_TotalCalc1.OtherTaxAmount, uC_TotalCalc1.VatAmount, uC_TotalCalc1.NbtAmount, uC_TotalCalc1.DiscountAmount,
                                    uC_TotalCalc1.SubTotal, uC_TotalCalc1.OtherTaxPresentage, uC_TotalCalc1.VatPresentage, uC_TotalCalc1.NbtPresentage, uC_TotalCalc1.DiscountPresentage,
                                    clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.FinancialYearID, clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), "default", "default", "default", clsSecurity.UserIDLoged, "default", "default", "default", "default", "default",
                                    clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                    false, false, false, false, rdoReturnGoods.Checked, false, rdoAPNAdjustment.Checked, 0, false, false, 0);
                                AccDBN.Insert();
                                #endregion

                                #region Insert Debit Note Detail
                                string sApnId = "", sPrnId = "";
                                decimal dApnAmount = 0;
                                decimal dTotalApnAmount = 0;
                                int iRowCount = 0;
                                foreach (DataGridViewRow row in dgvAPN.Rows)
                                {
                                    sApnId = rdoAPNAdjustment.Checked ? clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "") : clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                                    sPrnId = !rdoAPNAdjustment.Checked ? (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0 ? txtPRNNo.Tag.ToString() : "default") : "default";

                                    iRowCount = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));

                                    dApnAmount = clsHelpMethods.getSavePrice(decimal.Parse(clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, "0.00")), uC_ExchangeRate1.ExchangeRate);
                                    dTotalApnAmount += dApnAmount;
                                    tbl_accPaymentVoucher_Detail oPvDetail = new tbl_accPaymentVoucher_Detail(iRowCount, "default", sApnId, "default", txtDebitNoteID.Text.Trim(), "default", "default", -1, "default", -1, "", dApnAmount, true);
                                    oPvDetail.Insert();

                                    if (sApnId != "default" && sApnId.Length > 0)
                                    {
                                        tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sApnId);
                                        if (detail != null)
                                        {
                                            detail.SettledAmount += dApnAmount;
                                            if (detail.GrandTotal <= detail.SettledAmount)
                                                detail.IsSeattled = true;
                                            detail.Update();
                                        }
                                    }
                                    if (sPrnId != "default" && sPrnId.Length > 0)
                                    {
                                        tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sPrnId);
                                        if (detail != null)
                                        {
                                            detail.SeattleAmount += dApnAmount;
                                            if (detail.GrandTotal <= detail.SeattleAmount)
                                                detail.IsSeattled = true;
                                            detail.Update();
                                        }
                                    }
                                }

                                if (dTotalApnAmount == AccDBN.GrandTotal)
                                {
                                    AccDBN.IsSettled = true;
                                    AccDBN.Update();
                                }
                                #endregion

                                #region  Insert Detail - DEBIT NOTE Account Details
                                int iRow;
                                string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";
                                bool bIsCredit;
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

                                    #region Insert Debit Note SubTotal
                                    tbl_accDebitNote_SubTotal Insdetail = new tbl_accDebitNote_SubTotal(iRow, txtDebitNoteID.Text.Trim(), sCategoryID, sGLCode,
                                    uC_Supplier1.Supplier_ID, sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                    Insdetail.Insert();
                                    #endregion

                                }
                                #endregion

                                #region Debit Note settlement

                                //need to implement -atp-

                                #endregion

                                clsMethods_GL.PostTransaction_SuplierDBN(txtDebitNoteID.Text.Trim());
                                Attachments.Insert(txtDebitNoteID.Text.ToString());

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //else
                            //    MessageBox.Show("Debit Note ID " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        tbl_accDebitNote Fdetail = tbl_accDebitNote.Select(txtDebitNoteID.Text.ToString());
                        if (Fdetail != null)
                        {
                            ClearFields();
                            FillDetails(Fdetail.DebitNote_ID);
                        }
                    }
                }
            }
        }
        #endregion

        #region Button Delete
        private void frm_AccDebitNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebitNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_accDebitNote detail = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsDeleted)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "  Debit Note : " + txtPRNNo.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        #region Remove Settlement
                                        foreach (tbl_accPaymentVoucher_Detail oDbnDetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(detail.DebitNote_ID))
                                        {
                                            if (rdoAPNAdjustment.Checked)
                                            {
                                                #region Remove APN Settlement
                                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(oDbnDetail.AccountPayableNote_ID);
                                                if (oAPN != null)
                                                {
                                                    oAPN.SettledAmount -= oDbnDetail.SettleAmount;
                                                    if (oAPN.GrandTotal > oAPN.SettledAmount)
                                                        oAPN.IsSeattled = false;
                                                    oAPN.Update();
                                                }
                                                #endregion
                                            }
                                            oDbnDetail.IsSettled = false;
                                            oDbnDetail.SettleAmount = 0;
                                            oDbnDetail.Update();

                                        }
                                        #endregion

                                        detail.IsDeleted = true;
                                        detail.DateModified = clsSecurity.getServerDateTime();
                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        detail.Update();

                                        clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ClearFields();
                                    }
                                }//deleted
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else // not found
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ItemNotFound), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Btn Remove APN Grid
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAPN.SelectedCells.Count != 0)
                {
                    if (dgvAPN.Rows.Count > 0)
                    {
                        dgvAPN.Rows.RemoveAt(dgvAPN.SelectedCells[0].RowIndex);
                        UpdateApnTotal();
                        CalcualteTotalAmount();
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

        #region Button Print
        private void frm_AccDebitNote_SF_printButton_Click(object sender, EventArgs e)
        {
            tbl_accDebitNote detail = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
            if (detail != null && detail.IsApproved)
            {
                Print(false);
            }
            else
            {
                MessageBox.Show("Please Approve the Transaction Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Draft
        private void frm_AccDebitNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_AccDebitNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_AccDebitNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_AccDebitNote_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Temp
        private void frm_AccDebitNote_SF_tempButton_Click_1(object sender, EventArgs e)
        {
            if (txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPRNNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteType, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSPRNNo, true);

                txtDebitNoteID.Tag = null;
                SetDisableControl(true);

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

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
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPRNNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteType, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSPRNNo, true);
            uC_Supplier1.Enabled = true;

            clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, true);

            btnallocattion.Visible = false;

            SetDisableControl(true);

            txtDebitNoteID.Tag = null;
            txtPRNNo.Tag = null;
            txtTrackingNo.Tag = null;
            txtDebitNoteType.Tag = null;
            lblDebitNoteType.Tag = null;
            lblAPNNo.Tag = null;
            dtpDabitNoteDate.Tag = null;

            txtTrackingNo.Clear();
            txtDebitNoteType.Clear();
            txtPRNNo.Clear();
            txtDebitNoteType.Clear();
            txtTotalAmount.Clear();
            txtPRNNo.Clear();
            txtNarration.Clear();

            dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

            txtSPRNNo.Text = "";
            txtSPRNNo.Tag = null;
            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkShowSettle.Checked = false;
            rdoAPNAdjustment.Checked = true;

            chkSettings.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDebitNoteID.Text = "<Auto Generate>";
            else
                txtDebitNoteID.Clear();
            if (txtDebitNoteID.Enabled)
            {
                txtDebitNoteID.SelectAll();
                txtDebitNoteID.Focus();
            }

            dgvAPN.Rows.Clear();
            rdoAPNAdjustment.Checked = true;

            UpdateApnTotal();

            uC_ExchangeRate1.ClearFields();
            uC_Supplier1.ClearFields();
            uC_TotalCalc1.ClearFields();
            uC_DoubleEntry1.ClearFields();

            Attachments.Clear();
        }

        #endregion

        #region Fill
        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_accDebitNote detail = tbl_accDebitNote.Select(sID);
                    if (detail != null && detail.DebitNote_ID != "default")
                    {
                        //set the update flag and Locked
                        IsUpdate = true;

                        uC_TotalCalc1.ClearFields();
                        uC_DoubleEntry1.ClearFields();

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPRNNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTrackingNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNNo, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblTrackingNo, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, true);
                        SetDisableControl(false);

                        txtDebitNoteID.Tag = detail.DebitNote_ID;
                        dtpDabitNoteDate.Value = detail.DebitNote_Date;

                        txtPRNNo.Text = "";
                        txtDebitNoteID.Text = detail.DebitNote_ID;
                        txtNarration.Text = detail.Remarks;

                        if (detail.IsAPNAdjustment)
                        {
                            rdoAPNAdjustment.Checked = true;
                            rdoReturnGoods.Checked = false;
                        }
                        else
                        {
                            rdoAPNAdjustment.Checked = false;
                            rdoReturnGoods.Checked = true;
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

                        if (detail.IsReturnedGoods)
                        {
                            txtSPRNNo.Text = detail.PurchaseReturnedNote_ID;
                            txtSPRNNo.Tag = detail.PurchaseReturnedNote_ID; ;
                        }

                        string sTransactionId = "";
                        DateTime dtmTransactionDate = clsSecurity.getServerDateTime();
                        decimal dAmount = 0;

                        foreach (tbl_accPaymentVoucher_Detail APNdetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(detail.DebitNote_ID))
                        {
                            if (APNdetail.AccountPayableNote_ID != "default" && APNdetail.AccountPayableNote_ID != "")
                            {
                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(APNdetail.AccountPayableNote_ID);
                                if (oAPN.AccountPayableNote_ID != "default" && oAPN != null)
                                {
                                    sTransactionId = oAPN.AccountPayableNote_ID;
                                    dtmTransactionDate = oAPN.AccountPayableNoteDate;
                                }
                            }
                            dAmount = clsHelpMethods.getDisplayPrice(APNdetail.SettleAmount, uC_ExchangeRate1.ExchangeRate);
                            dgvAPN.Rows.Add(sTransactionId, clsFormatter.FormatDate_Short(dtmTransactionDate), clsFormatter.FormatDecimalPlaces_Price(dAmount));
                        }

                        UpdateApnTotal();

                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);
                        uC_Supplier1.SetSupplier(detail.Supplier_ID, IsUpdate);
                        uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.Supplier_ID, "default", detail.CurrencyRate);

                        foreach (tbl_accDebitNote_SubTotal oDBNDetail in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(detail.DebitNote_ID))
                        {
                            uC_TotalCalc1.SetGL(oDBNDetail.Line_No, int.Parse(oDBNDetail.Tc_ID), oDBNDetail.Gl_ID, oDBNDetail.Amount, oDBNDetail.IsCredi, oDBNDetail.CostCenter1_ID, oDBNDetail.CostCenter2_ID, "");
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

        private void FillDetailsAPN(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sID);
                    if (detail != null)
                    {
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);

                        txtPRNNo.Tag = detail.AccountPayableNote_ID;
                        txtPRNNo.Text = detail.AccountPayableNote_ID;

                        uC_Supplier1.SetSupplier(detail.Supplier_ID, IsUpdate);

                        if (txtPRNNo.Tag != null)
                        {
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);
                        }

                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);

                        decimal dUnSettledAmount = detail.GrandTotal - detail.SettledAmount;
                        dgvAPN.Rows.Add(detail.AccountPayableNote_ID, clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate), clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(dUnSettledAmount, uC_ExchangeRate1.ExchangeRate)));

                        uC_TotalCalc1.SetEnableTax(uC_Supplier1.IsNBTenable, uC_Supplier1.IsVATenable, uC_Supplier1.IsSVATenable, uC_Supplier1.Supplier_ID, "default", "default", uC_ExchangeRate1.ExchangeRate);

                        uC_TotalCalc1.FillDetail(detail.SubTotal, detail.DiscountTotal, detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.Supplier_ID, "default", detail.CurrencyRate);

                        //foreach (tbl_accAccountPayableNote_SubTotal oAPNDetail in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(detail.AccountPayableNote_ID))
                        //{
                        //    uC_TotalCalc1.SetGL(oAPNDetail.Line_No, int.Parse(oAPNDetail.Tc_ID), oAPNDetail.Gl_ID, oAPNDetail.Amount, !oAPNDetail.IsCredit, oAPNDetail.CostCenter1_ID, oAPNDetail.CostCenter2_ID, "");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void FillDetailsPRN(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sID);
                    if (detail != null & detail.PurchaseReturnedNote_ID != "default")
                    {
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNNo, true);

                        if (txtPRNNo.Tag != null)
                        {
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);
                        }

                        uC_ExchangeRate1.FillDetailsCurrency(detail.Currency_ID, detail.CurrencyRate);

                        txtTotalAmount.Text = (detail.GrandTotal - detail.SeattleAmount).ToString(); //this is only for single PRN 
                        txtTotalAmount.Tag = (detail.GrandTotal - detail.SeattleAmount).ToString(); //this is only for single PRN                                       

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

        #region Events Other

        #region Events KeyDown
        private void txtDebitNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtDebitNoteID_DoubleClick(null, null);
        }

        private void txtPRNNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtPRNNo_DoubleClick(sender, e);
        }
        private void txtSPRNNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtSRNNo_DoubleClick(sender, e);
            }
        }
        #endregion

        #region Events DoubleClick

        private void txtPRNNo_DoubleClick(object sender, EventArgs e)
        {
            #region For APN Ajustment
            if (!rdoReturnGoods.Checked)
            {
                if (uC_Supplier1.Supplier_ID != null && uC_Supplier1.Supplier_ID != "default")
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, uC_Supplier1.Supplier_ID, "", false, false, false, true);
                else
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, "", "", false, false, false, true);
                if (txtPRNNo.Tag != null && CheckValidateDuplicateAPNNo(txtPRNNo.Tag.ToString()))
                {
                    FillDetailsAPN(txtPRNNo.Tag.ToString());
                }

                UpdateApnTotal();
            }
            #endregion

            #region For Return Good Ajustment
            else
            {

                if (clsValidate.ValidateTextBox_EmptyValue(txtSPRNNo, "Supplier Name"))
                {
                    if (uC_Supplier1.Supplier_ID != null && uC_Supplier1.Supplier_ID != "default" && uC_Supplier1.Supplier_ID.Length > 0)
                        clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, uC_Supplier1.Supplier_ID, "", false, false, false, true);
                    else
                        clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, "", "", false, false, false, true);
                    if (txtPRNNo.Tag != null && CheckValidateDuplicateAPNNo(txtPRNNo.Tag.ToString()))
                    {
                        tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtPRNNo.Tag.ToString());
                        if (detail != null)
                        {
                            dgvAPN.Rows.Add(detail.AccountPayableNote_ID, clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate), clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal - detail.SettledAmount));
                        }
                    }
                }
            }
            #endregion
        }

        private void txtDebitNoteID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_Transaction_AccDebitNote_New(ref txtDebitNoteID, chkShowSettle.Checked);
                if (txtDebitNoteID.Tag != null && txtDebitNoteID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtDebitNoteID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtSRNNo_DoubleClick(object sender, EventArgs e)
        {
            if (rdoReturnGoods.Checked)
            {
                try
                {
                    if (uC_Supplier1.CheckValidity_EmptyField())
                        clsSearch.Search_TransactionPurchaseReturnNote_New(ref txtSPRNNo, uC_Supplier1.Tag.ToString(), false);

                    if (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0)
                        FillDetailsPRN(txtSPRNNo.Tag.ToString().Trim());
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Change DBN Type to Return Goods ........!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Events CheckedChanged
        private void rdoAPNAdjustment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAPNAdjustment.Checked)
                lblAPNNo.Text = "APN No";
            else
                lblAPNNo.Text = "PRN No";
        }
        #endregion

        #region Events CellEndEdit
        private void dgvAPN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (rdoAPNAdjustment.Checked)
                CalcualteTotalAmount();
            else
            {
                //try
                //{
                //    dgvAPN.Rows[e.RowIndex].Tag = true;
                //}
                //catch (Exception ex)
                //{ }
            }
        }
        #endregion

        #endregion

        #region Check Validity

        private bool CheckValidityAPN()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtPRNNo.TextLength == 0)
                {
                    strMessage += "\n" + "APN No ";
                    bStatus = false;
                }

                if (bStatus == false)
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }

        private bool CheckApnAmountValidity()
        {
            bool bIsOk = true;
            try
            {
                decimal dTemp = 0;
                foreach (DataGridViewRow row in dgvAPN.Rows)
                {
                    string sDgvApnNo = clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                    decimal dDgvApnAmount = clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, dTemp);
                    decimal dOldSettlementAmmount = 0;

                    if (sDgvApnNo.Length > 0)
                    {
                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sDgvApnNo);
                        if (oAPN != null && oAPN.AccountPayableNote_ID != "default")
                        {
                            #region Insert
                            if (!IsUpdate)
                            {
                            }
                            #endregion
                            #region Update
                            else
                            {
                                foreach (tbl_accPaymentVoucher_Detail oPVD in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(txtDebitNoteID.Text.Trim()))
                                {
                                    if (oPVD.AccountPayableNote_ID == sDgvApnNo)
                                    {
                                        dOldSettlementAmmount = oPVD.SettleAmount;
                                    }
                                }
                            }
                            #endregion

                            if ((oAPN.GrandTotal - oAPN.SettledAmount + dOldSettlementAmmount) < dDgvApnAmount)
                            {
                                bIsOk = false;
                                MessageBox.Show("Settlement Note Amount Cannot be Greater than APN  <<" + sDgvApnNo + ">>" + " Outstanding ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
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
            return bIsOk;
        }

        private bool CheckValidity_PRNAmount()
        {
            bool bIsValid = true;

            try
            {
                //decimal dPrnGrandTotal = decimal.Parse(txtGrandTotal.Text.ToString());
                decimal dPrnGrandTotal = 0;
                if (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0)
                {
                    tbl_scsPurchaseReturnedNote OPRN = tbl_scsPurchaseReturnedNote.Select(txtSPRNNo.Tag.ToString());
                    if (OPRN != null && OPRN.PurchaseReturnedNote_ID != "default")
                    {
                        #region Update
                        if (IsUpdate)
                        {

                        }
                        #endregion
                        #region Insert
                        else
                        {
                            decimal dUnSettledAmount = decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(OPRN.GrandTotal - OPRN.SeattleAmount));
                            if (dPrnGrandTotal > dUnSettledAmount)
                            {
                                bIsValid = false;
                                MessageBox.Show("Debit Amount must be less than or equal to PRN Amount....! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
            return bIsValid;
        }

        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (uC_TotalCalc1.CheckValidity_DoubleEntry())
            {
                if (CheckApnAmountValidity())
                {
                    if (CheckValidity_PRNAmount())
                    {
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                            bIsOk = true;
                    }
                }
            }
            return bIsOk;
        }

        private bool CheckValidateDuplicateAPNNo(string sAPNNo)
        {
            bool bIsOk = true;
            foreach (DataGridViewRow r in dgvAPN.Rows)
            {
                if (r.Cells["APNCode"].Value.ToString() == sAPNNo)
                {
                    bIsOk = false;
                    break;
                }
            }
            return bIsOk;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtPRNNo);
                //clsCommon.ValidateForeignKey(ref txtSupplierID);
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
                string sDuplicate = "";
                string sCreateUserAndDate = "", sCheckedUserAndDate = "", sApprovedUserAndDate = "";
                if (txtDebitNoteID.Text.Trim().Length > 0 && txtDebitNoteID.Text.Trim() != "<Auto Generate>")
                {
                    #region Using Dataset
                    Cursor = Cursors.WaitCursor;
                    glb_dts_DebitNote.Clear();

                    tbl_accDebitNote oDebit = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                    if (oDebit != null && oDebit.DebitNote_ID != "default")
                    {
                        //sCreateUserAndDate = oDebit.CreateUser_ID.Length > 0 ? clsGenaralName.getName_User(oDebit.CreateUser_ID) + " - " + clsFormatter.FormatDate_Short(oDebit.DateCreate) : "";
                        //sApprovedUserAndDate = oDebit.ApprovedUser_ID.Length > 0 ? clsGenaralName.getName_User(oDebit.ApprovedUser_ID) + " - " + clsFormatter.FormatDate_Short(oDebit.DateApproved) : "";
                        //sCheckedUserAndDate = oDebit.CheckedUser_ID.Length > 0 ? clsGenaralName.getName_User(oDebit.CheckedUser_ID) + " - " + clsFormatter.FormatDate_Short(oDebit.DateChecked) : "";

                        sCreateUserAndDate = oDebit.CreateUser_ID.Length > 0 ? "[ " + clsGenaralName.getName_User(oDebit.CreateUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(oDebit.DateCreate) : "";
                        sApprovedUserAndDate = oDebit.ApprovedUser_ID.Length > 0 ? "[ " + clsGenaralName.getName_User(oDebit.ApprovedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(oDebit.DateApproved) : "";
                        sCheckedUserAndDate = oDebit.CheckedUser_ID.Length > 0 ? "[ " + clsGenaralName.getName_User(oDebit.CheckedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(oDebit.DateChecked) : "";

                        if (!bIsDraft)
                        {
                            if (oDebit.PrintCount > 0)
                                sDuplicate = "Duplicate Copy" + oDebit.PrintCount;

                            oDebit.PrintCount++;
                            oDebit.Update();
                        }

                        glb_dts_DebitNote.dt_acc_DebitNote.Adddt_acc_DebitNoteRow(oDebit.DebitNote_ID, oDebit.DebitNote_Date, clsGenaralName.getName_Supplier(oDebit.Supplier_ID), clsGenaralName.getSupplierAddressRegister(oDebit.Supplier_ID)
                            , oDebit.Remarks, oDebit.DiscountPercentage, oDebit.NbtPercentage, oDebit.SubTotal, oDebit.VatPercentage, oDebit.DiscountTotal, oDebit.NbtTotal, oDebit.VatTotal, oDebit.GrandTotal, oDebit.Currency_ID, oDebit.CurrencyRate, oDebit.Invoice_ID, "", DateTime.MinValue, "", 0, "", "", DateTime.MinValue, 0, oDebit.IsDeleted);

                        #region APN
                        if (oDebit.AccountPayableNote_ID != "default")
                        {
                            foreach (tbl_accPaymentVoucher_Detail detail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                            {
                                DateTime dtAPNDate;
                                if (detail.AccountPayableNote_ID != "default")
                                {
                                    tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(detail.AccountPayableNote_ID);
                                    if (oAPN != null)
                                        dtAPNDate = oAPN.AccountPayableNoteDate;
                                    else
                                        dtAPNDate = DateTime.MinValue;
                                    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(detail.DebitNote_ID, detail.AccountPayableNote_ID, dtAPNDate, detail.SettleAmount, true);

                                }
                                //else if (detail.PurchaseReturnedNote_ID != "default")
                                //{
                                //    tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(detail.PurchaseReturnedNote_ID);
                                //    if (oPRN != null)
                                //        dtAPNDate = oPRN.PurchaseReturnedNoteDate;
                                //    else
                                //        dtAPNDate = DateTime.MinValue;
                                //    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(detail.DebitNote_ID, detail.PurchaseReturnedNote_ID, dtAPNDate, detail.SettledAmount);
                                //}
                            }
                        }
                        #endregion

                        #region PRN
                        else if (oDebit.PurchaseReturnedNote_ID != "default")
                        {
                            tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(oDebit.PurchaseReturnedNote_ID);
                            if (oPRN != null)
                                glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(oDebit.DebitNote_ID, oDebit.PurchaseReturnedNote_ID, oPRN.PurchaseReturnedNoteDate, oPRN.SeattleAmount, false);
                        }
                        #endregion

                        #region Others
                        else
                        {
                            foreach (tbl_accDebitNote_SubTotal oDBNSub in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                            {
                                glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(oDebit.DebitNote_ID, "default", DateTime.Now, oDebit.SettledAmount, false);
                            }
                        }
                        #endregion

                        #region GL Detalls
                        foreach (tbl_accDebitNote_SubTotal oDBN_SubTotal in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                        {
                            decimal dCreditVal = 0, dDebetVal = 0;
                            dCreditVal = 0;
                            dDebetVal = 0;
                            if (oDBN_SubTotal.IsCredi)
                                dCreditVal = oDBN_SubTotal.Amount;
                            else
                                dDebetVal = oDBN_SubTotal.Amount;

                            glb_dts_DebitNote.dt_acc_DoubleEntry.Adddt_acc_DoubleEntryRow(oDebit.DebitNote_ID, oDBN_SubTotal.Gl_ID, clsGenaralName.getName_AccountName(oDBN_SubTotal.Gl_ID), "", clsGenaralName.getName_AccCostCenter1(oDBN_SubTotal.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oDBN_SubTotal.CostCenter2_ID), oDBN_SubTotal.Amount, oDBN_SubTotal.IsCredi, "");
                        }
                        #endregion

                        #region PO / GRN Detail
                        foreach (tbl_accPaymentVoucher_Detail PVdetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                        {
                            List<tbl_accAccountPayableNote_Allocation> oAllDetail = tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.AccountPayableNote_ID == PVdetail.AccountPayableNote_ID).ToList();
                            var oAllocation = oAllDetail.GroupBy(gb => new { gb.ExternalGoodReceivedNote_ID }, (Key, group) =>
                                                new { ExternalGoodReceivedNote_ID = Key.ExternalGoodReceivedNote_ID, SettledAmount = group.Sum(p => p.AllocatedAmount) });

                            foreach (var oGRNAllocation in oAllocation.OrderBy(p => (p.ExternalGoodReceivedNote_ID)))
                            {
                                string sPOID = "";
                                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRNAllocation.ExternalGoodReceivedNote_ID))
                                {
                                    sPOID = oGRNDetail.PurchaseOrder_ID;
                                }
                                tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(oGRNAllocation.ExternalGoodReceivedNote_ID);
                                tbl_scsPurchaseOrder oPO = tbl_scsPurchaseOrder.Select(sPOID);
                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(PVdetail.AccountPayableNote_ID);
                                if (oGRN != null && oPO != null && oAPN != null)
                                {
                                    glb_dts_DebitNote.dt_GrnDetail.Adddt_GrnDetailRow(PVdetail.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, oPO.PurchaseOrderDate, sPOID, oGRN.ExternalGoodReceivedNoteDate, oGRN.ExternalGoodReceivedNote_ID, "", oPO.GrandTotal, oGRNAllocation.SettledAmount, oGRNAllocation.SettledAmount);

                                }
                            }

                            //if(oAllDetail.Count == 0)
                            //    glb_dts_DebitNote.dt_GrnDetail.Adddt_GrnDetailRow("", DateTime.MinValue, "", DateTime.MinValue, "", "", 0, 0, 0);
                        }
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

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                            }
                        }

                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true,false);

                        glb_dts_DebitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "SUPPLIER DEBIT NOTE", "", "", clsSecurity.UserNameLoged, "");

                        #endregion


                    }
                    string s_Path = "";
                    string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_AccountDebitNote));

                    if (sGetRptPath != null && sGetRptPath.Length > 0)
                        s_Path = sGetRptPath;
                    else
                    {
                        s_Path = "\\Reports\\ACC\\NotePrinting\\rpt_accDebitNotes.rpt";
                    }

                    print(s_Path, " Debit Note ", glb_dts_DebitNote, sCreateUserAndDate, sCheckedUserAndDate, sApprovedUserAndDate, sDuplicate, oDebit.IsDeleted, bIsDraft, clsAutocode.getReportID(enum_ReportName.NP_AccountDebitNote));
                    #endregion
                }
                else
                    MessageBox.Show("Please Select the Debit Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Set Disable Control
        private void SetDisableControl(bool bEnable)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDebitNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, bEnable);
        }
        #endregion

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sCreateUserNameAndDate, string sChekcedUserNameAndDate, string sApprovedUserNameAndDate, string sDuplicate, bool isCancel, bool bIsDraft, string sReportID)
        {
            try
            {
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", isCancel ? "CANCELLED" : "", true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUserNameAndDate, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sChekcedUserNameAndDate, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUserNameAndDate, true,false);

                if (bIsDraft)
                {
                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                    {
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                    }
                }

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, ojbDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        private void UpdateApnTotal()
        {
            Decimal dAmount = 0;
            int iApnCount = 0;
            foreach (DataGridViewRow row in dgvAPN.Rows)
            {
                iApnCount++;
                dAmount += decimal.Parse(clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, "0.00"));
            }
            if (iApnCount > 0)
                uC_Supplier1.Enabled = false;

            txtTotalAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dAmount);
            uC_TotalCalc1.SubTotal = decimal.Parse(txtTotalAmount.Text);
        }

        #region Calcualte Total Amount
        private void CalcualteTotalAmount()
        {
            try
            {
                decimal Amount = 0;
                for (int i = 0; i < dgvAPN.Rows.Count; i++)
                {
                    string s = dgvAPN["APNAmount", i].Value.ToString();
                    if (dgvAPN["APNAmount", i].Value != null && dgvAPN["APNAmount", i].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvAPN["APNAmount", i].Value.ToString()))
                            Amount += decimal.Parse(dgvAPN["APNAmount", i].Value.ToString());
                    }
                }
                txtTotalAmount.Text = Amount.ToString();
                txtTotalAmount.Tag = Amount;
                uC_TotalCalc1.SubTotal = decimal.Parse(txtTotalAmount.Text);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }
        #endregion

        #region Button Allocation
        private void btnallocattion_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                if (rdoReturnGoods.Checked)
                {
                    #region Settle DBN With APN
                    if (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0)
                    {
                        if (txtDebitNoteID.Tag != null && txtDebitNoteID.Tag.ToString().Length > 0)
                        {

                            try
                            {
                                tbl_accDebitNote oDBN = tbl_accDebitNote.Select(txtDebitNoteID.Tag.ToString());
                                tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(txtSPRNNo.Tag.ToString());

                                if ((oPRN != null && oPRN.PurchaseReturnedNote_ID != "default") && (oDBN != null && oDBN.DebitNote_ID != "default"))
                                {
                                    string sTempApnNO = "";
                                    decimal dAllocatedAmount = 0;
                                    bool bIsEnoughDbnAmountToSettledApn = true;
                                    foreach (DataGridViewRow row in dgvAPN.Rows)
                                    {
                                        string sApnNo = clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                                        decimal dApnAmountTobeSettle = clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, decimal.Parse("0.00"));

                                        if (clsHelpMethods.RemoveSattlementsFrom_DebitNoteWithAPN("default", sApnNo, "default", oDBN.DebitNote_ID, "default"))
                                        {
                                            dAllocatedAmount += clsHelpMethods.AutoSettleDebitNoteWithAPN(sApnNo, oDBN.DebitNote_ID, DateTime.Now.Date, dApnAmountTobeSettle, "", row.Index + 1, ref bIsEnoughDbnAmountToSettledApn);
                                            sTempApnNO += dAllocatedAmount > 0 ? sApnNo + " , " : "";
                                            if (!bIsEnoughDbnAmountToSettledApn)//To stop The operation When DBN Amount lesthan APN to be Settled amount.
                                                break;
                                        }
                                    }
                                    if (dAllocatedAmount > 0)
                                        MessageBox.Show("PRN No-" + "<<" + txtSPRNNo.Tag.ToString() + ">>" + "Successfully Settled With" + "This APN" + "<<" + sTempApnNO + ">>", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                            }
                            catch (Exception ex)
                            {
                                clsValidate.WriteErrorLog("", iFormID, ex);
                                SEACCException.Show(ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Select Debit Note To Settle......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select PRN To Settle......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else
                    MessageBox.Show("Please check the Return good Redio Button......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please Save Note Before Settle the Note......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtDebitNoteID.Text != null && txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
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

                                        tbl_accDebitNote objDO = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsApproved = true;
                                            objDO.DateApproved = clsSecurity.getServerDateTime();
                                            objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDO.Update();
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
                if (txtDebitNoteID.Text != null && txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
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

                                        tbl_accDebitNote objDO = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsChecked = true;
                                            objDO.DateChecked = clsSecurity.getServerDateTime();
                                            objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDO.Update();
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
                if (txtDebitNoteID.Text != "" || txtDebitNoteID.Text != "<Auto Generate>")
                {
                    tbl_accDebitNote detail = tbl_accDebitNote.Select(txtDebitNoteID.Text);
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

        #region Settings Panel Events
        public override void SettingsClick()
        {
            xSetting.Visible = true;
            xSetting.Focus();
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        #endregion

        private void uC_Supplier1_SupplierChanged()
        {
            uC_TotalCalc1.SetEnableTax(uC_Supplier1.IsNBTenable, uC_Supplier1.IsVATenable, uC_Supplier1.IsSVATenable, uC_Supplier1.Supplier_ID, "default", "default", uC_ExchangeRate1.ExchangeRate);
        }

        private void uC_ExchangeRate1_ExRateChanged()
        {
            uC_TotalCalc1.SetEnableTax(uC_Supplier1.IsNBTenable, uC_Supplier1.IsVATenable, uC_Supplier1.IsSVATenable, uC_Supplier1.Supplier_ID, "default", "default", uC_ExchangeRate1.ExchangeRate);
        }

        private void uC_TotalCalc1_DoubleEntryUpdataed(DataTable dt)
        {
            uC_DoubleEntry1.Refresh(dt);
        }

    }
}